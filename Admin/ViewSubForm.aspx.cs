using MPTBCBussinessLayer.Admin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ViewSubForm : System.Web.UI.Page
{
    MPTBCBussinessLayer.Admin.FormMaster obFormMaster = new FormMaster();
    MPTBCBussinessLayer.Admin.SubMenuForm obSubMenu = new SubMenuForm();

    DBAccess db = new DBAccess();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {         
            fillModule();
            fillGrid();
        }
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            obFormMaster.FormTrno = int.Parse(hdnFormTrno.Value);
            obFormMaster.SubModuleTrno = int.Parse(ddSublModule.SelectedValue);
            obFormMaster.Status = ddlStatus.SelectedValue;
            obFormMaster.FormDesc = txtFormDesc.Text;
            obFormMaster.FormPath = txtFormPath.Text;
            obFormMaster.VisibleInLink = Convert.ToBoolean(rblShowInLink.SelectedValue.ToString());
            obFormMaster.OrderNo = int.Parse(txtOrder.Text);
            obFormMaster.TranID = int.Parse(hdnFormTrno.Value);
            obFormMaster.MainFormTrno_I = int.Parse(ddlFormName.SelectedValue.ToString());
          
           obFormMaster.SubFrmInsertUpdate();
            pnlFormMaster.Visible = true;
            pnlNewForm.Visible = false;
            ddlSelectModule_OnSelectedIndexChanged(sender, e);
            fillGrid();
        }
        catch
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "";
        }
    }

    protected void ddlFormName_Init(object sender, EventArgs e)
    {
        ddlFormName.DataSource = string.Empty;
        ddlFormName.DataBind();
        ddlFormName.Items.Insert(0, "Select");
    }
    private void fillModule()
    {

        obFormMaster.FormTrno = 0;
        obFormMaster.QueryType = 1;

        DataSet dsModuleMaster = obFormMaster.Select();
        ddlModule.DataSource = dsModuleMaster.Tables[0];
        ddlModule.DataValueField = "ModuleTrno_I";
        ddlModule.DataTextField = "ModuleName_V";
        ddlModule.DataBind();
        ddlSelectModule.DataSource = dsModuleMaster.Tables[0];
        ddlSelectModule.DataValueField = "ModuleTrno_I";
        ddlSelectModule.DataTextField = "ModuleName_V";
        ddlSelectModule.DataBind();
        ddlSelectModule.Items.Insert(0, new ListItem("All", "0"));
        fillSubModule();
    }


    protected void ddlSelectModule_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        obFormMaster.FormTrno = int.Parse(ddlSelectModule.SelectedValue);
        //if (int.Parse(ddlSelectModule.SelectedValue) == 0)
        //{
        //    obFormMaster.QueryType = 2;
        //}
        //else
        //{
        //    obFormMaster.QueryType = 3;
        //}

        gvFormMaster.PageIndex = 0;
        fillGrid();
        //  DataSet dsModuleMaster = obFormMaster.Select();
    }


    protected void ddSublModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddSublModule.SelectedItem.Text != "Select")
        {
//            db.execute(@"SELECT FormTrno_I, SubModuleTrno_I, Status_V, FormDesc_V, FormPath_V, VisibleInLink_B, OrderNo_I
// FROM adm_formmaster where SubModuleTrno_I='" + ddSublModule.SelectedValue.ToString() + "' and VisibleInLink_B=1", DBAccess.SQLType.IS_QUERY);
            obSubMenu.QueryType = 0;
            obSubMenu.ParameterValue = int.Parse(ddSublModule.SelectedValue.ToString());
          
            ddlFormName.DataSource =   obSubMenu.Select().Tables[0];
            ddlFormName.DataValueField = "FormTrno_I";
            ddlFormName.DataTextField = "FormDesc_V";
            ddlFormName.DataBind();
            ddlFormName.Items.Insert(0, "Select");
        }
    }

    protected void ddlFormName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFormName.SelectedItem.Text != "Select")
        {
//            db.execute(@"SELECT FormTrno_I, SubModuleTrno_I, Status_V, FormDesc_V, FormPath_V, VisibleInLink_B, OrderNo_I
// FROM adm_formmaster where FormTrno_I='" + ddlFormName.SelectedValue.ToString() + "'", DBAccess.SQLType.IS_QUERY);
            obSubMenu.QueryType = 1;
            obSubMenu.ParameterValue = int.Parse(ddlFormName.SelectedValue.ToString());
            DataSet ds = obSubMenu.Select();
           txtFormDesc.Text=ds.Tables[0].Rows[0]["FormDesc_V"].ToString();
           txtFormPath.Text = ds.Tables[0].Rows[0]["FormPath_V"].ToString();
           ddlStatus.ClearSelection();
           ddlStatus.Items.FindByText(ds.Tables[0].Rows[0]["Status_V"].ToString()).Selected = true;
          //  Status_V
        }
    }
    protected void btnNewForm_Click(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        pnlFormMaster.Visible = false;
        pnlNewForm.Visible = true;
        hdnFormTrno.Value = "0";
        ddlStatus.SelectedValue = string.Empty;
        txtFormDesc.Text = string.Empty;
        txtFormPath.Text = string.Empty;

        //ddlModule.SelectedIndex = 0;
        //ddSublModule.SelectedIndex = 0;
    }
    private void fillGrid()
    {
//        db.execute(@"SELECT   adm_Subformmaster.FormTrno_I,
//                          adm_modulemaster.ModuleTrno_I,
//                          adm_modulemaster.ModuleName_V,
//                          adm_modulemaster.ModuleOrderNO_I,
//                          adm_submodulemaster.SubModuleTrno_I  ,
//                          adm_submodulemaster.SubModuleName_V,
//                          adm_Subformmaster.Status_V ,
//                          adm_Subformmaster.FormDesc_V  ,
//                          adm_Subformmaster.FormPath_V  ,
//                          adm_Subformmaster.VisibleInLink_B   ,
//                          adm_Subformmaster.OrderNo_I,MainFormTrno_I,
//fm.FormDesc_V FormDesc_VM
//                  FROM
//                          adm_Subformmaster
//                  INNER  JOIN
//                          adm_submodulemaster ON
//                          adm_submodulemaster.SubModuleTrno_I=adm_Subformmaster.SubModuleTrno_I
//                  INNER JOIN
//                          adm_modulemaster ON
//                          adm_modulemaster.ModuleTrno_I=adm_submodulemaster.ModuleTrno_I
//inner join adm_formmaster fm on fm.FormTrno_I=adm_Subformmaster.MainFormTrno_I;", DBAccess.SQLType.IS_QUERY);
        obSubMenu.QueryType = 2;
        obSubMenu.ParameterValue = int.Parse(ddlSelectModule.SelectedValue.ToString());
        DataSet ds = obSubMenu.Select(); // db.records();
        gvFormMaster.DataSource = ds.Tables[0];
        gvFormMaster.DataBind();
    }
    private void fillSubModule()
    {

        obFormMaster.QueryType = 2;
        obFormMaster.FormTrno = int.Parse(ddlModule.SelectedValue);
        //obSubModuleMaster.SubModuleTrno = int.Parse(ddlModule.SelectedValue);
        DataSet dsSubModuleMaster = obFormMaster.Select();
        ddSublModule.DataSource = dsSubModuleMaster.Tables[0];
        ddSublModule.DataValueField = "SubModuleTrno_I";
        ddSublModule.DataTextField = "SubModuleName_V";
        ddSublModule.DataBind();
    }
    protected void gvFormMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        hdnFormTrno.Value = gvFormMaster.DataKeys[e.NewEditIndex].Value.ToString();
        Label lblObject = (Label)gvFormMaster.Rows[e.NewEditIndex].FindControl("gvlblModuleTr");
        ddlModule.SelectedValue = lblObject.Text;

        fillSubModule();

        lblObject = (Label)gvFormMaster.Rows[e.NewEditIndex].FindControl("gvlblSubModuleTrno");
        ddSublModule.SelectedValue = lblObject.Text;
        ddlStatus.SelectedValue = gvFormMaster.Rows[e.NewEditIndex].Cells[4].Text;
        txtFormDesc.Text = gvFormMaster.Rows[e.NewEditIndex].Cells[5].Text;
        txtFormPath.Text = gvFormMaster.Rows[e.NewEditIndex].Cells[6].Text;
        txtOrder.Text = gvFormMaster.Rows[e.NewEditIndex].Cells[8].Text;

        ddSublModule_SelectedIndexChanged(sender, e);
       // ddlFormName_SelectedIndexChanged(sender, e);
        try
        {
            ddlFormName.ClearSelection();
            ddlFormName.Items.FindByValue(gvFormMaster.Rows[e.NewEditIndex].Cells[9].Text).Selected = true;
        }
        catch { }
        CheckBox chkVisibleinLink_B = new CheckBox();
        chkVisibleinLink_B = (CheckBox)gvFormMaster.Rows[e.NewEditIndex].FindControl("gvchkVisibleinLink_B");
        if (chkVisibleinLink_B.Checked)
        {
            rblShowInLink.SelectedIndex = 0;
        }
        else
        {
            rblShowInLink.SelectedIndex = 1;
        }

        pnlFormMaster.Visible = false;
        pnlNewForm.Visible = true;
    }


    protected void gvFormMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
        try
        {
            hdnFormTrno.Value = gvFormMaster.DataKeys[e.RowIndex].Value.ToString();

            obFormMaster.Delete(int.Parse(hdnFormTrno.Value));
            fillGrid();
        }
        catch
        {

            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Can not delete this record";
        }

    }

    protected void gvFormMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvFormMaster.PageIndex = e.NewPageIndex;
        obFormMaster.FormTrno = int.Parse(ddlSelectModule.SelectedValue);
        if (int.Parse(ddlSelectModule.SelectedValue) == 0)
        {
            obFormMaster.QueryType = 0;
        }
        else
        {
            obFormMaster.QueryType = 3;
        }
        fillGrid();
    }
    
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSubModule();
    }
}
