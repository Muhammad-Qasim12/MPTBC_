using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.AcademicB;
using System.Data;
using System.Globalization;

public partial class AcademicB_ViewDemandOtherthanTextbook : System.Web.UI.Page
{
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    DemandCreation obDemandCreation = new DemandCreation();
    
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

            obDemandCreation.QueryType = -5;            
            GrdCategoryDetails.DataSource = obDemandCreation.Select();
            GrdCategoryDetails.DataBind();

        }
        catch
        {
        }
        finally
        {
            
        }
    }
    protected void GrdCategoryDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //obPRI_CategoryMaster = new PRI_CategoryMaster();
        //string str = GrdCategoryDetails.DataKeys[e.RowIndex].Value.ToString();
        //obPRI_CategoryMaster.Delete(Convert.ToInt32(str));
        //FillData();
    }
    protected void GrdCategoryDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdCategoryDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewOrderAgreementInfo.aspx");
    }
}