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
public partial class Paper_WorkPlan : System.Web.UI.Page
{
    DataSet ds;
    PPR_WorkPlan objWorkPlan = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ViewState["WorkPlanTrId_I"] = "";
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear1();
            lblAcYear.Text = DdlACYear.SelectedValue;
            if (Request.QueryString["ID"] != null)
            {
                FiledFill();

            }
        }
    }
    public void FiledFill()
    {
        objWorkPlan = new PPR_WorkPlan();
        objWorkPlan.WorkPlanTrId_I = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        ds = objWorkPlan.FieldFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            venderFill();
            ddlVendor.ClearSelection();
            ddlVendor.Items.FindByValue(ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true;
            ddlVendor.Enabled = false;
            LOIIDFill();
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOIId_I"].ToString()).Selected = true;
            ddlLOINo.Enabled = false;
            LOIDetails();
            ddlPaperSize.Enabled = false;
            ddlPaperType.Enabled = false;
            btnSave.Visible = false;
        }

    }

    private void ClearCtrls()
    {
        lblAddress.Text = "";
        lblTenderName.Text = "";
        lblTenderNo.Text = "";
        lblLOIDate.Text = "";
        lblLOITO.Text = "";
        lblqty.Text = "";
        lblRate.Text = "";
        lblAgreementNo.Text = "";
        lblallotedqty.Text = "";
        GrdWorkPlan.DataSource = null;
        GrdWorkPlan.DataBind();
    }

    public void venderFill()
    {
        objWorkPlan = new PPR_WorkPlan();
        ddlVendor.DataSource = objWorkPlan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        venderFill();
    }
    public void LOIIDFill()
    {
        if (ddlVendor.SelectedItem.Text != "Select")
        {
            objWorkPlan = new PPR_WorkPlan();
            objWorkPlan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            //ddlLOINo.DataSource = objWorkPlan.LOINoFill();
            ddlLOINo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_GetLoiByVendorandAcYear(" + ddlVendor.SelectedItem.Value + ",'"+DdlACYear.SelectedItem.Text+"')");

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
        LOIIDFill();
    }
    public void LOIDetails()
    {
        objWorkPlan = new PPR_WorkPlan();
        //Random rand = new Random();
        //int randnum = rand.Next(100000, 10000000);
        //lblorderNo.Text = randnum.ToString();
        objWorkPlan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
        objWorkPlan.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);
        ds = objWorkPlan.LOINoDetailsFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblAddress.Text = ds.Tables[0].Rows[0]["PaperVendorAddress_V"].ToString() + " " + ds.Tables[0].Rows[0]["City_V"].ToString() + " " + ds.Tables[0].Rows[0]["District_Name_Eng_V"].ToString() + "-" + ds.Tables[0].Rows[0]["PinCode_V"].ToString();
            lblRate.Text = ds.Tables[0].Rows[0]["BidRate_N"].ToString();
            lblTenderName.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
            lblTenderNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
            lblLOITO.Text = ds.Tables[0].Rows[0]["PaperVendorName_V"].ToString();
            lblAgreementNo.Text = ds.Tables[0].Rows[0]["AgreementNo_V"].ToString();
            lblqty.Text = ds.Tables[0].Rows[0]["RqcQuantity"].ToString();
            lblallotedqty.Text = ds.Tables[0].Rows[0]["AllotedQuantity"].ToString();
            
            try
            {
                DateTime dat = new DateTime();
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["LOIDate_D"].ToString());
                lblLOIDate.Text = dat.ToString("dd/MM/yyyyy");
            }
            catch { }
            GridFill();
            PaperTypeFill();
            try
            {
                ddlPaperType.Items.FindByValue(ds.Tables[0].Rows[0]["PaperType_I"].ToString()).Selected = true;
                ddlPaperType.Enabled = false;
            }
            catch { }
            PaperSizeFill();
        }
    }

    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearCtrls();
        LOIDetails();
    }
    public void PaperSizeFill()
    {
        if (ddlPaperType.SelectedItem.Text != "Select")
        {
            objWorkPlan = new PPR_WorkPlan();
            objWorkPlan.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
            ddlPaperSize.DataSource = objWorkPlan.PaperSizeFill();
            ddlPaperSize.DataTextField = "CoverInformation";
            ddlPaperSize.DataValueField = "PaperTrId_I";
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "Select");
        }
    }


    protected void txtPaperQty_TextChanged(object sender, EventArgs e)
    {
        string FirstVal = "";
        FirstVal = txtPaperQty.Text.ToString().Substring(0, 1);
        if (FirstVal == "0" || FirstVal == "-")
        {
            txtPaperQty.Text = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Invalid Quantity.');</script>");
        }
        else
        {
            try
            {
                txtTotAmt.Text = (decimal.Parse(lblRate.Text) * decimal.Parse(txtPaperQty.Text)).ToString("0.00");
            }
            catch { txtTotAmt.Text = "0"; }
        }

    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {

        PaperSizeFill();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string Date = "", FeeDate = "", StartDate = "";
        if (txtDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtDate.Text, cult);
            }
            catch { Date = "NoDate"; }
        }
        if (txtStartDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtStartDate.Text, cult);
            }
            catch { StartDate = "NoStartDate"; }
        }

        if (txtSupplyTillDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtSupplyTillDate.Text, cult);
            }
            catch { FeeDate = "NoFeeDate"; }
        }

        if (Date != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Order Date.');</script>");
        }
        else if (FeeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct End date.');</script>");
        }
        else if (StartDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct start date.');</script>");
        }
        else if (lblRate.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter tender rate.');</script>");
        }
        else if (txtTotAmt.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter amount.');</script>");
        }
        else
        {

            objWorkPlan = new PPR_WorkPlan();
            objWorkPlan.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.Trim());

            objWorkPlan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedValue.ToString());
            objWorkPlan.PaperType_I = int.Parse(ddlPaperType.SelectedValue.ToString());
            objWorkPlan.PaperQuality_I = int.Parse(txtPaperQty.Text.ToString());
            objWorkPlan.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedItem.Value);

            objWorkPlan.UserId_I = int.Parse(Session["UserID"].ToString());
            objWorkPlan.SupplyDate_D = DateTime.Parse(txtDate.Text, cult);
            objWorkPlan.SupplyTillDate_D = DateTime.Parse(txtSupplyTillDate.Text, cult);
            objWorkPlan.StartDate = DateTime.Parse(txtStartDate.Text, cult);
            objWorkPlan.TotAmount = decimal.Parse(txtTotAmt.Text);
            objWorkPlan.BitRate = decimal.Parse(lblRate.Text);
            objWorkPlan.OrderNo = Convert.ToString(lblorderNo.Text);

            if (Request.QueryString["ID"] != null || (ddlVendor.Enabled == false && ddlLOINo.Enabled == false))
            {
                objWorkPlan.WorkPlanTrId_I = int.Parse(ViewState["WorkPlanTrId_I"].ToString());
            }
            else
            {
                objWorkPlan.WorkPlanTrId_I = 0;
            }
            if (ddlVendor.SelectedItem.Text == "Select" || ddlLOINo.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
            }
            else if (DateTime.Parse(txtSupplyTillDate.Text, cult) < DateTime.Parse(txtDate.Text, cult))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Till date can not be greater then supply date.');</script>");
            }
            else
            {
                int i = objWorkPlan.InsertUpdate();
                // 
                obCommonFuction.FillDatasetByProc("call USPppr_workplan_tfyUpdate('" + DdlACYear.SelectedItem.Text + "'," + i + ")");
                if (i > 0)
                {

                    if (Request.QueryString["ID"] != null || (ddlVendor.Enabled == false && ddlLOINo.Enabled == false))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                        //Response.Redirect("ViewPPR_009_WPlan.aspx");
                        ddlLOINo.Enabled = true;
                        ddlVendor.Enabled = true;
                    }
                    else
                    {
                        // Response.Redirect("ViewPPR_009_WPlan.aspx");
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    }
                    //obCommonFuction.EmptyTextBoxes(this);
                    ddlPaperSize.SelectedIndex = 0;
                    ddlPaperType.SelectedIndex = 0;
                    txtDate.Text = "";
                    txtPaperQty.Text = "";
                    txtSupplyTillDate.Text = "";
                    lblAddress.Text = "";
                    lblRate.Text = "";
                    txtTotAmt.Text = "";
                    lblLOIDate.Text = "";
                    lblTenderName.Text = "";
                    lblTenderNo.Text = "";
                    lblLOITO.Text = "";
                    txtStartDate.Text = "";
                    ddlLOINo.SelectedIndex = 0;
                    ddlVendor.SelectedIndex = 0;
                    ViewState["WorkPlanTrId_I"] = "";
                    GrdWorkPlan.DataSource = string.Empty;
                    GrdWorkPlan.DataBind();
                    //Random rand = new Random();
                    //int randnum = rand.Next(100000, 10000000);
                    //lblorderNo.Text = rand.ToString();
                }
            }
        }
    }
    protected void ddlPaperQlty_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    public void GridFill()
    {
        try
        {
            if (ddlLOINo.SelectedItem.Text != "Select")
            {
                objWorkPlan = new PPR_WorkPlan();
                objWorkPlan.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
                GrdWorkPlan.DataSource = objWorkPlan.GrWorkPlanFill();
                GrdWorkPlan.DataBind();
            }
        }
        catch { }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
        Label lblSupplyDate_D = (Label)gv.FindControl("lblSupplyDate_D");
        Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
        Label lblWorkPlanTrId_I = (Label)gv.FindControl("lblWorkPlanTrId_I");
        Label lblEndDate_D = (Label)gv.FindControl("lblEndDate_D");
        Label lblStartDate = (Label)gv.FindControl("lblStartDate");
        Label lblItmOrderNo = (Label)gv.FindControl("lblItmOrderNo");
        txtStartDate.Text = lblStartDate.Text;
        lblorderNo.Text = lblItmOrderNo.Text;
        txtSupplyTillDate.Text = lblEndDate_D.Text;
        ViewState["WorkPlanTrId_I"] = lblWorkPlanTrId_I.Text;
        txtDate.Text = lblSupplyDate_D.Text;
        txtPaperQty.Text = lblPaperQuantity_N.Text;
        PaperTypeFill();
        ddlPaperType.ClearSelection();
        ddlPaperType.Items.FindByValue(lblPaperType_I.Text).Selected = true;
        PaperSizeFill();
        ddlPaperSize.ClearSelection();
        ddlPaperSize.Items.FindByValue(lblPaperMstrTrId_I.Text).Selected = true;
        try
        {
            txtTotAmt.Text = (decimal.Parse(lblRate.Text) * decimal.Parse(txtPaperQty.Text)).ToString("0.00");
        }
        catch { txtTotAmt.Text = "0"; }
        ddlLOINo.Enabled = false;
        ddlVendor.Enabled = false;
        btnSave.Visible = true;
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblWorkPlanTrId_I = (Label)gv.FindControl("lblWorkPlanTrId_I");
        objWorkPlan = new PPR_WorkPlan();
        objWorkPlan.Delete(int.Parse(lblWorkPlanTrId_I.Text));
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GridFill();
    }
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            Label lblStartDate = (Label)e.Row.FindControl("lblStartDate");
            Label lblSupplyDate_D = (Label)e.Row.FindControl("lblSupplyDate_D");
            Label lblEndDate_D = (Label)e.Row.FindControl("lblEndDate_D");
            DateTime dat = new DateTime();
            try
            {
                dat = DateTime.Parse(lblSupplyDate_D.Text);
                lblSupplyDate_D.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }
            try
            {
                dat = DateTime.Parse(lblStartDate.Text);
                lblStartDate.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }
            try
            {
                dat = DateTime.Parse(lblEndDate_D.Text);
                lblEndDate_D.Text = dat.ToString("dd/MM/yyyy");
            }
            catch { }
            if (Request.QueryString["ID"] != null)
            {
               // lnkDelete.Visible = false;
                lnkDelete.Visible = true;
            }
            else
            {
                lnkDelete.Visible = true;
            }

        }
    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperTypeFill();
    }
    public void PaperTypeFill()
    {
        objWorkPlan = new PPR_WorkPlan();
        ddlPaperType.DataSource = objWorkPlan.PaperTypeFill();
        ddlPaperType.DataTextField = "PaperType";
        ddlPaperType.DataValueField = "PaperType_Id";
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "Select");
    }
}
