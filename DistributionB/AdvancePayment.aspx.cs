using System;
using MPTBCBussinessLayer.Admin;
using System.Data;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class DistributionB_AdvancePayment : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.AdvancePayment obAdvancePayment = new MPTBCBussinessLayer.DistributionB.AdvancePayment();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillGrid();

        }
        mainDiv.Style.Add("display", "none");
        mainDiv.CssClass = "form-message error";
        lblmsg.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            if (Session["UserId"] != null)
            {
                obAdvancePayment.DepartmentID = int.Parse(ddlDepartment.SelectedValue);
                obAdvancePayment.TitleID = int.Parse(ddlTitle.SelectedValue);
                obAdvancePayment.FinancialYrId = int.Parse(ddlAcademicYr.SelectedValue);
                obAdvancePayment.LetterNo = txtLetterNo.Text;
                obAdvancePayment.LetterDate = Convert.ToDateTime(txtLetterDate.Text, cult).ToString("yyyy-MM-dd");
                obAdvancePayment.AdvanceType = ddlAdvanceType.SelectedValue;
                obAdvancePayment.PaymentDetails = txtPaymentDetails.Text;
                obAdvancePayment.Payment = int.Parse(txtAdvancePayment.Text);
                obAdvancePayment.UserID = int.Parse(Session["UserID"].ToString());
                obAdvancePayment.AdvancePaymentID = int.Parse(hdnPaymentID.Value);
                if (hdnPaymentID.Value == "0")
                    obAdvancePayment.TransType = 0;
                else
                    obAdvancePayment.TransType = -1;

                obAdvancePayment.InsertUpdate();

                pnlModuleMaster.Visible = true;
                pnlNewModule.Visible = false;
                fillGrid();
                mainDiv.Style.Add("display", "block");
                mainDiv.CssClass = "form-message success";
                lblmsg.Text = "Record Saved Successfully";
            }
            else
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Session Expired.Please login again";
            }
        }
        catch (Exception ex)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Duplicate entry found";
        }
    }
    protected void btnNewModule_Click(object sender, EventArgs e)
    {
        pnlModuleMaster.Visible = false;
        pnlNewModule.Visible = true;
        hdnPaymentID.Value = "0";
        txtAdvancePayment.Text = "";
        txtLetterDate.Text = "";
        txtLetterNo.Text = "";
        txtPaymentDetails.Text = "";
        FillCombo();
    }
    private void FillCombo()
    {
        obAdvancePayment.QueryType = 0;
        ddlDepartment.DataSource = obAdvancePayment.Select();
        ddlDepartment.DataTextField = "DepName_V";
        ddlDepartment.DataValueField = "DepTrno_I";
        ddlDepartment.DataBind();
        ddlDepartment.Items.Insert(0, new ListItem("--Select--", "0"));

        obAdvancePayment.QueryType = 1;
        ddlTitle.DataSource = obAdvancePayment.Select();
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, new ListItem("--Select--", "0"));


        obAdvancePayment.QueryType = 2;
        ddlAcademicYr.DataSource = obAdvancePayment.Select();
        ddlAcademicYr.DataTextField = "AcYear";
        ddlAcademicYr.DataValueField = "Id";
        ddlAcademicYr.DataBind();
        ddlAcademicYr.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlAcademicYr_SelectedIndexChanged(null, null);
    }
    private void fillGrid()
    {
        obAdvancePayment.QueryType = 4;
        gvModuleMaster.DataSource = obAdvancePayment.Select();
        gvModuleMaster.DataBind();
    }

    protected void gvModuleMaster_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {

        //txtModuleName.Text = gvModuleMaster.Rows[e.NewEditIndex].Cells[1].Text;
        //txtOrderNo.Text = gvModuleMaster.Rows[e.NewEditIndex].Cells[2].Text;
        hdnPaymentID.Value = gvModuleMaster.DataKeys[e.NewEditIndex].Value.ToString(); //gvModuleMaster.Rows[e.NewEditIndex].Cells[0].Text;
        FillCombo();
        FillData(int.Parse(hdnPaymentID.Value));


    }
    private void FillData(int paymentid)
    {
        obAdvancePayment.QueryType = 5;
        obAdvancePayment.Parameter1 = paymentid;
        DataSet dsPayment = obAdvancePayment.Select();
        if (dsPayment.Tables[0].Rows.Count > 0)
        {
            ddlDepartment.SelectedValue = dsPayment.Tables[0].Rows[0]["DepartmentId_I"].ToString();
            ddlAdvanceType.SelectedValue = dsPayment.Tables[0].Rows[0]["AdvanceType_V"].ToString();
            ddlTitle.SelectedValue = dsPayment.Tables[0].Rows[0]["TitleID_I"].ToString();
            ddlAcademicYr.SelectedValue = dsPayment.Tables[0].Rows[0]["FinancialYrID_I"].ToString();
            ddlAcademicYr_SelectedIndexChanged(null, null);
            txtLetterNo.Text = dsPayment.Tables[0].Rows[0]["LetterNo_V"].ToString();
            txtLetterDate.Text =Convert.ToDateTime(dsPayment.Tables[0].Rows[0]["LetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            txtPaymentDetails.Text = dsPayment.Tables[0].Rows[0]["PaymentDetails_V"].ToString();
            txtAdvancePayment.Text = dsPayment.Tables[0].Rows[0]["PaymentAmount_I"].ToString();

            pnlModuleMaster.Visible = false;
            pnlNewModule.Visible = true;
        }
        else
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Error in fetching Data";
        }

    }

    protected void gvModuleMaster_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        hdnPaymentID.Value = gvModuleMaster.DataKeys[e.RowIndex].Value.ToString(); //gvModuleMaster.Rows[e.RowIndex].Cells[0].Text;

        obAdvancePayment.Delete(int.Parse(hdnPaymentID.Value));
        fillGrid();
    }

    protected void gvModuleMaster_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
    {
        gvModuleMaster.PageIndex = e.NewPageIndex;
        fillGrid();
    }
    protected void ddlAcademicYr_SelectedIndexChanged(object sender, EventArgs e)
    {
        obAdvancePayment.QueryType = 3;
        obAdvancePayment.Parameter1 = int.Parse(ddlAcademicYr.SelectedValue);
        try
        {
            lblFinancialYr.Text = obAdvancePayment.Select().Tables[0].Rows[0]["FyYear"].ToString();
        }
        catch
        {
            lblFinancialYr.Text = "--";
        }
    }
}
