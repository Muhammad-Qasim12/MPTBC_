using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class CountingDetails:ICommon
    {
       private DateTime _Hund_ReDate;

     private string  _OrderNo_V;private int _PinterID_I;private string _ChallanNo_V;private DateTime _ChallanDate;
     private int _TotalNoOfReceiveBundle_I ;private int _NofSchemeBook_I ;private int _NoOFgenralBook_I;private int _NoOfBookCounted_I;
     private string _BookDimention_V, _LetterNo_V;private DateTime  _LetterDate ;private string _bookNo_V,_BundleNo_V,_SatusOfBook_V,_PrinterCompanyperson_V;
     private int _TitalID;
       private DateTime _PresentDate_D;private int _CheckBundleNoOfBookFirst_I,_CheckBundleNoOfBookSecond;
      private string _RegisterNo, _Remarks_V; private DateTime _Date_D, _FromDate_D, _Receiveddate_D, _Totaldate_D, _TrnasDate; 
        private int _ReceivedBookNo_I, _TotalNotuseful_N;
       private int _userID,_DStockReceivedTPerID_I;

       public DateTime Hund_ReDate { get { return _Hund_ReDate; } set { _Hund_ReDate = value; } }
       public int TitalID { get { return _TitalID; } set { _TitalID = value; } }
        public int DStockReceivedTPerID_I { get { return _DStockReceivedTPerID_I; } set { _DStockReceivedTPerID_I = value; } }
       public string OrderNo_V { get { return _OrderNo_V; } set { _OrderNo_V = value; } }
       public int PinterID_I { get { return _PinterID_I; } set { _PinterID_I = value; } }
       public string  ChallanNo_V { get { return _ChallanNo_V; } set { _ChallanNo_V = value; } }
        public DateTime  ChallanDate { get { return _ChallanDate; } set { _ChallanDate = value; } }
       public int TotalNoOfReceiveBundle_I { get { return _TotalNoOfReceiveBundle_I; } set { _TotalNoOfReceiveBundle_I = value; } }
        public int NofSchemeBook_I { get { return _NofSchemeBook_I; } set { _NofSchemeBook_I = value; } }
       public int NoOFgenralBook_I { get { return _NoOFgenralBook_I; } set { _NoOFgenralBook_I = value; } }
        public int NoOfBookCounted_I { get { return _NoOfBookCounted_I; } set { _NoOfBookCounted_I = value; } }
       public string BookDimention_V { get { return _BookDimention_V; } set { _BookDimention_V = value; } }
       public string LetterNo_V { get { return _LetterNo_V; } set { _LetterNo_V = value; } }
       public DateTime LetterDate { get { return _LetterDate; } set { _LetterDate = value; } }
       public string bookNo_V { get { return _bookNo_V; } set { _bookNo_V = value; } }
       public string BundleNo_V { get { return _BundleNo_V; } set { _BundleNo_V = value; } }
       public string SatusOfBook_V { get { return _SatusOfBook_V; } set { _SatusOfBook_V = value; } }
       public string PrinterCompanyperson_V { get { return _PrinterCompanyperson_V; } set { _PrinterCompanyperson_V = value; } }
       public DateTime PresentDate_D { get { return _PresentDate_D; } set { _PresentDate_D = value; } }
       public int CheckBundleNoOfBookFirst_I { get { return _CheckBundleNoOfBookFirst_I; } set { _CheckBundleNoOfBookFirst_I = value; } }
       public int CheckBundleNoOfBookSecond { get { return _CheckBundleNoOfBookSecond; } set { _CheckBundleNoOfBookSecond = value; } }
       public string RegisterNo { get { return _RegisterNo; } set { _RegisterNo = value; } }
       public string Remarks_V { get { return _Remarks_V; } set { _Remarks_V = value; } }
       public DateTime Date_D { get { return _Date_D; } set { _Date_D = value; } }
       public DateTime FromDate_D { get { return _FromDate_D; } set { _FromDate_D = value; } }
       public DateTime Receiveddate_D { get { return _Receiveddate_D; } set { _Receiveddate_D = value; } }
        public DateTime Totaldate_D { get { return _Totaldate_D; } set { _Totaldate_D = value; } }
        public DateTime TrnasDate { get { return _TrnasDate; } set { _TrnasDate = value; } }
        public int userID { get { return _userID; } set { _userID = value; } }
       public int ReceivedBookNo_I { get { return _ReceivedBookNo_I; } set { _ReceivedBookNo_I = value; } }
       public int TotalNotuseful_N { get { return _TotalNotuseful_N; } set { _TotalNotuseful_N = value; } }

       public System.Data.DataSet FatchData(int id, int DReceivedType_I, int DUserID, int DTwentyfivePerStatus_I)
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_DPT016_FatchTwentyFivePercentDetails", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("DReceivedType_I", DReceivedType_I);
           obDBAccess.addParam("DUserID", DUserID);
           obDBAccess.addParam("id", id);
           obDBAccess.addParam("DTwentyfivePerStatus_I", DTwentyfivePerStatus_I);
           return obDBAccess.records();
       }
        public int InsertUpdate()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_DPT016_TwentyfivePer_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("OrderNo_V", OrderNo_V);
              obDBAccess.addParam("PinterID_I", PinterID_I);
            obDBAccess.addParam("ChallanNo_V", ChallanNo_V);
            obDBAccess.addParam("ChallanDate", ChallanDate);
            obDBAccess.addParam("TotalNoOfReceiveBundle_I", TotalNoOfReceiveBundle_I);
            obDBAccess.addParam("NofSchemeBook_I", NofSchemeBook_I);
            obDBAccess.addParam("NoOFgenralBook_I", NoOFgenralBook_I);
            obDBAccess.addParam("NoOfBookCounted_I", NoOfBookCounted_I);
            obDBAccess.addParam("BookDimention_V", BookDimention_V);
            obDBAccess.addParam("LetterNo_V", LetterNo_V);
            obDBAccess.addParam("LetterDate", LetterDate);
            obDBAccess.addParam("bookNo_V", bookNo_V);
            obDBAccess.addParam("BundleNo_V", BundleNo_V);
            obDBAccess.addParam("SatusOfBook_V", SatusOfBook_V);
            obDBAccess.addParam("PrinterCompanyperson_V", PrinterCompanyperson_V);
            obDBAccess.addParam("PresentDate_D", PresentDate_D);
            obDBAccess.addParam("CheckBundleNoOfBookFirst_I", CheckBundleNoOfBookFirst_I);
            obDBAccess.addParam("CheckBundleNoOfBookSecond", CheckBundleNoOfBookSecond);
            
            obDBAccess.addParam("RegisterNo", RegisterNo);
            obDBAccess.addParam("Date_D", Date_D);
             obDBAccess.addParam("Remarks_V", Remarks_V);
            obDBAccess.addParam("FromDate_D", FromDate_D);
            obDBAccess.addParam("Totaldate_D", Totaldate_D);
             obDBAccess.addParam("ReceivedBookNo_I", ReceivedBookNo_I);
             obDBAccess.addParam("Receiveddate_D", Receiveddate_D);
            obDBAccess.addParam("TotalNotuseful_N", TotalNotuseful_N);
            obDBAccess.addParam("userID", userID);
            obDBAccess.addParam("TitalID", TitalID);
            obDBAccess.addParam("Hund_ReDate", Hund_ReDate);
            
             obDBAccess.addParam("DStockReceivedTPerID_I", DStockReceivedTPerID_I);
            obDBAccess.addParam("TrnasDate", TrnasDate);
             object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);
        }
        public int InsertUpdateHund()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT017_UpdateHundredPer", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", DStockReceivedTPerID_I);
            obDBAccess.addParam("FromDate_D", FromDate_D);
            obDBAccess.addParam("Totaldate_D", Totaldate_D);
            obDBAccess.addParam("Remarks_V", Remarks_V);
            obDBAccess.addParam("Hund_ReDate", Hund_ReDate);
            obDBAccess.addParam("mReceivedBookNo_I", ReceivedBookNo_I);
            obDBAccess.addParam("TotalNotuseful_N", TotalNotuseful_N);
            object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);
        }
      //--
        public int UpdateTwStatus()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT016_UpdateTwentyFiveStatus", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", PinterID_I);
           object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);
        }
        //
        public System.Data.DataSet FillHundredPerPriterDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT017_FillHundredPerPrinterDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", PinterID_I);
            return obDBAccess.records();
        }
        public  System.Data.DataSet FillPriterDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT017_FillPrinterDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("@muserID", userID);
            
            return obDBAccess.records();
        }
       public  System.Data.DataSet FillHundredPerDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT017_LoadHunderedPerDataDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", PinterID_I);
            obDBAccess.addParam("DateD", LetterNo_V);
            return obDBAccess.records();
        }
       
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT016_TwntyFivePerCounting_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DUserID", LetterNo_V);
            obDBAccess.addParam("id", PinterID_I);
              return obDBAccess.records();
        }

        public int Delete(int id)
        {
            
             DBAccess obDBAccess = new DBAccess();
             obDBAccess.execute("USP_DPT016_TwentyFivePer_delete", DBAccess.SQLType.IS_PROC);
             obDBAccess.addParam("id", id);
             int result = obDBAccess.executeMyQuery();
            return result;
        }

        
    }
}
