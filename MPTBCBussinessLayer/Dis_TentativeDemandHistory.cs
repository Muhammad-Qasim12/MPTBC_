using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class Dis_TentativeDemandHistory
    {
        private string _CurrentAcYear;
        private int _BlockID_12;
        private int _DistrictID_12;
        private int _DemandId;
        private string _AcYearId;
        private int _TitleId;
        private int _NoOfBooks;
        private int _UserId;

        public string CurrentAcYear { get { return _CurrentAcYear; } set { _CurrentAcYear = value; } }
        public int BlockID_12 { get { return _BlockID_12; } set { _BlockID_12 = value; } }
        public int DistrictID_12 { get { return _DistrictID_12; } set { _DistrictID_12 = value; } }
        public int DemandId { get { return _DemandId; } set { _DemandId = value; } }
        public string AcYearId { get { return _AcYearId; } set { _AcYearId = value; } }
        public int TitleId { get { return _TitleId; } set { _TitleId = value; } }
        public int NoOfBooks { get { return _NoOfBooks; } set { _NoOfBooks = value; } }
        public int UserId { get { return _UserId; } set { _UserId = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DISO001_TentativeDemandSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandId", DemandId);
            obDBAccess.addParam("mAcYearId", AcYearId);
            obDBAccess.addParam("mTitleId", TitleId);
            obDBAccess.addParam("mNoOfBooks", NoOfBooks);
            obDBAccess.addParam("mUserId", UserId);
            obDBAccess.addParam("mDistrictId", DistrictID_12);
            obDBAccess.addParam("mblockId", BlockID_12);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet TentativeHistory(string CurrentAcYear, int BlockID, int DistrictID, int Medum_12, int Class_12, int type)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DISO001_TentativeDemandHistory", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("CurrentAcYear", CurrentAcYear);
            obDBAccess.addParam("mBlockID_12", BlockID);
            obDBAccess.addParam("mDistrictID_12", DistrictID);
            obDBAccess.addParam("mMedum_12", Medum_12);
            obDBAccess.addParam("mClass_12", Class_12);
            obDBAccess.addParam("mtype", type);
            return obDBAccess.records();
        }

        public System.Data.DataSet TentativeHistoryWithYear(int TiTleID, string CurrentAcYear, int BlockID, int DistrictID, int Medum_12, int Class_12)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DISO001_TentativeDemandHistoryWithYear", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("CurrentAcYear", CurrentAcYear);
            obDBAccess.addParam("mBlockID_12", BlockID);
            obDBAccess.addParam("mDistrictID_12", DistrictID);
            obDBAccess.addParam("mMedum_12", Medum_12);
            obDBAccess.addParam("mClass_12", Class_12);
            obDBAccess.addParam("mTiTleID", TiTleID);

            return obDBAccess.records();
        }

        public System.Data.DataSet TentativeDemandCheckQty(int TiTleID, string CurrentAcYear, int BlockID, int DistrictID)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DISO001_TentativeDemandCheckQty", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAcYearId", CurrentAcYear);
            obDBAccess.addParam("mTitleId", TiTleID);
            obDBAccess.addParam("mDistrictId", DistrictID);   
            obDBAccess.addParam("mblockId", BlockID);                     
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet TentativeDemandAcadminYearFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DISO001_TentativeDemandCheckQty", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAcYearId", "");
            obDBAccess.addParam("mTitleId", 0);
            obDBAccess.addParam("mDistrictId", 0);
            obDBAccess.addParam("mblockId", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet MedumFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("ProcDropdownFillMedumClass", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet ClassFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("ProcDropdownFillMedumClass", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet DistrictFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("ProcDropdownFillMedumClass", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mtype", 2);
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
