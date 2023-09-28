using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System.Globalization;
public partial class Depo_BeemaKiReportD : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlmonth.DataSource = obCommonFuction.FillDatasetByProc(@"SELECT MonthId, MonthFullName FROM  `hr_monthmaster`
");
            ddlmonth.DataTextField = "MonthFullName";
            ddlmonth.DataValueField = "MonthId";
            ddlmonth.DataBind();
            ddlmonth.Items.Insert(0, "Select");
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.Items.Insert(0, "Select");
            //ddlSessionYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }

  
    protected void Button1_Click(object sender, EventArgs e)
    {
        ReportDataSource rds = new ReportDataSource();

        rds.Name = "DataSet1";

        //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
        DataSet dd = obCommonFuction.FillDatasetByProc(@"SELECT adm_depomaster_m.`DepoName_V`,`DepoAddress_V`,WareHouseName_V,
WareHouseAddress_V,IFNULL(TotalBook,0)TotalBook,IFNULL(TotalAmount,0)TotalAmount,
DATE_FORMAT(`DateD`,'%d/%m/%Y')DateD
 FROM  `dpt_warehouuse_m`
INNER  JOIN DPT_BeemaKiJankari ON DPT_BeemaKiJankari.WareHouseID=dpt_warehouuse_m.`WareHouseID_I`
 INNER JOIN `adm_depomaster_m` ON  adm_depomaster_m.`DepoTrno_I`=DepoID
 WHERE `Month`="+ddlmonth.SelectedValue+" AND `Year`='"+ddlSessionYear.SelectedValue+"'  ");
        Dt = dd.Tables[0];
        rds.Value = Dt;
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("BeemaRpt.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportParameterCollection Param = new ReportParameterCollection();
        Param.Add(new ReportParameter("Month",ddlmonth.SelectedValue));
        Param.Add(new ReportParameter("Year", ddlSessionYear.SelectedValue));
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;

        ReportViewer1.LocalReport.Refresh();
    }
}