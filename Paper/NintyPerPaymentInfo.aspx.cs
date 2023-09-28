using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer.Paper;
using System.Data;

public partial class Paper_NintyPerPaymentInfo : System.Web.UI.Page
{
    DataSet ds;
    ppr_VoucharDetails objPaperVoucharDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string Depot_Id = "";
    double Amount = 0, Weight = 0, NoOfReel = 0, DefReel = 0, MainWtCal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        fnvisibleCtrls(false);
        Depot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            AutoSampleNo();
            if (Request.QueryString["ID"] != null)
            {
                LabInvDtlFill();
            }

            if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "1")
            {
                HDNRedirect.Value = "~/EmployeeHome.aspx";
                btnSave.Visible = false;
            }
            else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "rpt")
            {
                HDNRedirect.Value = "~/VoucherBillRpt.aspx";
                btnSave.Visible = false;
            }
            else if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "e")
            {
                HDNRedirect.Value = "~/paper/ViewNintyPerPaymentInfo.aspx";                
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        //Response.Redirect("VIEW006_BillPayments.aspx");
        Response.Redirect(HDNRedirect.Value);
    }

    public void AutoSampleNo()
    {
        objPaperVoucharDetails = new ppr_VoucharDetails();
        ds = objPaperVoucharDetails.AutoGenSampleNo();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtVoucharNo.Text = "VCHNo" + ds.Tables[0].Rows[0]["BillNo"].ToString();
        }
    }

    private void fnvisibleCtrls(bool val)
    {
        trBankdetails1.Visible = val;
        trBankdetails2.Visible = val;
        trBankdetails3.Visible = val;
      
    }

    public void LabInvDtlFill()
    {

        objPaperVoucharDetails = new ppr_VoucharDetails();
        objPaperVoucharDetails.Vouchar_Tr_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        ds = objPaperVoucharDetails.FiledFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DateTime dte = new DateTime();
            dte = DateTime.Parse(ds.Tables[0].Rows[0]["VoucharDate"].ToString());
            txtVoucharDate.Text = dte.ToString("dd/MM/yyyy");
            txtVoucharNo.Text = ds.Tables[0].Rows[0]["VoucharNo"].ToString();
            lblRatePMT.Text = ds.Tables[0].Rows[0]["Rate"].ToString();

            txtTotWeight.Text = ds.Tables[0].Rows[0]["TotWt"].ToString();
            txtThabba.Text = ds.Tables[0].Rows[0]["Thabba"].ToString();
            txtNetWt.Text = ds.Tables[0].Rows[0]["NetWt"].ToString();
            txtPay100.Text =  ds.Tables[0].Rows[0]["NetWtPayment"].ToString();
             
            txtPay10.Text = ds.Tables[0].Rows[0]["Payment10"].ToString();
            txtPay90.Text = ds.Tables[0].Rows[0]["Payment90"].ToString();

            txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
            txtChequeNo.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
            txtChequeDate.Text = ds.Tables[0].Rows[0]["CqDate"].ToString();
            string status = ds.Tables[0].Rows[0]["Status"].ToString();
            if (status == "3")
            {
                fnvisibleCtrls(true);
            }
            else
            {
                fnvisibleCtrls(false);
            }


            VendorFill();
            ddlVendor.ClearSelection();
            ddlVendor.Items.FindByValue(ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true; ;
           // ddlVendor.Enabled = false;

            LOIFill();
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
           // ddlLOINo.Enabled = false;
            GrdWorkPlan.DataSource = ds.Tables[0];
            GrdWorkPlan.DataBind();
            foreach (GridViewRow gv in GrdWorkPlan.Rows)
            {
                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                chkSelect.Checked = true;
             //   chkSelect.Enabled = false;
            }

            if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "1")
            {
                btnSave.Visible = false;
                
            }
        }

    }
    public void VendorFill()
    {
        objPaperVoucharDetails = new ppr_VoucharDetails();
        ddlVendor.DataSource = objPaperVoucharDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        VendorFill();
    }
    public void LOIFill()
    {
        if (ddlVendor.SelectedItem.Text != "Select")
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetLoiByVendorandAcYear(" + objPaperVoucharDetails.PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "')");
            //ddlLOINo.DataSource = objPaperVoucharDetails.LOINoFill();
            ddlLOINo.DataSource = ds1.Tables[0];

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
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            //ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            //ddlAcYear.DataTextField = "AcYear";
            //ddlAcYear.DataBind();
            //ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");

            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataValueField = "AcYear";
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
        }
        catch { }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIFill();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string CheckSts;
        objPaperVoucharDetails = new ppr_VoucharDetails();

        DateTime DteCheck;
        string RptDate = "",CqeDate = "";;
        if (txtVoucharDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtVoucharDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtChequeDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtChequeDate.Text, cult);
            }
            catch { CqeDate = "NoDate"; }
        }
          
            
        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Voucher Date.');</script>");
        }
        else if (DateTime.Parse(txtVoucharDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Voucher date cannot greater than current date.');</script>");
        }
        else if (ddlVendor.SelectedItem.Text == "Select" || ddlLOINo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
        }

        else if (txtVoucharNo.Text == "" || txtVoucharDate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter voucher information.');</script>");
        }
        else if (lblRatePMT.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('No Record Found.');</script>");
        }
        else if (txtPay90.Text == "" || txtPay90.Text == "0" || txtPay90.Text == "0.00")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Enter 90% Amount To Be Paid.');</script>");
        }
        else if (CqeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Cheque / Demand Draft Date.');</script>");
        }
        else
        {
            if (Request.QueryString["ID"] == null)
            { 
              //  AutoSampleNo();
                objPaperVoucharDetails.Vouchar_Tr_Id = 0;
                objPaperVoucharDetails.VoucharNo = txtVoucharNo.Text;
                objPaperVoucharDetails.Depot_Id = int.Parse(Depot_Id);
                objPaperVoucharDetails.VoucharDate = DateTime.Parse(txtVoucharDate.Text, cult);
                objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedValue.ToString());
                objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedValue.ToString());
                try
                {
                    objPaperVoucharDetails.Rate = float.Parse(lblRatePMT.Text);
                }
                catch { objPaperVoucharDetails.Rate = 0; }

                objPaperVoucharDetails.TotWt = float.Parse(txtTotWeight.Text);
                objPaperVoucharDetails.Thabba = decimal.Parse(txtThabba.Text);
                objPaperVoucharDetails.NetWt = decimal.Parse(txtNetWt.Text);
                objPaperVoucharDetails.NetWtPayment = decimal.Parse(txtPay100.Text);
                objPaperVoucharDetails.Payment10 = decimal.Parse(txtPay10.Text);
                objPaperVoucharDetails.Payment90 = decimal.Parse(txtPay90.Text);
                


                objPaperVoucharDetails.BankName = txtBankName.Text;
                objPaperVoucharDetails.ChequeNo = txtChequeNo.Text;
                objPaperVoucharDetails.CqDate = (txtChequeDate.Text == "" ? DateTime.Parse("01/01/1900") : DateTime.Parse(txtChequeDate.Text, cult));


                string CheckSaveSts = "NotOk";
                foreach (GridViewRow gv in GrdWorkPlan.Rows)
                {
                    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                    if (chkSelect.Checked == true)
                    {
                        CheckSaveSts = "Ok";

                    }
                }
                if (CheckSaveSts == "Ok")
                {
                    try
                    {
                        int i = objPaperVoucharDetails.InsertUpdate();
                        if (i > 0)
                        {
                            CommonFuction obj = new CommonFuction();
                            obj.FillDatasetByProc("call VoucherUpdate_12PerIGST(" + Convert.ToDecimal(lblCost.Text) + "," + Convert.ToDecimal(lblIGST.Text) + "," + Convert.ToDecimal(lblIGSTTDS.Text) + "," + Convert.ToDecimal(txtNetPay.Text) + "," + int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString())) + ")");
                            CheckSts = "NotOk";
                            foreach (GridViewRow gv in GrdWorkPlan.Rows)
                            {
                                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                                if (chkSelect.Checked == true)
                                {
                                    Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
                                    Label lblChallanNo = (Label)gv.FindControl("lblChallanNo");
                                    Label lblChallanDate = (Label)gv.FindControl("lblChallanDate");
                                    Label lblGRNo = (Label)gv.FindControl("lblGRNo");
                                    Label lblGrDate = (Label)gv.FindControl("lblGrDate");
                                    Label lblReceivedDate = (Label)gv.FindControl("lblReceivedDate");
                                    Label lblNoOfReel = (Label)gv.FindControl("lblNoOfReel");
                                    Label lblWeight = (Label)gv.FindControl("lblWeight");
                                    Label lblAmount = (Label)gv.FindControl("lblAmount");

                                    objPaperVoucharDetails.Vouchar_Child_Id = 0;
                                    objPaperVoucharDetails.Vouchar_Tr_Id = i;
                                    objPaperVoucharDetails.DisTranId = int.Parse(lblDisTranId.Text);
                                    objPaperVoucharDetails.ChallanNo = lblChallanNo.Text;
                                    objPaperVoucharDetails.ChallanDate = DateTime.Parse(lblChallanDate.Text, cult);
                                    objPaperVoucharDetails.ReceivedDate = DateTime.Parse(lblReceivedDate.Text, cult);
                                    objPaperVoucharDetails.GRNo = lblGRNo.Text;
                                    objPaperVoucharDetails.GRDate = DateTime.Parse(lblGrDate.Text, cult);
                                    objPaperVoucharDetails.NoOfReel = float.Parse(lblNoOfReel.Text);
                                    objPaperVoucharDetails.Weight = float.Parse(lblWeight.Text);
                                    objPaperVoucharDetails.Amount = decimal.Parse(lblAmount.Text);
                                    

                                    objPaperVoucharDetails.ChildInsertUpdate();
                                    CheckSts = "Ok";
                                }

                            }
                            if (CheckSts == "Ok")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                                Response.Redirect("ViewNintyPerPaymentInfo.aspx");
                                ddlLOINo.Enabled = true;
                                ddlVendor.Enabled = true;
                            }
                        }
                    }
                    catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Voucher No Already Exist.');</script>"); }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select Al least one check box.');</script>");
                }
            }
            else
            {
                objPaperVoucharDetails.Vouchar_Tr_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                objPaperVoucharDetails.VoucharNo = txtVoucharNo.Text;
                objPaperVoucharDetails.Depot_Id = int.Parse(Depot_Id);
                objPaperVoucharDetails.VoucharDate = DateTime.Parse(txtVoucharDate.Text, cult);
                objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedValue.ToString());
                objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedValue.ToString());
                objPaperVoucharDetails.Rate = 0;
                objPaperVoucharDetails.TotWt = float.Parse(txtTotWeight.Text);
                objPaperVoucharDetails.Thabba = decimal.Parse(txtThabba.Text);
                objPaperVoucharDetails.NetWt = decimal.Parse(txtNetWt.Text);
                objPaperVoucharDetails.NetWtPayment = decimal.Parse(txtPay100.Text);
                objPaperVoucharDetails.Payment10 = decimal.Parse(txtPay10.Text);
                objPaperVoucharDetails.Payment90 = decimal.Parse(txtPay90.Text);

                objPaperVoucharDetails.BankName = txtBankName.Text;
                objPaperVoucharDetails.ChequeNo = txtChequeNo.Text;
                objPaperVoucharDetails.CqDate = (txtChequeDate.Text == "" ? DateTime.Parse("01/01/1900") : DateTime.Parse(txtChequeDate.Text, cult));
                try
                {
                    int i = objPaperVoucharDetails.InsertUpdate();

                    if (i > 0)
                    {
                        CommonFuction obj = new CommonFuction();
                        //obj.FillDatasetByProc("call VoucherUpdate_12PerIGST(" + Convert.ToDecimal(lblCost.Text) + "," + lblIGST.Text + "," + lblIGSTTDS.Text + "," + txtNetPay.Text + "," + i + ")");
                        obj.FillDatasetByProc("call VoucherUpdate_12PerIGST(" + Convert.ToDecimal(lblCost.Text) + "," + Convert.ToDecimal(lblIGST.Text) + "," + Convert.ToDecimal(lblIGSTTDS.Text) + "," + Convert.ToDecimal(txtNetPay.Text) + "," + int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString())) + ")");
                        
                        foreach (GridViewRow gv in GrdWorkPlan.Rows)
                        {
                            CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                            if (chkSelect.Checked == true)
                            {
                                Label lblDisTranId = (Label)gv.FindControl("lblDisTranId");
                                Label lblChallanNo = (Label)gv.FindControl("lblChallanNo");
                                Label lblChallanDate = (Label)gv.FindControl("lblChallanDate");
                                Label lblGRNo = (Label)gv.FindControl("lblGRNo");
                                Label lblGrDate = (Label)gv.FindControl("lblGrDate");
                                Label lblReceivedDate = (Label)gv.FindControl("lblReceivedDate");
                                Label lblNoOfReel = (Label)gv.FindControl("lblNoOfReel");
                                Label lblWeight = (Label)gv.FindControl("lblWeight");
                                Label lblAmount = (Label)gv.FindControl("lblAmount");

                                objPaperVoucharDetails.Vouchar_Child_Id = 0;
                                objPaperVoucharDetails.Vouchar_Tr_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString())); 
                                objPaperVoucharDetails.DisTranId = int.Parse(lblDisTranId.Text);
                                objPaperVoucharDetails.ChallanNo = lblChallanNo.Text;
                                objPaperVoucharDetails.ChallanDate = DateTime.Parse(lblChallanDate.Text, cult);
                                objPaperVoucharDetails.ReceivedDate = DateTime.Parse(lblReceivedDate.Text, cult);
                                objPaperVoucharDetails.GRNo = lblGRNo.Text;
                                objPaperVoucharDetails.GRDate = DateTime.Parse(lblGrDate.Text, cult);
                                objPaperVoucharDetails.NoOfReel = float.Parse(lblNoOfReel.Text);
                                objPaperVoucharDetails.Weight = float.Parse(lblWeight.Text);
                                objPaperVoucharDetails.Amount = decimal.Parse(lblAmount.Text);

                                objPaperVoucharDetails.ChildInsertUpdate();
                                CheckSts = "Ok";
                            }

                        }

                        Response.Redirect("ViewNintyPerPaymentInfo.aspx");
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Voucher No Already Exist.');</script>"); }
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
        //    if (ddlLOINo.SelectedItem.Text != "Select")
        //    {
        //        objPaperVoucharDetails = new ppr_VoucharDetails();
        //        objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
        //        GrdWorkPlan.DataSource = objPaperVoucharDetails.GrWorkPlanFill();
        //        GrdWorkPlan.DataBind();
        //    }
        //}
        //catch { }
    }

    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        double TotWt = 0, DefectiveReel = 0, MainTotDeftivReel = 0;
        MainWtCal = 0;
         
        CheckBox chek = (CheckBox)sender;
        GridViewRow gv = (GridViewRow)chek.NamingContainer;
        Label lblWeight = (Label)gv.FindControl("lblWeight");
        Label lblDefReel = (Label)gv.FindControl("lblDefReel");
        try
        {
            TotWt = double.Parse(txtTotWeight.Text);
        }
        catch { TotWt = 0; }
        try
        {
            MainTotDeftivReel = double.Parse(txtThabba.Text);
        }
        catch { MainTotDeftivReel = 0; }
        if (chek.Checked == true)
        {
            try
            {
                MainWtCal = double.Parse(lblWeight.Text);
            }
            catch { }
            TotWt = TotWt + MainWtCal;
            txtTotWeight.Text = TotWt.ToString("#,##0.000");


            try
            {
                DefectiveReel = double.Parse(lblDefReel.Text);
            }
            catch { }
            MainTotDeftivReel = MainTotDeftivReel + DefectiveReel;
            txtThabba.Text = MainTotDeftivReel.ToString("#,##0.000");
        }
        if (chek.Checked == false)
        {
            try
            {
                MainWtCal = double.Parse(lblWeight.Text);
            }
            catch { }
            TotWt = TotWt - MainWtCal;
            txtTotWeight.Text = TotWt.ToString("#,##0.000");
            try
            {
                DefectiveReel = double.Parse(lblDefReel.Text);
            }
            catch { }
            MainTotDeftivReel = MainTotDeftivReel - DefectiveReel;
            txtThabba.Text = MainTotDeftivReel.ToString("#,##0.000");
        }
        CalAmt();
    }

    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            Label lblChallanDate = (Label)e.Row.FindControl("lblChallanDate");
            Label lblGrDate = (Label)e.Row.FindControl("lblGrDate");
            Label lblReceivedDate = (Label)e.Row.FindControl("lblReceivedDate");
            Label lblDefReel = (Label)e.Row.FindControl("lblDefReel");

            Label lblNoOfReel = (Label)e.Row.FindControl("lblNoOfReel");
            Label lblWeight = (Label)e.Row.FindControl("lblWeight");
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");

            try
            {
                DefReel = DefReel + double.Parse(lblDefReel.Text);
            }
            catch { DefReel = 0; }
            try
            {
                Amount = Amount + double.Parse(lblAmount.Text);
            }
            catch { Amount = 0; }
            try
            {
                Weight = Weight + double.Parse(lblWeight.Text);
            }
            catch { Weight = 0; }
            try
            {
                NoOfReel = NoOfReel + double.Parse(lblNoOfReel.Text);
            }
            catch { NoOfReel = 0; }
            if (chkSelect.Checked == true)
            {
                try
                {
                    MainWtCal = MainWtCal + double.Parse(lblWeight.Text);
                }
                catch { MainWtCal = 0; }
            }

            DateTime Dte = new DateTime();
           // Dte = DateTime.Parse(lblChallanDate.Text);
            //lblChallanDate.Text = Dte.ToString("dd/MM/yyyy");
            try
            {
                Dte = DateTime.Parse(lblGrDate.Text);
                lblGrDate.Text = Dte.ToString("dd/MM/yyyy");
            }
            catch { }
            //Dte = DateTime.Parse(lblReceivedDate.Text);
           // lblReceivedDate.Text = Dte.ToString("dd/MM/yyyy");
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFDefReel = (Label)e.Row.FindControl("lblFDefReel");
            Label lblFNoOfReel = (Label)e.Row.FindControl("lblFNoOfReel");
            Label lblFWeight = (Label)e.Row.FindControl("lblFWeight");
            Label lblFAmount = (Label)e.Row.FindControl("lblFAmount");
            lblFNoOfReel.Text = NoOfReel.ToString();
            lblFDefReel.Text = DefReel.ToString();
            lblFWeight.Text = Weight.ToString("#,##0.000");
            lblFAmount.Text = Amount.ToString("#,##0.000");
            lblAmountM.Text = Amount.ToString("#,##0");
            lblCost.Text = (Convert.ToDouble(Amount)*(100.0/112.0)).ToString("#,##0");
            lblIGST.Text = (Convert.ToDouble(lblAmountM.Text) - Convert.ToDouble(lblCost.Text)).ToString("#,##0");
            lblIGSTTDS.Text = (Math.Round(Convert.ToDouble(lblCost.Text) * (2.0 / 100.0))).ToString("#,##0");
            txtTDSGST.Text = lblIGSTTDS.Text;
            try { 
            txtNetPay.Text = (Convert.ToDouble(txtPay90.Text) - Convert.ToDouble(lblIGSTTDS.Text)).ToString("#,##0");
            }
            catch {txtNetPay.Text =lblIGSTTDS.Text; }
            //txtTotWeight.Text = MainWtCal.ToString("0.00");
           // CalAmt();
        }
    }
    public void CalAmt()
    {
        decimal TotWt = 0, thabba = 0, NetWt = 0, Pay100 = 0, Pay10 = 0, Pay90 = 0;
        try
        {
            TotWt = decimal.Parse(txtTotWeight.Text);
        }
        catch { }
        if (TotWt != 0 || TotWt != decimal.Parse("0.00"))
        {
            try
            {
                thabba = decimal.Parse(txtThabba.Text);
            }
            catch { }
            try
            {
                NetWt = TotWt - thabba;
            }
            catch { }
            txtNetWt.Text = NetWt.ToString("#,##0.000");

            try
            {
                Pay100 = NetWt * decimal.Parse(lblRatePMT.Text);
            }
            catch { }
            txtPay100.Text = Pay100.ToString("#,##0.000");
            try
            {
                Pay10 = Pay100 * 10 / 100;
            }
            catch { }
            txtPay10.Text = Pay10.ToString("0.00");
            try
            {
                Pay90 = Pay100 * 90 / 100;

            }
            catch { }
            txtPay90.Text = Pay90.ToString("#,##0");
            txtNetPay.Text = (decimal.Parse(txtPay90.Text) - decimal.Parse(txtTDSGST.Text)).ToString("#,##0");
        }
        else
        {
            txtNetWt.Text = "0";
            txtPay100.Text = "0";
            txtPay10.Text = "0";
            txtPay90.Text = "0";
        }
    }
    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVendor.SelectedItem.Text != "Select" && ddlLOINo.SelectedItem.Text != "Select")
        {
            MainWtCal = 0;
            txtTotWeight.Text = "0";
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);
             
            ds = objPaperVoucharDetails.ChallanFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblRatePMT.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                GrdWorkPlan.DataSource = ds.Tables[0];
                GrdWorkPlan.DataBind();
            }
            else
            {
                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
            }
        }
        else
        {
            GrdWorkPlan.DataSource = string.Empty;
            GrdWorkPlan.DataBind();
        }

        DataTable ds1 = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "',0,-3)");
        ddlGSM.DataSource = ds1;
        ddlGSM.DataTextField = "CoverInformation";
        ddlGSM.DataValueField = "PaperMstrTrID_I";
        ddlGSM.DataBind();
        ddlGSM.Items.Insert(0, "Select");
    }
    protected void txtThabba_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtThabba.Text.ToString().Substring(0, 1);
        if (FirstVal == "-")
        {
            txtThabba.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Weight.');</script>");
            CalAmt();
        }
        else
        {
            CalAmt();
        }
    }
    protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVendor.SelectedItem.Text != "Select" && ddlLOINo.SelectedItem.Text != "Select")
        {

            MainWtCal = 0;
            txtTotWeight.Text = "0";
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objPaperVoucharDetails.DisTranId = int.Parse(ddlGSM.SelectedItem.Value);
            objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);

            DataTable ds1 = obCommonFuction.FillTableByProc("call USP_PPR0018_VoucharDataShow('" + objPaperVoucharDetails.PaperVendorTrId_I + "'," + objPaperVoucharDetails.DisTranId + ", 0," + objPaperVoucharDetails.LOITrId_I + ",0, 2)");

            // ds = objPaperVoucharDetails.ChallanFill();
            // if (ds.Tables[0].Rows.Count > 0)
            //{
            try
            {
                lblRatePMT.Text = ds1.Rows[0]["Rate"].ToString();
                GrdWorkPlan.DataSource = ds1;
                GrdWorkPlan.DataBind();
            }
            catch
            {
                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
            }
        }
        else
        {
            GrdWorkPlan.DataSource = string.Empty;
            GrdWorkPlan.DataBind();
        }
             
         
    }
}
