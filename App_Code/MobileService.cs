using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using System.Xml.Serialization;
using System.IO;
using System.Text;

/// <summary>
/// Summary description for MobileService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class MobileService : System.Web.Services.WebService {
    CommonFuction comm = new CommonFuction();
    public MobileService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    
    [WebMethod]
    public void BookSellerChallan(int UserID)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc(@"SELECT OrderNo,LoginID_V User_ID_I,SUM(PaikBandal)PaikBandal FROM (
SELECT  dpt_bookselledemandmaster.OrderNo,LoginID_V,
 TotalDemand AS DestributeBook,BookNumber,Depo_ID_I,
FLOOR(( TotalDemand/BookNumber)) AS PaikBandal 
FROM dpt_bookselledemandmaster
       INNER JOIN tbl_bookperbundle ON tbl_bookperbundle.TitleID=dpt_bookselledemandmaster.TitalID_I 
      AND tbl_bookperbundle.`Acyear`=(SELECT `AcYear` FROM `adm_acadmicyears` WHERE `Isactive`=1)
             INNER JOIN dpt_booksellerregistration_m ON dpt_booksellerregistration_m.LoginID_V=dpt_bookselledemandmaster.User_ID_I

WHERE FLOOR(( TotalDemand/BookNumber))<>0  AND Issumbited_I=1
--  AND OrderNo=97451146
) aa  WHERE  Depo_ID_I=" + UserID + " GROUP BY OrderNo");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<InterDepoChallan>";
            xml += "<OrderNo>" + IDDset.Rows[i][0] + "</OrderNo>";
            xml += "<User_ID_I>" + IDDset.Rows[i][1] + "</User_ID_I>";
            xml += "<PaikBandal>" + IDDset.Rows[i][2] + "</PaikBandal>";
            xml += "</InterDepoChallan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
    }
   
    public class Login
    {
        public string UserName;
        public string User_ID;

    }
    public class PrinterNamea
    {
        public string PrinterName;
        public string PrinterID;

    }
    public class ChallanD
    {
        public string ChallanNo;
        public string BundleNoFrom;
        public string BundleNoTo;
        public string ChallanTrID;
        public string BookName;
        public string BookType;
        public string TotalBundle;
        public string TotalBook;
        public string BookNoFrom;
        public string BookNoTo;
        public string PerBandalBook;
        //, BooksToYoj
       // public string PrinterID;

    }
    [WebMethod]
    public void CheckBarcode(int Key) 
    {
        string Status="";
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc("select  ifnull(BarcodeStatus,0)BarcodeStatus from tbl_Barcodekey  where BarcodeKey='" + Key + "'");
        if (IDDset.Rows[0]["BarcodeStatus"].ToString() == "0")
        {
            comm.FillTableByProc("update tbl_Barcodekey set BarcodeStatus=1 where BarcodeKey='" + Key + "'  ");
            Status = "0";
        }
        else
        {
            Status = "1";
        }
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> 
<foo>";


        xml += "<Barocde>";
        xml += "<status>" + Status + "</status>";
        xml += "</Barocde>";
        xml += "</foo>";
        Context.Response.Write(xml);

    }
    public class BlockChallan
    {
        public string ChallanID;
        public string challanNO;
    }
    public class ChallanBookDetails
    {
        public string TitleHindi_V;
        public string TitalID;
    }
    //obCommonFuction.FillDatasetByProc("Call USPDPTGetInterDepoChallan('" + ddlChallano.SelectedValue + "'," + Session["UserID"] + ",'" + lblfyYaer.ToString() + "','" + ddlChallano.SelectedItem.Text + "')");
    [WebMethod]
    public void InterDepoChallanDetails(int Depotid)
    {
        string lblfyYaer;
        lblfyYaer = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc(@"SELECT  TitleNameHindi_K AS TitleHindi_V,ChallanNo,FLOOR( Supply/`BookNumber`)Supply,FLOOR( Supply%`BookNumber`)looj ,
acd_titledetail.TitleID_I FROM dpt_interdepoBookSupply
INNER JOIN acd_titledetail ON acd_titledetail.TitleID_I=dpt_interdepoBookSupply.TitleID 
INNER JOIN `tbl_bookperbundle` ON tbl_bookperbundle.`TitleID`=acd_titledetail.TitleID_I
where SupplierDepoID=" + Depotid + " ORDER BY dpt_interdepoBookSupply.ID  DESC LIMIT 20");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<InterDepoChallan>";
            xml += "<TitleHindi_V>" + IDDset.Rows[i][0] + "</TitleHindi_V>";
            xml += "<ChallanNo>" + IDDset.Rows[i][1] + "</ChallanNo>";
            xml += "<Supply>" + IDDset.Rows[i][2] + "</Supply>";
            xml += "<looj>" + IDDset.Rows[i][3] + "</looj>";
            xml += "<TitleID_I>" + IDDset.Rows[i][4] + "</TitleID_I>";
            //
            xml += "</InterDepoChallan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
        //DBAccess dbAccess = new DBAccess();



    }
    //
    [WebMethod]
    public void InterDepoReceivedChallan(int Depotid)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc(@" SELECT DISTINCT ChallanNO_v, CONCAT( ChallanNO_v,'-',`UserName_V`) ChallanDetails,
FLOOR(SUM(NoOfBookTransferd)/tbl_bookperbundle.`BookNumber`)TotalBundle FROM dpt_interdepobookstransferchild
LEFT JOIN dpt_stockditributeinterdepo_m ON dpt_interdepobookstransferchild.reqno=dpt_stockditributeinterdepo_m.OrderNo_I
INNER JOIN acd_titledetail ON acd_titledetail.TitleID_I=dpt_interdepobookstransferchild.TitleID_I
-- LEFT JOIN adm_depomaster_m ON adm_depomaster_m.DepoTrno_I=dpt_interdepobookstransferchild.SupplierDepoID
INNER JOIN `adm_usersmaster` ON adm_usersmaster.`UserID_I`=dpt_interdepobookstransferchild.SupplierDepoID
INNER JOIN `tbl_bookperbundle` ON tbl_bookperbundle.`TitleID`=dpt_interdepobookstransferchild.TitleID_I
AND tbl_bookperbundle.`Acyear`=(SELECT `AcYear` FROM`adm_acadmicyears` WHERE `Isactive`=1)
WHERE Demandingdepotid="+Depotid+" AND ISStanderd_I=1   AND reqno <>'' AND ChallanNO_V IS NOT NULL  AND  ChallanNO_V NOT IN(SELECT ChallanNo_V FROM dpt_stockreceiveentry_m)GROUP BY ChallanNO_v");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<InterDepoChallan>";
            xml += "<ChallanNO_v>" + IDDset.Rows[i][0] + "</ChallanNO_v>";
            xml += "<ChallanDetails>" + IDDset.Rows[i][1] + "</ChallanDetails>";
            xml += "<TotalBundle>" + IDDset.Rows[i][2] + "</TotalBundle>";
            xml += "</InterDepoChallan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
    }

    [WebMethod]
    public void InterDepoChallan(int Depotid)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc("call USP_DPTInterDepoChallan(" + Depotid + ",0,0)");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<InterDepoChallan>";
            xml += "<ChallanNo_V>" + IDDset.Rows[i][1] + "</ChallanNo_V>";
            xml += "</InterDepoChallan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
        //DBAccess dbAccess = new DBAccess();




    }
    [WebMethod]
    public void GetInterDepo(string userID)
    {
        string s = userID;
        string ChallanID = "";
        string BarCode = "";
        int Count = 0;
        string[] words = s.Split('/');
        foreach (string word in words)
        {
            if (Count == 0)
            {
                ChallanID = word.ToString();
            }
            else
            {
                BarCode = word.ToString();
            }
            Count = Count + 1;

        }

        //XmlDocument a = new XmlDocument();
        //// userID = id;
  comm.FillTableByProc("insert into tblTest(test01) values ('" + userID + "')");

        //XmlDocument xml = new XmlDocument();
        //xml.LoadXml(userID);
        //XmlNodeList xnList = xml.SelectNodes("/foo/BarCodeData");

        //foreach (XmlNode xn in xnList)
        //{

        //    string ChallanID = xn["ChallanID"].InnerText;

        //    string BarCode = xn["BarCode"].InnerText;
        //    try {
  comm.FillDatasetByProc(@"update dpt_stockdetailschild_t set IsDistribute =2 ,DistributID ='" + ChallanID + "' where FIND_IN_SET (BundleNo_I,'" + BarCode + "') AND IsDistribute=0");
           // }
          //  catch { }
           // comm.FillTableByProc("insert into tblTest(test01) values ('" + BarCode + "')");
        

    }

    [WebMethod]
    public void SaveBookSellerChallan(string userID)
    {
        string s = userID;
        string ChallanID = "";
        string BarCode = "";
        int Count = 0;
        string[] words = s.Split('/');
        foreach (string word in words)
        {
            if (Count == 0)
            {
                ChallanID = word.ToString();
            }
            else
            {
                BarCode = word.ToString();
            }
            Count = Count + 1;

        }
        comm.FillDatasetByProc("INSERT INTO tbl_BookSellerChallan (ChallanNO,BundleNo  )VALUES ('" + ChallanID + "','" + BarCode + "')");

        try
        {
            DataSet dt = comm.FillDatasetByProc("select StockDistributionSEntryID_I from dpt_stockdistributionschemeentry_m where `ChallanNo_V`=" + ChallanID + "");
            comm.FillDatasetByProc("UPDATE dpt_stockdetailschild_t SET IsDistribute =4,DistributID =" + dt.Tables[0].Rows[0]["StockDistributionSEntryID_I"].ToString() + ",BookSellerChallan=" + ChallanID + " WHERE FIND_IN_SET (BundleNo_I,'" + BarCode + "') AND IsDistribute=0 AND IFNULL(iflooj,0)=0 and IsOpenMarket=2 ; ");
        }
        catch {  }

         //  UPDATE dpt_stockdetailschild_t SET IsDistribute =4,DistributID =MChalanNo,BookSellerChallan=id WHERE FIND_IN_SET (BundleNo_I,MBundleNo_I) AND IsDistribute=0 AND IFNULL(iflooj,0)=0; 
    }

    [WebMethod]
    public void GetInterDepoBookReceived(string userID)
    {


        //XmlDocument a = new XmlDocument();
        //// userID = id;

      comm.FillTableByProc("insert into tblTest(test01) values ('" + userID + "')");

        //XmlDocument xml = new XmlDocument();
        //xml.LoadXml(userID);
        //XmlNodeList xnList = xml.SelectNodes("/foo/BarCodeData");

        //foreach (XmlNode xn in xnList)
        //{

        //    string ChallanID = xn["ChallanID"].InnerText;

        //    string BarCode = xn["BarCode"].InnerText;
      string s = userID;
      string ChallanID = "";
      string BarCode = "";
      int Count = 0;
      string[] words = s.Split('/');
      foreach (string word in words)
      {
          if (Count == 0)
          {
              ChallanID = word.ToString();
          }
          else
          {
              BarCode = word.ToString();
          }
          Count = Count + 1;

      }
            comm.FillDatasetByProc("call USP_DPTStockUpdate(0," + ChallanID + ",'" + BarCode + "')"); ;
            comm.FillTableByProc("insert into tblTest(test01) values ('" + BarCode + "')");
       //

    }
    //.
    [WebMethod]
    public void GetSchemeData(string userID)
    {
       
       
        //XmlDocument a = new XmlDocument();
        //// userID = id;

       
        string s = userID;
        comm.FillTableByProc("insert into tblTestNew(test01) values ('" + userID + "')");
        // Split string on spaces.
        // ... This will separate all the words.
        string ChallanID = "";
        string BarCode = "";
        int Count = 0;
        string[] words = s.Split('/');
        foreach (string word in words)
        {
            if (Count == 0)
            {
                ChallanID = word.ToString();
            }
            else
            {
                BarCode = word.ToString();
            }
            Count = Count + 1;

        }
        comm.FillTableByProc("insert into tbl_Scheme(ChallanNo,Bundel) values ('" + ChallanID + "','" + BarCode + "')");
        comm.FillDatasetByProc(@"update dpt_stockdetailschild_t set  IsDistribute ='3',DistributID ='" + ChallanID + "' where find_in_Set(BundleNo_I,'" + BarCode + "') and DistributID=0 ");
      
    }
    [WebMethod]
    public void GetInterDepoReceivedDataNew(string userID)
    {
        string s = userID;
        string ChallanID = "";
        string BarCode = "";
        int Count = 0;
        string[] words = s.Split('/');
        foreach (string word in words)
        {
            if (Count == 0)
            {
                ChallanID = word.ToString();
            }
            else
            {
                BarCode = word.ToString();
            }
            Count = Count + 1;

        }
        try {
            comm.FillDatasetByProc("insert into interDepoBarcode(Barocde,Challano )values ('" + BarCode + "','" + ChallanID + "')");
        }
        catch { }
        try
        {
            comm.FillDatasetByProc(@"update dpt_stockdetailschild_t set  IsDistribute ='10',DistributID ='" + ChallanID + "' where find_in_Set(BundleNo_I,'" + BarCode + "')  ");
        }
        catch { }
    }
    //UPDATE dpt_stockdetailschild_t SET IsDistribute=10 WHERE DistributID=DistributIDI AND FIND_IN_SET(BundleNo_I,BundleNoI);
    [WebMethod]
    public void BlockChallanBookDetails(int userID)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc(@"select distinct StockDistributionSEntryID_I,ChallanID,'-'  TitleHindi_V,0 TitalID,0 paikbandal,0 loojbandal
from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.MasterID=StockDistributionSEntryID_I
inner join acd_titledetail on acd_titledetail.TitleID_I=TitalID where userID =" + userID + " ");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<BlockChallan>";
            xml += "<ChallanID>" + IDDset.Rows[i][0] + "</ChallanID>";
            xml += "<ChallanNo>" + IDDset.Rows[i][1] + "</ChallanNo>";
            xml += "<TitleHindi_V>" + IDDset.Rows[i][2] + "</TitleHindi_V>";
            xml += "<TitalID>" + IDDset.Rows[i][3] + "</TitalID>";
            xml += "<paikbandal>" + IDDset.Rows[i][4] + "</paikbandal>";
            xml += "<loojbandal>" + IDDset.Rows[i][5] + "</loojbandal>";
            xml += "</BlockChallan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
        //DBAccess dbAccess = new DBAccess();
        //List<Login> list = new List<Login>();
        //dbAccess.execute(@"SELECT UserID_I, UserName_V FROM adm_usersmaster  where  UserName_V='" + Username + "' and Password_V='" + password + "' ", DBAccess.SQLType.IS_QUERY);
        //DataTable dt = dbAccess.records1();
        //Login ob = new Login();
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {

        //        ob.UserName = Convert.ToString(dr["UserName_V"]);
        //        ob.User_ID = Convert.ToString(dr["UserID_I"]);
        //        list.Add(ob);

        //    }
        //    Context.Response.Write(JsonHelper.JsonSerializer<IList<Login>>(list));
        //}
        //else
        //{
        //    Context.Response.Write("0");
        //}



    }
    [WebMethod]
    public void BlockChallanDetails(int Depotid)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc(@"select DISTINCT StockDistributionSEntryID_I,ChallanNo_V from dpt_stockdistributionschemeentry_m 
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
        where   UserID ='" + Depotid + "' and yearid='2019-2020' and SendStatus not in(1,2) ");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<BlockChallan>";
            xml += "<StockDistributionSEntryID_I>" + IDDset.Rows[i][0] + "</StockDistributionSEntryID_I>";
            xml += "<ChallanNo_V>" + IDDset.Rows[i][1] + "</ChallanNo_V>";
            xml += "</BlockChallan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
        //DBAccess dbAccess = new DBAccess();
      



    }
    [WebMethod]
    public void GetBarcodeDetails(string barcodeNo)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc("CALL USP_DISGetBundleInfo(  " + barcodeNo + ")");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

      
            xml += "<Barcode>";
            xml += "<TitleHindi_V>" + IDDset.Rows[0]["TitleHindi_V"].ToString() + "</TitleHindi_V>";
            xml += "<DepoName_V>" + IDDset.Rows[0]["DepoName_V"].ToString() + "</DepoName_V>";
            xml += "<AcYear>" + IDDset.Rows[0]["AcYear"].ToString() + "</AcYear>";
            xml += "<BookNumberFrom>" + IDDset.Rows[0]["BookNumberFrom"].ToString() + "</BookNumberFrom>";
            xml += "<BookNumberTo>" + IDDset.Rows[0]["BookNumberTo"].ToString() + "</BookNumberTo>";
            xml += "<NameofPress_V>" + IDDset.Rows[0]["NameofPress_V"].ToString() + "</NameofPress_V>";
            xml += "<BooksPerBundle>" + IDDset.Rows[0]["BooksPerBundle"].ToString() + "</BooksPerBundle>";
            xml += "</Barcode>";
       
        xml += "</foo>";
        Context.Response.Write(xml);
        //DBAccess dbAccess = new DBAccess();
        //DS = obCommonFuction.FillDatasetByProc("CALL USP_DISGetBundleInfo(  " + Convert.ToInt64(TxtCode.Text) + ")");
        //if (DS.Tables[0].Rows.Count > 0)
        //{
        //    LblBook.Text = DS.Tables[0].Rows[0]["TitleHindi_V"].ToString();
        //    lblDepo.Text = DS.Tables[0].Rows[0]["DepoName_V"].ToString();
        //    lblPrinter.Text = DS.Tables[0].Rows[0]["NameofPress_V"].ToString();
        //    lblAcyear.Text = DS.Tables[0].Rows[0]["AcYear"].ToString();
        //    lblbookNo.Text = DS.Tables[1].Rows[0]["FromNo_I"].ToString();
        //    lblbookNoto.Text = DS.Tables[1].Rows[0]["ToNo_I"].ToString();
        //    lblTotalBook.Text = DS.Tables[1].Rows[0]["TotalBooks"].ToString();
        //}



    }
    [WebMethod]
    public void UserLogin(string Username, string password)
    {
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc("SELECT UserID_I, UserName_V FROM adm_usersmaster  where  UserName_V='" + Username + "' and Password_V='" + password + "'");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<User>";
            xml += "<User_ID>" + IDDset.Rows[i][0] + "</User_ID>";
            xml += "<UserName>" + IDDset.Rows[i][1] + "</UserName>";
            xml += "</User>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
        //DBAccess dbAccess = new DBAccess();
        //List<Login> list = new List<Login>();
        //dbAccess.execute(@"SELECT UserID_I, UserName_V FROM adm_usersmaster  where  UserName_V='" + Username + "' and Password_V='" + password + "' ", DBAccess.SQLType.IS_QUERY);
        //DataTable dt = dbAccess.records1();
        //Login ob = new Login();
        //if (dt.Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {

        //        ob.UserName = Convert.ToString(dr["UserName_V"]);
        //        ob.User_ID = Convert.ToString(dr["UserID_I"]);
        //        list.Add(ob);

        //    }
        //    Context.Response.Write(JsonHelper.JsonSerializer<IList<Login>>(list));
        //}
        //else
        //{
        //    Context.Response.Write("0");
        //}



    }
    public struct ClientData
    {
        public String Name;
        public int ID;
    }
   

    [WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void CitiesXML()
    {
       
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc ("call GetPrinterName()");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<Printer>";
            xml += "<PrinterID>" + IDDset.Rows[i][0] + "</PrinterID>";
            xml += "<Printername>" + IDDset.Rows[i][1] + "</Printername>";
            xml += "</Printer>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);
    }

    [WebMethod]
    public string GetPrinterName()
    {
        DataSet ds = comm.FillDatasetByProc("call GetPrinterName()");

        using(MemoryStream ms = new MemoryStream())
        {
            using(TextWriter tw = new StreamWriter(ms))
            {
                XmlSerializer xs =  new XmlSerializer(typeof(DataSet));
                xs.Serialize(tw, ds);
                string xml = Encoding.UTF8.GetString(ms.ToArray());

                string s1 = xml.Substring(0, xml.LastIndexOf("</NewDataSet>"));
                string s2 = s1.Substring(s1.LastIndexOf("<NewDataSet>"));

                return s2.Replace("<NewDataSet>","");

            }
        }

    }
    [WebMethod]
    public void PrinterName()
    {
       // PRI_PrinterRegistration obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        // DBAccess dbAccess = new DBAccess();   ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();
        List<PrinterNamea> list = new List<PrinterNamea>();
       // dbAccess.execute(@"SELECT UserID_I, UserName_V FROM adm_usersmaster  where  UserName_V='" + Username + "' and Password_V='" + password + "' ", DBAccess.SQLType.IS_QUERY);
        DataSet dt = comm.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload(0)");

      
        if (dt.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Tables[0].Rows)
            {
                PrinterNamea ob = new PrinterNamea();

                ob.PrinterName = Convert.ToString(dr["NameofPressHindi_V"]);
                ob.PrinterID = Convert.ToString(dr["Printer_RedID_I"]);
                list.Add(ob);

            }
            Context.Response.Write(JsonHelper.JsonSerializer<IList<PrinterNamea>>(list));
        }
        else
        {
            Context.Response.Write("0");
        }

    }
    [WebMethod]
    public void ChallanDetails(string DepotID)
    {
       // PRI_PrinterRegistration obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        //// DBAccess dbAccess = new DBAccess();   ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();
        //List<ChallanD> list = new List<ChallanD>();
        //// dbAccess.execute(@"SELECT UserID_I, UserName_V FROM adm_usersmaster  where  UserName_V='" + Username + "' and Password_V='" + password + "' ", DBAccess.SQLType.IS_QUERY);
        //DataSet dt = comm.FillDatasetByProc("call GetDepoandPrinterWise(" + DepotID + "," + PrinterID + ")");

       
        //if (dt.Tables[0].Rows.Count > 0)
        //{
        //    foreach (DataRow dr in dt.Tables[0].Rows)
        //    {
        //        ChallanD ob = new ChallanD();

        //        ob.ChallanNo = Convert.ToString(dr["ChalanNo"]);
        //        ob.BundleNoFrom = Convert.ToString(dr["BooksFromYoj"]);
        //        ob.BundleNoTo = Convert.ToString(dr["BooksToYoj"]);
        //        ob.ChallanTrID = Convert.ToString(dr["ChallanTrno_I"]);
        //        ob.BookName = Convert.ToString(dr["TitleHindi_V"]);
        //        ob.BookType = Convert.ToString(dr["BookType"]);
        //        ob.TotalBundle = Convert.ToString(dr["PacketsSendAsPerChallanYoj"]);
        //        ob.TotalBook = Convert.ToString(dr["TotalNoBook"]);
        //        ob.BookNoFrom = Convert.ToString(dr["BookFrom"]);
        //        ob.BookNoTo = Convert.ToString(dr["Bookto"]);
        //        ob.PerBandalBook = Convert.ToString(dr["PerBandalBook"]);
                
        //        // BooksFromYoj, BooksToYoj
        //        list.Add(ob);

        //    }
        //    Context.Response.Write(JsonHelper.JsonSerializer<IList<ChallanD>>(list));
        //}
        //else
        //{
        //    Context.Response.Write("0");
        //}
        DataTable IDDset = new DataTable();
        IDDset = comm.FillTableByProc("call GetDepoandPrinterWise(" + DepotID + ")");
        string xml = "<?xml version=" + @"""1.0"" encoding=" + @"""UTF-8""?> <foo>";

        for (int i = 0; i <= IDDset.Rows.Count - 1; i++)
        {
            xml += "<Challan>";
            xml += "<ChalanNo>" + IDDset.Rows[i]["ChalanNo"].ToString() + "</ChalanNo>";
            xml += "<BundleFrom>" + IDDset.Rows[i]["BooksFromYoj"].ToString() + "</BundleFrom>";
            xml += "<BundleTO>" + IDDset.Rows[i]["BooksToYoj"].ToString() + "</BundleTO>";
            xml += "<ChallanTrno_I>" + IDDset.Rows[i]["ChallanTrno_I"].ToString() + "</ChallanTrno_I>";
            xml += "<TitleHindi_V>" + IDDset.Rows[i]["TitleHindi_V"].ToString() + "</TitleHindi_V>";
            xml += "<BookType>" + IDDset.Rows[i]["BookType"].ToString() + "</BookType>";
            xml += "<TotalBundle>" + IDDset.Rows[i]["PacketsSendAsPerChallan"].ToString() + "</TotalBundle>";
            xml += "<TotalBook>" + IDDset.Rows[i]["TotalNoBook"].ToString() + "</TotalBook>";
            xml += "<BookNoFrom>" + IDDset.Rows[i]["BooksFrom"].ToString() + "</BookNoFrom>";
            xml += "<BookNoTo>" + IDDset.Rows[i]["Booksto"].ToString() + "</BookNoTo>";
            xml += "<PerBandalBook>" + IDDset.Rows[i]["PerBandalBook"].ToString() + "</PerBandalBook>";
            xml += "<NameofPress_V>" + IDDset.Rows[i]["NameofPressHindi_V"].ToString() + "</NameofPress_V>";
            
            xml += "</Challan>";
        }
        xml += "</foo>";
        Context.Response.Write(xml);

    }
    [WebMethod]
    public void BundleNo(string bundleNoID)

    {
       comm.FillTableByProc("insert into tblTest(test01) values ('" + bundleNoID + "')");
       try { 
     //   comm.FillTableByProc("UPDATE dpt_stockdetailschild_t SET IsDistribute =9  WHERE   FIND_IN_SET(BundleNo_I, '" + bundleNoID + "')  AND  dpt_stockdetailschild_t.IsDistribute=5");
       }
       catch { }
      //  
    }
   
    // call GetDepoandPrinterWise(" + Session["UserID"] + ")
}
