using MPTBCBussinessLayer.DistributionB;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_InterDepotransforOrder : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    RDLC_Data objReports = new RDLC_Data();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlFyYr.DataSource = objReports.FillFyYear().Tables[0];
            ddlFyYr.DataTextField = "AcYear";
            ddlFyYr.DataValueField = "AcYear";
            ddlFyYr.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select", "0"));
            ddlFyYr.DataBind();
            FillLetterNo();
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtOrderNo.Text = randnum.ToString();
            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "Select..");
            DdlDepot0.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot0.DataValueField = "DepoTrno_I";
            DdlDepot0.DataTextField = "DepoName_V";
            DdlDepot0.DataBind();
            DdlDepot0.Items.Insert(0, "Select..");
            fillgrd();
        }
    }
    private void FillLetterNo()
    {
        ddlLetterNo.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(0,-1)");
        ddlLetterNo.DataValueField = "TitleID_I";
        ddlLetterNo.DataTextField = "TitleHindi_V";
        ddlLetterNo.DataBind();
        ddlLetterNo.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("insert into DistB_InterDepoOrder(DepoFrom,DepoTo,OrderNo,OrderDate, SubID,Year,TitleID,TotalNoofBooks)values (" + DdlDepot.SelectedValue + "," + DdlDepot0.SelectedValue + ",'" + txtOrderNo.Text + "','" + Convert.ToDateTime(txtDate.Text, cult).ToString ("yyyy-MM-dd") + "','" + ddlSub.SelectedValue + "','" + ddlFyYr.SelectedValue + "','" + ddlLetterNo.SelectedValue + "','"+txtNoofBook.Text+"') ");

        obCommonFuction.EmptyTextBoxes(this);
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        txtOrderNo.Text = randnum.ToString();
        fillgrd();

    }
    public void fillgrd()
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"  SELECT DistB_InterDepoOrder.`Year`, a.`DepoName_V` a,b.`DepoName_V` b
      ,SubTitleHindi_V,DistB_InterDepoOrder.`OrderNo`,DATE_FORMAT(`OrderDate`,'%d/%m/%y')OrderDate,TotalNoofBooks ,
      `TitleHindi_V`
       FROM DistB_InterDepoOrder
      INNER JOIN `adm_depomaster_m` AS a ON a.`DepoTrno_I`=DistB_InterDepoOrder.`DepoFrom`
      INNER JOIN `adm_depomaster_m` AS b ON b.`DepoTrno_I`=DistB_InterDepoOrder.`DepoTo`
      INNER JOIN `acb_titledetail` ON acb_titledetail.`TitleID_I`=DistB_InterDepoOrder.`TitleID`
      INNER JOIN `acb_subtitle` ON acb_subtitle.`SubTitleID_I`=`SubID`
      
      ");
        GridView1.DataBind();
    
    }
    protected void ddlLetterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSub.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(" + ddlLetterNo.SelectedValue + ",-2)");
        ddlSub.DataValueField = "SubTitleID_I";
        ddlSub.DataTextField = "SubTitleHindi_V";
        ddlSub.DataBind();
        ddlSub.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrd();
    }
}