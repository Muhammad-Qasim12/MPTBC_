using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_PrinReport : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try { 
            DPT_DepotMaster obDPT_DepotMaster = null;
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();
            try { 
            //lblDate.Text = Request.QueryString["PDate"].ToString ();
            }
            catch { }
            CommonFuction comm = new CommonFuction();
            lblfyYaer.Text = comm.GetFinYear();
            Label1.Text = Request.QueryString["PrinterName"].ToString();
            Label2.Text = Request.QueryString["bookName"].ToString(); //
            lblunloding.Text = Request.QueryString["unloading"].ToString();
            lbltrukno.Text = Request.QueryString["TruckNo"].ToString();
            lbllother.Text = Request.QueryString["Other"].ToString();
            lblltranpo.Text = Request.QueryString["trspotration"].ToString();
            lblloding.Text = Request.QueryString["loding"].ToString();
            Label3.Text = Request.QueryString["BookType"].ToString();
            ds = obCommonFuction.FillDatasetByProc("call UspBandalDetails(" + Request.QueryString["titalID"] + "," + Request.QueryString["PrinterID"] + ")");
            }
            catch { }
            //    Response.Redirect("PrinReport.aspx?challanNo=" + lblchalan.Text + "&date=" + lblchalandate.Text + "&PrinterID=" + hPrinterID.Value + "&titalID=" + hdnTitleID.Value + "&PrinterName=" + lblAddress.Text + "&bookName=" + lblbookName.Text + "&loding=" + txtloding.Text + "&unloading=" + txtunloding.Text + "&trspotration=" + txtTransport.Text + "&TruckNo=" + txtTruckNo.Text + "&Other=" + txtOther.Text + "");
        }

    }
}