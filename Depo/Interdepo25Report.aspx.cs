using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
using System.IO;

public partial class Depo_Interdepo25Report : System.Web.UI.Page
{
    DepoReport obDepoReport = new DepoReport();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public APIProcedure api = new APIProcedure();
    CommonFuction obCommanFun = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtFromdate.Text = "01/04/2015";
            txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            //DataSet dd = obCommanFun.FillDatasetByProc("call GetPrinterName()");
            //ddlPrinter.DataTextField = "NameofPress_V";
            //ddlPrinter.DataValueField = "Printer_RedID_I";
            //ddlPrinter.DataSource = dd.Tables[0];
            //ddlPrinter.DataBind();
            //ddlPrinter.Items.Insert(0, "All");

            DdlACYear.DataSource = obCommanFun.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommanFun.GetFinYear();

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(txtTodate.Text, cult) < DateTime.Parse(txtFromdate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('दिनांक तक  दिनांक से से बड़ी चुने  .');</script>");
        }
        else
        {
            DPT_DepotMaster obDPT_DepotMaster = null;
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            //lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            //lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            //lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();

            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoName_V"].ToString();
            lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            CommonFuction comm = new CommonFuction();
            lblfyYaer.Text = comm.GetFinYear();
            Label1.Text = txtFromdate.Text;
            Label2.Text = txtTodate.Text;
           // Label3.Text = ddlPrinter.SelectedItem.Text;
            aa.Visible = true;
            obDepoReport.ID = Convert.ToInt32(Session["UserID"]);
            //obDepoReport.fromdate = Convert.ToDateTime(txtFromdate.Text);
            //obDepoReport.Todate = Convert.ToDateTime(txtTodate.Text);
            string PrinID;

            DataSet ds = obCommanFun.FillDatasetByProc("call USP_InterDepo25Report('" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "', '" + Convert.ToInt32(Session["UserID"]) + "',0,'" + DdlACYear.SelectedItem.Text + "')");
            //obDepoReport.GetTwentyFivePer();
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public void ExportToExcell()
    {
        try
        {
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AVASKIJANKARI.xls"));
            Response.Charset = "";
            Response.ContentType = "application / vnd.ms - word";

            StringWriter sw = new StringWriter();
            HtmlTextWriter HW = new HtmlTextWriter(sw);

            ExportDiv.RenderControl(HW);
            Response.Write(sw.ToString());
            Response.End();
            Response.Clear();
        }
        catch { }
    }

    protected void btnExport_Click1(object sender, EventArgs e)
    {
        ExportToExcell();
    }
}