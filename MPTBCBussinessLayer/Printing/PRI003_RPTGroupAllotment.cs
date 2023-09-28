using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
  public   class PRI003_RPTGroupAllotment
    {
      int      _Printer_RedID_I ;
      string _AcYearId;

      public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
      public string AcYearId { get { return _AcYearId; } set { _AcYearId = value; } }

      public DataSet LoadGroupAllotment() 
      {
          DBAccess obdbAccess = new DBAccess();

          DataSet ds = new DataSet();

          try
          {
              obdbAccess.execute("USP_PRI003_RPTGroupAllotment", DBAccess.SQLType.IS_PROC);
              obdbAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
              obdbAccess.addParam("mAcYearId", AcYearId);
              ds = obdbAccess.records();
          }

          catch (Exception ex) { }
          finally { obdbAccess= null ; }

          return ds;
      }







    }
}
