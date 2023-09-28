using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Academic
{
    public class StatusMaster:ICommon
    {

        public string Status_V { get; set; }
        public int Trans_I { get; set; }
        public int StatusMasterTrno_I { get; set; }

        DBAccess obDBAccess = new DBAccess();


        #region ICommon Members

        public int InsertUpdate()
        {
            

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD006_StatusMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mStatusMasterTrno_I", StatusMasterTrno_I);
            obDBAccess.addParam("mStatus_V", Status_V);
            obDBAccess.addParam("mTransID", Trans_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD006_StatusMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mStatusId", StatusMasterTrno_I);
            return obDBAccess.records();
       
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD006_StatusMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}
