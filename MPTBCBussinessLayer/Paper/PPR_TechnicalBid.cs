using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace MPTBCBussinessLayer.Paper
{
    public class PPR_TechnicalBid
    {

        private int _TenderTrId_I;
        private int _Tender_Cond_Id;
        private int _Techn_TrId;
        private int _UserId_I;
        private int _PaperVendorTrId_I;
        private string _CheckStatus;

        public string CheckStatus { get { return _CheckStatus; } set { _CheckStatus = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int Tender_Cond_Id { get { return _Tender_Cond_Id; } set { _Tender_Cond_Id = value; } }
        public int Techn_TrId { get { return _Techn_TrId; } set { _Techn_TrId = value; } }
        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }


        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mTender_Cond_Id", 0);
            obDBAccess.addParam("mUserId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mCheckStatus", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();
        }


        public int insertBid()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", Techn_TrId);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mTender_Cond_Id", Tender_Cond_Id);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mCheckStatus", CheckStatus);

            obDBAccess.addParam("mtype", 0);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int UpdateBid()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", Techn_TrId);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mTender_Cond_Id", Tender_Cond_Id);
            obDBAccess.addParam("mUserId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mCheckStatus", CheckStatus);
            obDBAccess.addParam("mtype", 1);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet VendorCheck()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mTender_Cond_Id", 0);
            obDBAccess.addParam("mUserId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mCheckStatus", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet ConditionFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mTender_Cond_Id", 0);
            obDBAccess.addParam("mUserId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mCheckStatus", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet BidConditionFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mTender_Cond_Id", 0);
            obDBAccess.addParam("mUserId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mCheckStatus", 0);
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records();
        }
        public System.Data.DataSet SearchTender(string TenderNo)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0024_TechnicalBid", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTechn_TrId", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mTender_Cond_Id", 0);
            obDBAccess.addParam("mUserId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mCheckStatus", TenderNo);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records();
        }
    }
}
