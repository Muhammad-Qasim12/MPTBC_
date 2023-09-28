using System;
namespace MPTBCBussinessLayer.Admin
{
   public class ModuleMaster: ICommon
    {
        public int ModuleTrno_I { get; set; }
        public string ModuleName { get; set; }
        public int ModuleOrder { get; set; }
        public int TranID { get; set; }

        #region ICommon Members
        DBAccess obDBAccess;
        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM001_ModuleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mModuleTrno_I", ModuleTrno_I);
            obDBAccess.addParam("ModuleName_V", ModuleName);
            obDBAccess.addParam("ModuleOrderNO_I", ModuleOrder);
            obDBAccess.addParam("TranID", TranID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM001_ModuleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mModuleTrno_I", ModuleTrno_I);
            return obDBAccess.records();           
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM001_ModuleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mModuleTrno_I", id);            
            return obDBAccess.executeMyQuery(); 
        }

        #endregion
    }
}
