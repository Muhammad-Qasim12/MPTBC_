using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class TransportMaster : ICommon
    {
  private int   _TransportID_I;
 private string _TransportName_V;
 private string  _RegistrationNo_V;
 private DateTime  _RegistrationDate_D;
 private string  _TransportOwnerName_V;
 private string _MobileNo_N;
  private string  _TelephoneNo_V;
  private string _Address_V;
 private int  _DistrictID_I;
 private string  _FaxNumber_V;
 private string  _EmailID_V;
 private string  _PanNo_V;
 private string _TinNo_V;
 private string _ServiceNo_V;
 private string _ServicePeriod_V;
 private decimal _RegistrationAmount_N;
 private string _DDNo_V;
 private string _BankName_V;
private string _DepoID_I;
private DateTime  _TransactionDate_D;
private int _UserID_I;
private int _TransID;
private int _Result1;
private string  _TenNumber;
private string _City_V, _PinNo, _EPFNO;
private DateTime _DDDate;
private string _fyYear;
public string fyYear { get { return _fyYear; } set { _fyYear = value; } }
public string EPFNO { get { return _EPFNO; } set { _EPFNO = value; } }
public DateTime DDDate { get { return _DDDate; } set { _DDDate = value; } }
public string City_V { get { return _City_V; } set { _City_V = value; } }
public string PinNo { get { return _PinNo; } set { _PinNo = value; } }

public string TenNumber { get { return _TenNumber; } set { _TenNumber = value; } }
public int Result1 { get { return _Result1; } set { _Result1 = value; } }
public int  TransportID_I { get { return _TransportID_I; } set { _TransportID_I = value; } }

public string TelephoneNo_V { get { return _TelephoneNo_V; } set { _TelephoneNo_V = value; } }
public string TransportName_V { get { return _TransportName_V; } set { _TransportName_V = value; } }
public string RegistrationNo_V { get { return _RegistrationNo_V; } set { _RegistrationNo_V = value; } }
public DateTime  RegistrationDate_D { get { return _RegistrationDate_D; } set { _RegistrationDate_D = value; } }
public string TransportOwnerName_V { get { return _TransportOwnerName_V; } set { _TransportOwnerName_V = value; } }
public string   MobileNo_N { get { return _MobileNo_N; } set { _MobileNo_N = value; } }
public string Address_V { get { return _Address_V; } set { _Address_V = value; } }
public int  DistrictID_I { get { return _DistrictID_I; } set { _DistrictID_I = value; } }
public string FaxNumber_V { get { return _FaxNumber_V; } set { _FaxNumber_V = value; } }
public string EmailID_V { get { return _EmailID_V; } set { _EmailID_V = value; } }
public string PanNo_V { get { return _PanNo_V; } set { _PanNo_V = value; } }
public string TinNo_V { get { return _TinNo_V; } set { _TinNo_V = value; } }
public string ServiceNo_V { get { return _ServiceNo_V; } set { _ServiceNo_V = value; } }
public string ServicePeriod_V { get { return _ServicePeriod_V; } set { _ServicePeriod_V = value; } }
public decimal  RegistrationAmount_N { get { return _RegistrationAmount_N; } set { _RegistrationAmount_N = value; } }
public string DDNo_V { get { return _DDNo_V; } set { _DDNo_V = value; } }
public string BankName_V { get { return _BankName_V; } set { _BankName_V = value; } }
public string DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
public DateTime  TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
public int  TransID { get { return _TransID; } set { _TransID = value; } }
public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DTP002_TransportMaster_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("TransportID_ID", TransportID_I);
            obDBAccess.addParam("RegistrationNo_V", RegistrationNo_V);
            obDBAccess.addParam("RegistrationDate_D", RegistrationDate_D);
            obDBAccess.addParam("TransportOwnerName_V", TransportOwnerName_V);
            obDBAccess.addParam("TransportName_V", TransportName_V);
            obDBAccess.addParam("MobileNo_N", MobileNo_N);
            obDBAccess.addParam("TelephoneNo_V", TelephoneNo_V);
            obDBAccess.addParam("Address_V", Address_V);
            obDBAccess.addParam("DistrictID_I", DistrictID_I);
            obDBAccess.addParam("FaxNumber_V", FaxNumber_V);
            obDBAccess.addParam("EmailID_V", EmailID_V);
            obDBAccess.addParam("PanNo_V", PanNo_V);
            obDBAccess.addParam("TinNo_V", TinNo_V);
            obDBAccess.addParam("ServiceNo_V", ServiceNo_V);
            obDBAccess.addParam("ServicePeriod_V", ServicePeriod_V);
            obDBAccess.addParam("RegistrationAmount_N", RegistrationAmount_N);
            obDBAccess.addParam("DDNo_V", DDNo_V);
            obDBAccess.addParam("BankName_V", BankName_V);
            obDBAccess.addParam("DepoID_I", DepoID_I);
            obDBAccess.addParam("UserID_I", UserID_I );
            obDBAccess.addParam("Trans_I", TransID);
            obDBAccess.addParam("TransactionDate_D", TransactionDate_D);
            obDBAccess.addParam("TenNumber", TenNumber);
            obDBAccess.addParam("City_V", City_V);
            obDBAccess.addParam("PinNo", PinNo);
            obDBAccess.addParam("DDDate", DDDate);
            obDBAccess.addParam("EPFNO", EPFNO);
            obDBAccess.addParam("Fyyeara", fyYear);
            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;

            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        { 
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT002_TransportMaster_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", TransportID_I);
            obDBAccess.addParam("UID", UserID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        { DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT002_TranspotMaster_Delete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}
