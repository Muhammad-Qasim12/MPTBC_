using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Paper
{
    public class ppr_DeliveryChallan
    {

        private int _PaperType_I;
        private int _PaperMstrTrId_I;
        private int _PaperVendorTrId_I;

        private int _DisTranId;
        private int _Delivery_Id;
        private int _Delivery_Child_Id;

        private string _ChallanNo;
        private string _RollNo;
        private float _NetWt;
        private float _GrossWt;

        public int Delivery_Id { get { return _Delivery_Id; } set { _Delivery_Id = value; } }
        public int Delivery_Child_Id { get { return _Delivery_Child_Id; } set { _Delivery_Child_Id = value; } }

        public int DisTranId { get { return _DisTranId; } set { _DisTranId = value; } }
        public int PaperVendorTrId_I { get { return _PaperVendorTrId_I; } set { _PaperVendorTrId_I = value; } }
        public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
        public int PaperMstrTrId_I { get { return _PaperMstrTrId_I; } set { _PaperMstrTrId_I = value; } }

        public float NetWt { get { return _NetWt; } set { _NetWt = value; } }
        public float GrossWt { get { return _GrossWt; } set { _GrossWt = value; } }
        public string ChallanNo { get { return _ChallanNo; } set { _ChallanNo = value; } }
        public string RollNo { get { return _RollNo; } set { _RollNo = value; } }



        public DataSet InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDelivery_Id", Delivery_Id);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            return obDBAccess.records();
        }

        public int ChildInsert()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelChildSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDelivery_Child_Id", Delivery_Child_Id);
            obDBAccess.addParam("mDelivery_Id", Delivery_Id);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mRollNo", RollNo);
            obDBAccess.addParam("mNetWt", NetWt);
            obDBAccess.addParam("mGrossWt", GrossWt);
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        public System.Data.DataSet SearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mChallanNo",ChallanNo);
            return obDBAccess.records();
        }

        public System.Data.DataSet ShowAllData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype",0);
            return obDBAccess.records();
        }
        public System.Data.DataSet CheckDataAlreadyEntry()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 7);
            return obDBAccess.records();
        }
    
        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);        
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();

        }
        public System.Data.DataSet ChallanFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();

        }
        public System.Data.DataSet ReportChallanFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 8);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperTypeFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();

        }
        public System.Data.DataSet PaperSizeFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", PaperVendorTrId_I);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();

        }
        public System.Data.DataSet ReelQtyFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDelivery_Id", 0);
            obDBAccess.addParam("mDisTranId", DisTranId);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 5);
            return obDBAccess.records();

        }
        public System.Data.DataSet DetailsFill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0019_PaperDeliveryReelShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperVendorTrId_I", 0);
            obDBAccess.addParam("mDelivery_Id", Delivery_Id);
            obDBAccess.addParam("mDisTranId", 0);
            obDBAccess.addParam("mPaperType_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mDelivery_Child_Id", 0);
            obDBAccess.addParam("mtype", 6);
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
    }
}
