using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
    public class InsuranceTenderEvaluation:ICommon
    {
        private int _TenderEvaluationTrId_I;
        private int _TenderTrId_I;
        private int _Venderid_I;
        private string _Qualify_Sts_V;
        private int _L_I;        
        private int  _UserId_I;
        private Decimal _BidRate_N;
        private DateTime _TechnicalDate;
        private DateTime _TenderEvaluationDate_D;
        //private Decimal _ReelExciseAmt;
        //private Decimal _ReelNonExciseAmt;
        //private Decimal _SheetExciseAmt;
        //private Decimal _SheetNonExciseAmt;
        //private Decimal _PerKmAmt;

        public DateTime TechnicalDate { get { return _TechnicalDate; } set { _TechnicalDate = value; } }
        public DateTime TenderEvaluationDate_D { get { return _TenderEvaluationDate_D; } set { _TenderEvaluationDate_D = value; } }
        //public Decimal ReelExciseAmt { get { return _ReelExciseAmt; } set { _ReelExciseAmt = value; } }
        //public Decimal ReelNonExciseAmt { get { return _ReelNonExciseAmt; } set { _ReelNonExciseAmt = value; } }
        //public Decimal SheetExciseAmt { get { return _SheetExciseAmt; } set { _SheetExciseAmt = value; } }
        //public Decimal SheetNonExciseAmt { get { return _SheetNonExciseAmt; } set { _SheetNonExciseAmt = value; } }
        //public Decimal PerKmAmt { get { return _PerKmAmt; } set { _PerKmAmt = value; } }



        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int TenderEvaluationTrId_I { get { return _TenderEvaluationTrId_I; } set { _TenderEvaluationTrId_I = value; } }
        public int Venderid_I { get { return _Venderid_I; } set { _Venderid_I = value; } }
        public string Qualify_Sts_V { get { return _Qualify_Sts_V; } set { _Qualify_Sts_V = value; } }
        public int L_I { get { return _L_I; } set { _L_I = value; } }
        public Decimal BidRate_N { get { return _BidRate_N; } set { _BidRate_N = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public decimal FlPremium { get; set; }
        public decimal FlServiceTax { get; set; }
        public decimal FlOtherTax { get; set; }
        public decimal BuPremium { get; set; }
        public decimal BuServiceTax { get; set; }
        public decimal BuOtherTax { get; set; }
        public string StringParameter { get; set; }
        public string Remark { get; set; }
        public int Is_L1 { get; set; }
        public string RemarkL1 { get; set; }

        public int InsertUpdate()
        {   
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);            
            obDBAccess.addParam("mUserId_I", UserId_I);
            //obDBAccess.addParam("mBidRate_N", BidRate_N);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet InsertChildData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            //obDBAccess.addParam("mBidRate_N", BidRate_N);

            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);
            obDBAccess.addParam("mFlPremium", FlPremium);
            obDBAccess.addParam("mFlServiceTax", FlServiceTax);
            obDBAccess.addParam("mFlOtherTax", FlOtherTax);
            obDBAccess.addParam("mBuPremium", BuPremium);
            obDBAccess.addParam("mBuServiceTax", BuServiceTax);
            obDBAccess.addParam("mBuOtherTax", BuOtherTax);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);
            obDBAccess.addParam("mRemark", Remark);
            obDBAccess.addParam("mEvalutionType", "L1");
            return obDBAccess.records();
        }

        public int UpdateTenderAmtData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationUpdateAmtData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);

            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);
            obDBAccess.addParam("mFlPremium", FlPremium);
            obDBAccess.addParam("mFlServiceTax", FlServiceTax);
            obDBAccess.addParam("mFlOtherTax", FlOtherTax);
            obDBAccess.addParam("mBuPremium", BuPremium);
            obDBAccess.addParam("mBuServiceTax", BuServiceTax);
            obDBAccess.addParam("mBuOtherTax", BuOtherTax);
            obDBAccess.addParam("mRemark", Remark);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        public int EvalutionUpdateData(string EvalutionType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            //obDBAccess.addParam("mBidRate_N", BidRate_N);            
            obDBAccess.addParam("mL_I", L_I);
            obDBAccess.addParam("mEvalutionType", EvalutionType);
            obDBAccess.addParam("mIs_L1", Is_L1);
            obDBAccess.addParam("mRemarkL1", RemarkL1);
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "0");
            return obDBAccess.records();
        }
        public System.Data.DataSet CheckEvalution()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "5");
            return obDBAccess.records();
        }
        public System.Data.DataSet EvalutionSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "4");
            return obDBAccess.records();
        }

        public System.Data.DataSet EvalutionSelectWithType(string FilterType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationAmtWise", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mFilterType", FilterType);        
            return obDBAccess.records();
        }


        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", id);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "3");
          

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet TenderSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB012_TenderInfoLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mStringParameter", StringParameter);
            return obDBAccess.records();
        }

        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB011_InsuranceCompanyLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCompanyID_I", 0);          
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithTender()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "6");
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithDlt()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mtype", "2");
            return obDBAccess.records();
        }
        
    }
}
