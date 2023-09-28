
namespace MPTBCBussinessLayer.DistributionB
{
    public class DemandfromOthers : ICommon
    {
        public int QueryType { get; set; }
        public int ParameterValue { get; set; }
        public int ParameterValue2 { get; set; }
        public string StringParameterValue { get; set; }

        public int DemandID_I { get; set; }
        public int DepTrno_I { get; set; }
        public int AcYrID_I { get; set; }
        public string LetterNo_V { get; set; }
        public string LetterDate_D { get; set; }
        public string RefLetterNo_V { get; set; }
        public string RefLetterDate_D { get; set; }
        public int TitleID_I { get; set; }
        public string ScanLetterPath_V { get; set; }
        public int DemandFrom_I { get; set; }
        public int DistrictID_I { get; set; }
        public int DemandDetailsID_I { get; set; }
        public int SubTitleID_I { get; set; }
        public int DistrictSupply_I { get; set; }
        public string OtherAgencyName_V { get; set; }

        public int BlockSupply_I { get; set; }
        public int BRCSupply_I { get; set; }
        public int DPCSupply_I { get; set; }
        public int DiatSupply_I { get; set; }
        public int OtherSupply_I { get; set; }
        public int TransID { get; set; }
        public int BlockTrno_I { get; set; }
        public int DemandSubTitleDetailsTrno_I { get; set; }
        public string FIleName { get; set; }
        DBAccess obDBAccess = new DBAccess();

        #region ICommon Members

        public int InsertUpdate()
        {
            obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB002_DemandfromOthersSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDemandID_I", DemandID_I);
            obDBAccess.addParam("mDepTrno_I", DepTrno_I);
            obDBAccess.addParam("mAcYrID_I", AcYrID_I);
            obDBAccess.addParam("mLetterNo_V", LetterNo_V);
            obDBAccess.addParam("mLetterDate_D", LetterDate_D);
            obDBAccess.addParam("mRefLetterNo_V", RefLetterNo_V);
            obDBAccess.addParam("mRefLetterDate_D", RefLetterDate_D);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mScanLetterPath_V", ScanLetterPath_V);
            obDBAccess.addParam("mDemandFrom_I", DemandFrom_I);
            obDBAccess.addParam("mDistrictID_I", DistrictID_I);
            obDBAccess.addParam("mDemandDetailsID_I", DemandDetailsID_I);
            obDBAccess.addParam("mSubTitleID_I", SubTitleID_I);
            obDBAccess.addParam("mDistrictSupply_I", DistrictSupply_I);
            obDBAccess.addParam("mBlockSupply_I", BlockSupply_I);
            obDBAccess.addParam("mBRCSupply_I", BRCSupply_I);
            obDBAccess.addParam("mDPCSupply_I", DPCSupply_I);
            obDBAccess.addParam("mDiatSupply_I", DiatSupply_I);
            obDBAccess.addParam("mOtherSupply_I", OtherSupply_I);
            obDBAccess.addParam("mBlockTrno_I", BlockTrno_I);
            obDBAccess.addParam("mOtherAgencyName_V", OtherAgencyName_V);
            obDBAccess.addParam("mDemandSubTitleDetailsTrno_I", DemandSubTitleDetailsTrno_I);

            obDBAccess.addParam("FIleName", FIleName);
            obDBAccess.addParam("mTransID", TransID);
            object result = obDBAccess.executeMyScalar();

            return int.Parse(result.ToString());
        }

        public System.Data.DataSet Select()
        {
            if (string.IsNullOrEmpty(StringParameterValue))
                StringParameterValue = "0";

            obDBAccess.execute("USP_DIB002_DemandfromOthersSelect", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mType", QueryType);
            obDBAccess.addParam("mParameterValue", ParameterValue);
            obDBAccess.addParam("mParameterValue2", ParameterValue2);
            obDBAccess.addParam("mStringParameterValue", StringParameterValue);

            return obDBAccess.records();
        }

        public System.Data.DataSet FillGrid()
        {
            obDBAccess.execute("USP_DIB002_DemandFromOtherLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDistrictID_I", DistrictID_I);

            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
