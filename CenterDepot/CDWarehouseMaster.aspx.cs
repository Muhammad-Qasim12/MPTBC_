using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_WarehouseMaster : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = null;
    DistrictMaster obDistrictMaster = new DistrictMaster();
    string path, mapFile;
    string path1, AgrimentFile;
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
            }
            catch { }
            finally { obWareHouseMaster = null; }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (txtWareHouseName.Text == "")
        {
            txtWareHouseName.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill warehouse name";
             return;
        }
        if (rdwarehouse.SelectedValue == "")
        {
            rdwarehouse.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please slect warehouse type";
            return;
        }
        if (txtWarehouseOwnerN.Text == "")
        {
            txtWarehouseOwnerN.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill warehouse Owner  name";
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
        if (txtCorpet.Text == "")
        {
            txtCorpet.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill carpet area";
            return;
        }
        if (ddlCorpetType.SelectedValue == "0")
        {
            ddlCorpetType.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select carpaet area unit";
            return;
        }
        if (txtaddress.Text == "0")
        {
            txtaddress.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill all required fields";
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
        if (txtRentAmount.Text == "")
        {
            txtRentAmount.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill RentAmount";
            return;
        }
        if (txtRegAmount.Text == "")
        {
            txtRegAmount.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill RegAmount";
            return;
        }
        if (txtPinCode.Text == "")
        {
            txtPinCode.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please enter pincode";
            return;
        }
        if (txtCheckDate.Text == "")
        {
            txtRegDate.Focus();
            lblmsg.Style.Add("display", "block");
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please fill DD.Check Date";
            return;
        }

        try {
            path = Server.MapPath("~/MapFile/");
            if (FlMapFile.HasFile)
            {
                mapFile = FlMapFile.FileName;
                FlMapFile.PostedFile.SaveAs(path + FlMapFile.FileName);
            }
            else
            {
                mapFile = mapID.Value;
            }
            path1 = Server.MapPath("~/AgrimentFile/");
            if (FlAgrimentFile.HasFile)
            {
                AgrimentFile = FlAgrimentFile.FileName;
                FlMapFile.PostedFile.SaveAs(path1 + FlAgrimentFile.FileName);
            }
            else
            {
                AgrimentFile = Agriment.Value;
            }
        obWareHouseMaster = new WareHouseMaster();
        obWareHouseMaster.DDDate = Convert.ToDateTime(txtCheckDate.Text, cult);
        obWareHouseMaster.WareHouseName_V = Convert.ToString(txtWareHouseName.Text.Trim ());
        obWareHouseMaster.RegistrationNo_V = Convert.ToString(txtRegistrationNo.Text.Trim());
        obWareHouseMaster.WareHouseAddress_V = Convert.ToString(txtaddress.Text.Trim());
        obWareHouseMaster.RegistrationDate_D = Convert.ToDateTime(txtRegDate.Text,cult );
        obWareHouseMaster.WareHouseOwnerName_V = Convert.ToString(txtWarehouseOwnerN.Text.Trim());
        obWareHouseMaster.CarpateArea_V = Convert.ToString(txtCorpet.Text.Trim());
        obWareHouseMaster.MobileNo_N = Convert.ToString(txtMoblie.Text.Trim());
        obWareHouseMaster.TelephoneNo_V =Convert.ToString(txtstdCode.Text).Trim()+" - "+ Convert.ToString(txtTelPhone2.Text).Trim();
        obWareHouseMaster.DistrictID_I = Convert.ToInt32(ddlDistrict.SelectedValue);
        obWareHouseMaster.FaxNumber_V = Convert.ToString(txtstdCode1.Text.Trim()) + " - " + Convert.ToString(txtFaxNo.Text);
        obWareHouseMaster.EmailID_V = Convert.ToString(txtEmailID.Text.Trim());
        obWareHouseMaster.PanNo_V = Convert.ToString(txtPanNo.Text.Trim());
        obWareHouseMaster.TinNo_V = Convert.ToString(txtTinNo.Text.Trim());
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
        obWareHouseMaster.DepoID_I = int.Parse(Session["UserID"].ToString());
        obWareHouseMaster.UserID_I = int.Parse(Session["UserID"].ToString());
        obWareHouseMaster.TranID = 0;
        obWareHouseMaster.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
        obWareHouseMaster.WareHouseID = 0;
        obWareHouseMaster.WarehouseType=Convert.ToInt32 (rdwarehouse.SelectedValue);
        obWareHouseMaster.CorpetType=Convert.ToInt32 (ddlCorpetType.SelectedValue);
        obWareHouseMaster.AmountType = Convert.ToInt32(ddlAmountType.SelectedValue);
        obWareHouseMaster.CityName_V = Convert.ToString(txtCity.Text );
        try
        {
            obWareHouseMaster.PinNo = Convert.ToInt32(txtPinCode.Text);
        }
        catch { obWareHouseMaster.PinNo = 0; }
        obWareHouseMaster.TanNumber = Convert.ToString(txttenno.Text);
            
            
        if (HiddenField1.Value != "")
        {
            obWareHouseMaster.TranID = 1;
            obWareHouseMaster.WareHouseID = Convert.ToInt32(HiddenField1.Value);
        }
        obWareHouseMaster.InsertUpdate();
        obCommonFuction = new CommonFuction();
        obCommonFuction.EmptyTextBoxes(this);
        HiddenField1.Value = "";
        }
        catch { }
        finally 
        { 
            obWareHouseMaster = null; 
        }
       
       // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
        Response.Redirect("VIEW_WareHouse.aspx");
        
    }
   
    public void showdata(string ID)
    {
        try
        {
            obWareHouseMaster = new WareHouseMaster();
            obWareHouseMaster.WareHouseID = Convert.ToInt32(Request.QueryString["ID"]);
            DataSet obDataSet = obWareHouseMaster.Select();
            HiddenField1.Value = (Request.QueryString["ID"]);
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
                txtstdCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Substring(0,4).Trim();
                txtTelPhone2.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TelephoneNo_V"]).Skip(4).ToString().Trim();

            }
            else {
                txtstdCode.Text = strPhoneNo[0].Trim();
                txtTelPhone2.Text = strPhoneNo[1].Trim();
            
            }
            
            ddlDistrict.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistrictID_I"]);
            string[] strPhoneNo1 = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Split('-');
            if (strPhoneNo1.Length == 1 && strPhoneNo1[0] != "")
            {
                txtstdCode1.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Substring(0, 4).Trim();
                txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]).Skip(4).ToString().Trim();

            }
            else
            {
                txtstdCode1.Text = strPhoneNo1[0].Trim();
                txtFaxNo.Text = strPhoneNo1[1].Trim();

            }
           // txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNumber_V"]);
            txtEmailID.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["EmailID_V"]);
            txtPanNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PanNo_V"]);
            txtTinNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TinNo_V"]);
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
            rdwarehouse.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["WarehouseType"]);
            ddlCorpetType.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["CorpetType"]);
            ddlAmountType.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AmountType"]);
            txtCity.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["CityName_V"]);
            txtPinCode.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PinNo"]);
            txttenno.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TanNumber"]);
            txtCheckDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DDDate"]);
            //obWareHouseMaster.CityName_V = Convert.ToString(
            //obWareHouseMaster.PinNo = Convert.ToInt32(txtPinCode.Text);
            //obWareHouseMaster.TanNumber = Convert.ToString(txttenno.Text);
            obWareHouseMaster.TranID = 1;
           
            if (txtCorpet.Text != "")
            {
                Label1.Text = Convert.ToString(Convert.ToDecimal(txtCorpet.Text) * Convert.ToDecimal(txtRentAmount.Text));
            }
        }
        catch { }

    }
    public void FillMonth()
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

    protected void txtServiceTaxNo_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtRentAmount_TextChanged(object sender, EventArgs e)
    {
        if (txtCorpet.Text != "")
        {
            Label1.Text = Convert.ToString(Convert.ToDecimal(txtCorpet.Text) * Convert.ToDecimal(txtRentAmount.Text));
        }
    }
    protected void ddlCorpetType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlAmountType.SelectedValue = ddlCorpetType.SelectedValue;
    }

    public class Month
    {
        public string MonthName {get; set; }
        public string MonthString { get; set; }
    }
}