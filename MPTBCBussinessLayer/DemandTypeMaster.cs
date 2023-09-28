using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public class DemandTypeMaster : ICommon
    {
        private int _DemandTypeId;
        private string  _DemandTypeHindi;
        private string _DemandTypeEng;
        private int _UserID;
        private string _Discription;

        public int UserID{ get { return _UserID; } set { _UserID = value; } }
        public int DemandTypeId { get { return _DemandTypeId; } set { _DemandTypeId = value; } }
        public string DemandTypeHindi { get { return _DemandTypeHindi; } set { _DemandTypeHindi = value; } }
        public string DemandTypeEng { get { return _DemandTypeEng; } set { _DemandTypeEng = value; } }
        public string Discription { get { return _Discription; } set { _Discription = value; } }
        #region ICommon Members

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_DemandTypeMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("TypeId", DemandTypeId);
            obDBAccess.addParam("DemandTypeHindi", DemandTypeHindi);
            obDBAccess.addParam("DemandTypeEng", DemandTypeEng);
            obDBAccess.addParam("Discription", Discription);
            obDBAccess.addParam("UserID", UserID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_DemandTypeMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("TypeId", DemandTypeId);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_DemandTypeMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("TypeId", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}
