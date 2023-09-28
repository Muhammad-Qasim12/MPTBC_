using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.AcademicB
{
    public class ACB_PaperAllotmentDetails  
    {
        private Int32 _PaperAltID_I;
        private string _AcadmicYR_V;
        private Int32 _PrinterID_I;
        private Int32 _PaperTypeId_I;
        private Int32 _PaperTrId_I;
        private Int32 _WorkOrderId_I;
        private DateTime _Supplydate_D;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;
        private Int32 _PaperQty_I;
        private Int32 _OrderNo_I;
        private string _AllotStatus;
        private double _PaperQuantity_N;
        private decimal _TotalSheets;
        private Int32 _pprAlltChild_id;

        public decimal TotalSheets { get { return _TotalSheets; } set { _TotalSheets = value; } }
        public double PaperQuantity_N { get { return _PaperQuantity_N; } set { _PaperQuantity_N = value; } }

        public Int32 pprAlltChild_id { get { return _pprAlltChild_id; } set { _pprAlltChild_id = value; } }
        public Int32 PaperAltID_I { get { return _PaperAltID_I; } set { _PaperAltID_I = value; } }
        public string AcadmicYR_V { get { return _AcadmicYR_V; } set { _AcadmicYR_V = value; } }
        public Int32 PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public Int32 PaperTypeId_I { get { return _PaperTypeId_I; } set { _PaperTypeId_I = value; } }
        public Int32 PaperTrId_I { get { return _PaperTrId_I; } set { _PaperTrId_I = value; } }
        public Int32 WorkOrderId_I { get { return _WorkOrderId_I; } set { _WorkOrderId_I = value; } }
        public DateTime Supplydate_D { get { return _Supplydate_D; } set { _Supplydate_D = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public Int32 PaperQty_I { get { return _PaperQty_I; } set { _PaperQty_I = value; } }
        public Int32 OrderNo_I { get { return _OrderNo_I; } set { _OrderNo_I = value; } }
        public string AllotStatus { get { return _AllotStatus; } set { _AllotStatus = value; } }


        public DataSet InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_PaperAllotmentDetailsSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
            obDBAccess.addParam("mAcadmicYR_V", AcadmicYR_V);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mPaperTypeId_I", PaperTypeId_I);
            obDBAccess.addParam("mPaperTrId_I", PaperTrId_I);
            obDBAccess.addParam("mWorkOrderId_I", WorkOrderId_I);
            obDBAccess.addParam("mSupplydate_D", Supplydate_D);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);
            obDBAccess.addParam("mPaperQty_I", PaperQty_I);
            obDBAccess.addParam("mOrderNo_I", OrderNo_I);
            obDBAccess.addParam("mAllotStatus", AllotStatus);
            return obDBAccess.records();
        }
        public int ChildInsert()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_PaperAllotmentChildSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
            obDBAccess.addParam("mpprAlltChild_id", pprAlltChild_id);
            obDBAccess.addParam("mPaperType_I", PaperTypeId_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperTrId_I);
            obDBAccess.addParam("mPaperQty_N", PaperQuantity_N);
            obDBAccess.addParam("mTotSheets", TotalSheets);
            obDBAccess.addParam("mtype", 0);
            int result = obDBAccess.executeMyQuery();
            return result;

            throw new NotImplementedException();
        }
        public DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_PaperAllotmentDetailsLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", PaperAltID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PRI006_PaperAllotmentDeleteABC", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mPaperAltID_I", id);
        //    int result = obDBAccess.executeMyQuery();
        //    return result;
        //    throw new NotImplementedException();
        //}
        public DataSet OrderNoExist()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_CheckOrderNoExist", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOrderNo_I", OrderNo_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public DataSet SelectddlJobCode()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_FillJobCode", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinter_regid_i", PrinterID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB010_PaprAllotmentDetailsDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperAltID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public DataSet Fillddl(int PaperType_ID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI009_Fillddl", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperType_ID", PaperType_ID);
            return obDBAccess.records();
        }

        // function to load Class
        public DataSet FillClass()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM014_ClassMaster_Load", DBAccess.SQLType.IS_PROC);
            //obDBAccess.addParam("id", ClassTrno_I);
            return obDBAccess.records();
        }

    }
}

