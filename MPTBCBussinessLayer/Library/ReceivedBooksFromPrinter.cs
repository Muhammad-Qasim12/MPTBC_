using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Library
{
    public class ReceivedBooksFromPrinter:ICommon
    {

        private int _Printer_RedID_I;
        private int _QueryType;
        private int _WorkOrderID_I;
        private int _BooksReceivedID_I;
        private int _TitleID_I;
        private int _ReceivedQuantity_I;
        private int _UserTrId_I;
        private DateTime _TrDate_D;
        private int _SubTitleID_I;
        private string _BookType_V;
        private string _OtherDistributor_V;
        private string _OtherBookName_V;
        private string _Remark_V;
        

        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public int QueryType { get { return _QueryType; } set { _QueryType = value; } }
        public int WorkOrderID_I { get { return _WorkOrderID_I; } set { _WorkOrderID_I = value; } }
        public int BooksReceivedID_I { get { return _BooksReceivedID_I; } set { _BooksReceivedID_I = value; } }
        public int TitleID_I { get { return _TitleID_I; } set { _TitleID_I = value; } }
        public int ReceivedQuantity_I { get { return _ReceivedQuantity_I; } set { _ReceivedQuantity_I = value; } }
        public int UserTrId_I { get { return _UserTrId_I; } set { _UserTrId_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public int SubTitleID_I { get { return _SubTitleID_I; } set { _SubTitleID_I = value; } }
        public string BookType_V { get { return _BookType_V; } set { _BookType_V = value; } }
        public string OtherDistributor_V { get { return _OtherDistributor_V; } set { _OtherDistributor_V = value; } }
        public string OtherBookName_V { get { return _OtherBookName_V; } set { _OtherBookName_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_LIB001_BooksReceivedSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBooksReceivedID_I", BooksReceivedID_I);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mReceivedQuantity_I", ReceivedQuantity_I);
            obDBAccess.addParam("mUserTrId_I", UserTrId_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mBookType_V", BookType_V);
            obDBAccess.addParam("mOtherDistributor_V", OtherDistributor_V);
            obDBAccess.addParam("mOtherBookName_V", OtherBookName_V);
            obDBAccess.addParam("mRemark_V", Remark_V);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBooksReceivedID_I", BooksReceivedID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public DataSet FillTitles()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD005_PrinterProofLoadRPT", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mWorkOrderID_I", WorkOrderID_I);
            return obDBAccess.records();
        }

        public DataSet FillOtherTitles()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_WorkOrderDetailsLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}



