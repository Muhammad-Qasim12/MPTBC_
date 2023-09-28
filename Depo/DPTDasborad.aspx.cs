using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_DPTDasborad : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    public DataSet ddd;
    public DataSet ddd1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          

        }

    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
          try { 
          DataSet dd=  comm.FillDatasetByProc("call GetDepoDashboard(" + Session["UserID"] + ",'"+comm.GetFinYear ()+"')");
          lblTotalBook.Text = Convert.ToString(Convert.ToInt32(dd.Tables[0].Rows[0]["Samany"]) + Convert.ToInt32(dd.Tables[0].Rows[0]["Yojna"]));
          lblSamany.Text = dd.Tables[0].Rows[0]["Samany"].ToString();
          lblYojnaBook.Text = dd.Tables[0].Rows[0]["Yojna"].ToString();

          

          if (dd.Tables[2].Rows.Count != 0)
          {
              
              lblotalBooSupP.Text = Convert.ToString(Convert.ToInt32(dd.Tables[2].Rows[0]["Samany"]) + Convert.ToInt32(dd.Tables[2].Rows[0]["Yojna"]));
              lblTotaSup.Text = dd.Tables[1].Rows[0]["Supbook"].ToString();
              lblRemain.Text = Convert.ToString(Convert.ToInt32(lblTotaSup.Text) - Convert.ToInt32(lblotalBooSupP.Text));
          }
          
         
         
            }
            catch { }
             try { 
            ddd = comm.FillDatasetByProc("call GetDepoNotification(" + Session["UserID"] + ")");

            DataSet dt = comm.FillDatasetByProc("call USP_BookAllotment('" + comm.GetFinYear() + "'," + Session["UserID"] + ")");
            lblTotalAllotmentbook.Text = Convert.ToString(dt.Tables[0].Rows[0]["NoOfBooks"]);
            lblSupplied.Text = Convert.ToString(dt.Tables[1].Rows[0]["PradayBook"]);
            lblRemaining.Text = Convert.ToString(Convert.ToDouble(lblTotalAllotmentbook.Text) - Convert.ToDouble(lblSupplied.Text));
            //lblBooksellerDemand.Text = Convert.ToString(dt.Tables[0].Rows[0]["TotalDemand"]);
             }
             catch { }
             ddd1 = comm.FillDatasetByProc("call USP_GetvitranNirdesh('" + comm.GetFinYear1() + "'," + Session["UserID"] + ")");
    }
    [System.Web.Services.WebMethod]

    public static string DepoStock(string ID)
    {
       
        List<CDStockDtl> list = new List<CDStockDtl>();
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds;
        ds = obCommonFuction.FillDatasetByProc("CALL DepoDashboardClasswiseStock (" + ID + ")");
        DataTable dt = ds.Tables[0];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            CDStockDtl ob = new CDStockDtl();
            ob.country = Convert.ToString(dr["Classdet_V"]);
            try
            {
                ob.visits =Convert.ToDecimal( dr["TotalBook"]);
            }
            catch { ob.visits = 0; }
            ob.color = Color(i);
            ob.PaperType = Convert.ToString("");
            ob.fullName = Convert.ToString(dr["TotalBook"]);

            // ob.TotQty = Convert.ToString(dr["TotQty"]);
            // ob.TotDispatch = Convert.ToString(dr["TotDispatch"]);
            list.Add(ob);
            i++;
        }
        JsonHelper.JsonSerializer<IList<CDStockDtl>>(list);
        return JsonHelper.JsonSerializer<IList<CDStockDtl>>(list);
    }

    public static string Color(int i)
    {
        string Color = "";
        if (i == 0)
        {
            Color = "#0D52D1";
        }
        else if (i == 1)
        {
            Color = "#FF6600";
        }
        else if (i == 2)
        {
            Color = "#754DEB";
        }
        else if (i == 3)
        {
            Color = "#FCD202";
        }
        else if (i == 4)
        {
            Color = "#F8FF01";
        }
        else if (i == 5)
        {
            Color = "#B0DE09";
        }
        else if (i == 6)
        {
            Color = "#04D215";
        }
        else if (i == 7)
        {
            Color = "#0D8ECF";
        }
        else if (i == 8)
        {
            Color = "#FF0F00";
        }
        else if (i == 9)
        {
            Color = "#2A0CD0";
        }
        else if (i == 10)
        {
            Color = "#8A0CCF";
        }
        else if (i == 11)
        {
            Color = "#CD0D74";
        }
        else if (i == 12)
        {
            Color = "#FF9E01";
        }
       
        return Color;
    }
}

public class CDStockDtl
{
    public string country { get; set; }
    public decimal visits { get; set; }
    public string color { get; set; }
    public string PaperType { get; set; }
    public string fullName { get; set; }
    // public string TotQty { get; set; }
    //    public string TotDispatch { get; set; }

}
