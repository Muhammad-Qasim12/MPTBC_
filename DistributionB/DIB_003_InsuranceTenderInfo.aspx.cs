using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;

public partial class Distribution_InsuranceTenderInfo : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.InsuranceCompanyRegistration obInsuranceCompanyRegistration = new MPTBCBussinessLayer.DistributionB.InsuranceCompanyRegistration();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    int InsuranceCompanyTrno = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillFinancialYr();

            if (Request.QueryString["ID"] != null)
            {
                int.TryParse(Request.QueryString["ID"], out InsuranceCompanyTrno);
                if (InsuranceCompanyTrno > 0)
                {
                    FillValues();
                }
            }

            hdnInsuranceCompanyTrno.Value = InsuranceCompanyTrno.ToString();
            fillTechnicalCondition();
        }
    }

    private void fillTechnicalCondition()
    {
        obInsuranceCompanyRegistration.TransID = -6;
        obInsuranceCompanyRegistration.ParameterValue= int.Parse(hdnInsuranceCompanyTrno.Value);
        GrdTechnicalCondition.DataSource = obInsuranceCompanyRegistration.Select();
        GrdTechnicalCondition.DataBind();
        
    }
    private void fillFinancialYr()
    {
        obInsuranceCompanyRegistration.TransID= -1;
        ddlFinaicalYear.DataSource= obInsuranceCompanyRegistration.Select();
        ddlFinaicalYear.DataValueField = "Id";
        ddlFinaicalYear.DataTextField = "FyYear";
        ddlFinaicalYear.DataBind();
    }
    private void FillValues()
    {
        obInsuranceCompanyRegistration.TransID = -2;
        obInsuranceCompanyRegistration.ParameterValue = InsuranceCompanyTrno;
        DataSet dsCompany = obInsuranceCompanyRegistration.Select();
        if (dsCompany.Tables[0]!=null && dsCompany.Tables[0].Rows.Count > 0)
        {
            ddlFinaicalYear.SelectedValue = dsCompany.Tables[0].Rows[0]["FinancialYr_I"].ToString(); 
            txtInsuranceCompanyName.Text = dsCompany.Tables[0].Rows[0]["CompanyName_V"].ToString();
            //chkIRDA.Checked = bool.Parse(dsCompany.Tables[0].Rows[0]["IsIRDA_B"].ToString());
            //chkFormPurchase.Checked = bool.Parse(dsCompany.Tables[0].Rows[0]["IsFormPurchase_B"].ToString());
            //chkDeclarePolicy.Checked = bool.Parse(dsCompany.Tables[0].Rows[0]["IsDeclarePolicy_B"].ToString());
            //chkFireOther.Checked = bool.Parse(dsCompany.Tables[0].Rows[0]["IsFireOther_B"].ToString());
            //chkSiftRSMD.Checked = bool.Parse(dsCompany.Tables[0].Rows[0]["IsSiftRSMD_B"].ToString());
            //chkIRDARules.Checked = bool.Parse(dsCompany.Tables[0].Rows[0]["IsIRDARules_B"].ToString());
            txtInsuranceTo.Text = DateTime.Parse(dsCompany.Tables[0].Rows[0]["DateTo"].ToString()).ToString("dd/MM/yyyy");
            txtInsuranceFrom.Text = DateTime.Parse( dsCompany.Tables[0].Rows[0]["DateFrom"].ToString()).ToString("dd/MM/yyyy");
            txtRemark.Text = dsCompany.Tables[0].Rows[0]["Remark_V"].ToString();

            //txtFlNetPremium.Text= Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["NetPrimium_N"].ToString()),2).ToString();
            //txtFlServiceTax.Text= Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["ServiceTax_N"].ToString()),2).ToString();
            //txtFlOtherTax.Text = Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["OtherTax_N"].ToString()), 2).ToString();
            //txtFlGrPremium.Text= Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["GrossPrimium_N"].ToString()),2).ToString();
            //txtBuNetPremium.Text= Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["BurglaryNetPrimium_N"].ToString()),2).ToString();
            //txtBuServiceTax.Text= Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["BurglaryServiceTax_N"].ToString()),2).ToString();
            //txtBuOtherTax.Text= Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["BurglaryOtherTax_N"].ToString()),2).ToString();
            //txtBuGrPrimium.Text = Math.Round(double.Parse(dsCompany.Tables[0].Rows[0]["BurglaryGrossPrimium_N"].ToString()), 2).ToString();
            //txtComRemark.Text=dsCompany.Tables[0].Rows[0]["BurglaryRemark_V"].ToString();




        }
    }
    private bool CheckDate(string datestring)
    {
        try
        {
            DateTime.Parse(datestring, cult);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if(!CheckDate(txtInsuranceFrom.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('बिमा अवधि प्रारंभ की दिनांक सही नहीं है');</script>"); 
        }
        else if (!CheckDate(txtInsuranceTo.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('बिमा अवधि समाप्ति की दिनांक सही नहीं है');</script>");
        }
        else if (DateTime.Parse(txtInsuranceFrom.Text,cult) > DateTime.Now.Date)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('बिमा अवधि प्रारंभ की दिनांक वर्तमान दिनांक से पूर्व की है ');</script>");
        }
        else if (DateTime.Parse(txtInsuranceFrom.Text,cult) > DateTime.Parse(txtInsuranceTo.Text,cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('बिमा अवधि समाप्ति की दिनांक, प्रारंभ दिनांक से प्रूर्व की है');</script>");
        }
        else
        {
            obInsuranceCompanyRegistration.InsuranceCompanyTrno = int.Parse(hdnInsuranceCompanyTrno.Value);
            obInsuranceCompanyRegistration.FinancialYr = int.Parse(ddlFinaicalYear.SelectedValue);
            obInsuranceCompanyRegistration.CompanyName = txtInsuranceCompanyName.Text;

            //obInsuranceCompanyRegistration.IRDA = chkIRDA.Checked;
            //obInsuranceCompanyRegistration.FormPurchase = chkFormPurchase.Checked;
            //obInsuranceCompanyRegistration.DeclarePolicy = chkDeclarePolicy.Checked;
            //obInsuranceCompanyRegistration.FireOther = chkFireOther.Checked;

            obInsuranceCompanyRegistration.InsDateFrom = DateTime.Parse(txtInsuranceFrom.Text, cult).ToString("yyyy-MM-dd");
            obInsuranceCompanyRegistration.InsDateTo = DateTime.Parse(txtInsuranceTo.Text, cult).ToString("yyyy-MM-dd");
            obInsuranceCompanyRegistration.Remark = txtRemark.Text;

            //obInsuranceCompanyRegistration.NetPrimium = double.Parse(txtFlNetPremium.Text);
            //obInsuranceCompanyRegistration.ServiceTax = double.Parse(txtFlServiceTax.Text);
            //obInsuranceCompanyRegistration.OtherTax = double.Parse(txtFlOtherTax.Text);
            //obInsuranceCompanyRegistration.GrossPrimium = double.Parse(txtFlGrPremium.Text);
            //obInsuranceCompanyRegistration.BurglaryNetPrimium = double.Parse(txtBuNetPremium.Text);
            //obInsuranceCompanyRegistration.BurglaryServiceTax = double.Parse(txtBuServiceTax.Text);
            //obInsuranceCompanyRegistration.BurglaryOtherTax = double.Parse(txtBuOtherTax.Text);
            //obInsuranceCompanyRegistration.BurglaryGrossPrimium = double.Parse(txtBuGrPrimium.Text);
            //obInsuranceCompanyRegistration.BurglaryRemark = txtComRemark.Text;


            obInsuranceCompanyRegistration.TransID = int.Parse(hdnInsuranceCompanyTrno.Value);
            obInsuranceCompanyRegistration.InsuranceCompanyTrno = obInsuranceCompanyRegistration.InsertUpdate();

            for (int i = 0; i < GrdTechnicalCondition.Rows.Count; i++)
            {
                CheckBox chkTendorCondition = (CheckBox)GrdTechnicalCondition.Rows[i].FindControl("chkTechCondition");
                //if (chkTendorCondition.Checked)
                {
                    obInsuranceCompanyRegistration.TransID = -2;
                    obInsuranceCompanyRegistration.Tender_Cond_Id = int.Parse(GrdTechnicalCondition.DataKeys[i].Value.ToString());
                    obInsuranceCompanyRegistration.Tender_Cond_Value = chkTendorCondition.Checked;
                    obInsuranceCompanyRegistration.InsertUpdate();
                }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('रिकॉर्ड सफलतापूर्वक सुरक्षित कर लिया गया है');</script>");
            Response.Redirect("View_DIB_003.aspx");
        }
    }
}
