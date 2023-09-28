using System;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;
using System.Web.UI;
using Microsoft.Reporting.WebForms;

public partial class Distrubution_RptEstimatedDemandDepot : System.Web.UI.Page
{
   
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        if (!IsPostBack)
        {
           
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


            //DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            //DdlDepot.DataValueField = "DepoTrno_I";
            //DdlDepot.DataTextField = "DepoName_V";
            //DdlDepot.DataBind();
            //DdlDepot.Items.Insert(0, "Select");

            DdlClass.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            DdlClass.DataValueField = "ClassTrno_I";
            DdlClass.DataTextField = "Classdet_V";
            DdlClass.DataBind();
            //DdlClass.Items.Insert(0, new ListItem("-Select-", "-1"));
            //DdlClass.Items.Insert(1, new ListItem("-All-", "0"));

            DdlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)");
            DdlMedium.DataValueField = "MediumTrno_I";
            DdlMedium.DataTextField = "MediunNameHindi_V";
            DdlMedium.DataBind();
            DdlMedium.Items.Insert(0, "Select");


        }
    }
     
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            string strclasses = "";

            CommonFuction obCommonFuction = new CommonFuction();
            foreach (ListItem item in DdlClass.Items)
            {
                if (item.Selected)
                {
                    strclasses = strclasses + "," + item.Value;
                }

            }
            DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_DemandEstimation_BycheckBoxRpt('" + DdlACYear.SelectedValue.ToString() + "'," + Convert.ToInt32(DdlDepot.SelectedValue) + "," + Convert.ToInt32(DdlMedium.SelectedValue) + ",'" + strclasses + "')");
            if (obDataset.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = obDataset.Tables[0];
                string Title = "";
                Title = " डिपोवार मांग का प्रकार : " + DdlDepot.SelectedItem.Text + ", माध्यम :" + DdlMedium.SelectedItem.Text + ", कक्षा का नाम :" + strclasses;

                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Distribution/RptEstimatedDemandDepot.rdlc");

                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(rds);

                ReportParameter[] Param = new ReportParameter[2];
                Param[0] = new ReportParameter("Year", DdlACYear.SelectedItem.Text);
                Param[1] = new ReportParameter("Title", Title);
                ReportViewer1.LocalReport.SetParameters(Param);  
                ReportViewer1.LocalReport.EnableExternalImages = true;
                ReportViewer1.ShowPrintButton = true;
                ReportViewer1.LocalReport.Refresh();
            }
            

        }
        catch { }
    }
    protected void DdlClasses_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

  
}