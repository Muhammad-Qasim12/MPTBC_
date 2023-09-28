using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_PaperRequirementDispatch
    {



        private int _Dis_Id_I;
        private int _PprReq_Id_i;
        private DateTime _SupplyDt_D;
        private int _SupQty_i;
        private string _ChallanNo_V;
        private DateTime _ChallanDt_D;
        private int _UserId_I;

        public int Dis_Id_I { get { return _Dis_Id_I; } set { _Dis_Id_I = value; } }
        public int PprReq_Id_i { get { return _PprReq_Id_i; } set { _PprReq_Id_i = value; } }
        public DateTime SupplyDt_D { get { return _SupplyDt_D; } set { _SupplyDt_D = value; } }
        public int SupQty_i { get { return _SupQty_i; } set { _SupQty_i = value; } }
        public string ChallanNo_V { get { return _ChallanNo_V; } set { _ChallanNo_V = value; } }
        public DateTime ChallanDt_D { get { return _ChallanDt_D; } set { _ChallanDt_D = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0015_PaperRequirementDtlSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDis_Id_I", Dis_Id_I);
            obDBAccess.addParam("mPprReq_Id_i", PprReq_Id_i);
            obDBAccess.addParam("mSupplyDt_D", SupplyDt_D);
            obDBAccess.addParam("mSupQty_i", SupQty_i);
            obDBAccess.addParam("mChallanNo_V", ChallanNo_V);
            obDBAccess.addParam("mChallanDt_D", ChallanDt_D);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
       

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0015_PaperRequirementDtlShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPprReq_Id_i", 0);
            obDBAccess.addParam("mDis_Id_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);            
            obDBAccess.addParam("mtype", 0);
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
