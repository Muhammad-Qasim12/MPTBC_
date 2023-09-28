using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Library
{
   public class DistributeBooks:ICommon
   {
       private int _Medium;
       private int _ClassTrno;
       private string _TitleHindi;
       private int _TitleID;
       private int _distributebookID_I;
       private string _SendTo_V;
       private int _DispatchQuantity_I;
       private DateTime _DemandDate_D;
       private string _DemandLetterNo_V;
       private string _Remark_V;
       private int _UpdateQty;
       private int _UserTrNo_I;
       private DateTime _TrDate_D;
       private int _Printer_RedID_I;
       private int _SubTitleID_I;
       private string _BookType_V;
       private string _OtherBookName_V;

      public int Medium { get{return _Medium;} set{_Medium=value;} }
      public int ClassTrno { get{return _ClassTrno;} set{_ClassTrno=value;} }
      public string TitleHindi { get { return _TitleHindi; } set { _TitleHindi = value; } }
      public int TitleID { get { return _TitleID; } set { _TitleID = value; } }
      public int distributebookID_I { get { return _distributebookID_I; } set { _distributebookID_I = value; } }
      public string SendTo_V { get { return _SendTo_V; } set { _SendTo_V = value; } }
      public int DispatchQuantity_I { get { return _DispatchQuantity_I; } set { _DispatchQuantity_I = value; } }
      public DateTime DemandDate_D { get { return _DemandDate_D; } set { _DemandDate_D = value; } }
      public string DemandLetterNo_V { get { return _DemandLetterNo_V; } set { _DemandLetterNo_V = value; } }
      public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
      public int UpdateQty { get { return _UpdateQty; } set { _UpdateQty = value; } }
      public int UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
      public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
      public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
      public int SubTitleID_I { get { return _SubTitleID_I; } set { _SubTitleID_I = value; } }
      public string BookType_V { get { return _BookType_V; } set { _BookType_V = value; } }
      public string OtherBookName_V { get { return _OtherBookName_V; } set { _OtherBookName_V = value; } }

       private int _ID;
       public int ID { get { return _ID; } set { _ID = value; } }

       DBAccess obDBAccess;



       #region ICommon Members

       public int InsertUpdate()
       {
           obDBAccess = new DBAccess();
           obDBAccess.execute("USP_LIB002_DistributeBooksSave", DBAccess.SQLType.IS_PROC);

           obDBAccess.addParam("mdistributebookID_I", distributebookID_I);
           obDBAccess.addParam("mTitleID_I", TitleID);
           obDBAccess.addParam("mSendTo_V", SendTo_V);
           obDBAccess.addParam("mDispatchQuantity_I", DispatchQuantity_I);
           obDBAccess.addParam("mDemandDate_D", DemandDate_D);
           obDBAccess.addParam("mDemandLetterNo_V", DemandLetterNo_V);
           obDBAccess.addParam("mRemark_V", Remark_V);
           obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
           obDBAccess.addParam("mTrDate_D", TrDate_D);
           obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
           obDBAccess.addParam("mBookType_V", BookType_V);
           obDBAccess.addParam("mOtherBookName_V", OtherBookName_V);
           
           int result = obDBAccess.executeMyQuery();
           return result;
       }

       public System.Data.DataSet Select()
       {
           obDBAccess = new DBAccess();
           obDBAccess.execute("USP_LIB002_DistributeBooksLoad", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mID", ID);
           obDBAccess.addParam("mTitleID_I", TitleID);
           obDBAccess.addParam("mClassTrno_I", ClassTrno);
           obDBAccess.addParam("mMedium_I", Medium);
           obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
           obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
           obDBAccess.addParam("mOtherBookName_V", OtherBookName_V);

           return obDBAccess.records();
       }

       public DataSet FillUser()
       {
           obDBAccess = new DBAccess();
           obDBAccess.execute("USP_LIB002_FillUser", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mID", ID);

           return obDBAccess.records();
       }

       public int Delete(int id)
       {
           obDBAccess = new DBAccess();
           obDBAccess.execute("", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mTitleID_I", id);
           int result = obDBAccess.executeMyQuery();
           return result;
       }

       public DataSet FillGrid()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_LIB002_DistributeBooksRPT", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mID", ID);
           obDBAccess.addParam("mBookType_V", BookType_V);
           return obDBAccess.records();
       }

       #endregion
   }
}

