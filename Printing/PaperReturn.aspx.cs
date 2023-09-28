using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;
using MPTBCBussinessLayer;

public partial class Printing_PaperReturn : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string Depot_Id = "";
    PPR_TenderEvaluation objTenderEvaluation = null;
    APIProcedure objdb = new APIProcedure();
    double TotGrossWt = 0, TotNetWt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Depot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            Session["d"] = null;
            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet ds1 = new DataSet();
            ds1 = PriReg.GetPrinterDetails();
            if (ds1.Tables[0].Rows.Count > 0)
            {

                Session["PrierID_I"] = Convert.ToString(ds1.Tables[0].Rows[0]["Printer_RedID_I"]);
                hdnSessionPrinterId.Value = Session["PrierID_I"] != null ? Session["PrierID_I"].ToString() : "0";
            }

            OrderNoAllFill();
            ViewState["TempData"] = "";
            if (Request.QueryString["ID"] != null)
            {
                LabInvDtlFill();
                SupplyDateFill();
            }
            else
            {
                OrderNoAllFill();
                PrinterAllFill();

            }

        }
    }
    public void SupplyDateFill()
    {
        if (ddlPrinter.SelectedItem.Text != "Select" && ddlOrderNo.SelectedItem.Text != "Select")
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PrinterID_I = int.Parse(ddlPrinter.SelectedItem.Value);
            objPaperDispatchDetails.OrderNo = ddlOrderNo.SelectedItem.Text;

            if (ddlDemandType.Text == "पाठ्यपुस्तक")
            {
                CommonFuction comm = new CommonFuction();
                ds = comm.FillDatasetByProc("call USP_PPR0014_PaperDispatchToPrinterShowData(" + ddlPrinter.SelectedValue + ",0,'" + ddlOrderNo.SelectedItem.Text + "',0,0,2)");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtOrderDate.Text = ds.Tables[0].Rows[0]["Supplydate_D"].ToString();
                }
                else
                {
                    txtOrderDate.Text = "";
                }
            }
            else if (ddlDemandType.Text == "अन्य पाठ्य सामग्री")
            {
                ds = objPaperDispatchDetails.AcdminPrinterOrderFill();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtOrderDate.Text = ds.Tables[0].Rows[0]["Supplydate_D"].ToString();
                }
                else
                {
                    txtOrderDate.Text = "";
                }
            }

        }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            //  ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    public void LabInvDtlFill()
    {
        try
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PrinterDisTranId = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
            ds = objPaperDispatchDetails.PrinterDisptchDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlDemandType.ClearSelection();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
                try
                {
                    ddlDemandType.Items.FindByText(ds.Tables[0].Rows[0]["DemandFrom"].ToString()).Selected = true;
                    ddlDemandType.Enabled = false;
                }
                catch { }

                PrinterAllFill();
                ddlPrinter.ClearSelection();
                try
                {
                    ddlPrinter.Items.FindByValue(ds.Tables[0].Rows[0]["PrinterID_I"].ToString()).Selected = true;
                }
                catch { }
                ddlPrinter.Enabled = false;
                OrderNoAllFill();
                ddlOrderNo.ClearSelection();
                try
                {
                    ddlOrderNo.Items.FindByValue(ds.Tables[0].Rows[0]["OrderNo"].ToString()).Selected = true;
                }
                catch { }
                ddlOrderNo.Enabled = false;

                txtChallanDate.Text = ds.Tables[0].Rows[0]["ChallanDate"].ToString();

                //  dte = DateTime.Parse(ds.Tables[0].Rows[0]["ReceivedDate"].ToString());
                // txtRecivedDate.Text = dte.ToString("dd/MM/yyyy");
                txtChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo"].ToString();
                //LoiAddressFill();
                txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtDriverName.Text = ds.Tables[0].Rows[0]["DriverName"].ToString();
                txtTruckNo.Text = ds.Tables[0].Rows[0]["TruckNo"].ToString();
                txtChallanNo.Enabled = false;
                txtGrNo.Text = ds.Tables[0].Rows[0]["GRNo"].ToString();
                txtGrDate.Text = ds.Tables[0].Rows[0]["GRDate"].ToString();

                // WareHouseId();
                // ddlWareHouse.ClearSelection();
                try
                {

                    //   ddlWareHouse.Items.FindByValue(ds.Tables[0].Rows[0]["WareHouseID_I"].ToString()).Selected = true;
                }
                catch { }
                txtBlockNo.Text = ds.Tables[0].Rows[0]["BlockNo"].ToString();
                //txtDefReel.Text = ds.Tables[0].Rows[0]["DefReel"].ToString();
                //txtDefWt.Text = ds.Tables[0].Rows[0]["DefW t"].ToString();

                try
                {
                    // lblTitleRemark.Text = "";
                    //ddlSupplier.Items.FindByValue(ds.Tables[0].Rows[0]["SupplierID"].ToString()).Selected = true;
                }
                catch { }
                if (ddlDemandType.Text == "पाठ्यपुस्तक")
                {
                    GrdWorkPlan.DataSource = ds.Tables[1];
                    GrdWorkPlan.DataBind();
                }
                else
                {
                    GrdWorkPlan.DataSource = ds.Tables[2];
                    GrdWorkPlan.DataBind();
                }

                ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(" + objdb.Decrypt(Request.QueryString["ID"].ToString()) + ",'" + txtChallanNo.Text + "','',4)");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        DataBindToGrid(dr["PaperType_I"].ToString(), dr["PaperMstrTrId_I"].ToString(), dr["CoverInformation"].ToString(),
                            dr["RollNo"].ToString(), dr["NetWt"].ToString(), dr["GrossWt"].ToString(), dr["PaperVendorTrId_I"].ToString(),
                            dr["PaperVendorName_V"].ToString(), dr["TotalSheets"].ToString(), dr["RollStockID_I"].ToString());
                    }
                }
            }
        }
        catch { }
    }

    public void DataBindToGrid(string PaperType_I, string PaperMstrTrId_I, string CoverInformation,
    string RollNo, string NetWet, string GrossWt, string PaperVendorTrId_I, string PaperVendorName_V, string TotalSheets, string id)
    {
        string Check = "", ChkAmt = "";
        double TotGsWt = 0, TotDemnd = 0, TotNetWet = 0;
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
            dt.Columns.Add("id", typeof(string));


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
            Dr["id"] = id;
            try
            {
                TotDemnd = double.Parse(lblTotWtQty.Text);
            }
            catch { TotDemnd = 0; }
            try
            {
                TotNetWet = double.Parse(NetWet);
            }
            catch { TotNetWet = 0; }

            if (TotNetWet > TotDemnd)
            {
                ChkAmt = "Yes";
            }
            if (ChkAmt == "Yes" && Request.QueryString["ID"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Total Gross Weight Exceed From Demand Weight.');OpenBill();</script>");
            }
            else
            {
                dt.Rows.Add(Dr);
            }
            ViewState["TempData"] = dt;
            GrdChallanReel.DataSource = dt;
            GrdChallanReel.DataBind();
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
                    Dr["id"] = id;
                }
                if (dt.Rows[0].ToString() == "")
                {
                    dt.Rows[0].Delete();
                    dt.AcceptChanges();
                }

                foreach (DataRow drd in dt.Rows)
                {
                    if (drd["RollNo"].ToString() == RollNo && PaperMstrTrId_I != "26")
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

            GrdChallanReel.DataSource = dt;
            GrdChallanReel.DataBind();
        }
    }
    public void PrinterAllFill()
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
        ddlPrinter.Items.Insert(0, "Select");
        //if (ddlDemandType.Text == "पाठ्यपुस्तक")
        //{
        //    objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //    ddlPrinter.DataSource = objPaperDispatchDetails.PrinterFill();
        //    ddlPrinter.DataTextField = "NameofPress_V";
        //    ddlPrinter.DataValueField = "PrinterID_I";
        //    ddlPrinter.DataBind();
        //    ddlPrinter.Items.Insert(0, "Select");
        //}
        //else if (ddlDemandType.Text == "अन्य पाठ्य सामग्री")
        //{
        //    objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //    ddlPrinter.DataSource = objPaperDispatchDetails.AcdmicPrinterFill();
        //    ddlPrinter.DataTextField = "NameofPress_V";
        //    ddlPrinter.DataValueField = "PrinterID_I";
        //    ddlPrinter.DataBind();
        //    ddlPrinter.Items.Insert(0, "Select");
        //}
        //else
        //{
        //    ddlPrinter.DataSource = string.Empty;
        //    ddlPrinter.DataBind();
        //    ddlPrinter.Items.Insert(0, "Select");
        //}
    }
    //public void WareHouseId()
    //{
    //    Depot_Id = Session["UserID"].ToString();
    //    objPaperDispatchDetails = new PPR_PaperDispatchDetails();
    //    objPaperDispatchDetails.DepoID_I = int.Parse(Depot_Id);
    //    ddlWareHouse.DataSource = objPaperDispatchDetails.WareHouseFill();
    //    ddlWareHouse.DataTextField = "WareHouseName_V";
    //    ddlWareHouse.DataValueField = "WareHouseID_I";
    //    ddlWareHouse.DataBind();
    //    ddlWareHouse.Items.Insert(0, "Select");
    //}
    protected void ddlPrinter_Init(object sender, EventArgs e)
    {
        PrinterAllFill();
    }
    public void OrderNoAllFill()
    {

        CommonFuction comm = new CommonFuction();
        string UserID = Session["PrierID_I"].ToString();
        DataSet ds2 = new DataSet();
        ds2 = comm.FillDatasetByProc("call USP_GetReturnOrderNoFromPrinter(" + UserID + ",'" + ddlAcYear.SelectedItem.Text + "',0)");
        if (ds2.Tables != null)
        {
            ddlOrderNo.DataSource = ds2.Tables[0];
            ddlOrderNo.DataTextField = "OrderNo";
            ddlOrderNo.DataValueField = "OrderNo";
            ddlOrderNo.DataBind();
            ddlOrderNo.Items.Insert(0, "Select");
            ViewState["Data"] = ds2.Tables[1]; ;
        }
    }
    protected void ddlDemandType_SelectedIndexChanged(object sender, EventArgs e)
    {
        PrinterAllFill();
    }
    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        OrderNoAllFill();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string RptDate = "", GrDate = "", prid = "0";
        if (txtChallanDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtChallanDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtGrDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtGrDate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }

        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Challan Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct GR Date.');</script>");
        }
        else if (DateTime.Parse(txtChallanDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan date cannot greater than current date.');</script>");
        }
        else if (DateTime.Parse(txtGrDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('GR date cannot greater than current date.');</script>");
        }
        else if (GrdWorkPlan.Rows.Count < 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Fill Dispatch Details.');</script>");
        }
        else if (DateTime.Parse(txtGrDate.Text, cult) < DateTime.Parse(txtChallanDate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('GR Date can not be less then challan date.');</script>");
        }
        else
        {
            string CheckSts, PaperGSM = "";
            double TotReel = 0;
            txtChallanNo.Text = txtChallanNo.Text.Replace("(R)", "") + "(R)";
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            try
            {
                objPaperDispatchDetails.PrinterID_I = int.Parse(Session["PrierID_I"].ToString());
            }
            catch { objPaperDispatchDetails.PrinterID_I = 0; }
            objPaperDispatchDetails.OrderNo = ddlOrderNo.SelectedValue.ToString();
            objPaperDispatchDetails.UserId_I = int.Parse(Depot_Id);
            objPaperDispatchDetails.ChallanDate = DateTime.Parse(txtChallanDate.Text, cult);
            objPaperDispatchDetails.ChallanNo = txtChallanNo.Text;
            objPaperDispatchDetails.AcYear = ddlAcYear.SelectedItem.Text.ToString();
            objPaperDispatchDetails.DriverName = txtDriverName.Text;
            objPaperDispatchDetails.MobileNo = txtMobileNo.Text;
            objPaperDispatchDetails.TruckNo = txtTruckNo.Text;
            objPaperDispatchDetails.GRNo = txtGrNo.Text;
            objPaperDispatchDetails.GRDate = DateTime.Parse(txtGrDate.Text, cult);
            // objPaperDispatchDetails.WareHouseID_I = int.Parse(ddlWareHouse.SelectedItem.Value);
            objPaperDispatchDetails.BlockNo = txtBlockNo.Text;
            objPaperDispatchDetails.DemandFrom = ddlDemandType.SelectedItem.Text;
            objPaperDispatchDetails.Remark = txtRemark.Text;
            if (Request.QueryString["ID"] != null)
            {
                objPaperDispatchDetails.PrinterID_I = int.Parse(Session["UserID"].ToString());
                objPaperDispatchDetails.PrinterDisTranId = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
            }
            else
            {
                objPaperDispatchDetails.PrinterDisTranId = 0;
            }
            if (ddlOrderNo.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
            }

            //else if (DateTime.Parse(txtChallanDate.Text, cult) > DateTime.Parse(txtReceivedDate.Text, cult))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Can not be greater challan date from receive date.');</script>");
            //}
            else if (txtChallanNo.Text == "" || txtChallanDate.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter challan information.');</script>");
            }
            else
            {
                if (Request.QueryString["ID"] != null)
                {
                    try
                    {

                        ds = PrinterDispInsertUpdate(objPaperDispatchDetails);

                        if (ds.Tables[0].Rows[0]["ChallanCheck"].ToString() == "0")
                        {
                            CheckSts = "NotOk";
                            foreach (GridViewRow gv in GrdWorkPlan.Rows)
                            {
                                CheckBox chkbox = (CheckBox)gv.FindControl("CheckBox1");
                                if (chkbox.Checked == true)
                                {

                                    Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
                                    Label lblDisDtl_Id = (Label)gv.FindControl("lblDisDtl_Id");
                                    Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                    TextBox txtSendQty = (TextBox)gv.FindControl("txtSendQty");
                                    Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                    Label lblPrinterSendQty = (Label)gv.FindControl("lblPrinterSendQty");
                                    TextBox txtNoOfReels = (TextBox)gv.FindControl("txtNoOfReels");
                                    DropDownList ddlVenderFill = (DropDownList)gv.FindControl("ddlVenderFill");

                                    Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
                                    try
                                    {
                                        TotReel = TotReel + double.Parse(txtNoOfReels.Text);
                                    }
                                    catch { }
                                    try
                                    {
                                        if (PaperGSM == "")
                                        {
                                            PaperGSM = lblCoverInformation.Text;
                                        }
                                        else
                                        {
                                            PaperGSM = PaperGSM + ", " + lblCoverInformation.Text;
                                        }
                                    }
                                    catch { }
                                    objPaperDispatchDetails.PrinterDisDtl_Id = int.Parse(lblDisDtl_Id.Text);
                                    objPaperDispatchDetails.PrinterDisTranId = int.Parse(lblDisTranId.Text);
                                    objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
                                    objPaperDispatchDetails.SendQty = float.Parse(txtSendQty.Text);
                                    objPaperDispatchDetails.PaperType_I = int.Parse(lblPaperType_I.Text);
                                    objPaperDispatchDetails.NoOfReels = float.Parse(txtNoOfReels.Text);
                                    objPaperDispatchDetails.ReqQty = float.Parse(lblPrinterSendQty.Text);
                                    try
                                    {
                                        objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlPrinter.SelectedValue);
                                    }
                                    catch { objPaperDispatchDetails.PaperVendorTrId_I = 0; }
                                    objPaperDispatchDetails.NetWt = decimal.Parse(txtSendQty.Text);

                                    DepotPrinterDispChallanChildInsert(objPaperDispatchDetails);

                                    CheckSts = "Ok";
                                }
                            }
                            if (CheckSts == "Ok")
                            {
                                obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate('',0,0,'',0,0,''," + Depot_Id + ",0,''," + objPaperDispatchDetails.PrinterDisTranId + ",'',0,3,0)");
                                foreach (GridViewRow gv in GrdChallanReel.Rows)
                                {
                                    double lblNetWt_d = 0; double lblGrossWt_d = 0;
                                    Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
                                    Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                    Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                    Label lblRollNo = (Label)gv.FindControl("lblRollNo");
                                    Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                                    Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                                    Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                                    if (lblTotalSheets.Text == "" || lblTotalSheets.Text == "0")
                                    {
                                        lblTotalSheets.Text = "1";
                                    }
                                    string prin = "0";
                                    try
                                    {
                                        if (ddlPrinter.SelectedItem.Value != "Select")
                                            prin = ddlPrinter.SelectedItem.Value;
                                        else
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
                                    }
                                    catch { }
                                    if (ddlPrinter.Visible == true)
                                    {
                                        obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdateptop(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt_d + "," + lblGrossWt_d + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + 0 + ",'" + obCommonFuction.GetFinYear() + "'," + ds.Tables[0].Rows[0]["LastId"].ToString() + ",'" + ddlDemandType.SelectedItem.Text + "'," + prin + ",2," + lblTotalSheets.Text + ")");
                                    }
                                    else
                                    {
                                        obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt_d + "," + lblGrossWt_d + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + 0 + ",'" + obCommonFuction.GetFinYear() + "'," + ds.Tables[0].Rows[0]["LastId"].ToString() + ",'" + ddlDemandType.SelectedItem.Text + "'," + prin + ",0," + lblTotalSheets.Text + ")");
                                        //obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdateptop(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt.Text + "," + lblGrossWt.Text + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + 0 + ",'" + obCommonFuction.GetFinYear() + "'," + ds.Tables[0].Rows[0]["LastId"].ToString() + ",'" + ddlDemandType.SelectedItem.Text + "'," + prin + ",0," + lblTotalSheets.Text + ")");
                                    }
                                }
                            }
                            if (CheckSts == "Ok")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");


                                Response.Redirect("View_PaperAllotmentReturn.aspx?y=" + objdb.Encrypt(ddlAcYear.SelectedItem.Text));

                                txtChallanDate.Text = "";
                                // txtReceivedDate.Text = "";
                                txtChallanNo.Text = "";

                                txtTruckNo.Text = "";
                                txtDriverName.Text = "";
                                txtMobileNo.Text = "";
                                GrdWorkPlan.DataSource = string.Empty;
                                GrdWorkPlan.DataBind();
                            }
                        }
                    }
                    catch
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan No Already Exist.');</script>");
                        // string exp = ex.Message;
                    }
                }
                else
                {

                    ds = PrinterDispInsertUpdate(objPaperDispatchDetails);
                    try
                    {
                        // obCommonFuction.FillDatasetByProc("call  USPPaperprinterdispatchUpdateSupplierName(" + ds.Tables[0].Rows[0]["LastId"].ToString() + "," + ddlSupplier.SelectedValue + ")");
                    }
                    catch { }//  
                    if (ds.Tables[0].Rows[0]["ChallanCheck"].ToString() == "0")
                    {
                        CheckSts = "NotOk";
                        foreach (GridViewRow gv in GrdWorkPlan.Rows)
                        {
                            //  GrdWorkPlan

                            //CheckBox1
                            CheckBox chkbox = (CheckBox)gv.FindControl("CheckBox1");
                            if (chkbox.Checked == true)
                            {

                                Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                TextBox txtSendQty = (TextBox)gv.FindControl("txtSendQty");
                                Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                Label lblPrinterSendQty = (Label)gv.FindControl("lblPrinterSendQty");
                                TextBox txtNoOfReels = (TextBox)gv.FindControl("txtNoOfReels");
                                objPaperDispatchDetails.PrinterDisDtl_Id = 0;
                                objPaperDispatchDetails.PrinterDisTranId = int.Parse(ds.Tables[0].Rows[0]["LastId"].ToString());
                                objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
                                objPaperDispatchDetails.SendQty = float.Parse(txtSendQty.Text);
                                objPaperDispatchDetails.PaperType_I = int.Parse(lblPaperType_I.Text);
                                objPaperDispatchDetails.NoOfReels = float.Parse(txtNoOfReels.Text);
                                objPaperDispatchDetails.ReqQty = float.Parse(lblPrinterSendQty.Text);
                                DropDownList ddlVenderFill = (DropDownList)gv.FindControl("ddlVenderFill");
                                try
                                {
                                    objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlPrinter.SelectedValue);
                                }
                                catch { objPaperDispatchDetails.PaperVendorTrId_I = 0; }
                                objPaperDispatchDetails.NetWt = decimal.Parse(txtSendQty.Text);
                                DepotPrinterDispChallanChildInsert(objPaperDispatchDetails);

                                CheckSts = "Ok";
                            }
                        }
                        if (CheckSts == "Ok")
                        {
                            foreach (GridViewRow gv in GrdChallanReel.Rows)
                            {
                                double lblNetWt_d = 0; double lblGrossWt_d = 0;
                                Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
                                Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                Label lblRollNo = (Label)gv.FindControl("lblRollNo");
                                Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                                Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                                Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                                HiddenField hdnRollID = (HiddenField)gv.FindControl("hdnRollID");
                                if (lblTotalSheets.Text == "" || lblTotalSheets.Text == "0")
                                {
                                    lblTotalSheets.Text = "1";
                                }
                                string prin = "0";
                                try
                                {
                                    if (ddlPrinter.SelectedItem.Value != "Select")
                                        prin = ddlPrinter.SelectedItem.Value;
                                    else
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
                                }
                                catch { }
                                try
                                {
                                    lblPaperVendorTrId_I.Text = obCommonFuction.FillScalarByProc("SELECT MAX(PaperVendorTrId_I) FROM ppr_tblpaperrolestock WHERE RollNo='" + lblRollNo.Text + "'");
                                    if (ddlPrinter.Visible == true)
                                    {

                                        obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt_d + "," + lblGrossWt_d + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + lblPaperVendorTrId_I.Text + ",'" + obCommonFuction.GetFinYear() + "'," + ds.Tables[0].Rows[0]["LastId"].ToString() + ",'" + ddlDemandType.SelectedItem.Text + "'," + prin + ",6," + lblTotalSheets.Text + ")");
                                    }
                                    else
                                    {
                                        //first save in temporary table -
                                        //obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt_d + "," + lblGrossWt_d + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + lblPaperVendorTrId_I.Text + ",'" + obCommonFuction.GetFinYear() + "'," + ds.Tables[0].Rows[0]["LastId"].ToString() + ",'" + ddlDemandType.SelectedItem.Text + "'," + prin + ",5," + lblTotalSheets.Text + ")");
                                        obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdateptret(''," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ",'" + lblRollNo.Text + "'," + lblNetWt_d + "," + lblGrossWt_d + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + lblPaperVendorTrId_I.Text + ",'" + obCommonFuction.GetFinYear() + "'," + ds.Tables[0].Rows[0]["LastId"].ToString() + ",'" + ddlDemandType.SelectedItem.Text + "'," + prin + ",5," + lblTotalSheets.Text + "," + hdnRollID.Value + ")");

                                    }
                                }
                                catch { }
                            }
                        }
                        if (CheckSts == "Ok")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                            Response.Redirect("View_PaperAllotmentReturn.aspx?y=" + objdb.Encrypt(ddlAcYear.SelectedItem.Text));

                            txtChallanDate.Text = "";
                            txtChallanNo.Text = "";
                            txtTruckNo.Text = "";
                            txtDriverName.Text = "";
                            txtMobileNo.Text = "";
                            GrdWorkPlan.DataSource = string.Empty;
                            GrdWorkPlan.DataBind();
                        }

                    }

                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan No Already Exist.');</script>");
                    }
                }
            }
        }
    }
    protected void txtNoOfReels_TextChanged(object sender, EventArgs e)
    {
        TextBox txtQty = (TextBox)sender;
        GridViewRow gv = (GridViewRow)txtQty.NamingContainer;
        Label lblPerSheetWt = (Label)gv.FindControl("lblPerSheetWt");
        Label lblPaperCategory = (Label)gv.FindControl("lblPaperCategory");
        TextBox txtNetWt = (TextBox)gv.FindControl("txtSendQty");
        TextBox txtNoOfReels = (TextBox)gv.FindControl("txtNoOfReels");
        string FirstVal = "";
        FirstVal = txtQty.Text.ToString().Substring(0, 1);

        if (FirstVal == "-" || FirstVal == "0")
        {
            txtQty.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Quantity.');</script>");
        }
        else
        {
            if (lblPaperCategory.Text.Trim() == "Sheet")
            {
                try
                {
                    txtNetWt.Text = (decimal.Parse(txtQty.Text) * (decimal.Parse(lblPerSheetWt.Text) / 1000)).ToString("0.000");
                }
                catch { txtNetWt.Text = "0"; }
            }
            else
            {
                txtNetWt.Text = "0";
            }
        }

    }
    protected void ddlPaperQlty_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    public void GridFill()
    {
        //try
        //{
        //    if (ddlOrderNo.SelectedItem.Text != "Select")
        //    {
        //        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //        objPaperDispatchDetails.LOITrId_I = int.Parse(ddlOrderNo.SelectedItem.Value.ToString());
        //        GrdWorkPlan.DataSource = objPaperDispatchDetails.GrWorkPlanFill();
        //        GrdWorkPlan.DataBind();
        //    }
        //}
        //catch { }
    }

    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            //{
            Label lblPaperVendorTrId_I = (Label)e.Row.FindControl("lblPaperVendorTrId_I");
            Label lblPaperCategory = (Label)e.Row.FindControl("lblPaperCategory");
            Label lblPaperMstrTrId_I = (Label)e.Row.FindControl("lblPaperMstrTrId_I");
            Label lblTotSend = (Label)e.Row.FindControl("lblTotSend");
            Label lblPrinterSendQty = (Label)e.Row.FindControl("lblPrinterSendQty");
            Label lblRemainQty = (Label)e.Row.FindControl("lblRemainQty");
            Label lblTotSheets = (Label)e.Row.FindControl("lblTotSheets");
            DataSet DS;
            decimal TotSend = 0, TotAllot = 0, TotRemin = 0, OldRemainng = 0, AllAloted = 0;
            //DS = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(" + lblPaperMstrTrId_I.Text + ",'" + ddlAcYear.SelectedItem.Text + "','" + ddlOrderNo.SelectedValue + "',5)");

            string Category = lblPaperCategory.Text;

            //if (DS.Tables[0].Rows.Count > 0)
            //{
            //    try
            //    {
            //        // TotSend = decimal.Parse(DS.Tables[1].Rows[0]["NetWt"].ToString());
            //        if (Category == "Sheet" && lblPaperMstrTrId_I.Text != "28")
            //        {
            //            //TotSend = decimal.Parse(DS.Tables[1].Rows[0]["NoOfReels"].ToString());
            //            //OldRemainng = decimal.Parse(DS.Tables[1].Rows[0]["NoOfReels"].ToString());

            //        }
            //        // AllAloted
            //    }
            //    catch { TotSend = 0; }
            //}
            try
            {
                TotAllot = decimal.Parse(lblPrinterSendQty.Text);
            }
            catch { TotSend = 0; }
            if (Category == "Sheet" && lblPaperMstrTrId_I.Text != "28")
            {
                TotRemin = TotAllot - OldRemainng;
                lblTotSend.Text = OldRemainng.ToString("0.###");
                lblRemainQty.Text = TotRemin.ToString("0.###");
                lblTotSheets.Text = TotRemin.ToString("0.###");
                lblPrinterSendQty.Text = (decimal.Parse(lblPrinterSendQty.Text)).ToString("0.###");

            }

            else
            {
                TotRemin = TotAllot - TotSend;
                lblTotSend.Text = TotSend.ToString("0.000");
                lblRemainQty.Text = TotRemin.ToString("0.000");
                lblTotSheets.Text = TotRemin.ToString("0.000");
            }

            //lblTotSend.Text = TotSend.ToString("0.000");
            // lblTotSend.Text = TotRemin.ToString("0.000");

            //DropDownList ddlVenderFill = (DropDownList)e.Row.FindControl("ddlVenderFill");
            //objTenderEvaluation = new PPR_TenderEvaluation();
            //ddlVenderFill.DataSource = objTenderEvaluation.VenderFill();
            //ddlVenderFill.DataTextField = "PaperVendorName_V";
            //ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            //ddlVenderFill.DataBind();
            //ddlVenderFill.Items.Insert(0, "Select");
            try
            {
                // ddlVenderFill.Items.FindByValue(lblPaperVendorTrId_I.Text).Selected = true;
            }
            catch { }

            if (Request.QueryString["ID"] != null)
            {
                // ddlVenderFill.Enabled = false;
            }

        }
    }
    protected void ddlWareHouse_Init(object sender, EventArgs e)
    {
        // WareHouseId();
    }
    protected void ddlOrderNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        if (ddlOrderNo.SelectedItem.Text != "Select")
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PrinterID_I = int.Parse(Session["UserID"].ToString());
            // objPaperDispatchDetails.OrderNo = ddlOrderNo.SelectedValue;
            string UserID = Session["PrierID_I"].ToString();
            DataSet ds2 = new DataSet();
            DataTable dt = new DataTable();
            ds2 = comm.FillDatasetByProc("call USP_GetReturnOrderNoFromPrinter(" + UserID + ",'" + ddlOrderNo.SelectedItem.Text + "',1)");
            if (ds2.Tables != null)
            {
                dt = ds2.Tables[0];
            }

            // dt = (DataTable)ViewState["Data"];
            string distype = dt.Rows[0]["ReternTo"].ToString();
            if (distype == "Printer")
            {
                ddlPrinter.SelectedValue = dt.Rows[0]["IssueID"].ToString();
                ddlPrinter.Enabled = false;
                ddlPrinter.Visible = true;
                lblcpdsendto.Visible = false;
                txtOrderDate.Text = dt.Rows[0]["OrderDate"].ToString();
            }
            else
            {
                ddlPrinter.Enabled = true;
                lblcpdsendto.Visible = true;
                lblcpdsendto.Text = dt.Rows[0]["ReternTo"].ToString();
                ddlPrinter.Visible = false;
                txtOrderDate.Text = dt.Rows[0]["OrderDate"].ToString();
            }
            ViewState["TempData"] = "";
            if (ddlDemandType.Text == "पाठ्यपुस्तक")
            {

                ds = comm.FillDatasetByProc("call USP_GetReturnOrderNoFromPrinter(" + UserID + ",'" + ddlOrderNo.SelectedItem.Text + "',2)");

                //bDBAccess.addParam("mPrinterID_I", PrinterID_I);
                //obDBAccess.addParam("mPaperAltID_I", 0);
                //obDBAccess.addParam("mOrderNo", OrderNo);
                //obDBAccess.addParam("mPaperType_I", 01
                //obDBAccess.addParam("mPaperMstrTrId_I", 0);
                //obDBAccess.addParam("mtype", 2);
                // ds = objPaperDispatchDetails.PrinterOrderFill();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //txtOrderDate.Text = ds.Tables[0].Rows[0]["Supplydate_D"].ToString();
                    // lblTitleRemark.Text = "";
                    GrdWorkPlan.DataSource = ds.Tables[0];
                    GrdWorkPlan.DataBind();
                }
                else
                {
                    txtOrderDate.Text = "";
                    GrdWorkPlan.DataSource = string.Empty;
                    GrdWorkPlan.DataBind();
                }
            }
            else if (ddlDemandType.Text == "अन्य पाठ्य सामग्री")
            {
                ds = objPaperDispatchDetails.AcdminPrinterOrderFill();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtOrderDate.Text = ds.Tables[0].Rows[0]["Supplydate_D"].ToString();
                    GrdWorkPlan.DataSource = ds.Tables[0];
                    GrdWorkPlan.DataBind();
                }
                else
                {
                    txtOrderDate.Text = "";
                    GrdWorkPlan.DataSource = string.Empty;
                    GrdWorkPlan.DataBind();
                }
            }

            DataSet ds12 = comm.FillDatasetByProc("call GetPrinterOrderbyTitleName('" + ddlOrderNo.SelectedValue + "')");
            if (ds12.Tables[0].Rows.Count > 0)
            {
                //ddlTitle.DataTextField = "TitleHindi_V";
                //ddlTitle.DataValueField = "TitleID_I";
                //ddlTitle.DataSource = ds12.Tables[0];
                //ddlTitle.DataBind();
            }
            // 

        }

    }
    protected void btnShowDtl_Click(object sender, EventArgs e)
    {
        try
        {
            string UserID = Session["PrierID_I"].ToString();
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            if (chkAutoRoll.Checked == true && txtWeightPerBundal.Text != "")
            {
                txtRoleNo.Text = Math.Ceiling(Convert.ToDouble(lblTotWtQty.Text) / Convert.ToDouble(txtWeightPerBundal.Text)).ToString();
                txtTotalSheets.Text = txtWeightPerBundal.Text;
                //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntryNew2(" + lblMPaperMIllNameID.Text + ",'" + lblPprid.Text + "','" + txtRoleNo.Text + "',8,''," + txtRoleNo.Text + ")");
                ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntryNew2(" + UserID + ",'" + lblPprid.Text + "','" + txtRoleNo.Text + "',8,''," + txtRoleNo.Text + ")");
            }
            else
            {
                ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntryNew2(" + UserID + ",'0','" + txtRoleNo.Text + "',7,'',0)");
            }
            if (ds.Tables[0].Rows.Count > 0)
            {
                gvRoleDetails.DataSource = ds.Tables[0];
                gvRoleDetails.DataBind();
                btnRoleAdd.Visible = true;
                if (lblCheckFlag.Text == "Sheet")
                {
                    tdsheet1.Visible = true;
                    tdsheet2.Visible = true;
                    RqtxtTotalSheets.Visible = true;
                }
                else
                {
                    RqtxtTotalSheets.Visible = false;
                    tdsheet1.Visible = false;
                    tdsheet2.Visible = false;
                }
            }
            else
            {
                gvRoleDetails.DataSource = ds.Tables[0];
                gvRoleDetails.DataBind();
                btnRoleAdd.Visible = false;
            }

            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
        }
        catch { }
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }
    protected void btnRoleAdd_Click(object sender, EventArgs e)
    {
        string TotalSheetsFlag = "", Msg = "";
        foreach (GridViewRow gv in gvRoleDetails.Rows)
        {
            Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
            Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
            Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
            Label lblRollNo = (Label)gv.FindControl("lblRollNo");
            Label lblNetWt = (Label)gv.FindControl("lblNetWt");
            Label lblActTotalSheets = (Label)gv.FindControl("lblActTotalSheets");


            CheckBox ChkSelectedRoll = (CheckBox)gv.FindControl("chkitem");
            Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
            Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
            Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");//500
            HiddenField hdnRollID = (HiddenField)gv.FindControl("hdnRollID");//500

            if (txtTotalSheets.Text == "")
            {
                txtTotalSheets.Text = "0";
            }
            if (lblCheckFlag.Text == "Sheet" && lblPaperMstrTrId_I.Text != "28")
            {

                decimal TotWetOfSheet = 0;
                foreach (GridViewRow gvd in GrdChallanReel.Rows)
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

                //if (decimal.Parse(lblTotalSheets.Text) < decimal.Parse(txtTotalSheets.Text))
                //{
                //    TotalSheetsFlag = "";
                //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Insufficient Sheets.');OpenBill();</script>");
                //}
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
                if (TotalSheetsFlag == "" && ChkSelectedRoll.Checked == true)
                {
                    DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, "", txtTotalSheets.Text, hdnRollID.Value);
                    // txtTotalSheets.Text = "0";
                }
                if (TotalSheetsFlag == "" && ChkSelectedRoll.Checked == false)
                {
                    DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, "", txtTotalSheets.Text, hdnRollID.Value);
                    // txtTotalSheets.Text = "0";
                }
            }
            else
            {
                decimal TotWetOfReel = 0;
                foreach (GridViewRow gvd in GrdChallanReel.Rows)
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

                //if (decimal.Parse(lblPaperDemand.Text) < (TotWetOfReel + (decimal.Parse(lblNetWt.Text) / 1000)))
                //{
                //    TotalSheetsFlag = "NotOk";
                //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Reel Weight Exceed From Demand Weight.');OpenBill();</script>");
                //}
                //else
                //{
                if (TotalSheetsFlag == "")
                {
                    try
                    {
                        if (double.Parse(lblNetWt.Text) > 1)
                            lblNetWt.Text = ((double.Parse(lblNetWt.Text)) / 1000).ToString("0.000");
                        lblGrossWt.Text = (double.Parse(lblNetWt.Text) + 0.005).ToString("0.000");
                    }
                    catch { }
                    DataBindToGrid(lblPaperType_I.Text, lblPaperMstrTrId_I.Text, lblCoverInformation.Text, lblRollNo.Text, lblNetWt.Text, lblGrossWt.Text, lblPaperVendorTrId_I.Text, "0", txtTotalSheets.Text, hdnRollID.Value);
                    if (lblPaperMstrTrId_I.Text != "28")
                        txtTotalSheets.Text = "0";
                }
                // }
            }
        }
        foreach (GridViewRow gvG in GrdWorkPlan.Rows)
        {
            DropDownList ddlVenderFill = (DropDownList)gvG.FindControl("ddlVenderFill");
            TextBox txtNoOfReels = (TextBox)gvG.FindControl("txtNoOfReels");
            TextBox txtSendQty = (TextBox)gvG.FindControl("txtSendQty");
            Label lblMPaperMstrTrId_I = (Label)gvG.FindControl("lblPaperMstrTrId_I");
            Label lblCheckFlag1 = (Label)gvG.FindControl("lblPaperCategory");
            Label lblOrderTotalSheets = (Label)gvG.FindControl("lblOrderTotalSheets");

            decimal TotReel = 0, TotWtGrs = 0;
            foreach (GridViewRow gv in GrdChallanReel.Rows)
            {
                Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                Label lblPaperMstrTrId_I1 = (Label)gv.FindControl("lblPaperMstrTrId_I");
                Label lblGrossWt = (Label)gv.FindControl("lblNetWt");
                if (lblPaperMstrTrId_I1.Text == lblMPaperMstrTrId_I.Text)
                {
                    if (lblTotalSheets.Text == "")
                    {
                        lblTotalSheets.Text = "0";
                    }
                    if (lblCheckFlag1.Text == "Sheet" || lblMPaperMstrTrId_I.Text == "28")
                    {
                        TotReel = TotReel + (decimal.Parse(lblTotalSheets.Text));
                    }
                    else
                    {
                        TotReel = TotReel + 1;
                    }
                    //if (TotReel == 0)
                    //{
                    //    TotReel = 1;
                    //}
                    try
                    {
                        TotWtGrs = TotWtGrs + decimal.Parse(lblGrossWt.Text);
                    }
                    catch { }
                }
            }

            if (TotReel != 0)
            {
                txtNoOfReels.Text = TotReel.ToString();
                txtSendQty.Text = TotWtGrs.ToString("0.000");
                //if (ddlVenderFill.SelectedItem.Text != "Select")
                //{
                //    ddlVenderFill.Enabled = false;
                //}
            }

        }
        gvRoleDetails.DataSource = string.Empty;
        gvRoleDetails.DataBind();

        //ChkAutoRoll.Checked = false;
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }
    protected void btnAddChallanDetailse_Click(object sender, EventArgs e)
    {
        Button btnView = (Button)sender;
        GridViewRow gv = (GridViewRow)btnView.NamingContainer;
        DropDownList ddlVenderFill = (DropDownList)gv.FindControl("ddlVenderFill");
        Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
        Label lblPrinterSendQty = (Label)gv.FindControl("lblPrinterSendQty");
        Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
        Label lblRemainQty = (Label)gv.FindControl("lblRemainQty");
        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
        Label lblPaperCategory = (Label)gv.FindControl("lblPaperCategory");
        Label lblTotSheets = (Label)gv.FindControl("lblTotSheets");
        Label lblOrderTotalSheets = (Label)gv.FindControl("lblOrderTotalSheets");
        Label lblReqTotalSheets = (Label)gv.FindControl("lblReqTotalSheets");


        //lblPaperMIllName.Text = ddlVenderFill.SelectedItem.Text;
        //lblMPaperMIllNameID.Text = ddlVenderFill.SelectedItem.Value;
        lblMPaperMIllNameID.Text = lblPaperVendorTrId_I.Text != "" ? lblPaperVendorTrId_I.Text : "0"; //later will change
        lblTotWtQty.Text = lblRemainQty.Text;
        lblMPaperSize.Text = lblCoverInformation.Text;
        lblPprid.Text = lblPaperMstrTrId_I.Text;
        lblPaperDemand.Text = lblPrinterSendQty.Text;
        lblCheckFlag.Text = lblPaperCategory.Text;
        lblOrderTotSheet.Text = lblPrinterSendQty.Text;

        chkAutoRoll.Checked = false;
        txtRoleNo.Text = "";
        txtWeightPerBundal.Text = "";
        txtTotalSheets.Text = "";
        btnRoleAdd.Visible = false;

        DataSet dsr = new DataSet();

        if (lblPaperCategory.Text == "Sheet")
        {
            if (lblPaperMstrTrId_I.Text == "28")
            {
                decimal tots = decimal.Parse(lblTotSheets.Text);
                decimal totw = tots * 5761;
                // ChkAutoRoll.Visible = true;
                //lblAutoRoll.Visible = true;
                lblPaperlbl.Text = "कुल शीट <br> Total Sheets";
                lblTotWtQty.Text = totw.ToString();

            }
            // ChkAutoRoll.Visible = true;
            //  lblAutoRoll.Visible = true;
            lblPaperlbl.Text = "कुल शीट <br> Total Sheets";
            lblTotWtQty.Text = lblTotSheets.Text;
            chkAutoRoll.Visible = true;
            lblAutoRoll.Visible = true;

        }
        else
        {
            lblPaperlbl.Text = " वापसी की मात्रा (मे. टन)<br /> Return Paper(Metric Ton)";
            lblTotWtQty.Text = lblRemainQty.Text;
            chkAutoRoll.Visible = false;
            lblAutoRoll.Visible = false;

        }
        if (ViewState["TempData"] == "")
        {
            GrdChallanReel.DataSource = string.Empty;
            GrdChallanReel.DataBind();
        }
        else
        {
            GrdChallanReel.DataSource = (DataTable)ViewState["TempData"];
            GrdChallanReel.DataBind();
        }


        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");

    }
    protected void GrdChallanReel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");
            try
            {
                TotNetWt = TotNetWt + double.Parse(lblNetWt.Text);
            }
            catch { TotNetWt = 0; }
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
            lblTotNetWt.Text = TotNetWt.ToString("0.000");
            lblTotGrossWt.Text = TotGrossWt.ToString("0.000");
        }
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        OrderNoAllFill();
    }

    public int DepotPrinterDispChallanChildInsert(PPR_PaperDispatchDetails o)
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0014_PaperPrinterReturnChildSaveData", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mPrinterDisDtl_Id", o.PrinterDisDtl_Id);
        obDBAccess.addParam("mPrinterDisTranId", o.PrinterDisTranId);
        obDBAccess.addParam("mPaperMstrTrId_I", o.PaperMstrTrId_I);
        obDBAccess.addParam("mPaperType_I", o.PaperType_I);
        obDBAccess.addParam("mSendQty", o.SendQty);
        obDBAccess.addParam("mNoOfReels", o.NoOfReels);
        obDBAccess.addParam("mPrinter_RedID_I", o.PrinterID_I);
        obDBAccess.addParam("mBlockNo", o.BlockNo);
        obDBAccess.addParam("mWareHouseID_I", o.WareHouseID_I);
        obDBAccess.addParam("mAcYear", o.AcYear);
        obDBAccess.addParam("mUser_Id", o.UserId_I);
        obDBAccess.addParam("mReqQty", o.ReqQty);
        obDBAccess.addParam("mDemandFrom", o.DemandFrom);
        obDBAccess.addParam("mNetWt", o.NetWt);
        obDBAccess.addParam("mPaperVendorTrId_I", o.PaperVendorTrId_I);
        int result = obDBAccess.executeMyQuery();
        return result;
    }
    public DataSet PrinterDispInsertUpdate(PPR_PaperDispatchDetails o)
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0014_PaperPrinterReturnSaveData", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mPrinterDisTranId", o.PrinterDisTranId);
        obDBAccess.addParam("mPrinter_RedID_I", o.PrinterID_I);
        obDBAccess.addParam("mPaperVendorTrId_I", o.PaperVendorTrId_I);
        obDBAccess.addParam("mChallanNo", o.ChallanNo);
        obDBAccess.addParam("mChallanDate", o.ChallanDate);
        obDBAccess.addParam("mUserId", o.UserId_I);
        obDBAccess.addParam("mAcYear", o.AcYear);
        obDBAccess.addParam("mMobileNo", o.MobileNo);
        obDBAccess.addParam("mTruckNo", o.TruckNo);
        obDBAccess.addParam("mDriverName", o.DriverName);
        obDBAccess.addParam("mGRNo", o.GRNo);
        obDBAccess.addParam("mGRDate", o.GRDate);
        obDBAccess.addParam("mOrderNo", o.OrderNo);
        obDBAccess.addParam("mWareHouseID_I", o.WareHouseID_I);
        obDBAccess.addParam("mBlockNo", o.BlockNo);
        obDBAccess.addParam("mDemandFrom", o.DemandFrom);
        obDBAccess.addParam("mRemark", o.Remark);
        return obDBAccess.records();
    }
}
