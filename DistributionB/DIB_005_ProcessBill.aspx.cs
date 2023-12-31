using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using System;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;


public partial class Distribution_FreeTextBooksDemandFromRSK : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.ProcessBill obProcessBill = new MPTBCBussinessLayer.DistributionB.ProcessBill();
    private DataTable dtSelectedTitle;

    CultureInfo cult = new CultureInfo("gu-IN", true);
    string path, mapFile;
    ///int count; HiddenField2.Value = "0";
    ///
    PRI_TenderEvaluation obPriEval = new PRI_TenderEvaluation();
    APIProcedure objdb = new APIProcedure();
    //YF_WebService objWebService = new YF_WebService();
    UserMaster objUMaster = new UserMaster();
    DataSet ds;
    string PrathamUId = "", BranchId = "", CreatedByEmpId = "", SenderEmpGuid = "", BillXml = "", UploadedFilePath = "", fileExt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        mainDiv.CssClass = "form-message error";
        lblmsg.Text = "Please select at least one title";

        if (!IsPostBack)
        {
            dtSelectedTitle = new DataTable();
            DataColumn[] keys = new DataColumn[1];
            dtSelectedTitle.Columns.Add("Title", typeof(string));
            dtSelectedTitle.Columns.Add("SubTitle", typeof(string));
            keys[0] = dtSelectedTitle.Columns.Add("SubTitleID", typeof(int));
            dtSelectedTitle.Columns.Add("TotalBooks", typeof(int));
            dtSelectedTitle.Columns.Add("Rate", typeof(double));
            dtSelectedTitle.Columns.Add("TotalAmount", typeof(int));
            dtSelectedTitle.Columns.Add("Discount", typeof(int));
            dtSelectedTitle.Columns.Add("DiscountPercent", typeof(double));
            dtSelectedTitle.Columns.Add("NetAmount", typeof(int));
            dtSelectedTitle.PrimaryKey = keys;
            ViewState.Add("dtSelectedTitle", dtSelectedTitle);

            FillCombo();

            hdnProcessBillID.Value = "0";
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    int id = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
                    hdnProcessBillID.Value = id.ToString();
                    FillFreeDistributionData(id.ToString());
                }
                catch
                {
                    hdnProcessBillID.Value = "0";
                }

            }
            else if (Request.QueryString["DemandID"] != null)
            {
                hdnDemandID.Value = new APIProcedure().Decrypt(Request.QueryString["DemandID"].ToString());
                obProcessBill.TransID = -10;
                obProcessBill.QueryParameterValue = int.Parse(hdnDemandID.Value);
                DataSet dsRefBillId = obProcessBill.Select();
                if (dsRefBillId.Tables[0].Rows[0]["RefBillID_I"].ToString() != "" &&
                    dsRefBillId.Tables[0].Rows[0]["RefBillID_I"].ToString() != "0")
                {
                    //int id = int.Parse(Request.QueryString["ID"]);
                    hdnProcessBillID.Value = dsRefBillId.Tables[0].Rows[0]["RefBillID_I"].ToString();
                    FillFreeDistributionData(hdnProcessBillID.Value);
                    ddlAcademicSession.SelectedValue = dsRefBillId.Tables[0].Rows[0]["AcYrID_I"].ToString();
                    txtRefLetterNo.Text = dsRefBillId.Tables[0].Rows[0]["RefLetterNo_V"].ToString();
                }
                else
                {
                    obProcessBill.TransID = -11;
                    obProcessBill.QueryParameterValue = int.Parse(hdnDemandID.Value);
                    dtSelectedTitle = obProcessBill.Select().Tables[0];
                    grdSelectedTitle.DataSource = dtSelectedTitle;
                    grdSelectedTitle.DataBind();
                    // txtDiscountPercentage.Text = "15";
                    CalculateTotal();
                    DataColumn[] keys1 = new DataColumn[1];
                    keys1[0] = dtSelectedTitle.Columns["SubTitleID"];
                    dtSelectedTitle.PrimaryKey = keys1;
                    ViewState["dtSelectedTitle"] = dtSelectedTitle;

                    FillSubTitle();
                    ddlAcademicSession.SelectedValue = dsRefBillId.Tables[0].Rows[0]["AcYrID_I"].ToString();
                    txtRefLetterNo.Text = dsRefBillId.Tables[0].Rows[0]["RefLetterNo_V"].ToString();
                    txtRefLetterDate.Text =Convert.ToDateTime(dsRefBillId.Tables[0].Rows[0]["LetterDate_D"]).ToString("dd/MM/yyyy");
                    ddlTitle.SelectedValue = dsRefBillId.Tables[0].Rows[0]["TitleID_I"].ToString();
                    txtTotalBooks.Enabled = false;
                    txtRate.Enabled = false;
                }
            }

        }
    }

    private void FillFreeDistributionData(string ProcessBillID)
    {
        obProcessBill.TransID = -8;
        obProcessBill.QueryParameterValue = int.Parse(ProcessBillID);
        DataSet dsobFreeBooksDistribution = obProcessBill.Select();
        ddlAcademicSession.ClearSelection();
        if (dsobFreeBooksDistribution.Tables[0].Rows.Count > 0)
        {
            ddlAcademicSession.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["AcYearID_I"].ToString();
            FillFinaincialYear();
            mapID.Value = Convert.ToString(dsobFreeBooksDistribution.Tables[0].Rows[0]["BillDOc"]);
            txtLetterNo.Text = dsobFreeBooksDistribution.Tables[0].Rows[0]["LetterNo_V"].ToString();
            txtLetterDate.Text = Convert.ToDateTime(dsobFreeBooksDistribution.Tables[0].Rows[0]["LetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            txtRefLetterNo.Text = dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterNo_V"].ToString();
            try
            {
                txtRefLetterDate.Text = Convert.ToDateTime(dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            }
            catch
            {
                txtRefLetterDate.Text = "";
            }
            ddlBillType.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["BillType_V"].ToString();
            ddlDepartment.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["DepartmentID_I"].ToString();

            txtTotalBooks.Text = "0";

            obProcessBill.TransID = -9;
            obProcessBill.QueryParameterValue = int.Parse(ProcessBillID);
            dtSelectedTitle = obProcessBill.Select().Tables[0];
            grdSelectedTitle.DataSource = dtSelectedTitle;
            grdSelectedTitle.DataBind();
            // txtDiscountPercentage.Text = "15";
            CalculateTotal();
            DataColumn[] keys = new DataColumn[1];
            keys[0] = dtSelectedTitle.Columns["SubTitleID"];
            dtSelectedTitle.PrimaryKey = keys;
            ViewState["dtSelectedTitle"] = dtSelectedTitle;

            FillSubTitle();
        }
    }

    private void FillCombo()
    {
        //ddlAcademicSession
        //ddlClass

        obProcessBill.TransID = -1;
        ddlAcademicSession.DataSource = obProcessBill.Select();
        ddlAcademicSession.DataTextField = "AcYear";
        ddlAcademicSession.DataValueField = "Id";
        ddlAcademicSession.DataBind();
        FillFinaincialYear();

        obProcessBill.TransID = -3;
        ddlTitle.DataSource = obProcessBill.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        FillSubTitle();

        obProcessBill.TransID = -6;
        ddlDepartment.DataSource = obProcessBill.Select();
        ddlDepartment.DataTextField = "DepartmentName_V";
        ddlDepartment.DataValueField = "DepartmentID_I";
        ddlDepartment.DataBind();


    }
    protected void rbtnSupplyFrom_SelectedIndexChanged(object sender, EventArgs e)
    {
        //ShowDepo();
    }

    protected void ddlAcademicSession_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        FillFinaincialYear();
    }
    private void FillFinaincialYear()
    {
        obProcessBill.TransID = -2;
        obProcessBill.QueryParameterValue = int.Parse(ddlAcademicSession.SelectedValue);
        DataSet dsAcademicYear = obProcessBill.Select();
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



    }

    protected void ddlTitle_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubTitle();
    }
    private void FillSubTitle()
    {
        obProcessBill.TransID = -5;
        obProcessBill.QueryParameterValue = int.Parse(ddlTitle.SelectedValue);
        DataSet dsTitle = obProcessBill.Select();
        ddlSubTitle.DataSource = dsTitle.Tables[0];
        ddlSubTitle.DataTextField = "SubTitleHindi_V";
        ddlSubTitle.DataValueField = "SubTitleID_I";
        ddlSubTitle.DataBind();


    }
    protected void btnAddTitle_Click(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;

        if (int.Parse(txtTotalBooks.Text) == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Total Books should be greater then 0";
        }
        else if (int.Parse(txtRate.Text) == 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Rate should be greater then 0";
        }
        else
        {
            dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
            DataRow drNewTitle = dtSelectedTitle.NewRow();
            if (grdSelectedTitle.Rows.Count == 0)
            {
                HiddenField2.Value = "";
            }
            if (HiddenField2.Value == "")
            {
                HiddenField2.Value = "1";

                drNewTitle["Title"] = ddlTitle.SelectedItem;
                drNewTitle["SubTitle"] = ddlSubTitle.SelectedItem;
                drNewTitle["SubTitleID"] = ddlSubTitle.SelectedValue;
                drNewTitle["TotalBooks"] = txtTotalBooks.Text;
                drNewTitle["Rate"] = txtRate.Text;
                double TotalAmount = int.Parse(txtTotalBooks.Text) * double.Parse(txtRate.Text);
                drNewTitle["TotalAmount"] = TotalAmount.ToString();
                drNewTitle["DiscountPercent"] = txtDiscountPercentage.Text;
                double Discount = TotalAmount * double.Parse(txtDiscountPercentage.Text) / 100;
                drNewTitle["Discount"] = Math.Round(Discount).ToString();
                drNewTitle["NetAmount"] = TotalAmount - Discount;
                dtSelectedTitle.Rows.Add(drNewTitle);
                ViewState.Add("dtSelectedTitle", dtSelectedTitle);
                HiddenField1.Value = ddlTitle.SelectedValue;
                FillGrid();
            }
            else
            {
                //if (HiddenField1.Value == ddlTitle.SelectedValue)
                //{

                    drNewTitle["Title"] = ddlTitle.SelectedItem;
                    drNewTitle["SubTitle"] = ddlSubTitle.SelectedItem;
                    drNewTitle["SubTitleID"] = ddlSubTitle.SelectedValue;
                    drNewTitle["TotalBooks"] = txtTotalBooks.Text;
                    drNewTitle["Rate"] = txtRate.Text;
                    double TotalAmount = int.Parse(txtTotalBooks.Text) * double.Parse(txtRate.Text);
                    drNewTitle["TotalAmount"] = TotalAmount.ToString();
                    drNewTitle["DiscountPercent"] = txtDiscountPercentage.Text;
                    double Discount = TotalAmount * double.Parse(txtDiscountPercentage.Text) / 100;
                    drNewTitle["Discount"] = Math.Round(Discount).ToString();
                    drNewTitle["NetAmount"] = TotalAmount - Discount;
                    try
                    {
                        dtSelectedTitle.Rows.Add(drNewTitle);
                    }
                    catch
                    {
                        mainDiv.Style.Add("display", "block");
                        lblmsg.Text = "Duplicate Title \"" + ddlSubTitle.SelectedItem + "\"";
                    }
                    ViewState.Add("dtSelectedTitle", dtSelectedTitle);

                    FillGrid();
                //}
                //else
                //{
                //    mainDiv.Style.Add("display", "block");
                //    lblmsg.Text = "  एक बिल में एक की टाइटल जोड़ सकते है  ";
                //}
            }


        }

    }
    private void FillGrid()
    {
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];
        grdSelectedTitle.DataSource = dtSelectedTitle;
        grdSelectedTitle.DataBind();
        CalculateTotal();
    }

    private void CalculateTotal()
    {
        double TotalAmount = 0;
        for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
        {
            TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[8].Text);
        }

        lblTotalAmount.Text = TotalAmount.ToString("N");
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
        int ErrorRowNumber = 0;
        string Rate = "0";
        for (int i = 0; i < grdSelectedTitle.Rows.Count; i++)
        {
            Label lblDgRate = (Label)grdSelectedTitle.Rows[i].FindControl("lblDgRate");

            if (lblDgRate == null)
            {
                TextBox txtDgRate = (TextBox)grdSelectedTitle.Rows[i].FindControl("txtDgRate");
                Rate = txtDgRate.Text;
            }
            else
            {
                Rate = lblDgRate.Text;
            }

            if (Rate == "0")
            {
                ErrorRowNumber = i + 1;
                break;
            }
        }
        int ProcessBillID = 0;
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];

        if (!CheckDateFormate(txtLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid letter date";
        }
        else if (txtRefLetterDate.Text != "" && !CheckDateFormate(txtRefLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid Reference letter date";
        }
        else if (DateTime.Parse(txtLetterDate.Text, cult) > DateTime.Now.Date ||
            (txtRefLetterDate.Text != "" && DateTime.Parse(txtRefLetterDate.Text, cult) > DateTime.Now.Date))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Date can not be future date";
        }
        else if (ErrorRowNumber > 0)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Rate can not be 0 in row number " + ErrorRowNumber.ToString();
        }
        else if (dtSelectedTitle.Rows.Count > 0)
        {
            int.TryParse(hdnProcessBillID.Value, out ProcessBillID);
            obProcessBill.ProcessBillTrno = ProcessBillID;

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
                path = Server.MapPath("~/DistributionBFile/");
                if (fileScanLetter.HasFile)
                {
                    //mapFile = fileScanLetter.FileName;
                    //fileScanLetter.PostedFile.SaveAs(path + fileScanLetter.FileName);
                    mapFile = objApi.FullFileName;
                }
                else
                {
                    mapFile = mapID.Value;
                }

                obProcessBill.AcYearID = int.Parse(ddlAcademicSession.SelectedValue);
                obProcessBill.LetterNo = txtLetterNo.Text;
                obProcessBill.LetterDate = DateTime.Parse(txtLetterDate.Text, cult).ToString("yyyy-MM-dd");
                obProcessBill.RefLetterNo = txtRefLetterNo.Text;
                if (txtRefLetterDate.Text != "")
                {
                    obProcessBill.RefLetterDate = DateTime.Parse(txtRefLetterDate.Text, cult).ToString("yyyy-MM-dd");
                }
                else
                {
                    obProcessBill.RefLetterDate = null;
                }
                obProcessBill.ScanLetterFileName = fileScanLetter.FileName;
                obProcessBill.DepartmentID = int.Parse(ddlDepartment.SelectedValue);
                obProcessBill.BillType = ddlBillType.SelectedValue;
                obProcessBill.BillDOc = Convert.ToString(mapFile);
                obProcessBill.DemandID = int.Parse(hdnDemandID.Value);
                obProcessBill.TransID = ProcessBillID;
                hdnProcessBillID.Value = obProcessBill.InsertUpdate().ToString();

                for (int i = 0; i < dtSelectedTitle.Rows.Count; i++)
                {
                    int.TryParse(hdnProcessBillID.Value, out ProcessBillID);
                    obProcessBill.ProcessBillTrno = ProcessBillID;
                    obProcessBill.SubTitleID = int.Parse(dtSelectedTitle.Rows[i]["SubTitleID"].ToString());
                    obProcessBill.TotalBooks = int.Parse(dtSelectedTitle.Rows[i]["TotalBooks"].ToString());
                    obProcessBill.Rate = double.Parse(dtSelectedTitle.Rows[i]["Rate"].ToString());
                    obProcessBill.DiscountPercent = double.Parse(dtSelectedTitle.Rows[i]["DiscountPercent"].ToString());
                    obProcessBill.TransID = -1;

                    obProcessBill.InsertUpdate();
                    CheckCond = "Ok";
                }
                if (CheckCond == "Ok")
                {
                    try
                    {
                        CommonFuction obCommonFuction = new CommonFuction();
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
                            string ReceiptDetailxml = "", Instrumentxml = "", NewInsnNo = "";
                            NewInsnNo = Guid.NewGuid().ToString();
                            DateTime DateRec = new DateTime();

                            DateRec = DateTime.Parse(txtLetterDate.Text, cult);

        //                    Instrumentxml = @"<DocumentElement><INSTRUMENTXML><ROWNO>1</ROWNO><CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE>" +
        //"<CHEQUEAMOUNT>" + lblTotalAmount.Text.Replace(",", "") + "</CHEQUEAMOUNT><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";


        //                    ReceiptDetailxml = @"<DocumentElement><RECEIPTDETAILXML>" +
        //                  "<ROWNO>1</ROWNO><COLUMNID>00011</COLUMNID><COLUMNVALUE>" + txtRefLetterNo.Text + "," + DateRec.ToString("yyyy/MM/dd") + "</COLUMNVALUE>" +
        //                      "<INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID><RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML>" +
        //                      "<ROWNO>1</ROWNO><COLUMNID>00034</COLUMNID><COLUMNVALUE>" + txtLetterNo.Text + "</COLUMNVALUE>" +
        //                      "<INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID>" +
        //                      "<RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML>" +
        //                      "<ROWNO>1</ROWNO><COLUMNID>00036</COLUMNID><COLUMNVALUE>" + DateRec.ToString("yyyy/MM/dd") + "</COLUMNVALUE>" +
        //                    "<INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID><RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML>" +
        //                      "<ROWNO>1</ROWNO><COLUMNID>00035</COLUMNID><COLUMNVALUE>Bill Process</COLUMNVALUE>" +
        //                      "<INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID><RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML><RECEIPTDETAILXML>" +
        //                      "<ROWNO>1</ROWNO><COLUMNID>00004</COLUMNID><COLUMNVALUE>" + lblTotalAmount.Text.Replace(",", "") + "</COLUMNVALUE><INSTRUMENTID>" + NewInsnNo + "</INSTRUMENTID><RECEIPTTYPEID>05136c22-0258-4d64-b90e-71d00e570d14</RECEIPTTYPEID></RECEIPTDETAILXML></DocumentElement>";

        //                    ds = objWebService.SAVE_Bill_Process_And_Received_Payment_information(DateRec.ToString("yyyy/MM/dd"), CreatedByEmpId, PaymentType, PrathamUId.ToString(), BranchId, ReceiptDetailxml, Instrumentxml, lblTotalAmount.Text.Replace(",", ""), CreatedByEmpId, objUMaster.SendToEmpId(),
        //                        "From Bill Process Bill Type: " + ddlBillType.SelectedItem.Text + " / " + ddlDepartment.SelectedItem.Text + " Bill No:" + txtLetterNo.Text, null);
        //                    obPriEval.UpdateDisBBillAccHRN(ds.Tables[0].Rows[0][1].ToString(), hdnProcessBillID.Value, int.Parse(hdnProcessBillID.Value));


                        }
                    }
                    catch { }
                }
                HiddenField2.Value = "";
                if (hdnDemandID.Value != "0")
                {
                    Response.Redirect("DemandOtherThenTextBook.aspx");
                }
                else
                {
                    Response.Redirect("BillProcessPaymentInfo.aspx");
                }
            }

           
        }
        else
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.Style.Add("Class", "form-message error");
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
    protected void grdSelectedTitle_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        grdSelectedTitle.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void grdSelectedTitle_RowUpdated(object sender, System.Web.UI.WebControls.GridViewUpdatedEventArgs e)
    {

    }
    protected void grdSelectedTitle_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
    {
        grdSelectedTitle.EditIndex = -1;
        FillGrid();
    }
    protected void grdSelectedTitle_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtDgRate = (TextBox)grdSelectedTitle.Rows[e.RowIndex].FindControl("txtDgRate");
        if (txtDgRate.Text == "" || int.Parse(txtDgRate.Text) == 0)
        {
            mainDiv.Style.Add("display", "block");
            mainDiv.Style.Add("Class", "form-message error");
            lblmsg.Text = "Rate Can not be 0";
        }
        else
        {
            dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];

            string TotalBooks = grdSelectedTitle.Rows[e.RowIndex].Cells[4].Text;
            dtSelectedTitle.Rows[e.RowIndex]["Rate"] = txtDgRate.Text;
            double TotalAmount = int.Parse(TotalBooks) * double.Parse(txtDgRate.Text);
            dtSelectedTitle.Rows[e.RowIndex]["TotalAmount"] = TotalAmount.ToString();
            dtSelectedTitle.Rows[e.RowIndex]["DiscountPercent"] = txtDiscountPercentage.Text;
            double Discount = TotalAmount * double.Parse(txtDiscountPercentage.Text) / 100;
            dtSelectedTitle.Rows[e.RowIndex]["Discount"] = Math.Round(Discount).ToString();
            dtSelectedTitle.Rows[e.RowIndex]["NetAmount"] = TotalAmount - Discount;

            dtSelectedTitle.AcceptChanges();
            ViewState["dtSelectedTitle"] = dtSelectedTitle;
            grdSelectedTitle.EditIndex = -1;
            mainDiv.Style.Add("display", "block");
            mainDiv.CssClass = "form-message success";
            lblmsg.Text = "Record updated successfully";
            FillGrid();
            //dtSelectedTitle.Rows[]
        }
    }
    protected void grdSelectedTitle_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
