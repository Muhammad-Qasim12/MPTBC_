using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Depo_DepoWiseBookSellingReport : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            txtFromdate.Text = "28-03-2019";
            txtTodate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Label1.Text = "शिक्षा सत्र  " + DdlACYear.SelectedItem.Text + "हेतु खुले बाजार की विक्रय संख्या दिनांक "+txtFromdate.Text+" से "+txtTodate.Text+" तक की जानकारी";
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call GetBooksellerDemandAllDepo('" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy-MM-dd") + "')");
        GridView1.DataBind();
    }
    int TotalBook;
    double bookAmount;
    double bookAmount1;
    double bookAmount2;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                    TotalBook += Convert.ToInt32( e.Row.Cells[2].Text);
                }
                catch { }
                try
                {
                    bookAmount += Convert.ToDouble(e.Row.Cells[3].Text);
                }
                catch { }
                try
                {
                    bookAmount1 += Convert.ToDouble(e.Row.Cells[4].Text);
                }
                catch { }
                

            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
           
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[1].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = TotalBook.ToString();
            e.Row.Cells[3].Text = bookAmount.ToString();
            e.Row.Cells[4].Text = bookAmount1.ToString();
         //   e.Row.Cells[5].Text = bookAmount2.ToString();

        }
    }
}