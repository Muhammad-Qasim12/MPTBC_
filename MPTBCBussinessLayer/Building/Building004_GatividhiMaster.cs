using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Building004_GatividhiMaster : ICommon
    {

        string _GatividhiName_V,
                _GatividhiPayDuration_V,
                _GatividhiBhavan_V,
                _Remark_V;
        int _UserTrno_I,
            _GatividhiBhavanTrno_I,
            _GatividhiPayDuration_I,
            _GatividhiTrno_I;

        public int GatividhiTrno_I { get { return _GatividhiTrno_I; } set { _GatividhiTrno_I = value; } }
        public int GatividhiBhavanTrno_I { get { return _GatividhiBhavanTrno_I; } set { _GatividhiBhavanTrno_I = value; } }
        public string GatividhiName_V { get { return _GatividhiName_V; } set { _GatividhiName_V = value; } }
        public string GatividhiPayDuration_V { get { return _GatividhiPayDuration_V; } set { _GatividhiPayDuration_V = value; } }
        public string GatividhiBhavan_V { get { return _GatividhiBhavan_V; } set { _GatividhiBhavan_V = value; } }

        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }
        public int GatividhiPayDuration_I { get { return _GatividhiPayDuration_I; } set { _GatividhiPayDuration_I = value; } }


        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building004_GatividhiMasterSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mGatividhiTrno_I", GatividhiTrno_I);
                obDbaccess.addParam("mGatividhiName_V", GatividhiName_V);
                obDbaccess.addParam("mGatividhiPayDuration_V", GatividhiPayDuration_V);
                obDbaccess.addParam("mGatividhiPayDuration_I", GatividhiPayDuration_I);
                obDbaccess.addParam("mGatividhiBhavan_V", GatividhiBhavan_V);
                obDbaccess.addParam("mGatividhiBhavanTrno_I", GatividhiBhavanTrno_I);
                obDbaccess.addParam("mRemark_V", Remark_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }

        public System.Data.DataSet Select()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building004_GatividhiMasterLoad", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mGatividhiTrno_I", GatividhiTrno_I);
                ds = obDbaccess.records();
            }


            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }

        public int Delete(int id)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_Building004_GatividhiMasterDelete", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGatividhiTrno_I", id);
                i = obDbAccess.executeMyQuery();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;
        }

        #endregion
    }
}
