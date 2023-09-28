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

public partial class DistributionB_DIB_Reports_Rpt_DIB001_FreshBooksDemand : System.Web.UI.Page
{
    FreeBooksDistribution obFreeBooksDistribution = null;
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
               // FillData();
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
            finally { obFreeBooksDistribution = null; }
        }
    }

    public void FillData()
    {
        try
        {
            obFreeBooksDistribution = new FreeBooksDistribution();
            obFreeBooksDistribution.TransID = 0;
            obFreeBooksDistribution.DateFrom = Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy-MM-dd");
            obFreeBooksDistribution.DateTo = Convert.ToDateTime(txtToDate.Text, cult).ToString("yyyy-MM-dd");

            DataTable dt = obFreeBooksDistribution.SelectRPT().Tables[0];
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
            obFreeBooksDistribution = null;
        }
    }
    private void CalculateTotal()
    {
        //double TotalAmount = 0;
        //for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
        //{
        //    TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[8].Text);
        //}

        //lblTotalAmount.Text = TotalAmount.ToString("N");
    }

    protected void lnBtnViewPrinterProof_Click(object sender, EventArgs e)
    {
        //Messages.Style.Add("display", "block");
        //fadeDiv.Style.Add("display", "block");

        //try
        //{
        //    LinkButton lnkSender = (LinkButton)sender;
        //    GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        //    Label lblFreeBooksDistributionID_I = (Label)gv.FindControl("lblFreeBooksDistributionID_I");

        //    obFreeBooksDistribution = new FreeBooksDistribution();
        //    obFreeBooksDistribution.TransID = -9;
        //    obFreeBooksDistribution.QueryParameterValue = Convert.ToInt32(lblFreeBooksDistributionID_I.Text);
        //    var data = obFreeBooksDistribution.Select();
        //    grdSelectedTitle.DataSource = data;
        //    grdSelectedTitle.DataBind();
        //    CalculateTotal();
        //}
        //catch
        //{
        //}
        //finally
        //{
        //    obFreeBooksDistribution = null;
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

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ////FillGrid();
        //Class1 cls = new Class1();
        //cls.Export("RSK_FreeBooksSupplyInformation.xls", GrdLetterInfo, "रा०शि०के से नि:शुल्क पुस्तकों की मांग की स्थिति");
        ExportToExcell();
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Free_Distribution.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    protected void GrdLetterInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            //LinkButton lnkSender = (LinkButton)sender;
            //GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
            if (e.Row.RowIndex >= 0)
            {
                Label lblFreeBooksDistributionID_I = (Label)e.Row.FindControl("lblFreeBooksDistributionID_I");
                GridView grdSelectedTitle = (GridView)e.Row.FindControl("grdSelectedTitle");
                obFreeBooksDistribution = new FreeBooksDistribution();
                obFreeBooksDistribution.TransID = -9;
                obFreeBooksDistribution.QueryParameterValue = Convert.ToInt32(lblFreeBooksDistributionID_I.Text);
                var data = obFreeBooksDistribution.Select();
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
        FillData();
    }

     
}