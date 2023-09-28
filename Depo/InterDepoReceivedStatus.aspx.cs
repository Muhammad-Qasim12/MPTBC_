using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Store;
using System.Data;
using System.Globalization;
using System.IO;
using MPTBCBussinessLayer;

public partial class Depo_InterDepoReceivedStatus : System.Web.UI.Page
{
    MediumMaster obMediumMaster = null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "सलेक्ट करे ..");
            ddlfyyear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlfyyear.DataValueField = "AcYear";
            ddlfyyear.DataTextField = "AcYear";
            ddlfyyear.DataBind();
            ddlfyyear.SelectedValue = comm.GetFinYear();
            DataSet dt = comm.FillDatasetByProc("call USP_InterDepoChallanReport(" + Session["UserID"] + ",0,0,0)");
            ddldepoName.DataSource = dt.Tables[1];
            ddldepoName.DataValueField = "DepoTrno_I";
            ddldepoName.DataTextField = "DepoName_V";
            ddldepoName.DataBind();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string meditumIDa;
        if (ddlMedium.SelectedIndex == 0)
        {
            meditumIDa = "0";
        }
        else
        {
            meditumIDa = ddlMedium.SelectedValue;
        }
        btnExportPDF.Visible = true;
        btnExportPDF0.Visible = true;
        GridView1.DataSource = comm.FillDatasetByProc("call USP_InterDepoChallanReportNew(" + Session["UserID"] + "," + ddldepoName.SelectedValue + "," + meditumIDa + ",'" + ddlfyyear.SelectedValue + "')");
        GridView1.DataBind();
    }
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "interDepo.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}