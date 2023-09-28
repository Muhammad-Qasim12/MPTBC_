using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class logoutAutometically : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] != null)
        {
            Response.Write("login");
            Response.End();
            return;

        }
        else
        {
            Session.Abandon();
            Session.RemoveAll();
            Response.Redirect("login.aspx");
            Response.Write("Logout");
            Response.End();
            return;
        }
       
    }
}
