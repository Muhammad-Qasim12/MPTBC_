using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_DepoStockBarcode : System.Web.UI.Page
{
     CommonFuction comm = new CommonFuction();
     string Classes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));
            ddlSessionYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();

            DdlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        GridView1.DataSource = comm.FillDatasetByProc("call USP_DepoPhysicalBarcodePrint(" + DdlDepot.SelectedValue + ",'" + ddlSessionYear.SelectedItem.Text + "','" + Classes + "',"+ddlMedium.SelectedValue+")");
        GridView1.DataBind();
        //USP_DepoPhysicalBarcodePrint
    }
}