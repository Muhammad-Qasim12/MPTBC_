using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
using System.Data.SqlClient ;

public partial class Depo_ShowTwentyPerRept : System.Web.UI.Page
{
    public CommonFuction obj = new CommonFuction();
    public DBAccess db = new DBAccess();
    public DataSet ds;
    public APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // Response.Redirect("TentyFiveperReport.aspx");
    }
}