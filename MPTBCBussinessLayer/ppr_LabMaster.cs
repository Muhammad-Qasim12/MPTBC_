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
