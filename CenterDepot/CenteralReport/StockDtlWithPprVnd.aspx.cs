using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using MPTBCBussinessLayer.Paper;
using System.IO;
using MPTBCBussinessLayer;

public partial class StockDtlWithPprVnd : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    double TotQty = 0, TotDispatch = 0, TotRema = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        //  CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    protected void ddlPaperSize_Init(object sender, EventArgs e)
    {
        ddlPaperSize.DataSource = string.Empty;
        ddlPaperSize.DataBind();
        ddlPaperSize.Items.Insert(0, "All");
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaperType.SelectedItem.Text != "All")
        {
            ddlPaperSize.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0022_StockReport(" + ddlPaperType.SelectedItem.Value + ",0,0,4)");
            ddlPaperSize.DataTextField = "CoverInformation";
            ddlPaperSize.DataValueField = "PaperMstrTrId_I";
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "All");
        }
        else
        {
            ddlPaperSize.DataSource = string.Empty;
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "All");
        }
    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PPR_RDLCData objReports = new PPR_RDLCData();
        ddlPaperType.DataSource = objReports.PaperTypeWithStk();
        ddlPaperType.DataTextField = "PaperType";
        ddlPaperType.DataValueField = "PaperType_I";
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "All");
    }
    protected void ddlYear_Init(object sender, EventArgs e)
    {
        Dis_TentativeDemandHistory objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlYear.DataSource = objTentativeDemandHistory.TentativeDemandAcadminYearFill();
        ddlYear.DataTextField = "AcYear";
        ddlYear.DataValueField = "AcYear";
        ddlYear.DataBind();
        ddlYear.Items.Insert(0, "Select");
        try
        {
            ddlYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
        }
        catch { }
    }
    public void venderFill()
    {

        ddlVendor.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtl(0,0,0,0,0,0,'',6)");
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "All");
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }

    public void GridFillLoad()
    {
        try
        {
            string papertype = ddlPaperType.SelectedItem.Value.ToString().Replace("All", "0");
            string papersize = ddlPaperSize.SelectedItem.Value.ToString().Replace("All", "0");
            lblYear.Text = ddlYear.SelectedItem.Text;
            lblTitle.Text = " पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " पेपर का प्रकार : " + ddlPaperType.SelectedItem.Text.Replace("All", "सभी") + ", " + " पेपर का आकार : " + ddlPaperSize.SelectedItem.Text.Replace("All", "सभी");
            lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();

            GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcStockDtlWithPaperMill(" + papertype + "," + papersize + "," + ddlVendor.SelectedItem.Value.ToString().Replace("All", "0") + ",'" + ddlYear.SelectedItem.Text + "',0)");
            GrdLOI.DataBind();

            //if (Convert.ToInt32(papersize) > 0)
            //{
            //    GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcStockDtlWithPaperMill(" + papertype + "," + papersize + "," + ddlVendor.SelectedItem.Value.ToString().Replace("All", "0") + ",'" + ddlYear.SelectedItem.Text + "',0)");
            //    GrdLOI.DataBind();
            //}
            //else
            //{
            //    DataTable dtt = obCommonFuction.FillDatasetByProc("Call USP_GetPprStkLastYearDetails('" + ddlYear.SelectedItem.Text + "'," + papertype + ")").Tables[0];
            //    if (dtt.Rows.Count > 0)
            //    {
            //        for (int i = 0; i <= dtt.Rows.Count - 1; i++)
            //        {
            //            papersize = dtt.Rows[i]["0"].ToString();
            //        }
            //    }
            //}
            
            TotQty = 0; TotDispatch = 0; TotRema = 0;
        }
        catch { }

    }

    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    protected void GvReelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       // TotQty = 0; TotDispatch = 0; TotRema=0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //TotQty = 0; TotDispatch = 0; TotRema = 0;
            Label lblTotQty = (Label)e.Row.FindControl("lblTotQty");
            Label lblTotDebitQty = (Label)e.Row.FindControl("lblTotDebitQty");
            Label lblRemainingQty = (Label)e.Row.FindControl("lblRemainingQty");
            try
            {
                TotQty = TotQty + double.Parse(lblTotQty.Text);
            }
            catch { }
            try
            {
                TotDispatch = TotDispatch + double.Parse(lblTotDebitQty.Text);
            }
            catch { }
            try
            {
                TotRema = TotRema + double.Parse(lblRemainingQty.Text);
            }
            catch { }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFTotQty = (Label)e.Row.FindControl("lblFTotQty");
            Label lblFTotDebitQty = (Label)e.Row.FindControl("lblFTotDebitQty");
            Label lblFRemainingQty = (Label)e.Row.FindControl("lblFRemainingQty");
            lblFTotQty.Text = TotQty.ToString("0.000");
            lblFTotDebitQty.Text = TotDispatch.ToString("0.000");
            lblFRemainingQty.Text = TotRema.ToString("0.000");
        }
    }

    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView GvReelDetails = (GridView)e.Row.FindControl("GvReelDetails");
            Label lblPaperType_I = (Label)e.Row.FindControl("lblPaperType_I");
            Label lblPaperMstrTrId_I = (Label)e.Row.FindControl("lblPaperMstrTrId_I");
            Label lblPaperVendorTrId_I = (Label)e.Row.FindControl("lblPaperVendorTrId_I");

            GvReelDetails.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcStockDtlWithPaperMill(" + lblPaperType_I.Text + "," + lblPaperMstrTrId_I.Text + "," + ddlVendor.SelectedItem.Value.ToString().Replace("All", "0") + ",'" + ddlYear.SelectedItem.Text + "',1)");
            GvReelDetails.DataBind();
            TotQty = 0; TotDispatch = 0; TotRema = 0;
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
         
                string papertype = ddlPaperType.SelectedItem.Value.ToString().Replace("All", "0");
                string papersize = ddlPaperSize.SelectedItem.Value.ToString().Replace("All", "0");
                lblYear.Text = ddlYear.SelectedItem.Text;
                lblTitle.Text = " पेपर मिल का नाम  : " + ddlVendor.SelectedItem.Text.Replace("All", "सभी") + ", " + " पेपर का प्रकार : " + ddlPaperType.SelectedItem.Text.Replace("All", "सभी") + ", " + " पेपर का आकार : " + ddlPaperSize.SelectedItem.Text.Replace("All", "सभी");
                lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("MMM dd, yyyy");
                objPaperDispatchDetails = new PPR_PaperDispatchDetails();

                //GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcStockDtlWithPaperMill(" + papertype + "," + papersize + "," + ddlVendor.SelectedItem.Value.ToString().Replace("All", "0") + ",'" + ddlYear.SelectedItem.Text + "',1)");
                GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcStockDtlWithPaperMill(" + papertype + "," + papersize + "," + ddlVendor.SelectedItem.Value.ToString().Replace("All", "0") + ",'" + ddlYear.SelectedItem.Text + "',0)");
                GrdLOI.DataBind();
           
        }
        catch { }
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "StockDtlWithPprVnd.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
}