using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_VendorMaster : ICommon
    {
        private int _PaperVendorTrId_I;
        private string _RegistrationNo_V;
        private DateTime _RegistrationDate_D;
        private string _PaperVendorName_V;
        private string _PaperVendorAddress_V;
        private int _StateId_I;
        private int _DistrictId_I;
        private string _CityId_I;
        private string _PinCode_V;
        private string _ContactPerson_V;
        private string _PaperVendorEmail_V;
        private string _PaperVendorContactNo_V;
        private string _PaperVendorVATTaxNo_V;
        private string _Remark_V;
        private int _UserId_I;



        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public string RegistrationNo_V { get { return _RegistrationNo_V; } set { _RegistrationNo_V = value; } }
        public DateTime RegistrationDate_D { get { return _RegistrationDate_D; } set { _RegistrationDate_D = value; } }
        public string PaperVendorName_V { get { return _PaperVendorName_V; } set { _PaperVendorName_V = value; } }
        public string PaperVendorAddress_V { get { return _PaperVendorAddress_V; } set { _PaperVendorAddress_V = value; } }
        public int StateId_I { get { return _StateId_I; } set { _StateId_I = value; } }
        public int DistrictId_I { get { return _DistrictId_I; } set { _DistrictId_I = value; } }
        public string CityId_I { get { return _CityId_I; } set { _CityId_I = value; } }
        public string PinCode_V { get { return _PinCode_V; } set { _PinCode_V = value; } }
        public string ContactPerson_V { get { return _ContactPerson_V; } set { _ContactPerson_V = value; } }
        public string PaperVendorEmail_V { get { return _PaperVendorEmail_V; } set { _PaperVendorEmail_V = value; } }
        public string PaperVendorContactNo_V { get { return _PaperVendorContactNo_V; } set { _PaperVendorContactNo_V = value; } }
        public string PaperVendorVATTaxNo_V { get { return _PaperVendorVATTaxNo_V; } set { _PaperVendorVATTaxNo_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_VendorSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mRegistrationNo_V", RegistrationNo_V);
            obDBAccess.addParam("mRegistrationDate_D", RegistrationDate_D);
            obDBAccess.addParam("mPaperVendorName_V", PaperVendorName_V);
            obDBAccess.addParam("mPaperVendorAddress_V", PaperVendorAddress_V);
            obDBAccess.addParam("mStateId_I", StateId_I);
            obDBAccess.addParam("mDistrictId_I", DistrictId_I);
            obDBAccess.addParam("mCityId_I", CityId_I);
            obDBAccess.addParam("mPinCode_V", PinCode_V);
            obDBAccess.addParam("mContactPerson_V", ContactPerson_V);
            obDBAccess.addParam("mPaperVendorEmail_V", PaperVendorEmail_V);
            obDBAccess.addParam("mPaperVendorContactNo_V", PaperVendorContactNo_V);
            obDBAccess.addParam("mPaperVendorVATTaxNo_V", PaperVendorVATTaxNo_V);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mUserId_I", UserId_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_VendorLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_PaperVendorDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
