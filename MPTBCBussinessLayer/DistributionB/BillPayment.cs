using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
    public class BillPayment:ICommon
    {
        public int ProcessBillDetailsTrno_I { get; set; }      
        public int TotalPaidTitles_I { get; set; }
        public double TdsAmount_I { get; set; }
        public double PaidAmount_I { get; set; }
        public string ChqNo_V { get; set; }
        public string ChqDate_D { get; set; }
      
        public string BankName_V { get; set; }
        public string LetterNo_V { get; set; }
        public string LetterDate_D { get; set; }
        public int BillPaymentTrno { get; set; }
        public string ScanLetterFileName { get; set; }
     
        public double Rate { get; set; }

    
      

        public double DiscountPercent { get; set; } 
        public int QueryParameterValue{get; set; }
        public int QueryParameterValue2 { get; set; }  
        public int TransID { get; set; }

        public int UserID { get; set; }
        public string PaymentMode { get; set; }
        DBAccess obDBAccess;

        #region ICommon Members

        public int InsertUpdate()
        {



            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB008_BillPaymentSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillPaymentTrno_I", BillPaymentTrno);
            obDBAccess.addParam("mProcessBillDetailsTrno_I", ProcessBillDetailsTrno_I);
            obDBAccess.addParam("mTotalPaidTitles_I", TotalPaidTitles_I);
            obDBAccess.addParam("mTdsAmount_I", TdsAmount_I);
            
            obDBAccess.addParam("mPaidAmount_I", PaidAmount_I);
            obDBAccess.addParam("mChqNo_V", ChqNo_V);
            obDBAccess.addParam("mChqDate_D", ChqDate_D);
            obDBAccess.addParam("mBankName_V", BankName_V);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mLetterDate_D", LetterDate_D);
            obDBAccess.addParam("mPaymentMode", PaymentMode);
            obDBAccess.addParam("mUserId", UserID);

            obDBAccess.addParam("mTransID", TransID);
            object result = obDBAccess.executeMyScalar();

 
            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB008_BillPaymentSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryParameterValue", QueryParameterValue);
            obDBAccess.addParam("mQueryParameterValue2", QueryParameterValue2);
            obDBAccess.addParam("mQueryType", TransID);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB008_BillPaymentDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBillPaymentTrno_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        #endregion
    }
}
