using System;
using System.Data;

public partial class Distribution_FreeTextBooksDemandFromRSK : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.InsuranceCompanyRegistration obInsuranceCompanyRegistration = new MPTBCBussinessLayer.DistributionB.InsuranceCompanyRegistration();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obInsuranceCompanyRegistration.TransID = -5;
            ddlFyYear.DataSource = obInsuranceCompanyRegistration.Select();
            ddlFyYear.DataTextField = "FyYear";
            ddlFyYear.DataValueField = "FinancialYr_I";
            ddlFyYear.DataBind();

            ddlFyYear_OnSelectedIndexChanged(sender, e);
        }
    }

    private void FillInfoGrid()
    {
        obInsuranceCompanyRegistration.TransID = -3;
        obInsuranceCompanyRegistration.ParameterValue = int.Parse(ddlFyYear.SelectedValue);
        GrdInfo.DataSource = obInsuranceCompanyRegistration.Select();
        GrdInfo.DataBind();

    }
    protected void btnNewCompany_Click(object sender, EventArgs e)
    {
        obInsuranceCompanyRegistration.InsuranceCompanyTrno = int.Parse(ddlCompany.SelectedValue);
        obInsuranceCompanyRegistration.FinancialYr = int.Parse(ddlFyYear.SelectedValue);
        obInsuranceCompanyRegistration.TransID = -1;
        obInsuranceCompanyRegistration.InsertUpdate();

        FillInfoGrid();
    }
    protected void GrdInfo_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
     
        string str = GrdInfo.DataKeys[e.RowIndex].Value.ToString();
        obInsuranceCompanyRegistration.Delete(Convert.ToInt32(str));
        FillInfoGrid();
    }

    protected void GrdInfo_DataBound(object sender, EventArgs e)
    {
        
    }

    protected void ddlFyYear_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        obInsuranceCompanyRegistration.TransID = -3;
        obInsuranceCompanyRegistration.ParameterValue = int.Parse(ddlFyYear.SelectedValue);
        ddlCompany.DataSource = obInsuranceCompanyRegistration.Select();
        ddlCompany.DataTextField = "CompanyName_V";
        ddlCompany.DataValueField = "InsuranceCompanyTrno_I";
        ddlCompany.DataBind();

        FillInfoGrid();
    }
}
