using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Collections.Generic;
using System.Web.Script.Serialization;
public partial class MobiBookReceived : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    DBAccess db = new DBAccess();
    JavaScriptSerializer jsonSerializer = new JavaScriptSerializer();
    public DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds = comm.FillDatasetByProc("call USP_DPT018_PrinterDelivery_load(" + Session["UserID"] + ",1)");
            DropDownList1.DataTextField = "ChalanNo";
            DropDownList1.DataValueField = "ChallanTrno_I";
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataBind();

        }
        //if (Request.QueryString["Flag"] != null)
        //{
        //    if (Request.QueryString["Flag"] == "Loadddl")
        //    {
        //        ddlLoad();
        //    }
        //    if (Request.QueryString["Flag"] == "SaveData")
        //    {
        //        SaveBandalDetails(Request.QueryString["ChallanNO"].ToString(), Request.QueryString["BandalNO"].ToString());
        //    }
        //}
    }
    [System.Web.Services.WebMethod]
    public List<MobileChallanNo> SaveBandalDetails(string ChallanNO, string BandalNO)
    {
        List<MobileChallanNo> st = new List<MobileChallanNo>();
        BandalNO = 0 + BandalNO;
      
        MobileChallanNo ddl = new MobileChallanNo();
        ddl.Msg = "Ok";
        st.Add(ddl);
        HttpContext.Current.Response.Write(jsonSerializer.Serialize(st));
        HttpContext.Current.Response.ContentType = "application/json";
        HttpContext.Current.Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
        HttpContext.Current.Response.SuppressContent = true;
        return st;
    }

    public List<MobileChallanNo> ddlLoad()
     {
         List<MobileChallanNo> st = new List<MobileChallanNo>();
         try
         {
             ds = comm.FillDatasetByProc("call USP_DPT018_PrinterDelivery_load("+Session["UserID"]+",1)");
             if (ds.Tables[0].Rows.Count > 0)
             {
                 for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                 {
                     MobileChallanNo ddl = new MobileChallanNo();
                     ddl.ChalanNo = ds.Tables[0].Rows[i]["ChalanNo"].ToString();
                     ddl.ChallanTrno_I = ds.Tables[0].Rows[i]["ChallanTrno_I"].ToString();
                     st.Add(ddl);
                 }
             }
         }
         catch
         {
             // return new List<string>();
         }
         HttpContext.Current.Response.Write(jsonSerializer.Serialize(st));
         HttpContext.Current.Response.ContentType = "application/json";
         HttpContext.Current.Response.Flush();
         HttpContext.Current.ApplicationInstance.CompleteRequest();
         HttpContext.Current.Response.SuppressContent = true;
         return st;
     }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
      
DataSet ds= comm.FillDatasetByProc("call Bundalnogeneratenew('" + textbox.InnerHtml + "')");
        
   
        textbox.InnerHtml = "";
        Label1.Text = "Total No (" + ds.Tables[0].Rows[0]["TotalNO"].ToString() + " ) of Bundle Saved";
    
    }
}
public class MobileChallanNo
{
    public string Msg { get; set; }
    public string ChalanNo { get; set; }
    public string ChallanTrno_I { get; set; }
}