using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public   class TransportDetails : ICommon 
    {
        private int _TransportDetailsID_I;
        private int _TransportID_I;
        private int _BlockID_I;
        private double _FullTruckRate_N;
        private double _HalfTruckRate_N;
        private double _RatePerBundle_N;
        private int _TransID_I;
        private int _UserID_I;
    private string  _DistrictID;
    private string _DepoID;
    private string _DistType;
    private string _FyID;
    int _depotypea;

    public string DistType { get { return _DistType; } set { _DistType = value; } }
    public string DistrictID { get { return _DistrictID; } set { _DistrictID = value; } }

    public string DepoID { get { return _DepoID; } set { _DepoID = value; } }
    public string FyID { get { return _FyID; } set { _FyID = value; } }
   
     public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }

     public int depotypea { get { return _depotypea; } set { _depotypea = value; } }

        public int TransID_I { get { return _TransID_I; } set { _TransID_I = value; } }
        public int TransportDetailsID_I { get { return _TransportDetailsID_I; } set { _TransportDetailsID_I = value; } }
        public int TransportID_I { get { return _TransportID_I; } set { _TransportID_I = value; } }
        public int BlockID_I { get { return _BlockID_I; } set { _BlockID_I = value; } }
        public double FullTruckRate_N { get { return _FullTruckRate_N; } set { _FullTruckRate_N = value; } }
        public double HalfTruckRate_N { get { return _HalfTruckRate_N; } set { _HalfTruckRate_N = value; } }
        public double RatePerBundle_N { get { return _RatePerBundle_N; } set { _RatePerBundle_N = value; } }


        public System.Data.DataSet DistAndBolck()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_BLOCKDistiLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("distID",UserID_I );
            obDBAccess.addParam("id", TransportID_I);
            return obDBAccess.records();
        }
        public System.Data.DataSet FillFyyear()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM015_AcadmicYearLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mId",TransportID_I);
            return obDBAccess.records();
        }
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT003_TrnasportDetails_Save", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("DTransportDetailsID_I", TransportDetailsID_I);
            obDBAccess.addParam("TransportID_I", TransportID_I);
            obDBAccess.addParam("BlockID_I", BlockID_I);
            obDBAccess.addParam("FullTruckRate_N", FullTruckRate_N);
            obDBAccess.addParam("HalfTruckRate_N", HalfTruckRate_N);
            obDBAccess.addParam("RatePerBundle_N", RatePerBundle_N);
            obDBAccess.addParam("TransID_I", TransID_I);
            obDBAccess.addParam("DistrictID", DistrictID);
            obDBAccess.addParam("DepoID", DepoID);
            obDBAccess.addParam("DistType", DistType);
            obDBAccess.addParam("FyID", FyID);
            obDBAccess.addParam("depotypea", depotypea);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT003_TransportDetails_Load", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", TransportDetailsID_I);
            obDBAccess.addParam("UID", UserID_I);
            obDBAccess.addParam("mTransportID_I", TransportID_I);
            obDBAccess.addParam("mFyID", FyID);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DPT003_TransportDetails_Delete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", id);
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}
