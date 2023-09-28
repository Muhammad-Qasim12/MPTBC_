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
using MPTBCBussinessLayer;
using System.Globalization;
using MPTBCBussinessLayer.Paper;

public partial class Paper_DispatchDetails : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string Depot_Id = "";
    double TotSheetWt = 0, TotNet = 0, TotGrossWt = 0;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        Depot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {

            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('CENTRAL STORE  ')");
            ddlEmployee.DataSource = ds.Tables[0];
            ddlEmployee.DataTextField = "Name";
            ddlEmployee.DataValueField = "EmployeeID_I";
            ddlEmployee.Items.Insert(0, "Select...");
            ddlEmployee.DataBind();
            ViewState["ChkRcrd"] = "";
            if (Request.QueryString["ID"] != null)
            {
                LabInvDtlFill();
                //ReelDetailFill();
                txtRecivedDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                //  VendorFill();
                // ddlVendor.ClearSelection();
                // ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
                // ddlVendor.Enabled = false;
                //LOIFill();

            }

            //   fillblock();


        }
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
    public void ReelDetailFill()
    {

        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntryNew(" + ddlVendor.SelectedItem.Value.ToString() + ",'" + txtChallanNo.Text + "','',1,'" + ddlAcYear.SelectedValue + "')");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdChallanReel.DataSource = ds.Tables[0];
            GrdChallanReel.DataBind();
        }
        else
        {
            GrdChallanReel.DataSource = ds.Tables[0];
            GrdChallanReel.DataBind();

            //
        }

    }
    public void LabInvDtlFill()
    {

        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        objPaperDispatchDetails.DisTranId = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        ds = objPaperDispatchDetails.DetailsFill();
        if (ds.Tables[0].Rows.Count > 0)
        {

            VendorFill();
            ddlVendor.ClearSelection();
            try
            {
                ddlVendor.Items.FindByValue(ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true; ;
            }
            catch { }
            ddlVendor.Enabled = false;
            try
            {
                ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
                ddlAcYear.DataTextField = "AcYear";
                ddlAcYear.DataBind();
                ddlAcYear.Items.FindByText(ds.Tables[0].Rows[0]["AcYear"].ToString()).Selected = true;
                // ddlAcYear.Items.Insert(0, "Select");
            }
            catch { }
            LOIFill();
            //    ddlLOINo.ClearSelection();
            try
            {
                ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
            }
            catch { }
            // ddlLOINo.Enabled = false;
            DateTime dte = new DateTime();
            dte = DateTime.Parse(ds.Tables[0].Rows[0]["ChallanDate"].ToString());
            txtChallanDate.Text = dte.ToString("dd/MM/yyyy");

            txtChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo"].ToString();
            lblChallanNoRole.Text = txtChallanNo.Text;
            //LoiAddressFill();
            txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            txtDriverName.Text = ds.Tables[0].Rows[0]["DriverName"].ToString();
            txtTruckNo.Text = ds.Tables[0].Rows[0]["TruckNo"].ToString();
            txtChallanNo.Enabled = false;
            txtGrNo.Text = ds.Tables[0].Rows[0]["GRNo"].ToString();
            txtGrDate.Text = ds.Tables[0].Rows[0]["GRDate"].ToString();
            txtDefReel.Text = ds.Tables[0].Rows[0]["DefReel"].ToString();
            txtDefWt.Text = ds.Tables[0].Rows[0]["DefWt"].ToString();

            txtGSRPageNo.Text = ds.Tables[0].Rows[0]["GSRPageNo"].ToString();
            txtGSRSrNo.Text = ds.Tables[0].Rows[0]["GSRSrNo"].ToString();
            txtTransporterName.Text = ds.Tables[0].Rows[0]["TransporterName"].ToString();
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

            if (txtGSRPageNo.Text != "")
            {
                btnSave.Visible = true;
                btnPrint.Visible = true;
            }
            if (ds.Tables[0].Rows[0]["ReceivedDate"].ToString() != "")
            {
                dte = DateTime.Parse(ds.Tables[0].Rows[0]["ReceivedDate"].ToString());
                txtRecivedDate.Text = dte.ToString("dd/MM/yyyy");
            }
            if (ds.Tables[0].Rows[0]["BlockNo"].ToString() != "")
            {
                // fillblock();
                txtBlockNo.SelectedValue = ds.Tables[0].Rows[0]["BlockNo"].ToString();
            }
            if (ds.Tables[0].Rows[0]["WareHouseID_I"].ToString() != "")
            {

                btnAddChallanDetails.Visible = true;
                WareHouseId();
                ddlWareHouse.ClearSelection();
                try
                {
                    ddlWareHouse.Items.FindByValue(ds.Tables[0].Rows[0]["WareHouseID_I"].ToString()).Selected = true;
                }
                catch { }
            }
            else
            {
                ViewState["ChkRcrd"] = "NewEntry";
            }

            GrdWorkPlan.DataSource = ds.Tables[0];
            GrdWorkPlan.DataBind();
        }

    }
    public void VendorFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
        /*
         txtBlockNo.Items.Insert(1, "1");
         txtBlockNo.Items.Insert(2, "2");
         txtBlockNo.Items.Insert(3, "3");
         txtBlockNo.Items.Insert(4, "4");
         txtBlockNo.Items.Insert(5, "5");
         txtBlockNo.Items.Insert(6, "6");
         */
    }
    public void fillblock()
    {
        txtBlockNo.Items.Clear();
        txtBlockNo.Items.Insert(0, "Select");
        txtBlockNo.Items.Insert(1, "1");
        txtBlockNo.Items.Insert(2, "2");
        txtBlockNo.Items.Insert(3, "3");
        txtBlockNo.Items.Insert(4, "4");
        txtBlockNo.Items.Insert(5, "5");
        txtBlockNo.Items.Insert(6, "6");
    }
    public void WareHouseId()
    {
        Depot_Id = Session["UserID"].ToString();
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        objPaperDispatchDetails.DepoID_I = int.Parse(Depot_Id);
        ddlWareHouse.DataSource = objPaperDispatchDetails.WareHouseFill();
        ddlWareHouse.DataTextField = "WareHouseName_V";
        ddlWareHouse.DataValueField = "WareHouseID_I";
        ddlWareHouse.DataBind();
        ddlWareHouse.Items.Insert(0, "Select");
        // ddlWareHouse.Items.FindByValue("66").Selected = true;
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        VendorFill();
    }
    public void LOIFill()
    {
        if (ddlVendor.SelectedItem.Text != "Select")
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            //ddlLOINo.DataSource = objPaperDispatchDetails.LOINoFill();
            ddlLOINo.DataSource = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchShowData_ShowAll('" + objPaperDispatchDetails.PaperVendorTrId_I + "',0,0,0,0,0,1,'" + ddlAcYear.SelectedValue + "')");
            ddlLOINo.DataTextField = "LOINo_V";
            ddlLOINo.DataValueField = "LOITrId_I";
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "Select");

        }
        else
        {
            ddlLOINo.DataSource = string.Empty;
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "Select");

        }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIFill();
    }

    protected void btnAddChallanDetailse_Click(object sender, EventArgs e)
    {
        ReelDetailFill();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }

    protected void btnRoleAdd_Click(object sender, EventArgs e)
    {
        float totDefectiveReel = 0, totNoOfReel = 0, TotNetWtSelected = 0;
        string SumWet = "0";
        foreach (GridViewRow gv in GrdChallanReel.Rows)
        {
            CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
            CheckBox chkDefectiveReel = (CheckBox)gv.FindControl("chkDefectiveReel");
            Label lblNetWt = (Label)gv.FindControl("lblNetWt");
            if (chkSelect.Checked == true)
            {
                if (chkDefectiveReel.Checked == true)
                {
                    totDefectiveReel = totDefectiveReel + 1;
                }
                totNoOfReel = totNoOfReel + 1;
                SumWet = (TotNetWtSelected + float.Parse(lblNetWt.Text)).ToString();


                TotNetWtSelected = (TotNetWtSelected + float.Parse(lblNetWt.Text));//(float.Parse(SumWet));
                btnSave.Visible = true;
            }
        }
        try
        {
            txtDefReel.Text = totDefectiveReel.ToString();
        }
        catch { txtDefReel.Text = "0"; }
        try
        {
            txtDefWt.Text = ((totDefectiveReel * 25) / 1000).ToString();
        }
        catch { txtDefWt.Text = "0"; }

        foreach (GridViewRow gv in GrdWorkPlan.Rows)
        {
            TextBox txtNoOfReels = (TextBox)gv.FindControl("txtNoOfReels");
            TextBox txtRecivedQty = (TextBox)gv.FindControl("txtRecivedQty");
            Label lblSndrReel = (Label)gv.FindControl("lblSndrReel");
            Label lblVdrSendQty = (Label)gv.FindControl("lblVdrSendQty");

            try
            {
                txtNoOfReels.Text = (totNoOfReel).ToString();
                if (lblSndrReel.Text.Trim() == txtNoOfReels.Text.Trim())
                {
                    txtRecivedQty.Text = lblVdrSendQty.Text.Trim();
                }
                else
                {

                    float NetSum = (TotNetWtSelected / 1000);
                    string dd = "";
                    string[] a = NetSum.ToString().Split('.');

                    string intDigit = a[0];
                    string DecimalDigit = "";
                    try
                    {
                        DecimalDigit = a[1];
                    }
                    catch { }
                    if (DecimalDigit == "")
                    {
                        dd = intDigit;
                    }
                    else
                    {
                        dd = intDigit + "." + DecimalDigit.Substring(0, 3);
                    }
                    //dd = intDigit+;
                    txtRecivedQty.Text = dd;
                }
            }
            catch { txtNoOfReels.Text = "0"; }
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        FillReceiptDtl();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>BillPrint();</script>");

    }
    public void FillReceiptDtl()
    {
        double totNoOfRl = 0;
        foreach (GridViewRow gv in GrdWorkPlan.Rows)
        {
            TextBox txtNoOfReels = (TextBox)gv.FindControl("txtNoOfReels");
            try
            {
                totNoOfRl = totNoOfRl + double.Parse(txtNoOfReels.Text);
            }
            catch { txtNoOfReels.Text = "0"; }
        }
        lblGSRPagePrint.Text = txtGSRPageNo.Text;
        lblReceiptPrint.Text = txtRecivedDate.Text;
        lblVehicleNoPrint.Text = txtTruckNo.Text.ToUpper();
        lblDamajReelPrint.Text = txtDefReel.Text;
        lblYear.Text = obCommonFuction.GetFinYear();
        lblReceiptReelPrint.Text = totNoOfRl.ToString();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string CheckSts;
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        DateTime DteCheck;
        string RptDate = "", GrDate = "", ReceivedDate = "";
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

        if (txtRecivedDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtRecivedDate.Text, cult);
            }
            catch { ReceivedDate = "NoDate"; }
        }
        if (ddlVendor.SelectedItem.Text == "Select" || ddlLOINo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
        }

        else if (txtChallanNo.Text == "" || txtChallanDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter challan information.');</script>");
        }
        else if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Challan Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct GR Date.');</script>");
        }
        else if (ReceivedDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Receive Date.');</script>");
        }

        else if (DateTime.Parse(txtRecivedDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Received date cannot greater than current date.');</script>");
        }
        else if (DateTime.Parse(txtChallanDate.Text, cult) > DateTime.Parse(txtRecivedDate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Received date can not be less then challan date.');</script>");
        }

        else
        {
            if (Request.QueryString["ID"] != null)
            {

                //This Code For Reel Entry
                string ChkRoleBx = "No";
                foreach (GridViewRow gv in GrdChallanReel.Rows)
                {
                    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

                    if (chkSelect.Checked == true)
                    {
                        ChkRoleBx = "Ok";
                    }
                }
                if (ChkRoleBx == "No")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select at least on Check Box of Reel.');</script>");
                }
                else
                {
                    obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate('',0,0,'',0,0,'" + txtChallanNo.Text + "'," + Depot_Id + ", " + ddlVendor.SelectedItem.Value.ToString() + ",'',0,'',0,1,0)");
                    CheckSts = "NotOk";
                    foreach (GridViewRow gv in GrdChallanReel.Rows)
                    {
                        Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                        Label lblRollNo = (Label)gv.FindControl("lblRollNo");
                        Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                        Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                        Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                        CheckBox chkDefectiveReel = (CheckBox)gv.FindControl("chkDefectiveReel");
                        if (chkSelect.Checked == true)
                        {
                            if (lblTotalSheets.Text == "0.00" || lblTotalSheets.Text == "0.0" || lblTotalSheets.Text == "0")
                            {
                                lblTotalSheets.Text = "1";
                            }

                            obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockSaveUpdate('" + chkDefectiveReel.Checked.ToString() + "'," + lblPaperMstrTrId_I.Text + "," + lblPaperType_I.Text + ", '" + lblRollNo.Text + "'," + lblNetWt.Text + "," + lblGrossWt.Text + ",'" + txtChallanNo.Text + "'," + Depot_Id + "," + ddlVendor.SelectedItem.Value.ToString() + ",'" + ddlAcYear.SelectedItem.Text + "',0,''," + ddlEmployee.SelectedValue + ",0," + lblTotalSheets.Text + ")");
                            CheckSts = "Ok";
                        }
                    }
                    if (CheckSts == "Ok")
                    {
                        CheckSts = "";

                        objPaperDispatchDetails.UserId_I = int.Parse(Depot_Id);
                        objPaperDispatchDetails.ReceivedDate = DateTime.Parse(txtRecivedDate.Text, cult);

                        objPaperDispatchDetails.GRNo = txtGrNo.Text;
                        objPaperDispatchDetails.GRDate = DateTime.Parse(txtGrDate.Text, cult);
                        objPaperDispatchDetails.GRNo = txtGrNo.Text;
                        objPaperDispatchDetails.GRDate = DateTime.Parse(txtGrDate.Text, cult);

                        objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);
                        objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);

                        objPaperDispatchDetails.WareHouseID_I = int.Parse(ddlWareHouse.SelectedItem.Value);
                        objPaperDispatchDetails.BlockNo = txtBlockNo.SelectedValue;

                        objPaperDispatchDetails.GSRPageNo = txtGSRPageNo.Text;
                        objPaperDispatchDetails.GSRSrNo = txtGSRSrNo.Text;
                        objPaperDispatchDetails.TransporterName = txtTransporterName.Text;
                        objPaperDispatchDetails.AcYear = ddlAcYear.SelectedItem.Text;
                        objPaperDispatchDetails.Remark = txtRemark.Text;

                        CheckSts = "NotOk";
                        string ChqQty = "";
                        foreach (GridViewRow gv in GrdWorkPlan.Rows)
                        {
                            TextBox txtRecivedQty = (TextBox)gv.FindControl("txtRecivedQty");
                            Label lblVdrSendQty = (Label)gv.FindControl("lblVdrSendQty");
                            if (txtRecivedQty.Text == "" || txtRecivedQty.Text == "0")
                            {
                                CheckSts = "BoxNotOk";
                            }
                            if (float.Parse(lblVdrSendQty.Text) < float.Parse(txtRecivedQty.Text))
                            {
                                ChqQty = "No";
                            }
                        }
                        if (CheckSts == "BoxNotOk")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter quantity.');</script>");
                        }
                        else if (ChqQty == "No")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Receive quantity exceed from send quantity.');</script>");
                        }
                        else
                        {
                            CheckSts = "NotOk";
                            foreach (GridViewRow gv in GrdWorkPlan.Rows)
                            {
                                Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");

                                Label lblDisDtl_Id = (Label)gv.FindControl("lblDisDtl_Id");
                                Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
                                TextBox txtRecivedQty = (TextBox)gv.FindControl("txtRecivedQty");
                                TextBox txtNoOfReels = (TextBox)gv.FindControl("txtNoOfReels");
                                objPaperDispatchDetails.NoOfReels = float.Parse(txtNoOfReels.Text);
                                objPaperDispatchDetails.DisDtl_Id = int.Parse(lblDisDtl_Id.Text);
                                objPaperDispatchDetails.DisTranId = int.Parse(lblDisTranId.Text);
                                objPaperDispatchDetails.ReqQty = float.Parse(txtRecivedQty.Text);

                                objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
                                objPaperDispatchDetails.PaperType_I = int.Parse(lblPaperType_I.Text);

                                if (txtDefReel.Text == "")
                                { txtDefReel.Text = "0"; }
                                if (txtDefWt.Text == "")
                                { txtDefWt.Text = "0"; }

                                objPaperDispatchDetails.DefReel = float.Parse(txtDefReel.Text);
                                objPaperDispatchDetails.DefWt = float.Parse(txtDefWt.Text);

                                objPaperDispatchDetails.DepotChallanChildInsert();
                                CheckSts = "Ok";
                            }

                        }
                        if (CheckSts == "Ok")
                        {
                            btnAddChallanDetails.Visible = true;
                            btnSave.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Saved successfully.');</script>");
                            try
                            {
                                MailHelper objSendSms = new MailHelper();
                                PPR_RDLCData objGetMobile = new PPR_RDLCData();
                                string Msg = "", DepotMoblNo = "";
                                //Usp_Get_SMS_MobileNo
                                ds = new DataSet();
                                ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
                                Msg = "Received as per Challan No : " + txtChallanNo.Text.Trim() + "  and date " + txtChallanDate.Text + " On " + txtRecivedDate.Text + " Date";
                                foreach (DataRow Dr in ds.Tables[0].Rows)
                                {
                                    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Paper")
                                    {
                                        objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                                    }
                                    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
                                    {
                                        objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                                    }

                                    if (Dr["Flag"].ToString() == "User" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Paper Vendor")
                                    {
                                        try
                                        {
                                            // Paper Vendor
                                            ds = new DataSet();
                                            DepotMoblNo = objGetMobile.GetMobileNoForSms("0", ddlVendor.SelectedItem.Value.ToString()).Tables[0].Rows[0]["MobileNo"].ToString();
                                        }
                                        catch { }
                                        objSendSms.sendMessage(DepotMoblNo, Msg);
                                    }
                                }
                            }
                            catch { }


                            if (Request.QueryString["ID"] != null)
                            {
                                //if (ViewState["ChkRcrd"].ToString() == "NewEntry")
                                //{ }
                                //else
                                //{
                                btnPrint.Visible = true;
                                Response.Redirect("ViewChallanDetails.aspx");
                                // }
                            }
                        }
                        //ddlLOINo.Enabled = true;
                        //ddlVendor.Enabled = true;
                    }
                }
            }
        }
    }
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void ddlPaperQlty_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    public void GridFill()
    {
        //try
        //{
        //    if (ddlLOINo.SelectedItem.Text != "Select")
        //    {
        //        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //        objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
        //        GrdWorkPlan.DataSource = objPaperDispatchDetails.GrWorkPlanFill();
        //        GrdWorkPlan.DataBind();
        //    }
        //}
        //catch { }
    }



    protected void GrdChallanReel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");


            Label lblRollNo = (Label)e.Row.FindControl("lblRollNo");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            CheckBox chkDefectiveReel = (CheckBox)e.Row.FindControl("chkDefectiveReel");
            /*
             ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(" + ddlVendor.SelectedItem.Value.ToString() + ",'" + txtChallanNo.Text + "','" + lblRollNo.Text + "',2)");
             if (ds.Tables[0].Rows.Count > 0)
             {
                 chkSelect.Checked = true;
             }
             else
             {
                 chkSelect.Checked = false;
             }
             ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(" + ddlVendor.SelectedItem.Value.ToString() + ",'" + txtChallanNo.Text + "','" + lblRollNo.Text + "',6)");
             if (ds.Tables[0].Rows.Count > 0)
             {
                 try
                 {
                     chkDefectiveReel.Checked = bool.Parse(ds.Tables[0].Rows[0][0].ToString());
                 }
                 catch
                 {
                     chkDefectiveReel.Checked = false;
                 }
             }
             else
             {
                 chkDefectiveReel.Checked = false;
             }
             CheckBox chkSave = (CheckBox)e.Row.Cells[2].FindControl("chkSelect");
             CheckBox chkBxSaveHeader = (CheckBox)this.GrdChallanReel.HeaderRow.FindControl("chkBxSaveHeader");
             chkSave.Attributes["onclick"] = string.Format("javascript:SaveChildClick(this,'{0}');", chkBxSaveHeader.ClientID);

             try
             {
                 TotSheetWt = TotSheetWt + double.Parse(lblTotalSheets.Text);
             }
             catch { }
             try
             {
                 TotNet = TotNet + double.Parse(lblNetWt.Text);
             }
             catch { }
             try
             {
                 TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text);
             }
             catch { }
             */
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFTotalSheets = (Label)e.Row.FindControl("lblFTotalSheets");
            Label lblFNetWt = (Label)e.Row.FindControl("lblFNetWt");
            Label lblFGrossWt = (Label)e.Row.FindControl("lblFGrossWt");

            lblFTotalSheets.Text = TotSheetWt.ToString("0.000");
            lblFNetWt.Text = TotNet.ToString("0.000");
            lblFGrossWt.Text = TotGrossWt.ToString("0.000");
        }
    }
    protected void txtRecivedQty_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow Gv = (GridViewRow)txt.NamingContainer;
        Label lblVdrSendQty = (Label)Gv.FindControl("lblVdrSendQty");

        string FirstVal = "";
        try
        {
            FirstVal = txt.Text.ToString().Substring(0, 1);
        }
        catch { }
        if (FirstVal == "-" || FirstVal == "0")
        {
            txt.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Quantity.');</script>");
        }
        else
        {
            if (float.Parse(txt.Text) > float.Parse(lblVdrSendQty.Text))
            {
                txt.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Receive Quantity exceed From Send Quantity.');</script>");
            }
        }
    }
    protected void txtNoOfReels_TextChanged(object sender, EventArgs e)
    {
        TextBox txt = (TextBox)sender;
        GridViewRow Gv = (GridViewRow)txt.NamingContainer;
        Label lblSndrReel = (Label)Gv.FindControl("lblSndrReel");
        string FirstVal = "";
        FirstVal = txt.Text.ToString().Substring(0, 1);

        if (FirstVal == "-" || FirstVal == "0")
        {
            txt.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Quantity.');</script>");
        }
        else
        {
            if (float.Parse(txt.Text) > float.Parse(lblSndrReel.Text))
            {
                txt.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Receive Reels exceed From Send Reels.');</script>");
            }
        }

    }
    protected void ddlWareHouse_Init(object sender, EventArgs e)
    {
        WareHouseId();
    }
}
