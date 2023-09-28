using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_TenderEvaluation:ICommon
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
       
        
        private Decimal _BasicRate;
        private Decimal _ExciseDuty;
        private Decimal _Cess;
        private Decimal _EduCess;
        private Decimal _Surcharge;

         private Decimal _STCSTVAT;
        private Decimal _FreightUnloading;
        private Decimal _Insurance;
        private Decimal _TotalAmt;
        private Decimal _DisKm;
        private Decimal _DisKmAmt;
        private string _ChdRemark;
        private DateTime _CommDate;
        private string _CommTime;
        
        public DateTime CommDate { get { return _CommDate; } set { _CommDate = value; } }
        public string CommTime { get { return _CommTime; } set { _CommTime = value; } }

        public DateTime TechnicalDate { get { return _TechnicalDate; } set { _TechnicalDate = value; } }
        public DateTime TenderEvaluationDate_D { get { return _TenderEvaluationDate_D; } set { _TenderEvaluationDate_D = value; } }

        public Decimal BasicRate { get { return _BasicRate; } set { _BasicRate = value; } }
        public Decimal ExciseDuty { get { return _ExciseDuty; } set { _ExciseDuty = value; } }
        public Decimal Cess { get { return _Cess; } set { _Cess = value; } }
        public Decimal EduCess { get { return _EduCess; } set { _EduCess = value; } }
        public Decimal Surcharge { get { return _Surcharge; } set { _Surcharge = value; } }

        public Decimal STCSTVAT { get { return _STCSTVAT; } set { _STCSTVAT = value; } }
        public Decimal FreightUnloading { get { return _FreightUnloading; } set { _FreightUnloading = value; } }
        public Decimal Insurance { get { return _Insurance; } set { _Insurance = value; } }
        public Decimal TotalAmt { get { return _TotalAmt; } set { _TotalAmt = value; } }
        public Decimal DisKm { get { return _DisKm; } set { _DisKm = value; } }
        public Decimal DisKmAmt { get { return _DisKmAmt; } set { _DisKmAmt = value; } }
        public string ChdRemark { get { return _ChdRemark; } set { _ChdRemark = value; } }

        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int TenderEvaluationTrId_I { get { return _TenderEvaluationTrId_I; } set { _TenderEvaluationTrId_I = value; } }
        public int Venderid_I { get { return _Venderid_I; } set { _Venderid_I = value; } }
        public string Qualify_Sts_V { get { return _Qualify_Sts_V; } set { _Qualify_Sts_V = value; } }
        public int L_I { get { return _L_I; } set { _L_I = value; } }
        public Decimal BidRate_N { get { return _BidRate_N; } set { _BidRate_N = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {   
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);            
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet InsertChildData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);

            obDBAccess.addParam("mBasicRate", BasicRate);
            obDBAccess.addParam("mExciseDuty", ExciseDuty);
            obDBAccess.addParam("mCess", Cess);
            obDBAccess.addParam("mEduCess", EduCess);
            obDBAccess.addParam("mSurcharge", Surcharge);
            obDBAccess.addParam("mSTCSTVAT", STCSTVAT);
            obDBAccess.addParam("mFreightUnloading", FreightUnloading);
            obDBAccess.addParam("mInsurance", Insurance);
            obDBAccess.addParam("mTotalAmt", TotalAmt);
            obDBAccess.addParam("mDisKm", DisKm);

            obDBAccess.addParam("mDisKmAmt", DisKmAmt);
            obDBAccess.addParam("mRemark", ChdRemark);

            obDBAccess.addParam("mCommDate", CommDate);
            obDBAccess.addParam("mCommTime", CommTime); 
            return obDBAccess.records();
        }

        public int UpdateTenderAmtData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationUpdateAmtData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);

            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);

            obDBAccess.addParam("mBasicRate", BasicRate);
            obDBAccess.addParam("mExciseDuty", ExciseDuty);
            obDBAccess.addParam("mCess", Cess);
            obDBAccess.addParam("mEduCess", EduCess);
            obDBAccess.addParam("mSurcharge", Surcharge);
            obDBAccess.addParam("mSTCSTVAT", STCSTVAT);
            obDBAccess.addParam("mFreightUnloading", FreightUnloading);
            obDBAccess.addParam("mInsurance", Insurance);
            obDBAccess.addParam("mTotalAmt", TotalAmt);
            obDBAccess.addParam("mDisKm", DisKm); 
            obDBAccess.addParam("mDisKmAmt", DisKmAmt);
            obDBAccess.addParam("mRemark", ChdRemark);
            obDBAccess.addParam("mCommDate", CommDate);
            obDBAccess.addParam("mCommTime", CommTime); ;
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        public int EvalutionUpdateData(string EvalutionType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);            
            obDBAccess.addParam("mL_I", L_I);
            obDBAccess.addParam("mEvalutionType", EvalutionType);
            obDBAccess.addParam("mDisKm", 0); 

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "0");
            return obDBAccess.records();
        }
        public System.Data.DataSet CheckEvalution()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "5");
            return obDBAccess.records();
        }
        public System.Data.DataSet EvalutionSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "4");
            return obDBAccess.records();
        }

        public System.Data.DataSet EvalutionSelectWithType(string FilterType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationAmtWise", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mFilterType", FilterType);        
            return obDBAccess.records();
        }


        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
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
            obDBAccess.execute("USP_PPR001_TenderEvaluationFieldFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            return obDBAccess.records();
        }

        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "1");
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithTender()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "6");
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithDlt()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mtype", "2");
            return obDBAccess.records();
        }
        
    }
}
