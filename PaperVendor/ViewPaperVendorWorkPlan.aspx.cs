using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Paper_ViewVendorAgreement : System.Web.UI.Page
{
    CommonFuction objComm = new CommonFuction();
    DataSet ds;
    PPR_WorkPlan objWorkPlan = null;
    public string AgreementDate, AgreementNo, Validity, PBGAMT, PBGNo, LOITo, LOIDate, LOINo;
    string PaperVendorTrId_I = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objWorkPlan = new PPR_WorkPlan();
            objWorkPlan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
            GrdAgreement.DataSource = objComm.FillDatasetByProc("call USP_PaperVendorSearch('" + txtSearch.Text + "'," + PaperVendorTrId_I + ",'" + ddlAcYear.SelectedItem.Text + "',0)");//objWorkPlan.VendorDataSelect();
            GrdAgreement.DataBind();
        }
        catch { }

    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = objComm.FillDatasetByProc("call ppr_GetAcYearAllTbl(5)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            //ddlAcYear.SelectedValue = objComm.GetFinYearNew();
            //ddlAcYear.Enabled = false;
        }
        catch { }
    }
    protected void lnkAgrSave_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblLOIId_I = (Label)gv.FindControl("lblLOIId_I");
        CheckBox chkAgrStatus = (CheckBox)gv.FindControl("chkAgrStatus");
        objWorkPlan = new PPR_WorkPlan();
        objWorkPlan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
        objWorkPlan.LOITrId_I = int.Parse(lblLOIId_I.Text);
        string Status = "";
        if (chkAgrStatus.Checked == true)
        {
            Status = "Yes";
        }
        else
        {
            Status = "No";
        }
        objWorkPlan.VendorAgrSave(Status);
        GridFillLoad();

     //  ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }
    protected void lnkView_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblAgreementTrId_I = (Label)gv.FindControl("lblAgreementTrId_I");
        objWorkPlan = new PPR_WorkPlan();
        try
        {
            objWorkPlan.WorkPlanTrId_I = int.Parse(lblAgreementTrId_I.Text);
        }
        catch { }

        ds = objWorkPlan.AgreeMentPBGDetails();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdPBGInfo.DataSource = ds.Tables[0];
            GrdPBGInfo.DataBind();

            DateTime dtL = new DateTime();
            try
            {
                dtL = DateTime.Parse(ds.Tables[0].Rows[0]["AgreementDate_D"].ToString());
                AgreementDate = dtL.ToString("dd/MM/yyyy");
            }
            catch { }
            try
            {
                dtL = DateTime.Parse(ds.Tables[0].Rows[0]["LOIDate_D"].ToString());
                LOIDate = dtL.ToString("dd/MM/yyyy");
            }
            catch { }

            AgreementNo = ds.Tables[0].Rows[0]["AgreementNo_V"].ToString();
            Validity = ds.Tables[0].Rows[0]["ValidityTime_I"].ToString();
            PBGAMT = ds.Tables[0].Rows[0]["PBGAmount"].ToString();
            PBGNo = ds.Tables[0].Rows[0]["PBGNo_V"].ToString();
            LOITo = ds.Tables[0].Rows[0]["PaperVendorName_V"].ToString();
            //  LOIDate = ds.Tables[0].Rows[0]["LOIDate_D"].ToString();
            LOINo = ds.Tables[0].Rows[0]["LOINo_V"].ToString();
        }
        else
        {
            AgreementDate = ""; AgreementNo = ""; Validity = ""; PBGAMT = ""; PBGNo = ""; LOITo = ""; LOIDate = ""; LOINo = "";
        }
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
    }
    protected void GrdAgreement_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objWorkPlan = new PPR_WorkPlan();
        objWorkPlan.Delete(Convert.ToInt32(GrdAgreement.DataKeys[e.RowIndex].Value.ToString()));
        GridFillLoad();
    }
    protected void GrdAgreement_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdAgreement.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdAgreement_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DateTime dtL = new DateTime();
          
            Label lblPprVendorAgrSts = (Label)e.Row.FindControl("lblPprVendorAgrSts");
            Label lblAgreementTrId_I = (Label)e.Row.FindControl("lblAgreementTrId_I");
            Label lblTenderSubmissionDate_D = (Label)e.Row.FindControl("lblPBGDate_D");
            Panel pnlAgr = (Panel)e.Row.FindControl("pnlAgr");
            Panel PnlStsDate = (Panel)e.Row.FindControl("PnlStsDate");
            
       
            Panel Panel1StsNo = (Panel)e.Row.FindControl("Panel1StsNo");
            if (lblAgreementTrId_I.Text == "0" && lblPprVendorAgrSts.Text == "No")
            {
                Panel1StsNo.Visible = true;
                PnlStsDate.Visible = true;
            }
            else if (lblAgreementTrId_I.Text == "0" && lblPprVendorAgrSts.Text == "Yes")
            {
                Panel1StsNo.Visible = true;
                PnlStsDate.Visible = true;
            }
            else if (lblAgreementTrId_I.Text != "0")
            {
                pnlAgr.Visible = true;
            }
            try
            {
                dtL = DateTime.Parse(lblTenderSubmissionDate_D.Text);
                lblTenderSubmissionDate_D.Text = dtL.ToString("dd/MM/yyyy");
            }
            catch { }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            //objWorkPlan = new PPR_WorkPlan();
            //objWorkPlan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
            //GrdAgreement.DataSource = objWorkPlan.VendorDataSearchName(txtSearch.Text);
            //GrdAgreement.DataBind();
            GridFillLoad();
        }
        catch { }
    }
}