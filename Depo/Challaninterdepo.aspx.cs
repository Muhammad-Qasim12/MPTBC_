using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_Challaninterdepo : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
       
    lblDepoName.Text= obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
    lblChallan.Text = Request.QueryString["challanID"].ToString ();
    lblUnloding.Text = Request.QueryString["unLordingCharge"].ToString();
    lblUploading.Text = Request.QueryString["LordingCharge"].ToString();
    lblOther.Text = Request.QueryString["otherCharge"].ToString();
    Label2.Text = Request.QueryString["challanDate"].ToString();


    DataSet ds1 = obCommonFuction.FillDatasetByProc("call GetChallanDetailsInerDepo(" + Request.QueryString["challanID"] + "," + Session["UserID"] + ")");
        
        grdDepoTransfer.DataSource = ds1;
        grdDepoTransfer.DataBind();
        // Response.Redirect("Challaninterdepo.aspx?ID=" + ddlOrderNo.SelectedValue + "&challanID=" + lblDepoChalan.Text + "&challanDate=" + lblDepochalanDate.Text + "&LordingCharge=" + txtdepolOading.Text + "&unLordingCharge="+txtDepoUnloading.Text+"&otherCharge="+txtDepoother.Text+"");
            
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InterDepoSendChallan.aspx?ChallanID=" + Request.QueryString["challanID"] + "");
    }
}