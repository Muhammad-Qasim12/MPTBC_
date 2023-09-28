using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
   public class AdvancePayment : ICommon
    {
        public int QueryType { get; set; }
        public int Parameter1 { get; set; }
        public int Parameter2 { get; set; }

        public int TransType { get; set; }
        public int AdvancePaymentID { get; set; }
        public int DepartmentID { get; set; }
        public int TitleID { get; set; }
        public int FinancialYrId { get; set; }
        public string LetterNo { get; set; }
        public string LetterDate { get; set; }
        public string AdvanceType { get; set; }
        public string PaymentDetails { get; set; }
        public int Payment { get; set; }
        public int UserID { get; set; }
        DBAccess obDBAccess;


        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_017_SaveAdvancePayment", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepartmentID", DepartmentID);
            obDBAccess.addParam("mTitleID", TitleID);
            obDBAccess.addParam("mFinancialYrId", FinancialYrId);
            obDBAccess.addParam("mLetterNo", LetterNo);
            obDBAccess.addParam("mLetterDate", LetterDate);
            obDBAccess.addParam("mAdvanceType", AdvanceType);
            obDBAccess.addParam("mPaymentDetail", PaymentDetails);
            obDBAccess.addParam("mPayment", Payment);
            obDBAccess.addParam("mUserID", UserID);
            obDBAccess.addParam("mTransID", TransType);
            obDBAccess.addParam("mAdvancePaymentID", AdvancePaymentID);
            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_017_AdvancePaymentSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryParameterValue", Parameter1);
            obDBAccess.addParam("mQueryParameterValue2", Parameter2);
            obDBAccess.addParam("mQueryType", QueryType);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_017_AdvancePaymentDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mAdvancePaymentID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}
