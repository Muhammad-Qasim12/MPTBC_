using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class MobiLogin : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet ds = comm.FillDatasetByProc("call USP_DPTMobileLogin (2,0,0,0)");
            ddlDepotID.DataTextField = "UserName_V";
            ddlDepotID.DataValueField = "UserID_I";
            ddlDepotID.DataSource = ds.Tables[0];
            ddlDepotID.DataBind();
            ddlDepotID.Items.Insert(0, "Select..");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ds1 = comm.FillDatasetByProc("call USP_DPTMobileLogin (1,'"+ddlDepotID.SelectedValue+"','"+txtpwd.Text+"',0)");
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Session["UserID"] = ds1.Tables[0].Rows[0]["UserID_I"].ToString();
            Session["UserName"] =ddlDepotID.SelectedItem.Text;
            Response.Redirect("MobilDasbord.aspx");
        }
        else
        {
            lblmsg.Text = "Invalid username or password";
        }
    }
}