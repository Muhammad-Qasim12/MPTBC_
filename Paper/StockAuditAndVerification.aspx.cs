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
using System.Globalization;
using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Paper;

public partial class Paper_StockAuditAndVerification : System.Web.UI.Page
{
    DataSet ds;
    string path, FileName;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PPR_StockAuditAndVerification objStockAuditAndVerification = null;
    APIProcedure objApi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["TempData"] = "";
            if (Request.QueryString["ID"] != null)
            {
                InspectionDetailsFill();
            }
        }
    }
    public void InspectionDetailsFill()
    {
        objStockAuditAndVerification = new PPR_StockAuditAndVerification();
        objStockAuditAndVerification.AuditTrId_I = int.Parse(objApi.Decrypt( Request.QueryString["ID"].ToString()));
        ds = objStockAuditAndVerification.StorageDetailsFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnADD.Visible = false;
            DateTime dte = new DateTime();
            dte = DateTime.Parse(ds.Tables[0].Rows[0]["VerificationDate_D"].ToString());
            txtInspectionDate.Text = dte.ToString("dd/MM/yyyy");
            txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
            txtVerificationRpt.Text = ds.Tables[0].Rows[0]["VerificationReport_V"].ToString();
            hdnFile.Value = ds.Tables[0].Rows[0]["VerifcationReportFile_V"].ToString();
            LOIFill();
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
            ddlLOINo.Enabled = false;
            objStockAuditAndVerification.AuditTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));


            GrdOfficerDetail.DataSource = objStockAuditAndVerification.StorageDetailsFill();
            GrdOfficerDetail.DataBind();

        }

    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblOfficeid = (Label)gv.FindControl("lblOfficeid");
        Label lblPost = (Label)gv.FindControl("lblPost");
        Label lblAuditDtld_I = (Label)gv.FindControl("lblAuditDtld_I");

        OfficeFill();
        ddlOfficeName.ClearSelection();
        ddlOfficeName.Items.FindByValue(lblOfficeid.Text).Selected = true;
        txtDesignation.Text = lblPost.Text;
        hdChildId.Value = lblAuditDtld_I.Text;
        btnADD.Visible = true;
    }
    public void DataBindToGrid()
    {
        if (ViewState["TempData"] == null || ViewState["TempData"] == "")
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("OfficeName", typeof(string));
            dt.Columns.Add("OfficerPost", typeof(string));
            dt.Columns.Add("OfficerId", typeof(string));
            dt.Columns.Add("AuditDtld_I", typeof(string));



            DataRow Dr = dt.NewRow();
            Dr["OfficeName"] = ddlOfficeName.SelectedItem.Text;
            Dr["OfficerId"] = ddlOfficeName.SelectedItem.Value.ToString();
            Dr["OfficerPost"] = txtDesignation.Text;
            Dr["AuditDtld_I"] = "0";

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
                    Dr["OfficeName"] = ddlOfficeName.SelectedItem.Text;
                    Dr["OfficerId"] = ddlOfficeName.SelectedItem.Value.ToString();
                    Dr["OfficerPost"] = txtDesignation.Text;

                    Dr["AuditDtld_I"] = "0";
                }
                if (dt.Rows[0].ToString() == "")
                {
                    dt.Rows[0].Delete();
                    dt.AcceptChanges();
                }
                string Ckh = "";
                foreach (DataRow drt in dt.Rows)
                {
                    if (ddlOfficeName.SelectedItem.Value == drt["OfficerId"].ToString())
                    {
                        Ckh = "Yes";
                    }
                }
                if (Ckh == "Yes")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Officer Already Exist.');</script>");
                }
                else
                {
                    dt.Rows.Add(Dr);
                }
               
                ViewState["TempData"] = dt;
            }

            GrdOfficerDetail.DataSource = dt;
            GrdOfficerDetail.DataBind();
        }
        ddlOfficeName.SelectedIndex = 0;
        txtDesignation.Text = "";
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblOfficeid = (Label)gv.FindControl("lblOfficeid");

        DataTable Dt = new DataTable();
        Dt = (DataTable)ViewState["TempData"];
        for (int i = 0; i < Dt.Rows.Count; i++)
        {
            string PBGNo_V = "";
            PBGNo_V = Dt.Rows[i]["OfficerId"].ToString();
            if (lblOfficeid.Text.ToLower() == PBGNo_V.ToLower())
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
        }

        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GrdOfficerDetail.DataSource = Dt;
        GrdOfficerDetail.DataBind();
    }
    protected void GrdOfficerDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            LinkButton lnkUpdate = (LinkButton)e.Row.FindControl("lnkUpdate");

            if (Request.QueryString["ID"] != null)
            {
                lnkDelete.Visible = false;
                lnkUpdate.Visible = true;

            }
            else
            {
                lnkUpdate.Visible = false;
                lnkDelete.Visible = true;
            }
        }
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {

            objStockAuditAndVerification.AuditDtld_I = int.Parse(hdChildId.Value.ToString());

            objStockAuditAndVerification.OfficerId = int.Parse(ddlOfficeName.SelectedItem.Value);
            objStockAuditAndVerification.OfficerPost = ddlOfficeName.SelectedItem.Text.ToString();
            objStockAuditAndVerification.OfficerInsertUpdate();
            objStockAuditAndVerification.AuditTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
            GrdOfficerDetail.DataSource = objStockAuditAndVerification.StorageDetailsFill();
            GrdOfficerDetail.DataBind();
            hdChildId.Value = "";
            txtDesignation.Text = "";
            ddlOfficeName.SelectedIndex = 0;
            btnADD.Visible = false;
        }
        else
        {
            DataBindToGrid();
        }
    }
    public void LOIFill()
    {
        objStockAuditAndVerification = new PPR_StockAuditAndVerification();
        ddlLOINo.DataSource = objStockAuditAndVerification.LOIFill();

        DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_GetLoiByVendorandAcYear (0,'" + ddlAcYear.SelectedItem.Text + "')");
        ddlLOINo.DataSource = ds1.Tables[0];
        ddlLOINo.DataTextField = "LOINo_V";
        ddlLOINo.DataValueField = "LOITrId_I";
        ddlLOINo.DataBind();
        ddlLOINo.Items.Insert(0, "Select");
    }
    protected void ddlLOINo_Init(object sender, EventArgs e)
    {
        LOIFill();
    }

    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string RptDate = "";
        if (txtInspectionDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtInspectionDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }

        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Date.');</script>");
        }
        else if (DateTime.Parse(txtInspectionDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Inspection date cannot greater than current date.');</script>");
        }
        else if (GrdOfficerDetail.Rows.Count > 0)
        {
            string ImgStatus = ""; string filename = "";
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
                objStockAuditAndVerification = new PPR_StockAuditAndVerification();
                objStockAuditAndVerification.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
                objStockAuditAndVerification.Remark_V = txtRemark.Text;
                objStockAuditAndVerification.VerifcationReportFile_V = FileName;
                objStockAuditAndVerification.VerificationReport_V = txtVerificationRpt.Text;
                objStockAuditAndVerification.VerificationDate_D = DateTime.Parse(txtInspectionDate.Text, cult);
                objStockAuditAndVerification.UserId_I = int.Parse(Session["UserID"].ToString());
                if (Request.QueryString["ID"] != null)
                {
                    objStockAuditAndVerification.AuditTrId_I = int.Parse(objApi.Decrypt(Request.QueryString["ID"].ToString()));
                }
                else
                {
                    objStockAuditAndVerification.AuditTrId_I = 0;
                }

                if (Request.QueryString["ID"] != null)
                {
                    //int i = objStockAuditAndVerification.Update();
                    int i = InsertUpdateNew(objStockAuditAndVerification);

                    if (i > 0)
                    {
                        ViewState["TempData"] = "";
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        Response.Redirect("ViewPPR_012_SAAndV.aspx");
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Not Changed.');</script>");
                    }
                }
                else
                {
                    int i = InsertUpdateNew(objStockAuditAndVerification);
                    //int i = objStockAuditAndVerification.InsertUpdate();
                    if (i > 0)
                    {
                        string CheckSts = "No";
                        foreach (GridViewRow gv in GrdOfficerDetail.Rows)
                        {
                            Label lblInspectionDate = (Label)gv.FindControl("lblInspectionDate");
                            Label lblOfficeid = (Label)gv.FindControl("lblOfficeid");
                            Label lblPost = (Label)gv.FindControl("lblPost");
                            objStockAuditAndVerification.OfficerId = int.Parse(lblOfficeid.Text);
                            objStockAuditAndVerification.OfficerPost = lblPost.Text;
                            objStockAuditAndVerification.AuditTrId_I = i;
                            objStockAuditAndVerification.AuditDtld_I = 0;
                            objStockAuditAndVerification.OfficerInsertUpdate();
                            CheckSts = "Ok";
                        }
                        if (CheckSts == "Ok")
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                            obCommonFuction.EmptyTextBoxes(this);
                            lblMsg.Text = "";
                            GrdOfficerDetail.DataSource = string.Empty;
                            GrdOfficerDetail.DataBind();
                            ViewState["TempData"] = "";
                        }
                    }
                }
            }
            else
            {
                lblMsg.Text = ImgStatus.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Add Officer Detail.');</script>");
            ViewState["TempData"] = "";
        }
    }
    public void OfficeFill()
    {
        objStockAuditAndVerification = new PPR_StockAuditAndVerification();
        ddlOfficeName.DataSource = objStockAuditAndVerification.OfficerDesignationmFill();
        ddlOfficeName.DataTextField = "Name";
        ddlOfficeName.DataValueField = "OffDesId_i";
        ddlOfficeName.DataBind();
        ddlOfficeName.Items.Insert(0, "Select");
    }
    protected void ddlOfficeName_Init(object sender, EventArgs e)
    {
        OfficeFill();
    }
    protected void ddlOfficeName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlOfficeName.SelectedItem.Text != "Select")
        {
            objStockAuditAndVerification = new PPR_StockAuditAndVerification();
            ds = objStockAuditAndVerification.OfficerPostFill(int.Parse(ddlOfficeName.SelectedValue.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtDesignation.Text = ds.Tables[0].Rows[0]["Post"].ToString();
            }
        }
        else
        { txtDesignation.Text = ""; }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            //ds = obCommonFuction.FillDatasetByProc("call ppr_GetAcYearAllTbl(1)");
            //ddlAcYear.DataSource = ds.Tables[0];
            //ddlAcYear.DataTextField = "AcYear";
            //ddlAcYear.DataBind();
            //   ddlAcYear.Items.Insert(0, "Select");


            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
        }
        catch { }
    }
    public int InsertUpdateNew(PPR_StockAuditAndVerification obj)
    {

        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0017_PaperStockAuditAndVerifSave", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mAuditTrId_I", obj.AuditTrId_I);
        obDBAccess.addParam("mLOITrId_I", obj.LOITrId_I);
        obDBAccess.addParam("mVerificationReport_V", obj.VerificationReport_V);
        obDBAccess.addParam("mRemark_V", obj.Remark_V);
        obDBAccess.addParam("mVerifcationReportFile_V", obj.VerifcationReportFile_V);
        obDBAccess.addParam("mVerificationDate_D", obj.VerificationDate_D);
        obDBAccess.addParam("mUserId_I", obj.UserId_I);
        obDBAccess.addParam("mAcYear", ddlAcYear.SelectedItem.Text);
        int i = Convert.ToInt32(obDBAccess.executeMyScalar());


        return i;
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIFill(); 
    }
}
