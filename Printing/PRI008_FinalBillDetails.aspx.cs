using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;


public partial class PRI008_FinalBillDetails : System.Web.UI.Page
{
    DataSet ds;
    Pri_BillDetails_New objBillDetails = null;
    public DataSet dta;
    CultureInfo cult = new CultureInfo("gu-IN", true);
   public CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objApi = new APIProcedure();
    float TotalAmt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {


            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            TextBox13.Enabled = false;
            
            PrinterFill();
            ViewState["BillID_I"] = "";
            if (Request.QueryString["ID"] != null)
            {   
                GridFillLoad();                           
            }
            if (Request.QueryString["vw"] != null )
            {
                string strvw = objApi.Decrypt(Request.QueryString["vw"]).ToString();
                if (strvw == "1")
                {
                Button1.Visible = false;
                btnBack.Visible = true;

                ddlPrinter.Enabled = false;
                pnlBillDetail.Enabled = false;
                pnlMain.Enabled = false;
                DdlACYear.Enabled = false;

                HDNRedirect.Text = "Printing/ViewPRI008FinalBillDetails.aspx";
                }
                else if (strvw == "home")
                {
                    Button1.Visible = false;
                    btnBack.Visible = true;

                    ddlPrinter.Enabled = false;
                    pnlBillDetail.Enabled = false;
                    pnlMain.Enabled = false;
                    DdlACYear.Enabled = false;

                    HDNRedirect.Text = "EmployeeHome.aspx";
                }
                else if (strvw == "rpt")
                {
                    Button1.Visible = false;
                    btnBack.Visible = true;

                    ddlPrinter.Enabled = false;
                    pnlBillDetail.Enabled = false;
                    pnlMain.Enabled = false;
                    DdlACYear.Enabled = false;

                    HDNRedirect.Text = "VoucherBillRpt.aspx";
                }
            }
        }
    }

    public void GridFillLoad()
    {
        try
        {
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.BillID_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"]).ToString());
            hdnID.Value = objBillDetails.BillID_I.ToString();
           
            ds = objBillDetails.FieldFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
              
                ViewState["BillID_I"] = objApi.Decrypt(Request.QueryString["ID"]).ToString();
                ddlPrinter.ClearSelection();
                PrinterFill();
                ddlPrinter.Items.FindByValue(ds.Tables[0].Rows[0]["PrinterID_I"].ToString()).Selected = true;

                Label6.Text = ds.Tables[0].Rows[0]["BalanceSecurity"].ToString();
                Label2.Text = ds.Tables[0].Rows[0]["PrintingCharges1"].ToString();
                Label3.Text = ds.Tables[0].Rows[0]["PaperSecurity"].ToString();
                TextBox1.Text = ds.Tables[0].Rows[0]["substandardbadPrinting"].ToString();
                TextBox2.Text = ds.Tables[0].Rows[0]["Penaltyformistakes"].ToString();

                TextBox4.Text = ds.Tables[0].Rows[0]["DelaysupplyofBooks"].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0]["ExpenditureonbehalfofPrinters"].ToString();
                TextBox6.Text = ds.Tables[0].Rows[0]["SalableBooks"].ToString();
                TextBox7.Text = ds.Tables[0].Rows[0]["balancepaperwithprinter"].ToString();
                TextBox8.Text = ds.Tables[0].Rows[0]["IncomeTax"].ToString();

                TextBox9.Text = ds.Tables[0].Rows[0]["TransportationCharges"].ToString();
                TextBox10.Text = ds.Tables[0].Rows[0]["Interestonpaper"].ToString();
                TextBox11.Text = ds.Tables[0].Rows[0]["deductionifany"].ToString();
                TextBox12.Text = ds.Tables[0].Rows[0]["PrintingCharges"].ToString();
                Label7.Text = ds.Tables[0].Rows[0]["Atotal"].ToString();
                Label8.Text = ds.Tables[0].Rows[0]["BTotal"].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0]["delaysubmissionofProof"].ToString();
                TextBox13.Text = ds.Tables[0].Rows[0]["NetPayable_N"].ToString();    
                //NetPayDeduction();                   
            
               
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
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
            if (Request.QueryString["ID"] != null)
            {
                objBillDetails.Type_ID = 5;
            }
            else
                objBillDetails.Type_ID = 6;
            objBillDetails.ChallanRecDate_D = DateTime.Parse("2017/07/24");
            objBillDetails.BillDate_D = DateTime.Parse("2017/07/24");
            ds = objBillDetails.BillChildDetailsFill();
            dta = obCommonFuction.FillDatasetByProc("call USP_getPrintingCharge("+ddlPrinter.SelectedValue+")");
            Label6.Text = Convert.ToString(dta.Tables[0].Rows[0]["PrnChrg25per_N"].ToString());
            Label2.Text = Convert.ToString(dta.Tables[0].Rows[0]["PapSecReimburse_N"].ToString());
            Label3.Text = Convert.ToString(dta.Tables[0].Rows[0]["BalSecurity_N"].ToString());
            Label7.Text = Convert.ToString(Convert.ToDouble(Label6.Text) + Convert.ToDouble(Label2.Text) + Convert.ToDouble(Label3.Text));
        //    GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
        //    GrdPaperCoverAndPrintingChares.DataBind();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        txtPaperSecurityDeposit.Text = ds.Tables[0].Rows[0]["dPaperSecurityAmount_N"].ToString();
        //        txtDepotExpenditure.Text = ds.Tables[0].Rows[0]["dDedDepoExp_N"].ToString();
        //        txtTotalPaperSupply.Text = ds.Tables[0].Rows[0]["TotPaperConsum_Wastage_N"].ToString();
        //        txtTotalCoverPaperSupply.Text = ds.Tables[0].Rows[0]["TotCoverPaperConsum_Wastage_N"].ToString();
        //    }
        //    else
        //    {
        //        txtPaperSecurityDeposit.Text = "";
        //        txtDepotExpenditure.Text = "";
        //    }
          
        //    OnLoad();

        }
        else
        {
        //    GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
        //    GrdPaperCoverAndPrintingChares.DataBind();
        //    txtPrintingCharge.Text = "0";
        //    txtPrintingCharge25Per.Text = "0";
        //    txtPrintingCharge75Per.Text = "0";
        }
    }

    protected void txtBlankPages_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        Label lblRate_N = (Label)gv.FindControl("lblRate_N");
        Label lblAmount = (Label)gv.FindControl("lblAmount");
        Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        TextBox txtLibBook= (TextBox)gv.FindControl("txtLibBook");
        TextBox txtPapterConsumption = (TextBox)gv.FindControl("txtPapterConsumption");
        TextBox txtCoverPapterConsumption = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
       
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

        Amt = ((Qty+Lib) * Rate * TotalPage) / 8000;

        lblAmount.Text = Math.Round(Amt, 0).ToString("0.00");


        
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
      
        
    }
    public void CalAmt()
   {
        try
        {
            //double Amount = 0; string ChalanNo = "";
            //foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
            //{
            //    Label lblAmount = (Label)gv.FindControl("lblAmount");
            //    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
            //    HiddenField hdChalanNo = (HiddenField)gv.FindControl("hdChalanNo");
            //    try
            //    {
            //        if (chkSelect.Checked == true)
            //        {
            //            if (lblAmount.Text == "")
            //            {
            //                lblAmount.Text = "0";
            //            }
            //            Amount = Amount + float.Parse(lblAmount.Text);
            //            ChalanNo += hdChalanNo.Value + ",";
            //        }
            //    }
            //    catch { }

            //}
            //Amount = Math.Round(Amount,0);
            //txtPrintingCharge.Text = Amount.ToString("0.00");
            //txtPrintingCharge25Per.Text = Math.Round(((Amount * 25) / 100),0).ToString("0.00");
            //txtPrintingCharge75Per.Text =Math.Round( ((Amount * 75) / 100),0).ToString("0.00");
            //txt2PerInComeTAX.Text = Math.Round(((Convert.ToDouble(txtPrintingCharge75Per.Text) * 2) / 100), 0).ToString("0.00");

            ////calculate interest chalan wise - 8/5/2017
            //ChalanNo = ChalanNo.Substring(ChalanNo.Length - (ChalanNo.Length), (ChalanNo.Length - 1));
            //txtPaperInterest.Text    = CalInterest(ChalanNo);
            //txtDepotExpenditure.Text = CalDepoExpenditure(ChalanNo);
            //txtShortSizeBookDeduction.Text = CallKatotra(ChalanNo);

            OnLoad();
        }
        catch { }
    }

    public string CalInterest(string chalanno)
    {
        //objBillDetails = new Pri_BillDetails_New();
        
        string res = "0";
        
        //objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
        //DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',1,'" + objBillDetails.ChallanRecDate_D  + "')");
        //if(Dt.Rows.Count > 0)
        //{
        //    try{
        //       res = Dt.Compute("Sum(BillAmount)", "").ToString();
        //    }catch{}
            
        //}
        return res;
    }

    public string CalDepoExpenditure(string chalanno)
    {
        
        string res = "0";
        //DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',2,'" + DateTime.Parse(txtChalanrecDate.Text, cult) + "')");
        //if (Dt.Rows.Count > 0)
        //{
        //    try
        //    {
        //        res = Dt.Compute("Sum(dDedDepoExp_N)", "").ToString();
        //    }
        //    catch { }

        //}
        return res;
    }

    public string CalIDepoExpenditure(string printerid, string chalanno)
    {
       
        string res = "0";
        //DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',2,'" + DateTime.Parse(txtChalanrecDate.Text, cult) + "')");
        //if (Dt.Rows.Count > 0)
        //{
        //    try
        //    {
        //        res = Dt.Rows[0][0].ToString();
        //    }
        //    catch { }

        //}
        return res;
    }

    public string CallKatotra(string chalanno)
    {
        
        string res = "0";
        //DataTable Dt = obCommonFuction.FillTableByProc("call usp_getinterest_depoexpenditure('" + chalanno + "','" + ddlPrinter.SelectedValue + "',3,'" + DateTime.Parse(txtChalanrecDate.Text, cult) + "')");
        //if (Dt.Rows.Count > 0)
        //{
        //    try
        //    {
        //        res = Dt.Rows[0][0].ToString();
        //    }
        //    catch { }

        //}
        return res;
    }

    public void isEmpty()
    {
        //if (txt2PerInComeTAX.Text == "")
        //{ txt2PerInComeTAX.Text = "0"; }

        //if (txtBalancePaperSecurityReimbursed.Text == "")
        //{ txtBalancePaperSecurityReimbursed.Text = "0"; }
        //if (txtBFPay.Text == "")
        //{ txtBFPay.Text = "0"; }
        //if (txtBillAmount.Text == "")
        //{ txtBillAmount.Text = "0"; }

        //if (txtBillAmountofDeduction.Text == "")
        //{ txtBillAmountofDeduction.Text = "0"; }
        //if (txtBillNetPayablePrinting.Text == "")
        //{ txtBillNetPayablePrinting.Text = "0"; }
        //if (txtDeductionPaperSecurity.Text == "")
        //{ txtDeductionPaperSecurity.Text = "0"; }
        //if (txtDelaySupplyPenalty.Text == "")
        //{ txtDelaySupplyPenalty.Text = "0"; }
        //if (txtDepotExpenditure.Text == "")
        //{ txtDepotExpenditure.Text = "0"; }
        //if (txtNetPayable.Text == "")
        //{ txtNetPayable.Text = "0"; }


        //if (txtPaperInterest.Text == "")
        //{ txtPaperInterest.Text = "0"; }
        //if (txtPaperSecurityDeposit.Text == "")
        //{ txtPaperSecurityDeposit.Text = "0"; }
        //if (txtPaperSecurityFor.Text == "")
        //{ txtPaperSecurityFor.Text = "0"; }
        //if (txtPaperSecurityReimbursed.Text == "")
        //{ txtPaperSecurityReimbursed.Text = "0"; }
        //if (txtPayBlePrintingCharg.Text == "")
        //{ txtPayBlePrintingCharg.Text = "0"; }
        //if (txtPrintingCharge.Text == "")
        //{ txtPrintingCharge.Text = "0"; }


        //if (txtPrintingCharge25Per.Text == "")
        //{ txtPrintingCharge25Per.Text = "0"; }
        //if (txtPrintingCharge75Per.Text == "")
        //{ txtPrintingCharge75Per.Text = "0"; }
        //if (txtReemPaperRs.Text == "")
        //{ txtReemPaperRs.Text = "0"; }
        //if (txtReimburseAmount.Text == "")
        //{ txtReimburseAmount.Text = "0"; }
        //if (txtRs2.Text == "")
        //{ txtRs2.Text = "0"; }
        //if (txtRs3.Text == "")
        //{ txtRs3.Text = "0"; }

        //if (txtShortSizeBookDeduction.Text == "")
        //{ txtShortSizeBookDeduction.Text = "0"; }
        //if (txtTonsPerReem.Text == "")
        //{ txtTonsPerReem.Text = "0"; }
        //if (txtTotalCoverPaperSupply.Text == "")
        //{ txtTotalCoverPaperSupply.Text = "0"; }
        //if (txtTotalDeduction.Text == "")
        //{ txtTotalDeduction.Text = "0"; }


        //if (txtTotalPaperSupply.Text == "")
        //{ txtTotalPaperSupply.Text = "0"; }
        //if (txtTotalPaybleAmount.Text == "")
        //{ txtTotalPaybleAmount.Text = "0"; }

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Printing/ViewPRI008FinalBillDetails.aspx");
        Response.Redirect("~/"+HDNRedirect.Text);
    }

    protected void btnForward_Click(object sender, EventArgs e)
    {
       
        //PrinterID, PrintingCharges1, PaperSecurity, BalanceSecurity, substandardbadPrinting, Penaltyformistakes, DelaysupplyofBooks, ExpenditureonbehalfofPrinters, SalableBooks, balancepaperwithprinter, IncomeTax, TransportationCharges, Interestonpaper, deductionifany, PrintingCharges, Atotal, BTotal
        //objBillDetails = new Pri_BillDetails_New();

        //objBillDetails.Billno_V = txtBillNo.Text;
        //objBillDetails.BillDate_D = DateTime.Parse(txtBillDate.Text, cult);
        //objBillDetails.ChallanRecDate_D  = DateTime.Parse(txtChalanrecDate.Text, cult);
        //objBillDetails.PrinterID_I = int.Parse(ddlPrinter.SelectedItem.Value.ToString());
        //objBillDetails.TotalPaperSup_N = float.Parse(txtTotalPaperSupply.Text);
        //objBillDetails.TotCovPaperSup_N = float.Parse(txtTotalCoverPaperSupply.Text);
        //objBillDetails.PapSecReimburse_N = float.Parse(txtPaperSecurityReimbursed.Text);
        //objBillDetails.PaperSecurityDeposit = float.Parse(txtPaperSecurityDeposit.Text);
        //objBillDetails.BalSecurity_N = float.Parse(txtBalancePaperSecurityReimbursed.Text);
        //objBillDetails.PrnChrg100per_N = float.Parse(txtPrintingCharge.Text);
        //objBillDetails.PrnChrg25per_N = float.Parse(txtPrintingCharge25Per.Text);
        //objBillDetails.PrnChrg75per_N = float.Parse(txtPrintingCharge75Per.Text);
        //objBillDetails.PaperSecforton_N = float.Parse(txtPaperSecurityFor.Text);
        //objBillDetails.PaperReemRs_N = float.Parse(txtReemPaperRs.Text);
        //objBillDetails.TonsPerReem_N = float.Parse(txtTonsPerReem.Text);
        //objBillDetails.Reimburseamt_N = float.Parse(txtReimburseAmount.Text);
        //objBillDetails.PayablePrnchrg_N = float.Parse(txtTotalPaybleAmount.Text);
        //objBillDetails.Totalpayable_N = float.Parse(txtTotalPaybleAmount.Text);
        //objBillDetails.BFPay = float.Parse(txtBFPay.Text);
        //objBillDetails.DedIncometax_N = float.Parse(txt2PerInComeTAX.Text);
        //objBillDetails.DedpapSec_N = float.Parse(txtDeductionPaperSecurity.Text);
        //objBillDetails.DedDepoExp_N = float.Parse(txtDepotExpenditure.Text);
        //objBillDetails.DedInterestonpaper_N = float.Parse(txtPaperInterest.Text);
        //objBillDetails.PenDelaySup_N = float.Parse(txtDelaySupplyPenalty.Text);
        //objBillDetails.DedShotSizePaper1_N = float.Parse(txtShortSizeBookDeduction.Text);
        //objBillDetails.DedShotSizePaper2_N = float.Parse(txtRs2.Text);
        //objBillDetails.DedShotSizePaper3_N = float.Parse(txtRs3.Text);
        //objBillDetails.TotalDed_N = float.Parse(txtTotalDeduction.Text);
        //objBillDetails.NetPayable_N = float.Parse(txtNetPayable.Text);
        //objBillDetails.BillAmount = 0;
        //objBillDetails.BillAmountofDeduction = 0;
        //objBillDetails.BillNetPayablePrinting = 0;
        //objBillDetails.JobCode_V = "";
        //if (Request.QueryString["ID"] != null)
        //{
        //    objBillDetails.BillID_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"]).ToString());
        //}
        //else
        //{
        //    objBillDetails.BillID_I = 0;
        //}

        //if (Request.QueryString["ID"] != null)
        //{
        //    int i = objBillDetails.MasterUpdate();
        //    if (i > 0)
        //    {
        //        string CheckSts = "No";
        //        objBillDetails.BillDetID_I = -1;
        //        i = objBillDetails.ChildInsertDelete();
        //        foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
        //        {
        //             CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
        //             if (chkSelect.Checked == true)
        //             {
        //                 Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
        //                 Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        //                 Label lblRate_N = (Label)gv.FindControl("lblRate_N");
        //                 Label lblBillDetID_I = (Label)gv.FindControl("lblBillDetID_I");
        //                 Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        //                 Label lblAmount = (Label)gv.FindControl("lblAmount");
        //                 Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        //                 TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");
        //                 TextBox txtLibBook = (TextBox)gv.FindControl("txtLibBook");
        //                 TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
        //                 TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        //                 HiddenField hdPriTransID = (HiddenField)gv.FindControl("hdPriTransID");


        //                 if (txtPaperConsum_Wastage_N.Text == "")
        //                 { txtPaperConsum_Wastage_N.Text = "0"; }

        //                 if (txtCoverPaperConsum_Wastage_N.Text == "")
        //                 { txtCoverPaperConsum_Wastage_N.Text = "0"; }

        //                 if (txtBlankPages.Text == "")
        //                 { txtBlankPages.Text = "0"; }

        //                 if (lblTotalBlankPages_N.Text == "")
        //                 { lblTotalBlankPages_N.Text = "0"; }
        //                 if (lblAmount.Text == "")
        //                 { lblAmount.Text = "0"; }
        //                 objBillDetails.Depotid_I = 0;
        //                 objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
        //                 objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
        //                 objBillDetails.mLibraryBook = int.Parse(txtLibBook.Text);
        //                 objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
        //                 objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
        //                 objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
        //                 objBillDetails.Amount_N = float.Parse(lblAmount.Text);
        //                 objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
        //                 objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
        //                 //objBillDetails.BillID_I = 0;
        //                 objBillDetails.BillDetID_I = int.Parse(lblBillDetID_I.Text);
        //                 objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);
        //                 objBillDetails.PriTransID =  hdPriTransID.Value ;

        //                 objBillDetails.ChildInsertUpdate();
        //                 CheckSts = "Ok";
        //             }
        //        }
        //        if (CheckSts == "Ok")
        //        {
                    
        //            Response.Redirect("ViewBillDetails.aspx");
        //            obCommonFuction.EmptyTextBoxes(this);
        //            isEmpty();
        //            GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
        //            GrdPaperCoverAndPrintingChares.DataBind();
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record updated successfully.');", true);
        //        }

        //    }
        //    else
        //    {
               
        //        ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record Not Changed.');", true);
        //    }
        //}
        //else
        //{
        //    int i = objBillDetails.InsertUpdate();


        //        ViewState["BillID_I"] = i.ToString();
        //        string CheckSts = "No";
        //        foreach (GridViewRow gv in GrdPaperCoverAndPrintingChares.Rows)
        //        {
        //            CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
        //            if (chkSelect.Checked == true)
        //            {
        //                Label lblTitleID_I = (Label)gv.FindControl("lblTitleID_I");
        //                Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        //                Label lblRate_N = (Label)gv.FindControl("lblRate_N");

        //                Label lblPages_N = (Label)gv.FindControl("lblPages_N");
        //                Label lblAmount = (Label)gv.FindControl("lblAmount");
        //                TextBox txtPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtPapterConsumption");
        //                TextBox txtCoverPaperConsum_Wastage_N = (TextBox)gv.FindControl("txtCoverPapterConsumption");
        //                Label lblTotalBlankPages_N = (Label)gv.FindControl("lblTotalBlankPages_N");
        //                TextBox txtBlankPages = (TextBox)gv.FindControl("txtBlankPages");
        //                HiddenField hdPriTransID = (HiddenField)gv.FindControl("hdPriTransID");

        //                if (txtPaperConsum_Wastage_N.Text == "")
        //                { txtPaperConsum_Wastage_N.Text = "0"; }

        //                if (txtCoverPaperConsum_Wastage_N.Text == "")
        //                { txtCoverPaperConsum_Wastage_N.Text = "0"; }
        //                if (lblAmount.Text == "")
        //                { lblAmount.Text = "0"; }

        //                if (txtBlankPages.Text == "")
        //                { txtBlankPages.Text = "0"; }

        //                if (lblTotalBlankPages_N.Text == "")
        //                { lblTotalBlankPages_N.Text = "0"; }

        //                objBillDetails.BlankPages = int.Parse(txtBlankPages.Text);
        //                objBillDetails.TotBlankPage = int.Parse(lblTotalBlankPages_N.Text);
        //                objBillDetails.Depotid_I = 0;
        //                objBillDetails.Qty_N = float.Parse(lblTotalNoBook.Text);
        //                objBillDetails.Rate_N = float.Parse(lblRate_N.Text);
        //                objBillDetails.Pages_N = float.Parse(lblPages_N.Text);
        //                objBillDetails.Amount_N = float.Parse(lblAmount.Text);
        //                objBillDetails.PaperConsum_Wastage_N = float.Parse(txtPaperConsum_Wastage_N.Text);
        //                objBillDetails.CoverPaperConsum_Wastage_N = float.Parse(txtCoverPaperConsum_Wastage_N.Text);
        //                objBillDetails.BillID_I = i;
        //                objBillDetails.BillDetID_I = 0;
        //                objBillDetails.BookTitleID_I = int.Parse(lblTitleID_I.Text);
        //                objBillDetails.PriTransID = hdPriTransID.Value ;

        //                objBillDetails.ChildInsertUpdate();
        //                CheckSts = "Ok";
        //            }
        //        }
        //        if (CheckSts == "Ok")
        //        {
                    
        //            obCommonFuction.EmptyTextBoxes(this);
        //            isEmpty();
        //            GrdPaperCoverAndPrintingChares.DataSource = string.Empty;
        //            GrdPaperCoverAndPrintingChares.DataBind();
        //            lblFinanceMsg.Text = "Record saved successfully! Do You Want To Send Finance Department.";
        //            btnSendToFinance.Visible = true;
        //            lblFinanceMsg.Visible = true;
        //            btnForward.Visible = false;
                  
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record saved successfully.');", true);
        //        }
        //        else
        //        {
                    
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please Check Your Entry');", true);
                   
        //        }
        //    }
        //}

    }

    protected void btnSendToFinance_Click(object sender, EventArgs e)
    {
        
    }



    public void AmtCalPaper()
    {
        //float perSecAmt = 0, perSecRemin = 0;
        //try
        //{
        //    perSecAmt = float.Parse(txtPaperSecurityDeposit.Text);
        //}
        //catch { }
        //try
        //{
        //    perSecRemin = float.Parse(txtPaperSecurityReimbursed.Text);
        //}
        //catch { }

        //txtBalancePaperSecurityReimbursed.Text = (perSecAmt - perSecRemin).ToString("0.00");
    }
    public void OnLoad()
    {
        BillDesctionSection();
        TotDeduction();
        AbCal();
        NetPayDeduction();
        BillAmountCal();
        AmtCalPaper();
    }
    public void BillDesctionSection()
    {
        //float PrintingCharge75Per = 0, ReimburseAmount = 0, PayBlePrintingCharg = 0, Totamt = 0;
        //try
        //{
        //    PrintingCharge75Per = float.Parse(txtPrintingCharge75Per.Text);
        //}
        //catch { }

        //try
        //{
        //    ReimburseAmount = float.Parse(txtReimburseAmount.Text);
        //}
        //catch { }

        //try
        //{
        //    PayBlePrintingCharg = float.Parse(txtPayBlePrintingCharg.Text);
        //}
        //catch { }
        //try
        //{
        //    Totamt = PrintingCharge75Per + ReimburseAmount + PayBlePrintingCharg;
        //}
        //catch { }

        //txtTotalPaybleAmount.Text = Totamt.ToString("0.00");
        //TotDeduction();
    }

    public void TotDeduction()
    {
        //float PerInComeTAX = 0, DeductionPaperSecurity = 0, DepotExpenditure = 0, PaperInterest = 0, DelaySupplyPenalty = 0, ShortSizeBookDeduction = 0, Totamt = 0;
        //try
        //{
        //    PerInComeTAX = float.Parse(txt2PerInComeTAX.Text);
        //}
        //catch { PerInComeTAX = 0; }
        //try
        //{
        //    DeductionPaperSecurity = float.Parse(txtDeductionPaperSecurity.Text);
        //}
        //catch { DeductionPaperSecurity = 0; }

        //try
        //{
        //    DepotExpenditure = float.Parse(txtDepotExpenditure.Text);
        //}
        //catch { DepotExpenditure = 0; }
        //try
        //{
        //    PaperInterest = float.Parse(txtPaperInterest.Text);
        //}
        //catch { PaperInterest = 0; }

        //try
        //{
        //    DelaySupplyPenalty = float.Parse(txtDelaySupplyPenalty.Text);
        //}
        //catch { DelaySupplyPenalty = 0; }

        //try
        //{
        //    ShortSizeBookDeduction = float.Parse(txtShortSizeBookDeduction.Text);
        //}
        //catch { ShortSizeBookDeduction = 0; }

        //Totamt = (PerInComeTAX + DeductionPaperSecurity + DepotExpenditure + PaperInterest + DelaySupplyPenalty + ShortSizeBookDeduction);
        //txtTotalDeduction.Text = Totamt.ToString("0.00");
        //AbCal();

    }

    public void AbCal()
    {
        //float amt = 0, TotalPayAmt = 0, TotalDeduc = 0;
        //try
        //{
        //    TotalPayAmt = float.Parse(txtTotalPaybleAmount.Text);
        //}
        //catch { }
        //try
        //{
        //    TotalDeduc = float.Parse(txtTotalDeduction.Text);
        //}
        //catch { }
        //amt = TotalPayAmt - TotalDeduc;
        //txtNetPayable.Text = amt.ToString("0.00");
        //NetPayDeduction();

    }

    public void NetPayDeduction()
    {

        //txtBillAmountofDeduction.Text = txtNetPayable.Text;
        //BillAmountCal();
    }
    public void BillAmountCal()
    {

        //txtBillAmount.Text = txtTotalPaybleAmount.Text;
        //txtBillAmountofDeduction.Text = txtTotalDeduction.Text;
        //txtBillNetPayablePrinting.Text = txtNetPayable.Text;
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
        //OnLoad();
        //Label8.Text = txt2PerInComeTAX.Text;
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
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        //txtPrintingCharge.Text = "0";
        //txtPrintingCharge25Per.Text = "0";
        //txtPrintingCharge75Per.Text = "0";
        //txtTotalPaybleAmount.Text = "0";
        //txtBillAmount.Text = "0";
        //txtBillAmountofDeduction.Text = "0";
        //txtBillNetPayablePrinting.Text = "0";
        //txtPayBlePrintingCharg.Text = "0";
        //txtDepotExpenditure.Text = "0";
        //txtPaperInterest.Text = "0";
        //txt2PerInComeTAX.Text = "0";
        //CalAmt();
    }

    protected void txtLibBook_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txt.NamingContainer;
        Label lblTotalNoBook = (Label)gv.FindControl("lblTotalNoBook");
        Label lblRate_N = (Label)gv.FindControl("lblRate_N");
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
        }
    



       
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
        public string  PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int User_ID { get { return _User_ID; } set { _User_ID = value; } }
        public int Type_ID { get { return _Type_ID; } set { _Type_ID = value; } }
        public int mLibraryBook { get { return _mLibraryBook; } set { _mLibraryBook = value; } }

       

        public int MasterUpdate()
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
            

            int result = obDBAccess.executeMyQuery();
            return result;
        }
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
            obDBAccess.addParam("mReceiptDate", ChallanRecDate_D);
            obDBAccess.addParam("mBillDate", BillDate_D);       
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
            obDBAccess.execute("USP_Prin008_FinalBillDetailsFill", DBAccess.SQLType.IS_PROC);
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

        
    }
    
    
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
         //Label8.Text = TextBox1.Text;
         //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));    
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
          //if (TextBox1.Text == "")
          //  {
          //      TextBox1.Text = "0";
          //  }
          //  Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text));
          //  TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
       
    }
    protected void TextBox3_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox4_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
      
    }
    protected void TextBox7_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
        
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //if (TextBox6.Text == "")
            //{
            //    TextBox6.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox8_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();

            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //if (TextBox6.Text == "")
            //{
            //    TextBox6.Text = "0";
            //}
            //if (TextBox7.Text == "")
            //{
            //    TextBox7.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox8.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox9_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();

            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //if (TextBox6.Text == "")
            //{
            //    TextBox6.Text = "0";
            //}
            //if (TextBox7.Text == "")
            //{
            //    TextBox7.Text = "0";
            //}
            //if (TextBox8.Text == "")
            //{
            //    TextBox8.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox8.Text) + Convert.ToDouble(TextBox9.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox10_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
        
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //if (TextBox6.Text == "")
            //{
            //    TextBox6.Text = "0";
            //}
            //if (TextBox7.Text == "")
            //{
            //    TextBox7.Text = "0";
            //}
            //if (TextBox8.Text == "")
            //{
            //    TextBox8.Text = "0";
            //}
            //if (TextBox9.Text == "")
            //{
            //    TextBox9.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox8.Text) + Convert.ToDouble(TextBox9.Text) + Convert.ToDouble(TextBox10.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox11_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
        
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //if (TextBox6.Text == "")
            //{
            //    TextBox6.Text = "0";
            //}
            //if (TextBox7.Text == "")
            //{
            //    TextBox7.Text = "0";
            //}
            //if (TextBox8.Text == "")
            //{
            //    TextBox8.Text = "0";
            //}
            //if (TextBox9.Text == "")
            //{
            //    TextBox9.Text = "0";
            //}
            //if (TextBox10.Text == "")
            //{
            //    TextBox10.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox8.Text) + Convert.ToDouble(TextBox9.Text) + Convert.ToDouble(TextBox10.Text) + Convert.ToDouble(TextBox11.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void TextBox12_TextChanged(object sender, EventArgs e)
    {
        TotalNetPayable();
        
            //if (TextBox1.Text == "")
            //{
            //    TextBox1.Text = "0";
            //}
            //if (TextBox2.Text == "")
            //{
            //    TextBox2.Text = "0";
            //}
            //if (TextBox3.Text == "")
            //{
            //    TextBox3.Text = "0";
            //}
            //if (TextBox4.Text == "")
            //{
            //    TextBox4.Text = "0";
            //}
            //if (TextBox5.Text == "")
            //{
            //    TextBox5.Text = "0";
            //}
            //if (TextBox6.Text == "")
            //{
            //    TextBox6.Text = "0";
            //}
            //if (TextBox7.Text == "")
            //{
            //    TextBox7.Text = "0";
            //}
            //if (TextBox8.Text == "")
            //{
            //    TextBox8.Text = "0";
            //}
            //if (TextBox9.Text == "")
            //{
            //    TextBox9.Text = "0";
            //}
            //if (TextBox10.Text == "")
            //{
            //    TextBox10.Text = "0";
            //}
            //if (TextBox11.Text == "")
            //{
            //    TextBox11.Text = "0";
            //}
            //Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox8.Text) + Convert.ToDouble(TextBox9.Text) + Convert.ToDouble(TextBox10.Text) + Convert.ToDouble(TextBox11.Text) + Convert.ToDouble(TextBox12.Text));
            //TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            int mType = 0;
            if (hdnID.Value != "") { mType = int.Parse(hdnID.Value); } 

            //obCommonFuction.FillDatasetByProc("call USP_PRIN_PrintingFinalBillDetails(0," + ddlPrinter.SelectedValue + "," + Label2.Text + "," + Label3.Text + "," + Label6.Text + "," + TextBox1.Text + "," + TextBox2.Text + "," + TextBox4.Text + "," + TextBox5.Text + "," + TextBox6.Text + "," + TextBox7.Text + "," + TextBox8.Text + "," + TextBox9.Text + "," + TextBox10.Text + "," + TextBox11.Text + "," + TextBox12.Text + "," + Label7.Text + "," + Label8.Text + "," + TextBox3.Text + ",'" + DdlACYear.SelectedItem.Text + "','" + TextBox13.Text + "')");
            obCommonFuction.FillDatasetByProc("call USP_PRIN_PrintingFinalBillDetails('" + mType + "'," + ddlPrinter.SelectedValue + "," + Label2.Text + "," + Label3.Text + "," + Label6.Text + "," + TextBox1.Text + "," + TextBox2.Text + "," + TextBox4.Text + "," + TextBox5.Text + "," + TextBox6.Text + "," + TextBox7.Text + "," + TextBox8.Text + "," + TextBox9.Text + "," + TextBox10.Text + "," + TextBox11.Text + "," + TextBox12.Text + "," + Label7.Text + "," + Label8.Text + "," + TextBox3.Text + ",'" + DdlACYear.SelectedItem.Text + "','" + TextBox13.Text + "')");
            Response.Redirect("ViewPRI008FinalBillDetails.aspx");
            obCommonFuction.EmptyTextBoxes(this);
        }
        catch { }
    }

    private void TotalNetPayable()
    {
       
        try
        {
            if (TextBox1.Text == "")
            {
                TextBox1.Text = "0";
            }
            if (TextBox2.Text == "")
            {
                TextBox2.Text = "0";
            }
            if (TextBox3.Text == "")
            {
                TextBox3.Text = "0";
            }
            if (TextBox4.Text == "")
            {
                TextBox4.Text = "0";
            }
            if (TextBox5.Text == "")
            {
                TextBox5.Text = "0";
            }
            if (TextBox6.Text == "")
            {
                TextBox6.Text = "0";
            }
            if (TextBox7.Text == "")
            {
                TextBox7.Text = "0";
            }
            if (TextBox8.Text == "")
            {
                TextBox8.Text = "0";
            }
            if (TextBox9.Text == "")
            {
                TextBox9.Text = "0";
            }
            if (TextBox10.Text == "")
            {
                TextBox10.Text = "0";
            }
            if (TextBox11.Text == "")
            {
                TextBox11.Text = "0";
            }
            Label8.Text = Convert.ToString(Convert.ToDouble(TextBox1.Text) + Convert.ToDouble(TextBox2.Text) + Convert.ToDouble(TextBox3.Text) + Convert.ToDouble(TextBox4.Text) + Convert.ToDouble(TextBox5.Text) + Convert.ToDouble(TextBox6.Text) + Convert.ToDouble(TextBox7.Text) + Convert.ToDouble(TextBox8.Text) + Convert.ToDouble(TextBox9.Text) + Convert.ToDouble(TextBox10.Text) + Convert.ToDouble(TextBox11.Text) + Convert.ToDouble(TextBox12.Text));
            TextBox13.Text = Convert.ToString(Convert.ToDouble(Label7.Text) - Convert.ToDouble(Label8.Text));
        }
        catch { }
    }
}