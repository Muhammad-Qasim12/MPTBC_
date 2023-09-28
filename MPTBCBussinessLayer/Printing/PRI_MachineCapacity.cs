using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class PRI_MachineCapacity:ICommon 
    {
        string _ACYear_V;

        int _MachineCapID_I, _Printer_RedID_I, _UserTrno_I, _MachineID_I;
        double _OneColor_N, _TwoColor_N, _FourColor_N;

        public int MachineCapID_I { get { return _MachineCapID_I; } set { _MachineCapID_I = value; } }
        public int Printer_RedID_I { get { return _Printer_RedID_I; } set { _Printer_RedID_I = value; } }
        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }
        public int MachineID_I { get { return _MachineID_I; } set { _MachineID_I = value; } }
        
        public double OneColor_N { get { return _OneColor_N; } set { _OneColor_N = value; } }
        public double TwoColor_N { get { return _TwoColor_N; } set { _TwoColor_N = value; } }
        public double FourColor_N { get { return _FourColor_N; } set { _FourColor_N = value; } }

        public string ACYear_V { get { return _ACYear_V; } set { _ACYear_V = value; } }
        
        #region ICommon Members

        public int InsertUpdate()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;

            try
            {
                obDbAccess.execute("USP_PRI004_PrinterMachineCapacitySaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mMachineCapID_I", MachineCapID_I);
                obDbAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
                obDbAccess.addParam("mAcYear_V", ACYear_V);
                obDbAccess.addParam("mOneColor_N", OneColor_N);
                obDbAccess.addParam("mTwoColor_N", TwoColor_N);
                obDbAccess.addParam("mFourColor_N",FourColor_N);
                obDbAccess.addParam("mUserTrno_I", UserTrno_I);
                obDbAccess.addParam("mMachineID_I", MachineID_I);

                i = obDbAccess.executeMyQuery();

            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return i;
        }

        public DataSet Select()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_PRI004_PrinterMachineCapacityLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mACYear_V", ACYear_V);
                ds = obDbAccess.records();
            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
