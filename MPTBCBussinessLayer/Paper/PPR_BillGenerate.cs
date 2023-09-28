using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_BillGenerate
    {
        private int _BillGenId_I;
        private int _LOITrId_I;
        private string _BillNo_V;
        private DateTime _BillDate_D;
        private float _Amount_D;
        private int _Status_I;
        private int _PaperVendorTrId_I;
        private int _UserId_I;



        public int BillGenId_I { get { return _BillGenId_I; } set { _BillGenId_I = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public string BillNo_V { get { return _BillNo_V; } set { _BillNo_V = value; } }
        public DateTime BillDate_D { get { return _BillDate_D; } set { _BillDate_D = value; } }
        public float Amount_D { get { return _Amount_D; } set { _Amount_D = value; } }
        public int Status_I { get { return _Status_I; } set { _Status_I = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0012_BillGenerateSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillGenId_I", BillGenId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mBillNo_V", BillNo_V);
            obDBAccess.addParam("mBillDate_D", BillDate_D);
            obDBAccess.addParam("mAmount_D", Amount_D);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mStatus_I", Status_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet VendorFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0012_BillGenerateShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillGenId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet LoiFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0012_BillGenerateShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillGenId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }

        public System.Data.DataSet Select()        
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0012_BillGenerateShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillGenId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet BillDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0012_BillGenerateShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillGenId_I", BillGenId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0012_BillGenerateDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillGenId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
