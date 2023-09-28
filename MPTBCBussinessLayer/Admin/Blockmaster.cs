
namespace MPTBCBussinessLayer
{
  public  class Blockmaster : ICommon
    {
      //Block
      private int _BlockTrno_I;
       private int _DistrictTrno_I;
       private string _BlockName_V;
       private int _UserID_I;
       private string _BlockNameHindi_V;
      
       public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }
       public int BlockTrno_I { get { return _BlockTrno_I; } set { _BlockTrno_I = value; } }
       public int DistrictTrno_I { get { return _DistrictTrno_I; } set { _DistrictTrno_I = value; } }
       public string BlockName_V { get { return _BlockName_V; } set { _BlockName_V = value; } }
       public string BlockNameHindi_V { get { return _BlockNameHindi_V; } set { _BlockNameHindi_V = value; } }
        #region ICommon Members
        
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM011_BlockMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBlockTrno_I", BlockTrno_I);
            obDBAccess.addParam("mDistrictTrno_I", DistrictTrno_I);
            obDBAccess.addParam("mBlockName_V", _BlockName_V);
            obDBAccess.addParam("mBlockNameHindi_V", _BlockNameHindi_V);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM011_BlockMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBlockTrno_I", BlockTrno_I);
            return obDBAccess.records();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM011_BlockMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mBlockTrno_I", id);          
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        #endregion
    }
}
