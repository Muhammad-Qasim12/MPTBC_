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
using System.Net;

using System.Web.Script.Serialization;

/// <summary>
/// 
/// Summary description for RKSKNew
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RKSKNew : System.Web.Services.WebService
{

    public RKSKNew()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    public string HelloWorld()
    {
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
        public string AcYear;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Title> TitleDetails(string ACYEARID)
    {
        DBAccess dbAccess = new DBAccess();
        List<Title> list = new List<Title>();
        dbAccess.execute(@"SELECT TitleID_I , Medium_I,  ClassTrno_I,  TitleHindi_V ,AcYear FROM `acd_titledetail`
INNER JOIN adm_acadmicyears A ON A.Id = acd_titledetail.AcademicYrId_I
WHERE `BookChangeStatus` <>5  AND Isactive = 1  
UNION
SELECT DISTINCT CONCAT(sb.SubTitleID_I)TitleID,0 AS Medium_I,Class AS ClassTrno_I,CONCAT(TitleHindi_V,'-',SubTitleHindi_V)SubTitle,YEAR AS AcYear FROM acb_subtitle sb

INNER JOIN acb_titledetail t ON t.TitleID_I=sb.TitleID_I
WHERE `Year`= ('" + ACYEARID + "') AND `Class`='1-8'  ", DBAccess.SQLType.IS_QUERY);
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
                ob.AcYear = Convert.ToString(dr["AcYear"]);
                list.Add(ob);

            }
            //Context.Response.Write(JsonHelper.JsonSerializer<IList<Title>>(list));
        }
        return list;
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

    public List<District> DistrictMaster()
    {
        List<District> list = new List<District>();
        DBAccess dbAccess = new DBAccess();
        dbAccess.execute(@"SELECT DistrictTrno_I , DivisionTrno_I , District_Name_Hindi_V   ,     DepotID_I   FROM `adm_districtmaster` where OrderBy IS NOT NULL", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                District ob = new District();

                ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
                ob.DivisionTrno_I = Convert.ToString(dr["DivisionTrno_I"]);
                ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
                ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
                list.Add(ob);

            }
        }
        return list;

    }




    //public void DistrictMaster()
    //{
    //   // CommonFuction obj = new CommonFuction();
    //    List<District> list = new List<District>();
    //    DBAccess dbAccess = new DBAccess();

    //    dbAccess.execute(@"SELECT DistrictTrno_I , DivisionTrno_I , District_Name_Hindi_V   ,     DepotID_I   FROM `adm_districtmaster`", DBAccess.SQLType.IS_QUERY);
    //    DataTable dt = dbAccess.records1();


    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            District ob = new District();

    //            ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
    //            ob.DivisionTrno_I = Convert.ToString(dr["DivisionTrno_I"]);
    //            ob.District_Name_Hindi_V = Convert.ToString(dr["District_Name_Hindi_V"]);
    //            ob.DepotID_I = Convert.ToString(dr["DepotID_I"]);
    //            list.Add(ob);

    //        }
    //        Context.Response.Write(JsonHelper.JsonSerializer<IList<District>>(list));


    //}




    public class Depo
    {
        public string DepoTrno_I;
        public string DepoName_V;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Depo> DepotMaster()
    {
        List<Depo> list = new List<Depo>();
        DBAccess dbAccess = new DBAccess();

        dbAccess.execute(@"SELECT DepoTrno_I , DepoName_V  FROM adm_depomaster_m", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Depo ob = new Depo();


                ob.DepoTrno_I = Convert.ToString(dr["DepoTrno_I"]);
                ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);
                list.Add(ob);
            }
        }
        return list;
    }


    //public class Depo
    //{
    //    public string DepoTrno_I;
    //    public string DepoName_V;

    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    //public void DepotMaster()
    //{

    //    List<Depo> list = new List<Depo>();
    //    DBAccess dbAccess = new DBAccess();

    //    dbAccess.execute(@"SELECT DepoTrno_I , DepoName_V  FROM adm_depomaster_m", DBAccess.SQLType.IS_QUERY);
    //    DataTable dt = dbAccess.records1();

    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        Depo ob = new Depo();


    //             ob.DepoTrno_I = Convert.ToString(dr["DepoTrno_I"]);
    //             ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);
    //        list.Add(ob);
    //    }

    //    Context.Response.Write(JsonHelper.JsonSerializer<IList<Depo>>(list));

    //    //CommonFuction obj = new CommonFuction();
    //    //List<Depo> list = new List<Depo>();
    //    //DataTable dt = obj.FillTableByProc("SELECT DepoTrno_I , DepoName_V  FROM `adm_depomaster_m");
    //    //Depo ob = new Depo();
    //    //if (dt.Rows.Count > 0)
    //    //{
    //    //    foreach (DataRow dr in dt.Rows)
    //    //    {

    //    //        ob.DepoTrno_I = Convert.ToString(dr["DepoTrno_I"]);
    //    //        ob.DepoName_V = Convert.ToString(dr["DepoName_V"]);

    //    //        list.Add(ob);

    //    //    }
    //    //    Context.Response.Write(JsonHelper.JsonSerializer<IList<Depo>>(list));
    //    //}

    //}

    public class Mediem
    {
        public string MediumTrno_I;
        public string MediunNameHindi_V;

    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public List<Mediem> Mediummaster()
    {
        CommonFuction obj = new CommonFuction();
        List<Mediem> list = new List<Mediem>();
        DBAccess dbAccess = new DBAccess();
        dbAccess.execute(@"SELECT * FROM adm_mediummaster", DBAccess.SQLType.IS_QUERY);
        DataTable dt = dbAccess.records1();
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                Mediem ob = new Mediem();
                ob.MediumTrno_I = Convert.ToString(dr["MediumTrno_I"]);
                ob.MediunNameHindi_V = Convert.ToString(dr["MediunNameHindi_V"]);

                list.Add(ob);

            }
        }
        return list;
    }


    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void Mediummaster()
    //{
    //    CommonFuction obj = new CommonFuction();
    //    List<Mediem> list = new List<Mediem>();

    //    DBAccess dbAccess = new DBAccess();

    //    dbAccess.execute(@"SELECT * FROM adm_mediummaster", DBAccess.SQLType.IS_QUERY);
    //    DataTable dt = dbAccess.records1();
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        Mediem ob = new Mediem();
    //        ob.MediumTrno_I = Convert.ToString(dr["MediumTrno_I"]);
    //        ob.MediunNameHindi_V = Convert.ToString(dr["MediunNameHindi_V"]);

    //        list.Add(ob);

    //    }
    //    Context.Response.Write(JsonHelper.JsonSerializer<IList<Mediem>>(list));


    //}


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

    public class TotalSumbookDetails
    {
        public string Title_ID;
        public string block_Id;
        public string noof_Books;

    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public List<TotalSumbookDetails> Totalsumbookwise(string Year, string DemandTypeId)
    {

        CommonFuction obj = new CommonFuction();
        List<TotalSumbookDetails> list = new List<TotalSumbookDetails>();
        DataTable dt;

        dt = obj.FillTableByProc("call Totalsumbookwise('" + Year.ToString() + "','" + DemandTypeId + "')");
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                TotalSumbookDetails ob = new TotalSumbookDetails();
                ob.Title_ID = Convert.ToString(dr["TitleID"]);
                ob.block_Id = Convert.ToString(dr["blockId"]);
                ob.noof_Books = Convert.ToString(dr["noofBooks"]);
                list.Add(ob);

            }
        }
        return list;

    }
    //public void Totalsumbookwise(string Year, string DemandTypeId)
    //{
    //    CommonFuction obj = new CommonFuction();
    //    DataTable dt;
    //    List<TotalSumbookDetails> list = new List<TotalSumbookDetails>();

    //    dt = obj.FillTableByProc("call Totalsumbookwise('" + Year.ToString() + "','" + DemandTypeId + "')");

    //    if (dt.Rows.Count > 0)
    //    {
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            TotalSumbookDetails ob = new TotalSumbookDetails();

    //            ob.Title_ID = Convert.ToString(dr["TitleID"]);
    //            ob.block_Id = Convert.ToString(dr["blockId"]);
    //            ob.noof_Books = Convert.ToString(dr["noofBooks"]);
    //            list.Add(ob);

    //        }
    //        Context.Response.Write(JsonHelper.JsonSerializer<IList<TotalSumbookDetails>>(list));
    //    }
    //}


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

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void BooksData(string disID, string Block, string fYYear)
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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public void BookDispatchDetails(string Year, string ServiceCode, string Consigneeid)
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt;
        List<NicChallan> list = new List<NicChallan>();

        if (Consigneeid == "0")
        {
            dt = obj.FillTableByProc("call USP_RKSkNewService('" + Year.ToString() + "','" + ServiceCode + "','" + Consigneeid + "')");
        }
        else
        {

            dt = obj.FillTableByProc("call USP_RKSkNewService1('" + Year.ToString() + "','" + ServiceCode + "','" + Consigneeid + "')");
        }

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


    public class NicChallanDetailsCopy
    {
        public string BookID;
        public string bundleType;
        public string Bundles;
        public string books;
    }
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public List<NicChallanDetailsCopy> BookDispatchDetailsCopyVersion(string Year, string ServiceCode, string Consigneeid)
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt;
        List<NicChallanDetailsCopy> list = new List<NicChallanDetailsCopy>();

        if (Consigneeid == "0")
        {
            dt = obj.FillTableByProc("call USP_RKSkNewService('" + Year.ToString() + "','" + ServiceCode + "','" + Consigneeid + "')");
        }
        else
        {

            dt = obj.FillTableByProc("call USP_RKSkNewService1('" + Year.ToString() + "','" + ServiceCode + "','" + Consigneeid + "')");
        }
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {

                DataTable dt1 = obj.FillTableByProc("call USP_NICnewService2('" + dr["ChallanNo_V"] + "'," + dr["Depoid"] + ")");
                // List<NicChallanDetailsCopy> list = new List<NicChallanDetailsCopy>();

                foreach (DataRow dr1 in dt1.Rows)
                {

                    NicChallanDetailsCopy ob = new NicChallanDetailsCopy();

                    ob.BookID = Convert.ToString(dr1["TitalID"]);
                    ob.bundleType = Convert.ToString(dr1["LoojBandal"]);
                    ob.Bundles = Convert.ToString(dr1["paikbundel"]);
                    ob.books = Convert.ToString(dr1["DestributeBook"]);
                    list.Add(ob);
                }
                // list.Add(new NicChallan(dr["yearIDa"].ToString(), dr["ChallanNo_V"].ToString(), dr["ChallanDate_D"].ToString(), dr["Depoid"].ToString(), dr["StockDistributionSEntryID_I"].ToString(), dr["paikbundel"].ToString(), dr["PradayBook"].ToString(), dr["TruckNo_V"].ToString(), list1));

            }
        }
        return list;


    }




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
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void BookDispatchDetailsByChallan(string Challan)
    {
        CommonFuction obj = new CommonFuction();
        DataTable dt;
        List<NicChallan1> list = new List<NicChallan1>();


        dt = obj.FillTableByProc("call USP_RKSkNewService2('" + Challan.ToString() + "')");


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
            var url = "https://shikshaportal.mp.gov.in/Textbooks/Webservices/T3B.svc/C";



            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls;
            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";

            httpRequest.Accept = "application/raw";
            httpRequest.ContentType = "application/raw";

            string jd = JsonHelper.JsonSerializer<IList<NicChallan1>>(list);
            int length = 0;
            length = jd.Length - 2;

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
            try
            {
                obj.FillDatasetByProc("insert into NIC_ChallanStatus(ChallanNo,  ChallanStatus , DATE  )values ('" + Challan.ToString() + "','" + httpResponse.StatusCode + "','" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')");
            }
            catch { }
            Console.WriteLine(httpResponse.StatusCode);
            Context.Response.Write(httpResponse.StatusCode);
        }



    }














    //public class NicChallan1CopyVersion
    //{
    //    public string Year;
    //    public string ChallanNo;
    //    public string ChallanDate;
    //    public string DepotID;
    //    public string Consigneeid;
    //    public string TotalBundal;
    //    public string Totalbooks;
    //    public string TruckNo;
    //    public string ServiceCode;

    //    public List<NicChallanDetails> Ch;
    //    public NicChallan1CopyVersion()
    //    {

    //    }
    //    public NicChallan1CopyVersion(string Year, string ChallanNo, string ChallanDate, string DepotID, string Consigneeid, string TotalBundal, string Totalbooks, string TruckNo, string ServiceCode, List<NicChallanDetails> NicChallanDetails)
    //    {
    //        this.Year = Year;
    //        this.ChallanNo = ChallanNo;
    //        this.ChallanDate = ChallanDate;
    //        this.DepotID = DepotID;
    //        this.Consigneeid = Consigneeid;
    //        this.TotalBundal = TotalBundal;
    //        this.Totalbooks = Totalbooks;
    //        this.TruckNo = TruckNo;
    //        this.ServiceCode = ServiceCode;
    //        this.Ch = NicChallanDetails;
    //    }

    //}
    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]


    //public List<NicChallanDetailsCopy> BookDispatchDetailsByChallanCopyVersion(string Challan)
    //{
    //    CommonFuction obj = new CommonFuction();
    //    DataTable dt;
    //    List<NicChallan1CopyVersion> list = new List<NicChallan1CopyVersion>();
    //    dt = obj.FillTableByProc("call USP_RKSkNewService2('" + Challan.ToString() + "')");

    //    if (dt.Rows.Count > 0)
    //    {
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            DataTable dt1 = obj.FillTableByProc("call USP_NICnewService2('" + dr["ChallanNo_V"] + "'," + dr["Depoid"] + ")");
    //            List<NicChallanDetails> list1 = new List<NicChallanDetails>();

    //            foreach (DataRow dr1 in dt1.Rows)
    //            {

    //                NicChallanDetails ob = new NicChallanDetails();

    //                ob.BookID = Convert.ToString(dr1["TitalID"]);
    //                ob.bundleType = Convert.ToString(dr1["LoojBandal"]);
    //                ob.Bundles = Convert.ToString(dr1["paikbundel"]);
    //                ob.books = Convert.ToString(dr1["DestributeBook"]);
    //                list1.Add(ob);
    //            }
    //        }
    //    }
    //    return list;
    //}
   












    //public class Block
    //{
    //    public string BlockTrno_I;
    //    public string DistrictTrno_I;
    //    public string BlockName_V;
    //    public string BlockNameHindi_V;
    //}

    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void Blockmaster()
    //{
    //    CommonFuction obj = new CommonFuction();
    //    List<Block> list = new List<Block>();
    //    DataTable dt = obj.FillTableByProc("SELECT BlockTrno_I , DistrictTrno_I,  BlockName_V  ,BlockNameHindi_V   FROM `adm_blockmaster`");

    //    if (dt.Rows.Count > 0)
    //    {
    //        foreach (DataRow dr in dt.Rows)
    //        {
    //            Block ob = new Block();

    //            ob.BlockTrno_I = Convert.ToString(dr["BlockTrno_I"]);
    //            ob.DistrictTrno_I = Convert.ToString(dr["DistrictTrno_I"]);
    //            ob.BlockName_V = Convert.ToString(dr["BlockName_V"]);
    //            ob.BlockNameHindi_V = Convert.ToString(dr["BlockNameHindi_V"]);
    //            list.Add(ob);

    //        }
    //        Context.Response.Write(JsonHelper.JsonSerializer<IList<Block>>(list));
    //    }

    //}



    //Changes as per the Ankur sir 

    public class Block
    {
        public string BlockTrno_I;
        public string DistrictTrno_I;
        public string BlockName_V;
        public string BlockNameHindi_V;
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public List<Block> Blockmaster()
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
        }
        return list;
    }


}
