using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Web.UI;
public partial class Academic_ViewPrintingProofInfo : System.Web.UI.Page
{
    MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();
    CommonFuction obCommonFunction = new CommonFuction();
    public string acyeara;
    // Table tblJobTitle;
    CultureInfo cult = new CultureInfo("gu-IN", true);
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
            FillCombo();
            BindTenderDDL();
            ddlPrinter.DataSource = obCommonFunction.FillDatasetByProc("call USP_ACD005_PrinterProofSelectNew(5,0,0,'','" + DdlACYear.SelectedValue + "','')");
            ddlPrinter.DataTextField = "nameofpress_v";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, "All");
           // FillJobGrid();

        }

        //if (Session["tblJobTitle"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //    //pnlJobTitles.Controls.Add(tblJobTitle);
        //}

    }

    private void FillCombo()
    {
        obPrinterProof.QueryType = -2;
        ddlStatus.DataSource = obPrinterProof.Select();
        ddlStatus.DataTextField = "Status_V";
        ddlStatus.DataValueField = "StatusMasterID_I";
        ddlStatus.DataBind();

    }
    private void FillJobGrid()
    {
        obPrinterProof.QueryType = 0;
        //grdJobList.DataSource = obCommonFunction.FillDatasetByProc("call USP_ACDPrinterAgriment('"+DdlACYear.SelectedItem.Text+"',"+ddlPrinter.SelectedValue+")");
        grdJobList.DataSource = obCommonFunction.FillDatasetByProc("call USP_ACD005_PrinterProofSelectNew(6,0,0,'" + ddlPrinter.SelectedItem.Value.ToString().Replace("All", "0") + "','"+DdlACYear.SelectedItem.Text+"','"+ddlTender.SelectedItem.Text+"')"); //obPrinterProof.Select();
        grdJobList.DataBind();
    }
    protected void lnkPrinter_Click(object sender, EventArgs e)
    {
        tblJobDetails.Visible = true;
        pnlJob.Visible = false;
    }
    string IsProceed = "";
    private bool SaveValues()
    {
        obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();
        obPrinterProof.TransID = 0;
        
        bool IsSuccess = true;
        IsProceed = "Success";
        for (int rowno = 0; rowno < grdJobDetails.Rows.Count; rowno++)
        {
            string gridTextValue = string.Empty;
           // obPrinterProof.WorkOrderID_I = -- int.Parse(hdnWorkID.Value);
            obPrinterProof.WorkOrderID_I = Convert.ToInt32(((HiddenField)grdJobDetails.Rows[rowno].FindControl("hdWorkNumber")).Value);
             
            TextBox txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtTitleID");
            obPrinterProof.TitleID_I = int.Parse(txtGridTxt.Text);

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtCDProofLetterNo");
            obPrinterProof.CDProofLetterNo_V = txtGridTxt.Text;

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtCDProofLetterDate");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                try
                {
                    gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
                }
                catch
                {
                    gridTextValue = null;
                    IsProceed = "Invalid Date for \"Provide CD Proof \" in row number " + (rowno + 1).ToString();
                }
            }
            obPrinterProof.CDProofLetterDate_D = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtCDProofRetLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProof.CDProofRetLetterNo_V = gridTextValue;

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtCDProofRetLetterDate");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                try
                {
                    gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
                }
                catch
                {
                    gridTextValue = null;
                    IsProceed = "Invalid Date for \"Receive Proof \" in row number " + (rowno + 1).ToString();
                }
            }
            obPrinterProof.CDProofRetLetterDate_D = gridTextValue;

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtDepSendProofLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProof.DepSendProofLetterNo_V = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtDepSendProofLetterDate");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                try
                {
                    gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
                }
                catch
                {
                    gridTextValue = null;
                    IsProceed = "Invalid Date for \"Send Proof to RSK/TBC \" in row number " + (rowno + 1).ToString();
                }
            }
            obPrinterProof.DepSendProofLetterDate_D = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtProofAcceptLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProof.ProofAcceptLetterNo_V = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtProofAcceptLetterDate");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                try
                {
                    gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
                }
                catch
                {
                    gridTextValue = null;
                    IsProceed = "Invalid Date for \"Proof Aprooval \" in row number " + (rowno + 1).ToString();
                }
            }
            obPrinterProof.ProofAcceptLetterDate_D = gridTextValue;


            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtPrintOrderLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
             {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProof.PrintOrderLetterNo_V = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtPrintOrderLetterDate");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                try
                {
                    gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
                }
                catch
                {
                    gridTextValue = null;
                    IsProceed = "Invalid Date for \"Issue Print Order \" in row number " + (rowno + 1).ToString();
                }
            }
            obPrinterProof.PrintOrderLetterDate_D = gridTextValue;


            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtRetProofLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProof.RetProofLetterNo_V = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtRetProofLetterDate");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                try
                {
                    gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
                }
                catch
                {
                    gridTextValue = null;
                    IsProceed = "Invalid Date for \"Return of Printing Material\" in row number " + (rowno + 1).ToString();
                }
            }
            obPrinterProof.RetProofLetterDate_D = gridTextValue;

            if (IsProceed == "Success")
            {
                IsProceed = ValidateAllBoxes("txtCDProofLetterNo", "txtCDProofLetterDate", rowno, "Provide CD Proof ", "txtCDProofLetterDate", "CD Proof");
            }
            if (IsProceed == "Success")
            {
                IsProceed = ValidateAllBoxes("txtCDProofRetLetterNo", "txtCDProofRetLetterDate", rowno, "Recieve of Proof", "txtCDProofLetterDate", "Provide CD Proof");
            }
            if (IsProceed == "Success")
            {
                IsProceed = ValidateAllBoxes("txtDepSendProofLetterNo", "txtDepSendProofLetterDate", rowno, "Send Proof to RSK/TBC", "txtCDProofRetLetterDate", "Recieve of Proof");
            }
            if (IsProceed == "Success")
            {
                IsProceed = ValidateAllBoxes("txtProofAcceptLetterNo", "txtProofAcceptLetterDate", rowno, "Proof Aprooval", "txtDepSendProofLetterDate", "Send Proof to RSK/TBC");
            }
            if (IsProceed == "Success")
            {
                IsProceed = ValidateAllBoxes("txtPrintOrderLetterNo", "txtPrintOrderLetterDate", rowno, " Issue Print Order", "txtProofAcceptLetterDate", "Proof Aprooval");
            }
            if (IsProceed == "Success")
            {
                IsProceed = ValidateAllBoxes("txtRetProofLetterNo", "txtRetProofLetterDate", rowno, "Return of Printing Material", "txtPrintOrderLetterDate", " Issue Print Order");
            }

            if (IsProceed == "Success")
            {
                hdnPrinterProofID.Value = obPrinterProof.InsertUpdate().ToString();
            }
            else
            {

                IsSuccess = false;
                break;
            }
        }
        return IsSuccess;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bool IsSuccess = SaveValues();
        if (IsSuccess)
        {
            tblJobDetails.Visible = false;
            pnlJob.Visible = true;

            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record saved successfully";
        }
        else
        {
            mainDiv.CssClass = "form-message error";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = IsProceed;
        }
    }

    private string ValidateAllBoxes(string LetterNoTxtBox, string LetterDateTextBox, int RowNumber, string TxtBoxIsFor, string PreviousDateTxtBox, string PreviousTxtBoxIsFor)
    {
        string retVal = "Success";
        TextBox txtLetterNo = (TextBox)grdJobDetails.Rows[RowNumber].FindControl(LetterNoTxtBox);
        TextBox txtLetterDate = (TextBox)grdJobDetails.Rows[RowNumber].FindControl(LetterDateTextBox);
        TextBox txtPreviousDate = (TextBox)grdJobDetails.Rows[RowNumber].FindControl(PreviousDateTxtBox);
        DateTime PreviousDate = Convert.ToDateTime("1/1/1900");
        DateTime CurrentDate = Convert.ToDateTime("1/1/1900");
        try
        {
            PreviousDate = Convert.ToDateTime(txtPreviousDate.Text, cult);
        }
        catch
        {

        }
        try
        {
            CurrentDate = Convert.ToDateTime(txtLetterDate.Text, cult);
        }
        catch
        {

        }
        if ((txtLetterDate.Text != "" && txtLetterNo.Text != "") ||  (txtLetterDate.Text == "" && txtLetterNo.Text == ""))
        {
            if (txtLetterDate.Text != "" && txtPreviousDate.Text == "")
            {
                retVal = "Can not insert \"" + TxtBoxIsFor + "\" before \"" + PreviousTxtBoxIsFor + "\" in Row Number " + (RowNumber + 1).ToString();
            }
            else if (txtLetterDate.Text != "" && PreviousDate > CurrentDate)
            {
                retVal = "Date for \"" + TxtBoxIsFor + "\" can not be before \"" + PreviousTxtBoxIsFor + "\" in Row Number " + (RowNumber + 1).ToString();
            }
        }
        else
        {
            retVal = "Please enter both values for \"" + TxtBoxIsFor + "\" in Row Number " + (RowNumber + 1).ToString();
        }
        return retVal;
    }
    private void CreateTable()
    {
        Unit txtWidth = new Unit("70 px");
        Unit txtLetterNoWidth = new Unit("30 px");

        //obPrinterProof.QueryType = -1;
        //obPrinterProof.ParameterValue = int.Parse(hdnWorkID.Value);
        //obPrinterProof.ParameterValue2 = int.Parse(hdnPrinterID.Value);
        //DataSet dsJobTitles = obPrinterProof.Select();
        DataSet dsJobTitles = obCommonFunction.FillDatasetByProc("call USP_GetAcOrder(" + hdnPrinterID.Value + ",'"+DdlACYear.SelectedValue+"') ");
        grdJobDetails.DataSource = dsJobTitles;
        grdJobDetails.DataBind();
    }
    protected void GrdViewDetails_Rowcreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView GrdViewDetails = (GridView)sender;
            GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            TableHeaderCell HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "क्रमांक / S.No. ";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "कक्षा / Class";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "शीर्षक का नाम / Title";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "ग्रुप / Group";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "पाण्डुलिपि प्रदान /Provide CD Proof ";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = " प्रूफ प्राप्ति / Receive Proof";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "  RSK/TBC को प्रूफ भेजना / Send Proof to RSK/TBC";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "  प्रूफ अनुमोदन / Proof Aprooval";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = " मुद्रण आदेश जारी करना / Issue Print Order";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "मुद्रण सामाग्री की वापसी / Return of Printing Material";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.ColumnSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            HeaderCell = new TableHeaderCell();
            HeaderCell.Text = "अन्य विवरण / Other Details";
            HeaderCell.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell.RowSpan = 2;
            HeaderRow.Cells.Add(HeaderCell);

            GrdViewDetails.Controls[0].Controls.AddAt(0, HeaderRow);
        }
    }
    protected void GrdViewDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Visible = false;
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
            e.Row.Cells[16].Visible = false;
        }
    }
    protected void grdJobList_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        TextBox txtGrdId = (TextBox)grdJobList.Rows[e.NewEditIndex].FindControl("txtWorkOrderID");
        hdnWorkID.Value = txtGrdId.Text;

        txtGrdId = (TextBox)grdJobList.Rows[e.NewEditIndex].FindControl("txtPrinterName");
        lblPrinterName.Text = txtGrdId.Text;

        txtGrdId = (TextBox)grdJobList.Rows[e.NewEditIndex].FindControl("txtPrinterID");
        hdnPrinterID.Value = txtGrdId.Text;
         txtGrdId = (TextBox)grdJobList.Rows[e.NewEditIndex].FindControl("txtPrinterID");
         lblAgreementdate.Text = grdJobList.Rows[e.NewEditIndex].Cells[4].Text;
        
        lblJobCode.Text = grdJobList.Rows[e.NewEditIndex].Cells[1].Text;

        CreateTable();

        tblJobDetails.Visible = true;
        pnlJob.Visible = false;

    }

    protected void btnOtherInfo_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        tblJobDetails.Visible = false;
        pnlJob.Visible = true;
    }
    protected void btnSaveOtherDetails_Click(object sender, EventArgs e)
    {

        try
        {
            MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();

            obPrinterProof.WorkOrderID_I = int.Parse(hdnWorkID.Value);
            obPrinterProof.TitleID_I = int.Parse(hdnTitleID.Value);
            obPrinterProof.OtherDetailLetterNo_V = txtPopupLetterNo.Text;
            obPrinterProof.OtherDetailLetterDate_D = DateTime.Parse(txtPopupLetterDate.Text, cult).ToString("yyyy-MM-dd");
            obPrinterProof.StatusTrno_I = int.Parse(ddlStatus.SelectedValue);
            obPrinterProof.Remark_V = txtPopupRemark.Text;
            obPrinterProof.TransID = -1;

            string retValue = obPrinterProof.InsertUpdate().ToString();
            if (retValue == "-1")
            {
                if (SaveValues())
                {
                    obPrinterProof.InsertUpdate();
                    FillOtherDetailsGrid();
                }
                else
                {
                    Messages.Style.Add("display", "none");
                    fadeDiv.Style.Add("display", "none");
                    mainDiv.CssClass = "form-message error";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Please Correct the Problem- " + IsProceed;
                }
            }
            else
            {

                FillOtherDetailsGrid();
            }

            txtPopupRemark.Text = string.Empty;
            txtPopupLetterNo.Text = string.Empty;
            txtPopupLetterDate.Text = string.Empty;

            ///divOtherDetails.InnerHtml = obDis.SavePrintingProofOtherinfo(hdnTitleID.Value, hdnWorkID.Value, txtPopupLetterNo.Text, txtPopupLetterDate.Text, ddlStatus.SelectedValue, txtPopupRemark.Text);
            // = obDis.GetPrintingProofOtherinfo(hdnTitleID.Value, hdnWorkID.Value);
        }
        catch
        {
            pnlPopupMessage.CssClass = "form-message error";
            pnlPopupMessage.Style.Add("display", "block");
            lblPopupMessage.Text = "Record not saved due to duplicate entry !!";
        }


    }
    private void FillOtherDetailsGrid()
    {
        MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();
        obPrinterProof.QueryType = -3;
        obPrinterProof.ParameterValue = int.Parse(hdnTitleID.Value);
        obPrinterProof.ParameterValue2 = int.Parse(hdnWorkID.Value);

        DataSet dsOtherPrintProofDetails = obPrinterProof.Select();
        grdOtherDetails.DataSource = dsOtherPrintProofDetails;
        grdOtherDetails.DataBind();
    }
    protected void grdJobDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblPopupPrinterName.Text = lblPrinterName.Text;
        lblPopupTitle.Text = grdJobDetails.Rows[e.NewEditIndex].Cells[2].Text;
        TextBox txtTitleID = (TextBox)grdJobDetails.Rows[e.NewEditIndex].FindControl("txtTitleID");
        hdnTitleID.Value = txtTitleID.Text;
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            pnlPopupMessage.CssClass = "form-message error";
            pnlPopupMessage.Style.Add("display", "none");
            lblPopupMessage.Text = "";
            txtPopupRemark.Text = string.Empty;
            txtPopupLetterNo.Text = string.Empty;
            txtPopupLetterDate.Text = string.Empty;
            FillOtherDetailsGrid();
        }
        catch
        {
            pnlPopupMessage.CssClass = "form-message error";
            pnlPopupMessage.Style.Add("display", "block");
            lblPopupMessage.Text = "Record not saved for this title or Duplicate entry !!";

        }

    }

    protected void btnClosePopUp_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");

        fadeDiv.Style.Add("display", "none");
    }

    protected void grdOtherDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        MPTBCBussinessLayer.Academic.PrinterProof obPrinterProof = new MPTBCBussinessLayer.Academic.PrinterProof();
        Label txtPrinterProofTrNo = (Label)grdOtherDetails.Rows[e.RowIndex].FindControl("lblPrinterProofVerificationOtherDetailsTrno");
        obPrinterProof.PrinterProofVerificationOtherDetailsTrno_I = int.Parse(txtPrinterProofTrNo.Text);

        obPrinterProof.TransID = -2;
        try
        {
            obPrinterProof.InsertUpdate().ToString();
            FillOtherDetailsGrid();
            pnlPopupMessage.CssClass = "form-message success";
            pnlPopupMessage.Style.Add("display", "block");
            lblPopupMessage.Text = "Record deleted successfully !!";

        }
        catch
        {
            pnlPopupMessage.CssClass = "form-message error";
            pnlPopupMessage.Style.Add("display", "block");
            lblPopupMessage.Text = "Record can not deleted for this entry !!";

        }
    }

    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
        

    }
    public void BindTenderDDL()
    {
        ddlTender.DataSource = obCommonFunction.FillDatasetByProc("call USP_ACD005_PrinterProofSelectNew(8,0,0,'','" + DdlACYear.SelectedItem.Text + "','')");
        ddlTender.DataTextField = "TenderNo_V";
        ddlTender.DataValueField = "TenderNo_V";
        ddlTender.DataBind();
        ddlTender.Items.Insert(0, "All");
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        acyeara = DdlACYear.SelectedValue;
        FillJobGrid();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTenderDDL();
    }
    protected void BtnBack_Click(object sender, EventArgs e)
    {
        tblJobDetails.Visible = true;
        pnlJob.Visible = false;
    }
    protected void BtnBack_Click1(object sender, EventArgs e)
    {
        tblJobDetails.Visible = false;
        pnlJob.Visible = true;


      
    }
    protected void grdJobList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void grdJobList_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
}
