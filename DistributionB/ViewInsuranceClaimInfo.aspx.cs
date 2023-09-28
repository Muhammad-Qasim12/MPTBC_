using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.DistributionB;

public partial class DistributionB_ViewInsuranceClaimInfo : System.Web.UI.Page
{
    InsuranceClaimSettlement obInsuranceClaimSettlement = null;
    CommonFuction obCommonFuction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }
    public void FillData()
    {
        try
        {
            obInsuranceClaimSettlement = new InsuranceClaimSettlement();
            obInsuranceClaimSettlement.ClaimId_I = 0;
            GrdClaimDetail.DataSource = obInsuranceClaimSettlement.Select();
            GrdClaimDetail.DataBind();
        }
        catch
        {
        }
        finally
        { obInsuranceClaimSettlement = null; }

    }
    protected void GrdItemCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obInsuranceClaimSettlement = new InsuranceClaimSettlement();
            string str = GrdClaimDetail.DataKeys[e.RowIndex].Value.ToString();
            obInsuranceClaimSettlement.Delete(Convert.ToInt32(str));
            FillData();
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कृपया..पहले अन्य पेजों से जानकारी हटाएं..');</script>");
        }
        finally
        { obInsuranceClaimSettlement = null; }
    }
    protected void GrdItemCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdClaimDetail.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("InsuranceClaimInfo.aspx");
    }
}