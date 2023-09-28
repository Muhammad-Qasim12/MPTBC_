using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_PChallanDetails : System.Web.UI.Page
{
    public CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call Dpt_DateWisePrinterN( " + Session["UserID"] + "," + Request.QueryString["Type"] + "," + Request.QueryString["TitleID"] + ")");
            GridView1.DataBind();
        }
    }
}