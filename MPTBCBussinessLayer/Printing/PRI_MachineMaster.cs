using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
    public class PRI_MachineMaster : ICommon
    {

        private int _MachineID_I;
        private string _MachineType_V, _MachineSize_V, _MachineCat_V, _MacPrintCapOneColor_V,
                       _MacPrintCapTwoColor_V, _MacPrintCapFourColor_V;



        public int MachineID_I { get { return _MachineID_I; } set { _MachineID_I = value; } }
        public string MachineType_V { get { return _MachineType_V; } set { _MachineType_V = value; } }
        public string MachineSize_V { get { return _MachineSize_V; } set { _MachineSize_V = value; } }
        public string MachineCat_V { get { return _MachineCat_V; } set { _MachineCat_V = value; } }
        public string MacPrintCapOneColor_V { get { return _MacPrintCapOneColor_V; } set { _MacPrintCapOneColor_V = value; } }
        public string MacPrintCapTwoColor_V { get { return _MacPrintCapTwoColor_V; } set { _MacPrintCapTwoColor_V = value; } }
        public string MacPrintCapFourColor_V { get { return _MacPrintCapFourColor_V; } set { _MacPrintCapFourColor_V = value; } }








        #region ICommon Members

        public int InsertUpdate()
        {
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_MachineMasterSave", DBAccess.SQLType.IS_PROC);
            obj.addParam("mMachineID_I", MachineID_I);
            obj.addParam("mMachineType_V", MachineType_V);
            obj.addParam("mMachineSize_V", MachineSize_V);
            obj.addParam("mMachineCat_V", MachineCat_V);
            obj.addParam("mMacPrintCapOneColor_V", MacPrintCapOneColor_V);
            obj.addParam("mMacPrintCapTwoColor_V", MacPrintCapTwoColor_V);
            obj.addParam("mMacPrintCapFourColor_V", MacPrintCapFourColor_V);

            int i = obj.executeMyQuery();

            return i;
        }

        public DataSet Select()
        {
            DataSet ds = new DataSet();
            DBAccess obj = new DBAccess();

            obj.execute("USP_PRI001_MachineMasterLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("ID", MachineID_I);
            ds = obj.records();

            if (ds.Tables[0].Rows.Count > 0)
            {
                MachineID_I = Convert.ToInt32(ds.Tables[0].Rows[0]["MachineID_I"]);
                MachineType_V = Convert.ToString(ds.Tables[0].Rows[0]["MachineType_V"]);
                MachineCat_V = Convert.ToString(ds.Tables[0].Rows[0]["MachineCat_V"]);
                MacPrintCapOneColor_V = Convert.ToString(ds.Tables[0].Rows[0]["MacPrintCapOneColor_V"]);
                MacPrintCapTwoColor_V = Convert.ToString(ds.Tables[0].Rows[0]["MacPrintCapTwoColor_V"]);
                MacPrintCapFourColor_V = Convert.ToString(ds.Tables[0].Rows[0]["MacPrintCapFourColor_V"]);

            }


            return ds;
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
