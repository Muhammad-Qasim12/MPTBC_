using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Academic
{
    public class MapVerification : ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public string StringParam { get; set; }

        public int MapVerDetailsID_I { get; set; }
        public int MapVerID_I { get; set; } 
        public string SendDate_D { get; set; }
        public string LetterNo_V { get; set; }
        public double Fees_N { get; set; }
        public string DD_Chq_Detail_V { get; set; }
        public string DD_Chq_Date_D { get; set; }
        public string BankName_V { get; set; }
        public int TotalnoofBooks_I { get; set; }
        public int TotalnoofMap_I { get; set; }
        public string Remarks_V { get; set; }

        public string AcknowledgementDate_D { get; set; }
        public string AcknowledgementLetterno_V { get; set; }
        public string Ret_Remarks_V { get; set; }
        public string Forwarddate_D { get; set; }
        public string ForwardLetterno_V { get; set; }
        public string Forward_Remarks_V { get; set; }
        public int Forwared_Department_I { get; set; }

        public int TitleID { get; set; }
        public string SessionID { get; set; }

        public int TranID { get; set; }
        public int UserID { get; set; }
        public int AcademicYrID { get; set; }
        public string  MapVerificatDate { get; set; }
        public string  MapLatterNo { get; set; }
        public string  MapAmount { get; set; }
        public string mapPaymentType { get; set; }

        DBAccess obDBAccess = new DBAccess();

        #region ICommon Members

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD007_MapVerificationSave", DBAccess.SQLType.IS_PROC);

            obDBAccess.addParam("mMapVerDetailsID_I", MapVerDetailsID_I);
            obDBAccess.addParam("mMapVerID_I", MapVerID_I);
            obDBAccess.addParam("mSendDate_D", SendDate_D);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mFees_N", Fees_N);
            obDBAccess.addParam("mDD_Chq_Detail_V", DD_Chq_Detail_V);

             obDBAccess.addParam("mDD_Chq_Date_D", DD_Chq_Date_D);
            obDBAccess.addParam("mBankName_V", BankName_V);
            obDBAccess.addParam("mTotalnoofBooks_I", TotalnoofBooks_I);
            obDBAccess.addParam("mTotalnoofMap_I", TotalnoofMap_I);
            obDBAccess.addParam("mRemarks_V", Remarks_V);
            obDBAccess.addParam("mAcknowledgementDate_D", AcknowledgementDate_D);

             obDBAccess.addParam("mAcknowledgementLetterno_V", AcknowledgementLetterno_V);
            obDBAccess.addParam("mRet_Remarks_V", Ret_Remarks_V);
            obDBAccess.addParam("mForwarddate_D", Forwarddate_D);
            obDBAccess.addParam("mForwardLetterno_V", ForwardLetterno_V);
            obDBAccess.addParam("mForward_Remarks_V", Forward_Remarks_V);
            obDBAccess.addParam("mSessionID", SessionID);
            obDBAccess.addParam("mForwared_Department_I", Forwared_Department_I);

            obDBAccess.addParam("mUserId", UserID);
            obDBAccess.addParam("mAcademicYrId", AcademicYrID);

            obDBAccess.addParam("MapVerificatDatea", MapVerificatDate);
            obDBAccess.addParam("MapLatterNoa", MapLatterNo);
            obDBAccess.addParam("MapAmounta", MapAmount);
            obDBAccess.addParam("mapPaymentTypea", mapPaymentType);

            obDBAccess.addParam("mTransID", TranID);
           // MapVerificatDate, MapLatterNo, MapAmount, mapPaymentType 
            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
        }

        public int InsertTitle()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD007_SaveTmpTitles", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID", TitleID);
            obDBAccess.addParam("mSessionID", SessionID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD007_MapVerificationSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mSessionID", StringParam);
            return obDBAccess.records();
        }

        public System.Data.DataSet SelectTitle()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD007_MapVerificationSelectTitle", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mMediumID", ParameterValue);
            obDBAccess.addParam("mClassID", ParameterValue2 );
            obDBAccess.addParam("mSessionID", SessionID);
            obDBAccess.addParam("mParameterValue", MapVerDetailsID_I);
           
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
        public int SaveRecTitles()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD007_SaveRecTitles", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mMapVerDetailsID_I", MapVerDetailsID_I);
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mRecLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mRecLetterDate_D", SendDate_D);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public int DeleteSelectedTitle()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD007_DeleteTmpTitles", DBAccess.SQLType.IS_PROC);         
            obDBAccess.addParam("mTitleIDs", StringParam);
            obDBAccess.addParam("mSessionID", SessionID);
            obDBAccess.addParam("mTransType", TranID);
            obDBAccess.addParam("mMapVerDetailsId_I", MapVerDetailsID_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
        #endregion
    }
}
