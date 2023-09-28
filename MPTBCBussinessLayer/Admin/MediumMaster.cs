using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MPTBCBussinessLayer
{
   public  class MediumMaster: ICommon 
    {
 private int _MediumTrno_I;
private string _MediunNameHindi_V;
private string _MediunNameEnglish_V;
private int _Trans_I;
public int MediumTrno_I { get { return _MediumTrno_I; } set { _MediumTrno_I = value; } }
public int Trans_I { get { return _Trans_I; } set { _Trans_I = value; } }
public string  MediunNameHindi_V { get { return _MediunNameHindi_V; } set { _MediunNameHindi_V = value; } }
public string MediunNameEnglish_V { get { return _MediunNameEnglish_V; } set { _MediunNameEnglish_V = value; } }
public int InsertUpdate()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_ADM013_MediunMaster_SAVE", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("AMediumTrno_I", MediumTrno_I);
    obDBAccess.addParam("MediunNameHindi_V", MediunNameHindi_V);
    obDBAccess.addParam("MediunNameEnglish_V", MediunNameEnglish_V);
    obDBAccess.addParam("trnasID", Trans_I);
    int result = obDBAccess.executeMyQuery();
    return result;
}

public System.Data.DataSet Select()
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_ADM013_MediumMaster_Load", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("id", MediumTrno_I);
    return obDBAccess.records();
    throw new NotImplementedException();
}

public int Delete(int id)
{
    DBAccess obDBAccess = new DBAccess();
    obDBAccess.execute("USP_ADM013_ADM_MediumMasterDelete", DBAccess.SQLType.IS_PROC);
    obDBAccess.addParam("ID", id);
    int result = obDBAccess.executeMyQuery();
    return result;
    throw new NotImplementedException();
}
    }
}
