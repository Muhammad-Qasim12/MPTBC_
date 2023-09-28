using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Depo_StockReport : System.Web.UI.Page
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
            ddlSessionYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string Classes = "";
            if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
            else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
            a.Visible = true;
            //obDPT_DepotMaster = new DPT_DepotMaster();
            //obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            //DataSet obDataSet = obDPT_DepotMaster.Select();
            //lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();

            //lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            //Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CommonFuction obCommon = new CommonFuction();
            DataTable dt = new DataTable();
            dt = obCommon.FillDatasetByProc(@"call dptStockDetailsReport(" + Session["USerID"] + "," + ddlTital.SelectedValue + "," + ddlMedium.SelectedValue + ",'" + Classes + "','" + ddlSessionYear.SelectedValue + "')").Tables[0];

            DataView obvdatview = dt.DefaultView;
           // obvdatview.RowFilter = "cnt1>0 or cnt2>0";
            GridView1.DataSource = obvdatview;
            GridView1.DataBind();
        }
        catch { }
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
}