using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_InspectionByTBc
    {

        private int _WorkPlanTrId_I;
        private int _PaperMstrTrId_I;

        private int _InspectionTrId_I;
        private int _InspectionType_I;

        private int _PaperType_I;
        private int _LOITrId_I;
        private string _InspectionReport_V;
        private string _InspectionFile_V;
        private DateTime _InspectionDate_D;
        private int _UserId_I;

        private int _InspectionLevel_I;
        private string _InspectionName_V;
        private int _InspectionOfficerTrId_I;
        private int _InspectionOfficerName_I;

        private int _OfficerDesignation_I;
        //private int _InspectionType_I;
        //  private int _InspectionTrId_I;

        public int InspectionLevel_I { get { return _InspectionLevel_I; } set { _InspectionLevel_I = value; } }
        public string InspectionName_V { get { return _InspectionName_V; } set { _InspectionName_V = value; } }
        public int InspectionOfficerTrId_I { get { return _InspectionOfficerTrId_I; } set { _InspectionOfficerTrId_I = value; } }
        public int InspectionOfficerName_I { get { return _InspectionOfficerName_I; } set { _InspectionOfficerName_I = value; } }
        public int OfficerDesignation_I { get { return _OfficerDesignation_I; } set { _OfficerDesignation_I = value; } }
        //public int InspectionType_I { get { return _InspectionType_I; } set { _InspectionType_I = value; } }
        //public int InspectionTrId_I { get { return _InspectionTrId_I; } set { _InspectionTrId_I = value; } }




        public int WorkPlanTrId_I { get { return _WorkPlanTrId_I; } set { _WorkPlanTrId_I = value; } }
        public int PaperMstrTrId_I { get { return _PaperMstrTrId_I; } set { _PaperMstrTrId_I = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public int InspectionTrId_I { get { return _InspectionTrId_I; } set { _InspectionTrId_I = value; } }
        public int InspectionType_I { get { return _InspectionType_I; } set { _InspectionType_I = value; } }

        public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public string InspectionReport_V { get { return _InspectionReport_V; } set { _InspectionReport_V = value; } }
        public string InspectionFile_V { get { return _InspectionFile_V; } set { _InspectionFile_V = value; } }
        public DateTime InspectionDate_D { get { return _InspectionDate_D; } set { _InspectionDate_D = value; } }


        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mInspectionTrId_I", InspectionTrId_I);
            obDBAccess.addParam("mInspectionType_I", InspectionType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mInspectionReport_V", InspectionReport_V);
            obDBAccess.addParam("mInspectionFile_V", InspectionFile_V);
            obDBAccess.addParam("mInspectionDate_D", InspectionDate_D);
            obDBAccess.addParam("mInspectionLevel_I", InspectionLevel_I);
            obDBAccess.addParam("mInspectionName_V", InspectionName_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int i = Convert.ToInt32(obDBAccess.executeMyScalar());
            return i;
        }

        public int Update()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mInspectionTrId_I", InspectionTrId_I);
            obDBAccess.addParam("mInspectionType_I", InspectionType_I);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mPaperType_I", PaperType_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mInspectionReport_V", InspectionReport_V);
            obDBAccess.addParam("mInspectionFile_V", InspectionFile_V);
            obDBAccess.addParam("mInspectionDate_D", InspectionDate_D);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mInspectionLevel_I", InspectionLevel_I);
            obDBAccess.addParam("mInspectionName_V", InspectionName_V);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int OfficerInsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionOfficeSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mInspectionOfficerTrId_I", InspectionOfficerTrId_I);
            obDBAccess.addParam("mInspectionOfficerName_I", InspectionOfficerName_I);
            obDBAccess.addParam("mOfficerDesignation_I", OfficerDesignation_I);
            obDBAccess.addParam("mInspectionType_I", InspectionType_I);
            obDBAccess.addParam("mInspectionTrId_I", InspectionTrId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet LOIFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDetailShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mInspectionTrId_I", 0);
            obDBAccess.addParam("mType", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet PaperFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDetailShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", LOITrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mInspectionTrId_I", 0);
            obDBAccess.addParam("mType", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet SizeFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDetailShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", LOITrId_I);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", PaperMstrTrId_I);
            obDBAccess.addParam("mInspectionTrId_I", 0);
            obDBAccess.addParam("mType", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDetailShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mInspectionTrId_I", 0);

            obDBAccess.addParam("mType", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet TBCSearchName(string Name)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mName", Name);
            return obDBAccess.records();
        }


        public System.Data.DataSet InspectionDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDetailShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mInspectionTrId_I", InspectionTrId_I);
            obDBAccess.addParam("mType", 4);
            return obDBAccess.records();
        }
        public System.Data.DataSet InspectionChildFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDetailShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOIId_I", 0);
            obDBAccess.addParam("mWorkPlanTrId_I", 0);
            obDBAccess.addParam("mPaperMstrTrId_I", 0);
            obDBAccess.addParam("mInspectionTrId_I", InspectionTrId_I);
            obDBAccess.addParam("mType", 5);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR009_InspectionDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mInspectionTrId_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet OfficerDesignationmFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("officerdesignationmFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOffDesId_i", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet OfficerPostFill(int OffDesId_i)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("officerdesignationmFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOffDesId_i", OffDesId_i);
            return obDBAccess.records();
        }


    }
}
