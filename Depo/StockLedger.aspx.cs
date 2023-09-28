using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using MPTBCBussinessLayer;
using Microsoft.Reporting.WebForms;

public partial class Depo_StockLedger : System.Web.UI.Page
{ public  CommonFuction obCommonFuction = new CommonFuction();
  public DataSet ds1;
  public DataTable myDT;
  public int j;

  CultureInfo cult = new CultureInfo("gu-IN", true);
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
        ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
        TextBox1.Text = "01-11-2017";
        TextBox2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        Label lblfyYaer = new Label();
        Label lblAddress = new Label();
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();

        CommonFuction comm = new CommonFuction();
        comm.FillDatasetByProc("truncate table tmpTransdate");
        lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        string Title = "दिनांक : " + TextBox1.Text + " से दिनांक : " + TextBox2.Text + " तक";
        DataSet ds = new DataSet();
        //ds = obCommonFuction.FillDatasetByProc("call USP_MPTBC_GET_STOCK_POSITION(" + Session["UserID"] + ")");
        LoadReport();
        ds.Dispose();
    }
    public void LoadReport()
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        if (RadioButtonList1.SelectedValue == "1")
        { 
        obCommonFuction.FillDatasetByProc(@"CALL DPTStockLegerNewmsapp(" + ddlTital.SelectedValue + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "'," + Session["UserID"] + ")");
        DS = obCommonFuction.FillDatasetByProc(@"CALL DPTStockLegerNewms(" + ddlTital.SelectedValue + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "'," + Session["UserID"] + ")");
        }
        else {
            DS = obCommonFuction.FillDatasetByProc(@"CALL USP_acbLegerMaster(" + ddlTital.SelectedValue + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "'," + Session["UserID"] + ")");
   
        }
        rds.Value = DS.Tables[0];
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Stockledger.rdlc");
        //string Title = "";
        //Title = "डिपो : " + Session["UserName"] + ", " + " जिला : " + DdlDistrict.SelectedItem.Text + ", " + " कक्षा : " + DDLClass.SelectedItem.Text + ", " + " योजना : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "सभी");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        string Title = ""+  ddlTital.SelectedItem.Text+" ,दिनांक : " + TextBox1.Text + " से दिनांक : " + TextBox2.Text + " तक";
        ReportParameter[] Param = new ReportParameter[4];
        Param[0] = new ReportParameter("fyyear",  obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString());
        Param[1] = new ReportParameter("BookName", Title);
        Param[2] = new ReportParameter("DateA", System.DateTime.Now.ToString ("dd/MM/yyyy"));
        Param[3] = new ReportParameter("DepoName", DepoName);
        //DepoName
        ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "")
        {
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
        }
        else
        {
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call USP_ACBTitleDetails()");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("Select..", "0"));
        }
       

    }
}