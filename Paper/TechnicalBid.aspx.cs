using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;
using MPTBCBussinessLayer.Paper;

public partial class Paper_TechnicalBid : System.Web.UI.Page
{
    DataSet ds;
    PPR_TenderEvaluation objTenderEvaluation = null;
    PPR_TechnicalBid objTechnicalBid = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            DataSet ds = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");

            lblAcYear.Text = ds.Tables[0].Rows[0][1].ToString();


           // lblAcYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();

            if (Request.QueryString["TndId"] != null)
            {
                TenderDtlFill();
                ddlTenderType.ClearSelection();
                try
                {
                    ddlTenderType.Items.FindByValue(objdb.Decrypt(Request.QueryString["TndId"].ToString())).Selected = true;
                }
                catch { }
                ddlTenderType.Enabled = false;                
                VenderFill();
                //try
                //{
                //    ddlVenderFill.ClearSelection();
                //    ddlVenderFill.Items.FindByValue(objdb.Decrypt(Request.QueryString["VndId"].ToString())).Selected = true;
                //    VenderAddressFill();
                //    ddlVenderFill.Enabled = false;
                //}
                //catch { }
              
                TenderDtlFillById();
            }
        }
    }
    public void TenderDtlFill()
    {

        objTenderEvaluation = new PPR_TenderEvaluation();
        objTenderEvaluation.TenderTrId_I = 0;
        ddlTenderType.DataSource = objTenderEvaluation.TenderSelect();
        ddlTenderType.DataTextField = "TenderNo_V";
        ddlTenderType.DataValueField = "TenderTrId_I";
        ddlTenderType.DataBind();
        ddlTenderType.Items.Insert(0, "Select");

    }
    protected void ddlTenderType_Init(object sender, EventArgs e)
    {
       // TenderDtlFill();

        ddlTenderType.DataSource = obCommonFuction.FillDatasetByProc("call USP_ppr_TechniBidSearch('','',5)");// objTenderEvaluation.TenderSelect();
        ddlTenderType.DataTextField = "TenderNo_V";
        ddlTenderType.DataValueField = "TenderTrId_I";
        ddlTenderType.DataBind();
     //   ddlTenderType.Items.Insert(0, "Select");
    }
    public void TenderDtlFillById()
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
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
                lblAcYear.Text = ds.Tables[0].Rows[0]["AcYear"].ToString();
                Label1.Text = ds.Tables[0].Rows[0]["RqcQuantity"].ToString();
                objTechnicalBid = new PPR_TechnicalBid();
                objTechnicalBid.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value);
                
                if (Request.QueryString["TndId"] != null)
                {
                    if (ddlVenderFill.SelectedItem.Text != "Select")
                    {
                        objTechnicalBid.PaperVendorTrId_I = int.Parse(ddlVenderFill.SelectedItem.Value);
                        ds = objTechnicalBid.BidConditionFill();
                        GrdWorkPlan.DataSource = ds.Tables[0];
                        GrdWorkPlan.DataBind();
                    }
                }
                else
                {
                    ds = objTechnicalBid.ConditionFill();
                    GrdWorkPlan.DataSource = ds.Tables[0];
                    GrdWorkPlan.DataBind();
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
                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
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
            GrdWorkPlan.DataSource = string.Empty;
            GrdWorkPlan.DataBind();
        }
    }
    protected void ddlTenderType_SelectedIndexChanged(object sender, EventArgs e)
    {
        TenderDtlFillById();
    }

    public void VenderFill()
    {

        
        if (Request.QueryString["TndId"] != null)
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
            //ddlVenderFill.DataSource = objTenderEvaluation.VenderFill();
            ddlVenderFill.DataSource = obCommonFuction.FillDatasetByProc("call USP_ppr_TechniBidSearch('" + ddlTenderType.SelectedItem.Value + "','',4)");
            ddlVenderFill.DataTextField = "PaperVendorName_V";
            ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            ddlVenderFill.DataBind();
            ddlVenderFill.Items.Insert(0, "Select");
        }
        else
        {
            objTenderEvaluation = new PPR_TenderEvaluation();
            ddlVenderFill.DataSource = objTenderEvaluation.VenderFill();
            ddlVenderFill.DataTextField = "PaperVendorName_V";
            ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            ddlVenderFill.DataBind();
            ddlVenderFill.Items.Insert(0, "Select");
        }
    }
    protected void ddlVenderFill_Init(object sender, EventArgs e)
    {
        VenderFill();
    }
    public void VenderAddressFill()
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
    protected void ddlVenderFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        VenderAddressFill();
        if (Request.QueryString["TndId"] != null)
        {
            if (ddlVenderFill.SelectedItem.Text != "Select")
            {
                objTechnicalBid = new PPR_TechnicalBid();
                objTechnicalBid.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value);
                objTechnicalBid.PaperVendorTrId_I = int.Parse(ddlVenderFill.SelectedItem.Value);
                ds = objTechnicalBid.BidConditionFill();
                GrdWorkPlan.DataSource = ds.Tables[0];
                GrdWorkPlan.DataBind();

                //ds = objTechnicalBid.ConditionFill();
                //GrdWorkPlan.DataSource = ds.Tables[0];
                //GrdWorkPlan.DataBind();
            }
        } 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ddlTenderType.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
        }
        else if (ddlVenderFill.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select vendor.');</script>");
        }
        else
        {  
            objTechnicalBid = new PPR_TechnicalBid();
            objTechnicalBid.PaperVendorTrId_I = int.Parse(ddlVenderFill.SelectedItem.Value);
            objTechnicalBid.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value);
            ds = objTechnicalBid.VendorCheck();
            if (ds.Tables[0].Rows[0][0].ToString() != "0" && Request.QueryString["TndId"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Vendor Already Exist.');</script>");
            }
            else
            {
                //string CheckBoxSts = "";
                //foreach (GridViewRow gv in GrdWorkPlan.Rows)
                //{
                //    CheckBox chkSelect = (CheckBox)gv.FindControl("lblTender_Cond_Id");
                //    if (chkSelect.Checked == false)
                //    {
                //        CheckBoxSts = "No";
                //        break;
                //    }
                //}
                if (GrdWorkPlan.Rows.Count < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select atleast one check box.');</script>");
                }
                //else if (CheckBoxSts == "No")
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all information.');</script>");
                //}
                else
                {
                    string Sts = "NotOk";

                    foreach (GridViewRow gv in GrdWorkPlan.Rows)
                    {

                        CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");

                        if (chkSelect.Checked == true)
                        {
                            Sts = "CheckOk";
                        }
                    }

                    if (Sts == "CheckOk")
                    {
                        foreach (GridViewRow gv in GrdWorkPlan.Rows)
                        {
                            Label lblTender_Cond_Id = (Label)gv.FindControl("lblTender_Cond_Id");
                            CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                            objTechnicalBid.Techn_TrId = 0;
                            objTechnicalBid.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value);
                            objTechnicalBid.Tender_Cond_Id = int.Parse(lblTender_Cond_Id.Text);
                            objTechnicalBid.UserId_I = int.Parse(Session["UserID"].ToString());
                            objTechnicalBid.PaperVendorTrId_I = int.Parse(ddlVenderFill.SelectedItem.Value);
                            objTechnicalBid.CheckStatus = chkSelect.Checked.ToString();
                            int i = 0;
                            if (Request.QueryString["TndId"] != null)
                            {
                                Label lblTechn_TrId = (Label)gv.FindControl("lblTechn_TrId");
                                objTechnicalBid.Techn_TrId = int.Parse(lblTechn_TrId.Text);
                                i = objTechnicalBid.UpdateBid();
                            }
                            else
                            {
                                i = objTechnicalBid.insertBid();
                            }
                            if (i > 0)
                            {
                                Sts = "Ok";
                            }
                        }
                    }
                    if (Sts == "Ok")
                    {
                        if (Request.QueryString["TndId"] != null)
                        {
                            Response.Redirect("ViewPPR_002_TechBid.aspx");
                        }
                        else
                        {
                            Response.Redirect("ViewPPR_002_TechBid.aspx");
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical Bid Has Been Completed.');</script>");
                        }

                        lblTenderDt.Text = "";
                        lblSubDt.Text = "";
                        lblTenderDtl.Text = "";
                        lblEMd.Text = "";
                        lblTenderWork.Text = "";
                        lblTenderType.Text = "";
                        lblTenderNo.Text = "";
                        lblTenderFee.Text = "";
                        lblCompAdd.Text = "";
                        GrdWorkPlan.DataSource = string.Empty;
                        GrdWorkPlan.DataBind();
                        ddlTenderType.SelectedIndex = 0;
                        ddlVenderFill.SelectedIndex = 0;

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select atleast one check box.');</script>");
                    }
                }
            }
        }
    }

    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCheckStatus = (Label)e.Row.FindControl("lblCheckStatus");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            if (Request.QueryString["TndId"] != null)
            {
                if (lblCheckStatus.Text.ToLower() == "false")
                {
                    chkSelect.Checked = false;
                }
                else
                {
                    chkSelect.Checked = true;
                }

            }
            else
            {
                if (lblCheckStatus.Text.ToLower() == "false")
                {
                    chkSelect.Checked = false;
                }
                else
                {
                    chkSelect.Checked = true;
                }

            }
        }
    }
}
