using System.Data;

namespace MPTBCBussinessLayer.Distribution
{
    public class DIS001_GroupCreation : ICommon
    {
        private int _GroupId, _UserId, _isSatellite_I;
        private string _GroupName, _DepotIds, _Description;

        public int GroupId { get { return _GroupId; } set { _GroupId = value; } }
        public int UserId { get { return _UserId; } set { _UserId = value; } }
        public int isSatellite_I { get { return _isSatellite_I; } set { _isSatellite_I = value; } }

        public string GroupName { get { return _GroupName; } set { _GroupName = value; } }
        public string DepotIds { get { return _DepotIds; } set { _DepotIds = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }





        public int InsertUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;


            obDbAccess.execute("USP_DIS002_GroupCreationSave", DBAccess.SQLType.IS_PROC);

            obDbAccess.addParam("mGroupId", GroupId);
            obDbAccess.addParam("mGroupName", GroupName);
            obDbAccess.addParam("mDepotIds", DepotIds);
            obDbAccess.addParam("mDescription", Description);
            obDbAccess.addParam("mUserId", UserId);

            i = obDbAccess.executeMyQuery();

            return i;
        }


        public DataSet GroupListLoad()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();


            obDbAccess.execute("USP_ADM018_SelectTypeWiseDepot", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("misSatellite_I", isSatellite_I);
            ds = obDbAccess.records();

            return ds;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();


            obDbAccess.execute("USP_DIS002_GroupCreationLoad", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mGroupId", GroupId);
            ds = obDbAccess.records();

            return ds;
        }

        public int Delete(int id)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;


            obDbAccess.execute("USP_DIS002_GroupDelete", DBAccess.SQLType.IS_PROC);
            obDbAccess.addParam("mGroupId", id);
            i = obDbAccess.executeMyQuery();

            return i;
        }
    }
}
