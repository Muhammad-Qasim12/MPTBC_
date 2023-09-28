using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Data;
using System.IO;
using Microsoft.Reporting.WebForms;

public partial class Depo_SchemeWiseBookDetail : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
     CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {


            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectDistrict(" + Session["UserID"] + ",0,0)");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");
            

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

         //   LblFyYear.Text = DdlACYear.SelectedItem.Text;


        }
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        DdlBlock.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_GEN_GetBlockByDistrict("+DdlDistrict.SelectedValue+")");
        DdlBlock.DataValueField = "BlockTrno_I";
        DdlBlock.DataTextField = "Blockname_v";
        DdlBlock.DataBind();
        DdlBlock.Items.Insert(0, "--Select--");
    }
    protected void BtnViewAll_Click(object sender, EventArgs e)
    {
        string Classes = "";
        if (ddlCls.SelectedValue == "1-8")
         {
           Classes = "1,2,3,4,5,6,7,8";
        }
       else  
        {
            Classes = "9,10,11,12";
       }
        DataSet dt = obCommonFuction.FillDatasetByProc(@"SELECT SUM(`NoOfBooks`)NoOfBooks, `SchemeName_Hindi`,`TitleHindi_V` FROM `dis_textbookdemand_t`
INNER JOIN `adm_schememaster` ON `adm_schememaster`.`SchemeId`=dis_textbookdemand_t.`SchemeID`
INNER JOIN `acd_titledetail` ON acd_titledetail.`TitleID_I`=`TitleId`
 WHERE `AcYearId`='" + DdlACYear.SelectedValue + "' AND `DemandTypeId`=4 AND `blockId`=" + DdlBlock.SelectedValue + " and find_in_set(ClassTrno_I,'" + Classes + "')  GROUP BY  `SchemeName_Hindi`,`TitleHindi_V` ORDER BY  ClassTrno_I,`RateListSNo_I`");

        ReportDataSource rds = new ReportDataSource();
        rds.Name = "DataSet1";
        rds.Value = dt.Tables[0];
        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Depo/RptSchemWise.rdlc");
        ReportViewer1.LocalReport.DataSources.Clear();
        ReportViewer1.LocalReport.DataSources.Add(rds);        
        ReportViewer1.LocalReport.EnableExternalImages = true;
        ReportViewer1.ShowPrintButton = true;
        ReportViewer1.LocalReport.Refresh();
//        SELECT `NoOfBooks`, `SchemeName_Hindi`,`TitleHindi_V` FROM `dis_textbookdemand_t`
//INNER JOIN `adm_schememaster` ON `adm_schememaster`.`SchemeId`=dis_textbookdemand_t.`SchemeID`
//INNER JOIN `acd_titledetail` ON acd_titledetail.`TitleID_I`=`TitleId`
// WHERE `AcYearId`='2019-2020' AND `DemandTypeId`=1
// AND `blockId`
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {
       // USP_DD_SelectDistrict
     
    }
}