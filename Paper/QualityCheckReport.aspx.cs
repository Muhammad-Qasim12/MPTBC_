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
using MPTBCBussinessLayer.Paper;
using System.Globalization;
using System.IO;

public partial class Paper_QualityCheckReport : System.Web.UI.Page
{
    DataSet ds, DS;
    string path, FileName;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PPR_LabInspection objLabInspection = null;
    APIProcedure objApi = new APIProcedure();
    int RptSts = 0, TotRptCunt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["TempData"] = "";
            ViewState["LabInspChild_Id_I"] = "";

            if (Request.QueryString["ID"] != null)
            {
                ViewState["LabInspChild_Id_I"] = "";
                InspectionDetailsFill();
            }
            else
            {
                AutoSampleNo();
            }
        }
    }
    public void AutoSampleNo()
    {
        objLabInspection = new PPR_LabInspection();
        ds = objLabInspection.AutoGenSampleNo();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtSampleNo.Text = "S" + ds.Tables[0].Rows[0]["SampleNo"].ToString();
        }
    }
    public void InspectionDetailsFill()
    {
        objLabInspection = new PPR_LabInspection();
        objLabInspection.LabInspectionTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
        DS = objLabInspection.FiledFill();
        if (DS.Tables[0].Rows.Count > 0)
        {
            txtSampleNo.Text = DS.Tables[0].Rows[0]["SampleNo"].ToString();
            ddlSampleFrom.ClearSelection();
            try
            {
                ddlSampleFrom.Items.FindByText(DS.Tables[0].Rows[0]["SampleFrom"].ToString()).Selected = true;
            }
            catch { }
            DateTime Dte = new DateTime();
            try
            {
                Dte = DateTime.Parse(DS.Tables[0].Rows[0]["PprCntrDptDrawDate"].ToString());
                txtSampleDrawDate.Text = Dte.ToString("dd/MM/yyyy");
            }
            catch { }

            vendorFill();
            ddlVendorFill.ClearSelection();
            try
            {
                ddlVendorFill.Items.FindByValue(DS.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true;
            }
            catch { }
            LOIFill();
            ddlLOIFill.ClearSelection();
            try
            {
                ddlLOIFill.Items.FindByValue(DS.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
            }
            catch { }
            GrdOfficerDetail.DataSource = DS.Tables[0];
            GrdOfficerDetail.DataBind();
            RptSts = 0;
            RptSts = DS.Tables[0].Rows.Count;

            if (RptSts >= 2)
            {
                btnADD.Visible = false;
            }
            else
            {
                btnADD.Visible = true;
            }
            txtRemark.Text = DS.Tables[0].Rows[0]["Remark_V"].ToString();
            PaperFill();
            ddlPaperType.SelectedValue = DS.Tables[0].Rows[0]["PaperType_I"].ToString();
            PaperSizeFill();
            ddlPaperSize.SelectedValue = DS.Tables[0].Rows[0]["PaperMstrTrId_I"].ToString();
            LabFill();
            ddlLabName.SelectedValue = DS.Tables[0].Rows[0]["LabTrId_I"].ToString();
            LabaddressFill();


            DateTime SampleDate = DateTime.Parse(DS.Tables[0].Rows[0]["SampleSendDate_D"].ToString());
            txtSendDate.Text = SampleDate.ToString("dd/MM/yyyy");

            ddlLOIFill.Enabled = false;
            ddlVendorFill.Enabled = false;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime DteCheck;
            string RptDate = "";
            if (txtSampleDrawDate.Text != "")
            {
                try
                {
                    DteCheck = DateTime.Parse(txtSampleDrawDate.Text, cult);
                }
                catch { RptDate = "NoDate"; }
            }

            if (RptDate != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct sample Date.');</script>");
            }
            else if (DateTime.Parse(txtSampleDrawDate.Text, cult) > System.DateTime.Now)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sample date cannot greater than current date.');</script>");
            }
            else if (txtInspectionReport.Text.ToString().Length > 199)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 200 charecter in Inspection Report text box.');</script>");

            }

            else if (txtRemark.Text.ToString().Length > 199)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 200 charecter in remark text box.');</script>");

            }

            else
            {
                if (Request.QueryString["ID"] == null)
                {
                    AutoSampleNo();
                }
                objLabInspection = new PPR_LabInspection();
                if (Request.QueryString["ID"] != null)
                {
                    objLabInspection.LabInspectionTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                }
                else
                {
                    objLabInspection.LabInspectionTrId_I = 0;
                }

                objLabInspection.PaperVendorTrId_I = int.Parse(ddlVendorFill.SelectedItem.Value.ToString());
                objLabInspection.LOITrId_I = int.Parse(ddlLOIFill.SelectedItem.Value.ToString());
                objLabInspection.UserId_I = int.Parse(Session["UserID"].ToString());
                objLabInspection.Remark_V = txtRemark.Text.Trim();
                objLabInspection.PprCntrDptDrawDate = DateTime.Parse(txtSampleDrawDate.Text, cult);
                objLabInspection.SampleNo = txtSampleNo.Text.Trim();
                objLabInspection.SampleFrom = ddlSampleFrom.SelectedItem.Text;

                try
                {
                    int i = objLabInspection.MasterInsertUpdate();
                    if (i > 0)
                    {
                         
                        if (Request.QueryString["ID"] != null)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                            Response.Redirect("ViewQualityCheckReport.aspx");
                        }
                        else
                        {
                            string SaveSts = "";
                            foreach (GridViewRow gv in GrdOfficerDetail.Rows)
                            {
                                Label lblLabTrId_I = (Label)gv.FindControl("lblLabTrId_I");
                                Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                Label lblSampleSendDate_D = (Label)gv.FindControl("lblSampleSendDate_D");
                                Label lblSampleReceiveDate_D = (Label)gv.FindControl("lblSampleReceiveDate_D");
                                Label lblLabInspectionReport_V = (Label)gv.FindControl("lblLabInspectionReport_V");
                                Label lblQualityCheckStatus_I = (Label)gv.FindControl("lblQualityCheckStatus_I");
                                Label lblLabInspectionFile_V = (Label)gv.FindControl("lblLabInspectionFile_V");
                                Label lblReportNo = (Label)gv.FindControl("lblReportNo");
                                Label lblReportDate = (Label)gv.FindControl("lblReportDate");
                                //string a = DateTime.Now.ToString();
                                // Label lblReportDate = a;

                                objLabInspection.ReportNo = lblReportNo.Text;
                                try
                                {
                                    objLabInspection.ReportDate = DateTime.Now;
                                }
                                catch { }
                                objLabInspection.LabInspectionTrId_I = i;
                                objLabInspection.LabInspChild_Id_I = 0;
                                objLabInspection.LabTrId_I = int.Parse(lblLabTrId_I.Text.Trim());
                                try
                                {
                                    objLabInspection.SampleSendDate_D = DateTime.Parse(lblSampleSendDate_D.Text, cult);
                                }
                                catch { }
                                try
                                {
                                    // objLabInspection.SampleReceiveDate_D = DateTime.Parse(lblSampleReceiveDate_D.Text, cult);
                                    objLabInspection.SampleReceiveDate_D = DateTime.Now;
                                }
                                catch { }
                                objLabInspection.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
                                objLabInspection.PaperType_I = int.Parse(lblPaperType_I.Text);
                                objLabInspection.LabInspectionReport_V = lblLabInspectionReport_V.Text;
                                objLabInspection.QualityCheckStatus_I = int.Parse(lblQualityCheckStatus_I.Text.ToString());
                                objLabInspection.LabInspectionFile_V = lblLabInspectionFile_V.Text;
                                // objLabInspection.InsertUpdate();
                                InsertUpdateNew(objLabInspection);
                                SaveSts = "Yes";
                                Response.Redirect("ViewQualityCheckReport.aspx");

                            }

                            if (SaveSts == "Yes")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                                obCommonFuction.EmptyTextBoxes(this);
                                txtLabAddress.Text = "";
                                rbQualitycheck.SelectedValue = "2";
                                lblMsg.Text = "";
                                GrdOfficerDetail.DataSource = string.Empty;
                                GrdOfficerDetail.DataBind();
                                ViewState["LabInspChild_Id_I"] = "";
                                ViewState["TempData"] = "";
                                btnADD.Visible = true;
                                chkSample.Visible = false;
                                Response.Redirect("ViewQualityCheckReport.aspx");
                            }
                            //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                            ViewState["LabInspChild_Id_I"] = "";
                            if (Request.QueryString["ID"] == null)
                            {
                                AutoSampleNo();
                            }

                        }
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sample No Already Exist.');</script>"); ViewState["LabInspChild_Id_I"] = ""; }
            }
            ViewState["LabInspChild_Id_I"] = "";
        }
        catch { }
        Response.Redirect("ViewQualityCheckReport.aspx");
    }

    public void vendorFill()
    {
        objLabInspection = new PPR_LabInspection();
        ddlVendorFill.DataSource = objLabInspection.VendorFill();
        ddlVendorFill.DataTextField = "PaperVendorName_V";
        ddlVendorFill.DataValueField = "PaperVendorTrId_I";
        ddlVendorFill.DataBind();
        ddlVendorFill.Items.Insert(0, "Select");
    }
    protected void ddlVendorFill_Init(object sender, EventArgs e)
    {
        vendorFill();
    }
    public void LabFill()
    {
        objLabInspection = new PPR_LabInspection();
        ddlLabName.DataSource = objLabInspection.LabFill();
        ddlLabName.DataTextField = "LabName";
        ddlLabName.DataValueField = "LabTrId_I";
        ddlLabName.DataBind();
        ddlLabName.Items.Insert(0, "Select");
    }
    protected void ddlLabName_Init(object sender, EventArgs e)
    {
        LabFill();
    }
    public void LabaddressFill()
    {
        if (ddlLabName.SelectedItem.Text != "Select")
        {
            objLabInspection = new PPR_LabInspection();
            objLabInspection.LabTrId_I = int.Parse(ddlLabName.SelectedItem.Value);
            ds = objLabInspection.LabAddressFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtLabAddress.Text = ds.Tables[0].Rows[0]["LabAddress"].ToString();
            }
        }
        else
        {
            txtLabAddress.Text = "";
        }
    }
    protected void ddlLabName_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabaddressFill();
    }
    public void LOIFill()
    {
        if (ddlVendorFill.SelectedItem.Text != "Select")
        {

            ppr_VoucharDetails objPaperVoucharDetails = new ppr_VoucharDetails();
            objPaperVoucharDetails.PaperVendorTrId_I = int.Parse(ddlVendorFill.SelectedItem.Value);
            DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetLoiByVendorandAcYear (" + objPaperVoucharDetails.PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "')");
            //ds1 = objPaperVoucharDetails.LOINoFill();

            if (ds1.Tables[0].Rows.Count > 0)
            {
                ddlLOIFill.DataSource = ds1.Tables[0];
                // ddlLOIFill.DataSource = ds.Tables[0];
                ddlLOIFill.DataTextField = "LOINo_V";
                ddlLOIFill.DataValueField = "LOITrId_I";
                ddlLOIFill.DataBind();
                ddlLOIFill.Items.Insert(0, "Select");
            }
            else
            {
                ddlLOIFill.DataSource = string.Empty;
                ddlLOIFill.DataBind();
                ddlLOIFill.Items.Insert(0, "Select");
            }
        }
        else
        {
            ddlLOIFill.DataSource = string.Empty;
            ddlLOIFill.DataBind();
            ddlLOIFill.Items.Insert(0, "Select");
        }
    }
    protected void ddlVendorFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIFill();
    }

    public void PaperFill()
    {
        if (ddlLOIFill.SelectedItem.Text != "Select")
        {
            objLabInspection = new PPR_LabInspection();
            objLabInspection.LOITrId_I = int.Parse(ddlLOIFill.SelectedItem.Value);
            ddlPaperType.DataSource = objLabInspection.PaperTypeFill();
            ddlPaperType.DataTextField = "PaperType";
            ddlPaperType.DataValueField = "PaperType_I";
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
        }
        else
        {
            ddlPaperType.DataSource = string.Empty;
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
        }
    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperFill();
    }
    public void PaperSizeFill()
    {
        if (ddlPaperType.SelectedItem.Text != "Select")
        {
            objLabInspection = new PPR_LabInspection();
            objLabInspection.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
            objLabInspection.LOITrId_I = int.Parse(ddlLOIFill.SelectedItem.Value);
            ds = objLabInspection.PaperSizeFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlPaperSize.DataSource = ds.Tables[0];
                ddlPaperSize.DataTextField = "CoverInformation";
                ddlPaperSize.DataValueField = "PaperMstrTrId_I";
                ddlPaperSize.DataBind();
                ddlPaperSize.Items.Insert(0, "Select");
            }
        }
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        PaperSizeFill();
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string Date = "", FeeDate = "", RptDate = "";
        if (txtSendDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtSendDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }

        if (txtReportDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtReportDate.Text, cult);
            }
            catch { FeeDate = "NoFeeDate"; }
        }

        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct paper send Date.');</script>");
        }
        else if (Date != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Received date.');</script>");
        }
        else if (FeeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Report date.');</script>");
        }
        else if (DateTime.Parse(txtSendDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Send date cannot greater than current date.');</script>");
        }


        else if (ddlVendorFill.SelectedItem.Text == "Select" || ddlLOIFill.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select All Fileds.');</script>");
        }
        else
        {

            if (Request.QueryString["ID"] != null)
            {
                int CuntDta = 0;
                string ImgStatus = "";
                if (fileUp1.FileName == "")
                {
                    ImgStatus = "Ok";
                    FileName = hdnFile.Value.ToString();
                }
                else
                {
                    ImgStatus = objApi.uploadFile(fileUp1, "PaperUploadedFile", 1000);
                    if (ImgStatus == "Ok")
                    {
                        FileName = objApi.FullFileName;
                    }
                }

                if (ImgStatus == "Ok")
                {
                    if (Request.QueryString["ID"] != null)
                    {
                        if (ViewState["LabInspChild_Id_I"] != "")
                        {
                            objLabInspection = new PPR_LabInspection();
                            objLabInspection.LabInspectionTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                            objLabInspection.LabInspChild_Id_I = int.Parse(ViewState["LabInspChild_Id_I"].ToString());
                            objLabInspection.LabTrId_I = int.Parse(ddlLabName.SelectedItem.Value.Trim());
                            objLabInspection.SampleSendDate_D = DateTime.Parse(txtSendDate.Text, cult);
                            objLabInspection.SampleReceiveDate_D = DateTime.Parse(txtRecivedDate.Text, cult);
                            objLabInspection.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedItem.Value);
                            objLabInspection.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
                            objLabInspection.LabInspectionReport_V = txtInspectionReport.Text;
                            objLabInspection.QualityCheckStatus_I = int.Parse(rbQualitycheck.SelectedItem.Value);
                            objLabInspection.LabInspectionFile_V = FileName.ToString();
                            objLabInspection.ReportNo = txtReportNo.Text;
                            objLabInspection.ReportDate = DateTime.Parse(txtReportDate.Text, cult);

                            //objLabInspection.InsertUpdate();
                            InsertUpdateNew(objLabInspection);

                            ViewState["LabInspChild_Id_I"] = "";

                            objLabInspection.LabInspectionTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                            ds = objLabInspection.FiledFill();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                GrdOfficerDetail.DataSource = ds.Tables[0];
                                GrdOfficerDetail.DataBind();
                                CuntDta = 0;
                                CuntDta = ds.Tables[0].Rows.Count;

                                if (CuntDta >= 2)
                                {
                                    btnADD.Visible = false;
                                }
                                else
                                {
                                    btnADD.Visible = true;
                                }
                            }
                            rbQualitycheck.SelectedValue = "2";
                            ddlLabName.SelectedIndex = 0;
                            ddlPaperSize.SelectedIndex = 0;
                            ddlPaperType.SelectedIndex = 0;
                            txtSendDate.Text = "";
                            txtRecivedDate.Text = "";
                            txtRemark.Text = "";
                            txtLabAddress.Text = "";
                            txtInspectionReport.Text = "";
                            txtReportDate.Text = "";
                            txtReportNo.Text = "";
                            txtLabAddress.Text = ""; lblMsg.Text = "";
                        }
                        else
                        {
                            objLabInspection = new PPR_LabInspection();
                            objLabInspection.LabInspectionTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                            objLabInspection.LabInspChild_Id_I = 0;
                            objLabInspection.LabTrId_I = int.Parse(ddlLabName.SelectedItem.Value.Trim());
                            objLabInspection.SampleSendDate_D = DateTime.Parse(txtSendDate.Text, cult);
                            objLabInspection.SampleReceiveDate_D = DateTime.Parse(txtRecivedDate.Text, cult);
                           
                            objLabInspection.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedItem.Value);
                            objLabInspection.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
                            objLabInspection.LabInspectionReport_V = txtInspectionReport.Text;
                            objLabInspection.QualityCheckStatus_I = int.Parse(rbQualitycheck.SelectedItem.Value);
                            objLabInspection.LabInspectionFile_V = FileName.ToString();
                            objLabInspection.ReportNo = txtReportNo.Text;
                            objLabInspection.ReportDate = DateTime.Parse(txtReportDate.Text, cult);
                           
                            // objLabInspection.InsertUpdate();
                            InsertUpdateNew(objLabInspection);
                            ViewState["LabInspChild_Id_I"] = "";
                            ds = objLabInspection.FiledFill();
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                GrdOfficerDetail.DataSource = ds.Tables[0];
                                GrdOfficerDetail.DataBind();
                                CuntDta = 0;
                                CuntDta = ds.Tables[0].Rows.Count;

                                if (CuntDta >= 2)
                                {
                                    btnADD.Visible = false;
                                }
                                else
                                {
                                    btnADD.Visible = true;
                                }
                            }
                            rbQualitycheck.SelectedValue = "2";
                            ddlLabName.SelectedIndex = 0;
                            ddlPaperSize.SelectedIndex = 0;
                            ddlPaperType.SelectedIndex = 0;
                            txtSendDate.Text = "";
                            txtRecivedDate.Text = "";
                            txtRemark.Text = "";
                            txtLabAddress.Text = "";
                            txtInspectionReport.Text = "";
                            txtReportDate.Text = "";
                            txtReportNo.Text = "";
                            txtLabAddress.Text = "";
                            lblMsg.Text = "";
                        }

                    }
                }
                else
                {
                    lblMsg.Text = ImgStatus.ToString();
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
                ViewState["LabInspChild_Id_I"] = "";
            }
            else
            {


                DataBindToGrid();

            }
        }
    }
    protected void GrdOfficerDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            Label lblQualityCheckStatus = (Label)e.Row.FindControl("lblQualityCheckStatus");
            if (Request.QueryString["ID"] != null)
            {
                LinkButton lnkUpdate = (LinkButton)e.Row.FindControl("lnkUpdate");
                Label lblSampleSendDate_D = (Label)e.Row.FindControl("lblSampleSendDate_D");
                Label lblSampleReceiveDate_D = (Label)e.Row.FindControl("lblSampleReceiveDate_D");


                if (lblQualityCheckStatus.Text == "Yes")
                {
                    RptSts = RptSts + 1;
                }
                TotRptCunt = TotRptCunt + 1;

                Label lblReportDate = (Label)e.Row.FindControl("lblReportDate");
                lnkUpdate.Visible = true;
                lnkDelete.Visible = false;
                Label lblPBGDate_D = (Label)e.Row.FindControl("lblPBGDate_D");
                //DateTime dat = new DateTime();
                //dat = DateTime.Parse(lblSampleSendDate_D.Text);
                //lblSampleSendDate_D.Text = dat.ToString("dd/MM/yyyy");
                //dat = DateTime.Parse(lblSampleReceiveDate_D.Text);
                //lblSampleReceiveDate_D.Text = dat.ToString("dd/MM/yyyy");
                lblSampleReceiveDate_D.Text = DateTime.Parse(lblSampleSendDate_D.Text).ToString("dd/MM/yyyy");
                try
                {
                    //dat = DateTime.Parse(lblReportDate.Text);
                    lblReportDate.Text = DateTime.Parse(lblReportDate.Text).ToString("dd/MM/yyyy");
                }
                catch { }
            }
            else
            {
                TotRptCunt = TotRptCunt + 1;
                lnkDelete.Visible = true;
                if (lblQualityCheckStatus.Text == "Yes")
                {
                    RptSts = RptSts + 1;
                }

            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            if (RptSts <= 1 && TotRptCunt >= 2)
            {
                chkSample.Visible = true;
            }
            else
            {
                chkSample.Visible = false;
            }
        }

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblLabTrId_I = (Label)gv.FindControl("lblLabTrId_I");

        DataTable Dt = new DataTable();
        Dt = (DataTable)ViewState["TempData"];
        for (int i = 0; i < Dt.Rows.Count; i++)
        {
            string PBGNo_V = "";
            PBGNo_V = Dt.Rows[i]["LabTrId_I"].ToString();
            if (lblLabTrId_I.Text.ToLower() == PBGNo_V.ToLower())
            {
                Dt.Rows.RemoveAt(i);
                Dt.AcceptChanges();
            }
        }
        if (Dt.Rows.Count > 0)
        {
            ViewState["TempData"] = Dt;
        }
        else
        {
            ViewState["TempData"] = "";
            btnADD.Visible = true;
            chkSample.Visible = false;
        }
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");

        GrdOfficerDetail.DataSource = Dt;
        GrdOfficerDetail.DataBind();
    }
    public void DataBindToGrid()
    {
        int CuntDta = 0;
        string ImgStatus = "";
        if (fileUp1.FileName == "")
        {
            ImgStatus = "Ok";
            FileName = hdnFile.Value.ToString();
        }
        else
        {
            ImgStatus = objApi.uploadFile(fileUp1, "PaperUploadedFile", 1000);
            if (ImgStatus == "Ok")
            {
                FileName = objApi.FullFileName;
            }
        }

        if (ImgStatus == "Ok")
        {

            if (ViewState["TempData"] == null || ViewState["TempData"] == "")
            {
                DataTable dt = new DataTable();


                dt.Columns.Add("LabTrId_I", typeof(string));
                dt.Columns.Add("LabName", typeof(string));
                dt.Columns.Add("SampleSendDate_D", typeof(string));
                dt.Columns.Add("SampleReceiveDate_D", typeof(string));
                dt.Columns.Add("PaperMstrTrId_I", typeof(string));
                dt.Columns.Add("PaperSize_V", typeof(string));
                dt.Columns.Add("PaperType_I", typeof(string));
                dt.Columns.Add("PaperType", typeof(string));
                dt.Columns.Add("LabInspectionReport_V", typeof(string));
                dt.Columns.Add("QualityCheckStatus_I", typeof(string));
                dt.Columns.Add("LabInspectionFile_V", typeof(string));
                dt.Columns.Add("QualityCheckStatus", typeof(string));
                dt.Columns.Add("LabInspChild_Id_I", typeof(string));
                dt.Columns.Add("ReportDate", typeof(string));
                dt.Columns.Add("ReportNo", typeof(string));



                DataRow Dr = dt.NewRow();
                Dr["LabInspChild_Id_I"] = 0;
                Dr["LabTrId_I"] = ddlLabName.SelectedItem.Value;
                Dr["LabName"] = ddlLabName.SelectedItem.Text;
                Dr["SampleSendDate_D"] = txtSendDate.Text;
                Dr["SampleReceiveDate_D"] = txtRecivedDate.Text;
                Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value;
                Dr["PaperSize_V"] = ddlPaperSize.SelectedItem.Text;
                Dr["PaperType_I"] = ddlPaperType.SelectedItem.Value.ToString();
                Dr["PaperType"] = ddlPaperType.SelectedItem.Text.ToString();
                Dr["LabInspectionReport_V"] = txtInspectionReport.Text.ToString();
                Dr["QualityCheckStatus_I"] = rbQualitycheck.SelectedItem.Value;
                Dr["QualityCheckStatus"] = rbQualitycheck.SelectedItem.Text;
                Dr["LabInspectionFile_V"] = FileName;
                Dr["ReportDate"] = txtReportDate.Text;
                Dr["ReportNo"] = txtReportNo.Text;



                dt.Rows.Add(Dr);
                ViewState["TempData"] = dt;
                GrdOfficerDetail.DataSource = dt;
                GrdOfficerDetail.DataBind();
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
                        Dr["LabInspChild_Id_I"] = 0;
                        Dr["LabTrId_I"] = ddlLabName.SelectedItem.Value.ToString();
                        Dr["LabName"] = ddlLabName.SelectedItem.Text;
                        Dr["SampleSendDate_D"] = txtSendDate.Text;
                        Dr["SampleReceiveDate_D"] = txtRecivedDate.Text;
                        Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value;
                        Dr["PaperSize_V"] = ddlPaperSize.SelectedItem.Text;
                        Dr["PaperType_I"] = ddlPaperType.SelectedItem.Value.ToString();
                        Dr["PaperType"] = ddlPaperType.SelectedItem.Text.ToString();
                        Dr["LabInspectionReport_V"] = txtInspectionReport.Text.ToString();
                        Dr["QualityCheckStatus_I"] = rbQualitycheck.SelectedItem.Value;
                        Dr["QualityCheckStatus"] = rbQualitycheck.SelectedItem.Text;
                        Dr["LabInspectionFile_V"] = FileName;
                        Dr["ReportDate"] = txtReportDate.Text;
                        Dr["ReportNo"] = txtReportNo.Text;
                    }
                    if (dt.Rows[0].ToString() == "")
                    {
                        dt.Rows[0].Delete();
                        dt.AcceptChanges();
                    }
                    string Ckh = "";
                    foreach (DataRow drt in dt.Rows)
                    {
                        if (ddlLabName.SelectedItem.Value == drt["LabTrId_I"].ToString())
                        {
                            Ckh = "Yes";
                        }
                    }
                    if (Ckh == "Yes")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Lab Already Exist.');</script>");
                    }
                    else
                    {
                        dt.Rows.Add(Dr);
                    }
                    ViewState["TempData"] = dt;
                }

                GrdOfficerDetail.DataSource = dt;
                GrdOfficerDetail.DataBind();
                CuntDta = dt.Rows.Count;

                if (CuntDta >= 2)
                {
                    btnADD.Visible = false;
                }
                else
                {
                    btnADD.Visible = true;
                }
            }
        }
        else
        {
            lblMsg.Text = ImgStatus.ToString();
            lblMsg.ForeColor = System.Drawing.Color.Red;
        }

        ddlLabName.SelectedIndex = 0;
        txtSendDate.Text = "";
        txtRecivedDate.Text = "";
        ddlPaperSize.SelectedIndex = 0;
        ddlPaperType.SelectedIndex = 0;
        txtInspectionReport.Text = "";
        rbQualitycheck.SelectedIndex = 2;
        txtLabAddress.Text = "";
        txtReportDate.Text = "";
        txtReportNo.Text = "";

    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblLabTrId_I = (Label)gv.FindControl("lblLabTrId_I");
        Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
        Label lblSampleSendDate_D = (Label)gv.FindControl("lblSampleSendDate_D");
        Label lblSampleReceiveDate_D = (Label)gv.FindControl("lblSampleReceiveDate_D");
        Label lblLabInspectionReport_V = (Label)gv.FindControl("lblLabInspectionReport_V");
        Label lblQualityCheckStatus_I = (Label)gv.FindControl("lblQualityCheckStatus_I");
        Label lblLabInspectionFile_V = (Label)gv.FindControl("lblLabInspectionFile_V");
        Label lblLabInspChild_Id_I = (Label)gv.FindControl("lblLabInspChild_Id_I");
        Label lblReportNo = (Label)gv.FindControl("lblReportNo");
        Label lblReportDate = (Label)gv.FindControl("lblReportDate");


        ViewState["LabInspChild_Id_I"] = lblLabInspChild_Id_I.Text;
        txtSendDate.Text = lblSampleSendDate_D.Text;
        txtReportNo.Text = lblReportNo.Text;
        txtReportDate.Text = lblReportDate.Text;

        txtRecivedDate.Text = lblSampleReceiveDate_D.Text;

        rbQualitycheck.SelectedValue = lblQualityCheckStatus_I.Text;
        hdnFile.Value = lblLabInspectionFile_V.Text;
        txtInspectionReport.Text = lblLabInspectionReport_V.Text;

        LabFill();
        ddlLabName.SelectedValue = lblLabTrId_I.Text;
        LabaddressFill();

        PaperFill();
        ddlPaperType.ClearSelection();
        try
        {
            ddlPaperType.Items.FindByValue(lblPaperType_I.Text).Selected = true;
        }
        catch { }
        PaperSizeFill();
        ddlPaperSize.ClearSelection();
        try
        {
            ddlPaperSize.Items.FindByValue(lblPaperMstrTrId_I.Text).Selected = true;
        }
        catch { }

        btnADD.Visible = true;
    }
    protected void chkSample_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSample.Checked == true)
        {
            btnADD.Visible = true;
            chkSample.Visible = false;
            chkSample.Checked = false;
            PaperFill();
            ViewState["LabInspChild_Id_I"] = "";
        }
        else
        {
            PaperFill();
            chkSample.Checked = false;
            btnADD.Visible = false;
        }
    }
    protected void ddlLOIFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        PaperFill();
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {

        LOIFill();
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();



        }
        catch { }
    }

    public int InsertUpdateNew(PPR_LabInspection obj)
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0010_LabInspectionSaveData", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mLabInspectionTrId_I", obj.LabInspectionTrId_I);
        obDBAccess.addParam("mLabTrId_I", obj.LabTrId_I);
        obDBAccess.addParam("mLabInspChild_Id_I", obj.LabInspChild_Id_I);
        obDBAccess.addParam("mSampleSendDate_D", obj.SampleSendDate_D);
        obDBAccess.addParam("mSampleReceiveDate_D", obj.SampleReceiveDate_D);
        obDBAccess.addParam("mPaperMstrTrId_I", obj.PaperMstrTrId_I);
        obDBAccess.addParam("mPaperType_I", obj.PaperType_I);
        obDBAccess.addParam("mLabInspectionReport_V", obj.LabInspectionReport_V);
        obDBAccess.addParam("mQualityCheckStatus_I", obj.QualityCheckStatus_I);
        obDBAccess.addParam("mLabInspectionFile_V", obj.LabInspectionFile_V);
        obDBAccess.addParam("mReportNo", obj.ReportNo);
        obDBAccess.addParam("mReportDate", obj.ReportDate);
        obDBAccess.addParam("mAcYear", ddlAcYear.SelectedItem.Text);
        int result = obDBAccess.executeMyQuery();
        return result;
    }
}
