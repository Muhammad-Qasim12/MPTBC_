using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Distribution_DisOpeningStockReport : System.Web.UI.Page
{
    decimal total_PerBundle = 0;
    decimal total_kulbook = 0;
    decimal total_Total = 0;
    decimal total_TotalBookpaik = 0;
    decimal total_BundleNo_IMin = 0;
    decimal total_BundleNo_Imax = 0;
    decimal total_FromNo_I = 0;
    decimal total_ToNo_I = 0;
    decimal total_LoojBook = 0;
    int TotalSamany, TotalScheme; string Classes;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();
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

            DdlDepot.DataSource = comm.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, new ListItem("Select", "0"));
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();


        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        string Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
        lblDepoName.Text = " डिपो का नाम : " + DdlDepot.SelectedItem.Text + ", " + "माध्यम : " + ddlMedium.SelectedItem.Text.Replace("All", "सभी") + " ," + " पुस्तक का प्रकार : " + ddlTital0.SelectedItem.Text.Replace("All", "सभी") + ", पुस्तक का नाम : " + ddlTital.SelectedItem.Text.Replace("All", "सभी") + " कक्षा :" + Classes;
        lblAcYearRpt.Text = comm.GetFinYear();
        lblDate.Text = System.DateTime.Now.ToString("d MMM yyyy");
        GridView1.DataSource = comm.FillDatasetByProc("call USP_DPTSaveOpeningStock(1,'" + DdlACYear.SelectedItem.Text + "',0," + DdlDepot.SelectedValue + ",0,0,'" + Classes + "'," + ddlMedium.SelectedValue + ")");

        GridView1.DataBind();

    }
    protected void ddlTital0_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                    TextBox txtSamany = (TextBox)e.Row.FindControl("txtSamany");
                    TotalSamany += txtSamany.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(txtSamany.Text);
                }
                catch { }
                try
                {
                    TextBox lblPerBundle = (TextBox)e.Row.FindControl("txtYojna");
                    TotalScheme += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblPerBundle.Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = TotalScheme.ToString();
            e.Row.Cells[3].Text = TotalSamany.ToString();

        }
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "OpeningStockReport.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

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


    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
}