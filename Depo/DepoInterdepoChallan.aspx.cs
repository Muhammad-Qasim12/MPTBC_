using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_DepoInterdepoChallan : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            GridView1.DataSource = comm.FillDatasetByProc("call USP_InterDepoSt(" + Session["UserID"] + ")");
            GridView1.DataBind();
        }
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        Response.Redirect("DPT015_Bookreceived.aspx");
    }
}