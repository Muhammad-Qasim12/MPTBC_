using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MPTBCBussinessLayer;

namespace MPTBCBussinessLayer
{
    public class PRI_PaperBillInterestonPaper:ICommon
    {
        private int _BillIntID_I;
        private int _PrinterID_I;
        private string _JobCode_V;
        private int _PaperAltID_I;
        private double _PaperSupplyTon_N;
        private DateTime _SupplyDate_D;
        private DateTime _ReturnDate_D;
        private double _Days_N;
        private double _Amount_N;
        private int _InttperTon_I;
        private int _USerID_I;
        private DateTime _Transdate_D;



        public int BillIntID_I { get { return _BillIntID_I; } set { _BillIntID_I = value; } }
        public int PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public int PaperAltID_I { get { return _PaperAltID_I; } set { _PaperAltID_I = value; } }
        public double PaperSupplyTon_N { get { return _PaperSupplyTon_N; } set { _PaperSupplyTon_N = value; } }
        public DateTime SupplyDate_D { get { return _SupplyDate_D; } set { _SupplyDate_D = value; } }
        public DateTime ReturnDate_D { get { return _ReturnDate_D; } set { _ReturnDate_D = value; } }
        public double Days_N { get { return _Days_N; } set { _Days_N = value; } }
        public double Amount_N { get { return _Amount_N; } set { _Amount_N = value; } }
        public int InttperTon_I { get { return _InttperTon_I; } set { _InttperTon_I = value; } }
        public int USerID_I { get { return _USerID_I; } set { _USerID_I = value; } }
        public DateTime Transdate_D { get { return _Transdate_D; } set { _Transdate_D = value; } }


        public System.Data.DataSet LoadReportBillInterest()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI007_RPTBillInterestOnPaper", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPrinter_RedID_I", PrinterID_I);
                return obDBAccess.records();
            }
            catch { }
            throw new NotImplementedException();
        }


        public int InsertUpdate()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI007_BillInterestOnPaperSave", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mBillIntID_I", BillIntID_I);
                obDBAccess.addParam("mPrinterID_I", PrinterID_I);
                obDBAccess.addParam("mJobCode_V", JobCode_V);
                obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
                obDBAccess.addParam("mPaperSupplyTon_N", PaperSupplyTon_N);
                obDBAccess.addParam("mSupplyDate_D", SupplyDate_D);
                obDBAccess.addParam("mReturnDate_D", ReturnDate_D);
                obDBAccess.addParam("mDays_N", Days_N);
                obDBAccess.addParam("mAmount_N", Amount_N);
                obDBAccess.addParam("mInttperTon_I", InttperTon_I);
                obDBAccess.addParam("mUSerID_I", USerID_I);
                obDBAccess.addParam("mTransdate_D", Transdate_D);
                

                int result = obDBAccess.executeMyQuery();
                return result;
            }
            catch { }
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI006_PaperAllotmentLoad", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
                return obDBAccess.records();
            }
            catch { }
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select(int i)
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI007_BillInterestOnPaperLoad", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mBillIntID_I", i);
                return obDBAccess.records();
            }
            catch { }
            throw new NotImplementedException();
        }

        public System.Data.DataSet SelectPaperBillIntrestLoad()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI007_BillInterestOnPaperLoadWithAllotment", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mBillIntID_I", BillIntID_I);
                return obDBAccess.records();
            }
            catch { }
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("#", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mBillIntID_I", id);
                int result = obDBAccess.executeMyQuery();
                return result;
            }
            catch { } 
            throw new NotImplementedException();
        }
    }
}
