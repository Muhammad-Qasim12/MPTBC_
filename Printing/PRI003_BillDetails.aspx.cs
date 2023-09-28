using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
using System.IO;
 

public partial class Printing_PRI003_BillDetails : System.Web.UI.Page
{
    DataSet ds;
    Pri_BillDetails_New objBillDetails = null;
   public  CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objApi = new APIProcedure();
    float TotalAmt = 0;
    Decimal dPaperTotal = 0; Decimal dCoverTotal = 0;
    Decimal dPaper70Total = 0; Decimal dPaper80Total = 0;
    Decimal dCoverPaper230Total = 0; Decimal dCoverPaper250Total = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblOutgst.Text = "0"; lblIngst_s.Text = "0"; lblIngst_c.Text = "0";
            //DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(1)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            txtBillDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            PrinterFill();
            ViewState["BillID_I"] = "";
            if (Request.QueryString["ID"] != null)
            {   
                GridFillLoad();
            }
        }
    }

    public void GridFillLoad()
    {
        try
        {
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.BillID_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"]).ToString());
           
            objBillDetails.BillDate_D = DateTime.Parse(txtBillDate.Text, cult);
            ds = objBillDetails.FieldFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime datch = new DateTime();
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["BillDate_D"].ToString());
                txtBillDate.Text = dat.ToString("dd/MM/yyyy");
                // objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                if (ds.Tables[0].Rows[0]["challanupto"].ToString() != "")
                {
                    datch = DateTime.Parse(ds.Tables[0].Rows[0]["challanupto"].ToString());
                    txtChalanrecDate.Text = datch.ToString("dd/MM/yyyy");
                }
                txtBillNo.Text = ds.Tables[0].Rows[0]["Billno_V"].ToString();
                ViewState["BillID_I"] = objApi.Decrypt(Request.QueryString["ID"]).ToString();
                ddlPrinter.ClearSelection();
                PrinterFill();
                ddlPrinter.Items.FindByValue(ds.Tables[0].Rows[0]["Printer_RedID_I"].ToString()).Selected = true;
                txtTotalPaperSupply.Text = ds.Tables[0].Rows[0]["TotPaperConsum_Wastage_N"].ToString();
                txtTotalCoverPaperSupply.Text = ds.Tables[0].Rows[0]["TotCoverPaperConsum_Wastage_N"].ToString();
                txtPaperSecurityReimbursed.Text = ds.Tables[0].Rows[0]["PapSecReimburse_N"].ToString();
                txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["PaperSecurityDeposit"].ToString();
                txtBalancePaperSecurityReimbursed.Text = ds.Tables[0].Rows[0]["BalSecurity_N"].ToString();
                txtPrintingCharge.Text = ds.Tables[0].Rows[0]["PrnChrg100per_N"].ToString();
                txtPrintingCharge25Per.Text = ds.Tables[0].Rows[0]["PrnChrg25per_N"].ToString();
                txtPrintingCharge75Per.Text = ds.Tables[0].Rows[0]["PrnChrg75per_N"].ToString();
                txtPaperSecurityFor.Text = ds.Tables[0].Rows[0]["PaperSecforton_N"].ToString();
                txtReemPaperRs.Text = ds.Tables[0].Rows[0]["PaperReemRs_N"].ToString();
                txtTonsPerReem.Text = ds.Tables[0].Rows[0]["TonsPerReem_N"].ToString();
                txtReimburseAmount.Text = ds.Tables[0].Rows[0]["Reimburseamt_N"].ToString();
                txtPayBlePrintingCharg.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
                txtTotalPaybleAmount.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
                txtBFPay.Text = ds.Tables[0].Rows[0]["BFPay"].ToString();
                txt2PerInComeTAX.Text = ds.Tables[0].Rows[0]["DedIncometax_N"].ToString();
                txt2PerTDSGST.Text = ds.Tables[0].Rows[0]["tdsonGst"].ToString();
                txt2PerTDSCGST.Text = ds.Tables[0].Rows[0]["tdsCGst"].ToString();
                txtDeductionPaperSecurity.Text = ds.Tables[0].Rows[0]["DedpapSec_N"].ToString();
                txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["DedDepoExp_N"].ToString();
                txtPaperInterest.Text = ds.Tables[0].Rows[0]["DedInterestonpaper_N"].ToString();
                txtDelaySupplyPenalty.Text = ds.Tables[0].Rows[0]["PenDelaySup_N"].ToString();
                txtShortSizeBookDeduction.Text = ds.Tables[0].Rows[0]["DedShotSizePaper1_N"].ToString();
                txtRs2.Text = ds.Tables[0].Rows[0]["DedShotSizePaper2_N"].ToString();
                txtRs3.Text = ds.Tables[0].Rows[0]["DedShotSizePaper3_N"].ToString();
                txtTotalDeduction.Text = ds.Tables[0].Rows[0]["TotalDed_N"].ToString();
                // txtTotalDeduction.Text = (txtTotalDeduction.Text) + (txt2PerInComeTAX.Text);
                
                txtNetPayable.Text = ds.Tables[0].Rows[0]["NetPayable_N"].ToString();
                // txtNetPayable.Text = (Convert.ToDouble(txtNetPayable.Text) - Convert.ToDouble(txt2PerInComeTAX.Text)).ToString() ;

                string status = ds.Tables[0].Rows[0]["BillStatus"].ToString();
                int IsChequeIssue = int.Parse(ds.Tables[0].Rows[0]["IsChequeIssue"].ToString());
                int isStatePRinter = int.Parse(ds.Tables[0].Rows[0]["IsStatePrinter"].ToString());

                txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                txtChequeDDNo.Text = ds.Tables[0].Rows[0]["ChequeDDNo"].ToString();
                txtChequeDate.Text = ds.Tables[0].Rows[0]["ChequeDate"].ToString();
                txtCheckRemark.Text = ds.Tables[0].Rows[0]["ChequeRemark"].ToString();
                txtCheckAmount.Text = ds.Tables[0].Rows[0]["ChequeAmount"].ToString();

                txtOtherDedDescription.Text = ds.Tables[0].Rows[0]["OtherDedDescription"].ToString();
                txtOtherDedAmt.Text = ds.Tables[0].Rows[0]["OtherDedAmount"].ToString();

                txtBadPrinting.Text = ds.Tables[0].Rows[0]["BadPrinting_N"].ToString();
                txtPrintingMistakes.Text = ds.Tables[0].Rows[0]["PrintingMistakes_N"].ToString();
                txtLamination.Text = ds.Tables[0].Rows[0]["Lamination_N"].ToString();
                txtPerfectBinding.Text = ds.Tables[0].Rows[0]["PerfectBinding_N"].ToString();
                txtLooseBundlePack.Text = ds.Tables[0].Rows[0]["LooseBundlePack_N"].ToString();
                txtTransportationDelvry.Text = ds.Tables[0].Rows[0]["TransportationDelvryChrg_N"].ToString();
                lblGSTAmt.Text = ds.Tables[0].Rows[0]["GSTAmt_N"].ToString();
                txtGST.Text = lblGSTAmt.Text;
                txtAmtReturnToPrinter.Text = ds.Tables[0].Rows[0]["AmtReturnToPrinter_N"].ToString();
                txtAmtReturnToPrinter0.Text = ds.Tables[0].Rows[0]["AmtReturnToPrinter_N"].ToString();
                txtTotalPayableWithGST.Text = ds.Tables[0].Rows[0]["TotAmtPayableWithGST_N"].ToString();
                
                //txtBillAmount.Text = ds.Tables[0].Rows[0]["BillAmount"].ToString();
                //txtBillAmountofDeduction.Text = ds.Tables[0].Rows[0]["BillAmountofDeduction"].ToString();
                //txtBillNetPayablePrinting.Text = ds.Tables[0].Rows[0]["BillNetPayablePrinting"].ToString();
                //fill bill amount details
                NetPayDeduction();
                               

                if (ddlPrinter.SelectedItem.Text != "Select")
                {
                    objBillDetails = new Pri_BillDetails_New();
                    objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
                    objBillDetails.Type_ID = 5;
                    objBillDetails.BillID_I = int.Parse(ViewState["BillID_I"].ToString());
                    objBillDetails.mAcyear = DdlACYear.SelectedValue;
                    objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                    ds = objBillDetails.BillChildDetailsFillnew();
                    GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
                    GrdPaperCoverAndPrintingChares.DataBind();

                    ViewState["dtBill"] = ds.Tables[0];
                  
                    //if (ds.Tables[0].Rows.Count > 0)
                    //{
                    //    txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
                    //    txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
                    //}
                    //else
                    //{
                    //    txtPaperSecurityDeposit.Text = "";
                    //    txtDepotExpenditure.Text = "";
                    //}
                   // 88 PrinterpaperSupplyFill();
                    //OnLoad();

                }                           
           
           
                GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
                GrdPaperCoverAndPrintingChares.DataBind();
                //checkbox checked
                foreach (GridViewRow grv in GrdPaperCoverAndPrintingChares.Rows)
                {
                    Label lblBillDetID_I = (Label)grv.FindControl("lblBillDetID_I");
                    CheckBox chkSelect = grv.FindControl("chkSelect") as CheckBox;
                    if (int.Parse(lblBillDetID_I.Text) > 0)
                    {
                        chkSelect.Checked = true;
                    }
                    else
                        chkSelect.Checked = false;
                }
                //CalAmt();

                btnSendToFinance.Visible = true;
                // pnlFinance.Visible = true;
                lblFinanceMsg.Visible = true;
                ddlPrinter.Enabled = false;
                lblFinanceMsg.Text = "Do You Want To Send Finance Department.";
                //OnLoad();

                //cheque issued = 4, 
                if( IsChequeIssue== 4)
                {
                    if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "1")
                    {
                        btnSendToFinance.Visible = false;
                        btnForward.Visible = false;
                        pnlChequeIssue.Visible = true;
                        pnlChequeIssue.Enabled = false;
                    }
                    else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "p")
                    {
                        btnSendToFinance.Visible = false;
                        btnForward.Visible = false;
                        pnlChequeIssue.Visible = true;
                        pnlChequeIssue.Enabled = false;
                    }
                    else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "home")
                    {
                        btnSendToFinance.Visible = false;
                        btnForward.Visible = false;
                        pnlChequeIssue.Visible = true;
                        pnlChequeIssue.Enabled = false;
                    }
                }
                else if (IsChequeIssue == 3 || IsChequeIssue == 2 || IsChequeIssue == 1)
                {//100
                    btnSendToFinance.Visible = false;
                    btnForward.Visible = true;
                    pnlChequeIssue.Enabled = false;
                    pnlPrintingSection.Enabled = false;
                    pnlFinance.Enabled = false;
                    pnlMain.Enabled = true;
                }

                // added for printing bill view by officer - 27/7/2017
                if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "1")
                {
                    btnSendToFinance.Visible = false;
                    btnForward.Visible = false;
                    pnlChequeIssue.Visible = false;
                    pnlChequeIssue.Enabled = false;
                }
                else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "p")
                {
                    btnSendToFinance.Visible = false;
                    btnForward.Visible = false;
                    pnlChequeIssue.Visible = false;
                    pnlChequeIssue.Enabled = false;
                }
                else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "home")
                {
                    btnSendToFinance.Visible = false;
                    btnForward.Visible = false;
                    pnlChequeIssue.Visible = false;
                    pnlChequeIssue.Enabled = false;
                }

                //added for gst - 28/12/17
                rdIn.Checked = false; rdOut.Checked = false;
                GSTCalc();
                if (isStatePRinter == 0)
                {
                    rdOut.Checked = true;
                    //dvOutgst.Visible = true;
                    //dvIngst_c.Visible = false;
                    //dvIngst_s.Visible = false;
                    lblTDSGST.Text = "(2) Withheld 2% regarding IGST TDS Rs. ";
                    lblTDSCGST.Visible =false;
                    txt2PerTDSCGST.Text = "0";


                    dvOutgst.Style.Add("display", "block");
                    dvIngst_s.Style.Add("display", "none");
                    dvIngst_c.Style.Add("display", "none");
                    
                }
                else if (isStatePRinter == 1)
                {
                    rdIn.Checked = true;
                    // dvOutgst.Visible = false;
                    //dvIngst_c.Visible = true;
                    //dvIngst_s.Visible = true;
                    lblTDSGST.Text = "(2-a) Withheld 1% regarding SGST TDS Rs. ";
                    lblTDSCGST.Visible = true;
                    lblTDSCGST.Text = "(b) Withheld 1% regarding CGST TDS  Rs. ";


                    dvOutgst.Style.Add("display", "none");
                    dvIngst_s.Style.Add("display", "block");
                    dvIngst_c.Style.Add("display", "block");
                }
            }
        }
        catch { }

    }


    public void PrinterFill()
    {
        objBillDetails = new Pri_BillDetails_New();
        ddlPrinter.DataSource = objBillDetails.PrinterDetailsFill();
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
      
    }


    //public void PrinterpaperSupplyFill()
    //{
    //    PRI_PaperAllotment obj = new PRI_PaperAllotment();
    //    try{
       
    //    DataSet ds1 = new DataSet();
    //    obj.Printer_RedID_I = Convert.ToInt32 ( ddlPrinter.SelectedValue);
    //    obj.AcadmicYR_V =Convert.ToString ( DdlACYear.SelectedValue);
    //    ds1 = obj.GetPrinterPaperSupply(); 
    //   if (ds1.Tables[0].Rows.Count>0) 
    //   {
    //       txtTotalPaperSupply.Text = ds1.Tables[0].Rows[0]["PriPaperQty_N"].ToString();

    //       txtTotalCoverPaperSupply.Text = ds1.Tables[0].Rows[0]["CovPaperQty_N"].ToString();
    //    }
    //   }
    //        catch {}

    //    finally { obj = null; }
    //}

    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
       
    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrinter.SelectedItem.Text != "Select")
        {
            if (ViewState["dtBill"] != null)
                ViewState["dtBill"] = null;

            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
            if (Request.QueryString["ID"] != null)
            {
                objBillDetails.Type_ID = 5;
            }
            else
            objBillDetails.Type_ID = 6;
            objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
            objBillDetails.BillDate_D = DateTime.Parse(txtBillDate.Text, cult);
            objBillDetails.mAcyear = DdlACYear.SelectedValue;  
            ds = objBillDetails.BillChildDetailsFillnew();
            GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
            GrdPaperCoverAndPrintingChares.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
                txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
                txtTotalPaperSupply.Text = ds.Tables[0].Rows[0]["TotPaperConsum_Wastage_N"].ToString();
                txtTotalCoverPaperSupply.Text = ds.Tables[0].Rows[0]["TotCoverPaperConsum_Wastage_N"].ToString();
                //ViewState["dtBill"] = ds.Tables[0];
            }
            else
            {
                txtPaperSecurityDeposit.Text = "";
                txtDepotExpenditure.Text = "";
            }
            DataTable Dt = obCommonFuction.FillTableByProc("call USP_Penalty_delay('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd-MM-yyyy") + "')");
            txtDelaySupplyPenalty.Text = Math.Ceiling(float.Parse(Dt.Rows[0][0].ToString()!=""?Dt.Rows[0][0].ToString():"0")).ToString();     
          //  PrinterpaperSupplyFill();
            //CalBadPrintingAndMistakes("", "1");
            OnLoad();

            //get autogenerate bill no
            string strBillNo = obCommonFuction.FillScalarByProc("SELECT FN_GetAllBillNos('Printer','"+ddlPrinter.SelectedValue+"','"+DdlACYear.SelectedValue+"')");
            if (strBillNo != "")
            {
                txtBillNo.Text = strBillNo;
                txtBillNo.Enabled = false;
            }
            else
            {
                txtBillNo.Text = "";
                txtBillNo.Enabled = true;
            }
            
        }
        else
        {
            GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
            GrdPaperCoverAndPrintingChares.DataBind();
            txtPrintingCharge.Text = "0";
            txtPrintingCharge25Per.Text = "0";
            txtPrintingCharge75Per.Text = "0";
            txtBadPrinting.Text = "0";
        }
    }

    protected void txtBlankPages_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
         TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        TextBox txtLibBook= (TextBox)gv.FindControl("txtLibBook");
        TextBox txtPapterConsumption = (TextBox)gv.FindControl("txtPapterConsumption");
        TextBox txtCoverPapterConsumption = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

        Label lblPayablePages = (Label)gv.FindControl("lblPayablePages");
       
            float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0,Lib=0;
            try
            {
                Page = float.Parse(lblPages_N.Text);
            }
            catch { }
            try
            {
                BlankPage = float.Parse(txt.Text);
            }
            catch { }
            TotalPage = Page - BlankPage;



        
            try
        { Qty = float.Parse(lblTotalNoBook.Text);
        Lib = float.Parse(txtLibBook.Text); 
        }
        catch { Qty = 0; }
        try
        { Rate = float.Parse(lblRate_N.Text); }
        catch { Rate = 0; }
        lblTotalBlankPages_N.Text = (Qty * BlankPage).ToString();

        Amt = ((Qty) * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");


        
            if (chkSelect.Checked == true)
            {
                try
                {
                    CalAmt();
                }
                catch { }
            }

        //payable pages
            if (Convert.ToInt32(txt.Text != "" ? txt.Text : "0") > 0)
            {
                int totp = Convert.ToInt32 (Math.Round (Convert.ToDecimal ( lblPages_N.Text))) ;
                int blpag = int.Parse(txt.Text);
                int paypg = totp - blpag;
               // lblPayablePages.Text = (int.Parse(lblPages_N.Text)-int.Parse(txt.Text)).ToString() + "+" + txt.Text;
                lblPayablePages.Text = (paypg).ToString() + "+" + txt.Text;
            }
            else
            {
                lblPayablePages.Text = lblPages_N.Text;
            }
    }

    protected void txtBadPrinPercent_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

       // float oldval = float.Parse(txtBadPrinting.Text);

       // float Amt = 0, perc = 0, totbadprinting = 0;
       // try
       // {
       //     perc = float.Parse(txt.Text);
       // }
       // catch { }
       // try
       // {
       //     Amt = float.Parse(lblAmount.Text);
       // }
       // catch { }

       // totbadprinting = (Amt * perc)/100 + oldval;

       //// TotalPage = Page - BlankPage;       

       // txtBadPrinting.Text = Math.Round(totbadprinting, 0).ToString("0.00");

        if (chkSelect.Checked == true)
        {
            try
            {
                CalAmt();
            }
            catch { }
        }
       
    }

    
    //double Amount = 0;
    protected void GrdPaperCoverAndPrintingChares_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //Label lblTotalNoBook = (e.Row.FindControl("lblTotalNoBook") as Label);
        //    // TextBox lblRate_N = (e.Row.FindControl("lblRate_N") as Label);
        //    Label lblAmount = (e.Row.FindControl("lblAmount") as Label);
        //    //Label lblTotalBlankPages_N = (e.Row.FindControl("lblTotalBlankPages_N") as Label);
        //    //Label lblPages_N = (e.Row.FindControl("lblPages_N") as Label);
        //    //TextBox txtBlankPages = (e.Row.FindControl("txtBlankPages") as TextBox);

        //    //float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0;
        //    //try
        //    //{
        //    //    Page = float.Parse(lblPages_N.Text);
        //    //}
        //    //catch { }
        //    //try
        //    //{
        //    //    BlankPage = float.Parse(txtBlankPages.Text);
        //    //}
        //    //catch { }
        //    //TotalPage = Page - BlankPage;

        //    //try
        //    //{ Qty = float.Parse(lblTotalNoBook.Text); }
        //    //catch { Qty = 0; }
        //    //try
        //    //{ Rate = float.Parse(lblRate_N.Text); }
        //    //catch { Rate = 0; }
        //    //lblTotalBlankPages_N.Text = (Qty * BlankPage).ToString();

        //    //Amt = (Qty * Rate * TotalPage) / 8000;

        //    //lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");
        //    try
        //    {
        //        Amount = Amount + double.Parse(lblAmount.Text);
        //        //Amount = Amount + Amt;
        //        //CalAmt();
        //    }
        //    catch { }
        //}
        //Amount = Math.Round(Amount, 0);
        //txtPrintingCharge.Text = Amount.ToString("0.00");
        //txtPrintingCharge25Per.Text = Math.Round(((Amount * 25) / 100), 0).ToString("0.00");
        //txtPrintingCharge75Per.Text = Math.Round(((Amount * 75) / 100), 0).ToString("0.00");
        //OnLoad();

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPages_N = (e.Row.FindControl("lblPages_N") as Label);
            TextBox txtBlankPages = (e.Row.FindControl("txtBlankPages") as TextBox);
            Label lblPayablePages = (e.Row.FindControl("lblPayablePages") as Label);

            if (int.Parse(txtBlankPages.Text != "" ? txtBlankPages.Text : "0") > 0)
            {
                lblPayablePages.Text =Convert.ToString ( (Convert.ToInt32 (Math.Round (Convert.ToDecimal(lblPages_N.Text)) - Convert.ToInt32 (Math.Round (Convert.ToDecimal(txtBlankPages.Text)))) )) + "+" + txtBlankPages.Text;
            }
            else
            {
                lblPayablePages.Text = lblPages_N.Text;
            }
        }
    }
    public void CalAmt()
            {
        try
        {
            double Amount = 0; string ChalanNo = ""; string TitleID_I = ""; double Badprinperc = 0; double per = 0;
            foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
            {
                Label lblAmount = (Label)gv.FindControl("lblAmount");
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                HiddenField hdChalanNo = (HiddenField)gv.FindControl("hdChalanNo");
                Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                TextBox tBadPrintPen_grd = (TextBox)gv.FindControl("txtBadPrintPen_grd");

                try{
                    per = (double.Parse(tBadPrintPen_grd.Text) * double.Parse(lblAmount.Text != "" ? lblAmount.Text : "0")) / 100;
                }catch{}
                
                try
                {
                    if (chkSelect.Checked == true)
                    {
                        if (lblAmount.Text == "")
                        {
                            lblAmount.Text = "0";
                        }
                        Amount = Amount + float.Parse(lblAmount.Text);
                        ChalanNo += hdChalanNo.Value + ",";
                        TitleID_I += lblTitleID_I.Text + ",";
                        Badprinperc = Badprinperc + per;
                    }
                }
                catch { }

            }
            Amount = Math.Round(Amount,0);
            txtPrintingCharge.Text = Amount.ToString("0.00");
            txtPrintingCharge25Per.Text = Math.Round(((Amount * 25) / 100),0).ToString("0.00");
            txtPrintingCharge75Per.Text =Math.Round( ((Amount * 75) / 100),0).ToString("0.00");
            txt2PerInComeTAX.Text = Math.Ceiling(((Convert.ToDouble(txtPrintingCharge.Text) * 2) / 100)).ToString("0.00");
            Badprinperc = Math.Round(Badprinperc,0);
            if (rdIn.Checked==true)
            { 
                string  odd1; 
                odd1= Math.Round((float.Parse(txt2PerInComeTAX.Text) % 2)).ToString("0");

                if (odd1 == "1")
                {


                    txt2PerTDSGST.Text = Math.Floor(((Convert.ToDouble(txtPrintingCharge.Text) * 1) / 100)).ToString("0.00");
                    txt2PerTDSCGST.Text = Math.Ceiling(((Convert.ToDouble(txtPrintingCharge.Text) * 1) / 100)).ToString("0.00");
                }
                else 
                {

                    txt2PerTDSGST.Text = Math.Ceiling(((Convert.ToDouble(txtPrintingCharge.Text) * 1) / 100)).ToString("0.00");
                    txt2PerTDSCGST.Text = Math.Ceiling(((Convert.ToDouble(txtPrintingCharge.Text) * 1) / 100)).ToString("0.00");
                }
            }
                    
            else
            {
                txt2PerTDSGST.Text = Math.Ceiling(((Convert.ToDouble(txtPrintingCharge.Text) * 2) / 100)).ToString("0.00");
           // txt2PerTDSGST.Text = "0";
            txt2PerTDSCGST.Text = "0";            
            }
            txtBadPrinting.Text = Badprinperc.ToString("0.00");

            //calculate interest chalan wise - 8/5/2017
            if (ChalanNo.Length > 0)
            {
                ChalanNo = ChalanNo.Substring(ChalanNo.Length - (ChalanNo.Length), (ChalanNo.Length - 1));
                txtPaperInterest.Text = CalInterest(ChalanNo);
                txtDepotExpenditure.Text = CalDepoExpenditure(ChalanNo);
            }
                txtShortSizeBookDeduction.Text = CallKatotra(ChalanNo);

                if (TitleID_I.Length > 0)
                {
                    TitleID_I = TitleID_I.Substring(TitleID_I.Length - (TitleID_I.Length), (TitleID_I.Length - 1));
                }
            //CalBadPrintingAndMistakes(TitleID_I, TitleID_I!= ""?"0":"1");

            OnLoad();
        }
        catch { }
    }

    public string CalInterest(string chalanno)
    {
        objBillDetails = new Pri_BillDetails_New();
        //1 - interest, 2 - depoexpenditure
        string res = "0";
        //DataTable Dt = obCommonFuction.FillTableByProc("SELECT PriTransID,AcYear,ChalanNo,PaperQuantity,BillAmount FROM pri_BillCalculationDetail WHERE FIND_IN_SET(chalanno,'" + chalanno + "') and printerid='"+ddlPrinter.SelectedValue+"'");
        objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
        DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',1,'" + objBillDetails.ChallanRecDate_D  + "')");
        if(Dt.Rows.Count > 0)
        {
            try{
               res = Dt.Compute("Sum(BillAmount)", "").ToString();
            }catch{}
            
        }
        return res;
    }

    public string CalDepoExpenditure(string chalanno)
    {
        //1 - interest, 2 - depoexpenditure
        string res = "0";
        DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',2,'" + DateTime.Parse(txtChalanrecDate.Text, cult) + "')");
        if (Dt.Rows.Count > 0)
        {
            try
            {
                res = Dt.Compute("Sum(dDedDepoExp_N)", "").ToString();
            }
            catch { }

        }
        return res;
    }

    public string CalIDepoExpenditure(string printerid, string chalanno)
    {
        //1 - interes, 2 - depoexpenditure
        string res = "0";
        DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',2,'" + DateTime.Parse(txtChalanrecDate.Text, cult) + "')");
        if (Dt.Rows.Count > 0)
        {
            try
            {
                res = Dt.Rows[0][0].ToString();
            }
            catch { }

        }
        return res;
    }

    public void CalBadPrintingAndMistakes(string titleid, string mType)
    {
        //1 - interest, 2 - depoexpenditure
        string res = "0";
        DataTable Dt = obCommonFuction.FillTableByProc("call USP_Penalty_badprinting_Show('" + DdlACYear.SelectedItem.Text + "','" + ddlPrinter.SelectedValue + "','" + DateTime.Parse(txtChalanrecDate.Text, cult).ToString("dd/MM/yyyy") + "','"+titleid+"','"+mType+"')");
        if (Dt.Rows.Count > 0)
        {
            try
            {
                txtBadPrinting.Text = Math.Ceiling(float.Parse(Dt.Rows[0][0].ToString())).ToString();
                txtPrintingMistakes.Text = Math.Ceiling(float.Parse(Dt.Rows[0][1].ToString())).ToString();
            }
            catch { }

        }
        else
        {
            txtBadPrinting.Text ="0";
            txtPrintingMistakes.Text = "0";
        }
        
    }

    public string CallKatotra(string chalanno)
    {
        //1 - interes, 2 - depoexpenditure
        string res = "0";
        DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',3,'" + DateTime.Parse(txtChalanrecDate.Text, cult) + "')");
        if (Dt.Rows.Count > 0)
        {
            try
            {
                res = Dt.Rows[0][0].ToString();
            }
            catch { }

        }
        return res;
    }

    public void isEmpty()
    {
        if (txt2PerInComeTAX.Text == "")
        {
            txt2PerInComeTAX.Text = "0"; txt2PerTDSGST.Text = "0"; txt2PerTDSCGST.Text="0"; 
        }
        
        if (txtBalancePaperSecurityReimbursed.Text == "")
        { txtBalancePaperSecurityReimbursed.Text = "0"; }
        if (txtBFPay.Text == "")
        { txtBFPay.Text = "0"; }
        if (txtBillAmount.Text == "")
        { txtBillAmount.Text = "0"; }

        if (txtBillAmountofDeduction.Text == "")
        { txtBillAmountofDeduction.Text = "0"; }
        if (txtBillNetPayablePrinting.Text == "")
        { txtBillNetPayablePrinting.Text = "0"; }
        if (txtDeductionPaperSecurity.Text == "")
        { txtDeductionPaperSecurity.Text = "0"; }
        if (txtDelaySupplyPenalty.Text == "")
        { txtDelaySupplyPenalty.Text = "0"; }
        if (txtDepotExpenditure.Text == "")
        { txtDepotExpenditure.Text = "0"; }
        if (txtNetPayable.Text == "")
        { txtNetPayable.Text = "0"; }


        if (txtPaperInterest.Text == "")
        { txtPaperInterest.Text = "0"; }
        if (txtPaperSecurityDeposit.Text == "")
        { txtPaperSecurityDeposit.Text = "0"; }
        if (txtPaperSecurityFor.Text == "")
        { txtPaperSecurityFor.Text = "0"; }
        if (txtPaperSecurityReimbursed.Text == "")
        { txtPaperSecurityReimbursed.Text = "0"; }
        if (txtPayBlePrintingCharg.Text == "")
        { txtPayBlePrintingCharg.Text = "0"; }
        if (txtPrintingCharge.Text == "")
        { txtPrintingCharge.Text = "0"; }


        if (txtPrintingCharge25Per.Text == "")
        { txtPrintingCharge25Per.Text = "0"; }
        if (txtPrintingCharge75Per.Text == "")
        { txtPrintingCharge75Per.Text = "0"; }
        if (txtReemPaperRs.Text == "")
        { txtReemPaperRs.Text = "0"; }
        if (txtReimburseAmount.Text == "")
        { txtReimburseAmount.Text = "0"; }
        if (txtRs2.Text == "")
        { txtRs2.Text = "0"; }
        if (txtRs3.Text == "")
        { txtRs3.Text = "0"; }

        if (txtShortSizeBookDeduction.Text == "")
        { txtShortSizeBookDeduction.Text = "0"; }
        if (txtTonsPerReem.Text == "")
        { txtTonsPerReem.Text = "0"; }
        if (txtTotalCoverPaperSupply.Text == "")
        { txtTotalCoverPaperSupply.Text = "0"; }
        if (txtTotalDeduction.Text == "")
        { txtTotalDeduction.Text = "0"; }


        if (txtTotalPaperSupply.Text == "")
        { txtTotalPaperSupply.Text = "0"; }
        if (txtTotalPaybleAmount.Text == "")
        { txtTotalPaybleAmount.Text = "0"; }

        if (txtOtherDedAmt.Text == "")
        { txtOtherDedAmt.Text = "0"; }

        if (txtAmtReturnToPrinter.Text == "")
        { txtAmtReturnToPrinter.Text = "0"; }

    }
    protected void btnForward_Click(object sender, EventArgs e)
    {
        objBillDetails = new Pri_BillDetails_New();

        objBillDetails.Billno_V = txtBillNo.Text;
        objBillDetails.BillDate_D = DateTime.Parse(txtBillDate.Text, cult);
        objBillDetails.ChallanRecDate_D  = DateTime.Parse( DateTime.Parse(txtChalanrecDate.Text, cult).ToString("yyyy-MM-dd"));
        objBillDetails.PrinterID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
        objBillDetails.TotalPaperSup_N = float.Parse(txtTotalPaperSupply.Text);
        objBillDetails.TotCovPaperSup_N = float.Parse(txtTotalCoverPaperSupply.Text);
        objBillDetails.PapSecReimburse_N = float.Parse(txtPaperSecurityReimbursed.Text);
        objBillDetails.PaperSecurityDeposit = float.Parse(txtPaperSecurityDeposit.Text);
        objBillDetails.BalSecurity_N = float.Parse(txtBalancePaperSecurityReimbursed.Text);
        objBillDetails.PrnChrg100per_N = float.Parse(txtPrintingCharge.Text);
        objBillDetails.PrnChrg25per_N = float.Parse(txtPrintingCharge25Per.Text);
        objBillDetails.PrnChrg75per_N = float.Parse(txtPrintingCharge75Per.Text);
        objBillDetails.PaperSecforton_N = float.Parse(txtPaperSecurityFor.Text);
        objBillDetails.PaperReemRs_N = float.Parse(txtReemPaperRs.Text);
        objBillDetails.TonsPerReem_N = float.Parse(txtTonsPerReem.Text);
        objBillDetails.Reimburseamt_N = float.Parse(txtReimburseAmount.Text);
        objBillDetails.PayablePrnchrg_N = float.Parse(txtTotalPaybleAmount.Text);
        objBillDetails.Totalpayable_N = float.Parse(txtTotalPaybleAmount.Text);
        objBillDetails.BFPay = float.Parse(txtBFPay.Text);
        objBillDetails.DedIncometax_N = float.Parse(txt2PerInComeTAX.Text);
        objBillDetails.TDSonGST = float.Parse(txt2PerTDSGST.Text);
        objBillDetails.DedpapSec_N = float.Parse(txtDeductionPaperSecurity.Text);
        objBillDetails.DedDepoExp_N = float.Parse(txtDepotExpenditure.Text);
        objBillDetails.DedInterestonpaper_N = float.Parse(txtPaperInterest.Text);
        objBillDetails.PenDelaySup_N = float.Parse(txtDelaySupplyPenalty.Text);
        objBillDetails.DedShotSizePaper1_N = float.Parse(txtShortSizeBookDeduction.Text);
        objBillDetails.DedShotSizePaper2_N = float.Parse(txtRs2.Text);
        objBillDetails.DedShotSizePaper3_N = float.Parse(txtRs3.Text);
        objBillDetails.TotalDed_N = float.Parse(txtTotalDeduction.Text);
        objBillDetails.NetPayable_N = float.Parse(txtNetPayable.Text);
        objBillDetails.BillAmount = 0;
        objBillDetails.BillAmountofDeduction = 0;
        objBillDetails.BillNetPayablePrinting = 0;

        //change 792017- add acedamic year in pri bill table in AccHRID field
        //objBillDetails.JobCode_V = "";
        objBillDetails.JobCode_V = DdlACYear.SelectedValue;

        objBillDetails.OtherDedAmount_N = float.Parse(txtOtherDedAmt.Text);
        objBillDetails.OtherDed_V = txtOtherDedDescription.Text;

        //Add new fields - 14917
        objBillDetails.BadPrinting_N = float.Parse(txtBadPrinting.Text);
        objBillDetails.PrintingMistakes_N = float.Parse(txtPrintingMistakes.Text);
        objBillDetails.Lamination_N = float.Parse(txtLamination.Text);
        objBillDetails.PerfectBinding_N= float.Parse(txtPerfectBinding.Text);
        objBillDetails.LooseBundlePack_N = float.Parse(txtLooseBundlePack.Text);
        objBillDetails.TransportationDelvryChrg_N = float.Parse(txtTransportationDelvry.Text);
        objBillDetails.GSTAmt_N = float.Parse(lblGSTAmt.Text != ""?lblGSTAmt.Text:"0");
        objBillDetails.AmtReturnToPrinter_N = float.Parse(txtAmtReturnToPrinter.Text);
        objBillDetails.TotAmtPayableWithGST_N = float.Parse(txtTotalPayableWithGST.Text);
        //ajay
        objBillDetails.TDSonSGST  = float.Parse(txt2PerTDSCGST.Text);
         
        objBillDetails.IsStatePrinter = 0;
        if (rdIn.Checked)
        {
            objBillDetails.IsStatePrinter = 1;
        }
        

        if (Request.QueryString["ID"] != null)
        {
            objBillDetails.BillID_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"]).ToString());
        }
        else
        {
            objBillDetails.BillID_I = 0;
        }

        if (Request.QueryString["ID"] != null)
        {
            int i = objBillDetails.MasterUpdate();
            if (i > 0)
            {
                string CheckSts = "No";
                objBillDetails.BillDetID_I = -1;
                i = objBillDetails.ChildInsertDelete();
                foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
                {
                     CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                     if (chkSelect.Checked == true)
                     {
                         Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                         Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
                          TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");
                         Label lblBillDetID_I = (Label)gv.FindControl("lblBillDetID_I");
                         Label lblPages_N = (Label)gv.FindControl("lblPages_N");
                         Label lblAmount = (Label)gv.FindControl("lblAmount");
                         Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
                         TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");
                         TextBox txtLibBook = (TextBox)gv.FindControl("txtLibBook");
                         TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
                         TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");
                         HiddenField hdPriTransID = (HiddenField)gv.FindControl("hdPriTransID");

                         TextBox txtBadPrintPen_grd = (TextBox)gv.FindControl("txtBadPrintPen_grd");
                         HiddenField hdnGrpno_V = (HiddenField)gv.FindControl("hdnGrpno_V");

                         if (txtBadPrintPen_grd.Text == "")
                         { txtBadPrintPen_grd.Text = "0"; }

                         if (txtPaperConsum_Wastage_N.Text == "")
                         { txtPaperConsum_Wastage_N.Text = "0"; }

                         if (txtCoverPaperConsum_Wastage_N.Text == "")
                         { txtCoverPaperConsum_Wastage_N.Text = "0"; }

                         if (txtBlankPages.Text == "")
                         { txtBlankPages.Text = "0"; }

                         if (lblTotalBlankPages_N.Text == "")
                         { lblTotalBlankPages_N.Text = "0"; }
                         if (lblAmount.Text == "")
                         { lblAmount.Text = "0"; }
                         objBillDetails.Depotid_I = 0;
                         objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
                         objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
                         objBillDetails.mLibraryBook = int.Parse(txtLibBook.Text);
                         objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
                         objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
                         objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
                         objBillDetails.Amount_N = float.Parse(lblAmount.Text);
                         objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
                         objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
                         //objBillDetails.BillID_I = 0;
                         objBillDetails.BillDetID_I = int.Parse(lblBillDetID_I.Text);
                         objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);
                         objBillDetails.PriTransID =  hdPriTransID.Value ;

                         objBillDetails.BadPrintingPerc_N = float.Parse(txtBadPrintPen_grd.Text);
                         objBillDetails.Grpno_V = hdnGrpno_V.Value;
                         HiddenField HiddenBookType = (HiddenField)gv.FindControl("HiddenBookType");
                         objBillDetails.mBookType = int.Parse(HiddenBookType.Value);
                         objBillDetails.ChildInsertUpdate();
                         CheckSts = "Ok";
                     }
                }
                if (CheckSts == "Ok")
                {
                    try
                    {
                        // update entry in hr_voucher detail table - 6/9/2017
                        fnSaveHRVoucherDetail(objBillDetails.BillID_I, 1);
                    }
                    catch { }
                }
                if (CheckSts == "Ok")
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    Response.Redirect("ViewBillDetails.aspx");
                    obCommonFuction.EmptyTextBoxes(this);
                    isEmpty();
                    GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
                    GrdPaperCoverAndPrintingChares.DataBind();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record updated successfully.');", true);
                }

            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Not Changed.');</script>");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record Not Changed.');", true);
            }
        }
        else
        {
            int i = objBillDetails.InsertUpdate();
            

            if (i > 0)
            {

//                string prinbillxml = @"<DocumentElement>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>P1</TPPDCOLID>
//                        <TPPDTEXT>Total Printing Charges</TPPDTEXT>" +
//                          "<TPPDVALUE>" + txtNetPayable.Text + "</TPPDVALUE>"
//                        + @"</TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>P2</TPPDCOLID>
//                        <TPPDTEXT>Deduct wilhheld(25% of printing charges)</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>P3</TPPDCOLID>
//                        <TPPDTEXT>Printing Security reimbursed</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>P4</TPPDCOLID>
//                        <TPPDTEXT>Paper Security reimbursed</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>P5</TPPDCOLID>
//                        <TPPDTEXT>Net Printing Charge Payable</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>P6</TPPDCOLID>
//                        <TPPDTEXT>Total Amount Payable</TPPDTEXT>
//                        <TPPDVALUE>1850</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D1</TPPDCOLID>
//                        <TPPDTEXT> Withheld 2% regarding income Tax on Rs</TPPDTEXT>
//                        <TPPDVALUE>40</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D2</TPPDCOLID>
//                        <TPPDTEXT> Deduction against paper security</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D3</TPPDCOLID>
//                        <TPPDTEXT> Depot Expenditure on behalf of printer</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D4</TPPDCOLID>
//                        <TPPDTEXT> Interest on Paper</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D5</TPPDCOLID>
//                        <TPPDTEXT> Penalty for delay in supply of books</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D6</TPPDCOLID>
//                        <TPPDTEXT> Deduction of paper cost  against short size of books</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D7</TPPDCOLID>
//                        <TPPDTEXT> Total Deductions</TPPDTEXT>
//                        <TPPDVALUE>0</TPPDVALUE>
//                      </TPPDDETAIL>
//                      <TPPDDETAIL>
//                        <TPPDCOLID>D8</TPPDCOLID>
//                        <TPPDTEXT>Net Payable Rs   (A-B)</TPPDTEXT>" +
//                         " <TPPDVALUE>" + txtNetPayable.Text + "</TPPDVALUE></TPPDDETAIL> </DocumentElement>";


//                string Bankxml = @"<DocumentElement>
//                      <BANKDETAIL>
//                        <BANKLEDGERID>44ad170e-8fdd-4146-960b-f91fdd7922b2</BANKLEDGERID>
//                        <CHEQUENO>000000</CHEQUENO>
//                      </BANKDETAIL>
//                    </DocumentElement>";

//                CommonFuction obCommonFuction = new CommonFuction();
              
                
                //YojnaTBC.YF_WebServiceSoapClient oYF_WebService = new YojnaTBC.YF_WebServiceSoapClient();
                //DataSet ds = obCommonFuction.FillDatasetByProc("call GetPrinterDetailsByID(" + ddlPrinter.SelectedItem.Value + ")");
                //var workorder = "W-1234";
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    var w = oYF_WebService.SavePrintingBillPayment(Guid.NewGuid().ToString(), workorder, Convert.ToString(ds.Tables[0].Rows[0]["hrid"]), txtBillNo.Text, "2015-07-01", prinbillxml, "4421A9B1-067D-4BBD-99C5-C398DF41588A", "85C61553-38C1-4A63-AB78-C647DBC22937", "2015-07-01", "4421A9B1-067D-4BBD-99C5-C398DF41588A", "", "2015-07-01", Bankxml, null, null, "1");

                //}



                ViewState["BillID_I"] = i.ToString();
                string CheckSts = "No";
                foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
                {
                    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                    if (chkSelect.Checked == true)
                    {
                        Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
                        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
                         TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");

                        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
                        Label lblAmount = (Label)gv.FindControl("lblAmount");
                        TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
                        TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");
                        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
                        TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");
                        HiddenField hdPriTransID = (HiddenField)gv.FindControl("hdPriTransID");
                        TextBox txtLibBook = (TextBox)gv.FindControl("txtLibBook");

                        TextBox txtBadPrintPen_grd = (TextBox)gv.FindControl("txtBadPrintPen_grd");
                        HiddenField hdnGrpno_V = (HiddenField)gv.FindControl("hdnGrpno_V");

                        if (txtBadPrintPen_grd.Text == "")
                        { txtBadPrintPen_grd.Text = "0"; }

                        if (txtPaperConsum_Wastage_N.Text == "")
                        { txtPaperConsum_Wastage_N.Text = "0"; }

                        if (txtCoverPaperConsum_Wastage_N.Text == "")
                        { txtCoverPaperConsum_Wastage_N.Text = "0"; }
                        if (lblAmount.Text == "")
                        { lblAmount.Text = "0"; }

                        if (txtBlankPages.Text == "")
                        { txtBlankPages.Text = "0"; }

                        if (lblTotalBlankPages_N.Text == "")
                        { lblTotalBlankPages_N.Text = "0"; }

                        objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
                        objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
                        objBillDetails.Depotid_I = 0;
                        objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
                        objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
                        objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
                        objBillDetails.Amount_N = float.Parse(lblAmount.Text);
                        objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
                        objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
                        objBillDetails.BillID_I = i;
                        objBillDetails.BillDetID_I = 0;
                        objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);
                        objBillDetails.PriTransID = hdPriTransID.Value ;
                        objBillDetails.mLibraryBook = int.Parse(txtLibBook.Text);

                        objBillDetails.BadPrintingPerc_N = float.Parse(txtBadPrintPen_grd.Text);
                        objBillDetails.Grpno_V = hdnGrpno_V.Value;
                        HiddenField HiddenBookType = (HiddenField)gv.FindControl("HiddenBookType");
                        objBillDetails.mBookType = int.Parse(HiddenBookType.Value);
                        objBillDetails.ChildInsertUpdate();
                        CheckSts = "Ok";
                    }
                }

                if (CheckSts == "Ok")
                {
                    try
                    {
                        // save entry in hr_voucher detail table - 6/9/2017
                        fnSaveHRVoucherDetail(objBillDetails.BillID_I,0);
                    }
                    catch { }
                }

                if (CheckSts == "Ok")
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    obCommonFuction.EmptyTextBoxes(this);
                    isEmpty();
                    GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
                    GrdPaperCoverAndPrintingChares.DataBind();
                    lblFinanceMsg.Text = "Record saved successfully! Do You Want To Send Finance Department.";
                    btnSendToFinance.Visible = true;
                    lblFinanceMsg.Visible = true;
                    btnForward.Visible = false;
                   // pnlFinance.Visible = true;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record saved successfully.');", true);
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Check Your Entry');</script>");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please Check Your Entry');", true);
                   
                }
            }
        }
    }

    private void fnSaveHRVoucherDetail(int BillID_I, int TransId)
    {
        try
        {
            string strLedgerId = "";
            DataSet Vo = obCommonFuction.FillDatasetByProc("call USP_HR_GetVoucherNo('j')");
            string VoNo = Vo.Tables[0].Rows[0]["Voucher"].ToString().ToUpper();

            //update hr voucher detail
            if (TransId > 0)
            {
                DataTable dtt = obCommonFuction.FillTableByProc("CALL USP_Hr_PRIAccountVchrDelete('" + BillID_I.ToString() + "','Printing Charges')");
                TransId = dtt.Rows.Count > 0 ? int.Parse(dtt.Rows[0][0].ToString()) : 0;
                //if (TransId == 0) return;
            }

            /********************Debit****************************/
            //-- 100% Printing Changes Book  (Total 100% Printing Charges Rs)
            DataSet LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('130')");
            strLedgerId = LedgerID.Tables[0].Rows[0]["LedgerID"].ToString();
            
            DataTable dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0,0," + float.Parse(txtPrintingCharge.Text) + ","+
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "',"+
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "',"+
            " '" + strLedgerId + "','" + VoNo + "',1,0,'" + BillID_I.ToString() + "')");


            /********************Credit****************************/
            //-- 75% net amount - Printer Name ((c) Net payable Rs)
           string printerName = "M/s " + ddlPrinter.SelectedItem.Text;
           DataSet LedgerID11 = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyName('" + printerName + "')");
           strLedgerId = LedgerID11.Tables[0].Rows.Count > 0 ? LedgerID11.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txtBillNetPayablePrinting.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txtBillNetPayablePrinting.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }

           //-- I.Tax Deduction  (Withheld 2% regarding income Tax on Rs.)         
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('35')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txt2PerInComeTAX.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txt2PerInComeTAX.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }

           //-- Interest on Paper (Interest on Paper)        
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('1471')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txtPaperInterest.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txtPaperInterest.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }

           //--  Depo expenditure (Depot Expenditure on behalf of Printer)        
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('369')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txtDepotExpenditure.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txtDepotExpenditure.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }

           //--  Paper Security (Deduction against paper security)
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('1465')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txtDeductionPaperSecurity.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txtDeductionPaperSecurity.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");              
           }

           //--  Penalty (Penalty for Delay supply of Books)     
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('267')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txtDelaySupplyPenalty.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txtDelaySupplyPenalty.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }

           //--  Paper size (Deduction of Paper cost of against short size of Books)    
           //LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyName('Paper Size')");
           //strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           //if (strLedgerId != "")
           //{
           //    dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
           // "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse("0") + ",0," +
           // "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
           // "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
           // " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           //}

           //--  Other Deduction
           double dblOtherdeduction = float.Parse(txtOtherDedAmt.Text) + float.Parse(txtShortSizeBookDeduction.Text)+float.Parse(txtBadPrinting.Text)
                 +float.Parse(txtPrintingMistakes.Text)+float.Parse(txtLamination.Text)+float.Parse(txtPerfectBinding.Text)+float.Parse(txtLooseBundlePack.Text)
                 +float.Parse(txtTransportationDelvry.Text);
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyName('other Deduction')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && dblOtherdeduction>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + dblOtherdeduction + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }

           //--  Printing Charges Payable  - 25%     
           LedgerID = obCommonFuction.FillDatasetByProc("CALL USP_hr_GetledgerIDbyID('14')");
           strLedgerId = LedgerID.Tables[0].Rows.Count > 0 ? LedgerID.Tables[0].Rows[0]["LedgerID"].ToString() : "";
           if (strLedgerId != "" && float.Parse(txtPrintingCharge25Per.Text)>0)
           {
               dtRes = obCommonFuction.FillTableByProc("call  USP_Hr_PRIAccountVchrSave('JOURNAL'," +
            "'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "','Printing Charges',0," + float.Parse(txtPrintingCharge25Per.Text) + ",0," +
            "'Cash','0','','" + Convert.ToDateTime(txtBillDate.Text, cult).ToString("yyyy-MM-dd") + "'," +
            "'" + Session["UserID"] + "','Depo','" + obCommonFuction.GetFinYearNew() + "'," +
            " '" + strLedgerId + "','" + VoNo + "',2,0,'" + BillID_I.ToString() + "')");
           }
        }
        catch { }

    }

    protected void btnSendToFinance_Click(object sender, EventArgs e)
    {
        objBillDetails = new Pri_BillDetails_New();
        objBillDetails.BillID_I = int.Parse(ViewState["BillID_I"].ToString());
        int i = objBillDetails.SendToFinance();
        if (i > 0)
        {
            string prinbillxml = @"<DocumentElement>
                      <TPPDDETAIL>
                        <TPPDCOLID>P1</TPPDCOLID>
                        <TPPDTEXT>Total Printing Charges</TPPDTEXT>" +
                         "<TPPDVALUE>" + txtNetPayable.Text + "</TPPDVALUE>"
                       + @"</TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>P2</TPPDCOLID>
                        <TPPDTEXT>Deduct wilhheld(25% of printing charges)</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>P3</TPPDCOLID>
                        <TPPDTEXT>Printing Security reimbursed</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>P4</TPPDCOLID>
                        <TPPDTEXT>Paper Security reimbursed</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>P5</TPPDCOLID>
                        <TPPDTEXT>Net Printing Charge Payable</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>P6</TPPDCOLID>
                        <TPPDTEXT>Total Amount Payable</TPPDTEXT>
                        <TPPDVALUE>1850</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D1</TPPDCOLID>
                        <TPPDTEXT> Withheld 2% regarding income Tax on Rs</TPPDTEXT>
                        <TPPDVALUE>40</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D2</TPPDCOLID>
                        <TPPDTEXT> Deduction against paper security</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D3</TPPDCOLID>
                        <TPPDTEXT> Depot Expenditure on behalf of printer</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D4</TPPDCOLID>
                        <TPPDTEXT> Interest on Paper</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D5</TPPDCOLID>
                        <TPPDTEXT> Penalty for delay in supply of books</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D6</TPPDCOLID>
                        <TPPDTEXT> Deduction of paper cost  against short size of books</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D7</TPPDCOLID>
                        <TPPDTEXT> Total Deductions</TPPDTEXT>
                        <TPPDVALUE>0</TPPDVALUE>
                      </TPPDDETAIL>
                      <TPPDDETAIL>
                        <TPPDCOLID>D8</TPPDCOLID>
                        <TPPDTEXT>Net Payable Rs   (A-B)</TPPDTEXT>" +
                        " <TPPDVALUE>" + txtNetPayable.Text + "</TPPDVALUE></TPPDDETAIL> </DocumentElement>";


            string Bankxml = @"<DocumentElement>
                      <BANKDETAIL>
                        <BANKLEDGERID>44ad170e-8fdd-4146-960b-f91fdd7922b2</BANKLEDGERID>
                        <CHEQUENO>000000</CHEQUENO>
                      </BANKDETAIL>
                    </DocumentElement>";

            CommonFuction obCommonFuction = new CommonFuction();
           
         //   YojnaTBC.YF_WebServiceSoapClient oYF_WebService = new YojnaTBC.YF_WebServiceSoapClient();
            DataSet ds = obCommonFuction.FillDatasetByProc("call GetPrinterDetailsByID(" + ddlPrinter.SelectedItem.Value + ")");
            var workorder = "W-1234";
            if (ds.Tables[0].Rows.Count > 0)
            {
                // oYF_WebService.SavePrintingBillPayment(Guid.NewGuid().ToString(), "nill", Convert.ToString(ds.Tables[0].Rows[0]["hrid"]), txtBillNo.Text, txtBillDate.Text, prinbillxml, "0CFB0DB0-316E-4CC4-97B9-C302E94D1C4B", "0CFB0DB0-316E-4CC4-97B9-C302E94D1C4B", System.DateTime.Now.ToString(), "0CFB0DB0-316E-4CC4-97B9-C302E94D1C4B", "", System.DateTime.Now.ToString(), Bankxml, null, null, "0");

               // var w = oYF_WebService.SavePrintingBillPayment(Guid.NewGuid().ToString(), workorder, Convert.ToString(ds.Tables[0].Rows[0]["hrid"]), txtBillNo.Text, "2015-07-01", prinbillxml, "4421A9B1-067D-4BBD-99C5-C398DF41588A", "85C61553-38C1-4A63-AB78-C647DBC22937", "2015-07-01", "4421A9B1-067D-4BBD-99C5-C398DF41588A", "", "2015-07-01", Bankxml, null, null, "1");

            }
            Response.Redirect("ViewBillDetails.aspx");
        }
    }

    public void GSTCalc()
    {
        float fivepercent = float.Parse("5")/105; //(perc = 5/105 -- 2118)
        float netPayable = 0, depoexpenditure = 0; float netpaybal_75perc = 0; float gstpercent = float.Parse("0.024");
        float totgstamt = 0;
        try
        {
            netPayable = float.Parse(txtBillNetPayablePrinting.Text);
        }
        catch { }
        try
        {
            depoexpenditure = float.Parse(txtDepotExpenditure.Text != ""?txtDepotExpenditure.Text:"0");
        }
        catch { }

        try
        {
            netpaybal_75perc = float.Parse(txtPrintingCharge.Text != "" ? txtPrintingCharge.Text : "0");
            lblOutgst.Text = Math.Round(((netpaybal_75perc) * fivepercent)).ToString("0.00");
            hdngst_out.Value = lblOutgst.Text;

            string  odd1; 
                odd1= Math.Round((float.Parse(lblOutgst.Text) % 2)).ToString("0");

                if (odd1 == "1")
                {

                    //lblIngst_c.Text = Math.Ceiling(((netpaybal_75perc) * gstpercent)).ToString("0.00");
                    //lblIngst_s.Text = Math.Ceiling(((netpaybal_75perc) * gstpercent)).ToString("0.00");

                lblIngst_c.Text = Math.Ceiling((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                lblIngst_s.Text = Math.Floor((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                }
                else
                {
                    lblIngst_c.Text = Math.Floor((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                    lblIngst_s.Text = Math.Floor((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                }
            hdngst.Value = (float.Parse(lblIngst_c.Text) + float.Parse(lblIngst_s.Text)).ToString("0.00"); 

            if (rdOut.Checked)
            {
              totgstamt = float.Parse(lblOutgst.Text);                
            }
            else if (rdIn.Checked)
            {
               totgstamt = float.Parse(lblIngst_c.Text) + float.Parse(lblIngst_s.Text);
                
            }
        }
        catch { }

        //change - gst for state and non-state printers
        //lblGSTAmt.Text = Math.Ceiling(((netPayable + depoexpenditure)*fivepercent)).ToString("0.00");
        if (rdOut.Checked)
        {
            lblGSTAmt.Text = hdngst_out.Value;
        }
        else if (rdIn.Checked)
        {
            lblGSTAmt.Text = hdngst.Value;

        }
        //lblGSTAmt.Text = totgstamt.ToString("0.00");
        txtGST.Text = lblGSTAmt.Text;
        //txtTotalPayableWithGST.Text = Math.Ceiling((float.Parse(txtGST.Text) + float.Parse(txtBillNetPayablePrinting.Text))).ToString("0.00");
        txtTotalPayableWithGST.Text = Math.Ceiling((float.Parse(txtGST.Text) + float.Parse(txtBillNetPayablePrinting.Text)+ float.Parse(txtAmtReturnToPrinter.Text))).ToString("0.00");

        //change 912018 - substract gst with totalamount payable
        float PrintingCharge75Per = 0; float Totamt = 0; float gstamt = 0;
        try
        {
            PrintingCharge75Per = float.Parse(txtPrintingCharge75Per.Text);
            gstamt = float.Parse(lblGSTAmt.Text);
            Totamt = PrintingCharge75Per - gstamt;
        }
        catch { }
        txtTotalPaybleAmount.Text = Totamt.ToString("0.00");
        TotDeduction();

         float gstTotalpayablewithgst = float.Parse(txtTotalPayableWithGST.Text);
         float netamt = float.Parse(txtBillNetPayablePrinting.Text) + float.Parse(lblGSTAmt.Text) + float.Parse(txtAmtReturnToPrinter.Text);
         txtTotalPayableWithGST.Text = netamt.ToString("0.00");
        
    }

    public void AmtCalPaper()
    {
        float perSecAmt = 0, perSecRemin = 0;
        try
        {
            perSecAmt = float.Parse(txtPaperSecurityDeposit.Text);
        }
        catch { }
        try
        {
            perSecRemin = float.Parse(txtPaperSecurityReimbursed.Text);
        }
        catch { }

        txtBalancePaperSecurityReimbursed.Text = (perSecAmt - perSecRemin).ToString("0.00");
    }
    public void OnLoad()
    {
        BillDesctionSection();
        TotDeduction();
        AbCal();
        NetPayDeduction();
        BillAmountCal();
        AmtCalPaper();
        GSTCalc();
    }



    public void BillDesctionSection()
    {
        float PrintingCharge75Per = 0, ReimburseAmount = 0, PayBlePrintingCharg = 0, Totamt = 0;
        try
        {
            PrintingCharge75Per = float.Parse(txtPrintingCharge75Per.Text);
        }
        catch { }

        try
        {
            ReimburseAmount = float.Parse(txtReimburseAmount.Text);
        }
        catch { }

        try
        {
            PayBlePrintingCharg = float.Parse(txtPayBlePrintingCharg.Text);
        }
        catch { }
        try
        {
            //Totamt = PrintingCharge75Per + ReimburseAmount + PayBlePrintingCharg;
            Totamt = PrintingCharge75Per ;
        }
        catch { }

        txtTotalPaybleAmount.Text = Totamt.ToString("0.00");
        TotDeduction();
    }

    public void TotDeduction()
    {
        float PerInComeTAX = 0, PerTDSGST = 0, PerTDSSGST = 0, DeductionPaperSecurity = 0, DepotExpenditure = 0, PaperInterest = 0, DelaySupplyPenalty = 0, ShortSizeBookDeduction = 0, Totamt = 0;
        float badPrinting = 0, PrintingMistakes = 0, Lamination = 0, PerfectBinding = 0, LooseBundlePack = 0, Transportation = 0;
        float OtherDeduction = 0;
        try
        {
            PerInComeTAX = float.Parse(Math.Ceiling(float.Parse(txt2PerInComeTAX.Text)).ToString());
            PerTDSGST = float.Parse( (float.Parse(txt2PerTDSGST.Text)).ToString("0.00"));
            PerTDSSGST = float.Parse((float.Parse(txt2PerTDSCGST.Text)).ToString("0.00"));
        }
        catch { PerInComeTAX = 0; PerTDSGST = 0; PerTDSSGST = 0; }
        try
        {
            DeductionPaperSecurity = float.Parse(txtDeductionPaperSecurity.Text);
        }
        catch { DeductionPaperSecurity = 0; }

        try
        {
            DepotExpenditure = float.Parse(txtDepotExpenditure.Text);
        }
        catch { DepotExpenditure = 0; }
        try
        {
            PaperInterest = float.Parse(txtPaperInterest.Text);
        }
        catch { PaperInterest = 0; }

        try
        {
            DelaySupplyPenalty = float.Parse(txtDelaySupplyPenalty.Text);
        }
        catch { DelaySupplyPenalty = 0; }

        try
        {
            ShortSizeBookDeduction = float.Parse(txtShortSizeBookDeduction.Text);
        }
        catch { ShortSizeBookDeduction = 0; }

        try
        {
            OtherDeduction = float.Parse(txtOtherDedAmt.Text);
        }
        catch { OtherDeduction = 0; }

        try
        {
            badPrinting = float.Parse(txtBadPrinting.Text);
        }
        catch { badPrinting = 0; }

        try
        {
            PrintingMistakes = float.Parse(txtPrintingMistakes.Text);
        }
        catch { PrintingMistakes = 0; }

        try
        {
            Lamination = float.Parse(txtLamination.Text);
        }
        catch { Lamination = 0; }

        try
        {
            PerfectBinding = float.Parse(txtPerfectBinding.Text);
        }
        catch { PerfectBinding = 0; }

        try
        {
            LooseBundlePack = float.Parse(txtLooseBundlePack.Text);
        }
        catch { LooseBundlePack = 0; }

        try
        {
            Transportation = float.Parse(txtTransportationDelvry.Text);
        }
        catch { Transportation = 0; }

        Totamt = PerInComeTAX + PerTDSGST + PerTDSSGST + DeductionPaperSecurity + DepotExpenditure + PaperInterest + DelaySupplyPenalty + ShortSizeBookDeduction + OtherDeduction
                 + badPrinting+PrintingMistakes + Lamination + PerfectBinding + LooseBundlePack + Transportation;

        txtTotalDeduction.Text = Math.Ceiling(Totamt).ToString("0.00");

        AbCal();

    }

    public void AbCal()
    {
        float amt = 0, TotalPayAmt = 0, TotalDeduc = 0;
        try
        {
            TotalPayAmt = float.Parse(txtTotalPaybleAmount.Text);
        }
        catch { }
        try
        {
            TotalDeduc = float.Parse(txtTotalDeduction.Text);
        }
        catch { }
        amt = TotalPayAmt - TotalDeduc;
        txtNetPayable.Text = Math.Ceiling(amt).ToString("0.00");
        NetPayDeduction();

    }

    public void NetPayDeduction()
    {

        txtBillAmountofDeduction.Text = txtNetPayable.Text;
        BillAmountCal();
    }
    public void BillAmountCal()
    {

        txtBillAmount.Text = txtTotalPaybleAmount.Text;
        txtBillAmountofDeduction.Text = txtTotalDeduction.Text;
        txtBillNetPayablePrinting.Text = txtNetPayable.Text;
    }

    protected void txtReimburseAmount_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPrintingCharge75Per_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPayBlePrintingCharg_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txt2PerInComeTAX_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDeductionPaperSecurity_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDepotExpenditure_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPaperInterest_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtDelaySupplyPenalty_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtShortSizeBookDeduction_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtTotalDeduction_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }

    protected void txtOtherDedAmt_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }

    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        txtPrintingCharge.Text = "0";
        txtPrintingCharge25Per.Text = "0";
        txtPrintingCharge75Per.Text = "0";
        txtTotalPaybleAmount.Text = "0";
        txtBillAmount.Text = "0";
        txtBillAmountofDeduction.Text = "0";
        txtBillNetPayablePrinting.Text = "0";
        txtPayBlePrintingCharg.Text = "0";
        txtDepotExpenditure.Text = "0";
        txtPaperInterest.Text = "0";
        txt2PerInComeTAX.Text = "0";
        txt2PerTDSGST.Text = "0";
        txt2PerTDSCGST.Text = "0";
        txtBadPrinting.Text = "0";
        txtPrintingMistakes.Text = "0";
        txtLamination.Text = "0";
        txtLooseBundlePack.Text = "0";
        txtTransportationDelvry.Text = "0";
        txtPerfectBinding.Text = "0";
        CalAmt();
    }

    protected void txtLibBook_TextChanged(object sender, EventArgs e)
    {
//        fn_getPaperTonnageonPaperno(TitleID_I,IFNULL(TotalNoOfBooks,0) ,1)) AS PaperConsum_Wastage_N,
//CAST((fn_getPaperTonnageonPaperno(td.TitleID_I,IFNULL(cd.TotalNoOfBooks,0) ,2)) 
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");

         TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        TextBox blankpages = (TextBox)gv.FindControl("txtBlankPages");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        TextBox txtPapterConsumption = (TextBox)gv.FindControl("txtPapterConsumption");
        TextBox txtCoverPapterConsumption = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
     

        Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");

        float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0, Lib = 0;
        try
        {
            Page = float.Parse(lblPages_N.Text);
        }
        catch { }
        try
        {
           // BlankPage = float.Parse(lblTotalBlankPages_N.Text);
            BlankPage = float.Parse(blankpages.Text);
        }
        catch { }
        TotalPage = Page - BlankPage;



        try
        {
            Qty = float.Parse(lblTotalNoBook.Text);
            Lib = float.Parse(txt.Text);
        }
        catch { Qty = 0; }
        try
        { Rate = float.Parse(lblRate_N.Text); }
        catch { Rate = 0; }
        lblTotalBlankPages_N.Text = ((Qty + Lib) * BlankPage).ToString();

        //Amt = ((Qty + Lib) * Rate * TotalPage) / 8000;
        Amt = ((Qty) * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");

        if (chkSelect.Checked == true)
        {
            try
            {
                CalAmt();
            }
            catch { }
        }
    
        //change 9118 - for library book consumption
        try
        {
            if (txt.Text == "") { txt.Text = "0"; }
                int totbooks = int.Parse((float.Parse(txt.Text) + float.Parse(lblTotalNoBook.Text)).ToString());
                /*DataTable dtt = obCommonFuction.FillTableByProc("SELECT fn_getPaperTonnageonPaperno('"+lblTitleID_I.Text+"',IFNULL('"+totbooks.ToString()+"',0) ,1) PaperConsum_Wastage_N,"+
                       "cast(fn_getPaperTonnageonPaperno('"+lblTitleID_I.Text+"',IFNULL('" + totbooks.ToString() + "',0) ,2) as decimal(18,0)) CoverPaperConsum_Wastage_N");*/
                DataTable dtt = obCommonFuction.FillTableByProc("SELECT CASE WHEN IFNULL(`fn_getPaperTonnageonPrinterMachine`('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1),0)=0 THEN fn_getPaperTonnageonPaperno('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1) ELSE    `fn_getPaperTonnageonPrinterMachine`('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1) END PaperConsum_Wastage_N," +
                           "cast(fn_getPaperTonnageonPaperno('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,2) as decimal(18,0)) CoverPaperConsum_Wastage_N");
                DataTable dtt1 = obCommonFuction.FillTableByProc("SELECT fn_getPaperTonnageonPapernoacb('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1)  PaperConsum_Wastage_N," +
                               "cast(fn_getPaperTonnageonPapernoacb('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,2) as decimal(18,0)) CoverPaperConsum_Wastage_N");
                HiddenField HiddenBookType = (HiddenField)gv.FindControl("HiddenBookType");

                if (HiddenBookType.Value.ToString()  != "1")
                {

                    if (dtt.Rows.Count > 0)
                    {
                        txtPapterConsumption.Text = dtt.Rows[0]["PaperConsum_Wastage_N"].ToString();
                        txtCoverPapterConsumption.Text = dtt.Rows[0]["CoverPaperConsum_Wastage_N"].ToString();
                    }
                }
                else
                {
                    if (dtt1.Rows.Count > 0)
                    {
                        txtPapterConsumption.Text = dtt1.Rows[0]["PaperConsum_Wastage_N"].ToString();
                        txtCoverPapterConsumption.Text = dtt1.Rows[0]["CoverPaperConsum_Wastage_N"].ToString();
                    }
                }
           
        }
        catch { }


        /*TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
         TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        TextBox blankpages = (TextBox)gv.FindControl("txtBlankPages");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        TextBox txtPapterConsumption = (TextBox)gv.FindControl("txtPapterConsumption");
        TextBox txtCoverPapterConsumption = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

        float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0, Lib = 0;
        try
        {
            Page = float.Parse(lblPages_N.Text);
        }
        catch { }
        try
        {
           // BlankPage = float.Parse(lblTotalBlankPages_N.Text);
            BlankPage = float.Parse(blankpages.Text);
        }
        catch { }
        TotalPage = Page - BlankPage;



        try
        {
            Qty = float.Parse(lblTotalNoBook.Text);
            Lib = float.Parse(txt.Text);
        }
        catch { Qty = 0; }
        try
        { Rate = float.Parse(lblRate_N.Text); }
        catch { Rate = 0; }
        lblTotalBlankPages_N.Text = ((Qty + Lib) * BlankPage).ToString();

        Amt = ((Qty + Lib) * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");

        if (chkSelect.Checked == true)
        {
            try
            {
                CalAmt();
            }
            catch { }
        }*/
    }
    protected void txtAmount1_TextChanged(object sender, EventArgs e)
    {
        //        fn_getPaperTonnageonPaperno(TitleID_I,IFNULL(TotalNoOfBooks,0) ,1)) AS PaperConsum_Wastage_N,
        //CAST((fn_getPaperTonnageonPaperno(td.TitleID_I,IFNULL(cd.TotalNoOfBooks,0) ,2)) 
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
         TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        TextBox blankpages = (TextBox)gv.FindControl("txtBlankPages");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        TextBox txtPapterConsumption = (TextBox)gv.FindControl("txtPapterConsumption");
        TextBox txtCoverPapterConsumption = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

        Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");

        float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0, Lib = 0;
        try
        {
            Page = float.Parse(lblPages_N.Text);
        }
        catch { }
        try
        {
            // BlankPage = float.Parse(lblTotalBlankPages_N.Text);
            BlankPage = float.Parse(blankpages.Text);
        }
        catch { }
        TotalPage = Page - BlankPage;



        try
        {
            Qty = float.Parse(lblTotalNoBook.Text);
            Lib = float.Parse(txt.Text);
        }
        catch { Qty = 0; }
        try
        { Rate = float.Parse(lblRate_N.Text); }
        catch { Rate = 0; }
        lblTotalBlankPages_N.Text = ((Qty + Lib) * BlankPage).ToString();

        //Amt = ((Qty + Lib) * Rate * TotalPage) / 8000;
        Amt = ((Qty) * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");

        if (chkSelect.Checked == true)
        {
            try
            {
                CalAmt();
            }
            catch { }
        }

        //change 9118 - for library book consumption
        try
        {
            if (txt.Text == "") { txt.Text = "0"; }
            int totbooks = int.Parse((float.Parse(txt.Text) + float.Parse(lblTotalNoBook.Text)).ToString());
            /*DataTable dtt = obCommonFuction.FillTableByProc("SELECT fn_getPaperTonnageonPaperno('"+lblTitleID_I.Text+"',IFNULL('"+totbooks.ToString()+"',0) ,1) PaperConsum_Wastage_N,"+
                   "cast(fn_getPaperTonnageonPaperno('"+lblTitleID_I.Text+"',IFNULL('" + totbooks.ToString() + "',0) ,2) as decimal(18,0)) CoverPaperConsum_Wastage_N");*/
            DataTable dtt = obCommonFuction.FillTableByProc("SELECT CASE WHEN IFNULL(`fn_getPaperTonnageonPrinterMachine`('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1),0)=0 THEN fn_getPaperTonnageonPaperno('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1) ELSE    `fn_getPaperTonnageonPrinterMachine`('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1) END PaperConsum_Wastage_N," +
                       "cast(fn_getPaperTonnageonPaperno('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,2) as decimal(18,0)) CoverPaperConsum_Wastage_N");
            DataTable dtt1 = obCommonFuction.FillTableByProc("SELECT fn_getPaperTonnageonPapernoacb('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,1))  PaperConsum_Wastage_N," +
                           "cast(fn_getPaperTonnageonPapernoacb('" + lblTitleID_I.Text + "',IFNULL('" + totbooks.ToString() + "',0) ,2) as decimal(18,0)) CoverPaperConsum_Wastage_N");

            if (dtt.Rows.Count > 0)
            {
                txtPapterConsumption.Text = dtt.Rows[0]["PaperConsum_Wastage_N"].ToString();
                txtCoverPapterConsumption.Text = dtt.Rows[0]["CoverPaperConsum_Wastage_N"].ToString();
            }

        }
        catch { }


        /*TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
         TextBox lblRate_N = (TextBox)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        TextBox blankpages = (TextBox)gv.FindControl("txtBlankPages");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        TextBox txtPapterConsumption = (TextBox)gv.FindControl("txtPapterConsumption");
        TextBox txtCoverPapterConsumption = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

        float Qty = 0, Rate = 0, TotalPage = 0, Page = 0, BlankPage = 0, Amt = 0, Lib = 0;
        try
        {
            Page = float.Parse(lblPages_N.Text);
        }
        catch { }
        try
        {
           // BlankPage = float.Parse(lblTotalBlankPages_N.Text);
            BlankPage = float.Parse(blankpages.Text);
        }
        catch { }
        TotalPage = Page - BlankPage;



        try
        {
            Qty = float.Parse(lblTotalNoBook.Text);
            Lib = float.Parse(txt.Text);
        }
        catch { Qty = 0; }
        try
        { Rate = float.Parse(lblRate_N.Text); }
        catch { Rate = 0; }
        lblTotalBlankPages_N.Text = ((Qty + Lib) * BlankPage).ToString();

        Amt = ((Qty + Lib) * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");

        if (chkSelect.Checked == true)
        {
            try
            {
                CalAmt();
            }
            catch { }
        }*/
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
        private float _TDSonGST;
        private float _TDSonSGST;
        private float _TDSonCGST;
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
        private int _mBookType ;

        private float _OtherDedAmount_N;
        private string _OtherDed_V;
        private string _mAcyear;

        //added 14917
        private float _BadPrinting_N;
        private float _PrintingMistakes_N;
        private float _Lamination_N;
        private float _PerfectBinding_N;
        private float _LooseBundlePack_N;
        private float _TransportationDelvryChrg_N;
        private float _GSTAmt_N;
        private float _AmtReturnToPrinter_N;
        private float _TotAmtPayableWithGST_N;
        private int _IsStatePrinter;

        private float _BadPrintingPerc_N;
        private string _Grpno_V;

        public float BadPrintingPerc_N { get { return _BadPrintingPerc_N; } set { _BadPrintingPerc_N = value; } }
        public string Grpno_V { get { return _Grpno_V; } set { _Grpno_V = value; } }

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
        public float TDSonCGST { get { return _TDSonCGST; } set { _TDSonCGST = value; } }
        // end
        //

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
        public float TDSonGST { get { return _TDSonGST; } set { _TDSonGST = value; } }
        public float TDSonSGST { get { return _TDSonSGST; } set { _TDSonSGST = value; } }
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
        public string  PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int User_ID { get { return _User_ID; } set { _User_ID = value; } }
        public int Type_ID { get { return _Type_ID; } set { _Type_ID = value; } }
        public int mLibraryBook { get { return _mLibraryBook; } set { _mLibraryBook = value; } }
        public int IsStatePrinter { get { return _IsStatePrinter; } set { _IsStatePrinter = value; } }
        public int mBookType { get { return _mBookType; } set { _mBookType = value; } }
        public float OtherDedAmount_N { get { return _OtherDedAmount_N; } set { _OtherDedAmount_N = value; } }
        public string OtherDed_V { get { return _OtherDed_V; } set { _OtherDed_V = value; } }

        //added 1492017
        public float BadPrinting_N { get { return _BadPrinting_N; } set { _BadPrinting_N = value; } }
        public float PrintingMistakes_N { get { return _PrintingMistakes_N; } set { _PrintingMistakes_N = value; } }
        public float Lamination_N { get { return _Lamination_N; } set { _Lamination_N = value; } }
        public float PerfectBinding_N { get { return _PerfectBinding_N; } set { _PerfectBinding_N = value; } }
        public float LooseBundlePack_N { get { return _LooseBundlePack_N; } set { _LooseBundlePack_N = value; } }
        public float TransportationDelvryChrg_N { get { return _TransportationDelvryChrg_N; } set { _TransportationDelvryChrg_N = value; } }
        public float GSTAmt_N { get { return _GSTAmt_N; } set { _GSTAmt_N = value; } }
        public float AmtReturnToPrinter_N { get { return _AmtReturnToPrinter_N; } set { _AmtReturnToPrinter_N = value; } }
        public float TotAmtPayableWithGST_N { get { return _TotAmtPayableWithGST_N; } set { _TotAmtPayableWithGST_N = value; } }

        public int MasterUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mBillno_V", Billno_V);
            obDBAccess.addParam("mBillDate_D", BillDate_D);
            //obDBAccess.addParam("mChallanRecDate", ChallanRecDate_D); 
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mBookTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mTotalPaperSup_N", TotalPaperSup_N);
            obDBAccess.addParam("mTotCovPaperSup_N", TotCovPaperSup_N);
            obDBAccess.addParam("mPapSecReimburse_N", PapSecReimburse_N);
            obDBAccess.addParam("mBalSecurity_N", BalSecurity_N);
            obDBAccess.addParam("mPrnChrg100per_N", PrnChrg100per_N);
            obDBAccess.addParam("mPrnChrg25per_N", PrnChrg25per_N);
            obDBAccess.addParam("mPrnChrg75per_N", PrnChrg75per_N);
            obDBAccess.addParam("mPaperSecforton_N", PaperSecforton_N);
            obDBAccess.addParam("mPaperReemRs_N", PaperReemRs_N);
            obDBAccess.addParam("mTonsPerReem_N", TonsPerReem_N);
            obDBAccess.addParam("mReimburseamt_N", Reimburseamt_N);
            obDBAccess.addParam("mPayablePrnchrg_N", PayablePrnchrg_N);
            obDBAccess.addParam("mTotalpayable_N", Totalpayable_N);
            obDBAccess.addParam("mDedIncometax_N", DedIncometax_N);
            obDBAccess.addParam("mTDSonGST", TDSonGST);
            obDBAccess.addParam("mTDSonSGST", TDSonCGST);  
            obDBAccess.addParam("mDedpapSec_N", DedpapSec_N);
            obDBAccess.addParam("mDedDepoExp_N", DedDepoExp_N);
            obDBAccess.addParam("mDedInterestonpaper_N", DedInterestonpaper_N);
            obDBAccess.addParam("mPenDelaySup_N", PenDelaySup_N);
            obDBAccess.addParam("mDedShotSizePaper1_N", DedShotSizePaper1_N);
            obDBAccess.addParam("mDedShotSizePaper2_N", DedShotSizePaper2_N);
            obDBAccess.addParam("mDedShotSizePaper3_N", DedShotSizePaper3_N);
            obDBAccess.addParam("mTotalDed_N", TotalDed_N);
            obDBAccess.addParam("mNetPayable_N", NetPayable_N);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mPaperSecurityDeposit", PaperSecurityDeposit);
            obDBAccess.addParam("mBFPay", BFPay);
            obDBAccess.addParam("mChallanRecDate", ChallanRecDate_D);
            obDBAccess.addParam("mOtherDedDescription", OtherDed_V);
            obDBAccess.addParam("mOtherDedAmount", OtherDedAmount_N);

            //added new fields 1492017
            obDBAccess.addParam("mBadPrinting_N", BadPrinting_N);
            obDBAccess.addParam("mPrintingMistakes_N", PrintingMistakes_N);
            obDBAccess.addParam("mLamination_N", Lamination_N);
            obDBAccess.addParam("mPerfectBinding_N", PerfectBinding_N);
            obDBAccess.addParam("mLooseBundlePack_N", LooseBundlePack_N);
            obDBAccess.addParam("mTransportationDelvryChrg_N", TransportationDelvryChrg_N);
            obDBAccess.addParam("mGSTAmt_N", GSTAmt_N);
            obDBAccess.addParam("mAmtReturnToPrinter_N", AmtReturnToPrinter_N);
            obDBAccess.addParam("mTotAmtPayableWithGST_N", TotAmtPayableWithGST_N);

            //added new fields 291217
            obDBAccess.addParam("misStatePrinter", IsStatePrinter);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        //objBillDetails.BadPrinting_N = float.Parse(txtBadPrinting.Text);
        //objBillDetails.PrintingMistakes_N = float.Parse(txtPrintingMistakes.Text);
        //objBillDetails.Lamination_N = float.Parse(txtLamination.Text);
        //objBillDetails.PerfectBinding_N= float.Parse(txtPerfectBinding.Text);
        //objBillDetails.LooseBundlePack_N = float.Parse(txtLooseBundlePack.Text);
        //objBillDetails.TransportationDelvryChrg_N = float.Parse(txtTransportationDelvry.Text);
        //objBillDetails.GSTAmt_N = float.Parse(lblGSTAmt.Text != ""?lblGSTAmt.Text:"0");
        //objBillDetails.AmtReturnToPrinter_N = float.Parse(txtAmtReturnToPrinter.Text);

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mBillno_V", Billno_V);
            obDBAccess.addParam("mBillDate_D", BillDate_D);
            obDBAccess.addParam("mChallanRecDate", ChallanRecDate_D); 
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mBookTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mTotalPaperSup_N", TotalPaperSup_N);
            obDBAccess.addParam("mTotCovPaperSup_N", TotCovPaperSup_N);
            obDBAccess.addParam("mPapSecReimburse_N", PapSecReimburse_N);
            obDBAccess.addParam("mBalSecurity_N", BalSecurity_N);
            obDBAccess.addParam("mPrnChrg100per_N", PrnChrg100per_N);
            obDBAccess.addParam("mPrnChrg25per_N", PrnChrg25per_N);
            obDBAccess.addParam("mPrnChrg75per_N", PrnChrg75per_N);
            obDBAccess.addParam("mPaperSecforton_N", PaperSecforton_N);
            obDBAccess.addParam("mPaperReemRs_N", PaperReemRs_N);
            obDBAccess.addParam("mTonsPerReem_N", TonsPerReem_N);
            obDBAccess.addParam("mReimburseamt_N", Reimburseamt_N);
            obDBAccess.addParam("mPayablePrnchrg_N", PayablePrnchrg_N);
            obDBAccess.addParam("mTotalpayable_N", Totalpayable_N);
            obDBAccess.addParam("mDedIncometax_N", DedIncometax_N);
            obDBAccess.addParam("mTDSonGST", TDSonGST);
            obDBAccess.addParam("mTDSonSGST", TDSonSGST);
            obDBAccess.addParam("mDedpapSec_N", DedpapSec_N);
            obDBAccess.addParam("mDedDepoExp_N", DedDepoExp_N);
            obDBAccess.addParam("mDedInterestonpaper_N", DedInterestonpaper_N);
            obDBAccess.addParam("mPenDelaySup_N", PenDelaySup_N);
            obDBAccess.addParam("mDedShotSizePaper1_N", DedShotSizePaper1_N);
            obDBAccess.addParam("mDedShotSizePaper2_N", DedShotSizePaper2_N);
            obDBAccess.addParam("mDedShotSizePaper3_N", DedShotSizePaper3_N);
            obDBAccess.addParam("mTotalDed_N", TotalDed_N);
            obDBAccess.addParam("mNetPayable_N", NetPayable_N);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mPaperSecurityDeposit", PaperSecurityDeposit);
            obDBAccess.addParam("mBFPay", BFPay);
            
            obDBAccess.addParam("mOtherDedDescription", OtherDed_V);
            obDBAccess.addParam("mOtherDedAmount", OtherDedAmount_N);

            //added new fields 1492017
            obDBAccess.addParam("mBadPrinting_N", BadPrinting_N);
            obDBAccess.addParam("mPrintingMistakes_N", PrintingMistakes_N);
            obDBAccess.addParam("mLamination_N", Lamination_N);
            obDBAccess.addParam("mPerfectBinding_N", PerfectBinding_N);
            obDBAccess.addParam("mLooseBundlePack_N", LooseBundlePack_N);
            obDBAccess.addParam("mTransportationDelvryChrg_N", TransportationDelvryChrg_N);
            obDBAccess.addParam("mGSTAmt_N", GSTAmt_N);
            obDBAccess.addParam("mAmtReturnToPrinter_N", AmtReturnToPrinter_N);
            obDBAccess.addParam("mTotAmtPayableWithGST_N", TotAmtPayableWithGST_N);

            //added new field 30/12/17
            obDBAccess.addParam("misStatePrinter", IsStatePrinter); 

            int i = Convert.ToInt32(obDBAccess.executeMyScalar());
            return i;
        }
        public int ChildInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveChildUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", BillDetID_I);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mDepotid_I", Depotid_I);
            obDBAccess.addParam("mQty_N", Qty_N);
            obDBAccess.addParam("mRate_N", Rate_N);
            obDBAccess.addParam("mPages_N", Pages_N);
            obDBAccess.addParam("mAmount_N", Amount_N);
            obDBAccess.addParam("mPaperConsum_Wastage_N", PaperConsum_Wastage_N);
            obDBAccess.addParam("mCoverPaperConsum_Wastage_N", CoverPaperConsum_Wastage_N);
            obDBAccess.addParam("mTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mBlankPages", BlankPages);
            obDBAccess.addParam("mTotBlankPage", TotBlankPage);
            obDBAccess.addParam("mPriTransID", PriTransID);
            obDBAccess.addParam("mLibraryBook", mLibraryBook);

            obDBAccess.addParam("mBadPrinPerc", BadPrintingPerc_N);
            obDBAccess.addParam("mGrpno_v", Grpno_V);
            obDBAccess.addParam("mBookType", mBookType);
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public int ChildInsertDelete()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveChildUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", BillDetID_I);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mDepotid_I", Depotid_I);
            obDBAccess.addParam("mQty_N", Qty_N);
            obDBAccess.addParam("mRate_N", Rate_N);
            obDBAccess.addParam("mPages_N", Pages_N);
            obDBAccess.addParam("mAmount_N", Amount_N);
            obDBAccess.addParam("mPaperConsum_Wastage_N", PaperConsum_Wastage_N);
            obDBAccess.addParam("mCoverPaperConsum_Wastage_N", CoverPaperConsum_Wastage_N);
            obDBAccess.addParam("mTitleID_I", BookTitleID_I);
            obDBAccess.addParam("mBlankPages", BlankPages);
            obDBAccess.addParam("mTotBlankPage", TotBlankPage);
            obDBAccess.addParam("mPriTransID", PriTransID);
            obDBAccess.addParam("mLibraryBook", mLibraryBook);

            obDBAccess.addParam("mBadPrinPerc", 0);
            obDBAccess.addParam("mGrpno_v", "");
            obDBAccess.addParam("mBookType", mBookType);
            int result = obDBAccess.executeMyQuery();
            return result;
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
            obDBAccess.execute("USP_Prin001_BillDetailsFillnew_acb", DBAccess.SQLType.IS_PROC);
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

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 2);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);   
            return obDBAccess.records();

        }
        public System.Data.DataSet SelectTotPaperQty()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 7);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);   
            return obDBAccess.records();

        }
        public System.Data.DataSet FieldFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 3);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);   
            return obDBAccess.records();

        }

        public System.Data.DataSet FieldFillnew()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 3);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);
            obDBAccess.addParam("macyear", mAcyear);
            return obDBAccess.records();

        }

        public System.Data.DataSet InterestFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_pri_PaperInterest", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBookRecieveddate", ChallanRecDate_D.ToString("dd/MM/yyyy"));
            obDBAccess.addParam("mAcYear", Billno_V);
            obDBAccess.addParam("mPrinterID", Printer_RedID_I);
            return obDBAccess.records();

        }
        public int SendToFinance()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 4);
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);   
            int result = obDBAccess.executeMyQuery();
            return result;

        }

        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterDelete", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", id);

        //    int result = obDBAccess.executeMyQuery();
        //    return result;
        //}
    }
    
    protected void txtBillDate_TextChanged(object sender, EventArgs e)
    {
        if (ddlPrinter.SelectedItem.Text != "Select")
        {
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
            if (Request.QueryString["ID"] != null)
            {
                objBillDetails.Type_ID = 5;
            }
            else
                objBillDetails.Type_ID = 6;
            objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
            objBillDetails.BillDate_D   = DateTime.Parse(txtBillDate.Text, cult);
            objBillDetails.mAcyear = DdlACYear.SelectedValue;  
            ds = objBillDetails.BillChildDetailsFillnew();
            GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
            GrdPaperCoverAndPrintingChares.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
                txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
                txtTotalPaperSupply.Text = ds.Tables[0].Rows[0]["TotPaperConsum_Wastage_N"].ToString();
                txtTotalCoverPaperSupply.Text = ds.Tables[0].Rows[0]["TotCoverPaperConsum_Wastage_N"].ToString();
            }
            else
            {
                txtPaperSecurityDeposit.Text = "";
                txtDepotExpenditure.Text = "";
            }
            //  PrinterpaperSupplyFill();
            OnLoad();

        }
        else
        {
            GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
            GrdPaperCoverAndPrintingChares.DataBind();
            txtPrintingCharge.Text = "0";
            txtPrintingCharge25Per.Text = "0";
            txtPrintingCharge75Per.Text = "0";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        Pri_BillDetails_New objBillDet = new Pri_BillDetails_New();
        try
        {

            objBillDet.Billno_V = Convert.ToString(DdlACYear.SelectedValue);
          //  objBillDet.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
            objBillDet.Printer_RedID_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"]).ToString());
            objBillDet.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);

            GrdBillIntrast.DataSource = objBillDet.InterestFill();
            GrdBillIntrast.DataBind();

        }
        catch
        {
        }
        finally
        {
            objBillDet = null;
        }
    }
    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "none");


        fadeDiv.Style.Add("display", "none");

        Div1.Style.Add("display", "none");
        Div2.Style.Add("display", "none");
        Div3.Style.Add("display", "none");

        dvPenltyBadPrtg.Style.Add("display", "none");
        dvPenPopup.Style.Add("display", "none");
    }

   
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("TentyFiveperReportforBill.aspx?ID=" + ddlPrinter.SelectedValue + "&dtfrom=01/11/2017&dtto=" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd/MM/yyyy") + "&myear="+DdlACYear.SelectedValue+"");
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        Div1.Style.Add("display", "block");
        Div2.Style.Add("display", "block");

        try
        {


            DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('0','" + ddlPrinter.SelectedValue + "',4,'" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd/MM/yyyy") + "')");
            GridBooksizePenalty.DataSource = Dt;
            GridBooksizePenalty.DataBind();

        }
        catch
        {
        }
        finally
        {

        }
    }

    protected void lnktitleBill_Click(object sender, EventArgs e)
    {
        Messages22.Style.Add("display", "block");
        fadeDiv22.Style.Add("display", "block");

        try
        {
            GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lblTitleID_I = grdrow.FindControl("lblTitleID_I") as Label;
            Label lblBillDetID_I = grdrow.FindControl("lblBillDetID_I") as Label;

            TextBox txtLibBook_11 = grdrow.FindControl("txtLibBook") as TextBox;
            TextBox txtBlankPages_11 = grdrow.FindControl("txtBlankPages") as TextBox;
            Label lblTotalBlankPages_N_11 = grdrow.FindControl("lblTotalBlankPages_N") as Label;
              TextBox lblRate_N11 = grdrow.FindControl("lblRate_N") as TextBox;
             HDN_TitleName.Value = (grdrow.FindControl("lnktitleBill") as LinkButton).Text;
            

            //HDNRowIndex.Value = grdrow.RowIndex.ToString();
            HDNRowIndex.Value = lblTitleID_I.Text;
            HDNBillDetailID_I.Value = lblBillDetID_I.Text;
            HDN_Rate.Value = lblRate_N11.Text;

            string PrinID = ddlPrinter.SelectedValue;

            HiddenField hdPriTransID11 = grdrow.FindControl("hdPriTransID") as HiddenField;
            HiddenField hdPriTransID_All11 = grdrow.FindControl("hdPriTransID_All") as HiddenField;

            string mDtfrom = Convert.ToDateTime("01/11/2017", cult).ToString("yyyy-MM-dd");
            string mDtto = Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("yyyy-MM-dd");
            string myear = Convert.ToString(DdlACYear.SelectedValue);
            CommonFuction obCommanFun = new CommonFuction();
           //DataSet ds = obCommanFun.FillDatasetByProc("call USP_DPTTwentyFiveReportPrinting_ByTitleID('" + mDtfrom + "','" + mDtto + "'," + Convert.ToInt32(lblTitleID_I.Text) + "," + PrinID + ",'" + myear + "','" + txtLibBook_11.Text + "','" + txtBlankPages_11.Text + "','" + lblTotalBlankPages_N_11.Text + "','" + hdPriTransID11.Value + "','" + HDNBillDetailID_I.Value + "')");
           //Ajay - DataSet ds = obCommanFun.FillDatasetByProc("call USP_DPTTwentyFiveReportPrinting_ByTitleID_ACB('" + mDtfrom + "','" + mDtto + "'," + Convert.ToInt32(lblTitleID_I.Text) + "," + PrinID + ",'" + myear + "','" + txtLibBook_11.Text + "','" + txtBlankPages_11.Text + "','" + lblTotalBlankPages_N_11.Text + "','" + hdPriTransID11.Value + "','" + HDNBillDetailID_I.Value + "','" + hdPriTransID_All11.Value + "','" + HDN_Rate.Value + "')");
            DataSet ds = obCommanFun.FillDatasetByProc("call USP_DPTTwentyFiveReportPrinting_ByTitleID_ACB('" + mDtfrom + "','" + mDtto + "'," + Convert.ToInt32(lblTitleID_I.Text) + "," + PrinID + ",'" + myear + "','" + txtLibBook_11.Text + "','" + txtBlankPages_11.Text + "','" + lblTotalBlankPages_N_11.Text + "','" + hdPriTransID11.Value + "','" + HDNBillDetailID_I.Value + "','" + hdPriTransID_All11.Value + "')");
    
            
            GrdChallantitlewiseChallans.DataSource = ds.Tables[0];
            GrdChallantitlewiseChallans.DataBind();
            //lblTotalQty.Text = ds.Tables[0].Compute("Sum(NoOfBooks)", "").ToString();


            //if (Request.QueryString["ID"] != null)
            //{
            //    HiddenField hdPriTransID = grdrow.FindControl("hdPriTransID") as HiddenField;
            //    string[] transIds = hdPriTransID.Value.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //    foreach (GridViewRow grdd in GrdChallantitlewiseChallans.Rows)
            //    {
            //        CheckBox chkSelect = grdd.FindControl("chkSelect") as CheckBox;
            //        chkSelect.Checked = false;
            //    }

            //    foreach (GridViewRow grdd in GrdChallantitlewiseChallans.Rows)
            //    {
            //        CheckBox chkSelect = grdd.FindControl("chkSelect") as CheckBox;
            //        HiddenField hdPriTransID22 = grdd.FindControl("hdPriTransID") as HiddenField;
            //        for (int i = 0; i < transIds.Length; i++)
            //        {
            //            if (transIds[i].Trim() == hdPriTransID22.Value)
            //            {
            //                chkSelect.Checked = true;
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //    string PriTransIDs = ""; int totQty = 0;
            //    if (ViewState["dtBill"] != null)
            //    {
            //        DataTable dttnew = (DataTable)ViewState["dtBill"];
            //        if (dttnew.Rows.Count > 0)
            //        {
            //            DataView dvv = new DataView(dttnew, "TitleID_I='" + HDNRowIndex.Value + "'", "", DataViewRowState.CurrentRows);
            //            if (dvv.Count > 0)
            //            {
            //                PriTransIDs = dvv[0]["PriTransID"].ToString();
            //                string[] transIds = PriTransIDs.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            //                foreach (GridViewRow grdd in GrdChallantitlewiseChallans.Rows)
            //                {
            //                    CheckBox chkSelect = grdd.FindControl("chkSelect") as CheckBox;
            //                    chkSelect.Checked = false;
            //                }


            //                foreach (GridViewRow grdd in GrdChallantitlewiseChallans.Rows)
            //                {
            //                    CheckBox chkSelect = grdd.FindControl("chkSelect") as CheckBox;
            //                    HiddenField hdPriTransID22 = grdd.FindControl("hdPriTransID") as HiddenField;
            //                    Label lblTotalNoBook_11 = grdd.FindControl("lblTotalNoBook") as Label;
            //                    //totQty += totQty + int.Parse(lblTotalNoBook_11.Text);
            //                    for (int i = 0; i < transIds.Length; i++)
            //                    {
            //                        if (transIds[i].Trim() == hdPriTransID22.Value)
            //                        {
            //                            chkSelect.Checked = true;
            //                        }

            //                    }
            //                }

            //            }
            //        }
            //    }
            //}

            DataTable dtMainGrid = fnSetInitialRow();
            foreach (GridViewRow grdd in GrdPaperCoverAndPrintingChares.Rows)
            {
                CheckBox chkSelect_11 = (CheckBox)grdd.FindControl("chkSelect");
                LinkButton lnktitleBill = (LinkButton)grdd.FindControl("lnktitleBill");
                Label lblAmount = (Label)grdd.FindControl("lblAmount");
                Label lblPapterConsumption = (Label)grdd.FindControl("lblPapterConsumption");
                Label lblCoverPapterConsumption = (Label)grdd.FindControl("lblCoverPapterConsumption");
                Label lblTotalNoBook = (Label)grdd.FindControl("lblTotalNoBook");
                HiddenField hdPriTransID = (HiddenField)grdd.FindControl("hdPriTransID");
                TextBox txtLibBook = grdd.FindControl("txtLibBook") as TextBox;
                TextBox txtBlankPages = grdd.FindControl("txtBlankPages") as TextBox;
                Label lblTotalBlankPages_N = grdd.FindControl("lblTotalBlankPages_N") as Label;
                Label lblPages_N = grdd.FindControl("lblPages_N") as Label;

                //Label lnktitleBill = grdrow.FindControl("lnktitleBill") as Label;
                Label lblBillDetID_I_11 = grdd.FindControl("lblBillDetID_I") as Label;
                Label lblTitleID_I_11 = grdd.FindControl("lblTitleID_I") as Label;
                HiddenField hdPriTransID_11 = grdd.FindControl("hdPriTransID") as HiddenField;
                HiddenField hdChalanNo = grdd.FindControl("hdChalanNo") as HiddenField;
                 TextBox lblRate_N = grdd.FindControl("lblRate_N") as TextBox;
                TextBox txtPapterConsumption = grdd.FindControl("txtPapterConsumption") as TextBox;
                TextBox txtCoverPapterConsumption = grdd.FindControl("txtCoverPapterConsumption") as TextBox;

                HiddenField hdnGrpno_V = grdd.FindControl("hdnGrpno_V") as HiddenField;
                TextBox txtBadPrintPen_grd = grdd.FindControl("txtBadPrintPen_grd") as TextBox;
                HiddenField hdPriTransID_All = grdd.FindControl("hdPriTransID_All") as HiddenField;
                HiddenField HiddenBookType = grdd.FindControl("HiddenBookType") as HiddenField;
                DataRow dr = dtMainGrid.NewRow();
                dr["TitleHindi_V"] = lnktitleBill.Text;
                dr["BillDetID_I"] = lblBillDetID_I_11.Text;
                dr["TitleID_I"] = lblTitleID_I_11.Text;
                dr["PriTransID"] = hdPriTransID_11.Value;
                dr["ChalanNo"] = hdChalanNo.Value;

                dr["TotalNoOfBooks"] = lblTotalNoBook.Text;
                dr["Rate_N"] = lblRate_N.Text;
                dr["Pages_N"] = lblPages_N.Text;

                dr["LibraryBook"] = txtLibBook.Text;
                dr["BlankPages"] = txtBlankPages.Text;
                dr["TotBlankPage"] = lblTotalBlankPages_N.Text;

                dr["Amount_N"] = lblAmount.Text;
                dr["PaperConsum_Wastage_N"] = txtPapterConsumption.Text;
                dr["CoverPaperConsum_Wastage_N"] = txtCoverPapterConsumption.Text;
                dr["Grpno_V"] = hdnGrpno_V.Value;
                dr["BadPrintPenPercent"] = txtBadPrintPen_grd.Text;
                dr["PriTransID_All"] = hdPriTransID_All.Value;
                dr["BookType"] = HiddenBookType.Value;
                if (chkSelect_11.Checked == true)
                {
                    dr["IsChecked"] = "1";
                }
                else
                    dr["IsChecked"] = "0";

                dtMainGrid.Rows.Add(dr);
            }

            if (dtMainGrid.Rows.Count > 0)
            {
                ViewState["dtBill"] = dtMainGrid;
            }

        }
        catch { }
    }

    protected void btnBack11_Click(object sender, EventArgs e)
    {
        if(Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "1")
            Response.Redirect("~/voucherbillrpt.aspx");
        else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "home")
            Response.Redirect("~/EmployeeHome.aspx");
        else
          Response.Redirect("~/Printing/ViewBillDetails.aspx");
    }

    protected void btnAddBill_Click(object sender, EventArgs e)
    {
        try
        {
            double dbAmount = 0; double dbPapterConsumption = 0; double dbCoverPapterConsumption = 0; double dbTotalNoBook = 0; int i = 0; string strPriTransID = "";
            foreach (GridViewRow grd in GrdChallantitlewiseChallans.Rows)
            {
                CheckBox chkSelect = (CheckBox)grd.FindControl("chkSelect");
                if (chkSelect.Checked == true)
                {
                    Label lblAmount = (Label)grd.FindControl("lblAmount");
                    Label lblPapterConsumption = (Label)grd.FindControl("lblPapterConsumption");
                    Label lblCoverPapterConsumption = (Label)grd.FindControl("lblCoverPapterConsumption");
                    Label lblTotalNoBook = (Label)grd.FindControl("lblTotalNoBook");
                    HiddenField hdPriTransID = (HiddenField)grd.FindControl("hdPriTransID");
                    HiddenField hdLibraryBook = (HiddenField)grd.FindControl("hdLibraryBook");
                    HiddenField hdBlankPages = (HiddenField)grd.FindControl("hdBlankPages");

                    dbAmount += double.Parse(lblAmount.Text);
                    dbPapterConsumption += double.Parse(lblPapterConsumption.Text);
                    dbCoverPapterConsumption += double.Parse(lblCoverPapterConsumption.Text);
                    dbTotalNoBook += double.Parse(lblTotalNoBook.Text);
                    strPriTransID += hdPriTransID.Value + ",";

                    i++;
                }
            }

            if (i > 0)
            {
                if (strPriTransID != "") { strPriTransID = strPriTransID.TrimEnd(','); }

                string LibraryBook = "0"; string BlankPages = "0"; string TotBlankPage = "0"; string IsChecked = "0"; string Grpno_V = ""; string BadPrintPenPercent = "0";
                string PrinTransID_All = "";

                DataTable dtt = new DataTable();
                DataTable dtNew = new DataTable();
                if (ViewState["dtBill"] != null)
                {
                    dtt = (DataTable)ViewState["dtBill"];
                    //DataView dvv = new DataView(dtt, "TitleID_I<>'" + HDNRowIndex.Value + "' and Rate_N='" + HDN_Rate.Value + "'", "", DataViewRowState.CurrentRows);
                    DataView dvv = new DataView(dtt, "TitleHindi_V<>'" + HDN_TitleName.Value + "'", "", DataViewRowState.CurrentRows);

                    //for fetching library and blank pages
                    //DataView dvData = new DataView(dtt, "TitleHindi_V='" + HDNRowIndex.Value + "' and Rate_N='"+HDN_Rate.Value+"'", "", DataViewRowState.CurrentRows);
                    DataView dvData = new DataView(dtt, "TitleHindi_V='" + HDN_TitleName.Value + "'", "", DataViewRowState.CurrentRows);
                    if (dvData.Count > 0)
                    {
                        LibraryBook = dvData[0]["LibraryBook"].ToString();
                        BlankPages = dvData[0]["BlankPages"].ToString();
                        TotBlankPage = dvData[0]["TotBlankPage"].ToString();
                        IsChecked = dvData[0]["IsChecked"].ToString();
                        Grpno_V = dvData[0]["Grpno_V"].ToString();
                        BadPrintPenPercent = dvData[0]["BadPrintPenPercent"].ToString();
                        PrinTransID_All = dvData[0]["PriTransID_All"].ToString();
                    }

                    dtt = dvv.ToTable();


                }

                CommonFuction obCommanFun = new CommonFuction();
                //DataSet ds = obCommanFun.FillDatasetByProc("call USP_Prin001_BillDetailsFillnew_ByChallanID('" + ddlPrinter.SelectedValue + "','" + strPriTransID + "',6,'" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedValue + "','" + HDNBillDetailID_I.Value + "','" + LibraryBook + "','" + BlankPages + "','" + TotBlankPage + "','" + IsChecked + "','" + Grpno_V + "','" + BadPrintPenPercent + "')");
                DataSet ds = obCommanFun.FillDatasetByProc("call USP_Prin001_BillDetailsFillnew_ByChallanID('" + ddlPrinter.SelectedValue + "','" + strPriTransID + "',6,'" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedValue + "','" + HDNBillDetailID_I.Value + "','" + LibraryBook + "','" + BlankPages + "','" + TotBlankPage + "','" + IsChecked + "','" + Grpno_V + "','" + BadPrintPenPercent + "','" + PrinTransID_All + "')");
                ds.Tables[0].Merge(dtt, true, MissingSchemaAction.Ignore);

                dtNew = new DataView(ds.Tables[0], "1=1", "TitleID_I ASC, Rate_N Desc", DataViewRowState.CurrentRows).ToTable();

                GrdPaperCoverAndPrintingChares.DataSource = dtNew;
                GrdPaperCoverAndPrintingChares.DataBind();

                ViewState["dtBill"] = dtNew;

                //calculate
                if (Request.QueryString["ID"] != null)
                {
                    foreach (GridViewRow grd in GrdPaperCoverAndPrintingChares.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)grd.FindControl("chkSelect");
                        HiddenField hdnIsChecked = (HiddenField)grd.FindControl("hdnIsChecked");
                        if (hdnIsChecked.Value == "1")
                        {
                            chkSelect.Checked = true;
                        }
                    }
                    chkSelect_CheckedChanged(null, null);
                    foreach (GridViewRow grd in GrdPaperCoverAndPrintingChares.Rows)
                    {
                        TextBox txtLibBook = (TextBox)grd.FindControl("txtLibBook");
                        txtLibBook_TextChanged(txtLibBook, null);
                    }

                }
                else
                {
                    foreach (GridViewRow grd in GrdPaperCoverAndPrintingChares.Rows)
                    {
                        CheckBox chkSelect = (CheckBox)grd.FindControl("chkSelect");
                        HiddenField hdnIsChecked = (HiddenField)grd.FindControl("hdnIsChecked");
                        if (hdnIsChecked.Value == "1")
                        {
                            chkSelect.Checked = true;
                            chkSelect_CheckedChanged(chkSelect, null);
                        }
                    }

                }

                lnBtnBack22_Click(null, null);
            }

        }
        catch { }
    }

    protected void Button5_Click1(object sender, EventArgs e)
    {
        Pri_BillDetails_New objBillDet = new Pri_BillDetails_New();
        try
        {
            objBillDet.Billno_V = Convert.ToString(DdlACYear.SelectedValue);
            objBillDet.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
            objBillDet.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);

            GrdBillIntrast.DataSource = objBillDet.InterestFill();
            GrdBillIntrast.DataBind();

            //ExportToExcell();
        }
        catch
        {
        }
        finally
        {
            objBillDet = null;
        }
    }

    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    //base.VerifyRenderingInServerForm(control);
    //}


    public void ExportToExcell()
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "IntCal.xls"));
            Response.Charset = "";
            Response.ContentType = "application / vnd.ms - xls";

            StringWriter sw = new StringWriter();
            HtmlTextWriter HW = new HtmlTextWriter(sw);

            Panel7.RenderControl(HW);
            Response.Write(sw.ToString());
            Response.End();
            Response.Clear();
        }
        catch { }
    }


    private void fnClearViewstateDt()
    {
        if (ViewState["dtBill"] != null)
            ViewState["dtBill"] = null;
    }

    private DataTable fnSetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        //Define the Columns
        dt.Columns.Add(new DataColumn("TitleHindi_V", typeof(string)));
        dt.Columns.Add(new DataColumn("BillDetID_I", typeof(string)));
        dt.Columns.Add(new DataColumn("TitleID_I", typeof(string)));
        dt.Columns.Add(new DataColumn("PriTransID", typeof(string)));
        dt.Columns.Add(new DataColumn("ChalanNo", typeof(string)));

        dt.Columns.Add(new DataColumn("TotalNoOfBooks", typeof(string)));
        dt.Columns.Add(new DataColumn("Rate_N", typeof(string)));
        dt.Columns.Add(new DataColumn("Pages_N", typeof(string)));

        dt.Columns.Add(new DataColumn("LibraryBook", typeof(string)));
        dt.Columns.Add(new DataColumn("BlankPages", typeof(string)));
        dt.Columns.Add(new DataColumn("TotBlankPage", typeof(string)));

        dt.Columns.Add(new DataColumn("Amount_N", typeof(string)));
        dt.Columns.Add(new DataColumn("PaperConsum_Wastage_N", typeof(string)));
        dt.Columns.Add(new DataColumn("CoverPaperConsum_Wastage_N", typeof(string)));
        dt.Columns.Add(new DataColumn("IsChecked", typeof(string)));
        dt.Columns.Add(new DataColumn("Grpno_V", typeof(string)));
        dt.Columns.Add(new DataColumn("BadPrintPenPercent", typeof(string)));
        dt.Columns.Add(new DataColumn("PriTransID_All", typeof(string)));
        dt.Columns.Add(new DataColumn("BookType", typeof(string)));
        return dt;
      
    }

    protected void lnBtnViewIndent_Click(object sender, EventArgs e)
    {
        Messages11.Style.Add("display", "block");
        fadeDiv11.Style.Add("display", "block");

        //HDNCoverTotal.Value = "";
        //HDNPaperTotal.Value = "";

        try
        {
            
            CommonFuction obCommonFuction = new CommonFuction();
            //DataTable dt = obCommonFuction.FillDatasetByProc("call USP_Prin003_GetBillDetailsFill('" + ddlPrinter.SelectedValue + "','" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedItem.Text + "')").Tables[0];
            DataTable dt = obCommonFuction.FillDatasetByProc("call USP_Prin003_GetBillDetailsFill_GSMWise('" + ddlPrinter.SelectedValue + "','" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedItem.Text + "')").Tables[0];
            GrdViewIndentDetails.DataSource = dt;
            GrdViewIndentDetails.DataBind();

            //if (dt.Rows.Count > 0)
            //{
            //    HDNCoverTotal.Value = dt.Compute("Sum(PaperQty)", "").ToString();
            //    HDNPaperTotal.Value = dt.Compute("Sum(CoverPaperQty)", "").ToString();
            //}
        }
        catch { }
    }

    protected void lnBtnBack11_Click(object sender, EventArgs e)
    {
        Messages11.Style.Add("display", "none");
        fadeDiv11.Style.Add("display", "none");
    }

    protected void lnBtnBack22_Click(object sender, EventArgs e)
    {
        Messages22.Style.Add("display", "none");
        fadeDiv22.Style.Add("display", "none");
    }

    protected void Button3_Click1(object sender, EventArgs e)
    {
        Div1.Style.Add("display", "block");
        Div3.Style.Add("display", "block");
        string ChalanNo = "";
        try
        {

            foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
            {
                
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                HiddenField hdChalanNo = (HiddenField)gv.FindControl("hdPriTransID");
                

         

                try
                {
                    if (chkSelect.Checked == true)
                    {

                        ChalanNo += hdChalanNo.Value + ",";
                        
                    }
                }
                catch { }

            }
     

            //calculate interest chalan wise - 8/5/2017
            if (ChalanNo.Length > 0)
            {
                ChalanNo = ChalanNo.Substring(ChalanNo.Length - (ChalanNo.Length), (ChalanNo.Length - 1));
                 
            }


            DataTable Dt = obCommonFuction.FillTableByProc("call USP_Penalty_delay_Show('"+ DdlACYear.SelectedValue +"','" + ddlPrinter.SelectedValue + "','" + ChalanNo +"')");
            //+ Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd-MM-yyyy") + "','"
            GrdDelayPen.DataSource = Dt;
            GrdDelayPen.DataBind();

        }
        catch
        {
        }
        finally
        {

        }
    }

    protected void Button4_Click1(object sender, EventArgs e)
    {
        dvPenltyBadPrtg.Style.Add("display", "block");
        dvPenPopup.Style.Add("display", "block");        

        try
        {
            //DataTable Dt = obCommonFuction.FillTableByProc("call USP_Penalty_badprinting_Show('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd-MM-yyyy") + "')");
            DataTable Dt = obCommonFuction.FillTableByProc("call USP_Penalty_badprinting_Show('" + DdlACYear.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + Convert.ToDateTime(txtChalanrecDate.Text, cult).ToString("dd/MM/yyyy") + "','',0)");
            GrdPenltyBadPrtg.DataSource = Dt;
            GrdPenltyBadPrtg.DataBind();

        }
        catch
        {
        }
        finally
        {

        }
    }

    protected void GrdViewIndentDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
        {
            // GET THE RUNNING TOTAL OF PRICE FOR EACH PAGE.
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPaperQty = (Label)e.Row.FindControl("lblPaperQty");
                dPaperTotal += Decimal.Parse(lblPaperQty.Text);

                Label lblCoverQty = (Label)e.Row.FindControl("lblCoverQty");
                dCoverTotal += Decimal.Parse(lblCoverQty.Text);
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblPaperTotal = (Label)e.Row.FindControl("lblPaperTotal");
                Label lblCoverTotal = (Label)e.Row.FindControl("lblCoverTotal");

                lblPaperTotal.Text = dPaperTotal.ToString("N2");
                lblCoverTotal.Text = dCoverTotal.ToString();
            }
        }
        catch { }
    }

    protected void GrdViewIndentDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            // GET THE RUNNING TOTAL OF PRICE FOR EACH PAGE.
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lbl70gsmPaperQty = (Label)e.Item.FindControl("lblGSM70");
                dPaper70Total += Decimal.Parse(lbl70gsmPaperQty.Text);

                Label lbl80gsmPaperQty = (Label)e.Item.FindControl("lblGSM80");
                dPaper80Total += Decimal.Parse(lbl80gsmPaperQty.Text);

                Label lbl230gsmCoverPaperQty = (Label)e.Item.FindControl("lblGSM230");
                dCoverPaper230Total += Decimal.Parse(lbl230gsmCoverPaperQty.Text);

                Label lbl250gsmCoverPaperQty = (Label)e.Item.FindControl("lblGSM250");
                dCoverPaper250Total += Decimal.Parse(lbl250gsmCoverPaperQty.Text);
            }

            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lblPaper70Total = (Label)e.Item.FindControl("lbl70GSMPaperTotal");
                Label lblPaper80Total = (Label)e.Item.FindControl("lbl80GSMPaperTotal");

                Label lblCoverPaper230Total = (Label)e.Item.FindControl("lbl230GSMCoverPaperTotal");
                Label lblCoverPaper250Total = (Label)e.Item.FindControl("lbl250GSMCoverPaperTotal");

                lblPaper70Total.Text = dPaper70Total.ToString("N2");
                lblPaper80Total.Text = dPaper80Total.ToString();

                lblCoverPaper230Total.Text = dCoverPaper230Total.ToString();
                lblCoverPaper250Total.Text = dCoverPaper250Total.ToString();
            }
        }
        catch { }
    }

    protected void txtBadPrinting_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPrintingMistakes_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtLamination_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtPerfectBinding_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtLooseBundlePack_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }
    protected void txtTransportationDelvry_TextChanged(object sender, EventArgs e)
    {
        OnLoad();
    }

    decimal d1 = 0; decimal d2 = 0; decimal d3 = 0;
    protected void GrdBillIntrast_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalNoOfBooks = (Label)e.Row.FindControl("lblTotalNoOfBooks");
            try
            {
                if (lblTotalNoOfBooks.Text != "")
                {
                    d1 += decimal.Parse(lblTotalNoOfBooks.Text);
                }
            }
            catch { }

            Label lblPaperQty_N = (Label)e.Row.FindControl("lblPaperQty_N");
            try
            {
                if (lblPaperQty_N.Text != "")
                {
                    d2 += decimal.Parse(lblPaperQty_N.Text);
                }
            }
            catch { }

            Label lblIntrestOnPaper = (Label)e.Row.FindControl("lblIntrestOnPaper");
            try
            {
                if (lblIntrestOnPaper.Text != "")
                {
                    d3 += decimal.Parse(lblIntrestOnPaper.Text);
                }
            }
            catch { }

           
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotalNoOfBooks_f = (Label)e.Row.FindControl("lblTotalNoOfBooks_f");
            lblTotalNoOfBooks_f.Text = d1.ToString("0");

            Label lblPaperQty_N_f = (Label)e.Row.FindControl("lblPaperQty_N_f");
            lblPaperQty_N_f.Text = d2.ToString("0.000");

            Label lblIntrestOnPaper_f = (Label)e.Row.FindControl("lblIntrestOnPaper_f");
            lblIntrestOnPaper_f.Text = d3.ToString("0");
        }
    }

    decimal dPaper70Total11 = 0; decimal dPaper70Total22 = 0; decimal dDelayDays = 0; decimal dPenAmtPerc = 0;
    protected void GrdDelayPen_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalNoOfBooks = (Label)e.Row.FindControl("lblTotalNoOfBooks");
            try
            {
                if (lblTotalNoOfBooks.Text != "")
                {
                    dPaper70Total11 += decimal.Parse(lblTotalNoOfBooks.Text);
                }
            }
            catch { }

            Label lblDetailsAll_hunamt = (Label)e.Row.FindControl("lblDetailsAll_hunamt");
            try
            {
                if (lblDetailsAll_hunamt.Text != "")
                {
                    dPaper70Total22 += decimal.Parse(lblDetailsAll_hunamt.Text);
                }
            }
            catch { }

            Label lblIntrestOnPaper = (Label)e.Row.FindControl("lblIntrestOnPaper");
            try
            {
                if (lblIntrestOnPaper.Text != "")
                {
                    dDelayDays += decimal.Parse(lblIntrestOnPaper.Text);
                }
            }
            catch { }

            Label lblDetailsAll_penamt = (Label)e.Row.FindControl("lblDetailsAll_penamt");
            try
            {
                if (lblDetailsAll_penamt.Text != "")
                {
                    dPenAmtPerc += decimal.Parse(lblDetailsAll_penamt.Text);
                }
            }
            catch { }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotBook_f = (Label)e.Row.FindControl("lblTotBook_f");
            lblTotBook_f.Text = dPaper70Total11.ToString("0");

            Label lblTotHunAmount_f = (Label)e.Row.FindControl("lblTotHunAmount_f");
            lblTotHunAmount_f.Text = dPaper70Total22.ToString("0");

            Label lblIntrestOnPaper_f = (Label)e.Row.FindControl("lblIntrestOnPaper_f");
            lblIntrestOnPaper_f.Text = dDelayDays.ToString("0");

            Label lblDetailsAll_penamt_f = (Label)e.Row.FindControl("lblDetailsAll_penamt_f");
            lblDetailsAll_penamt_f.Text = dPenAmtPerc.ToString("0");
            txtDelaySupplyPenalty.Text = lblDetailsAll_penamt_f.Text;
        }
    }
    protected void rdIn_CheckedChanged(object sender, EventArgs e)
    {
                    lblTDSGST.Text = "(2-a) Withheld 1% regarding SGST TDS Rs. ";
                    lblTDSCGST.Visible = true;
                    lblTDSCGST.Text = "(b) Withheld 1% regarding CGST TDS  Rs. ";

                    CalAmt();
                    dvOutgst.Style.Add("display", "none");
                    dvIngst_s.Style.Add("display", "block");
                    dvIngst_c.Style.Add("display", "block");

    }

    protected void rdOut_CheckedChanged(object sender, EventArgs e)
    {
         lblTDSGST.Text = "(2) Withheld 2% regarding IGST TDS Rs. ";
                    lblTDSCGST.Visible =false;
                    txt2PerTDSCGST.Text = "0";

                    CalAmt();
                    dvOutgst.Style.Add("display", "block");
                    dvIngst_s.Style.Add("display", "none");
                    dvIngst_c.Style.Add("display", "none");
    }
    protected void txtAmtReturnToPrinter_TextChanged(object sender, EventArgs e)
    {
        txtAmtReturnToPrinter0.Text = txtAmtReturnToPrinter.Text;
    }
}