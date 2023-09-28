using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Paper
{
    public class PPR_StockAuditAndVerification
    {

        private int _AuditTrId_I;
        private int _LOITrId_I;
        private string _VerificationReport_V;
        private string _Remark_V;
        private string _VerifcationReportFile_V;
        private DateTime _VerificationDate_D;
        private int _UserId_I;
        private int _AuditDtld_I;
        private int _OfficerId;
        private string _OfficerPost;




        public int AuditDtld_I { get { return _AuditDtld_I; } set { _AuditDtld_I = value; } }
        public int OfficerId { get { return _OfficerId; } set { _OfficerId = value; } }
        public string OfficerPost { get { return _OfficerPost; } set { _OfficerPost = value; } }


        public int AuditTrId_I { get { return _AuditTrId_I; } set { _AuditTrId_I = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public string VerificationReport_V { get { return _VerificationReport_V; } set { _VerificationReport_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public string VerifcationReportFile_V { get { return _VerifcationReportFile_V; } set { _VerifcationReportFile_V = value; } }
        public DateTime VerificationDate_D { get { return _VerificationDate_D; } set { _VerificationDate_D = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditTrId_I", AuditTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVerificationReport_V", VerificationReport_V);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mVerifcationReportFile_V", VerifcationReportFile_V);
            obDBAccess.addParam("mVerificationDate_D", VerificationDate_D);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int i = Convert.ToInt32(obDBAccess.executeMyScalar());

           
            return i;
        }

        public int Update()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditTrId_I", AuditTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mVerificationReport_V", VerificationReport_V);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mVerifcationReportFile_V", VerifcationReportFile_V);
            obDBAccess.addParam("mVerificationDate_D", VerificationDate_D);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int OfficerInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifChildSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditDtld_I", AuditDtld_I);
            obDBAccess.addParam("mAuditTrId_I", AuditTrId_I);
            obDBAccess.addParam("mOfficerId", OfficerId);
            obDBAccess.addParam("mOfficerPost", OfficerPost);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet LOIFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifiShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mAuditDtld_I", 0);

            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifiShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mAuditDtld_I", 0);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet StockSearchName(string Name)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifiSearchName", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mName", Name);
            return obDBAccess.records();
        }


        public System.Data.DataSet StorageDetailsFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifiShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditTrId_I", AuditTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mAuditDtld_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAuditTrId_I", id);
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

        public System.Data.DataSet OfficerDesignationmAdminFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("officerdesignationmFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOffDesId_i", 100);
            return obDBAccess.records();
        }

    }
}
