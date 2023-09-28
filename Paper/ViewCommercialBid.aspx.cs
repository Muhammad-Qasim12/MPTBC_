using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Paper_ViewCommercialBid : System.Web.UI.Page
{

    PPR_TenderInfo ObjTenderInfo = null;
    // 
    DataSet ds;
    CommonFuction objComm = new CommonFuction();
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
            ObjTenderInfo = new PPR_TenderInfo();
            ObjTenderInfo.TenderTrId_I = 0;
            //ds = objComm.FillDatasetByProc("call USP_PPR004_TenderInfoLoad(0,'" + ddlAcYear.SelectedItem.Value + "')");
            ds = objComm.FillDatasetByProc("call USP_ppr_TechniBidSearch('"+txtSearch.Text+"','" + ddlAcYear.SelectedItem.Value + "',7)"); 
            GrdTenderInfo.DataSource = ds.Tables[0]; //ObjTenderInfo.Select();                  
            GrdTenderInfo.DataBind();
        }
        catch { }

    }
    protected void GrdTenderInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjTenderInfo = new PPR_TenderInfo();
        ObjTenderInfo.Delete(Convert.ToInt32(GrdTenderInfo.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdTenderInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTenderInfo.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdTenderInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dtL = new DateTime();
            Label lblTenderSubmissionDate_D = (Label)e.Row.FindControl("lblTenderSubmissionDate_D");
            dtL = DateTime.Parse(lblTenderSubmissionDate_D.Text);
            lblTenderSubmissionDate_D.Text = dtL.ToString("dd/MM/yyyy");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
            //ObjTenderInfo = new PPR_TenderInfo();
            //ObjTenderInfo.WorkName_V = txtSearch.Text;
            //ds = objComm.FillDatasetByProc("call USP_PPR004_TenderInfoSearchName('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Value + "')");
            //GrdTenderInfo.DataSource = ds.Tables[0]; //ObjTenderInfo.TenderNameSearch();
            //GrdTenderInfo.DataBind();
        }
        catch { }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {


            DataSet ds = objComm.FillDatasetByProc("call USP_ADM015_AcadmicYear_Active(0)");
            ddlAcYear.DataSource = objComm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataValueField = "AcYear";
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.SelectedValue = ds.Tables[0].Rows[0][0].ToString();

            ddlAcYear.Enabled = false;
            
            //ds = objComm.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            //ddlAcYear.DataSource = ds.Tables[0];
            //ddlAcYear.DataTextField = "AcYear";
            //ddlAcYear.DataBind();
            //ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
}