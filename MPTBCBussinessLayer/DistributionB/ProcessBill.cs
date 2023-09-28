using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
    public class ProcessBill:ICommon
    {
        public int ProcessBillTrno { get; set; }      
        public int AcYearID { get; set; }
        public string LetterNo { get; set; }
        public string LetterDate { get; set; }
        public string RefLetterNo { get; set; }
        public string RefLetterDate { get; set; }
      
        public int SubTitleID { get; set; }
        public string BillType { get; set; }
        public int DepartmentID { get; set; }

        public int TotalBooks { get; set; }
        public string ScanLetterFileName { get; set; }
     
        public double Rate { get; set; }
        public double DiscountPercent { get; set; } 
        public int QueryParameterValue{get; set; }
        public int QueryParameterValue2 { get; set; }  
        public int TransID { get; set; }
        public string BillDOc { get; set; }
        public int DemandID { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int AcademicYr { get; set; }
        public int Department { get; set; }
        public int TitleID { get; set; }

        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {



            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB005_ProcessBillSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mProcessBillTrno_I", ProcessBillTrno);
            obDBAccess.addParam("mBillType_V", BillType);
            obDBAccess.addParam("mDepartmentID_I", DepartmentID);
            
            obDBAccess.addParam("mAcYearID_I", AcYearID);
            obDBAccess.addParam("mLetterNo_V", LetterNo);
            obDBAccess.addParam("mLetterDate_D", LetterDate);
            obDBAccess.addParam("mRefLetterNo_V", RefLetterNo);
            obDBAccess.addParam("mRefLetterDate_D", RefLetterDate);
            obDBAccess.addParam("mScanLetterFileName_V", ScanLetterFileName);

            obDBAccess.addParam("mSubTitleID_I", SubTitleID);
            obDBAccess.addParam("mTotalBooks_I", TotalBooks);
            obDBAccess.addParam("mRate_N", Rate);
            obDBAccess.addParam("mDiscountPercent_N", DiscountPercent);
            obDBAccess.addParam("mTransID", TransID);
            obDBAccess.addParam("BillDOc", BillDOc);
            obDBAccess.addParam("mDemandID_I", DemandID);
            object result = obDBAccess.executeMyScalar();

            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB005_ProcessBillSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryParameterValue", QueryParameterValue);
            obDBAccess.addParam("mQueryParameterValue2", QueryParameterValue2);
            obDBAccess.addParam("mQueryType", TransID);
            return obDBAccess.records();
        }
        public System.Data.DataSet SelectRPT()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB005_ProcessBillSelectRPT", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mFromDate", FromDate);
            obDBAccess.addParam("mToDate", ToDate);
            obDBAccess.addParam("mAcademicYr", AcademicYr);
            obDBAccess.addParam("mDepartmentId", DepartmentID);
            obDBAccess.addParam("mTitleId", TitleID);
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


        #endregion
    }
}
