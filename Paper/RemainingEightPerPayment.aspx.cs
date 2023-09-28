using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class Paper_RemainingEightPerPayment : System.Web.UI.Page
{
    DataSet ds;
    ppr_VoucharDetails objPaperVoucharDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    string Depot_Id = "";
    double Amount2 = 0, Amount8 = 0, Amount90 = 0, Amount100 = 0, Weight = 0, Weight90 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        Depot_Id = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
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
        ds = objPaperVoucharDetails.Per10AutoGenSampleNo();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtVoucharNo.Text = "V-No" + ds.Tables[0].Rows[0]["BillNo"].ToString();
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
    public void LabInvDtlFill()
    {

        objPaperVoucharDetails = new ppr_VoucharDetails();
        objPaperVoucharDetails.Vouchar_Tr_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        ds = objPaperVoucharDetails.FiledFill90();
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

            if (ds.Tables[1].Rows.Count > 0)
            {
                gv90PerChallan.DataSource = ds.Tables[1];
                gv90PerChallan.DataBind();
            }
            else
            {
                gv90PerChallan.DataSource = ds.Tables[1];
                gv90PerChallan.DataBind();

            }
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
           // ddlLOINo.DataSource = objPaperVoucharDetails.LOINoFill();
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetLoiByVendorandAcYear(" + objPaperVoucharDetails.PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "')");
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
        else if (GrdWorkPlan.Rows.Count <= 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Vouchar Detail Not found.');</script>");
        }
        else if (CqeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Cheque / Demand Draft Date.');</script>");
        }
        else
        {

            try
            {
                string ChkCdt = "";
                foreach(GridViewRow rg in gv90PerChallan.Rows)
                {
                    CheckBox chkSelect = (CheckBox)rg.FindControl("chkSelect");
                    if(chkSelect.Checked==true)
                    {
                        ChkCdt = "Ok";
                    }
                }

                if (ChkCdt == "Ok")
                {
                   
                    if (Request.QueryString["ID"] == null)
                    {
                        AutoSampleNo();
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
                    objPaperVoucharDetails.BillPer = 0;//decimal.Parse(ddlPer.SelectedItem.Text.ToString());
                    objPaperVoucharDetails.Amount = decimal.Parse(txtNetAmt.Text.ToString());
                    objPaperVoucharDetails.Remark = txtRemark.Text;
                    objPaperVoucharDetails.Weight = float.Parse(txtWeight.Text);
                    objPaperVoucharDetails.Payment10 = 8;

                    objPaperVoucharDetails.BankName = txtBankName.Text;
                    objPaperVoucharDetails.ChequeNo = txtChequeNo.Text;
                    objPaperVoucharDetails.CqDate = (txtChequeDate.Text == "" ? DateTime.Parse("01/01/1900") : DateTime.Parse(txtChequeDate.Text, cult));
                    if (Request.QueryString["ID"] == null)
                    {
                        ds = objPaperVoucharDetails.InsertUpdate10Save();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            foreach (GridViewRow GV in gv90PerChallan.Rows)
                            {
                                Label lblVoucharNo = (Label)GV.FindControl("lblVoucharNo");
                                Label lblVouchar_Tr_Id = (Label)GV.FindControl("lblVouchar_Tr_Id");
                                objPaperVoucharDetails.Vch_10Trans_Id = int.Parse(ds.Tables[0].Rows[0]["Last_Id"].ToString());
                                objPaperVoucharDetails.Vouchar_90Tr_Id = int.Parse(lblVouchar_Tr_Id.Text);
                                objPaperVoucharDetails.VoucharNo = lblVoucharNo.Text;

                                CheckBox chkSelect = (CheckBox)GV.FindControl("chkSelect");
                                if (chkSelect.Checked == true)
                                {
                                    objPaperVoucharDetails.InsertUpdate10ChildSave();
                                }
                            }

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
                            Response.Redirect("ViewRemainingEightPerPayment.aspx");

                        }
                    }
                    else
                    {
                        ds = objPaperVoucharDetails.InsertUpdate10Save();

                        objPaperVoucharDetails.Vch_10Trans_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                        objPaperVoucharDetails.InsertUpdate10ChildDelete();
                        foreach (GridViewRow GV in gv90PerChallan.Rows)
                        {                          
                            Label lblVoucharNo = (Label)GV.FindControl("lblVoucharNo");
                            Label lblVouchar_Tr_Id = (Label)GV.FindControl("lblVouchar_Tr_Id");
                            objPaperVoucharDetails.VoucharNo = lblVoucharNo.Text;
                            objPaperVoucharDetails.Vouchar_90Tr_Id = int.Parse(lblVouchar_Tr_Id.Text);
                            CheckBox chkSelect = (CheckBox)GV.FindControl("chkSelect");
                            if (chkSelect.Checked == true)
                            {
                                objPaperVoucharDetails.InsertUpdate10ChildSave();
                            }
                        }
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        Response.Redirect("ViewRemainingEightPerPayment.aspx");
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
    protected void txtWeight_TextChanged(object sender, EventArgs e)
    {

        string FirstVal = "";
        FirstVal = txtWeight.Text.ToString().Substring(0, 1);
        decimal TotWt = 0, RateMt = 0, Amt = 0, TotPaid = 0;
        if (FirstVal == "-" || FirstVal == "0")
        {
            txtWeight.Text = "";
            try
            {
                TotWt = decimal.Parse(txtWeight.Text);
            }
            catch { }
            try
            {
                RateMt = decimal.Parse(lblRatePMT.Text);
            }
            catch { }
             

            try
            {
                TotPaid = ((TotWt) * 8 / 100);
                txtNetAmt.Text = (TotPaid * RateMt).ToString("0.00");
            }
            catch { txtNetAmt.Text = "0"; }


            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Weight.');</script>");
        }
        else
        {
            try
            {
                TotWt = decimal.Parse(txtWeight.Text);
            }
            catch { }
            try
            {
                RateMt = decimal.Parse(lblRatePMT.Text);
            }
            catch { }
            try
            {
                TotPaid = ((TotWt) * 8 / 100);
                txtNetAmt.Text = (TotPaid * RateMt).ToString("0.00");
            }
            catch { txtNetAmt.Text = "0"; }
        }
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


    protected void gv90PerChallan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lbl100Amount = (Label)e.Row.FindControl("lbl100Amount");
            Label lblWeight = (Label)e.Row.FindControl("lblWeight");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            if (Request.QueryString["ID"] != null)
            {
                chkSelect.Checked = true;
            }

            try
            {
                Amount90 = Amount90 + double.Parse(lbl100Amount.Text);
            }
            catch { Amount90 = 0; }
            try
            {
                Weight90 = Weight90 + double.Parse(lblWeight.Text);
            }
            catch { Weight90 = 0; }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblF100Amount = (Label)e.Row.FindControl("lblF100Amount");
            Label lblFWeight = (Label)e.Row.FindControl("lblFWeight");

            lblF100Amount.Text = Amount90.ToString("0.00");
            lblFWeight.Text = Weight90.ToString("0.00");
        }
    }
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
    }
    public void VoucherDtlBYLoi()
    {

        if (ddlVendor.SelectedItem.Text != "Select" && ddlLOINo.SelectedItem.Text != "Select")
        {
            objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objPaperVoucharDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);

            ds = objPaperVoucharDetails.Vouchar90DtlFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblRatePMT.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                GrdWorkPlan.DataSource = ds.Tables[0];
                GrdWorkPlan.DataBind();
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lblActualWet.Text = ds.Tables[1].Rows[0]["NetWt"].ToString();
                    lblTotWt.Text = ds.Tables[1].Rows[0]["TotAllotment"].ToString();
                    lblPaidWt.Text = ds.Tables[1].Rows[0]["TotWt"].ToString();
                    lblRemWt.Text = ds.Tables[1].Rows[0]["TotRemaining"].ToString();
                    lblTotPaidAmount.Text = ds.Tables[1].Rows[0]["TotPaidAmt"].ToString();

                    lblThabba.Text = ds.Tables[1].Rows[0]["Thabba"].ToString();
                }
                else
                {
                    lblActualWet.Text = "0";
                    lblTotWt.Text = "0";
                    lblPaidWt.Text = "0";
                    lblRemWt.Text = "0";
                    lblTotPaidAmount.Text = "0";
                    lblThabba.Text = "0";
                }
                if (Request.QueryString["ID"] == null)
                {
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        gv90PerChallan.DataSource = ds.Tables[2];
                        gv90PerChallan.DataBind();
                    }
                    else
                    {
                        gv90PerChallan.DataSource = ds.Tables[2];
                        gv90PerChallan.DataBind();

                    }
                }
                double TotWt = 0, RateTnd = 0,   TotPaid = 0;
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
                
            }
            else
            {

                gv90PerChallan.DataSource = string.Empty;
                gv90PerChallan.DataBind();

                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
                lblActualWet.Text = "0";
                lblTotWt.Text = "0";
                lblPaidWt.Text = "0";
                lblRemWt.Text = "0";
                lblTotPaidAmount.Text = "0";
                lblRemAmount.Text = "0";
                lblThabba.Text = "0";
            }
        }
        else
        {
            gv90PerChallan.DataSource = string.Empty;
            gv90PerChallan.DataBind();

            GrdWorkPlan.DataSource = string.Empty;
            GrdWorkPlan.DataBind();
            lblActualWet.Text = "0";
            lblTotWt.Text = "0";
            lblPaidWt.Text = "0";
            lblRemWt.Text = "0";
            lblTotPaidAmount.Text = "0";
            lblRemAmount.Text = "0";
            lblThabba.Text = "0";
        }

    }
    protected void chkSelect_CheckedChanged(object sender, EventArgs e)
    {
        double TotWt = 0, TotPaid = 0;
          
        foreach (GridViewRow gv in gv90PerChallan.Rows)
        { 
            CheckBox chkSelect= (CheckBox)gv.FindControl("chkSelect");
            Label lblWeight = (Label)gv.FindControl("lblWeight");
            if (chkSelect.Checked == true)
            {
                try
                {
                    TotWt = TotWt + double.Parse(lblWeight.Text);
                }
                catch { TotWt = 0; }
            }        
        }


        try
        {
            txtWeight.Text = TotWt.ToString("0.000");
        }
        catch { txtWeight.Text = "0"; }

        try
        {
            double Rate = 0;
            Rate = double.Parse(lblRatePMT.Text);
            TotPaid = (TotWt * 8) / 100;
            txtNetAmt.Text = (TotPaid * Rate).ToString("0.00");
        }
        catch { txtNetAmt.Text = "0"; }
    }
}
