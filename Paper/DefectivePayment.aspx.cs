using MPTBCBussinessLayer.Paper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paper_DefectivePayment : System.Web.UI.Page
{
    DataSet ds;
    ppr_VoucharDetails objPaperVoucharDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string Depot_Id = "";
    double Amount2 = 0, Amount8 = 0, Amount90 = 0, Amount100 = 0, Weight = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserID"] == null)
        {
            Response.Redirect("~/login.aspx");
        }

            Depot_Id = Session["UserID"].ToString();
            if (!Page.IsPostBack)
            {
                fnvisibleCtrls(false);
                AutoSampleNo();
                if (Request.QueryString["ID"] != null)
                {
                    LabInvDtlFill();
                }

            }
       
      
    }
    public void AutoSampleNo()
    {
        objPaperVoucharDetails = new ppr_VoucharDetails();
        ds = objPaperVoucharDetails.ThabbaAutoGenSampleNo();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtVoucharNo.Text = "ThabbaV-No" + ds.Tables[0].Rows[0]["BillNo"].ToString();
        }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }

    private void fnvisibleCtrls(bool val)
    {
        trBankdetails1.Visible = val;
        trBankdetails2.Visible = val;
        trBankdetails3.Visible = val;
        trBankdetails4.Visible = val;
        //trBankdetails5.Visible = val;
    }

    public void LabInvDtlFill()
    {

        objPaperVoucharDetails = new ppr_VoucharDetails();
        objPaperVoucharDetails.Vouchar_Tr_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        hdnID.Value = objPaperVoucharDetails.Vouchar_Tr_Id.ToString();
        ds = objPaperVoucharDetails.ThabbaFiledFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            DateTime dte = new DateTime();
            dte = DateTime.Parse(ds.Tables[0].Rows[0]["VoucharDate"].ToString());
            txtVoucharDate.Text = dte.ToString("dd/MM/yyyy");
            txtVoucharNo.Text = ds.Tables[0].Rows[0]["VoucharNo"].ToString();
            txtNetAmt.Text = ds.Tables[0].Rows[0]["TotAmount"].ToString();
            txtWeight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();

            txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
            txtChequeNo.Text = ds.Tables[0].Rows[0]["ChequeNo"].ToString();
            txtChequeDate.Text = ds.Tables[0].Rows[0]["CqDate"].ToString();
            txtTotalThabba.Text = ds.Tables[0].Rows[0]["ThabbaWt"].ToString();
            txtChequeAmt.Text = txtNetAmt.Text;
            string status = ds.Tables[0].Rows[0]["Status"].ToString();

            //  ddlPer.ClearSelection();
            // ddlPer.Items.FindByText(ds.Tables[0].Rows[0]["Billper"].ToString()).Selected = true;

            VendorFill();
            ddlVendor.ClearSelection();
            ddlVendor.Items.FindByValue(ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true; ;
            ddlVendor.Enabled = false;

            LOIFill();
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
            ddlLOINo.Enabled = false;
            VoucherDtlBYLoi();

            
            if (int.Parse(status) == 2)
            {
                if (Request.QueryString["vw"] != null && Request.QueryString["vw"].ToString() == "1")
                {
                    fnvisibleCtrls(false);
                    btnSave.Visible = false;
                    btnSaveBankDetails.Visible = false;

                }
                else
                {
                    fnvisibleCtrls(true);
                    btnSave.Visible = false;
                    btnSaveBankDetails.Visible = true;
                }
            }
            else if(int.Parse(status) == 3)
            {
                fnvisibleCtrls(true);
                btnSave.Visible = false;
                btnSaveBankDetails.Visible = false;
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
           // ddlLOINo.DataSource = objPaperVoucharDetails.LOINoFill();
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
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIFill();
    }

    protected void btnSaveBankDetails_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime DteCheck;
            string CqeDate = "";

            if (txtChequeDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtChequeDate.Text, cult);
                }
                catch { CqeDate = "NoDate"; }
            }

            if (txtBankName.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Bank name.')", true);
                ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Bank name.');");
            }
            else if (txtChequeNo.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter cheque number.');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter cheque number.');");
            }
            else if (txtChequeDate.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter Cheque / Demand Draft Date.');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter Cheque / Demand Draft Date.');");
            }
            else if (CqeDate != "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter correct Cheque / Demand Draft Date.');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter correct Cheque / Demand Draft Date.');");
            }
            else if (txtRemark.Text == "")
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Please enter remark.');", true);
                ClientScript.RegisterStartupScript(this.GetType(), "msg11", "javascript:alert('Please enter remark.');");
            }
            else
            {

                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_PPR0019_Vouchar10PerDataShow_ppr_new(0,0,0,0,'" + hdnID.Value + "',11,'" + txtBankName.Text + "'" +
                           ",'" + (txtChequeDate.Text == "" ? DateTime.Parse("01/01/1900") : DateTime.Parse(txtChequeDate.Text, cult)).ToString("yyyy-MM-dd") + "','" + txtChequeNo.Text + "','" + txtRemark.Text + "')");

                int i = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                if (i > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    LabInvDtlFill();
                }
            }
        }
        catch
        {
        
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        objPaperVoucharDetails = new ppr_VoucharDetails();

        DateTime DteCheck;
        string RptDate = "", CqeDate = "";
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
        else if (txtNetAmt.Text == "" || txtNetAmt.Text == "0" || txtNetAmt.Text == "0.00")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
        }
        else if (txtWeight.Text == "" || txtWeight.Text == "0" || txtWeight.Text == "0.00")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Enter Weight.');</script>");
        }
        else if (decimal.Parse(txtNetAmt.Text) > decimal.Parse(lblRemAmount.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Net Amount exceed From Remaining Amount.');</script>");
        }
        else if (CqeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Cheque / Demand Draft Date.');</script>");
        }
        //else if (GrdWorkPlan.Rows.Count <= 0)
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Vouchar Detail Not found.');</script>");
        //}
        else
        {

            try
            {
                AutoSampleNo();
                if (Request.QueryString["ID"] == null)
                {
                    objPaperVoucharDetails.Vch_Trans_Id = 0;
                }
                else
                {
                    objPaperVoucharDetails.Vch_Trans_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                }
                objPaperVoucharDetails.Vouchar_Tr_Id = 0;
                objPaperVoucharDetails.VoucharNo = txtVoucharNo.Text;
                objPaperVoucharDetails.UserId_I = int.Parse(Session["UserID"].ToString());
                objPaperVoucharDetails.VoucharDate = DateTime.Parse(txtVoucharDate.Text, cult);
                objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedValue.ToString());
                objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedValue.ToString());

                objPaperVoucharDetails.Amount = decimal.Parse(txtNetAmt.Text.ToString());
                objPaperVoucharDetails.Remark = txtRemark.Text;
                objPaperVoucharDetails.Weight = float.Parse(txtWeight.Text);
                objPaperVoucharDetails.Thabba = decimal.Parse(txtTotalThabba.Text);

                objPaperVoucharDetails.BankName = txtBankName.Text;
                objPaperVoucharDetails.ChequeNo = txtChequeNo.Text;
                objPaperVoucharDetails.CqDate = (txtChequeDate.Text == "" ? DateTime.Parse("01/01/1900") : DateTime.Parse(txtChequeDate.Text, cult));

                int i = InsertUpdateThabbaSaveNew(objPaperVoucharDetails);
                //int i = objPaperVoucharDetails.InsertUpdateThabbaSave();
                if (i > 0)
                {
                    if (Request.QueryString["ID"] == null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                        obCommonFuction.EmptyTextBoxes(this);
                        lblRatePMT.Text = "";
                        GrdWorkPlan.DataSource = string.Empty;
                        GrdWorkPlan.DataBind();
                        lblActualWet.Text = "0";
                        lblTotWt.Text = "0";
                        lblPaidWt.Text = "0";
                        lblRemWt.Text = "0";
                        lblTotPaidAmount.Text = "0";
                        lblRemAmount.Text = "0";
                        lblThabba.Text = "0";
                        AutoSampleNo();
                        Response.Redirect("ViewDefectivePayment.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        Response.Redirect("ViewDefectivePayment.aspx");
                        ddlLOINo.Enabled = true;
                        ddlVendor.Enabled = true;
                    }

                }
            }
            catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Voucher No Already Exist.');</script>"); }
        }
    }
    protected void ddlPaperQlty_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

      protected void txtTotalThabba_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtTotalThabba.Text.ToString().Substring(0, 1);
        decimal TotThabba = 0, totAmt = 0;
        if (FirstVal == "-" || FirstVal == "0")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Weight.');</script>");
            try
            {
                TotThabba = decimal.Parse(txtTotalThabba.Text);
            }
            catch { TotThabba = 0; }
            try
            {
                txtWeight.Text = (decimal.Parse(lblThabba.Text) - TotThabba).ToString("0.00");
            }
            catch { txtWeight.Text = "0"; }
            try
            {
                totAmt=decimal.Parse(txtWeight.Text) * decimal.Parse(lblRatePMT.Text);
                txtNetAmt.Text = (totAmt * 90 / 100).ToString("0.00");
            }
            catch { txtNetAmt.Text = "0"; }
        }
        else
        {
            try
            {
                TotThabba = decimal.Parse(txtTotalThabba.Text);
            }
            catch { }
            try
            {
                txtWeight.Text = (decimal.Parse(lblThabba.Text) - TotThabba).ToString("0.00");
            }
            catch { txtWeight.Text = "0"; }
            try
            {
                totAmt = decimal.Parse(txtWeight.Text) * decimal.Parse(lblRatePMT.Text);
                txtNetAmt.Text = (totAmt * 90 / 100).ToString("0.00");
            }
            catch { txtNetAmt.Text = "0"; }
        }
    }
    //protected void txtWeight_TextChanged(object sender, EventArgs e)
    //{

    //    string FirstVal = "";
    //    FirstVal = txtWeight.Text.ToString().Substring(0, 1);
    //    decimal TotWt = 0, RateMt = 0, Amt = 0;
    //    if (FirstVal == "-" || FirstVal == "0")
    //    {
    //        txtWeight.Text = "";
    //        try
    //        {
    //            TotWt = decimal.Parse(txtWeight.Text);
    //        }
    //        catch { }
    //        try
    //        {
    //            RateMt = decimal.Parse(lblRatePMT.Text);
    //        }
    //        catch { }
    //        Amt = TotWt * RateMt;
    //        txtNetAmt.Text = Amt.ToString("0.00");
    //        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Weight.');</script>");
    //    }
    //    else
    //    {
    //        try
    //        {
    //            TotWt = decimal.Parse(txtWeight.Text);
    //        }
    //        catch { }
    //        try
    //        {
    //            RateMt = decimal.Parse(lblRatePMT.Text);
    //        }
    //        catch { }
    //        Amt = TotWt * RateMt;
    //        txtNetAmt.Text = Amt.ToString("0.00");
    //    }
    //}
     
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl100Amount = (Label)e.Row.FindControl("lbl100Amount");
            Label lblWeight = (Label)e.Row.FindControl("lblWeight");


            try
            {
                Amount100 = Amount100 + double.Parse(lbl100Amount.Text);
            }
            catch { Amount100 = 0; }
            try
            {
                Weight = Weight + double.Parse(lblWeight.Text);
            }
            catch { Weight = 0; }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblF100Amount = (Label)e.Row.FindControl("lblF100Amount");
            Label lblFWeight = (Label)e.Row.FindControl("lblFWeight");

            lblF100Amount.Text = Amount100.ToString("0.00");
            lblFWeight.Text = Weight.ToString("0.00");
        }
    }
    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        VoucherDtlBYLoi();
        //trBankDetails.Visible = true;
    }
    public void VoucherDtlBYLoi()
    {

        if (ddlVendor.SelectedItem.Text != "Select" && ddlLOINo.SelectedItem.Text != "Select")
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);

            ds = objPaperVoucharDetails.ThabbaVoucharDtlFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdWorkPlan.DataSource = ds.Tables[0];
                GrdWorkPlan.DataBind();
            }
            else
            {
                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                lblRatePMT.Text = ds.Tables[2].Rows[0]["Rate"].ToString();
            }
            else
            {
                lblRatePMT.Text = "0";
            }
            if (ds.Tables[1].Rows.Count > 0)
            {

                lblActualWet.Text = ds.Tables[1].Rows[0]["NetWt"].ToString();
                lblTotWt.Text = ds.Tables[1].Rows[0]["TotAllotment"].ToString();
                lblPaidWt.Text = ds.Tables[1].Rows[0]["TotWt"].ToString();
                lblRemWt.Text = ds.Tables[1].Rows[0]["TotRemaining"].ToString();
                lblTotPaidAmount.Text = ds.Tables[1].Rows[0]["TotPaidAmt"].ToString();

                lblThabba.Text = ds.Tables[1].Rows[0]["Thabba"].ToString();


                double TotWt = 0, RateTnd = 0;
                try
                {
                    TotWt = double.Parse(lblTotWt.Text);
                }
                catch { }

                try
                {
                    RateTnd = double.Parse(lblRatePMT.Text);
                }
                catch { }
                try
                {
                    lblRemAmount.Text = ((TotWt * RateTnd) - double.Parse(lblTotPaidAmount.Text)).ToString("0.00");
                }
                catch { }
                if (Request.QueryString["ID"] == null)
                {
                    txtTotalThabba.Text = lblThabba.Text;
                    txtWeight.Text = "0";
                    txtNetAmt.Text = "0";
                }
            }
            else
            {
                lblActualWet.Text = "0";
                lblTotWt.Text = "0";
                lblPaidWt.Text = "0";
                lblRemWt.Text = "0";
                lblTotPaidAmount.Text = "0";
                lblRemAmount.Text = "0";
                lblThabba.Text = "0";
                txtWeight.Text = "0";
                txtNetAmt.Text = "0";
            }

        }
        else
        {
            GrdWorkPlan.DataSource = string.Empty;
            GrdWorkPlan.DataBind();
            lblActualWet.Text = "0";
            lblTotWt.Text = "0";
            lblPaidWt.Text = "0";
            lblRemWt.Text = "0";
            lblTotPaidAmount.Text = "0";
            lblRemAmount.Text = "0";
            lblThabba.Text = "0";
            lblRatePMT.Text = "0";
        }

    }

    public int InsertUpdateThabbaSaveNew(ppr_VoucharDetails obj)
    {

        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0019_VoucharThabbaSaveData", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mVch_Trans_Id", obj.Vch_Trans_Id);
        obDBAccess.addParam("mVouchar_Tr_Id", obj.Vouchar_Tr_Id);
        obDBAccess.addParam("mVoucharNo", obj.VoucharNo);
        obDBAccess.addParam("mUserId_I", obj.UserId_I);
        obDBAccess.addParam("mVoucharDate", obj.VoucharDate);
        obDBAccess.addParam("mPaperVendorTrId_I", obj.PaperVendorTrId_I);
        obDBAccess.addParam("mLOITrId_I", obj.LOITrId_I);
        obDBAccess.addParam("mTotAmount", obj.Amount);
        obDBAccess.addParam("mRemark", obj.Remark);
        obDBAccess.addParam("mWeight", obj.Weight);
        obDBAccess.addParam("mBankName", obj.BankName);
        obDBAccess.addParam("mCqDate", obj.CqDate);
        obDBAccess.addParam("mChequeNo", obj.ChequeNo);
        obDBAccess.addParam("mThabbaWt", obj.Thabba);
        obDBAccess.addParam("mAcYear", ddlAcYear.SelectedItem.Text);
        int result = obDBAccess.executeMyQuery();
        return result;
    }
}