using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_Rpt_GroupWiseDemandMedium : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    DataTable Dt;
    // RDLCReport objRDLCReport = new RDLCReport();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {


        lblTitleName.Text = "ग्रुप वार मांग की रिपोर्ट / Group Wise Demand Report ";
        Page.Title = lblTitleName.Text;

        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            // DdlScheme.Items.Insert(0, new ListItem("-All-", "0")); 

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();


            ddlGroupName.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookGroupName()");
            ddlGroupName.DataValueField = "GroupId";
            ddlGroupName.DataTextField = "GroupName";
            ddlGroupName.DataBind();
            ddlGroupName.Items.Insert(0, "Select");
            //DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));

            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
        }
    }
    public void LoadReport()
    {
        //ReportDataSource rds = new ReportDataSource();
        //rds.Name = "DataSet1";
        DataSet DS;

        string Bookstatus;
        string strclasses = "";
        if (RadioButtonList2.SelectedValue == "1")
        {
            Bookstatus = "1";
        }
        else if (RadioButtonList2.SelectedValue == "2")
        {
            Bookstatus = "0,2";
        }
        else
        {

            Bookstatus = "0,1,2";
        }

        CommonFuction obCommonFuction = new CommonFuction();
        foreach (ListItem item in DdlClass.Items)
        {
            if (item.Selected)
            {
                strclasses = strclasses + "," + item.Value;
            }

        }
        string Title = "";
        if (RadioButtonList1.SelectedValue == "1")
        {
            Dt = obCommonFuction.FillTableByProc("call USP_GroupWiseVitranNirdeshReport(" + ddlGroupName.SelectedValue + "," + DdlScheme.SelectedItem.Value + ",'" + Convert.ToString(DdlACYear.SelectedValue) + "','" + strclasses + "','" + Bookstatus + "')");
            Title = " शिक्षा सत्र : " + DdlACYear.SelectedItem.Text + " ग्रुप : " + ddlGroupName.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " माध्यम : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "वितरण निर्देश ") ;
        
        }else
        { 
        Dt = obCommonFuction.FillTableByProc(@"CALL USP_DisRpt_GroupWiseDemandMedium(" + ddlGroupName.SelectedItem.Value + "," + DdlScheme.SelectedItem.Value + ",'" + Convert.ToString(DdlACYear.SelectedValue) + "','" + strclasses + "'," + DDlDemandType.SelectedItem.Value + ")");
        Title = " शिक्षा सत्र : " + DdlACYear.SelectedItem.Text + " ग्रुप : " + ddlGroupName.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " माध्यम : " + DdlScheme.SelectedItem.Text.ToString().Replace("-All-", "सभी") + " मांग का प्रकार  :" + DDlDemandType.SelectedItem.Text.ToString().Replace("0", "सभी");
        }
        // rds.Value = DS.Tables[0];
        
       


        ReportDataSource rds = new ReportDataSource("DataSet1", Dt);
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/Report_GroupWiseDmnd.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);
        ReportParameter[] Param = new ReportParameter[2];
        Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
        Param[1] = new ReportParameter("Title", Title);
        ReportViewer1.LocalReport.SetParameters(Param);
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
        ReportViewer1.Visible = true;

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        LoadReport();
    }
    protected void DDlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
        //try
        //{
        //    DdlDistrict.Enabled = true;
        //    CommonFuction obCommonFuction = new CommonFuction();

        //    DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + DDlDepot.SelectedValue + " ,0,0 )");
        //    DdlDistrict.DataValueField = "DistrictTrno_I";
        //    DdlDistrict.DataTextField = "District_Name_Hindi_V";
        //    DdlDistrict.DataBind();
        //    DdlDistrict.Items.Insert(0, new ListItem("-Select-", "0"));
        //}
        //catch { }
    }

}
