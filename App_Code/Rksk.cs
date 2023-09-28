using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Globalization;
using System.Xml.Serialization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
/// <summary>
/// Summary description for Rksk
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Rksk : System.Web.Services.WebService {

    public Rksk () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    public DataTable OtherthanTextbook_TitleDetails()
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("TitleID_I");
       dt.Columns.Add("TitleHindi_V");
       DataTable dt12 = obj.FillTableByProc("call USP_DIB_Rpt001_DepowiseDemand(43,'-2')");

        if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["TitleID_I"] = Convert.ToString(dr["LetterNo_V"]);
                dr2["TitleHindi_V"] = Convert.ToString(dr["LetterNo_Va"]);
                dt.Rows.Add(dr2);
            }
        }



        return dt;
    }
    [WebMethod]
    public DataTable OtherthanTextbook_Allotment(string TitleID)
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("Title");
        dt.Columns.Add("DepoName_V");
        dt.Columns.Add("District");
         dt.Columns.Add("Allotment");//BRCSupply
         dt.Columns.Add("DistributeBook");
         dt.Columns.Add("BlockName");
         dt.Columns.Add("DistrictID");
         dt.Columns.Add("BlockID");
         dt.Columns.Add("DepoID");
         dt.Columns.Add("SubTitleID");
        


        

        
        DataTable dt12 = obj.FillTableByProc("call USP_OtherhanBlockWiseDepo_N('" + TitleID + "')");

        if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["Title"] = Convert.ToString(dr["Title"]);
                dr2["DepoName_V"] = Convert.ToString(dr["Depo"]);
                dr2["District"] = Convert.ToString(dr["District"]);
                dr2["BlockName"] = Convert.ToString(dr["BlockName"]);
                dr2["Allotment"] = Convert.ToString(dr["BRCSupply"]);
                dr2["DistributeBook"] = Convert.ToString(dr["DistributeBook"]);

                dr2["DistrictID"] = Convert.ToString(dr["DistrictID"]);
                dr2["BlockID"] = Convert.ToString(dr["BlockID"]);
                dr2["DepoID"] = Convert.ToString(dr["DepoID"]);
                dr2["SubTitleID"] = Convert.ToString(dr["SubTitleID"]);
               // dt.Columns.Add("DistributeBook");
                dt.Rows.Add(dr2);
            }
        }



        return dt;
    } 



    public class Title
    {
        public string TitleID_I;
        public string Medium_I;
        public string ClassTrno_I;
        public string TitleHindi_V;
    }
    [WebMethod]
    public DataTable TitleDetails()
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("TitleID_I");
        dt.Columns.Add("Medium_I");
        dt.Columns.Add("ClassTrno_I");
        dt.Columns.Add("TitleHindi_V");
        DataTable dt12 = obj.FillTableByProc("SELECT TitleID_I , Medium_I,  ClassTrno_I,  TitleHindi_V  FROM `acd_titledetail` WHERE `BookChangeStatus` <>5");

        if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["TitleID_I"] = Convert.ToString(dr["TitleID_I"]);
                dr2["Medium_I"] = Convert.ToString(dr["Medium_I"]);
                dr2["ClassTrno_I"] = Convert.ToString(dr["ClassTrno_I"]);
                dr2["TitleHindi_V"] = Convert.ToString(dr["TitleHindi_V"]);
                dt.Rows.Add(dr2);
            }
        }



        return dt;
    }  
   // [WebMethod]
    public void TitleDetails1()
    {
        DBAccess dbAccess = new DBAccess();
        List<Title> list = new List<Title>();
        dbAccess.execute(@"SELECT TitleID_I , Medium_I,  ClassTrno_I,  TitleHindi_V  FROM `acd_titledetail` WHERE `BookChangeStatus` <>5 ", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        Title ob = new Title();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                ob.TitleID_I = Convert.ToString(dr["TitleID_I"]);
                ob.Medium_I = Convert.ToString(dr["Medium_I"]);
                ob.ClassTrno_I = Convert.ToString(dr["ClassTrno_I"]);
                ob.TitleHindi_V = Convert.ToString(dr["TitleHindi_V"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Title>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }
    }
    public class Block
    {
        public string BlockTrno_I;
        public string DistrictTrno_I;
        public string BlockName_V;
        public string BlockNameHindi_V;
    }
    [WebMethod]
    public DataTable Blockmaster()
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("BlockTrno_I");
        dt.Columns.Add("DistrictTrno_I");
        dt.Columns.Add("BlockName_V");
        dt.Columns.Add("BlockNameHindi_V");
        DataTable dt12 = obj.FillTableByProc("SELECT BlockTrno_I , DistrictTrno_I,  BlockName_V  ,BlockNameHindi_V   FROM `adm_blockmaster`");

        if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["BlockTrno_I"] = Convert.ToString(dr["BlockTrno_I"]);
                dr2["DistrictTrno_I"] = Convert.ToString(dr["DistrictTrno_I"]);
                dr2["BlockName_V"] = Convert.ToString(dr["BlockName_V"]);
                dr2["BlockNameHindi_V"] = Convert.ToString(dr["BlockNameHindi_V"]);
                dt.Rows.Add(dr2);
            }
        }



        return dt;
    }  
    public void Blockmaster1()
    {
        DBAccess dbAccess = new DBAccess();
        List<Block> list = new List<Block>();
        dbAccess.execute(@"SELECT BlockTrno_I , DistrictTrno_I,  BlockName_V  ,BlockNameHindi_V   FROM `adm_blockmaster`", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        Block ob = new Block();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                ob.BlockTrno_I = Convert.ToString(dr["BlockTrno_I"]);
                ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
                ob.BlockName_V = Convert.ToString(dr["BlockName_V"]);
                ob.BlockNameHindi_V = Convert.ToString(dr["BlockNameHindi_V"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Block>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }
    }
    public class District
    {
        public string DistrictTrno_I;
        public string DivisionTrno_I;
        public string District_Name_Hindi_V;
        public string DepotID_I;
    }
    [WebMethod]
    public DataTable DistrictMaster()
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("DistrictTrno_I");
        dt.Columns.Add("DivisionTrno_I");
        dt.Columns.Add("District_Name_Hindi_V");
        dt.Columns.Add("DepotID_I");
      
        DataTable dt12 = obj.FillTableByProc("SELECT DistrictTrno_I , DivisionTrno_I , District_Name_Hindi_V   ,     DepotID_I   FROM `adm_districtmaster`");

        if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["DistrictTrno_I"] = Convert.ToString(dr["DistrictTrno_I"]);
                dr2["DivisionTrno_I"] = Convert.ToString(dr["DivisionTrno_I"]);
                dr2["District_Name_Hindi_V"] = Convert.ToString(dr["District_Name_Hindi_V"]);
                dr2["DepotID_I"] = Convert.ToString(dr["DepotID_I"]);
                dt.Rows.Add(dr2);
            }
        }



        return dt;
    }  
   // [WebMethod]
    public void DistrictMaster1()
    {
        DBAccess dbAccess = new DBAccess();
        List<District> list = new List<District>();
        dbAccess.execute(@"SELECT DistrictTrno_I , DivisionTrno_I , District_Name_Hindi_V   ,     DepotID_I   FROM `adm_districtmaster`", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        District ob = new District();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
                ob.DivisionTrno_I = Convert.ToString(dr["DivisionTrno_I"]);
                ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
                ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<District>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }
    }
    public class Depo
    {
        public string DepoTrno_I;
        public string DepoName_V;
      
    }
    [WebMethod]
    public void DepotMaster()
    {
        DBAccess dbAccess = new DBAccess();
        List<Depo> list = new List<Depo>();
        dbAccess.execute(@"SELECT DepoTrno_I , DepoName_V  FROM `adm_depomaster_m`", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        Depo ob = new Depo();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                ob.DepoTrno_I = Convert.ToString(dr["DepoTrno_I"]);
                ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);
               // ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
              //  ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Depo>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }
    }
    public class Mediem
    {
        public string MediumTrno_I;
        public string MediunNameHindi_V;

    }
    [WebMethod]
    public DataTable mediummaster( )
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("MediumTrno_I");
        dt.Columns.Add("MediunNameHindi_V");

        DataTable dt12 = obj.FillTableByProc("SELECT * FROM adm_mediummaster");

        if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["MediumTrno_I"] = Convert.ToString(dr["MediumTrno_I"]);
                dr2["MediunNameHindi_V"] = Convert.ToString(dr["MediunNameHindi_V"]);
              
                dt.Rows.Add(dr2);
            }
        }



        return dt;
    }   
    
    public void mediummaster1()
    {
        DBAccess dbAccess = new DBAccess();
        List<Mediem> list = new List<Mediem>();
        dbAccess.execute(@"SELECT * FROM `adm_mediummaster`", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        Mediem ob = new Mediem();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                ob.MediumTrno_I = Convert.ToString(dr["MediumTrno_I"]);
                ob.MediunNameHindi_V = Convert.ToString(dr["MediunNameHindi_V"]);
                // ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
                //  ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Mediem>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }
    }
    public class Book
    {
        public string BlockNameHindi_V;
        public string NoOfBooks;
        public string PradayBook;
        public string Title_V;
        public string BlockTrno_I;
        public string TitleId;
        
      //  BlockName_V ,BlockTrno_I

    }
    [WebMethod]
    public void BookDistribute(string ACYEARID, string medium_I, string ClassA, string DistID )
    {
        CommonFuction obj = new CommonFuction();

        List<Book> list = new List<Book>();
        
        DataTable dt = obj.FillTableByProc("call USP_GetBookDistributionINBlockDepo('" + ACYEARID + "','" + medium_I + "','" + ClassA + "','" + DistID + "',4)");
        Book ob = new Book();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                ob.BlockNameHindi_V = Convert.ToString(dr["BlockName_V"]);
                ob.NoOfBooks = Convert.ToString(dr["NoOfBooks"]);
                ob.PradayBook = Convert.ToString(dr["PradayBook"]);
                ob.Title_V = Convert.ToString(dr["Title_V"]);
                ob.BlockTrno_I = Convert.ToString(dr["BlockTrno_I"]);
                ob.TitleId = Convert.ToString(dr["TitleId"]);
                // ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
                //  ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Book>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }
    }
    [WebMethod]
    public DataTable BooksData(string disID ,string Block)
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt = new DataTable();
        dt.TableName = "Mytab";
        dt.Columns.Add("BlockID");
        dt.Columns.Add("BlockName");
        dt.Columns.Add("TitleName");
        dt.Columns.Add("TitleID");
      //  dt.Columns.Add("BookAlloted");
        dt.Columns.Add("BookDistribute");
        dt.Columns.Add("Date");
        DataTable dt12 = obj.FillTableByProc("call USP_RKSK(" + disID + "," + Block + ")");

         if (dt12.Rows.Count > 0)
        {
            foreach (DataRow dr in dt12.Rows)
            {
                DataRow dr2 = dt.NewRow();
                dr2["BlockID"] = Convert.ToString(dr["BlockTrno_I"]);
                dr2["BlockName"] = Convert.ToString(dr["BlockName_V"]);
                dr2["TitleName"] = Convert.ToString(dr["Title_V"]);
                dr2["TitleID"] = Convert.ToString(dr["TitleId"]);
               // dr2["BookAlloted"] = Convert.ToString(dr["NoOfBooks"]);
                dr2["BookDistribute"] = Convert.ToString(dr["PradayBook"]);
                dr2["Date"] = Convert.ToString(dr["ChallanDate_D"]);
                dt.Rows.Add(dr2);
            }
        }

       

        return dt;
    }
    // Datat

    public class NicChallan1
    {
        public string Year;
        public string ChallanNo;
        public string ChallanDate;
        public string DepotID;
        public string Consigneeid;
        public string TotalBundal;
        public string Totalbooks;
        public string TruckNo;
        public string ServiceCode;

        public List<NicChallanDetails> Ch;
        public NicChallan1()
        {

        }
        public NicChallan1(string Year, string ChallanNo, string ChallanDate, string DepotID, string Consigneeid, string TotalBundal, string Totalbooks, string TruckNo, string ServiceCode, List<NicChallanDetails> NicChallanDetails)
        {
            this.Year = Year;
            this.ChallanNo = ChallanNo;
            this.ChallanDate = ChallanDate;
            this.DepotID = DepotID;
            this.Consigneeid = Consigneeid;
            this.TotalBundal = TotalBundal;
            this.Totalbooks = Totalbooks;
            this.TruckNo = TruckNo;
            this.ServiceCode = ServiceCode;
            this.Ch = NicChallanDetails;
        }

    }
    public class NicChallan
    {
        public string Year;
        public string ChallanNo;
        public string ChallanDate;
        public string DepotID;
        public string Consigneeid;
        public string TotalBundal;
        public string Totalbooks;
        public string TruckNo;

        public List<NicChallanDetails> Ch;
        public NicChallan()
        {

        }
        public NicChallan(string Year, string ChallanNo, string ChallanDate, string DepotID, string Consigneeid, string TotalBundal, string Totalbooks, string TruckNo, List<NicChallanDetails> NicChallanDetails)
        {
            this.Year = Year;
            this.ChallanNo = ChallanNo;
            this.ChallanDate = ChallanDate;
            this.DepotID = DepotID;
            this.Consigneeid = Consigneeid;
            this.TotalBundal = TotalBundal;
            this.Totalbooks = Totalbooks;
            this.TruckNo = TruckNo;
            this.Ch = NicChallanDetails;

        }

    }

    public class NicChallanDetails
    {
        public string BookID;
        public string bundleType;
        public string Bundles;
        public string books;
    }
    [WebMethod]
   
    public void BookDispatchDetails(string YearAb, string ServiceCode)
    {
        CommonFuction obj = new CommonFuction();

        List<NicChallan> list = new List<NicChallan>();

        DataTable dt = obj.FillTableByProc("call USP_RKSkNewService('" + YearAb.ToString() + "','" + ServiceCode + "')");

        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                DataTable dt1 = obj.FillTableByProc("call USP_NICnewService2('" + dr["ChallanNo_V"] + "'," + dr["Depoid"] + ")");
                List<NicChallanDetails> list1 = new List<NicChallanDetails>();

                foreach (DataRow dr1 in dt1.Rows)
                {

                    NicChallanDetails ob = new NicChallanDetails();

                    ob.BookID = Convert.ToString(dr1["TitalID"]);
                    ob.bundleType = Convert.ToString(dr1["LoojBandal"]);
                    ob.Bundles = Convert.ToString(dr1["paikbundel"]);
                    ob.books = Convert.ToString(dr1["DestributeBook"]);
                    list1.Add(ob);
                }
                list.Add(new NicChallan(dr["yearIDa"].ToString(), dr["ChallanNo_V"].ToString(), dr["ChallanDate_D"].ToString(), dr["Depoid"].ToString(), dr["StockDistributionSEntryID_I"].ToString(), dr["paikbundel"].ToString(), dr["PradayBook"].ToString(), dr["TruckNo_V"].ToString(), list1));
                //list.Add(new NicChallan (dr["year"], dr["ChallanNo_V"], dr["ChallanDate_D"], dr["Depoid"], dr["StockDistributionSEntryID_I"], dr["paikbundel"], dr["PradayBook"], dr["TruckNo_V"], list1));
            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<NicChallan>>(list));
        }

    }
    [WebMethod]
   // [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void BookDispatchDetailsByChallan(string Year)
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt;
        List<NicChallan1> list = new List<NicChallan1>();


        dt = obj.FillTableByProc("call USP_RKSkNewService2('" + Year.ToString() + "')");


        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                DataTable dt1 = obj.FillTableByProc("call USP_NICnewService2('" + dr["ChallanNo_V"] + "'," + dr["Depoid"] + ")");
                List<NicChallanDetails> list1 = new List<NicChallanDetails>();

                foreach (DataRow dr1 in dt1.Rows)
                {

                    NicChallanDetails ob = new NicChallanDetails();

                    ob.BookID = Convert.ToString(dr1["TitalID"]);
                    ob.bundleType = Convert.ToString(dr1["LoojBandal"]);
                    ob.Bundles = Convert.ToString(dr1["paikbundel"]);
                    ob.books = Convert.ToString(dr1["DestributeBook"]);
                    list1.Add(ob);
                }
                list.Add(new NicChallan1(dr["yearIDa"].ToString(), dr["ChallanNo_V"].ToString(), dr["ChallanDate_D"].ToString(), dr["Depoid"].ToString(), dr["StockDistributionSEntryID_I"].ToString(), dr["paikbundel"].ToString(), dr["PradayBook"].ToString(), dr["TruckNo_V"].ToString(), "F345A8F1-CE8C-4388-9DB1-B84D2C50C1A8", list1));
                //list.Add(new NicChallan (dr["year"], dr["ChallanNo_V"], dr["ChallanDate_D"], dr["Depoid"], dr["StockDistributionSEntryID_I"], dr["paikbundel"], dr["PradayBook"], dr["TruckNo_V"], list1));
            }
            var url = "http://shikshaportal.mp.gov.in/Textbooks/Webservices/T3B.svc/C";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/raw";
            httpRequest.ContentType = "application/raw";

            string jd = JsonHelper.JsonSerializer<IList<NicChallan1>>(list);
           int length=0;
            length=jd.Length-2;

            jd = jd.Substring(1, length);
            using (var streamWriter = new StreamWriter(httpRequest.GetRequestStream()))
            {
                streamWriter.Write(jd);
            }

            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }

            Console.WriteLine(httpResponse.StatusCode);
            Context.Response.Write(httpResponse.StatusCode);
        }



    }
}
