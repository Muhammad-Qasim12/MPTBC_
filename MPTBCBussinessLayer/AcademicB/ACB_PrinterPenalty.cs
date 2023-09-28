using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.AcademicB
{
    public class ACB_PrinterPenalty:ICommon
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
        private Int32 _UserTrNo_I;

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
         public Int32 UserTrNo_I{ get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }

        public int  workorderid_i { get { return _workorderid_i; } set { _workorderid_i = value; } }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB012_PenaltyDetailsSave", DBAccess.SQLType.IS_PROC);
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
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB012_PenaltyDetailsLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPenaltyID_I", PenaltyID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB012_PenaltyDetailDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPenaltyID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public DataSet PrinterAlldetails(int ID, int PrinterID_I, int GRPID_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Pri_PrinterAlldetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mGRPID_I", GRPID_I);
            return obDBAccess.records();
        }




        public DataSet FillJobCodeDetail() 
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbaccess.execute("USP_ACB012_JobCodeDetailLoadForPrinterPenalty", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mworkorderid_i", workorderid_i);

                ds= obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }

            return ds;
        }



    }
        
}

