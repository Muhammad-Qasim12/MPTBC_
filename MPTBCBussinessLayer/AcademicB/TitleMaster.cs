
namespace MPTBCBussinessLayer.AcademicB  
{
    public class TitleMaster:ICommon
    {
        public string TitleHindi { get; set; }
        public string TitleEnglish { get; set; }
        public int Medium { get; set; }
        public int ClassTrno { get; set; } 
        public string Size { get; set; }
        public int Pages { get; set; }       
        public string ColourCover1n4 { get; set; }
        public string ColourCover2n3{ get; set; }
        public string ColorText { get; set; }
        public string AcYear { get; set; }
        public double Rate { get; set; }
        public int TranID { get; set; }
        public int TitleID { get; set; } 

        public int DepartmentTrno { get; set; }
        public int UserID { get; set; }
        
        DBAccess obDBAccess;



        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB001_TitleMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleHindi_V", TitleHindi);         
            obDBAccess.addParam("mTitleEnglish_V", TitleEnglish);        
            obDBAccess.addParam("mTranID", TranID);
            obDBAccess.addParam("mUserId", UserID);
            obDBAccess.addParam("mRate_N", Rate);
            obDBAccess.addParam("mAcYear", AcYear); 
            object result = obDBAccess.executeMyScalar();
            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB001_TitleMasterSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", TitleID);           
            return obDBAccess.records();        
        }

        public int Delete(int id)
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB001_TitleMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}
