using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
  public class DistrictMaster
    {
   private int _DistrictTrno_I;
   private int _DivisionTrno_N;
   private string _District_Name_V;
   private string _District_Name_Eng_V;
   private int _DepotID_I;
   private int _Trans_I;
   public int DistrictTrno_I { get { return _DistrictTrno_I; } set { _DistrictTrno_I = value; } }
   public int DivisionTrno_N { get { return _DivisionTrno_N; } set { _DivisionTrno_N = value; } }
   public string  District_Name_V { get { return _District_Name_V; } set { _District_Name_V = value; } }
   public string District_Name_Eng_V { get { return _District_Name_Eng_V; } set { _District_Name_Eng_V = value; } }
   public int DepotID_I { get { return _DepotID_I; } set { _DepotID_I = value; } }
   public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
  
      public int InsertUpdate()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_ADM009_DistrictMaster", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ADistrictTrno_I", DistrictTrno_I);
    obDBAccess.addParam("DivisionTrno_N", DivisionTrno_N);     
    obDBAccess.addParam("District_Name_V", District_Name_V);
    obDBAccess.addParam("DepotID_I", DepotID_I);
    obDBAccess.addParam("District_Name_Eng_V", District_Name_Eng_V);
    obDBAccess.addParam("Trans_I", Trans_I);
          
    int result = obDBAccess.executeMyQuery();
    return result;

           
        }

public System.Data.DataSet Select()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_ADM009_DistrictMasterLoad", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("mDistrictTrno_I", DistrictTrno_I);
    //obDBAccess.addParam("UID", UserID);
    return obDBAccess.records();
   
}

public int Delete(int id)
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_ADM009_DistrictMaster_delete", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ID", id);
    int result = obDBAccess.executeMyQuery();
    return result;
   
}
    }
    }

