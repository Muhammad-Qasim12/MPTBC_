using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_VIEW_DPT008 : System.Web.UI.Page
{
    otherStockOpeningDetails obotherStockOpeningDetails = null;
    public APIProcedure api = new APIProcedure();
    //  CommonFuction obCommonFuction = null;
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
            
            obotherStockOpeningDetails = new otherStockOpeningDetails ();
            obotherStockOpeningDetails.DOtherStockID_I = 0;

            obotherStockOpeningDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
            GrdOtherStock.DataSource = obotherStockOpeningDetails.Select();
            GrdOtherStock.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdOtherStock_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obotherStockOpeningDetails = new otherStockOpeningDetails();
        obotherStockOpeningDetails.Delete(Convert.ToInt32(GrdOtherStock.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }
    protected void GrdOtherStock_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdOtherStock.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT008_OtherStockDetails.aspx");
    }
   
}