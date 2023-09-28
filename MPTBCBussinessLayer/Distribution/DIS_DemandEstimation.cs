using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPTBCBussinessLayer
{
    public class DIS_DemandEstimation
    {
        private string _AcYear;
        private int _DepotID;
        private int _TitleId;
        private int _MediumId;
        private int _UserID;
        private int _OpnMktDemand;
        private int _SchemeDemand;
        private int _StockOpenMkt;
        private int _NetSchemeDemand;
        private int _NetOpenMkt;
        private int _StockYojna;
        private int _DemandType;

        public string AcYear { get { return _AcYear; } set { _AcYear = value; } }
        public int DepotID { get { return _DepotID; } set { _DepotID = value; } }
        public int TitleId { get { return _TitleId; } set { _TitleId = value; } }
        public int OpnMktDemand { get { return _OpnMktDemand; } set { _OpnMktDemand = value; } }
        public int SchemeDemand { get { return _SchemeDemand; } set { _SchemeDemand = value; } }
        public int StockOpenMkt { get { return _StockOpenMkt; } set { _StockOpenMkt = value; } }
        public int NetOpenMkt { get { return _NetOpenMkt; } set { _NetOpenMkt = value; } }
        public int NetSchemeDemand { get { return _NetSchemeDemand; } set { _NetSchemeDemand = value; } }
        public int StockYojna { get { return _StockYojna; } set { _StockYojna = value; } }
        public int MediumId { get { return _MediumId; } set { _MediumId = value; } }
        public int UserID { get { return _UserID; } set { _UserID = value; } }
        public int DemandType { get { return _DemandType; } set { _DemandType = value; } }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS_DemandToPrinting", DBAccess.SQLType.IS_PROC);

            obDBAccess.addParam("mTitleId", TitleId);
            obDBAccess.addParam("mMediumId", MediumId);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mDepotID", DepotID);
            obDBAccess.addParam("mSchemeDemand", SchemeDemand);
            obDBAccess.addParam("mOpnMktDemand", OpnMktDemand);
            obDBAccess.addParam("mStockYojna", StockYojna);
            obDBAccess.addParam("mStockOpenMkt", StockOpenMkt);
            obDBAccess.addParam("mNetSchemeDemand", NetSchemeDemand);
            obDBAccess.addParam("mNetOpenMkt", NetOpenMkt);
            obDBAccess.addParam("mUserID", UserID);
          
            obDBAccess.addParam("mDemandType", DemandType);

            int result = obDBAccess.executeMyQuery();
            return result;
        }



    }
}