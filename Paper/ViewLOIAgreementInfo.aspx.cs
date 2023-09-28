using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Paper_ViewLOIAgreementInfo : System.Web.UI.Page
{
    CommonFuction objComm = new CommonFuction();
    PPR_LOIDetails objLOIDetails = null;
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
            GrdLOI.DataSource = objComm.FillDatasetByProc("Call Usp_pprLOISearchDetails('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Text + "',0)");//objLOIDetails.Select();
            GrdLOI.DataBind();
        }
        catch { }

    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objLOIDetails = new PPR_LOIDetails();
        objLOIDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
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
            Label lblLOIDate = (Label)e.Row.FindControl("lblLOIDate");
            DateTime dat = new DateTime();
            dat = DateTime.Parse(lblLOIDate.Text);

            lblLOIDate.Text = dat.ToString("dd/MM/yyyy");

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
            //objLOIDetails = new PPR_LOIDetails();
            //objLOIDetails.LOINo_V =txtSearch.Text;
            //GrdLOI.DataSource = objComm.FillDatasetByProc("Call Usp_pprLOISearchDetails('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Text + "',1)"); //objLOIDetails.SearchLOIName();
            //GrdLOI.DataBind();
        }
        catch { }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        { 
            ddlAcYear.DataSource = objComm.FillDatasetByProc("call ppr_GetAcYearAllTbl(3)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Enabled = false;
            
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
}