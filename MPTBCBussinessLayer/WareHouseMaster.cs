using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{

 


    public class WareHouseMaster : ICommon
    {
        private Int32 _WareHouseID;
        private string _WareHouseName_V;
        private string _RegistrationNo_V;
        private DateTime _RegistrationDate_D;
        private string _WareHouseOwnerName_V;
        private string _WareHouseAddress_V;
        private string _CarpateArea_V;
        private string _MobileNo_N;
        private int _TranID;
        private string _TelephoneNo_V;
        private int _DistrictID_I;
        private string _FaxNumber_V;
        private string _PanNo_V;
        private string _TinNo_V;
        private string _ServiceNo_V;
        private string _EmailID_V;
        private double _RegistrationAmount_N;
        private string _DDNo_V;
        private string _BankName_V;
        private string _WareHouseMap_V;
        private string _Agreement_V;
        private string _ServicePeriod_V;
        private DateTime _RentDate_D;
        private DateTime _DDDate;
        private decimal _RentAmount_N;
        private int _DepoID_I;
        private DateTime _TransactionDate_D;
        private int _UserID_I;
        private int _Trans_I;
        private int _WarehouseType, _CorpetType, _AmountType;
     private string _CityName_V;
     private int _PinNo;
     private string _TanNumber;


     public DateTime  DDDate { get { return _DDDate; } set { _DDDate = value; } }
     public string CityName_V { get { return _CityName_V; } set { _CityName_V = value; } }
     public string TanNumber { get { return _TanNumber; } set { _TanNumber = value; } }

         public int PinNo { get { return _PinNo; } set { _PinNo = value; } }
        public int WarehouseType { get { return _WarehouseType; } set { _WarehouseType = value; } }
        public int CorpetType { get { return _CorpetType; } set { _CorpetType = value; } }
        public int AmountType { get { return _AmountType; } set { _AmountType = value; } }

        public string ServicePeriod_V { get { return _ServicePeriod_V; } set { _ServicePeriod_V = value; } }
        public int TranID { get { return _TranID; } set { _TranID = value; } }
        public Int32 WareHouseID { get { return _WareHouseID; } set { _WareHouseID = value; } }
        public string WareHouseName_V { get { return _WareHouseName_V; } set { _WareHouseName_V = value; } }
        public string RegistrationNo_V { get { return _RegistrationNo_V; } set { _RegistrationNo_V = value; } }
        public DateTime RegistrationDate_D { get { return _RegistrationDate_D; } set { _RegistrationDate_D = value; } }
        public string WareHouseOwnerName_V { get { return _WareHouseOwnerName_V; } set { _WareHouseOwnerName_V = value; } }
        public string CarpateArea_V { get { return _CarpateArea_V; } set { _CarpateArea_V = value; } }
        public string MobileNo_N { get { return _MobileNo_N; } set { _MobileNo_N = value; } }
        public string EmailID_V { get { return _EmailID_V; } set { _EmailID_V = value; } }
      
        public int DistrictID_I { get { return _DistrictID_I; } set { _DistrictID_I = value; } }
        public string FaxNumber_V { get { return _FaxNumber_V; } set { _FaxNumber_V = value; } }
        public string PanNo_V { get { return _PanNo_V; } set { _PanNo_V = value; } }

        public string TinNo_V { get { return _TinNo_V; } set { _TinNo_V = value; } }
        public string ServiceNo_V { get { return _ServiceNo_V; } set { _ServiceNo_V = value; } }
        public double RegistrationAmount_N { get { return _RegistrationAmount_N; } set { _RegistrationAmount_N = value; } }

        public string DDNo_V { get { return _DDNo_V; } set { _DDNo_V = value; } }

        public string BankName_V { get { return _BankName_V; } set { _BankName_V = value; } }
        public string WareHouseMap_V { get { return _WareHouseMap_V; } set { _WareHouseMap_V = value; } }
        public string Agreement_V { get { return _Agreement_V; } set { _Agreement_V = value; } }

        public DateTime RentDate_D { get { return _RentDate_D; } set { _RentDate_D = value; } }
        public decimal RentAmount_N { get { return _RentAmount_N; } set { _RentAmount_N = value; } }
        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
        public DateTime TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
        public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
        public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
        public string  TelephoneNo_V { get { return _TelephoneNo_V; } set { _TelephoneNo_V = value; } }
        public string WareHouseAddress_V { get { return _WareHouseAddress_V; } set { _WareHouseAddress_V = value; } }
        
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            
            obDBAccess.execute("USP_DPT001_WarehouseMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("@DWareHouseID_I", WareHouseID);
            obDBAccess.addParam("@WareHouseName_V", WareHouseName_V);
            obDBAccess.addParam("@RegistrationNo_V", RegistrationNo_V);
            obDBAccess.addParam("@RegistrationDate_D", RegistrationDate_D);
            obDBAccess.addParam("@WareHouseOwnerName_V", WareHouseOwnerName_V);
            obDBAccess.addParam("@CarpateArea_V", CarpateArea_V);
            obDBAccess.addParam("@MobileNo_N", MobileNo_N);
            obDBAccess.addParam("@TelephoneNo_V",TelephoneNo_V);
            obDBAccess.addParam("@WareHouseAddress_V",WareHouseAddress_V);
            obDBAccess.addParam("@DistrictID_I", DistrictID_I);
            obDBAccess.addParam("@FaxNumber_V", FaxNumber_V);
            obDBAccess.addParam("@EmailID_V", EmailID_V);
            obDBAccess.addParam("@PanNo_V", PanNo_V);
            obDBAccess.addParam("@TinNo_V", TinNo_V);
            obDBAccess.addParam("@ServiceNo_V", ServiceNo_V);
            obDBAccess.addParam("@ServicePeriod_V", ServicePeriod_V);
            obDBAccess.addParam("@RegistrationAmount_N", RegistrationAmount_N);
            obDBAccess.addParam("@DDNo_V", DDNo_V);
            obDBAccess.addParam("@BankName_V", BankName_V);
            obDBAccess.addParam("@WareHouseMap_V", WareHouseMap_V);
            obDBAccess.addParam("@RentDate_D", RentDate_D);
            obDBAccess.addParam("@RentAmount_N", RentAmount_N);
            obDBAccess.addParam("@Agreement_v", Agreement_V);
            obDBAccess.addParam("@DepoID_I", DepoID_I);
            obDBAccess.addParam("@UserID_I", UserID_I);
            obDBAccess.addParam("@TranID", TranID);
            obDBAccess.addParam("@TransactionDate_D", TransactionDate_D);
            obDBAccess.addParam("@WarehouseType", WarehouseType);
            obDBAccess.addParam("@CorpetType", CorpetType);
            obDBAccess.addParam("@AmountType", AmountType);
            obDBAccess.addParam("@CityName_V", CityName_V);
            obDBAccess.addParam("@PinNo", PinNo);
            obDBAccess.addParam("@TanNumber", TanNumber);
            obDBAccess.addParam("@DDDate", DDDate);

            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT001_WarehouseMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("@ID", WareHouseID);
            obDBAccess.addParam("@UID", UserID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT001_WarehouseMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
          
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}
