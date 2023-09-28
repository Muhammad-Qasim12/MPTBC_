using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_DamageReturn :ICommon
    {
        private Int32 _DamageReturnItemsID_I;
        private Int32 _IndentDetailID_I;
        private string _DamageReturnType_V;
        private Int32 _DamageRepairQuantity_I;
        private string _Remark_V;
        private Decimal _PerItemCost_DL;
        private Int32 _IsStoreAccepted;
        private string _DamageReturnStatus_V;
        private Decimal _RepairingAmount_DL;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;
       
        public Int32 _ID;
        public Int32 _OpeningStockID_I;
        public Int32 _Quantity_I;
        public Int32 _UpdateStoreQty;
        public Int32 _UpdateDptQty;
        public Int32 _DepartmentID_I;

        public Int32 DamageReturnItemsID_I { get { return _DamageReturnItemsID_I; } set { _DamageReturnItemsID_I = value; } }
        public Int32 IndentDetailID_I { get { return _IndentDetailID_I; } set { _IndentDetailID_I = value; } }
        public string DamageReturnType_V { get { return _DamageReturnType_V; } set { _DamageReturnType_V = value; } }
        public Int32 DamageRepairQuantity_I { get { return _DamageRepairQuantity_I; } set { _DamageRepairQuantity_I = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public Decimal PerItemCost_DL { get { return _PerItemCost_DL; } set { _PerItemCost_DL = value; } }
        public Int32 IsStoreAccepted { get { return _IsStoreAccepted; } set { _IsStoreAccepted = value; } }
        public string DamageReturnStatus_V { get { return _DamageReturnStatus_V; } set { _DamageReturnStatus_V = value; } }
        public Decimal RepairingAmount_DL { get { return _RepairingAmount_DL; } set { _RepairingAmount_DL = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public Int32 OpeningStockID_I { get { return _OpeningStockID_I; } set { _OpeningStockID_I = value; } }
        public Int32 Quantity_I { get { return _Quantity_I; } set { _Quantity_I = value; } }
        public Int32 UpdateStoreQty { get { return _UpdateStoreQty; } set { _UpdateStoreQty = value; } }
        public Int32 UpdateDptQty { get { return _UpdateDptQty; } set { _UpdateDptQty = value; } }
        public Int32 DepartmentID_I { get { return _DepartmentID_I; } set { _DepartmentID_I = value; } }
       

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR008_DamageReturnItemSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mDamageReturnItemsID_I", DamageReturnItemsID_I);
            obDBAccess.addParam("mIndentDetailID_I", IndentDetailID_I);
            obDBAccess.addParam("mDamageReturnType_V", DamageReturnType_V);
            obDBAccess.addParam("mDamageRepairQuantity_I", DamageRepairQuantity_I);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mPerItemCost_DL", PerItemCost_DL);
            obDBAccess.addParam("mIsStoreAccepted", IsStoreAccepted);
            obDBAccess.addParam("mDamageReturnStatus_V", DamageReturnStatus_V);
            obDBAccess.addParam("mRepairingAmount_DL", RepairingAmount_DL);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);
            obDBAccess.addParam("mOpeningStockID_I", OpeningStockID_I);
            obDBAccess.addParam("mUpdateStoreQty", UpdateStoreQty);
            obDBAccess.addParam("mUpdateDptQty", UpdateDptQty);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR008_UserTotalItemLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public System.Data.DataSet DamageReturnLoad()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR008_DamagereturnLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public System.Data.DataSet UserTotalItemLoad()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR008_UserTotalItemLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", 1);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDamageReturnItemsID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

    }
}



