using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_ExtraDemand : System.Web.UI.Page
{
  //  CommonFuction obCommonFuction = new CommonFuction();
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlSessionYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select", "0"));
            DDlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            TextBox2.Text = randnum.ToString();
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf1 = comm.FillDatasetByProc("call GetMediumbyTitile(" + ddlMedium.SelectedValue + ",0)");
        ddlTital.DataSource = asdf1.Tables[1];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
       // `USP_SaveExtraDemand`(MIDa INT, TitID INT , DepoIDa INT, YearM VARCHAR(50),Schedemand VARCHAR(50),SamanDemand VARCHAR(50),OrdeNoa VARCHAR(50))

        comm.FillDatasetByProc("call USP_SaveExtraDemand(" + ddlMedium.SelectedValue + ","+ddlTital.SelectedValue+","+DDlDepot.SelectedValue+",'"+ddlSessionYear.SelectedItem.Text+"','"+txt01.Text+"','"+txt02.Text+"','"+TextBox2.Text+"')");
        comm.EmptyTextBoxes(this);
        mainDiv.Style.Add("display", "block");
        mainDiv.CssClass = "response-msg error ui-corner-all";
        lblmsg.Style.Add("display", "block");
        lblmsg.Text = "Data Saved";
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        TextBox2.Text = randnum.ToString();
    
    }
}