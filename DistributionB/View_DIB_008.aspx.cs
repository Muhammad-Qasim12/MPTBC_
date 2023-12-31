using System;
using System.Data;

public partial class Distribution_FreeTextBooksDemandFromRSK : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.ProcessBill obProcessBill = new MPTBCBussinessLayer.DistributionB.ProcessBill();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            FillLetterInfoGrid();
        }
    }
   
    private void FillLetterInfoGrid()
    {
        obProcessBill.TransID = -7;
        GrdLetterInfo.DataSource = obProcessBill.Select();
        GrdLetterInfo.DataBind();

    }
    protected void btnNewFreeDistribution_Click(object sender, EventArgs e)
    {
        Response.Redirect("DIB_005_ProcessBill.aspx");
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
}
