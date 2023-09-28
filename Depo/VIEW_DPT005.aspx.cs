using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Depo_VIEW_DPT005 : System.Web.UI.Page
{
    HeadMaster obHeadMaster = null;
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
          
            obHeadMaster = new HeadMaster();
            obHeadMaster.HeadID_I = 0;
            obHeadMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            GrdHead.DataSource = obHeadMaster.Select();
            GrdHead.DataBind();

        }
        catch
        {
        }

    }
   
    protected void GrdHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdHead.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT005_HeadMaster.aspx");
    }
    protected void GrdHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "eDelete")
        {
            try
            {
                obHeadMaster = new HeadMaster();
                obHeadMaster.Delete(Convert.ToInt32(e.CommandArgument));
                
            }
            catch { }
            FillData();
            Response.Write("<script>alert('Record has deleted');</script>");
        }
    }
}