using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Globalization;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.DistributionB;
public partial class AcademicB_ViewPrinterProof : System.Web.UI.Page
{
   //MPTBCBussinessLayer.AcademicB.PrinterProof obPrinterProof = new MPTBCBussinessLayer.AcademicB.PrinterProof();
    CommonFuction obCommonFunction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration obPriReg = null;
    PrinterProofnew obPrinterProofnew = new PrinterProofnew();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";
        if (!IsPostBack)
        {
            FillCombo();
           
            try
            {
                obPriReg = new PRI_PrinterRegistration();

                ddlPrinter_regid_i.DataTextField = "NameofPress_V";
                ddlPrinter_regid_i.DataValueField = "Printer_RedID_I";

                ddlPrinter_regid_i.SelectedIndex = 0;
                //ddlPrinter.DataSource = obPriReg.PrinterRegistrationLoad();
                obCommonFunction = new CommonFuction();
                DataSet dd = obCommonFunction.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload_wo_wise(0,'2023-2024')");
                ddlPrinter_regid_i.DataSource = dd;
                ddlPrinter_regid_i.DataBind();


                ddlPrinter_regid_i.Items.Insert(0, new ListItem("All", "0"));
                ddlPrinter_regid_i.SelectedIndex = 0; 

            }
            catch { }
            FillJobGrid();
        }

        //if (Session["tblJobTitle"] == null)
        //{
        //  //  Response.Redirect("Login.aspx");
        //}
        //else
        //{

