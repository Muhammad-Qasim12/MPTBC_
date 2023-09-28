using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace MPTBCBussinessLayer
{
    public class PRI_TenderEvaluation : ICommon
    {

        string _NameofPress_V,
               _LOINo_V;

        int     
                _TenEvalDetID_I,
                _TenAllotid_I,
                _Tenevalid_i,
                _Tenderid_i,
                _GrPID_i,
                _Printerid_i,
                
                _isALLOTED,
                _isPrinter;

        double _Ratequoated_n;





        public string NameofPress_V { get { return _NameofPress_V; } set { _NameofPress_V = value; } }
        public string LOINo_V { get { return _LOINo_V; } set { _LOINo_V = value; } }

        public int TenEvalDetID_I { get { return _TenEvalDetID_I; } set { _TenEvalDetID_I = value; } }
        public int TenAllotid_I { get { return _TenAllotid_I; } set { _TenAllotid_I = value; } }
        public int Tenevalid_i { get { return _Tenevalid_i; } set { _Tenevalid_i = value; } }
        public int Tenderid_i { get { return _Tenderid_i; } set { _Tenderid_i = value; } }
        public int GrPID_i { get { return _GrPID_i; } set { _GrPID_i = value; } }
        public int Printerid_i { get { return _Printerid_i; } set { _Printerid_i = value; } }
        public int isALLOTED { get { return _isALLOTED; } set { _isALLOTED = value; } }
        public int isPrinter { get { return _isPrinter; } set { _isPrinter = value; } }

        public double  Ratequoated_n { get { return _Ratequoated_n; } set { _Ratequoated_n = value; } }


        public int optType { get; set; }
        public int Key { get; set; }
        public DateTime AllotDate { get; set; }
        public int DepoId { get; set; }
        public int TitleId { get; set; }
        public string AcYear { get; set; }
        public int TenderReAllotmentSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TenderReAlloteSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mOpt", optType);
                obDbaccess.addParam("mKey", Key);
                obDbaccess.addParam("mTenderid_i", Tenderid_i);
                obDbaccess.addParam("mGrPID_i", GrPID_i);
                obDbaccess.addParam("mTitleid_i", TitleId);
                obDbaccess.addParam("mDepoid_i", DepoId);
                obDbaccess.addParam("mPrinterid_i", Printerid_i);
                obDbaccess.addParam("mRatequoated_n", Ratequoated_n);
                obDbaccess.addParam("mAllotDate", AllotDate);
                obDbaccess.addParam("mAcyear", AcYear);
                i = obDbaccess.executeMyQuery();
            }
            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }


        public DataSet GetPriIDAndStatus() 
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds= new DataSet();
            try
            {
                obDbaccess.execute("USP_PRI010_PrinterIDGetByPriName", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mNameofPress_V", NameofPress_V);
                ds= obDbaccess.records();
               

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        public DataSet GetGrPID()
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                obDbaccess.execute("USP_PRI010_GroupIDGetByGrpName", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mGroupNO_V", NameofPress_V);
                obDbaccess.addParam("TenderID_Ia", TenAllotid_I);
                ds = obDbaccess.records();


            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        public DataSet GetLUNList()
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                obDbaccess.execute("USP_LUNList", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mtenderid", Tenderid_i);
                ds = obDbaccess.records();


            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }

        public int TenderEvalMasterSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TEnderEvalMasterSave",DBAccess.SQLType.IS_PROC  );
                obDbaccess.addParam("mTenEvalID_I", Tenevalid_i );
                obDbaccess.addParam("mTenderID_I", Tenderid_i );
                obDbaccess.addParam("mGRPID_I", GrPID_i );
                obDbaccess.addParam("mLOINo_V", LOINo_V );

                i = Convert.ToInt32(obDbaccess.executeMyScalar());

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }



        public int TenderEvalDetailSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TenderEvalDetailsSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenEvalDetID_I", TenEvalDetID_I );
                obDbaccess.addParam("mTenEvalID_I", Tenevalid_i );
                obDbaccess.addParam("mGRPID_I", GrPID_i );
                obDbaccess.addParam("mPrinterID_I", Printerid_i );
                obDbaccess.addParam("mRateQuoated_N", Ratequoated_n );

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }

        public int TenderAllotmentSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TenderAlloteSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenAllotid_I", TenAllotid_I);
                obDbaccess.addParam("mTenevalid_i", Tenevalid_i);
                obDbaccess.addParam("mTenderid_i", Tenderid_i);
                obDbaccess.addParam("mGrPID_i", GrPID_i);
                obDbaccess.addParam("mPrinterid_i", Printerid_i);
                obDbaccess.addParam("mRatequoated_n", Ratequoated_n);
                obDbaccess.addParam("misALLOTED", isALLOTED);
                obDbaccess.addParam("misPrinter", isPrinter);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
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
    }
}
