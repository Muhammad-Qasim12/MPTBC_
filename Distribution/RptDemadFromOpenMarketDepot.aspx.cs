using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.IO;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Distrubution_RptDemadFromOpenMarketDepot : System.Web.UI.Page
{
    double LastYearSaleBook = 0, CurntYearOpenBook = 0, OpenTentetiveStock = 0, NetDemand = 0;
    Dis_TentativeDemandHistory objTentativeDemandHistory = null;
    Dis_OpenMarketDemand objOpenMarketDemand = null;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        int CurrentYear = DateTime.Today.Year;
        string PreviousYear = (CurrentYear - 1).ToString();
        string NextYear = (CurrentYear + 1).ToString();
        string finYear = "";
        if (DateTime.Today.Month > 3)
            finYear = CurrentYear.ToString() + "-" + NextYear;
        else
            finYear = PreviousYear + "-" + CurrentYear.ToString();

        if (!IsPostBack)
        {
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.Items.FindByText(obCommonFuction.GetFinYear()).Selected = true;
        }


    }

    protected void ddlMedum_Init(object sender, EventArgs e)
    {
        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlMedum.DataSource = objTentativeDemandHistory.MedumFill();
        ddlMedum.DataValueField = "MediumTrno_I";
        ddlMedum.DataTextField = "MediunNameHindi_V";
        ddlMedum.DataBind();
        ddlMedum.Items.Insert(0, "Select");
    }
    protected void ddlClass_Init(object sender, EventArgs e)
    {

        objTentativeDemandHistory = new Dis_TentativeDemandHistory();
        ddlClass.DataSource = objTentativeDemandHistory.ClassFill();
        ddlClass.DataValueField = "ClassTrno_I";
        ddlClass.DataTextField = "ClassDesc_V";
        ddlClass.DataBind();
        //ddlClass.Items.Insert(0, "Select");
    }

    
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlClass.SelectedItem.Text != "Select" && ddlMedum.SelectedItem.Text != "Select")
            {
                string strclasses = "";
                foreach (ListItem item in ddlClass.Items)
                {
                    if (item.Selected)
                    {
                        strclasses = strclasses + "," + item.Value;
                    }

                }

                DataSet Ds = new DataSet();
                Ds = obCommonFuction.FillDatasetByProc("Call USP_DIS001_OpenDemandDataShowWithCls('" + ddlDepoMaster.SelectedValue.ToString().Replace("All", "0") + "','" + ddlMedum.SelectedItem.Value.ToString().Replace("Select", "0") + "','" + strclasses + "','" + ddlSessionYear.SelectedValue + "',3)"); // objOpenMarketDemand.BooksfillWithClass(strclasses);
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "DataSet1";
                    rds.Value = Ds.Tables[0];
                    string Title = "";
                    Title = " डिपोवार मांग का प्रकार : " + ddlDepoMaster.SelectedItem.Text + ", माध्यम :" + ddlMedum.SelectedItem.Text + ", कक्षा का नाम :" + ddlClass.SelectedItem.Text;

                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/RptDemadFromOpenMarketDepot.rdlc");
                   
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportViewer1.LocalReport.DataSources.Add(rds);

                    ReportParameter[] Param = new ReportParameter[2];
                    Param[0] = new ReportParameter("Year", ddlSessionYear.SelectedItem.Text);
                    Param[1] = new ReportParameter("Title", Title);
                    ReportViewer1.LocalReport.SetParameters(Param);


                    ReportViewer1.LocalReport.EnableExternalImages = true;
                    ReportViewer1.ShowPrintButton = true;
                    ReportViewer1.LocalReport.Refresh();
                }
                else
                {
                    

                }


            }
        }
        catch { }
    }

   
}
