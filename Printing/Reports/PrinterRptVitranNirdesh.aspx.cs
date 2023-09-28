using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;

public partial class Depo_RptVitranNirdesh : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;
    MDDashboard md = new MDDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
            DataSet ds = new DataSet();
            ds = PriReg.GetPrinterDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
            }
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }


    }
    protected void BtnShow_Click(object sender, EventArgs e)
    {
        DPT_DepotMaster obDPT_DepotMaster = null;
        obDPT_DepotMaster = new DPT_DepotMaster();
        obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obDPT_DepotMaster.Select();

        CommonFuction comm = new CommonFuction();

        Dt = VitranNirdesh(DdlACYear.SelectedItem.Text, Convert.ToInt32(Session["PrierID_I"]));// md.VitranNirdesh(Convert.ToString(DdlACYear.SelectedItem.Text), Convert.ToInt32(Session["PrierID_I"]));

        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Printing/Reports/PrinterRptvitrannirdesh.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportParameter[] Param = new ReportParameter[2];
       
        Param[0] = new ReportParameter("AcYear", DdlACYear.SelectedItem.Text);
        Param[1] = new ReportParameter("Date", System.DateTime.Now.ToString("dd/MM/yyyy"));
        ReportViewer1.LocalReport.SetParameters(Param);

        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;
    }
    public System.Data.DataTable VitranNirdesh(string sessionYear, int Printer_RedID_I)
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("ProcPriterVitranNirdesh", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("sessionYear", sessionYear);
        obDBAccess.addParam("mPrinter_RedID_I", Printer_RedID_I);
        return obDBAccess.records1();

    }
}