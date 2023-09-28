using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class Academic_GrantInformation : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.CssClass = "form-message error";
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            fillgrd();

            ddlLetterNo.DataSource = obCommonFuction.FillDatasetByProc("call USPGrantMasterSave(-1,0,0,0,0,0,0)");
            ddlLetterNo.DataValueField = "GratnID";
            ddlLetterNo.DataTextField = "LetterNoDate";
            ddlLetterNo.DataBind();
            ddlLetterNo.Items.Insert(0, "Select..");
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            fillgrd1();
        }
    }
    public void fillgrd1()
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USPGrantDetails(-1,0,0,0,0,0,0,0,0,0,0,0,0,0)");
        grdSelectedTitle1.DataSource = dd.Tables[0];
        grdSelectedTitle1.DataBind();

    }
    public void fillgrd()
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USPGrantMasterSave(-1,0,0,0,0,0,0)");
        grdSelectedTitle.DataSource = dd.Tables[0];
        grdSelectedTitle.DataBind();

    }
    protected void btnOrder1_Click(object sender, EventArgs e)
    {
        if (hdData.Value == "")
        {
            if (ddlLetterNo.SelectedIndex == 0)
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "मांगकर्ता संस्था का पत्र क्रमांक एवं दिनांक.चुने";
            }
            //else if (txtLetterNoa.Text == "")
            //{
            //    mainDiv.Style.Add("display", "block");
            //    lblmsg.Text = " पत्र क्रमांक डाले  ";
            //}
            //else if (txtLetterDatea.Text == "")
            //{
            //    mainDiv.Style.Add("display", "block");
            //    lblmsg.Text = "पत्र  दिनांक डाले ";
            //}
            //else if (txtAmounta.Text == "")
            //{
            //    mainDiv.Style.Add("display", "block");
            //    lblmsg.Text = "राशि  डाले ";
            //}
            //else if (txtBankName.Text == "")
            //{
            //    mainDiv.Style.Add("display", "block");
            //    lblmsg.Text = "बैंक का नाम डाले ";
            //}
            //else if (txtddDate.Text == "")
            //{
            //    mainDiv.Style.Add("display", "block");
            //    lblmsg.Text = "डी.डी. का दिनांक  डाले ";
            //}
            //else if (txtMettingDate.Text == "")
            //{
            //    mainDiv.Style.Add("display", "block");
            //    lblmsg.Text = "बैठक का दिनांक  डाले ";
            //}
               
            else {
                try {
                    if (txtLetterDatea.Text == "")
                    {
                        txtLetterDatea.Text = "01/01/1900";
                    }
                    if (txtddDate.Text == "")
                    {
                        txtddDate.Text = "01/01/1900";
                    }
                    if (txtMettingDate.Text == "")
                    {
                        txtMettingDate.Text = "01/01/1900";
                    }
                    if (txtAmounta.Text == "")
                    {
                        txtAmounta.Text = "0";
                    }
                obCommonFuction.FillDatasetByProc(" call USPGrantDetails(0,'" + ddlLetterNo.SelectedValue + "','" + txtLetterNoa.Text + "','" +Convert.ToDateTime(txtLetterDatea.Text, cult).ToString("yyyy-MM-dd") + "','" + txtAmounta.Text + "','" + ddlPayment.SelectedItem.Text + "','" + txtBankName.Text + "','" + txtdddNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtRemark.Text + "','" + ddlLetterNo0.SelectedItem.Text + "','" + txtDratfNo.Text + "','" + txtMettingNo.Text + "','" +  Convert.ToDateTime(txtMettingDate.Text, cult).ToString("yyyy-MM-dd") + "')");
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record saved successfully";
                }
                catch { }
            }
            //ID, GrantID, LetterNo, LetterDate, Amount, paymentType, BankNamw, DDNO, ddDate, Remark, Anumati, PointNo, MeettingNo, MettingDate 
        }
        else
        {
            //  if (txtMettingDate.Text==)
            obCommonFuction.FillDatasetByProc("call USPGrantDetails(" + hdData.Value + ",'" + ddlLetterNo.SelectedValue + "','" + txtLetterNoa.Text + "','" + Convert.ToDateTime(txtLetterDatea.Text, cult).ToString("yyyy-MM-dd") + "','" + txtAmounta.Text + "','" + ddlPayment.SelectedItem.Text + "','" + txtBankName.Text + "','" + txtdddNo.Text + "','" + Convert.ToDateTime(txtddDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtRemark.Text + "','" + ddlLetterNo0.SelectedItem.Text + "','" + txtDratfNo.Text + "','" + txtMettingNo.Text + "','" + Convert.ToDateTime(txtMettingDate.Text, cult).ToString("yyyy-MM-dd") + "')");
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Updated successfully";
        }
        obCommonFuction.EmptyTextBoxes(this);
        hdData.Value = "";
        fillgrd1();
        tcTitle.ActiveTabIndex = 1;
         
    }
    protected void ddlLetterNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dda = obCommonFuction.FillDatasetByProc("call USPGrantMasterSave(-2," + ddlLetterNo.SelectedValue + ",0,0,0,0,0)");
        Label3.Text ="चाही गई राशि : - "+ dda.Tables[0].Rows[0]["Amount"].ToString();
        tcTitle.ActiveTabIndex = 1;
    }
    protected void btnOrder_Click(object sender, EventArgs e)
    {
        if (hdData.Value == "")
        {
            if (txtDepartment.Text == "")
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = " संस्था का नाम डाले ";
            }
            else if (txtMad.Text == "")
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "मद डाले  ";
            }
            else if (txtLetterNo.Text == "")
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "पत्र क्रमांक डाले  ";
            }
            else if (txtLetterDate.Text == "")
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "पत्र दिनांक क्रमांक डाले  ";
            }
            else if (txtAmount.Text == "")
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "राशि डाले  ";
            }
            else

            {
                try { 
            obCommonFuction.FillDatasetByProc(" call USPGrantMasterSave(0,'" + txtDepartment.Text + "','" + txtMad.Text + "','" + txtLetterNo.Text + "','" + Convert.ToDateTime(txtLetterDate.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedItem.Text + "','" + txtAmount.Text + "')");
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record saved successfully";
                }
                catch {
                    mainDiv.CssClass = "form-message success";
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "पत्र क्रमांक पहले से डाला हुआ है ";
                }
            }
        }
        else
        {
            obCommonFuction.FillDatasetByProc(" call USPGrantMasterSave(" + hdData.Value + ",'" + txtDepartment.Text + "','" + txtMad.Text + "','" + txtLetterNo.Text + "','" + Convert.ToDateTime(txtLetterDate.Text, cult).ToString("yyyy-MM-dd") + "','" + DdlACYear.SelectedItem.Text + "','" + txtAmount.Text + "')");
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Updated successfully";
        }
        obCommonFuction.EmptyTextBoxes(this);
        hdData.Value = "";
        fillgrd();
        ddlLetterNo.DataSource = obCommonFuction.FillDatasetByProc("call USPGrantMasterSave(-1,0,0,0,0,0,0)");
        ddlLetterNo.DataValueField = "GratnID";
        ddlLetterNo.DataTextField = "LetterNoDate";
        ddlLetterNo.DataBind();
        ddlLetterNo.Items.Insert(0, "Select..");
    }
    protected void grdSelectedTitle1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd1 = obCommonFuction.FillDatasetByProc("call USPGrantDetails(-2," + grdSelectedTitle1.SelectedDataKey.Value + ",0,0,0,0,0,0,0,0,0,0,0,0)");
        ddlLetterNo.ClearSelection();
        ddlLetterNo.SelectedValue = dd1.Tables[0].Rows[0]["GrantID"].ToString();
        txtLetterNoa.Text = dd1.Tables[0].Rows[0]["LetterNo"].ToString();
        txtLetterDatea.Text = dd1.Tables[0].Rows[0]["LetterDate"].ToString();
        txtAmounta.Text = dd1.Tables[0].Rows[0]["Amount"].ToString();
        ddlPayment.ClearSelection();
        ddlPayment.Items.FindByText(dd1.Tables[0].Rows[0]["paymentType"].ToString()).Selected = true;
        // ddlPayment.SelectedItem.Text = dd1.Tables[0].Rows[0]["Amount"].ToString();
        txtBankName.Text = dd1.Tables[0].Rows[0]["BankNamw"].ToString();
        txtdddNo.Text = dd1.Tables[0].Rows[0]["DDNO"].ToString();
        txtddDate.Text = dd1.Tables[0].Rows[0]["ddDate"].ToString();
        txtRemark.Text = dd1.Tables[0].Rows[0]["Remark"].ToString();
        txtDratfNo.Text = dd1.Tables[0].Rows[0]["PointNo"].ToString();

        ddlLetterNo0.ClearSelection();
        ddlLetterNo0.Items.FindByText(dd1.Tables[0].Rows[0]["Anumati"].ToString()).Selected = true;

        txtMettingNo.Text = dd1.Tables[0].Rows[0]["MeettingNo"].ToString();
        txtMettingDate.Text = dd1.Tables[0].Rows[0]["MettingDate"].ToString();
        hdData.Value = grdSelectedTitle1.SelectedDataKey.Value.ToString();
        ddlLetterNo_SelectedIndexChanged(sender, e);
    }
    protected void grdSelectedTitle_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet dd1 = obCommonFuction.FillDatasetByProc("call USPGrantMasterSave(-2," + grdSelectedTitle.SelectedDataKey.Value + ",0,0,0,0,0)");
        DdlACYear.ClearSelection();
        DdlACYear.Items.FindByText(dd1.Tables[0].Rows[0]["Fyyear"].ToString()).Selected = true;
        txtAmount.Text = dd1.Tables[0].Rows[0]["Amount"].ToString();
        txtDepartment.Text = dd1.Tables[0].Rows[0]["DepartmentName"].ToString();
        txtLetterDate.Text = dd1.Tables[0].Rows[0]["LetterDate"].ToString();
        txtLetterNo.Text = dd1.Tables[0].Rows[0]["LetterNo"].ToString();
        txtMad.Text = dd1.Tables[0].Rows[0]["Mad"].ToString();
        hdData.Value = grdSelectedTitle.SelectedDataKey.Value.ToString();

    }
}