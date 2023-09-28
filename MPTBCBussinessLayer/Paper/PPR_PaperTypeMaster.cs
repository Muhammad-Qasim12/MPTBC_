using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer.Paper
{
    public class PPR_PaperTypeMaster
    {
         private int _Qualifyid_I;        
        private int _PaperType_Id;
        private string _QualifyType;
        private string _PaperType;

        public int PaperType_Id{ get { return _PaperType_Id; } set { _PaperType_Id= value; } }
        public int Qualifyid_I{ get { return _Qualifyid_I; } set { _Qualifyid_I= value; } }
        public string QualifyType{ get { return _QualifyType; } set { _QualifyType= value; } }
        public string PaperType{ get { return _PaperType; } set { _PaperType= value; } }

        public int InsertUpdate()
        {
          
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR004_PaperQutyTypeMasterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQualifyid_I", Qualifyid_I);
            obDBAccess.addParam("mQualifyType", QualifyType);
            obDBAccess.addParam("mPaperType_Id", PaperType_Id);
            obDBAccess.addParam("mtype", 1);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
          public int Update()
        {
          
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR004_PaperQutyTypeMasterShowData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mQualifyid_I", Qualifyid_I);
            obDBAccess.addParam("mQualifyType", QualifyType);
            obDBAccess.addParam("mPaperType_Id", PaperType_Id);
            obDBAccess.addParam("mtype", 2);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        
          public System.Data.DataSet Select()
          {
              DBAccess obDBAccess = new DBAccess();
              obDBAccess.execute("USP_PPR004_PaperQutyTypeMasterShowData", DBAccess.SQLType.IS_PROC);
              obDBAccess.addParam("mQualifyid_I", 0);
              obDBAccess.addParam("mQualifyType", 0);
              obDBAccess.addParam("mPaperType_Id", 0);
              obDBAccess.addParam("mtype", 3);
              return obDBAccess.records();
          }
          public System.Data.DataSet FiledFill()
          {
              DBAccess obDBAccess = new DBAccess();
              obDBAccess.execute("USP_PPR004_PaperQutyTypeMasterShowData", DBAccess.SQLType.IS_PROC);
              obDBAccess.addParam("mQualifyid_I", Qualifyid_I);
              obDBAccess.addParam("mQualifyType", 0);
              obDBAccess.addParam("mPaperType_Id", 0);
              obDBAccess.addParam("mtype", 4);
              return obDBAccess.records();
          }
          public System.Data.DataSet PaperTypeFill()
          {
              DBAccess obDBAccess = new DBAccess();
              obDBAccess.execute("USP_PPR004_PaperQutyTypeMasterShowData", DBAccess.SQLType.IS_PROC);
              obDBAccess.addParam("mQualifyid_I", Qualifyid_I);
              obDBAccess.addParam("mQualifyType", QualifyType);
              obDBAccess.addParam("mPaperType_Id", PaperType_Id);
              obDBAccess.addParam("mtype", 5);
              return obDBAccess.records();
          }

          public int Delete(int id)
          {
              DBAccess obDBAccess = new DBAccess();              
              obDBAccess.execute("USP_PPR004_PaperQutyTypeMasterShowData", DBAccess.SQLType.IS_PROC);
              obDBAccess.addParam("mQualifyid_I", id);
              obDBAccess.addParam("mQualifyType", 0);
              obDBAccess.addParam("mPaperType_Id", 0);
              obDBAccess.addParam("mtype", 6);
              int result = obDBAccess.executeMyQuery();
              return result;
          }
    }
}
