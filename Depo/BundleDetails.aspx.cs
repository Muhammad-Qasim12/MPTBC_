using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

using System.Globalization;

using System.IO;
public partial class Depo_BundleDetails : System.Web.UI.Page
{
    public CommonFuction comm = new CommonFuction();
    DPT_DepotMaster obDPT_DepotMaster = null;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();

            lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblfyYaer.Text = comm.GetFinYear();
            Label4.Text = Request.QueryString["ID"];
           // Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            DataSet ds = comm.FillDatasetByProc(@" select case RemaingLoose_V when '' then ifnull(ToNo_I  ,0)-ifnull(FromNo_I ,0)+1 else (length(RemaingLoose_V) - length(Replace (RemaingLoose_V,',',''))) end TotalBook,dpt_stockdetailschild_t.* ,TitleHindi_V , case IsOpenMarket when 2 then 'सामान्य' else 'योज़ना' end as booktype from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I
            inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I
            where dpt_warehouuse_m.UserID_I=" + Session["UserID"] + " and  IsDistribute=3 and  DistributID =(select StockDistributionSEntryID_I from dpt_stockdistributionschemeentry_m where ChallanNo_V=" + Request.QueryString["ID"] + ")");
            grdPrinterBundleDetails.DataSource = ds.Tables[0];
            grdPrinterBundleDetails.DataBind();
           
        }
    }
}