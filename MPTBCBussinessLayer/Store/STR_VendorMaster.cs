using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_VendorMaster :ICommon
    {
        private Int32 _Vendor_I;
        private string _VendorName_V;
        private string _Address_V;
        private Int32 _StateID_I;
        private Int32 _CityID_I;
        private string _ContactPersonName_V;
        private string _MobileNo_V;
        private string _TelephoneNo_V;
        private string _FaxNo_V;
        private string _ServiceTax_V;
        private string _TinNo_V;
        private string _EmailID_V;
        private string _Website_V;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;

        public Int32 Vendor_I { get { return _Vendor_I; } set { _Vendor_I = value; } }
        public string VendorName_V { get { return _VendorName_V; } set { _VendorName_V = value; } }
        public string Address_V { get { return _Address_V; } set { _Address_V = value; } }
        public Int32 StateID_I { get { return _StateID_I; } set { _StateID_I = value; } }
        public Int32 CityID_I { get { return _CityID_I; } set { _CityID_I = value; } }
        public string ContactPersonName_V { get { return _ContactPersonName_V; } set { _ContactPersonName_V = value; } }
        public string MobileNo_V { get { return _MobileNo_V; } set { _MobileNo_V = value; } }
        public string TelephoneNo_V { get { return _TelephoneNo_V; } set { _TelephoneNo_V = value; } }
        public string FaxNo_V { get { return _FaxNo_V; } set { _FaxNo_V = value; } }
        public string ServiceTax_V { get { return _ServiceTax_V; } set { _ServiceTax_V = value; } }
        public string TinNo_V { get { return _TinNo_V; } set { _TinNo_V = value; } }
        public string EmailID_V { get { return _EmailID_V; } set { _EmailID_V = value; } }
        public string Website_V { get { return _Website_V; } set { _Website_V = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR005_VendorMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVendor_I", Vendor_I);
            obDBAccess.addParam("mVendorName_V", VendorName_V);
            obDBAccess.addParam("mAddress_V", Address_V);
            obDBAccess.addParam("mStateID_I", StateID_I);
            obDBAccess.addParam("mCityID_I", CityID_I);
            obDBAccess.addParam("mContactPersonName_V", ContactPersonName_V);
            obDBAccess.addParam("mMobileNo_V", MobileNo_V);
            obDBAccess.addParam("mTelephoneNo_V", TelephoneNo_V);
            obDBAccess.addParam("mFaxNo_V", FaxNo_V);
            obDBAccess.addParam("mServiceTax_V", ServiceTax_V);
            obDBAccess.addParam("mTinNo_V", TinNo_V);
            obDBAccess.addParam("mEmailID_V", EmailID_V);
            obDBAccess.addParam("mWebsite_V", Website_V);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR005_VendorMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVendor_I", Vendor_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR005_VendorMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVendor_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public System.Data.DataSet FillStateCity()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR005_FillStateCity", DBAccess.SQLType.IS_PROC);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
    }
}


