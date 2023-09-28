using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public  class DepoBookDemand :ICommon 
    {
      private string _Date;
      private int _DDemandID_I;
      private int _DemandType_I;private int _BookType_I;private DateTime _DemandDate_D;
      private int _MedaimID_I;private int _ClassID_I;private int _DepoID;
      private DateTime _TransactionDate_D;int _UserID_I;
      private int _DDemandDetailsID_I;
      private int _SubjectID_I;
      private int _Demand_I;
      private int _isSubmited;
      private int _RequesrdQt_I;
      private int _StockP;
      public string _OrderNo;
      public string OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }
      public int StockP { get { return _StockP; } set { _StockP = value; } }
      public string Date { get { return _Date; } set { _Date = value; } }
      public int RequesrdQt_I { get { return _RequesrdQt_I; } set { _RequesrdQt_I = value; } }
      public int isSubmited { get { return _isSubmited; } set { _isSubmited = value; } }
      public int DDemandDetailsID_I { get { return _DDemandDetailsID_I; } set { _DDemandDetailsID_I = value; } }
      public int SubjectID_I { get { return _SubjectID_I; } set { _SubjectID_I = value; } }
      public int Demand_I { get { return _Demand_I; } set { _Demand_I = value; } }
      public int DDemandID_I { get { return _DDemandID_I; } set { _DDemandID_I = value; } }
      public int DemandType_I { get { return _DemandType_I; } set { _DemandType_I = value; } }
      public int BookType_I { get { return _BookType_I; } set { _BookType_I = value; } }
      public DateTime DemandDate_D { get { return _DemandDate_D; } set { _DemandDate_D = value; } }
       public DateTime TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
     // public DateTime TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; }
      public int MedaimID_I { get { return _MedaimID_I; } set { _MedaimID_I = value; } }
      public int ClassID_I { get { return _ClassID_I; } set { _ClassID_I = value; } }
      public int DepoID { get { return _DepoID; } set { _DepoID = value; } }
       public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
      public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DTP014_DemandonDepoMaster_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DDemandID_I", DDemandID_I);
            obDBAccess.addParam("DemandType_I", DemandType_I);
            obDBAccess.addParam("BookType_I", BookType_I);
            obDBAccess.addParam("DemandDate_D", DemandDate_D);
            obDBAccess.addParam("TransactionDate_D", TransactionDate_D);
            obDBAccess.addParam("MedaimID_I", MedaimID_I);
            obDBAccess.addParam("ClassID_I", ClassID_I);
            obDBAccess.addParam("OrderNo", OrderNo);
            obDBAccess.addParam("DepoID", DepoID);
             obDBAccess.addParam("UserID_I", UserID_I);
            object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);
        }
       public int InsertUpdateDemandDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT015_DemandDetail_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DDemandDetailsID_I", DDemandDetailsID_I);
            obDBAccess.addParam("DemandID_I", DDemandID_I);
            obDBAccess.addParam("SubjectID_I", SubjectID_I);
            obDBAccess.addParam("ClassID_I", ClassID_I);
            obDBAccess.addParam("Demand_I", Demand_I);
             obDBAccess.addParam("DepoID_I", DepoID);
             obDBAccess.addParam("UserID_I", UserID_I);
             obDBAccess.addParam("StockP", StockP);
           
             obDBAccess.addParam("isSubmited", isSubmited);
             obDBAccess.addParam("RequesrdQt_I", RequesrdQt_I);
           
            object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);
        }
       public int UpdateDemandDetails()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_DPT015_UpdatedemandDetails", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("id", DDemandDetailsID_I);
            int  result = obDBAccess.executeMyQuery ();
           return Convert.ToInt32(result);
       }
      //USP_DPT015CheckDate
       public System.Data.DataSet CheckDate()
       {

           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_DPT015CheckDate", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("dated", Date);
           obDBAccess.addParam("UserID", UserID_I);
           return obDBAccess.records();
           
       }
        public System.Data.DataSet Select()
        {
      
             DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT015_DemandDetails_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", DDemandID_I);
            obDBAccess.addParam("UserID", UserID_I);
            return obDBAccess.records();
            
        }
        public System.Data.DataSet fillBookData(string  ClassID, int mMediumID, int BookTypoe, int mUser_I)
        {
            // 
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT014FatchBookStockDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClassID", ClassID);
            obDBAccess.addParam("mMediumID", mMediumID);
            obDBAccess.addParam("BookTypoe", BookTypoe);
            obDBAccess.addParam("mUser_I", mUser_I);
            return obDBAccess.records();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        }
    }

