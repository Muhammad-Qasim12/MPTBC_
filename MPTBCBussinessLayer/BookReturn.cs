using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class BookReturn:ICommon 
    {
       private int _ID;
       private int _DbookRetrNo_I;
       private DateTime _RetDate_D;
       private string _Reson_V;
       private string _Remark_V;
       private int _UserID_I;
       private DateTime _TrnasDate;
       private int _BandalNo;
       private int _BookNo;
       private int _DepoID;
       private int _TranID_I;
       private int _TitalID;

       public int TitalID { get { return _TitalID; } set { _TitalID = value; } }
       public int ID { get { return _ID; } set { _ID = value; } }
       public int DbookRetrNo_I { get { return _DbookRetrNo_I; } set { _DbookRetrNo_I = value; } }
       public DateTime RetDate_D { get { return _RetDate_D; } set { _RetDate_D = value; } }
       public string  Reson_V { get { return _Reson_V; } set { _Reson_V = value; } }
       public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
       public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
       public DateTime TrnasDate { get { return _TrnasDate; } set { _TrnasDate = value; } }
        public int BandalNo { get { return _BandalNo; } set { _BandalNo = value; } }
        public int BookNo { get { return _BandalNo; } set { _BookNo = value; } }
        public int DepoID { get { return _DepoID; } set { _DepoID = value; } }
        public int TranID_I { get { return _TranID_I; } set { _TranID_I = value; } }
      

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT013_BookReturns_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DbookRetrNo_I",DbookRetrNo_I);
            obDBAccess.addParam("RetDate_D", RetDate_D);
            obDBAccess.addParam("Reson_V", Reson_V);
            obDBAccess.addParam("Remark_V", Remark_V);
            obDBAccess.addParam("UserID_I", UserID_I);
            obDBAccess.addParam("TrnasDate", TrnasDate);
            obDBAccess.addParam("BandalNo", BandalNo);
            obDBAccess.addParam("TitalID", TitalID);
            obDBAccess.addParam("BookNo", BookNo);
            obDBAccess.addParam("DepoID", DepoID);
            obDBAccess.addParam("TranID_I", TranID_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT013_BookReturnLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", DbookRetrNo_I);
            obDBAccess.addParam("UserID", UserID_I);
            
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        public System.Data.DataSet fillDatabyBandalno()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT013_BookReturn_ShowDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", ID );
            return obDBAccess.records();
        }


    }
}
