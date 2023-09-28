using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Paper_ViewPaperMillInfo : System.Web.UI.Page
{
    PPR_VendorMaster objVendorMaster = null; 
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
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
            objVendorMaster = new PPR_VendorMaster();
            objVendorMaster.PaperVendorTrId_I = 0;
            GrdVendorMaster.DataSource = objVendorMaster.Select();
            GrdVendorMaster.DataBind();
        }
        catch { }

    }
    protected void GrdVendorMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objVendorMaster = new PPR_VendorMaster();
        objVendorMaster.Delete(Convert.ToInt32(GrdVendorMaster.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdVendorMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdVendorMaster.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdVendorMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRegistrationDate = (Label)e.Row.FindControl("lblRegistrationDate");
            DateTime dat = new DateTime();
            dat = DateTime.Parse(lblRegistrationDate.Text);

            lblRegistrationDate.Text = dat.ToString("dd/MM/yyyy");

        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            objVendorMaster = new PPR_VendorMaster();
            objVendorMaster.PaperVendorName_V = txtSearch.Text;
            GrdVendorMaster.DataSource = objVendorMaster.PaperVendorSearchName();
            GrdVendorMaster.DataBind();
        }
        catch { }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow GV = (GridViewRow)lnk.NamingContainer;
        Label lblPaperVendorTrId_I = (Label)GV.FindControl("lblPaperVendorTrId_I");
        objVendorMaster = new PPR_VendorMaster();
        objVendorMaster.Delete(Convert.ToInt32(lblPaperVendorTrId_I.Text));
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GridFillLoad();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<string> GetCompletionList(string prefixText, int count)
    {
        
        prefixText = '%' + prefixText + '%';

        CommonFuction com = new CommonFuction();

        DataSet dt = com.FillDatasetByProc("call USP_Common_Search(2,'" + prefixText + "')");

        List<string> countryNames = new List<string>();
        for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
        {

            countryNames.Add(dt.Tables[0].Rows[i]["Schemes"].ToString());
        }
        return countryNames;        
    } 
}