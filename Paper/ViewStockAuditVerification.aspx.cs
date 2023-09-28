using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using System.Data;
public partial class Paper_ViewStockAuditVerification : System.Web.UI.Page
{
    PPR_StockAuditAndVerification objStockAuditAndVerification = null;
    CommonFuction obCommonFuction = new CommonFuction();
    DataSet ds = new DataSet();
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
            //objStockAuditAndVerification = new PPR_StockAuditAndVerification();
            //objStockAuditAndVerification.LOITrId_I = 0;
            //GrdLOI.DataSource = objStockAuditAndVerification.Select();
            //GrdLOI.DataBind();
            DataSet ds1 = new DataSet();
            ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0017_PaperStockAuditAndVerifiSearchName('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Text + "')");
            GrdLOI.DataSource = ds1.Tables[0];
            GrdLOI.DataBind();
        }
        catch { }

    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objStockAuditAndVerification = new PPR_StockAuditAndVerification();
        objStockAuditAndVerification.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            //DataSet ds1 = new DataSet();
            //ds1 = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            //ddlAcYear.DataSource = ds1.Tables[0];
            //ddlAcYear.DataTextField = "AcYear";
            //ddlAcYear.DataBind();
            //   ddlAcYear.Items.Insert(0, "Select");


            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
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
            //Label lblLOIDate = (Label)e.Row.FindControl("lblLOIDate");
            //DateTime dat = new DateTime();
            //dat = DateTime.Parse(lblLOIDate.Text);

            //lblLOIDate.Text = dat.ToString("dd/MM/yyyy");

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //objStockAuditAndVerification = new PPR_StockAuditAndVerification();            
            //GrdLOI.DataSource = objStockAuditAndVerification.StockSearchName(txtSearch.Text);
            //GrdLOI.DataBind();
              DataSet ds1 = new DataSet();
              ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0017_PaperStockAuditAndVerifiSearchName('"+txtSearch.Text+"','"+ddlAcYear.SelectedItem.Text+"')");
              GrdLOI.DataSource = ds1.Tables[0];
              GrdLOI.DataBind();
        }
        catch { }

    }
}