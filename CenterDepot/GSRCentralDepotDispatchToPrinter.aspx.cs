using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class GSRCentralDepotDispatchToPrinter : System.Web.UI.Page
{
    int i=1;
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
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
       

        }
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
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet dsr = new DataSet();
        if (txtFromDate.Text == "")
        {
            dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchToPrinterCDSearchNewGSR('" + txtSearch.Text + "'," + PrinterID + ",'" + ddlAcYear.SelectedItem.Text + "','')");
        }
        else
        {
            dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchToPrinterCDSearchNewGSR('" + txtSearch.Text + "'," + PrinterID + ",'" + ddlAcYear.SelectedItem.Text + "','" + Convert.ToDateTime(txtFromDate.Text, cult).ToString("yyyy-MM-dd") + "')");
        }
        GrdLOI.DataSource = dsr;
        GrdLOI.DataBind();
        // MergeCells();
        //if (e.Rows.Count > 0)
        //    btnExport.Visible = true;
        //else
        //    btnExport.Visible = false;
        ////USP_PPR0014_PaperDispatchToPrinterCDSearchNew
        }
        catch { }

    }
    public void BindPrinterDDL()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        ////////
        // objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "All");
    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView grid = sender as GridView;
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow row = new GridViewRow(0, -1,
                DataControlRowType.Header, DataControlRowState.Normal);

            for (int Index = 1; Index <= 13; Index++)
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
                    t.Rows.AddAt(2, row);
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Label ChallanNo = (Label)e.Row.FindControl("ChallanNo");
            Label ChallanDate = (Label)e.Row.FindControl("lblChallanDate");
            Label lblPaperQty = (Label)e.Row.FindControl("lblPaperQty");
            Label lblPrinter_RedID_I = (Label)e.Row.FindControl("lblPrinter_RedID_I");
            Label lblPaperCategory = (Label)e.Row.FindControl("lblPaperCategory");
            Label lblSendQty = (Label)e.Row.FindControl("lblSendQty");
            Label lblNoOfReels = (Label)e.Row.FindControl("lblNoOfReels");
            Label lblBalance = (Label)e.Row.FindControl("lblBalance");
            Label lblSheet = (Label)e.Row.FindControl("lblSheet");
            Label lblReel = (Label)e.Row.FindControl("lblReel");
            Label lblBandal = (Label)e.Row.FindControl("lblBandal");
            
            if (lblSendQty.Text != "" && lblPaperQty.Text != "")
            {
               
                if (lblPaperCategory.Text == "Sheet")
                {
                    //lblBalance.Text = (Convert.ToDouble(lblPaperQty.Text) - Convert.ToDouble(lblNoOfReels.Text)).ToString();
                    //lblSheet.Text = lblPaperQty.Text + ' ' + lblPaperCategory.Text;
                    lblSheet.Text = lblNoOfReels.Text + ' ' + lblPaperCategory.Text;
                    lblReel.Text = "--";
                    //lblBandal.Text = Convert.ToString(Convert.ToInt32(lblPaperQty.Text) / 576);
                    DataRowView drv = e.Row.DataItem as DataRowView;
                    lblBandal.Text = drv.Row["BundleNo"].ToString();
                }
                else
                {
                    lblSheet.Text = "--";
                    //lblReel.Text = lblPaperQty.Text + ' ' + lblPaperCategory.Text;
                    lblReel.Text = lblNoOfReels.Text + ' ' + lblPaperCategory.Text;
                    lblBandal.Text = "--";
                    // lblBalance.Text = (Convert.ToDouble(lblPaperQty.Text) - Convert.ToDouble(lblSendQty.Text)).ToString();
                }
            }

            //if (e.Row.RowIndex > 0)
            //{
            //    GridViewRow previousRow = GrdLOI.Rows[e.Row.RowIndex - 1];
            //    if (e.Row.Cells[1].Text == previousRow.Cells[1].Text)
            //    {
            //        if (previousRow.Cells[1].RowSpan == 0)
            //        {
            //            previousRow.Cells[1].RowSpan += 2;
            //            e.Row.Cells[1].Visible = false;
            //        }
            //    }
            //}
            
        }

       
        //for (int rowIndex = GrdLOI.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        //{
        //    GridViewRow gvRow = GrdLOI.Rows[rowIndex];
        //    GridViewRow gvPreviousRow = GrdLOI.Rows[rowIndex + 1];

        //    if ((gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
        //    {
        //        gvRow.Cells[0].Text = i.ToString();
        //    }
        //    else
        //    {
        //        i = i + 1;
        //    }
        //}

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int VenderID;
            if (ddlPrinter.SelectedItem.Text == "All")
            {
                VenderID = 0;
            }
            else
            {
                VenderID = Convert.ToInt32(ddlPrinter.SelectedValue);
            }

            string ChallanDate = "1900-01-01";
            if (txtFromDate.Text != "")
            {
                ChallanDate = FnDtFormat(txtFromDate.Text);
            }

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr1 = new DataSet();
            //dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewGSR('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            dsr1 = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchToPrinterCDSearchNewGSRsummary(1,'" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "','" + ChallanDate + "')");

            string SendQty, NoOfReels, TotReem, Noofsheet, BundleNo;
            SendQty = dsr1.Tables[0].Rows[0]["SendQty"].ToString();
            NoOfReels = dsr1.Tables[0].Rows[0]["NoOfReels"].ToString();
            TotReem = dsr1.Tables[0].Rows[0]["TotReem"].ToString();
            Noofsheet = dsr1.Tables[0].Rows[0]["BundleNo"].ToString();
            BundleNo = dsr1.Tables[0].Rows[0]["Noofsheet"].ToString();

            this.AddTotalRow("Total", SendQty, NoOfReels, TotReem, Noofsheet, BundleNo);


        }

    }
    public string FnDtFormat(string date)
    {
        if (date.Trim().Length > 0)
        {
            if (date.IndexOf('-') > 0)
            {
                date = date.Split('-')[2] + "-" + date.Split('-')[1] + "-" + date.Split('-')[0];
            }
            else
                date = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        }
        return date;
    }


    protected void fnFormatGridView()
    {
        i = 1;

        //for (int rowIndex = GridView1.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        //{
        //    GridViewRow gvRow = GridView1.Rows[rowIndex];
        //    GridViewRow gvPreviousRow = GridView1.Rows[rowIndex + 1];

        //    if ((gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
        //    {
        //        gvRow.Cells[0].Text = i.ToString();
        //    }
        //    else
        //    {
        //        i = i + 1;


        //    }
        //}

        for (int rowIndex = GrdLOI.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GrdLOI.Rows[rowIndex];
            GridViewRow gvPreviousRow = GrdLOI.Rows[rowIndex + 1];

            //if ((gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text))
            //{
            //    gvRow.Cells[0].Text = i.ToString();
            //}
            //else
            //{
            //    gvPreviousRow.Cells[0].Text = i.ToString();
            //    i = i - 1;
                
            //}

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
                else if (cellCount == 2)
                {
                    //  i = i + 1;
                    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text) && (gvRow.Cells[2].Text == gvPreviousRow.Cells[2].Text))
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

                //else if (cellCount > 9)
                //    //(cellCount == 9 || cellCount == 10 || cellCount == 11 || cellCount == 12 || cellCount == 13 || cellCount == 14)
                //{// not merge
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


                //else
                //{
                //    if ((gvRow.Cells[cellCount].Text == gvPreviousRow.Cells[cellCount].Text) && (gvRow.Cells[1].Text == gvPreviousRow.Cells[1].Text) && (gvRow.Cells[2].Text == gvPreviousRow.Cells[2].Text))
                //    {

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
            }
        }
    }

    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("ChallanDate").ToString();
        Literal ltrSno = (Literal)lt.FindControl("ltrSNo");
        
        if (!string.Equals(lt.Text, leaderName))
        {
            leaderName = lt.Text;
            ltrSno.Text = ltSno.ToString();
            ltSno++;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    protected void ltrChallanNo_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("ChallanNo").ToString();

        if (!string.Equals(lt.Text, ChallanNo))
        {
            ChallanNo = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
   
    
    protected void ltrDemandFrom_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
        lt.Text = Eval("NameofPress_V").ToString();

        if (!string.Equals(lt.Text, NameofPress_V))
        {
            NameofPress_V = lt.Text;
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    
    //protected void gridView_PreRender(object sender, EventArgs e)
    //{
    //    //GridDecorator.MergeRows(GrdLOI);
    //}

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //try
        //{
        GridFillLoad();
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //GrdLOI.DataSource = objPaperDispatchDetails.CDSearchNameChallan(txtSearch.Text);
        //GrdLOI.DataBind();
        //}
        //catch { }

        
    }
    ////////  EXport  Excel
    public void ExportToExcell()
    {
        GrdLOI.AllowPaging = false;
        GridFillLoad();
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GSRSupplyDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    //public override void VerifyRenderingInServerForm(Control control)
    //{
    //    //base.VerifyRenderingInServerForm(control);
    //}

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    protected void GrdLOI_PreRender(object sender, EventArgs e)
    {
        // GridDecorator.MergeRows(GrdLOI);
        // MergeRows(GrdLOI);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {

    }

    protected void GrdLOI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            //HeaderCell.Text = " प्रदाय का विवरण";
            HeaderCell.ColumnSpan = 6;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderGridRow.Cells.Add(HeaderCell);

             HeaderCell = new TableCell();
             HeaderCell.Text = "प्रदाय का विवरण";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderGridRow.Cells.Add(HeaderCell);
            
            HeaderCell = new TableCell();
            //HeaderCell.Text = "ट्रक एवं गोदाम की जानकारी";
            HeaderCell.ColumnSpan = 3;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderGridRow.Cells.Add(HeaderCell);

            GrdLOI.Controls[0].Controls.AddAt(0, HeaderGridRow);

        } 
    }
    private void AddTotalRow(string labelText, string SendQty, string NoOfReels, string TotReem, string Noofsheet, string BundleNo)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        // row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
        row.Cells.AddRange(new TableCell[11] { new TableCell (), //Empty Cell
                                        new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right},
                                        
                                          new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                           new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                            new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                             new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
              new TableCell { Text = NoOfReels , HorizontalAlign = HorizontalAlign.Right },                            
       // new TableCell { Text = NoOfReels+"Reel/"+TotReem+"Reem", HorizontalAlign = HorizontalAlign.Right }, 
        new TableCell { Text = Noofsheet, HorizontalAlign = HorizontalAlign.Right },
        new TableCell { Text = BundleNo, HorizontalAlign = HorizontalAlign.Right },
        
        new TableCell { Text = SendQty , HorizontalAlign = HorizontalAlign.Right },
         new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right}});

        GrdLOI.Controls[0].Controls.Add(row);
    }
}

