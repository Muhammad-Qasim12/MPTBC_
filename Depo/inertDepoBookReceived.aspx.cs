using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;


public partial class Depo_inertDepoBookReceived : System.Web.UI.Page
{
    WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = null;
    StockMaster obStockMaster = new StockMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BookReceivedDetails obBookReceivedDetails = new BookReceivedDetails();
    int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            //obCommonFuction = new CommonFuction();
            //DataSet ds = obCommonFuction.FillDatasetByProc("call officerdesignationmFill(0)");
            //ddlEmployee.DataSource = ds.Tables[0];
            //ddlEmployee.DataTextField = "Name";
            //ddlEmployee.DataValueField = "EmployeeID_I";
            //ddlEmployee.DataBind();
            //ddlEmployee.Items.Insert(0, "Select...");

            obCommonFuction = new CommonFuction();
            ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT35GetReceivedInterDepoRequest(" + Session["UserID"] + ")");
            ddlOrderNo.DataTextField = "ChallanNOA";
            ddlOrderNo.DataValueField = "challanno";
            ddlOrderNo.DataBind();
            try {
                ddlOrderNo.SelectedValue = Request.QueryString["ID"].ToString();
                }catch {}


            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = 0;
            obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet dsWareHouse = obWareHouseMaster.Select();
            ddldepoWarehouse.DataTextField = "WareHouseName_V";
            ddldepoWarehouse.DataValueField = "WareHouseID_I";
            ddldepoWarehouse.DataSource = dsWareHouse.Tables[0];
            ddldepoWarehouse.DataBind();
            ddldepoWarehouse.Items.Insert(0, "Select...");
            try
            {
                string user = Session["UserName"].ToString().ToLower();
                string userName = user.Replace("depo", "");
                //     DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('" + userName.ToString () + "')");

                DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('" + userName.ToString() + "')");
                ddlEmployee.DataSource = ds.Tables[0];
                ddlEmployee.DataTextField = "Name";
                ddlEmployee.DataValueField = "EmployeeID_I";

                ddlEmployee.DataBind();

            }
            catch { }

        }
    }
    protected void SerarchDepoOrdere(object sender, EventArgs e)
    {
        obCommonFuction = new CommonFuction();
        DataSet ds1 = obCommonFuction.FillDatasetByProc("Call USP_DPTInterDepoBandalDistibute('0','" + ddlOrderNo.SelectedValue + "',004," + Convert.ToString(Session["UserID"]) + ",'0','0')");
        if (ds1.Tables[0].Rows.Count == 0)
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.Attributes.Add("class", "error");
            lblmsg.Text = "No records found ";
            lblmsg.Style.Add("display", "block");
            return;
        }
        grdInterdepoRequest.DataSource = ds1;
        grdInterdepoRequest.DataBind();
     DataSet dt=  obCommonFuction.FillDatasetByProc("call GetInterDepoChallanDetails(" + ddlOrderNo.SelectedValue + ")");
     txtDepoGrnoDate.Text = dt.Tables[0].Rows[0]["ChallanDate_D"].ToString();
     txtDepoGrno.Text = dt.Tables[0].Rows[0]["ChallanNo_V"].ToString();
     txtDepoTruck.Text = dt.Tables[0].Rows[0]["TruckNo_V"].ToString();
        if (grdInterdepoRequest.Rows.Count > 0)
        {
            divDepo.Style.Add("display", "block");

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        BookReceivedDetails obBookReceivedDetails = new BookReceivedDetails();

        obBookReceivedDetails.ChallanDate_D = System.DateTime.Now;
        obBookReceivedDetails.ChallanNo_V = Convert.ToString(ddlOrderNo.SelectedValue);
        obBookReceivedDetails.Ddate_D = System.DateTime.Now;
        obBookReceivedDetails.EmployeeName_I = Convert.ToInt32(ddlEmployee.SelectedValue);
        obBookReceivedDetails.GRDate_D = Convert.ToDateTime(txtDepoGrnoDate.Text, cult);
        obBookReceivedDetails.GRNo_V = Convert.ToString(txtDepoGrno.Text);
        obBookReceivedDetails.IsStanderd_I = 0;
        obBookReceivedDetails.LordingCharge_N = Convert.ToInt32(txtdepolOading.Text);
        obBookReceivedDetails.OrderDate_D = System.DateTime.Now;
        obBookReceivedDetails.OrderNo_I = "";
        obBookReceivedDetails.OtherCharges_N = Convert.ToInt32(txtDepoother.Text);

        obBookReceivedDetails.Stock_ID_I = Convert.ToInt32(0);
        obBookReceivedDetails.TransactionDate_N = Convert.ToDateTime(System.DateTime.Now, cult);
        obBookReceivedDetails.TransportationCharge_N = Convert.ToInt32(txtDepoTransport.Text);
        obBookReceivedDetails.TruckNo_V = Convert.ToString(txtDepoTruck.Text);
        obBookReceivedDetails.TwentyfivePerStatus_I = 0;
        obBookReceivedDetails.unLordingCharge_N = Convert.ToInt32(txtDepoUnloading.Text);
        obBookReceivedDetails.UserID_I = Convert.ToInt32(Session["UserID"]);
        obBookReceivedDetails.ReceivedType_I = 1;

        obBookReceivedDetails.BundleNo = "-1";
        obBookReceivedDetails.LooseBookNo = "";

        obBookReceivedDetails.InsertUpdate();

        obCommonFuction = new CommonFuction();
        obCommonFuction.FillDatasetByProc("call USP_DPTStockUpdate(2,'" + ddlOrderNo.SelectedValue + "'," + ddldepoWarehouse.SelectedValue + ")");
        ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_DPT35GetReceivedInterDepoRequest(" + Session["UserID"] + ")");
        ddlOrderNo.DataTextField = "ChallanNOA";
        ddlOrderNo.DataValueField = "challanno";
        ddlOrderNo.DataBind();
        divDepo.Style.Add("display", "none");
        mainDiv.Attributes.Add("class", "success");
        mainDiv.Style.Add("display", "block");
        lblmsg.Text = "Book Received Successfully";
        lblmsg.Style.Add("display", "block");
        grdInterdepoRequest.DataSource = null;
        grdInterdepoRequest.DataBind();

        // divDepo.Visible = false;
    }
}