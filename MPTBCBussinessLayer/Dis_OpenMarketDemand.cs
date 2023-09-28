using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Data;
namespace MPTBCBussinessLayer
{
    public class Dis_OpenMarketDemand
    {

       // DataSet ds;
        private int _DepoTrno_I;
        private int _MediumTrno_I;
        private int _ClassTrno_I;
        private int _OpnMrktId_I;
        private string _Session_v;
        private int _TitleID_I;
        private int _LstYearSaleBook_I;
        private int _CurntYearDmndBook_I;
        private int _OpenDmndStock_I;
        private int _CurntNetDmnd_I;
        private string _Remark_v;
        private int _UserID_I;

        public int DepoTrno_I { get { return _DepoTrno_I; } set { _DepoTrno_I = value; } }
        public int MediumTrno_I { get { return _MediumTrno_I; } set { _MediumTrno_I = value; } }
        public int ClassTrno_I { get { return _ClassTrno_I; } set { _ClassTrno_I = value; } }
        public int OpnMrktId_I { get { return _OpnMrktId_I; } set { _OpnMrktId_I = value; } }
        public string Session_v { get { return _Session_v; } set { _Session_v = value; } }
        public int TitleID_I { get { return _TitleID_I; } set { _TitleID_I = value; } }
        public int LstYearSaleBook_I { get { return _LstYearSaleBook_I; } set { _LstYearSaleBook_I = value; } }
        public int CurntYearDmndBook_I { get { return _CurntYearDmndBook_I; } set { _CurntYearDmndBook_I = value; } }
        public int OpenDmndStock_I { get { return _OpenDmndStock_I; } set { _OpenDmndStock_I = value; } }
        public int CurntNetDmnd_I { get { return _CurntNetDmnd_I; } set { _CurntNetDmnd_I = value; } }
        public string Remark_v { get { return _Remark_v; } set { _Remark_v = value; } }
        public int UserID_I { get { return _UserID_I; } set { _UserID_I = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_OpenDemandDataSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mOpnMrktId_I", OpnMrktId_I);
            obDBAccess.addParam("mSession_v", Session_v);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            obDBAccess.addParam("mClassTrno_I", ClassTrno_I);
            obDBAccess.addParam("mTitleID_I", TitleID_I);
            obDBAccess.addParam("mMedium_I", MediumTrno_I);
            obDBAccess.addParam("mLstYearSaleBook_I", LstYearSaleBook_I);

            obDBAccess.addParam("mCurntYearDmndBook_I", CurntYearDmndBook_I);
            obDBAccess.addParam("mOpenDmndStock_I", OpenDmndStock_I);
            obDBAccess.addParam("mCurntNetDmnd_I", CurntNetDmnd_I);
            obDBAccess.addParam("mRemark_v", Remark_v);
            obDBAccess.addParam("mUserID_I", UserID_I);

            int result = obDBAccess.executeMyQuery();
            return result;

        }

        //public System.Data.DataSet Select()
        //{

        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_DIS001_OpenDemandDataShow", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mDepoTrno_I", PaperTrId_I);
        //    obDBAccess.addParam("mMediumTrno_I", PaperTrId_I);
        //    obDBAccess.addParam("mClassTrno_I", PaperTrId_I);
        //    obDBAccess.addParam("mtype", PaperTrId_I);
        //    return obDBAccess.records();

        //}
        public System.Data.DataSet Depofill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_OpenDemandDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", 0);
            obDBAccess.addParam("mMediumTrno_I", 0);
            obDBAccess.addParam("mClassTrno_I", 0);
            obDBAccess.addParam("mSession", Session_v);
            
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();

        }
        public System.Data.DataSet Booksfill()
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_OpenDemandDataShow", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            obDBAccess.addParam("mMediumTrno_I", MediumTrno_I);
            obDBAccess.addParam("mSession", Session_v);
            obDBAccess.addParam("mClassTrno_I", ClassTrno_I);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();

        }
        public System.Data.DataSet BooksfillWithClass(string Class)
        {

            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIS001_OpenDemandDataShowWithCls", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDepoTrno_I", DepoTrno_I);
            obDBAccess.addParam("mMediumTrno_I", MediumTrno_I);
            obDBAccess.addParam("mSession", Session_v);
            obDBAccess.addParam("mClassTrno_I", Class);
            obDBAccess.addParam("mtype", 1);
            return obDBAccess.records();

        }
        //public int Delete(int id)
        //{
        //    DBAccess obDBAccess = new DBAccess();
        //    obDBAccess.execute("USP_PPR001_PaperMasterDelete", DBAccess.SQLType.IS_PROC);
        //    obDBAccess.addParam("mPaperTrId_I", id);
        //    int result = obDBAccess.executeMyQuery();
        //    return result;

        //}
    }
}
