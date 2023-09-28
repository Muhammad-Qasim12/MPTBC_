using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Depo_AwantanPradya : System.Web.UI.Page
{
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserName"]).ToUpper() == "DPI" || Convert.ToString(Session["UserName"]).ToUpper() == "RSK")
        {
            LblClass.Visible = DDLClass.Visible = false;
        }

        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            //CommonFuction obCommonFuction = new CommonFuction();

            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();

            //DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            //DDlDepot.DataValueField = "DepoTrno_I";
            //DDlDepot.DataTextField = "DepoName_V";
            //DDlDepot.DataBind();
            //DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));

            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataValueField = "SchemeID";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));

            DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));
            if (Convert.ToString((Request.QueryString["Type"])) == "A")
            {
                a.Visible = true;
                a1.Visible = false;
            }
            else
            {
                a.Visible = false;
                a1.Visible = true;
            }

        }
    }
    public void LoadReport()
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();
        
        string DepoName = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString().Trim().Length == 0 ? "" : obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
        //lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        string Classes = "";

        if (DDLClass.SelectedValue.ToString() == "1-8")
        {
            Classes = "1,2,3,4,5,6,7,8";
        }
        else if (DDLClass.SelectedValue.ToString() == "9-12")
        {
            Classes = "9,10,11,12";
        }


        DS = obCommonFuction.FillDatasetByProc(@"CALL DepoDISGetVitranNirdesStatusDepo(" + Convert.ToInt32(DdlDistrict.SelectedValue)
                                                                             + "," + Convert.ToInt32(Session["UserID"])
                                                                             + ",'" + Classes + "'"
                                                                             + "," + Convert.ToInt32(DdlScheme.SelectedValue)
                                                                             + ",'" + Convert.ToString(DdlACYear.SelectedValue)
                                                                             + "')");

        rds.Value = DS.Tables[0];

        if (Convert.ToString((Request.QueryString["Type"])) == "A")
        {

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/Report.rdlc");
        }

        else
        {

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/ReportAllotment.rdlc");
        }
        string Title = "";
        Title = "डिपो : " + DepoName.ToString () + ", " + " जिला : " + DdlDistrict.SelectedItem.Text + ", " + " कक्षा : " + DDLClass.SelectedItem.Text + ", " + " योजना : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "सभी");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);

        ReportParameter[] Param = new ReportParameter[3];
        Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        Param[1] = new ReportParameter("Title", Title);
        Param[2] = new ReportParameter("DepoName", DepoName.ToString());

        ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void DDlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DdlDistrict.Enabled = true;

        }
        catch { }
    }
    protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + DDLClass.SelectedValue.ToString() + "')");
        DdlScheme.DataTextField = "SchemeName_Hindi";
        DdlScheme.DataBind();

        DdlScheme.Items.Insert(0, new ListItem("-All-", "0"));
    }
}