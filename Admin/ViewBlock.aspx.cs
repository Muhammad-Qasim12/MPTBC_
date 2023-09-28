using System;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Admin_ViewBlock : System.Web.UI.Page
{
    Blockmaster obBlockmaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
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
           
            obBlockmaster = new Blockmaster();
            obBlockmaster.BlockTrno_I = 0;
            
            GrdBlockmaster.DataSource = obBlockmaster.Select();
            GrdBlockmaster.DataBind();

        }
        catch
        {
        }

    }
    protected void GrdAdvanceDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obBlockmaster = new Blockmaster();
            obBlockmaster.Delete(Convert.ToInt32(GrdBlockmaster.DataKeys[e.RowIndex].Value.ToString()));
            FillData();
        }
        catch
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Can not delte this record";
        }
    }
    protected void GrdAdvanceDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
         GrdBlockmaster.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("BlockMaster.aspx");
    }
}