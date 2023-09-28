using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public  class DepoTenderInfo:ICommon
    {
      private int _TenderTrId_I;
        private string _WorkName_V;
        private string _TenderType_V;
        private string _TenderNo_V;
        private DateTime _TenderDate_D;
        private float _EMDAmount_N;
        private float _TenderFees_N;
        private string _TenderDescription_V;
        private DateTime _TenderSubmissionDate_D;
        private string _TenderFile_V;
        private string _Remark_V;
        private int _UserId_I;

        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public string WorkName_V { get { return _WorkName_V; } set { _WorkName_V = value; } }
        public string TenderType_V { get { return _TenderType_V; } set { _TenderType_V = value; } }
        public string TenderNo_V { get { return _TenderNo_V; } set { _TenderNo_V = value; } }
        public DateTime TenderDate_D { get { return _TenderDate_D; } set { _TenderDate_D = value; } }
        public float EMDAmount_N { get { return _EMDAmount_N; } set { _EMDAmount_N = value; } }
        public float TenderFees_N { get { return _TenderFees_N; } set { _TenderFees_N = value; } }
        public string TenderDescription_V { get { return _TenderDescription_V; } set { _TenderDescription_V = value; } }
        public DateTime TenderSubmissionDate_D { get { return _TenderSubmissionDate_D; } set { _TenderSubmissionDate_D = value; } }
        public string TenderFile_V { get { return _TenderFile_V; } set { _TenderFile_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public DepoTenderInfo(int userid)
        {
            _UserId_I = userid;
        
        }
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT023_TenderInformation", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            //obDBAccess.addParam("TenderTrId_I", TenderTrId_I);
             obDBAccess.addParam("mWorkName_V", WorkName_V);
            obDBAccess.addParam("mTenderType_V", TenderType_V);
            obDBAccess.addParam("mTenderNo_V", TenderNo_V);
            obDBAccess.addParam("mTenderDate_D", TenderDate_D);
            obDBAccess.addParam("mTenderDescription_V", TenderDescription_V);            
            obDBAccess.addParam("mEMDAmount_N", EMDAmount_N);
            obDBAccess.addParam("mTenderFees_N", TenderFees_N);
            obDBAccess.addParam("mTenderSubmissionDate_D", TenderSubmissionDate_D);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mTenderFile_V", TenderFile_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT23_TenderInfoLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("DUserId_I", UserId_I);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT_023TenderInformationDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", id);
            //obDBAccess.addParam("DUserId_I", UserId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
    }

