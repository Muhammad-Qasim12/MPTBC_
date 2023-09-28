using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using MPTBCBussinessLayer.Admin;
public partial class Depo_DPT002_TransportMaster : System.Web.UI.Page
{
    DistrictMaster obDistrictMaster = new DistrictMaster();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    TransportMaster obTransportMaster = null;
    CommonFuction obCommonFuction = null;
    APIProcedure api = new APIProcedure();

    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objapi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
   
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                obCommonFuction = new CommonFuction();
                DataSet dsdist = obDistrictMaster.Select();
                ddlDistrict.DataTextField = "District_Name_Hindi_V";
                ddlDistrict.DataValueField = "DistrictTrno_I";
                ddlDistrict.DataSource = dsdist.Tables[0];
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "Select..");
                ddlFyYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                ddlFyYear.DataValueField = "AcYear";
                ddlFyYear.DataTextField = "AcYear";
                ddlFyYear.DataBind();
                ddlFyYear.SelectedValue = obCommonFuction.GetFinYear();
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }
                obCommonFuction = new CommonFuction();
                DataSet st = obCommonFuction.FillDatasetByProc("call USP_Hr_AccountMasterFillDetailsNew(" + Session["USerID"] + ",0)");
                txtBankName.DataTextField = "BankName";
                txtBankName.DataValueField = "AccountID";
                txtBankName.DataSource = st.Tables[1];
                txtBankName.DataBind();
                txtBankName.Items.Insert(0, "Select..");

            }
            catch { }
            finally { obTransportMaster = null; }
        }

    }
    public string GetFinYear()
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        return finYear;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtTransPort.Text == "")
        {
            txtTransPort.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill transport company name";
            return;
        }

        if (txtRegNO.Text == "")
        {
            txtRegNO.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill registration no";
            return;
        }
        if (txtRegDate.Text == "")
        {
            txtRegDate.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill Reg. Date";
            return;
        }
        if (txtWonerName.Text == "")
        {
            txtWonerName.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill transpoter name";
            return;
        }
        if (ddlDistrict.SelectedValue == "Select..")
        {
            ddlDistrict.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill district";
            return;
        }
        if (txtserviceTax.Text == "")
        {
            txtRegAmonut.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill service Tax No";
            return;
        }
        if (txtRegAmonut.Text == "")
        {
            txtRegAmonut.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill registration amount";
            return;
        }
        if (txtddDate.Text == "")
        {
            txtRegAmonut.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill DD Date ";
            return;
        }
        try
        {
            obTransportMaster = new TransportMaster();

            obTransportMaster.DDDate = Convert.ToDateTime(txtddDate.Text, cult);
            obTransportMaster.TransportName_V = Convert.ToString(txtTransPort.Text);
            obTransportMaster.RegistrationNo_V = Convert.ToString(txtRegNO.Text);
            obTransportMaster.RegistrationDate_D = Convert.ToDateTime(txtRegDate.Text, cult);
            obTransportMaster.TransportOwnerName_V = Convert.ToString(txtWonerName.Text);
            obTransportMaster.MobileNo_N = Convert.ToString(txtMoblieNO.Text);
            obTransportMaster.TelephoneNo_V = Convert.ToString(txtstdCode.Text) + " - " + Convert.ToString(txtTelPhone2.Text);
            obTransportMaster.Address_V = Convert.ToString(txtAddress.Text);
            obTransportMaster.DistrictID_I = Convert.ToInt32(ddlDistrict.SelectedValue);
            obTransportMaster.FaxNumber_V = Convert.ToString(txtFaxCode.Text) + "-" + Convert.ToString(txtFaxNo.Text);
            obTransportMaster.EmailID_V = Convert.ToString(txtemailID.Text);
            obTransportMaster.PanNo_V = Convert.ToString(txtPanNo.Text);
            obTransportMaster.TinNo_V = Convert.ToString(txtTinNo.Text);
            obTransportMaster.ServiceNo_V = Convert.ToString(txtserviceTax.Text);
            obTransportMaster.ServicePeriod_V = Convert.ToString(txtServiceP.Text);
            obTransportMaster.RegistrationAmount_N = Convert.ToDecimal(txtRegAmonut.Text);
            obTransportMaster.DDNo_V = Convert.ToString(txtDdNo.Text);
            obTransportMaster.BankName_V = Convert.ToString(txtBankName.Text);
            obTransportMaster.City_V = Convert.ToString(txtCity.Text);
            obTransportMaster.PinNo = Convert.ToString(txtPinCode.Text);
            obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            obTransportMaster.EPFNO = Convert.ToString(txtEpfNo.Text);
            obTransportMaster.TransID = 0;
            obTransportMaster.DepoID_I = Convert.ToInt32(Session["UserID"]).ToString();
            obTransportMaster.fyYear = Convert.ToString(ddlFyYear.SelectedValue); obTransportMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            obTransportMaster.TransportID_I = 0;

            obTransportMaster.TenNumber = Convert.ToString(txtTenNumber.Text);
            if (HiddenField1.Value != "")
            {
                obTransportMaster.TransID = 1;
                obTransportMaster.TransportID_I = Convert.ToInt32(HiddenField1.Value);
            }
            string EntrySts = "";
            int i = obTransportMaster.InsertUpdate();
            CommonFuction obCommonFuction = new CommonFuction();
            if (i > 0)
            {
                if (HiddenField1.Value == "")
                {
                    
                    //DataSet Vo = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('j')");
                    //DataSet ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgermasterSaveUpdateForDepoPrinter('" + txtTransPort.Text + "',1,0,1,0,0," + Session["UserID"] + "," + i + ",'Transport')");
                    //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0,0," + txtRegAmonut.Text + ",'Cash'," + txtBankName.SelectedValue + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',1)");
                    //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmonut.Text + ",0,'Cash'," + txtBankName.SelectedValue + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',2)");

                    //DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                    //DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + txtBankName.SelectedValue + ")");
                    //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0,0," + txtRegAmonut.Text + ",'Bank'," + txtBankName.SelectedValue + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1)");

                    //DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Registration Fees')");
                    //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmonut.Text + ",0,'Bank'," + txtBankName.SelectedValue + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2)");

                    DataSet Vo = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('j')");
                    DataSet ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgermasterSaveUpdateForDepoPrinter('" + txtTransPort.Text + "',17,0,1,0,0," + Session["UserID"] + "," + i + ",'BookSeller')");
                    obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0,0," + txtRegAmonut.Text + ",'Cash'," + txtBankName.SelectedValue + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',1,0)");

                    DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Security Deposit - Others')");
                    obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0," + txtRegAmonut.Text + ",0,'Bank'," + txtBankName.SelectedValue + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',2,0)");


                    DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                    DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + txtBankName.SelectedValue + ")");
                    obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0," + txtRegAmonut.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,1)");

                    obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0,0," + txtRegAmonut.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtDdNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,1)");
                }
                
                obCommonFuction.EmptyTextBoxes(this);
                Response.Redirect("VIEW_DPT002.aspx");
            }
        }
        catch { }
        finally
        {
            obTransportMaster = null;
        }
        Response.Redirect("VIEW_DPT002.aspx");
    }
    public void showdata(string ID)
    {
        obTransportMaster = new TransportMaster();
        obTransportMaster.TransportID_I = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"]));
        HiddenField1.Value = (api.Decrypt(Request.QueryString["ID"].ToString()));
        DataSet obDataSet = obTransportMaster.Select();
        obTransportMaster = new TransportMaster();

        txtTransPort.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TransportName_V"]);
        txtRegNO.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationNo_V"]);
        txtRegDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationDate_D"]);
        txtWonerName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TransportOwnerName_V"]);
        txtMoblieNO.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["MobileNo_N"]);
        string[] strPhoneNo = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Split('-');
        if (strPhoneNo.Length == 1 && strPhoneNo[0] != "")
        {
            txtstdCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Substring(0, 4);
            txtTelPhone2.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Skip(4).ToString();

        }
        else
        {
            txtstdCode.Text = strPhoneNo[0];
            txtTelPhone2.Text = strPhoneNo[1];

        }
        txtAddress.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Address_V"]);
        ddlDistrict.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistrictID_I"]);
        string[] strPhoneNo1 = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Split('-');
        if (strPhoneNo1.Length == 1 && strPhoneNo[0] != "")
        {
            txtFaxCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Substring(0, 4);
            txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Skip(4).ToString();

        }
        else
        {
            txtFaxCode.Text = strPhoneNo1[0];
            txtFaxNo.Text = strPhoneNo1[1];

        }
        //  txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]);
        txtemailID.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["EmailID_V"]);
        txtPanNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PanNo_V"]);
        txtTinNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TinNo_V"]);
        txtserviceTax.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["ServiceNo_V"]);
        txtServiceP.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["ServicePeriod_V"]);
        txtRegAmonut.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationAmount_N"]);
        txtDdNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DDNo_V"]);
        txtBankName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["BankName_V"]);
        obTransportMaster.TransID = 1;
        txtTenNumber.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenNumber"]);
        txtCity.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["City_V"]);
        txtPinCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PinNo"]);
        txtddDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DDDate"]);
        txtEpfNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["EPFNO"]);
        ddlFyYear.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["Fyyear"]);
        // obTransportMaster.EPFNO = Convert.ToString(txtEpfNo.Text);
    }
}