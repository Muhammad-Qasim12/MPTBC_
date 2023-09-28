using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Paper_ViewInspectionByTBC : System.Web.UI.Page
{
    PPR_InspectionByTBc objInspectionByTBc = null;
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
            GrdLOI.DataSource = objInspectionByTBc.Select();
            GrdLOI.DataBind();
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