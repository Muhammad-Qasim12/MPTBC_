using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ViewData : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
       
        }
    }
    public void fillgrd()
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_InterDepoP("+Session["UserID"]+")");
        GridView1.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepoTrans.aspx");
    }
}