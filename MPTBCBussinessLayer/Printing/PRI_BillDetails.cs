using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class Pri_BillDetails
    {


        private int _Printer_RedID_I;
        private int _ChallanTrno_I;
        private int _PriTransID;
        private int _User_ID;

        private int _BillID_I;
        private string _Billno_V;
        private DateTime _BillDate_D;
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

         private int _BlankPages ;
         private int _TotBlankPage;

        //Details
        private int _BillDetID_I;
        private int _Depotid_I;
        private float _Qty_N;
        private float _Rate_N;
        private float _Pages_N;
        private float _Amount_N;
        private float _PaperConsum_Wastage_N;
        private float _CoverPaperConsum_Wastage_N;


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



        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public int ChallanTrno_I { get { return _ChallanTrno_I; } set { _ChallanTrno_I = value; } }
        public int PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int User_ID { get { return _User_ID; } set { _User_ID = value; } }

        public int MasterUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI003_BillDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillID_I", BillID_I);
            obDBAccess.addParam("mBillno_V", Billno_V);
            obDBAccess.addParam("mBillDate_D", BillDate_D);
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
            return obDBAccess.records();
        }
        public System.Data.DataSet BillChildDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
           
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I", 0);
            obDBAccess.addParam("mtype", 1);
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
            return obDBAccess.records();
           
        }

        public System.Data.DataSet SelectSearch()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFillSearch", DBAccess.SQLType.IS_PROC);

            obDBAccess.addParam("mPrinter",JobCode_V );

            return obDBAccess.records();
           

        }
        public System.Data.DataSet FieldFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Prin001_BillDetailsFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillDetID_I", 0);
            obDBAccess.addParam("mBillID_I",BillID_I);
            obDBAccess.addParam("mPrinter_RedID_I", 0);
            obDBAccess.addParam("mChallanTrno_I", 0);
            obDBAccess.addParam("mPriTransID", 0);
            obDBAccess.addParam("mUser_ID", 0);
            obDBAccess.addParam("mtype", 3);
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
