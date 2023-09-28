using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;
public partial class Distribution_DepoWiseOpenMarketSell : System.Web.UI.Page
{
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));

            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();
            DdlScheme.Items.Insert(0, new ListItem("--Select--", "0"));
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_OpenMarketTitleWiseDemand("+DDlDepot.SelectedValue+","+DdlScheme.SelectedValue+")");
        GridView1.DataBind();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
        }
        catch { }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    public void ExportToExcell()
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
    public decimal value1;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
         if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {

                try
                {
                    value1 += e.Row.Cells[2].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[2].Text);
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
                e.Row.Cells[2].Text = value1.ToString();
               
            }
            
        }
    }
