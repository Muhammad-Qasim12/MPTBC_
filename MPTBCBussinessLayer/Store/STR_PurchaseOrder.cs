using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_PurchaseOrder :ICommon
    {
        private Int32 _PurchaseOrderID_I;
        private DateTime _PurchaseOrderDate_D;
        private Int32 _Vendor_I;
        private DateTime _ExpectedReceivingDate_D;
        private string _ApprovalStatus_V;
        private Int32 _ApprovedBy_I;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;
        private string _Bill_V;
        private Int32 _PurchaseOrderDetailID_I;
        private Int32 _CategoryID_I;
        private Int32 _ItemID_I;
        private Int32 _SpecificationTrNo_I;
        private Int32 _PurchaseQuantity_I;
        private Int32 _ReceivedQuantity_I;
        private Int32 _LID;
        private string _ItemName_V;
        private string _CategoryType_V;
        public string _Specification_V;
        public Int32 _ID;
        public Int32 _OpeningStockID_I;
        public Int32 _Quantity_I;
        public Int32 _UpdateQty;
        private string _Remark_V;
        private Int32 _PerItemCost_I;

        public Int32 PurchaseOrderID_I { get { return _PurchaseOrderID_I; } set { _PurchaseOrderID_I = value; } }
        public DateTime PurchaseOrderDate_D { get { return _PurchaseOrderDate_D; } set { _PurchaseOrderDate_D = value; } }
        public Int32 Vendor_I { get { return _Vendor_I; } set { _Vendor_I = value; } }
        public DateTime ExpectedReceivingDate_D { get { return _ExpectedReceivingDate_D; } set { _ExpectedReceivingDate_D = value; } }
        public string ApprovalStatus_V { get { return _ApprovalStatus_V; } set { _ApprovalStatus_V = value; } }
        public Int32 ApprovedBy_I { get { return _ApprovedBy_I; } set { _ApprovedBy_I = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public string Bill_V { get { return _Bill_V; } set { _Bill_V = value; } }
        public Int32 PurchaseOrderDetailID_I { get { return _PurchaseOrderDetailID_I; } set { _PurchaseOrderDetailID_I = value; } }
        public Int32 CategoryID_I { get { return _CategoryID_I; } set { _CategoryID_I = value; } }
        public Int32 ItemID_I { get { return _ItemID_I; } set { _ItemID_I = value; } }
        public Int32 SpecificationTrNo_I { get { return _SpecificationTrNo_I; } set { _SpecificationTrNo_I = value; } }
        public Int32 PurchaseQuantity_I { get { return _PurchaseQuantity_I; } set { _PurchaseQuantity_I = value; } }
        public Int32 ReceivedQuantity_I { get { return _ReceivedQuantity_I; } set { _ReceivedQuantity_I = value; } }
        public Int32 LID { get { return _LID; } set { _LID = value; } }
        public string ItemName_V { get { return _ItemName_V; } set { _ItemName_V = value; } }
        public string CategoryType_V { get { return _CategoryType_V; } set { _CategoryType_V = value; } }
        public string Specification_V { get { return _Specification_V; } set { _Specification_V = value; } }
        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public Int32 OpeningStockID_I { get { return _OpeningStockID_I; } set { _OpeningStockID_I = value; } }
        public Int32 Quantity_I { get { return _Quantity_I; } set { _Quantity_I = value; } }
        public Int32 UpdateQty { get { return _UpdateQty; } set { _UpdateQty = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public Int32 PerItemCost_I { get { return _PerItemCost_I; } set { _PerItemCost_I = value; } }
        public string Type { get; set; } 

        public int InsertUpdate()
        {
            LID = 0;
            if (PurchaseOrderID_I != 0)
            {
                LID = PurchaseOrderID_I;
            }
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR007_PurchaseOrderSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mPurchaseOrderID_I", PurchaseOrderID_I);
            obDBAccess.addParam("mPurchaseOrderDate_D", PurchaseOrderDate_D);
            obDBAccess.addParam("mVendor_I", Vendor_I);
            obDBAccess.addParam("mExpectedReceivingDate_D", ExpectedReceivingDate_D);
            obDBAccess.addParam("mApprovalStatus_V", ApprovalStatus_V);
            obDBAccess.addParam("mApprovedBy_I", ApprovedBy_I);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);
            obDBAccess.addParam("mBill_V", Bill_V);
            obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32, DBAccess.SqlDirection.OUT);

            int result = obDBAccess.executeMyQuery();
            LID = Convert.ToInt32(obDBAccess.getParameter(10).ToString());
            return LID;
        }
        public int InsertUpdateDetails()
        {
            LID = 0;
            if (PurchaseOrderID_I != 0)
            {
                LID = PurchaseOrderID_I;
            }
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR007_PurchaseOrderDetailsSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mPurchaseOrderDetailID_I", PurchaseOrderDetailID_I);
            obDBAccess.addParam("mPurchaseOrderID_I", PurchaseOrderID_I);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mSpecificationTrNo_I", SpecificationTrNo_I);
            obDBAccess.addParam("mPurchaseQuantity_I", PurchaseQuantity_I);
            obDBAccess.addParam("mReceivedQuantity_I", ReceivedQuantity_I);
            obDBAccess.addParam("mOpeningStockID_I", OpeningStockID_I);
            obDBAccess.addParam("mUpdateQty", UpdateQty);
            obDBAccess.addParam("mBill_V", Bill_V);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mPerItemCost_I", PerItemCost_I);

            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;


        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR007_PurchaseOrderLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPurchaseOrderID_I", PurchaseOrderID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public System.Data.DataSet FillUserPO()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR007_PurchaseOrderUserLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR007_PurchaseOrderDetailsDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPurchaseOrderDetailID_I", id);

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
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
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

        public System.Data.DataSet FillDDLVendor()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR007_FillDDLVendor", DBAccess.SQLType.IS_PROC);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
    }
}


