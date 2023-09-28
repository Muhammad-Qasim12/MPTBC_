using System;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.IO;
using System.Web.UI;


public partial class Distribution_DemandReportNew : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();

    CommonFuction objExec = new CommonFuction();
    int Total1, Total2, Total3, Total4, Total5, Total6, Total7, Total8, Total9, Total10, Total11;
    int Total123, Total124;
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();
        if (!IsPostBack)
        {
            lblYear.Text = Request.QueryString["Year"];
            lblClass.Text = Request.QueryString["Class"];
            lblDemand.Text = Request.QueryString["DemandName"];
            lblDepoName.Text = Request.QueryString["DepoName"];
            lblMideum.Text = Request.QueryString["MeidumName"];
            Label2.Text = Request.QueryString["PerCentage"];
            //;MeidumName
            DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_DIS_DemandEstimation_BycheckBox(" + Convert.ToInt32(Request.QueryString["depoID"]) + "," + Request.QueryString["meidumID"] + ",'" + Request.QueryString["Class"] + "','" + Request.QueryString["Year"] + "'," + Convert.ToInt16(Request.QueryString["DemandType"]) + ",'" + Request.QueryString["Bookstatus"] + "'," + Request.QueryString["PerCentage"] + "," + Request.QueryString["WithStock"] + "," + Request.QueryString["Samayan"] + ")");
            GridView1.DataSource = obDataset.Tables[0];
            GridView1.DataBind();
       //    Response.Redirect("DemandReportNew.aspx?DemandType=" + DDlDemandType.SelectedValue + "&Year=" + DdlACYear.SelectedValue + "&Class=" + strclasses + "&DepoName=" + DdlDepot.SelectedItem.Text + "&depoID=" + DdlDepot.SelectedValue + " ");


        }

    }
    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_DataBound(object sender, EventArgs e)
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
                    Label lbl11 = (Label)e.Row.FindControl("txt001");
                    Total123 += lbl11.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl11.Text);
                }
                catch { }
                try
                {
                    Label lbl22 = (Label)e.Row.FindControl("lbl22");
                    Total124 += lbl22.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl22.Text);
                }

                catch { }
                try
                {
                    Label lblFromNo_I = (Label)e.Row.FindControl("lbl1");
                    Total1 += lblFromNo_I.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblFromNo_I.Text);
                }
                catch { }
                try
                {
                    Label lbl2 = (Label)e.Row.FindControl("lbl2");
                    Total2 += lbl2.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl2.Text);
                }
                catch { }
                try
                {
                    Label lbl3 = (Label)e.Row.FindControl("lbl3");
                    Total3 += lbl3.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl3.Text);
                }
                catch { }
                try
                {
                    Label lbl4 = (Label)e.Row.FindControl("lbl4");
                    Total4 += lbl4.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl4.Text);
                }
                catch { }
                try
                {
                    Label lbl5 = (Label)e.Row.FindControl("lbl5");
                    Total5 += lbl5.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl5.Text);
                }
                catch { }
                try
                {
                    Label lbl6 = (Label)e.Row.FindControl("lbl6");
                    Total6 += lbl6.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl6.Text);
                }
                catch { }
                try
                {
                    Label lbl7 = (Label)e.Row.FindControl("lbl7");
                    Total7 += lbl7.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl7.Text);
                }
                catch { }
                try
                {
                    Label lbl8 = (Label)e.Row.FindControl("lbl8");
                    Total8 += lbl8.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl8.Text);
                }
                catch { }
                try
                {
                    Label lbl9 = (Label)e.Row.FindControl("lbl9");
                    Total9 += lbl9.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl9.Text);
                }
                catch { }
                try
                {
                    Label lbl10 = (Label)e.Row.FindControl("lbl10");
                    Total10 += lbl10.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl10.Text);
                }
                catch { }
                try
                {
                    Label lbl11 = (Label)e.Row.FindControl("lbl11");
                    Total11 += lbl11.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lbl11.Text);
                }
                catch { }
               // lbl2
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = Total123.ToString();
            e.Row.Cells[3].Text = Total124.ToString();

            e.Row.Cells[4].Text = Total1.ToString();
            e.Row.Cells[5].Text = Total2.ToString();
            e.Row.Cells[6].Text = Total3.ToString();
            e.Row.Cells[7].Text = Total4.ToString();
            e.Row.Cells[8].Text = Total5.ToString();
            e.Row.Cells[9].Text = Total6.ToString();
            e.Row.Cells[10].Text = Total7.ToString();
            e.Row.Cells[11].Text = Total8.ToString();
            e.Row.Cells[12].Text = Total9.ToString();
            e.Row.Cells[13].Text = Total10.ToString();
            e.Row.Cells[14].Text = Total11.ToString();
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
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