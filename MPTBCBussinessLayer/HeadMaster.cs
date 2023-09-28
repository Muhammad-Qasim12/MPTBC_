using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public class HeadMaster : ICommon
    {
      private int _HeadID_I;
      private string  _HeadName_V;
      private DateTime  _TransactionDate_D;
      private int _UserID_I;
      private int _transID_I;

      public int HeadID_I { get { return _HeadID_I; } set { _HeadID_I = value; } }
      public string HeadName_V { get { return _HeadName_V; } set { _HeadName_V = value; } }
      public DateTime TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
      public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
      public int transID_I { get { return _transID_I; } set { _transID_I = value; } }
        public int InsertUpdate()
      {
          DBAccess obDBAccess = new DBAccess();
          obDBAccess.execute("USP_DPT005_HeadMaster", DBAccess.SQLType.IS_PROC);
          obDBAccess.addParam("DHeadID_I", HeadID_I);
          obDBAccess.addParam("HeadName_V", HeadName_V);
          obDBAccess.addParam("TransactionDate_D", TransactionDate_D);
          obDBAccess.addParam("UserID_I", UserID_I);
          obDBAccess.addParam("TranID_I", transID_I);
          int result = obDBAccess.executeMyQuery();
          return result;
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT005_HeadMsterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", HeadID_I);
              return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT005_HeadMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            throw new NotImplementedException();
        }
    }
}
