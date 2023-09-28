using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class PRI_PaperAllotment
    {
        private int _Id;
        private int _Printer_RedID_I;

        private int _PaperAltID_I;
        private string _AcadmicYR_V;
        private string _PaperSize_V;
        private string _PaperCategory_V;
        private string _PaperGSM_V;
        private double _PaperQty_N;
        private int _PrinterID_I;
        private int _PaperOpt_I;
        private int _Status;
        private string _JobCode_V;
        private DateTime _Supplydate_D;
        private string _OrderNo;
        private int _pprAlltChild_id;
        private decimal _TotalSheets;
        public int Id { get { return _Id; } set { _Id = value; } }
        
        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
         public int pprAlltChild_id { get { return _pprAlltChild_id; } set { _pprAlltChild_id = value; } }

        public decimal TotalSheets{get{return _TotalSheets;} set{_TotalSheets=value;}}
        public int PaperAltID_I { get { return _PaperAltID_I; } set { _PaperAltID_I = value; } }
        public string AcadmicYR_V { get { return _AcadmicYR_V; } set { _AcadmicYR_V = value; } }
        public string PaperSize_V { get { return _PaperSize_V; } set { _PaperSize_V = value; } }
        public string PaperCategory_V { get { return _PaperCategory_V; } set { _PaperCategory_V = value; } }
        public string PaperGSM_V { get { return _PaperGSM_V; } set { _PaperGSM_V = value; } }
        public double PaperQty_N { get { return _PaperQty_N; } set { _PaperQty_N = value; } }
        public int PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public int PaperOpt_I { get { return _PaperOpt_I; } set { _PaperOpt_I = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public DateTime Supplydate_D { get { return _Supplydate_D; } set { _Supplydate_D = value; } }
        public string OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }
        
        public DataSet InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI006_PaperAllotmentSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
            obDBAccess.addParam("mAcadmicYR_V", AcadmicYR_V);
            obDBAccess.addParam("mPaperSize_V", PaperSize_V);
            obDBAccess.addParam("mPaperCategory_V", PaperCategory_V);
            obDBAccess.addParam("mPaperGSM_V", PaperGSM_V);
            obDBAccess.addParam("mPaperQty_N", PaperQty_N);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mPaperOpt_I", PaperOpt_I);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mSupplydate_D", Supplydate_D);
            obDBAccess.addParam("mOrderNo", OrderNo);

            return obDBAccess.records();

            throw new NotImplementedException();
        }
        public int ChildInsert()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI006_PaperAllotmentChildSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
            obDBAccess.addParam("mpprAlltChild_id", 0);
            obDBAccess.addParam("mPaperType_I", PaperOpt_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperCategory_V);
            obDBAccess.addParam("mPaperQty_N", PaperQty_N);
            obDBAccess.addParam("mTotSheets", TotalSheets);              
            obDBAccess.addParam("mtype", 0);
            int result = obDBAccess.executeMyQuery();
            return result;

            throw new NotImplementedException();
        }
        public int ChildUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI006_PaperAllotmentChildSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
            obDBAccess.addParam("mpprAlltChild_id", pprAlltChild_id);
            obDBAccess.addParam("mPaperType_I", PaperOpt_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperCategory_V);
            obDBAccess.addParam("mPaperQty_N", PaperQty_N);
            obDBAccess.addParam("mTotSheets", TotalSheets);  
            obDBAccess.addParam("mtype", 1);

            int result = obDBAccess.executeMyQuery();
            return result;

            throw new NotImplementedException();
        }
        public DataSet OrderNoExistPrinter()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI002_OrderNoCheck", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOrderNo_I", OrderNo);
            return obDBAccess.records();
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

        public System.Data.DataSet SelectSearch()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI006_PaperAllotmentLoadSearch", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPrinterName", JobCode_V);
                return obDBAccess.records();
            }
            catch { }

            throw new NotImplementedException();
        }

        public DataSet SelectddlPrinterName()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI004_PrinterRegistrationload", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
                return obDBAccess.records();
            }
            catch { }

            throw new NotImplementedException();
        }


        public DataSet GetPrinterPaperSupply()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_Pri006_PrintingCoverpaperSupplytoPrinter", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("acdyr",AcadmicYR_V);
                obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
                return obDBAccess.records();
            }
            catch { }

            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI006_PaperAllotmentDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public DataSet SelectddlAcadmicYear()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_ADM015_AcadmicYearLoad", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mId", Id);
                return obDBAccess.records();
            }
            catch { }
            throw new NotImplementedException();
        }


        public DataSet SelectddlJobCode()
        {
            try
            {
                DBAccess obDBAccess = new DBAccess();
                obDBAccess.execute("USP_PRI006_PaperAllotmentJobCode", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mId", Id);
                return obDBAccess.records();
            }
            catch { }
            throw new NotImplementedException();
        }


        public System.Data.DataSet UpdateStatus(int PaperAltID_I,int Status)
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI006_PaperAllotmentStatusSave", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
                obDBAccess.addParam("mStatus", Status);

            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();
        }

    }
}
