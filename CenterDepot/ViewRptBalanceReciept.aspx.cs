using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;

public partial class ViewRptBalanceReceipt : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails ();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    decimal dcTotReel = 0; decimal dcTotSheet = 0; decimal dcTotBundle = 0;
    string leaderName = string.Empty;
    string ChallanNo = string.Empty;
    string NameofPress_V = string.Empty;
    int ltSno = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            BindPrinterDDL();
            //GridFillLoad();
        }
    }

    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("BalanceRecieptNo").ToString();
        Literal ltrSno = (Literal)lt.FindControl("ltrSNo");
        Literal ltrdt = (Literal)lt.FindControl("ltrBRDate");
        LinkButton lnk = (LinkButton)lt.FindControl("lnk");
        Literal ltrRemark = (Literal)lt.FindControl("ltrRemark");
        Panel pnl = (Panel)lt.FindControl("pnl");
       
        if (!string.Equals(lt.Text, leaderName))
        {
            leaderName = lt.Text;
            ltrSno.Text = ltSno.ToString();
            ltrdt.Text = Eval("BalanceRecieptDate").ToString();
            lnk.Text = "Cancel";
            ltSno++;
            ltrRemark.Text = Eval("Remark").ToString();
        }
        else
        {
            lt.Text = string.Empty;
            ltrdt.Text = "";
            lnk.Text = "";
            ltrRemark.Text = "";
            pnl.Visible = false;
        }
    }
    protected void ltrChallanNo_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("BalanceRecieptDate").ToString();
        LinkButton lnk = (LinkButton)lt.FindControl("lnk");

        if (!string.Equals(lt.Text, ChallanNo))
        {
            ChallanNo = lt.Text;
            lnk.Text = "Cancel";
        }
        else
        {
            lt.Text = string.Empty;
            lnk.Text = "";
        }
    }
   

    protected void btnAddnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("RptBalanceReciept.aspx");
    }

    protected void btnReason_Click(object sender, EventArgs e)
    {

        if (hdnFormId.Value != "")
        {
            if (txtReason.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter reason.');</script>");
            }

            DateTime DteCheck;
            string RptDate = "";
            if (txtDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDate.Text, cult);
                }
                catch { RptDate = "NoDate"; }
            }

            if (RptDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Date.');</script>");
            }

            try
            {
                obCommonFuction.FillTableByProc("call USP_PRI_BalanceParchiStatus('" + hdnFormId.Value + "'," +
                     "'" + txtReason.Text + "'," +
                   "'" + obCommonFuction.dtFormat(txtDate.Text) + "','9')");
                GridFillLoad();
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Status updated successfully.');</script>");
            }
            catch
            {

            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if(hdnFormId.Value != "" )
        {
            if (txtReason.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter reason.');</script>");
            }

            DateTime DteCheck;
            string RptDate = "";
            if (txtDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDate.Text, cult);
                }
                catch { RptDate = "NoDate"; }
            }

            if (RptDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Date.');</script>");
            }

            try{

            }
            catch
            {

            }
        }
    }

    
    public void BindPrinterDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "All");
    }

    public void GridFillLoad()
    {
        try
        {
            int PrinterID = 0;

            if (ddlPrinter.SelectedItem.Text == "All")
            {
                PrinterID = 0;
            }
            else
            {
                PrinterID = Convert.ToInt32(ddlPrinter.SelectedValue);
            }

            string BalanceRcptFromDt = "1900-01-01";
            if (txtFromDt.Text != "")
            {
                BalanceRcptFromDt = FnDtFormat(txtFromDt.Text);
            }
            string BalanceRcptToDt = "9999-01-01";
            if (txtToDt.Text != "")
            {
                BalanceRcptToDt = FnDtFormat(txtToDt.Text);
            }

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();

            dsr = obCommonFuction.FillDatasetByProc("call USP_PRI_LIST_BalanceParchi('" + ddlAcYear.SelectedItem.Text + "'," +
            "'" + PrinterID + "', '" + BalanceRcptFromDt + "','" + BalanceRcptToDt + "','" + txtSearch.Text + "','')");
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();

            if (GrdLOI.Rows.Count > 0)
                btnExport.Visible = true;
            else
                btnExport.Visible = false;
        }
        catch { }
    }

    protected void GrdLOI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
           
        }        
    }

   
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            
        }
        catch { }
    }
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }

    int i = 0;
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView grid = sender as GridView;

        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, -1,
                DataControlRowType.Header, DataControlRowState.Normal);

            for (int Index = 1; Index <= GrdLOI.Columns.Count; Index++)
            {
                TableCell left = new TableHeaderCell();
                
                left.Text = Index.ToString();
                left.BackColor = System.Drawing.Color.Gray;
                left.ForeColor = System.Drawing.Color.White;
                left.HorizontalAlign = HorizontalAlign.Center;
                left.VerticalAlign = VerticalAlign.Middle;
                row.Cells.Add(left);

                Table t = grid.Controls[0] as Table;
                if (t != null)
                {
                    t.Rows.AddAt(1, row);
                }

                if (Index == 10)
                {
                    left.Text = "";
                    
                }
            }
        }

       

    }

    private void fnFormatGrid()
    {
        for (int rowIndex = GrdLOI.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GrdLOI.Rows[rowIndex];
            GridViewRow gvPreviousRow = GrdLOI.Rows[rowIndex + 1];

            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {
                if (cellCount == 0)
                {
                    //  i = i + 1;
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                    {
                        // aj = aj + 1;
                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }


                }
                //else if (cellCount == 2)
                //{
                //    //  i = i + 1;
                //    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text) && (gvRow.Cells[2].Text == gvPreviousRow.Cells[2].Text))
                //    {
                //        // aj = aj + 1;
                //        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                //        {
                //            gvRow.Cells[cellCount].RowSpan = 2;
                //        }
                //        else
                //        {
                //            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                //        }
                //        gvPreviousRow.Cells[cellCount].Visible = false;

                //    }

                //}


                else if (cellCount == 1)
                {
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
                    {

                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }
                }


                else
                {
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text) && (gvRow.Cells[2].Text == gvPreviousRow.Cells[2].Text))
                    {

                        if (gvPreviousRow.Cells[cellCount].RowSpan < 2)
                        {
                            gvRow.Cells[cellCount].RowSpan = 2;
                        }
                        else
                        {
                            gvRow.Cells[cellCount].RowSpan = gvPreviousRow.Cells[cellCount].RowSpan + 1;
                        }
                        gvPreviousRow.Cells[cellCount].Visible = false;

                    }
                }
            }
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        
          int PrinterID = 0;
            if (ddlPrinter.SelectedItem.Text == "All")
            {
                PrinterID = 0;
            }
            else
            {
                PrinterID = Convert.ToInt32(ddlPrinter.SelectedValue);
            }

            string BalanceRcptFromDt = "1900-01-01";
        if (txtFromDt.Text != "")
        {
            BalanceRcptFromDt = FnDtFormat(txtFromDt.Text);
        }
        string BalanceRcptToDt = "9999-01-01";
        if (txtToDt.Text != "")
        {
            BalanceRcptToDt = FnDtFormat(txtToDt.Text);
        }
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();
            dsr = obCommonFuction.FillDatasetByProc("call USP_PRI_LIST_BalanceParchi('" + ddlAcYear.SelectedItem.Text + "',"+
            "'" + PrinterID + "', '" + BalanceRcptFromDt + "','" + BalanceRcptToDt + "','" + txtSearch.Text + "','0')");
        
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();

            if (GrdLOI.Rows.Count > 0)
                btnExport.Visible = true;
            else
                btnExport.Visible = false;
            //fnFormatGrid();
    }

    public string FnDtFormat(string date)
    {
        if (date.Trim().Length > 0)
        {
            if(date.IndexOf('-') > 0)
            {
                date = date.Split('-')[2] + "-" + date.Split('-')[1] + "-" + date.Split('-')[0];
            }
            else
                date = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        }
        return date;
    }

    protected void lnkChangeSts_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
        obCommonFuction.FillDatasetByProc("call Usp_pprLOISearchDetails('" + lblDisTranId.Text + "','',8)");
        GridFillLoad();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }

    public void ExportToExcell()
    {
        GrdLOI.AllowPaging = false;
        GridFillLoad();
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GSRSupplyDetails11.xls"));
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
        
    }
}