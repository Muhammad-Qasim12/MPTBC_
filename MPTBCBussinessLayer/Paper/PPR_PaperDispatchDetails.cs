using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Paper
{
    public class PPR_PaperDispatchDetails
    {

        private int _LOITrId_I;
        private int _DisDtl_Id;
        private int _PaperVendorTrId_I;
        private int _PaperType_I;
        private int _PaperQuality_I;
        private int _PaperMstrTrId_I;
        private int _UserId_I;
        private DateTime _ReceivedDate;
        private DateTime _ChallanDate;
        private int _DisTranId;
        private float _ReceivedQty;
        private string _ChallanNo;
        private string _AcYear;
        private float _ReqQty;
        private float _VdrSendQty;
        private string _TruckNo;
        private string _DriverName;
        private string _MobileNo;
        private string _GRNo;
        private DateTime _GRDate,_mdate;
        private float _NoOfReels;
        private float _SndrReel;
        private float _DefReel;
        private float _DefWt;
        private string _OrderNo;
        private int _DepoID_I;
        private int _PrinterID_I;
        private int _PrinterDisTranId;
        private string _BlockNo;
        private int _WareHouseID_I,_mtype;
        private int _PrinterDisDtl_Id;
        private float _SendQty;
        private string _DemandFrom;
        private string _Remark;
        private decimal _NetWt;
        private string _GSRPageNo;
        private string _GSRSrNo;
        private string _TransporterName;
        

        public string GSRPageNo { get { return _GSRPageNo; } set { _GSRPageNo = value; } }
        public string GSRSrNo { get { return _GSRSrNo; } set { _GSRSrNo = value; } }
        public string TransporterName { get { return _TransporterName; } set { _TransporterName = value; } }

        public decimal NetWt { get { return _NetWt; } set { _NetWt = value; } }
        public float SendQty { get { return _SendQty; } set { _SendQty = value; } }
        public int PrinterDisDtl_Id { get { return _PrinterDisDtl_Id; } set { _PrinterDisDtl_Id = value; } }
        public int PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public int PrinterDisTranId { get { return _PrinterDisTranId; } set { _PrinterDisTranId = value; } }

        public string BlockNo { get { return _BlockNo; } set { _BlockNo = value; } }
        public int WareHouseID_I { get { return _WareHouseID_I; } set { _WareHouseID_I = value; } }

        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
     //   public int mtype { get { return _mtype; } set { _mtype = value; } }
        
        public float DefReel { get { return _DefReel; } set { _DefReel = value; } }
        public float DefWt { get { return _DefWt; } set { _DefWt = value; } }
        public string OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }


        public float SndrReel { get { return _SndrReel; } set { _SndrReel = value; } }
        public float NoOfReels { get { return _NoOfReels; } set { _NoOfReels = value; } }

        public string GRNo { get { return _GRNo; } set { _GRNo = value; } }
        public DateTime GRDate { get { return _GRDate; } set { _GRDate = value; } }
        public DateTime mdate { get { return _mdate; } set { _mdate = value; } }

        public float ReqQty { get { return _ReqQty; } set { _ReqQty = value; } }
        public string TruckNo { get { return _TruckNo; } set { _TruckNo = value; } }
        public string DriverName { get { return _DriverName; } set { _DriverName = value; } }
        public string MobileNo { get { return _MobileNo; } set { _MobileNo = value; } }
        public string DemandFrom { get { return _DemandFrom; } set { _DemandFrom = value; } }

        public string Remark { get { return _Remark; } set { _Remark = value; } }
        public float VdrSendQty { get { return _VdrSendQty; } set { _VdrSendQty = value; } }
        public int DisTranId { get { return _DisTranId; } set { _DisTranId = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public int DisDtl_Id { get { return _DisDtl_Id; } set { _DisDtl_Id = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
        public int PaperQuality_I { get { return _PaperQuality_I; } set { _PaperQuality_I = value; } }
        public int mtype { get { return _mtype; } set { _mtype = value; } }
        public int PaperMstrTrId_I { get { return _PaperMstrTrId_I; } set { _PaperMstrTrId_I = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public DateTime ReceivedDate { get { return _ReceivedDate; } set { _ReceivedDate = value; } }
        public DateTime ChallanDate { get { return _ChallanDate; } set { _ChallanDate = value; } }
        public string ChallanNo { get { return _ChallanNo; } set { _ChallanNo = value; } }
        public string AcYear { get { return _AcYear; } set { _AcYear = value; } }
        public float ReceivedQty { get { return _ReceivedQty; } set { _ReceivedQty = value; } }


        public DataSet InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            obDBAccess.addParam("mChallanDate", ChallanDate);
            obDBAccess.addParam("mReceivedDate", ReceivedDate);
            obDBAccess.addParam("mUserId", UserId_I);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mMobileNo", MobileNo);
            obDBAccess.addParam("mTruckNo", TruckNo);
            obDBAccess.addParam("mDriverName", DriverName);
            obDBAccess.addParam("mGRNo", GRNo);
            obDBAccess.addParam("mGRDate", GRDate);
            obDBAccess.addParam("mOrderNo", OrderNo);


            return obDBAccess.records();
        }
        public DataSet PrinterDispInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperPrinterDispatchSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterDisTranId", PrinterDisTranId);
            obDBAccess.addParam("mPrinter_RedID_I", PrinterID_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            obDBAccess.addParam("mChallanDate", ChallanDate);
            obDBAccess.addParam("mUserId", UserId_I);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mMobileNo", MobileNo);
            obDBAccess.addParam("mTruckNo", TruckNo);
            obDBAccess.addParam("mDriverName", DriverName);
            obDBAccess.addParam("mGRNo", GRNo);
            obDBAccess.addParam("mGRDate", GRDate);
            obDBAccess.addParam("mOrderNo", OrderNo);
            obDBAccess.addParam("mWareHouseID_I", WareHouseID_I);
            obDBAccess.addParam("mBlockNo", BlockNo);
            obDBAccess.addParam("mDemandFrom", DemandFrom);
            obDBAccess.addParam("mRemark", Remark);
            return obDBAccess.records();
        }

        public int InsertUpdateData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            obDBAccess.addParam("mChallanDate", ChallanDate);
            obDBAccess.addParam("mReceivedDate", ReceivedDate);
            obDBAccess.addParam("mUserId", UserId_I);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mMobileNo", MobileNo);
            obDBAccess.addParam("mTruckNo", TruckNo);
            obDBAccess.addParam("mDriverName", DriverName);
            obDBAccess.addParam("mGRNo", GRNo);
            obDBAccess.addParam("mGRDate", GRDate);
            obDBAccess.addParam("mOrderNo", OrderNo);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int ChildInsert()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchChildSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDisDtl_Id", DisDtl_Id);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mVdrSendQty", VdrSendQty);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mReqQty", ReqQty);
            obDBAccess.addParam("mSndrReel", SndrReel);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int DepotChallanChildInsert()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0016_CenterDepotChallanUpdate", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDisDtl_Id", DisDtl_Id);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mReqQty", ReqQty);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mReceivedDate", ReceivedDate);
            obDBAccess.addParam("mGRDate", GRDate);
            obDBAccess.addParam("mGRNo", GRNo);
            obDBAccess.addParam("mNoOfReels", NoOfReels);
            obDBAccess.addParam("mDefReel", DefReel);
            obDBAccess.addParam("mDefWt", DefWt);
            obDBAccess.addParam("nAcYear", AcYear);
            obDBAccess.addParam("mWareHouseID_I", WareHouseID_I);
            obDBAccess.addParam("mBlockNo", BlockNo);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);

            
            obDBAccess.addParam("mGSRPageNo", GSRPageNo);
            obDBAccess.addParam("mGSRSrNo", GSRSrNo);
            obDBAccess.addParam("mTransporterName", TransporterName);
            obDBAccess.addParam("mRemark", Remark);


            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public int DepotPrinterDispChallanChildInsert()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchPrinterChildSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterDisDtl_Id", PrinterDisDtl_Id);
            obDBAccess.addParam("mPrinterDisTranId", PrinterDisTranId);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mSendQty", SendQty);
            obDBAccess.addParam("mNoOfReels", NoOfReels);
            obDBAccess.addParam("mPrinter_RedID_I", PrinterID_I);
            obDBAccess.addParam("mBlockNo", BlockNo);
            obDBAccess.addParam("mWareHouseID_I", WareHouseID_I);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mUser_Id", UserId_I);
            obDBAccess.addParam("mReqQty", ReqQty);
            obDBAccess.addParam("mDemandFrom", DemandFrom);
            obDBAccess.addParam("mNetWt", NetWt);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
             
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet ShowAllData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records();
        }

        public System.Data.DataSet SearchName(string ChallanNo)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mChallanNo", ChallanNo);
   
            return obDBAccess.records();
        }

        public System.Data.DataSet WareHouseFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0021_PaperWareHouseName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoID_I", DepoID_I);

            return obDBAccess.records();
        }
      
        public System.Data.DataSet CentralDepoShowAllData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 10);
            return obDBAccess.records();
        }
    
        public System.Data.DataSet CenterDpotSearchName(string ChallanNo)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchCDSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            return obDBAccess.records();
        }
        public System.Data.DataSet VendorShowAllData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 8);
            return obDBAccess.records();
        }
        public System.Data.DataSet WorkQtyData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 11);
            return obDBAccess.records();

        }
        public System.Data.DataSet PrinterFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", 0);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();

        }
        public System.Data.DataSet AcdmicPrinterFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", 0);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records();

        }
        public System.Data.DataSet PrinterDispDetailsFromDepot()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", 0);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();

        }
        public System.Data.DataSet CDSearchNameChallan(string ChallanNo)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterCDSearch", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            return obDBAccess.records();

        }
        public System.Data.DataSet PrinterOrderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", OrderNo);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();

        }
        public System.Data.DataSet AcdminPrinterOrderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", OrderNo);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records();

        }
        public System.Data.DataSet LOINoFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();

        }
        public System.Data.DataSet OrderNoFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 1);

            return obDBAccess.records();

        }
        public System.Data.DataSet AcdminOrderNoFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mPaperAltID_I", 0);
            obDBAccess.addParam("mOrderNo", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 6);

            return obDBAccess.records();

        }
        public System.Data.DataSet PrinterDisptchDetails()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchToPrinterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterID_I", 0);
            obDBAccess.addParam("mPaperAltID_I", PrinterDisTranId);
            obDBAccess.addParam("mOrderNo", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperTypeFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperSizeFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();

        }
        public System.Data.DataSet QtyFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();

        }
        public System.Data.DataSet DetailsFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0014_PaperDispatchShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records();

        }
        
        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR008_WorkPlanDelete", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mWorkPlanTrId_I", id);
        //    int result = obDBAccess.executeMyQuery();
        //    return result;

        //}
        public System.Data.DataSet DASHBOARD_SUMMARY(string acyear,DateTime  mdate,int mtype )
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DASHBOARD_SUMMARY", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAcyear", acyear);
            obDBAccess.addParam("mdate", mdate);
            obDBAccess.addParam("mtype", mtype);
            return obDBAccess.records();

        }
        public System.Data.DataSet DASHBOARD_SUMMARY1(string acyear)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("DistributionSummaryDepotwise", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAcyear", acyear);
            return obDBAccess.records();

        }
         public DataSet GetChallanDetailFromDepo()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI004_printerChallanManagement", DBAccess.SQLType.IS_PROC);


            obj.addParam("mtype", mtype);
             obj.addParam("mdate", mdate);
            ds = obj.records();
            return ds;
        } 
    }
}
