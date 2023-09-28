using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class Depo_MidSessionDND
    {
        private int _MediumTrno_I;
        private int _ClassTrno_I;
        private string _ClassNos_V;
        private int _UserId_I;



        public int MediumTrno_I { get { return _MediumTrno_I; } set { _MediumTrno_I = value; } }
        public int ClassTrno_I { get { return _ClassTrno_I; } set { _ClassTrno_I = value; } }
        public string ClassNos_V { get { return _ClassNos_V; } set { _ClassNos_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        //public int InsertUpdate()
        //{

        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterSave", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", LabTrId_I);
        //    obDBAccess.addParam("mLabName", LabName);
        //    obDBAccess.addParam("mLabAddress", LabAddress);
        //    obDBAccess.addParam("mStateId_I", StateId_I);
        //    obDBAccess.addParam("mDistrictId_I", DistrictId_I);
        //    obDBAccess.addParam("mCity_V", City_V);
        //    obDBAccess.addParam("mPinCode_V", PinCode_V);
        //    obDBAccess.addParam("mContactPerson_V", ContactPerson_V);
        //    obDBAccess.addParam("mEmail_V", Email_V);
        //    obDBAccess.addParam("mContactNo_V", ContactNo_V);
        //    obDBAccess.addParam("mRemark_V", Remark_V);
        //    obDBAccess.addParam("mUserId_I", UserId_I);
        //    int result = obDBAccess.executeMyQuery();
        //    return result;
        //}
        public System.Data.DataSet MedumFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO001_InterDemandTrans", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mMediumTrno_I", 0);
            obDBAccess.addParam("mClassTrno_I", 0);
            obDBAccess.addParam("mClassNos_V", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet MedumSubFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO001_InterDemandTrans", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mMediumTrno_I", MediumTrno_I);
            obDBAccess.addParam("mClassTrno_I", 0);
            obDBAccess.addParam("mClassNos_V", ClassNos_V);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }


        //public System.Data.DataSet Select()
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterLoadData", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", LabTrId_I);
        //    return obDBAccess.records();
        //}

        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterDelete", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", id);

        //    int result = obDBAccess.executeMyQuery();
        //    return result;
        //  }
    }
}
