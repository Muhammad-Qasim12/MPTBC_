using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class BookDitribute :ICommon
    {
    //,,,,,,,,,,,,,,,,,,
        #region ICommon Members
       private int _dStockReceiveEntryID_I, _IsStanderd_I, _TwentyfivePerStatus_I, _UserID_I, _Stock_ID_I, _ReceivedType_I, _PinterID_I, _EmployeeName_I;
       private int _TransportationCharge_N, _OtherCharges_N, _LordingCharge_N, _unLordingCharge_N;
       private DateTime _OrderDate_D, _ChallanDate_D, _GRDate_D, _TransactionDate_N;
       private string _OrderNo_I;
       public int unLordingCharge_N { get { return _unLordingCharge_N; } set { _unLordingCharge_N = value; } }
       public int LordingCharge_N { get { return _LordingCharge_N; } set { _LordingCharge_N = value; } }
       public int OtherCharges_N { get { return _OtherCharges_N; } set { _OtherCharges_N = value; } }
       public int TransportationCharge_N { get { return _TransportationCharge_N; } set { _TransportationCharge_N = value; } }
       public int dStockReceiveEntryID_I { get { return _dStockReceiveEntryID_I; } set { _dStockReceiveEntryID_I = value; } }
       public int IsStanderd_I { get { return _IsStanderd_I; } set { _IsStanderd_I = value; } }
       public int TwentyfivePerStatus_I { get { return _TwentyfivePerStatus_I; } set { _TwentyfivePerStatus_I = value; } }
       public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
       public int Stock_ID_I { get { return _Stock_ID_I; } set { _Stock_ID_I = value; } }
       public int DistributeType_I { get { return _ReceivedType_I; } set { _ReceivedType_I = value; } }
       public int PinterID_I { get { return _PinterID_I; } set { _PinterID_I = value; } }
       public string OrderNo_I { get { return _OrderNo_I; } set { _OrderNo_I = value; } }
       public int EmployeeName_I { get { return _EmployeeName_I; } set { _EmployeeName_I = value; } }


       private string _ChallanNo_V, _GRNo_V, _TruckNo_V;
       public string TruckNo_V { get { return _TruckNo_V; } set { _TruckNo_V = value; } }
       public string GRNo_V { get { return _GRNo_V; } set { _GRNo_V = value; } }
       public string ChallanNo_V { get { return _ChallanNo_V; } set { _ChallanNo_V = value; } }


       public DateTime OrderDate_D { get { return _OrderDate_D; } set { _OrderDate_D = value; } }
       public DateTime Ddate_D { get { return _OrderDate_D; } set { _OrderDate_D = value; } }
       public DateTime ChallanDate_D { get { return _ChallanDate_D; } set { _ChallanDate_D = value; } }
       public DateTime GRDate_D { get { return _GRDate_D; } set { _GRDate_D = value; } }
       public DateTime TransactionDate_N { get { return _TransactionDate_N; } set { _TransactionDate_N = value; } }


       public string BundleNo { get; set; }
       public string TitleId { get; set; }
       public int ClassId { get; set; }
       public int BookType { get; set; }
       public string LooseBookNo { get; set; }
       public int SDepoID { get; set; }
       
       

      // ,,,,,,,,,,,,,,,,,,)

        public int InsertUpdate()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_DPT19StockDistributeEntrySave", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("dStockReceiveEntryID_I", dStockReceiveEntryID_I);
           obDBAccess.addParam("Stock_ID_I", Stock_ID_I);
           obDBAccess.addParam("OrderNo_I", OrderNo_I);
           obDBAccess.addParam("OrderDate_D", OrderDate_D);
          
           obDBAccess.addParam("ChallanNo_V", ChallanNo_V);
           obDBAccess.addParam("ChallanDate_D", ChallanDate_D);
          
           obDBAccess.addParam("TruckNo_V", TruckNo_V);
           obDBAccess.addParam("EmployeeName_I", EmployeeName_I);
           obDBAccess.addParam("TransportationCharge_N", TransportationCharge_N);
           obDBAccess.addParam("OtherCharges_N", OtherCharges_N);
           obDBAccess.addParam("LordingCharge_N", OtherCharges_N);
           obDBAccess.addParam("unLordingCharge_N", OtherCharges_N);
           obDBAccess.addParam("TransactionDate_N", TransactionDate_N);
           obDBAccess.addParam("UserID_I", UserID_I);
           obDBAccess.addParam("TwentyfivePerStatus_I", TwentyfivePerStatus_I);
           obDBAccess.addParam("IsStanderd_I", IsStanderd_I);
           obDBAccess.addParam("ReceivedType_I", DistributeType_I);
           obDBAccess.addParam("BundleNo", BundleNo);
           obDBAccess.addParam("TitleId", TitleId);
           obDBAccess.addParam("ClassId", ClassId);
           obDBAccess.addParam("LooseBookNo", LooseBookNo);
           obDBAccess.addParam("SDepoID", SDepoID);
           int result = Convert.ToInt32(obDBAccess.executeMyScalar());
           return result;
         
        }
        public int UpdatePrinterStatus()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT022_PrinterDeveStatusUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", dStockReceiveEntryID_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}


