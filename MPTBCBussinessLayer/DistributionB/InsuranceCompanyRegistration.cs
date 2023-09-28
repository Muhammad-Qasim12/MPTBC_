using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
    
    public class InsuranceCompanyRegistration : ICommon
    {
        public int FinancialYr { get; set; }
        public int InsuranceCompanyTrno{ get; set; }
        public string CompanyName { get; set; }
      
        public string Remark { get; set; }
        public string InsDateFrom { get; set; }
        public string InsDateTo { get; set; }

        public double NetPrimium {get; set;}
        public double ServiceTax {get; set;}
        public double OtherTax {get; set;}
        public double GrossPrimium {get; set;}
        public double BurglaryNetPrimium {get; set;}
        public double BurglaryServiceTax {get; set;}
        public double BurglaryOtherTax {get; set;}
        public double BurglaryGrossPrimium {get; set;}
        public string BurglaryRemark {get; set;}

        public int Tender_Cond_Id { get; set; }
        public bool Tender_Cond_Value { get; set; }

        public int ParameterValue { get; set; }
        public int TransID { get; set; }

        DBAccess obDBAccess = new DBAccess();

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB003_InsuranceCompanySave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mInsuranceCompanyTrno_I", InsuranceCompanyTrno);
            obDBAccess.addParam("mFinancialYr_I", FinancialYr);
            obDBAccess.addParam("mCompanyName_V", CompanyName);
           
            //obDBAccess.addParam("mIsIRDA_B", IRDA);
            //obDBAccess.addParam("mIsFormPurchase_B", FormPurchase);
            obDBAccess.addParam("mDateFrom", InsDateFrom);
            obDBAccess.addParam("mDateTo", InsDateTo);
            
            obDBAccess.addParam("mTender_Cond_Id", Tender_Cond_Id);
            obDBAccess.addParam("mTender_Cond_Value", Tender_Cond_Value);            

            obDBAccess.addParam("mRemark_V", Remark);

            obDBAccess.addParam("mNetPrimium_N", NetPrimium);
            obDBAccess.addParam("mServiceTax_N", ServiceTax);
            obDBAccess.addParam("mOtherTax_N", OtherTax);
            obDBAccess.addParam("mGrossPrimium_N", GrossPrimium);
            obDBAccess.addParam("mBurglaryNetPrimium_N", BurglaryNetPrimium);
            obDBAccess.addParam("mBurglaryServiceTax_N", BurglaryServiceTax);
            obDBAccess.addParam("mBurglaryOtherTax_N", BurglaryOtherTax);
            obDBAccess.addParam("mBurglaryGrossPrimium_N", BurglaryGrossPrimium);
            obDBAccess.addParam("mBurglaryRemark_V", BurglaryRemark);
           
            obDBAccess.addParam("mTransID", TransID);         
          


            object result = obDBAccess.executeMyScalar();

            return int.Parse(result.ToString());
            
           
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB003_InsuranceCompanySelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQueryType", TransID);
            obDBAccess.addParam("mParameterValue_I", ParameterValue);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB003_InsuranceCompanyDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mInsuranceCompanyTrno", id);
            int retValue= obDBAccess.executeMyQuery();
            return retValue;
        }

        #endregion
    }
}
