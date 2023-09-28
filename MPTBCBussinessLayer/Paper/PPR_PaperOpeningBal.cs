using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Paper
{
 public   class PPR_PaperOpeningBal
    {
        private int _OpnBal_Id;
        private int _PaperTrId_I;
        private string _AcYear;
        private int _PaperType_I;
        private float _Qty;
        private int _UserId_I;



        public int OpnBal_Id { get { return _OpnBal_Id; } set { _OpnBal_Id = value; } }
        public int PaperTrId_I { get { return _PaperTrId_I; } set { _PaperTrId_I = value; } }
        public string AcYear { get { return _AcYear; } set { _AcYear = value; } }
        public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
        public float Qty { get { return _Qty; } set { _Qty = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        { 
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0016_PaperOpeningBal", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpnBal_Id", OpnBal_Id);
            obDBAccess.addParam("mPaperTrId_I", PaperTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mUser_Id", UserId_I);
            obDBAccess.addParam("mQty", Qty);
            obDBAccess.addParam("mtype",2);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet FillOpeningStock()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0016_PaperOpeningBal", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpnBal_Id", 0);
            obDBAccess.addParam("mPaperTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mUser_Id", 0);
            obDBAccess.addParam("mQty", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet SearchStock(string CoverInformation)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0016_PaperOpeningSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCoverInformation", CoverInformation);
            obDBAccess.addParam("mAcYear", AcYear);
            return obDBAccess.records();
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
