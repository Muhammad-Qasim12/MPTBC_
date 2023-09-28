using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer ;
using MPTBCBussinessLayer.DistributionB;
using System.IO;
using System.Data;
public partial class Printing_Reports_RPT003a_GroupAllotment : System.Web.UI.Page
{
    PRI003_RPTGroupAllotment obGroupAllotment = null;
    PRI_PrinterRegistration obPriReg = null;
    DemandfromOthers obDemandfromOthers = new DemandfromOthers();
    CommonFuction obCommon = null;
    int currentId = 0;
    decimal subTotal = 0; decimal vitsubTotal = 0; decimal tenqtysubTotal = 0; decimal PaperIssuesubTotal=0;
    decimal total = 0; decimal vittotal = 0; decimal tenqtytotal = 0; decimal PaperIssueTotal = 0;
    int subTotalRowIndex = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadAcYear(); 
            FillData(); 
            btnExport.Visible = false;
            btnExportPDF.Visible = false;

        }
    }

    public void MergeRows(GridView gridView)
    {
        for (int rowIndex = GrdGroupDetails.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow row = gridView.Rows[rowIndex];
            GridViewRow previousRow = gridView.Rows[rowIndex + 1];

            for (int i = 0; i < row.Cells.Count; i++)
            {
                if (row.Cells[i].Text == previousRow.Cells[i].Text)
                {
                    row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                           previousRow.Cells[i].RowSpan + 1;
                    previousRow.Cells[i].Visible = false;
                }
            }
        }
    }


    public void LoadAcYear() 
    {
        obDemandfromOthers.QueryType = -1;
        ddlAcYearId.DataSource = obDemandfromOthers.Select();
        ddlAcYearId.DataTextField = "AcYear";
        ddlAcYearId.DataValueField = "AcYear";
        ddlAcYearId.DataBind();
        ddlAcYearId.SelectedIndex = 0;
       // FillData();

        //ddlAcYearId.Items.Insert(0, new ListItem("Select", "0"));

       // BindTenderNo();
    
    }

  


    public void FillData()
    {
        try
        {
            obPriReg = new PRI_PrinterRegistration();

            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";

            obPriReg.Printer_RedID_I = 0;
            //ddlPrinter.DataSource = obPriReg.PrinterRegistrationLoad();
            obCommon = new CommonFuction();
            DataSet dd = obCommon.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload_wo_wise(0,'" + ddlAcYearId.SelectedItem.Text + "')");
            ddlPrinter.DataSource = dd;
            ddlPrinter.DataBind();

          


            ddlPrinter.Items.Insert(0, new ListItem("All", "0"));

        }
        catch (Exception ex)
        {
        }
        finally
        {
            obPriReg = null;
        }
    }



    public void LoadGroup()
    {
        obGroupAllotment = new PRI003_RPTGroupAllotment();

        try
        {
            lblTitle.Text = "शेक्षणिक सत्र :" + ddlAcYearId.SelectedItem.Text + ", प्रिंटर का नाम :" + ddlPrinter.SelectedItem.Text+", दिनांक :"+System.DateTime.Now.ToString("MMM dd,yyyy");;
            obGroupAllotment.Printer_RedID_I = Convert.ToInt32(ddlPrinter.SelectedValue);
            obGroupAllotment.AcYearId = Convert.ToString(ddlAcYearId.SelectedValue);
            //GrdGroupDetails.DataSource = obGroupAllotment.LoadGroupAllotment();
            GrdGroupDetails.DataSource = GetLoadGroup(obGroupAllotment);
            GrdGroupDetails.DataBind();

            if (GrdGroupDetails.Rows.Count > 0)
            {
                btnExport.Visible = true;
                btnExportPDF.Visible = true;
              
            }
            else
            {
                btnExport.Visible = false;
                btnExportPDF.Visible = false ;
                
            }



        }

        catch (Exception ex)
        {
        }
        finally
        {
            obGroupAllotment = null;
        }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadGroup();
        BindTenderNo();

    }
     public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "PrinterTender.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

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

    protected void btnExport_Click(object sender, EventArgs e)
    {
        ExportToExcell();
    }
    protected void btnExportPDF_Click(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LoadGroup();
    }
    public void BindTenderNo()
    {
        DataSet ds = new DataSet();
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTenderDetails(0,'" + ddlAcYearId.SelectedItem.Text + "')"); ;
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, new ListItem("All", "0"));
        //LoadGroup();
    }

    public DataSet GetLoadGroup(PRI003_RPTGroupAllotment ob)
    {
        int tenID = 0;
        if (ddlTenderID_I.SelectedIndex>0)
        tenID=Convert.ToInt32(ddlTenderID_I.SelectedValue);
        DataSet ds1 = new DataSet();
        CommonFuction obCommonFuction = new CommonFuction();
        ds1 = obCommonFuction.FillDatasetByProc("call InsertData_MisReport201718('"+ob.AcYearId + "','"+ddlPrinter.SelectedValue+"')");  
       return ds1;
    }
    protected void GrdGroupDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    string previousCov = ""; int firstRow = -1;
    string previousCov11 = ""; int firstRow11 = -1;
    string previousCov22 = ""; int firstRow22 = -1;
    protected void GrdGroupDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridView grid = sender as GridView;
        if (e.Row.RowType == DataControlRowType.Header)
        {
           
            GridViewRow row = new GridViewRow(0, -1,
                DataControlRowType.Header, DataControlRowState.Normal);

            for (int Index = 1; Index <= GrdGroupDetails.Columns.Count; Index++)
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
                    t.Rows.AddAt(0, row);
                }
            }
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //try
            //{
            //    DataRowView drv = ((DataRowView)e.Row.DataItem);
            //    if (previousCov == drv["NamePrinters"].ToString())
            //    {
            //        if (GrdGroupDetails.Rows[firstRow].Cells[1].RowSpan == 0)
            //        {
            //            GrdGroupDetails.Rows[firstRow].Cells[1].RowSpan = 2;
            //            //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align", "middle");
            //        }
            //        else
            //        {
            //            GrdGroupDetails.Rows[firstRow].Cells[1].RowSpan += 1;
            //            //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align","middle");
            //        }
            //        e.Row.Cells.RemoveAt(1);

            //    }
            //    else
            //    {
            //        //e.Row.VerticalAlign = VerticalAlign.Middle;
            //        previousCov = drv["NamePrinters"].ToString();
            //        firstRow = e.Row.RowIndex;
            //    }
            //}
            //catch { }

            //try
            //{
            //    DataRowView drv11 = ((DataRowView)e.Row.DataItem);
            //    if (previousCov11 == drv11["bankguarent"].ToString())
            //    {
            //        if (GrdGroupDetails.Rows[firstRow11].Cells[3].RowSpan == 0)
            //        {
            //            GrdGroupDetails.Rows[firstRow11].Cells[3].RowSpan = 2;
            //            //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align", "middle");
            //        }
            //        else
            //        {
            //            GrdGroupDetails.Rows[firstRow11].Cells[3].RowSpan += 1;
            //            //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align","middle");
            //        }
            //        e.Row.Cells.RemoveAt(3);

            //    }
            //    else
            //    {
            //        //e.Row.VerticalAlign = VerticalAlign.Middle;
            //        previousCov11 = drv11["bankguarent"].ToString();
            //        firstRow11 = e.Row.RowIndex;
            //    }
            //}
            //catch { }

            //try
            //{
            //    DataRowView drv22 = ((DataRowView)e.Row.DataItem);
            //    if (previousCov22 == drv22["bankguarentaddition"].ToString())
            //    {
            //        if (GrdGroupDetails.Rows[firstRow22].Cells[13].RowSpan == 0)
            //        {
            //            GrdGroupDetails.Rows[firstRow22].Cells[13].RowSpan = 2;
            //            //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align", "middle");
            //        }
            //        else
            //        {
            //            GrdGroupDetails.Rows[firstRow22].Cells[13].RowSpan += 1;
            //            //GridView1.Rows[firstRow].Cells[1].Style.Add("vertical-align","middle");
            //        }
            //        e.Row.Cells.RemoveAt(13);

            //    }
            //    else
            //    {
            //        //e.Row.VerticalAlign = VerticalAlign.Middle;
            //        previousCov22 = drv22["bankguarentaddition"].ToString();
            //        firstRow22 = e.Row.RowIndex;
            //    }
            //}
            //catch { }
        }
    }
    protected void ddlAcYearId_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        ddlPrinter.DataTextField = "NameofPress_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        obCommon = new CommonFuction();
        DataSet dd = obCommon.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload_wo_wise(0,'" + ddlAcYearId.SelectedItem.Text + "')");
        ddlPrinter.DataSource = dd;
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void GrdGroupDetails_DataBound(object sender, EventArgs e)
    {
        for (int rowIndex = GrdGroupDetails.Rows.Count - 2; rowIndex >= 0; rowIndex--)
        {
            GridViewRow gvRow = GrdGroupDetails.Rows[rowIndex];
            GridViewRow gvPreviousRow = GrdGroupDetails.Rows[rowIndex + 1];
            for (int cellCount = 0; cellCount < gvRow.Cells.Count; cellCount++)
            {

                if (cellCount <0)
                {
                }
                else
                {
                    if (cellCount == 1 || cellCount == 3 || cellCount == 12 || cellCount == 13 || cellCount == 14)
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
                }
            }
        }

       for (int i = subTotalRowIndex; i < GrdGroupDetails.Rows.Count; i++)
        {
            subTotal += Convert.ToDecimal(GrdGroupDetails.Rows[i].Cells[2].Text);
        }
       this.AddTotalRow("Sub Total", "", subTotal.ToString("N2"), vitsubTotal.ToString("N2"), tenqtysubTotal.ToString("N2"), PaperIssuesubTotal.ToString("N2"));
       this.AddTotalRow("Total", "", total.ToString("N2"), vittotal.ToString("N2"), tenqtytotal.ToString("N2"), PaperIssueTotal.ToString("N2"));
       
    }

    // total and subtotal
    protected void OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (e.Row.DataItem as DataRowView).DataView.Table;
            int orderId = Convert.ToInt32(dt.Rows[e.Row.RowIndex]["PrinterID"]);
            total += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["TENDERTOTAL"]);
            vittotal += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["VITRANTOT"]);
            tenqtytotal += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["QtyAsPerTender"]);
            PaperIssueTotal +=   Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["PaperIssue"] );
            
            
            try
            {
                subTotal += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["TENDERTOTAL"]);
                vitsubTotal += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["VITRANTOT"]);
                tenqtysubTotal += Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["QtyAsPerTender"]);
                PaperIssuesubTotal +=   Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["PaperIssue"]);
                //
            }
            catch { }

            if (orderId != currentId)
            {
                if (currentId != 0)
                {

                    subTotal = subTotal - Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["TENDERTOTAL"]);
                    vitsubTotal =vitsubTotal- Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["VITRANTOT"]);
                    tenqtysubTotal =tenqtysubTotal- Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["QtyAsPerTender"]);
                    PaperIssuesubTotal = PaperIssuesubTotal -   Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["PaperIssue"]);
                }
                if (e.Row.RowIndex > 0)
                {

                    for (int i = subTotalRowIndex; i < e.Row.RowIndex; i++)
                    {

                    }
                    this.AddTotalRow("Sub Total", "", subTotal.ToString("N2"), vitsubTotal.ToString("N2"), tenqtysubTotal.ToString("N2"), PaperIssuesubTotal.ToString("N2"));
                    subTotalRowIndex = e.Row.RowIndex;
                    if (currentId != 0)
                    {
                        subTotal = Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["TENDERTOTAL"]);
                        vitsubTotal = Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["VITRANTOT"]);
                        tenqtysubTotal = Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["QtyAsPerTender"]);
                        PaperIssuesubTotal =   Convert.ToDecimal(dt.Rows[e.Row.RowIndex]["PaperIssue"]);
                    }
                }
                currentId = orderId;
            }



        }
        else
        {
            if (currentId == 0) { }
            else
            {
                this.AddTotalRow("Sub Total", "", subTotal.ToString("N2"), vitsubTotal.ToString("N2"), tenqtysubTotal.ToString("N2"), PaperIssuesubTotal.ToString("N2"));
                this.AddTotalRow("Total", "", total.ToString("N2"), vittotal.ToString("N2"), tenqtytotal.ToString("N2"), PaperIssueTotal.ToString("N2"));
            }

        }

    }

    private void AddTotalRow(string labelText, string valuena, string value, string vitvalue, string tenqtyvalue, string paperallotvalue)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
        row.BackColor = System.Drawing.Color.Gray;
        // ColorTranslator.FromHtml("#F9F9F9");
        row.Cells.AddRange(new TableCell[15] { new TableCell (), //Empty Cell
                                        new TableCell { Text = labelText, HorizontalAlign = HorizontalAlign.Right},
                                        new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
                                        new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
                                         new TableCell { Text = value, HorizontalAlign = HorizontalAlign.Right },
        new TableCell { Text = vitvalue, HorizontalAlign = HorizontalAlign.Right },
        new TableCell { Text = tenqtyvalue, HorizontalAlign = HorizontalAlign.Right },
         new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
          new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
           new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
            new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
             new TableCell { Text = paperallotvalue, HorizontalAlign = HorizontalAlign.Right },
              new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
               new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right },
        new TableCell { Text = valuena, HorizontalAlign = HorizontalAlign.Right }
        });

        GrdGroupDetails.Controls[0].Controls.Add(row);
    }

    /*protected void OnDataBound(object sender, EventArgs e)
    {
        for (int i = subTotalRowIndex; i < GrdGroupDetails.Rows.Count; i++)
        {
            subTotal += Convert.ToDecimal(GrdGroupDetails.Rows[i].Cells[2].Text);
        }
        this.AddTotalRow("Sub Total", subTotal.ToString("N2"), subTotal.ToString("N2"));
        this.AddTotalRow("Total", total.ToString("N2"), subTotal.ToString("N2"));
    }
    */
}