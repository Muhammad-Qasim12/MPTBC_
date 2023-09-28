using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Academic
{
    public class CDProofVerification : ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public int ParameterValue3 { get; set; }

        public string StringParameter { get; set; }

        public int AcYearID_I { get; set; }
        public string LetterNo_V { get; set; }
        public string LetterDate_D { get; set; }
        public string ExpectedRetDate_D { get; set; }
        public int CDProofVerificationTrno_I { get; set; }
        public int TitleID_I { get; set; }

        public string UploadFilePath { get; set; }
        public string FileName { get; set; }
        public int TotalCopies { get; set; }
        public int TotalCD { get; set; }
        public int TransID { get; set; }

        public string  Remark { get; set; }
        public int RetCDProofVerificationTrno_I { get; set; }

        DBAccess obDBAccess;


        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD003_CDProofVerificationSave", DBAccess.SQLType.IS_PROC); 

            obDBAccess.addParam("mAcYearID_I", AcYearID_I);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mLetterDate_D", LetterDate_D);
            obDBAccess.addParam("mExpectedRetDate_D", ExpectedRetDate_D);
            obDBAccess.addParam("mCDProofVerificationTrno_I", CDProofVerificationTrno_I);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mTotalCopies", TotalCopies);
            obDBAccess.addParam("mTotalCD", TotalCD);
            obDBAccess.addParam("mRetCDProofVerificationTrno_I", RetCDProofVerificationTrno_I);
            obDBAccess.addParam("mRemark_V", Remark);
            obDBAccess.addParam("mUploadFilePath", UploadFilePath);
            obDBAccess.addParam("mFileName", FileName);
            obDBAccess.addParam("mTransID", TransID);
            

            object result = obDBAccess.executeMyScalar();
            return int.Parse( result.ToString() );
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD003_CDProofVerificationSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            obDBAccess.addParam("mParameterValue3", ParameterValue3);
            obDBAccess.addParam("mStringParameter", StringParameter);
            return obDBAccess.records();      
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
