using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Paper_ViewInspectionByTBC : System.Web.UI.Page
{
    PPR_InspectionByTBc objInspectionByTBc = null;
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
            objInspectionByTBc = new PPR_InspectionByTBc();
            objInspectionByTBc.LOITrId_I = 0;
            GrdLOI.DataSource = GetData();
            GrdLOI.DataBind();
        }
        catch { }

    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
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
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objInspectionByTBc = new PPR_InspectionByTBc();
        objInspectionByTBc.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
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
            //Label lblLOIDate = (Label)e.Row.FindControl("lblLOIDate");
            //DateTime dat = new DateTime();
            //dat = DateTime.Parse(lblLOIDate.Text);

            //lblLOIDate.Text = dat.ToString("dd/MM/yyyy");

        }
    }
    public DataSet GetData()
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR009_InspectionDetailShowDataNew", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mLOIId_I", 0);
        obDBAccess.addParam("mWorkPlanTrId_I", 0);
        obDBAccess.addParam("mPaperMstrTrId_I", 0);
        obDBAccess.addParam("mInspectionTrId_I", 0);
        obDBAccess.addParam("mType", 3);
        obDBAccess.addParam("mAcYear",ddlAcYear.SelectedItem.Text);
        return obDBAccess.records();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objInspectionByTBc = new PPR_InspectionByTBc();
           
            GrdLOI.DataSource = objInspectionByTBc.TBCSearchName(txtSearch.Text);
            GrdLOI.DataBind();
        }
        catch { }
    }
}