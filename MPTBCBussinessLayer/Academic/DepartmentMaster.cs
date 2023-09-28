﻿
namespace MPTBCBussinessLayer.Academic
{
    public class DepartmentMaster:ICommon
    {
//        mDepTrno_I int(10),
//mDepName_V Varchar(50),
//mTranID INT(11)
        public int DepTrno { get; set; }
        public string DepName { get; set; }
        public int TranID { get; set; }

        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD002_DepartmentMasterSave", DBAccess.SQLType.IS_PROC);

            obDBAccess.addParam("mDepTrno_I", DepTrno);
            obDBAccess.addParam("mDepName_V", DepName);
            obDBAccess.addParam("mTranID", TranID);          
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD002_DepartmentMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepTrno_I", DepTrno);
            return obDBAccess.records();        
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD002_DepartmentMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepTrno_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}