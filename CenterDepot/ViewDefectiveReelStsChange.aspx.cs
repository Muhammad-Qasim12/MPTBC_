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
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;

public partial class ViewDefectiveReelStsChange : System.Web.UI.Page
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
            VendorFill();
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        //try
        //{
        int PrinterID = 0;
        if (ddlVendor.SelectedItem.Text == "All")
        {
            PrinterID = 0;
        }
        else
        {
            PrinterID = Convert.ToInt32(ddlVendor.SelectedValue);
        }
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtlNew(0," + PrinterID + ",'" + ddlAcYear.SelectedItem.Text + "',0,0,'" + txtSearch.Text + "','',10)");
            GrdLOI.DataBind();
        //}
        //catch { }

    }
    //public void BindPrinterDDL()
    //{
    //    PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
    //    obPRI_PaperAllotment.Printer_RedID_I = 0;
    //    DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
    //    ////////
    //    // objPaperDispatchDetails = new PPR_PaperDispatchDetails();
    //    ddlPrinter.DataSource = ds.Tables[0];
    //    ddlPrinter.DataTextField = "NameofPressHindi_V";
    //    ddlPrinter.DataValueField = "Printer_RedID_I";
    //    ddlPrinter.DataBind();
    //    ddlPrinter.Items.Insert(0, "All");
    //}
    public void VendorFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "All");
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
           // ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
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


        }
    }

    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        LinkButton lnkUpdate = (LinkButton)gv.FindControl("lnkUpdate");
        LinkButton lnkEdit = (LinkButton)gv.FindControl("lnkEdit");
        lnkUpdate.Visible = false;
        lnk.Visible = false;
        lnkEdit.Visible = true;
        
        Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
        Label lblNetWt = (Label)gv.FindControl("lblNetWt");
        TextBox txtNetWt = (TextBox)gv.FindControl("txtNetWt");
        TextBox txtTotalSheets = (TextBox)gv.FindControl("txtTotalSheets");
        lblTotalSheets.Visible = true;
        lblNetWt.Visible = true;
        txtNetWt.Visible = false;
        txtTotalSheets.Visible = false;
    }

    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        LinkButton lnkUpdate = (LinkButton)gv.FindControl("lnkUpdate"); 
        Label lblPaperCategory = (Label)gv.FindControl("lblPaperCategory");
        Label lblid = (Label)gv.FindControl("lblid"); 
        TextBox txtNetWt = (TextBox)gv.FindControl("txtNetWt");
        TextBox txtTotalSheets = (TextBox)gv.FindControl("txtTotalSheets");

        obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ProcDefectiveReelDtl('" + lblid.Text + "',0,0,'" + txtNetWt.Text + "','" + txtTotalSheets.Text + "',0,'" + lblPaperCategory.Text + "',1)");
        GridFillLoad();

    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        LinkButton lnkUpdate = (LinkButton)gv.FindControl("lnkUpdate");
        LinkButton lnkCancel = (LinkButton)gv.FindControl("lnkCancel");
        Label lblPaperCategory = (Label)gv.FindControl("lblPaperCategory");
        Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
        Label lblNetWt = (Label)gv.FindControl("lblNetWt");
        TextBox txtNetWt = (TextBox)gv.FindControl("txtNetWt");
        TextBox txtTotalSheets = (TextBox)gv.FindControl("txtTotalSheets");
        if (lblPaperCategory.Text == "Sheet")
        {
            lblTotalSheets.Visible = false;
            txtTotalSheets.Visible = true;
        }

        lblNetWt.Visible = false;
        txtNetWt.Visible = true;
        lnkUpdate.Visible = true;
        lnkCancel.Visible = true;
        lnk.Visible = false;

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
        }
        catch { }
    }
}