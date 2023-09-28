using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Data;

namespace MPTBCBussinessLayer
{
     public class DPT_DepotMaster : ICommon
      {
         private Int32 _DepoTrno_I;
         private string _DepoName_V;
         private string _TeleNo_V;
        private string _MobNo_V;
        private string _DepoAddress_V;
        private int _DistrictTrno_I;
        private string _FaxNo_V;
        private string _Emailid_V;
        private string _DepoManager_Name_V;

        public Int32 DepoTrno_I { get { return _DepoTrno_I; } set { _DepoTrno_I = value; } }
        public string DepoName_V { get { return _DepoName_V; } set { _DepoName_V = value; } }
        public string TeleNo_V { get { return _TeleNo_V; } set { _TeleNo_V = value; } }
        public string MobNo_V { get { return _MobNo_V; } set { _MobNo_V = value; } }
        public string DepoAddress_V { get { return _DepoAddress_V; } set { _DepoAddress_V = value; } }
        public int DistrictTrno_I { get { return _DistrictTrno_I; } set { _DistrictTrno_I = value; } }
        public string FaxNo_V { get { return _FaxNo_V; } set { _FaxNo_V = value; } }
        public string Emailid_V { get { return _Emailid_V; } set { _Emailid_V = value; } }
        public string DepoManager_Name_V { get { return _DepoManager_Name_V; } set { _DepoManager_Name_V = value; } }

        public int ParentDepotId { get; set; }
        public Boolean IsSatellite { get; set; }

        
        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM010_DepoMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            obDBAccess.addParam("mDepoName_V", DepoName_V);
            obDBAccess.addParam("mTeleNo_V", TeleNo_V);
            obDBAccess.addParam("mMobNo_V", MobNo_V);
            obDBAccess.addParam("mDepoAddress_V", DepoAddress_V);
            obDBAccess.addParam("mDistrictTrno_I", DistrictTrno_I);
            obDBAccess.addParam("mFaxNo_V", FaxNo_V);
            obDBAccess.addParam("mEmailid_V", Emailid_V);
            obDBAccess.addParam("mDepoManager_Name_V", DepoManager_Name_V);
            obDBAccess.addParam("mIsSatellite_I", IsSatellite);
            obDBAccess.addParam("mParentDepotId_I", ParentDepotId);


            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM010_DepomasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM010_DepomasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", id);
          
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}

