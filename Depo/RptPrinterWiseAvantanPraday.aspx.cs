using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Depo_RptPrinterWiseAvantanPraday : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            }
            catch { }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        ExportDiv.Visible = true;
        DataSet aa = obCommonFuction.FillDatasetByProc("CALL USP_DPTAvantanPradya('" + Convert.ToDateTime(txtFromdate.Text, cult).ToString("yyyy/MM/dd") + "','" + Convert.ToDateTime(txtTodate.Text, cult).ToString("yyyy/MM/dd") + "'," + Session["UserID"] + ",'" + DdlACYear.SelectedItem.Text + "')");
        GridView1.DataSource = aa;
        GridView1.DataBind();

    }
}