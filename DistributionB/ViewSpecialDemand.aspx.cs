using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class DistributionB_ViewSpecialDemand : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.SpecialBookDemand obSpecialBookDemand = new MPTBCBussinessLayer.DistributionB.SpecialBookDemand();
  
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillAcYr();
            FillLetterInfoGrid();
            
        }
    }
    private void FillAcYr()
    {
        obSpecialBookDemand.TransID = -1;
        ddlAcYr.DataSource = obSpecialBookDemand.Select();
        ddlAcYr.DataTextField = "AcYear";
        ddlAcYr.DataValueField = "Id";
        ddlAcYr.DataBind();
        ddlAcYr.Items.Insert(0, new ListItem("All", "0"));
    }
    private void FillLetterInfoGrid()
    {
        obSpecialBookDemand.TransID =-7;
        obSpecialBookDemand.QueryParameterValue = int.Parse(ddlAcYr.SelectedValue);
        GrdLetterInfo.DataSource = obSpecialBookDemand.Select();
        GrdLetterInfo.DataBind();

    }
    protected void btnNewFreeDistribution_Click(object sender, EventArgs e)
    {
        Response.Redirect("SpecialDemand.aspx");
    }
    protected void GrdLetterInfo_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
      
    }
    protected void GrdLetterInfo_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //obClassMaster = new ClassMaster();
        //obClassMaster.Delete(Convert.ToInt32(GrdClassMaster.DataKeys[e.RowIndex].Value.ToString()));
        //FillData();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillLetterInfoGrid();
    }
}
