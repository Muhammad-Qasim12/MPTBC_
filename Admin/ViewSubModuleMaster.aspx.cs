using System;
using MPTBCBussinessLayer.Admin;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_ViewSubModuleMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.Admin.SubModuleMaster obSubModuleMaster = new SubModuleMaster(); 
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGrid();
            fillModule();
        }
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obSubModuleMaster.SubModuleTrno = int.Parse(hdnSubModuleId.Value);
            obSubModuleMaster.ModuleTrno = int.Parse(ddlModule.SelectedValue);
            obSubModuleMaster.SubModuleName = txtSubModuleName.Text;            
            obSubModuleMaster.TranID = int.Parse(hdnSubModuleId.Value);

            obSubModuleMaster.OrderNo = int.Parse(txtOrderNo.Text);
            obSubModuleMaster.Path = txtPath.Text; 
            obSubModuleMaster.InsertUpdate();
            txtPath.Text = "";
            txtOrderNo.Text = "";
            pnlSubModuleMaster.Visible = true;
            pnlNewSubModule.Visible = false;
            fillGrid();
        }
        catch 
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Duplicate entry found";
        }
    }

    private void fillModule()
    {
        MPTBCBussinessLayer.Admin.ModuleMaster obModuleMaster = new MPTBCBussinessLayer.Admin.ModuleMaster();
        obModuleMaster.ModuleTrno_I = 0;
        DataSet dsModuleMaster = obModuleMaster.Select();
        ddlModule.DataSource = dsModuleMaster.Tables[0];
        ddlModule.DataValueField = "ModuleTrno_I";
        ddlModule.DataTextField = "ModuleName_V";
        ddlModule.DataBind();

    }
    protected void btnNewSubModule_Click(object sender, EventArgs e)
    {
        pnlSubModuleMaster.Visible = false;
        pnlNewSubModule.Visible = true;
        hdnSubModuleId.Value = "0";
        txtSubModuleName.Text = string.Empty;
        ddlModule.SelectedIndex = 0;
    }
    private void fillGrid()
    {
        obSubModuleMaster.SubModuleTrno=0;
        obSubModuleMaster.QueryType = 0;
        DataSet dsSubModuleMaster= obSubModuleMaster.Select();
        gvSubModuleMaster.DataSource = dsSubModuleMaster.Tables[0];
        gvSubModuleMaster.DataBind();
    }

    protected void gvSubModuleMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        txtSubModuleName.Text = gvSubModuleMaster.Rows[e.NewEditIndex].Cells[2].Text;
        Label lblModuleTr = (Label)gvSubModuleMaster.Rows[e.NewEditIndex].FindControl("gvlblModuleTrno_I");

        txtPath.Text = gvSubModuleMaster.Rows[e.NewEditIndex].Cells[4].Text.Trim().TrimEnd().TrimStart().Replace("&nbsp;", "");
        txtOrderNo.Text = gvSubModuleMaster.Rows[e.NewEditIndex].Cells[5].Text.Trim().TrimEnd().TrimStart().Replace("&nbsp;", "");
        
        
        ddlModule.SelectedValue = lblModuleTr.Text;
        hdnSubModuleId.Value = gvSubModuleMaster.DataKeys[e.NewEditIndex].Value.ToString();

        pnlSubModuleMaster.Visible = false;
        pnlNewSubModule.Visible = true;
        
    }


    protected void gvSubModuleMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
            hdnSubModuleId.Value = gvSubModuleMaster.DataKeys[e.RowIndex].Value.ToString();

            obSubModuleMaster.Delete(int.Parse(hdnSubModuleId.Value));
            fillGrid();
        }
        catch 
        {

            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Can not delete this record";
        }
        finally
        {

        }
    }

    protected void gvSubModuleMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvSubModuleMaster.PageIndex = e.NewPageIndex;
        fillGrid();
    }
    protected void gvSubModuleMaster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
