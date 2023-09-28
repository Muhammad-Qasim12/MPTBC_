using System;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Distrubution_Dis_BillEstimation : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
           string Class = Convert.ToString(DdlClass.SelectedItem.Text);
           if (Class != "9-12")
           {
               Class = "1-8";
           }
           if (Class == "9-12")
           {
               DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
               DdlScheme.DataValueField = "MediumTrno_I";
               DdlScheme.DataTextField = "MediunNameHindi_V";
               DdlScheme.DataBind();
               DdlScheme.Items.Insert(0, new ListItem("All", "0"));
           }
           else
           {

               DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + Class + "')");
               DdlScheme.DataValueField = "SchemeId";
               DdlScheme.DataTextField = "SchemeName_Hindi";
               DdlScheme.DataBind();
               DdlScheme.Items.Insert(0, new ListItem("-Select-", "0"));
           }
        }


    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Class = Convert.ToString(DdlClass.SelectedItem.Text);
        if (Class != "9-12")
        {
            Class = "1-8";
        }
        if (Class == "9-12")
        {
            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("All", "0"));
        }
        else
        {

            DdlScheme.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_SchemeLoadClassWise('" + Class + "')");
            DdlScheme.DataValueField = "SchemeId";
            DdlScheme.DataTextField = "SchemeName_Hindi";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("-Select-", "0"));
        }
    }

    //protected void FillGrid() {

    //    DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_BillEstimation(" + Convert.ToInt32(DdlScheme.SelectedValue) + ",'" + Convert.ToString(DdlClass.SelectedValue) + "')");
    //    GrdBillEstimation.DataSource = obDataset;
    //    GrdBillEstimation.DataBind();
    //}

    protected void BtnShow_Click(object sender, EventArgs e)
    {

        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";
        DataSet DS;
        DS = obCommonFuction.FillDatasetByProc(@"Call USP_DIS_BillEstimationNew(" + Convert.ToInt32(DdlScheme.SelectedValue)
                                                                                + ",'" + Convert.ToString(DdlClass.SelectedValue)
                                                                                + "','" + Convert.ToString(DdlACYear.SelectedValue)
                                                                                + "','" + Convert.ToString(DDlDemandType.SelectedValue)
                                                                                + "',"+TextBox1.Text +")");

        rds.Value = DS.Tables[0];

        string Amount="0";


        Button btn = (Button)sender;
        if (ddlBillDetails.SelectedItem.Value == "100")
        {
            if (DdlClass.SelectedItem.Text == "6-8" || DdlClass.SelectedItem.Text == "9-12")
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/8515BillDetails.rdlc");
                Amount = "";
            }
            else
            {
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/BillDetails.rdlc");
               Amount = "";
            }
        }
           
        else if (ddlBillDetails.SelectedItem.Value == "80")
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/80PercentBill.rdlc");
            Amount = DS.Tables[0].Rows[0]["eighty"].ToString();
        }
        else if (ddlBillDetails.SelectedItem.Value == "20")
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/20PercentBill.rdlc");
            Amount = DS.Tables[0].Rows[0]["twenty"].ToString();
        }
        else if (ddlBillDetails.SelectedItem.Value == "15")
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/15PercentBill.rdlc");
            Amount = DS.Tables[0].Rows[0]["fifteen"].ToString();
        }
        else if (ddlBillDetails.SelectedItem.Value == "85")
        {
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/85PercentBill.rdlc");
            Amount = DS.Tables[0].Rows[0]["eightfive"].ToString();
        }
        string Title = "";
        Title = " कक्षा : " + DdlClass.SelectedItem.Text + ", " + " माध्यम : " + DdlScheme.SelectedItem.Text.ToString().Replace("-Select-", "सभी") + ", " + " डिमांड टाइप  : " + DDlDemandType.SelectedItem.Text.ToString().Replace("-All-", "सभी");



        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;

        ReportParameter[] Param = new ReportParameter[4];

        Param[0] = new ReportParameter("Classes", Convert.ToString(DdlClass.SelectedItem.Text.Replace("-", " से ")));
        Param[1] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        Param[2] = new ReportParameter("Title", Title);
        Param[3] = new ReportParameter("Amount", Amount);
        ReportViewer1.LocalReport.SetParameters(Param);


        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
    public void LoadReport(string ReportName)
    {
        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        DataSet DS;
        DS = obCommonFuction.FillDatasetByProc("Call USP_DIS_BillEstimation(" + Convert.ToInt32(DdlScheme.SelectedValue) + ",'" + Convert.ToString(DdlClass.SelectedValue) + "')");

        rds.Value = DS.Tables[0];

        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/BillDetails.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();

    }
}