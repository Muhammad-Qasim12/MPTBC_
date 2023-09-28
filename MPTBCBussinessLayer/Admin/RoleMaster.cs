
namespace MPTBCBussinessLayer.Admin
{
    public class RoleMaster
    {
        public int Roletrno { get; set; }
        public int TranID { get; set; }
        public int QueryType { get; set; }
        public string Role { get; set; }
        public int FormTrno { get; set; }

        public int ModuleTrno { get; set; }

        DBAccess obDBAccess;


        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM005_RoleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mRoletrno_I", Roletrno);
            obDBAccess.addParam("mRole_V", Role);
            obDBAccess.addParam("mFormTrno_I", FormTrno);         
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mModuleTrno_I", ModuleTrno);

            object result = obDBAccess.executeMyScalar();
            
            return int.Parse(result.ToString());
           
            //throw new NotImplementedException();
        }

        public void InsertForm()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM005_RoleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mRoletrno_I", Roletrno);
            obDBAccess.addParam("mRole_V", Role);
            obDBAccess.addParam("mFormTrno_I", FormTrno);  
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mModuleTrno_I", ModuleTrno);
            obDBAccess.executeMyScalar();

            //return int.Parse(result.ToString());

            //throw new NotImplementedException();
        }
        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM005_RoleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mRoleTrno", Roletrno);
            obDBAccess.addParam("mModuleTrno", ModuleTrno);
            
            return obDBAccess.records();        
           // throw new NotImplementedException();
        }
        public System.Data.DataSet UserDepartFill()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM005_RoleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mRoleTrno", Roletrno);
            obDBAccess.addParam("mModuleTrno", ModuleTrno);

            return obDBAccess.records();
            // throw new NotImplementedException();
        }
       

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM005_RoleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mRoletrno_I", id);

            return obDBAccess.executeMyQuery(); 
        }

        #endregion
    }
}
