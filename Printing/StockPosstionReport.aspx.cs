using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Printing_StockPosstionReport : System.Web.UI.Page
{
    public CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds1;
    public DataTable myDT;
    public int j;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = "01/04/2015";
            TextBox2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
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
            ddlDepo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataBind();
            ddlDepo.Items.Insert(0, "Select");
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(TextBox2.Text, cult) < DateTime.Parse(TextBox1.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('दिनांक तक  दिनांक से से बड़ी चुने  .');</script>");
        }
        else
        {
            //Panel1.Visible = true;
            //btnExport.Visible = true;
            //btnExportPDF.Visible = true;
            DPT_DepotMaster obDPT_DepotMaster = null;
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(ddlDepo.SelectedValue);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            Label lblfyYaer = new Label();
            Label lblAddress = new Label();
            string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();

            CommonFuction comm = new CommonFuction();
            lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            string Title = "दिनांक : " + TextBox1.Text + " से दिनांक : " + TextBox2.Text + " तक";
            DataSet ds = new DataSet();
            ds = obCommonFuction.FillDatasetByProc("call USP_MPTBC_GET_STOCK_POSITION(" + ddlDepo.SelectedValue + "," + ddlTital.SelectedValue + "," + ddlMedium.SelectedValue + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "')");
            LoadReport(ds, DepoName, Title, lblfyYaer.Text);
            ds.Dispose();

        }

    }
    public void LoadReport(DataSet dsGSR, string DepoName, string Title, string FinancialYear)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "dsStockPosition";
        rds.Value = dsGSR.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/StockPosition.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("p_DepoName", DepoName));
        Param.Add(new ReportParameter("p_Title", Title));
        Param.Add(new ReportParameter("p_FYear", FinancialYear));

        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }

}