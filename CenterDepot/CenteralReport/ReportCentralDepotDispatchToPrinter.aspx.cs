using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Text;
using System.IO;

public partial class CenterDepot_ReportCentralDepotDispatchToPrinter : System.Web.UI.Page
{
   public

       decimal vales; int count;
    DataSet ds; DataTable Dt; StringBuilder sb = new StringBuilder();
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    public int reem, bundle,TotalBundle;
    public string GRNo;
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string CntrDepot_Id = ""; double TotNet = 0, TotGrossWt = 0, TotSheets = 0; int TotNetBundlNo = 0;
    public string address; public string titlehindi_v = ""; protected string recievername = ""; protected string recievdDt = ""; string paperdemand = "";
    protected string GRdate = ""; protected string pageno = "";
    protected string suppliername = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            fillParameter();
            if (DdlACYear.SelectedItem.Text != "Select")
            {
                PrinterAllFill();
            }

            //landing page for printing from viewdispatchtoprintier.aspx page in CPD
            if (Request.QueryString["Ono"] != null)
            {
                
                string Challanno = objdb.Decrypt(Request.QueryString["Ono"].ToString());
                string PrinterId = objdb.Decrypt(Request.QueryString["PrinterId"].ToString());
                string acyear = objdb.Decrypt(Request.QueryString["acyr"].ToString());

                DdlACYear.ClearSelection();
                try
                {
                    DdlACYear.Items.FindByValue(acyear).Selected = true;
                }
                catch { }

                ddlPrinter.ClearSelection();
                try
                {
                    ddlPrinter.Items.FindByValue(PrinterId).Selected = true;
                }
                catch { }

                if (ddlPrinter.SelectedValue != "Select" && ddlPrinter.Items.Count>0)
                {
                    ddlPrinter_SelectedIndexChanged(null, null);
                    try
                    {
                        ddlOrderNo.Items.FindByText(Challanno).Selected = true;
                        if (ddlOrderNo.Items.Count > 0 && ddlOrderNo.SelectedItem.Text != "All")
                        {
                            btnSearch_Click(null, null);
                        }
                    }
                    catch { }
                }
            }
        }
    }
    public void fillParameter()
    {
        CommonFuction comm = new CommonFuction();
        DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        DdlACYear.DataValueField = "AcYear";
        DdlACYear.DataTextField = "AcYear";
        DdlACYear.DataBind();
        try
        {
            DdlACYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
        }
        catch { }
    }

    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
        ddlPrinter.DataSource = string.Empty;
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
    }
    public void PrinterAllFill()
    {
        BindPrinterDDL();
        if (ddlDemandType.Text == "पाठ्यपुस्तक")
        {
        //    //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //    ddlPrinter.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ReportPaperDispatchToPrinterByParam('" + DdlACYear.SelectedItem.Text + "','0','0','',1)"); //objPaperDispatchDetails.PrinterFill();
        //    ddlPrinter.DataTextField = "NameofPress_V";
        //    ddlPrinter.DataValueField = "PrinterID_I";
        //    ddlPrinter.DataBind();
        //    ddlPrinter.Items.Insert(0, "Select");
            divHeadTitle.InnerHtml = "पाठ्यपुस्तक हेतु पेपर की मांग का आवंटन की रिपोर्ट / Report of Paper Demand Of Textbook Allotment";
            tdInfo.InnerHtml = "रीलो का विवरण ";
        }
        else if (ddlDemandType.Text == "अन्य पाठ्य सामग्री")
        {
        //    //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //    ddlPrinter.DataSource = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ReportPaperDispatchToPrinterByParam('" + DdlACYear.SelectedItem.Text + "','0','0','',2)"); //objPaperDispatchDetails.AcdmicPrinterFill();
        //    ddlPrinter.DataTextField = "NameofPress_V";
        //    ddlPrinter.DataValueField = "PrinterID_I";
        //    ddlPrinter.DataBind();
        //    ddlPrinter.Items.Insert(0, "Select");
            divHeadTitle.InnerHtml = "अन्य पाठ्य सामग्री हेतु पेपर की मांग का आवंटन की रिपोर्ट / Report of Paper Demand Of Other Than Textbook Allotment";
           tdInfo.InnerHtml = "रीलो का विवरण ";
        }
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
    protected void GvReelDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lbl01 = (Label)e.Row.FindControl("lbl01");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            HiddenField hf = e.Row.FindControl("hdnPaperType_I_grdv") as HiddenField;
            foreach (TableCell cell in e.Row.Cells)
            {
                if (lblTotalSheets.Text == "0.000 Sheets" || lblTotalSheets.Text == "0.00")
                {
                    cell.BackColor = System.Drawing.Color.Green;
                    cell.ForeColor = System.Drawing.Color.White;
                }
            }

            try
            {
                if (hf.Value == "2")
                {
                    TotSheets = TotSheets + double.Parse(lblTotalSheets.Text);
                    
                }
            }
            catch { TotSheets = 0; }

            try
            {
                TotNet = TotNet + double.Parse(lblNetWt.Text);
                //TotalBundle = TotalBundle + Convert.ToInt32(lbl01.Text);
            }
            catch { TotNet = 0; }

            try
            {
                //TotNet = TotNet + double.Parse(lblNetWt.Text);
                TotalBundle = TotalBundle + Convert.ToInt32(lbl01.Text);
                            
            }
            catch { TotalBundle = 0; }

            try
            { TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text); }
            catch { TotGrossWt = 0; }

            
            if (hf.Value == "1")
            {
                e.Row.Cells[1].Visible = false;
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");
            Label lblTotGrossWt = (Label)e.Row.FindControl("lblTotGrossWt");
            Label lblTot1Sheets = (Label)e.Row.FindControl("lblTotSheets");                       
            
            lblTotNetWt.Text = TotNet.ToString("0.0000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.0000");
            lblTot1Sheets.Text = TotSheets.ToString();
           // Label3.Text = TotalBundle.ToString("0.000");
            Label4.Text = TotNet.ToString("0.0000");
            Label5.Text = TotGrossWt.ToString("0.0000");
            Label6.Text = lblTot1Sheets.Text;
            
        }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        disableControl();
        OrderNoAllFill();
    }

    public void OrderNoAllFill()
    {
        disableControl();
        CommonFuction comm = new CommonFuction();
        if (ddlPrinter.SelectedIndex > 0)
        {
            ddlOrderNo.DataSource = obCommonFuction.FillDatasetByProc("Call USP_FillChallanNO('" + Int32.Parse(ddlPrinter.SelectedValue) + "','" + DdlACYear.SelectedItem.Text + "')");
            ddlOrderNo.DataValueField = "ChallanNo";
            ddlOrderNo.DataTextField = "ChallanNo";
            ddlOrderNo.DataBind();
            if (ddlOrderNo.Items.Count > 0)
            {
                ddlOrderNo.Items.Insert(0, new ListItem("All", "0"));
            }
            else
            {
                ddlOrderNo.DataSource = string.Empty;
                ddlOrderNo.DataBind();
                ddlOrderNo.Items.Insert(0, "Select");
            }
        }
        else
        {
            ddlOrderNo.DataSource = string.Empty;
            ddlOrderNo.DataBind();
            ddlOrderNo.Items.Insert(0, "Select");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select printer name.');</script>");
        }

    }
    public void GridFillLoad()
    {
        try
        {
            ds = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ReportPaperDispatchToPrinterByParam('" + DdlACYear.SelectedItem.Text + "','" + ddlDemandType.SelectedItem.Text + "','" + Int32.Parse(ddlPrinter.SelectedValue) + "','" + ddlOrderNo.SelectedValue + "',0)");
            GrdLOI.DataSource = ds.Tables[0];
            GrdLOI.DataBind();
        }
        catch { }

    }
    protected void GrdLOI_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //objPaperDispatchDetails.Delete(Convert.ToInt32(GrdLOI.DataKeys[e.RowIndex].Value.ToString()));
        //GridFillLoad();
    }
    int j = 0;
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        DataSet dsChild = new DataSet();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            j = j + 1;
            //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(" + objdb.Decrypt(Request.QueryString["ID"].ToString()) + ",'" + txtChallanNo.Text + "','',4)");
            int mPaperVendorTrId_I = Int32.Parse(GrdLOI.DataKeys[e.Row.RowIndex].Value.ToString());
            Label lblChallanNo = e.Row.FindControl("lblChallanNo") as Label; // (Label)GrdLOI.FindControl("lblChallanNo");
            Label lblPaperMstrTrId_I = e.Row.FindControl("lblPaperMstrTrId_I") as Label; // (Label)GrdLOI.FindControl("lblChallanNo");
            HiddenField hdnPaperType_I = e.Row.FindControl("hdnPaperType_I") as HiddenField;
            
            GridView gvOrders = e.Row.FindControl("gvOrders") as GridView;
           
            GridView gvOrders1 = e.Row.FindControl("GridView2") as GridView;
            GridView gvOrders2 = e.Row.FindControl("GridView3") as GridView;
            dsChild = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ReportProcReelStockEntry(" + mPaperVendorTrId_I + ",'" + lblChallanNo.Text + "','" + lblPaperMstrTrId_I.Text + "',4)");
            TotNet = 0; TotGrossWt = 0; TotSheets = 0;
            if (count == 0)
            {
                count = count + 1;
                reem=Convert.ToInt32 (dsChild.Tables[0].Rows.Count);
            }
            else {
                bundle = Convert.ToInt32(dsChild.Tables[0].Rows.Count);
            }
            sb.Append(mPaperVendorTrId_I + ",");
            if (dsChild.Tables[0].Rows.Count > 0)
            {
                gvOrders.DataSource = dsChild.Tables[0];
                gvOrders.DataBind();
                

                 try {
                     gvOrders1.DataSource = dsChild.Tables[1];
                     gvOrders1.DataBind();
                     gvOrders2.DataSource = dsChild.Tables[2];
                     gvOrders2.DataBind();
                     //gvOrders2.Visible = false;   
                 }
                 catch { }
            }

            if (hdnPaperType_I.Value == "1")
            {
                if (gvOrders.Rows.Count > 0)
                {
                    gvOrders.HeaderRow.Cells[1].Visible = false;
                    gvOrders.FooterRow.Cells[1].Visible = false;

                    gvOrders.HeaderRow.Cells[0].Text = "क्रमांक<br>SrNo<br>1";
                    gvOrders.HeaderRow.Cells[2].Text = "रील नंबर<br>Roll No.<br>2";
                    gvOrders.HeaderRow.Cells[3].Text = "नेट वजन (मे. टन)<br>Net Weight(M.T.)<br>3";
                    gvOrders.HeaderRow.Cells[4].Text = "ग्रॉस वजन (मे. टन)<br>Gross Weight(M.T.)<br>4";
                }

                if (gvOrders1.Rows.Count > 0)
                {
                    gvOrders1.HeaderRow.Cells[1].Visible = false;
                    gvOrders1.FooterRow.Cells[1].Visible = false;

                    gvOrders1.HeaderRow.Cells[0].Text = "क्रमांक<br>SrNo<br>1";
                    gvOrders1.HeaderRow.Cells[2].Text = "रील नंबर<br>Roll No.<br>2";
                    gvOrders1.HeaderRow.Cells[3].Text = "नेट वजन (मे. टन)<br>Net Weight(M.T.)<br>3";
                    gvOrders1.HeaderRow.Cells[4].Text = "ग्रॉस वजन (मे. टन)<br>Gross Weight(M.T.)<br>4";
                }
                if (gvOrders2.Rows.Count > 0)
                {
                    gvOrders2.HeaderRow.Cells[1].Visible = false;
                    gvOrders2.FooterRow.Cells[1].Visible = false;

                    gvOrders2.HeaderRow.Cells[0].Text = "क्रमांक<br>SrNo<br>1";
                    gvOrders2.HeaderRow.Cells[2].Text = "रील नंबर<br>Roll No.<br>2";
                    gvOrders2.HeaderRow.Cells[3].Text = "नेट वजन (मे. टन)<br>Net Weight(M.T.)<br>3";
                    gvOrders2.HeaderRow.Cells[4].Text = "ग्रॉस वजन (मे. टन)<br>Gross Weight(M.T.)<br>4";
                }

            }

            if (hdnPaperType_I.Value == "2")
            {
                if (gvOrders.Rows.Count > 0)
                {
                    gvOrders.HeaderRow.Cells[2].Text = "बंडल नंबर <br> Bundle No.</br>3";
                }
                if (gvOrders1.Rows.Count > 0)
                {
                    gvOrders1.HeaderRow.Cells[2].Text = "बंडल नंबर <br> Bundle No.</br>3";
                }
                if (gvOrders2.Rows.Count > 0)
                {
                    gvOrders2.HeaderRow.Cells[2].Text = "बंडल नंबर <br> Bundle No.</br>3";
                }
                System.Web.UI.HtmlControls.HtmlTableRow tr11 = (System.Web.UI.HtmlControls.HtmlTableRow)e.Row.FindControl("trHeader");
                if (tr11 != null)
                {
                    tr11.Visible = false;
                }

                if (gvOrders.Rows.Count > 0)
                {
                    Label lblTotBundle = (Label)gvOrders.FooterRow.FindControl("lblTotBundle");
                }
                //lblTotBundle.Text = gvOrders.Rows.Count.ToString();

            }

            if (j == 1 ||   lblPaperMstrTrId_I.Text=="42")
            { 
            
            
            }
            else
            {
              //  if (lblPaperMstrTrId_I.Text == "27" || lblPaperMstrTrId_I.Text == "42")
              //  {
                    gvOrders.Visible = false;
              //  }
               // else
               // { gvOrders.Visible = false; }
                gvOrders1.Visible = false;
                gvOrders2.Visible = false;
            }
        }

    }
    string leaderName;
    protected void ltrLeader_DataBinding(object sender, EventArgs e)
    {
        Literal lt = (Literal)sender;
           //Label lb1 = (Label)sender;
       //  Literal lt1=
        lt.Text = (Eval("TruckNo") + " <br> में मेसर्स  " + Eval("DriverName")).ToString();
       // Label2
        if (!string.Equals(lt.Text, leaderName))
        {
            leaderName = lt.Text ;
            //Literal1
        }
        else
        {
            lt.Text = string.Empty;
        }
    }
    protected void ddlDemandType_SelectedIndexChanged(object sender, EventArgs e)
    {
        disableControl();
        PrinterAllFill();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlPrinter.SelectedIndex > 0)
            {
                A.Style.Add("Display", "block");
                PP.Style.Add("Display", "block");
                PP1.Style.Add("Display", "block");
                if (ddlOrderNo.SelectedItem.Text.ToLower() == "select")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select challan detail.');</script>");
                }
                //string a = ddlOrderNo.SelectedItem.Text  ;                                                                                                                                                                                                                                                                                                               em.Text;
                ds = obCommonFuction.FillDatasetByProc("Call USP_PPR0014_ReportPaperDispatchToPrinterByParam('" + DdlACYear.SelectedItem.Text + "','" + ddlDemandType.SelectedItem.Text + "','" + Int32.Parse(ddlPrinter.SelectedValue) + "','" + ddlOrderNo.SelectedItem.Text + "',0)");
                address = ds.Tables[0].Rows[0]["FullAddress_V"].ToString();
                GRNo = ds.Tables[0].Rows[0]["GRNo"].ToString();
                recievdDt = ds.Tables[0].Rows[0]["ChallanDate"].ToString();
                suppliername = ds.Tables[0].Rows[0]["SupplierName"].ToString();
                pageno = ds.Tables[0].Rows[0]["PageNo"].ToString();
                //Label3.Text = ds.Tables[0].Rows[0]["GRNo"].ToString();
                GrdLOI.DataSource = ds.Tables[0];
                GrdLOI.DataBind();
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    enableControl();
                    hfRowCnt.Value = ds.Tables[0].Rows.Count.ToString();
                }
                else
                    hfRowCnt.Value = "0";

                if (ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                {
                    for (int i = 0; i <= ds.Tables[1].Rows.Count - 1; i++)
                    {
                        titlehindi_v += ds.Tables[1].Rows[i][0].ToString() + ",";
                    }
                       
                    if(titlehindi_v != "")
                    {
                        titlehindi_v = titlehindi_v.TrimEnd(',');
                    }
                }

                recievername = ds.Tables[0].Rows[0]["RecieverName"].ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select printer name.');</script>");
                GrdLOI.DataSource = null;
                GrdLOI.DataBind();
                ddlOrderNo.DataSource = string.Empty;
                ddlOrderNo.DataBind();
                ddlOrderNo.Items.Insert(0, "Select");
            }
        }
        catch { }
    }
    public void enableControl()
    {
        tdPrint.Visible = true; tdExportBtn.Visible = true;
        tdMpHeading.Visible = true;
      //  tdDepo.Visible = true;
        tdInfo.Visible = true;
        tdYear.Visible = true;
        tdDate.Visible = true;
        tdTitle.Visible = true;
        tdPradaykrta.Visible = true;
        //tdUnit.Visible = true;
        lblYear.Text = DdlACYear.SelectedItem.Text;
        //lblTitle.Text = "प्रिंटर का नाम  : " + ddlPrinter.SelectedItem.Text.Replace("All", "सभी") + ", " + " चालान क्रमांक : " + ddlOrderNo.SelectedItem.Text.Replace("All", "सभी");
        lblDate.Text = "दिनांक :" + System.DateTime.Now.ToString("dd MMM yyyy");
    }
    public void disableControl()
    {
        tdPrint.Visible = false;
        tdExportBtn.Visible = false;
        tdMpHeading.Visible = false;
       // tdDepo.Visible = false;
        tdInfo.Visible = false;
        tdYear.Visible = false;
        tdDate.Visible = false;
        tdTitle.Visible = false;
        //tdUnit.Visible = false;
        GrdLOI.DataSource = null;
        GrdLOI.DataBind();
        ddlOrderNo.DataSource = string.Empty;
        ddlOrderNo.DataBind();
        ddlOrderNo.Items.Insert(0, "Select");

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
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "AvantanDetails.xls"));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - xls";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        ExportDiv.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    //+ DdlACYear.SelectedItem.Text + "','" + ddlDemandType.SelectedItem.Text + "','" + Int32.Parse(ddlPrinter.SelectedValue) + "','" + ddlOrderNo.SelectedItem.Text + "')");
    //    Session["AcdYear"] = DdlACYear.SelectedItem.Text;
    //    Session["ddlDemandType"] = ddlDemandType.SelectedItem.Text;
    //    Session["ddlPrinterName"] = ddlPrinter.SelectedItem.Text;
    //    Session["ddlPrinterID"] = Int32.Parse(ddlPrinter.SelectedValue);
    //    Session["ddlChallanNo"] = ddlOrderNo.SelectedItem.Text;
    //    Response.Redirect("~/CenterDepot/CenteralReport/ReportProcReelStockEntry.aspx");
    //}
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        disableControl();

        if (DdlACYear.SelectedItem.Text != "Select")
        {
            PrinterAllFill();
        }

    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try {
                Label lblTotal = (Label)e.Row.FindControl("Label1");
                Label lblTotal1 = (Label)e.Row.FindControl("Label2");
                Label lblTotal2 = (Label)e.Row.FindControl("Label3");

                vales += lblTotal.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblTotal.Text);
               
           // vales += Convert.ToDouble(e.Row.Cells[4].Text);
                TotNetBundlNo = TotNetBundlNo + Convert.ToInt32(lblTotal1.Text !=""?lblTotal1.Text:"0");
            }               
            catch { }
            Label3.Text = TotNetBundlNo.ToString();

            try
            {
                HiddenField hdnPaperVendorTrId = (HiddenField)e.Row.FindControl("hdnPaperVendorTrId");
                HiddenField hdnPaperType_I = (HiddenField)e.Row.FindControl("hdnPaperType_I");
                Label lblTotal2 = (Label)e.Row.FindControl("Label1");
                Label lblAmt = (Label)e.Row.FindControl("lblAmt");
                 DataTable dtt = obCommonFuction.FillTableByProc("Call USP_PPR0018_RptGetRatePrinterDispatch('" + DdlACYear.SelectedItem.Text + "','" + hdnPaperType_I.Value + "','" + Int32.Parse(hdnPaperVendorTrId.Value) + "')");
                if (dtt.Rows.Count > 0)
                {
                    decimal bidrate_n = decimal.Parse(dtt.Rows[0][0].ToString());
                    if (bidrate_n > 0)
                    {
                        lblAmt.Text = (bidrate_n * Convert.ToDecimal(lblTotal2.Text)).ToString("0.00");
                    }

                    //netamt += lblAmt.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblAmt.Text);
                }
            }
            catch { }

            //merge cells
            try
            {
                if (e.Row.RowIndex > 0)
                {
                    GridViewRow previousRow = GridView1.Rows[e.Row.RowIndex - 1];

                    //find hiddenfield of both current and previous rows
                    //HiddenField hdnLeader = (HiddenField)e.Row.FindControl("hdnLeader");
                    //HiddenField hdnLeader_prev = (HiddenField)previousRow.FindControl("hdnLeader");

                    if (((HiddenField)e.Row.Cells[4].FindControl("hdnLeader")).Value == ((HiddenField)previousRow.Cells[4].FindControl("hdnLeader")).Value)
                    {
                        if (previousRow.Cells[4].RowSpan == 0)
                        {
                            previousRow.Cells[4].RowSpan += 2;
                            e.Row.Cells[4].Visible = false;
                        }
                    }
                }
            }
            catch { }
        }
    }

    
}