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

public partial class CenterDepot_ViewCentralDepotDispatchToPrinter : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            BindPrinterDDL();            
           HDN_fillload.Value = "-1"; //only show today's record at page load            
           GridFillLoad();
          
        }
    }

    //Session["PrierID_I"]

    protected void hrefSend_ServerClick(object sender, EventArgs e)
    {
        try
        {
            System.Web.UI.HtmlControls.HtmlAnchor o = (System.Web.UI.HtmlControls.HtmlAnchor)sender;
            GridViewRow gv = (GridViewRow)o.NamingContainer;
            string pk = GrdLOI.DataKeys[gv.RowIndex].Values[0].ToString();
            string status = obCommonFuction.FillScalarByProc("update ppr_paperprinterdispatch_m set sendStatus=1 where PrinterDisTranId='" + pk + "'; SELECT IFNULL(sendstatus,0)  FROM ppr_paperprinterdispatch_m WHERE PrinterDisTranId='" + pk + "';");
            if (status == "1")
            {
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Sent to Printer and HO successfully.');");
                Response.Write("</script>");
                GridFillLoad();
            }
        }
        catch { }
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

             if (HDN_fillload.Value == "-1")
            {
                PrinterID = -1;
            }

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();
            dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchToPrinterCDSearchNew('" + txtSearch.Text + "'," + PrinterID + ",'" + ddlAcYear.SelectedItem.Text + "',0)");
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
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
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
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Panel pnlEdit = (Panel)e.Row.FindControl("pnlEdit");
            if (HDNPriID.Value != "")
                pnlEdit.Visible = false;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            HDN_fillload.Value = "";
            GridFillLoad();
            //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            //GrdLOI.DataSource = objPaperDispatchDetails.CDSearchNameChallan(txtSearch.Text);
            //GrdLOI.DataBind();
        }
        catch { }
    }
}