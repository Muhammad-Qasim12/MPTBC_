using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
 public class DepoTenderEvaluation:ICommon 
    {
        
        private int _TenderEvaluationTrId_I;
        private int _TenderTrId_I;
        private int _Venderid_I;
        private string _Qualify_Sts_V;
        private int _L_I;        
        private int  _UserId_I;
        private float _BidRate_N;


        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int TenderEvaluationTrId_I { get { return _TenderEvaluationTrId_I; } set { _TenderEvaluationTrId_I = value; } }
        public int Venderid_I { get { return _Venderid_I; } set { _Venderid_I = value; } }
        public string Qualify_Sts_V { get { return _Qualify_Sts_V; } set { _Qualify_Sts_V = value; } }
        public int L_I { get { return _L_I; } set { _L_I = value; } }
        public float BidRate_N { get { return _BidRate_N; } set { _BidRate_N = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public DepoTenderEvaluation(int userid)
        {
            _UserId_I = userid;
        
        }

        public int InsertUpdate()
        {   
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_tenderevaluation_Save", DBAccess.SQLType.IS_PROC);
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
            obDBAccess.execute("USP_DPT024_tenderevaluation_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            return obDBAccess.records();
        }

        public int UpdateTenderAmtData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationUpdateAmtData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        public int EvalutionUpdateData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mL_I", L_I);
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "0");
            obDBAccess.addParam("DUserId_I", UserId_I);
            return obDBAccess.records();
        }
        public System.Data.DataSet CheckEvalution()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "5");
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            return obDBAccess.records();
        }
        public System.Data.DataSet EvalutionSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "4");
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            return obDBAccess.records();
        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", id);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            obDBAccess.addParam("mtype", "3");
          

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet TenderSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_FillTenderDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "1");
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithDlt()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT024_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mtype", "2");
            obDBAccess.addParam("DUserId_I", UserId_I);
            
            return obDBAccess.records();
        }
        
    }
    }

