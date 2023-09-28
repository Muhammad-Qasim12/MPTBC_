using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_PaperRequirement
    {
        private int _PprReq_Id_i;
        private int _PaperVendorTrId_I;
        private int _ReqQty_i;
        private DateTime _UpToDate_D;
        private string _Status_V;
        private int _UserId_I;


        public int PprReq_Id_i { get { return _PprReq_Id_i; } set { _PprReq_Id_i = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int ReqQty_i { get { return _ReqQty_i; } set { _ReqQty_i = value; } }
        public DateTime UpToDate_D { get { return _UpToDate_D; } set { _UpToDate_D = value; } }
        public string Status_V { get { return _Status_V; } set { _Status_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperRequirementSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPprReq_Id_i", PprReq_Id_i);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mReqQty_i", ReqQty_i);
            obDBAccess.addParam("mUpToDate_D", UpToDate_D);           
            obDBAccess.addParam("mUserId_I", UserId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet VendorFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperRequirementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPprReq_Id_i", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }


        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperRequirementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPprReq_Id_i", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet PaperReqDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperRequirementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPprReq_Id_i", PprReq_Id_i);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperRequirementDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPprReq_Id_i", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
