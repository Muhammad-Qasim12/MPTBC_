using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_NPrinReport : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DPT_DepotMaster obDPT_DepotMaster = null;
                obDPT_DepotMaster = new DPT_DepotMaster();
                obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
                DataSet obDataSet = obDPT_DepotMaster.Select();
                lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
                lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
                lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
                lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();


            }
            catch { }
        }
    }
}