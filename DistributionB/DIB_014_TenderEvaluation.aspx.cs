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
using MPTBCBussinessLayer.DistributionB;
using System.Globalization;

public partial class Paper_TenderEvaluation : System.Web.UI.Page
{
    DataSet ds;
    InsuranceTenderEvaluation objTenderEvaluation = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {
                TenderDtlFill();
                TenderDtlFillById();
            }
        }
    }
    public void TenderDtlFill()
    {
        if (Request.QueryString["ID"] != null)
        {
            objTenderEvaluation = new  InsuranceTenderEvaluation();
            objTenderEvaluation.TenderTrId_I = 0;
            ddlTenderType.DataSource = objTenderEvaluation.TenderSelect();
            ddlTenderType.DataTextField = "TenderNo_V";
            ddlTenderType.DataValueField = "TenderTrId_I";
            ddlTenderType.DataBind();
            ddlTenderType.Items.Insert(0, "Select");
            ddlTenderType.Items.FindByValue(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString())).Selected = true;
            ddlTenderType.Enabled = false;
           // VenderFill();
            TenderDtlFillById();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            ds = objTenderEvaluation.CheckEvalution();
            if (ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                GridEvalutionFillLoad();
                btnEvalution.Visible = false;
            }

            if (GrdTenderEvaluation.Rows.Count > 0)
            {
                btnEvalution.Visible = true;
            }
            else
            {
                btnEvalution.Visible = false;
            }
        }
        else
        {
            objTenderEvaluation = new  InsuranceTenderEvaluation();
            objTenderEvaluation.TenderTrId_I = 0;
            ddlTenderType.DataSource = objTenderEvaluation.TenderSelect();
            ddlTenderType.DataTextField = "TenderNo_V";
            ddlTenderType.DataValueField = "TenderTrId_I";
            ddlTenderType.DataBind();
            ddlTenderType.Items.Insert(0, "Select");
        }
    }
    protected void ddlTenderType_Init(object sender, EventArgs e)
    {
        
    }
    public void TenderDtlFillById()
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {
            btnAdd.Enabled = true;
            btnEvalution.Enabled = true;
            btnSave.Enabled = true;

            GridFillLoad();
            VenderFill();
            objTenderEvaluation = new  InsuranceTenderEvaluation();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            ds = objTenderEvaluation.TenderSelect();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime SubDt = new DateTime();

                dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
                lblTenderDt.Text = dat.ToString("dd/MM/yyyy");
                lblSubDt.Text = SubDt.ToString("dd/MM/yyyy");
                lblTenderDtl.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
                lblEMd.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
                lblTenderWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
                lblTenderType.Text = ds.Tables[0].Rows[0]["TenderType_V"].ToString();
                lblTenderNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
                lblTenderFee.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();
                lblInsuranceDateFrom_D.Text= Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateFrom_D"]).ToString("dd/MM/yyyy");
                lblInsuranceDateTo_D.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateTo_D"]).ToString("dd/MM/yyyy");
                try
                {
                    //SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
                    //txtCommercialBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                    //SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TechDate"].ToString());
                    //txtTechnicalBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                }
                catch { }
                //txtCommercialBidDate.Enabled = false;
                //txtTechnicalBidDate.Enabled = false;              

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
        //TenderDtlFillById();
       
    }
    public void GridFillLoad()
    {
        try
        {
            if (ddlTenderType.SelectedItem.Text != "Select")
            {
                DataSet DSS;
                objTenderEvaluation = new  InsuranceTenderEvaluation();
                objTenderEvaluation.TenderTrId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
                DSS = objTenderEvaluation.Select();
                GrdTenderEvaluation.DataSource = DSS.Tables[0];
                GrdTenderEvaluation.DataBind();

                if (GrdTenderEvaluation.Rows.Count > 0)
                {
                    btnEvalution.Visible = true;
                }
                else
                {
                    btnEvalution.Visible = false;

                }
              
                objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
                ds = objTenderEvaluation.CheckEvalution();
                if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    GridEvalutionFillLoad();
                    btnEvalution.Visible = false;
                }
                else
                {
                    GVEvaluation.DataSource = null;
                    GVEvaluation.DataBind();
                }

                //if (DSS.Tables[0].Rows.Count > 0)
                //{
                //    if (DSS.Tables[0].Rows[0]["EvalutionType"].ToString() != "")
                //    {
                //        ddlEvelutionType.ClearSelection();
                //        try
                //        {
                //            ddlEvelutionType.Items.FindByText(DSS.Tables[0].Rows[0]["EvalutionType"].ToString()).Selected = true;
                //            ddlEvelutionType.Enabled = false;
                //        }
                //        catch { }
                //    }

                //    //DateTime SubDt = new DateTime();

                //    //if (DSS.Tables[0].Rows.Count > 0)
                //    //{
                //    //    SubDt = DateTime.Parse(DSS.Tables[0].Rows[0]["TechnicalDate"].ToString());
                //    //    txtTechnicalBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                //    //    txtTechnicalBidDate.Enabled = false;

                //    //    SubDt = DateTime.Parse(DSS.Tables[0].Rows[0]["TenderEvaluationDate_D"].ToString());
                //    //    txtCommercialBidDate.Text = SubDt.ToString("dd/MM/yyyy");
                //    //    txtCommercialBidDate.Enabled = false;
                //    //}
                //    //else
                //    //{
                //    //    txtTechnicalBidDate.Text = "";
                //    //    txtCommercialBidDate.Text = "";
                //    //}
                //}               
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

                objTenderEvaluation = new  InsuranceTenderEvaluation();
                objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
                //GVEvaluation.DataSource = objTenderEvaluation.EvalutionSelectWithType(ddlEvelutionType.SelectedItem.Text);
                var data = objTenderEvaluation.EvalutionSelectWithType("L1");
                GVEvaluation.DataSource = data;
                GVEvaluation.DataBind();

               
                if (GVEvaluation.Rows.Count > 0)
                {
                    txtRemarkL1.Text = Convert.ToString(data.Tables[0].Rows[0]["RemarkL1"]);
                    btnSave.Visible = true;
                    txtRemarkL1.Visible = true;
                    lblRemarkL1.Visible = true;
                    //btnEvalution.Visible = false;
                }
                else
                {
                    btnSave.Visible = false;
                    txtRemarkL1.Visible = false;
                    lblRemarkL1.Visible = false;
                    //btnEvalution.Visible = true;
                }
            }
        }
        catch { }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {


        //DateTime DteCheck, CommDteCheck;
        string RptDate = "", CommDate = "";
        //if (txtTechnicalBidDate.Text != "")
        //{
        //    try
        //    {
        //        DteCheck = DateTime.Parse(txtTechnicalBidDate.Text, cult);
        //    }
        //    catch { RptDate = "NoDate"; }
        //}
        //if (txtCommercialBidDate.Text != "")
        //{
        //    try
        //    {
        //        CommDteCheck = DateTime.Parse(txtCommercialBidDate.Text, cult);
        //    }
        //    catch { CommDate = "NoDate"; }
        //}
        //if (txtTechnicalBidDate.Text == "")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter technical Date.');</script>");
        //}
        //else if (txtCommercialBidDate.Text == "")
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Commercial Date.');</script>");
        //}
        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct technical Date.');</script>");
        }
        else if (CommDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Commercial Date.');</script>");
        }
        //else   if (DateTime.Parse(txtCommercialBidDate.Text, cult) < DateTime.Parse(txtTechnicalBidDate.Text, cult))
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be greater then Commercial date.');</script>");
        //}
        else if (ddlTenderType.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
        }
        else if (ddlVenderFill.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select company name.');</script>");

        }
        else
        {

            objTenderEvaluation = new  InsuranceTenderEvaluation();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            objTenderEvaluation.Venderid_I = int.Parse(ddlVenderFill.SelectedItem.Value.ToString());
            objTenderEvaluation.Qualify_Sts_V = "Yes";//ddlStatus.SelectedItem.Text.Trim();
            objTenderEvaluation.BidRate_N = 0;


            //objTenderEvaluation.TenderEvaluationDate_D = DateTime.Parse(txtCommercialBidDate.Text, cult);
            //objTenderEvaluation.TechnicalDate = DateTime.Parse(txtTechnicalBidDate.Text, cult);
            objTenderEvaluation.FlPremium = Decimal.Parse(txtFlNetPremium.Text);
            objTenderEvaluation.FlServiceTax = Decimal.Parse(txtFlServiceTax.Text);
            objTenderEvaluation.FlOtherTax = Decimal.Parse(txtFlOtherTax.Text);
            objTenderEvaluation.BuPremium = Decimal.Parse(txtBuNetPremium.Text);
            objTenderEvaluation.BuServiceTax = Decimal.Parse(txtBuServiceTax.Text);
            objTenderEvaluation.BuOtherTax = Decimal.Parse(txtBuOtherTax.Text);
            objTenderEvaluation.Remark = txtRemark.Text;
            objTenderEvaluation.SubTotal = Decimal.Parse(TxtTot1.Text);
            objTenderEvaluation.TTotal  = Decimal.Parse(TxtTot2.Text);
            //objTenderEvaluation.ReelExciseAmt = Decimal.Parse(txtReelExcise.Text);
            //objTenderEvaluation.ReelNonExciseAmt = Decimal.Parse(txtReelNonExcise.Text);
            //objTenderEvaluation.SheetExciseAmt = Decimal.Parse(txtSheetExcise.Text);
            //objTenderEvaluation.SheetNonExciseAmt = Decimal.Parse(txtSheetNonExcise.Text);
            //objTenderEvaluation.PerKmAmt = Decimal.Parse(txtPerKmAmt.Text);
            objTenderEvaluation.UserId_I = int.Parse(Session["UserID"].ToString());



            if (Request.QueryString["ID"] != null)
            {
                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
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

                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                    GridFillLoad();
                    //obCommonFuction.EmptyTextBoxes(this);

                    //lblCompAdd.Text = "";
                    ddlVenderFill.SelectedIndex = 0;
                    ddlVenderFill.Enabled = true;
                    lblTenderAutoNo.Text = "0";
                    GVEvaluation.DataSource = string.Empty;
                    GVEvaluation.DataBind();
                    btnSave.Visible = false;
                    txtFlNetPremium.Text = "";
                    txtFlServiceTax.Text = "";
                    txtFlOtherTax.Text = "";
                    txtBuNetPremium.Text = "";
                    txtBuServiceTax.Text = "";
                    txtBuOtherTax.Text = "";
                    txtRemark.Text = "";
                    //   Clear();
                    GridEvalutionFillLoad();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sorry Record Not Updated.');</script>");
                }
            }
            else
            {
                ds = objTenderEvaluation.InsertChildData();

                if (ds.Tables[0].Rows[0]["Sts"].ToString() == "Ok")
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    GridFillLoad();
                    //lblCompAdd.Text = "";
                    ddlVenderFill.SelectedIndex = 0;
                    //obCommonFuction.EmptyTextBoxes(this);
                    txtFlNetPremium.Text = "";
                    txtFlServiceTax.Text = "";
                    txtFlOtherTax.Text = "";
                    txtBuNetPremium.Text = "";
                    txtBuServiceTax.Text = "";
                    txtBuOtherTax.Text = "";
                    txtRemark.Text = "";
                    //   Clear();
                    GVEvaluation.DataSource = string.Empty;
                    GVEvaluation.DataBind();
                    btnSave.Visible = false;
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + ds.Tables[0].Rows[0]["Msg"].ToString() + "');</script>");
                }


            }
        }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
       
        Label lblVenderid_I = (Label)gv.FindControl("lblVenderid_I");
        Label lblPaperVendorAddress_V = (Label)gv.FindControl("lblPaperVendorAddress_V");
        Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");

        Label lblFlPremium = (Label)gv.FindControl("lblFlPremium");
        Label lblFlServiceTax = (Label)gv.FindControl("lblFlServiceTax");
        Label lblFlOtherTax = (Label)gv.FindControl("lblFlOtherTax");      
        Label lblBuPremium = (Label)gv.FindControl("lblBuPremium");
        Label lblBuServiceTax = (Label)gv.FindControl("lblBuServiceTax");
        Label lblBuOtherTax = (Label)gv.FindControl("lblBuOtherTax");
        Label lblRemark = (Label)gv.FindControl("lblRemark");
        //txtPerKmAmt.Text = lblPerKmAmt.Text;
        //txtReelExcise.Text = lblReelExciseAmt.Text;
        //txtReelNonExcise.Text = lblReelNonExciseAmt.Text;
        //txtSheetExcise.Text=lblSheetExciseAmt.Text;
        //txtSheetNonExcise.Text = lblSheetNonExciseAmt.Text;
        
        txtFlNetPremium.Text = lblFlPremium.Text;
        txtFlServiceTax.Text = lblFlServiceTax.Text;
        txtFlOtherTax.Text = lblFlOtherTax.Text;
        txtBuNetPremium.Text = lblBuPremium.Text;
        txtBuServiceTax.Text = lblBuServiceTax.Text;
        txtBuOtherTax.Text = lblBuOtherTax.Text;
        txtRemark.Text = lblRemark.Text;
        //txtCommercialBidDate.Enabled = true;
        //txtTechnicalBidDate.Enabled = true;



        lblTenderAutoNo.Text = lblTenderEvaluationTrId_I.Text;
        //lblCompAdd.Text = lblPaperVendorAddress_V.Text;

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

        objTenderEvaluation = new  InsuranceTenderEvaluation();
        objTenderEvaluation.Delete(int.Parse(lblTenderEvaluationTrId_I.Text));
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GridFillLoad();
        if (GrdTenderEvaluation.Rows.Count > 0)
        {
            btnEvalution.Visible = true;
        }
        else
        {
            btnEvalution.Visible = false;
            btnSave.Visible = false;
        }
        GVEvaluation.DataSource = string.Empty;
        GVEvaluation.DataBind();
        btnSave.Visible = false;
        txtFlNetPremium.Text = "";
        txtFlServiceTax.Text = "";
        txtFlOtherTax.Text = "";
        txtBuNetPremium.Text = "";
        txtBuServiceTax.Text = "";
        txtBuOtherTax.Text = "";
        txtRemark.Text = "";
        ddlVenderFill.Enabled = true;
    }
    public void VenderFill()
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {
            objTenderEvaluation = new  InsuranceTenderEvaluation();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedValue.ToString());
            ddlVenderFill.DataSource = objTenderEvaluation.VenderFillWithTender();
            ddlVenderFill.DataTextField = "Company_V";
            ddlVenderFill.DataValueField = "InsCompanyID_I";
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
        VenderFill();
        ddlVenderFill.DataSource = string.Empty;
        ddlVenderFill.DataBind();
        ddlVenderFill.Items.Insert(0, "Select");
    }
    protected void ddlVenderFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlVenderFill.SelectedItem.Text != "Select")
        //{
        //    objTenderEvaluation = new  InsuranceTenderEvaluation();
        //    objTenderEvaluation.Venderid_I = int.Parse(ddlVenderFill.SelectedItem.Value.ToString());
        //    ds = objTenderEvaluation.VenderFillWithDlt();
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        //lblCompAdd.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString();
        //    }
        //}
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
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
        }

        else
        {
            string Sts = "NotOk";
            objTenderEvaluation = new  InsuranceTenderEvaluation();
            foreach (GridViewRow gv in GVEvaluation.Rows)
            {
                Label lblL_1 = (Label)gv.FindControl("lblL_1");
                Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");
                Label lblTenderTrId_I = (Label)gv.FindControl("lblTenderTrId_I");
                Label lblBidRate_N = (Label)gv.FindControl("lblBidRate_N");
                RadioButton rblL1 = (RadioButton)gv.FindControl("rblL1");
                objTenderEvaluation.TenderTrId_I = int.Parse(lblTenderTrId_I.Text);
                objTenderEvaluation.BidRate_N = Decimal.Parse(lblBidRate_N.Text);
                
                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(lblTenderEvaluationTrId_I.Text);
                objTenderEvaluation.L_I = int.Parse(lblL_1.Text);
                objTenderEvaluation.RemarkL1 = Convert.ToString(txtRemarkL1.Text);
                if (rblL1.Checked == true)
                {
                    objTenderEvaluation.Is_L1 = 1;
                }
                else
                {
                    objTenderEvaluation.Is_L1 = 0;
                }

                //int i = objTenderEvaluation.EvalutionUpdateData(ddlEvelutionType.SelectedItem.Text);
                int i = objTenderEvaluation.EvalutionUpdateData("L1");

                if (i > 0)
                {
                    Sts = "Ok";
                }

            }
            if (Sts == "Ok")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Evaluation Has Been Completed.');</script>");
                GridFillLoad();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Add Company Name For Evalution.');</script>");
            }
        }
    }
    protected void GrdTenderEvaluation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            objTenderEvaluation = new  InsuranceTenderEvaluation();
            LinkButton lnkUpdate = (LinkButton)e.Row.FindControl("lnkUpdate");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            Label lblTenderTrId_I = (Label)e.Row.FindControl("lblTenderTrId_I");

            objTenderEvaluation.TenderTrId_I = int.Parse(lblTenderTrId_I.Text);
            ds = objTenderEvaluation.CheckEvalution();
            if (ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                lnkUpdate.Visible = true;
                lnkDelete.Visible = false;
                btnEvalution.Enabled = false;
                btnSave.Enabled = true;
                btnAdd.Enabled = true;
            }

        }
    }

    protected void rblL1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow GVR in GVEvaluation.Rows)
            {
                ((RadioButton)GVR.FindControl("rblL1")).Checked = false;
            }
            RadioButton rb = (RadioButton)sender;
            GridViewRow GV = (GridViewRow)rb.NamingContainer;
            ((RadioButton)GV.FindControl("rblL1")).Checked = true;
        }
        catch { }
        finally { }
    }
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenderInsuranceInfo.aspx");
    }

    public class InsuranceTenderEvaluation  
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
        //private Decimal _ReelExciseAmt;
        //private Decimal _ReelNonExciseAmt;
        //private Decimal _SheetExciseAmt;
        //private Decimal _SheetNonExciseAmt;
        //private Decimal _PerKmAmt;

        public DateTime TechnicalDate { get { return _TechnicalDate; } set { _TechnicalDate = value; } }
        public DateTime TenderEvaluationDate_D { get { return _TenderEvaluationDate_D; } set { _TenderEvaluationDate_D = value; } }
        //public Decimal ReelExciseAmt { get { return _ReelExciseAmt; } set { _ReelExciseAmt = value; } }
        //public Decimal ReelNonExciseAmt { get { return _ReelNonExciseAmt; } set { _ReelNonExciseAmt = value; } }
        //public Decimal SheetExciseAmt { get { return _SheetExciseAmt; } set { _SheetExciseAmt = value; } }
        //public Decimal SheetNonExciseAmt { get { return _SheetNonExciseAmt; } set { _SheetNonExciseAmt = value; } }
        //public Decimal PerKmAmt { get { return _PerKmAmt; } set { _PerKmAmt = value; } }



        public int TenderTrId_I { get { return _TenderTrId_I; } set { _TenderTrId_I = value; } }
        public int TenderEvaluationTrId_I { get { return _TenderEvaluationTrId_I; } set { _TenderEvaluationTrId_I = value; } }
        public int Venderid_I { get { return _Venderid_I; } set { _Venderid_I = value; } }
        public string Qualify_Sts_V { get { return _Qualify_Sts_V; } set { _Qualify_Sts_V = value; } }
        public int L_I { get { return _L_I; } set { _L_I = value; } }
        public Decimal BidRate_N { get { return _BidRate_N; } set { _BidRate_N = value; } }
        public int UserId_I { get { return _UserId_I; } set { _UserId_I = value; } }

        public decimal FlPremium { get; set; }
        public decimal FlServiceTax { get; set; }
        public decimal FlOtherTax { get; set; }
        public decimal BuPremium { get; set; }
        public decimal BuServiceTax { get; set; }
        public decimal BuOtherTax { get; set; }
        public string StringParameter { get; set; }
        public string Remark { get; set; }
        public int Is_L1 { get; set; }
        public string RemarkL1 { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TTotal { get; set; }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            //obDBAccess.addParam("mBidRate_N", BidRate_N);
            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public System.Data.DataSet InsertChildData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationSaveData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mQualify_Sts_V", Qualify_Sts_V);
            obDBAccess.addParam("mL_I", 0);
            obDBAccess.addParam("mUserId_I", UserId_I);
            //obDBAccess.addParam("mBidRate_N", BidRate_N);

            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);
            obDBAccess.addParam("mFlPremium", FlPremium);
            obDBAccess.addParam("mFlServiceTax", FlServiceTax);
            obDBAccess.addParam("mFlOtherTax", FlOtherTax);
            obDBAccess.addParam("mBuPremium", BuPremium);
            obDBAccess.addParam("mBuServiceTax", BuServiceTax);
            obDBAccess.addParam("mBuOtherTax", BuOtherTax);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);
            obDBAccess.addParam("mRemark", Remark);
            obDBAccess.addParam("mEvalutionType", "L1");
            obDBAccess.addParam("mSubtotal", SubTotal);
            obDBAccess.addParam("mTotal", TTotal);
            return obDBAccess.records();
        }

        public int UpdateTenderAmtData()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationUpdateAmtData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mBidRate_N", BidRate_N);

            obDBAccess.addParam("mTenderEvaluationDate_D", TenderEvaluationDate_D);
            obDBAccess.addParam("mFlPremium", FlPremium);
            obDBAccess.addParam("mFlServiceTax", FlServiceTax);
            obDBAccess.addParam("mFlOtherTax", FlOtherTax);
            obDBAccess.addParam("mBuPremium", BuPremium);
            obDBAccess.addParam("mBuServiceTax", BuServiceTax);
            obDBAccess.addParam("mBuOtherTax", BuOtherTax);
            obDBAccess.addParam("mRemark", Remark);
            obDBAccess.addParam("mTechnicalDate", TechnicalDate);
       
            int result = obDBAccess.executeMyQuery();
            return result;
        }


        public int EvalutionUpdateData(string EvalutionType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationUpdateData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", TenderEvaluationTrId_I);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            //obDBAccess.addParam("mBidRate_N", BidRate_N);            
            obDBAccess.addParam("mL_I", L_I);
            obDBAccess.addParam("mEvalutionType", EvalutionType);
            obDBAccess.addParam("mIs_L1", Is_L1);
            obDBAccess.addParam("mRemarkL1", RemarkL1);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public System.Data.DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "0");
            return obDBAccess.records();
        }
        public System.Data.DataSet CheckEvalution()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "5");
            return obDBAccess.records();
        }
        public System.Data.DataSet EvalutionSelect()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "4");
            return obDBAccess.records();
        }

        public System.Data.DataSet EvalutionSelectWithType(string FilterType)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationAmtWise", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mFilterType", FilterType);
            return obDBAccess.records();
        }


        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
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
            obDBAccess.execute("USP_DIB012_TenderInfoLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mStringParameter", StringParameter);
            return obDBAccess.records();
        }

        public System.Data.DataSet VenderFill()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB011_InsuranceCompanyLoadData", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mCompanyID_I", 0);
            obDBAccess.addParam("mtype", 0);
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithTender()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", TenderTrId_I);
            obDBAccess.addParam("mVenderid_I", 0);
            obDBAccess.addParam("mtype", "6");
            return obDBAccess.records();
        }
        public System.Data.DataSet VenderFillWithDlt()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_DIB014_TenderEvaluationShowDta", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTenderEvaluationTrId_I", 0);
            obDBAccess.addParam("mTenderTrId_I", 0);
            obDBAccess.addParam("mVenderid_I", Venderid_I);
            obDBAccess.addParam("mtype", "2");
            return obDBAccess.records();
        }

    }
}
