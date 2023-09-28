using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer.Admin;
public partial class Depo_WarehouseMaster : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = null;
    DistrictMaster obDistrictMaster = new DistrictMaster();
    string path, mapFile;
    string path1, AgrimentFile;
    APIProcedure api = new APIProcedure();
    MessageC m = new MessageC();

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
                FillMonth();
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }
                DataSet dsdist = obDistrictMaster.Select();
                ddlDistrict.DataTextField = "District_Name_Hindi_V";
                ddlDistrict.DataValueField = "DistrictTrno_I";
                ddlDistrict.DataSource = dsdist.Tables[0];
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, "Select..");
                obCommonFuction = new CommonFuction();
                DataSet st = obCommonFuction.FillDatasetByProc("call USP_Hr_AccountMasterFillDetailsNew(" + Session["USerID"] + ")");
                txtBankName.DataTextField = "BankName";
                txtBankName.DataValueField = "AccountID";
                txtBankName.DataSource = st.Tables[1];
                txtBankName.DataBind();
                txtBankName.Items.Insert(0, "Select..");
            }
            catch { }
            finally { obWareHouseMaster = null; }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string msg = "";
        if (txtWareHouseName.Text.Trim() == "")
        {
            msg += "वेयरहाउस का नाम भरें";
        }
        if (rdwarehouse.SelectedValue == "")
        {
            msg += "Please slect warehouse type";
        }
        if (txtRegistrationNo.Text == "")
        {
            msg = "Please slect tRegistratio No ";
        }
        if (txtRegDate.Text == "")
        {
            msg = "Please fill Reg. Date";
        }
        if (txtWarehouseOwnerN.Text == "")
        {
            msg = "Please fill warehouse Owner  name";
        }

        if (txtCorpet.Text == "")
        {
            msg = "Please fill carpet area";
        }
        if (ddlCorpetType.SelectedValue == "0")
        {
            msg = "Please select carpaet area unit";
        }
        if (txtMoblie.Text == "")
        {
            msg = "Please fill Mobile No";
        }
        if (txtaddress.Text == "")
        {
            msg = "Please fill all required fields";
        }
        if (ddlDistrict.SelectedValue == "Select..")
        {
            msg = "Please fill district";
        }
        if (txtPinCode.Text == "")
        {
            msg = "Please enter pincode";
        }
        if (txtCheckDate.Text == "")
        {
            msg = "Please fill DD.Check Date";
        }
        if (txtRegAmount.Text == "")
        {
            msg = "Please fill Reg Amount";
        }

        if (txtRentAmount.Text == "")
        {
            msg = "Please fill Rent Amount";
        }
        string ImgStatus = "", ImgStatus1 = "";

        try
        {
            if (FlMapFile.FileName == "")
            {
                ImgStatus = "Ok";
            }
            else
            {
                ImgStatus = api.SingleuploadFile(FlMapFile, "mapFile", 1024);
                mapFile = api.FullFileName;
            }
            if (FlAgrimentFile.FileName == "")
            {
                ImgStatus1 = "Ok";
            }
            else
            {
                ImgStatus1 = api.SingleuploadFile(FlAgrimentFile, "AgrimentFile", 1024);
                AgrimentFile = api.FullFileName;
            }

            if (ImgStatus != "Ok")
            {
                msg = ImgStatus;

            }
            else if (ImgStatus1 != "Ok")
            {
                msg = ImgStatus1;
            }
            else if (msg == "")
            {
                obWareHouseMaster = new WareHouseMaster();
                obWareHouseMaster.DDDate = Convert.ToDateTime(txtCheckDate.Text, cult);
                obWareHouseMaster.WareHouseName_V = Convert.ToString(txtWareHouseName.Text.Trim());
                obWareHouseMaster.RegistrationNo_V = Convert.ToString(txtRegistrationNo.Text.Trim());
                obWareHouseMaster.WareHouseAddress_V = Convert.ToString(txtaddress.Text.Trim());
                obWareHouseMaster.RegistrationDate_D = Convert.ToDateTime(txtRegDate.Text, cult);
                obWareHouseMaster.WareHouseOwnerName_V = Convert.ToString(txtWarehouseOwnerN.Text.Trim());
                obWareHouseMaster.CarpateArea_V = Convert.ToString(txtCorpet.Text.Trim());
                obWareHouseMaster.MobileNo_N = Convert.ToString(txtMoblie.Text.Trim());
               // obWareHouseMaster.TelephoneNo_V = Convert.ToString(txtstdCode.Text).Trim() + " - " + Convert.ToString(txtTelPhone2.Text).Trim();
                obWareHouseMaster.DistrictID_I = Convert.ToInt32(ddlDistrict.SelectedValue);
               // obWareHouseMaster.FaxNumber_V = Convert.ToString(txtstdCode1.Text.Trim()) + " - " + Convert.ToString(txtFaxNo.Text);
                obWareHouseMaster.EmailID_V = Convert.ToString(txtEmailID.Text.Trim());
                obWareHouseMaster.PanNo_V = Convert.ToString(txtPanNo.Text.Trim());
               // obWareHouseMaster.TinNo_V = Convert.ToString(txtTinNo.Text.Trim());
                obWareHouseMaster.ServiceNo_V = Convert.ToString(txtServiceTaxNo.Text.Trim());
                obWareHouseMaster.ServicePeriod_V = Convert.ToString(txtServicePe.Text.Trim());
                obWareHouseMaster.RegistrationAmount_N = Convert.ToDouble(txtRegAmount.Text);
                obWareHouseMaster.DDNo_V = Convert.ToString(txtCheckNo.Text.Trim());
                obWareHouseMaster.BankName_V = Convert.ToString(txtBankName.Text.Trim());
                obWareHouseMaster.WareHouseMap_V = Convert.ToString(mapFile);
                // obWareHouseMaster.Agreement_V  Convert.ToString(AgrimentFile);
                obWareHouseMaster.Agreement_V = Convert.ToString(AgrimentFile);
                obWareHouseMaster.RentDate_D = Convert.ToDateTime(txtRentDate.Text + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year, cult);
                obWareHouseMaster.RentAmount_N = Convert.ToDecimal(txtRentAmount.Text);
                obWareHouseMaster.DepoID_I = Convert.ToInt32(Session["UserID"]);
                obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
                obWareHouseMaster.TranID = 0;
                obWareHouseMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
                obWareHouseMaster.WareHouseID = 0;
                obWareHouseMaster.WarehouseType = Convert.ToInt32(rdwarehouse.SelectedValue);
                obWareHouseMaster.CorpetType = Convert.ToInt32(ddlCorpetType.SelectedValue);
                obWareHouseMaster.AmountType = Convert.ToInt32(ddlAmountType.SelectedValue);
                obWareHouseMaster.CityName_V = Convert.ToString(txtCity.Text);
                obWareHouseMaster.PinNo = Convert.ToInt32(txtPinCode.Text);
               // obWareHouseMaster.TanNumber = Convert.ToString(txttenno.Text);


                if (HiddenField1.Value != "")
                {
                    obWareHouseMaster.TranID = 1;
                    obWareHouseMaster.WareHouseID = Convert.ToInt32(HiddenField1.Value);
                }
                string EntrySts = "";
                int i = obWareHouseMaster.InsertUpdate();
                if (i > 0)
                {
                    CommonFuction obCommonFuction = new CommonFuction();
                    if (HiddenField1.Value == "")
                    {
                        if (rdwarehouse.SelectedValue != "3")
                        {
                            try
                            {
                                DataSet Vo = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('j')");
                                DataSet ddd = obCommonFuction.FillDatasetByProc("call USP_HR_ledgermasterSaveUpdateForDepoPrinter('" + txtWareHouseName.Text + "',1,0,1,0,0," + Session["UserID"] + "," + i + ",'WareHouse')");
                                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0,0," + txtRegAmount.Text + ",'Cash'," + txtBankName.SelectedValue + ",'" + txtCheckNo.Text + "','" + Convert.ToDateTime(txtCheckDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',1,0)");

                                DataSet LedgerID = obCommonFuction.FillDatasetByProc("call USP_hr_GetledgerIDbyName('Security Deposit - Others')");
                                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('JOURNAL','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0," + txtRegAmount.Text + ",0,'Bank'," + txtBankName.SelectedValue + ",'" + txtCheckNo.Text + "','" + Convert.ToDateTime(txtCheckDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + LedgerID.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo.Tables[0].Rows[0]["Voucher"] + "',2,0)");


                                DataSet Vo1 = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('R')");
                                DataSet Bank = obCommonFuction.FillDatasetByProc("call USP_Hr_GetLedgerIDBYAccount(" + txtBankName.SelectedValue + ")");
                                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0," + txtRegAmount.Text + ",0,'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtCheckNo.Text + "','" + Convert.ToDateTime(txtCheckDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + ddd.Tables[0].Rows[0]["aa"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',1,1)");

                                obCommonFuction.FillDatasetByProc("call  USP_Hr_BookSellerEndSave('Receipt','" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Security Deposit',0,0," + txtRegAmount.Text + ",'Bank'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + txtCheckNo.Text + "','" + Convert.ToDateTime(txtCheckDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," + Bank.Tables[0].Rows[0]["LedgerID"] + ",'" + Vo1.Tables[0].Rows[0]["Voucher"] + "',2,1)");

                            }
                            catch { }
                        }
                    }

                    obCommonFuction = new CommonFuction();
                    obCommonFuction.EmptyTextBoxes(this);
                    HiddenField1.Value = "";
                    // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    Response.Redirect("WareHouseMasterList.aspx", false);
                }
            }
            else
            {
                m.ShowOtherMessage("e", msg);
            }


        }
        catch (Exception ex) { }
        finally
        {
            obWareHouseMaster = null;
        }
    }
    public void showdata(string ID)
    {
        try
        {
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"]));
            DataSet obDataSet = obWareHouseMaster.Select();
            HiddenField1.Value = (api.Decrypt(Request.QueryString["ID"].ToString()));
            txtWareHouseName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["WareHouseName_V"]);
            txtRegistrationNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationNo_V"]);
            txtaddress.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["WareHouseAddress_V"]);
            txtRegDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationDate_D"]);
            txtWarehouseOwnerN.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["WareHouseOwnerName_V"]);
            txtCorpet.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["CarpateArea_V"]);
            txtMoblie.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["MobileNo_N"]);
            string[] strPhoneNo = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Split('-');
            if (strPhoneNo.Length == 1 && strPhoneNo[0] != "")
            {
              //  txtstdCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Substring(0, 4).Trim();
                txtTelPhone2.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Skip(4).ToString().Trim();

            }
            else
            {
             //   txtstdCode.Text = strPhoneNo[0].Trim();
                txtTelPhone2.Text = strPhoneNo[1].Trim();

            }

            ddlDistrict.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistrictID_I"]);
            string[] strPhoneNo1 = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Split('-');
            if (strPhoneNo1.Length == 1 && strPhoneNo1[0] != "")
            {
              //  txtstdCode1.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Substring(0, 4).Trim();
                txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Skip(4).ToString().Trim();

            }
            else
            {
              //  txtstdCode1.Text = strPhoneNo1[0].Trim();
                txtFaxNo.Text = strPhoneNo1[1].Trim();

            }
            // txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]);
            txtEmailID.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["EmailID_V"]);
            txtPanNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PanNo_V"]);
           // txtTinNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TinNo_V"]);
            txtServiceTaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["ServiceNo_V"]);
            txtServicePe.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["ServicePeriod_V"]);
            txtRegAmount.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RegistrationAmount_N"]);
            txtCheckNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DDNo_V"]);
            txtBankName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["BankName_V"]);
            try
            {
                txtRentDate.SelectedValue = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["RentDate_D"]).Month.ToString();
            }
            catch { }
            txtRentAmount.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["RentAmount_N"]);
            mapID.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["WareHouseMap_V"]);
            Agriment.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["Agreement_V"]);

            //rdwarehouse.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["WarehouseType"]);
            ddlCorpetType.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["CorpetType"]);
            ddlAmountType.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AmountType"]);
            txtCity.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["CityName_V"]);
            txtPinCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PinNo"]);
           // txttenno.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TanNumber"]);
            txtCheckDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DDDate"]);
            //obWareHouseMaster.CityName_V = Convert.ToString(
            //obWareHouseMaster.PinNo = Convert.ToInt32(txtPinCode.Text);
            //obWareHouseMaster.TanNumber = Convert.ToString(txttenno.Text);
            obWareHouseMaster.TranID = 1;

            if (txtCorpet.Text != "")
            {
                Label1.Text = Convert.ToString(Convert.ToDecimal(txtCorpet.Text) * Convert.ToDecimal(txtRentAmount.Text));
            }
            rdwarehouse.ClearSelection();
            // rdwarehouse.Items.FindByText(obDataSet.Tables[0].Rows[0]["WarehouseType"].ToString()).Selected = true;
            string r = obDataSet.Tables[0].Rows[0]["WarehouseType"].ToString();
            rdwarehouse.SelectedValue = rdwarehouse.Items.FindByText(r).Value;
        }
        catch { }

    }
    public void FillMonth()
    {
        try
        {

            List<Month> obMonthList = new List<Month>();
            for (int i = 1; i <= 31; i++)
            {
                Month obMonth = new Month();
                obMonth.MonthString = "हर माह की " + i.ToString() + " दिनांक";
                obMonth.MonthName = i.ToString();

                obMonthList.Add(obMonth);

            }
            txtRentDate.DataSource = obMonthList;
            txtRentDate.DataTextField = "MonthString";
            txtRentDate.DataValueField = "MonthName";
            txtRentDate.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void txtRentAmount_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtCorpet.Text != "")
            {
                //Label1.Text = Convert.ToString(Convert.ToDecimal(txtCorpet.Text) * Convert.ToDecimal(txtRentAmount.Text));
                txtRentAmount.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtRentAmount.Text) / Convert.ToDouble(txtCorpet.Text), 2));
                Label1.Text = Convert.ToString(Math.Round(Convert.ToDouble(txtCorpet.Text) * Convert.ToDouble(txtRentAmount.Text), 2));
            }

        }
        catch (Exception)
        {
        }
    }
    protected void ddlCorpetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAmountType.SelectedValue = ddlCorpetType.SelectedValue;
    }

    public class Month
    {
        public string MonthName { get; set; }
        public string MonthString { get; set; }
    }
}