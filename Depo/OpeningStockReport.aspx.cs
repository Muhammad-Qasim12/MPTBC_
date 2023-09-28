
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class OpeningStockReport : System.Web.UI.Page
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
    decimal total_PerBundleas = 0;
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
            ddlTital.Items.Insert(0, new ListItem("Select..", "0"));

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select..", "0"));
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear();
            if (Request.QueryString["BookTitle"] !=null)
            {
                DataSet books = comm.FillDatasetByProc("call USP_DPTOPeningStock(" + Request.QueryString["BookTitle"] + ",-1," + Session["userID"].ToString() + "," + Request.QueryString["BookTitle"] + "," + Request.QueryString["Medium"] + "," + Request.QueryString["ClassTrno"] + ")");
                grdPrinterBundleDetails0.DataSource = books.Tables[0];
                grdPrinterBundleDetails0.DataBind();
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";

        CommonFuction comm = new CommonFuction();
        //USP_DPTOPeningStockOLD
        DataSet books = new DataSet();
        if (DdlACYear.SelectedItem.Text == "2017-2018")
        {
            books = comm.FillDatasetByProc("call USP_DPTOPeningStock(" + ddlTital.SelectedValue + ",-1," + Session["userID"].ToString() + "," + ddlTital0.SelectedValue + "," + ddlMedium.SelectedValue + ",'" + Classes + "')");
            try
            {
                grdPrinterBundleDetails0.DataSource = books.Tables[0];
                grdPrinterBundleDetails0.DataBind();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            catch { }
        }
        else if (DdlACYear.SelectedItem.Text == "2016-2017")
        {
            books = comm.FillDatasetByProc("call USP_DPTOPeningStockOLD(" + ddlTital.SelectedValue + ",-1," + Session["userID"].ToString() + "," + ddlTital0.SelectedValue + "," + ddlMedium.SelectedValue + ",'" + Classes + "')");
            try
            {
                grdPrinterBundleDetails0.DataSource = books.Tables[0];
                grdPrinterBundleDetails0.DataBind();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            catch { }
        }
        else if (DdlACYear.SelectedItem.Text == "2019-2020")
        {
            GridView1.DataSource = comm.FillDatasetByProc("call USP_DPTSaveOpeningStock(5,'" + DdlACYear.SelectedValue + "',0," + Session["UserID"] + ",0,0,'" + Classes + "'," + ddlMedium.SelectedValue + ")");
            GridView1.DataBind();
            grdPrinterBundleDetails0.DataSource = null;
            grdPrinterBundleDetails0.DataBind();
        }
        else
        {

            GridView1.DataSource = comm.FillDatasetByProc("call USP_DPTSaveOpeningStock(4,'" + DdlACYear.SelectedValue + "',0," + Session["UserID"] + ",0,0,'" + Classes + "'," + ddlMedium.SelectedValue + ")");
            GridView1.DataBind();
            grdPrinterBundleDetails0.DataSource = null ;
            grdPrinterBundleDetails0.DataBind();
        }
       // (IDa INT, fyYeara VARCHAR(20), TitleIDa INT, DepoIDa INT, YojanaBooka INT, samanyBooka INT, statusa VARCHAR(100),MediumIDa INT )
        
       
        //CommonFuction comm = new CommonFuction();
        //DataSet books = comm.FillDatasetByProc("call USP_DPTOPeningStock("+ddlTital.SelectedValue+",0,"+Session["userID"].ToString ()+")");
        //grdPrinterBundleDetails.DataSource = books.Tables[0];
        //grdPrinterBundleDetails.DataBind();

        //decimal total_PerBundle = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("PerBundle"));
        //decimal total_kulbook = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("kulbook"));
        //decimal total_Total = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("Total"));
        //decimal total_TotalBookpaik = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("TotalBookpaik"));
        //decimal total_BundleNo_IMin = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("BundleNo_IMin"));
        //decimal total_BundleNo_Imax = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("BundleNo_Imax"));
        //decimal total_FromNo_I = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("FromNo_I"));
        //decimal total_ToNo_I = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("ToNo_I"));
        //decimal total_LoojBook = books.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("LoojBook"));

        //grdPrinterBundleDetails0.FooterRow.Cells[1].Text = "Total";
        //grdPrinterBundleDetails0.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Right;
        //grdPrinterBundleDetails0.FooterRow.Cells[3].Text = total_PerBundle.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[4].Text = total_kulbook.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[5].Text = total_Total.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[6].Text = total_TotalBookpaik.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[7].Text = total_BundleNo_IMin.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[8].Text = total_BundleNo_Imax.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[9].Text = total_FromNo_I.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[10].Text = total_ToNo_I.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[11].Text = total_LoojBook.ToString("N2");
        //grdPrinterBundleDetails0.FooterRow.Cells[12].Text = total_LoojBook.ToString("N2");
    }
    protected void ddlTital0_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void grdPrinterBundleDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    Label lblPerBundle = (Label)e.Row.Cells[3].FindControl("lblPerBundle");
                    total_PerBundle += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblPerBundle.Text);
                }
                catch { }
                try
                {
                    Label lblkulbook = (Label)e.Row.Cells[4].FindControl("lblkulbook");
                    total_kulbook += lblkulbook.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblkulbook.Text);
                }
                catch { }
                try
                {
                    Label lblTotal = (Label)e.Row.Cells[5].FindControl("lblTotal");
                    total_Total += lblTotal.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblTotal.Text);
                }
                catch { }
                try
                {
                    Label lblTotalBookpaik = (Label)e.Row.Cells[6].FindControl("lblTotalBookpaik");
                    total_TotalBookpaik += lblTotalBookpaik.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblTotalBookpaik.Text);
                }
                catch { }
                try
                {
                    total_BundleNo_IMin += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text);
                }
                catch { }
                try
                {
                    total_BundleNo_Imax += e.Row.Cells[8].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[8].Text.Replace("&nbsp;", "0").Trim());
                }
                catch { }
                try
                {
                    Label lblFromNo_I = (Label)e.Row.Cells[9].FindControl("lblFromNo_I");
                    total_FromNo_I += lblFromNo_I.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblFromNo_I.Text);
                }
                catch { }
                try
                {
                    Label lblToNo_I = (Label)e.Row.Cells[10].FindControl("lblToNo_I");
                    total_ToNo_I += lblToNo_I.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblToNo_I.Text);
                }
                catch { }
                Label lblLoojBook = (Label)e.Row.FindControl("lblLoojBook");
                try
                {
                    total_LoojBook = total_LoojBook + Convert.ToDecimal(lblLoojBook.Text);
                }
                catch { }


                //ToNo_I0
                Label ToNo_I0 = (Label)e.Row.FindControl("ToNo_I0");
                try
                {
                    string ToNoVal = (ToNo_I0.Text);
                    total_PerBundleas = total_PerBundleas + Convert.ToDecimal(ToNoVal);
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
            e.Row.Cells[4].Text = total_kulbook.ToString();
            e.Row.Cells[5].Text = total_Total.ToString();
            e.Row.Cells[6].Text = total_TotalBookpaik.ToString();
            //e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            //e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            //e.Row.Cells[9].Text = total_FromNo_I.ToString();
            //e.Row.Cells[10].Text = total_ToNo_I.ToString();
            lblFLoojBook.Text = total_LoojBook.ToString();
            FToNo_I0.Text = total_PerBundleas.ToString();
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    int TotalYojna, samay, Total;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            TotalYojna += e.Row.Cells[2].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[2].Text);
            samay += e.Row.Cells[3].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[3].Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = TotalYojna.ToString();
            e.Row.Cells[3].Text = samay.ToString();
            e.Row.Cells[4].Text =Convert.ToString( Convert.ToInt32(samay) + Convert.ToInt32(TotalYojna));
        }

    }
    protected void btnExport_Click1(object sender, EventArgs e)
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
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
}