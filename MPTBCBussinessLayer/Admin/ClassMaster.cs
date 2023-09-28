using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class ClassMaster:ICommon 
    {
   private int _ClassTrno_I;
   private string _Classdet_V;
   private int _TransID;

   public int ClassTrno_I { get { return _ClassTrno_I; } set { _ClassTrno_I = value; } }
   public int Trans_I { get { return _TransID; } set { _TransID = value; } }
   public string Classdet_V { get { return _Classdet_V; } set { _Classdet_V = value; } }
   
   public int InsertUpdate()
   {
       DBAccess obDBAccess = new DBAccess();
       obDBAccess.execute("USP_ADM014_CLassMaster_Save", DBAccess.SQLType.IS_PROC);
       obDBAccess.addParam("AClassTrno_I", ClassTrno_I);
       obDBAccess.addParam("Classdet_V", Classdet_V);
       obDBAccess.addParam("trnasID", Trans_I);
       int result = obDBAccess.executeMyQuery();
       return result;
   }

   public System.Data.DataSet Select()
   {
       DBAccess obDBAccess = new DBAccess();
       obDBAccess.execute("USP_ADM014_ClassMaster_Load", DBAccess.SQLType.IS_PROC);
       obDBAccess.addParam("id", ClassTrno_I);
       return obDBAccess.records();
       
   }

   public int Delete(int id)
   {
       DBAccess obDBAccess = new DBAccess();
       obDBAccess.execute("USP_ADM014_Classmaster_Delete", DBAccess.SQLType.IS_PROC);
       obDBAccess.addParam("ID", id);
       int result = obDBAccess.executeMyQuery();
       return result;
      
   }
    }
}
