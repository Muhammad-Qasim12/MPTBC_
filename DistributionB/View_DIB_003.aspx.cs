using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Distribution_FreeTextBooksDemandFromRSK : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.InsuranceCompanyRegistration obInsuranceCompanyRegistration = new MPTBCBussinessLayer.DistributionB.InsuranceCompanyRegistration();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            FillInfoGrid();
        }
    }

    private void FillInfoGrid()
    {
        obInsuranceCompanyRegistration.TransID = 0;
        GrdInfo.DataSource = obInsuranceCompanyRegistration.Select();
        GrdInfo.DataBind();

    }
    protected void btnNewCompany_Click(object sender, EventArgs e)
    {
        Response.Redirect("DIB_003_InsuranceTenderInfo.aspx");
    }
    protected void GrdInfo_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
     
        
        string str = GrdInfo.DataKeys[e.RowIndex].Value.ToString();
        
        obInsuranceCompanyRegistration.Delete(Convert.ToInt32(str));
        FillInfoGrid();
    }
    protected void GrdInfo_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //obClassMaster = new ClassMaster();
        //obClassMaster.Delete(Convert.ToInt32(GrdClassMaster.DataKeys[e.RowIndex].Value.ToString()));
        //FillData();
    }
    protected void GrdInfo_DataBinding(object sender, EventArgs e)
    {

    }
    protected void GrdInfo_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex >= 0)
        {
            obInsuranceCompanyRegistration.TransID = -6;
            Label lblCmpId = (Label)e.Row.FindControl("lblCmpId");
            obInsuranceCompanyRegistration.ParameterValue = int.Parse(lblCmpId.Text);
            GridView grdDetails = (GridView)e.Row.FindControl("GrdSpecDetails");
            grdDetails.DataSource = obInsuranceCompanyRegistration.Select();
            grdDetails.DataBind();
        }
    }
}
