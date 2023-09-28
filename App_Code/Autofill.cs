using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
 
using System.Collections.Generic;
using System.IO;
using MPTBCBussinessLayer;

/// <summary>
/// Summary description for Autofill
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Autofill : System.Web.Services.WebService {

    public Autofill()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    /// <summary>
    /// ///////////////////////// for search ULB name
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public DataTable FillPaperQuality(string Name)
    {
        PPR_PaperMaster ObjPaperMaster = null;
        ObjPaperMaster = new PPR_PaperMaster();
        ObjPaperMaster.PaperTrId_I = 0;
        DataSet  ds = new DataSet();
        ds = ObjPaperMaster.Select();
 
        return  ds.Tables[0];


    }


    [WebMethod(true)]
    public List<string> AutoCompleteLocationPaper(string location)
    {

        List<string> result = null;
        try
        {


            DataTable data = FillPaperQuality(location);
            result = new List<string>();
            foreach (DataRow dr in data.Rows)
            {
                result.Add(dr["PaperQuality_V"].ToString());

            }
        }
        catch { }
        finally { }
        return result;
    }

/// <summary>
/// ////////////////// for Search ULB trNo 
/// </summary>
/// <param name="Name"></param>
/// <returns></returns>


    /*
    public DataTable FillULBTrno(string Name)
    {
        DBaccess obj = new DBaccess();
        DataTable dt = new DataTable();
        obj.openConnection();
        obj.execute("SSM_ULBTrnosearch", DBaccess.SQLType.IS_PROC);
        obj.addParam("@ULB", SqlDbType.NVarChar, Name, DBaccess.SqlDirection.IN);

        dt = obj.records1();
        obj.closeConnection();
        return dt;


    }

 
    [WebMethod(true)]
    public List<string> AutoCompleteLocationULBTrno(string location)
    {

        List<string> result = null;
        try
        {


            DataTable data = FillULBTrno(location);
            result = new List<string>();
            foreach (DataRow dr in data.Rows)
            {
                result.Add(dr["OfficeTrno_N"].ToString());

            }
        }
        catch { }
        finally { }
        return result;
    }
      


    public DataTable Fill(string Name)
    {
        DBaccess obj = new DBaccess();
        DataTable dt = new DataTable();
        obj.openConnection();
        obj.execute("EZN_SearchULB", DBaccess.SQLType.IS_PROC);
        obj.addParam("@ULB", SqlDbType.NVarChar, Name, DBaccess.SqlDirection.IN);

        dt = obj.records1();
        obj.closeConnection();
        return dt;


    }


    [WebMethod(true)]
    public List<string> AutoCompleteLocation(string location)
    {

        List<string> result = null;
        try
        {


            DataTable data = Fill(location);
            result = new List<string>();
            foreach (DataRow dr in data.Rows)
            {
                result.Add(dr["ULB"].ToString());

            }
        }
        catch { }
        finally { }
        return result;
    } 
     */

}

