using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;
public partial class Depo_GSRReport : System.Web.UI.Page
{
   public  CommonFuction obCommanFun = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public DataSet ds = new DataSet();
    public int j;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromdate.Text = "01/11/2018";
            txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
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
            //DropDownList1.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand('42,43','-2')");
            DropDownList1.DataSource = comm.FillDatasetByProc("call USP_DIB_Rpt001_DepowiseDemand('47','-2')");
            DropDownList1.DataTextField = "TitleHindi_V";
            DropDownList1.DataValueField = "TitleID_I";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            //ddlPrinter.DataTextField = "NameofPress_V";
            //ddlPrinter.DataValueField = "Printer_RedID_I";
            //ddlPrinter.DataSource = dd.Tables[0];
            //ddlPrinter.DataBind();
            //ddlPrinter.Items.Insert(0, "सेलेक्ट..");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try { 
        ExportDiv.Visible = true;
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
        lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
        lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
        lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
        CommonFuction comm = new CommonFuction();

        lblfyYaer.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        Label1.Text = txtFromdate.Text;
        Label2.Text = txtTodate.Text;

        //GridView1.DataSource = obCommanFun.FillDatasetByProc("call USP_DPTGetGSRRegister(" + Convert.ToInt32(Session["UserID"]) + ",'" + txtFromdate.Text + "','" + txtTodate.Text + "')");
        //GridView1.DataBind();
        string Title = "";
        DataSet ds = new DataSet();
        if (RadioButtonList1.SelectedValue == "1")
        {
            Title = "दिनांक : " + txtFromdate.Text + " से दिनांक : " + txtTodate.Text + " तक , माध्यम -" + ddlMedium.SelectedItem.Text + ", पुस्तक का नाम -" + ddlTital.SelectedItem.Text + "";

            //string fromDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
            //string toDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
            ds = obCommanFun.FillDatasetByProc("call USP_DPTGetGSRRegister(" + Convert.ToInt32(Session["UserID"]) + ",'" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlMedium.SelectedValue + "," + ddlTital.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "')");
        }
        else {
            Title = "दिनांक : " + txtFromdate.Text + " से दिनांक : " + txtTodate.Text + " तक ";
            int TitleA=0,subTitleID=0;
            if (DropDownList1.SelectedIndex==0)
            {
            TitleA=0;
            }
            else 
            { TitleA=Convert.ToInt32 ( DropDownList1.SelectedValue) ;}
            if (DropDownList2.SelectedIndex == 0)
            {
                subTitleID = 0;
            }
            else
            { subTitleID = Convert.ToInt32(DropDownList2.SelectedValue); }
            //string fromDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
            //string toDate = (txtFromdate.Text.Split('/')[1] + "/" + txtFromdate.Text.Split('/')[0] + txtFromdate.Text.Split('/')[2]).ToString();
            ds = obCommanFun.FillDatasetByProc("call USP_GSROtherThanTextbook(" + Convert.ToInt32(Session["UserID"]) + ",'" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "'," + TitleA + ","+subTitleID+")");
    
        
        }
             LoadReport(ds, DepoName, Title, lblfyYaer.Text);
        ds.Dispose();
        }
        catch { }
    }

    public void LoadReport(DataSet dsGSR, string DepoName, string Title, string FinancialYear)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = dsGSR.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/GSR001.rdlc");
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
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf1 = comm.FillDatasetByProc("call GetMediumbyTitile("+ddlMedium.SelectedValue+",0)");
        ddlTital.DataSource = asdf1.Tables[1];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            a1a.Visible = true;
            othea.Visible = false;
        }
        else
        {
            a1a.Visible = false;
            othea.Visible = true;

        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf1 = comm.FillDatasetByProc("SELECT SubTitleID_I,SubTitleHindi_V FROM `acb_subtitle` WHERE TitleID_I="+DropDownList1.SelectedValue+"");
        DropDownList2.DataSource = asdf1.Tables[0];
        DropDownList2.DataTextField = "SubTitleHindi_V";
        DropDownList2.DataValueField = "SubTitleID_I";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, new ListItem("All", "0"));
        //SELECT SubTitleID_I,SubTitleHindi_V FROM `acb_subtitle` WHERE `TitleID_I`
    }
}