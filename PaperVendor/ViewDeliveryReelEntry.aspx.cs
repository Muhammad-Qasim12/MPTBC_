using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class PaperVendor_ViewDeliveryReelEntry : System.Web.UI.Page
{
    DataSet ds;
    ppr_DeliveryChallan objDeliveryChallan = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string PaperVendorTrId_I = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objDeliveryChallan = new ppr_DeliveryChallan();
            objDeliveryChallan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
            //GrdLOI.DataSource = objDeliveryChallan.ShowAllData();
            GrdLOI.DataSource = obCommonFuction.FillDatasetByProc("call USP_PPR0019_PaperDeliveryReelShowData_ShowAll('" + objDeliveryChallan.PaperVendorTrId_I + "',0,0,0,0,0,0,'" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataBind();
        }
        catch { }

    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objDeliveryChallan = new ppr_DeliveryChallan();
        //objDeliveryChallan.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
       // GridFillLoad();
        DataSet ds1 = new DataSet();
        objDeliveryChallan = new ppr_DeliveryChallan();
        objDeliveryChallan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
        objDeliveryChallan.ChallanNo = txtSearch.Text;
        //GrdLOI.DataSource = objDeliveryChallan.SearchName();
        ds1 = obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelSearchNameNew(" + objDeliveryChallan.PaperVendorTrId_I + ",'" + objDeliveryChallan.ChallanNo + "','" + ddlAcYear.SelectedItem.Text + "')");
        GrdLOI.DataSource = ds1.Tables[0];
        GrdLOI.DataBind();
    }
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds1 = new DataSet();
            objDeliveryChallan = new ppr_DeliveryChallan();
            objDeliveryChallan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
            objDeliveryChallan.ChallanNo = txtSearch.Text;
            //GrdLOI.DataSource = objDeliveryChallan.SearchName();
            ds1 = obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelSearchNameNew(" + objDeliveryChallan.PaperVendorTrId_I + ",'" + objDeliveryChallan.ChallanNo + "','" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataSource = ds1.Tables[0];
            GrdLOI.DataBind();
        }
        catch { }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(2)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
           // ddlAcYear.SelectedValue = obCommonFuction.GetFinYearNew();
            //ddlAcYear.Enabled = false;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
}