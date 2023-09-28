using System;
using MPTBCBussinessLayer.Admin;
using System.Data;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Paper;
using Yojnaservice;

public partial class Admin_UserMaster : System.Web.UI.Page
{
    RoleMaster obRoleMaster = new RoleMaster();
    YF_WebService obj = new YF_WebService();
    DataSet ds;
    DataTable dt;
    MPTBCBussinessLayer.Admin.UserMaster obUserMaster = new UserMaster();
    PPR_StockAuditAndVerification objStockAuditAndVerification = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obUserMaster.UserID = 0;
            obUserMaster.QueryType = -1;

            DataSet dsUserMaster = obUserMaster.Select();
            ddlSearchRole.DataSource = dsUserMaster.Tables[0];
            ddlSearchRole.DataValueField = "RoleTrno_I";
            ddlSearchRole.DataTextField = "Role_V";
            ddlSearchRole.DataBind();
            ddlSearchRole.Items.Insert(0, new ListItem("--All--", "0"));
            // dt = obj.Get_Emp_Details();
            fillGrid();
            fillRole();
            trLoginSts.Visible = false;
        }
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
        pnlUserMaster.Visible = true;
        pnlNewUser.Visible = false;
    }
    public void OfficeFill()
    {
        objStockAuditAndVerification = new PPR_StockAuditAndVerification();
        ddlOfficeName.DataSource = objStockAuditAndVerification.OfficerDesignationmAdminFill();
        ddlOfficeName.DataTextField = "Name";
        ddlOfficeName.DataValueField = "AgencyID";
        ddlOfficeName.DataBind();
        ddlOfficeName.Items.Insert(0, "Select");
    }
    //protected void ddlSearch_Init(object sender, EventArgs e)
    //{
    //    obRoleMaster.QueryType = 0;
    //    obRoleMaster.Roletrno = 0;
    //    obRoleMaster.ModuleTrno = 0;
    //    DataSet dsRoleMaster = obRoleMaster.Select();
    //    ddlSearch.DataSource = dsRoleMaster;
    //    ddlSearch.DataValueField = "Roletrno_I";
    //    ddlSearch.DataTextField = "Role_V";
    //    ddlSearch.DataBind();
    //    ddlSearch.Items.Insert(0, "All");
    //}

    protected void ddlOfficeName_Init(object sender, EventArgs e)
    {
        OfficeFill();
    }

    protected void ddlUserDepart_Init(object sender, EventArgs e)
    {
        obRoleMaster.QueryType = 5;
        obRoleMaster.Roletrno = 0;
        obRoleMaster.ModuleTrno = 0;
        DataSet dsRoleMaster = obRoleMaster.UserDepartFill();
        ddlUserDepart.DataSource = dsRoleMaster;
        ddlUserDepart.DataValueField = "Dpt_I";
        ddlUserDepart.DataTextField = "DptName";
        ddlUserDepart.DataBind();
        ddlUserDepart.Items.Insert(0, "Select");

    }

    protected void ddlBranchName_Init(object sender, EventArgs e)
    {
        try
        {
            ddlBranchName.DataSource = obj.GetAllBranches("00001,00002");
            ddlBranchName.DataTextField = "AgencyName";
            ddlBranchName.DataValueField = "AgencyID";
            ddlBranchName.DataBind();
        }
        catch { }
    }
    protected void ddlUserFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlUserFrom.SelectedItem.Text != "Select")
        {
            //try
            //{
            //    ddlBranchName.DataSource = obj.GetAllBranches(ddlUserFrom.SelectedItem.Value.ToString());
            //    ddlBranchName.DataTextField = "AgencyName";
            //    ddlBranchName.DataValueField = "AgencyID";
            //    ddlBranchName.DataBind();
            //}
            //catch { }
        }
        pnlUserMaster.Visible = false;
        pnlNewUser.Visible = true;
    }



    protected void btnSearch_Click(object sender, EventArgs e)
    {
        fillGrid();
        //if (ddlSearch.SelectedItem.Text == "All")
        //{
        //    obUserMaster.UserID = 0;
        //    obUserMaster.QueryType = 0;
        //}
        //else
        //{
        //    obUserMaster.UserID = int.Parse(ddlSearch.SelectedItem.Value);
        //    obUserMaster.QueryType = 2;
        //}
        //DataSet dsUserMaster = obUserMaster.Select();
        //gvUserMaster.DataSource = dsUserMaster.Tables[0];
        //gvUserMaster.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (txtPassword.Text == txtRePassword.Text)
            {

                obUserMaster.UserID = int.Parse(hdnUserTrno.Value);
                obUserMaster.UserName = txtUsername.Text;
                obUserMaster.Password = txtRePassword.Text;
                obUserMaster.RoleTrno = int.Parse(ddlRole.SelectedValue);
                obUserMaster.UserType = ddlUserType.SelectedValue;
                obUserMaster.TranID = int.Parse(hdnUserTrno.Value);
                obUserMaster.LoginSts = ddlLoginStatus.SelectedItem.Text;

                obUserMaster.EmpId = ddlOfficeName.SelectedItem.Value;
                obUserMaster.UserFromDPHO = ddlUserFrom.SelectedItem.Value;
                obUserMaster.UserDpt_I = int.Parse(ddlUserDepart.SelectedItem.Value);
                obUserMaster.BranchId = "2";//ddlBranchName.SelectedItem.Value;

                string RoleBothSts = "";
                foreach (ListItem chk in chkCoreModuleRights.Items)
                {
                    if (chk.Text == "Business Module")
                    {
                        if (chk.Selected == true)
                        {
                            RoleBothSts = "Business Module";
                        }
                    }

                    if (chk.Text == "Code Module")
                    {
                        if (chk.Selected == true)
                        {
                            obUserMaster.CoreRoleId = int.Parse(ddlCoreRole.SelectedItem.Value);
                            obUserMaster.CoreSts = "Yes";
                            if (RoleBothSts == "Business Module")
                            {
                                RoleBothSts = "Both";
                            }
                            else
                            {
                                RoleBothSts = "Code Module";
                            }
                        }
                        else
                        {
                            obUserMaster.CoreRoleId = 0;
                            obUserMaster.CoreSts = "No";
                        }
                    }
                }
                obUserMaster.RoleAccess = RoleBothSts;


                bool ChkUser;
                ds = obUserMaster.InsertUpdateWithHistory();
                //if (hdnUserTrno.Value != "0")
                //{ ChkUser = true; }
                //else
                //{
                if (ds.Tables[0].Rows[0]["HrdID"].ToString() == "No")
                {
                    ChkUser = obj.CheckUserValidation(txtUsername.Text, txtPassword.Text, int.Parse(ddlCoreRole.SelectedItem.Value.ToString()), ddlOfficeName.SelectedItem.Value.ToString(), "2");
                }
                else
                {
                    ChkUser = true;
                }
                //  }
                if (ChkUser == true)
                {
                    if (ds.Tables[0].Rows[0]["PwdCount"].ToString() == "0")
                    {
                        //if (chkCoreModuleRights.Checked == true)
                        //{
                        if (ds.Tables[0].Rows[0]["HrdID"].ToString() == "No")
                        {
                            try
                            {
                                DataTable Dt;
                                Dt = obj.SaveUser(ds.Tables[0].Rows[0]["LastId"].ToString(), txtUsername.Text, txtPassword.Text, int.Parse(ddlCoreRole.SelectedItem.Value.ToString()),
                                    ddlOfficeName.SelectedItem.Value.ToString(), "2");
                                if (Dt.Rows.Count > 0)
                                {
                                    obUserMaster.PrathamIdUpdate(ds.Tables[0].Rows[0]["LastId"].ToString(), Dt.Rows[0][0].ToString(), 0);
                                }
                            }
                            catch (Exception ex)
                            {
                                mainDiv.Style.Add("display", "block");
                                lblmsg.Text = lblmsg.Text + "Please check core section access." + ex.Message.ToString();
                                pnlUserMaster.Visible = false;
                                pnlNewUser.Visible = true;
                            }
                        }
                        //else
                        //{
                        //    ChkUser = obj.CheckUserValidation(txtUsername.Text, txtPassword.Text, int.Parse(ddlCoreRole.SelectedItem.Value.ToString()), ddlOfficeName.SelectedItem.Value.ToString(), ddlBranchName.SelectedItem.Value.ToString());
                        //    if (ChkUser == true)
                        //    {
                        //        DataTable Dt;
                        //        Dt = obj.SaveUser(ds.Tables[0].Rows[0]["LastId"].ToString(), txtUsername.Text, txtPassword.Text, int.Parse(ddlCoreRole.SelectedItem.Value.ToString()),
                        //            ddlOfficeName.SelectedItem.Value.ToString(), ddlBranchName.SelectedItem.Value.ToString());
                        //        if (Dt.Rows.Count > 0)
                        //        {
                        //            obUserMaster.PrathamIdUpdate(ds.Tables[0].Rows[0]["LastId"].ToString(), Dt.Rows[0][0].ToString(), 0);
                        //        }
                        //    }
                        //}
                        //}
                        pnlUserMaster.Visible = true;
                        pnlNewUser.Visible = false;
                        fillGrid();
                    }
                    else
                    {
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "UserName Or Employee ID Or Password Already Exist ";
                        pnlUserMaster.Visible = false;
                        pnlNewUser.Visible = true;
                    }
                }
                else
                {
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "UserName Or Employee ID Or Password Already Exist ";
                    pnlUserMaster.Visible = false;
                    pnlNewUser.Visible = true;
                }
            }
            else
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Password and confirm password not match";
                pnlUserMaster.Visible = false;
                pnlNewUser.Visible = true;

            }
        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please check your data." + ex.Message.ToString();
            pnlUserMaster.Visible = false;
            pnlNewUser.Visible = true;
        }
    }

    private void fillRole()
    {
        //Yojnaservice.YF_WebServiceSoapClient obj = new Yojnaservice.YF_WebServiceSoapClient();
        //DataTable dt = obj.Get_Emp_Details();
        try
        {
            ddlCoreRole.DataSource = obj.GetRoles();
            ddlCoreRole.DataValueField = "FormRoleId";
            ddlCoreRole.DataTextField = "FormRoleName";
            ddlCoreRole.DataBind();
        }
        catch
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please check core section access.";
            pnlUserMaster.Visible = false;
            pnlNewUser.Visible = true;
            ListItem a = new ListItem();
            a.Value = "57";
            a.Text = "TBC";

            ddlCoreRole.DataSource = string.Empty;
            ddlCoreRole.DataBind();
            ddlCoreRole.Items.Insert(0, a);

        }
        obUserMaster.UserID = 0;
        obUserMaster.QueryType = -1;
        DataSet dsUserMaster = obUserMaster.Select();
        ddlRole.DataSource = dsUserMaster.Tables[0];
        ddlRole.DataValueField = "RoleTrno_I";
        ddlRole.DataTextField = "Role_V";
        ddlRole.DataBind();
    }

    protected void chkCoreModuleRights_CheckedChanged(object sender, EventArgs e)
    {
        pnlUserMaster.Visible = false;
        pnlNewUser.Visible = true;
        foreach (ListItem chk in chkCoreModuleRights.Items)
        {


            if (chk.Text == "Code Module")
            {
                if (chk.Selected == true)
                {
                    trBranchId.Visible = true;
                    trCoreRole.Visible = true;
                    try
                    {
                        ddlBranchName.DataSource = obj.GetAllBranches("00001,00002");
                        ddlBranchName.DataTextField = "AgencyName";
                        ddlBranchName.DataValueField = "AgencyID";
                        ddlBranchName.DataBind();
                    }
                    catch { }
                }
                else
                {
                    trBranchId.Visible = false;
                    trCoreRole.Visible = false;
                    try
                    {
                        ddlUserFrom.ClearSelection();
                        ddlUserFrom.Items.FindByValue("00001").Selected = true;

                        ddlBranchName.DataSource = obj.GetAllBranches("00001,00002");
                        ddlBranchName.DataTextField = "AgencyName";
                        ddlBranchName.DataValueField = "AgencyID";
                        ddlBranchName.DataBind();
                    }
                    catch { }
                }
            }
        }


        pnlUserMaster.Visible = false;
        pnlNewUser.Visible = true;
    }
    protected void btnNewUser_Click(object sender, EventArgs e)
    {
        pnlUserMaster.Visible = false;
        pnlNewUser.Visible = true;
        hdnUserTrno.Value = "0";
        // ddlRole.SelectedIndex = 0;
        txtPassword.Text = string.Empty;
        txtRePassword.Text = string.Empty;
        txtUsername.Text = string.Empty;

        //ddlModule.SelectedIndex = 0;
        //ddSublModule.SelectedIndex = 0;
    }
    //private void fillGrid()
    //{
    //    obUserMaster.UserID=0;
    //    obUserMaster.QueryType = 0;

    //    DataSet dsUserMaster= obUserMaster.Select();
    //    gvUserMaster.DataSource = dsUserMaster.Tables[0];
    //    gvUserMaster.DataBind();
    //}
    private void fillGrid()
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_ADM007_UserMasterSearch", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mQueryType", 0);
        obDBAccess.addParam("mRoleID", ddlSearchRole.SelectedValue);
        obDBAccess.addParam("mUserName", txtSearchUser.Text);

        DataSet dsUserMaster = obDBAccess.records();
        gvUserMaster.DataSource = dsUserMaster.Tables[0];
        gvUserMaster.DataBind();
    }
    protected void gvUserMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        hdnUserTrno.Value = gvUserMaster.Rows[e.NewEditIndex].Cells[0].Text;
        Label lblObject = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("gvlblRoleTrno");
        Label lblUserFromDPHO = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("lblUserFromDPHO");
        Label lblCoreRoleId = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("lblCoreRoleId");
        Label lblUserDpt_I = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("lblUserDpt_I");
        Label lblBranchId = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("lblBranchId");
        Label lblRoleAccess = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("lblRoleAccess");

        ddlRole.SelectedValue = lblObject.Text;
        txtUsername.Text = gvUserMaster.Rows[e.NewEditIndex].Cells[1].Text;
        ddlUserType.SelectedValue = gvUserMaster.Rows[e.NewEditIndex].Cells[3].Text;

        try
        {
            ddlBranchName.DataSource = obj.GetAllBranches("00001,00002");
            ddlBranchName.DataTextField = "AgencyName";
            ddlBranchName.DataValueField = "AgencyID";
            ddlBranchName.DataBind();
            ddlBranchName.ClearSelection();
            ddlBranchName.Items.FindByValue(lblBranchId.Text).Selected = true;
        }
        catch { }
        try
        {
            ddlUserDepart.ClearSelection();
            ddlUserDepart.Items.FindByValue(lblUserDpt_I.Text).Selected = true;
        }
        catch { }
        try
        {
            ddlUserFrom.ClearSelection();
            ddlUserFrom.Items.FindByValue(lblUserFromDPHO.Text).Selected = true;
        }
        catch { }
        try
        {
            ddlCoreRole.ClearSelection();
            ddlCoreRole.Items.FindByValue(lblCoreRoleId.Text).Selected = true;
        }
        catch { }

        ddlLoginStatus.ClearSelection();
        ddlLoginStatus.Items.FindByText(gvUserMaster.Rows[e.NewEditIndex].Cells[4].Text).Selected = true;
        if (lblRoleAccess.Text == "Both")
        {
            foreach (ListItem chk in chkCoreModuleRights.Items)
            {
                chk.Selected = true;
            }
        }
        else
        {
            foreach (ListItem chk in chkCoreModuleRights.Items)
            {
                if (chk.Text == lblRoleAccess.Text)
                {
                    chk.Selected = true;
                }
                if (chk.Text == lblRoleAccess.Text)
                {
                    chk.Selected = true;
                }
            }
        }
        foreach (ListItem chk in chkCoreModuleRights.Items)
        {
            if (chk.Text == "Code Module")
            {
                if (chk.Selected == true)
                {
                    trBranchId.Visible = true;
                    trCoreRole.Visible = true;
                }
                else
                {
                    trBranchId.Visible = false;
                    trCoreRole.Visible = false;
                }
            }
        }
        Label lblEmpId = (Label)gvUserMaster.Rows[e.NewEditIndex].FindControl("lblEmpId");
        OfficeFill();
        try
        {
            ddlOfficeName.Items.FindByValue(lblEmpId.Text).Selected = true;
        }
        catch { }
        txtUsername.Enabled = false;
        pnlUserMaster.Visible = false;
        pnlNewUser.Visible = true;
        trLoginSts.Visible = true;
    }


    protected void gvUserMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        hdnUserTrno.Value = gvUserMaster.Rows[e.RowIndex].Cells[0].Text;

        obUserMaster.Delete(int.Parse(hdnUserTrno.Value));
        fillGrid();
    }

    protected void gvUserMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvUserMaster.PageIndex = e.NewPageIndex;
        fillGrid();
    }
}
