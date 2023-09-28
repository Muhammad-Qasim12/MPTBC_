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
public partial class Depo_BookSellerMaster : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    BooksellerMaster obBooksellerMaster = null;
    DistrictMaster obDistrictMaster = new DistrictMaster();
    CommonFuction obCommonFuction = new CommonFuction ();
    APIProcedure api = new APIProcedure();
    UserMaster obUserMaster = null;
    int id;

    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objapi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
    //YF_WebService objWebService = new YF_WebService();
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Random rand = new Random();
                int randnum = rand.Next(100000, 10000000);
                txtUserID.Text = "MPTBC_" + randnum.ToString();

                DataSet dsdist = obDistrictMaster.Select();
                ddlDistiID.DataTextField = "District_Name_Hindi_V";
                ddlDistiID.DataValueField = "DistrictTrno_I";
                ddlDistiID.DataSource = dsdist.Tables[0];
                ddlDistiID.DataBind();
                ddlDistiID.Items.Insert(0, "Select..");

                obCommonFuction = new CommonFuction();
                DataSet st = obCommonFuction.FillDatasetByProc("call USP_Hr_AccountMasterFillDetailsNew(" + Session["USerID"].ToString() + ")");
                ddlBank.DataTextField = "BankName";
                ddlBank.DataValueField = "AccountID";
                ddlBank.DataSource = st.Tables[1];
                ddlBank.DataBind();
                ddlBank.Items.Insert(0, "Select..");
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }

            }
            catch { }
            finally { obBooksellerMaster = null; }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
       
        try
        {
            if (txtbookSellerName.Text == "")
            {
                txtbookSellerName.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please fill BookSeller Name";
                return;
            }
            else if (txtRegNo.Text == "")
            {
                txtRegNo.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please fill Registration No ";
                return;
            }

            else if (txtRegDate.Text == "")
            {
                txtRegDate.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please fill Registration Date ";
                return;
            }
            else if (txtOwnerName.Text == "")
            {
                txtOwnerName.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please fill Owner Name ";
                return;
            }
            else if (txtAddress.Text == "")
            {
                txtbookSellerName.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please fill Address Name ";
                return;
            }
            else if (ddlDistiID.SelectedIndex == 0)
            {
                ddlDistiID.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Select District Name  ";
                return;
            }




            else if (txtRegAmount.Text == "")
            {
                txtRegAmount.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill Registration Amount  ";
                return;
            }
            else if (txtCheckNO.Text == "")
            {
                txtCheckNO.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill Check No.  ";
                return;
            }
            else if (txtValidity.Text == "")
            {
                txtValidity.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill Validity   ";
                return;
            }
            else if (txtddDate.Text == "")
            {
                txtddDate.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill DD Date   ";
                return;
            }
            else if (txtUserID.Text == "")
            {
                txtUserID.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill User ID   ";
                return;
            }
            else if (txtPassword.Text == "")
            {
                txtUserID.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill Password  ";
                return;
            }
            else if (ddlCategory.SelectedIndex == 0)
            {
                txtUserID.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Fill Category  ";
                return;
            }
            else if (ddlBank.SelectedIndex == 0)
            {
                ddlBank.Focus();
                lblmsg.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please Select Bank Name  ";
                return;
            }
            else
            {
                //OwnerName
                if (Request.QueryString["ID"] == null || HiddenField2.Value == "1")
                {
                    MPTBCBussinessLayer.Admin.UserMaster obUserMaster = new MPTBCBussinessLayer.Admin.UserMaster();
                    DBAccess db = new DBAccess();
                    db.execute("SELECT Roletrno_I FROM adm_rolemaster  where Role_V='BookSeller';", DBAccess.SQLType.IS_QUERY);
                    DataSet ds = db.records();
                    //obUserMaster.UserID = 0;
                    //obUserMaster.UserName = Convert.ToString(txtUserID.Text);
                    //obUserMaster.Password = Convert.ToString(txtPassword.Text);
                    //obUserMaster.UserType = "External User";
                    //obUserMaster.RoleTrno = Convert.ToInt32(ds.Tables[0].Rows[0]["Roletrno_I"].ToString());
                    //
                    
                    obCommonFuction = new CommonFuction();

                    DataSet dda = obCommonFuction.FillDatasetByProc("Call USP_ADM007_UserMasterSaveNew(0,'" + txtUserID.Text + "','" + txtPassword.Text + "'," + ds.Tables[0].Rows[0]["Roletrno_I"].ToString() + ",'External User',0,'" + txtOwnerName.Text + "')");
                    // id= obUserMaster.InsertUpdate();
                    id = int.Parse(dda.Tables[0].Rows[0][0].ToString());
                }
                obBooksellerMaster = new BooksellerMaster();
                obBooksellerMaster.BooksellerName_V = Convert.ToString(txtbookSellerName.Text);
                obBooksellerMaster.RegistrationNo_V = Convert.ToString(txtRegNo.Text.Trim());
                obBooksellerMaster.RegistrationDate_D = Convert.ToDateTime(txtRegDate.Text, cult);
                obBooksellerMaster.BooksellerOwnerName_V = Convert.ToString(txtOwnerName.Text.Trim());
                obBooksellerMaster.MobileNo_N = Convert.ToString(txtMoblieNo.Text.Trim());
                obBooksellerMaster.TelephoneNo_V = Convert.ToString(txtstdCode.Text).Trim() + " - " + Convert.ToString(txtTelPhone2.Text).Trim();
                obBooksellerMaster.Address_V = Convert.ToString(txtAddress.Text.Trim());
                obBooksellerMaster.DistrictID_I = Convert.ToInt32(ddlDistiID.SelectedValue);
                obBooksellerMaster.FaxNumber_V = Convert.ToString(txtFaxStd.Text) + "-" + Convert.ToString(txtFaxNo.Text.Trim());
                obBooksellerMaster.EmailID_V = Convert.ToString(txtEmailID.Text.Trim());
                obBooksellerMaster.RegistrationAmount_N = Convert.ToDecimal(txtRegAmount.Text);
                obBooksellerMaster.RegDDNo_V = Convert.ToString(txtCheckNO.Text.Trim());
                obBooksellerMaster.LoginID_V = Convert.ToString(id);
                obBooksellerMaster.UserPassowrd = Convert.ToString(txtPassword.Text.Trim());
                obBooksellerMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
                obBooksellerMaster.Cityname = Convert.ToString(txtCityName.Text);
                obBooksellerMaster.PinNumber = Convert.ToString(txtpincode.Text);
                obBooksellerMaster.TanNumber = Convert.ToString(txttennumber.Text);
                obBooksellerMaster.Validity = Convert.ToString(txtValidity.Text);
                obBooksellerMaster.Chekcdate = Convert.ToDateTime(txtddDate.Text, cult);
                obBooksellerMaster.PanNumber = Convert.ToString(txtpenNumber.Text);
                obBooksellerMaster.Category = Convert.ToInt32(ddlCategory.SelectedValue);
                obBooksellerMaster.Trans_I = 0;
                obBooksellerMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
                obBooksellerMaster.DBooksellerregistration_I = 0;
                /////////// User Role and password



                if (HiddenField1.Value != "")
                {
                    obBooksellerMaster.Trans_I = 1;
                    obBooksellerMaster.DBooksellerregistration_I = Convert.ToInt32(HiddenField1.Value);


                }
                string NewEntry = "";
                int i = obBooksellerMaster.InsertUpdate();
                if (i > 0)
                {
                    obCommonFuction.FillDatasetByProc("call USP_UpdateSecurityAmount("+i+","+txtSecurityAmount.Text+")");

                    //TransTypea VARCHAR(50), TransDatea VARCHAR(20), Descriptiona VARCHAR(200), VoucherStatusa VARCHAR(50), AmountCra DOUBLE, AmountDra DOUBLE, CashBankFlaga INT,
//BankIDa INT, ChequeDDNoa VARCHAR(50), chequeDatea VARCHAR(50),  CreatedBya INT, CreateTypea VARCHAR(50), FYeara VARCHAR(50),LedgerIDa INT
                   //  LEDGERNAMEa VARCHAR(200), GroupIda INT, ISCATEGORYa INT, ISAGENCYa INT, BUDGETa INT, ledgercodea VARCHAR(50), CreatedBya INT,AGENCYIDa INT, AGENCYTypea VARCHAR(50)
                    if (HiddenField1.Value == "")
                    {
                       // DataSet Vo=obCommonFuction.FillDatasetByProc ("call USP_HR_GetVoucherNo('j')");
                        //DataSet ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgermasterSaveUpdateForDepoPrinter('" + txtbookSellerName.Text + "',17,0,1,0,0," + Session["UserID"] + "," + i + ",'BookSeller')");
                        //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0,0," + txtRegAmount.Text + ",'Cash'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',1)");
                        //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmount.Text + ",0,'Cash'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',2)");

                        //DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                        //DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + ddlBank.SelectedValue + ")");
                        //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0,0," + txtRegAmount.Text + ",'Bank'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1)");

                        //DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Registration Fees')");
                        //obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmount.Text + ",0,'Bank'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2)");

                       
                        DataSet ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgermasterSaveUpdateForDepoPrinter('" + txtbookSellerName.Text + "',17,0,1,0,0," + Session["UserID"] + "," + i + ",'BookSeller')");
                     
                        //Security Deposit
                        DataSet Vo = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('j')");
                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Amount',0,0," + txtSecurityAmount.Text + ",'Cash'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',1,0)");
                        DataSet LedgerID1 = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Security Deposit - Book Sellers')");
                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Amount',0," + txtSecurityAmount.Text + ",0,'Bank'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID1.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',2,0)");
                        DataSet Vo12 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                        DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + ddlBank.SelectedValue + ")");
                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Amount',0," + txtSecurityAmount.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo12.Tables[0].Rows[0]["Voucher"] + "',1,1)");

                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Amount',0,0," + txtSecurityAmount.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo12.Tables[0].Rows[0]["Voucher"] + "',2,1)");
                        
                        //

                        DataSet Vo123 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('j')");
                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0,0," + txtRegAmount.Text + ",'Cash'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo123.Tables[0].Rows[0]["Voucher"] + "',1,0)");
                        
                        DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Registration Fees')");
                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmount.Text + ",0,'Bank'," + ddlBank.SelectedValue + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo123.Tables[0].Rows[0]["Voucher"] + "',2,0)");


                        DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                       // DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + ddlBank.SelectedValue + ")");
                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0," + txtRegAmount.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,1)");

                        obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Registration Amount',0,0," + txtRegAmount.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtCheckNO.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,1)");

                    }
                }
                obCommonFuction = new CommonFuction();
                obCommonFuction.EmptyTextBoxes(this);
            }
        }
        catch { }
        finally
        {
            obBooksellerMaster = null;
        }
        //Response.Redirect("BookSellerMasterList.aspx");

    }
    public void showdata(string ID)
    {
        try
        {
            obBooksellerMaster = new BooksellerMaster();
            obBooksellerMaster.DBooksellerregistration_I = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString()));
            DataSet obDataSet = obBooksellerMaster.Select();
            HiddenField1.Value = (api.Decrypt(Request.QueryString["ID"].ToString()));
            txtbookSellerName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["BooksellerName_V"]);
            txtRegNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationNo_V"]);
            txtRegDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationDate_D"]);
            txtOwnerName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["BooksellerOwnerName_V"]);
            txtMoblieNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["MobileNo_N"]);
            string[] strPhoneNo = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Split('-');
            if (strPhoneNo.Length == 1 && strPhoneNo[0] != "")
            {
                txtstdCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Substring(0, 4).Trim();
                txtTelPhone2.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Skip(4).ToString().Trim();

            }
            else
            {
                txtstdCode.Text = strPhoneNo[0].Trim();
                txtTelPhone2.Text = strPhoneNo[1].Trim();

            }
            txtAddress.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Address_V"]);
            ddlDistiID.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistrictID_I"]);
            //txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]);
            string[] strPhoneNo1 = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Split('-');
            if (strPhoneNo1.Length == 1 && strPhoneNo1[0] != "")
            {
                txtFaxStd.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Substring(0, 4).Trim();
                txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Skip(4).ToString().Trim();

            }
            else
            {
                txtFaxStd.Text = strPhoneNo1[0].Trim();
                txtFaxNo.Text = strPhoneNo1[1].Trim();

            }

            txtEmailID.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["EmailID_V"]);
            txtRegAmount.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationAmount_N"]);
            txtCheckNO.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegDDNo_V"]);
            txtUserID.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["LoginID_V"]);
            txtPassword.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["UserPassowrd"]);

            txtCityName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Cityname"]);
            txtpincode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PinNumber"]);
            txttennumber.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TanNumber"]);
            txtValidity.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Validity"]);
            txtddDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Chekcdat"]);
            txtpenNumber.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PanNumber"]);
            txtSecurityAmount.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["SecurityAmount"]);
            obBooksellerMaster.Trans_I = 1;
            ddlCategory.ClearSelection();
            ddlCategory.Items.FindByText(Convert.ToString(obDataSet.Tables[0].Rows[0]["Category"])).Selected = true;
            if (txtUserID.Text == "")
            {
                HiddenField2.Value = "1";
                Random rand = new Random();
                int randnum = rand.Next(100000, 10000000);
                txtUserID.Text = "MPTBC_" + randnum.ToString();
            }
            else
            {
                HiddenField2.Value = "0";
            }
        }
        catch { }
    }
    protected void txtCityName_TextChanged(object sender, EventArgs e)
    {

    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}