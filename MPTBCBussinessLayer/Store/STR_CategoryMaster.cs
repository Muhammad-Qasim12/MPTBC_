using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Store
{
    public class STR_CategoryMaster : ICommon
    {
        private Int32 _CategoryID_I;
        private string _CategoryType_V;
        private string _ItemCategory_V;
        private Int32 _UserTrNo_I;
        private DateTime _TrDate_D;

        public Int32 CategoryID_I { get { return _CategoryID_I; } set { _CategoryID_I = value; } }
        public string CategoryType_V { get { return _CategoryType_V; } set { _CategoryType_V = value; } }
        public string ItemCategory_V { get { return _ItemCategory_V; } set { _ItemCategory_V = value; } }
        public Int32 UserTrNo_I { get { return _UserTrNo_I; } set { _UserTrNo_I = value; } }
        public DateTime TrDate_D { get { return _TrDate_D; } set { _TrDate_D = value; } }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR001_CategoryMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            obDBAccess.addParam("mCategoryType_V", CategoryType_V);
            obDBAccess.addParam("mItemCategory_V", ItemCategory_V);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mTrDate_D", TrDate_D);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR001_CategoryMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mUserTrNo_I", UserTrNo_I);
            obDBAccess.addParam("mCategoryID_I", CategoryID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_STR001_CategoryMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCategoryID_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

    }
}
