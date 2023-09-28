using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public  class otherStockOpeningDetails : ICommon
    {
    private int _DOtherStockID_I;
    private int _WareHouseID_I1;
    private string _OtherBookName_V ;
    private int _PerBandalNo_I;
    private int _TotalBandal_I;
    private int _TotalNo_I;
    private int _DepoID_I;
    private DateTime _TransactionDate_D;
    private int _UserID_I;
    private int _TransID_I;
    //private int _TotalBandal_I;
    public int DOtherStockID_I { get { return _DOtherStockID_I; } set { _DOtherStockID_I = value; } }
    public int TotalBandal_I { get { return _TotalBandal_I; } set { _TotalBandal_I = value; } }
    public int WareHouseID_I1 { get { return _WareHouseID_I1; } set { _WareHouseID_I1 = value; } }
    public string OtherBookName_V { get { return _OtherBookName_V; } set { _OtherBookName_V = value; } }
    public int PerBandalNo_I { get { return _PerBandalNo_I; } set { _PerBandalNo_I = value; } }
    public int TotalNo_I { get { return _TotalNo_I; } set { _TotalNo_I = value; } }
    public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
    public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
    public int TransID_I { get { return _TransID_I; } set { _TransID_I = value; } }
    public DateTime  TransactionDate_D { get { return _TransactionDate_D; } set { _TransactionDate_D = value; } }
     
 public int InsertUpdate()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DPT008_OtherStockDetails_Save", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("DOtherStockID_I", DOtherStockID_I);
    obDBAccess.addParam("OtherBookName_V", OtherBookName_V);
    obDBAccess.addParam("PerBandalNo_I", PerBandalNo_I);
    obDBAccess.addParam("TotalBandal_I", TotalBandal_I);
    obDBAccess.addParam("WareHouseID_I", _WareHouseID_I1);
     
    obDBAccess.addParam("TotalNo_I", TotalNo_I);
    obDBAccess.addParam("DepoID_I", DepoID_I);
    obDBAccess.addParam("TransactionDate_D", TransactionDate_D);
    obDBAccess.addParam("UserID_I", UserID_I);
    obDBAccess.addParam("TransID_I", TransID_I); 
    int result = obDBAccess.executeMyQuery();
    return result;
 }

public System.Data.DataSet Select()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DPT008_OtherStockDetails_Load", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ID",DOtherStockID_I);
    obDBAccess.addParam("UID", UserID_I );
    return obDBAccess.records();
   
}

public int Delete(int id)
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_DPT008_OtherStockDetails_Delete", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ID", id);
    int result = obDBAccess.executeMyQuery();
    return result;
   
}
    }
}
