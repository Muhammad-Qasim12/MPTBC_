using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class Building006_BillPayment : ICommon
    {

        string
                _Bhavan_V,
                _BillPayFile_V,
                _Remark_V,
                _BillPaymentMonth_V,
                _BillPaymentYear_V,
                _ACYear_V,
                _BillNo_V;

        int
                _BhavanTrno_I,
                _GatividhiTrno_I,
                _UserTrno_I,
                _BillPaymentTrno_I,
                _AvasMasterTrno_I;

        DateTime
               _BillPaymentDate_D,
               _BillDate,
               _BillPeriodFrom,
               _BillPeriodTo;

        double
            _BillAmount_N,
            _PayedAmount_N,
            _TotalAmount_N,
            _RemainAmount_N,
            _PayAmount_N;

        

        public string Bhavan_V { get { return _Bhavan_V; } set { _Bhavan_V = value; } }
        public int BhavanTrno_I { get { return _BhavanTrno_I; } set { _BhavanTrno_I = value; } }
        public int GatividhiTrno_I { get { return _GatividhiTrno_I; } set { _GatividhiTrno_I = value; } }
        public DateTime BillPaymentDate_D { get { return _BillPaymentDate_D; } set { _BillPaymentDate_D = value; } }
        public string BillPaymentMonth_V { get { return _BillPaymentMonth_V; } set { _BillPaymentMonth_V = value; } }
        public string BillPaymentYear_V { get { return _BillPaymentYear_V; } set { _BillPaymentYear_V = value; } }
        public double BillAmount_N { get { return _BillAmount_N; } set { _BillAmount_N = value; } }
        public double PayedAmount_N { get { return _PayedAmount_N; } set { _PayedAmount_N = value; } }
        public string BillPayFile_V { get { return _BillPayFile_V; } set { _BillPayFile_V = value; } }
        public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }

        public string ACYear_V { get { return _ACYear_V; } set { _ACYear_V = value; } }

        public int UserTrno_I { get { return _UserTrno_I; } set { _UserTrno_I = value; } }
        public int BillPaymentTrno_I { get { return _BillPaymentTrno_I; } set { _BillPaymentTrno_I = value; } }


        public string BillNo_V { get { return _BillNo_V; } set { _BillNo_V = value; } }
        public double TotalAmount_N { get { return _TotalAmount_N; } set { _TotalAmount_N = value; } }

        public double RemainAmount_N { get { return _RemainAmount_N; } set { _RemainAmount_N = value; } }

        public double PayAmount_N { get { return _PayAmount_N; } set { _PayAmount_N = value; } }
       
        public DateTime BillDate { get { return _BillDate; } set { _BillDate = value; } }
        public DateTime BillPeriodFrom { get { return _BillPeriodFrom; } set { _BillPeriodFrom = value; } }
        public DateTime BillPeriodTo { get { return _BillPeriodTo; } set { _BillPeriodTo = value; } }

        public int AvasMasterTrno_I { get { return _AvasMasterTrno_I; } set { _AvasMasterTrno_I = value; } }



        public int GatividhiBillSaveUpdate()
        {
            int i = 0;
            DBAccess obDbaccess = new DBAccess();

            try
            {
                obDbaccess.execute("USP_Building006_GatividhiBillPaymentSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mBillPayTrno_I", BillPaymentTrno_I);
                obDbaccess.addParam("mACYear_V", ACYear_V);
                obDbaccess.addParam("mBuildingTrno", BhavanTrno_I);
                obDbaccess.addParam("mBuildingName", Bhavan_V);
                obDbaccess.addParam("mGatividhiTrno_I", GatividhiTrno_I);
                obDbaccess.addParam("mBillNo_V", BillNo_V);
                obDbaccess.addParam("mBillDate_D", BillDate);
                obDbaccess.addParam("mTotalAmount_N", TotalAmount_N);
                obDbaccess.addParam("mRemainAmount_N", RemainAmount_N);
                obDbaccess.addParam("mPayAmount_N", PayAmount_N);
                obDbaccess.addParam("mBillFile_V", BillPayFile_V);
                obDbaccess.addParam("mRemark_V", Remark_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);
                obDbaccess.addParam("mBillPayDate", BillPaymentDate_D);
                obDbaccess.addParam("mBillPeriodFrom", BillPeriodFrom);
                obDbaccess.addParam("mBillPeriodTo", BillPeriodTo);

                obDbaccess.addParam("mAvasMasterTrno_I", AvasMasterTrno_I);

                i = Convert.ToInt32(obDbaccess.executeMyScalar());
                return i;


            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }

        public DataSet GatividhiBillLoad()
        {

            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Building006_GatividhiBillPaymentLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mBillPayTrno_I", BillPaymentTrno_I);
                obDbaccess.addParam("mACYear_V", ACYear_V);
                obDbaccess.addParam("mBuildingTrno", BhavanTrno_I);
                obDbaccess.addParam("mGatividhiTrno_I", GatividhiTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;


        }


        public DataSet GatividhiLoad()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Building006_GatividhiLoadBhavanWise", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mGatividhiBhavanTrno_I", BhavanTrno_I);

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
                obDbaccess.execute("USP_Building006_BillPaymentSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mBillPaymentTrno_I", BillPaymentTrno_I);
                obDbaccess.addParam("mBhavan_V", Bhavan_V);
                obDbaccess.addParam("mBhavanTrno_I", BhavanTrno_I);
                obDbaccess.addParam("mGatividhiTrno_I", GatividhiTrno_I);
                obDbaccess.addParam("mBillPaymentDate_D", BillPaymentDate_D);
                obDbaccess.addParam("mBillPaymentMonth_V", BillPaymentMonth_V);
                obDbaccess.addParam("mBillPaymentYear_V", BillPaymentYear_V);
                obDbaccess.addParam("mBillAmount_N", BillAmount_N);
                obDbaccess.addParam("mPayedAmount_N", PayedAmount_N);
                obDbaccess.addParam("mBillPayFile_V", BillPayFile_V);
                obDbaccess.addParam("mRemark_V", Remark_V);
                obDbaccess.addParam("mUserTrno_I", UserTrno_I);



                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;

        }

        public DataSet Select()
        {
            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Building006_PaymentLoad", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mBillPaymentTrno_I", BillPaymentTrno_I);

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



        public DataSet RPTGatividhiBillLoad()
        {

            DataSet ds = new DataSet();

            DBAccess obDbaccess = new DBAccess();

            try
            {

                obDbaccess.execute("USP_Building001_RPTBillPayments", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mBillPayTrno_I", BillPaymentTrno_I);
                obDbaccess.addParam("mACYear_V", ACYear_V);
                obDbaccess.addParam("mBuildingTrno", BhavanTrno_I);
                obDbaccess.addParam("mGatividhiTrno_I", GatividhiTrno_I);

                ds = obDbaccess.records();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;


        }

    }
}
