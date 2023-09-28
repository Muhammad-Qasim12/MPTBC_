using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace MPTBCBussinessLayer
{
    public class Building001_AvasSanchipt : ICommon
    {
        string _AvasCategory_V, _AvasAddress_V, _AvasType_V, _Remark_V;
        int _UserTrno_I, _AvasMasterTrno_I;

        public string AvasCategory_V { get { return _AvasCategory_V; } set { _AvasCategory_V = value; } }
        public string AvasAddress_V { get { return _AvasAddress_V; } set { _AvasAddress_V = value; } }
        public string AvasType_V { get { return _AvasType_V; } set { _AvasType_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }

        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }
        public int AvasMasterTrno_I { get { return _AvasMasterTrno_I; } set { _AvasMasterTrno_I = value; } }







        #region ICommon Members

        public int InsertUpdate()
        {
              DBAccess obDbAccess = new DBAccess();
            int i = 0;

            try
            {
                obDbAccess.execute("USP_Building001_AvasMasterSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
                obDbAccess.addParam("mAvasCategory_V", AvasCategory_V);
                obDbAccess.addParam("mAvasAddress_V", AvasAddress_V);
                obDbAccess.addParam("mAvasType_V", AvasType_V);
                obDbAccess.addParam("mRemark_V", Remark_V);
                obDbAccess.addParam("mUserTrno_I", UserTrno_I );

                i = obDbAccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_building001_AvasMasterLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;
        }

        public int Delete(int id)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_Building001_AvasMasterDelete", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAvasMasterTrno_I", id);
                i = obDbAccess.executeMyQuery();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;
        }

        #endregion
    }
}
