using System;
using MPTBCBussinessLayer.Admin;
using System.Data;
using System.Web.UI.WebControls;

public partial class Admin_ViewFormMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.Admin.FormMaster obFormMaster = new FormMaster();
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
            obFormMaster.FormTrno = int.Parse(hdnFormTrno.Value);
            obFormMaster.SubModuleTrno = int.Parse(ddSublModule.SelectedValue);
            obFormMaster.Status = ddlStatus.SelectedValue;
            obFormMaster.FormDesc = txtFormDesc.Text;
            obFormMaster.FormPath = txtFormPath.Text;
            obFormMaster.VisibleInLink = Convert.ToBoolean(rblShowInLink.SelectedValue.ToString());
            obFormMaster.OrderNo = int.Parse(txtOrder.Text);
            obFormMaster.TranID = int.Parse(hdnFormTrno.Value); 
            obFormMaster.InsertUpdate();            
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
        ddlSelectModule.Items.Insert(0,new ListItem("All","0"));
        fillSubModule();
    }


    protected void ddlSelectModule_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        obFormMaster.FormTrno = int.Parse(ddlSelectModule.SelectedValue);
        if (int.Parse(ddlSelectModule.SelectedValue) == 0)
        {
            obFormMaster.QueryType = 0;
        }
        else
        {
            obFormMaster.QueryType = 3;
        }

        gvFormMaster.PageIndex = 0;
        fillGrid();
      //  DataSet dsModuleMaster = obFormMaster.Select();
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
        obFormMaster.SubModuleTrno=0;
        DataSet dsSubModuleMaster= obFormMaster.Select();
        gvFormMaster.DataSource = dsSubModuleMaster.Tables[0];
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
        ddlStatus.SelectedValue = gvFormMaster.Rows[e.NewEditIndex].Cells[3].Text;
        txtFormDesc.Text = gvFormMaster.Rows[e.NewEditIndex].Cells[4].Text;
        txtFormPath.Text = gvFormMaster.Rows[e.NewEditIndex].Cells[5].Text;
        txtOrder.Text = gvFormMaster.Rows[e.NewEditIndex].Cells[7].Text;      
        //
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
    protected void ddSublModule_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillSubModule();

    }
}
