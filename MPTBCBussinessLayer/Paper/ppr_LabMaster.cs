using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class ppr_LabMaster : ICommon
    {
        private int _LabTrId_I;
        private string _LabName;
        private string _LabAddress;
        private int _StateId_I;
        private int _DistrictId_I;
        private string _City_V;
        private string _PinCode_V;
        private string _ContactPerson_V;
        private string _Email_V;
        private string _ContactNo_V;
        private string _Remark_V;
        private int _UserId_I;


        private string _TinNo_V;
        private string _TanNo_V;
        private string _PanNo_V;
        private string _BankName_V;
        private string _BranchName_V;
        private string _BankHolderName_V;
        private string _AccountNo_V;
        private string _Acc_Type_V;
        private string _IFSCCode;
        private string _MICRNo;
        private string _ServiceTaxNo;
        private string _FaxNo;

        public int LabTrId_I { get { return _LabTrId_I; } set { _LabTrId_I = value; } }
        public string LabName { get { return _LabName; } set { _LabName = value; } }
        public string LabAddress { get { return _LabAddress; } set { _LabAddress = value; } }
        public int StateId_I { get { return _StateId_I; } set { _StateId_I = value; } }
        public int DistrictId_I { get { return _DistrictId_I; } set { _DistrictId_I = value; } }
        public string City_V { get { return _City_V; } set { _City_V = value; } }
        public string PinCode_V { get { return _PinCode_V; } set { _PinCode_V = value; } }
        public string ContactPerson_V { get { return _ContactPerson_V; } set { _ContactPerson_V = value; } }
        public string Email_V { get { return _Email_V; } set { _Email_V = value; } }
        public string ContactNo_V { get { return _ContactNo_V; } set { _ContactNo_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }



        public string TinNo_V { get { return _TinNo_V; } set { _TinNo_V = value; } }
        public string TanNo_V { get { return _TanNo_V; } set { _TanNo_V = value; } }
        public string PanNo_V { get { return _PanNo_V; } set { _PanNo_V = value; } }
        public string BankName_V { get { return _BankName_V; } set { _BankName_V = value; } }
        public string BranchName_V { get { return _BranchName_V; } set { _BranchName_V = value; } }
        public string BankHolderName_V { get { return _BankHolderName_V; } set { _BankHolderName_V = value; } }
        public string AccountNo_V { get { return _AccountNo_V; } set { _AccountNo_V = value; } }
        public string Acc_Type_V { get { return _Acc_Type_V; } set { _Acc_Type_V = value; } }
        public string IFSCCode { get { return _IFSCCode; } set { _IFSCCode = value; } }
        public string MICRNo { get { return _MICRNo; } set { _MICRNo = value; } }


        public string ServiceTaxNo { get { return _ServiceTaxNo; } set { _ServiceTaxNo = value; } }
        public string FaxNo { get { return _FaxNo; } set { _FaxNo = value; } }


        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR003_LabMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabTrId_I", LabTrId_I);
            obDBAccess.addParam("mLabName", LabName);
            obDBAccess.addParam("mLabAddress", LabAddress);
            obDBAccess.addParam("mStateId_I", StateId_I);
            obDBAccess.addParam("mDistrictId_I", DistrictId_I);
            obDBAccess.addParam("mCity_V", City_V);
            obDBAccess.addParam("mPinCode_V", PinCode_V);
            obDBAccess.addParam("mContactPerson_V", ContactPerson_V);
            obDBAccess.addParam("mEmail_V", Email_V);
            obDBAccess.addParam("mContactNo_V", ContactNo_V);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mTinNo_V", TinNo_V);
            obDBAccess.addParam("mTanNo_V", TanNo_V);
            obDBAccess.addParam("mPanNo_V", PanNo_V);
            obDBAccess.addParam("mBankName_V", BankName_V);
            obDBAccess.addParam("mBranchName_V", BranchName_V);
            obDBAccess.addParam("mBankHolderName_V", BankHolderName_V);
            obDBAccess.addParam("mAccountNo_V", AccountNo_V);
            obDBAccess.addParam("mAcc_Type_V", Acc_Type_V);
            obDBAccess.addParam("mIFSCCode", IFSCCode);
            obDBAccess.addParam("mMICRNo", MICRNo);
            obDBAccess.addParam("mServiceTaxNo", ServiceTaxNo);
            obDBAccess.addParam("mFaxNo", FaxNo);


            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR003_LabMasterLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabTrId_I", LabTrId_I);
            return obDBAccess.records();
        }
        public System.Data.DataSet SearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR003_LabMasterSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabName", LabName);
            return obDBAccess.records();
        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR003_LabMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabTrId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
