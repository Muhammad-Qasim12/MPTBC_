using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ShowDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Convert.ToString(Request.QueryString["Type"]) == "Printer")
            {
                GridView1.DataSource = obCommonFuction.FillDatasetByProc("call Dpt_DateWisePrinter('" + Convert.ToDateTime(Request.QueryString["Fromdate"], cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(Request.QueryString["Todate"], cult).ToString("yyyy-MM-dd") + "'," + Request.QueryString["id"] + "," + Session["UserID"] + ")");
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_InterDepo(" + Session["UserID"] + ",'" + Convert.ToDateTime(Request.QueryString["Fromdate"], cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(Request.QueryString["Todate"], cult).ToString("yyyy-MM-dd") + "'," + Request.QueryString["id"] + ")");
                GridView1.DataBind();
            }
        }
       
    }
}