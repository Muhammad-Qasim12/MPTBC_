using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace MPTBCBussinessLayer
{
    public class Vehicle001_VehicleMaster : ICommon
    {
        int

                _NigamVehicleTrno_I,
                _OfficerName_I,
                _OfficerDesignation_I,

                _MonthlyQuota_I,
                _UserTrno,
                _TenderId_I,
                _TenderParID_I,
                _TenderVehicleTrno_I;

        string

                _VehicleNo_V,
                _VehicleManufacturer_V,
                _VehicleManufactureYear_V,
                _VehicleModelNo_V,
                _VehicleEngineCapacity_V,
                _VehicleChechisNo_V,
                _VehicleFuelType_V,
                _VehicleDriverName_V,
                _VehicleDriverMobileNo_V,
                _OfficerName_V,
                _OfficerDesignation_V,
                _FuleType_V,
                _DriverName_V,
                _DriverContact,
                _Remark_V,
                _VehicleName_V,
                _RoadTAXDetail_V;

        DateTime _AllotedDate_D,
                 _UnallotedDate_D,
                 _VehiclePurchaseDate_D;
        double _VehicleCost_N;




        public int NigamVehicleTrno_I { get { return _NigamVehicleTrno_I; } set { _NigamVehicleTrno_I = value; } }
        public string VehicleNo_V { get { return _VehicleNo_V; } set { _VehicleNo_V = value; } }
        public string VehicleManufacturer_V { get { return _VehicleManufacturer_V; } set { _VehicleManufacturer_V = value; } }
        public string VehicleManufactureYear_V { get { return _VehicleManufactureYear_V; } set { _VehicleManufactureYear_V = value; } }
        public string VehicleModelNo_V { get { return _VehicleModelNo_V; } set { _VehicleModelNo_V = value; } }
        public string VehicleEngineCapacity_V { get { return _VehicleEngineCapacity_V; } set { _VehicleEngineCapacity_V = value; } }
        public string VehicleChechisNo_V { get { return _VehicleChechisNo_V; } set { _VehicleChechisNo_V = value; } }
        public string VehicleFuelType_V { get { return _VehicleFuelType_V; } set { _VehicleFuelType_V = value; } }
        public string VehicleDriverName_V { get { return _VehicleDriverName_V; } set { _VehicleDriverName_V = value; } }
        public string VehicleDriverMobileNo_V { get { return _VehicleDriverMobileNo_V; } set { _VehicleDriverMobileNo_V = value; } }
        public string OfficerName_V { get { return _OfficerName_V; } set { _OfficerName_V = value; } }
        public string OfficerDesignation_V { get { return _OfficerDesignation_V; } set { _OfficerDesignation_V = value; } }
        public int OfficerName_I { get { return _OfficerName_I; } set { _OfficerName_I = value; } }
        public int OfficerDesignation_I { get { return _OfficerDesignation_I; } set { _OfficerDesignation_I = value; } }

        public int MonthlyQuota_I { get { return _MonthlyQuota_I; } set { _MonthlyQuota_I = value; } }

        public int UserTrno { get { return _UserTrno; } set { _UserTrno = value; } }


        public int TenderId_I { get { return _TenderId_I; } set { _TenderId_I = value; } }
        public int TenderParID_I { get { return _TenderParID_I; } set { _TenderParID_I = value; } }

        public string FuleType_V { get { return _FuleType_V; } set { _FuleType_V = value; } }
        public string DriverName_V { get { return _DriverName_V; } set { _DriverName_V = value; } }
        public string DriverContact { get { return _DriverContact; } set { _DriverContact = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public string VehicleName_V { get { return _VehicleName_V; } set { _VehicleName_V = value; } }
        public int TenderVehicleTrno_I { get { return _TenderVehicleTrno_I; } set { _TenderVehicleTrno_I = value; } }


        public DateTime AllotedDate_D { get { return _AllotedDate_D; } set { _AllotedDate_D = value; } }

        public DateTime UnallotedDate_D { get { return _UnallotedDate_D; } set { _UnallotedDate_D = value; } }


        public DateTime VehiclePurchaseDate_D { get { return _VehiclePurchaseDate_D; } set { _VehiclePurchaseDate_D = value; } }
        public double VehicleCost_N { get { return _VehicleCost_N; } set { _VehicleCost_N = value; } }
        public string RoadTAXDetail_V { get { return _RoadTAXDetail_V; } set { _RoadTAXDetail_V = value; } }

        public int TenderVehicleSaveUpdate()
        {

            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle001_tenderVehicleSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenderVehicleTrno_I", TenderVehicleTrno_I);

                obDbaccess.addParam("mTenderId_I", TenderId_I);
                obDbaccess.addParam("mTenderParID_I", TenderParID_I);
                obDbaccess.addParam("mVehicleNo_V", VehicleNo_V);
                obDbaccess.addParam("mFuleType_V", FuleType_V);
                obDbaccess.addParam("mDriverName_V", DriverName_V);
                obDbaccess.addParam("mDriverContact", DriverContact);
                obDbaccess.addParam("mRemark_V", Remark_V);
                obDbaccess.addParam("mVehicleName_V", VehicleName_V);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }

        public DataSet TenderVehicleDropDownLoad()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Vehicle001_TenderVehicleDropDownLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderId_I", TenderId_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }

        public DataSet TenderVehicleLoad()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Vehicle001_TenderVehicleLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderVehicleTrno_I", TenderVehicleTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        public int TenderVehicleAllotmenrSaveUpdate()
        {

            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle001_TenderVehicleAllotment", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderVehicleTrno_I", TenderVehicleTrno_I);
                obDbaccess.addParam("mAllotedOfficerNAme_V", OfficerName_V);
                obDbaccess.addParam("mAllotedOfficerTrno_I", OfficerName_I);
                obDbaccess.addParam("mOfficerDesignation_V", OfficerDesignation_V);
                obDbaccess.addParam("mOfficerDesignation_I", OfficerDesignation_I);
                obDbaccess.addParam("mAllotedDate_D", AllotedDate_D);
                
                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }



        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle001_NigamVehicleSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mNigamVehicleTrno_I", NigamVehicleTrno_I);
                obDbaccess.addParam("mVehicleNo_V", VehicleNo_V);
                obDbaccess.addParam("mVehicleManufacturer_V", VehicleManufacturer_V);
                obDbaccess.addParam("mVehicleManufactureYear_V", VehicleManufactureYear_V);
                obDbaccess.addParam("mVehicleModelNo_V", VehicleModelNo_V);
                obDbaccess.addParam("mVehicleEngineCapacity_V", VehicleEngineCapacity_V);
                obDbaccess.addParam("mVehicleChechisNo_V", VehicleChechisNo_V);
                obDbaccess.addParam("mVehicleFuelType_V", VehicleFuelType_V);
                obDbaccess.addParam("mVehicleDriverName_V", VehicleDriverName_V);
                obDbaccess.addParam("mVehicleDriverMobileNo_V", VehicleDriverMobileNo_V);
                obDbaccess.addParam("mOfficerName_V", OfficerName_V);

                obDbaccess.addParam("mOfficerDesignation_V", OfficerDesignation_V);
                obDbaccess.addParam("mOfficerName_I", OfficerName_I);
                obDbaccess.addParam("mOfficerDesignation_I", OfficerDesignation_I);
                obDbaccess.addParam("mMonthlyQuota_I", MonthlyQuota_I);
                obDbaccess.addParam("mUserTrno", UserTrno);

                obDbaccess.addParam("mVehiclePurchaseDate_D", VehiclePurchaseDate_D);
                obDbaccess.addParam("mVehicleCost_N", VehicleCost_N);
                obDbaccess.addParam("mRoadTAXDetail_V", RoadTAXDetail_V);

                i = Convert.ToInt32(obDbaccess.executeMyScalar());
                return i;


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

                obDbaccess.execute("USP_Vehicle001_NigamVehicleLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mNigamVehicleTrno_I", NigamVehicleTrno_I);

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
