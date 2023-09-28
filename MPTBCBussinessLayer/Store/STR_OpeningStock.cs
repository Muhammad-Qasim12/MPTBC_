using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_OpeningStock:ICommon
    {
        private Int32 _OpeningStockID_I;
        private Int32 _CategoryID_I;
        private Int32 _ItemID_I;
        private Int32 _SpecificationTrNo_I;
        private Int32 _Quantity_I;
        private Int32 _DepartmentID_I;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;
        private string _ItemName_V;
        private string _CategoryType_V;
        private string _Specification_V;
        private string _Status_V;

        public Int32 OpeningStockID_I { get { return _OpeningStockID_I; } set { _OpeningStockID_I = value; } }
        public Int32 CategoryID_I { get { return _CategoryID_I; } set { _CategoryID_I = value; } }
        public Int32 ItemID_I { get { return _ItemID_I; } set { _ItemID_I = value; } }
        public Int32 SpecificationTrNo_I { get { return _SpecificationTrNo_I; } set { _SpecificationTrNo_I = value; } }
        public Int32 Quantity_I { get { return _Quantity_I; } set { _Quantity_I = value; } }
        public Int32 DepartmentID_I { get { return _DepartmentID_I; } set { _DepartmentID_I = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public string CategoryType_V { get { return _CategoryType_V; } set { _CategoryType_V = value; } }
        public string ItemName_V { get { return _ItemName_V; } set { _ItemName_V = value; } }
        public string Specification_V { get { return _Specification_V; } set { _Specification_V = value; } }
        public string Status_V { get { return _Status_V; } set { _Status_V = value; } }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR004_OpeningStockSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpeningStockID_I", OpeningStockID_I);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mSpecificationTrNo_I", SpecificationTrNo_I);
            obDBAccess.addParam("mQuantity_I", Quantity_I);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public int InsertUpdateDeptStock()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_IndentGenerationDetailSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpeningStockID_I", OpeningStockID_I);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mSpecificationTrNo_I", SpecificationTrNo_I);
            obDBAccess.addParam("mQuantity_I", Quantity_I);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR004_OpeningStockLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpeningStockID_I", OpeningStockID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public System.Data.DataSet FillGridOpening()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR005_FillGridOpening", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpeningStockID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public System.Data.DataSet FillDDL()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR002_FillDDL", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryType_V", CategoryType_V);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public System.Data.DataSet FillDDLItem()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR003_FillDDLItemCategory", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
    }
}



