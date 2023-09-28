using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_agreementDtl
    {
        private int _LOITrId_I;
        private int _AgreementTrId_I;
        private string _AgreementNo_V;
        private string _AgreementFile_V;
        private string _Remark_V;
        private int _UserId_I;
        private DateTime _AgreementDate_D;

        public DateTime AgreementDate_D { get { return _AgreementDate_D; } set { _AgreementDate_D = value; } }
        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public int AgreementTrId_I { get { return _AgreementTrId_I; } set { _AgreementTrId_I = value; } }
        public string AgreementNo_V { get { return _AgreementNo_V; } set { _AgreementNo_V = value; } }
        public string AgreementFile_V { get { return _AgreementFile_V; } set { _AgreementFile_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {
             
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", AgreementTrId_I);
            obDBAccess.addParam("mAgreementNo_V", AgreementNo_V);
            obDBAccess.addParam("mAgreementDate_D", AgreementDate_D);
            obDBAccess.addParam("mAgreementFile_V", AgreementFile_V);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet LOIDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet PBGDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I",0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet AgreeMentPBGDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", AgreementTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet AgreeMentPBGDetailsForUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR007_AgreementShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAgreementTrId_I", AgreementTrId_I);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 4);
            return obDBAccess.records();
        }

    }
}
