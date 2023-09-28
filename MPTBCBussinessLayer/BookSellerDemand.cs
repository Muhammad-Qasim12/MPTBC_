using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class BookSellerDemand :ICommon
    {
       private int _Depo_ID_I;
       private int _Meidum_ID_I;
       private int _TitalID_I;
       private int _TotalDemand;
       private int _Issumbited_I;
       private int _User_ID_I;
       private int _ClassID_I;
       private DateTime _BDate_D;
       private DateTime _TranDate_D;
       private int _DBookSelleDemandTrNo_I;
       private string _DOrderNo;
       private int _TransIDI_I;
       public DateTime _DDDate;
       public string _DDNouber;
       public string _BankName;

       public string BankName { get { return _BankName; } set { _BankName = value; } }
       public string DDNouber { get { return _DDNouber; } set { _DDNouber = value; } }
       public DateTime DDDate { get { return _DDDate; } set { _DDDate = value; } }


       public string DOrderNo { get { return _DOrderNo; } set { _DOrderNo = value; } }
       public int TransIDI_I { get { return _TransIDI_I; } set { _TransIDI_I = value; } }
       public int Depo_ID_I { get { return _Depo_ID_I; } set { _Depo_ID_I = value; } }
       public int Meidum_ID_I { get { return _Meidum_ID_I; } set { _Meidum_ID_I = value; } }
       public int TotalDemand { get { return _TotalDemand; } set { _TotalDemand = value; } }
       public int TitalID_I { get { return _TitalID_I; } set { _TitalID_I = value; } }
       public int Issumbited_I { get { return _Issumbited_I; } set { _Issumbited_I = value; } }
       public int User_ID_I { get { return _User_ID_I; } set { _User_ID_I = value; } }
       public int ClassID_I { get { return _ClassID_I; } set { _ClassID_I = value; } }
      public int DBookSelleDemandTrNo_I { get { return _DBookSelleDemandTrNo_I; } set { _DBookSelleDemandTrNo_I = value; } }
      public DateTime BDate_D { get { return _BDate_D; } set { _BDate_D = value; } }
      public DateTime TranDate_D { get { return _TranDate_D; } set { _TranDate_D = value; } }
      



      #region ICommon Members

      public int InsertUpdate()
      {
          DBAccess obDBAccess = new DBAccess();
          obDBAccess.execute("USP_DPT012_BookSellerDemand_Save", DBAccess.SQLType.IS_PROC);
          obDBAccess.addParam("BDate_D", BDate_D);
           obDBAccess.addParam("DBookSelleDemandTrNo_I", DBookSelleDemandTrNo_I);
          obDBAccess.addParam("Depo_ID_I", Depo_ID_I);
          obDBAccess.addParam("Meidum_ID_I", Meidum_ID_I);
          obDBAccess.addParam("TitalID_I", TitalID_I);
          obDBAccess.addParam("TotalDemand", TotalDemand);
          obDBAccess.addParam("Issumbited_I", Issumbited_I);
          obDBAccess.addParam("ClassID_I", ClassID_I);
          obDBAccess.addParam("User_ID_I", User_ID_I);
          obDBAccess.addParam("TranDate_D", TranDate_D);
          obDBAccess.addParam("TransIDI_I", TransIDI_I);
          obDBAccess.addParam("DOrderNo", DOrderNo);
         
          int result = obDBAccess.executeMyQuery();
          return result;
        
      }
       public int BookUDemandpdate()
      {
          DBAccess obDBAccess = new DBAccess();
          obDBAccess.execute("USP_DPT012_BookDemandSend", DBAccess.SQLType.IS_PROC);
          obDBAccess.addParam("id", DBookSelleDemandTrNo_I);
          obDBAccess.addParam("DOrderNo", DOrderNo);
          obDBAccess.addParam("DDDate", DDDate);
          obDBAccess.addParam("DDNouber", DDNouber);
          obDBAccess.addParam("BankName", BankName);
          int result = obDBAccess.executeMyQuery();
          return result;
        
      }

      public System.Data.DataSet Select()
      {
          DBAccess obDBAccess = new DBAccess();
          obDBAccess.execute("USP_DPT012_BookDemandData_Load", DBAccess.SQLType.IS_PROC);
          obDBAccess.addParam("id", DBookSelleDemandTrNo_I);
          obDBAccess.addParam("UserID", User_ID_I);
          return obDBAccess.records();
      }
      public System.Data.DataSet loadBook(int mediumID, int ClassID)
      {
          DBAccess obDBAccess = new DBAccess();
          obDBAccess.execute("USP_DPT012_LoadTitalMediumwise", DBAccess.SQLType.IS_PROC);
          obDBAccess.addParam("mediumID", mediumID);
          obDBAccess.addParam("ClassID", ClassID);
          return obDBAccess.records();
      }
       

      public int Delete(int id)
      {
          DBAccess obDBAccess = new DBAccess();
          obDBAccess.execute("USP_DPT006_AdvanceDetails_Delete", DBAccess.SQLType.IS_PROC);
          obDBAccess.addParam("ID", id);
          int result = obDBAccess.executeMyQuery();
          return result;
      }

      #endregion
    }
}
