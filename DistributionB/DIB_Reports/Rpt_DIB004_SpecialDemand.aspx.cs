using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;
using System.Data;
using System.Globalization;
using System.IO;

public partial class DistributionB_DIB_Reports_Rpt_DIB004_SpecialDemand : System.Web.UI.Page
{
    SpecialBookDemand obSpecialBookDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillData();
                //obPrinterProof = new PrinterProof();
                //obPrinterProof.QueryType = 0;
                //ddlPrinter.DataSource = obPrinterProof.FillRPT();
                //ddlPrinter.DataValueField = "Printer_RedID_I";
                //ddlPrinter.DataTextField = "NameofPress_V";
                //ddlPrinter.DataBind();
                //ddlPrinter.Items.Insert(0, "Select..");
            }
            catch
            { }
            finally { obSpecialBookDemand = null; }
        }
    }

    public void FillData()
    {
        try
        {
            obSpecialBookDemand = new SpecialBookDemand();
            obSpecialBookDemand.TransID = 0;
            obSpecialBookDemand.DateFrom = Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy-MM-dd");
            obSpecialBookDemand.DateTo = Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy-MM-dd");

            DataTable dt = obSpecialBookDemand.SelectRPT().Tables[0];
            if (dt.Rows.Count > 0)
            {
                tdPrintContent.Visible = true;
                lblFromDate.Text = txtFromDate.Text;
                lblToDate.Text = txtToDate.Text;
                lblAcademicYear.Text = obCommonFuction.GetFinYear();
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
                GrdLetterInfo.DataSource = dt;
                GrdLetterInfo.DataBind();
            }
            else
            {
                tdPrintContent.Visible = false;
            }
        }
        catch
        {
        }
        finally
        {
            obSpecialBookDemand = null;
        }
    }
    private void CalculateTotal()
    {
        //double TotalAmount = 0;
        //for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
        //{
        //    TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[7].Text);
        //}

        //lblTotalAmount.Text = TotalAmount.ToString("N");
    }
    protected void GrdLetterInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //LinkButton lnkSender = (LinkButton)sender;
            //GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
            if (e.Row.RowIndex >= 0)
            {
                Label lblSpecialBookDemandTrno_I = (Label)e.Row.FindControl("lblSpecialBookDemandTrno_I");
                GridView grdSelectedTitle = (GridView)e.Row.FindControl("grdSelectedTitle");
                obSpecialBookDemand = new  SpecialBookDemand();
                obSpecialBookDemand.TransID = -9;
                obSpecialBookDemand.QueryParameterValue = Convert.ToInt32(lblSpecialBookDemandTrno_I.Text);
                var data = obSpecialBookDemand.Select();
                grdSelectedTitle.DataSource = data;
                grdSelectedTitle.DataBind();
                // CalculateTotal();
            }
        }
        catch
        {
        }
        finally
        {
            //obFreeBooksDistribution = null;
        }
    }
    protected void lnBtnViewPrinterProof_Click(object sender, EventArgs e)
    {
        ////Messages.Style.Add("display", "block");
        ////fadeDiv.Style.Add("display", "block");

        //try
        //{
        //    LinkButton lnkSender = (LinkButton)sender;
        //    GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        //    Label lblSpecialBookDemandTrno_I = (Label)gv.FindControl("lblSpecialBookDemandTrno_I");

        //    obSpecialBookDemand = new SpecialBookDemand();
        //    obSpecialBookDemand.TransID = -1;
        //    obSpecialBookDemand.QueryParameterValue = Convert.ToInt32(lblSpecialBookDemandTrno_I.Text);
        //    var data = obSpecialBookDemand.SelectRPT();
        //    grdSelectedTitle.DataSource = data;
        //    grdSelectedTitle.DataBind();
        //    CalculateTotal();
        //}
        //catch
        //{
        //}
        //finally
        //{
        //    obSpecialBookDemand = null;
        //}
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        //Messages.Style.Add("display", "none");
        //fadeDiv.Style.Add("display", "none");
    }

    protected void GrdViewPrinterProof_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLetterInfo.PageIndex = e.NewPageIndex;
        FillData();
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    //FillGrid();
    //    if (GrdLetterInfo.Rows.Count > 0)
    //    {
    //        Class1 cls = new Class1();
    //        cls.Export("DemandInformation.xls", GrdLetterInfo, "अन्य पाठ्य सामग्री की मांग जिला - " );
    //    }
    //    else
    //    {
    //        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('इस जिले की कोई जानकारी उपलब्ध नहीं है..');</script>");
    //    }
    //}
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillData();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ////FillGrid();
        //Class1 cls = new Class1();
        //cls.Export("RSK_FreeBooksSupplyInformation.xls", GrdLetterInfo, "रा०शि०के से नि:शुल्क पुस्तकों की मांग की स्थिति");
        ExportToExcell();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "SpecialDemandFromOfficers.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
}