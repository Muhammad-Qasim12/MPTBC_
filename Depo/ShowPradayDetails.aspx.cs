using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ShowPradayDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
        if (Convert.ToString(Request.QueryString["Type"]) == "1")
        {
            GridView1.DataSource = comm.FillDatasetByProc("call USP_PradayDetails(" + Session["UserID"] + "," + Request.QueryString["id"] + ",'" + Convert.ToDateTime(Request.QueryString["Fromdate"], cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(Request.QueryString["Todate"], cult).ToString("yyyy-MM-dd") + "')");
            GridView1.DataBind();
        }
        else if (Convert.ToString(Request.QueryString["Type"]) == "2")
        {
            GridView1.DataSource = comm.FillDatasetByProc("call USP_BookSeller(" + Session["UserID"] + "," + Request.QueryString["id"] + ",'" + Convert.ToDateTime(Request.QueryString["Fromdate"], cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(Request.QueryString["Todate"], cult).ToString("yyyy-MM-dd") + "')");
            GridView1.DataBind();
        }
        }
    }
}