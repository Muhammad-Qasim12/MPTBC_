using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Academic_CDProof : System.Web.UI.Page
{
    MPTBCBussinessLayer.Academic.CDProofVerification obCDProofVerification = new MPTBCBussinessLayer.Academic.CDProofVerification();
    CommonFuction obCommonFunction=new CommonFuction();
    DataTable dtSelectedTitle;
    DataTable dtRecSelectedTitle;

    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");        
        lblmsg.Text = string.Empty;
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFunction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "Id";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFunction.GetFinYear();

            dtSelectedTitle = new DataTable();
            dtSelectedTitle.Columns.Add("Class", typeof(string));            
            dtSelectedTitle.Columns.Add("Medium", typeof(string));           
            dtSelectedTitle.Columns.Add("Title", typeof(string));
            DataColumn[] Datakeyset = new DataColumn[1];
            Datakeyset[0]= dtSelectedTitle.Columns.Add("TitleID", typeof(int));
            dtSelectedTitle.Columns.Add("TotalCopies", typeof(int));
            dtSelectedTitle.Columns.Add("TotalCD", typeof(int));
            dtSelectedTitle.PrimaryKey = Datakeyset;
            ViewState.Add("dtSelectedTitle", dtSelectedTitle);


            dtRecSelectedTitle = new DataTable();
            dtRecSelectedTitle.Columns.Add("Class", typeof(string));
            dtRecSelectedTitle.Columns.Add("Medium", typeof(string));
            dtRecSelectedTitle.Columns.Add("Title", typeof(string));
            Datakeyset[0] = dtRecSelectedTitle.Columns.Add("TitleID", typeof(int));
            dtRecSelectedTitle.Columns.Add("LetterNo", typeof(string));
            dtRecSelectedTitle.Columns.Add("LetterDate", typeof(string));
            dtRecSelectedTitle.Columns.Add("Remark", typeof(string));
            dtRecSelectedTitle.Columns.Add("CDPath", typeof(string));
            dtRecSelectedTitle.Columns.Add("UploadFilePath", typeof(string));
            dtRecSelectedTitle.Columns.Add("CDProofVerificationTrno", typeof(int));

            dtRecSelectedTitle.PrimaryKey = Datakeyset;
            dtRecSelectedTitle.Columns.Add("NigamLetter", typeof(string));
            dtRecSelectedTitle.Columns.Add("NigamLetterDate", typeof(string));
            ViewState.Add("dtRecSelectedTitle", dtRecSelectedTitle);


            hdnCDProofID.Value = "0";
            obCDProofVerification.QueryType=-4;
            obCDProofVerification.StringParameter= obCommonFunction.GetFinYear();
            DdlACYear.SelectedValue = obCDProofVerification.StringParameter;
            DataSet dsAcYear= obCDProofVerification.Select();
           if(dsAcYear.Tables[0] !=null && dsAcYear.Tables[0].Rows.Count>0)
            {
                DdlACYear.SelectedValue = dsAcYear.Tables[0].Rows[0]["Id"].ToString();
            }
           else
           {
               hdnAcademicYear.Value="0";
           }
            FillCombo();
            //FillTitleGrid();

            FillRecTitles();
        }
    }
    private void FillCombo()
    {
        ListItem lstCmbItem = new ListItem("All", "0");

        obCDProofVerification.QueryType = 0;
        obCDProofVerification.ParameterValue = 0;
        ddlDepartment.DataSource = obCDProofVerification.Select().Tables[0];
        ddlDepartment.DataTextField = "DepName_V";
        ddlDepartment.DataValueField = "DepTrno_I";
        ddlDepartment.DataBind();


        obCDProofVerification.QueryType = -1;
        obCDProofVerification.ParameterValue = 0;
        ddlMedium.DataSource = obCDProofVerification.Select().Tables[0];
        ddlMedium.DataTextField = "MediunNameHindi_V";
        ddlMedium.DataValueField = "Medium_I";
        ddlMedium.DataBind();
        ddlMedium.Items.Insert(0, lstCmbItem);

        ddlRecMedium.DataSource = obCDProofVerification.Select().Tables[0];
        ddlRecMedium.DataTextField = "MediunNameHindi_V";
        ddlRecMedium.DataValueField = "Medium_I";
        ddlRecMedium.DataBind();
        ddlRecMedium.Items.Insert(0, lstCmbItem);



        obCDProofVerification.QueryType = -2;
        obCDProofVerification.ParameterValue = 0;
        ddlClass.DataSource = obCDProofVerification.Select().Tables[0];
        ddlClass.DataTextField = "Classdet_V";
        ddlClass.DataValueField = "ClassTrno_I";
        ddlClass.DataBind();
        ddlClass.Items.Insert(0, lstCmbItem);

        ddlRecClass.DataSource = obCDProofVerification.Select().Tables[0];
        ddlRecClass.DataTextField = "Classdet_V";
        ddlRecClass.DataValueField = "ClassTrno_I";
        ddlRecClass.DataBind();
        ddlRecClass.Items.Insert(0, lstCmbItem);


        obCDProofVerification.QueryType = -5;
        obCDProofVerification.ParameterValue3 = int.Parse(DdlACYear.SelectedValue);
    }

    protected void txtExpectedReturnDate_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToDateTime(txtExpectedReturnDate.Text, cult) < Convert.ToDateTime(txtLetterDate.Text, cult))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कृपया.. अपेक्षित पाण्डुलिपि वापसी दिनांक जांच लें..');</script>");
                txtExpectedReturnDate.Text = "";
            }
            tcTitle.ActiveTabIndex = 0;
        }
        catch
        {
           
        }
        finally { }
    }

    private void FillTitleGrid()
    {
       
      

        grdTitles.DataSource = obCDProofVerification.Select();
        grdTitles.DataBind();
    }
    protected void ddlMedium_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        obCDProofVerification.QueryType = -3;
        obCDProofVerification.ParameterValue = int.Parse(ddlMedium.SelectedValue);
        obCDProofVerification.ParameterValue2 = int.Parse(ddlClass.SelectedValue);
        obCDProofVerification.ParameterValue3 = int.Parse(DdlACYear.SelectedValue);
        FillTitleGrid();

        tcTitle.ActiveTabIndex = 0;
    }
    protected void btnAddTitle_Click(object sender, EventArgs e)
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        int TotalTitles = 0;
        for (int rowno = 0; rowno < grdTitles.Rows.Count; rowno++)
        {
            CheckBox chkIsTitleSelected = (CheckBox)grdTitles.Rows[rowno].FindControl("chkSelectTitle");
            if (chkIsTitleSelected.Checked)
            {
                TotalTitles++;
            }
        }
        if (TotalTitles == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select title";
        }
        else
        {
            for (int rowno = 0; rowno < grdTitles.Rows.Count; rowno++)
            {
                CheckBox chkIsTitleSelected = (CheckBox)grdTitles.Rows[rowno].FindControl("chkSelectTitle");

                if (chkIsTitleSelected.Checked)
                {

                    DataRow drNewTitle = dtSelectedTitle.NewRow();
                    drNewTitle["Class"] = grdTitles.Rows[rowno].Cells[3].Text;
                    drNewTitle["Medium"] = grdTitles.Rows[rowno].Cells[2].Text;
                    drNewTitle["Title"] = grdTitles.Rows[rowno].Cells[4].Text;
                    drNewTitle["TitleID"] = grdTitles.DataKeys[rowno].Value;

                    TextBox txtGridValue = (TextBox)grdTitles.Rows[rowno].FindControl("txtTotalCopies");

                    drNewTitle["TotalCopies"] = txtGridValue.Text;
                    txtGridValue = (TextBox)grdTitles.Rows[rowno].FindControl("txtTotalCD");
                    drNewTitle["TotalCD"] = txtGridValue.Text;
                    try
                    {
                        dtSelectedTitle.Rows.Add(drNewTitle);
                    }
                    catch
                    {
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "Duplicate title entry for " + grdTitles.Rows[rowno].Cells[4].Text;
                        break;
                    }


                }
            }
            ViewState.Add("dtSelectedTitle", dtSelectedTitle);
            FillSelectedTitleGrid();
        }
    }
    private void FillSelectedTitleGrid()
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        grdSelectedTitle.DataSource = dtSelectedTitle;
        grdSelectedTitle.DataBind();
    }
    private void FillRecTitles()
    {
        obCDProofVerification.QueryType = -7;
        obCDProofVerification.ParameterValue = int.Parse(ddlRecMedium.SelectedValue);
        obCDProofVerification.ParameterValue2 = int.Parse(ddlRecClass.SelectedValue);
        obCDProofVerification.ParameterValue3 = int.Parse(DdlACYear.SelectedValue);
        grdRecTitle.DataSource = obCDProofVerification.Select();
        grdRecTitle.DataBind();
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
       dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];

       if (hdnAcademicYear.Value == "0")
       {
           mainDiv.Style.Add("display", "block");
           lblmsg.Text = "Invalid academic year value.";
       }
       else if (dtSelectedTitle.Rows.Count == 0)
       {
           mainDiv.Style.Add("display", "block");
           lblmsg.Text = "No title selected";
       }
       else if (!CheckDateFormat(txtLetterDate.Text))
       {
           mainDiv.Style.Add("display", "block");
           lblmsg.Text = "Invalid letter date";
       }
       else if (!CheckDateFormat(txtExpectedReturnDate.Text))
       {
           mainDiv.Style.Add("display", "block");
           lblmsg.Text = "Invalid expected return date";
       }    
       else if (DateTime.Parse(txtLetterDate.Text,cult) > DateTime.Now.Date)
       {
           mainDiv.Style.Add("display", "block");
           lblmsg.Text = "Date can not be future date.";
       }
       else if (DateTime.Parse(txtLetterDate.Text,cult) > DateTime.Parse(txtExpectedReturnDate.Text , cult))
       {
           mainDiv.Style.Add("display", "block");
           lblmsg.Text = "Return date is before then letter date";
       }
       else
       {
           try
           {
               obCDProofVerification.AcYearID_I = int.Parse(DdlACYear.SelectedValue);
               obCDProofVerification.LetterNo_V = txtLetterNo.Text;
               obCDProofVerification.LetterDate_D = DateTime.Parse(txtLetterDate.Text,cult ).ToString("yyyy-MM-dd");
               obCDProofVerification.ExpectedRetDate_D = DateTime.Parse(txtExpectedReturnDate.Text, cult).ToString("yyyy-MM-dd");
               obCDProofVerification.UploadFilePath = "";
               obCDProofVerification.FileName = "";

               obCDProofVerification.TransID = 0;// int.Parse(hdnCDProofID.Value);
               hdnCDProofID.Value = obCDProofVerification.InsertUpdate().ToString();

               obCDProofVerification.CDProofVerificationTrno_I = int.Parse(hdnCDProofID.Value);
               for (int rowno = 0; rowno < dtSelectedTitle.Rows.Count; rowno++)
               {
                   obCDProofVerification.TransID = -1;
                   obCDProofVerification.TitleID_I = int.Parse(grdSelectedTitle.DataKeys[rowno].Value.ToString());

                   obCDProofVerification.TotalCopies = int.Parse(grdSelectedTitle.Rows[rowno].Cells[4].Text);
                   obCDProofVerification.TotalCD = int.Parse(grdSelectedTitle.Rows[rowno].Cells[5].Text);

                   obCDProofVerification.InsertUpdate();
               }

               ClearCtrl();
               mainDiv.CssClass = "form-message success";
               mainDiv.Style.Add("display", "block");           
               lblmsg.Text = "Record saved successfully";
           }
           catch
           {
               mainDiv.Style.Add("display", "block");
               lblmsg.Text = "Please check data.";
           }

           
       }
    }
    private void ClearCtrl()
    {
        txtExpectedReturnDate.Text = "";
        txtLetterDate.Text = "";
        txtLetterNo.Text = "";
        hdnCDProofID.Value = "0";
        obCDProofVerification.QueryType = -5;
        obCDProofVerification.ParameterValue3 = int.Parse(DdlACYear.SelectedValue);
        FillTitleGrid();

        dtSelectedTitle.Rows.Clear();
        ViewState["dtSelectedTitle"] = dtSelectedTitle;
        FillSelectedTitleGrid();

        ddlRecMedium.SelectedValue = "0";
        ddlRecClass.SelectedValue = "0";

        FillRecTitles();
    }
    private bool CheckDateFormat(string datestring)
    {
        try
        {
            DateTime.Parse(datestring, cult);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void ddlRecMedium_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        tcTitle.ActiveTabIndex = 1;
        FillRecTitles();
    }

    //private void FillRecTitle()
    //{
    //    obCDProofVerification.QueryType = -7;
    //    obCDProofVerification.ParameterValue = int.Parse(ddlRecMedium.SelectedValue);
    //    obCDProofVerification.ParameterValue2 = int.Parse(ddlRecClass.SelectedValue);
    //    obCDProofVerification.ParameterValue3 = int.Parse(hdnAcademicYear.Value);
    //    grdRecTitle.DataSource = obCDProofVerification.Select();
    //    grdRecTitle.DataBind();
    //    tcTitle.ActiveTabIndex = 1;
    //}
    protected void btnRecAddTitle_OnClick(object sender, EventArgs e)
    {
        dtRecSelectedTitle = (DataTable)ViewState["dtRecSelectedTitle"];
        int SelectedTitle = 0;
        for (int rowno = 0; rowno < grdRecTitle.Rows.Count; rowno++)
        {
            CheckBox chkIsTitleSelected = (CheckBox)grdRecTitle.Rows[rowno].FindControl("chkRecSelectTitle");

            if (chkIsTitleSelected.Checked)
            {
                SelectedTitle++;
            }
        }

        if (SelectedTitle==0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select title to add";
        }
        else
        {
            string UploadFilePath="", UploadStatus=null, FileName=null;
            for (int rowno = 0; rowno < grdRecTitle.Rows.Count; rowno++)
            {
                CheckBox chkIsTitleSelected = (CheckBox)grdRecTitle.Rows[rowno].FindControl("chkRecSelectTitle");

                if (chkIsTitleSelected.Checked)
                {

                    DataRow drNewTitle = dtRecSelectedTitle.NewRow();
                    drNewTitle["Class"] = grdRecTitle.Rows[rowno].Cells[3].Text;
                    drNewTitle["Medium"] = grdRecTitle.Rows[rowno].Cells[2].Text;
                    drNewTitle["Title"] = grdRecTitle.Rows[rowno].Cells[4].Text;
                    drNewTitle["TitleID"] = grdRecTitle.DataKeys[rowno].Value;
                    drNewTitle["LetterNo"] = grdRecTitle.Rows[rowno].Cells[5].Text;
                    drNewTitle["LetterDate"] = grdRecTitle.Rows[rowno].Cells[6].Text;

                    TextBox txtGridValue = (TextBox)grdRecTitle.Rows[rowno].FindControl("txtRecRemark");
                    drNewTitle["Remark"] = txtGridValue.Text;

                    txtGridValue = (TextBox)grdRecTitle.Rows[rowno].FindControl("txtCDProofID");
                    drNewTitle["CDProofVerificationTrno"] = int.Parse(txtGridValue.Text);
                    FileUpload fileCDPath = (FileUpload)grdRecTitle.Rows[rowno].FindControl("fileCDProof");
                    drNewTitle["CDPath"] = fileCDPath.FileName;
                    UploadFilePath=null;
                    FileName = null;
                    if (fileCDPath.FileName != "")
                    {
                        APIProcedure obApi = new APIProcedure();
                        UploadStatus = obApi.SingleuploadFile(fileCDPath, "AcademicFiles", 100240);
                        UploadFilePath = obApi.FullFileName;
                        FileName = fileCDPath.FileName;
                    }
                    drNewTitle["UploadFilePath"] = UploadFilePath;
                    //dtRecSelectedTitle.Columns.Add("NigamLetter", typeof(string));
                    //dtRecSelectedTitle.Columns.Add("NigamLetterDate", typeof(string));
                    drNewTitle["NigamLetter"] = txtRecLetterNo.Text;
                    drNewTitle["NigamLetterDate"] =txtRecLetterDate.Text;
                    try
                    {
                        if (UploadFilePath!=null && UploadStatus != "Ok")
                        {
                            mainDiv.Style.Add("display", "block");
                            lblmsg.Text = "Invalid file selected for " + grdRecTitle.Rows[rowno].Cells[4].Text;
                            break;
                        }
                        else
                        {

                            dtRecSelectedTitle.Rows.Add(drNewTitle);
                        }
                    }

                    catch
                    {
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "Duplicate title entry for " + grdRecTitle.Rows[rowno].Cells[4].Text;
                        break;
                    }

                }
            }
            ViewState.Add("dtRecSelectedTitle", dtRecSelectedTitle);
            FillRecSelectedTitleGrid();
        }
    }
    private void FillRecSelectedTitleGrid()
    {
        dtRecSelectedTitle = (DataTable)ViewState["dtRecSelectedTitle"];
        grdRetSelectedTitles.DataSource = dtRecSelectedTitle;
        grdRetSelectedTitles.DataBind();
    }
    protected void btnRecTitle_OnClick(object sender, EventArgs e)
    {
        dtRecSelectedTitle = (DataTable)ViewState["dtRecSelectedTitle"];

         if (!CheckDateFormat(txtRecLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid Date";
        }
        else if (DateTime.Parse(txtRecLetterDate.Text, cult) > DateTime.Now.Date)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Letter date can not be future date.";
        }
        else if (dtRecSelectedTitle.Rows.Count == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "No title selected ";
        }
        else
        {
            obCDProofVerification.AcYearID_I = int.Parse(DdlACYear.SelectedValue);
            obCDProofVerification.LetterNo_V = txtRecLetterNo.Text;
            obCDProofVerification.LetterDate_D = DateTime.Parse(txtRecLetterDate.Text, cult).ToString("yyyy-MM-dd");

            obCDProofVerification.TransID = -2;
            hdnRetCDProof.Value = obCDProofVerification.InsertUpdate().ToString();

            obCDProofVerification.RetCDProofVerificationTrno_I = int.Parse(hdnRetCDProof.Value);
            for (int rowno = 0; rowno < dtRecSelectedTitle.Rows.Count; rowno++)
            {
                obCDProofVerification.TransID = -3;

                obCDProofVerification.TitleID_I = int.Parse(grdRetSelectedTitles.DataKeys[rowno].Value.ToString());
                Label lblGrdId = (Label)grdRetSelectedTitles.Rows[rowno].FindControl("lblCDProofID");
                obCDProofVerification.CDProofVerificationTrno_I = int.Parse(lblGrdId.Text);
                obCDProofVerification.Remark = grdRetSelectedTitles.Rows[rowno].Cells[6].Text;
                obCDProofVerification.FileName = grdRetSelectedTitles.Rows[rowno].Cells[7].Text;
                lblGrdId = (Label)grdRetSelectedTitles.Rows[rowno].FindControl("lblUploadFileName");
                obCDProofVerification.UploadFilePath = lblGrdId.Text;
                obCDProofVerification.InsertUpdate();
            }

            txtRecLetterDate.Text = "";
            txtRecLetterNo.Text = "";
            hdnRetCDProof.Value = "0";
            ddlRecMedium.SelectedValue = "0";
            ddlRecClass.SelectedValue = "0";

            ddlRecMedium_OnSelectedIndexChanged(sender, e);

            dtRecSelectedTitle.Rows.Clear();
            ViewState["dtRecSelectedTitle"] = dtRecSelectedTitle;
            FillRecSelectedTitleGrid();

            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.ForeColor = System.Drawing.Color.Green;
            lblmsg.Text = "Record saved successfully";
        }
    }
    protected void grdSelectedTitle_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e) 
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        dtSelectedTitle.Rows[e.RowIndex].Delete();
        dtSelectedTitle.AcceptChanges();
        ViewState["dtSelectedTitle"] = dtSelectedTitle;
        FillSelectedTitleGrid();
    }
    protected void grdRetSelectedTitles_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        dtRecSelectedTitle = (DataTable)ViewState["dtRecSelectedTitle"];
        dtRecSelectedTitle.Rows[e.RowIndex].Delete();
        dtRecSelectedTitle.AcceptChanges();
        ViewState["dtRecSelectedTitle"] = dtRecSelectedTitle;
        FillRecSelectedTitleGrid();
    }
}
