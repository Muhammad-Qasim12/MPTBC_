using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PRI_ProjectManagement : ICommon
    {
        private int _TimelineTrno_I, _TimelineDay_I, _TimelinebaseID_I, _TimelineCompid_I;
        private string _JobCode_V;

        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public int TimelineTrno_I { get { return _TimelineTrno_I; } set { _TimelineTrno_I = value; } }
        public int TimelineDay_I { get { return _TimelineDay_I; } set { _TimelineDay_I = value; } }
        public int TimelinebaseID_I { get { return _TimelinebaseID_I; } set { _TimelinebaseID_I = value; } }
        public int TimelineCompid_I { get { return _TimelineCompid_I; } set { _TimelineCompid_I = value; } }

        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI003_ProjectManagementTimeLineSaveUpdate", DBAccess.SQLType.IS_PROC);
            obj.addParam("mTimelineTrno_I", TimelineTrno_I);
            obj.addParam("mTimelineDay_I", TimelineDay_I);
            obj.addParam("mTimelinebaseID_I", TimelinebaseID_I);
            obj.addParam("mTimelineCompid_I", TimelineCompid_I);

            i = obj.executeMyQuery();

            return i;

        }

        public DataSet ProjectManagementFill()
        {
            DBAccess obDBAccess = new DBAccess();
          //  obDBAccess.execute("ProjectManagementDtl", DBAccess.SQLType.IS_PROC);
            obDBAccess.execute("USP_PRI002_ProjectManagementDetails", DBAccess.SQLType.IS_PROC);            
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public DataSet JobNoFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI002_ProjectManagementDetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }


        public DataSet Select()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI003_ProjectManagementTimeLineLoad", DBAccess.SQLType.IS_PROC);

            ds = obj.records();

            return ds;
        }



        public DataSet ProjectTimeLineDescriptionLoad()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI003_ProjectManagementTileLineDescriptionLoad", DBAccess.SQLType.IS_PROC);

            ds = obj.records();

            return ds;

        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }


        #endregion








    }
}