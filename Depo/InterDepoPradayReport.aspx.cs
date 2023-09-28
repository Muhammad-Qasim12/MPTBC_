using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer;

public partial class Depo_InterDepoPradayReport : System.Web.UI.Page
{
    MediumMaster obMediumMaster = null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            //DataSet dtmedium = obMediumMaster.Select();
            //ddlMedium.DataTextField = "MediunNameHindi_V";
            //ddlMedium.DataValueField = "MediumTrno_I";
            //ddlMedium.DataSource = dtmedium.Tables[0];
            //ddlMedium.DataBind();
            //ddlMedium.Items.Insert(0, "सलेक्ट करे ..");
            ddlfyyear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlfyyear.DataValueField = "AcYear";
            ddlfyyear.DataTextField = "AcYear";
            ddlfyyear.DataBind();
            ddlfyyear.SelectedValue = comm.GetFinYear();
           DataSet dt=comm.FillDatasetByProc("call USP_InterDepoChallanReport(" + Session["UserID"] + ",0,0,0)");
           ddldepoName.DataSource = dt.Tables[1];
           ddldepoName.DataValueField = "DepoTrno_I";
           ddldepoName.DataTextField = "DepoName_V";
           ddldepoName.DataBind();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string meditumIDa;
        
        btnExportPDF.Visible = true;
        GridView1.DataSource = comm.FillDatasetByProc("call USP_InterDepoPraday(" + Session["UserID"] + "," + ddldepoName.SelectedValue + ",'" + ddlfyyear.SelectedValue + "')");
        GridView1.DataBind();
    }
}