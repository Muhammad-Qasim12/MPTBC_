using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class DistributionB_DemandFreeTextBooks : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.FreeBooksDistribution obFreeBooksDistribution = new MPTBCBussinessLayer.DistributionB.FreeBooksDistribution();
    private DataTable dtSelectedTitle;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    string path, mapFile;

     
    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    CommonFuction obCommonFuction;
    APIProcedure objApi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
    DataSet ds;
    string PrathamUId = "", BranchId = "", CreatedByEmpId = "", SenderEmpGuid = "", BillXml = "", UploadedFilePath = "", fileExt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;
        if (!IsPostBack)
        {
            dtSelectedTitle = new DataTable();
            DataColumn[] keys = new DataColumn[1];
            dtSelectedTitle.Columns.Add("Class", typeof(string));
            dtSelectedTitle.Columns.Add("ClassTrno_I", typeof(int));
            dtSelectedTitle.Columns.Add("Medium", typeof(string));
            dtSelectedTitle.Columns.Add("MediumID", typeof(int));
            dtSelectedTitle.Columns.Add("Title", typeof(string));
            keys[0] = dtSelectedTitle.Columns.Add("TitleID", typeof(int));
            dtSelectedTitle.Columns.Add("TotalBooks", typeof(int));
            dtSelectedTitle.Columns.Add("Rate", typeof(double));
            dtSelectedTitle.Columns.Add("TotalAmount", typeof(int));
            dtSelectedTitle.Columns.Add("Discount", typeof(double));
            dtSelectedTitle.Columns.Add("DiscountPercent", typeof(double));
            dtSelectedTitle.Columns.Add("NetAmount", typeof(double));

            dtSelectedTitle.PrimaryKey = keys;
            ViewState.Add("dtSelectedTitle", dtSelectedTitle);
            hdnTitleRate.Value = "0";
            lblDiscountPercentage.Text = "0";

            FillCombo();

            hdnFreeBooksDistributionID.Value = "0";
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    int id = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
                    hdnFreeBooksDistributionID.Value = id.ToString();
                    FillFreeDistributionData(id.ToString());
                }
                catch
                {
                    hdnFreeBooksDistributionID.Value = "0";
                }

            }


        }
    }
    private void FillFreeDistributionData(string FreeBooksDistributionID)
    {
        obFreeBooksDistribution.TransID = -8;
        obFreeBooksDistribution.QueryParameterValue = int.Parse(FreeBooksDistributionID);
        DataSet dsobFreeBooksDistribution = obFreeBooksDistribution.Select();
        ddlAcademicSession.ClearSelection();
        if (dsobFreeBooksDistribution.Tables[0].Rows.Count > 0)
        {
            ddlAcademicSession.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["AcYearID_I"].ToString();
            FillFinaincialYear();
            txtLetterNo.Text = dsobFreeBooksDistribution.Tables[0].Rows[0]["LetterNo_V"].ToString();
            txtLetterDate.Text = Convert.ToDateTime(dsobFreeBooksDistribution.Tables[0].Rows[0]["LetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            txtRefLetterNo.Text = dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterNo_V"].ToString();
            if (CheckDateFormate(dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterDate_D"].ToString()))
            {
                txtRefLetterDate.Text = Convert.ToDateTime(dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            }
            mapID.Value = Convert.ToString(dsobFreeBooksDistribution.Tables[0].Rows[0]["FileName"]);
            rbtnSupplyFrom.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["SupplyFrom_V"].ToString();
            ShowDepo();

            if (rbtnSupplyFrom.SelectedValue == "0")
            {
                ddlDepo.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["DepoTrno_I"].ToString();
            }

            txtTotalBooks.Text = "0";

            obFreeBooksDistribution.TransID = -9;
            obFreeBooksDistribution.QueryParameterValue = int.Parse(FreeBooksDistributionID);
            dtSelectedTitle = obFreeBooksDistribution.Select().Tables[0];
            grdSelectedTitle.DataSource = dtSelectedTitle;
            grdSelectedTitle.DataBind();
            CalculateTotal();
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtSelectedTitle.Columns["TitleID"];
            dtSelectedTitle.PrimaryKey = keys;
            ViewState["dtSelectedTitle"] = dtSelectedTitle;

            FillMedium();
        }
    }
    private void FillCombo()
    {
        //ddlAcademicSession
        //ddlClass

        obFreeBooksDistribution.TransID = -1;
        ddlAcademicSession.DataSource = obFreeBooksDistribution.Select();
        ddlAcademicSession.DataTextField = "AcYear";
        ddlAcademicSession.DataValueField = "Id";
        ddlAcademicSession.DataBind();
        FillFinaincialYear();

        FillMedium();



        obFreeBooksDistribution.TransID = -6;
        ddlDepo.DataSource = obFreeBooksDistribution.Select();
        ddlDepo.DataTextField = "DepoName_V";
        ddlDepo.DataValueField = "DepoTrno_I";
        ddlDepo.DataBind();


    }
    protected void rbtnSupplyFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        ShowDepo();
    }
    private void ShowDepo()
    {
        if (rbtnSupplyFrom.SelectedValue == "1")
        {
            ddlDepo.Visible = false;
        }
        if (rbtnSupplyFrom.SelectedValue == "0")
        {
            ddlDepo.Visible = true;
        }
    }
    protected void ddlAcademicSession_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        FillFinaincialYear();
    }
    private void FillClass()
    {
        obFreeBooksDistribution.TransID = -3;
        if (ddlMedium.SelectedValue != "")
            obFreeBooksDistribution.QueryParameterValue = int.Parse(ddlMedium.SelectedValue);
        ddlClass.DataSource = obFreeBooksDistribution.Select();
        ddlClass.DataTextField = "Classdet_V";
        ddlClass.DataValueField = "ClassTrno_I";
        ddlClass.DataBind();

        FillTitle();
    }
    private void FillFinaincialYear()
    {
        obFreeBooksDistribution.TransID = -2;
        obFreeBooksDistribution.QueryParameterValue = int.Parse(ddlAcademicSession.SelectedValue);
        DataSet dsAcademicYear = obFreeBooksDistribution.Select();
        if (dsAcademicYear.Tables[0].Rows.Count > 0)
        {
            lblFinancialYear.Text = dsAcademicYear.Tables[0].Rows[0]["FyYear"].ToString();
        }
        else
        {
            lblFinancialYear.Text = "--";
        }
    }
    protected void ddlClass_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        bool isAllSelected = true;
        foreach (ListItem lstItm in ddlClass.Items)
        {
            if (!lstItm.Selected)
                isAllSelected = false;
        }
        if (isAllSelected)
        {
            chkAllClasses.Checked = true;
        }
        else
            chkAllClasses.Checked = false;
        chkAllTitles.Checked = false;
        // FillMedium();
        FillTitle();

    }
    private void FillMedium()
    {
        obFreeBooksDistribution.TransID = -4;

        ddlMedium.DataSource = obFreeBooksDistribution.Select();
        ddlMedium.DataTextField = "MediunNameHindi_V";
        ddlMedium.DataValueField = "Medium_I";
        ddlMedium.DataBind();

        FillClass();
        //obFreeBooksDistribution.TransID = -10;
        //obFreeBooksDistribution.QueryParameterValue = int.Parse(ddlClass.SelectedValue);
        //DataSet dsDiscount = obFreeBooksDistribution.Select();
        //if (dsDiscount.Tables[0] !=null && dsDiscount.Tables[0].Rows.Count >0 )
        //{
        //    lblDiscountPercentage.Text = dsDiscount.Tables[0].Rows[0]["DiscountPercentage_N"].ToString();

        //}

        //FillTitle();
    }
    protected void ddlMedium_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        chkAllClasses.Checked = false;
        chkAllTitles.Checked = false;
        FillClass();
    }
    private void FillTitle()
    {
        obFreeBooksDistribution.TransID = -5;
        obFreeBooksDistribution.QueryParameterValue = int.Parse(ddlMedium.SelectedValue);
        obFreeBooksDistribution.StringParameter = string.Empty;

        foreach (ListItem itmClass in ddlClass.Items)
        {
            if (itmClass.Selected)
            {
                obFreeBooksDistribution.StringParameter += itmClass.Value + ",";
            }
        }

        if (obFreeBooksDistribution.StringParameter != string.Empty)
        {
            obFreeBooksDistribution.StringParameter = obFreeBooksDistribution.StringParameter.Substring(0,
                                                            obFreeBooksDistribution.StringParameter.Length - 1);

        }
        else
        {
            obFreeBooksDistribution.StringParameter = "0";
        }

        //if (ddlClass.SelectedValue != "")
        //    obFreeBooksDistribution.QueryParameterValue2 = int.Parse(ddlClass.SelectedValue);
        DataSet dsTitle = obFreeBooksDistribution.Select();
        ddlTitle.DataSource = dsTitle.Tables[0];
        ddlTitle.DataTextField = "TitleEnglish_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        if (dsTitle.Tables[0].Rows.Count > 0)
        {
            hdnTitleRate.Value = dsTitle.Tables[0].Rows[0]["Rate_N"].ToString();
        }
        else
        {
            hdnTitleRate.Value = "0";
        }


    }
    protected void btnAddTitle_Click(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;

        int SelectedTitles = 0;
        foreach (ListItem lstTitle in ddlTitle.Items)
        {
            if (lstTitle.Selected == true)
            {
                SelectedTitles++;
                break;
            }
        }

        if (int.Parse(txtTotalBooks.Text) == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Total Books should be greater then 0";
        }
        else if (SelectedTitles == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select title";
        }
        else
        {
            //if (HiddenField1.Value == ddlTitle.SelectedValue)
            //{path = Server.MapPath("~/DistributionBFile/");

            dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];

            //lblDiscountPercentage.Text = GetDiscountOfClass(int.Parse(lstClass.Value));
            foreach (ListItem lstTitle in ddlTitle.Items)
            {
                #region Old Code
                //DataRow drNewTitle = dtSelectedTitle.NewRow();
                //drNewTitle["Class"] = ddlClass.SelectedItem;
                //drNewTitle["ClassTrno_I"] = ddlClass.SelectedValue;
                //drNewTitle["Medium"] = ddlMedium.SelectedItem;
                //drNewTitle["MediumID"] = ddlMedium.SelectedValue;
                //drNewTitle["Title"] = ddlTitle.SelectedItem;
                //drNewTitle["TitleID"] = ddlTitle.SelectedValue;
                //drNewTitle["TotalBooks"] = txtTotalBooks.Text;
                //drNewTitle["Rate"] = hdnTitleRate.Value;
                //double TotalAmount = int.Parse(txtTotalBooks.Text) * double.Parse(hdnTitleRate.Value);
                //drNewTitle["TotalAmount"] = TotalAmount.ToString();
                //drNewTitle["DiscountPercent"] = lblDiscountPercentage.Text;
                //double Discount = TotalAmount * double.Parse(lblDiscountPercentage.Text) / 100;
                //drNewTitle["Discount"] = Math.Round(Discount).ToString();
                //drNewTitle["NetAmount"] = TotalAmount - Discount;
                //dtSelectedTitle.Rows.Add(drNewTitle);
                #endregion
                if (lstTitle.Selected)
                {
                    DataRow drNewTitle = dtSelectedTitle.NewRow();
                    DataTable dtTitleInfo = GetRateAndDiscountOfTitle(int.Parse(lstTitle.Value));
                    drNewTitle["Class"] = dtTitleInfo.Rows[0]["Class"];
                    drNewTitle["ClassTrno_I"] = dtTitleInfo.Rows[0]["ClassTrno_I"];
                    drNewTitle["Medium"] = ddlMedium.SelectedItem;
                    drNewTitle["MediumID"] = ddlMedium.SelectedValue;
                    drNewTitle["Title"] = lstTitle.Text;
                    drNewTitle["TitleID"] = lstTitle.Value;
                    drNewTitle["TotalBooks"] = txtTotalBooks.Text;

                    hdnTitleRate.Value = dtTitleInfo.Rows[0]["Rate_N"].ToString();
                    drNewTitle["Rate"] = hdnTitleRate.Value;
                    double TotalAmount = int.Parse(txtTotalBooks.Text) * double.Parse(hdnTitleRate.Value);
                    drNewTitle["TotalAmount"] = TotalAmount.ToString();
                    lblDiscountPercentage.Text = dtTitleInfo.Rows[0]["DiscountPercentage_N"].ToString();
                    drNewTitle["DiscountPercent"] = lblDiscountPercentage.Text;
                    double Discount = TotalAmount * double.Parse(lblDiscountPercentage.Text) / 100;
                    drNewTitle["Discount"] = Math.Round(Discount, 2).ToString();
                    drNewTitle["NetAmount"] = TotalAmount - Discount;

                    try
                    {
                        dtSelectedTitle.Rows.Add(drNewTitle);
                    }
                    catch
                    {
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "Duplicate entry of title\"" + lstTitle.Text + "\"";
                        break;
                    }

                }
            }

            ViewState.Add("dtSelectedTitle", dtSelectedTitle);
            // ddlTitle.SelectedItem;
            //HiddenField1.Value = Convert.ToString(ddlTitle.SelectedValue);
            FillGrid();
            //}
            //else
            //{ 

            //}
        }

    }
    private string GetDiscountOfClass(int ClassID)
    {
        //obFreeBooksDistribution.TransID = -10;
        //obFreeBooksDistribution.QueryParameterValue = int.Parse(ddlClass.SelectedValue);

        obFreeBooksDistribution.TransID = -10;
        obFreeBooksDistribution.QueryParameterValue = ClassID;
        DataSet dsDiscount = obFreeBooksDistribution.Select();
        if (dsDiscount.Tables[0].Rows.Count > 0)
        {
            return dsDiscount.Tables[0].Rows[0]["DiscountPercentage_N"].ToString();
        }
        else
        {
            return "0";
        }

    }

    private DataTable GetRateAndDiscountOfTitle(int TitleID)
    {
        obFreeBooksDistribution.TransID = -11;
        obFreeBooksDistribution.QueryParameterValue = TitleID;
        DataSet dsRate = obFreeBooksDistribution.Select();
        if (dsRate.Tables[0].Rows.Count > 0)
        {
            return dsRate.Tables[0];
        }
        else
        {
            return null;
        }

    }
    private void FillGrid()
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];

        grdSelectedTitle.DataSource = dtSelectedTitle;
        grdSelectedTitle.DataBind();

        CalculateTotal();

    }
    private bool CheckDateFormate(string DateValue)
    {
        try
        {
            DateTime dtTmp = DateTime.Parse(DateValue, cult);
            return true;
        }
        catch
        {
            return false;
        }
    }
    protected void btnSupply_Click(object sender, EventArgs e)
    {
        string CheckCond = "";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;

        int FreeBooksDistributionID = 0, DepoID = 0;
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];


        if (!CheckDateFormate(txtLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid letter date";
        }
        else if (dtSelectedTitle.Rows.Count > 0)
        {

            APIProcedure objApi = new APIProcedure();
            bool IsValidFile = true;
            if (fileScanLetter.HasFile)
            {

                string uploadStatus = objApi.uploadFile(fileScanLetter, "DistributionBFile", 3000);
                if (uploadStatus != "Ok")
                {
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = uploadStatus;
                    IsValidFile = false;
                }
            }
            if (IsValidFile)
            {
                if (DateTime.Parse(txtLetterDate.Text, cult) > DateTime.Now.Date ||
                        (CheckDateFormate(txtRefLetterDate.Text) && 
                        DateTime.Parse(txtRefLetterDate.Text, cult) > DateTime.Now.Date))
                {
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Date cannot be a future date";
                }
                else
                {
                    path = Server.MapPath("~/DistributionBFile/");
                    if (fileScanLetter.HasFile)
                    {
                        // mapFile = "000" + fileScanLetter.FileName;
                        // fileScanLetter.PostedFile.SaveAs(path + "000" + fileScanLetter.FileName);
                        mapFile = objApi.FullFileName;

                    }
                    else
                    {
                        mapFile = mapID.Value;
                    }
                    int.TryParse(hdnFreeBooksDistributionID.Value, out FreeBooksDistributionID);
                    obFreeBooksDistribution.FreeBooksDistributionID = FreeBooksDistributionID;
                    obFreeBooksDistribution.AcYearID = int.Parse(ddlAcademicSession.SelectedValue);
                    obFreeBooksDistribution.LetterNo = txtLetterNo.Text;
                    obFreeBooksDistribution.LetterDate = DateTime.Parse(txtLetterDate.Text, cult).ToString("yyyy-MM-dd");
                    obFreeBooksDistribution.RefLetterNo = txtRefLetterNo.Text;
                    if (CheckDateFormate(txtRefLetterDate.Text))
                    {
                        obFreeBooksDistribution.RefLetterDate = DateTime.Parse(txtRefLetterDate.Text, cult).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        obFreeBooksDistribution.RefLetterDate = null;
                    }
                    obFreeBooksDistribution.ScanLetterFileName = fileScanLetter.FileName;
                    obFreeBooksDistribution.SupplyFrom = rbtnSupplyFrom.SelectedValue;
                    int.TryParse(ddlDepo.SelectedValue, out DepoID);
                    obFreeBooksDistribution.DepoTrno = DepoID;
                    obFreeBooksDistribution.FileName = mapFile;
                    obFreeBooksDistribution.TransID = FreeBooksDistributionID;
                    hdnFreeBooksDistributionID.Value = obFreeBooksDistribution.InsertUpdate().ToString();
                    Label lblFtTotalNetAmount = new Label();
                    for (int i = 0; i < dtSelectedTitle.Rows.Count; i++)
                    {
                        int.TryParse(hdnFreeBooksDistributionID.Value, out FreeBooksDistributionID);
                        obFreeBooksDistribution.FreeBooksDistributionID = FreeBooksDistributionID;
                        obFreeBooksDistribution.TitleID = int.Parse(dtSelectedTitle.Rows[i]["TitleID"].ToString());
                        obFreeBooksDistribution.TotalBooks = int.Parse(dtSelectedTitle.Rows[i]["TotalBooks"].ToString());
                        obFreeBooksDistribution.Rate = double.Parse(dtSelectedTitle.Rows[i]["Rate"].ToString());
                        obFreeBooksDistribution.DiscountPercent = double.Parse(dtSelectedTitle.Rows[i]["DiscountPercent"].ToString());
                        obFreeBooksDistribution.TransID = -1;
                        lblFtTotalNetAmount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalNetAmount");
                        obFreeBooksDistribution.InsertUpdate();
                        CheckCond = "Ok";
                    }
                    if (CheckCond == "Ok")
                    {
                        try
                        {
                            obCommonFuction = new CommonFuction();
                            ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, Session["UserID"].ToString());
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                SenderEmpGuid = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();// ds.Tables[1].Rows[0][0].ToString();
                            }
                            if (SenderEmpGuid != "")
                            {
                                PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
                                BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
                                CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();

                                byte PaymentType = 1;
                                //ds = obCommonFuction.FillDatasetByProc("call GetPrinterRegStatus(" + i + ")");
                                string ReceiptDetailxml = "", INSTRUMENTXML = "";
                                string NewInsnNo = Guid.NewGuid().ToString();
                                DateTime DateRec = new DateTime();

                                DateRec = DateTime.Parse(txtLetterDate.Text, cult);

                                INSTRUMENTXML = @"<DocumentElement><INSTRUMENTXML><ROWNO>1</ROWNO>" +
        "<CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE> " +
        "<CHEQUEAMOUNT>" + lblFtTotalNetAmount.Text + "</CHEQUEAMOUNT>" +
        "<INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";


                                ReceiptDetailxml = @"<DocumentElement><RECEIPTDETAILXML><ROWNO>1</ROWNO>" +
        "<COLUMNID>00034</COLUMNID><COLUMNVALUE>" + txtLetterNo.Text + "</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID>" +
        "<RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML><ROWNO>1</ROWNO>" +
        "<COLUMNID>00035</COLUMNID><COLUMNVALUE>Free Books Demand From RSK</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID><RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID>" +
        "</RECEIPTDETAILXML><RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00004</COLUMNID><COLUMNVALUE>" + lblFtTotalNetAmount.Text + "</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID>" +
        "<RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML></DocumentElement>";



                              //  ds = objWebService.Save_Free_Book_Demand_From_RSK(DateRec.ToString("yyyy/MM/dd"), CreatedByEmpId, PaymentType, PrathamUId.ToString(), BranchId, ReceiptDetailxml, INSTRUMENTXML, lblFtTotalNetAmount.Text, CreatedByEmpId, objUMaster.SendToEmpId(),
                              //      "From Free Books Demand From RSK  Letter / Notesheet No.: " + txtLetterNo.Text, null);

                                //obPriEval.UpdateDisBFreebkAccHRN(ds.Tables[0].Rows[0][1].ToString(), hdnFreeBooksDistributionID.Value.ToString(), int.Parse(hdnFreeBooksDistributionID.Value));


                            }
                        }
                        catch { }
                    }
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('Record saved successfully');</script>");
                    Response.Redirect("ViewDemandFreeTextBooks.aspx");
                }

            }
        }
        else
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select at least one title";
        }
    }
    private void ResetFields()
    {
        ViewState["dtSelectedTitle"] = null;
        dtSelectedTitle = null;
        grdSelectedTitle.DataSource = dtSelectedTitle;
        grdSelectedTitle.DataBind();
        txtLetterNo.Text = "";
        txtLetterDate.Text = "";
        txtRefLetterDate.Text = "";
        txtRefLetterNo.Text = "";
        txtTotalBooks.Text = "0";
    }
    protected void grdSelectedTitle_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        dtSelectedTitle.Rows[e.RowIndex].Delete();
        dtSelectedTitle.AcceptChanges();
        ViewState["dtSelectedTitle"] = dtSelectedTitle;
        FillGrid();
    }
    protected void GrdLetterInfo_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {

    }
    protected void GrdLetterInfo_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //obClassMaster = new ClassMaster();
        //obClassMaster.Delete(Convert.ToInt32(GrdClassMaster.DataKeys[e.RowIndex].Value.ToString()));
        //FillData();
    }

    private void CalculateTotal()
    {
        double TotalAmount = 0;
        int TotalBooks = 0;
        double TotalDiscount = 0;
        double TotalNetAmount = 0;

        for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
        {
            //   TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[10].Text);
            Label lblTotalBooks = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblBooks");
            Label lblDiscount = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblDiscount");
            Label lblNetAmount = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblNetAmount");
            Label lblAmount = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblAmount");

            TotalDiscount += double.Parse(lblDiscount.Text);
            TotalAmount += double.Parse(lblAmount.Text);
            TotalBooks += int.Parse(lblTotalBooks.Text);
            TotalNetAmount += double.Parse(lblNetAmount.Text);

        }

        Label lblFtTotalBooks = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalBooks");
        Label lblFtTotalDiscount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalDiscount");
        Label lblFtTotalNetAmount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalNetAmount");
        Label lblFtTotalAmount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalAmount");

        lblFtTotalBooks.Text = TotalBooks.ToString();
        lblFtTotalDiscount.Text = TotalDiscount.ToString();
        lblFtTotalNetAmount.Text = TotalNetAmount.ToString();
        lblFtTotalAmount.Text = TotalAmount.ToString();

    }
    protected void chkAllTitles_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllTitles.Checked)
        {
            for (int i = 0; i < ddlTitle.Items.Count; i++)
            {
                ddlTitle.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < ddlTitle.Items.Count; i++)
            {
                ddlTitle.Items[i].Selected = false;
            }
        }
    }
    protected void chkAllClasses_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAllClasses.Checked)
        {
            for (int i = 0; i < ddlClass.Items.Count; i++)
            {
                ddlClass.Items[i].Selected = true;
            }
        }
        else
        {
            for (int i = 0; i < ddlClass.Items.Count; i++)
            {
                ddlClass.Items[i].Selected = false;
            }
        }
        chkAllTitles.Checked = false;
        FillTitle();
    }
    protected void ChkAllTitles_OnCheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkSelectAllTitleToDel = (CheckBox)sender;
        if (chkSelectAllTitleToDel.Checked)
        {
            foreach (GridViewRow dr in grdSelectedTitle.Rows)
            {
                CheckBox chkSelected = (CheckBox)dr.FindControl("ChkSelectTitle");
                chkSelected.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow dr in grdSelectedTitle.Rows)
            {
                CheckBox chkSelected = (CheckBox)dr.FindControl("ChkSelectTitle");
                chkSelected.Checked = false;
            }
        }
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        int[] ToDelTitleIDs = new int[grdSelectedTitle.Rows.Count];

        int rowCount = 0;
        foreach (GridViewRow dr in grdSelectedTitle.Rows)
        {
            CheckBox chkSelected = (CheckBox)dr.FindControl("ChkSelectTitle");
            if (chkSelected.Checked)
            {
                ToDelTitleIDs[rowCount] = int.Parse(grdSelectedTitle.DataKeys[dr.RowIndex].Value.ToString());
                rowCount++;
            }
        }

        if (rowCount > 0)
        {
            for (int i = 0; i < ToDelTitleIDs.Length; i++)
            {
                for (int j = 0; j < dtSelectedTitle.Rows.Count; j++)
                {
                    //CheckBox chkSelected = (CheckBox)grdSelectedTitle.Rows[i].FindControl("ChkSelectTitle");
                    if (dtSelectedTitle.Rows[j]["TitleID"].ToString() == ToDelTitleIDs[i].ToString())
                    {
                        dtSelectedTitle.Rows.RemoveAt(j);
                        dtSelectedTitle.AcceptChanges();
                        break;
                    }
                }
            }


            ViewState["dtSelectedTitle"] = dtSelectedTitle;
            FillGrid();
        }
        else
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "No title selected to delete";
        }
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool isAllSelected = true;
        foreach (ListItem lstItm in ddlTitle.Items)
        {
            if (!lstItm.Selected)
                isAllSelected = false;
        }
        if (isAllSelected)
        {
            chkAllTitles.Checked = true;
        }
        else
            chkAllTitles.Checked = false;
    }
    protected void btnSelectClass_Click(object sender, EventArgs e)
    {
        ddlClass_OnSelectedIndexChanged(sender, e);
    }
}
