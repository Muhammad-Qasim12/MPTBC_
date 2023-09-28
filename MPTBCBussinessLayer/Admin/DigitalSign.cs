using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Admin
{
   public  class DigitalSign : ICommon
    {

       public int SignID { get; set; }
       public int UserID { get; set; }
        public string UserName { get; set; }
        public string Department { get; set; }
        public DateTime ExpiryDate { get; set; }       
        public string CertificateID { get; set; }
        public int ModifiedBy { get; set; }

        public int TransID { get; set; }

        DBAccess obDBAccess = new DBAccess();

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM017_DigitalSignSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mSignId", SignID);
            obDBAccess.addParam("mUserID", UserID);
            obDBAccess.addParam("mUserName", UserName);
            obDBAccess.addParam("mDepartmentName", Department);
            obDBAccess.addParam("mExpiryDate", ExpiryDate);
            obDBAccess.addParam("mCertificateID", CertificateID);
            obDBAccess.addParam("mModifiedBy", ModifiedBy);
            obDBAccess.addParam("mTransID", TransID);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

       public System.Data.DataSet Select()
        {
            obDBAccess.execute("USP_ADM017_DigitalSignSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTransID", TransID);
            obDBAccess.addParam("mCertificateID", CertificateID);
            obDBAccess.addParam("mUserName", UserName);
            obDBAccess.addParam("mExpiryDate", ExpiryDate);
           
            return obDBAccess.records();
        }

      public  int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
