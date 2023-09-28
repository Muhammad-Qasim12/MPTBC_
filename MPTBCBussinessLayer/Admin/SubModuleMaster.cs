using System;
namespace MPTBCBussinessLayer.Admin
{
   public class SubModuleMaster: ICommon
    {
        
        public int SubModuleTrno { get; set; }
        public int ModuleTrno { get; set; }
        public string ModuleName { get; set; }       
        public int TranID { get; set; }
        public string SubModuleName { get; set; }
        public int QueryType { get; set; }
        public string Path { get; set; }
        public int OrderNo { get; set; }

        #region ICommon Members
        DBAccess obDBAccess;
        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM002_SubModuleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubModuleTrno_I", SubModuleTrno);            
            obDBAccess.addParam("mModuleTrno_I", ModuleTrno);
            obDBAccess.addParam("mSubModuleName_V", SubModuleName);
            obDBAccess.addParam("mOrderNo", OrderNo);
            obDBAccess.addParam("mPath", Path);
            obDBAccess.addParam("mTranID", TranID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM002_SubModuleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mSubModuleTrno_I", SubModuleTrno);
            return obDBAccess.records();           
        }
        public System.Data.DataSet LoginHistory(string Name)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM007_LogingHistory", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mName", Name);
            return obDBAccess.records();           
        }
        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM002_SubModuleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubModuleTrno_I", id);            
            return obDBAccess.executeMyQuery(); 
        }

        #endregion
    }
}
