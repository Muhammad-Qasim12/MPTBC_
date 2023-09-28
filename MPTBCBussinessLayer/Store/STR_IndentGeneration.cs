using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_IndentGeneration :ICommon
    {
        private Int32 _IndentID_I;
        private DateTime _IndentDate_D;
        private Int32 _DepartmentID_I;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;
        private Int32 _IndentDetailID_I;
        private Int32 _CategoryID_I;
        private Int32 _ItemID_I;
        private Int32 _SpecificationTrNo_I;
        private Int32 _RequiredQuantity_I;
        private Int32 _ApprovedQty_I;
        private Int32 _IsAccepted_I;
        private string _Remark_V;
        private Int32 _LID;
        private string _ItemName_V;
        private string _CategoryType_V;
        public string _Specification_V;
        public Int32 _ID;
        public Int32 _OpeningStockID_I;
        public Int32 _Quantity_I;
        public Int32 _UpdateQty;
        private string _Status_V;

        public Int32 IndentID_I { get { return _IndentID_I; } set { _IndentID_I = value; } }
        public DateTime IndentDate_D { get { return _IndentDate_D; } set { _IndentDate_D = value; } }
        public Int32 DepartmentID_I { get { return _DepartmentID_I; } set { _DepartmentID_I = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public Int32 IndentDetailID_I { get { return _IndentDetailID_I; } set { _IndentDetailID_I = value; } }
        public Int32 CategoryID_I { get { return _CategoryID_I; } set { _CategoryID_I = value; } }
        public Int32 ItemID_I { get { return _ItemID_I; } set { _ItemID_I = value; } }
        public Int32 SpecificationTrNo_I { get { return _SpecificationTrNo_I; } set { _SpecificationTrNo_I = value; } }
        public Int32 RequiredQuantity_I { get { return _RequiredQuantity_I; } set { _RequiredQuantity_I = value; } }
        public Int32 ApprovedQty_I { get { return _ApprovedQty_I; } set { _ApprovedQty_I = value; } }
        public Int32 IsAccepted_I { get { return _IsAccepted_I; } set { _IsAccepted_I = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public Int32 LID { get { return _LID; } set { _LID = value; } }
        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public string ItemName_V { get { return _ItemName_V; } set { _ItemName_V = value; } }
        public string CategoryType_V { get { return _CategoryType_V; } set { _CategoryType_V = value; } }
        public string Specification_V { get { return _Specification_V; } set { _Specification_V = value; } }

        public Int32 OpeningStockID_I { get { return _OpeningStockID_I; } set { _OpeningStockID_I = value; } }
        public Int32 Quantity_I { get { return _Quantity_I; } set { _Quantity_I = value; } }
        public Int32 UpdateQty { get { return _UpdateQty; } set { _UpdateQty = value; } }
        public string Status_V { get { return _Status_V; } set { _Status_V = value; } }
        public string Type { get ; set ; } 

        public int InsertUpdate()
        {
            LID=0;
            if(IndentID_I!=0)
            {
            LID=IndentID_I;
            }
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_IndentGeneration", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mIndentID_I", IndentID_I);
            obDBAccess.addParam("mIndentDate_D", IndentDate_D);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);
            obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32, DBAccess.SqlDirection.OUT);

            int result = obDBAccess.executeMyQuery();
            LID = Convert.ToInt32(obDBAccess.getParameter(5).ToString());
            return LID;
        }
        public int InsertUpdateDetails()
        {
            LID = 0;
            if (IndentID_I != 0)
            {
                LID = IndentID_I;
            }
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_IndentGenerationDetailSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mIndentDetailID_I", IndentDetailID_I);
            obDBAccess.addParam("mIndentID_I", IndentID_I);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mSpecificationTrNo_I", SpecificationTrNo_I);
            obDBAccess.addParam("mRequiredQuantity_I", RequiredQuantity_I);
            obDBAccess.addParam("mApprovedQty_I", ApprovedQty_I);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mIsAccepted_I", IsAccepted_I);
            obDBAccess.addParam("mOpeningStockID_I", OpeningStockID_I);
            obDBAccess.addParam("mUpdateQty", UpdateQty);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_IndentGenerationLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mIndentID_I", IndentID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public System.Data.DataSet FillUserIndent()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_IndentGenerationUserLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_IndentGenerationDetailDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mIndentDetailID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public System.Data.DataSet FillDDL()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR002_FillDDL", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryType_V", CategoryType_V);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mtype", Type);
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
        public System.Data.DataSet FillDDLSpecification()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR006_FillDDLSpecification", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
    }
}


