
namespace MPTBCBussinessLayer.Admin
{
    public class Login:ICommon
    {
        public string UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int UserID { get; set; }
        public int SubModuleTrno { get; set; }
        public int QueryType { get; set; }
        public string IpAdress { get; set; }   
        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {
            return 0;
            //throw new System.NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM008_LoginSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserType_V", UserType);
            obDBAccess.addParam("mUserName_V", UserName);
            obDBAccess.addParam("mPassword_V", Password);
            obDBAccess.addParam("mUserID_I", UserID);
            obDBAccess.addParam("mSubModuleTrno_I", SubModuleTrno);
            obDBAccess.addParam("mType", QueryType);  

            return obDBAccess.records();        
            //throw new System.NotImplementedException();
        }
        public System.Data.DataSet MyLogin()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM008_MyLogin", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserType_V", UserType);
            obDBAccess.addParam("mUserName_V", UserName);
            obDBAccess.addParam("mPassword_V", Password);
            obDBAccess.addParam("mUserID_I", UserID);
            obDBAccess.addParam("mIpAdress", IpAdress);
            obDBAccess.addParam("mType", QueryType);
            return obDBAccess.records();
            //throw new System.NotImplementedException();
        }
        public System.Data.DataSet GetBranchId()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("Adm_GetBranchType", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserName_V", UserName);
            obDBAccess.addParam("mType", QueryType);
            return obDBAccess.records();
            //throw new System.NotImplementedException();
        }

        public int Delete(int id)
        {
            return 0;
            //throw new System.NotImplementedException();
        }
        public System.Data.DataSet GetMenu()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM008_Menu", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID_I", UserID);
            return obDBAccess.records();
            //throw new System.NotImplementedException();
        }
        #endregion
    }
}
