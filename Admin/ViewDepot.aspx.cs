using System;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;


public partial class Admin_ViewDepot : System.Web.UI.Page
{
   // CultureInfo cult = new CultureInfo("gu-IN", true);
    DPT_DepotMaster obDPT_DepotMaster = null;
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
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = 0;
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["DepoTrno_I"]);
            GrdDepot.DataSource = obDPT_DepotMaster.Select();
            GrdDepot.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdDepot_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //obDPT_DepotMaster = new DPT_DepotMaster();
        //string str = GrdDepot.DataKeys[e.RowIndex].Value.ToString();
        //obDPT_DepotMaster.Delete(Convert.ToInt32(str));
        FillData();
    }
    protected void GrdDepot_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdDepot.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DepotMaster.aspx");
    }
}