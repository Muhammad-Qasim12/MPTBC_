using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_TrasnpotrtBillReport : System.Web.UI.Page
{
    TransportMaster obTransportMaster = null;
    DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
  public  DBAccess db = new DBAccess(); CultureInfo cult = new CultureInfo("gu-IN", true);
  public CommonFuction comp = new CommonFuction();
  public DataSet ds;
  

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obDPT_DepotMaster.DepoTrno_I = 0;
            DataSet depo = obDPT_DepotMaster.Select();

            obTransportMaster = new TransportMaster();
            obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet1 = obTransportMaster.Select();
            DropDownList1.DataTextField = "TransportName_V";
            DropDownList1.DataValueField = "TransportID_I";
            DropDownList1.DataSource = obDataSet1.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "सेलेक्ट..");
          
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();

            lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CommonFuction comm = new CommonFuction();
            lblfyYaer.Text = comm.GetFinYear();
         
        }

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
    }
}