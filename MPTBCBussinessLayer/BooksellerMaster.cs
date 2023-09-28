using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class BooksellerMaster : ICommon
    {
        //,,,,
        private string _Cityname, _PinNumber, _TanNumber, _Validity;
        private DateTime _Chekcdate;
        private Int32 _DBooksellerregistration_I;
        private string _BooksellerName_V;
        private string _RegistrationNo_V;
        private DateTime _RegistrationDate_D;
        private string _BooksellerOwnerName_V;
        private string _MobileNo_N;
        private string _TelephoneNo_V;
        private string _Address_V;
        private int _DistrictID_I;
        private string _FaxNumber_V;
        private string _EmailID_V;
        private decimal _RegistrationAmount_N;
        private string _RegDDNo_V;
      //  private decimal _DepositAmount_N;
      //  private string _DepoDDNo_V;
        private string _LoginID_V;
        private string _UserPassowrd;
        private int _DepoID_I;
        private DateTime _TransactionDate_D;
        private int _UserID_I;
        private int _Trans_I;
        private string _PanNumber;
        private int _Category;

        public int Category { get { return _Category; } set { _Category = value; } }
        public string Cityname { get { return _Cityname; } set { _Cityname = value; } }
        public string PinNumber { get { return _PinNumber; } set { _PinNumber = value; } }
        public string TanNumber { get { return _TanNumber; } set { _TanNumber = value; } }
        public string Validity { get { return _Validity; } set { _Validity = value; } }
        public DateTime Chekcdate { get { return _Chekcdate; } set { _Chekcdate = value; } }

        public int DBooksellerregistration_I { get { return _DBooksellerregistration_I; } set { _DBooksellerregistration_I = value; } }
        public string BooksellerName_V { get { return _BooksellerName_V; } set { _BooksellerName_V = value; } }

        public string PanNumber { get { return _PanNumber; } set { _PanNumber = value; } }

        public string RegistrationNo_V { get { return _RegistrationNo_V; } set { _RegistrationNo_V = value; } }
        public DateTime RegistrationDate_D { get { return _RegistrationDate_D; } set { _RegistrationDate_D = value; } }
        public string BooksellerOwnerName_V { get { return _BooksellerOwnerName_V; } set { _BooksellerOwnerName_V = value; } }
        public string MobileNo_N { get { return _MobileNo_N; } set { _MobileNo_N = value; } }
        public string TelephoneNo_V { get { return _TelephoneNo_V; } set { _TelephoneNo_V = value; } }
        public string Address_V { get { return _Address_V; } set { _Address_V = value; } }
        public int DistrictID_I { get { return _DistrictID_I; } set { _DistrictID_I = value; } }
        public string FaxNumber_V { get { return _FaxNumber_V; } set { _FaxNumber_V = value; } }
        public string EmailID_V { get { return _EmailID_V; } set { _EmailID_V = value; } }
        public decimal RegistrationAmount_N { get { return _RegistrationAmount_N; } set { _RegistrationAmount_N = value; } }
        public string RegDDNo_V { get { return _RegDDNo_V; } set { _RegDDNo_V = value; } }
        //public decimal DepositAmount_N { get { return _DepositAmount_N; } set { _DepositAmount_N = value; } }
        public string LoginID_V { get { return _LoginID_V; } set { _LoginID_V = value; } }
        //public string LoginID_V { get { return _LoginID_V; } set { _LoginID_V = value; } }
        public string UserPassowrd { get { return _UserPassowrd; } set { _UserPassowrd = value; } }
        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
        public DateTime TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
        public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
        public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT004_BooksellerRegistration_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DBooksellerregistration_I", DBooksellerregistration_I);
            obDBAccess.addParam("RegistrationNo_V", RegistrationNo_V);
            obDBAccess.addParam("RegistrationDate_D", RegistrationDate_D);
            obDBAccess.addParam("BooksellerOwnerName_V", BooksellerOwnerName_V);
            obDBAccess.addParam("MobileNo_N", MobileNo_N);
            obDBAccess.addParam("TelephoneNo_V", TelephoneNo_V);
            obDBAccess.addParam("Address_V", Address_V);
            obDBAccess.addParam("DistrictID_I", DistrictID_I);
            obDBAccess.addParam("FaxNumber_V", FaxNumber_V);
            obDBAccess.addParam("EmailID_V", EmailID_V);
            obDBAccess.addParam("RegistrationAmount_N", RegistrationAmount_N);
            obDBAccess.addParam("RegDDNo_V", RegDDNo_V);
            obDBAccess.addParam("BooksellerName_V", BooksellerName_V);
            obDBAccess.addParam("PanNumber", PanNumber);
            obDBAccess.addParam("LoginID_V", LoginID_V);
            obDBAccess.addParam("UserPassowrd", UserPassowrd);
            obDBAccess.addParam("DepoID_I", DepoID_I);
            obDBAccess.addParam("TransactionDate_D", TransactionDate_D);
            obDBAccess.addParam("UserID_I", UserID_I);
            obDBAccess.addParam("TransID_I", Trans_I);
            obDBAccess.addParam("Cityname", Cityname);
            obDBAccess.addParam("PinNumber", PinNumber);
            obDBAccess.addParam("TanNumber", TanNumber);
            obDBAccess.addParam("Chekcdate", Chekcdate);
            obDBAccess.addParam("Validity", Validity);
            obDBAccess.addParam("Category", Category);
            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;


        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT004_Booksellerregistnation_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", DBooksellerregistration_I);
            obDBAccess.addParam("UID", UserID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT004_BooksellerMaster_delete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}