        //}
        //fadeDiv.Style.Add("display", "block");
    }

    private void FillCombo()
    {
        obPrinterProofnew.QueryType = -2;
        ddlStatus.DataSource = obPrinterProofnew.Select();
        ddlStatus.DataTextField = "Status_V";
        ddlStatus.DataValueField = "StatusMasterID_I";
        ddlStatus.DataBind();

    }


    private void FillJobGrid()
    {
        obPrinterProofnew.QueryType = 0;
        obPrinterProofnew.ParameterValue = Convert.ToInt32(ddlPrinter_regid_i.SelectedValue);
        grdJobList.DataSource = obPrinterProofnew.Select();
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
        //obPrinterProofnew = new MPTBCBussinessLayer.AcademicB.PrinterProof();
        obPrinterProofnew.TransID = 0;
        obPrinterProofnew.WorkOrderID_I = int.Parse(hdnWorkID.Value);
        bool IsSuccess = true;
        IsProceed = "Success";
        for (int rowno = 0; rowno < grdJobDetails.Rows.Count; rowno++)
        {
            string gridTextValue = string.Empty;

            TextBox txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtTitleID");
            obPrinterProofnew.TitleID_I = int.Parse(txtGridTxt.Text);

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtCDProofLetterNo");
            obPrinterProofnew.CDProofLetterNo_V = txtGridTxt.Text;

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




            obPrinterProofnew.CDProofLetterDate_D = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtCDProofRetLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProofnew.CDProofRetLetterNo_V = gridTextValue;

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
            obPrinterProofnew.CDProofRetLetterDate_D = gridTextValue;

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtDepSendProofLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProofnew.DepSendProofLetterNo_V = gridTextValue;
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
            obPrinterProofnew.DepSendProofLetterDate_D = gridTextValue;
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtProofAcceptLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProofnew.ProofAcceptLetterNo_V = gridTextValue;
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
            obPrinterProofnew.ProofAcceptLetterDate_D = gridTextValue;

            //////////////////////////

           
            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtProofAcceptLetterDate50");
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
            obPrinterProofnew.ProofAcceptLetterDate_D50 = gridTextValue;

            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtProofAcceptLetterDate100");
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
            obPrinterProofnew.ProofAcceptLetterDate_D100 = gridTextValue;


            ////////////////////////







            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtPrintOrderLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProofnew.PrintOrderLetterNo_V = gridTextValue;
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
            obPrinterProofnew.PrintOrderLetterDate_D = gridTextValue;


            txtGridTxt = (TextBox)grdJobDetails.Rows[rowno].FindControl("txtRetProofLetterNo");
            if (txtGridTxt.Text.Trim() == "")
            {
                gridTextValue = null;
            }
            else
            {
                gridTextValue = txtGridTxt.Text;
            }
            obPrinterProofnew.RetProofLetterNo_V = gridTextValue;
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
            obPrinterProofnew.RetProofLetterDate_D = gridTextValue;

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
                IsProceed = ValidateAllBoxes("txtProofAcceptLetterNo", "txtProofAcceptLetterDate", rowno, "Proof Aprooval", "txtDepSendProofLetterDate", "Send Proof to RMSA/RSK/TBC");
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
                hdnPrinterProofID.Value = obPrinterProofnew.InsertUpdate().ToString();
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
        if ((txtLetterDate.Text != "" && txtLetterNo.Text != "") ||
            (txtLetterDate.Text == "" && txtLetterNo.Text == ""))
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

    //protected void btnSave_Click1(object sender, EventArgs e)
    //{
    //    obPrinterProof.TransID = 0;
    //    obPrinterProof.WorkOrderID_I = int.Parse(hdnWorkID.Value);
    //    tblJobTitle = (Table)Session["tblJobTitle"];

    //    for (int rowno = 2; rowno < tblJobTitle.Rows.Count; rowno++)
    //    {
    //        string gridTextValue = string.Empty;

    //        string IDPrefix = hdnWorkID.Value + "-" + rowno.ToString();

    //        TextBox txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtTitleID" + IDPrefix);
    //        obPrinterProof.TitleID_I = int.Parse(txtGridTxt.Text);

    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtCDProofLetterNo" + IDPrefix);
    //        obPrinterProof.CDProofLetterNo_V = txtGridTxt.Text;

    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtCDProofLetterDate" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
    //            }
    //            catch
    //            {
    //                gridTextValue = null;
    //            }
    //        }
    //        obPrinterProof.CDProofLetterDate_D = gridTextValue;

    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtRetCDProofLetterNo" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            gridTextValue = txtGridTxt.Text;
    //        }
    //        obPrinterProof.CDProofRetLetterNo_V = gridTextValue;

    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtRetCDProofLetterDate" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
    //            }
    //            catch
    //            {
    //                gridTextValue = null;
    //            }
    //        }
    //        obPrinterProof.CDProofRetLetterDate_D = gridTextValue;

    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtDepLetterNo" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            gridTextValue = txtGridTxt.Text;
    //        }
    //        obPrinterProof.DepSendProofLetterNo_V = gridTextValue;
    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtDepLetterDate" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
    //            }
    //            catch
    //            {
    //                gridTextValue = null;
    //            }
    //        }
    //        obPrinterProof.DepSendProofLetterDate_D = gridTextValue;
    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtProofAcceptLetterNo" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            gridTextValue = txtGridTxt.Text;
    //        }
    //        obPrinterProof.ProofAcceptLetterNo_V = gridTextValue;
    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtProofAcceptLetterDate" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
    //            }
    //            catch
    //            {
    //                gridTextValue = null;
    //            }
    //        }
    //        obPrinterProof.ProofAcceptLetterDate_D = gridTextValue;


    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtPrintorderLetterNo" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            gridTextValue = txtGridTxt.Text;
    //        }
    //        obPrinterProof.PrintOrderLetterNo_V = gridTextValue;
    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtPrintorderLetterDate" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
    //            }
    //            catch
    //            {
    //                gridTextValue = null;
    //            }
    //        }
    //        obPrinterProof.PrintOrderLetterDate_D = gridTextValue;


    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtRetProofLetterNo" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            gridTextValue = txtGridTxt.Text;
    //        }
    //        obPrinterProof.RetProofLetterNo_V = gridTextValue;
    //        txtGridTxt = (TextBox)tblJobTitle.Rows[rowno].FindControl("txtRetProofLetterDate" + IDPrefix);
    //        if (txtGridTxt.Text.Trim() == "")
    //        {
    //            gridTextValue = null;
    //        }
    //        else
    //        {
    //            try
    //            {
    //                gridTextValue = DateTime.Parse(txtGridTxt.Text, cult).ToString("yyyy-MM-dd");
    //            }
    //            catch
    //            {
    //                gridTextValue = null;
    //            }
    //        }
    //        obPrinterProof.RetProofLetterDate_D = gridTextValue;


    //        hdnPrinterProofID.Value = obPrinterProof.InsertUpdate().ToString();

    //    }

    //    tblJobDetails.Visible = false;
    //    pnlJob.Visible = true;

    //    mainDiv.CssClass = "form-message success";
    //    mainDiv.Style.Add("display", "block");
    //    lblmsg.Text = "Record saved successfully";
    //}

    private void CreateTable()
    {
        Unit txtWidth = new Unit("70 px");
        Unit txtLetterNoWidth = new Unit("30 px");

        obPrinterProofnew.QueryType = -1;
        obPrinterProofnew.ParameterValue = int.Parse(hdnWorkID.Value);
        obPrinterProofnew.ParameterValue2 = int.Parse(hdnPrinterID.Value);
        DataSet dsJobTitles = obPrinterProofnew.Select();
        grdJobDetails.DataSource = dsJobTitles;
        grdJobDetails.DataBind();
    }
    private void CreateTable1()
    {


        //tblJobTitle.Rows.Clear();
        //Unit txtWidth = new Unit("65 px");
        //Unit txtLetterNoWidth = new Unit("30 px");

        //obPrinterProof.QueryType = -1;
        //obPrinterProof.ParameterValue = int.Parse(hdnWorkID.Value);
        //obPrinterProof.ParameterValue2 = int.Parse(hdnPrinterID.Value);
        //DataSet dsJobTitles = obPrinterProof.Select();

        //#region HeaderRow
        //TableRow trNewRow = new TableRow();
        //TableHeaderCell thCell = new TableHeaderCell();

        //thCell.Text = " कक्षा";
        //thCell.RowSpan = 2;
        //thCell.Visible = false;
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " शीर्षक का नाम";
        //thCell.RowSpan = 2;
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = "  ग्रुप";
        //thCell.RowSpan = 2;
        //trNewRow.Cells.Add(thCell);



        //thCell = new TableHeaderCell();
        //thCell.Text = "  पाण्डुलिपि प्रदान ";
        //thCell.ColumnSpan = 2;
        //trNewRow.Cells.Add(thCell);
        //thCell = new TableHeaderCell();
        //thCell.Text = " प्रूफ प्राप्ति";
        //thCell.ColumnSpan = 2;
        //trNewRow.Cells.Add(thCell);
        //thCell = new TableHeaderCell();
        //thCell.Text = "  RSK/TBC को प्रूफ भेजना";
        //thCell.ColumnSpan = 2;
        //trNewRow.Cells.Add(thCell);
        //thCell = new TableHeaderCell();
        //thCell.Text = "  प्रूफ अनुमोदन";
        //thCell.ColumnSpan = 2;
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " मुद्रण आदेश जारी करना";
        //thCell.ColumnSpan = 2;
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = "मुद्रण सामाग्री की वापसी";
        //thCell.ColumnSpan = 2;

        //trNewRow.Cells.Add(thCell);



        //thCell = new TableHeaderCell();
        //thCell.Text = "  अन्य विवरण";
        //thCell.RowSpan = 2;
        //thCell.Width = txtLetterNoWidth;
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = "  titleID";
        //thCell.Visible = false;
        //thCell.RowSpan = 2;
        //trNewRow.Cells.Add(thCell);

        //tblJobTitle.Rows.Add(trNewRow);

        //trNewRow = new TableRow();
        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र क्रमांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र दिनांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र क्रमांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र दिनांक";
        //trNewRow.Cells.Add(thCell);
        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र क्रमांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र दिनांक";
        //trNewRow.Cells.Add(thCell);
        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र क्रमांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र दिनांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र क्रमांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र दिनांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र क्रमांक";
        //trNewRow.Cells.Add(thCell);

        //thCell = new TableHeaderCell();
        //thCell.Text = " पत्र दिनांक";
        //trNewRow.Cells.Add(thCell);

        //tblJobTitle.Rows.Add(trNewRow);
        //#endregion
        //if (dsJobTitles.Tables[0] != null && dsJobTitles.Tables[0].Rows.Count > 0)
        //{
        //    #region Row Creation
        //    for (int titlecount = 0; titlecount < dsJobTitles.Tables[0].Rows.Count; titlecount++)
        //    {
        //        trNewRow = new TableRow();
        //        TableCell tcCell = new TableCell();
        //        TextBox txtCellText = new TextBox();
        //        AjaxControlToolkit.MaskedEditExtender meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        AjaxControlToolkit.CalendarExtender cleGridTextDate = new AjaxControlToolkit.CalendarExtender();

        //        string IDPrefix = hdnWorkID.Value + "-" + (titlecount + 2).ToString();
        //        tcCell.Visible = false;
        //        tcCell.Text = "No Class"; // dsJobTitles.Tables[0].Rows[titlecount]["Classdet_V"].ToString();

        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        tcCell.Text = dsJobTitles.Tables[0].Rows[titlecount]["TitleHindi_V"].ToString();

        //        DateTime tmpDateValue;

        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        tcCell.Text = dsJobTitles.Tables[0].Rows[titlecount]["groupno_V"].ToString();
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtCDProofLetterNo" + IDPrefix;
        //        txtCellText.MaxLength = 4;

        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["CDProofLetterNo_V"].ToString();
        //        txtCellText.Width = txtLetterNoWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtCDProofLetterDate" + IDPrefix;
        //        txtCellText.MaxLength = 10;

        //        try
        //        {
        //            txtCellText.Text = DateTime.Parse(dsJobTitles.Tables[0].Rows[titlecount]["CDProofLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {

        //            txtCellText.Text = "";
        //        }


        //        if (dsJobTitles.Tables[0].Rows[titlecount]["CDProofLetterDate_D"].ToString() != null)
        //        {
        //            DateTime.TryParse(dsJobTitles.Tables[0].Rows[titlecount]["CDProofLetterDate_D"].ToString(), out tmpDateValue);

        //        }
        //        else
        //        {
        //            txtCellText.Text = string.Empty;
        //        }
        //        txtCellText.Width = txtWidth;

        //        meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        cleGridTextDate = new AjaxControlToolkit.CalendarExtender();
        //        meeGridTextDateMask.ID = "mee" + txtCellText.ID;
        //        meeGridTextDateMask.Mask = "99/99/9999";
        //        meeGridTextDateMask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
        //        meeGridTextDateMask.TargetControlID = txtCellText.ID;
        //        cleGridTextDate.ID = "cle" + txtCellText.ID;
        //        cleGridTextDate.Format = "dd/MM/yyyy";
        //        cleGridTextDate.TargetControlID = txtCellText.ID;

        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Controls.Add(meeGridTextDateMask);
        //        tcCell.Controls.Add(cleGridTextDate);

        //        trNewRow.Cells.Add(tcCell);



        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtRetCDProofLetterNo" + IDPrefix;
        //        txtCellText.MaxLength = 4;
        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["CDProofRetLetterNo_V"].ToString();
        //        txtCellText.Width = txtLetterNoWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        trNewRow.Cells.Add(tcCell);



        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtRetCDProofLetterDate" + IDPrefix;
        //        txtCellText.MaxLength = 10;
        //        try
        //        {
        //            txtCellText.Text = DateTime.Parse(dsJobTitles.Tables[0].Rows[titlecount]["CDProofRetLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {

        //            txtCellText.Text = "";
        //        }

        //        txtCellText.Width = txtWidth;


        //        meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        cleGridTextDate = new AjaxControlToolkit.CalendarExtender();
        //        meeGridTextDateMask.ID = "mee" + txtCellText.ID;
        //        meeGridTextDateMask.Mask = "99/99/9999";
        //        meeGridTextDateMask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
        //        meeGridTextDateMask.TargetControlID = txtCellText.ID;
        //        cleGridTextDate.ID = "cle" + txtCellText.ID;
        //        cleGridTextDate.Format = "dd/MM/yyyy";
        //        cleGridTextDate.TargetControlID = txtCellText.ID;

        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Controls.Add(meeGridTextDateMask);
        //        tcCell.Controls.Add(cleGridTextDate);

        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtDepLetterNo" + IDPrefix;
        //        txtCellText.MaxLength = 4;
        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["DepSendProofLetterNo_V"].ToString();
        //        txtCellText.Width = txtLetterNoWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtDepLetterDate" + IDPrefix;
        //        txtCellText.MaxLength = 10;
        //        try
        //        {
        //            txtCellText.Text = DateTime.Parse(dsJobTitles.Tables[0].Rows[titlecount]["DepSendProofLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {

        //            txtCellText.Text = "";
        //        }

        //        txtCellText.Width = txtWidth;

        //        meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        cleGridTextDate = new AjaxControlToolkit.CalendarExtender();
        //        meeGridTextDateMask.ID = "mee" + txtCellText.ID;
        //        meeGridTextDateMask.Mask = "99/99/9999";
        //        meeGridTextDateMask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
        //        meeGridTextDateMask.TargetControlID = txtCellText.ID;
        //        cleGridTextDate.ID = "cle" + txtCellText.ID;
        //        cleGridTextDate.Format = "dd/MM/yyyy";
        //        cleGridTextDate.TargetControlID = txtCellText.ID;

        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Controls.Add(meeGridTextDateMask);
        //        tcCell.Controls.Add(cleGridTextDate);

        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtProofAcceptLetterNo" + IDPrefix;
        //        txtCellText.MaxLength = 4;
        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["ProofAcceptLetterNo_V"].ToString();
        //        txtCellText.Width = txtLetterNoWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtProofAcceptLetterDate" + IDPrefix;
        //        txtCellText.MaxLength = 10;

        //        try
        //        {
        //            txtCellText.Text = DateTime.Parse(dsJobTitles.Tables[0].Rows[titlecount]["ProofAcceptLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {

        //            txtCellText.Text = "";
        //        }
        //        txtCellText.Width = txtWidth;

        //        meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        cleGridTextDate = new AjaxControlToolkit.CalendarExtender();
        //        meeGridTextDateMask.ID = "mee" + txtCellText.ID;
        //        meeGridTextDateMask.Mask = "99/99/9999";
        //        meeGridTextDateMask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
        //        meeGridTextDateMask.TargetControlID = txtCellText.ID;
        //        cleGridTextDate.ID = "cle" + txtCellText.ID;
        //        cleGridTextDate.Format = "dd/MM/yyyy";
        //        cleGridTextDate.TargetControlID = txtCellText.ID;

        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Controls.Add(meeGridTextDateMask);
        //        tcCell.Controls.Add(cleGridTextDate);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtPrintorderLetterNo" + IDPrefix;
        //        txtCellText.MaxLength = 4;
        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["PrintOrderLetterNo_V"].ToString();
        //        txtCellText.Width = txtLetterNoWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtPrintorderLetterDate" + IDPrefix;
        //        txtCellText.MaxLength = 10;

        //        try
        //        {
        //            txtCellText.Text = DateTime.Parse(dsJobTitles.Tables[0].Rows[titlecount]["PrintOrderLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {

        //            txtCellText.Text = "";
        //        }

        //        txtCellText.Width = txtWidth;
        //        meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        cleGridTextDate = new AjaxControlToolkit.CalendarExtender();
        //        meeGridTextDateMask.ID = "mee" + txtCellText.ID;
        //        meeGridTextDateMask.Mask = "99/99/9999";
        //        meeGridTextDateMask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
        //        meeGridTextDateMask.TargetControlID = txtCellText.ID;
        //        cleGridTextDate.ID = "cle" + txtCellText.ID;
        //        cleGridTextDate.Format = "dd/MM/yyyy";
        //        cleGridTextDate.TargetControlID = txtCellText.ID;

        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Controls.Add(meeGridTextDateMask);
        //        tcCell.Controls.Add(cleGridTextDate);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtRetProofLetterNo" + IDPrefix;
        //        txtCellText.MaxLength = 4;
        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["RetProofLetterNo_V"].ToString();
        //        txtCellText.Width = txtLetterNoWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtRetProofLetterDate" + IDPrefix;
        //        txtCellText.MaxLength = 10;

        //        try
        //        {
        //            txtCellText.Text = DateTime.Parse(dsJobTitles.Tables[0].Rows[titlecount]["RetProofLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
        //        }
        //        catch
        //        {

        //            txtCellText.Text = "";
        //        }

        //        txtCellText.Width = txtWidth;
        //        meeGridTextDateMask = new AjaxControlToolkit.MaskedEditExtender();
        //        cleGridTextDate = new AjaxControlToolkit.CalendarExtender();
        //        meeGridTextDateMask.ID = "mee" + txtCellText.ID;
        //        meeGridTextDateMask.Mask = "99/99/9999";
        //        meeGridTextDateMask.MaskType = AjaxControlToolkit.MaskedEditType.Date;
        //        meeGridTextDateMask.TargetControlID = txtCellText.ID;
        //        cleGridTextDate.ID = "cle" + txtCellText.ID;
        //        cleGridTextDate.Format = "dd/MM/yyyy";
        //        cleGridTextDate.TargetControlID = txtCellText.ID;

        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Controls.Add(meeGridTextDateMask);
        //        tcCell.Controls.Add(cleGridTextDate);
        //        trNewRow.Cells.Add(tcCell);



        //        tcCell = new TableCell();
        //        Button btnOtherInfo = new Button();

        //        btnOtherInfo.Text = "विवरण ";
        //        btnOtherInfo.EnableViewState = true;
        //        btnOtherInfo.CssClass = "btn";
        //        btnOtherInfo.Width = new Unit("60 px");
        //        btnOtherInfo.ID = "btnOtherInfo" + IDPrefix + "__" + dsJobTitles.Tables[0].Rows[titlecount]["SubTitleID_I"].ToString() + "__" +
        //                 dsJobTitles.Tables[0].Rows[titlecount]["TitleHindi_V"].ToString();
        //        //  btnOtherInfo.Click += new EventHandler(btnOtherInfo_Click);
        //        btnOtherInfo.OnClientClick = "javascript: return ShowPopup(this);";
        //        tcCell.Controls.Add(btnOtherInfo);
        //        trNewRow.Cells.Add(tcCell);

        //        tcCell = new TableCell();
        //        txtCellText = new TextBox();
        //        txtCellText.ID = "txtTitleID" + IDPrefix;
        //        txtCellText.Visible = false;
        //        txtCellText.Text = dsJobTitles.Tables[0].Rows[titlecount]["SubTitleID_I"].ToString();
        //        txtCellText.Width = txtWidth;
        //        tcCell.Controls.Add(txtCellText);
        //        tcCell.Visible = false;
        //        trNewRow.Cells.Add(tcCell);

        //        tblJobTitle.Rows.Add(trNewRow);
        //    }

        //    #endregion
        //}

        //Session["tblJobTitle"] = tblJobTitle;
        //pnlJobTitles.Controls.Remove(tblJobTitle);
        //pnlJobTitles.Controls.Add(tblJobTitle);

        //tblJobDetails.Visible = true;
        //pnlJob.Visible = false;
    }
    protected void grdJobDetails_RowCreated(object sender, GridViewRowEventArgs e)
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
            HeaderCell.Visible = false;
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
            HeaderCell.Text = " RMSA RSK/TBC को प्रूफ भेजना / Send Proof to RMSA/RSK/TBC";
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
    protected void grdJobDetails_RowDataBound(object sender, GridViewRowEventArgs e)
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
            MPTBCBussinessLayer.AcademicB.PrinterProof obPrinterProof = new MPTBCBussinessLayer.AcademicB.PrinterProof();
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
        Label txtPrinterProofTrNo = (Label)grdOtherDetails.Rows[e.RowIndex].FindControl("lblPrinterProofVerificationOtherDetailsTrno");
        obPrinterProofnew.PrinterProofVerificationOtherDetailsTrno_I = int.Parse(txtPrinterProofTrNo.Text);

        obPrinterProofnew.TransID = -2;
        try
        {
            obPrinterProofnew.InsertUpdate().ToString();
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
    protected void ddlPrinter_regid_i_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillJobGrid();
        }
        catch { }
    }


    public class PrinterProofnew
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public string StringParameter { get; set; }

        public int PrinterProofVerificationTrno_I { get; set; }
        public int WorkOrderID_I { get; set; }
        public int TitleID_I { get; set; }
        public string CDProofLetterNo_V { get; set; }
        public string CDProofLetterDate_D { get; set; }
        public string CDProofRetLetterNo_V { get; set; }
        public string CDProofRetLetterDate_D { get; set; }
        public string DepSendProofLetterNo_V { get; set; }
        public string DepSendProofLetterDate_D { get; set; }
        public string ProofAcceptLetterNo_V { get; set; }
        public string ProofAcceptLetterDate_D { get; set; }



        public string PrintOrderLetterNo_V { get; set; }
        public string PrintOrderLetterDate_D { get; set; }
        public string RetProofLetterNo_V { get; set; }
        public string RetProofLetterDate_D { get; set; }

        public int Printer_RedID_I { get; set; }

        public int PrinterProofVerificationOtherDetailsTrno_I { get; set; }
        public int StatusTrno_I { get; set; }
        public string Remark_V { get; set; }
        public string OtherDetailLetterNo_V { get; set; }
        public string OtherDetailLetterDate_D { get; set; }

        public int TransID { get; set; }
        public string ProofAcceptLetterDate_D50 { get; set; }
        public string ProofAcceptLetterDate_D100 { get; set; }
        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB008_PrinterProofSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterProofVerificationTrno_I", PrinterProofVerificationTrno_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mCDProofLetterNo_V", CDProofLetterNo_V);
            obDBAccess.addParam("mCDProofLetterDate_D", CDProofLetterDate_D);
            obDBAccess.addParam("mCDProofRetLetterNo_V", CDProofRetLetterNo_V);
            obDBAccess.addParam("mCDProofRetLetterDate_D", CDProofRetLetterDate_D);
            obDBAccess.addParam("mDepSendProofLetterNo_V", DepSendProofLetterNo_V);
            obDBAccess.addParam("mDepSendProofLetterDate_D", DepSendProofLetterDate_D);
            obDBAccess.addParam("mProofAcceptLetterNo_V", ProofAcceptLetterNo_V);
            obDBAccess.addParam("mProofAcceptLetterDate_D", ProofAcceptLetterDate_D);

            obDBAccess.addParam("mPrintOrderLetterNo_V", PrintOrderLetterNo_V);
            obDBAccess.addParam("mPrintOrderLetterDate_D", PrintOrderLetterDate_D);
            obDBAccess.addParam("mRetProofLetterNo_V", RetProofLetterNo_V);
            obDBAccess.addParam("mRetProofLetterDate_D", RetProofLetterDate_D);

            obDBAccess.addParam("mPrinterProofVerificationOtherDetailsTrno_I", PrinterProofVerificationOtherDetailsTrno_I);
            obDBAccess.addParam("mStatusTrno_I", StatusTrno_I);
            obDBAccess.addParam("mOtherDetailLetterNo_V", OtherDetailLetterNo_V);
            obDBAccess.addParam("mOtherDetailLetterDate_D", OtherDetailLetterDate_D);
            obDBAccess.addParam("mRemark_V", Remark_V);



            obDBAccess.addParam("mTransID", TransID);
            obDBAccess.addParam("mProofAcceptLetterDate_D50", ProofAcceptLetterDate_D50);
            obDBAccess.addParam("mProofAcceptLetterDate_D100", ProofAcceptLetterDate_D100);

            object result = obDBAccess.executeMyScalar();
            if (result != null)
            {
                return int.Parse(result.ToString());
            }
            else if (result == null && TransID == -1)
                return -1;
            else
                return 0;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB008_PrinterProofSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mStringParameter", StringParameter);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            return obDBAccess.records();
        }
        public DataSet FillRPT()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD005_PrinterProofLoadRPT", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion



    }
    

}
