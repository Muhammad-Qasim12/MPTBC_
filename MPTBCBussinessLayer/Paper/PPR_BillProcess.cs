using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public class PPR_BillProcess
   {
       private int _BillGenId_I;
       private int _PaperVendorTrId_I;
       private string _Remark_V;



       public int BillGenId_I { get { return _BillGenId_I; } set { _BillGenId_I = value; } }
       public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }

       public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }


       public int InsertUpdate()
       {

           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PPR0013_BillProcessUpdateData", DBAccess.SQLType.IS_PROC);           
           obDBAccess.addParam("mBillGenId_I", BillGenId_I);
           obDBAccess.addParam("mRemark", Remark_V);
           int result = obDBAccess.executeMyQuery();
           return result;
       }

       public System.Data.DataSet Select()
       {
          
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PPR0013_BillProcessShowData", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
           obDBAccess.addParam("mBillGenId_I", 0);
           obDBAccess.addParam("mtype", 0); 
           
           return obDBAccess.records();
       }
       public System.Data.DataSet ChallanDtlSelect()
       {

           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PPR0013_BillProcessShowData", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mPaperVendorTrId_I", 0);
           obDBAccess.addParam("mBillGenId_I", 0);
           obDBAccess.addParam("mtype", 2);

           return obDBAccess.records();
       }
       public System.Data.DataSet BillDetailsFill()
       {

           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PPR0013_BillProcessShowData", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
           obDBAccess.addParam("mBillGenId_I", BillGenId_I);
           obDBAccess.addParam("mtype", 1);

           return obDBAccess.records();
       }

   }
}
