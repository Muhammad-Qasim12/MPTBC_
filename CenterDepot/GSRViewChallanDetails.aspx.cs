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

public partial class GSRViewChallanDetails : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = new PPR_PaperDispatchDetails ();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string CntrDepot_Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        CntrDepot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            VendorFill();
         
            
        }
    }
    public void GridFillLoad()
    {
        int VenderID = 0;
        //try
        //{
        if (ddlVendor.SelectedItem.Text == "All")
        {
            VenderID = 0;
        }
        else
        {
            VenderID = Convert.ToInt32(ddlVendor.SelectedValue);
        }

        string ChallanDate = "1900-01-01";
        if (txtFromDate.Text != "")
        {
            ChallanDate = FnDtFormat(txtFromDate.Text);
        }

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr=new DataSet();
            //dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewGSR('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewGSR('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "','" + ChallanDate + "')");
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();
        //}
        //catch { }

            if (GrdLOI.Rows.Count > 0)
                btnExport.Visible = true;
            else
                btnExport.Visible = false;

    }

    protected void GrdLOI_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridView HeaderGrid = (GridView)sender;
            GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 7;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderGridRow.Cells.Add(HeaderCell);
            HeaderCell = new TableCell();
            HeaderCell.Text = " प्राप्ति का विवरण";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderGridRow.Cells.Add(HeaderCell);
            //HeaderCell = new TableCell();
            //HeaderCell.Text = "प्राप्ति मात्रा की जानकारी";
            //HeaderCell.ColumnSpan = 4;
            //HeaderCell.BackColor = System.Drawing.Color.Gray;
            //HeaderCell.ForeColor = System.Drawing.Color.White;
            //HeaderGridRow.Cells.Add(HeaderCell);

            HeaderCell = new TableCell();
            HeaderCell.Text = "";
            HeaderCell.ColumnSpan = 4;
            HeaderCell.BackColor = System.Drawing.Color.Gray;
            HeaderCell.ForeColor = System.Drawing.Color.White;
            HeaderGridRow.Cells.Add(HeaderCell);

            GrdLOI.Controls[0].Controls.AddAt(0, HeaderGridRow);

            //gridview header 2
            //GridViewRow HeaderGridRow22 = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);
            //TableCell HeaderCell22 = new TableCell();
            //HeaderCell22.Text = "1";
            //HeaderCell22.ColumnSpan = 1;
            //HeaderCell22.BackColor = System.Drawing.Color.Gray;
            //HeaderCell22.ForeColor = System.Drawing.Color.White;
            //HeaderGridRow.Cells.Add(HeaderCell22);
            //GrdLOI.Controls[2].Controls.AddAt(0, HeaderGridRow22);
        }
    }

    private void CreateSecondHeader()
    {
        GridViewRow row = new GridViewRow(0, -1, DataControlRowType.Header, DataControlRowState.Normal);

        TableCell left = new TableHeaderCell();
        left.ColumnSpan = 1;
        left.Text = "1";
        row.Cells.Add(left);
        
        this.InnerTable.Rows.AddAt(0, row);
    }

    protected Table InnerTable
    {
        get
        {
            if (this.HasControls())
            {
                return (Table)this.Controls[0];
            }

            return null;
        }
    }

    public void VendorFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "All");
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
                    t.Rows.AddAt(2, row);
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblChallanDate = (Label)e.Row.FindControl("lblChallanDate");
            Label lblSupplyTillDate_D = (Label)e.Row.FindControl("lblSupplyTillDate_D");
            Label lblPaperQty = (Label)e.Row.FindControl("lblPaperQty");
            Label lblLOITrId_I = (Label)e.Row.FindControl("lblLOITrId_I");
            Label lblPaperVendorTrId_I = (Label)e.Row.FindControl("lblPaperVendorTrId_I");
            Label lblPaperMstrTrId_I = (Label)e.Row.FindControl("lblPaperMstrTrId_I");
            Label lblReceivedDate = (Label)e.Row.FindControl("lblReceivedDate");
            Label lblSupplyDate_D = (Label)e.Row.FindControl("lblSupplyDate_D");
            DateTime dat = new DateTime();
            try
            {

                if (lblReceivedDate.Text == "0001-01-01 00:00:00")
                {
                    lblReceivedDate.Text = "";
                }
                else
                {
                    dat = DateTime.Parse(lblReceivedDate.Text);
                    lblReceivedDate.Text = dat.ToString("dd/MM/yyyy");
                }
            }
            catch { }

            dat = DateTime.Parse(lblChallanDate.Text);
            lblChallanDate.Text = dat.ToString("dd/MM/yyyy");
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(lblPaperVendorTrId_I.Text);
            objPaperDispatchDetails.LOITrId_I = int.Parse(lblLOITrId_I.Text);
            objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
            ds = objPaperDispatchDetails.WorkQtyData();
            if (ds.Tables[0].Rows.Count > 0)
            {
                try
                {
                    dat = DateTime.Parse(ds.Tables[0].Rows[0]["SupplyTillDate_D"].ToString());
                    lblSupplyTillDate_D.Text = dat.ToString("dd/MM/yyyy");
                }
                catch { }
                try
                {
                    dat = DateTime.Parse(ds.Tables[0].Rows[0]["SupplyDate_D"].ToString());
                    lblSupplyDate_D.Text = dat.ToString("dd/MM/yyyy");
                }
                catch { }
                lblPaperQty.Text = ds.Tables[0].Rows[0]["PaperQuantity_N"].ToString();
            }
            else
            {
                lblPaperQty.Text = "0";
            }

            Label lblPaperCategory = (Label)e.Row.FindControl("lblPaperCategory");
            Label lblSendQty = (Label)e.Row.FindControl("lblSendQty");
            Label lblNoOfReels = (Label)e.Row.FindControl("lblNoOfReels");
            Label lblBalance = (Label)e.Row.FindControl("lblBalance");
            Label lblSheet = (Label)e.Row.FindControl("lblSheet");
            Label lblReel = (Label)e.Row.FindControl("lblReel");
            Label lblBandal = (Label)e.Row.FindControl("lblBandal");
            Label lblReceivedQty_in_sheet = (Label)e.Row.FindControl("lblReceivedQty_in_sheet");
            
            if (lblSendQty.Text != "" && lblPaperQty.Text != "")
            {
                if (lblPaperCategory.Text == "Sheet")
                {
                    //lblSheet.Text = lblPaperQty.Text + ' ' + lblPaperCategory.Text;
                    //lblSheet.Text = lblReceivedQty_in_sheet.Text + ' ' + lblPaperCategory.Text;
                    //lblSheet.Text = lblNoOfReels.Text + ' ' + lblPaperCategory.Text;
                    DataRowView drv = e.Row.DataItem as DataRowView;
                    string sheetnos = drv.Row["SheetNo"].ToString();
                    lblSheet.Text = (sheetnos != "0" && sheetnos != "") ? sheetnos + ' ' + lblPaperCategory.Text : "--";
                    lblReel.Text = "--";
                    //lblBandal.Text = Convert.ToString(Convert.ToInt32(lblPaperQty.Text) / 576);
                    //lblBandal.Text = Convert.ToString(Convert.ToInt32(Convert.ToDecimal(lblReceivedQty_in_sheet.Text)) / 576);
                    
                    lblBandal.Text = drv.Row["NoOfReels"].ToString();
                }
                else
                {
                    lblSheet.Text = "--";
                    //lblReel.Text = lblPaperQty.Text + ' ' + lblPaperCategory.Text;
                    lblReel.Text = lblNoOfReels.Text + ' ' + lblPaperCategory.Text;
                    lblBandal.Text = "--";
                    
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            int VenderID;
            if (ddlVendor.SelectedItem.Text == "All")
            {
                VenderID = 0;
            }
            else
            {
                VenderID = Convert.ToInt32(ddlVendor.SelectedValue);
            }

            string ChallanDate = "1900-01-01";
            if (txtFromDate.Text != "")
            {
                ChallanDate = FnDtFormat(txtFromDate.Text);
            }

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr1 = new DataSet();
            //dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewGSR('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "')");
            dsr1 = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchToPrinterCDSearchNewGSRsummary(2,'" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "','" + ChallanDate + "')");

            string SendQty, NoOfReels, TotReem, Noofsheet, BundleNo;
            SendQty = dsr1.Tables[0].Rows[0]["SendQty"].ToString();
            NoOfReels = dsr1.Tables[0].Rows[0]["NoOfReels"].ToString();
            TotReem = dsr1.Tables[0].Rows[0]["TotReem"].ToString();
            Noofsheet = dsr1.Tables[0].Rows[0]["Noofsheet"].ToString();
            BundleNo = dsr1.Tables[0].Rows[0]["sheetno"].ToString();

            this.AddTotalRow("Total",  SendQty, NoOfReels , TotReem , Noofsheet , BundleNo );


        }

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //try
        //{
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //GrdLOI.DataSource = objPaperDispatchDetails.CenterDpotSearchName(txtSearch.Text);
        //GrdLOI.DataBind();
          int VenderID = 0;
            if (ddlVendor.SelectedItem.Text == "All")
            {
                VenderID = 0;
            }
            else
            {
                VenderID = Convert.ToInt32(ddlVendor.SelectedValue);
            }

            string ChallanDate = "1900-01-01";
        if (txtFromDate.Text != "")
        {
            ChallanDate = FnDtFormat(txtFromDate.Text);
        }
            CommonFuction obCommonFuction = new CommonFuction();
            DataSet dsr = new DataSet();
            dsr = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchCDSearchNameNewGSR('" + txtSearch.Text + "'," + VenderID + ",'" + ddlAcYear.SelectedItem.Text + "','"+ChallanDate+"')");
            GrdLOI.DataSource = dsr;
            GrdLOI.DataBind();

            if (GrdLOI.Rows.Count > 0)
                btnExport.Visible = true;
            else
                btnExport.Visible = false;
        //}
        //catch { }
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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "GSRPraptiDetails.xls"));
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
    private void AddTotalRow(string labelText, string SendQty, string NoOfReels,string TotReem,string Noofsheet,string BundleNo)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        // row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
        row.Cells.AddRange(new TableCell[11] { new TableCell (), //Empty Cell
                                        new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right},
                                         new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                          new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                           new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                            new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
                                             new TableCell { Text = "", HorizontalAlign = HorizontalAlign.Right},
              new TableCell { Text = NoOfReels , HorizontalAlign = HorizontalAlign.Right },                            
       // new TableCell { Text = NoOfReels+"Reel/"+TotReem+"Reem", HorizontalAlign = HorizontalAlign.Right }, 
        new TableCell { Text = Noofsheet, HorizontalAlign = HorizontalAlign.Right },
        new TableCell { Text = BundleNo, HorizontalAlign = HorizontalAlign.Right },
        
        new TableCell { Text = SendQty , HorizontalAlign = HorizontalAlign.Right }});

        GrdLOI.Controls[0].Controls.Add(row);
    }
}