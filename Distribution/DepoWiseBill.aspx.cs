using System;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Web.UI;


public partial class Depo_DepoWiseBill : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();


            DDlDemandType.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DIS001_DemandTypeMasterLoad(0)");
            DDlDemandType.DataValueField = "DemandTypeId";
            DDlDemandType.DataTextField = "DemandTypeHindi";
            DDlDemandType.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlBillDetails.SelectedItem.Text == "1-8")
        {
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_TotalAvatanPraptiBilln('" + DdlClass.SelectedValue + "','" + DdlACYear.SelectedValue + "','" + DDlDemandType.SelectedValue + "'," + ddlBillDetails.SelectedValue + ")");
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_TotalAvatanPraptiBill('" + DdlClass.SelectedValue + "','" + DdlACYear.SelectedValue + "','" + DDlDemandType.SelectedValue + "'," + ddlBillDetails.SelectedValue + ")");
            GridView1.DataBind();
        }
      
    }
    Double a1, a2, a3, a4, a5, a6;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                    Label txt1 = (Label)e.Row.FindControl("lbl1");
                    a1 +=txt1.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(txt1.Text);
                }
                catch { }
                try
                {
                    Label txt2 = (Label)e.Row.FindControl("lbl2");
                    a2 += txt2.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(txt2.Text); 
                }
                catch { }
                try
                {
                    Label txt3 = (Label)e.Row.FindControl("lbl3");
                    a3 += txt3.Text.Trim().Length == 0 ? 0 : Convert.ToDouble(txt3.Text);
                }
                catch { }
                try
                {
                    Label txt4 = (Label)e.Row.FindControl("lbl4");
                    a4 += txt4.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(txt4.Text);
                }
                catch { }
                try
                {
                    Label txt5 = (Label)e.Row.FindControl("lbl5");
                    a5 += txt5.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(txt5.Text);
                }
                catch { }
                try
                {
                    Label txt6 = (Label)e.Row.FindControl("lbl6");
                    a6 += txt6.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(txt6.Text);
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
            e.Row.Cells[2].Text = a1.ToString();
            e.Row.Cells[3].Text = a2.ToString();
            e.Row.Cells[4].Text = a3.ToString();
            e.Row.Cells[5].Text = a4.ToString();
            e.Row.Cells[6].Text = a5.ToString();
            e.Row.Cells[7].Text = a6.ToString();
           // e.Row.Cells[3].Text = TotalSamany.ToString();

        }
    }
      public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
      protected void btnExport_Click(object sender, EventArgs e)
      {
          ExportToExcell();
      }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "BundelReelDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

}