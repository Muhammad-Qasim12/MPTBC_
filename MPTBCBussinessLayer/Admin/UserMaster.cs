using System.Data;
using System;
namespace MPTBCBussinessLayer.Admin
{
    public class UserMaster 
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleTrno { get; set; }
        public int TranID { get; set; }
        public int QueryType { get; set; }
        public string UserType { get; set; }
        public string LoginSts { get; set; }
        public string CoreSts { get; set; }
        public string EmpId { get; set; }
        public string UserFromDPHO { get; set; }
        public int CoreRoleId { get; set; }
        public string BranchId { get; set; }
        public int UserDpt_I { get; set; }
        public string RoleAccess { get; set; }
        
       // DataSet ds;
        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", UserID);
            obDBAccess.addParam("mUserName_V", UserName);
            obDBAccess.addParam("mPassword_V", Password);
            obDBAccess.addParam("mRoleTrno_I", RoleTrno);
            obDBAccess.addParam("mUserType_V", UserType);
            obDBAccess.addParam("mTranID", TranID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public DataSet InsertUpdateWithHistory()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterWithHstorySave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", UserID);
            obDBAccess.addParam("mUserName_V", UserName);
            obDBAccess.addParam("mPassword_V", Password);
            obDBAccess.addParam("mRoleTrno_I", RoleTrno);
            obDBAccess.addParam("mUserType_V", UserType);
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mLoginSts", LoginSts);
            obDBAccess.addParam("mCoreSts", CoreSts);
            obDBAccess.addParam("mEmployeeID_I", EmpId);
            obDBAccess.addParam("mUserFromDPHO", UserFromDPHO);
            obDBAccess.addParam("mCoreRoleId", CoreRoleId);
            obDBAccess.addParam("mUserDpt_I", UserDpt_I);
            obDBAccess.addParam("mBranchId", BranchId);
            obDBAccess.addParam("mRoleAccess", RoleAccess);
            
            return obDBAccess.records();
        }
        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mUserID_I", UserID);
            return obDBAccess.records();        
        }
        public System.Data.DataSet Search()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterSearch", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mRoleID", RoleTrno);
            obDBAccess.addParam("mUserName", UserName);
            return obDBAccess.records();
        }
        public System.Data.DataSet PrathamIdUpdate(string UserId, string PrathamUId, int type)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_PrathamUseridUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserId", UserId);
            obDBAccess.addParam("mPrathamUId", PrathamUId);
            obDBAccess.addParam("mtype", type);
            return obDBAccess.records();        
        }
        public System.Data.DataSet PrathamIdSelect(string UserId, int type,string Id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_PrathamUseridUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserId", UserId);
            obDBAccess.addParam("mPrathamUId", Id);
            obDBAccess.addParam("mtype", type);
            return obDBAccess.records();
        }
        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_UserMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", id);
            return obDBAccess.executeMyQuery(); 
        }
        //public string SendToEmpId()
        //{
        //    return "F4BEE714-5914-45E5-8EEE-64F411EDFC1E";
                    
        //}
        public string SendToEmpId()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("SELECT Flag,ForwordedID FROM tblintigforwardedempid WHERE Flag='HO Head'", DBAccess.SQLType.IS_QUERY);
            return obDBAccess.records().Tables[0].Rows[0]["ForwordedID"].ToString(); ;
        }
        #endregion
    }
}
