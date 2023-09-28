using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public class DivisionMaster : ICommon
    {
        private int _DivisionTrno_I;
        private string _Division_Name_Hindi_V;
        private string _Division_Name_Eng_V;
        private int _Trans_I;
        public int DivisionTrno_I { get { return _DivisionTrno_I; } set { _DivisionTrno_I = value; } }
        public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
        public string Division_Name_Hindi_V { get { return _Division_Name_Hindi_V; } set { _Division_Name_Hindi_V = value; } }
        public string Division_Name_Eng_V { get { return _Division_Name_Eng_V; } set { _Division_Name_Eng_V = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM006_DivisionMasterSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDivisionTrno_I", DivisionTrno_I);
            obDBAccess.addParam("mDivision_Name_Hindi_V", Division_Name_Hindi_V);
            obDBAccess.addParam("mDivision_Name_Eng_V", Division_Name_Eng_V);
            obDBAccess.addParam("trnasID", Trans_I);
            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM006_DivisionMasterLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("ID", DivisionTrno_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ADM006_DivisionMasterDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mDivisionTrno_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;
            throw new NotImplementedException();
        }
    }
}