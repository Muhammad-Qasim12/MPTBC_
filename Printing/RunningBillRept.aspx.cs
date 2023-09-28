using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
using System.Data.SqlClient ;
using System.Globalization;
using MPTBCBussinessLayer;

public partial class RunningBillRept : System.Web.UI.Page
{
    public CommonFuction obj = new CommonFuction();
    public DBAccess db = new DBAccess();
    public DataSet ds;
    public APIProcedure objApi = new APIProcedure();
    Pri_BillDetails_New objBillDetails = null;
    public CultureInfo cult = new CultureInfo("gu-IN", true);
    protected string NameofPress_V = ""; protected string FullAddress_V = ""; protected string DdlACYear = "";
    protected string txtBillNo = ""; protected string txtBillDate = ""; protected string txtuptodate;
    protected string txtTotalPaperSupply ; protected string txtTotalCoverPaperSupply ; protected string txtPaperSecurityDeposit;
    protected string txtPaperSecurityReimbursed; protected string txtBalancePaperSecurityReimbursed;
     protected string txtTotalPayableWithGST;protected string  txtGST; protected string txtBillNetPayablePrinting ;
    protected string txtBillAmountofDeduction ; protected string txtBillAmount;protected string txtAmtReturnToPrinter;
       protected string txtNetPayable ; protected string txtTotalDeduction;protected string txtOtherDedAmt; protected string txtOtherDedDescription ;
    protected string txtTransportationDelvry ; protected string txtLooseBundlePack;
         protected string   txtPerfectBinding; protected string txtLamination; protected string txtPrintingMistakes ; protected string txtBadPrinting;
    protected string txtShortSizeBookDeduction; protected string  txtDelaySupplyPenalty;
        protected string  txtPaperInterest; protected string txtDepotExpenditure; protected string txtDeductionPaperSecurity ;
        protected string txt2PerInComeTAX; protected string txtTDSGST; protected string txtTotalPaybleAmount;
               protected string  txtReimburseAmount; protected string txtPrintingCharge75Per; protected string txtPrintingCharge25Per;
               protected string txtPrintingCharge;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                GridFillLoad();
            }
        }

    }

    decimal dTotalNoOfBooks = 0; decimal dRate_N = 0; decimal dAmount_N = 0; decimal dPaperConsum_Wastage_N = 0; decimal dCoverPaperConsum_Wastage_N = 0;
    decimal dPages_N = 0; decimal dLibraryBook = 0; decimal dBlankPages = 0; decimal dTotBlankPage = 0; decimal dBadPrintPenPercent = 0;
    protected void GrdCover_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            try
            {
                string TotalNoOfBooks = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotalNoOfBooks"));
                if (TotalNoOfBooks != "")
                {
                    dTotalNoOfBooks += decimal.Parse(TotalNoOfBooks);
                }
            }
            catch { }

            try
            {
                string Rate_N = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Rate_N"));
                if (Rate_N != "")
                {
                    dRate_N += decimal.Parse(Rate_N);
                }
            }
            catch { }

            try
            {
                string Amount_N = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Amount_N"));
                if (Amount_N != "")
                {
                    dAmount_N += decimal.Parse(Amount_N);
                }
            }
            catch { }

            try
            {
                string PaperConsum_Wastage_N = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PaperConsum_Wastage_N"));
                if (PaperConsum_Wastage_N != "")
                {
                    dPaperConsum_Wastage_N += decimal.Parse(PaperConsum_Wastage_N);
                }
            }
            catch { }

            try
            {
                string CoverPaperConsum_Wastage_N = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "CoverPaperConsum_Wastage_N"));
                if (CoverPaperConsum_Wastage_N != "")
                {
                    dCoverPaperConsum_Wastage_N += decimal.Parse(CoverPaperConsum_Wastage_N);
                }
            }
            catch { }

            try
            {
                string Pages_N = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Pages_N"));
                if (Pages_N != "")
                {
                    dPages_N += decimal.Parse(Pages_N);
                }
            }
            catch { }

            try
            {
                string LibraryBook = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "LibraryBook"));
                if (LibraryBook != "")
                {
                    dLibraryBook += decimal.Parse(LibraryBook);
                }
            }
            catch { }

            try
            {
                string BlankPages = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BlankPages"));
                if (BlankPages != "")
                {
                    dBlankPages += decimal.Parse(BlankPages);
                }
            }
            catch { }


            try
            {
                string TotBlankPage = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotBlankPage"));
                if (TotBlankPage != "")
                {
                    dTotBlankPage += decimal.Parse(TotBlankPage);
                }
            }
            catch { }

            try
            {
                string BadPrintPenPercent = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "BadPrintPenPercent"));
                if (BadPrintPenPercent != "")
                {
                    dBadPrintPenPercent += decimal.Parse(BadPrintPenPercent);
                }
            }
            catch { }
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label TotalNoOfBooks_f = (Label)e.Row.FindControl("TotalNoOfBooks_f");
            TotalNoOfBooks_f.Text = dTotalNoOfBooks.ToString("0");

            Label Rate_f = (Label)e.Row.FindControl("Rate_f");
            Rate_f.Text = dRate_N.ToString("0.00");

            Label Amount_N_f = (Label)e.Row.FindControl("Amount_N_f");
            Amount_N_f.Text = dAmount_N.ToString("0.00");

            Label PaperConsum_Wastage_N_f = (Label)e.Row.FindControl("PaperConsum_Wastage_N_f");
            PaperConsum_Wastage_N_f.Text = dPaperConsum_Wastage_N.ToString("0.000");

            Label CoverPaperConsum_Wastage_N_f = (Label)e.Row.FindControl("CoverPaperConsum_Wastage_N_f");
            CoverPaperConsum_Wastage_N_f.Text = dCoverPaperConsum_Wastage_N.ToString("0");

            Label Pages_N_f = (Label)e.Row.FindControl("Pages_N_f");
            Pages_N_f.Text = dPages_N.ToString("0");

            Label LibraryBook_f = (Label)e.Row.FindControl("LibraryBook_f");
            LibraryBook_f.Text = dLibraryBook.ToString("0");

            //Label BlankPages_f = (Label)e.Row.FindControl("BlankPages_f");
            //BlankPages_f.Text = dBlankPages.ToString("0");

            Label TotBlankPage_f = (Label)e.Row.FindControl("TotBlankPage_f");
            TotBlankPage_f.Text = dTotBlankPage.ToString("0");

            //Label BadPrintPenPercent_f = (Label)e.Row.FindControl("BadPrintPenPercent_f");
            //BadPrintPenPercent_f.Text = dBadPrintPenPercent.ToString("0.00");
        }
    }

    public void GridFillLoad()
    {
        try
        {
            objBillDetails = new Pri_BillDetails_New();
            objBillDetails.BillID_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"]).ToString());

            objBillDetails.BillDate_D = DateTime.Parse(System.DateTime.Now.ToString("dd/MM/yyyy"), cult);
            ds = objBillDetails.FieldFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime datch = new DateTime();
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["BillDate_D"].ToString());
                txtBillDate = dat.ToString("dd/MM/yyyy");
                // objBillDetails.ChallanRecDate_D = DateTime.Parse(txtChalanrecDate.Text, cult);
                if (ds.Tables[0].Rows[0]["challanupto"].ToString() != "")
                {
                    datch = DateTime.Parse(ds.Tables[0].Rows[0]["challanupto"].ToString());
                   // txtChalanrecDate.Text = datch.ToString("dd/MM/yyyy");
                }
                txtBillNo = ds.Tables[0].Rows[0]["Billno_V"].ToString();
                txtuptodate = datch.ToString("dd/MM/yyyy"); 

                NameofPress_V = ds.Tables[0].Rows[0]["NameofPress_V"].ToString();
                FullAddress_V = ds.Tables[0].Rows[0]["FullAddress_V"].ToString();

                ViewState["BillID_I"] = objApi.Decrypt(Request.QueryString["ID"]).ToString();
                //ddlPrinter.ClearSelection();
                //PrinterFill();
                //ddlPrinter.Items.FindByValue(ds.Tables[0].Rows[0]["Printer_RedID_I"].ToString()).Selected = true;
                string ddlPrinter= ds.Tables[0].Rows[0]["Printer_RedID_I"].ToString();
                DdlACYear = ds.Tables[0].Rows[0]["Acyear"].ToString();
                int isStatePRinter = int.Parse(ds.Tables[0].Rows[0]["IsStatePrinter"].ToString());
               
                txtTotalPaperSupply = ds.Tables[0].Rows[0]["TotPaperConsum_Wastage_N"].ToString();
                txtTotalCoverPaperSupply = ds.Tables[0].Rows[0]["TotCoverPaperConsum_Wastage_N"].ToString();
                txtPaperSecurityReimbursed = ds.Tables[0].Rows[0]["PapSecReimburse_N"].ToString();
                txtPaperSecurityDeposit = ds.Tables[0].Rows[0]["PaperSecurityDeposit"].ToString();
                txtBalancePaperSecurityReimbursed = ds.Tables[0].Rows[0]["BalSecurity_N"].ToString();
                txtPrintingCharge = ds.Tables[0].Rows[0]["PrnChrg100per_N"].ToString();
                txtPrintingCharge25Per = ds.Tables[0].Rows[0]["PrnChrg25per_N"].ToString();
                txtPrintingCharge75Per = ds.Tables[0].Rows[0]["PrnChrg75per_N"].ToString();
                txtPaperSecurityFor.Text = ds.Tables[0].Rows[0]["PaperSecforton_N"].ToString();
                txtReemPaperRs.Text = ds.Tables[0].Rows[0]["PaperReemRs_N"].ToString();
                txtTonsPerReem.Text = ds.Tables[0].Rows[0]["TonsPerReem_N"].ToString();
                txtReimburseAmount = ds.Tables[0].Rows[0]["Reimburseamt_N"].ToString();
                txtPayBlePrintingCharg.Text = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();
                txtTotalPaybleAmount = ds.Tables[0].Rows[0]["Totalpayable_N"].ToString();

                txtBFPay.Text = ds.Tables[0].Rows[0]["BFPay"].ToString();
                txt2PerInComeTAX = ds.Tables[0].Rows[0]["DedIncometax_N"].ToString();
                txtTDSGST = ds.Tables[0].Rows[0]["TDSonGST"].ToString();

                Literaligst.Text = ds.Tables[0].Rows[0]["TDSonGST"].ToString();
                Literalcgst.Text = ds.Tables[0].Rows[0]["TDSonGST"].ToString();
                Literalsgst.Text = ds.Tables[0].Rows[0]["tdscgst"].ToString();

                txtDeductionPaperSecurity = ds.Tables[0].Rows[0]["DedpapSec_N"].ToString();

                txtDepotExpenditure = ds.Tables[0].Rows[0]["DedDepoExp_N"].ToString();
                txtPaperInterest = ds.Tables[0].Rows[0]["DedInterestonpaper_N"].ToString();
                txtDelaySupplyPenalty = ds.Tables[0].Rows[0]["PenDelaySup_N"].ToString();
                txtShortSizeBookDeduction = ds.Tables[0].Rows[0]["DedShotSizePaper1_N"].ToString();
                txtRs2.Text = ds.Tables[0].Rows[0]["DedShotSizePaper2_N"].ToString();

                txtRs3.Text = ds.Tables[0].Rows[0]["DedShotSizePaper3_N"].ToString();
                txtTotalDeduction = ds.Tables[0].Rows[0]["TotalDed_N"].ToString();
                txtNetPayable = ds.Tables[0].Rows[0]["NetPayable_N"].ToString();


                txtOtherDedDescription = ds.Tables[0].Rows[0]["OtherDedDescription"].ToString();
                txtOtherDedAmt = ds.Tables[0].Rows[0]["OtherDedAmount"].ToString();

                txtBadPrinting = ds.Tables[0].Rows[0]["BadPrinting_N"].ToString();
                txtPrintingMistakes = ds.Tables[0].Rows[0]["PrintingMistakes_N"].ToString();
                txtLamination = ds.Tables[0].Rows[0]["Lamination_N"].ToString();
                txtPerfectBinding = ds.Tables[0].Rows[0]["PerfectBinding_N"].ToString();
                txtLooseBundlePack = ds.Tables[0].Rows[0]["LooseBundlePack_N"].ToString();
                txtTransportationDelvry = ds.Tables[0].Rows[0]["TransportationDelvryChrg_N"].ToString();
                //lblGSTAmt.Text = ds.Tables[0].Rows[0]["GSTAmt_N"].ToString();
                txtGST = ds.Tables[0].Rows[0]["GSTAmt_N"].ToString();
                txtAmtReturnToPrinter = ds.Tables[0].Rows[0]["AmtReturnToPrinter_N"].ToString();
                txtTotalPayableWithGST = ds.Tables[0].Rows[0]["TotAmtPayableWithGST_N"].ToString();

               NetPayDeduction();

               float fivepercent = float.Parse("5")/105; float netpaybal_75perc = 0; float gstpercent = float.Parse("0.025");
               try
               {
                   netpaybal_75perc = float.Parse(txtPrintingCharge != "" ? txtPrintingCharge : "0");
                   lblOutgst.Text = ds.Tables[0].Rows[0]["GSTAmt_N"].ToString();
                       // Math.Ceiling(((netpaybal_75perc) * fivepercent)).ToString("0.00");                 

                   //lblIngst_c.Text = Math.Ceiling(((netpaybal_75perc) * gstpercent)).ToString("0.00");
                   //lblIngst_s.Text = Math.Ceiling(((netpaybal_75perc) * gstpercent)).ToString("0.00");

                   string odd1;
                   odd1 = Math.Ceiling((float.Parse(lblOutgst.Text) % 2)).ToString("0");

                   //if (odd1 == "1")
                   //{

                       //lblIngst_c.Text = Math.Ceiling(((netpaybal_75perc) * gstpercent)).ToString("0.00");
                       //lblIngst_s.Text = Math.Ceiling(((netpaybal_75perc) * gstpercent)).ToString("0.00");

                   lblIngst_c.Text = Math.Round((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                   lblIngst_s.Text = Math.Round((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                   //}
                   //else
                   //{
                   //    lblIngst_c.Text = Math.Floor((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                   //    lblIngst_s.Text = Math.Floor((float.Parse(lblOutgst.Text) / 2)).ToString("0.00");
                   //}

                 


                  

                   hdngst.Value = (float.Parse(lblIngst_c.Text) + float.Parse(lblIngst_s.Text)).ToString("0.00"); 
               }
               catch { }

               if (isStatePRinter == 0)
               {
                   rdOut.Visible = true;
                   rdIn.Visible = false;
                   Div1.Visible = true;
                   Div4.Visible = true;
                   Div9.Visible = false;
                   Div5.Visible = false;
                   Div2.Visible = false;
                   Div3.Visible = false;
                   dvOutgst.Visible = true;
                   dvIngst_c.Visible =false;
                   dvIngst_s.Visible = false;
               }
               else if (isStatePRinter == 1)
               {
                   rdOut.Visible = false;
                   rdIn.Visible = true;
                   Div1.Visible = false;
                   Div9.Visible = true;
                   Div4.Visible = false;
                   Div5.Visible = true;
                   Div2.Visible = true;
                   Div3.Visible = true;
                   dvOutgst.Visible = false;
                   dvIngst_c.Visible = true;
                   dvIngst_s.Visible = true;
               }

                if (ddlPrinter != "")
                {
                    objBillDetails = new Pri_BillDetails_New();
                    objBillDetails.Printer_RedID_I = int.Parse(ddlPrinter);
                    objBillDetails.Type_ID = -5;
                    objBillDetails.BillID_I = int.Parse(ViewState["BillID_I"].ToString());
                    objBillDetails.mAcyear = DdlACYear;
                    ds = objBillDetails.BillChildDetailsFillnew();
                    GrdPaperCoverAndPrintingChares.DataSource = ds.Tables[0];
                    GrdPaperCoverAndPrintingChares.DataBind();
                }

                
                
            }
        }
        catch { }

    }

    protected string fnGetval(string blankpage, string pages)
    {
        if(blankpage != "0")
        {
            //return "235+1";
            int iBlankpage = int.Parse(blankpage);
            int iPages = int.Parse(pages);
            int result = iPages - iBlankpage;
            return result.ToString() + "+" + blankpage;
            
        }
        return pages;
    }

    public void NetPayDeduction()
    {

        txtBillAmountofDeduction = txtNetPayable;
        BillAmountCal();
    }
    public void BillAmountCal()
    {

        txtBillAmount = txtTotalPaybleAmount;
        txtBillAmountofDeduction = txtTotalDeduction;
        txtBillNetPayablePrinting = txtNetPayable;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("TentyFiveperReport.aspx");
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
}