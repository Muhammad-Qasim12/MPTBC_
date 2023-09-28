using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
public partial class Depo_UpdateChallan : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    WareHouseMaster obWareHouseMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string user = Session["UserName"].ToString().ToLower();
            string userName = user.Replace("depo", "");
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('" + userName + "')");
            ddlEmployee.DataSource = ds.Tables[0];
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "EmployeeID_I";

            ddlEmployee.DataBind();
            //obWareHouseMaster = new WareHouseMaster();
            //obWareHouseMaster.WareHouseID = 0;
            //obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
           // DataSet dsWareHouse = obWareHouseMaster.Select();
            //ddlWarehouse.DataTextField = "WareHouseName_V";
            //ddlWarehouse.DataValueField = "WareHouseID_I";
            //ddlWarehouse.DataSource = dsWareHouse.Tables[0];
            //ddlWarehouse.DataBind();
            if (Request.QueryString["ID"].ToString() != null)
            { 
           // USP_DPTStockReceivedEntryLoad

                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPTStockReceivedEntryLoad('" + Request.QueryString["ID"] + "')");
                ddlEmployee.SelectedValue = ds1.Tables[0].Rows[0]["EmployeeName_I"].ToString();
                txtPdate.Text = ds1.Tables[0].Rows[0]["TransactionDate_N"].ToString();
                txtloding.Text = ds1.Tables[0].Rows[0]["LordingCharge_N"].ToString();
                txtunloding.Text = ds1.Tables[0].Rows[0]["unLordingCharge_N"].ToString();
                txtTransport.Text = ds1.Tables[0].Rows[0]["TransportationCharge_N"].ToString();
                txtOther.Text = ds1.Tables[0].Rows[0]["OtherCharges_N"].ToString();
                txtTruckNo.Text = ds1.Tables[0].Rows[0]["TruckNo_V"].ToString();
                txtGrNo.Text = ds1.Tables[0].Rows[0]["GRNo_V"].ToString();
                txtDate.Text = ds1.Tables[0].Rows[0]["GRDate_D"].ToString();
                Label1.Text = ds1.Tables[0].Rows[0]["ChallanNo_V"].ToString();
                Label2.Text = ds1.Tables[0].Rows[0]["ChallanDate_D"].ToString();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //`dStockReceiveEntryID_IA` INT(11),  `TruckNo_VA` VARCHAR(50), `EmployeeName_IA` INT(11), `TransportationCharge_NA` DECIMAL, `OtherCharges_NA` DECIMAL, `LordingCharge_NA` DECIMAL, `unLordingCharge_NA` DECIMAL, `TransactionDate_Na` DATETIME, `GRNo_VA` VARCHAR(100), `GRDate_DA` DATETIME
        obCommonFuction.FillDatasetByProc("CALL USP_DTPUPdateReceivedChallAN("+Request.QueryString["ID"]+",'"+txtTruckNo.Text+"','"+ddlEmployee.SelectedValue+"',"+txtTransport.Text+","+txtOther.Text+","+txtloding.Text+","+txtunloding.Text+",'"+Convert.ToDateTime(txtPdate.Text,cult).ToString ("yyyy-MM-dd")+"','"+txtGrNo.Text+"','"+Convert.ToDateTime(txtDate.Text,cult).ToString ("yyyy-MM-dd")+"')");
        Response.Redirect("ViewChallan.aspx");
    }
}