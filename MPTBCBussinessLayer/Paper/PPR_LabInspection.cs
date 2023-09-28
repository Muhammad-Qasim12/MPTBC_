using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_LabInspection
    {
        private int _LabInspectionTrId_I;
        private int _LabTrId_I;
        private int _PaperVendorTrId_I;
        private int _LOITrId_I;
        private DateTime _SampleSendDate_D;
        private DateTime _SampleReceiveDate_D;
        private int _PaperMstrTrId_I;
        private int _PaperType_I;
        private string _LabInspectionReport_V;
        private string _Remark_V;
        private int _QualityCheckStatus_I;
        private string _LabInspectionFile_V;
        private int _UserId_I;
        private int _LabInspChild_Id_I;
        private string _ReportNo;
        private DateTime _ReportDate;
        private DateTime _PprCntrDptDrawDate;
        private string _SampleNo;
        private string _SampleFrom;
        public string SampleNo { get { return _SampleNo; } set { _SampleNo = value; } }
        public DateTime PprCntrDptDrawDate { get { return _PprCntrDptDrawDate; } set { _PprCntrDptDrawDate = value; } }

        public string SampleFrom { get { return _SampleFrom; } set { _SampleFrom = value; } }
        public string ReportNo { get { return _ReportNo; } set { _ReportNo = value; } }
        public DateTime ReportDate { get { return _ReportDate; } set { _ReportDate = value; } }

        public int LabInspChild_Id_I { get { return _LabInspChild_Id_I; } set { _LabInspChild_Id_I = value; } }
        public int LabInspectionTrId_I { get { return _LabInspectionTrId_I; } set { _LabInspectionTrId_I = value; } }
        public int LabTrId_I { get { return _LabTrId_I; } set { _LabTrId_I = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public DateTime SampleSendDate_D { get { return _SampleSendDate_D; } set { _SampleSendDate_D = value; } }
        public DateTime SampleReceiveDate_D { get { return _SampleReceiveDate_D; } set { _SampleReceiveDate_D = value; } }
        public int PaperMstrTrId_I { get { return _PaperMstrTrId_I; } set { _PaperMstrTrId_I = value; } }
        public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
        public string LabInspectionReport_V { get { return _LabInspectionReport_V; } set { _LabInspectionReport_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int QualityCheckStatus_I { get { return _QualityCheckStatus_I; } set { _QualityCheckStatus_I = value; } }
        public string LabInspectionFile_V { get { return _LabInspectionFile_V; } set { _LabInspectionFile_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", LabInspectionTrId_I);
            obDBAccess.addParam("mLabTrId_I", LabTrId_I);
            obDBAccess.addParam("mLabInspChild_Id_I", LabInspChild_Id_I);
            obDBAccess.addParam("mSampleSendDate_D", SampleSendDate_D);
            obDBAccess.addParam("mSampleReceiveDate_D", SampleReceiveDate_D);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mLabInspectionReport_V", LabInspectionReport_V);
            obDBAccess.addParam("mQualityCheckStatus_I", QualityCheckStatus_I);
            obDBAccess.addParam("mLabInspectionFile_V", LabInspectionFile_V);
            obDBAccess.addParam("mReportNo", ReportNo);
            obDBAccess.addParam("mReportDate", ReportDate);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int MasterInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionMasterSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", LabInspectionTrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mPprCntrDptDrawDate", PprCntrDptDrawDate);
            obDBAccess.addParam("mSampleNo", SampleNo);
            obDBAccess.addParam("mSampleFrom", SampleFrom);
            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;
        }
        
        public System.Data.DataSet LabFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet LabAddressFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", LabTrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet LoiFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 8);
            return obDBAccess.records();
        }
        public System.Data.DataSet VendorFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet AutoGenSampleNo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 9);
            return obDBAccess.records();
        }
        public System.Data.DataSet PaperTypeFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 12);//10
            return obDBAccess.records();
        }
        public System.Data.DataSet PaperTypeRDLCFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 10);
            return obDBAccess.records();
        }
        public System.Data.DataSet PaperSizeFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mtype", 13);//5
            return obDBAccess.records();
        }
        public System.Data.DataSet SampleNoFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 11);
            return obDBAccess.records();
        }
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records();
        }
        public System.Data.DataSet LabInspectionSearchName(string PaperVendorName_V)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorName_V", PaperVendorName_V);
            return obDBAccess.records();
        }
        public System.Data.DataSet FiledFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDetailsData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", LabInspectionTrId_I);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0010_LabInspectionDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspectionTrId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
