using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_LOIDetails
    {

        private int _TenderTrId_I;
        private int _PaperVendorTrId_I;
        private int _LOITrId_I;
        private string _LOINo_V;
        private decimal _PBGAmount_N;
        private string _LOIFile_V;
        private string _Remark_V;
        private int _UserId_I;

        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public string LOINo_V { get { return _LOINo_V; } set { _LOINo_V= value; } }        
        public decimal PBGAmount_N { get { return _PBGAmount_N; } set { _PBGAmount_N = value; } }
        public string LOIFile_V { get { return _LOIFile_V; } set { _LOIFile_V = value; } }     
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOISaveUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mLOINo_V", LOINo_V);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mPBGAmount_N", PBGAmount_N);
            obDBAccess.addParam("mLOIFile_V", LOIFile_V);            
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result; 
        }
        public System.Data.DataSet AlredyEntryCheck(string Id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0023_CheckDataForDuplicateEnrty", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mFilterId", Id);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOIShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet SearchLOIName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOISearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOINo_V", LOINo_V);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOIDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet LOINoCheck()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOINoCheck", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOINo_V", LOINo_V);
            return obDBAccess.records();
        }








        public System.Data.DataSet TenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOIShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I",0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }

        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOIShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOIShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet LOIDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_LOIShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();
        }
    }
}
