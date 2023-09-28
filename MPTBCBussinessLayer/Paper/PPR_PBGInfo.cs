﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PPR_PBGInfo
    {
        private int _LOITrId_I;
        private int _PBGTrId_I;
        private string _PBGNo_V;
        private string _PBGType_V;
        private DateTime _PBGDate_D;
        private int _BankName_I;
        private Decimal _PBGAmount;
        private int _ValidityTime_I;
        private DateTime _ValidityDate_D;
        private string _AgreementStatus_V;
        private string _Remark_V;
        private int _UserId_I;
        private int _Pbg_Child_Id;
        private string _BranchName;
        private string _SecurityType;
        private string _DepositReturn;

        public int LOITrId_I { get { return _LOITrId_I; } set { _LOITrId_I = value; } }
        public int PBGTrId_I { get { return _PBGTrId_I; } set { _PBGTrId_I = value; } }
        public int Pbg_Child_Id { get { return _Pbg_Child_Id; } set { _Pbg_Child_Id = value; } }



        public string DepositReturn { get { return _DepositReturn; } set { _DepositReturn = value; } }
            public string SecurityType { get { return _SecurityType; } set { _SecurityType = value; } }
        public string BranchName { get { return _BranchName; } set { _BranchName = value; } }
        public string PBGNo_V { get { return _PBGNo_V; } set { _PBGNo_V = value; } }
        public string PBGType_V { get { return _PBGType_V; } set { _PBGType_V = value; } }
        public DateTime PBGDate_D { get { return _PBGDate_D; } set { _PBGDate_D = value; } }
        public int BankName_I { get { return _BankName_I; } set { _BankName_I = value; } }
        public decimal PBGAmount { get { return _PBGAmount; } set { _PBGAmount = value; } }
        public int ValidityTime_I { get { return _ValidityTime_I; } set { _ValidityTime_I = value; } }
        public DateTime ValidityDate_D { get { return _ValidityDate_D; } set { _ValidityDate_D = value; } }
        public string AgreementStatus_V { get { return _AgreementStatus_V; } set { _AgreementStatus_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGSaveUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", PBGTrId_I);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mAgreementStatus_V", AgreementStatus_V);
            obDBAccess.addParam("mRemark_V", Remark_V);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mDepositReturn", DepositReturn);

            int result = Convert.ToInt32(obDBAccess.executeMyScalar());
            return result;
        }
        public int ChildInsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGChildSaveUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", PBGTrId_I);
            obDBAccess.addParam("mPbg_Child_Id", Pbg_Child_Id);
            obDBAccess.addParam("mPBGNo_V", PBGNo_V);
            obDBAccess.addParam("mPBGType_V", PBGType_V);
            obDBAccess.addParam("mPBGDate_D", PBGDate_D);
            obDBAccess.addParam("mBankName_I", BankName_I);
            obDBAccess.addParam("mPBGAmount", PBGAmount);
            obDBAccess.addParam("mValidityTime_I", ValidityTime_I);
            obDBAccess.addParam("mValidityDate_D", ValidityDate_D);
            obDBAccess.addParam("mBranchName", BranchName);
            obDBAccess.addParam("mSecurityType", SecurityType);
            obDBAccess.addParam("mDepositReturn", DepositReturn);     
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 2);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGDeleteData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet LOIFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", 0);
            obDBAccess.addParam("mtype", 0);

            return obDBAccess.records();
        }

        public System.Data.DataSet PBGNoCheck()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGNoCheck", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGNo_V", PBGNo_V);
            return obDBAccess.records();
        }

        public System.Data.DataSet PBGNoSearchName()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_SearchNamePBGNo", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGNo_V", PBGNo_V);
            return obDBAccess.records();
        }
        public System.Data.DataSet LOIDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();
        }
        public System.Data.DataSet PBGDtlFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR006_PBGShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPBGTrId_I", PBGTrId_I);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mLOITrId_I", LOITrId_I);
            obDBAccess.addParam("mtype", 3);
            return obDBAccess.records();
        }
        public System.Data.DataSet BankDetails()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("ProcBankMaster", DBAccess.SQLType.IS_PROC);

            return obDBAccess.records();
        }
    }
}





