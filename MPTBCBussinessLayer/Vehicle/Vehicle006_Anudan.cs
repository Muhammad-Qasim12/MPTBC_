using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace MPTBCBussinessLayer
{
    public class Vehicle006_Anudan : ICommon
    {
        int
            _AnudanTrno_I,
            _District_I,
           _UserTrno_I,
            _AnudanDetailsTrno_I

           ;




        string
            _ACYear_V,
            _SchoolName_V,


            _SanctionWork_V,
            _ApprovalJiladhyaksh_V,
            _Sambhag_V,
            _District_V,

            _Tahseel_V,
            _VikasKhand_V,
            _Post_V,
            _OtherDescription_V,

             _LetterNo_V,
             _ChequeNo_V,
             _InstallmentNo_V,
             _Remark_V;




        DateTime

             _SanctionDate_D,
              _ChequeDAte_D,
            _LetterDate_D
            ;




        double
             _SanctionAmount_N,
             _Amount_N;





        public string ACYear_V { get { return _ACYear_V; } set { _ACYear_V = value; } }
        public string SchoolName_V { get { return _SchoolName_V; } set { _SchoolName_V = value; } }
        public double SanctionAmount_N { get { return _SanctionAmount_N; } set { _SanctionAmount_N = value; } }
        public DateTime SanctionDate_D { get { return _SanctionDate_D; } set { _SanctionDate_D = value; } }
        public string SanctionWork_V { get { return _SanctionWork_V; } set { _SanctionWork_V = value; } }
        public string ApprovalJiladhyaksh_V { get { return _ApprovalJiladhyaksh_V; } set { _ApprovalJiladhyaksh_V = value; } }
        public string Sambhag_V { get { return _Sambhag_V; } set { _Sambhag_V = value; } }
        public string District_V { get { return _District_V; } set { _District_V = value; } }
        public int District_I { get { return _District_I; } set { _District_I = value; } }
        public string Tahseel_V { get { return _Tahseel_V; } set { _Tahseel_V = value; } }
        public string VikasKhand_V { get { return _VikasKhand_V; } set { _VikasKhand_V = value; } }
        public string Post_V { get { return _Post_V; } set { _Post_V = value; } }
        public string OtherDescription_V { get { return _OtherDescription_V; } set { _OtherDescription_V = value; } }

        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }

        public string LetterNo_V { get { return _LetterNo_V; } set { _LetterNo_V = value; } }
        public string ChequeNo_V { get { return _ChequeNo_V; } set { _ChequeNo_V = value; } }
        public string InstallmentNo_V { get { return _InstallmentNo_V; } set { _InstallmentNo_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
        public double Amount_N { get { return _Amount_N; } set { _Amount_N = value; } }
        public DateTime ChequeDAte_D { get { return _ChequeDAte_D; } set { _ChequeDAte_D = value; } }
        public DateTime LetterDate_D { get { return _LetterDate_D; } set { _LetterDate_D = value; } }
        public int AnudanTrno_I { get { return _AnudanTrno_I; } set { _AnudanTrno_I = value; } }

        public int AnudanDetailsTrno_I { get { return _AnudanDetailsTrno_I; } set { _AnudanDetailsTrno_I = value; } }









        public DataSet SelectACYEAR()
        {
            DBAccess obDBAccess = new DBAccess();

            obDBAccess.execute("USP_DIB002_DemandfromOthersSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", -1);
            obDBAccess.addParam("mParameterValue", 0);
            obDBAccess.addParam("mParameterValue2", 0);
            
            obDBAccess.addParam("mStringParameterValue", 0);

            return obDBAccess.records();
        }




        public int AnudanDetailsSaveUpdate()
        {
            int i = 0;

            DBAccess obDbAccess = new DBAccess();
            try
            {
                obDbAccess.execute("USP_Vehicle006_AnudanDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAnudanDetailsTrno_I", AnudanDetailsTrno_I);
                obDbAccess.addParam("mAnudanTrno_I", AnudanTrno_I);
                obDbAccess.addParam("mLetterNo_V", LetterNo_V);
                obDbAccess.addParam("mLetterDate_D", LetterDate_D);
                obDbAccess.addParam("mChequeNo_V", ChequeNo_V);
                obDbAccess.addParam("mChequeDAte_D", ChequeDAte_D);
                obDbAccess.addParam("mInstallmentNo_V", InstallmentNo_V);
                obDbAccess.addParam("mAmount_N", Amount_N);
                obDbAccess.addParam("mRemark_V", Remark_V);


                obDbAccess.addParam("mUserTrno_I", UserTrno_I);


                i = obDbAccess.executeMyQuery();

            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return i;

        }


        public DataSet AnudanDetailsLoad()
        {
            DataSet ds = new DataSet();

            DBAccess obDbAccess = new DBAccess();
            try
            {
                obDbAccess.execute("USP_Vehicle006_AnudanDetailsLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAnudanTrno_I", AnudanTrno_I);
                obDbAccess.addParam("mAnudanDetailsTrno_I", AnudanDetailsTrno_I);
                ds = obDbAccess.records();
            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }



        #region ICommon Members

        public int InsertUpdate()
        {
            int i = 0;

            DBAccess obDbAccess = new DBAccess();
            try
            {
                obDbAccess.execute("USP_Vehicle006_AnudanMasterSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAnudanTrno_I", AnudanTrno_I);
                obDbAccess.addParam("mACYear_V", ACYear_V);
                obDbAccess.addParam("mSchoolName_V", SchoolName_V);
                obDbAccess.addParam("mSanctionAmount_N", SanctionAmount_N);
                obDbAccess.addParam("mSanctionDate_D", SanctionDate_D);
                obDbAccess.addParam("mSanctionWork_V", SanctionWork_V);
                obDbAccess.addParam("mApprovalJiladhyaksh_V", ApprovalJiladhyaksh_V);

                obDbAccess.addParam("mSambhag_V", Sambhag_V);

                obDbAccess.addParam("mDistrict_V", District_V);
                obDbAccess.addParam("mDistrict_I", District_I);

                obDbAccess.addParam("mTahseel_V", Tahseel_V);
                obDbAccess.addParam("mVikasKhand_V", VikasKhand_V);
                obDbAccess.addParam("mPost_V", Post_V);
                obDbAccess.addParam("mOtherDescription_V", OtherDescription_V);

                obDbAccess.addParam("mUserTrno_I", UserTrno_I);
                i = Convert.ToInt32(obDbAccess.executeMyScalar());

            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return i;

        }

        public DataSet Select()
        {
            DataSet ds = new DataSet();

            DBAccess obDbAccess = new DBAccess();
            try
            {
                obDbAccess.execute("USP_Vehicle006_AnudanMasterLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAnudanTrno_I", AnudanTrno_I);
                obDbAccess.addParam("mACYear_V", ACYear_V);
                obDbAccess.addParam("mDistrict_I", District_I);


                ds = obDbAccess.records();
            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }





        public int Delete(int id)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_Vehicle006_AnudanDetailsDelete", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mAnudanDetailsTrno_I", id);

                i = obDbAccess.executeMyQuery();
            }
            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;
        }

        #endregion
    }
}
