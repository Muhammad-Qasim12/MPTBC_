using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace MPTBCBussinessLayer
{
    public class TenderDetails : ICommon
    {
        private Int32 _TenderId_I;
        private string _AcdmicYr_V;
        private string _TenderType_V;
        private string _TenderNo_V;
        private DateTime _TenderDate_D;
        private string _LUNSendNo_V;
        private DateTime _LUNDate_D;
        private DateTime _NITDate_D;
        private Decimal _TenderDocFee_N;
        private DateTime _TenderSubmissionDate_D;
        private DateTime _TechBidopeningDate_D;
        private DateTime _CommecialBidOpeningdate_D;
        private DateTime _Transdate_D;
        private Int32 _UserID_I;
        private Int32 _LID;
        private Int32 _TenDetid_I;
        private Int32 _GrpID_I;
        private Int32 _ID;
        private Int32 _PrinterID_I;
        private Double _RateQuoated_N;
        public Int32 TenderId_I { get { return _TenderId_I; } set { _TenderId_I = value; } }
        public string AcdmicYr_V { get { return _AcdmicYr_V; } set { _AcdmicYr_V = value; } }
        public string TenderType_V { get { return _TenderType_V; } set { _TenderType_V = value; } }
        public string TenderNo_V { get { return _TenderNo_V; } set { _TenderNo_V = value; } }
        public DateTime TenderDate_D { get { return _TenderDate_D; } set { _TenderDate_D = value; } }
        public string LUNSendNo_V { get { return _LUNSendNo_V; } set { _LUNSendNo_V = value; } }
        public DateTime LUNDate_D { get { return _LUNDate_D; } set { _LUNDate_D = value; } }
        public DateTime NITDate_D { get { return _NITDate_D; } set { _NITDate_D = value; } }
        public Decimal TenderDocFee_N { get { return _TenderDocFee_N; } set { _TenderDocFee_N = value; } }
        public DateTime TenderSubmissionDate_D { get { return _TenderSubmissionDate_D; } set { _TenderSubmissionDate_D = value; } }
        public DateTime TechBidopeningDate_D { get { return _TechBidopeningDate_D; } set { _TechBidopeningDate_D = value; } }
        public DateTime CommecialBidOpeningdate_D { get { return _CommecialBidOpeningdate_D; } set { _CommecialBidOpeningdate_D = value; } }
        public DateTime Transdate_D { get { return _Transdate_D; } set { _Transdate_D = value; } }
        public Int32 UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
        public Int32 LID { get { return _LID; } set { _LID = value; } }
        public Int32 TenDetid_I { get { return _TenDetid_I; } set { _TenDetid_I = value; } }
        public Int32 GrpID_I { get { return _GrpID_I; } set { _GrpID_I = value; } }
        public Int32 ID { get { return _ID; } set { _ID = value; } }
        public Int32 PrinterID_I { get { return _PrinterID_I; } set { _PrinterID_I = value; } }
        public Double RateQuoated_N { get { return _RateQuoated_N; } set { _RateQuoated_N = value; } }

        // add by nitin 4/6/2016
        public string CompanyName { get; set; }
        public string Rank { get; set; }
        public int LunListExcelDataSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                //obDbaccess.execute("USP_PRI010_TenderAlloteSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.execute("USP_PRI010_ExcelLunListSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mCompanyName", CompanyName);
                obDbaccess.addParam("mTenderid_i", TenderId_I);
                obDbaccess.addParam("mGrPID_i", TenderNo_V);
                obDbaccess.addParam("mRate", RateQuoated_N);
                obDbaccess.addParam("mRank", Rank);
                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }


        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            LID = 0;
            if (TenderId_I != 0)
            {
                LID = TenderId_I;
            }
            obDBAccess.execute("USP_PRI010_TenderDetailsSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderId_I", TenderId_I);
            obDBAccess.addParam("mAcdmicYr_V", AcdmicYr_V);
            obDBAccess.addParam("mTenderType_V", TenderType_V);
            obDBAccess.addParam("mTenderNo_V", TenderNo_V);
            obDBAccess.addParam("mTenderDate_D", TenderDate_D);
            obDBAccess.addParam("mLUNSendNo_V", LUNSendNo_V);
            obDBAccess.addParam("mLUNDate_D", LUNDate_D);
            obDBAccess.addParam("mNITDate_D", NITDate_D);
            obDBAccess.addParam("mTenderDocFee_N", TenderDocFee_N);
            obDBAccess.addParam("mTenderSubmissionDate_D", TenderSubmissionDate_D);
            obDBAccess.addParam("mTechBidopeningDate_D", TechBidopeningDate_D);
            obDBAccess.addParam("mCommecialBidOpeningdate_D", CommecialBidOpeningdate_D);
            obDBAccess.addParam("mTransdate_D", Transdate_D);
            obDBAccess.addParam("mUserID_I", UserID_I);
            obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32, DBAccess.SqlDirection.OUT);

            int result = obDBAccess.executeMyQuery();
            LID = Convert.ToInt32(obDBAccess.getParameter(14).ToString());
            return LID;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI010_TenderGroupDetailsLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderId_I", TenderId_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI010_TenderDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderId_I", id);

            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }

        public DataSet FillGroupDetail()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI010_GetGroupDetailLoad", DBAccess.SQLType.IS_PROC);
            return obDBAccess.records();
        }
        public DataSet FillGridGroupDetail()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI010_TenderGroupGridfill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("dtype", ID);
            obDBAccess.addParam("acyear", AcdmicYr_V);
            obDBAccess.addParam("mtenderid_i", TenderId_I);
            DataSet ds = new DataSet();
            ds = obDBAccess.records();
            return ds;
        }
        public DataSet FillGridGroupDetailAllSearch(int mmedium_i, int classtrno_i, string acyear)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI010_TenderGroupGridfillSearch", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("dtype", 0);
            obDBAccess.addParam("acyear", acyear);
            obDBAccess.addParam("mtenderid_i", TenderId_I);
            obDBAccess.addParam("mmedium_i", mmedium_i);
            obDBAccess.addParam("mclasstrno_i", classtrno_i);

            DataSet ds = new DataSet();
            ds = obDBAccess.records();
            return ds;
        }


        public int InsertGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI010_TenderGroupDetailsSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenDetid_I", TenDetid_I);
            obDBAccess.addParam("mTenderID_I", TenderId_I);
            obDBAccess.addParam("mGrpID_I", GrpID_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public DataSet PrinterGroupwise()                  
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Pri010_TenderEvalLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mtenevlid", TenderId_I);
            obDBAccess.addParam("mgrpid", GrpID_I);
            return obDBAccess.records();
        }

        public int InsertPrinterinGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_Pri010_TenderEvalsave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTranID", ID);
            obDBAccess.addParam("mTenEvalID_I", TenderId_I);
            obDBAccess.addParam("mGRPID_I", GrpID_I);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            obDBAccess.addParam("mRateQuoated_N", RateQuoated_N);
            int result = obDBAccess.executeMyQuery();
            return result;
        }



        //// function for generate LOI USP_PRI010_FatchTenderprinterArrange call

        public int LOIGenrateprinterArrange()
        {
            int i = 0;

            DBAccess obDbAccess = new DBAccess();

            try
            {
                obDbAccess.execute("USP_PRI010_FatchTenderprinterArrange", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("macdmicyr_v", AcdmicYr_V);
                obDbAccess.addParam("pTenderid_i", TenderId_I);

                i = obDbAccess.executeMyQuery();



            }

            catch (Exception ex) { }

            finally { obDbAccess = null; }

            return i;


        }

        //
        public int LOIGenrateAllot_ofprinter()
        {
            int i = 0;

            DBAccess obDbAccess = new DBAccess();

            try
            {
                obDbAccess.execute("USP_PRI010_FatchTenderfinal_Allot_ofprinter", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("macdmicyr_v", AcdmicYr_V);
                obDbAccess.addParam("pTenderid_i", TenderId_I);

                i = obDbAccess.executeMyQuery();



            }

            catch (Exception ex) { }

            finally { obDbAccess = null; }

            return i;


        }



        public DataSet LoadAllotedTenderList()
        {
            DBAccess ObDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                ObDbAccess.execute("USP_PRI010_TenderLOIData", DBAccess.SQLType.IS_PROC);
                ObDbAccess.addParam("mtenderid", TenderId_I);
                ds = ObDbAccess.records();
            }

            catch (Exception ex) { }

            finally { ObDbAccess = null; }
            return ds;
        }

    }
}
