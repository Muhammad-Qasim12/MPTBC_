using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Academic;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;

public partial class Printing_Reports_Rpt_ACD005_PrinterPrfReport : System.Web.UI.Page
{
    PrinterProof obPrinterProof = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != null)
        {
            if (!IsPostBack)
            {
                try
                {
                    PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
                    PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
                    DataSet ds = new DataSet();
                    ds = PriReg.GetPrinterDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                        lblPrinter.Text = ds.Tables[0].Rows[0]["NameOfPress_V"].ToString();
                    }

                    obCommonFuction = new CommonFuction();
                    DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                    DdlACYear.DataValueField = "AcYear";
                    DdlACYear.DataTextField = "AcYear";
                    DdlACYear.DataBind();

                    obPrinterProof = new PrinterProof();
                    obPrinterProof.QueryType = -1;
                    ddlPrinter.DataSource = obPrinterProof.FillRPT();
                    ddlPrinter.DataValueField = "Printer_RedID_I";
                    ddlPrinter.DataTextField = "NameofPress_V";
                    ddlPrinter.DataBind();
                    ddlPrinter.Items.Insert(0, "Select..");
                    try
                    {
                        ddlPrinter.Items.FindByValue(Session["PrierID_I"].ToString()).Selected = true;
                        ddlPrinter.Enabled = false;
                    }
                    catch { }
                    try
                    {
                        FillData();
                    }
                    catch
                    { }
                    finally { }
                }
                catch
                { }
                finally { obPrinterProof = null; }
            }
        }
        else
        {
            Response.Redirect("../../Login.aspx");
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            FillData();
        }
        catch { }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        //FillGrid();
        Class1 cls = new Class1();
        cls.Export("PrinterProofVerification.xls", GrdViewDetails, "पाठ्यपुस्तको के मुद्रण हेतु सामग्री प्रदाय की जानकारी");
    }
    public void FillData()
    {
        try
        {
            obPrinterProof = new PrinterProof();
            int? Printer_RedID = null;

            if (ddlPrinter.SelectedValue != "0" && ddlPrinter.SelectedValue != "Select..")
            {
                Printer_RedID = Convert.ToInt32(ddlPrinter.SelectedValue);
            }

            obPrinterProof.QueryType = 0;
            obPrinterProof.Printer_RedID_I = Convert.ToInt32(Printer_RedID);
           //DataSet ds = obPrinterProof.FillRPT();
            obCommonFuction = new CommonFuction();
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_ACD005_PrinterProofLoadRPT_rptNew(0," + Session["PrierID_I"].ToString() + "," + obPrinterProof.WorkOrderID_I + ",'" + DdlACYear.SelectedItem.Text + "')");
            GrdViewPrinterProof.DataSource = ds;
            GrdViewPrinterProof.DataBind();
           
        }
        catch
        {
        }
        finally
        {
            obPrinterProof = null;
        }
    }

    protected void lnBtnViewPrinterProof_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            LinkButton lnkSender = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
            Label lblPrinter_RedID_I = (Label)gv.FindControl("lblPrinter_RedID_I");
            Label lblWorkOrderID_I = (Label)gv.FindControl("lblWorkOrderID_I");

            obPrinterProof = new PrinterProof();
            obPrinterProof.QueryType = 1;
            obPrinterProof.Printer_RedID_I = Convert.ToInt32(lblPrinter_RedID_I.Text);
            obPrinterProof.WorkOrderID_I = Convert.ToInt32(lblWorkOrderID_I.Text);
            var data = obPrinterProof.FillRPT();
            GrdViewDetails.DataSource = data;
            GrdViewDetails.DataBind();

            lblPrinter_RedID.Text = Convert.ToString(data.Tables[0].Rows[0]["Jobcode_V"]);
            lblWorkOrderID.Text = Convert.ToString(data.Tables[0].Rows[0]["NameofPress_V"]);
        }
        catch
        {
        }
        finally
        {
            obPrinterProof = null;
        }
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }

    protected void GrdViewPrinterProof_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewPrinterProof.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FillData();
        }
        catch
        { }
        finally { }
    }

    protected void GrdViewDetails_Rowcreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView GrdViewDetails = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "कक्षा";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "शीर्षक का नाम";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "ग्रुप";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "पाण्डुलिपि प्रदान ";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = " प्रूफ प्राप्ति";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "  RSK/TBC को प्रूफ भेजना";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "  प्रूफ अनुमोदन";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = " मुद्रण आदेश जारी करना";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "मुद्रण सामाग्री की वापसी";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            GrdViewDetails.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }
    protected void GrdViewDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
        }
    }
}