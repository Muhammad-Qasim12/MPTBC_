using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace MPTBCBussinessLayer
{
    public class PRIN_ChallanDetails : ICommon
    {
        // start

        int _PriTransID,
            _TitalID,
            _BookFrom,
            _Bookto,
            _PerBandalBook,
            _TotalNoBook,
            _TotalNoBandal,
            _User_ID,
            _Depo_I,
            _PacketsSendAsPerChallan,
            _PacketsReceiveByCounting,
            _grpID_I,
            _ChallanTrno_I, _TotalNoOfBooksYoj, _BooksFromYoj, _BooksToYoj, _ClassID, _WorkorderId;
        string _Finyear, _PacketsSendAsPerChallanYoj;
        string _Remark, _ChalanNo;
        string _TruckCharges, _LoadingCharges, _OtherCharges;
        DateTime _ChalanDate, _ReceiptDate, _UnloadingCharges;
        public string Finyear { get { return _Finyear; } set { _Finyear = value; } }
        public int ClassID { get { return _ClassID; } set { _ClassID = value; } }
        public int PriTransID { get { return _PriTransID; } set { _PriTransID = value; } }
        public int WorkorderId { get { return _WorkorderId; } set { _WorkorderId = value; } }
        public string ChalanNo { get { return _ChalanNo; } set { _ChalanNo = value; } }
        public DateTime ChalanDate { get { return _ChalanDate; } set { _ChalanDate = value; } }
        public int TitalID { get { return _TitalID; } set { _TitalID = value; } }
        public int BookFrom { get { return _BookFrom; } set { _BookFrom = value; } }
        public int Bookto { get { return _Bookto; } set { _Bookto = value; } }
        public int PerBandalBook { get { return _PerBandalBook; } set { _PerBandalBook = value; } }
        public int TotalNoBook { get { return _TotalNoBook; } set { _TotalNoBook = value; } }
        public int TotalNoBandal { get { return _TotalNoBandal; } set { _TotalNoBandal = value; } }

        public int User_ID { get { return _User_ID; } set { _User_ID = value; } }

        public int Depo_I { get { return _Depo_I; } set { _Depo_I = value; } }

        public int PacketsSendAsPerChallan { get { return _PacketsSendAsPerChallan; } set { _PacketsSendAsPerChallan = value; } }
        public int PacketsReceiveByCounting { get { return _PacketsReceiveByCounting; } set { _PacketsReceiveByCounting = value; } }
        public int grpID_I { get { return _grpID_I; } set { _grpID_I = value; } }
        public int ChallanTrno_I { get { return _ChallanTrno_I; } set { _ChallanTrno_I = value; } }


        public DateTime ReceiptDate { get { return _ReceiptDate; } set { _ReceiptDate = value; } }
        public string TruckCharges { get { return _TruckCharges; } set { _TruckCharges = value; } }
        public DateTime UnloadingCharges { get { return _UnloadingCharges; } set { _UnloadingCharges = value; } }
        public string LoadingCharges { get { return _LoadingCharges; } set { _LoadingCharges = value; } }
        public string OtherCharges { get { return _OtherCharges; } set { _OtherCharges = value; } }
        public string Remark { get { return _Remark; } set { _Remark = value; } }

        public string PacketsSendAsPerChallanYoj { get { return _PacketsSendAsPerChallanYoj; } set { _PacketsSendAsPerChallanYoj = value; } }
        public int TotalNoOfBooksYoj { get { return _TotalNoOfBooksYoj; } set { _TotalNoOfBooksYoj = value; } }
        public int BooksFromYoj { get { return _BooksFromYoj; } set { _BooksFromYoj = value; } }
        public int BooksToYoj { get { return _BooksToYoj; } set { _BooksToYoj = value; } }


        public DataSet LoadChallanDetails()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_PRIN001_ChallanDetailsLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mPriTransID", PriTransID);
                obDbAccess.addParam("mprinterid", Depo_I);
                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }
        public DataSet PrinLoadChallanDetails()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_PRIN0011_ChallanDetailsLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mPriTransID", PriTransID);
                obDbAccess.addParam("mprinterid", Depo_I);
                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }


        public DataSet PrinLoadChallanDetailsprint()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_PRIN0011_ChallanDetailsPrint", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mprinterid", PriTransID);
                obDbAccess.addParam("mTitleid", TitalID );
                obDbAccess.addParam("mclass", ClassID );
                obDbAccess.addParam("myear", Finyear);
                obDbAccess.addParam("mdepotrno", Depo_I);
                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }


        public DataSet PrinLoadChallanbundal(int vitranno )
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_Pri009_Bundalas_vitran", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mvitran", vitranno);
             
                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; 
         }
            return ds;
        }

        public int SaveUpdateChallanDetails()
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;

            try
            {
                obDbAccess.execute("USP_PRIN001_ChallanDetailsSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mPriTransID", PriTransID);

                obDbAccess.addParam("mChalanNo", ChalanNo);
                obDbAccess.addParam("mChalanDate", ChalanDate);
                obDbAccess.addParam("mReceiptDate", ReceiptDate);
                obDbAccess.addParam("mTitalID", TitalID);
                //obDbAccess.addParam("mPacketsSendAsPerChallan", PacketsSendAsPerChallan);
                //obDbAccess.addParam("mPacketsReceiveByCounting", PacketsReceiveByCounting);
                //obDbAccess.addParam("mTotalNoBook", TotalNoBook);


                //obDbAccess.addParam("mBookFrom", BookFrom);
                //obDbAccess.addParam("mBookto", Bookto);
                // obDbAccess.addParam("mPerBandalBook", PerBandalBook);

                //obDbAccess.addParam("mTotalNoBandal", TotalNoBandal);



                obDbAccess.addParam("mUser_ID", User_ID);

                obDbAccess.addParam("mDepo_I", Depo_I);

                obDbAccess.addParam("mTruckCharges", TruckCharges);
                obDbAccess.addParam("mUnloadingCharges", ReceiptDate);
                obDbAccess.addParam("mLoadingCharges", LoadingCharges);
                obDbAccess.addParam("mOtherCharges", OtherCharges);
                obDbAccess.addParam("mRemark", Remark);
                obDbAccess.addParam("mBooktype", Bookto);
                obDbAccess.addParam("mOrderno", grpID_I);
                i = Convert.ToInt32(obDbAccess.executeMyScalar());
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }



            return i;
        }


        // function lo load Groups ,depot, title
        public DataSet LoadGroupDetails()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {
                obDbAccess.execute("USP_PRI001_GroupDetailsForChallan", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mPrinterid_I", User_ID);
                obDbAccess.addParam("mpritransid", PriTransID);
                obDbAccess.addParam("mdepottrno", Depo_I);
                obDbAccess.addParam("mclassID", ClassID);
                obDbAccess.addParam("mAcyear", Finyear);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }

        public DataSet PrinLoadGroupDetails()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {

                obDbAccess.execute("USP_PRI001_GroupDetailsForChallan", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mPrinterid_I", User_ID);
                obDbAccess.addParam("mpritransid", PriTransID);
                obDbAccess.addParam("mdepottrno", Depo_I);
                obDbAccess.addParam("mclassID", ClassID);
                obDbAccess.addParam("mAcyear", Finyear);


                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }


        public DataSet PrinLoadGroupDetailssent()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();

            try
            {

                obDbAccess.execute("USP_PRI001_GroupDetailsForChallansent", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mPrinterid_I", User_ID);
                obDbAccess.addParam("mpritransid", PriTransID);
                obDbAccess.addParam("mdepottrno", Depo_I);
                obDbAccess.addParam("mclassID", ClassID);
                obDbAccess.addParam("mAcyear", Finyear);


                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }
            return ds;
        }

        public int SaveChallanTitleDetails()
        {
            DBAccess obDbAccess = new DBAccess();

            int i = 0;
            try
            {
                obDbAccess.execute("USP_Prin001_ChallanTitleDetailsSave", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGRPID_I", grpID_I);
                obDbAccess.addParam("mTitleID_I", TitalID);
                obDbAccess.addParam("mDepoID_I", Depo_I);
                obDbAccess.addParam("mPriTransID", PriTransID);
                obDbAccess.addParam("mChallanTrno_I", ChallanTrno_I);

                obDbAccess.addParam("mPacketsSendAsPerChallan", PacketsSendAsPerChallan);
                obDbAccess.addParam("mPacketsReceiveByCounting", PacketsReceiveByCounting);
                obDbAccess.addParam("mTotalNoOfBooks", TotalNoBook);


                obDbAccess.addParam("mBooksFrom", BookFrom);
                obDbAccess.addParam("mBooksTo", Bookto);

                obDbAccess.addParam("mPacketsSendAsPerChallanYoj", PacketsSendAsPerChallanYoj);

                obDbAccess.addParam("mTotalNoOfBooksYoj", TotalNoOfBooksYoj);


                obDbAccess.addParam("mBooksFromYoj", BooksFromYoj);
                obDbAccess.addParam("mBooksToYoj", BooksToYoj);

                obDbAccess.addParam("mWorkoderid", WorkorderId);

                i = obDbAccess.executeMyQuery();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }


            return i;

        }
        
        

        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion



        // End 
    }
}
