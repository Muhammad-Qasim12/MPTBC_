using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_View_otherthanDemand : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dt = obj.FillDatasetByProc("call USP_Ph_otherDistribution_filldata(0,0,0,"+Session["UserID"]+")");
            GridView1.DataSource = dt.Tables[1]; 
            GridView1.DataBind();
        
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("OtherDistribution.aspx");
    }
}