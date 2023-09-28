using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class InterDepoTransfer
    {


        private int _DepoTrno_I;
        private int _DemandingDepotID;
        private string _ReqNo;
        private int _SupplierDepoID;
        private int _DemandChildTrNo;
        private int _NetDemand;
        private int _NoOfBookTransferd;
        private string _ChallanNo;
        private int _TitleID_I;
        private int _IsScheme;
        private int _DemandTrNo;
        private DateTime _ChalanDate;

        public int DemandTrNo { get { return _DemandTrNo; } set { _DemandTrNo = value; } }
        public int IsScheme { get { return _IsScheme; } set { _IsScheme = value; } }
        public int DepoTrno_I { get { return _DepoTrno_I; } set { _DepoTrno_I = value; } }
        public int DemandingDepotID { get { return _DemandingDepotID; } set { _DemandingDepotID = value; } }
        public string ReqNo { get { return _ReqNo; } set { _ReqNo = value; } }
        public int SupplierDepoID { get { return _SupplierDepoID; } set { _SupplierDepoID = value; } }
        public int DemandChildTrNo { get { return _DemandChildTrNo; } set { _DemandChildTrNo = value; } }
        public int NetDemand { get { return _NetDemand; } set { _NetDemand = value; } }
        public int NoOfBookTransferd { get { return _NoOfBookTransferd; } set { _NoOfBookTransferd = value; } }
        public string ChallanNo { get { return _ChallanNo; } set { _ChallanNo = value; } }
        public int TitleID_I { get { return _TitleID_I; } set { _TitleID_I = value; } }
        public DateTime ChalanDate { get { return _ChalanDate; } set { _ChalanDate = value; } }
       
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO002_InterDepoTransferSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandChildTrNo", DemandChildTrNo);
            obDBAccess.addParam("mDemandingDepotID", DemandingDepotID);
            obDBAccess.addParam("mReqNo", ReqNo);
            obDBAccess.addParam("mNetDemand", NetDemand);
            obDBAccess.addParam("mSupplierDepoID", SupplierDepoID);
            obDBAccess.addParam("mNoOfBookTransferd", NoOfBookTransferd);
            obDBAccess.addParam("mChallanNo", ChallanNo);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mIsScheme", IsScheme);
            obDBAccess.addParam("mDemandTrNo", DemandTrNo);
            obDBAccess.addParam("mChalanDate", ChalanDate);
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet DepoFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", 0);
            obDBAccess.addParam("mDemandingDepotID", 0);
            obDBAccess.addParam("mReqNo", 0);
            obDBAccess.addParam("mSupplierDepoID", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet RequestedDepoFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", 0);
            obDBAccess.addParam("mDemandingDepotID", 0);
            obDBAccess.addParam("mReqNo", 0);
            obDBAccess.addParam("mSupplierDepoID", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet DemandFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", 0);
            obDBAccess.addParam("mDemandingDepotID", DemandingDepotID);
            obDBAccess.addParam("mReqNo", 0);
            obDBAccess.addParam("mSupplierDepoID", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet ChallanFillForPrint()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", 0);
            obDBAccess.addParam("mDemandingDepotID", 0);
            obDBAccess.addParam("mReqNo", 0);
            obDBAccess.addParam("mSupplierDepoID", 0);
            obDBAccess.addParam("mtype",3);
            return obDBAccess.records();
        }
        public System.Data.DataSet ChallanFillForPrintBYSuppl()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPO002_InterDepoTransferShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", 0);
            obDBAccess.addParam("mDemandingDepotID", 0);
            obDBAccess.addParam("mReqNo", 0);
            obDBAccess.addParam("mSupplierDepoID", SupplierDepoID);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();
        }
        //public System.Data.DataSet Select()
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR003_LabMasterLoadData", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mLabTrId_I", LabTrId_I);
        //    return obDBAccess.records();
        //}

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
