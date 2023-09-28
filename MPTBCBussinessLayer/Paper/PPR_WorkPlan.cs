using System;
using System.Collections.Generic;
 
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_WorkPlan
    {
     
        private int _LOITrId_I;
        private int _WorkPlanTrId_I;       
        private int _PaperVendorTrId_I;
        private int _PaperType_I;
        private int _PaperQuality_I;
        private int _PaperMstrTrId_I;
        private int _UserId_I;
        private DateTime _SupplyDate_D, _StartDate;
        private DateTime _SupplyTillDate_D;
        private Decimal _TotAmount;
        private  Decimal _BitRate;
        private string _OrderNo;
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public int WorkPlanTrId_I { get { return _WorkPlanTrId_I; } set { _WorkPlanTrId_I = value; } }      
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
        public int PaperQuality_I { get { return _PaperQuality_I; } set { _PaperQuality_I = value; } }
        public int PaperMstrTrId_I { get { return _PaperMstrTrId_I; } set { _PaperMstrTrId_I = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public DateTime SupplyDate_D { get { return _SupplyDate_D; } set { _SupplyDate_D = value; } }
        public DateTime SupplyTillDate_D { get { return _SupplyTillDate_D; } set { _SupplyTillDate_D = value; } }
        public Decimal TotAmount { get { return _TotAmount; } set { _TotAmount = value; } }
        public Decimal BitRate { get { return _BitRate; } set { _BitRate = value; } }
        public DateTime StartDate { get { return _StartDate; } set { _StartDate = value; } }
        public string OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }
        

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkPlanTrId_I", WorkPlanTrId_I);
            obDBAccess.addParam("mLOIId_I", LOITrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperQuantity_N", PaperQuality_I);
            obDBAccess.addParam("mSupplyDate_D", SupplyDate_D);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mSupplyTillDate_D", SupplyTillDate_D);
            obDBAccess.addParam("mBidRate", BitRate);
            obDBAccess.addParam("mTotAmount", TotAmount);
            obDBAccess.addParam("mStartDate", StartDate);
            obDBAccess.addParam("OrderNoA", OrderNo);
            int result = obDBAccess.executeMyQuery();
            return result; 

        }

        public System.Data.DataSet Select()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records();

        }
        public System.Data.DataSet SearchWorkName(string PaperVendorName_V)
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorName_V", PaperVendorName_V);
         
            return obDBAccess.records();

        }
        public System.Data.DataSet VendorDataSelect()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 10);
            return obDBAccess.records();

        }
        public System.Data.DataSet VendorDataSearchName(string CoverInformation)
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanVndrSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mCoverInformation", CoverInformation);
            return obDBAccess.records();

        }
        public System.Data.DataSet VendorAgrSave(string Status)
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanAgrSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", LOITrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mstatus", Status);
            return obDBAccess.records();
       

        }
        public System.Data.DataSet FieldFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", WorkPlanTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 8);
            return obDBAccess.records();

        }
        public System.Data.DataSet AgreeMentPBGDetails()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", WorkPlanTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records();

        }
        public System.Data.DataSet GrWorkPlanFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records();

        }
        public System.Data.DataSet VenderFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();

        }
       
        public System.Data.DataSet LOINoFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();

        }
        public System.Data.DataSet LOINoDetailsFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperSizeFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperTypeFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 9);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperQultyFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();

        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR008_WorkPlanDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkPlanTrId_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;

        }
    }
}
