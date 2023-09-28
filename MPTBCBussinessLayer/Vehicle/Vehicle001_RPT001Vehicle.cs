using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer.Vehicle
{
    public class Vehicle001_RPT001Vehicle : ICommon
    {

        string
            _ACYear_V;
        int _DistrictTrno_I;

        public string ACYear_V { get { return _ACYear_V; } set { _ACYear_V = value; } }
        public int  DistrictTrno_I { get { return _DistrictTrno_I; } set { _DistrictTrno_I = value; } }

        public DataSet LoadAnudan()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Vehicle001_RPTAnudan", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mACYear_V", ACYear_V);
                obDbaccess.addParam("mDistrictTrno_I", DistrictTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }

        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
