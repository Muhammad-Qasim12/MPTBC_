using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.AcademicB
{
    public class SubTitle: ICommon
    {
        public string SubTitleHindi { get; set; }        
        public string SubTitleEnglish { get; set; }    
        public int TitleID { get; set; }
        public int SubTitleID { get; set; } 
        public int TranID { get; set; }
        DBAccess obDBAccess;
        
        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB002_SubTitleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubTitleHindi_V", SubTitleHindi);
            obDBAccess.addParam("mSubTitleEnglish_V", SubTitleEnglish);
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID);
            obDBAccess.addParam("mTranID", TranID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB002_SubTitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID);
            obDBAccess.addParam("mTranID", TranID);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB002_SubTitleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSubTitleID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}
