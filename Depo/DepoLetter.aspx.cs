using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_DepoLetter : System.Web.UI.Page
{
    DBAccess db = new DBAccess();
    APIProcedure api = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        db.execute("SELECT  DATE_FORMAT( date_add(RegistrationDate_D, interval ServicePeriod_V month),'%d/%m/%Y')dateD,WareHouseName_V FROM dpt_warehouuse_m where WareHouseID_I=" + api.Decrypt(Request.QueryString["ID"]) + "", DBAccess.SQLType.IS_QUERY);
        DataSet dd = db.records();
        Label1.Text = dd.Tables[0].Rows[0]["WareHouseName_V"].ToString ();
        Label2.Text =Convert.ToString(Session["UserName"]);
        Label3.Text = dd.Tables[0].Rows[0]["dateD"].ToString();
    }
}