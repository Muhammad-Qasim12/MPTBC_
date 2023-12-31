using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class DistributionB_ViewDemandFreeTextBooks : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.FreeBooksDistribution obFreeBooksDistribution = new MPTBCBussinessLayer.DistributionB.FreeBooksDistribution();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            FillLetterInfoGrid();
            FillAcYr();
        }
    }
    private void FillAcYr()
    {
        obFreeBooksDistribution.TransID = -1;
        ddlAcYr.DataSource = obFreeBooksDistribution.Select();
        ddlAcYr.DataTextField = "AcYear";
        ddlAcYr.DataValueField = "Id";
        ddlAcYr.DataBind();
        ddlAcYr.Items.Insert(0, new ListItem("All", "0"));
    }
    private void FillLetterInfoGrid()
    {
        obFreeBooksDistribution.TransID = -7;
        GrdLetterInfo.DataSource = obFreeBooksDistribution.Select();
        GrdLetterInfo.DataBind();

    }
    protected void btnNewFreeDistribution_Click(object sender, EventArgs e)
    {
        Response.Redirect("DemandFreeTextBooks.aspx");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        obFreeBooksDistribution.TransID = -12;
        obFreeBooksDistribution.QueryParameterValue = int.Parse(ddlAcYr.SelectedValue);
        GrdLetterInfo.DataSource = obFreeBooksDistribution.Select();
        GrdLetterInfo.DataBind();
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
    protected void lnkAgrSave_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblFreeDisID = (Label)gv.FindControl("lblFreeDisID");
        CheckBox chkAgrStatus = (CheckBox)gv.FindControl("chkAgrStatus");
        obFreeBooksDistribution.TransID = -2;
        obFreeBooksDistribution.FreeBooksDistributionID = int.Parse(lblFreeDisID.Text);
        if (chkAgrStatus.Checked == true)
        {
            obFreeBooksDistribution.ApprovStatus = 1;
        }
        else
        {
            obFreeBooksDistribution.ApprovStatus = 2;
        }

        obFreeBooksDistribution.InsertUpdate();
        btnSearch_Click(sender, e);
        //objWorkPlan = new PPR_WorkPlan();
        //objWorkPlan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
        //objWorkPlan.LOITrId_I = int.Parse(lblLOIId_I.Text);
        //string Status = "";
      
        //objWorkPlan.VendorAgrSave(Status);
        //GridFillLoad();

        //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }
}
