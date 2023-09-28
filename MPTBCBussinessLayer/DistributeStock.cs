using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPTBCBussinessLayer;

namespace MPTBCBussinessLayer
{
 public class DistributeStock :ICommon 
    {

     private int _OrderNo_I, _mStockDistributionSEntryID_I; 
     // private DateTime _OrderDate_D;
     //private string _ChallanNo_V; 
     // private DateTime _ChallanDate_D;
     private int _DistrictID_I ,_BlockID_I;
     //,_ClassID_I
    // private string _ReceiverName_V,_GRNO_V,_TruckNo_V,_Remarks_V;
    // private DateTime  _GRNODate_D;
    // _DriverMobileNo_V,
     public int mStockDistributionSEntryID_I { get { return _mStockDistributionSEntryID_I; } set { _mStockDistributionSEntryID_I = value; } }
     public int OrderNo_I { get { return _OrderNo_I; } set { _OrderNo_I = value; } }
     public int DistrictID_I { get { return _DistrictID_I; } set { _DistrictID_I = value; } }
     public int BlockID_I { get { return _BlockID_I; } set { _BlockID_I = value; } }

     #region ICommon Members

     public int InsertUpdate()
     {
         DBAccess obDBAccess = new DBAccess();
         obDBAccess.execute("USP_DPT019_DistributeStockSave", DBAccess.SQLType.IS_PROC);
         obDBAccess.addParam("mStockDistributionSEntryID_I", mStockDistributionSEntryID_I);
         obDBAccess.addParam("OrderNo_I", OrderNo_I);
         obDBAccess.addParam("DistrictID_I", DistrictID_I);
         obDBAccess.addParam("BlockID_I", BlockID_I);
         int result = obDBAccess.executeMyQuery();
         return result;
     }

     public System.Data.DataSet Select()
     {
         throw new NotImplementedException();
     }

     public int Delete(int id)
     {
         throw new NotImplementedException();
     }

     #endregion
    }
}
