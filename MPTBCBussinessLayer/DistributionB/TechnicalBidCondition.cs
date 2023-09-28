using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.DistributionB
{
    public class TechnicalBidCondition
    {
        private string _Condition;
        private int _Tender_Cond_Id;
        private string _DisplaySts;
        private int _UserId_I;

        public int Tender_Cond_Id { get { return _Tender_Cond_Id; } set { _Tender_Cond_Id = value; } }
        public string TndrCondition { get { return _Condition; } set { _Condition = value; } }
        public string DisplaySts { get { return _DisplaySts; } set { _DisplaySts = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public int InsertUpdate()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB009_TenderConditionSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTender_Cond_Id", Tender_Cond_Id);
            obDBAccess.addParam("mTndrCondition", TndrCondition);
            obDBAccess.addParam("mDisplaySts", DisplaySts);           
            obDBAccess.addParam("mUserId_I", UserId_I);        
            int result = obDBAccess.executeMyQuery();
            return result;
        }
      
        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB009_TenderConditionLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTender_Cond_Id", 0);      
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        } 

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB009_TenderConditionLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTender_Cond_Id", id);
            obDBAccess.addParam("mtype", 1);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
    }
}