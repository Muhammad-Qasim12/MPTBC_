using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class AdvanceDetails :ICommon 
    {
private int _AdvanceDetailsID;
private int _HeadID;
private double _Amount;
private string _QuarterNAme;
private int _DepoID;
private DateTime _TransactionDate;
private int _UserID;
private int _Trans_I;
private DateTime _Ddate_D;
public int AdvanceDetailsID { get { return _AdvanceDetailsID; } set { _AdvanceDetailsID = value; } }
public int HeadID { get { return _HeadID; } set { _HeadID = value; } }
public double  Amount { get { return _Amount; } set { _Amount = value; } }
public double EstimateCost { get; set; }
public double AvailableCost { get; set; }
public string QuarterNAme { get { return _QuarterNAme; } set { _QuarterNAme = value; } }
public DateTime TransactionDate { get { return _TransactionDate; } set { _TransactionDate = value; } }
public int  UserID { get { return _UserID; } set { _UserID = value; } }
public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
public int DepoID { get { return _DepoID; } set { _DepoID = value; } }
public DateTime Ddate_D { get { return _Ddate_D; } set { _Ddate_D = value; } }
       
       
public int InsertUpdate()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("UPS_DPT006_AdvanceDetails_Save", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("DAdvanceDetailsID", AdvanceDetailsID);
    obDBAccess.addParam("HeadID", HeadID);
    obDBAccess.addParam("Amount", Amount);
    obDBAccess.addParam("QuarterNAme", QuarterNAme);
    obDBAccess.addParam("DepoID", DepoID);
    obDBAccess.addParam("TransactionDate", TransactionDate);
    obDBAccess.addParam("UserID", UserID);
    obDBAccess.addParam("Trans_I", Trans_I);
    obDBAccess.addParam("Ddate_D", Ddate_D);
    obDBAccess.addParam("EstimateCost", EstimateCost);
    obDBAccess.addParam("AvailableCost", AvailableCost);

    
    int result = obDBAccess.executeMyQuery();
    return result;

            throw new NotImplementedException();
        }

public System.Data.DataSet Select()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DTP006_Advancedetails_Load", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("id", AdvanceDetailsID);
    obDBAccess.addParam("UID", UserID );
    return obDBAccess.records();
    throw new NotImplementedException();
}

public int Delete(int id)
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DPT006_AdvanceDetails_Delete", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ID", id);
    int result = obDBAccess.executeMyQuery();
    return result;
   
}
    }
}
