using System;
using MPTBCBussinessLayer.Admin;
using System.Data;

public partial class DistributionB_DepartmentMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.DepartmentMaster obDepartmentMaster = new MPTBCBussinessLayer.DistributionB.DepartmentMaster();
       
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";    
        if (!IsPostBack)
        {
            fillGrid();
              
        }
        if(Session["UserID"]==null)
        {
            Response.Redirect("~/login.aspx");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obDepartmentMaster.DepTrno = int.Parse(hdnDepTrno.Value);
            obDepartmentMaster.DepName = txtDepartment.Text;           
            obDepartmentMaster.TranID = int.Parse(hdnDepTrno.Value);
            obDepartmentMaster.UserID = int.Parse(Session["UserID"].ToString());
            obDepartmentMaster.InsertUpdate();
            pnlDepartmentMaster.Visible = true;
            pnlNewDepartment.Visible = false;
            fillGrid();
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Saved Successfully";    
        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Duplicate entry";    
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
        obDepartmentMaster.DepTrno=0;
        DataSet dsDepartment= obDepartmentMaster.Select();
        gvDepartmentMaster.DataSource = dsDepartment.Tables[0];
        gvDepartmentMaster.DataBind();
    }

    protected void gvDepartmentMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        
        txtDepartment.Text = gvDepartmentMaster.Rows[e.NewEditIndex].Cells[1].Text;

        hdnDepTrno.Value = gvDepartmentMaster.DataKeys[e.NewEditIndex].Value.ToString(); // e.Keys[0].ToString();  //gvDepartmentMaster.Rows[e.NewEditIndex].Cells[0].Text;

        pnlDepartmentMaster.Visible = false;
        pnlNewDepartment.Visible = true;
        
    }


    protected void gvDepartmentMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        hdnDepTrno.Value = e.Keys[0].ToString(); // gvDepartmentMaster.Rows[e.RowIndex]. //.Cells[0].Text;
        try
        {
            obDepartmentMaster.Delete(int.Parse(hdnDepTrno.Value));
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Deleted Successfully";   
        }
        catch
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Can not delete department";   
        }
        fillGrid();
    }

    protected void gvDepartmentMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvDepartmentMaster.PageIndex = e.NewPageIndex;
        fillGrid();
    }
}
