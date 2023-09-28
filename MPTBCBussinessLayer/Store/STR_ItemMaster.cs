using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_ItemMaster :ICommon
    {
        private Int32 _ItemID_I;
        private Int32 _CategoryID_I;
        private string _ItemName_V;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;
        private string _CategoryType_V;

        public Int32 ItemID_I { get { return _ItemID_I; } set { _ItemID_I = value; } }
        public Int32 CategoryID_I { get { return _CategoryID_I; } set { _CategoryID_I = value; } }
        public string ItemName_V { get { return _ItemName_V; } set { _ItemName_V = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }
        public string CategoryType_V { get { return _CategoryType_V; } set { _CategoryType_V = value; } }
        public string Type { get; set; } 


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR002_ItemMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mItemName_V", ItemName_V);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR002_ItemMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mItemID_I", ItemID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR002_ItemMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mItemID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public System.Data.DataSet FillDDL()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR002_FillDDL", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mCategoryType_V", CategoryType_V);
            obDBAccess.addParam("mtype", Type);
            return obDBAccess.records();
            throw new NotImplementedException();
        }
    }
}

