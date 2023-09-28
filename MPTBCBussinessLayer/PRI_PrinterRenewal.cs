using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class PRI_PrinterRenewal : ICommon
    {
        private Int32 _PriRenewalID_I;
        private Int32 _Printer_RedID_I;
        private DateTime _Renewaldate_D;
        private Int32 _Amount_I;
        private string _AmtDetail_V;
        private DateTime _RenFrom_D;
        private DateTime _RenTo_D;
        private string _NameofPress;
        

        public Int32 PriRenewalID_I { get { return _PriRenewalID_I; } set { _PriRenewalID_I = value; } }
        public Int32 Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public DateTime Renewaldate_D { get { return _Renewaldate_D; } set { _Renewaldate_D = value; } }
        public Int32 Amount_I { get { return _Amount_I; } set { _Amount_I = value; } }
        public string AmtDetail_V { get { return _AmtDetail_V; } set { _AmtDetail_V = value; } }
        public DateTime RenFrom_D { get { return _RenFrom_D; } set { _RenFrom_D = value; } }
        public DateTime RenTo_D { get { return _RenTo_D; } set { _RenTo_D = value; } }
        public string NameofPress { get { return _NameofPress; } set { _NameofPress = value; } }
       
        
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI005_PrinterRenewalsave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPriRenewalID_I", PriRenewalID_I);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mRenewaldate_D", Renewaldate_D);
            obDBAccess.addParam("mAmount_I", Amount_I);
            obDBAccess.addParam("mAmtDetail_V", AmtDetail_V);
            obDBAccess.addParam("mRenFrom_D", RenFrom_D);
            obDBAccess.addParam("mRenTo_D", RenTo_D);


            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI005_PrinterRenewalload", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
            obDBAccess.addParam("mPriRenewalID_I", PriRenewalID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }


        public System.Data.DataSet SelectSearch()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI005_PrinterRenewalSearchLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrintername",NameofPress);
            obDBAccess.addParam("mPriRenewalID_I", PriRenewalID_I);
           
            return obDBAccess.records();
            throw new NotImplementedException();
        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI005_PrinterRenewalDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPriRenewalID_I", id);
          
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}
