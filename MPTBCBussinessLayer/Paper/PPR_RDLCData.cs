using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Paper
{
    public class PPR_RDLCData
    {
        public System.Data.DataTable LabInsPectionDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", "");
            obDBAccess.addParam("mPaperVendorTrId_I", "");            
            obDBAccess.addParam("mtype", 0);

            return obDBAccess.records1();
        }

        public System.Data.DataSet GetMobileNoForSms(string type, string UserId)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_GetMobileNo", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mtype", type);
            obDBAccess.addParam("mUserId", UserId);            
            return obDBAccess.records();
        }
        public System.Data.DataTable LabInsPectionDetailsBYSample(string SampleNO)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", SampleNO);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records1();
        }
        public System.Data.DataTable LabInsPectionDetailsBYLOI(string LOINo_V, string SampleNO, int type)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsWithLOI", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOINo_V", LOINo_V);
            obDBAccess.addParam("mSampleNo",SampleNO);
            obDBAccess.addParam("mtype", type);
            return obDBAccess.records1();
        }
        public System.Data.DataTable YearlyDataShowOfStock()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", 0);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records1();
        }
        public System.Data.DataTable MonthPublishCoverAllotMent(string AcYear)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", AcYear);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 19);
            return obDBAccess.records1();
        }
        public System.Data.DataTable PublishCoverAllotMent(string AcYear)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", AcYear);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records1();
        }
        public System.Data.DataTable DailyStockRptCD(string AcYear)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0025_PaperTotStockWithYear", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAcYear", AcYear);
            return obDBAccess.records1();
        }
        public System.Data.DataTable LoiDetails(string LOINo, string FromDate, string ToDate)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_LoiReportsTwoDate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LOINo);
            obDBAccess.addParam("mFromDate", FromDate);
            obDBAccess.addParam("mToDate", ToDate);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records1();
        }
        public System.Data.DataTable VoucherDetails(string VoucherNo, string FromDate, string ToDate)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_LoiReportsTwoDate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", VoucherNo);
            obDBAccess.addParam("mFromDate", FromDate);
            obDBAccess.addParam("mToDate", ToDate);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records1();
        }
        public System.Data.DataTable DeliveryChallanDetails(string Challan)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", Challan);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 13);
            return obDBAccess.records1();
        }

        public System.Data.DataTable DeliveryChallanChildDetails(string Challan)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", Challan);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 14);
            return obDBAccess.records1();
        }


        public System.Data.DataTable WorkPlanDetails(string LoiId,string VendorName)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LoiId);
            obDBAccess.addParam("mPaperVendorTrId_I", VendorName);
            obDBAccess.addParam("mtype", 11);
            return obDBAccess.records1();
        }
        public System.Data.DataTable PGBReport(string LoiId, string VendorName)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LoiId);
            obDBAccess.addParam("mPaperVendorTrId_I", VendorName);
            obDBAccess.addParam("mtype", 21);
            return obDBAccess.records1();
        }
        public System.Data.DataTable PGBAllReport(string LoiId, string VendorName)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LoiId);
            obDBAccess.addParam("mPaperVendorTrId_I", VendorName);
            obDBAccess.addParam("mtype", 22);
            return obDBAccess.records1();
        }
        public System.Data.DataTable WorkPlanChildDetails(string LoiId)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LoiId);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 12);
            return obDBAccess.records1();
        }
        public System.Data.DataTable VoucherChildDetails(string AcYear)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", AcYear);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 9);
            return obDBAccess.records1();
        }
        public System.Data.DataTable VoucherAllFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", "");
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 10);
            return obDBAccess.records1();
        }
        public System.Data.DataTable TendorDetails(string TenderNo,string FromDate,string ToDate)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_LoiReportsTwoDate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", TenderNo);
            obDBAccess.addParam("mFromDate", FromDate);
            obDBAccess.addParam("mToDate", ToDate);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records1();
        }
        public System.Data.DataTable LoiNameFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", "");
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records1();
        }
        public System.Data.DataTable ExciseChallanFill(string PaperVendorTrId_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", "");
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mtype", 16);
            return obDBAccess.records1();
        }
        public System.Data.DataTable ExciseChallanDetails(string ChallaNo)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", ChallaNo);
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 15);
            return obDBAccess.records1();
        }
        public System.Data.DataTable TendorFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", "");
            obDBAccess.addParam("mPaperVendorTrId_I", "");
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records1();
        }
        public System.Data.DataTable PublishCoverAllotMent(string PaperVendorTrId_I, string LOITrId_I, string PaperType_I, string PaperMstrTrId_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0021_LabInspectionReportsDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            return obDBAccess.records1();
        }
        public System.Data.DataTable VendorDisptchFill(string PaperVendorTrId_I,string LOI)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LOI);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mtype", 17);
            return obDBAccess.records1();
        }
        public System.Data.DataTable VendorChildDisptchFill(string PaperVendorTrId_I, string LOI)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LOI);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mtype", 23);
            return obDBAccess.records1();
        }
        public System.Data.DataTable VendorChildDisptchFillPMill(string PaperVendorTrId_I, string LOI)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0020_LabInspectionReportsRDLC", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSampleNo", LOI);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mtype", 24);
            return obDBAccess.records1();
        }
        public System.Data.DataTable StockDetailsBetweenTwoDate(string name, string fromDate, string ToDate)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_StockReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mfromDate", fromDate);
            obDBAccess.addParam("mPrinter_Id", name);            
            obDBAccess.addParam("mToDate", ToDate);
            obDBAccess.addParam("mtype", 0);           
            return obDBAccess.records1();
        }
        public System.Data.DataTable PaperVendorStockDetailsBetweenTwoDate(string Name, string fromDate, string ToDate)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_StockReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mfromDate", fromDate);
            obDBAccess.addParam("mToDate", ToDate);
            obDBAccess.addParam("mPrinter_Id", Name);  
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records1();
        }
        public System.Data.DataTable StatusDeshBoard(string Session, int FlagId,int Type )
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_PaperDeshboard", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSession", Session);
            obDBAccess.addParam("mFlagId", FlagId);
            obDBAccess.addParam("mtype", Type);
            return obDBAccess.records1();
        }
      
        public System.Data.DataTable PrinterFillWithStk()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_StockReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mfromDate", "");
            obDBAccess.addParam("mToDate", "");
            obDBAccess.addParam("mPrinter_Id", "");
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records1();
        }
        public System.Data.DataTable PaperTypeWithStk()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0022_StockReport", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mfromDate", "");
            obDBAccess.addParam("mToDate", "");
            obDBAccess.addParam("mPrinter_Id", "");
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records1();
        }
    }
}
