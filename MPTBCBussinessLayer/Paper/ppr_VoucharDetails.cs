using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Paper
{
    public class ppr_VoucharDetails
    {

        private int _Vouchar_Child_Id;
        private int _Vouchar_Tr_Id;
        private int _DisTranId;
        private int _DisDtl_Id;

        private string _VoucharNo;
        private int _Depot_Id;
        private DateTime _VoucharDate;
        private int _PaperVendorTrId_I;
        private int _LOITrId_I;
        private float _TotWt;
        private int _Status;
        private float _Rate;
        private int _UserId_I;
        private int _Vch_Trans_Id;

        private string _ChallanNo;
        private DateTime _ChallanDate;
        private DateTime _ReceivedDate;
        private string _GRNo;
        private DateTime _GRDate;
        private float _NoOfReel;
        private float _Weight;
        private decimal _Amount;
        private decimal _BillPer;
        private string _Remark;
        private decimal _WithHeldAmt;

        private decimal _Thabba;
        private decimal _NetWt;
        private decimal _NetWtPayment;
        private decimal _Payment10;
        private decimal _Payment90;
        private string _BankName;
        private string _ChequeNo;
        private DateTime _CqDate;

        private int _Vch_10Trans_Id;
        private int _Vouchar_90Tr_Id;
        private int _Vch_10Trans_Child_I;

        public int Vch_10Trans_Id { get { return _Vch_10Trans_Id; } set { _Vch_10Trans_Id = value; } }
        public int Vouchar_90Tr_Id { get { return _Vouchar_90Tr_Id; } set { _Vouchar_90Tr_Id = value; } }
        public int Vch_10Trans_Child_I { get { return _Vch_10Trans_Child_I; } set { _Vch_10Trans_Child_I = value; } }


        public decimal Thabba { get { return _Thabba; } set { _Thabba = value; } }
        public decimal NetWt { get { return _NetWt; } set { _NetWt = value; } }
        public decimal NetWtPayment { get { return _NetWtPayment; } set { _NetWtPayment = value; } }
        public decimal Payment10 { get { return _Payment10; } set { _Payment10 = value; } }
        public decimal Payment90 { get { return _Payment90; } set { _Payment90 = value; } }





        public float Rate { get { return _Rate; } set { _Rate = value; } }
        public float NoOfReel { get { return _NoOfReel; } set { _NoOfReel = value; } }
        public float Weight { get { return _Weight; } set { _Weight = value; } }


        public string Remark { get { return _Remark; } set { _Remark = value; } }
        public decimal WithHeldAmt { get { return _WithHeldAmt; } set { _WithHeldAmt = value; } }

        public decimal BillPer { get { return _BillPer; } set { _BillPer = value; } }
        public decimal Amount { get { return _Amount; } set { _Amount = value; } }
        public DateTime ChallanDate { get { return _ChallanDate; } set { _ChallanDate = value; } }
        public DateTime ReceivedDate { get { return _ReceivedDate; } set { _ReceivedDate = value; } }
        public DateTime GRDate { get { return _GRDate; } set { _GRDate = value; } }

        public string GRNo { get { return _GRNo; } set { _GRNo = value; } }
        public string ChallanNo { get { return _ChallanNo; } set { _ChallanNo = value; } }


        public int Vch_Trans_Id { get { return _Vch_Trans_Id; } set { _Vch_Trans_Id = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public int Vouchar_Child_Id { get { return _Vouchar_Child_Id; } set { _Vouchar_Child_Id = value; } }
        public int Vouchar_Tr_Id { get { return _Vouchar_Tr_Id; } set { _Vouchar_Tr_Id = value; } }
        public int DisTranId { get { return _DisTranId; } set { _DisTranId = value; } }
        public int DisDtl_Id { get { return _DisDtl_Id; } set { _DisDtl_Id = value; } }

        public string VoucharNo { get { return _VoucharNo; } set { _VoucharNo = value; } }
        public int Depot_Id { get { return _Depot_Id; } set { _Depot_Id = value; } }
        public DateTime VoucharDate { get { return _VoucharDate; } set { _VoucharDate = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public float TotWt { get { return _TotWt; } set { _TotWt = value; } }
        public int Status { get { return _Status; } set { _Status = value; } }

        public string BankName { get { return _BankName; } set { _BankName = value; } }
        public string ChequeNo { get { return _ChequeNo; } set { _ChequeNo = value; } }
        public DateTime CqDate { get { return _CqDate; } set { _CqDate = value; } }



        public DataSet InsertUpdate10Save()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVch_Trans_Id", Vch_Trans_Id);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mVoucharDate", VoucharDate);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mTotAmount", Amount);
            obDBAccess.addParam("mBillper", BillPer);
            obDBAccess.addParam("mRemark", Remark);
            obDBAccess.addParam("mWeight", Weight);
            obDBAccess.addParam("mBankName", BankName);
            obDBAccess.addParam("mCqDate", CqDate);
            obDBAccess.addParam("mChequeNo", ChequeNo);
            obDBAccess.addParam("mPercentage", Payment10);
            return obDBAccess.records();
        }
        public int InsertUpdate10ChildSave()
        { 
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerChildSave", DBAccess.SQLType.IS_PROC); 
            obDBAccess.addParam("mVch_10Trans_Id", Vch_10Trans_Id);
            obDBAccess.addParam("mVouchar_90Tr_Id", Vouchar_90Tr_Id);
            obDBAccess.addParam("mVch_10Trans_Child_I", 0);
            obDBAccess.addParam("mVouchar90No", VoucharNo);
            obDBAccess.addParam("mtype", 0);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int InsertUpdate10ChildDelete()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerChildSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVch_10Trans_Id", Vch_10Trans_Id);
            obDBAccess.addParam("mVouchar_90Tr_Id", 0);
            obDBAccess.addParam("mVch_10Trans_Child_I", 0);
            obDBAccess.addParam("mVouchar90No", "");
            obDBAccess.addParam("mtype", 1);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet AutoGenSampleNoForAccountVoucher()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 8);
            return obDBAccess.records();
        }

        public int InsertUpdateThabbaSave()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_VoucharThabbaSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVch_Trans_Id", Vch_Trans_Id);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mVoucharDate", VoucharDate);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mTotAmount", Amount);
            obDBAccess.addParam("mRemark", Remark);
            obDBAccess.addParam("mWeight", Weight);
            obDBAccess.addParam("mBankName", BankName);
            obDBAccess.addParam("mCqDate", CqDate);
            obDBAccess.addParam("mChequeNo", ChequeNo);
            obDBAccess.addParam("mThabbaWt", Thabba);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataSaveMaster", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            obDBAccess.addParam("mDepot_Id", Depot_Id);
            obDBAccess.addParam("mVoucharDate", VoucharDate);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mRate", Rate);
            obDBAccess.addParam("mStatus", 0);
            obDBAccess.addParam("mTotWt", TotWt);
            obDBAccess.addParam("mThabba", Thabba);
            obDBAccess.addParam("mNetWt", NetWt);
            obDBAccess.addParam("mNetWtPayment", NetWtPayment);
            obDBAccess.addParam("mPayment10", Payment10);
            obDBAccess.addParam("mPayment90", Payment90);
            obDBAccess.addParam("mBankName", BankName);
            obDBAccess.addParam("mCqDate", CqDate);
            obDBAccess.addParam("mChequeNo", ChequeNo);
            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;
        }

        public int ChildInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataChildSaveMaster", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVouchar_Child_Id", Vouchar_Child_Id);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            obDBAccess.addParam("mChallanDate", ChallanDate);
            obDBAccess.addParam("mReceivedDate", ReceivedDate);
            obDBAccess.addParam("mGRNo", GRNo);
            obDBAccess.addParam("mGRDate", GRDate);
            obDBAccess.addParam("mNoOfReel", NoOfReel);
            obDBAccess.addParam("mWeight", Weight);
            obDBAccess.addParam("mAmount", Amount);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Per10AutoGenSampleNo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet ThabbaAutoGenSampleNo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records();
        }
        public System.Data.DataTable PerVoucharReport10(int PaperVendorTrId_I, int LOITrId_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records1();
        }
        public System.Data.DataTable PerVoucharAllReport10(int PaperVendorTrId_I, int LOITrId_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records1();
        }
        public System.Data.DataSet AutoGenSampleNo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records();
        }
        public System.Data.DataSet Vouchar90DtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet Vouchar2DtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 9);
            return obDBAccess.records();
        }
        public System.Data.DataSet ThabbaVoucharDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 6);
            return obDBAccess.records();
        }
        public System.Data.DataSet ShowAll90Data()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet FiledFill2()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mtype", 10);
            return obDBAccess.records();
        }
        public System.Data.DataSet FiledFill90()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet ThabbaFiledFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10PerDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mtype", 8);
            return obDBAccess.records();
        }
        //public System.Data.DataSet Select()
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterLoadData", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", LabTrId_I);
        //    return obDBAccess.records();
        //}
        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet LOINoFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet UpdateVoucharStatus()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records();
        }
        public System.Data.DataSet ChallanFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet ShowAllData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet VoucherSearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            return obDBAccess.records();
        }
        public System.Data.DataSet Voucher10SearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar10SearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            return obDBAccess.records();
        }
        public System.Data.DataSet Voucher2SearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_Vouchar2SearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            return obDBAccess.records();
        }
        public System.Data.DataSet VoucherThabbaSearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_ThabbaVoucharSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mVoucharNo", VoucharNo);
            return obDBAccess.records();
        }
        public System.Data.DataSet FiledFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0018_VoucharDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mDisDtl_Id", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mVouchar_Tr_Id", Vouchar_Tr_Id);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();
        }


        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterDelete", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", id);

        //    int result = obDBAccess.executeMyQuery();
        //    return result;
        //}
    }
}
