using System;
using MPTBCBussinessLayer.Admin;
using System.Data;

public partial class Academic_BookPublication : System.Web.UI.Page
{
    MPTBCBussinessLayer.Academic.DepartmentMaster obDepartmentMaster = new MPTBCBussinessLayer.Academic.DepartmentMaster();
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = "";    
        if (!IsPostBack)
        {
            fillGrid();              
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obDepartmentMaster.DepTrno = int.Parse(hdnDepTrno.Value);
            obDepartmentMaster.DepName = txtDepartment.Text;           
            obDepartmentMaster.TranID = int.Parse(hdnDepTrno.Value); 
            obDepartmentMaster.InsertUpdate();
            pnlDepartmentMaster.Visible = true;
            pnlNewDepartment.Visible = false;
            fillGrid();
            m.ShowMessage("s");
        }
        catch (Exception ex)
        {
            m.ShowMessage("e");
        }
    }
    protected void btnNewDepartment_Click(object sender, EventArgs e)
    {
        pnlDepartmentMaster.Visible = false;
        pnlNewDepartment.Visible = true;
        hdnDepTrno.Value = "0";
        txtDepartment.Text = string.Empty;       
    }
    private void fillGrid()
    {
        try
        {
            obDepartmentMaster.DepTrno = 0;
            DataSet dsDepartment = obDepartmentMaster.Select();
            gvDepartmentMaster.DataSource = dsDepartment.Tables[0];
            gvDepartmentMaster.DataBind();
        }
        catch (Exception)
        {
        }        
    }
    protected void gvDepartmentMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        try
        {
            txtDepartment.Text = gvDepartmentMaster.Rows[e.NewEditIndex].Cells[1].Text;
            hdnDepTrno.Value = gvDepartmentMaster.DataKeys[e.NewEditIndex].Value.ToString(); 
            // e.Keys[0].ToString();  //gvDepartmentMaster.Rows[e.NewEditIndex].Cells[0].Text;
            pnlDepartmentMaster.Visible = false;
            pnlNewDepartment.Visible = true;
        }
        catch (Exception)
        {
        }        
    }
    protected void gvDepartmentMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        hdnDepTrno.Value = e.Keys[0].ToString(); // gvDepartmentMaster.Rows[e.RowIndex]. //.Cells[0].Text;
        try
        {
            obDepartmentMaster.Delete(int.Parse(hdnDepTrno.Value));
            m.ShowMessage("d"); 
        }
        catch
        {
            m.ShowMessage("e");
        }
        fillGrid();
    }
    protected void gvDepartmentMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvDepartmentMaster.PageIndex = e.NewPageIndex;
        fillGrid();
    }
}
