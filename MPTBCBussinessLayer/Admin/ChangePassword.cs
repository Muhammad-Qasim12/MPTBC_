
namespace MPTBCBussinessLayer.Admin
{
    public class ChangePassword
    {
        public int UserId { get; set; }
        public string Password { get; set; }      
        public int QueryType { get; set; }
        public string UserName_V { get; set; }
        
        DBAccess obDBAccess;



        #region ICommon Members

        public System.Data.DataSet InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM016_ChangePasswordSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserId_I", UserId);
            obDBAccess.addParam("mPassword_V", Password);
            obDBAccess.addParam("mUserName_V", UserName_V);

            return obDBAccess.records();
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM016_ChangePasswordSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserID", UserId);
            obDBAccess.addParam("mType", QueryType);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            //obDBAccess = new DBAccess();
            //obDBAccess.execute("USP_ACD002_DepartmentMasterDelete", DBAccess.SQLType.IS_PROC);
            //obDBAccess.addParam("mDepTrno_I", id);
            //int result = obDBAccess.executeMyQuery();
            //return result;
            return 0;
        }

        #endregion
    }
}
