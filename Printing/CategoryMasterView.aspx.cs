using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_CategoryMasterView : System.Web.UI.Page
{
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_CategoryMaster obPRI_CategoryMaster = null;
    CommonFuction obCommonFuction = null;
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    public void FillData()
    {
        try
        {
            obPRI_CategoryMaster = new PRI_CategoryMaster();
            obPRI_CategoryMaster.CatID_I = 0;
            obPRI_CategoryMaster.CatID_I = Convert.ToInt32(Session["CatID_I"]);
            GrdCategoryDetails.DataSource = obPRI_CategoryMaster.Select();
            GrdCategoryDetails.DataBind();

        }
        catch
        {
        }
        finally
        {
            obPRI_CategoryMaster = null;
        }
    }
    protected void GrdCategoryDetails_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            string str = GrdCategoryDetails.DataKeys[e.RowIndex].Value.ToString();
            //obPRI_CategoryMaster.Delete(Convert.ToInt32(str));
            m.ShowMessage("d");
            FillData();
        }
        catch (Exception ex)
        {
            m.ShowOtherMessage("e", Convert.ToString(ex.Message));
        }
    }
    protected void GrdCategoryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdCategoryDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("CategoryMas.aspx");
    }

}