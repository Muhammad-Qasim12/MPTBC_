using System;
using MPTBCBussinessLayer.Admin;
using System.Data;

public partial class Admin_ViewModuleMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.Admin.ModuleMaster obModuleMaster = new MPTBCBussinessLayer.Admin.ModuleMaster();
       
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGrid();
              
        }
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obModuleMaster.ModuleTrno_I = int.Parse(hdnModuleId.Value); 
            obModuleMaster.ModuleName = txtModuleName.Text;
            obModuleMaster.ModuleOrder = int.Parse(txtOrderNo.Text);
            obModuleMaster.TranID = int.Parse(hdnModuleId.Value); 
            obModuleMaster.InsertUpdate();
            
            pnlModuleMaster.Visible = true;
            pnlNewModule.Visible = false;
            fillGrid();
        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Duplicate entry found";
        }
    }
    protected void btnNewModule_Click(object sender, EventArgs e)
    {
        pnlModuleMaster.Visible = false;
        pnlNewModule.Visible = true;
        hdnModuleId.Value = "0";
        txtModuleName.Text = string.Empty;
        txtOrderNo.Text = string.Empty;
    }
    private void fillGrid()
    {
        obModuleMaster.ModuleTrno_I=0;
        DataSet dsModuleMaster= obModuleMaster.Select();
        gvModuleMaster.DataSource = dsModuleMaster.Tables[0];
        gvModuleMaster.DataBind();
    }
    
    protected void gvModuleMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        
        txtModuleName.Text = gvModuleMaster.Rows[e.NewEditIndex].Cells[1].Text;
        txtOrderNo.Text = gvModuleMaster.Rows[e.NewEditIndex].Cells[2].Text;
        hdnModuleId.Value = gvModuleMaster.DataKeys[e.NewEditIndex].Value.ToString(); //gvModuleMaster.Rows[e.NewEditIndex].Cells[0].Text;

        pnlModuleMaster.Visible = false;
        pnlNewModule.Visible = true;
        
    }


    protected void gvModuleMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        hdnModuleId.Value = gvModuleMaster.DataKeys[e.RowIndex].Value.ToString(); //gvModuleMaster.Rows[e.RowIndex].Cells[0].Text;
      
        obModuleMaster.Delete(int.Parse(hdnModuleId.Value));
        fillGrid();
    }

    protected void gvModuleMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvModuleMaster.PageIndex = e.NewPageIndex;
        fillGrid();
    }
    protected void gvModuleMaster_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
