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

public partial class Paper_CommercialBid : System.Web.UI.Page
{
    DataSet ds;
    PPR_TenderEvaluation objTenderEvaluation = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
  public int Count=0;
    Double amounta, amounta2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           // DataSet ds = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYear_Active(0)");
            lblAcYear.Text = ds.Tables[0].Rows[0][1].ToString();
          //  lblAcYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            if (Request.QueryString["ID"] != null)
            {

            }
        }
    }
    public void TenderDtlFill()
    {
        if (Request.QueryString["ID"] != null)
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
            objTenderEvaluation.TenderTrId_I = 0;
            //ddlTenderType.DataSource = objTenderEvaluation.TenderSelect();
            ddlTenderType.DataSource = obCommonFuction.FillDatasetByProc("call USP_ppr_TechniBidSearch('','',9)"); 
            ddlTenderType.DataTextField = "TenderNo_V";
            ddlTenderType.DataValueField = "TenderTrId_I";
            ddlTenderType.DataBind();
            ddlTenderType.Items.Insert(0, "Select");
            ddlTenderType.Items.FindByValue(objdb.Decrypt(Request.QueryString["ID"].ToString())).Selected = true;
            ddlTenderType.Enabled = false;
            // VenderFill();
            TenderDtlFillById();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            ds = objTenderEvaluation.CheckEvalution();
            if (ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                GridEvalutionFillLoad();
                btnEvalution.Visible = false;
                trTenderEvl.Visible = false;
            }

            if (GrdTenderEvaluation.Rows.Count > 0)
            {
                btnEvalution.Visible = true;
                trTenderEvl.Visible = true;
            }
            else
            {
                btnEvalution.Visible = false;
                trTenderEvl.Visible = false;
            }
        }
        else
        {
           
            //objTenderEvaluation = new PPR_TenderEvaluation();
            //objTenderEvaluation.TenderTrId_I = 0;
            ddlTenderType.DataSource = ddlTenderType.DataSource = obCommonFuction.FillDatasetByProc("call USP_ppr_TechniBidSearch('','',6)");//objTenderEvaluation.TenderSelect();
            ddlTenderType.DataTextField = "TenderNo_V";
            ddlTenderType.DataValueField = "TenderTrId_I";
            ddlTenderType.DataBind();
            ddlTenderType.Items.Insert(0, "Select");
        }
    }
    protected void ddlTenderType_Init(object sender, EventArgs e)
    {
        TenderDtlFill();
    }
    public void TenderDtlFillById()
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {

            GridFillLoad();
            VenderFill();
            objTenderEvaluation = new PPR_TenderEvaluation();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            ds = objTenderEvaluation.TenderSelect();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime SubDt = new DateTime();

                dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
                Label1.Text = ds.Tables[0].Rows[0]["RqcQuantity"].ToString(); 
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
                lblTenderDt.Text = dat.ToString("dd/MM/yyyy");
                lblSubDt.Text = SubDt.ToString("dd/MM/yyyy");
                lblTenderDtl.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
                lblEMd.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
                lblTenderWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
                lblTenderType.Text = ds.Tables[0].Rows[0]["TenderType_V"].ToString();
                lblTenderNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
                lblTenderFee.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();
                txtCommTime.Text = ds.Tables[0].Rows[0]["CommTime"].ToString();
                txtTechnicalTime.Text = ds.Tables[0].Rows[0]["TechTime"].ToString(); 
                try
                {
                    try
                    {
                        SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
                        txtCommercialBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                    }
                    catch { }

                    SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TechDate"].ToString());
                    txtTechnicalBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                }
                catch { }
                
                txtTechnicalBidDate.Enabled = false;

            }
            else
            {
                lblTenderDt.Text = "";
                lblSubDt.Text = "";
                lblTenderDtl.Text = "";
                lblEMd.Text = "";
                lblTenderWork.Text = "";
                lblTenderType.Text = "";
                lblTenderNo.Text = "";
                lblTenderFee.Text = "";
            }
        }
        else
        {
            lblTenderDt.Text = "";
            lblSubDt.Text = "";
            lblTenderDtl.Text = "";
            lblEMd.Text = "";
            lblTenderWork.Text = "";
            lblTenderType.Text = "";
            lblTenderNo.Text = "";
            lblTenderFee.Text = "";
        }
    }
    protected void ddlTenderType_SelectedIndexChanged(object sender, EventArgs e)
    {
        TenderDtlFillById();
    }
    public void GridFillLoad()
    {
        try
        {
            if (ddlTenderType.SelectedItem.Text != "Select")
            {
                DataSet DSS;
                objTenderEvaluation = new PPR_TenderEvaluation();
                objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
                DSS = objTenderEvaluation.Select();
                GrdTenderEvaluation.DataSource = DSS.Tables[0];
                GrdTenderEvaluation.DataBind();

                if (GrdTenderEvaluation.Rows.Count > 0)
                {
                    btnEvalution.Visible = true;
                    trTenderEvl.Visible = true;
                }
                else
                {
                    btnEvalution.Visible = false;
                    trTenderEvl.Visible = false;

                }
                if (DSS.Tables[0].Rows.Count > 0)
                {
                    //if (DSS.Tables[0].Rows[0]["EvalutionType"].ToString() != "")
                    //{
                    //    ddlEvelutionType.ClearSelection();
                    //    try
                    //    {
                    //        ddlEvelutionType.Items.FindByText(DSS.Tables[0].Rows[0]["EvalutionType"].ToString()).Selected = true;
                    //        ddlEvelutionType.Enabled = false;
                    //    }
                    //    catch { }
                    //}

                    //DateTime SubDt = new DateTime();

                    //if (DSS.Tables[0].Rows.Count > 0)
                    //{
                    //    SubDt = DateTime.Parse(DSS.Tables[0].Rows[0]["TechnicalDate"].ToString());
                    //    txtTechnicalBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                    //    txtTechnicalBidDate.Enabled = false;

                    //    SubDt = DateTime.Parse(DSS.Tables[0].Rows[0]["TenderEvaluationDate_D"].ToString());
                    //    txtCommercialBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                    //    txtCommercialBidDate.Enabled = false;
                    //}
                    //else
                    //{
                    //    txtTechnicalBidDate.Text = "";
                    //    txtCommercialBidDate.Text = "";
                    //}
                }
            }
        }
        catch { }

    }
    public void GridEvalutionFillLoad()
    {
        try
        {
            if (ddlTenderType.SelectedItem.Text != "Select")
            {
                DataSet DSAll = new DataSet();

                objTenderEvaluation = new PPR_TenderEvaluation();
                objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
                DSAll = objTenderEvaluation.EvalutionSelectWithType("");
                GVEvaluation.DataSource = DSAll.Tables[0];
                GVEvaluation.DataBind();
                txtDistanceKm.Text = DSAll.Tables[0].Rows[0]["DisKm"].ToString();
                if (GVEvaluation.Rows.Count > 0)
                {
                   // trKm.Visible = true;
                    btnSave.Visible = true;
                }
                else
                {
                   // trKm.Visible = false;
                    btnSave.Visible = false;
                }
                
            }
        }
        catch { }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {


        DateTime DteCheck, CommDteCheck;
        string RptDate = "", CommDate = "";
        if (txtTechnicalBidDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtTechnicalBidDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtCommercialBidDate.Text != "")
        {
            try
            {
                CommDteCheck = DateTime.Parse(txtCommercialBidDate.Text, cult);
            }
            catch { CommDate = "NoDate"; }
        }
        if (txtTechnicalBidDate.Text == "")
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter technical Date.');</script>");
            lblMsg.Text = "Please enter technical Date.";
        }
        else if (txtCommercialBidDate.Text == "")
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Commercial Date.');</script>");
            lblMsg.Text = "Please enter Commercial Date.";
        }
        else if (RptDate != "")
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct technical Date.');</script>");
            lblMsg.Text = "Please enter correct technical Date.";
        }
        else if (CommDate != "")
        {
         //   ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Commercial Date.');</script>");
            lblMsg.Text = "Please enter correct Commercial Date.";
        }
        else if (DateTime.Parse(txtCommercialBidDate.Text, cult) < DateTime.Parse(txtTechnicalBidDate.Text, cult))
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be greater then Commercial date.');</script>");
            lblMsg.Text = "Technical date can not be greater then Commercial date.";
        }
        else if (ddlTenderType.SelectedItem.Text == "Select")
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
            lblMsg.Text = "Please select tender no.";
        }
        else if (ddlVenderFill.SelectedItem.Text == "Select")
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select company name.');</script>");
            lblMsg.Text = "Please select company name.";
        }
        else if (txtTotalAmt.Text == "" || txtTotalAmt.Text == "0" || txtTotalAmt.Text == "0.00")
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Enter Amount.');</script>");
            lblMsg.Text = "Please Enter Amount.";
        }
        else
        {
            lblMsg.Text = "";
            objTenderEvaluation = new PPR_TenderEvaluation();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            objTenderEvaluation.Venderid_I = int.Parse(ddlVenderFill.SelectedItem.Value.ToString());
            objTenderEvaluation.Qualify_Sts_V = ddlStatus.SelectedItem.Text.Trim();
            objTenderEvaluation.BidRate_N = 0;


            objTenderEvaluation.TenderEvaluationDate_D = DateTime.Parse(txtCommercialBidDate.Text, cult);
            objTenderEvaluation.TechnicalDate = DateTime.Parse(txtTechnicalBidDate.Text, cult);
            try
            {
                objTenderEvaluation.CommDate = DateTime.Parse(txtCommercialBidDate.Text, cult);
            }
            catch { }
            objTenderEvaluation.CommTime = txtCommTime.Text;
            try
            {
                objTenderEvaluation.BasicRate = Decimal.Parse(txtBasicRate.Text);
            }
            catch { objTenderEvaluation.BasicRate = 0; }
            try
            {
                objTenderEvaluation.ExciseDuty = Decimal.Parse(txtExciseDuty.Text);
            }
            catch { objTenderEvaluation.ExciseDuty = 0; }
            try
            {
                objTenderEvaluation.Cess = Decimal.Parse(txtCess.Text);
            }
            catch { objTenderEvaluation.Cess = 0; }
            try
            {
                objTenderEvaluation.EduCess = Decimal.Parse(txtEduCess.Text);
            }
            catch { objTenderEvaluation.EduCess = 0; }
            try
            {
                objTenderEvaluation.Surcharge = Decimal.Parse(txtSurcharge.Text);
            }
            catch { objTenderEvaluation.Surcharge = 0; }
            try
            {
                objTenderEvaluation.STCSTVAT = Decimal.Parse(txtStVat.Text);
            }
            catch { objTenderEvaluation.STCSTVAT = 0; }
            try
            {
                objTenderEvaluation.FreightUnloading = Decimal.Parse(txtFUnloading.Text);
            }
            catch { objTenderEvaluation.FreightUnloading = 0; }
            try
            {
                objTenderEvaluation.Insurance = Decimal.Parse(txtInsurange.Text);
            }
            catch { objTenderEvaluation.Insurance = 0; }
            try
            {
                objTenderEvaluation.TotalAmt = Decimal.Parse(txtTotalAmt.Text);
            }
            catch { objTenderEvaluation.TotalAmt = 0; }
            try
            {
                objTenderEvaluation.DisKm = Decimal.Parse(txtDistanceKm.Text);
            }
            catch { objTenderEvaluation.DisKm = 0; }

            try
            {
                objTenderEvaluation.DisKmAmt = Decimal.Parse(txtKmRates.Text);
            }
            catch { objTenderEvaluation.DisKmAmt = 0; }
            try
            {
                objTenderEvaluation.ChdRemark = txtRemark.Text;
            }
            catch { objTenderEvaluation.ChdRemark = ""; }
             
            objTenderEvaluation.UserId_I = int.Parse(Session["UserID"].ToString());

            try
            {
                objTenderEvaluation.mGST = Decimal.Parse(txtGST.Text);
                objTenderEvaluation.mTotalwithGST = Decimal.Parse(txtAmtWithGST.Text);
            }
            catch { }

            if (Request.QueryString["ID"] != null)
            {
                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
            }
            else
            {
                objTenderEvaluation.TenderEvaluationTrId_I = 0;
            }
            if (ddlVenderFill.Enabled == false)
            {
                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(lblTenderAutoNo.Text);
                int i = objTenderEvaluation.UpdateTenderAmtData();

                if (i > 0)
                {

                   // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    lblMsg.Text = "Record updated successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridFillLoad();
                    //obCommonFuction.EmptyTextBoxes(this);

                    lblCompAdd.Text = "";
                    ddlVenderFill.SelectedIndex = 0;
                    ddlVenderFill.Enabled = true;
                    lblTenderAutoNo.Text = "0";
                    GVEvaluation.DataSource = string.Empty;
                    GVEvaluation.DataBind();
                    btnSave.Visible = false;
                   // trKm.Visible = false;
                    txtBasicRate.Text = "";
                    txtCess.Text = "";
                    txtEduCess.Text = "";
                    txtExciseDuty.Text = "";
                    txtFUnloading.Text = "";
                    txtInsurange.Text = "";
                    txtStVat.Text = "";
                    txtSurcharge.Text = "";
                    txtTotalAmt.Text = "";
                    txtDistanceKm.Text = "";
                    txtRemark.Text = "";
                    txtKmRates.Text = "";
                    //   Clear();
                }
                else
                {
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sorry Record Not Updated.');</script>");
                    lblMsg.Text = "Sorry Record Not Updated.";

                }
            }
            else
            {
                ds = objTenderEvaluation.InsertChildData();

                if (ds.Tables[0].Rows[0]["Sts"].ToString() == "Ok")
                {

                  //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    lblMsg.Text = "Record saved successfully.";
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    GridFillLoad();
                    lblCompAdd.Text = "";
                    ddlVenderFill.SelectedIndex = 0;
                    txtBasicRate.Text = "";
                    txtCess.Text = "";
                    txtEduCess.Text = "";
                    txtExciseDuty.Text = "";
                    txtFUnloading.Text = "";
                    txtInsurange.Text = "";
                    txtStVat.Text = "";
                    txtSurcharge.Text = "";
                    txtTotalAmt.Text = "";
                    txtDistanceKm.Text = "";
                    txtRemark.Text = "";
                    txtKmRates.Text = "";


                    GVEvaluation.DataSource = string.Empty;
                    GVEvaluation.DataBind();
                    btnSave.Visible = false;
                   // trKm.Visible = false;
                }
                else
                {
                   // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + ds.Tables[0].Rows[0]["Msg"].ToString() + "');</script>");
                    lblMsg.Text = ds.Tables[0].Rows[0]["Msg"].ToString();
                }


            }
        }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblBasicRate = (Label)gv.FindControl("lblBasicRate");
        Label lblVenderid_I = (Label)gv.FindControl("lblVenderid_I");
        Label lblPaperVendorAddress_V = (Label)gv.FindControl("lblPaperVendorAddress_V");
        Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");

        Label lblExciseDuty = (Label)gv.FindControl("lblExciseDuty");
        Label lblCess = (Label)gv.FindControl("lblCess");
        Label lblEduCess = (Label)gv.FindControl("lblEduCess");
        Label lblSurcharge = (Label)gv.FindControl("lblSurcharge");


        Label lblSTCSTVAT = (Label)gv.FindControl("lblSTCSTVAT");
        Label lblFreightUnloading = (Label)gv.FindControl("lblFreightUnloading");
        Label lblInsurance = (Label)gv.FindControl("lblInsurance");
        Label lblTotalAmt = (Label)gv.FindControl("lblTotalAmt");
        
        Label lblDisKm = (Label)gv.FindControl("lblDisKm");
        Label lblRemark = (Label)gv.FindControl("lblRemark");
        Label lblDisKmAmt = (Label)gv.FindControl("lblDisKmAmt");



        txtDistanceKm.Text = lblDisKm.Text;
        txtRemark.Text = lblRemark.Text;
        txtKmRates.Text = lblDisKmAmt.Text;



        txtStVat.Text = lblSTCSTVAT.Text;
        txtFUnloading.Text = lblFreightUnloading.Text;
        txtInsurange.Text = lblInsurance.Text;
        txtTotalAmt.Text = lblTotalAmt.Text;

        txtBasicRate.Text = lblBasicRate.Text;
        txtExciseDuty.Text = lblExciseDuty.Text;
        txtCess.Text = lblCess.Text;
        txtEduCess.Text = lblEduCess.Text;
        txtSurcharge.Text = lblSurcharge.Text;


        txtCommercialBidDate.Enabled = true;
        txtTechnicalBidDate.Enabled = true;



        lblTenderAutoNo.Text = lblTenderEvaluationTrId_I.Text;
        lblCompAdd.Text = lblPaperVendorAddress_V.Text;

        VenderFill();
        ddlVenderFill.ClearSelection();
        ddlVenderFill.Items.FindByValue(lblVenderid_I.Text).Selected = true;
        ddlVenderFill.Enabled = false;

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");

        objTenderEvaluation = new PPR_TenderEvaluation();
        objTenderEvaluation.Delete(int.Parse(lblTenderEvaluationTrId_I.Text));
        //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        lblMsg.Text = "Record deleted successfully.";
        lblMsg.ForeColor = System.Drawing.Color.Green;
        GridFillLoad();
        if (GrdTenderEvaluation.Rows.Count > 0)
        {
            btnEvalution.Visible = true;
            trTenderEvl.Visible = true;
        }
        else
        {
            btnEvalution.Visible = false;
            trTenderEvl.Visible = false;
            btnSave.Visible = false;
           // trKm.Visible = false;
        }
        GVEvaluation.DataSource = string.Empty;
        GVEvaluation.DataBind();
        btnSave.Visible = false;
       // trKm.Visible = false;
    }
    public void VenderFill()
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedValue.ToString());
            ddlVenderFill.DataSource = objTenderEvaluation.VenderFillWithTender();
            ddlVenderFill.DataTextField = "PaperVendorName_V";
            ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            ddlVenderFill.DataBind();
            ddlVenderFill.Items.Insert(0, "Select");
        }
        else
        {
            ddlVenderFill.DataSource = string.Empty;
            ddlVenderFill.DataBind();
            ddlVenderFill.Items.Insert(0, "Select");
        }
    }
    protected void ddlVenderFill_Init(object sender, EventArgs e)
    {
        //  VenderFill();
        // ddlVenderFill.DataSource = string.Empty;
        // ddlVenderFill.DataBind();
        //ddlVenderFill.Items.Insert(0, "Select");
    }
    protected void ddlVenderFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVenderFill.SelectedItem.Text != "Select")
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
            objTenderEvaluation.Venderid_I = int.Parse(ddlVenderFill.SelectedItem.Value.ToString());
            ds = objTenderEvaluation.VenderFillWithDlt();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblCompAdd.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString();
            }
        }
    }
    protected void btnEvalution_Click(object sender, EventArgs e)
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {
            GridEvalutionFillLoad();

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlTenderType.SelectedItem.Text == "Select")
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
            lblMsg.Text = "Please select tender no.";
        }

        else
        {
            lblMsg.Text = "";
            string Sts = "NotOk";
            objTenderEvaluation = new PPR_TenderEvaluation();
            foreach (GridViewRow gv in GVEvaluation.Rows)
            {
                CheckBox chk = (CheckBox)gv.FindControl("CheckBox1");
                Label lblL_1 = (Label)gv.FindControl("lblL_1");
                Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");

                Label lblTenderTrId_I = (Label)gv.FindControl("lblTenderTrId_I");
                Label lblBidRate_N = (Label)gv.FindControl("lblBidRate_N");
                objTenderEvaluation.TenderTrId_I = int.Parse(lblTenderTrId_I.Text);
                objTenderEvaluation.BidRate_N = Decimal.Parse(lblBidRate_N.Text);
             

                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(lblTenderEvaluationTrId_I.Text);
                objTenderEvaluation.L_I = int.Parse(lblL_1.Text);
                CommonFuction comm = new CommonFuction();
                if (chk.Checked == true)
                {
                    comm.FillDatasetByProc("call USP_PPRTenderEvaluvationChangeStatus(" + lblTenderEvaluationTrId_I.Text + "," + lblTenderTrId_I.Text+ ",1)");
                }
                else
                {
                    comm.FillDatasetByProc("call USP_PPRTenderEvaluvationChangeStatus(" + lblTenderEvaluationTrId_I.Text + "," + lblTenderTrId_I.Text + ",0)");
                }
                int i = objTenderEvaluation.EvalutionUpdateData("");

                //    
                //lblTenderEvaluationTrId_I,lblTenderTrId_I
                if (i > 0)
                {
                    Sts = "Ok";
                }

            }
            if (Sts == "Ok")
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Evaluation Has Been Completed.');</script>");
                lblMsg.Text = "Evaluation Has Been Completed.";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("ViewCommercialBid.aspx");
                GridFillLoad();
            }
            else
            {
                //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Add Company Name For Evalution.');</script>");
                lblMsg.Text = "Please Add Company Name For Evalution.";
                
            }
        }
    }
    protected void GrdTenderEvaluation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
            LinkButton lnkUpdate = (LinkButton)e.Row.FindControl("lnkUpdate");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            Label lblTenderTrId_I = (Label)e.Row.FindControl("lblTenderTrId_I");

            objTenderEvaluation.TenderTrId_I = int.Parse(lblTenderTrId_I.Text);
            ds = objTenderEvaluation.CheckEvalution();
            if (ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                lnkUpdate.Visible = false;
                lnkDelete.Visible = false;
                btnEvalution.Enabled = false;
                btnSave.Enabled = false;
                trTenderEvl.Visible = false;
                //btnAdd.Enabled = false;
            }

        }
    }
    public void CalAmt()
    {
        decimal BasicRate = 0, ExcDuty = 0, Cess = 0, EduCess = 0, Surcharge = 0, StVt = 0, Unloading = 0, Insurance = 0;
        try
        {
            BasicRate = decimal.Parse(txtBasicRate.Text);
        }
        catch { }
        try
        {
            ExcDuty = decimal.Parse(txtExciseDuty.Text);
        }
        catch { }
        try
        {
            Cess = decimal.Parse(txtCess.Text);
        }
        catch { }
        try
        {
            EduCess = decimal.Parse(txtEduCess.Text);
        }
        catch { }
        try
        {
            Surcharge = decimal.Parse(txtSurcharge.Text);
        }
        catch { }
        //try
        //{
        //    StVt = decimal.Parse(txtStVat.Text);
        //}
        //catch { }
        try
        {
            Unloading = decimal.Parse(txtFUnloading.Text);
        }
        catch { }
        try
        {
            Insurance = decimal.Parse(txtInsurange.Text);
        }
        catch { }
        txtTotalAmt.Text = (BasicRate + ExcDuty + Cess + EduCess + Surcharge + StVt + Unloading + Insurance).ToString("0.00");

        try { GST(); }
        catch { }
    }
    protected void txtBasicRate_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtBasicRate.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtBasicRate.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
            txtCess.Focus();            
        }
        else
        {
            txtCess.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtCess_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtCess.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtExciseDuty.Focus();
            txtCess.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtExciseDuty.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtExciseDuty_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtExciseDuty.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtEduCess.Focus();
            txtExciseDuty.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtEduCess.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtEduCess_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtEduCess.Text.ToString().Substring(0, 1);
        if (FirstVal == "" || FirstVal == "-")
        {
            txtSurcharge.Focus();
            txtEduCess.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtSurcharge.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtSurcharge_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtSurcharge.Text.ToString().Substring(0, 1);
        if (FirstVal == "" || FirstVal == "-")
        {
            txtFUnloading.Focus();
            txtSurcharge.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtFUnloading.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtFUnloading_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtFUnloading.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtStVat.Focus();
            txtFUnloading.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtStVat.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtStVat_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtStVat.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtInsurange.Focus();
            txtStVat.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtInsurange.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void txtInsurange_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtInsurange.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtInsurange.Focus();
            txtInsurange.Text = "0";
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Amount.');</script>");
            lblMsg.Text = "Invalid Amount.";
        }
        else
        {
            txtDistanceKm.Focus();
            lblMsg.Text = "";
            CalAmt();
        }
    }
    protected void GVEvaluation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPerBundle = (Label)e.Row.FindControl("lblL_1");
            amounta = Convert.ToDouble(((Label)e.Row.FindControl("lblBidRate_N")).Text);
            //lblBidRate_N
            if (amounta == amounta2)
            {
                Count = Count;
            }
            else
            {
                Count = Count + 1;
            }
            lblPerBundle.Text =Convert.ToString(Count);
            amounta2 = amounta;
        }
    }

    public void GST()
    {
        decimal calm=0,totCalm=0;
        calm=decimal.Parse(txtTotalAmt.Text) * 12 / 100;
        txtGST.Text = calm.ToString() ;
        totCalm=decimal.Parse(txtTotalAmt.Text)+decimal.Parse(txtGST.Text);
        txtAmtWithGST.Text = totCalm.ToString();  
    }

    public class PPR_TenderEvaluation  
    {
        private int _TenderEvaluationTrId_I;
        private int _TenderTrId_I;
        private int _Venderid_I;
        private string _Qualify_Sts_V;
        private int _L_I;
        private int _UserId_I;
        private Decimal _BidRate_N;
        private DateTime _TechnicalDate;
        private DateTime _TenderEvaluationDate_D;


        private Decimal _BasicRate;
        private Decimal _ExciseDuty;
        private Decimal _Cess;
        private Decimal _EduCess;
        private Decimal _Surcharge;

        private Decimal _STCSTVAT;
        private Decimal _FreightUnloading;
        private Decimal _Insurance;
        private Decimal _TotalAmt;
        private Decimal _DisKm;
        private Decimal _DisKmAmt;
        private string _ChdRemark;
        private DateTime _CommDate;
        private string _CommTime;
        private Decimal _mGST;
        private Decimal _mTotalwithGST;

        public DateTime CommDate { get { return _CommDate; } set { _CommDate = value; } }
        public string CommTime { get { return _CommTime; } set { _CommTime = value; } }

        public DateTime TechnicalDate { get { return _TechnicalDate; } set { _TechnicalDate = value; } }
        public DateTime TenderEvaluationDate_D { get { return _TenderEvaluationDate_D; } set { _TenderEvaluationDate_D = value; } }

        public Decimal BasicRate { get { return _BasicRate; } set { _BasicRate = value; } }
        public Decimal ExciseDuty { get { return _ExciseDuty; } set { _ExciseDuty = value; } }
        public Decimal Cess { get { return _Cess; } set { _Cess = value; } }
        public Decimal EduCess { get { return _EduCess; } set { _EduCess = value; } }
        public Decimal Surcharge { get { return _Surcharge; } set { _Surcharge = value; } }

        public Decimal STCSTVAT { get { return _STCSTVAT; } set { _STCSTVAT = value; } }
        public Decimal FreightUnloading { get { return _FreightUnloading; } set { _FreightUnloading = value; } }
        public Decimal Insurance { get { return _Insurance; } set { _Insurance = value; } }
        public Decimal TotalAmt { get { return _TotalAmt; } set { _TotalAmt = value; } }
        public Decimal DisKm { get { return _DisKm; } set { _DisKm = value; } }
        public Decimal DisKmAmt { get { return _DisKmAmt; } set { _DisKmAmt = value; } }
        public string ChdRemark { get { return _ChdRemark; } set { _ChdRemark = value; } }

        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int TenderEvaluationTrId_I { get { return _TenderEvaluationTrId_I; } set { _TenderEvaluationTrId_I = value; } }
        public int Venderid_I { get { return _Venderid_I; } set { _Venderid_I = value; } }
        public string Qualify_Sts_V { get { return _Qualify_Sts_V; } set { _Qualify_Sts_V = value; } }
        public int L_I { get { return _L_I; } set { _L_I = value; } }
        public Decimal BidRate_N { get { return _BidRate_N; } set { _BidRate_N = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }
        public Decimal mGST { get { return _mGST; } set { _mGST = value; } }
        public Decimal mTotalwithGST { get { return _mTotalwithGST; } set { _mTotalwithGST = value; } }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet InsertChildData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);

            obDBAccess.addParam("mBasicRate", BasicRate);
            obDBAccess.addParam("mExciseDuty", ExciseDuty);
            obDBAccess.addParam("mCess", Cess);
            obDBAccess.addParam("mEduCess", EduCess);
            obDBAccess.addParam("mSurcharge", Surcharge);
            obDBAccess.addParam("mSTCSTVAT", STCSTVAT);
            obDBAccess.addParam("mFreightUnloading", FreightUnloading);
            obDBAccess.addParam("mInsurance", Insurance);
            obDBAccess.addParam("mTotalAmt", TotalAmt);
            obDBAccess.addParam("mDisKm", DisKm);

            obDBAccess.addParam("mDisKmAmt", DisKmAmt);
            obDBAccess.addParam("mRemark", ChdRemark);

            obDBAccess.addParam("mCommDate", CommDate);
            obDBAccess.addParam("mCommTime", CommTime);
            obDBAccess.addParam("mGST", mGST);
            obDBAccess.addParam("mTotalwithGST", mTotalwithGST);
            return obDBAccess.records();
        }

        public int UpdateTenderAmtData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationUpdateAmtData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);

            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);

            obDBAccess.addParam("mBasicRate", BasicRate);
            obDBAccess.addParam("mExciseDuty", ExciseDuty);
            obDBAccess.addParam("mCess", Cess);
            obDBAccess.addParam("mEduCess", EduCess);
            obDBAccess.addParam("mSurcharge", Surcharge);
            obDBAccess.addParam("mSTCSTVAT", STCSTVAT);
            obDBAccess.addParam("mFreightUnloading", FreightUnloading);
            obDBAccess.addParam("mInsurance", Insurance);
            obDBAccess.addParam("mTotalAmt", TotalAmt);
            obDBAccess.addParam("mDisKm", DisKm);
            obDBAccess.addParam("mDisKmAmt", DisKmAmt);
            obDBAccess.addParam("mRemark", ChdRemark);
            obDBAccess.addParam("mCommDate", CommDate);
            obDBAccess.addParam("mCommTime", CommTime); ;
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        public int EvalutionUpdateData(string EvalutionType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);
            obDBAccess.addParam("mL_I", L_I);
            obDBAccess.addParam("mEvalutionType", EvalutionType);
            obDBAccess.addParam("mDisKm", 0);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "0");
            return obDBAccess.records();
        }
        public System.Data.DataSet CheckEvalution()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "5");
            return obDBAccess.records();
        }
        public System.Data.DataSet EvalutionSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "4");
            return obDBAccess.records();
        }

        public System.Data.DataSet EvalutionSelectWithType(string FilterType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationAmtWise", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mFilterType", FilterType);
            return obDBAccess.records();
        }


        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", id);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "3");


            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet TenderSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR001_TenderEvaluationFieldFill", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            return obDBAccess.records();
        }

        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "1");
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithTender()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "6");
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithDlt()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PPR002_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mtype", "2");
            return obDBAccess.records();
        }

    }

}
