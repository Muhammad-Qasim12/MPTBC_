using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ViewFormat11 : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = obj.FillDatasetByProc("call GetFormat11(" + Session["UserID"] + ")");
            GridView1.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("Formate11.aspx");
    }
}