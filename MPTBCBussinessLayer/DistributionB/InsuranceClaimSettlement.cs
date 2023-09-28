using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.DistributionB
{
    public class InsuranceClaimSettlement:ICommon
    {
        private Int32 _ClaimId_I;
        private string _LetterNo_V;
        private DateTime _ClaimDate_D;
        private Int32 _InsuranceCompany_I;
        private Int32 _DepoName_I;
        private Int32 _ClaimAmount_I;
        private string _ClaimReason_V;
        private Int32 _ReimbursedAmount_I;
        private DateTime _ReimbursedDate_D;
        private string _ReimbursedRemark_V;
        private DateTime _TrDate_D;
        private Int32 _UserTrNo_I;
        private string _ClaimType_V;

        public Int32 ClaimId_I { get { return _ClaimId_I; } set { _ClaimId_I = value; } }
        public string LetterNo_V { get { return _LetterNo_V; } set { _LetterNo_V = value; } }
        public DateTime ClaimDate_D { get { return _ClaimDate_D; } set { _ClaimDate_D = value; } }
        public Int32 InsuranceCompany_I { get { return _InsuranceCompany_I; } set { _InsuranceCompany_I = value; } }
        public Int32 DepoName_I { get { return _DepoName_I; } set { _DepoName_I = value; } }
        public Int32 ClaimAmount_I { get { return _ClaimAmount_I; } set { _ClaimAmount_I = value; } }
        public string ClaimReason_V { get { return _ClaimReason_V; } set { _ClaimReason_V = value; } }
        public Int32 ReimbursedAmount_I { get { return _ReimbursedAmount_I; } set { _ReimbursedAmount_I = value; } }
        public DateTime ReimbursedDate_D { get { return _ReimbursedDate_D; } set { _ReimbursedDate_D = value; } }
        public string ReimbursedRemark_V { get { return _ReimbursedRemark_V; } set { _ReimbursedRemark_V = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public string ClaimType_V { get { return _ClaimType_V; } set { _ClaimType_V = value; } }

       


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB016_InsuranceClaimSettlementSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimId_I", ClaimId_I);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mClaimDate_D", ClaimDate_D);
            obDBAccess.addParam("mClaimType_V", ClaimType_V);
            obDBAccess.addParam("mInsuranceCompany_I", InsuranceCompany_I);
            obDBAccess.addParam("mDepoName_I", DepoName_I);
            obDBAccess.addParam("mClaimAmount_I", ClaimAmount_I);
            obDBAccess.addParam("mClaimReason_V", ClaimReason_V);
            obDBAccess.addParam("mTrDate_D", TrDate_D);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mReimbursedAmount_I", ReimbursedAmount_I);
            obDBAccess.addParam("mReimbursedDate_D", ReimbursedDate_D);
            obDBAccess.addParam("mReimbursedRemark_V", ReimbursedRemark_V);

            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB016_InsuranceClaimSettlementLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimId_I", ClaimId_I);
            return obDBAccess.records();
           
        }
        public int SaveOtherInfo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB16_InsuranceClaimOtherInfo", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimID", ClaimId_I);
            obDBAccess.addParam("mLetterNO", LetterNo_V);
            obDBAccess.addParam("mLetterDate", ClaimDate_D);
            obDBAccess.addParam("mRemark", ClaimType_V);
            obDBAccess.addParam("mUserId", UserTrNo_I);
            obDBAccess.addParam("mTransID", 0);        

            int result = obDBAccess.executeMyQuery();
            return result;

        }
        public System.Data.DataSet SelectOther()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB16_InsuranceClaimOtherInfo", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimID", ClaimId_I);           
            obDBAccess.addParam("mLetterNO", LetterNo_V);
            obDBAccess.addParam("mLetterDate", ClaimDate_D);
            obDBAccess.addParam("mRemark", ClaimType_V);
            obDBAccess.addParam("mUserId", UserTrNo_I);
            obDBAccess.addParam("mTransID", -1);
            return obDBAccess.records();

        }
        public int DeleteOther()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB16_InsuranceClaimOtherInfo", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimID", ClaimId_I);
            obDBAccess.addParam("mLetterNO", LetterNo_V);
            obDBAccess.addParam("mLetterDate", ClaimDate_D);
            obDBAccess.addParam("mRemark", ClaimType_V);
            obDBAccess.addParam("mUserId", InsuranceCompany_I);
            obDBAccess.addParam("mTransID", -2);
            int result = obDBAccess.executeMyQuery();
            return result;

        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB016_InsuranceClaimSettlementDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
          
        }

        public DataSet FillCompany()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB016_FillCompany",DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClaimDate_D", ClaimDate_D);

            return obDBAccess.records();
        }
    }
}

