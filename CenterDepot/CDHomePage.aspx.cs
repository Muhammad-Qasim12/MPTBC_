using MPTBCBussinessLayer.Paper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CenterDepot_CDHomePage : System.Web.UI.Page
{
    DataSet ds;
    DataTable Dt, dt;
    PPR_RDLCData objReports = new PPR_RDLCData();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadHomePage();
        }

    }
    public void LoadHomePage()
    {
        ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0022_PaperDeshboard('2015-2016',0,8)");
        if (ds.Tables[0].Rows.Count > 0)
        { //STock Details

            lblPaperTotQty.Text = ds.Tables[0].Rows[0]["TotQty"].ToString();
            lblPprTotSupplied.Text = ds.Tables[0].Rows[0]["TotDebitQty"].ToString();
            lblPPRTotRemaining.Text = ds.Tables[0].Rows[0]["RemainingQty"].ToString();
        }
        else
        {
            lblPaperTotQty.Text = "0";
            lblPprTotSupplied.Text = "0";
            lblPPRTotRemaining.Text = "0";
        }
        if (ds.Tables[1].Rows.Count > 0)
        {//Mill details
            lblMillTotAllot.Text = ds.Tables[1].Rows[0]["TotalAllotment"].ToString();
            lblMillTotSupplied.Text = ds.Tables[1].Rows[0]["TotalDispatch"].ToString();
            lblMillTotRemaining.Text = ds.Tables[1].Rows[0]["RemainingQty"].ToString();
        }
        else
        {
            lblMillTotAllot.Text = "0";
            lblMillTotSupplied.Text = "0";
            lblMillTotRemaining.Text = "0";
        }
        if (ds.Tables[2].Rows.Count > 0)
        {//Printer details
            lblPrinterTotAllotted.Text = ds.Tables[2].Rows[0]["TotalAllotment"].ToString();
            lblPrinterTotSupplied.Text = ds.Tables[2].Rows[0]["TotalDispatch"].ToString();
            lblPrinterTotRemaining.Text = ds.Tables[2].Rows[0]["RemainingQty"].ToString();
        }
        else
        {
            lblPrinterTotAllotted.Text = "0";
            lblPrinterTotSupplied.Text = "0";
            lblPrinterTotRemaining.Text = "0";
        }
        //if (ds.Tables[3].Rows.Count > 0)
        //{
        //    //Printer details
        //    lblWorkTotAllot.Text = ds.Tables[3].Rows[0]["TotalAllotMent"].ToString();
        //    lblWorkTotSupplied.Text = ds.Tables[3].Rows[0]["TotSuppied"].ToString();
        //    lblWorkRemain.Text = ds.Tables[3].Rows[0]["RemainingQty"].ToString();
        //}
        //else
        //{
        //    lblWorkTotAllot.Text = "0";
        //    lblWorkTotSupplied.Text = "0";
        //    lblWorkRemain.Text = "0";
        //}
        if (ds.Tables[3].Rows.Count > 0)
        {
            //Graph details
            GVCurrentActivity.DataSource = ds.Tables[3];
            GVCurrentActivity.DataBind();
        }
        else
        {
            GVCurrentActivity.DataSource = null;
            GVCurrentActivity.DataBind();

        }

        try
        {
            DataSet dPpr = obCommonFuction.FillDatasetByProc("call GetPprAndPrinterNotification('')");
            if (dPpr.Tables[0].Rows.Count > 0)
            {
                rpt.DataSource = dPpr.Tables[0];
                rpt.DataBind();
            }
            else
            {
                rpt.DataSource = null;
                rpt.DataBind();
            }

            if (dPpr.Tables[1] != null && dPpr.Tables[1].Rows.Count > 0)
            {
                rptPrinter.DataSource = dPpr.Tables[1];
                rptPrinter.DataBind();
            }
            else
            {
                rptPrinter.DataSource = null;
                rptPrinter.DataBind();
            }

            try
            {
                if (dPpr.Tables[2] != null && dPpr.Tables[2].Rows.Count > 0)
                {
                    rptStock.DataSource = dPpr.Tables[2];
                    rptStock.DataBind();
                }
                else
                {
                    rptStock.DataSource = null;
                    rptStock.DataBind();
                }
            }
            catch { }
        }
        catch { }

    }
    [System.Web.Services.WebMethod]
    public static string PaperStock()
    {
        List<CDStockDtl> list = new List<CDStockDtl>();
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds;
        ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0022_PaperDeshboard('2015-2016',0,7)");
        DataTable dt = ds.Tables[0];
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            CDStockDtl ob = new CDStockDtl();
            ob.country = Convert.ToString(dr["CoverInformation"]);
            try
            {
                ob.visits = decimal.Parse(dr["RemainingQty"].ToString());
            }
            catch { ob.visits = 0; }
            ob.color = Color(i);
            ob.PaperType = Convert.ToString(dr["PaperType"]);
            ob.fullName = Convert.ToString(dr["fullName"]);

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
        else if (i == 13)
        {
            Color = "#DDDDDD";
        }
        else if (i == 14)
        {
            Color = "#999999";
        }
        else if (i == 15)
        {
            Color = "#333333";
        }
        else if (i == 16)
        {
            Color = "#6666ff";
        }
        else if (i == 17)
        {
            Color = "#ff3399";
        }
        else if (i == 18)
        {
            Color = "#99ff33";
        }
        else if (i == 19)
        {
            Color = "#996600";
        }
        else if (i == 20)
        {
            Color = "#336600";
        }
        else
        {
            Color = "#620441";
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