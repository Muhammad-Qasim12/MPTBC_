using System.Data;
namespace MPTBCBussinessLayer.Academic
{
    public class TitleMaster:ICommon
    {
        public int Medium { get; set; }
        public int ClassTrno { get; set; }       
        public string TitleHindi { get; set; }
        public string Size { get; set; }
        public int Pages { get; set; }       
        public string ColourCover1n4 { get; set; }
        public string ColourCover2n3{ get; set; }
        public string ColorText { get; set; }
        public string TitleEnglish { get; set; }
        public double Rate { get; set; }
        public double PrintngPaperSize_GSM { get; set; }
        public double CoverPaperSize_GSM { get; set; }
        public int TranID { get; set; }
        public int TitleID { get; set; } 

        public int DepartmentTrno { get; set; }
        public int RateListSNo { get; set; }
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; } }

        public string StringParameter { get; set; }
        public int AcademicYrID { get; set; }
        public int UserId { get; set; }
        DBAccess obDBAccess;
        public string PrintingPaperDetails { get; set; }
        public string CoverpaperDetails { get; set; }
        public string BindingDetails { get; set; }
       // PrintingPaperDetails,CoverpaperDetails, BindingDetails

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD001_TitleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mMedium_I", Medium);
            obDBAccess.addParam("mClassTrno_I", ClassTrno);
            obDBAccess.addParam("mTitleHindi_V", TitleHindi);
            obDBAccess.addParam("mSize_V", Size);
            obDBAccess.addParam("mPages_N", Pages);
            obDBAccess.addParam("mColourCover1n4_V", ColourCover1n4);
            obDBAccess.addParam("mColourCover2n3_V", ColourCover2n3);
            obDBAccess.addParam("mColorText_V", ColorText);
            obDBAccess.addParam("mTitleEnglish_V", TitleEnglish);
            obDBAccess.addParam("mDepartmentTrno_I", DepartmentTrno);
            obDBAccess.addParam("mRate_N", Rate);
            obDBAccess.addParam("mPrintngPaperSize_GSM_N", PrintngPaperSize_GSM);
            obDBAccess.addParam("mCoverPaperSize_GSM_N", CoverPaperSize_GSM);
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mRateListSNo_I", RateListSNo);
            obDBAccess.addParam("mAcademicYrId", AcademicYrID);
            obDBAccess.addParam("mUserID", UserId);
            obDBAccess.addParam("PrintingPaperDetailsa", PrintingPaperDetails);
            obDBAccess.addParam("CoverpaperDetailsa", CoverpaperDetails);
            obDBAccess.addParam("BindingDetailsa", BindingDetails);
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD001_TitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", TitleID); 
            obDBAccess.addParam("mParameter", ClassTrno);
            obDBAccess.addParam("mParameter2", Medium);
            obDBAccess.addParam("mStringParameter", StringParameter);
            obDBAccess.addParam("mAcademicYrId", AcademicYrID);

           
            return obDBAccess.records();        
        }

         public DataSet FillReport()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD001_TitleMasterLoadRPT", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID); 
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mClassTrno_I", ClassTrno);
            obDBAccess.addParam("mMedium_I", Medium);
            obDBAccess.addParam("mAcademicYrId", AcademicYrID);
            return obDBAccess.records();        
        }

         public DataSet FillCDReport()
         {
             obDBAccess = new DBAccess();
             obDBAccess.execute("USP_ACD003_CDReportLoadRPT", DBAccess.SQLType.IS_PROC);
             obDBAccess.addParam("mID", ID);
             obDBAccess.addParam("mAcademicYr", AcademicYrID);
             obDBAccess.addParam("mClassTrno_I", ClassTrno);
             obDBAccess.addParam("mMedium_I", Medium);

             return obDBAccess.records();
         }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACD001_TitleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", id);
            obDBAccess.addParam("mUserID", UserId);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}
