using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
public partial class Depo_PrinterReceivedChallanDetails : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd = comm.FillDatasetByProc("call USP_DPTPrinterChallanR(" + Session["UserID"].ToString() + ")");
            DropDownList1.DataTextField = "ChalanNo";
            DropDownList1.DataValueField = "PriTransID";
            DropDownList1.DataSource = dd.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("Select...", "0"));
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportDiv.Visible = true;
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
        lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
        lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
        lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();
        lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        DataSet ddd = comm.FillDatasetByProc("call USP_DPTPrinterChallanDetilas("+Session["USERID"]+","+DropDownList1.SelectedValue +")");
        Label1.Text = ddd.Tables[0].Rows[0]["NameofPress_V"].ToString();
        Label2.Text = ddd.Tables[0].Rows[0]["TitleHindi_V"].ToString();
        lblChallan.Text = ddd.Tables[0].Rows[0]["ChalanNo"].ToString();//ChalanDate
        lblChallanDate.Text = ddd.Tables[0].Rows[0]["TransactionDate_N"].ToString();
        lblDate.Text = ddd.Tables[0].Rows[0]["TransactionDate_N"].ToString();
        lblloding.Text = ddd.Tables[0].Rows[0]["LordingCharge_N"].ToString();
        lblunloding.Text = ddd.Tables[0].Rows[0]["unLordingCharge_N"].ToString();
        lbllother.Text = ddd.Tables[0].Rows[0]["OtherCharges_N"].ToString();
        lblltranpo.Text = ddd.Tables[0].Rows[0]["TransportationCharge_N"].ToString();
        lblPrinterSendData.Text = ddd.Tables[0].Rows[0]["packetssendasperchallan"].ToString();
        lblReceivedbandal.Text = ddd.Tables[0].Rows[0]["TotalNoOfBundle"].ToString();
        Label3.Text = ddd.Tables[0].Rows[0]["BookType"].ToString();
        lbltrukno.Text = ddd.Tables[0].Rows[0]["TruckNo_V"].ToString();//TruckNo_V
        //lblTotalBook.Text = ddd.Tables[0].Rows[0]["TotalBook"].ToString();

        GridView1.DataSource = comm.FillDatasetByProc("call USP_BundalDetailsD(" + DropDownList1 .SelectedValue+ ")");
        GridView1.DataBind();
        try {
            lblTotalBook.Text = Convert.ToString(Convert.ToInt32(ddd.Tables[0].Rows[0]["LordingCharge_N"]) + Convert.ToInt32(ddd.Tables[0].Rows[0]["unLordingCharge_N"]) + Convert.ToInt32(ddd.Tables[0].Rows[0]["OtherCharges_N"]) + Convert.ToInt32(ddd.Tables[0].Rows[0]["TransportationCharge_N"]));
        }
        catch { }
        try {
            lblReceivedbandal0.Text =  Convert.ToString(Convert.ToInt32(lblPrinterSendData.Text) - Convert.ToInt32(lblPrinterSendData.Text)); 
        }
        catch { }
        }
}