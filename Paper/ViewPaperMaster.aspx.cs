using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

public partial class Paper_ViewPaperMaster : System.Web.UI.Page
{
    PPR_PaperMaster ObjPaperMaster = null;
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
            ObjPaperMaster = new PPR_PaperMaster();
            ObjPaperMaster.PaperTrId_I = 0;
            GrdPaperMaster.DataSource = ObjPaperMaster.Select();
            GrdPaperMaster.DataBind();
        }
        catch { }

    }
    protected void GrdPaperMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjPaperMaster = new PPR_PaperMaster();
        ObjPaperMaster.Delete(Convert.ToInt32(GrdPaperMaster.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdPaperMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperMaster.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ObjPaperMaster = new PPR_PaperMaster();
            GrdPaperMaster.DataSource = ObjPaperMaster.SearchPaperName(txtSearch.Text);
            GrdPaperMaster.DataBind();
        }
        catch { }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow GV = (GridViewRow)lnk.NamingContainer;
        Label lblPaperTrId_I = (Label)GV.FindControl("lblPaperTrId_I");
        ObjPaperMaster = new PPR_PaperMaster();
        ObjPaperMaster.Delete(Convert.ToInt32(lblPaperTrId_I.Text));
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GridFillLoad();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCompletionList(string prefixText, int count)
    {


        prefixText = '%' + prefixText + '%';

        CommonFuction com = new CommonFuction();

        DataSet dt = com.FillDatasetByProc("call USP_Common_Search(1,'" + prefixText + "')");
        
        List<string> countryNames = new List<string>();
        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {

            countryNames.Add(dt.Tables[0].Rows[i]["Schemes"].ToString());
        }

        return countryNames;



    } 
}