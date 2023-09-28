using System;
using MPTBCBussinessLayer.Admin;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_ViewRoleMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.Admin.RoleMaster obRoleMaster = new RoleMaster();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillMoudle();
            fillGrid();           
        }
        mainDiv.Style.Add("display", "none");
        lblmsg.ForeColor = System.Drawing.Color.Red;
        lblmsg.Text = "";
    }

    private void FillMoudle()
    {
        obRoleMaster.QueryType = 4;
        ddlModule.DataSource = obRoleMaster.Select().Tables[0];
        ddlModule.DataValueField = "ModuleTrno_I";
        ddlModule.DataTextField = "ModuleName_V";
        ddlModule.DataBind();

    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        pnlRoleMaster.Visible = true;
        pnlNewRole.Visible = false;
        fillGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.ForeColor = System.Drawing.Color.Red;
        lblmsg.Text = "";
               
        try
        {
            bool isFormSelected =true;
            //for(int i =0; i< gvRoleForms.Rows.Count;i++)
            //{
            //    CheckBox chkFormSelected = (CheckBox)gvRoleForms.Rows[i].FindControl("chkSelectForm");
            //    if (chkFormSelected.Checked)
            //    {
            //        isFormSelected = true;
            //    }
            //}

            if (isFormSelected)
            {
               
                obRoleMaster.Roletrno = int.Parse(hdnRoletrno.Value);
                obRoleMaster.Role = txtRole.Text;
                obRoleMaster.TranID = int.Parse(hdnRoletrno.Value);
                obRoleMaster.ModuleTrno = int.Parse(ddlModule.SelectedValue);
                obRoleMaster.Roletrno = obRoleMaster.InsertUpdate();
               
                for (int i = 0; i < gvRoleForms.Rows.Count; i++)
                {
                    CheckBox chkFormSelected = (CheckBox)gvRoleForms.Rows[i].FindControl("chkSelectForm");
                    if (chkFormSelected.Checked)
                    {
                        obRoleMaster.TranID = -1;
                        Label lblFormno= (Label) gvRoleForms.Rows[i].FindControl("gvlblFormTrno");
                        obRoleMaster.FormTrno = int.Parse(lblFormno.Text);
                        obRoleMaster.InsertForm();
                    }
                }

                mainDiv.Style.Add("display", "block");
                lblmsg.ForeColor = System.Drawing.Color.Green;
                lblmsg.Text = "Record saved successfully";
                CommonFuction comm = new CommonFuction();
                comm.FillDatasetByProc("call USP_menu()");
            }
            else
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Please select at least on form";
               
            }
        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Duplicate entry found";
        }
    }

    protected void btnNewRole_Click(object sender, EventArgs e)
    {
        pnlRoleMaster.Visible = false;
        pnlNewRole.Visible = true;
        hdnRoletrno.Value = "0";
       
        txtRole.Text = string.Empty;
        obRoleMaster.QueryType = 1;
        fillGridForm();
        //ddlModule.SelectedIndex = 0;
        //ddSublModule.SelectedIndex = 0;
    }

    private void fillGrid()
    {
        obRoleMaster.QueryType = 0;
        obRoleMaster.Roletrno = 0;
        obRoleMaster.ModuleTrno = int.Parse(ddlModule.SelectedValue);
        DataSet dsRoleMaster = obRoleMaster.Select();
        gvRoleMaster.DataSource = dsRoleMaster.Tables[0];
        gvRoleMaster.DataBind();
    }

    private void fillGridForm()
    {
        
        obRoleMaster.Roletrno = int.Parse(hdnRoletrno.Value);
        obRoleMaster.ModuleTrno = int.Parse(ddlModule.SelectedValue);
        DataSet dsFormMaster = obRoleMaster.Select();
        gvRoleForms.DataSource = dsFormMaster.Tables[0];
        gvRoleForms.DataBind();
    }
    public bool ConvertValue(object value)
    {
        if (value.ToString() == "true")
            return true;
        else    
            return false;
        
    }
    protected void gvRoleMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        
        hdnRoletrno.Value = gvRoleMaster.DataKeys[e.NewEditIndex].Value.ToString(); //gvRoleMaster.Rows[e.NewEditIndex].Cells[0].Text;
        ////Label lblObject = (Label)gvRoleMaster.Rows[e.NewEditIndex].FindControl("gvlblModuleTr");
        ////ddlModule.SelectedValue = lblObject.Text;
        ////lblObject = (Label)gvRoleMaster.Rows[e.NewEditIndex].FindControl("gvlblSubModuleTrno");
        ////ddlStatus.SelectedValue = gvRoleMaster.Rows[e.NewEditIndex].Cells[3].Text;
        ////txtFormDesc.Text = gvRoleMaster.Rows[e.NewEditIndex].Cells[4].Text;
        txtRole.Text = gvRoleMaster.Rows[e.NewEditIndex].Cells[1].Text;
        obRoleMaster.QueryType = 3;
        fillGridForm();

        pnlRoleMaster.Visible = false;
        pnlNewRole.Visible = true;
        
    }


    protected void gvRoleMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        //hdnRoletrno.Value = gvRoleMaster.Rows[e.RowIndex].Cells[0].Text;
        hdnRoletrno.Value = gvRoleMaster.DataKeys[e.RowIndex].Value.ToString();
        obRoleMaster.Delete(int.Parse(hdnRoletrno.Value));
        fillGrid();
    }

    protected void gvRoleMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvRoleMaster.PageIndex = e.NewPageIndex;
        fillGrid(); 
    }


    protected void ddlModule_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        obRoleMaster.QueryType = 3;
        fillGridForm();
    }
}
