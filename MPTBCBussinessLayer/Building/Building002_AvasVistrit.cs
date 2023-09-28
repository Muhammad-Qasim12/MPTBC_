using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Building002_AvasVistrit : ICommon
    {

        int
            _AvasVistritTrno_I,
            _AvasMasterTrno_I,
              _AreaUnit_I,
              _DistrictTrno_I,
              _ResidenceType_I,
              _UserTrno_I
              ,
                _BuildingArea_I,
                _BuildingAreaUnitTrno_I,
                _OtherAvasTrno_I
              ;
        string _AvasNo_V,
                _Zone_V,
                _WardNo_V,
                _AreaDes_V,
                _PayScale_V,
                _Remark_V,
                _AvasName_V,
                _BuildingType_V,
                _AvasAddress_V,

                _ContactPerson_V,
                _ContactNo_V,

                _PurchaseFromWhome_V,
                _EstimateApprovedBy_V,
                _RegistryFile_V,
                _BuildingStatus_V
              ;

        double _Area_N,
                _Rent45A_N,
                _Rent45B_N,
                _IllegalRent_N,
                _RentAmount_N,
                _BuildingPurchasingCost_N;

        DateTime _BuildingPossesionDate_D;






        public int AvasVistritTrno_I { get { return _AvasVistritTrno_I; } set { _AvasVistritTrno_I = value; } }
        public int AvasMasterTrno_I { get { return _AvasMasterTrno_I; } set { _AvasMasterTrno_I = value; } }
        public double Area_N { get { return _Area_N; } set { _Area_N = value; } }
        public int AreaUnit_I { get { return _AreaUnit_I; } set { _AreaUnit_I = value; } }
        public string AvasNo_V { get { return _AvasNo_V; } set { _AvasNo_V = value; } }
        public string Zone_V { get { return _Zone_V; } set { _Zone_V = value; } }
        public string WardNo_V { get { return _WardNo_V; } set { _WardNo_V = value; } }
        public string AreaDes_V { get { return _AreaDes_V; } set { _AreaDes_V = value; } }
        public int DistrictTrno_I { get { return _DistrictTrno_I; } set { _DistrictTrno_I = value; } }
        public string PayScale_V { get { return _PayScale_V; } set { _PayScale_V = value; } }
        public double Rent45A_N { get { return _Rent45A_N; } set { _Rent45A_N = value; } }
        public double Rent45B_N { get { return _Rent45B_N; } set { _Rent45B_N = value; } }
        public double IllegalRent_N { get { return _IllegalRent_N; } set { _IllegalRent_N = value; } }
        public double RentAmount_N { get { return _RentAmount_N; } set { _RentAmount_N = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public int ResidenceType_I { get { return _ResidenceType_I; } set { _ResidenceType_I = value; } }

        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }


        public int OtherAvasTrno_I { get { return _OtherAvasTrno_I; } set { _OtherAvasTrno_I = value; } }


        public string AvasName_V { get { return _AvasName_V; } set { _AvasName_V = value; } }
        public string BuildingType_V { get { return _BuildingType_V; } set { _BuildingType_V = value; } }
        public string AvasAddress_V { get { return _AvasAddress_V; } set { _AvasAddress_V = value; } }

        public int BuildingArea_I { get { return _BuildingArea_I; } set { _BuildingArea_I = value; } }
        public int BuildingAreaUnitTrno_I { get { return _BuildingAreaUnitTrno_I; } set { _BuildingAreaUnitTrno_I = value; } }
        public string ContactPerson_V { get { return _ContactPerson_V; } set { _ContactPerson_V = value; } }
        public string ContactNo_V { get { return _ContactNo_V; } set { _ContactNo_V = value; } }


        public DateTime BuildingPossesionDate_D { get { return _BuildingPossesionDate_D; } set { _BuildingPossesionDate_D = value; } }
        public double BuildingPurchasingCost_N { get { return _BuildingPurchasingCost_N; } set { _BuildingPurchasingCost_N = value; } }
        public string PurchaseFromWhome_V { get { return _PurchaseFromWhome_V; } set { _PurchaseFromWhome_V = value; } }
        public string EstimateApprovedBy_V { get { return _EstimateApprovedBy_V; } set { _EstimateApprovedBy_V = value; } }
        public string RegistryFile_V { get { return _RegistryFile_V; } set { _RegistryFile_V = value; } }
        public string BuildingStatus_V { get { return _BuildingStatus_V; } set { _BuildingStatus_V = value; } }



        public DataSet RPTAvasVistritLoad()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Building001_RPTAvasVistritLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mZone_V", Zone_V);
                obDbaccess.addParam("mAvasType_V", AvasAddress_V);
                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
                obDbaccess.addParam("mPayScale_V", PayScale_V);
                obDbaccess.addParam("mDistrictTrno_I", DistrictTrno_I);

                ds = obDbaccess.records();
            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }

        public System.Data.DataSet AvasTitleSelect()
        {

            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_building001_AvasMasterLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;

        }


        public DataSet OtherAvasLoad()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Building002_OtherAvasLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mOtherAvasTrno_I", OtherAvasTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;

        }



        public int OtherAvasInsertUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building003_OtherAvasSaveUpdate", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mOtherAvasTrno_I", OtherAvasTrno_I);
                obDbaccess.addParam("mAvasName_V", AvasName_V);
                obDbaccess.addParam("mBuildingType_V", BuildingType_V);
                obDbaccess.addParam("mAvasAddress_V", AvasAddress_V);
                obDbaccess.addParam("mDistrictTrno_I", DistrictTrno_I);
                obDbaccess.addParam("mBuildingArea_I", BuildingArea_I);
                obDbaccess.addParam("mBuildingAreaUnitTrno_I", BuildingAreaUnitTrno_I);
                obDbaccess.addParam("mContactPerson_V", ContactPerson_V);
                obDbaccess.addParam("mContactNo_V", ContactNo_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);
                obDbaccess.addParam("mResidenceType_I", ResidenceType_I);
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

                obDbaccess.execute("USP_Building002_AvasVistritSaveUpdate", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mAvasVistritTrno_I", AvasVistritTrno_I);
                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);
                obDbaccess.addParam("mArea_N", Area_N);
                obDbaccess.addParam("mAreaUnit_I", AreaUnit_I);
                obDbaccess.addParam("mAvasNo_V", AvasNo_V);
                obDbaccess.addParam("mZone_V", Zone_V);
                obDbaccess.addParam("mWardNo_V", WardNo_V);
                obDbaccess.addParam("mAreaDes_V", AreaDes_V);
                obDbaccess.addParam("mDistrictTrno_I", DistrictTrno_I);
                obDbaccess.addParam("mPayScale_V", PayScale_V);
                obDbaccess.addParam("mRent45A_N", Rent45A_N);
                obDbaccess.addParam("mRent45B_N", Rent45B_N);
                obDbaccess.addParam("mIllegalRent_N", IllegalRent_N);
                obDbaccess.addParam("mRentAmount_N", RentAmount_N);
                obDbaccess.addParam("mRemark_V", Remark_V);
                obDbaccess.addParam("mResidenceType_I", ResidenceType_I);

                obDbaccess.addParam("mBuildingPossesionDate_D", BuildingPossesionDate_D);
                obDbaccess.addParam("mBuildingPurchasingCost_N", BuildingPurchasingCost_N);
                obDbaccess.addParam("mPurchaseFromWhome_V", PurchaseFromWhome_V);
                obDbaccess.addParam("mEstimateApprovedBy_V", EstimateApprovedBy_V);
                obDbaccess.addParam("mRegistryFile_V", RegistryFile_V);
                obDbaccess.addParam("mBuildingStatus_V", BuildingStatus_V);
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

                obDbaccess.execute("USP_Building002_AvasVistritLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mAvasVistritTrno_I", AvasVistritTrno_I);

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
                obDbAccess.execute("USP_Building002_AvasVistritDelete", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAvasVistritTrno_I", id);
                i = obDbAccess.executeMyQuery();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;
        }

        #endregion
    }
}