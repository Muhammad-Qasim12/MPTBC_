using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace MPTBCBussinessLayer.AcademicB
{
    public class WorkOrderDetails : ICommon
    {
        private Int32 _WorkorderID_I;
        private Int32 _TenderID_I;
        private string _WorkorderNo_V;
        private DateTime _WorkOrderDate_D;
        private string _PBGNo_V;
        private DateTime _PBGdate_D;
        private string _WorkorderFilePath_V;
        private int _isAgreement_I;
        private DateTime _ArgDate_D;
        private string _ArgNo_V;
        private Decimal _PrintSecurityAmount_N;
        private string _PrintSecurityDetail_V;
        private Decimal _PaperSecurityAmount_N;
        private string _PaperSecurityDetail_V;
        private string _JobCode_V;
        private Int32 _Printer_regid_i;
        private Int32 _Userid_I;
        private DateTime _Transdate_D;
        private Int32 _GRPID_I;
        private Int32 _WorkOrderDetID_I;
        private string _LOINo_V;
        private DateTime _LOIDate_D;
        private Int32 _LID;

        public Int32 WorkorderID_I { get { return _WorkorderID_I; } set { _WorkorderID_I = value; } }
        public Int32 TenderID_I { get { return _TenderID_I; } set { _TenderID_I = value; } }
        public string WorkorderNo_V { get { return _WorkorderNo_V; } set { _WorkorderNo_V = value; } }
        public DateTime WorkOrderDate_D { get { return _WorkOrderDate_D; } set { _WorkOrderDate_D = value; } }
        public string PBGNo_V { get { return _PBGNo_V; } set { _PBGNo_V = value; } }
        public DateTime PBGdate_D { get { return _PBGdate_D; } set { _PBGdate_D = value; } }
        public string WorkorderFilePath_V { get { return _WorkorderFilePath_V; } set { _WorkorderFilePath_V = value; } }
        public Int32 isAgreement_I { get { return _isAgreement_I; } set { _isAgreement_I = value; } }
        public DateTime ArgDate_D { get { return _ArgDate_D; } set { _ArgDate_D = value; } }
        public string ArgNo_V { get { return _ArgNo_V; } set { _ArgNo_V = value; } }
        public Decimal PrintSecurityAmount_N { get { return _PrintSecurityAmount_N; } set { _PrintSecurityAmount_N = value; } }
        public string PrintSecurityDetail_V { get { return _PrintSecurityDetail_V; } set { _PrintSecurityDetail_V = value; } }
        public Decimal PaperSecurityAmount_N { get { return _PaperSecurityAmount_N; } set { _PaperSecurityAmount_N = value; } }
        public string PaperSecurityDetail_V { get { return _PaperSecurityDetail_V; } set { _PaperSecurityDetail_V = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public Int32 Printer_regid_i { get { return _Printer_regid_i; } set { _Printer_regid_i = value; } }
        public Int32 Userid_I { get { return _Userid_I; } set { _Userid_I = value; } }
        public DateTime Transdate_D { get { return _Transdate_D; } set { _Transdate_D = value; } }
        public Int32 GRPID_I { get { return _GRPID_I; } set { _GRPID_I = value; } }
        public Int32 WorkOrderDetID_I { get { return _WorkOrderDetID_I; } set { _WorkOrderDetID_I = value; } }
        public string LOINo_V { get { return _LOINo_V; } set { _LOINo_V = value; } }
        public DateTime LOIDate_D { get { return _LOIDate_D; } set { _LOIDate_D = value; } }
        public Int32 LID { get { return _LID; } set { _LID = value; } }

        public string Finyear { get; set; }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            LID = 0;
            if (WorkorderID_I != 0)
            {
                LID = WorkorderID_I;
            }
            obDBAccess.execute("USP_ACB007_WorkOrderDetailsSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mTenderID_I", TenderID_I);
            obDBAccess.addParam("mWorkorderNo_V", WorkorderNo_V);
            obDBAccess.addParam("mWorkOrderDate_D", WorkOrderDate_D);
            obDBAccess.addParam("mPBGNo_V", PBGNo_V);
            obDBAccess.addParam("mPBGdate_D", PBGdate_D);
            obDBAccess.addParam("mWorkorderFilePath_V", WorkorderFilePath_V);
            obDBAccess.addParam("misAgreement_I", isAgreement_I);
            obDBAccess.addParam("mArgDate_D", ArgDate_D);
            obDBAccess.addParam("mArgNo_V", ArgNo_V);
            obDBAccess.addParam("mPrintSecurityAmount_N", PrintSecurityAmount_N);
            obDBAccess.addParam("mPrintSecurityDetail_V", PrintSecurityDetail_V);
            obDBAccess.addParam("mPaperSecurityAmount_N", PaperSecurityAmount_N);
            obDBAccess.addParam("mPaperSecurityDetail_V", PaperSecurityDetail_V);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mPrinter_regid_i", Printer_regid_i);
            obDBAccess.addParam("mUserid_I", Userid_I);
            obDBAccess.addParam("mTransdate_D", Transdate_D);
            obDBAccess.addParam("mLOINo_V", LOINo_V);
            obDBAccess.addParam("mLOIDate_D", LOIDate_D);
            obDBAccess.addParam("macyear", Finyear);

            obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32, DBAccess.SqlDirection.OUT);

            int result = obDBAccess.executeMyQuery();
            LID = Convert.ToInt32(obDBAccess.getParameter(20).ToString());
            return LID;
        }
        public int UpdateAgreement()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderAgreementSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mArgDate_D", ArgDate_D);
            obDBAccess.addParam("mArgNo_V", ArgNo_V);
            obDBAccess.addParam("mPrintSecurityAmount_N", PrintSecurityAmount_N);
            obDBAccess.addParam("mPrintSecurityDetail_V", PrintSecurityDetail_V);
            obDBAccess.addParam("mPaperSecurityAmount_N", PaperSecurityAmount_N);
            obDBAccess.addParam("mPaperSecurityDetail_V", PaperSecurityDetail_V);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            int i = obDBAccess.executeMyQuery();
            return i;
        }

        public DataSet JobCardNo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderAgreementSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", 0);
            obDBAccess.addParam("mArgDate_D", 0);
            obDBAccess.addParam("mArgNo_V", 0);
            obDBAccess.addParam("mPrintSecurityAmount_N", 0);
            obDBAccess.addParam("mPrintSecurityDetail_V", 0);
            obDBAccess.addParam("mPaperSecurityAmount_N", 0);
            obDBAccess.addParam("mPaperSecurityDetail_V", 0);
            obDBAccess.addParam("mJobCode_V", 0);
            return obDBAccess.records();
        }
        public DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDetailLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDetailsDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public DataSet PrinterAlldetails(int ID, int TenderID_I, int PrinterID_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDDLdetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mTenderID_I", TenderID_I);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            return obDBAccess.records();
        }

        public int InsertGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDetailDataSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkOrderDetID_I", WorkOrderDetID_I);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mGRPID_I", GRPID_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public DataSet ViewGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderGroupDetail", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            return obDBAccess.records();
        }
    }

}

