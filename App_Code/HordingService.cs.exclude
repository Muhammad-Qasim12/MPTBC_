using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;


/// <summary>
/// Summary description for HordingService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HordingService : System.Web.Services.WebService
{

    public HordingService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

  
    
    public class Hording
    {
        public string HordingName;
        public string HordingWindow;
        public string HordingType;
        public double Latitude;
        public double Lonitude;
        public string AjancyId;
        public string Zone;
    }



//    [WebMethod]
//    public void UserLogin(string username, string password, string DiviceID)
//    {
//        DBAccess dbAccess = new DBAccess();
//        dbAccess.execute(@"SELECT [UserID]
//      ,[CollegeID_I]
//      ,[UserName_V]
//      ,[Password_V]
//      ,[UserType]
//      ,[CreateDate_D]
//      ,[Active]
//      FROM [Tbl_UserMaster] where UserName_V ='" + username + "'  and Password_V ='" + password + "'", DBAccess.SQLType.IS_QUERY);
//        DataTable dt = dbAccess.records1();

//        if (dt.Rows.Count > 0)
//        {
//            dbAccess.execute("update Tbl_UserMaster set DeviceID='" + DiviceID + "' where UserName_V ='" + username + "'and Password_V ='" + password + "'", DBAccess.SQLType.IS_QUERY);
//            dbAccess.executeMyQuery();
//            Context.Response.Write("1");

//        }
//        else { Context.Response.Write("0"); }


//    }
//    [WebMethod]
//    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
//    public void SaveRegistration(string EmplooyeeName, string EmployeeCode, string Designationname, string Department, string DateofJoining, string Address)
//    {
//        DBAccess dbAccess = new DBAccess();

//        dbAccess.execute(@"INSERT INTO Tbl_EmployeeReg
//           (EmplooyeeName
//           ,EmployeeCode
//           ,Designationname ,Department,DateofJoining,Address)
//     VALUES
//           ('" + EmplooyeeName + "','" + EmployeeCode + "','" + Designationname + "','" + Department + "','" + DateofJoining + "','" + Address + "') ", DBAccess.SQLType.IS_QUERY);
//        DataTable dt = dbAccess.records1();
//        Context.Response.Write("Record Save successfully");
//    }
//    [WebMethod]
//    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
//    public void SendGPSData(string lat, string longg, string devices_id, string Date, string address)
//    {
//        DBAccess dbAccess = new DBAccess();

//        dbAccess.execute(@"INSERT INTO Tbl_Latlog
//           (Lat ,longg,devices_id,address)
//     VALUES('" + lat + "','" + longg + "','" + devices_id + "','" + address + "') ", DBAccess.SQLType.IS_QUERY);
//        DataTable dt = dbAccess.records1();
//        Context.Response.Write("Record Save successfully");
//    }
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void SendGPSDataWithLocation(string lat, string longg, string devices_id, string Distance, string address)
    //{
    //    DBAccess dbAccess = new DBAccess();

    //    dbAccess.execute(@"INSERT INTO tbl_LetlongDetails  (lat ,longg,devices_ID ,Distance ,address) VALUES('" + lat + "','" + longg + "','" + devices_id + "','" + Distance + "','" + address + "') ", DBAccess.SQLType.IS_QUERY);
    //    DataTable dt = dbAccess.records1();
    //    Context.Response.Write("Record Save successfully");
    //}
    [WebMethod]
    public void DepoWiseStock()
    {
        CommonFuction cm = new CommonFuction();
        List<YearWiseDemandA> list = new List<YearWiseDemandA>();
       // dbAccess.execute(@"SELECT ,Lat,longg,devices_id,convert(varchar,Date,106)Date FROM Tbl_Latlog where devices_id=" + devices_id + " and Date='" + Date + "' ", DBAccess.SQLType.IS_QUERY);

        DataSet ds = cm.FillDatasetByProc("call MD_Daskbord(002)");
        DataTable dt =ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            YearWiseDemandA ob = new YearWiseDemandA();
            ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);
            ob.Books = Convert.ToString(dr["Books"]);
          
            list.Add(ob);
        }
        Context.Response.Write(JsonHelper.JsonSerializer<IList<YearWiseDemandA>>(list));
    }
    [WebMethod]
    public void LegalCaseStatus()
    {
        CommonFuction cm = new CommonFuction();
        List<LegalCourtA> list = new List<LegalCourtA>();
        // dbAccess.execute(@"SELECT ,Lat,longg,devices_id,convert(varchar,Date,106)Date FROM Tbl_Latlog where devices_id=" + devices_id + " and Date='" + Date + "' ", DBAccess.SQLType.IS_QUERY);

        DataSet ds = cm.FillDatasetByProc("call MD_Daskbord(0)");
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            LegalCourtA ob = new LegalCourtA();
            ob.pending = Convert.ToString(dr["pending"]);
            ob.Resoled = Convert.ToString(dr["Resoled"]);
            ob.Newcase = Convert.ToString(dr["Newcase"]);
            list.Add(ob);
        }
        Context.Response.Write(JsonHelper.JsonSerializer<IList<LegalCourtA>>(list));
    }
    [WebMethod]
    public void PaperStcok()
    {
        CommonFuction cm = new CommonFuction();
        List<PaperStockA> list = new List<PaperStockA>();
        // dbAccess.execute(@"SELECT ,Lat,longg,devices_id,convert(varchar,Date,106)Date FROM Tbl_Latlog where devices_id=" + devices_id + " and Date='" + Date + "' ", DBAccess.SQLType.IS_QUERY);

        DataSet ds = cm.FillDatasetByProc("call MD_Daskbord(003)");
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            PaperStockA ob = new PaperStockA();
            ob.CoverInformation = Convert.ToString(dr["CoverInformation"]);
            ob.PaperType = Convert.ToString(dr["PaperType"]);
            ob.TotAllot = Convert.ToString(dr["TotAllot"]);
            ob.TotReq = Convert.ToString(dr["TotReq"]);
            list.Add(ob);
        }
        Context.Response.Write(JsonHelper.JsonSerializer<IList<PaperStockA>>(list));
    }
    [WebMethod]
    public void CurentYearDemand(string FinancialYeAR)
    {
        CommonFuction cm = new CommonFuction();
        List<demand> list = new List<demand>();
        // dbAccess.execute(@"SELECT ,Lat,longg,devices_id,convert(varchar,Date,106)Date FROM Tbl_Latlog where devices_id=" + devices_id + " and Date='" + Date + "' ", DBAccess.SQLType.IS_QUERY);

        DataSet ds = cm.FillDatasetByProc("call MD_Daskbord('" + FinancialYeAR + "')");
        DataTable dt = ds.Tables[0];
        foreach (DataRow dr in dt.Rows)
        {
            demand ob = new demand();
            ob.NoOfBooksRSK = Convert.ToString(dr["NoOfBooksRSK"]);
            ob.NoOfBooksDPI = Convert.ToString(dr["NoOfBooksDPI"]);
            ob.CurntYearDmndBook_I = Convert.ToString(dr["CurntYearDmndBook_I"]);
             list.Add(ob);
        }
        Context.Response.Write(JsonHelper.JsonSerializer<IList<demand>>(list));
    }
    public class YearWiseDemandA
    {
        public string DepoName_V;
        public string Books;
     
    }
    public class LegalCourtA
    {
        public string pending;
        public string Resoled;
        public string Newcase;
    }
    public class PaperStockA
    {
        public string CoverInformation;
        public string PaperType;
        public string TotAllot;
        public string TotReq;
    }

    public class demand
    {
        public string NoOfBooksRSK;
        public string NoOfBooksDPI;
        public string CurntYearDmndBook_I;
      
    }

}