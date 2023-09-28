
using System.Data;
namespace MPTBCBussinessLayer.DistributionB
{
    public class RDLC_Data
    {
        DBAccess obDBAccess;
        public int DemandID { get; set; }
        public int FyYearID { get; set; }
        public int AcYearID { get; set; }
        public int TitleID { get; set; }
        public int TransID { get; set; }
        public DataSet FillLetterNo()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_Rpt001_DepowiseDemand", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID", FyYearID);
            obDBAccess.addParam("mType", -1);
            return obDBAccess.records();
        }
        public DataSet FillFyYear()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB002_DemandfromOthersSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", -1);
            obDBAccess.addParam("mParameterValue", 0);
            obDBAccess.addParam("mParameterValue2", 0);
            obDBAccess.addParam("mStringParameterValue", 0);
            return obDBAccess.records();
        }
        public DataSet DepowiseReport()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_Rpt001_DepowiseDemand", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID", DemandID);
            //obDBAccess.addParam("mQueryParameterValue2", QueryParameterValue2);
            obDBAccess.addParam("mType", 0);
            return obDBAccess.records();
        }

        public DataSet GroupwiseReport() 
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB_Rpt002_GropwiseDemandnew", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleID_I", TitleID);
            obDBAccess.addParam("mAcYearID", AcYearID);
            obDBAccess.addParam("mTransID", TransID );
            obDBAccess.addParam("mdemandid", DemandID);   
            
            return obDBAccess.records();
        }
    }
}
