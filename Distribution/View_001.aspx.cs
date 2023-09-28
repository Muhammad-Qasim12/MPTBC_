using System;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Admin_View_001 : System.Web.UI.Page
{
    DemandTypeMaster obDemandTypeMaster = null;
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

            obDemandTypeMaster = new DemandTypeMaster();
            obDemandTypeMaster.DemandTypeId  = 0;

            GrdDemandTypemaster.DataSource = obDemandTypeMaster.Select();
            GrdDemandTypemaster.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdDemandTypemaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obDemandTypeMaster = new DemandTypeMaster();
        obDemandTypeMaster.Delete(Convert.ToInt32(GrdDemandTypemaster.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }
    protected void GrdDemandTypemaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDemandTypemaster.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DIS_001_DemandTypeMaster.aspx");
    }
}