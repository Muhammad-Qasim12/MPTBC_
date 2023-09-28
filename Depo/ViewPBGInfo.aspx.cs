using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Paper_ViewPBGInfo : System.Web.UI.Page
{

    Depo_VGINFO objPBGInfo = null;
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
            objPBGInfo = new Depo_VGINFO(Convert.ToInt32(Session["UserID"]));
            objPBGInfo.LOITrId_I = 0;
            GrdPBGInfo.DataSource = objPBGInfo.Select();
            GrdPBGInfo.DataBind();
        }
        catch { }

    }
    protected void GrdPBGInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objPBGInfo = new Depo_VGINFO(Convert.ToInt32(Session["UserID"]));
        objPBGInfo.Delete(Convert.ToInt32(GrdPBGInfo.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdPBGInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPBGInfo.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdPBGInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dtL = new DateTime();
            Label lblTenderSubmissionDate_D = (Label)e.Row.FindControl("lblPBGDate_D");
            dtL = DateTime.Parse(lblTenderSubmissionDate_D.Text);
            lblTenderSubmissionDate_D.Text = dtL.ToString("dd/MM/yyyy");
        }
    }
}