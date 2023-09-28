using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_RptStockAvailability 
    {
        private Int32 _CategoryID_I;
        private Int32 _ItemID_I;
        private Int32 _SpecificationTrNo_I;
        private string _ItemName_V;
        private string _CategoryType_V;
        public string _Specification_V;
        public Int32 _Quantity_I;

        private Int32 _DepartmentID_I;
        private string _DamageReturnStatus_V;

        private Int32 _PurchaseOrderID_I;
        private Int32 _Vendor_I;
        private DateTime? _ExpectedReceivingDate_D;
        private string _ApprovalStatus_V;

        public Int32 CategoryID_I { get { return _CategoryID_I; } set { _CategoryID_I = value; } }
        public Int32 ItemID_I { get { return _ItemID_I; } set { _ItemID_I = value; } }
        public Int32 SpecificationTrNo_I { get { return _SpecificationTrNo_I; } set { _SpecificationTrNo_I = value; } }
        public string ItemName_V { get { return _ItemName_V; } set { _ItemName_V = value; } }
        public string CategoryType_V { get { return _CategoryType_V; } set { _CategoryType_V = value; } }
        public string Specification_V { get { return _Specification_V; } set { _Specification_V = value; } }
        public Int32 Quantity_I { get { return _Quantity_I; } set { _Quantity_I = value; } }


        public Int32 DepartmentID_I { get { return _DepartmentID_I; } set { _DepartmentID_I = value; } }
        public string DamageReturnStatus_V { get { return _DamageReturnStatus_V; } set { _DamageReturnStatus_V = value; } }


        public Int32 PurchaseOrderID_I { get { return _PurchaseOrderID_I; } set { _PurchaseOrderID_I = value; } }
        public Int32 Vendor_I { get { return _Vendor_I; } set { _Vendor_I = value; } }
        public DateTime? ExpectedReceivingDate_D { get { return _ExpectedReceivingDate_D; } set { _ExpectedReceivingDate_D = value; } }
        public string ApprovalStatus_V { get { return _ApprovalStatus_V; } set { _ApprovalStatus_V = value; } }

        public DataSet FillGrid()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR009_RptStockAvailability", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mSpecificationTrNo_I", SpecificationTrNo_I);
            obDBAccess.addParam("mCategoryType_V", CategoryType_V);

            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public DataSet FillDamageReturn()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR009_RptDamageReturn", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDamageReturnStatus_V", DamageReturnStatus_V);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID_I);

            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public DataSet FillDepartment()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR009_FillDepartment", DBAccess.SQLType.IS_PROC);

            return obDBAccess.records();
            throw new NotImplementedException();
        }

         public DataSet FillPurchaseOrder()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR009_RptPurchaseOrder", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mApprovalStatus_V", ApprovalStatus_V);
            obDBAccess.addParam("mExpectedReceivingDate_D", ExpectedReceivingDate_D);
            obDBAccess.addParam("mPurchaseOrderID_I", PurchaseOrderID_I);
            obDBAccess.addParam("mVendor_I", Vendor_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
    }
}



