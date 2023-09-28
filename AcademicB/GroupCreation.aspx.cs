using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AcademicB_GroupCreation : System.Web.UI.Page
{
   // MPTBCBussinessLayer.AcademicB.GroupCreation obGroupCreation = new MPTBCBussinessLayer.AcademicB.GroupCreation();
    GroupCreation obGroupCreation = new GroupCreation();
    DataTable dtSelectedTitle;
    CommonFuction obCommonFunction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFunction.GetFinYear();
            LoadGrd();

            dtSelectedTitle = new DataTable();
            DataColumn[] DatakeySet = new DataColumn[2];
           
            dtSelectedTitle.Columns.Add("Title", typeof(string));
            dtSelectedTitle.Columns.Add("SubTitle", typeof(string));
            dtSelectedTitle.Columns.Add("DepoName", typeof(string));
            dtSelectedTitle.Columns.Add("TotalSupply", typeof(int));
            //dtSelectedTitle.Columns.Add("DistrictID", typeof(int));

            dtSelectedTitle.Columns.Add("TitleID", typeof(int));
            DatakeySet[0] = dtSelectedTitle.Columns.Add("SubTitleID", typeof(string));
            dtSelectedTitle.Columns.Add("DemandID", typeof(int));
            DatakeySet[1] = dtSelectedTitle.Columns.Add("DepoTrno", typeof(int));
            dtSelectedTitle.Columns.Add("PaperQty", typeof(double));
            //dtSelectedTitle.Columns.Add("DemandSupply", typeof(int));
            dtSelectedTitle.Columns.Add("Grpbookmarkid", typeof(string));
            dtSelectedTitle.Columns.Add("Grpbookmarkname", typeof(string));           
            dtSelectedTitle.PrimaryKey = DatakeySet;
            ViewState.Add("dtSelectedTitle", dtSelectedTitle);
            FillTitle();
            int DemandID = 0;
            if (Request.QueryString["ID"] != null)
                int.TryParse(new APIProcedure().Decrypt(Request.QueryString["ID"]), out DemandID);
            if (DemandID > 0)
            {
                obGroupCreation.QueryType = -7;
                obGroupCreation.PrameterValue = DemandID;
                obGroupCreation.GroupNameIds = "";
                obGroupCreation._FYear = DdlACYear.SelectedValue;
                DataSet dsGroup = obGroupCreation.Select();
                if (dsGroup.Tables[0].Rows.Count > 0)
                {
                    DdlACYear.SelectedIndex = -1;
                    DdlACYear.SelectedValue = dsGroup.Tables[0].Rows[0]["FYear"].ToString();
                    txtGroupName.Text = dsGroup.Tables[0].Rows[0]["GroupNO_V"].ToString();
                    txtEMDAmount_N.Text = dsGroup.Tables[0].Rows[0]["EmdAmount"].ToString();
                    //added 22102017
                    ddlTitle.SelectedValue = dsGroup.Tables[0].Rows[0]["TitleID_I"].ToString();
                    FillCtrlsByGrpId(dsGroup.Tables[0].Rows[0]["GrpBookmarkID_I"].ToString());
                    ddlSubTitle.SelectedValue = dsGroup.Tables[0].Rows[0]["SubTitleID_I"].ToString();
                   
                    hdnGrpId_I.Value = dsGroup.Tables[0].Rows[0]["GrpID_I"].ToString();
                    obGroupCreation.QueryType = -8;
                    obGroupCreation.PrameterValue = DemandID;
                    dtSelectedTitle = obGroupCreation.Select().Tables[0];
                    ViewState["dtSelectedTitle"] = dtSelectedTitle;
                    FillSelectedTitleGrid();
                    FillDepoGrid();
                }
            }
            //fillDepoDetails();
            //LoadCategoryDropdown();
            //ddlCategory_OnSelectedIndexChanged(sender, e);

          
        }
    }

    private void fnClearCtrls()
    {
        grdDepo.DataSource = null;
        grdDepo.DataBind();
        grdSelectedTitle.DataSource = null;
        grdSelectedTitle.DataBind();
        

    }

    protected void chkGroupName_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkGrpName = (CheckBox)sender;
        DataListItem Dl = (DataListItem)chkGrpName.NamingContainer;
        string Val = "";
        fnClearCtrls();
        foreach (DataListItem dl in DlistGroup.Items)
        {
            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
            Label lblGroupId = (Label)dl.FindControl("lblGroupId");
            if (chkGroupName.Checked == true)
            {
                Val = Val + lblGroupId.Text + ",";
            }
        }

        if (Val != "")
        {
            // LoadTitlesGrd(Val);
            FillGrid_allGroup(Val);
        }
        else
        {
            FillGrid();
        }
    }

    protected void chkGroupName1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSubTitleName = (CheckBox)sender;
        DataListItem Dl = (DataListItem)chkSubTitleName.NamingContainer;
        string Val = "";
        fnClearCtrls();
        foreach (DataListItem dl in DlistGroup0.Items)
        {
            CheckBox chkSubTitleName1 = (CheckBox)dl.FindControl("chkSubTitleName");
            Label lblGroupId = (Label)dl.FindControl("lblSubTitle");
            if (chkSubTitleName1.Checked == true)
            {
                Val = Val + lblGroupId.Text + ",";
            }
        }

        if (Val != "")
        {
            // LoadTitlesGrd(Val);
           FillGridwithsubtitle(Val);
        }
        else
        {
            FillGrid();
        }
    }

    private void FillTitle()
    {
        obGroupCreation.QueryType = -1;
        ddlTitle.DataSource = obGroupCreation.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("--Select--", "0"));
        FillSubTitle();
    }

    //added for edit group creation - 22102017
    private void FillCtrlsByGrpId(string GrpBookmarkId)
    {
        obGroupCreation.QueryType = -2;
        obGroupCreation.PrameterValue = int.Parse(ddlTitle.SelectedValue);
        ddlSubTitle.DataSource = obGroupCreation.Select();
        ddlSubTitle.DataTextField = "SubTitleHindi_V";
        ddlSubTitle.DataValueField = "SubTitleID_I";
        ddlSubTitle.DataBind();
        ddlSubTitle.Items.Insert(0, new ListItem("--Select--", "0"));

       foreach (DataListItem dl in DlistGroup.Items)
        {
            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
            Label lblGroupId = (Label)dl.FindControl("lblGroupId");
            if (lblGroupId.Text == GrpBookmarkId)
            {
                chkGroupName.Checked = true;
            }           
        }
    }

    private void FillSubTitle()
    {
        obGroupCreation.QueryType = -2;
        obGroupCreation.PrameterValue = int.Parse(ddlTitle.SelectedValue);
        ddlSubTitle.DataSource = obGroupCreation.Select();
        ddlSubTitle.DataTextField = "SubTitleHindi_V";
        ddlSubTitle.DataValueField = "SubTitleID_I";
        ddlSubTitle.DataBind();
        ddlSubTitle.Items.Insert(0, new ListItem("--Select--", "0"));
        //fillDemandDetails();
        // fillDepoDetails();
        FillGrid();
    }

    //private void fillDepoDetails()
    //{
    //    obGroupCreation.QueryType = -5;
    //    //obGroupCreation.PrameterValue = int.Parse(ddlSubTitle.SelectedValue);
    //    ddlDepo.DataSource = obGroupCreation.Select();
    //    ddlDepo.DataTextField = "DepoName_V";
    //    ddlDepo.DataValueField = "DepoTrno_I";
    //    ddlDepo.DataBind();
    //    ddlDepo.Items.Insert(0, new ListItem("--Select--", "0"));
    //    FillGrid();
    //}

    //private void fillDemandDetails()
    //{
    //    obGroupCreation.QueryType = -3;
    //    obGroupCreation.PrameterValue = int.Parse(ddlSubTitle.SelectedValue);
    //    ddlDemandDetails.DataSource = obGroupCreation.Select();
    //    ddlDemandDetails.DataTextField = "LetterNo";
    //    ddlDemandDetails.DataValueField = "DemandID_I";
    //    ddlDemandDetails.DataBind();
    //    ddlDemandDetails.Items.Insert(0, new ListItem("--Select--", "0"));
    //    FillGrid();
    //}

    private void FillGrid()
    {
        obGroupCreation.QueryType = -4;
        obGroupCreation.PrameterValue = int.Parse(ddlSubTitle.SelectedValue);
        obGroupCreation.PrameterValue2 = int.Parse(ddlTitle.SelectedValue);
        grdDepo.DataSource = obGroupCreation.Select();
        grdDepo.DataBind();

        fnSelectGridChkbox();
    }

    private void FillGridwithsubtitle(string val)
    {
        obGroupCreation.QueryType = -200;
        obGroupCreation.GroupNameIds  = val;
        obGroupCreation.PrameterValue2 = int.Parse(ddlTitle.SelectedValue);
        grdDepo.DataSource = obGroupCreation.Select();
        grdDepo.DataBind();

       // fnSelectGridChkbox();
    }

    private void fnSelectGridChkbox()
    {
        if (grdDepo.Rows.Count > 0)
        {
            foreach (GridViewRow gv in grdDepo.Rows)
            {
                CheckBox chkGroupName = (CheckBox)gv.FindControl("chkSelectDepo");
                chkGroupName.Checked = true;
            }
        }
    }

    private void FillGrid_alltitle()
    {
        obGroupCreation.QueryType = 200;
        obGroupCreation.PrameterValue = int.Parse(ddlTitle.SelectedValue);
        //obGroupCreation.PrameterValue2 = int.Parse( ddlSubTitle.SelectedValue);
        grdDepo.DataSource = obGroupCreation.Select();
        grdDepo.DataBind();
        fnSelectGridChkbox();
    }

    private void FillGrid_allGroup(string groupIds)
    {
         string Val = "";obGroupCreation.QueryType = -9;
       // obGroupCreation.PrameterValue = int.Parse(ddlTitle.SelectedValue);
        if(ddlSubTitle.SelectedValue != "" && ddlSubTitle.SelectedValue != "0")
            obGroupCreation.PrameterValue = int.Parse(ddlSubTitle.SelectedValue);
        else if (ddlTitle.SelectedValue != "" && ddlTitle.SelectedValue != "0")
        {




            foreach (DataListItem dl in DlistGroup0.Items)
            {
                CheckBox chkSubTitleName1 = (CheckBox)dl.FindControl("chkSubTitleName");
                Label lblGroupId = (Label)dl.FindControl("lblSubTitle");
                if (chkSubTitleName1.Checked == true)
                {
                    Val =  lblGroupId.Text  ;
                }
            }
            
             
            
            obGroupCreation.PrameterValue = int.Parse(ddlTitle.SelectedValue);
            obGroupCreation.PrameterValue2 = int.Parse(Val);
            obGroupCreation.QueryType = -11;
        }
        obGroupCreation.GroupNameIds = groupIds;
        obGroupCreation._FYear = DdlACYear.SelectedValue;
        grdDepo.DataSource = obGroupCreation.Select();
        grdDepo.DataBind();
        fnSelectGridChkbox();
    }

    protected void ddlTitle_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        fnClearCtrls();
        FillSubTitle();
        LoadGrdSubtitle();
    }

    protected void DlistGroup_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    //CheckBox chkGroupName = (CheckBox)sender.FindControl("chkGroupName");

        //    CheckBox chkGroupName = (CheckBox)sender;
        //    string selectedValue = ((DropDownList)chkGroupName.NamingContainer.FindControl("ddlitem")).SelectedValue;
        //}
        //catch { }
    }

    public void LoadGrd()
    {
        MPTBCBussinessLayer.PRIN_GroupCreation obGroup = new MPTBCBussinessLayer.PRIN_GroupCreation();
        try
        {
            obGroup.GroupId = 0;          
            obGroup.ACYear = Convert.ToString(DdlACYear.SelectedValue);
            DlistGroup.DataSource = obGroup.Select();
            DlistGroup.DataBind();          
                       
        }
           
        catch (Exception ex) { }
        finally { obGroup = null; }

    }


    public void LoadGrdSubtitle()
    {
         
        try
        {
             


            obGroupCreation.QueryType = -2;
            obGroupCreation.PrameterValue = int.Parse(ddlTitle.SelectedValue);
            DlistGroup0.DataSource = obGroupCreation.Select();
            DlistGroup0.DataBind();


        }

        catch (Exception ex) { }
        finally { obGroupCreation = null; }

    }
    protected void ddlSubTitle_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //fillDemandDetails();
        // fillDepoDetails();
        fnClearCtrls();
        FillGrid();
    }

    protected void ddlDepo_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    //
    protected void ddlDemandDetails_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }


    //public void LoadCategoryDropdown()
    //{

    //    try
    //    {
    //        obGroupCreation.QueryType = 0;
    //        int CategoryId = 0;
    //        int.TryParse(ddlCategory.SelectedValue, out CategoryId);
    //        obGroupCreation.PrameterValue = CategoryId;
    //        ddlCategory.DataSource = obGroupCreation.LoadCategory();
    //        ddlCategory.DataTextField = "CategoryNo_V";
    //        ddlCategory.DataValueField = "CatID_I";

    //        ddlCategory.DataBind();

    //        ddlCategory.Items.Insert(0, new ListItem("Select", "0"));
    //    }

    //    catch (Exception ex) { }
    //    finally { obGroupCreation = null; }


    //}
    //protected void ddlCategory_OnSelectedIndexChanged(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        divCategoryDesc.InnerHtml = string.Empty;
    //        obGroupCreation.QueryType = -1;
    //        int CategoryId = 0;
    //        int.TryParse(ddlCategory.SelectedValue, out CategoryId);
    //        obGroupCreation.PrameterValue = CategoryId;
    //        DataSet dsCategoryDetails=  obGroupCreation.LoadCategory();
    //        if (dsCategoryDetails.Tables[0].Rows.Count > 0)
    //        {
    //            divCategoryDesc.InnerHtml += "टेक्स्ट की कलर स्कीम :" + dsCategoryDetails.Tables[0].Rows[0]["ColorSchText_V"].ToString() + "</br>";
    //            divCategoryDesc.InnerHtml += "कवर पेपर की कलर स्कीम :" + dsCategoryDetails.Tables[0].Rows[0]["ColorSchCoverPaper_V"].ToString() + "</br>";
    //            divCategoryDesc.InnerHtml += "मुद्रण पेपर की जानकारी :" + dsCategoryDetails.Tables[0].Rows[0]["PrintingPaperInformation"].ToString() + "</br>";
    //            divCategoryDesc.InnerHtml += "कवर पेपर की जानकारी :" + dsCategoryDetails.Tables[0].Rows[0]["CoverPaperinformation"].ToString() + "</br>";
    //            divCategoryDesc.InnerHtml += "बाइंडिंग की जानकारी :" + dsCategoryDetails.Tables[0].Rows[0]["Bindingdetail_V"].ToString() + "</br>";

    //        }

    //    }

    //    catch (Exception ex) { }
    //    finally { obGroupCreation = null; }

    //}
    private void FillSelectedTitleGrid()
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        grdSelectedTitle.DataSource = dtSelectedTitle;
        grdSelectedTitle.DataBind();
    }

    private void FillDepoGrid()
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        grdDepo.DataSource = dtSelectedTitle;
        grdDepo.DataBind();
        fnSelectGridChkbox();
    }

    //protected void btnSave_Click(object sender, EventArgs e)
    //{
    //    if (grdSelectedTitle.Rows.Count > 0)
    //    {
    //        obGroupCreation.GroupName_V = txtGroupName.Text;
    //        obGroupCreation._EMDAmount_N = txtEMDAmount_N.Text == "" ? 0 : Convert.ToDouble(txtEMDAmount_N.Text);
    //        obGroupCreation._FYear = Convert.ToString(DdlACYear.SelectedValue);

    //        //added from Group bookmark id in acb_groupmaster table
    //        string Val = "";
    //        foreach (DataListItem dl in DlistGroup.Items)
    //        {
    //            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
    //            Label lblGroupId = (Label)dl.FindControl("lblGroupId");
    //            if (chkGroupName.Checked == true)
    //            {
    //                Val = lblGroupId.Text;
    //            }
    //        }

    //        if (Request.QueryString["ID"] != null)
    //        {
    //            obGroupCreation.DemandGroupTrno_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"]));
    //        }
    //        else { obGroupCreation.DemandGroupTrno_I = 0; }

    //        obGroupCreation.DemandGroupTrno_I = obGroupCreation.GroupMasterSaveUpdate();

    //        if (obGroupCreation.DemandGroupTrno_I == 0)
    //        {
    //            mainDiv.CssClass = "form-message error";
    //            mainDiv.Style.Add("display", "block");
    //            lblmsg.Text = "Duplicate group name";
    //        }
    //        else
    //        {
    //            bool isError = false;
    //            for (int row = 0; row < grdSelectedTitle.Rows.Count && obGroupCreation.DemandGroupTrno_I > 0; row++)
    //            {
    //                Label lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblSubTitleID");
    //                obGroupCreation.SubTitleID_I = lblGrid.Text;

    //                lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblDepoID");
    //                obGroupCreation.DepoTrno_I = int.Parse(lblGrid.Text);


    //                lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblDemandID");
    //                obGroupCreation.DemandID_I = int.Parse(lblGrid.Text);

    //                try
    //                {
    //                    obGroupCreation.GroupDetailsSaveUpdate();
    //                }
    //                catch
    //                {
    //                    isError = true;
    //                    mainDiv.CssClass = "form-message error";
    //                    mainDiv.Style.Add("display", "block");
    //                    lblmsg.Text = "Error in data!!";

    //                }
    //            }

    //            if (!isError)
    //            {
    //                mainDiv.CssClass = "form-message success";
    //                mainDiv.Style.Add("display", "block");
    //                lblmsg.Text = "Record added successfully";
    //                ClearCtrl();
    //                Response.Redirect("View_ACB_003.aspx");
    //            }
    //        }

    //    }
    //    else
    //    {
    //        mainDiv.CssClass = "form-message error";
    //        mainDiv.Style.Add("display", "block");
    //        lblmsg.Text = "No record selected";
    //    }
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string Val = "";
        foreach (DataListItem dl in DlistGroup.Items)
        {
            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkGroupName");
            Label lblGroupId = (Label)dl.FindControl("lblGroupId");
            if (chkGroupName.Checked == true)
            {
                Val = lblGroupId.Text;
            }
        }

        if (Val == "")
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select Bookmark name";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please select Bookmark name');");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg33", "alert('Please select Bookmark name');", true);
            return;
        }

        if (grdDepo.Rows.Count > 0)
        {
            obGroupCreation.GroupName_V = txtGroupName.Text;
            obGroupCreation._EMDAmount_N = txtEMDAmount_N.Text == "" ? 0 : Convert.ToDouble(txtEMDAmount_N.Text);
            obGroupCreation._FYear = Convert.ToString(DdlACYear.SelectedValue);
            
            //added from Group bookmark id in acb_groupmaster table
           
            obGroupCreation.GroupNameIds = Val ;

            if (Request.QueryString["ID"] != null)
            {
                obGroupCreation.DemandGroupTrno_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"]));
            }
            else { obGroupCreation.DemandGroupTrno_I = 0; }

            obGroupCreation.DemandGroupTrno_I = obGroupCreation.GroupMasterSaveUpdate();

            if (obGroupCreation.DemandGroupTrno_I == 0)
            {
                mainDiv.CssClass = "form-message error";
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Duplicate group name";
            }
            else
            {
                bool isError = false;

                if (hdnGrpId_I.Value != "")
                {
                    obGroupCreation.QueryType = -12;
                    obGroupCreation.PrameterValue = obGroupCreation.DemandGroupTrno_I;
                    obGroupCreation.Select();
                }

                
                //for (int row = 0; row < grdSelectedTitle.Rows.Count && obGroupCreation.DemandGroupTrno_I > 0; row++)
                for (int row = 0; row < grdDepo.Rows.Count && obGroupCreation.DemandGroupTrno_I > 0; row++)
                {
                    CheckBox chkDepoSelect = (CheckBox)grdDepo.Rows[row].FindControl("chkSelectDepo");
                    if (chkDepoSelect.Checked == true)
                    {
                        Label lblGrid = (Label)grdDepo.Rows[row].FindControl("lblSubTitleID");
                        obGroupCreation.SubTitleID_I = lblGrid.Text;

                        lblGrid = (Label)grdDepo.Rows[row].FindControl("lblDepoID");
                        obGroupCreation.DepoTrno_I = int.Parse(lblGrid.Text);


                        lblGrid = (Label)grdDepo.Rows[row].FindControl("lblDemandID");
                        obGroupCreation.DemandID_I = int.Parse(lblGrid.Text);

                        try
                        {
                            obGroupCreation.GroupDetailsSaveUpdate();
                        }
                        catch
                        {
                            isError = true;
                            mainDiv.CssClass = "form-message error";
                            mainDiv.Style.Add("display", "block");
                            lblmsg.Text = "Error in data!!";

                        }
                    }
                }

                if (!isError)
                {
                    mainDiv.CssClass = "form-message success";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Record added successfully";
                    ClearCtrl();
                    Response.Redirect("View_ACB_003.aspx");
                }
            }

        }
        else
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "No record selected";
        }
    }

    protected void btnSave_Click1(object sender, EventArgs e)
    {
        /*
        if (grdSelectedTitle.Rows.Count > 0)
        {

            try
            {
                if (Request.QueryString["Cid"] != null)
                {
                    obGroupCreation.DemandGroupTrno_I = Convert.ToInt32(Request.QueryString["Cid"]);
                }
                else { obGroupCreation.DemandGroupTrno_I = 0; }

                obGroupCreation.GroupName_V = Convert.ToString(txtGroupName.Text);
                obGroupCreation.PrintingCategory_V = Convert.ToString(ddlCategory.SelectedValue);

                obGroupCreation.DepoTrno_I = 0;

                obGroupCreation.DemandGroupTrno_I = obGroupCreation.GroupMasterSaveUpdate();

            }
            catch  { }
           
          


            for (int row = 0; row < grdSelectedTitle.Rows.Count; row++)
            {
               
                Label lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblDemandSubTitleTrno");

                string[] DemandDetails = lblGrid.Text.Split(',');

                for (int i = 0; i < DemandDetails.Length; i++)
                {


                    obGroupCreation.DemandID_I = int.Parse(DemandDetails[i]);

                    lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblSubTitleID");
                    obGroupCreation.SubTitleID_I = int.Parse(lblGrid.Text);

                    lblGrid = (Label)grdSelectedTitle.Rows[row].FindControl("lblDepoID");
                    obGroupCreation.DepoTrno_I = int.Parse(lblGrid.Text);
                    obGroupCreation.TotalSupply_I = int.Parse(grdSelectedTitle.Rows[row].Cells[3].Text);
                    obGroupCreation.GroupName_V = txtGroupName.Text;
                    obGroupCreation.GroupDate_D = DateTime.Now.ToString("yyyy-MM-dd");
                    obGroupCreation.TypeID = 0;
                    try
                    {
                        obGroupCreation.GroupDetailsSaveUpdate();
                    }
                    catch
                    {
                        //mainDiv.CssClass = "form-message error";
                        //mainDiv.Style.Add("display", "block");
                        //lblmsg.Text = "Error in data!!";

                    }
                }
            }

            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record saved successfully";
            ClearCtrl();
        }
        else
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "No record selected!!";
        }
        //obGroupCreation.DemandID_I
    
         */
    }


    protected void grdSelectedTitle_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        dtSelectedTitle.Rows[e.RowIndex].Delete();
        dtSelectedTitle.AcceptChanges();
        ViewState["dtSelectedTitle"] = dtSelectedTitle;
        FillSelectedTitleGrid();
    }
    private void ClearCtrl()
    {
        txtGroupName.Text = "";
        grdDepo.DataSource = null;
        grdDepo.DataBind();
        // FillTitle();
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        dtSelectedTitle.Rows.Clear();
        ViewState["dtSelectedTitle"] = dtSelectedTitle;
        FillSelectedTitleGrid();
        grdSelectedTitle.DataSource = null;
        grdSelectedTitle.DataBind();

    }
    protected void btnAddTitle_Click(object sender, EventArgs e)
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        for (int rowno = 0; rowno < grdDepo.Rows.Count; rowno++)
        {
            CheckBox chkIsTitleSelected = (CheckBox)grdDepo.Rows[rowno].FindControl("chkSelectDepo");

            if (chkIsTitleSelected.Checked)
            {


                DataRow drNewTitle = dtSelectedTitle.NewRow();
                drNewTitle["Title"] = grdDepo.Rows[rowno].Cells[2].Text;
                drNewTitle["SubTitle"] = grdDepo.Rows[rowno].Cells[3].Text;
                drNewTitle["DepoName"] = grdDepo.Rows[rowno].Cells[4].Text;
                drNewTitle["TotalSupply"] = grdDepo.Rows[rowno].Cells[5].Text;
                drNewTitle["PaperQty"] = grdDepo.Rows[rowno].Cells[6].Text;

                //Label lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblDistrictID");
                //drNewTitle["DistrictID"] = lblGridValue.Text;

                Label lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblDepoID");
                drNewTitle["DepoTrno"] = lblGridValue.Text;

                lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblTitleID");
                drNewTitle["TitleID"] = lblGridValue.Text;
                lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblSubTitleID");
                drNewTitle["SubTitleID"] = lblGridValue.Text;

                lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblDemandID");
                drNewTitle["DemandID"] = lblGridValue.Text;

                HiddenField hdnGrpBookmarkid = (HiddenField)grdDepo.Rows[rowno].FindControl("hdnGrpBookmarkid");
                drNewTitle["Grpbookmarkid"] = hdnGrpBookmarkid.Value;

                hdnGrpBookmarkid = (HiddenField)grdDepo.Rows[rowno].FindControl("hdnGrpBookmarkname");
                drNewTitle["Grpbookmarkname"] = hdnGrpBookmarkid.Value; ;

                //lblGridValue = (Label)grdDepo.Rows[rowno].FindControl("lblDemandSubTitleTrno");
                //drNewTitle["DemandSubTitleDetailsTrno"] = lblGridValue.Text;
                try
                {
                    dtSelectedTitle.Rows.Add(drNewTitle);
                    mainDiv.CssClass = "form-message success";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Record added successfully";
                }
                catch
                {
                    mainDiv.CssClass = "form-message error";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Duplicate entry!!";
                }


            }
        }
        ViewState.Add("dtSelectedTitle", dtSelectedTitle);
        FillSelectedTitleGrid();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        fnClearCtrls();
        FillGrid_alltitle();
    }
    protected void DlistGroup0_SelectedIndexChanged(object sender, EventArgs e)
    {
        CheckBox chkGrpName = (CheckBox)sender;
        DataListItem Dl = (DataListItem)chkGrpName.NamingContainer;
        string Val = "";
        fnClearCtrls();
        foreach (DataListItem dl in DlistGroup0.Items)
        {
            CheckBox chkGroupName = (CheckBox)dl.FindControl("chkSubTitleName");
            Label lblGroupId = (Label)dl.FindControl("lblSubTitle");
            if (chkGroupName.Checked == true)
            {
                Val = Val + lblGroupId.Text + ",";
            }
        }

        if (Val != "")
        {
            // LoadTitlesGrd(Val);
            FillGridwithsubtitle(Val);
        }

    }

    public class GroupCreation
    {
        public int QueryType { get; set; }
        public int PrameterValue { get; set; }
        public int PrameterValue2 { get; set; }

        public int DemandGroupTrno_I { get; set; }
        public int DemandID_I { get; set; }
        public string SubTitleID_I { get; set; }
        public int DepoTrno_I { get; set; }
        public int TotalSupply_I { get; set; }

        public string GroupName_V { get; set; }
        public string GroupDate_D { get; set; }
        public int TypeID { get; set; }
        public int GrpDetailID_I { get; set; }


        public string PrintingCategory_V { get; set; }

        public double _EMDAmount_N { get; set; }
        public string _FYear { get; set; }
        public string GroupNameIds { get; set; }


        //DemandGroupTrno_I, 
        //DemandID_I, 
        //SubTitleID_I, 
        //DepoTrno_I, 
        //TotalSupply_I, 
        //GroupName_V, 
        //GroupDate_D

        DBAccess obDBAccess = new DBAccess();



        public int InsertUpdate()
        {
            obDBAccess.execute("USP_ACB003_GroupCreationSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandGroupTrno_I", DemandGroupTrno_I);
            obDBAccess.addParam("mDemandID_I", DemandID_I);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            obDBAccess.addParam("mTotalSupply_I", TotalSupply_I);
            obDBAccess.addParam("mGroupName_V", GroupName_V);
            obDBAccess.addParam("mGroupDate_D", GroupDate_D);
            obDBAccess.addParam("mTypeID", TypeID);


            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_ACB003_GroupCreationSelect_New", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrameterValue", PrameterValue);
            obDBAccess.addParam("mPrameterValue2", PrameterValue2);
            obDBAccess.addParam("mGroupNameIds", GroupNameIds);
            obDBAccess.addParam("mAcYr", _FYear);

            return obDBAccess.records();
        }

        public System.Data.DataSet SelectSubtitle()
        {
            obDBAccess.execute("USP_ACB003_GroupCreationSelect_New", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrameterValue", PrameterValue);
            obDBAccess.addParam("mPrameterValue2", PrameterValue2);
            obDBAccess.addParam("mGroupNameIds", GroupNameIds);
            obDBAccess.addParam("mAcYr", _FYear);

            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataSet LoadCategory()
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_ACB003_CategoryMasterLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mQueryType", QueryType);
            obj.addParam("mCatID_I", PrameterValue);
            ds = obj.records();

            return ds;


        }
        public int GroupMasterSaveUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            int i = 0;
            try
            {
                //obDBAccess.execute("USP_ACB003_GroupCreationMasterSave", DBAccess.SQLType.IS_PROC);
                obDBAccess.execute("USP_ACB003_GroupCreationMasterSave_New", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mGrpID_I", DemandGroupTrno_I);
                obDBAccess.addParam("mGroupNO_V", GroupName_V);
                obDBAccess.addParam("mPrintingCategory_V", PrintingCategory_V);
                obDBAccess.addParam("mDepoID_I", DepoTrno_I);
                obDBAccess.addParam("mEmdAmount", _EMDAmount_N);
                obDBAccess.addParam("mFYear", _FYear);
                obDBAccess.addParam("mGrpBookmarkID_I", GroupNameIds);

                i = Convert.ToInt32(obDBAccess.executeMyScalar());

            }

            catch (Exception ex) { }
            finally { obDBAccess = null; }

            return i;

        }
        public int GroupDetailsSaveUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_ACB003_GroupDetailSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpDetId_I", GrpDetailID_I);
                obDbAccess.addParam("mGRPID_I", DemandGroupTrno_I);
                obDbAccess.addParam("mSubTitleID_I", SubTitleID_I);
                obDbAccess.addParam("mDepoID_I", DepoTrno_I);
                obDbAccess.addParam("mDemandID_I", DemandID_I);
                i = obDbAccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;

        }

    }
    
}
