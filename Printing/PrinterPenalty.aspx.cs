using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_PrinterPenalty : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterPenalty obPRI_PrinterPenalty = null;
    CommonFuction obCommonFuction = null;
    APIProcedure objApi = new APIProcedure();
    Pri_BillDetails_New objBillDetails = null;
    int? BookID = null;
    Decimal? PrintingChr100per = null, Substandardbadprintingper = null, BadPrintingAmount = null, PrintMistakPer = null,
           MistakeAmount = null, Delay_proof = null, Perofpenalty_proof = null, TotPerofpenalty_proof = null,
           AmountofPenalty_proof = null, Delay_Supply = null, TotPerofpenalty_Supply = null, AmountofPenalty_Supply = null;
    DateTime? DateofRecMssDesign = null, DateofProofSubmission = null, Supp_DueDate = null, RecDate = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtBadPrintingAmount_N.ReadOnly = true;
            txtMistakeAmount_N.ReadOnly = true;
            txtDelay_proof_N.ReadOnly = true;
            txtTotPerofpenalty_proof_N.ReadOnly = true;
            txtAmountofPenalty_proof_N.ReadOnly = true;
            txtDelay_Supply_N.ReadOnly = true;
            //DDlFill();
            //FillJobCodeDDl();
            txtChalanrecDate.Text = "11-04-2017";
            PrinterFill();
            FillAcademicYr();
            if (Request.QueryString["ID"] != null)
            {
                showdata();
            }
        }
    }

    private void FillAcademicYr()
    {
        try
        {
            obCommonFuction = new CommonFuction();
            ddlJobCode.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlJobCode.DataValueField = "AcYear";
            ddlJobCode.DataTextField = "AcYear";
            ddlJobCode.DataBind();
            ddlJobCode.SelectedValue = obCommonFuction.GetFinYear();
            ddlJobCode.Enabled = false;
        }
        catch { }
        finally { obCommonFuction = null; }
    }


    public void FillJobCodeDDl()
    {
        ddlJobCode.DataTextField = "jobcode_v";
        ddlJobCode.DataValueField = "workorderid_i";

        ddlJobCode.DataSource = LoadJobCodeDetail(0);
        ddlJobCode.DataBind();

        ddlJobCode.Items.Insert(0, new ListItem("Select", "0"));

    }



    // function to load all details based on Job code
    public DataSet LoadJobCodeDetail(int ID)
    {
        obPRI_PrinterPenalty = new PRI_PrinterPenalty();
        DataSet ds = new DataSet();

        try
        {
            obPRI_PrinterPenalty.workorderid_i = ID;
            ds = obPRI_PrinterPenalty.FillJobCodeDetail();


        }
        catch (Exception ex) { }
        finally { obPRI_PrinterPenalty = null; }
        return ds;

    }

    public void DDlFill()
    {
        try
        {
            obPRI_PrinterPenalty = new PRI_PrinterPenalty();
            ddlPrinterID_I.DataSource = obPRI_PrinterPenalty.PrinterAlldetails(0, 0, 0);
            ddlPrinterID_I.DataTextField = "NameofPress_V";
            ddlPrinterID_I.DataValueField = "Printer_RedID_I";
            ddlPrinterID_I.DataBind();
            ddlPrinterID_I.Items.Insert(0, new ListItem("Select", "0"));
            //if (Request.QueryString["ID"] != null)
            //{
            //    showdata(Request.QueryString[ID]);
            //}

        }
        catch { }
        finally { obPRI_PrinterPenalty = null; }

    }

    public void PrinterFill()
    {
        objBillDetails = new Pri_BillDetails_New();
        ddlPrinterID_I.DataSource = objBillDetails.PrinterDetailsFill();
        ddlPrinterID_I.DataValueField = "Printer_RedID_I";
        ddlPrinterID_I.DataTextField = "NameofPress_V";
        ddlPrinterID_I.DataBind();
        ddlPrinterID_I.Items.Insert(0, "Select");

    }



    protected void btnSave_Click(object sender, EventArgs e)
    {

        //if (ddlBookID_I.SelectedValue != "0" && ddlBookID_I.SelectedValue!="सेलेक्ट..")
        //{
        //    BookID = Convert.ToInt32(ddlBookID_I.SelectedValue);
        //}
        if (txtPrintingChr100per_N.Text != "")
        {
            PrintingChr100per = Convert.ToDecimal(txtPrintingChr100per_N.Text);
        }
        if (txtSubstandardbadprintingper_N.Text != "")
        {
            Substandardbadprintingper = Convert.ToDecimal(txtSubstandardbadprintingper_N.Text);
        }
        if (txtBadPrintingAmount_N.Text != "")
        {
            BadPrintingAmount = Convert.ToDecimal(txtBadPrintingAmount_N.Text);
        }
        if (txtPrintMistakPer_N.Text != "")
        {
            PrintMistakPer = Convert.ToDecimal(txtPrintMistakPer_N.Text);
        }
        if (txtMistakeAmount_N.Text != "")
        {
            MistakeAmount = Convert.ToDecimal(txtMistakeAmount_N.Text);
        }
        if (txtDateofRecMssDesign_D.Text != "")
        {
            DateofRecMssDesign = Convert.ToDateTime(txtDateofRecMssDesign_D.Text, cult);
        }
        if (txtDateofProofSubmission_D.Text != "")
        {
            DateofProofSubmission = Convert.ToDateTime(txtDateofProofSubmission_D.Text, cult);
        }
        if (txtDelay_proof_N.Text != "")
        {
            Delay_proof = Convert.ToDecimal(txtDelay_proof_N.Text);
        }
        if (txtPerofpenalty_proof_N.Text != "")
        {
            Perofpenalty_proof = Convert.ToDecimal(txtPerofpenalty_proof_N.Text);
        }
        if (txtTotPerofpenalty_proof_N.Text != "")
        {
            TotPerofpenalty_proof = Convert.ToDecimal(txtTotPerofpenalty_proof_N.Text);
        }
        if (txtAmountofPenalty_proof_N.Text != "")
        {
            AmountofPenalty_proof = Convert.ToDecimal(txtAmountofPenalty_proof_N.Text);
        }
        if (txtSupp_DueDate_D.Text != "")
        {
            Supp_DueDate = Convert.ToDateTime(txtSupp_DueDate_D.Text, cult);
        }
        if (txtRecDate_D.Text != "")
        {
            RecDate = Convert.ToDateTime(txtRecDate_D.Text, cult);
        }
        if (txtDelay_Supply_N.Text != "")
        {
            Delay_Supply = Convert.ToDecimal(txtDelay_Supply_N.Text);
        }
        if (txtTotPerofpenalty_Supply_N.Text != "")
        {
            TotPerofpenalty_Supply = Convert.ToDecimal(txtTotPerofpenalty_Supply_N.Text);
        }
        if (txtAmountofPenalty_Supply_N.Text != "")
        {
            AmountofPenalty_Supply = Convert.ToDecimal(txtAmountofPenalty_Supply_N.Text);
        }

        DateTime? ChalanrecDate = null;
        if (txtChalanrecDate.Text != "")
        {
            ChalanrecDate = Convert.ToDateTime(txtChalanrecDate.Text, cult);
        }

        //check for penalty already exists
        if (Request.QueryString["ID"] != null)
        {
            if (Convert.ToDateTime(txtChalanrecDate.Text, cult) == Convert.ToDateTime(HfChallanDate.Value, cult))
            {
                string isok = "";
            }
            else
            {
                objBillDetails = new Pri_BillDetails_New();
                objBillDetails.Type_ID = 12;
                objBillDetails.Printer_RedID_I = int.Parse(ddlPrinterID_I.SelectedItem.Value.ToString());
                objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                objBillDetails.BillDate_D = DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);
                objBillDetails.mAcyear = ddlJobCode.SelectedValue;
                objBillDetails.BillID_I = int.Parse(ddlBookID_I.SelectedValue);
                //if only one record exist then update record
                if (lblCount.Text == "1")
                {
                    DataSet ds = objBillDetails.BillChildDetailsFillnew();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtPrintingChr100per_N.Text = ds.Tables[0].Rows[0]["Amount_N"].ToString();
                        HDNPriTransID.Value = ds.Tables[0].Rows[0]["PriTransID"].ToString();

                        txtSubstandardbadprintingper_N_TextChanged(null, null);
                        txtPrintMistakPer_N_TextChanged(null, null);
                        txtDateofProofSubmission_D_TextChanged(null, null);
                        txtPerofpenalty_proof_N_TextChanged(null, null);
                    }
                    else
                    {
                        HDNAlready.Value = "ok";
                    }
                }
                else
                {
                    //for more than one record get last challan date
                    if (lblLastMaxChallanDate.Text != "")
                    {
                        objBillDetails.BillDate_D = Convert.ToDateTime(lblLastMaxChallanDate.Text).AddDays(1);
                        if (Convert.ToDateTime(lblLastMaxChallanDate.Text) >= Convert.ToDateTime(txtChalanrecDate.Text))
                        {
                            HDNAlready.Value = "ok";
                        }
                        else if (Convert.ToDateTime(lblMaxChallanDate.Text) >= Convert.ToDateTime(txtChalanrecDate.Text))
                        {
                            HDNAlready.Value = "ok";
                        }
                        else if (Convert.ToDateTime(txtChalanrecDate.Text) > Convert.ToDateTime(lblMaxChallanDate.Text))  //dont update when Challan Date > Max challan date
                        {
                            HDNAlready.Value = "ok";
                        }
                        else
                        {
                            objBillDetails.Type_ID = 14;
                            objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                            DataSet ds = objBillDetails.BillChildDetailsFillnew();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                txtPrintingChr100per_N.Text = ds.Tables[0].Rows[0]["Amount_N"].ToString();
                                HDNPriTransID.Value = ds.Tables[0].Rows[0]["PriTransID"].ToString();

                                txtSubstandardbadprintingper_N_TextChanged(null, null);
                                txtPrintMistakPer_N_TextChanged(null, null);
                                txtDateofProofSubmission_D_TextChanged(null, null);
                                txtPerofpenalty_proof_N_TextChanged(null, null);
                            }
                            else
                            {
                                HDNAlready.Value = "ok";
                            }
                        }


                    }
                }

                if (HDNAlready.Value == "ok")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Penalty already exists.');</script>");
                    return;
                }
            }

        }

        Session["PenaltyID_I"] = 0;
        try
        {
            //obPRI_PrinterPenalty = new PRI_PrinterPenalty();            
            PRI_PrinterPenalty_New obPRI_PrinterPenalty11 = new PRI_PrinterPenalty_New();

            obPRI_PrinterPenalty11.PrinterID_I = Convert.ToInt32(ddlPrinterID_I.SelectedValue);
            //obPRI_PrinterPenalty.GRPID_I                     = Convert.ToInt32(ddlGRPID_I.SelectedValue);

            obPRI_PrinterPenalty11.BookID_I = Convert.ToInt32(ddlBookID_I.SelectedValue);
            obPRI_PrinterPenalty11.PrintingChr100per_N = Convert.ToDecimal(PrintingChr100per);
            obPRI_PrinterPenalty11.Substandardbadprintingper_N = Convert.ToDecimal(Substandardbadprintingper);
            obPRI_PrinterPenalty11.BadPrintingAmount_N = Convert.ToDecimal(BadPrintingAmount);
            obPRI_PrinterPenalty11.PrintMistakPer_N = Convert.ToDecimal(PrintMistakPer);
            obPRI_PrinterPenalty11.MistakeAmount_N = Convert.ToDecimal(MistakeAmount);
            obPRI_PrinterPenalty11.DateofRecMssDesign_D = Convert.ToDateTime(DateofRecMssDesign);
            obPRI_PrinterPenalty11.DateofProofSubmission_D = Convert.ToDateTime(DateofProofSubmission);
            obPRI_PrinterPenalty11.Delay_proof_N = Convert.ToDecimal(Delay_proof);
            obPRI_PrinterPenalty11.Perofpenalty_proof_N = Convert.ToDecimal(Perofpenalty_proof);
            obPRI_PrinterPenalty11.TotPerofpenalty_proof_N = Convert.ToDecimal(TotPerofpenalty_proof);
            obPRI_PrinterPenalty11.AmountofPenalty_proof_N = Convert.ToDecimal(AmountofPenalty_proof);
            obPRI_PrinterPenalty11.Supp_DueDate_D = Convert.ToDateTime(Supp_DueDate);
            obPRI_PrinterPenalty11.RecDate_D = Convert.ToDateTime(RecDate);
            obPRI_PrinterPenalty11.Delay_Supply_N = Convert.ToDecimal(Delay_Supply);
            obPRI_PrinterPenalty11.TotPerofpenalty_Supply_N = Convert.ToDecimal(TotPerofpenalty_Supply);
            obPRI_PrinterPenalty11.AmountofPenalty_Supply_N = Convert.ToDecimal(AmountofPenalty_Supply);
            obPRI_PrinterPenalty11.Transdate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            obPRI_PrinterPenalty11.JobCode_V = Convert.ToString(ddlJobCode.SelectedValue);
            obPRI_PrinterPenalty11.PriTransID = Convert.ToString(HDNPriTransID.Value);
            obPRI_PrinterPenalty11.UptoChallandate_D = Convert.ToDateTime(ChalanrecDate);

            obPRI_PrinterPenalty11.PenaltyID_I = 0;

            if (Request.QueryString["ID"] != null)
            {
                obPRI_PrinterPenalty11.PenaltyID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString());
            }
            obPRI_PrinterPenalty11.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);
            HiddenField1.Value = "";
        }
        catch { }
        finally
        {
            obPRI_PrinterPenalty = null;
        }

        Response.Redirect("VIEW_PrinterPenalty.aspx");
    }


    public void FillPrinter()
    {

    }
    protected void txtSubstandardbadprintingper_N_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (txtPrintingChr100per_N.Text != "")
            {
                BadPrintingAmount = (Convert.ToDecimal(txtPrintingChr100per_N.Text) * Convert.ToDecimal(txtSubstandardbadprintingper_N.Text) / 100);
                txtBadPrintingAmount_N.Text = Convert.ToString(BadPrintingAmount);
            }
            else
            {
                txtSubstandardbadprintingper_N.Text = "";
                messageDiv.Style.Add("display", "block");
                messageDiv.Attributes.Add("class", "form-message error");
                messageDiv.InnerHtml = "'प्रिंटिंग चार्ज(100%) दर्ज करें..";
            }
        }
        catch { }
    }

    protected void txtPrintMistakPer_N_TextChanged(object sender, EventArgs e)
    {
        if (txtPrintingChr100per_N.Text != "")
        {
            MistakeAmount = (Convert.ToDecimal(txtPrintingChr100per_N.Text) * Convert.ToDecimal(txtPrintMistakPer_N.Text) / 100);
            txtMistakeAmount_N.Text = Convert.ToString(MistakeAmount);
        }
        else
        {
            txtPrintMistakPer_N.Text = "";
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'प्रिंटिंग चार्ज(100%) दर्ज करें..";
        }
    }

    protected void txtDateofProofSubmission_D_TextChanged(object sender, EventArgs e)
    {
        if (txtDateofRecMssDesign_D.Text != "")
        {
            if (Convert.ToDateTime(txtDateofProofSubmission_D.Text, cult) > Convert.ToDateTime(txtDateofRecMssDesign_D.Text, cult))
            {
                Delay_proof = Convert.ToDecimal((Convert.ToDateTime(txtDateofProofSubmission_D.Text, cult) - Convert.ToDateTime(txtDateofRecMssDesign_D.Text, cult)).TotalDays);
            }
            else
            {
                Delay_proof = Convert.ToDecimal("0");
            }
            txtDelay_proof_N.Text = Convert.ToString(Delay_proof);
        }
        else
        {
            txtDateofProofSubmission_D.Text = "";
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'डिजाइन प्रदान करने की दिनाँक दर्ज करें..";
        }
    }

    protected void txtPerofpenalty_proof_N_TextChanged(object sender, EventArgs e)
    {
        if (txtPrintingChr100per_N.Text != "")
        {
            TotPerofpenalty_proof = (Convert.ToDecimal(txtDelay_proof_N.Text) * Convert.ToDecimal(txtPerofpenalty_proof_N.Text));
            txtTotPerofpenalty_proof_N.Text = Convert.ToString(TotPerofpenalty_proof);

            AmountofPenalty_proof = (Convert.ToDecimal(txtPrintingChr100per_N.Text) * Convert.ToDecimal(txtTotPerofpenalty_proof_N.Text) / 100);
            txtAmountofPenalty_proof_N.Text = Convert.ToString(AmountofPenalty_proof);
        }
        else
        {
            txtPerofpenalty_proof_N.Text = "";
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'प्रिंटिंग चार्ज(100%) दर्ज करें..";
        }
    }

    protected void txtRecDate_D_TextChanged(object sender, EventArgs e)
    {
        if (txtSupp_DueDate_D.Text != "")
        {
            if (Convert.ToDateTime(txtRecDate_D.Text, cult) > Convert.ToDateTime(txtSupp_DueDate_D.Text, cult))
            {
                Delay_Supply = Convert.ToDecimal((Convert.ToDateTime(txtRecDate_D.Text, cult) - Convert.ToDateTime(txtSupp_DueDate_D.Text, cult)).TotalDays);
            }
            else
            {
                Delay_Supply = Convert.ToDecimal("0");
            }
            txtDelay_Supply_N.Text = Convert.ToString(Delay_Supply);
        }
        else
        {
            txtRecDate_D.Text = "";
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'जमा करने की दिनाँक दर्ज करें..";
        }
    }
    protected void txtTotPerofpenalty_Supply_N_TextChanged(object sender, EventArgs e)
    {
        if (txtPrintingChr100per_N.Text != "")
        {
            AmountofPenalty_Supply = (Convert.ToDecimal(txtPrintingChr100per_N.Text) * Convert.ToDecimal(txtTotPerofpenalty_Supply_N.Text) / 100);
            txtAmountofPenalty_Supply_N.Text = Convert.ToString(AmountofPenalty_Supply);
        }
        else
        {
            txtTotPerofpenalty_Supply_N.Text = "";
            messageDiv.Style.Add("display", "block");
            messageDiv.Attributes.Add("class", "form-message error");
            messageDiv.InnerHtml = "'प्रिंटिंग चार्ज(100%) दर्ज करें..";
        }
    }

    protected void ddlPrinterID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlPrinterID_I.SelectedItem.Text != "Select")
            {
                objBillDetails = new Pri_BillDetails_New();
                objBillDetails.Printer_RedID_I = int.Parse(ddlPrinterID_I.SelectedItem.Value.ToString());
                if (Request.QueryString["ID"] != null)
                {
                    // objBillDetails.Type_ID = 5;
                    objBillDetails.Type_ID = 15;
                }
                else
                    objBillDetails.Type_ID = 6;
                objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                objBillDetails.BillDate_D = DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);
                objBillDetails.mAcyear = ddlJobCode.SelectedValue;
                DataSet ds = objBillDetails.BillChildDetailsFillnew();
                //GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
                //GrdPaperCoverAndPrintingChares.DataBind();


                ddlBookID_I.DataSource = ds;
                ddlBookID_I.DataTextField = "TitleHindi_V";
                ddlBookID_I.DataValueField = "TitleID_I";
                ddlBookID_I.DataBind();
                ddlBookID_I.Items.Insert(0, new ListItem("Select", "0"));

            }
            else
            {
                ddlBookID_I.DataSource = null;
                ddlBookID_I.DataBind();
            }
        }
        catch { }
    }


    //protected void ddlPrinterID_I_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    obPRI_PrinterPenalty = new PRI_PrinterPenalty();
    //    var data1= obPRI_PrinterPenalty.PrinterAlldetails(1,Convert.ToInt32(ddlPrinterID_I.SelectedValue), 0);
    //    ddlGRPID_I.DataSource = data1;
    //    ddlGRPID_I.DataTextField = "groupno_v";
    //    ddlGRPID_I.DataValueField = "grpid_i";
    //    ddlGRPID_I.DataBind();
    //    ddlGRPID_I.Items.Insert(0, "सेलेक्ट..");
    //    ddlGRPID_I.Items.Insert(1, "1");
    //    if (data1.Tables[0].Rows.Count>0)
    //    {
    //        lblJobCode_V.Text = Convert.ToString(data1.Tables[0].Rows[0]["jobcode_v"]);
    //    }
    //    else
    //    {
    //        lblJobCode_V.Text = "";
    //    }
    //}


    //public void ddlPrinterAlldetails(int intPrinterID)
    //{
    //    obPRI_PrinterPenalty = new PRI_PrinterPenalty();
    //    var data1 = obPRI_PrinterPenalty.PrinterAlldetails(1, Convert.ToInt32(intPrinterID), 0);
    //    ddlGRPID_I.DataSource = data1;
    //    ddlGRPID_I.DataTextField = "groupno_v";
    //    ddlGRPID_I.DataValueField = "grpid_i";
    //    ddlGRPID_I.DataBind();
    //    if (data1.Tables[0].Rows.Count>0)
    //    {
    //        lblJobCode_V.Text = Convert.ToString(data1.Tables[0].Rows[0]["jobcode_v"]);
    //    }
    //    else
    //    {
    //        lblJobCode_V.Text = "";
    //    }

    //}
    //protected void ddlGRPID_I_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    obPRI_PrinterPenalty = new PRI_PrinterPenalty();
    //    var data = obPRI_PrinterPenalty.PrinterAlldetails(2, Convert.ToInt32(ddlPrinterID_I.SelectedValue),Convert.ToInt32(ddlGRPID_I.SelectedValue));
    //    ddlBookID_I.DataSource = data;
    //    ddlBookID_I.DataTextField = "BookName";
    //    ddlBookID_I.DataValueField = "textbookid_I";
    //    ddlBookID_I.DataBind();
    //    ddlBookID_I.Items.Insert(0, "सेलेक्ट..");
    //}


    //public void ddlGroupAlldetails(int intPrinterID,int intGRPid)
    //{
    //    obPRI_PrinterPenalty = new PRI_PrinterPenalty();
    //    var data = obPRI_PrinterPenalty.PrinterAlldetails(2, Convert.ToInt32(intPrinterID), Convert.ToInt32(intGRPid));
    //    ddlBookID_I.DataSource = data;
    //    ddlBookID_I.DataTextField = "BookName";
    //    ddlBookID_I.DataValueField = "textbookid_I";
    //    ddlBookID_I.DataBind();
    //}

    public void showdata()
    {
        obPRI_PrinterPenalty = new PRI_PrinterPenalty();
        obPRI_PrinterPenalty.PenaltyID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString());
        DataSet obDataSet = obPRI_PrinterPenalty.Select();

        //ddlPrinterID_I.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrinterID_I"]);
        // ddlPrinterAlldetails(Convert.ToInt32(ddlPrinterID_I.SelectedValue));
        //ddlGRPID_I.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["GRPID_I"]);
        // ddlGroupAlldetails(Convert.ToInt32(ddlPrinterID_I.SelectedValue), Convert.ToInt32(ddlGRPID_I.SelectedValue));
        // ddlBookID_I.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["BookID_I"]);

        if (obDataSet.Tables[0].Rows.Count > 0)
        {
            txtPrintingChr100per_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrintingChr100per_N"]);
            txtSubstandardbadprintingper_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Substandardbadprintingper_N"]);
            txtBadPrintingAmount_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["BadPrintingAmount_N"]);
            txtPrintMistakPer_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrintMistakPer_N"]);
            txtMistakeAmount_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["MistakeAmount_N"]);
            txtDateofRecMssDesign_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["DateofRecMssDesign_D"]).ToString("dd/MM/yyyy");
            txtDateofProofSubmission_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["DateofProofSubmission_D"]).ToString("dd/MM/yyyy");
            txtDelay_proof_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Delay_proof_N"]);
            txtPerofpenalty_proof_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Perofpenalty_proof_N"]);
            txtTotPerofpenalty_proof_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TotPerofpenalty_proof_N"]);
            txtAmountofPenalty_proof_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["AmountofPenalty_proof_N"]);
            txtSupp_DueDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["Supp_DueDate_D"]).ToString("dd/MM/yyyy");
            txtRecDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["RecDate_D"]).ToString("dd/MM/yyyy");
            txtDelay_Supply_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Delay_Supply_N"]);
            txtTotPerofpenalty_Supply_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TotPerofpenalty_Supply_N"]);
            txtAmountofPenalty_Supply_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["AmountofPenalty_Supply_N"]);
            //= Convert.ToString(obDataSet.Tables[0].Rows[0]["Transdate_D"]);

            //ddlJobCode.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["WorkorderID_I"]);
            ddlJobCode.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["JobCode_V"]);
            ddlPrinterID_I.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrinterID_I"]);

            obPRI_PrinterPenalty.PenaltyID_I = 1;
            HiddenField1.Value = objApi.Decrypt(Request.QueryString["ID"]).ToString();
            ddlPrinterID_I_SelectedIndexChanged(null, null);
            ddlBookID_I.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["BookID_I"]);
            HDNPriTransID.Value = obDataSet.Tables[0].Rows[0]["PriTransID"].ToString();
            txtChalanrecDate.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["UptoChallandate_D"]).ToString("dd/MM/yyyy");
            HfChallanDate.Value = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["UptoChallandate_D"]).ToString("dd/MM/yyyy");

            lblLastMaxChallanDate.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["LastMaxChallanDate"]).ToString();
            lblCount.Text = obDataSet.Tables[0].Rows[0]["LastCount"].ToString();
            lblMaxChallanDate.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["MaxChallanDate"]).ToString();
            //PenaltyFill();

            if (ddlJobCode.SelectedValue != "0" && ddlJobCode.SelectedValue != "")
            {
                //DataSet ds = LoadJobCodeDetail(Convert.ToInt32(ddlJobCode.SelectedValue));
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    lblPrinterName.Text = ds.Tables[0].Rows[0]["nameofpress_v"].ToString();
                //    lblGroupNo.Text = ds.Tables[0].Rows[0]["groupno_v"].ToString();
                //     obPRI_PrinterPenalty = new PRI_PrinterPenalty();
                //    ddlBookID_I.DataSource = obPRI_PrinterPenalty.TitleFill(int.Parse(lblGroupNo.Text));
                //    ddlBookID_I.DataTextField = "TitleHindi_V";
                //    ddlBookID_I.DataValueField = "TextBookID_I";
                //    ddlBookID_I.DataBind();
                //    ddlBookID_I.Items.Insert(0, "Select");
                //    try
                //    {
                //        ddlBookID_I.Items.FindByText(ds.Tables[0].Rows[0]["TitleHindi_V"].ToString()).Selected = true;
                //    }
                //    catch { }
                //}
                //PenaltyFill();
            }
            else
            {
                lblPrinterName.Text = "";
                lblGroupNo.Text = "";
                ddlBookID_I.DataSource = string.Empty;
                ddlBookID_I.DataBind();
                ddlBookID_I.Items.Insert(0, "Select");
            }

        }
    }

    protected void ddlJobCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        if (ddlJobCode.SelectedValue != "0")
        {

            ds = LoadJobCodeDetail(Convert.ToInt32(ddlJobCode.SelectedValue));

            if (ds.Tables[0].Rows.Count > 0)
            {
                lblPrinterName.Text = ds.Tables[0].Rows[0]["nameofpress_v"].ToString();
                lblGroupNo.Text = ds.Tables[0].Rows[0]["groupno_v"].ToString();
                // lblBookName.Text = ds.Tables[0].Rows[0]["Group_CONCAT(TitleHindi_V,cLASSDET_V)"].ToString();
                obPRI_PrinterPenalty = new PRI_PrinterPenalty();
                ddlBookID_I.DataSource = obPRI_PrinterPenalty.TitleFill(int.Parse(lblGroupNo.Text));
                ddlBookID_I.DataTextField = "TitleHindi_V";
                ddlBookID_I.DataValueField = "TextBookID_I";
                ddlBookID_I.DataBind();
                ddlBookID_I.Items.Insert(0, "Select");

            }
        }
        else
        {
            lblPrinterName.Text = "";
            lblGroupNo.Text = "";
            //lblBookName.Text = "";
            ddlBookID_I.DataSource = string.Empty;
            ddlBookID_I.DataBind();
            ddlBookID_I.Items.Insert(0, "Select");
        }

    }

    protected void ddlBookID_I_Init(object sender, EventArgs e)
    {
        ddlBookID_I.DataSource = string.Empty;
        ddlBookID_I.DataBind();
        ddlBookID_I.Items.Insert(0, "Select");
    }
    protected void ddlBookID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        PenaltyFill();
        if (HDNAlready.Value == "ok")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Penalty already exists.');</script>");
            return;
        }
        else if (HDNAlready.Value == "-1")
        {
            // challan not found
            string Message = string.Format("Challan not found upto this date - " + txtChalanrecDate.Text + " for printer - " + ddlPrinterID_I.SelectedItem.Text + " and title - " + ddlBookID_I.SelectedItem.Text);
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + Message + "');</script>");
        }
    }

    public void PenaltyFill()
    {
        try
        {
            //change 192017 - for printer penalty, select bookid from book ddl
            //obPRI_PrinterPenalty = new PRI_PrinterPenalty();
            //DataSet ds = new DataSet();
            //ds = obPRI_PrinterPenalty.PenaltyAmt(int.Parse(ddlBookID_I.SelectedItem.Value));
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    txtPrintingChr100per_N.Text = ds.Tables[0].Rows[0]["Amount_N"].ToString();
            //}
            HDNAlready.Value = "";

            DataSet ds = new DataSet();
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.Printer_RedID_I = int.Parse(ddlPrinterID_I.SelectedItem.Value.ToString());
            objBillDetails.Type_ID = 12;
            objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
            objBillDetails.BillDate_D = DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);
            objBillDetails.mAcyear = ddlJobCode.SelectedValue;
            objBillDetails.BillID_I = int.Parse(ddlBookID_I.SelectedValue);

            //get max chalan date
            string strUptoChallanDate = "";
            objBillDetails.Type_ID = 13;
            ds = objBillDetails.BillChildDetailsFillnew();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    strUptoChallanDate = ds.Tables[0].Rows[0][0].ToString();
                }
            }

            if (strUptoChallanDate != "")
            {
                objBillDetails.BillDate_D = Convert.ToDateTime(strUptoChallanDate).AddDays(1);
                if (Convert.ToDateTime(strUptoChallanDate) >= objBillDetails.ChallanRecDate_D)
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Penalty already exists.');</script>");
                    //return;
                    HDNAlready.Value = "ok";
                    return;
                }
                else
                {
                    objBillDetails.Type_ID = 14;
                    objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                    ds = objBillDetails.BillChildDetailsFillnew();
                }


            }
            else
            {
                objBillDetails.Type_ID = 12;
                ds = objBillDetails.BillChildDetailsFillnew();
            }


            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPrintingChr100per_N.Text = ds.Tables[0].Rows[0]["Amount_N"].ToString();
                HDNPriTransID.Value = ds.Tables[0].Rows[0]["PriTransID"].ToString();

                if (Request.QueryString["ID"] != null)
                {
                    txtSubstandardbadprintingper_N_TextChanged(null, null);
                    txtPrintMistakPer_N_TextChanged(null, null);
                    txtDateofProofSubmission_D_TextChanged(null, null);
                    txtPerofpenalty_proof_N_TextChanged(null, null);
                }
            }
            else
            {
                txtPrintingChr100per_N.Text = "";
                HDNPriTransID.Value = "";
                //HDNAlready.Value = "Challan not found for printer - <b>"+ddlPrinterID_I.SelectedItem.Text+"</b> and title - <b>"+ddlBookID_I.SelectedItem.Text+"</b>";  // challan not found
                HDNAlready.Value = "-1";
            }
        }
        catch { HDNAlready.Value = ""; }
    }

    public class Pri_BillDetails_New
    {


        private int _Printer_RedID_I;
        private int _ChallanTrno_I;
        private string _PriTransID;
        private int _User_ID;

        private int _BillID_I;
        private string _Billno_V;
        private DateTime _BillDate_D;
        private DateTime _ChallanRecDate_D;
        private int _PrinterID_I;
        private int _BookTitleID_I;
        private float _TotalPaperSup_N;
        private float _TotCovPaperSup_N;
        private float _PapSecReimburse_N;
        private float _BalSecurity_N;
        private float _PrnChrg100per_N;
        private float _PrnChrg25per_N;
        private float _PrnChrg75per_N;
        private float _PaperSecforton_N;
        private float _PaperReemRs_N;
        private float _TonsPerReem_N;
        private float _Reimburseamt_N;
        private float _PayablePrnchrg_N;
        private float _Totalpayable_N;
        private float _DedIncometax_N;
        private float _DedpapSec_N;
        private float _DedDepoExp_N;
        private float _DedInterestonpaper_N;
        private float _PenDelaySup_N;
        private float _DedShotSizePaper1_N;
        private float _DedShotSizePaper2_N;
        private float _DedShotSizePaper3_N;
        private float _TotalDed_N;
        private float _NetPayable_N;
        private float _PaperSecurityDeposit;
        private float _BFPay;
        private string _JobCode_V;
        private float _BillAmountofDeduction;
        private float _BillAmount;
        private float _BillNetPayablePrinting;

        private int _BlankPages;
        private int _TotBlankPage;

        //Details
        private int _mLibraryBook;
        private int _BillDetID_I;
        private int _Depotid_I;
        private float _Qty_N;
        private float _Rate_N;
        private float _Pages_N;
        private float _Amount_N;
        private float _PaperConsum_Wastage_N;
        private float _CoverPaperConsum_Wastage_N;
        private int _Type_ID;

        private float _OtherDedAmount_N;
        private string _OtherDed_V;
        private string _mAcyear;

        public int BlankPages { get { return _BlankPages; } set { _BlankPages = value; } }
        public int TotBlankPage { get { return _TotBlankPage; } set { _TotBlankPage = value; } }

        public float BillNetPayablePrinting { get { return _BillNetPayablePrinting; } set { _BillNetPayablePrinting = value; } }
        public float BillAmountofDeduction { get { return _BillAmountofDeduction; } set { _BillAmountofDeduction = value; } }
        public float BillAmount { get { return _BillAmount; } set { _BillAmount = value; } }
        public float BFPay { get { return _BFPay; } set { _BFPay = value; } }
        public float PaperSecurityDeposit { get { return _PaperSecurityDeposit; } set { _PaperSecurityDeposit = value; } }
        public int BillDetID_I { get { return _BillDetID_I; } set { _BillDetID_I = value; } }
        public int Depotid_I { get { return _Depotid_I; } set { _Depotid_I = value; } }
        public float Qty_N { get { return _Qty_N; } set { _Qty_N = value; } }
        public float Rate_N { get { return _Rate_N; } set { _Rate_N = value; } }
        public float Pages_N { get { return _Pages_N; } set { _Pages_N = value; } }
        public float Amount_N { get { return _Amount_N; } set { _Amount_N = value; } }
        public float PaperConsum_Wastage_N { get { return _PaperConsum_Wastage_N; } set { _PaperConsum_Wastage_N = value; } }
        public float CoverPaperConsum_Wastage_N { get { return _CoverPaperConsum_Wastage_N; } set { _CoverPaperConsum_Wastage_N = value; } }

        // end


        public int BillID_I { get { return _BillID_I; } set { _BillID_I = value; } }
        public string Billno_V { get { return _Billno_V; } set { _Billno_V = value; } }
        public string mAcyear { get { return _mAcyear; } set { _mAcyear = value; } }
        public DateTime BillDate_D { get { return _BillDate_D; } set { _BillDate_D = value; } }
        public int PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public int BookTitleID_I { get { return _BookTitleID_I; } set { _BookTitleID_I = value; } }
        public float TotalPaperSup_N { get { return _TotalPaperSup_N; } set { _TotalPaperSup_N = value; } }
        public float TotCovPaperSup_N { get { return _TotCovPaperSup_N; } set { _TotCovPaperSup_N = value; } }
        public float PapSecReimburse_N { get { return _PapSecReimburse_N; } set { _PapSecReimburse_N = value; } }
        public float BalSecurity_N { get { return _BalSecurity_N; } set { _BalSecurity_N = value; } }
        public float PrnChrg100per_N { get { return _PrnChrg100per_N; } set { _PrnChrg100per_N = value; } }
        public float PrnChrg25per_N { get { return _PrnChrg25per_N; } set { _PrnChrg25per_N = value; } }
        public float PrnChrg75per_N { get { return _PrnChrg75per_N; } set { _PrnChrg75per_N = value; } }
        public float PaperSecforton_N { get { return _PaperSecforton_N; } set { _PaperSecforton_N = value; } }
        public float PaperReemRs_N { get { return _PaperReemRs_N; } set { _PaperReemRs_N = value; } }
        public float TonsPerReem_N { get { return _TonsPerReem_N; } set { _TonsPerReem_N = value; } }
        public float Reimburseamt_N { get { return _Reimburseamt_N; } set { _Reimburseamt_N = value; } }
        public float PayablePrnchrg_N { get { return _PayablePrnchrg_N; } set { _PayablePrnchrg_N = value; } }
        public float Totalpayable_N { get { return _Totalpayable_N; } set { _Totalpayable_N = value; } }
        public float DedIncometax_N { get { return _DedIncometax_N; } set { _DedIncometax_N = value; } }
        public float DedpapSec_N { get { return _DedpapSec_N; } set { _DedpapSec_N = value; } }
        public float DedDepoExp_N { get { return _DedDepoExp_N; } set { _DedDepoExp_N = value; } }
        public float DedInterestonpaper_N { get { return _DedInterestonpaper_N; } set { _DedInterestonpaper_N = value; } }
        public float PenDelaySup_N { get { return _PenDelaySup_N; } set { _PenDelaySup_N = value; } }
        public float DedShotSizePaper1_N { get { return _DedShotSizePaper1_N; } set { _DedShotSizePaper1_N = value; } }
        public float DedShotSizePaper2_N { get { return _DedShotSizePaper2_N; } set { _DedShotSizePaper2_N = value; } }
        public float DedShotSizePaper3_N { get { return _DedShotSizePaper3_N; } set { _DedShotSizePaper3_N = value; } }
        public float TotalDed_N { get { return _TotalDed_N; } set { _TotalDed_N = value; } }
        public float NetPayable_N { get { return _NetPayable_N; } set { _NetPayable_N = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public DateTime ChallanRecDate_D { get { return _ChallanRecDate_D; } set { _ChallanRecDate_D = value; } }
        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public int ChallanTrno_I { get { return _ChallanTrno_I; } set { _ChallanTrno_I = value; } }
        public string PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int User_ID { get { return _User_ID; } set { _User_ID = value; } }
        public int Type_ID { get { return _Type_ID; } set { _Type_ID = value; } }
        public int mLibraryBook { get { return _mLibraryBook; } set { _mLibraryBook = value; } }

        public float OtherDedAmount_N { get { return _OtherDedAmount_N; } set { _OtherDedAmount_N = value; } }
        public string OtherDed_V { get { return _OtherDed_V; } set { _OtherDed_V = value; } }


        public System.Data.DataSet BillChildDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", Type_ID);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);

            return obDBAccess.records();
        }

        public System.Data.DataSet BillChildDetailsFillnew()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFillnew", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", Type_ID);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);
            obDBAccess.addParam("mAcyear", mAcyear);
            return obDBAccess.records();
        }

        public System.Data.DataSet PrinterDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 0);
            //obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            //obDBAccess.addParam("mBillDate", BillDate_D);
            return obDBAccess.records();
        }

    }

    public class PRI_PrinterPenalty_New
    {
        private Int32 _ID;
        private Int32 _PenaltyID_I;
        private Int32 _PrinterID_I;
        private Int32 _GRPID_I;
        private Int32 _BookID_I;

        private Int32 _workorderid_i;

        private Decimal _PrintingChr100per_N;
        private Decimal _Substandardbadprintingper_N;
        private Decimal _BadPrintingAmount_N;
        private Decimal _PrintMistakPer_N;
        private Decimal _MistakeAmount_N;
        private DateTime _DateofRecMssDesign_D;
        private DateTime _DateofProofSubmission_D;
        private Decimal _Delay_proof_N;
        private Decimal _Perofpenalty_proof_N;
        private Decimal _TotPerofpenalty_proof_N;
        private Decimal _AmountofPenalty_proof_N;
        private DateTime _Supp_DueDate_D;
        private DateTime _RecDate_D;
        private Decimal _Delay_Supply_N;
        private Decimal _TotPerofpenalty_Supply_N;
        private Decimal _AmountofPenalty_Supply_N;
        private DateTime _Transdate_D;
        private string _JobCode_V;
        private string _PriTransID;
        private DateTime _UptoChallandate_D;


        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public Int32 PenaltyID_I { get { return _PenaltyID_I; } set { _PenaltyID_I = value; } }
        public Int32 PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public Int32 GRPID_I { get { return _GRPID_I; } set { _GRPID_I = value; } }
        public Int32 BookID_I { get { return _BookID_I; } set { _BookID_I = value; } }
        public Decimal PrintingChr100per_N { get { return _PrintingChr100per_N; } set { _PrintingChr100per_N = value; } }
        public Decimal Substandardbadprintingper_N { get { return _Substandardbadprintingper_N; } set { _Substandardbadprintingper_N = value; } }
        public Decimal BadPrintingAmount_N { get { return _BadPrintingAmount_N; } set { _BadPrintingAmount_N = value; } }
        public Decimal PrintMistakPer_N { get { return _PrintMistakPer_N; } set { _PrintMistakPer_N = value; } }
        public Decimal MistakeAmount_N { get { return _MistakeAmount_N; } set { _MistakeAmount_N = value; } }
        public DateTime DateofRecMssDesign_D { get { return _DateofRecMssDesign_D; } set { _DateofRecMssDesign_D = value; } }
        public DateTime DateofProofSubmission_D { get { return _DateofProofSubmission_D; } set { _DateofProofSubmission_D = value; } }
        public Decimal Delay_proof_N { get { return _Delay_proof_N; } set { _Delay_proof_N = value; } }
        public Decimal Perofpenalty_proof_N { get { return _Perofpenalty_proof_N; } set { _Perofpenalty_proof_N = value; } }
        public Decimal TotPerofpenalty_proof_N { get { return _TotPerofpenalty_proof_N; } set { _TotPerofpenalty_proof_N = value; } }
        public Decimal AmountofPenalty_proof_N { get { return _AmountofPenalty_proof_N; } set { _AmountofPenalty_proof_N = value; } }
        public DateTime Supp_DueDate_D { get { return _Supp_DueDate_D; } set { _Supp_DueDate_D = value; } }
        public DateTime RecDate_D { get { return _RecDate_D; } set { _RecDate_D = value; } }
        public Decimal Delay_Supply_N { get { return _Delay_Supply_N; } set { _Delay_Supply_N = value; } }
        public Decimal TotPerofpenalty_Supply_N { get { return _TotPerofpenalty_Supply_N; } set { _TotPerofpenalty_Supply_N = value; } }
        public Decimal AmountofPenalty_Supply_N { get { return _AmountofPenalty_Supply_N; } set { _AmountofPenalty_Supply_N = value; } }
        public DateTime Transdate_D { get { return _Transdate_D; } set { _Transdate_D = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public string PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int workorderid_i { get { return _workorderid_i; } set { _workorderid_i = value; } }
        public DateTime UptoChallandate_D { get { return _UptoChallandate_D; } set { _UptoChallandate_D = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI008_PenaltyDetailSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPenaltyID_I", PenaltyID_I);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mGRPID_I", GRPID_I);
            obDBAccess.addParam("mBookID_I", BookID_I);
            obDBAccess.addParam("mPrintingChr100per_N", PrintingChr100per_N);
            obDBAccess.addParam("mSubstandardbadprintingper_N", Substandardbadprintingper_N);
            obDBAccess.addParam("mBadPrintingAmount_N", BadPrintingAmount_N);
            obDBAccess.addParam("mPrintMistakPer_N", PrintMistakPer_N);
            obDBAccess.addParam("mMistakeAmount_N", MistakeAmount_N);
            obDBAccess.addParam("mDateofRecMssDesign_D", DateofRecMssDesign_D);
            obDBAccess.addParam("mDateofProofSubmission_D", DateofProofSubmission_D);
            obDBAccess.addParam("mDelay_proof_N", Delay_proof_N);
            obDBAccess.addParam("mPerofpenalty_proof_N", Perofpenalty_proof_N);
            obDBAccess.addParam("mTotPerofpenalty_proof_N", TotPerofpenalty_proof_N);
            obDBAccess.addParam("mAmountofPenalty_proof_N", AmountofPenalty_proof_N);
            obDBAccess.addParam("mSupp_DueDate_D", Supp_DueDate_D);
            obDBAccess.addParam("mRecDate_D", RecDate_D);
            obDBAccess.addParam("mDelay_Supply_N", Delay_Supply_N);
            obDBAccess.addParam("mTotPerofpenalty_Supply_N", TotPerofpenalty_Supply_N);
            obDBAccess.addParam("mAmountofPenalty_Supply_N", AmountofPenalty_Supply_N);
            obDBAccess.addParam("mTransdate_D", Transdate_D);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mPriTransID", PriTransID);
            obDBAccess.addParam("mChalanrecDate", UptoChallandate_D);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

    }
}