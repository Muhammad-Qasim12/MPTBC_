using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DistributionB_PerBundalNo : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    MPTBCBussinessLayer.DistributionB.ProcessBill obProcessBill = new MPTBCBussinessLayer.DistributionB.ProcessBill();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();


            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();

            obProcessBill.TransID = -3;
            ddlTitle.DataSource = obProcessBill.Select();
            ddlTitle.DataTextField = "TitleHindi_V";
            ddlTitle.DataValueField = "TitleID_I";
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, new ListItem("Select", "0"));    
            FillSubTitle();
           

        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CommonFuction obj = new CommonFuction();
        obj.FillDatasetByProc("delete from tbl_bookperbundle_acb where TitleID="+ddlSubTitle.SelectedValue+"");
        obj.FillDatasetByProc("insert into tbl_bookperbundle_acb(`TitleID`,`BookNumber`,`Acyear`)values ('"+ddlSubTitle.SelectedValue +"','"+TextBox1.Text+"','"+DdlACYear.SelectedValue+"')");

        fillgrd(ddlSubTitle.SelectedValue);
    }
    public void fillgrd(string Tital)
    { 
    CommonFuction obj = new CommonFuction();

    GridView1.DataSource = obj.FillDatasetByProc(@"SELECT acb_subtitle.`SubTitleHindi_V`,acb_titledetail.`TitleHindi_V`,`BookNumber`,tbl_bookperbundle_acb.`Acyear` FROM tbl_bookperbundle_acb 
INNER JOIN `acb_subtitle` ON acb_subtitle.`SubTitleID_I`=tbl_bookperbundle_acb.`TitleID`
INNER JOIN `acb_titledetail` ON acb_titledetail.`TitleID_I`=acb_subtitle.`TitleID_I`where acb_subtitle.`SubTitleID_I`=" + ddlSubTitle.SelectedValue + "");
    GridView1.DataBind();
    
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillSubTitle();
    }
    private void FillSubTitle()
    {
        obProcessBill.TransID = -5;
        obProcessBill.QueryParameterValue = int.Parse(ddlTitle.SelectedValue);
        DataSet dsTitle = obProcessBill.Select();
        ddlSubTitle.DataSource = dsTitle.Tables[0];
        ddlSubTitle.DataTextField = "SubTitleHindi_V";
        ddlSubTitle.DataValueField = "SubTitleID_I";
        ddlSubTitle.DataBind();
        ddlSubTitle.Items.Insert(0, new ListItem("Select", "0"));    


    }
    protected void ddlSubTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrd(ddlSubTitle.SelectedValue);
    }
}