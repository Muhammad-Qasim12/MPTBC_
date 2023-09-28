using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class CenterDepot_ViewPaperDetails : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = ""; double TotGrossWt = 0, TotNetWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            BindPrinterDDL();
           // GridFillLoad();
          
        }
    }
    public void GridFillLoad()
    {
        try
        {
            //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            //GrdLOI.DataSource = objPaperDispatchDetails.CDSearchNameChallan(txtSearch.Text);
            //GrdLOI.DataBind();
            //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            //GrdLOI.DataSource = objPaperDispatchDetails.PrinterDispDetailsFromDepot();
            //GrdLOI.DataBind();
            int PrinterID = 0;
            if (ddlPrinter.SelectedItem.Text == "All")
            {
                PrinterID = 0;
            }
            else
            {
                PrinterID = Convert.ToInt32(ddlPrinter.SelectedValue);
            }
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();
            dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0017_PaperDetailsPrinterCDSearch('" + txtSearch.Text + "'," + PrinterID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();
            //USP_PPR0014_PaperDispatchToPrinterCDSearchNew
        }
        catch { }

    }
    public void BindPrinterDDL()
    {
        PRI_PaperAllotment  obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ////////
       // objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "All");
    }
   
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
           
        }
        catch { }
    }

    protected void btnAddChallanDetailse_Click(object sender, EventArgs e)
    {
        try
        {
            System.Web.UI.HtmlControls.HtmlAnchor btnView = (System.Web.UI.HtmlControls.HtmlAnchor)sender;
            GridViewRow gv = (GridViewRow)btnView.NamingContainer;
            HiddenField hdnChallanno = (HiddenField)gv.FindControl("hdnChallanno");          
            obCommonFuction = new CommonFuction();
            DataTable dtt = obCommonFuction.FillTableByProc("SELECT * FROM tbl_paperallotment WHERE orderno='"+hdnChallanno.Value+"'");
            GrdChallanReel.DataSource = dtt;
            GrdChallanReel.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
        }
        catch { }
    }

    protected void GrdChallanReel_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
           // Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            try
            {
                TotNetWt = TotNetWt + double.Parse(lblNetWt.Text);
            }
            catch { TotNetWt = 0; }
           
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text);
            }
            catch { TotGrossWt = 0; }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");
            Label lblTotGrossWt = (Label)e.Row.FindControl("lblTotGrossWt");
            Label lblTS = (Label)e.Row.FindControl("lblTS");
            lblTotNetWt.Text = TotNetWt.ToString("0.000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
            
        }
    }

    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField hdnStatus = (HiddenField)e.Row.FindControl("hdnStatus");
            Panel pnl = (Panel)e.Row.FindControl("pnl");
            Panel pnlPrint = (Panel)e.Row.FindControl("pnlPrint");

            if (hdnStatus.Value == "0")
            {
                pnl.Visible = true;
                pnlPrint.Visible = false;
            }
            else if (hdnStatus.Value == "1")
            {
                pnl.Visible = false;
                pnlPrint.Visible = true;
            }
        }
    }
}