using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Building008_Voucher : ICommon
    {
        string
               _DepartmentName_V,
               _DeyakNo_V,
               _LekhaSheersh_V,
               _Mad_V,
               _PartyName_V,
               _PayMode_V,
               _PartyBillNo_V,
               _NotsheetFile_V,
               _OfficerName_V,
               _Designation_V,
               _NigamOrderNo_V;

        double

        _TotalBudjut_N,
        _PreviousBillAmount_N,
        _SanctionedAmount_N,
        _SamayojanAmount_N,
        _PayAmount_N,
        _SanctionedAmountByBranchOfficer_N;

        int
            _mVoucherTrno_I,
        _PartyTrno_I,
        _OfficerTrno_I,
        _DesignationTrno_I,
        _UserTrno_I,
        _BillPayTrno_I;


        DateTime

        _PartyBillDate_D,
        _NigamOrderDate_D;



        public int VoucherTrno_I { get { return _mVoucherTrno_I; } set { _mVoucherTrno_I = value; } }

        public string DepartmentName_V { get { return _DepartmentName_V; } set { _DepartmentName_V = value; } }
        public string DeyakNo_V { get { return _DeyakNo_V; } set { _DeyakNo_V = value; } }
        public string LekhaSheersh_V { get { return _LekhaSheersh_V; } set { _LekhaSheersh_V = value; } }
        public string Mad_V { get { return _Mad_V; } set { _Mad_V = value; } }
        public double TotalBudjut_N { get { return _TotalBudjut_N; } set { _TotalBudjut_N = value; } }
        public double PreviousBillAmount_N { get { return _PreviousBillAmount_N; } set { _PreviousBillAmount_N = value; } }
        public string PartyName_V { get { return _PartyName_V; } set { _PartyName_V = value; } }
        public int PartyTrno_I { get { return _PartyTrno_I; } set { _PartyTrno_I = value; } }
        public string PayMode_V { get { return _PayMode_V; } set { _PayMode_V = value; } }
        public double SanctionedAmount_N { get { return _SanctionedAmount_N; } set { _SanctionedAmount_N = value; } }
        public double SamayojanAmount_N { get { return _SamayojanAmount_N; } set { _SamayojanAmount_N = value; } }
        public double PayAmount_N { get { return _PayAmount_N; } set { _PayAmount_N = value; } }
        public string PartyBillNo_V { get { return _PartyBillNo_V; } set { _PartyBillNo_V = value; } }
        public DateTime PartyBillDate_D { get { return _PartyBillDate_D; } set { _PartyBillDate_D = value; } }
        public string NigamOrderNo_V { get { return _NigamOrderNo_V; } set { _NigamOrderNo_V = value; } }
        public DateTime NigamOrderDate_D { get { return _NigamOrderDate_D; } set { _NigamOrderDate_D = value; } }
        public string NotsheetFile_V { get { return _NotsheetFile_V; } set { _NotsheetFile_V = value; } }
        public string OfficerName_V { get { return _OfficerName_V; } set { _OfficerName_V = value; } }
        public int OfficerTrno_I { get { return _OfficerTrno_I; } set { _OfficerTrno_I = value; } }
        public int DesignationTrno_I { get { return _DesignationTrno_I; } set { _DesignationTrno_I = value; } }
        public string Designation_V { get { return _Designation_V; } set { _Designation_V = value; } }
        public double SanctionedAmountByBranchOfficer_N { get { return _SanctionedAmountByBranchOfficer_N; } set { _SanctionedAmountByBranchOfficer_N = value; } }
        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }
        public int BillPayTrno_I { get { return _BillPayTrno_I; } set { _BillPayTrno_I = value; } }



        public DataSet VoucherDetailsLoadBillID()
        {
            DataSet ds = new DataSet();
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building008_VoucherLoadBillIdWise", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mBillPayTrno_I", BillPayTrno_I);
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
                obDbaccess.execute("USP_Building008_VoucherSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mVoucherTrno_I", VoucherTrno_I);

                obDbaccess.addParam("mDepartmentName_V", DepartmentName_V);
                obDbaccess.addParam("mDeyakNo_V", DeyakNo_V);
                obDbaccess.addParam("mLekhaSheersh_V", LekhaSheersh_V);
                obDbaccess.addParam("mMad_V", Mad_V);
                obDbaccess.addParam("mTotalBudjut_N", TotalBudjut_N);
                obDbaccess.addParam("mPreviousBillAmount_N", PreviousBillAmount_N);
                obDbaccess.addParam("mPartyName_V", PartyName_V);
                obDbaccess.addParam("mPartyTrno_I", PartyTrno_I);
                obDbaccess.addParam("mPayMode_V", PayMode_V);
                obDbaccess.addParam("mSanctionedAmount_N", SanctionedAmount_N);
                obDbaccess.addParam("mSamayojanAmount_N", SamayojanAmount_N);
                obDbaccess.addParam("mPayAmount_N", PayAmount_N);
                obDbaccess.addParam("mPartyBillNo_V", PartyBillNo_V);
                obDbaccess.addParam("mPartyBillDate_D", PartyBillDate_D);
                obDbaccess.addParam("mNigamOrderNo_V", NigamOrderNo_V);
                obDbaccess.addParam("mNigamOrderDate_D", NigamOrderDate_D);
                obDbaccess.addParam("mNotsheetFile_V", NotsheetFile_V);
                obDbaccess.addParam("mOfficerName_V", OfficerName_V);
                obDbaccess.addParam("mOfficerTrno_I", OfficerTrno_I);
                obDbaccess.addParam("mDesignationTrno_I", DesignationTrno_I);
                obDbaccess.addParam("mDesignation_V", Designation_V);
                obDbaccess.addParam("mSanctionedAmountByBranchOfficer_N", SanctionedAmountByBranchOfficer_N);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);

                obDbaccess.addParam("mBillPayTrno_I", BillPayTrno_I);
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

                obDbaccess.execute("USP_Building008_VoucherLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mVoucherTrno_I", VoucherTrno_I);

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
