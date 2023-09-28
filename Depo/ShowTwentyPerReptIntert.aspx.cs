using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;

public partial class Depo_ShowTwentyPerReptIntert : System.Web.UI.Page
{
    public CommonFuction obj = new CommonFuction();
    public DBAccess db = new DBAccess();
    public DataSet ds;
    public APIProcedure api = new APIProcedure();
    public int R;
    public int id, id2;
    public int j;
    public string depoName, Depoaddress;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           DataSet dt= obj.FillDatasetByProc("select DepoName_V,DepoAddress_V from adm_depomaster_m where DepoTrno_I="+Session["UserID"]+"");
           depoName = Convert.ToString(dt.Tables[0].Rows[0]["DepoName_V"]);
           Depoaddress = Convert.ToString(dt.Tables[0].Rows[0]["DepoAddress_V"]);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("Interdepo25Report.aspx");
    }
}