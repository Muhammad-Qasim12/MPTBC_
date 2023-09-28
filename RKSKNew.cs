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
using System.Web.Script.Serialization;
/// <summary>
/// 
/// Summary description for RKSKNew
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RKSKNew : System.Web.Services.WebService {

    public RKSKNew () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

   
    public string HelloWorld() {
        return "Hello World";
    }
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void SaveAns(string UserID, string QID, string AnsID, string DateN, string Let, string Long
    //  , string Time, string AnsText
    // )
    //{
    //    List<saveData> list = new List<saveData>();
    //    DBAccess dbAccess = new DBAccess();

    //    saveData ob = new saveData();
    //    ob.Resp = "1";
    //    // ob.Div_NameHindi = Convert.ToString(dr["Div_NameHindi"]);
    //    list.Add(ob);

    //    dbAccess.execute(@"insert into CHALLENGE_UserAns(UserID,QID  ,AnsID  ,DateN ,Let ,Long ,Time,AnsText)values ('" + UserID + "'    ,'" + QID + "' ,N'" + AnsID + "'  ,'" + DateN + "','" + Let + "' ,'" + Long + "' ,'" + Time + "',N'" + AnsText + "') ", DBAccess.SQLType.IS_QUERY);
    //    DataTable dt = dbAccess.records1();
    //    //  Context.Response.Write("Record Save successfully");
    //    //Context.Response.Write(i.ToString());
    //    Context.Response.Write(JsonHelper.JsonSerializer<IList<saveData>>(list));

    //}

     
    //  [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public class othrBook
    {
        public string TitleID_I;
        public string TitleHindi_V;
    
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void OtherthanTitleDetails()
    {
        CommonFuction obj = new CommonFuction();
        List<othrBook> list = new List<othrBook>();
        DataTable dt = obj.FillTableByProc("call USP_DIB_Rpt001_DepowiseDemand(40,'-2')");
       
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                othrBook ob = new othrBook();

                ob.TitleID_I = Convert.ToString(dr["LetterNo_V"]);
                ob.TitleHindi_V = Convert.ToString(dr["LetterNo_Va"]);
               
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<othrBook>>(list));
        }

    }
    public class OtherthanAllotmanet1
    {
        public string Title;
        public string DepoName_V;
        public string District;
        public string Allotment;
        public string DistributeBook;
        public string BlockName;
        public string DistrictID;
        public string BlockID;
        public string DepoID;
        public string SubTitleID;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void OtherthanTextbook_Allotment(string TitleID)
    {
        CommonFuction obj = new CommonFuction();
        List<OtherthanAllotmanet1> list = new List<OtherthanAllotmanet1>();
        DataTable dt = obj.FillTableByProc("call USP_OtherhanBlockWiseDepo_N('" + TitleID + "')");
       
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                OtherthanAllotmanet1 ob = new OtherthanAllotmanet1();

                ob.Title = Convert.ToString(dr["Title"]);
                ob.DepoName_V = Convert.ToString(dr["Depo"]);
                ob.District = Convert.ToString(dr["District"]);
                ob.Allotment = Convert.ToString(dr["BRCSupply"]);
                ob.DistributeBook = Convert.ToString(dr["DistributeBook"]);
                ob.BlockName = Convert.ToString(dr["BlockName"]);
                ob.DistrictID = Convert.ToString(dr["DistrictID"]);
                ob.BlockID = Convert.ToString(dr["BlockID"]);
                ob.DepoID = Convert.ToString(dr["DepoID"]);
                ob.SubTitleID = Convert.ToString(dr["SubTitleID"]);

                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<OtherthanAllotmanet1>>(list));
        }

    }
   


    public class Title
    {
        public string TitleID_I;
        public string Medium_I;
        public string ClassTrno_I;
        public string TitleHindi_V;
    }
   
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void TitleDetails()
    {
        DBAccess dbAccess = new DBAccess();
        List<Title> list = new List<Title>();
        dbAccess.execute(@"SELECT TitleID_I , Medium_I,  ClassTrno_I,  TitleHindi_V  FROM `acd_titledetail` WHERE `BookChangeStatus` <>5 ", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
       
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Title ob = new Title();

                ob.TitleID_I = Convert.ToString(dr["TitleID_I"]);
                ob.Medium_I = Convert.ToString(dr["Medium_I"]);
                ob.ClassTrno_I = Convert.ToString(dr["ClassTrno_I"]);
                ob.TitleHindi_V = Convert.ToString(dr["TitleHindi_V"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Title>>(list));
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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Blockmaster()
    {
        CommonFuction obj = new CommonFuction();
        List<Block> list = new List<Block>();
        DataTable dt = obj.FillTableByProc("SELECT BlockTrno_I , DistrictTrno_I,  BlockName_V  ,BlockNameHindi_V   FROM `adm_blockmaster`");
       
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Block ob = new Block();

                ob.BlockTrno_I = Convert.ToString(dr["BlockTrno_I"]);
                ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
                ob.BlockName_V = Convert.ToString(dr["BlockName_V"]);
                ob.BlockNameHindi_V = Convert.ToString(dr["BlockNameHindi_V"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Block>>(list));
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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DistrictMaster()
    {
       // CommonFuction obj = new CommonFuction();
        List<District> list = new List<District>();
        DBAccess dbAccess = new DBAccess();

        dbAccess.execute(@"SELECT DistrictTrno_I , DivisionTrno_I , District_Name_Hindi_V   ,     DepotID_I   FROM `adm_districtmaster`", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        
       
            foreach (DataRow dr in dt.Rows)
            {
                District ob = new District();

                ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
                ob.DivisionTrno_I = Convert.ToString(dr["DivisionTrno_I"]);
                ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
                ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<District>>(list));
       

    }
  
   
    public class Depo
    {
        public string DepoTrno_I;
        public string DepoName_V;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void DepotMaster()
    {

        List<Depo> list = new List<Depo>();
        DBAccess dbAccess = new DBAccess();

        dbAccess.execute(@"SELECT DepoTrno_I , DepoName_V  FROM adm_depomaster_m", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();

        foreach (DataRow dr in dt.Rows)
        {
            Depo ob = new Depo();


                 ob.DepoTrno_I = Convert.ToString(dr["DepoTrno_I"]);
                 ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);
            list.Add(ob);
        }
        Context.Response.Write(JsonHelper.JsonSerializer<IList<Depo>>(list));

        //CommonFuction obj = new CommonFuction();
        //List<Depo> list = new List<Depo>();
        //DataTable dt = obj.FillTableByProc("SELECT DepoTrno_I , DepoName_V  FROM `adm_depomaster_m");
        //Depo ob = new Depo();
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {

        //        ob.DepoTrno_I = Convert.ToString(dr["DepoTrno_I"]);
        //        ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);
               
        //        list.Add(ob);

        //    }
        //    Context.Response.Write(JsonHelper.JsonSerializer<IList<Depo>>(list));
        //}

    }
    
    public class Mediem
    {
        public string MediumTrno_I;
        public string MediunNameHindi_V;

    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void Mediummaster()
    {
        //CommonFuction obj = new CommonFuction();
        List<Mediem> list = new List<Mediem>();
      
        DBAccess dbAccess = new DBAccess();
       
        dbAccess.execute(@"SELECT * FROM adm_mediummaster", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
           foreach (DataRow dr in dt.Rows)
            {
                Mediem ob = new Mediem();
                ob.MediumTrno_I = Convert.ToString(dr["MediumTrno_I"]);
                ob.MediunNameHindi_V = Convert.ToString(dr["MediunNameHindi_V"]);

                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<Mediem>>(list));
       

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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void BookDistribute(string ACYEARID, string medium_I, string ClassA, string DistID)
    {
        CommonFuction obj = new CommonFuction();

        List<Book> list = new List<Book>();

        DataTable dt = obj.FillTableByProc("call USP_GetBookDistributionINBlockDepo('" + ACYEARID + "','" + medium_I + "','" + ClassA + "','" + DistID + "',4)");
      
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Book ob = new Book();

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
        
    }
    public class bOOKD
    {
        public string BlockID;
        public string BlockName;
        public string TitleName;
        public string TitleID;
        public string BookDistribute;
        public string Date;
        public string BookAlloted;
    
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void BooksData(string disID, string Block,string fYYear)
    {
        CommonFuction obj = new CommonFuction();

        List<bOOKD> list = new List<bOOKD>();

        DataTable dt = obj.FillTableByProc("call USP_RKSK_1(" + disID + "," + Block + ",'" + fYYear + "')");
        
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                bOOKD ob = new bOOKD();

                ob.BlockID = Convert.ToString(dr["BlockTrno_I"]);
                ob.BlockName = Convert.ToString(dr["BlockName_V"]);
                ob.TitleName = Convert.ToString(dr["Title_V"]);
                ob.TitleID = Convert.ToString(dr["TitleId"]);
                ob.BookDistribute = Convert.ToString(dr["PradayBook"]);
                ob.Date = Convert.ToString(dr["ChallanDate_D"]);
                ob.BookAlloted = Convert.ToString(dr["NoOfBooks"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<bOOKD>>(list));
        }

    }
   
}
