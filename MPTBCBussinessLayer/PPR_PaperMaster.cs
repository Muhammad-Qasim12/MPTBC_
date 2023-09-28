using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace MPTBCBussinessLayer
{
    public class PPR_PaperMaster : ICommon
    {
        DataSet ds;
        private int _PaperTrId_I;
        private int _PaperType_I;
        private string _PaperQuality_V;
        private string _PaperSize_V;
        private string _Remark_V;
        private int _UserId_I;
        private int _GSM;


        public int GSM { get { return _GSM; } set { _GSM = value; } } 
        public int PaperTrId_I { get { return _PaperTrId_I; } set { _PaperTrId_I = value; } }
         public int PaperType_I { get { return _PaperType_I; } set { _PaperType_I = value; } }
         public string PaperQuality_V { get { return _PaperQuality_V; } set { _PaperQuality_V = value; } }
         public string PaperSize_V { get { return _PaperSize_V; } set { _PaperSize_V = value; } }
         public string Remark_V { get { return _Remark_V; } set { _Remark_V = value; } }
         public int UserId_I { get { return _UserId_I; } set { _UserId_I= value; } }



         public int InsertUpdate()
         {
             DBAccess obDBAccess = new DBAccess();
             obDBAccess.execute("USP_PPR001_PaperMasterSave", DBAccess.SQLType.IS_PROC);
             obDBAccess.addParam("mPaperTrId_I", PaperTrId_I);
             obDBAccess.addParam("mPaperType_I", PaperType_I);
             obDBAccess.addParam("mPaperQuality_V", PaperQuality_V);
             obDBAccess.addParam("mPaperSize_V", PaperSize_V);
             obDBAccess.addParam("mRemark_V", Remark_V);
             obDBAccess.addParam("mUserId_I", UserId_I);
             obDBAccess.addParam("mGSM", GSM);
             

             int result = obDBAccess.executeMyQuery();
             return result;

         }

        public System.Data.DataSet Select()
        {
           
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR001_PaperMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperTrId_I", PaperTrId_I);
            return obDBAccess.records();

        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR001_PaperMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPaperTrId_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;

        }
    }
}
