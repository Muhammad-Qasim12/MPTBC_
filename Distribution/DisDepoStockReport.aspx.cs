using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

using System.IO;
public partial class Depo_DepoStockReport : System.Web.UI.Page
{
    public CommonFuction comm = new CommonFuction();
    DPT_DepotMaster obDPT_DepotMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));

            DdlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "Select");
        }
    }
    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {

        //if (ddltype.SelectedValue == "Warehouse Wise")
        //{
        //    CommonFuction obCommon = new CommonFuction();
        //    grdstockreport.DataSource = obCommon.FillDatasetByProc(@"select dpt_warehouuse_m.WareHouseName_V as 'WareHouse Name', TitleHindi_V as Title,sum(case RemaingLoose_V when '' then ifnull(ToNo_I  ,0)-ifnull(FromNo_I ,0)+1 else (length(RemaingLoose_V) - length(Replace (RemaingLoose_V,',','')))+1 end)  as  'NO Of Books' from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and IsDistribute=0 group by WareHouseName_V, TitleHindi_V");
        //    grdstockreport.DataBind();
        
        //}
        //if (ddltype.SelectedValue == "All")
        //{
        //    CommonFuction obCommon = new CommonFuction();
        //    grdstockreport.DataSource = obCommon.FillDatasetByProc(@"select TitleHindi_V as Title,sum(case RemaingLoose_V when '' then ifnull(ToNo_I  ,0)-ifnull(FromNo_I ,0) +1 else (length(RemaingLoose_V) - length(Replace (RemaingLoose_V,',','')))+1 end) as  'NO Of Books' from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and IsDistribute=0 group by TitleHindi_V");
        //    grdstockreport.DataBind();

        //}
        //if (ddltype.SelectedValue.ToString().ToUpper() == "book type Wise".ToUpper())
        //{
        //    CommonFuction obCommon = new CommonFuction();
        //    grdstockreport.DataSource = obCommon.FillDatasetByProc(@"select case IsOpenMarket when 2 then 'सामान्य' else 'योज़ना' end as booktype , TitleHindi_V as Title,sum(case RemaingLoose_V when '' then ifnull(ToNo_I  ,0)-ifnull(FromNo_I ,0)+1  else (length(RemaingLoose_V) - length(Replace (RemaingLoose_V,',','')))+1 end) as  'NO Of Books' from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and IsDistribute=0 group by IsOpenMarket, TitleHindi_V ");
        //    grdstockreport.DataBind();

        //}

    }
    protected void grdstockreport_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try {
            string Classes = "";
            if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
            else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        a.Visible = true;
    //    obDPT_DepotMaster = new DPT_DepotMaster();
       // obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
      //  DataSet obDataSet = obDPT_DepotMaster.Select();
        //lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        lblDipo.Text = DdlDepot.SelectedItem.Text;
        lblClass.Text = DDLClass.SelectedItem.Text.ToString().Replace("All","सभी");
        lblBookName.Text = ddlTital.SelectedItem.Text.ToString().Replace("All", "सभी");
        lblMedium.Text = ddlMedium.SelectedItem.Text.ToString().Replace("All", "सभी");
        lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        CommonFuction obCommon = new CommonFuction();
        DataTable dt = new DataTable();
        dt = obCommon.FillDatasetByProc(@"call dptStockDetailsReport(" + DdlDepot.SelectedValue + "," + ddlTital.SelectedValue + "," + ddlMedium.SelectedValue + ",'" + Classes + "')").Tables[0];

        DataView obvdatview = dt.DefaultView;
        obvdatview.RowFilter = "cnt1>0 or cnt2>0";
        grdstockreport.DataSource = obvdatview;
        grdstockreport.DataBind();
        }
        catch { }
    }
    
}