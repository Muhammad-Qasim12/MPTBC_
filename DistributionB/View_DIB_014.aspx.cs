using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;

public partial class Paper_ViewTenderEvalution : System.Web.UI.Page
{

    InsuranceTenderInfo ObjTenderInfo = null;
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
            ObjTenderInfo = new InsuranceTenderInfo();
            ObjTenderInfo.TenderTrId_I = 0;
            GrdTenderInfo.DataSource = ObjTenderInfo.Select();
            GrdTenderInfo.DataBind();
        }
        catch { }

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
            ObjTenderInfo = new  InsuranceTenderInfo();
            ObjTenderInfo.WorkName_V = txtSearch.Text;
            GrdTenderInfo.DataSource = ObjTenderInfo.TenderNameSearch();
            GrdTenderInfo.DataBind();
        }
        catch { }
    }
}