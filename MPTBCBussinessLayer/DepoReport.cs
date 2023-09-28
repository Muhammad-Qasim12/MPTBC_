using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public class DepoReport :ICommon
   {
       public int _WareID;
       public string _Type, _Remark, _RenewalNO;
       public double _RenewalAmount;
       
       public int _UserID;
       public int _ID,_DistrictID;
        #region ICommon Members

       public int WareID { get { return _WareID; } set { _WareID = value; } }
       public string Type { get { return _Type; } set { _Type = value; } }
       public string RenewalNO { get { return _RenewalNO; } set { _RenewalNO = value; } }
       public string Remark { get { return _Remark; } set { _Remark = value; } }
       public double RenewalAmount { get { return _RenewalAmount; } set { _RenewalAmount = value; } }

       public int UserID { get { return _UserID; } set { _UserID = value; } }
       public int DistrictID { get { return _DistrictID; } set { _DistrictID = value; } }
       public int ID { get { return _ID; } set { _ID = value; } }
       public DateTime _fromdate, _Todate;
       public DateTime fromdate { get { return _fromdate; } set { _fromdate = value; } }
       public DateTime Todate { get { return _Todate; } set { _Todate = value; } }

       //,,,,
        public int InsertUpdate()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_DPT", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("Type", Type);
           obDBAccess.addParam("DTrNO", ID);
            
           obDBAccess.addParam("WareID", WareID);
           obDBAccess.addParam("RenewalDate", fromdate);
           obDBAccess.addParam("RenewalAmount", RenewalAmount);
           obDBAccess.addParam("RenewalNO", RenewalNO);
           obDBAccess.addParam("Remark", Remark);
           int result = Convert.ToInt32(obDBAccess.executeMyScalar());
           return result;           
        }
        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
           
        }
        public System.Data.DataSet LoadChallanDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT0013_LoadChallanDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("depoID", UserID);
            return obDBAccess.records();
        }
        public System.Data.DataSet legalReport()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_LG_GetReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("fromdate", fromdate);
            obDBAccess.addParam("todate", Todate);
            obDBAccess.addParam("id", ID);
            return obDBAccess.records();
        }
       //USP_LG_GetReport
        public System.Data.DataSet TransportReport()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPTTransproterReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("Fromdate", fromdate);
            obDBAccess.addParam("Todate", Todate);
            obDBAccess.addParam("userID", UserID);
            obDBAccess.addParam("id", ID);
            return obDBAccess.records();
        }

        public System.Data.DataSet BookSellerReport()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Repot001bookseller", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("distid", DistrictID);
            obDBAccess.addParam("userid", UserID);
            obDBAccess.addParam("id", ID );
            return obDBAccess.records();
        }
        public System.Data.DataSet wareHousereport()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_WareHouseReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DistrictID", DistrictID);
            obDBAccess.addParam("USerID", UserID);
            obDBAccess.addParam("ID", ID);
            return obDBAccess.records();
        }
        public System.Data.DataSet GetBooksellerBankDraft()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPTBookSellerBankDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("UID", UserID);
            obDBAccess.addParam("fromdate", fromdate);
            obDBAccess.addParam("todate", Todate);
            return obDBAccess.records();
        }
        public System.Data.DataSet GetBookReturnDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPTBookReturn", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", UserID);
            obDBAccess.addParam("fromdate", fromdate);
            obDBAccess.addParam("todate", Todate);
            return obDBAccess.records();
        }
        public System.Data.DataSet GetTranportRateDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPTTranportRateDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("id", ID);
            return obDBAccess.records();
        }
        public System.Data.DataSet GetTwentyFivePer()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPTTwentyFiveReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("fromdate", fromdate);
            obDBAccess.addParam("Todate", Todate);
            obDBAccess.addParam("ID", ID);
            return obDBAccess.records();
        }
        public System.Data.DataSet GetFinalCounting()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPTFinalCounting", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("fromdate", fromdate);
            obDBAccess.addParam("todate", Todate);
            obDBAccess.addParam("ID", ID);
            return obDBAccess.records();
        }
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
