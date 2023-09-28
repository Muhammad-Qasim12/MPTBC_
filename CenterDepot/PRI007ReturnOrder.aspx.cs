using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Paper;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using System.IO;
using System.Web.UI.HtmlControls;


public partial class Printing_PRI007ReturnOrder : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    double TotGrossWt = 0, TotNetWt = 0;
    string Depot_Id = ""; double TotalSheets;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            btnSave.Visible = false;
            obCommonFuction = new CommonFuction();
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYear_Active(0)");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = ds1.Tables[0].Rows[0][0].ToString();
            loadPrinters();
            FillData();           
            //DdlACYear_SelectedIndexChanged( sender,  e);
        }
    }

    public void FillData()
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
            obCommonFuction = new CommonFuction();
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_PRI007_PrinterReturnOrderLoad_new('" + PrinterID + "','" + txtSearch.Text + "','" + DdlACYear.SelectedItem.Text + "')");
            GrdPaperAllotment.DataSource = ds1;
            GrdPaperAllotment.DataBind();

            GrdPaperAllotmentPart.DataSource = ds1.Tables[1];
            GrdPaperAllotmentPart.DataBind();
          
        }
        catch
        {
        }
        finally { }
    }



    protected void btnSave_Click(object sender, EventArgs e)
    {
        string CheckSts, PaperGSM = ""; string PrinterDistTranID = ""; string PaperMstrTrId_I = ""; decimal dTotalNetWt = 0; string sTotReel = "";
            
           
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            try
            {
                //objPaperDispatchDetails.PrinterID_I = int.Parse(Session["PrierID_I"].ToString());
                Depot_Id = Session["UserID"] != null && Session["UserID"].ToString() != "" ? Session["UserID"].ToString() : "0";
                GridViewRow row = GridView2.FooterRow;
                dTotalNetWt = Convert.ToDecimal(((Label)row.FindControl("lblTotNetWt")).Text);
                sTotReel = txtNoOfReels.Text;
            }
            catch { objPaperDispatchDetails.PrinterID_I = 0; }
             
                    try
                    {
                        CheckSts = "Ok";
                           
                            if (CheckSts == "Ok")
                            {
                                //obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate('',0,0,'',0,0,''," + Depot_Id + ",0,''," + objPaperDispatchDetails.PrinterDisTranId + ",'',0,3,0)");
                                foreach (GridViewRow gv in GridView2.Rows)
                                {
                                    double lblNetWt_d = 0; double lblGrossWt_d = 0;
                                    Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
                                    Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                    Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                    Label lblRollNo = (Label)gv.FindControl("lblRollNo");
                                    Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                                    Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                                    Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                                    HiddenField hdnPrinterDisTranID = (HiddenField)gv.FindControl("hdnPrinterDisTranID");
                                    PrinterDistTranID = hdnPrinterDisTranID.Value;
                                    PaperMstrTrId_I = lblPaperMstrTrId_I.Text;
                                   
                                    
                                    if (lblTotalSheets.Text == "" || lblTotalSheets.Text == "0")
                                    {
                                        lblTotalSheets.Text = "1";
                                    }
                                    string prin = "0";
                                    string txtChallanNo = lblChallanno.Text;
                                    string LastId = "0";
                                    string ddlDemandType = Convert.ToString(DBNull.Value);
                                    
                                    try
                                    {
                                       
                                            prin = "0";

                                            //send to CPD
                                            if (double.Parse(lblNetWt.Text) < 1)
                                            {
                                                lblNetWt_d = double.Parse(lblNetWt.Text) * 1000;
                                            }
                                            if (double.Parse(lblGrossWt.Text) < 1)
                                            {
                                                lblGrossWt_d = double.Parse(lblGrossWt.Text) * 1000;
                                            }
                                       
                                    }
                                    catch { }

                                    obCommonFuction = new CommonFuction();
                                    obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt_d + "," + lblGrossWt_d + ",'" + txtChallanNo + "','" + Depot_Id + "'," + lblPaperVendorTrId_I.Text + ",'" + obCommonFuction.GetFinYear() + "'," + LastId + ",NULL," + prin + ",0," + lblTotalSheets.Text + ")");
                               }

                                string PrinterDisDtl_Id = obCommonFuction.FillScalarByProc("SELECT PrinterDisDtl_Id FROM ppr_paperprinterreturn_m p INNER JOIN ppr_paperprinterreturndetails pcd ON p.PrinterDisTranID=pcd.PrinterDisTranID WHERE p.PrinterDisTranID='"+PrinterDistTranID+"' AND PaperMstrTrId_I='"+PaperMstrTrId_I+"'");
                                if (PrinterDisDtl_Id != null && PrinterDisDtl_Id.ToString() != "")
                                {
                                    obCommonFuction.FillDatasetByProc("update ppr_paperprinterreturndetails set SendQty='"+dTotalNetWt+"', NetWt='"+dTotalNetWt+"', NoOfReels='"+sTotReel+"' WHERE PrinterDisDtl_Id='" + PrinterDisDtl_Id + "'; UPDATE ppr_paperprinterreturn_m SET UpdateStatus=2 WHERE PrinterDisTranID='"+PrinterDistTranID+"';");
                                }
                            }
                            if (CheckSts == "Ok")
                            {
                                FillData();
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");                               
                               
                            }
                        
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan No Already Exist.');</script>");
                        // string exp = ex.Message;
                    }
                
              
            
        
    }

   
    protected void GrdPaperAllotment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperAllotment.PageIndex = e.NewPageIndex;
        FillData();
        //FillData();
    }



    protected void btnAddChallanDetailse_Click(object sender, EventArgs e)
    {
        try
        {
            HtmlAnchor btnView = (HtmlAnchor)sender;
            GridViewRow gv = (GridViewRow)btnView.NamingContainer;
            HiddenField hdnChallanno = (HiddenField)gv.FindControl("hdnChallanno");
            HiddenField hdnAcyear = (HiddenField)gv.FindControl("hdnAcyear");
            HiddenField hdnPrinterDisTranId = (HiddenField)gv.FindControl("hdnPrinterDisTranId");
            HiddenField hdnUpdateStatus = (HiddenField)gv.FindControl("hdnUpdateStatus");
            obCommonFuction = new CommonFuction();
            DataSet dtt = new DataSet();
            if (hdnUpdateStatus.Value == "1")
            {
                dtt = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry_ptret('"+hdnPrinterDisTranId.Value+"','" + hdnChallanno.Value + "',0,7)");
               
            }
            else
                dtt = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(0,'" + hdnChallanno.Value + "','"+hdnPrinterDisTranId.Value+"',11)");

            if (dtt.Tables.Count>1)
            {
                lblPrintNoOfReels.Text = dtt.Tables[1].Rows[0]["NoofReels"].ToString();
                lblPrintRetQty.Text = dtt.Tables[1].Rows[0]["SendQty"].ToString();
                lblPrintRetToPri.Text = dtt.Tables[1].Rows[0]["ReturnToPrinter"].ToString();
                lblPrintPri.Text = dtt.Tables[1].Rows[0]["NameofPress_V"].ToString();
                Label1.Text = dtt.Tables[1].Rows[0]["ChallanNo"].ToString();
                Label2.Text = dtt.Tables[1].Rows[0]["ChallanDate"].ToString();
            }
            
            GrdChallanReel.DataSource = dtt.Tables[0];
            GrdChallanReel.DataBind();
            btnRoleAdd.Visible = false;
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
        }
        catch
        {
            GrdChallanReel.DataSource = null;
            GrdChallanReel.DataBind();
        }
    }

    protected void GrdChallanReel_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
          
            try
            {
                TotNetWt = TotNetWt + double.Parse(lblNetWt.Text);
            }
            catch { TotNetWt = 0; }
            try
            {
                TotalSheets = TotalSheets + double.Parse(lblTotalSheets.Text);
            }
            catch { TotalSheets = 0; }
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text);
            }
            catch { TotGrossWt = 0; }

           
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");
            Label lblTotGrossWt = (Label)e.Row.FindControl("lblTotGrossWt");
            Label lblTS = (Label)e.Row.FindControl("lblTS");
            lblTotNetWt.Text = TotNetWt.ToString("0.000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
            lblTS.Text = TotalSheets.ToString("0");
        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            try
            {
                TotNetWt = TotNetWt + double.Parse(lblNetWt.Text);
            }
            catch { TotNetWt = 0; }
            try
            {
                TotalSheets = TotalSheets + double.Parse(lblTotalSheets.Text);
            }
            catch { TotalSheets = 0; }
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text);
            }
            catch { TotGrossWt = 0; }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");
            Label lblTotGrossWt = (Label)e.Row.FindControl("lblTotGrossWt");
            Label lblTS = (Label)e.Row.FindControl("lblTS");
            lblTotNetWt.Text = TotNetWt.ToString("0.000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
            lblTS.Text = TotalSheets.ToString("0");
        }
    }

    protected void btnRoleAdd_Click(object sender, EventArgs e)
    {
        string TotalSheetsFlag = "", Msg = ""; string lblPaperMIllName = "";
        if (ViewState["TempData"] != null)
            ViewState["TempData"] = null;

        GridView2.DataSource = null;
        GridView2.DataBind();
        decimal TotReel = 0;

        foreach (GridViewRow gv in GridView1.Rows)
        {
            CheckBox ChkSelectedRoll = (CheckBox)gv.FindControl("chkitem");
            if (ChkSelectedRoll.Checked == true)
            {
                Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
                Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                Label lblRollNo = (Label)gv.FindControl("lblRollNo");
                Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                Label lblActTotalSheets = (Label)gv.FindControl("lblActTotalSheets");

                Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
                Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                HiddenField hdnRollStockID_I = (HiddenField)gv.FindControl("hdnRollStockID_I");
                HiddenField hdnPrinterDisTranID = (HiddenField)gv.FindControl("hdnPrinterDisTranID");
                
                TextBox txtNetWt = (TextBox)gv.FindControl("txtNetWt");
                TextBox txtGrossWt = (TextBox)gv.FindControl("txtGrossWt");

                lblNetWt.Text = txtNetWt.Text;
                lblGrossWt.Text = txtGrossWt.Text;

                if (txtTotalSheets.Text == "")
                {
                    txtTotalSheets.Text = "0";
                }

                if (lblTotalSheets.Text == "")
                {
                    lblTotalSheets.Text = "0";
                }
                if (lblCheckFlag.Text == "Sheet" || lblPaperMstrTrId_I.Text == "28")
                {
                    TotReel = TotReel + (decimal.Parse(lblTotalSheets.Text));
                }
                else
                {
                    TotReel = TotReel + 1;
                }

                if (lblCheckFlag.Text == "Sheet" && lblPaperMstrTrId_I.Text != "28")
                {
                    decimal TotWetOfSheet = 0;
                    foreach (GridViewRow gvd in GridView2.Rows)
                    {
                        Label lblPaperMstrTrId_ITot = (Label)gvd.FindControl("lblPaperMstrTrId_I");
                        Label lblTotalSheetsCall = (Label)gvd.FindControl("lblTotalSheets");
                        if (lblPaperMstrTrId_ITot.Text == lblPaperMstrTrId_I.Text)
                        {
                            try
                            {
                                TotWetOfSheet = TotWetOfSheet + decimal.Parse(lblTotalSheetsCall.Text);
                            }
                            catch { }
                        }
                    }


                    //if (decimal.Parse(lblOrderTotSheet.Text) < (TotWetOfSheet + decimal.Parse(txtTotalSheets.Text)))
                    //{
                    //    TotalSheetsFlag = "NotOk";
                    //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Total Sheets Exceed From Demand Sheets.');OpenBill();</script>");
                    //}
                    try
                    {
                        lblNetWt.Text = (((double.Parse(lblNetWt.Text) / double.Parse(lblActTotalSheets.Text)) * (double.Parse(txtTotalSheets.Text))) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
                        lblGrossWt.Text = (double.Parse(lblNetWt.Text) + 0.005).ToString("0.000");
                    }
                    catch { }


                    //if (TotalSheetsFlag == "" && ChkSelectedRoll.Checked == true)
                    //{
                    //    DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, lblPaperMIllName.Text, txtTotalSheets.Text);

                    //}
                    //if (TotalSheetsFlag == "" && ChkSelectedRoll.Checked == false)
                    //{
                    //    DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, lblPaperMIllName.Text, txtTotalSheets.Text);

                    //}

                    DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, lblPaperMIllName, txtTotalSheets.Text,hdnPrinterDisTranID.Value);
                }
                else
                {
                    decimal TotWetOfReel = 0;
                    foreach (GridViewRow gvd in GridView2.Rows)
                    {
                        Label lblPaperMstrTrId_ITot = (Label)gvd.FindControl("lblPaperMstrTrId_I");
                        Label lblTotNetWt = (Label)gvd.FindControl("lblNetWt");
                        if (lblPaperMstrTrId_ITot.Text == lblPaperMstrTrId_I.Text)
                        {
                            try
                            {
                                TotWetOfReel = TotWetOfReel + decimal.Parse(lblTotNetWt.Text);
                            }
                            catch { }
                        }
                    }

                    if (decimal.Parse(lblPaperDemand.Text) < (TotWetOfReel + (decimal.Parse(lblNetWt.Text) / 1000)))
                    {
                        TotalSheetsFlag = "NotOk";
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Reel Weight Exceed From Demand Weight.');OpenBill();</script>");
                    }
                    else
                    {
                        if (TotalSheetsFlag == "")
                        {
                            try
                            {
                                lblNetWt.Text = ((double.Parse(lblNetWt.Text)) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
                                lblGrossWt.Text = (double.Parse(lblNetWt.Text) + 0.005).ToString("0.000");
                            }
                            catch { }
                            DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, lblPaperMIllName, txtTotalSheets.Text,hdnPrinterDisTranID.Value);
                            if (lblPaperMstrTrId_I.Text != "28")
                                txtTotalSheets.Text = "0";
                        }
                    }
                }
            }
        }

        if(ViewState["TempData"] != null && ViewState["TempData"] !="")
        {
            DataTable dtt = (DataTable)ViewState["TempData"];
            GridView2.DataSource = dtt;
            GridView2.DataBind();
        }

        if (GridView2.Rows.Count > 0)
            btnSave.Visible = true;
        else
            btnSave.Visible = false;

        txtNoOfReels.Text = TotReel.ToString();
      
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill11();</script>");
    }

    public void DataBindToGrid(string PaperType_I, string PaperMstrTrId_I, string CoverInformation,
        string RollNo, string NetWet, string GrossWt, string PaperVendorTrId_I, string PaperVendorName_V, string TotalSheets, string PrinterDisTranID)
    {
        string Check = "", ChkAmt = "";
        double TotGsWt = 0, TotDemnd = 0;
        if (ViewState["TempData"] == null || ViewState["TempData"] == "")
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("PaperType_I", typeof(string));
            dt.Columns.Add("PaperMstrTrId_I", typeof(string));
            dt.Columns.Add("CoverInformation", typeof(string));
            dt.Columns.Add("RollNo", typeof(string));
            dt.Columns.Add("NetWt", typeof(string));
            dt.Columns.Add("GrossWt", typeof(string));
            dt.Columns.Add("PaperVendorTrId_I", typeof(string));
            dt.Columns.Add("PaperVendorName_V", typeof(string));
            dt.Columns.Add("TotalSheets", typeof(string));
            //dt.Columns.Add("RollStockID_I", typeof(string));
            dt.Columns.Add("PrinterDisTranID", typeof(string));


            DataRow Dr = dt.NewRow();
            Dr["PaperType_I"] = PaperType_I;
            Dr["PaperMstrTrId_I"] = PaperMstrTrId_I;
            Dr["CoverInformation"] = CoverInformation;
            Dr["RollNo"] = RollNo;
            Dr["NetWt"] = NetWet;
            Dr["GrossWt"] = GrossWt;
            Dr["PaperVendorTrId_I"] = PaperVendorTrId_I;
            Dr["PaperVendorName_V"] = PaperVendorName_V;
            Dr["TotalSheets"] = TotalSheets;
            // Dr["RollStockID_I"] = RollId;
            Dr["PrinterDisTranID"] = PrinterDisTranID;
            try
            {
                TotDemnd = double.Parse(lblTotWtQty.Text);
            }
            catch { TotDemnd = 0; }
            try
            {
                TotGsWt = double.Parse(GrossWt);
            }
            catch { TotGsWt = 0; }

            //if (TotGsWt > TotDemnd)
            //{
            //    ChkAmt = "Yes";
            //}
            if (ChkAmt == "Yes" && Request.QueryString["ID"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Total Gross Weight Exceed From Demand Weight.');OpenBill();</script>");
            }
            else
            {
                dt.Rows.Add(Dr);
            }
            ViewState["TempData"] = dt;
            //GridView2.DataSource = dt;
            //GridView2.DataBind();
        }
        else
        {
            DataTable dt = (DataTable)ViewState["TempData"];
            DataRow Dr = null;
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    Dr = dt.NewRow();
                    Dr["PaperType_I"] = PaperType_I;
                    Dr["PaperMstrTrId_I"] = PaperMstrTrId_I;
                    Dr["CoverInformation"] = CoverInformation;
                    Dr["RollNo"] = RollNo;
                    Dr["NetWt"] = NetWet;
                    Dr["GrossWt"] = GrossWt;
                    Dr["PaperVendorTrId_I"] = PaperVendorTrId_I;
                    Dr["PaperVendorName_V"] = PaperVendorName_V;
                    Dr["TotalSheets"] = TotalSheets;
                    //Dr["RollStockID_I"] = RollId;
                    Dr["PrinterDisTranID"] = PrinterDisTranID;
                }
                if (dt.Rows[0].ToString() == "")
                {
                    dt.Rows[0].Delete();
                    dt.AcceptChanges();
                }

                foreach (DataRow drd in dt.Rows)
                {
                    if (drd["RollNo"].ToString() == RollNo)
                    {
                        Check = "Yes";
                    }
                }
                foreach (DataRow drd in dt.Rows)
                {
                    if (drd["PaperMstrTrId_I"].ToString() == PaperMstrTrId_I)
                    {
                        TotGsWt = TotGsWt + double.Parse(drd["GrossWt"].ToString());
                    }
                }
                try
                {
                    TotDemnd = double.Parse(lblTotWtQty.Text);
                }
                catch { TotDemnd = 0; }


                try
                {
                    TotGsWt = TotGsWt + double.Parse(GrossWt);
                }
                catch { }
                //if (TotGsWt > TotDemnd)
                //{
                //    ChkAmt = "Yes";
                //}
                if (ChkAmt == "Yes" && Request.QueryString["ID"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Total Gross Weight Exceed From Demand Weight.');OpenBill();</script>");
                }
                else if (Check == "Yes")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Roll No Already Exist.');OpenBill();</script>");
                }
                else
                {
                    dt.Rows.Add(Dr);
                }

                ViewState["TempData"] = dt;
            }

            //GridView2.DataSource = dt;
           // GridView2.DataBind();
        }
    }

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");

            TextBox txtNetWt = (TextBox)e.Row.FindControl("txtNetWt");
            TextBox txtGrossWt = (TextBox)e.Row.FindControl("txtGrossWt");

            txtNetWt.Attributes.Add("onchange", "GrossWt('"+txtNetWt.ClientID+"','"+txtGrossWt.ClientID+"')");

            try
            {
                TotNetWt = TotNetWt + double.Parse(txtNetWt.Text);
            }
            catch { TotNetWt = 0; }
            try
            {
                TotalSheets = TotalSheets + double.Parse(lblTotalSheets.Text);
            }
            catch { TotalSheets = 0; }
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(txtGrossWt.Text);
            }
            catch { TotGrossWt = 0; }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");
            Label lblTotGrossWt = (Label)e.Row.FindControl("lblTotGrossWt");
            Label lblTS = (Label)e.Row.FindControl("lblTS");
            lblTotNetWt.Text = TotNetWt.ToString("0.000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
            lblTS.Text = TotalSheets.ToString("0");
        }
    }

    protected void lnkChangeSts_Click(object sender, EventArgs e)
    {
        //fadeDiv11.Style.Add("display", "block");
       // BillDiv11.Style.Add("display", "none");

        
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
       
        HiddenField hdnChallanno = (HiddenField)gv.FindControl("hdnChallanno");
        HiddenField hdnAcyear = (HiddenField)gv.FindControl("hdnAcyear");
        HiddenField hdnPrinterDisTranId = (HiddenField)gv.FindControl("hdnPrinterDisTranId");
        HiddenField hdnUpdateStatus = (HiddenField)gv.FindControl("hdnUpdateStatus");

        HiddenField hdnPaperCategory = (HiddenField)gv.FindControl("hdnPaperCategory");
        HiddenField hdnReturnQty = (HiddenField)gv.FindControl("hdnReturnQty");

        lblPaperDemand.Text = hdnReturnQty.Value;
        lblCheckFlag.Text = hdnPaperCategory.Value;
        lblOrderTotSheet.Text = hdnReturnQty.Value;
        lblTotWtQty.Text = hdnReturnQty.Value;
        lblChallanno.Text = hdnChallanno.Value;
        
        obCommonFuction = new CommonFuction();
        DataTable dtt = new DataTable();        
        dtt = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry_ptret('" + hdnPrinterDisTranId.Value + "','" + hdnChallanno.Value + "',0,7)").Tables[0];

        if (dtt.Rows.Count > 0)
        {
            //lblCoverInformation.Text = dtt.Rows[0]["CoverInformation"].ToString();
            lblCoverInformation.Text = dtt.Rows[0]["CoverInformation"].ToString();
        }
        else
            lblCoverInformation.Text = "";

        GridView1.DataSource = dtt;
        GridView1.DataBind();
        if (GridView1.Rows.Count > 0)
            btnRoleAdd.Visible = true;
        else
            btnRoleAdd.Visible = false;

        if (lblCheckFlag.Text == "Sheet")
        {
            //tdsheet1.Visible = true;
            tdsheet2.Visible = true;
            RqtxtTotalSheets.Visible = true;
        }
        else
        {
            RqtxtTotalSheets.Visible = false;
           // tdsheet1.Visible = false;
            tdsheet2.Visible = false;
        }

       ClientScript.RegisterStartupScript(this.GetType(), "msg22", "<script>OpenBill11();</script>");

        
       
    }
  
    protected void btnAdd_Click(object sender, EventArgs e)
    {
               
        FillData();
    }

    public void loadPrinters()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {

            obPRI_PrinterRegistration.Printer_RedID_I = 0;

            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();

            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";

            ddlPrinter.DataSource = ds;

            ddlPrinter.DataBind();

            ddlPrinter.Items.Insert(0, new ListItem("All", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            FillData();
        }
        catch { }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            //obCommonFuction = new CommonFuction();
            //GridView1.Visible = true;
            //GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadSearchNew(0,'" + DdlACYear.SelectedItem.Text + "')");
            //GridView1.DataBind();
            //ExportToExcell();
            //GridView1.Visible = false;

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
    
    protected void GrdPaperAllotmentPart_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    protected void lnkChangeStsPart_Click(object sender, EventArgs e)
    {
        //fadeDiv11.Style.Add("display", "block");
        // BillDiv11.Style.Add("display", "none");


        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;

        HiddenField hdnChallanno = (HiddenField)gv.FindControl("hdnChallanno");
        HiddenField hdnAcyear = (HiddenField)gv.FindControl("hdnAcyear");
        HiddenField hdnPrinterDisTranId = (HiddenField)gv.FindControl("hdnPrinterDisTranId");
        HiddenField hdnUpdateStatus = (HiddenField)gv.FindControl("hdnUpdateStatus");

        HiddenField hdnPaperCategory = (HiddenField)gv.FindControl("hdnPaperCategory");
        HiddenField hdnReturnQty = (HiddenField)gv.FindControl("hdnReturnQty");

        lblPaperDemand.Text = hdnReturnQty.Value;
        lblCheckFlag.Text = hdnPaperCategory.Value;
        lblOrderTotSheet.Text = hdnReturnQty.Value;
        lblTotWtQty.Text = hdnReturnQty.Value;
        lblChallanno.Text = hdnChallanno.Value;

        obCommonFuction = new CommonFuction();
        DataTable dtt = new DataTable();
        dtt = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry_ptret_part('" + hdnPrinterDisTranId.Value + "','" + hdnChallanno.Value + "',0,7)").Tables[0];

        if (dtt.Rows.Count > 0)
        {
            //lblCoverInformation.Text = dtt.Rows[0]["CoverInformation"].ToString();
            lblCoverInformation.Text = dtt.Rows[0]["CoverInformation"].ToString();
        }
        else
            lblCoverInformation.Text = "";

        GridView3.DataSource = dtt;
        GridView3.DataBind();
        if (GridView3.Rows.Count > 0)
            btnRoleAdd.Visible = true;
        else
            btnRoleAdd.Visible = false;

        if (lblCheckFlag.Text == "Sheet")
        {
            //tdsheet1.Visible = true;
            tdsheet2.Visible = true;
            RqtxtTotalSheets.Visible = true;
        }
        else
        {
            RqtxtTotalSheets.Visible = false;
            // tdsheet1.Visible = false;
            tdsheet2.Visible = false;
        }

        ClientScript.RegisterStartupScript(this.GetType(), "msg22", "<script>OpenBill11();</script>");
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");

            TextBox txtNetWtPart = (TextBox)e.Row.FindControl("txtNetWtPart");
            TextBox txtGrossWtPart = (TextBox)e.Row.FindControl("txtGrossWtPart");

            txtNetWtPart.Attributes.Add("onchange", "GrossWt('" + txtNetWtPart.ClientID + "','" + txtGrossWtPart.ClientID + "')");

            try
            {
                TotNetWt = TotNetWt + double.Parse(txtNetWtPart.Text);
            }
            catch { TotNetWt = 0; }
            try
            {
                TotalSheets = TotalSheets + double.Parse(lblTotalSheets.Text);
            }
            catch { TotalSheets = 0; }
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(txtGrossWtPart.Text);
            }
            catch { TotGrossWt = 0; }


        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWtPart = (Label)e.Row.FindControl("lblTotNetWtPart");
            Label lblTotGrossWtPart = (Label)e.Row.FindControl("lblTotGrossWtPart");
            Label lblTSPart = (Label)e.Row.FindControl("lblTSPart");
            lblTotNetWtPart.Text = TotNetWt.ToString("0.000");
            lblTotGrossWtPart.Text = TotGrossWt.ToString("0.000");
            lblTSPart.Text = TotalSheets.ToString("0");
        }
    }
}