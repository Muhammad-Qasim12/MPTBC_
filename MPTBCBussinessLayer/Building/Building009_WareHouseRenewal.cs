using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Building009_WareHouseRenewal : ICommon
    {
        int _TrNO, _RenewStatus;

        DateTime _BildingAprrovedDate;
        string _BildingRemark,
                 _RenewalNO,
                 _RenewFile;

        public int TrNO { get { return _TrNO; } set { _TrNO = value; } }
        public DateTime BildingAprrovedDate { get { return _BildingAprrovedDate; } set { _BildingAprrovedDate = value; } }
        public string BildingRemark { get { return _BildingRemark; } set { _BildingRemark = value; } }
        public string RenewalNO { get { return _RenewalNO; } set { _RenewalNO = value; } }
        public int RenewStatus { get { return _RenewStatus; } set { _RenewStatus = value; } }
        public string RenewFile { get { return _RenewFile; } set { _RenewFile = value; } }







        #region ICommon Members

        public int InsertUpdate()
        {
            DBAccess obDbaccess = new DBAccess();
            int i=0;
            try
            {
                obDbaccess.execute("USP_Building001_WareHouseRenewalSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTrNO", TrNO);
                obDbaccess.addParam("mBildingAprrovedDate", BildingAprrovedDate);
                obDbaccess.addParam("mBildingRemark", BildingRemark);
                obDbaccess.addParam("mRenewalNO", RenewalNO);
                obDbaccess.addParam("mRenewStatus", RenewStatus);
                obDbaccess.addParam("mRenewFile", RenewFile);

                i = obDbaccess.executeMyQuery();
            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }

            return i;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                obDbaccess.execute("USP_Building001_WarehouseRenewalLoad", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mRenewStatus",RenewStatus );
                obDbaccess.addParam("mDepoTrno_I", TrNO);
                
                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }

            return ds;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
