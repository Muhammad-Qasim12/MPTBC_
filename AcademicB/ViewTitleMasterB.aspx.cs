using System;
using System.Web.UI.WebControls;

public partial class AcademicB_ViewTitleMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.AcademicB.TitleMaster obTitleMaster = new MPTBCBussinessLayer.AcademicB.TitleMaster();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }

    }

    private void FillGrid()
    {
        obTitleMaster.TitleID = 0;
        GrdTitle.DataSource = obTitleMaster.Select();
        GrdTitle.DataBind();
    }

    protected void GrdTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obTitleMaster.Delete(Convert.ToInt32(GrdTitle.DataKeys[e.RowIndex].Value.ToString()));
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
        Response.Redirect("TitleMasterB.aspx");
    }


}