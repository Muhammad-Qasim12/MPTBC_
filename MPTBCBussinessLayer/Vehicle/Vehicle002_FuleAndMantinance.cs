using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Vehicle002_FuleAndMantinance : ICommon
    {
        int
              _FuelVyayTrno_I,
               _UserTrno,

              _VehicleNo_I,
              _VyayType_I,

              _MantinaceTrno_I,
              _TenderParID_I
              ;


        double

              _Coolend_I,
              _VyayQuota_N,
              _VyayDoura_N,
              _Survoil_N,
              _STP_I,
              _BreakOil_I,
              _TotalExpance_N,
              _Quantity_N,
              _Rate_N,

              _DeyakAmount_N,

              _2PerIncomeTax_N,
              _OtherTaxes_N
              ;


        DateTime
              _VyayDate_D;
        string
              _VehicleNo_V,
              _ReceiptNo_V,
              _ReceiptFile_V,

              _Remark_V,
              _VyayType_V,
              _TaxDescription_V,
              _WorkDescription_V,
              _NameOfParty,
              _BillNO_V
              ;







        public int FuelVyayTrno_I { get { return _FuelVyayTrno_I; } set { _FuelVyayTrno_I = value; } }
        public DateTime VyayDate_D { get { return _VyayDate_D; } set { _VyayDate_D = value; } }
        public int VehicleNo_I { get { return _VehicleNo_I; } set { _VehicleNo_I = value; } }
        public string VehicleNo_V { get { return _VehicleNo_V; } set { _VehicleNo_V = value; } }
        public int VyayType_I { get { return _VyayType_I; } set { _VyayType_I = value; } }
        public double VyayQuota_N { get { return _VyayQuota_N; } set { _VyayQuota_N = value; } }
        public double VyayDoura_N { get { return _VyayDoura_N; } set { _VyayDoura_N = value; } }
        public double Survoil_N { get { return _Survoil_N; } set { _Survoil_N = value; } }
        public double Coolend_I { get { return _Coolend_I; } set { _Coolend_I = value; } }
        public double STP_I { get { return _STP_I; } set { _STP_I = value; } }
        public double BreakOil_I { get { return _BreakOil_I; } set { _BreakOil_I = value; } }
        public double Quantity_N { get { return _Quantity_N; } set { _Quantity_N = value; } }
        public double Rate_N { get { return _Rate_N; } set { _Rate_N = value; } }


        public string ReceiptNo_V { get { return _ReceiptNo_V; } set { _ReceiptNo_V = value; } }
        public string ReceiptFile_V { get { return _ReceiptFile_V; } set { _ReceiptFile_V = value; } }

        public double TotalExpance_N { get { return _TotalExpance_N; } set { _TotalExpance_N = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public string VyayType_V { get { return _VyayType_V; } set { _VyayType_V = value; } }

        public int UserTrno { get { return _UserTrno; } set { _UserTrno = value; } }

        public int MantinaceTrno_I { get { return _MantinaceTrno_I; } set { _MantinaceTrno_I = value; } }
        public double DeyakAmount_N { get { return _DeyakAmount_N; } set { _DeyakAmount_N = value; } }

        public double PerIncomeTax_N { get { return _2PerIncomeTax_N; } set { _2PerIncomeTax_N = value; } }
        public string WorkDescription_V { get { return _WorkDescription_V; } set { _WorkDescription_V = value; } }
        public double OtherTaxes_N { get { return _OtherTaxes_N; } set { _OtherTaxes_N = value; } }
        public string TaxDescription_V { get { return _TaxDescription_V; } set { _TaxDescription_V = value; } }

        public string NameOfParty { get { return _NameOfParty; } set { _NameOfParty = value; } }
        public string BillNO_V { get { return _BillNO_V; } set { _BillNO_V = value; } }

        public int TenderParID_I { get { return _TenderParID_I; } set { _TenderParID_I = value; } }







        public int SaveUpdateMantinance()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle004_MantinanceVyaySaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mMantinaceTrno_I", MantinaceTrno_I);
                obDbaccess.addParam("mVyayDate_d", VyayDate_D);
                obDbaccess.addParam("mVehicleNo_I", VehicleNo_I);
                obDbaccess.addParam("mVehicleNo_V", VehicleNo_V);
                obDbaccess.addParam("mDeyakAmount_N", DeyakAmount_N);
                obDbaccess.addParam("mReceiptFile_V", ReceiptFile_V);
                obDbaccess.addParam("m2PerIncomeTax_N", PerIncomeTax_N);
                obDbaccess.addParam("mWorkDescription_V", WorkDescription_V);
                obDbaccess.addParam("mOtherTaxes_N", OtherTaxes_N);
                obDbaccess.addParam("mTaxDescription_V", TaxDescription_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno);

                obDbaccess.addParam("mNameOfParty", NameOfParty);
                obDbaccess.addParam("mTenderParID_I", TenderParID_I);

                obDbaccess.addParam("mBillNO_V", BillNO_V);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }




        public DataSet LoadMantinance() 
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Vehicle004_MantinaceVyayLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mMantinaceTrno_I", MantinaceTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        
        }

        public DataSet LoadParty()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Vehicle004_MantanancePartyLoad", DBAccess.SQLType.IS_PROC);

              

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;

        }


        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Vehicle003_FuleVyaySaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mFuelVyayTrno_I", FuelVyayTrno_I);
                obDbaccess.addParam("mVyayDate_D", VyayDate_D);
                obDbaccess.addParam("mVehicleNo_I", VehicleNo_I);
                obDbaccess.addParam("mVehicleNo_V", VehicleNo_V);
                obDbaccess.addParam("mVyayType_I", VyayType_I);
                obDbaccess.addParam("mVyayQuota_N", VyayQuota_N);
                obDbaccess.addParam("mVyayDoura_N", VyayDoura_N);
                obDbaccess.addParam("mSurvoil_N", Survoil_N);
                obDbaccess.addParam("mCoolend_I", Coolend_I);
                obDbaccess.addParam("mSTP_I", STP_I);
                obDbaccess.addParam("mBreakOil_I", BreakOil_I);
                obDbaccess.addParam("mReceiptNo_V", ReceiptNo_V);
                obDbaccess.addParam("mReceiptFile_V", ReceiptFile_V);
                obDbaccess.addParam("mTotalExpance_N", TotalExpance_N);
                obDbaccess.addParam("mRemark_V", Remark_V);
                obDbaccess.addParam("mUserTrno", UserTrno);
                obDbaccess.addParam("mQuantity_N", Quantity_N);
                obDbaccess.addParam("mRate_N", Rate_N);
                obDbaccess.addParam("mVyayType_V", VyayType_V);



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

                obDbaccess.execute("USP_Vehicle003_FuelVyayLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mFuelVyayTrno_I", FuelVyayTrno_I);

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
