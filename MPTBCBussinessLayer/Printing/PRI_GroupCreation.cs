using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
    public class PRI_GroupCreation 
    {
        int _CatID_I,
            _TitleID_I,
            _IsFinal,
            _PriDemandId,
            _GrpID_I,
            _DepoID_I,
            _GrpDetId_I,
            _DelStatus,
            _ClassID_I,
            _BookMarkId;

        string _CategoryNo_V,
               _ColorSchText_V,
               _ColorSchCoverPaper_V,
               _PrintingPaperInformation_V,
               _CoverPaperinformation_V,
               _Bindingdetail_V,
               _AcdYear,
               _GroupNO_V,
               _PrintingCategory_V,
                _BankName_V,
                _BankDetails,
                _BookmarkName_V, _TenderType
               ;


        double _EMDAmount_N;


        public int CatID_I { get { return _CatID_I; } set { _CatID_I = value; } }
        public int TitleID_I { get { return _TitleID_I; } set { _TitleID_I = value; } }
        public int IsFinal { get { return _IsFinal; } set { _IsFinal = value; } }
        public int PriDemandId { get { return _PriDemandId; } set { _PriDemandId = value; } }
        public int GrpID_I { get { return _GrpID_I; } set { _GrpID_I = value; } }
        public int DepoID_I { get { return _DepoID_I; } set { _DepoID_I = value; } }
        public int GrpDetId_I { get { return _GrpDetId_I; } set { _GrpDetId_I = value; } }
        public int DelStatus { get { return _DelStatus; } set { _DelStatus = value; } }
        public int ClassID_I { get { return _ClassID_I; } set { _ClassID_I = value; } }
              

        public string CategoryNo_V { get { return _CategoryNo_V; } set { _CategoryNo_V = value; } }
        public string ColorSchText_V { get { return _ColorSchText_V; } set { _ColorSchText_V = value; } }
        public string ColorSchCoverPaper_V { get { return _ColorSchCoverPaper_V; } set { _ColorSchCoverPaper_V = value; } }
        public string PrintingPaperInformation_V { get { return _PrintingPaperInformation_V; } set { _PrintingPaperInformation_V = value; } }
        public string CoverPaperinformation_V { get { return _CoverPaperinformation_V; } set { _CoverPaperinformation_V = value; } }
        public string Bindingdetail_V { get { return _Bindingdetail_V; } set { _Bindingdetail_V = value; } }
        public string AcdYear { get { return _AcdYear; } set { _AcdYear = value; } }
        public string GroupNO_V { get { return _GroupNO_V; } set { _GroupNO_V = value; } }
        public string PrintingCategory_V { get { return _PrintingCategory_V; } set { _PrintingCategory_V = value; } }
        public string TenderType { get { return _TenderType; } set { _TenderType = value; } }
        
        public int BookMarkId { get { return _BookMarkId; } set { _BookMarkId = value; } }
       
        public string BookmarkName_V { get { return _BookmarkName_V; } set { _BookmarkName_V = value; } }
        public double  EMDAmount_N { get { return _EMDAmount_N; } set { _EMDAmount_N = value; } }
        public string BankName_V { get { return _BankName_V; } set { _BankName_V = value; } }
        public string BankDetails { get { return _BankDetails; } set { _BankDetails = value; } }


        //function to load Category
        public DataSet LoadCategory() 
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_PRI009_CategoryMasterLoad", DBAccess.SQLType.IS_PROC);
            obj.addParam("mCatID_I", CatID_I);
            obj.addParam("mACYear", BankDetails);
            ds = obj.records();

            return ds;

        
        }

          //function to load title
        public DataSet LoadTitle() 
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_ACD001_TitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obj.addParam("mTitleID_I", TitleID_I);
                obj.addParam("mParameter", 0);
            obj.addParam("mParameter2", 0);

            ds = obj.records();

            return ds;

        
        }
        
            //function to load title
        public DataSet LoadClass() 
        {
            DBAccess obj = new DBAccess();
            DataSet ds = new DataSet();

            obj.execute("USP_ADM014_ClassMaster_Load", DBAccess.SQLType.IS_PROC);
            obj.addParam("id", TitleID_I);
            ds = obj.records();

            return ds;

        
        }


        // function to Load B

        public DataSet LoadBooksDetails(int status) 
        {
            DBAccess obDBAccess = new DBAccess();

            try
            {
                obDBAccess.execute("USP_PRI002_GroupTitleLoad", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("macyear", AcdYear);
                obDBAccess.addParam("mIsFinal", status);
                obDBAccess.addParam("mGrpID_I", GrpID_I);


            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return obDBAccess.records();
        
        }

        //public DataSet LoadBooksDetails(int status) 
        //{
        //    DBAccess obDBAccess = new DBAccess();

        //    try
        //    {
        //        obDBAccess.execute("USP_PRI009_Test", DBAccess.SQLType.IS_PROC);
        //        obDBAccess.addParam("acyear", AcdYear);
        //        obDBAccess.addParam("mIsFinal",status);


        //    }
        //    catch (Exception feException)
        //    {
        //        new Exception(feException.Message);
        //    }
        //    return obDBAccess.records();
        
        //}


        // function to Change Status of Group ie. form add or remove the titles in Group..
        public int GroupAllotmentStatusChang()
        {
            DBAccess obDBAccess = new DBAccess();
            int i = 0;
            try
            {
                obDBAccess.execute("USP_PRI009_GroupAllotmentStatusUpdate", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mPriDemandId", PriDemandId);
                obDBAccess.addParam("mIsFinal", IsFinal);
                obDBAccess.addParam("mGRPID_I", GrpID_I);
                
                i = obDBAccess.executeMyQuery();
                
            }
            catch (Exception feException)
            {
                new Exception(feException.Message);
            }
            return i;
        }

        // function to save Update Group Master information
        public int GroupMasterSaveUpdate() 
        {
            DBAccess obDBAccess = new DBAccess();
            int i = 0;
            try
            {
                obDBAccess.execute("USP_PRI002_GroupMasterSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDBAccess.addParam("mGrpID_I", GrpID_I);
                obDBAccess.addParam("mGroupNO_V", GroupNO_V);
                obDBAccess.addParam("mPrintingCategory_V", PrintingCategory_V);
                obDBAccess.addParam("mDepoID_I", DepoID_I);

                obDBAccess.addParam("mBookMarkId", BookMarkId);
                obDBAccess.addParam("mBookmarkName_V", BookmarkName_V);
                obDBAccess.addParam("mEMDAmount_N", EMDAmount_N);
                obDBAccess.addParam("mBankName_V", BankName_V);
                obDBAccess.addParam("mBankDetails", BankDetails);
                obDBAccess.addParam("mTenderType", TenderType);
                
                i = Convert.ToInt32(obDBAccess.executeMyScalar());


            }

            catch (Exception ex) { }
            finally { obDBAccess = null; }

            return i;

        }



        // Function to Load Group Details

        public DataSet LoadGroupDetails()
        {
            DBAccess obdbaccess = new DBAccess();

            DataSet ds = new DataSet();
            try
            {
                obdbaccess.execute("USP_PRI002_GroupDetails_Load", DBAccess.SQLType.IS_PROC);
                obdbaccess.addParam("acyear", AcdYear);
                obdbaccess.addParam("mIsFinal", IsFinal);
                obdbaccess.addParam("mGrpID_I", GrpID_I);
                ds = obdbaccess.records();

            }
            catch (Exception ex) { }

            finally { obdbaccess = null; }
            return ds;
        }
        // function to Save Update Group Details

        public int GroupDetailsSaveUpdate(string GroupId)
        {
            DBAccess obDbAccess = new DBAccess();
            int i = 0;
            try
            {
                obDbAccess.execute("USP_PRI002_GroupDetailSaveUpdate", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpDetId_I", GrpDetId_I);
                obDbAccess.addParam("mGRPID_I", GrpID_I);
                obDbAccess.addParam("mTextBookID_I", TitleID_I);
                obDbAccess.addParam("mPriDemandID", PriDemandId);
                obDbAccess.addParam("mDelStatus", DelStatus);
                obDbAccess.addParam("mDepoID_I", DepoID_I);
                obDbAccess.addParam("mGroupId", GroupId);
                obDbAccess.addParam("mAcYearid", AcdYear);

                i = obDbAccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return i;

        }



      // function to Load Group
        public DataSet GroupMasterLoad()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupMasterLoad", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpID_I", GrpID_I);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }

        public DataSet GroupMasterLoadFYYear()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupMasterLoadFYYear", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mFYYear", AcdYear);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }

        public DataSet GroupMasterLoadFYYearSearch()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupMasterLoadFYYearSearch", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mFYYear", AcdYear);
                obDbAccess.addParam("mGroupno", GroupNO_V );

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }


        public DataSet GroupDetailsLoad()
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupDetailsLoadonGrPID", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpID_I", GrpID_I);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds;

        }

        public string  GroupDetailsdELETE(int mGrpID_I)
        {
            DBAccess obDbAccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {

                obDbAccess.execute("USP_PRI002_GroupDetailsdELETE", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGrpID_I", mGrpID_I);

                ds = obDbAccess.records();
            }

            catch (Exception ex) { }
            finally { obDbAccess = null; }

            return ds.Tables[0].Rows[0][0].ToString()  ;

        }
           



        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public System.Data.DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion

        public DataSet LoadGridView() 
        {
            DBAccess obDBaccess = new DBAccess();

            DataSet ds = new DataSet();

            try
            {
                obDBaccess.execute("USP_PRI002_Test1", DBAccess.SQLType.IS_PROC);
                obDBaccess.addParam("macyearid",AcdYear);
                obDBaccess.addParam("mIsFinal",IsFinal);
                obDBaccess.addParam("mGrpID_I", GrpID_I);
                ds = obDBaccess.records();

            }
            catch (Exception ex) { }

            finally { obDBaccess = null; }
            return ds;
        }


        public DataSet LoadGridTitleView()
        {
            DBAccess obDBaccess = new DBAccess();

            DataSet ds = new DataSet();

            try
            {
                obDBaccess.execute("USP_PRI002_GroupGridFill", DBAccess.SQLType.IS_PROC);
                obDBaccess.addParam("macyearid", AcdYear);
                obDBaccess.addParam("mtitleid", TitleID_I);
                obDBaccess.addParam("mclasstrno_i", ClassID_I );
                ds = obDBaccess.records();

            }
            catch (Exception ex) { }

            finally { obDBaccess = null; }
            return ds;
        }

        public int GroupDetailsInsert() 
        {
            int i = 0;
            DBAccess obDbAccess = new DBAccess();

            try
            {
                obDbAccess.execute("USP_PRI002_GroupDetailsInsertForLOAD", DBAccess.SQLType.IS_PROC);
                obDbAccess.addParam("mGRPID_I", GrpID_I);
                obDbAccess.addParam("mTextBookID_I", TitleID_I);
                obDbAccess.addParam("mPriDemandID", PriDemandId);
                obDbAccess.addParam("mGrpStatus", IsFinal);
                obDbAccess.addParam("mDepoID_I", DepoID_I);
                
                i = obDbAccess.executeMyQuery();

            }
            catch (Exception ex)
            { }
            finally { obDbAccess = null; }

            return i;
        }
       
    }
}
