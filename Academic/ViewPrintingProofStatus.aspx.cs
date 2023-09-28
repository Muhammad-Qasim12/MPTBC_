using System;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Academic_ViewPrintingProofStatus : System.Web.UI.Page
{
    MPTBCBussinessLayer.Academic.StatusMaster obStatusMaster;
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            FillData();
        }
    }
    public void FillData()
    {
        try
        {
            obStatusMaster = new MPTBCBussinessLayer.Academic.StatusMaster();
            obStatusMaster.StatusMasterTrno_I = 0;
            GrdStatusMaster.DataSource = obStatusMaster.Select();
            GrdStatusMaster.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void GrdStatusMaster_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obStatusMaster = new MPTBCBussinessLayer.Academic.StatusMaster();
            obStatusMaster.Delete(Convert.ToInt32(GrdStatusMaster.DataKeys[e.RowIndex].Value.ToString()));
            FillData();
            m.ShowMessage("u");
        }
        catch
        {
            m.ShowMessage("e");
        }
    }
    protected void GrdStatusMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdStatusMaster.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnNewStatus_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrintingProofStatus.aspx");
    }
}