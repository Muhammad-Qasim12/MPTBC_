using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_LabInspevaluation
    {
        private int _LabInspEva_id_i;
        private int _LOITrId_I;
        private string _AcYear_V;
        private int _LabTrId_I;
        private int _UserId_I;
        private int _ReportSts_i;
        private string _LatterNo;
        private DateTime _LatterDate;
        private string _LatterStatus;

        //LatterNo,LatterDate,LatterStatus

        public string LatterNo { get { return _LatterNo; } set { _LatterNo = value; } }
        public string LatterStatus { get { return _LatterStatus; } set { _LatterStatus = value; } }
        public DateTime LatterDate { get { return _LatterDate; } set { _LatterDate = value; } }

        public int ReportSts_i { get { return _ReportSts_i; } set { _ReportSts_i = value; } }
        public int LabInspEva_id_i { get { return _LabInspEva_id_i; } set { _LabInspEva_id_i = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public string AcYear_V { get { return _AcYear_V; } set { _AcYear_V = value; } }
        public int LabTrId_I { get { return _LabTrId_I; } set { _LabTrId_I = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspEva_id_i", LabInspEva_id_i);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mAcYear_V", AcYear_V);
            obDBAccess.addParam("mLabTrId_I", LabTrId_I);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mReportSts_i", ReportSts_i);
            obDBAccess.addParam("mLatterNo", LatterNo);
            obDBAccess.addParam("mLatterDate", LatterDate);
            obDBAccess.addParam("mLatterStatus", LatterStatus);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet LOIFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationDetailsShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mLabInspEva_id_i", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet LOIDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationDetailsShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mLabInspEva_id_i", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet LabFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationDetailsShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mLabInspEva_id_i", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }
        public System.Data.DataSet FiledFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationDetailsShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mLabInspEva_id_i", LabInspEva_id_i);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationDetailsShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mLabInspEva_id_i", 0);
            obDBAccess.addParam("mLabTrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet LabInsEvaSearchName(string LabName)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabName", LabName); 
            return obDBAccess.records();
        }
        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0011_LabInspevaluationDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mLabInspEva_id_i", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
