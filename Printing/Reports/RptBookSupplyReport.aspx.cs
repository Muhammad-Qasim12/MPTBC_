using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Printing_RptBookSupplyReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction comm = new CommonFuction();
    int Yojan = 0;
    int Samany = 0; DataTable Dt;
    int Total = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            TextBox2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text ="आज दिनांक "+TextBox1.Text +" को मुद्रकों से डिपो में प्राप्त पुस्तको की जानकारी का पत्रक ";
      // DataSet ds= comm.FillDatasetByProc("call Pri_GetBookSupplyDetailsbyDate('"+Convert.ToDateTime(TextBox1.Text,cult).ToString ("yyyy-MM-dd")+"')");

        //GetPrinterChallanDetailsOtherthantextbook
        DataSet ds = new DataSet();
        if (RadioButtonList2.SelectedValue == "1")
        {
            ds = comm.FillDatasetByProc("call GetPrinterChallanDetails ('" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedValue + "')");
        }
        else
        {

            ds = comm.FillDatasetByProc("call GetPrinterChallanDetailsOtherthantextbook ('" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedValue + "')");
 
        }
            if (RadioButtonList1.SelectedValue == "1")
        {
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";

            //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
           // DataSet dd = obCommonFuction.FillDatasetByProc("call DPTGetDaybookData (" + Convert.ToString(Session["UserID"]) + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "' ,'" + Classes + "'," + ddlMedium.SelectedValue + ") ");
            Dt = ds.Tables[1];
            rds.Value = Dt;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("PrinterSupplyDateWise.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            //GridView2.DataSource = ds.Tables[1];
            //GridView2.DataBind();
        }
        else if (RadioButtonList1.SelectedValue == "3")
        {
            ReportDataSource rds = new ReportDataSource();

            rds.Name = "DataSet1";

            //Dt = md.DayBook(Convert.ToDateTime(TextBox1.Text,cult).ToString("yyyy-mm-dd"), Convert.ToString(Session["UserID"]));
            // DataSet dd = obCommonFuction.FillDatasetByProc("call DPTGetDaybookData (" + Convert.ToString(Session["UserID"]) + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "' ,'" + Classes + "'," + ddlMedium.SelectedValue + ") ");
            Dt = ds.Tables[1];
            rds.Value = Dt;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("PrinterSupplyDateWise_new.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.LocalReport.EnableExternalImages = true;
            ReportViewer1.ShowPrintButton = true;
            ReportViewer1.LocalReport.Refresh();
            //GridView2.DataSource = ds.Tables[1];
            //GridView2.DataBind();
        }

       btnExportPDF.Visible = true;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try {
            Label lblYojna = (Label)e.Row.Cells[3].FindControl("lblYojna");
            Yojan += lblYojna.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblYojna.Text);
            }
            catch { }
            try { 
            Label lblSamay = (Label)e.Row.Cells[3].FindControl("lblSamay");
            Samany += lblSamay.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblSamay.Text);
            }
            catch { }
            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[1].Text = "Total";
            e.Row.Cells[5].Text = Yojan.ToString();
            e.Row.Cells[6].Text = Samany.ToString();
            e.Row.Cells[7].Text =Convert.ToString (Yojan+ Samany);
        }
    }
    //protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //Yojan = 0; Samany = 0;
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        try
    //        {
    //            Label lblYojna = (Label)e.Row.FindControl("lblYojna0");
    //            Yojan += lblYojna.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblYojna.Text);
    //        }
    //        catch { }
    //        try
    //        {
    //            Label lblSamay = (Label)e.Row.FindControl("lblSamay0");
    //            Samany += lblSamay.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblSamay.Text);
    //        }
    //        catch { }

    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        e.Row.Style.Add("background", "#f1f1f1");
    //        e.Row.Cells[1].Text = "Total";
    //        e.Row.Cells[3].Text = Yojan.ToString();
    //        e.Row.Cells[4].Text = Samany.ToString();
    //        e.Row.Cells[5].Text = Convert.ToString(Yojan + Samany);
    //    }
    //}
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        GridView1.DataSource = null;
        GridView1.DataBind();
      
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}