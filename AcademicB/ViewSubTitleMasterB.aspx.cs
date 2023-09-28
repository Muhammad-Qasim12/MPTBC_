using System;
using System.Web.UI.WebControls;

public partial class AcademicB_ViewSubTitleMasterB : System.Web.UI.Page
{
    MPTBCBussinessLayer.AcademicB.SubTitle obSubTitleMaster = new MPTBCBussinessLayer.AcademicB.SubTitle();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }

    }

    private void FillGrid()
    {
        obSubTitleMaster.TitleID = 0;
        GrdTitle.DataSource = obSubTitleMaster.Select();
        GrdTitle.DataBind();
    }

    protected void GrdTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obSubTitleMaster.Delete(Convert.ToInt32(GrdTitle.DataKeys[e.RowIndex].Value.ToString()));
            FillGrid();
        }
        catch
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Can not delete this record');</script>");
        }
    }
    protected void GrdTitle_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GrdTitle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("SubTitleMasterB.aspx");
    }


}