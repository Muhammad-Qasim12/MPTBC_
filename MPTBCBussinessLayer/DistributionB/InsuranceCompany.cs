
namespace MPTBCBussinessLayer.DistributionB
{
    public class InsuranceCompany
    {
        private string _Company;
        private int _CompanyID;
        //private string _DisplaySts;
        private int _UserId_I;

        public int CompanyID { get { return _CompanyID; } set { _CompanyID = value; } }
        public string Company { get { return _Company; } set { _Company = value; } }
        //public string DisplaySts { get { return _DisplaySts; } set { _DisplaySts = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB011_InsuranceCompanySave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCompanyID_I", CompanyID);
            obDBAccess.addParam("mCompany_V", Company);
            //obDBAccess.addParam("mDisplaySts", DisplaySts);           
            obDBAccess.addParam("mUserId_I", UserId_I);        
            int result = obDBAccess.executeMyQuery();
            return result;
        }
      
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB011_InsuranceCompanyLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCompanyID_I", 0);      
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        } 

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB011_InsuranceCompanyLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mmCompanyID_I", id);
            obDBAccess.addParam("mtype", 1);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}