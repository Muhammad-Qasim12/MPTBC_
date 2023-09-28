using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Paper;

public partial class Paper_ViewTechnicalBid : System.Web.UI.Page
{
    CommonFuction objComm = new CommonFuction();
    PPR_TechnicalBid ObjTechnicalBid = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            ObjTechnicalBid = new PPR_TechnicalBid();
            GrdLabMaster.DataSource = objComm.FillDatasetByProc("call USP_ppr_TechniBidSearch('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Value + "',2)");//ObjTechnicalBid.Select();
            GrdLabMaster.DataBind();
        }
        catch { }

    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        { 
            ddlAcYear.DataSource = objComm.FillDatasetByProc("call ppr_GetAcYearAllTbl(2)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Enabled = false;
            //ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void GrdLabMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLabMaster.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
            //ObjTechnicalBid = new PPR_TechnicalBid();
            //GrdLabMaster.DataSource = objComm.FillDatasetByProc("call USP_ppr_TechniBidSearch('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Value + "',1)");
            //GrdLabMaster.DataBind();
        }
        catch { }
    }
    protected void GrdLabMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTenderId = (Label)e.Row.FindControl("lblTenderId");
            GridView grdPaperMill = (GridView)e.Row.FindControl("grdPaperMill");

            grdPaperMill.DataSource = objComm.FillDatasetByProc("call USP_ppr_TechniBidSearch('" + lblTenderId.Text + "','" + ddlAcYear.SelectedItem.Value + "',3)");//ObjTechnicalBid.Select();
            grdPaperMill.DataBind();
        }
    }
}