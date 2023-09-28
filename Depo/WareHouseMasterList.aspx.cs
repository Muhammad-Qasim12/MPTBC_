using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_WareHouseMasterList : System.Web.UI.Page
{
   // CultureInfo cult = new CultureInfo("gu-IN", true);
    WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = null;
    public APIProcedure api = new APIProcedure();
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
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
           DataSet ds = obWareHouseMaster.Select();
            GrdWarehouse.DataSource = obWareHouseMaster.Select();
            GrdWarehouse.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdWarehouse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obWareHouseMaster = new WareHouseMaster();
        obWareHouseMaster.Delete(Convert.ToInt32(GrdWarehouse.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }
    protected void GrdWarehouse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdWarehouse.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("WareHouseMaster.aspx");
    }
    protected void GrdWarehouse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.Delete(Convert.ToInt32(e.CommandArgument));
            FillData();
             Response.Write("<script>alert('Record has deleted');</script>");
          }
    }
}