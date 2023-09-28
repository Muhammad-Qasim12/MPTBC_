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
using System.IO;

public partial class Paper_TenderInfo : System.Web.UI.Page
{
    APIProcedure objApi = new APIProcedure();
    DataSet ds;
    PPR_TenderInfo objTenderInfo = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string path, FileName;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DataSet ds = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
         //   DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            if (Request.QueryString["ID"] != null)
            {
                GridFillLoad();
                TenderDtlFillById(objApi.Decrypt(Request.QueryString["ID"].ToString()));
            }
            else
            {
                lblAcYear.Text = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(2)").Tables[0].Rows[0][0].ToString();
               
            }
        }
    }
    public void TenderDtlFillById(string Id)
    {
        //objTenderInfo = new PPR_TenderInfo();
        //ds = objTenderInfo.TermAndConditionFill(Id);

        if (Request.QueryString["ID"] != null)
        {
            ds = obCommonFuction.FillDatasetByProc("Call USP_PPR004_TenderInfoTermAndCondt('" + Id + "','0')");
            if (ds.Tables[0].Rows.Count > 0)
            {
                GrdWorkPlan.DataSource = ds.Tables[0];
                GrdWorkPlan.DataBind();
                PaperTypeFill();
                try
                {
                    ddlPaperType.Items.FindByValue(ds.Tables[0].Rows[0]["PaperType_I"].ToString()).Selected = true;
                    ddlPaperType.Enabled = false;
                }
                catch { }
            }
            else
            {
                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
            }
        }
        else
        {
            if (ddlPaperType.SelectedItem.Text != "Select")
            {
                ds = obCommonFuction.FillDatasetByProc("Call USP_PPR004_TenderInfoTermAndCondt('','" + ddlPaperType.SelectedItem.Value + "')");

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
            }
            else
            {
                GrdWorkPlan.DataSource = string.Empty;
                GrdWorkPlan.DataBind();
            }
        }
        
    }
    public void PaperTypeFill()
    {
        ddlPaperType.DataSource = obCommonFuction.FillDatasetByProc("Call Usp_pprLOISearchDetails('','',6)");//ObjPaperMaster.PaperTypeFill();
        ddlPaperType.DataValueField = "PaperType_I";
        ddlPaperType.DataTextField = "PaperType";
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "Select");
    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperTypeFill();
    }
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblCheckStatus = (Label)e.Row.FindControl("lblCheckStatus");
            CheckBox chkSelect = (CheckBox)e.Row.FindControl("chkSelect");
            if (Request.QueryString["ID"] != null)
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime DteCheck;
            string Date = "", FeeDate = "", CommDate = "", TechDate = "", CommTime = "", TechTime = "";
            if (txtTechnicalTime.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse("01/01/2015 " + txtTechnicalTime.Text, cult);
                }
                catch { TechTime = "NoDate"; }
            }
            if (txtCommTime.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse("01/01/2015 " + txtCommTime.Text, cult);
                }
                catch { CommTime = "NoDate"; }
            }
            if (txtDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDate.Text, cult);
                }
                catch { Date = "NoDate"; }
            }
            if (txtCommDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDate.Text, cult);
                }
                catch { CommDate = "NoDate"; }
            }
            if (txtTechnicalDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtDate.Text, cult);
                }
                catch { TechDate = "NoDate"; }
            }
            if (txtTenderSubDt.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtTenderSubDt.Text, cult);
                }
                catch { FeeDate = "NoFeeDate"; }
            }

            if (Date != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct tender Date.');</script>");
            }

            else if (FeeDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct tender submission Date.');</script>");
            }

            else if (TechDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct technical Date.');</script>");
            }
            else if (CommDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct commercial Date.');</script>");
            }
            else if (TechTime != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct technical Time.');</script>");
            }
            else if (CommTime != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct commercial Time.');</script>");
            }
            else if (DateTime.Parse(txtDate.Text, cult) > System.DateTime.Now)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender date cannot greater than current date.');</script>");
            }
            else if (DateTime.Parse(txtTenderSubDt.Text, cult) < DateTime.Parse(txtDate.Text, cult))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender submission date should always be greater then tender date.');</script>");
            }
            else if (DateTime.Parse(txtTechnicalDate.Text, cult) < DateTime.Parse(txtDate.Text, cult))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be less then tender date.');</script>");
            }
            else if (DateTime.Parse(txtTenderSubDt.Text, cult) > DateTime.Parse(txtTechnicalDate.Text, cult))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be less then tender submission date.');</script>");
            }
            //else if ((DateTime.Parse(txtCommDate.Text, cult) < DateTime.Parse(txtTechnicalDate.Text, cult)) && txtCommDate.Text != "")
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be greater then Commercial date.');</script>");
            //}
            else if (txtDetails.Text.ToString().Length > 240)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 240 charecter in detail text box.');</script>");
            }
            else if (txtRemark.Text.ToString().Length > 149)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 150 charecter in remark text box.');</script>");
            }
            else if (txtQuantity.Text =="")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Total Required Paper Qunatity');</script>");
            }
            else
            {
                string ImgStatus = "";
                if (fileUp1.FileName == "")
                {
                    ImgStatus = "Ok";
                    FileName = hdnFile.Value.ToString();
                }
                else
                {
                    ImgStatus = objApi.SingleuploadFile(fileUp1, "PaperUploadedFile", 1000);
                    if (ImgStatus == "Ok")
                    {
                        FileName = objApi.FullFileName;
                    }
                }
                string ChkCondtion = "";
                foreach (GridViewRow gv in GrdWorkPlan.Rows)
                {
                    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                    if (chkSelect.Checked == true)
                    {
                        ChkCondtion = "Ok";
                    }

                }
                if (ChkCondtion == "Ok")
                {
                    if (ImgStatus == "Ok")
                    {
                        objTenderInfo = new PPR_TenderInfo();
                        objTenderInfo.EMDAmount_N = float.Parse(txtEMD.Text.Trim());
                        objTenderInfo.WorkName_V = txtNameOfWork.Text.Trim();
                        objTenderInfo.TenderDate_D = Convert.ToDateTime(txtDate.Text.Trim(), cult);
                        objTenderInfo.TenderDescription_V = txtDetails.Text.Replace("'", ""); ;
                        objTenderInfo.TenderFees_N = float.Parse(txtTenderFee.Text);
                        objTenderInfo.TenderFile_V = FileName;
                        objTenderInfo.TenderNo_V = txtRFPNo.Text.Trim().Replace("'", "");
                        objTenderInfo.TenderSubmissionDate_D = Convert.ToDateTime(txtTenderSubDt.Text.Trim(), cult);
                        objTenderInfo.TenderType_V = ddlTenderType.Text;
                        objTenderInfo.UserId_I = int.Parse(Session["UserID"].ToString());
                        objTenderInfo.Remark_V = txtRemark.Text.Trim().Replace("'", ""); ;
                        objTenderInfo.RqcQuantitya = Convert.ToDouble(txtQuantity.Text);
                        objTenderInfo.TechDate = DateTime.Parse(txtTechnicalDate.Text.Trim(), cult);
                        if (txtCommDate.Text == "")
                        { }
                        else
                        {
                            objTenderInfo.CommDate = DateTime.Parse(txtCommDate.Text.Trim(), cult);
                        }
                        objTenderInfo.TechTime = txtTechnicalTime.Text.Trim();
                        if (txtCommDate.Text == "")
                        { }
                        else
                        {
                            objTenderInfo.CommTime = txtCommTime.Text.Trim();
                        }
                        int i = 0;
                        if (Request.QueryString["ID"] != null)
                        {
                            objTenderInfo.TenderTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                            i = objTenderInfo.Update();
                            foreach (GridViewRow gv in GrdWorkPlan.Rows)
                            {
                                CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                                Label lblTechn_TrId = (Label)gv.FindControl("lblTechn_TrId");
                                Label lblTender_Cond_Id = (Label)gv.FindControl("lblTender_Cond_Id");
                                Label lblTnd_Cond_Id = (Label)gv.FindControl("lblTnd_Cond_Id");

                                obCommonFuction.FillDatasetByProc("call USP_PPR004_TenderInfoSaveTermCondition('" + lblTnd_Cond_Id.Text + "','" + objApi.Decrypt(Request.QueryString["ID"].ToString()) + "','" + lblTender_Cond_Id.Text + "','','" + chkSelect.Checked.ToString() + "','" + ddlPaperType.SelectedItem.Value + "')");
                                //int k = objTenderInfo.InsertUpdateCondt(int.Parse(lblTnd_Cond_Id.Text), int.Parse(lblTender_Cond_Id.Text), int.Parse(objApi.Decrypt( Request.QueryString["ID"].ToString())), chkSelect.Checked.ToString());

                            }
                        }
                        else
                        {
                            objTenderInfo.TenderTrId_I = 0;
                            i = objTenderInfo.Insert();
                            try { 
                            obCommonFuction.FillDatasetByProc("call UpdateTenderFyyear('"+DdlACYear.SelectedItem.Text+"',"+i.ToString ()+")");
                            }
                            catch { }
                        }
                        try
                        {

                            if (i > 0)
                            {
                                foreach (GridViewRow gv in GrdWorkPlan.Rows)
                                {
                                    CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
                                    Label lblTechn_TrId = (Label)gv.FindControl("lblTechn_TrId");
                                    Label lblTender_Cond_Id = (Label)gv.FindControl("lblTender_Cond_Id");
                                    //int k = objTenderInfo.InsertUpdateCondt(0, int.Parse(lblTender_Cond_Id.Text), i, chkSelect.Checked.ToString());
                                    obCommonFuction.FillDatasetByProc("call USP_PPR004_TenderInfoSaveTermCondition(0,'" + i + "','" + lblTender_Cond_Id.Text + "','','" + chkSelect.Checked.ToString() + "','" + ddlPaperType.SelectedItem.Value + "')");
                                }
                                if (Request.QueryString["ID"] != null)
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                                    Response.Redirect("ViewPPR_005_TInfo.aspx");
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                                    Response.Redirect("ViewPPR_005_TInfo.aspx");
                                }
                                obCommonFuction.EmptyTextBoxes(this);
                                lblMsg.Text = "";
                                TenderDtlFillById("");
                                ddlPaperType_Init(sender, e);
                                //   Clear();
                            }
                        }
                        catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender No Already Exist.');</script>"); }
                    }
                    else
                    {
                        lblMsg.Text = ImgStatus.ToString();
                        lblMsg.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Check at least one Check box.');</script>");
                }
            }
        }
        catch (Exception ex) { lblMsg.Text = ex.Message.ToString(); }
    }
    public void GridFillLoad()
    {
        try
        {
            objTenderInfo = new PPR_TenderInfo(); 
           // objTenderInfo.TenderTrId_I = int.Parse(objApi.Decrypt( Request.QueryString["ID"].ToString()));
            ds = obCommonFuction.FillDatasetByProc("call USP_PPR004_TenderInfoLoad(" + objApi.Decrypt(Request.QueryString["ID"].ToString()) + ",'" + objApi.Decrypt(Request.QueryString["AcYear"].ToString()) + "')");
            //ds = objTenderInfo.Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime SubDt = new DateTime();

                //
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
                txtDate.Text = dat.ToString("dd/MM/yyyy");
                txtTenderSubDt.Text = SubDt.ToString("dd/MM/yyyy");

                txtDetails.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
                txtEMD.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
                txtNameOfWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
                txtRFPNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
                txtTenderFee.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();
                DdlACYear.SelectedItem.Text = ds.Tables[0].Rows[0]["AcYear"].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0]["RqcQuantity"].ToString();
                try
                {
                   // SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
                    txtCommDate.Text = ds.Tables[0].Rows[0]["CommDate"].ToString();//SubDt.ToString("dd/MM/yyyy");
                }
                catch { }

               // SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TechDate"].ToString());
                txtTechnicalDate.Text =ds.Tables[0].Rows[0]["TechDate"].ToString();// SubDt.ToString("dd/MM/yyyy");


                txtTechnicalTime.Text = ds.Tables[0].Rows[0]["TechTime"].ToString();
                txtCommTime.Text = ds.Tables[0].Rows[0]["CommTime"].ToString();



                hdnFile.Value = ds.Tables[0].Rows[0]["TenderFile_V"].ToString();

                ddlTenderType.Text = ds.Tables[0].Rows[0]["TenderType_V"].ToString();
            }
        }
        catch { }

    }


    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        TenderDtlFillById("");
    }
}
