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

public partial class Paper_TenderEvaluation : System.Web.UI.Page
{
    DataSet ds;
    DepoTenderEvaluation objTenderEvaluation = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["ID"] != null)
            {

            }
        }
    }
    public void TenderDtlFill()
    {
        if (Request.QueryString["ID"] != null)
        {
            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
            objTenderEvaluation.TenderTrId_I = 0;
            ddlTenderType.DataSource = objTenderEvaluation.TenderSelect();
            ddlTenderType.DataTextField = "TenderNo_V";
            ddlTenderType.DataValueField = "TenderTrId_I";
            ddlTenderType.DataBind();
            ddlTenderType.Items.Insert(0, "Select");
            ddlTenderType.Items.FindByValue(Request.QueryString["ID"].ToString()).Selected = true;
            ddlTenderType.Enabled = false;
            TenderDtlFillById();
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            ds = objTenderEvaluation.CheckEvalution();
            if (ds.Tables[0].Rows[0][0].ToString() == "0")
            {
                GridEvalutionFillLoad();
            }
        }
        else
        {
            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
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
        TenderDtlFill();
    }
    public void TenderDtlFillById()
    {
        if (ddlTenderType.SelectedItem.Text != "Select")
        {

            GridFillLoad();
            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
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

                objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
                objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
                GrdTenderEvaluation.DataSource = objTenderEvaluation.Select();
                GrdTenderEvaluation.DataBind();
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

                objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
                objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
                GVEvaluation.DataSource = objTenderEvaluation.EvalutionSelect();
                GVEvaluation.DataBind();
            }
        }
        catch { }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlTenderType.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
        }
        else if (ddlVenderFill.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select company name.');</script>");

        }
        else
        {

            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
            objTenderEvaluation.TenderTrId_I = int.Parse(ddlTenderType.SelectedItem.Value.ToString());
            objTenderEvaluation.Venderid_I = int.Parse(ddlVenderFill.SelectedItem.Value.ToString());
            objTenderEvaluation.Qualify_Sts_V = ddlStatus.SelectedItem.Text.Trim();

            objTenderEvaluation.BidRate_N = float.Parse(txtBitAmt.Text);
            objTenderEvaluation.UserId_I = Convert.ToInt32(Session["UserID"]);;



            if (Request.QueryString["ID"] != null)
            {
                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(Request.QueryString["ID"].ToString());
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
                    txtBitAmt.Text = "";
                    lblCompAdd.Text = "";
                    ddlVenderFill.SelectedIndex = 0;
                    ddlVenderFill.Enabled = true;
                    lblTenderAutoNo.Text = "0";
                    //   Clear();
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
                    lblCompAdd.Text = "";
                    ddlVenderFill.SelectedIndex = 0;
                    //obCommonFuction.EmptyTextBoxes(this);
                    txtBitAmt.Text = "";
                    //   Clear();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + ds.Tables[0].Rows[0]["Msg"].ToString() + "');</script>");
                    GridFillLoad();
                }
            }
        }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblBidRate_N = (Label)gv.FindControl("lblBidRate_N");
        Label lblVenderid_I = (Label)gv.FindControl("lblVenderid_I");
        Label lblPaperVendorAddress_V = (Label)gv.FindControl("lblPaperVendorAddress_V");
        Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");

        lblTenderAutoNo.Text = lblTenderEvaluationTrId_I.Text;
        lblCompAdd.Text = lblPaperVendorAddress_V.Text;
        txtBitAmt.Text = lblBidRate_N.Text;
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

        objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
        objTenderEvaluation.Delete(int.Parse(lblTenderEvaluationTrId_I.Text));
        GridFillLoad();
    }
    public void VenderFill()
    {
        objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
        ddlVenderFill.DataSource = objTenderEvaluation.VenderFill();
        ddlVenderFill.DataTextField = "PaperVendorName_V";
        ddlVenderFill.DataValueField = "PaperVendorTrId_I";
        ddlVenderFill.DataBind();
        ddlVenderFill.Items.Insert(0, "Select");
    }
    protected void ddlVenderFill_Init(object sender, EventArgs e)
    {
        VenderFill();
    }
    protected void ddlVenderFill_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVenderFill.SelectedItem.Text != "Select")
        {
            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
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
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select tender no.');</script>");
        }

        else
        {
            string Sts = "NotOk";
            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
            foreach (GridViewRow gv in GVEvaluation.Rows)
            {
                Label lblL_1 = (Label)gv.FindControl("lblL_1");
                Label lblTenderEvaluationTrId_I = (Label)gv.FindControl("lblTenderEvaluationTrId_I");
                Label lblTenderTrId_I = (Label)gv.FindControl("lblTenderTrId_I");

                objTenderEvaluation.TenderTrId_I = int.Parse(lblTenderTrId_I.Text);
                objTenderEvaluation.TenderEvaluationTrId_I = int.Parse(lblTenderEvaluationTrId_I.Text);
                objTenderEvaluation.L_I = int.Parse(lblL_1.Text);

                int i = objTenderEvaluation.EvalutionUpdateData();

                if (i > 0)
                {
                    Sts = "Ok";
                }

            }
            if (Sts == "Ok")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Evaluation Has Been Completed.');</script>");
                GridFillLoad();
                Response.Redirect("ViewTenderEvalution.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Add Company For Evalution.');</script>");
          
            }
        }
    }
    protected void GrdTenderEvaluation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            objTenderEvaluation = new DepoTenderEvaluation(Convert.ToInt32(Session["UserID"]));
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
                btnAdd.Enabled = false;
            }

        }
    }
}
