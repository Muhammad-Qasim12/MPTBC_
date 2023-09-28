using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
    public class FreeBooksDistribution:ICommon
    {
        public int FreeBooksDistributionID { get; set; }      
        public int AcYearID { get; set; }
        public string LetterNo { get; set; }
        public string LetterDate { get; set; }
        public string RefLetterNo { get; set; }
        public string RefLetterDate { get; set; }
        public int ClassTrno { get; set; }
        public int MediumTrno { get; set; }
        public int TitleID { get; set; }
        public int TotalBooks { get; set; }
        public string ScanLetterFileName { get; set; }
        public string SupplyFrom { get; set; }
        public int DepoTrno { get; set; }
        public double Rate { get; set; }
        public double DiscountPercent { get; set; } 
        public int QueryParameterValue{get; set; }
        public int QueryParameterValue2 { get; set; }
        public string StringParameter { get; set; }
        public int TransID { get; set; }
        public string FileName { get; set; }
        public int ApprovStatus { get; set; }
        DBAccess obDBAccess;
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB001_FreeBookDistributionSave", DBAccess.SQLType.IS_PROC); 
            obDBAccess.addParam("mFreeBooksDistributionID_I", FreeBooksDistributionID);
            obDBAccess.addParam("mAcYearID_I", AcYearID);
            obDBAccess.addParam("mLetterNo_V", LetterNo);
            obDBAccess.addParam("mLetterDate_D", LetterDate);
            obDBAccess.addParam("mRefLetterNo_V", RefLetterNo);
            obDBAccess.addParam("mRefLetterDate_D", RefLetterDate);
            obDBAccess.addParam("mScanLetterFileName_V", ScanLetterFileName);
            obDBAccess.addParam("mSupplyFrom_V", SupplyFrom);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno);
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mTotalBooks_I", TotalBooks);
            obDBAccess.addParam("mRate_N", Rate);
            obDBAccess.addParam("mDiscountPercent_N", DiscountPercent);
            obDBAccess.addParam("FileName", FileName);
            obDBAccess.addParam("mApprovStatus", ApprovStatus);
            obDBAccess.addParam("mTransID", TransID);
            object result = obDBAccess.executeMyScalar();

            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB001_FreeBookDistributionSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryParameterValue", QueryParameterValue);
            obDBAccess.addParam("mQueryParameterValue2", QueryParameterValue2);
            obDBAccess.addParam("mStringValue", StringParameter);
            obDBAccess.addParam("mQueryType", TransID);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB001_FreeBookDistributionDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet SelectRPT()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB001_FreeBookDistributionRPT", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryParameterValue", QueryParameterValue);
            obDBAccess.addParam("mDateFrom", DateFrom);
            obDBAccess.addParam("mDateTo", DateTo);
            obDBAccess.addParam("mQueryType", TransID);
            return obDBAccess.records();
        }

        #endregion
    }
}
