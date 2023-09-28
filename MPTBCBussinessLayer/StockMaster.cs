using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class StockMaster : ICommon
    {
        private int _Stock_ID_I;
        private DateTime _Date_D;
        private int _MediamID_I;
        private int _WareHouseID_I;
        private int _ClassID_I;
        private int _DepoID_I;
        private DateTime _TransactionDate_D;
        private int _UserID_I;
        private int _Trans_I;
        private int _BookType_I;
        private int _TypeDetails;
        public int Stock_ID_I { get { return _Stock_ID_I; } set { _Stock_ID_I = value; } }
        public DateTime Date_D { get { return _Date_D; } set { _Date_D = value; } }
        public int MediamID_I { get { return _MediamID_I; } set { _MediamID_I = value; } }
        public int ClassID_I { get { return _ClassID_I; } set { _ClassID_I = value; } }
        public DateTime TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
        public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
        public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
        public int BookType_I { get { return _BookType_I; } set { _BookType_I = value; } }
        public int WareHouseID_I { get { return _WareHouseID_I; } set { _WareHouseID_I = value; } }
        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
        public int TypeDetails { get { return _TypeDetails; } set { _TypeDetails = value; } }
        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT007_StockMaster", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DStock_ID_I", Stock_ID_I);
            obDBAccess.addParam("Date_D", Date_D);
            obDBAccess.addParam("MediamID_I", MediamID_I);
            obDBAccess.addParam("ClassID_I", ClassID_I);
            obDBAccess.addParam("TransactionDate_D", TransactionDate_D);
            obDBAccess.addParam("UserID_I", UserID_I);
            obDBAccess.addParam("TransID_I", Trans_I);
            obDBAccess.addParam("BookType_I", BookType_I);
            obDBAccess.addParam("WareHouseID_I", WareHouseID_I);
            obDBAccess.addParam("DepoID_I", DepoID_I);
             obDBAccess.addParam("TypeDetails", TypeDetails);
           // TypeDetails
             object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT007_StockMaste_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", Stock_ID_I);
            return obDBAccess.records();
        }
        public System.Data.DataSet Select1(int mClassID, int mMediumID, int BookTypoe, int BookDetail, int MwarehouseID, int mUser_I, DateTime Date_V, Int32 Stock_ID_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT011FatchBookData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mClassID", mClassID);
            obDBAccess.addParam("mMediumID", mMediumID);
            obDBAccess.addParam("BookTypoe", BookTypoe);
            obDBAccess.addParam("BookDetail", BookDetail);
            obDBAccess.addParam("MwarehouseID", MwarehouseID);
            obDBAccess.addParam("mUser_I", mUser_I);
            obDBAccess.addParam("mStock_ID_I", Stock_ID_I);

            obDBAccess.addParam("mDate_V", Date_V);

            
            
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT007_StockMaster_Delete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
    public  class StockDetails :ICommon 
    {
        private int _DStockDetailsID_I;
        private int _Stock_ID_I;
        private int _ClassID_I;
        private int _SubJectID_I;
        private int _BookType_I;
        private int _NoOfBooks_I;
        private int _Trans_I;
        public int DStockDetailsID_I { get { return _DStockDetailsID_I; } set { _DStockDetailsID_I = value; } }
        public int Stock_ID_I { get { return _Stock_ID_I; } set { _Stock_ID_I = value; } }
        public int ClassID_I { get { return _ClassID_I; } set { _ClassID_I = value; } }
        public int SubJectID_I { get { return _SubJectID_I; } set { _SubJectID_I = value; } }
        public int BookType_I { get { return _BookType_I; } set { _BookType_I = value; } }
        public int NoOfBooks_I { get { return _NoOfBooks_I; } set { _NoOfBooks_I = value; } }
        public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }

public int  InsertUpdate()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DPT009_StockDetails_Save", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("DStockDetailsID_I", DStockDetailsID_I);
    obDBAccess.addParam("Stock_ID_I", Stock_ID_I);
    obDBAccess.addParam("ClassID_I", ClassID_I);
    obDBAccess.addParam("SubJectID_I", SubJectID_I);
    obDBAccess.addParam("BookType_I", BookType_I);
    obDBAccess.addParam("NoOfBooks_I", NoOfBooks_I);
    obDBAccess.addParam("Trans_I", Trans_I);
    object result = (object)obDBAccess.executeMyScalar();
    return Convert.ToInt32(result);
 	
}

public System.Data.DataSet  Select()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DPT009_StockDetails_Load", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("id", Stock_ID_I);
    return obDBAccess.records();
}

public int  Delete(int id)
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ID", id);
    int result = obDBAccess.executeMyQuery();
    return result;
}
}
    public class StockDetailsChild:ICommon 
    {
        private int _StockDetailsChildID_I;
        private int _StockDetailsID_I;
        private int _BundleNo_I;
        private int _FromNo_I;
        private int _ToNo_I;
        private int _BundleType_I;
        private string  _RemaingLoose_V;
        private int _Trans_I;

        public int StockDetailsChildID_I { get { return _StockDetailsChildID_I; } set { _StockDetailsChildID_I = value; } }
        public int StockDetailsID_I { get { return _StockDetailsID_I; } set { _StockDetailsID_I = value; } }
        public int BundleNo_I { get { return _BundleNo_I; } set { _BundleNo_I = value; } }
        public int FromNo_I { get { return _FromNo_I; } set { _FromNo_I = value; } }
        public int ToNo_I { get { return _ToNo_I; } set { _ToNo_I = value; } }
        public int BundleType_I { get { return _BundleType_I; } set { _BundleType_I = value; } }
        public string RemaingLoose_V { get { return _RemaingLoose_V; } set { _RemaingLoose_V = value; } }
        public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT010_StockDetailCh_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DStockDetailsChildID_I", StockDetailsChildID_I);
            obDBAccess.addParam("StockDetailsID_I", StockDetailsID_I);
            obDBAccess.addParam("BundleNo_I", BundleNo_I);
            obDBAccess.addParam("FromNo_I", FromNo_I);
            obDBAccess.addParam("ToNo_I", ToNo_I);
            obDBAccess.addParam("BundleType_I", BundleType_I);
            obDBAccess.addParam("RemaingLoose_V", RemaingLoose_V);
            obDBAccess.addParam("Trans_I", Trans_I);
            object result = (object)obDBAccess.executeMyScalar();
          return Convert.ToInt32(result);

        }


        public int InsertUpdate1()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT010_StockDetailCh_Save1", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DStockDetailsChildID_I", StockDetailsChildID_I);
            obDBAccess.addParam("StockDetailsID_I", StockDetailsID_I);
            obDBAccess.addParam("BundleNo_I", BundleNo_I);
            obDBAccess.addParam("FromNo_I", FromNo_I);
            obDBAccess.addParam("ToNo_I", ToNo_I);
            obDBAccess.addParam("BundleType_I", BundleType_I);
            obDBAccess.addParam("RemaingLoose_V", RemaingLoose_V);
            obDBAccess.addParam("Trans_I", Trans_I);
            object result = (object)obDBAccess.executeMyScalar();
            return Convert.ToInt32(result);

        }  

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT010_StockDetailsCh_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", StockDetailsID_I );
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
   }
