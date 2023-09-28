using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.IO;
using MPTBCBussinessLayer.Paper;

public partial class Dashboard : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objChallanSummary = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            objChallanSummary = new PPR_PaperDispatchDetails();
            string acyear = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblYr.Text = acyear.ToString()+ "Status As on " +  System.DateTime.Now.Date.ToString("dd/MM/yyyy");
            ds = objChallanSummary.DASHBOARD_SUMMARY(acyear, System.DateTime.Now.Date, 0);
            txtFromDate.Text = System.DateTime.Now.Date.ToString("dd/MM/yyyy");
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    lblTotalPrinter.Text = ds.Tables[0].Rows[0][0].ToString();
                    lblGenerated.Text = ds.Tables[1].Rows[0][0].ToString();
                    lblNotGenerated.Text = ds.Tables[2].Rows[0][0].ToString();
                    lblFilled.Text = ds.Tables[3].Rows[0][0].ToString();
                    lblNotFilled.Text = ds.Tables[4].Rows[0][0].ToString();
               
                    FillPaperVendor();
                  
                }
            }
            DataSet dsBookRcvd = new DataSet();
            dsBookRcvd = this.BookReceivedPrinter();
            if (dsBookRcvd!=null)
            {
                if (dsBookRcvd.Tables.Count>0)
                {
                    if (dsBookRcvd.Tables[0].Rows.Count>0)
                    {   
                        lblNoDepotReceivedPrinter.Text=dsBookRcvd.Tables[0].Rows[0][0].ToString();
                        lblNoOfBookReceivedPrinter.Text = dsBookRcvd.Tables[0].Rows[0][1].ToString();                     
                    }
                        if (dsBookRcvd.Tables[1].Rows.Count>0)
                        {
                            lblNoDepotDispatchPrinter.Text = dsBookRcvd.Tables[1].Rows[0][0].ToString();
                            lblNoOfBookDispatchPrinter.Text = dsBookRcvd.Tables[1].Rows[0][1].ToString();
                        }
                }
            }

            //SummaryOfBookReceivedPrinter
            FillBookDistributionDepotwise();
        }
    }
    //private void bindChallanSummary()
    //{
    //    //
    //    objChallanSummary=new PPR_PaperDispatchDetails();

    //    DataSet ChartData = new DataSet();
    //    ChartData = objChallanSummary.ChallanSummary();
    //    string[] XPointMember = new string[ChartData.Tables[0].Rows.Count];
    //    int[] YPointMember = new int[ChartData.Tables[0].Rows.Count];

    //    for (int count = 0; count < ChartData.Tables[0].Rows.Count; count++)
    //    {
    //        //Sorting Values for x-axis.
    //        XPointMember[count] = ChartData.Tables[0].Rows[count][""].ToString();

    //        //Sorting Values for y-axis.
    //        YPointMember[count] = Convert.ToInt32(ChartData.Tables[0].Rows[count][""].ToString());

    //        ChartChallanSummary.Series[0].BorderWidth = 10;
    //        ChartChallanSummary.Series[0].ChartType = SeriesChartType.Pie;

    //        foreach (Series charts in ChartChallanSummary.Series)
    //        {
    //            foreach (DataPoint point in charts.Points)
    //            {
    //                switch (point.AxisLabel)
    //                {
    //                    case "Generated": point.Color = Color.Red; break;
    //                    case "NotGenerated": point.Color = Color.Yellow; break;

    //                }
    //                point.Label = string.Format("{0:0}-{1}", point.YValues[0], point.AxisLabel);

    //            }
    //        }
    //        ChartChallanSummary.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
    //    }
    //}
    protected void GridPaperVendor_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridPaperVendor.PageIndex = e.NewPageIndex;
        FillPaperVendor();
    }
    public void FillPaperVendor()
    {
        objChallanSummary = new PPR_PaperDispatchDetails();
        string acyear = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();

        ds = objChallanSummary.DASHBOARD_SUMMARY(acyear, Convert.ToDateTime(txtFromDate.Text), 1);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[5].Rows.Count > 0)
                {
                    GridPaperVendor.DataSource = ds.Tables[5];
                    GridPaperVendor.DataBind();
                    lblTotalRcvdQty.Text = ds.Tables[6].Rows[0]["ttlReceivedQty"].ToString();
                }

            }
        }
    }
    public void FillBookDistributionDepotwise()
    {
        string acyear = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
        objChallanSummary = new PPR_PaperDispatchDetails();

        ds = objChallanSummary.DASHBOARD_SUMMARY1(acyear);
        if (ds != null)
        {
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridBookDistributionDepotwise.DataSource = ds.Tables[0];
                    GridBookDistributionDepotwise.DataBind();

                }
                else
                {
                    lblMsg1.Text = "No Data Available";
                }

            }
        }
    }

    protected void GridBookDistributionDepotwise_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridBookDistributionDepotwise.PageIndex = e.NewPageIndex;
        FillBookDistributionDepotwise();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "Dashboard.xls"));
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

    public System.Data.DataSet BookReceivedPrinter()
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("SummaryOfBookReceivedPrinter", DBAccess.SQLType.IS_PROC);
        return obDBAccess.records();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (txtFromDate.Text!="" )
        {
           objChallanSummary = new PPR_PaperDispatchDetails();
            string acyear = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            lblYr.Text = acyear.ToString()+ "Status As on " +  Convert.ToDateTime ( txtFromDate.Text);
            ds = objChallanSummary.DASHBOARD_SUMMARY(acyear,Convert.ToDateTime (txtFromDate.Text),1);

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    lblTotalPrinter.Text = ds.Tables[0].Rows[0][0].ToString();
                    lblGenerated.Text = ds.Tables[1].Rows[0][0].ToString();
                    lblNotGenerated.Text = ds.Tables[2].Rows[0][0].ToString();
                    lblFilled.Text = ds.Tables[3].Rows[0][0].ToString();
                    lblNotFilled.Text = ds.Tables[4].Rows[0][0].ToString();
               
                    FillPaperVendor();
                  
                }
            }
            DataSet dsBookRcvd = new DataSet();
            dsBookRcvd = this.BookReceivedPrinter();
            if (dsBookRcvd!=null)
            {
                if (dsBookRcvd.Tables.Count>0)
                {
                    if (dsBookRcvd.Tables[0].Rows.Count>0)
                    {   
                        lblNoDepotReceivedPrinter.Text=dsBookRcvd.Tables[0].Rows[0][0].ToString();
                        lblNoOfBookReceivedPrinter.Text = dsBookRcvd.Tables[0].Rows[0][1].ToString();                     
                    }
                        if (dsBookRcvd.Tables[1].Rows.Count>0)
                        {
                            lblNoDepotDispatchPrinter.Text = dsBookRcvd.Tables[1].Rows[0][0].ToString();
                            lblNoOfBookDispatchPrinter.Text = dsBookRcvd.Tables[1].Rows[0][1].ToString();
                        }
                }
            }

            //SummaryOfBookReceivedPrinter
            FillBookDistributionDepotwise();
        } 
        }
    protected void LnkBtnGenerated_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            FillData(0);
             
        }
        catch
        {
        }
        finally
        {
            objChallanSummary = null;
        }
    }

    protected void LnkBtnNotGenerated_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");

        try
        {
            FillData(1);
             
        }
        catch
        {
        }
        finally
        {
            objChallanSummary = null;
        }
    }
    
    public void FillData(int ty)
    {
        try
        {
            objChallanSummary = new PPR_PaperDispatchDetails();

            objChallanSummary.mtype = ty;//Convert.ToInt32(Session["UserID"]);
            objChallanSummary.mdate = Convert.ToDateTime( txtFromDate.Text  );
            GrdChallanDetail.DataSource = objChallanSummary.GetChallanDetailFromDepo();
            GrdChallanDetail.DataBind();

            Session["ty1"] = ty;
        }
        catch { }
    }
    protected void GridBookDistributionDepotwise_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void GrdChallanDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdChallanDetail.PageIndex = e.NewPageIndex;
        FillData(Convert.ToInt32 (  Session["ty1"]));
    }

    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        MessagesGroup.Style.Add("display", "none");
         
        fadeDiv.Style.Add("display", "none");
         
    }
}
 