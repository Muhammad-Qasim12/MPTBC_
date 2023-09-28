
namespace MPTBCBussinessLayer.Admin
{
    public class FormMaster : ICommon
    {
        //mFormTrno_I int(11) ,
        //                  mSubModuleTrno_I int(11) ,
        //                  mStatus_V varchar(5) ,
        //                  mFormDesc_V varchar(50) ,
        //                  mFormPath_V varchar(50)

        public int FormTrno { get; set; }
        public int SubModuleTrno { get; set; }
        public int ModuleTrno { get; set; }
        public string Status { get; set; }
        public string FormDesc { get; set; }
        public string FormPath { get; set; }
        public bool VisibleInLink { get; set; }
        public int OrderNo { get; set; }
        public int TranID { get; set; }
        public int QueryType { get; set; }
        public int MainFormTrno_I { get; set; }
        DBAccess obDBAccess;

        #region ICommon Members
        
        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM003_FormMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mFormTrno_I", FormTrno);
            obDBAccess.addParam("mSubModuleTrno_I", SubModuleTrno);
            obDBAccess.addParam("mStatus_V", Status);
            obDBAccess.addParam("mFormDesc_V", FormDesc);
            obDBAccess.addParam("mVisibleInLink_B", VisibleInLink);
            obDBAccess.addParam("mFormPath_V", FormPath);
            obDBAccess.addParam("mOrderNo_I", OrderNo);
            obDBAccess.addParam("mTranID", TranID);

            int result = obDBAccess.executeMyQuery();
            return result;
        } 
          public int SubFrmInsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM003_FormSubMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mFormTrno_I", FormTrno);
            obDBAccess.addParam("mSubModuleTrno_I", SubModuleTrno);
            obDBAccess.addParam("mStatus_V", Status);
            obDBAccess.addParam("mFormDesc_V", FormDesc);
            obDBAccess.addParam("mVisibleInLink_B", VisibleInLink);
            obDBAccess.addParam("mFormPath_V", FormPath);
            obDBAccess.addParam("mOrderNo_I", OrderNo);
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mMainFormTrno_I", MainFormTrno_I);              
            int result = obDBAccess.executeMyQuery();
            return result;
        } 
        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM003_FormMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mFormTrno_I", FormTrno);
            return obDBAccess.records();        
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM003_FormMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mFormTrno_I", id);
            return obDBAccess.executeMyQuery(); 
        }

        #endregion
    }
}
