using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
using System.Data.SqlClient ;




using System.Globalization;


public partial class Depo_ShowTwentyPerRept : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public CommonFuction obj = new CommonFuction();
    public DBAccess db = new DBAccess();
    public DataSet ds;
    public APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        int PrinID = Convert.ToInt32(Request.QueryString["Printerid"]) ;

        string mDtfrom = Convert.ToDateTime(Request.QueryString["dtfrom"], cult).ToString("yyyy-MM-dd");
        string mDtto = Convert.ToDateTime(Request.QueryString["Dtto"], cult).ToString("yyyy-MM-dd");
        string myear = Convert.ToString(Request.QueryString["myear"]);

        Response.Redirect("TentyFiveperReportforBill.aspx?ID="+PrinID+"&dtfrom="+mDtfrom+"&dtto="+mDtto+"&myear="+myear+"");
    } 
}