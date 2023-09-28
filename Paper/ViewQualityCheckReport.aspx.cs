using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Paper_ViewQualityCheckReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    PPR_LabInspection objLabInspection = null;
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

            DataSet ds = new DataSet();
            objLabInspection = new PPR_LabInspection();
            objLabInspection.LOITrId_I = 0;
            //GrdLabInspection.DataSource = objLabInspection.Select();
            //GrdLabInspection.DataBind();
            ds = obCommonFuction.FillDatasetByProc("call USP_PPR0010_LabInspectionSearchName('" + txtSearch.Text + "','" + ddlAcYear.SelectedItem.Text + "')");
            GrdLabInspection.DataSource = ds.Tables[0];
            GrdLabInspection.DataBind();
        }
        catch { }

    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            //DataSet ds = new DataSet();
            //ds = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            //ddlAcYear.DataSource = ds.Tables[0];
            //ddlAcYear.DataTextField = "AcYear";
            //ddlAcYear.DataBind();

            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            
        }
        catch { }
    }
    protected void GrdLabInspection_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objLabInspection = new PPR_LabInspection();
        objLabInspection.Delete(Convert.ToInt32(GrdLabInspection.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdLabInspection_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLabInspection.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdLabInspection_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dtL = new DateTime();
            Label lblSampleReceiveDate_D = (Label)e.Row.FindControl("lblSampleReceiveDate_D");
            dtL = DateTime.Parse(lblSampleReceiveDate_D.Text);
            lblSampleReceiveDate_D.Text = dtL.ToString("dd/MM/yyyy");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            GridFillLoad();
            //objLabInspection = new PPR_LabInspection();            
            //GrdLabInspection.DataSource = objLabInspection.LabInspectionSearchName(txtSearch.Text);
            //GrdLabInspection.DataBind();
        }
        catch { }

    }
}