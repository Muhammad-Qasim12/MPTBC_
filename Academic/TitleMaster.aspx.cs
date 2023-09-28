using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Academic_TitleMaster : System.Web.UI.Page
{
    PRI_CategoryMaster obPRI_CategoryMaster = null;
    MPTBCBussinessLayer.Academic.TitleMaster obTitleMaster = new MPTBCBussinessLayer.Academic.TitleMaster();
    CommonFuction obCommonFunction = new CommonFuction();
    public void LoadPrintingPaper()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        try
        {
            ddlPrintingPaperInformation_V.DataSource = obPRI_CategoryMaster.Fillddl(1);
            ddlPrintingPaperInformation_V.DataTextField = "PrintingInformation";
            ddlPrintingPaperInformation_V.DataValueField = "PaperTrId_I";
            ddlPrintingPaperInformation_V.DataBind();
            ddlPrintingPaperInformation_V.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }
    }
    public void LoadCoverPaper()
    {
        obPRI_CategoryMaster = new PRI_CategoryMaster();
        try
        {
            ddlCoverPaperinformation_V.DataSource = obPRI_CategoryMaster.Fillddl(2);
            ddlCoverPaperinformation_V.DataTextField = "CoverInformation";
            ddlCoverPaperinformation_V.DataValueField = "PaperTrId_I";
            ddlCoverPaperinformation_V.DataBind();
            ddlCoverPaperinformation_V.Items.Insert(0, new ListItem("Select", "0"));

        }
        catch (Exception ex) { }
        finally { obPRI_CategoryMaster = null; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obTitleMaster.TitleID = -5;
            lblAcademicYear.Text = obCommonFunction.GetFinYear();
            obTitleMaster.StringParameter = obCommonFunction.GetFinYear();
            DataSet dsAcYear = obTitleMaster.Select();
            LoadPrintingPaper();
            LoadCoverPaper();

            // ddlCoverPaperinformation_V.Items.Insert(0, "Select..");
            if (dsAcYear.Tables[0] != null && dsAcYear.Tables[0].Rows.Count > 0)
            {
                hdnAcademicYearID.Value = dsAcYear.Tables[0].Rows[0]["Id"].ToString();

            }
            else
            {
                hdnAcademicYearID.Value = "0";
            }
            ddlTitle.DataTextField = "TitleHindi_V";
            ddlTitle.DataValueField = "TitleID_I";
            ddlTitle.DataSource = obCommonFunction.FillDatasetByProc("call `USP_ACD001_TitleMasterSelect`(0," + hdnAcademicYearID.Value + ",0, 0, 0)");
            ddlTitle.DataBind();
            ddlTitle.Items.Insert(0, "Select..");
            FillCombos();
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    int id = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"]));

                    FillData(id);
                }
                catch
                {
                    ResetFields();
                }

            }
        }
    }
    private void FillCombos()
    {
        obTitleMaster.TitleID = -1;
        ddlClass.DataSource = obTitleMaster.Select();
        ddlClass.DataTextField = "Classdet_V";
        ddlClass.DataValueField = "ClassTrno_I";
        ddlClass.DataBind();
        ddlclass1.DataSource = obTitleMaster.Select();
        ddlclass1.DataTextField = "Classdet_V";
        ddlclass1.DataValueField = "ClassTrno_I";
        ddlclass1.DataBind();
        ddlclass1.Items.Insert(0, "Select..");
        obTitleMaster.TitleID = -2;
        ddlDepartment.DataSource = obTitleMaster.Select();
        ddlDepartment.DataTextField = "DepName_V";
        ddlDepartment.DataValueField = "DepTrno_I";
        ddlDepartment.DataBind();

        obTitleMaster.TitleID = -3;
        ddlMedium.DataSource = obTitleMaster.Select();
        ddlMedium.DataTextField = "MediunNameHindi_V";
        ddlMedium.DataValueField = "MediumTrno_I";
        ddlMedium.DataBind();


    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFunction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataValueField = "Id";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obCommonFunction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(2)").Tables[0].Rows[0][0].ToString()).Selected = true;
            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    private void ResetFields()
    {
        txtTitleHindi.Text = string.Empty;
        txtSize.Text = string.Empty;
        txtPages.Text = string.Empty;
        txtTitleEnglish.Text = string.Empty;
        txtRate.Text = string.Empty;
        txtRateListSNo.Text = string.Empty;
        hdnAcademicYearID.Value = "0";
    }
    private void FillData(int titleID)
    {
        obTitleMaster.TitleID = titleID;
        DataSet dsTitle = obTitleMaster.Select();
        if (dsTitle.Tables[0].Rows.Count > 0 && titleID != 0)
        {
            ddlMedium.SelectedValue = dsTitle.Tables[0].Rows[0]["Medium_I"].ToString();
            ddlClass.SelectedValue = dsTitle.Tables[0].Rows[0]["ClassTrno_I"].ToString();
            txtTitleHindi.Text = dsTitle.Tables[0].Rows[0]["TitleHindi_V"].ToString();
            txtSize.Text = dsTitle.Tables[0].Rows[0]["Size_V"].ToString();
            txtPages.Text = dsTitle.Tables[0].Rows[0]["Pages_N"].ToString();
            ddlColourCover1n4.SelectedValue = dsTitle.Tables[0].Rows[0]["ColourCover1n4_V"].ToString();
            ddlColourCover2n3.SelectedValue = dsTitle.Tables[0].Rows[0]["ColourCover2n3_V"].ToString();
            ddlColourText.SelectedValue = dsTitle.Tables[0].Rows[0]["ColorText_V"].ToString();
            txtTitleEnglish.Text = dsTitle.Tables[0].Rows[0]["TitleEnglish_V"].ToString();
            txtRate.Text = dsTitle.Tables[0].Rows[0]["Rate_N"].ToString();
            ddlDepartment.SelectedValue = dsTitle.Tables[0].Rows[0]["DepartmentTrno_I"].ToString();

            // txtCoverSize.Text = dsTitle.Tables[0].Rows[0]["CoverPaperSize_GSM_N"].ToString();
            // txtPaperSize.Text = dsTitle.Tables[0].Rows[0]["PrintngPaperSize_GSM_N"].ToString();
            txtRateListSNo.Text = dsTitle.Tables[0].Rows[0]["RateListSNo_I"].ToString();
            ddlAcYear.SelectedValue = dsTitle.Tables[0].Rows[0]["AcademicYrId_I"].ToString();
            try
            {
                // ddlPrintingPaperInformation_V.ClearSelection();
                //ddlPrintingPaperInformation_V.Items.FindByText(dsTitle.Tables[0].Rows[0]["PrintingPaperDetails"].ToString()).Selected = true;
                ddlPrintingPaperInformation_V.SelectedValue = dsTitle.Tables[0].Rows[0]["PrintingPaperID"].ToString();
            }

            catch { }
            try
            {
                // ddlCoverPaperinformation_V.ClearSelection();
                //ddlCoverPaperinformation_V.Items.FindByText(dsTitle.Tables[0].Rows[0]["CoverPaperID"].ToString()).Selected = true;
                ddlCoverPaperinformation_V.SelectedValue = dsTitle.Tables[0].Rows[0]["CoverPaperID"].ToString();
            }
            catch { }
            try
            {
                Binding.ClearSelection();
                Binding.Items.FindByText(dsTitle.Tables[0].Rows[0]["BindingDetails"].ToString()).Selected = true;
                //Binding.SelectedItem.Text = dsTitle.Tables[0].Rows[0]["BindingDetails"].ToString();
            }
            catch { }
            //obTitleMaster.PrintingPaperDetails = ddlPrintingPaperInformation_V.SelectedItem.Text;
            //obTitleMaster.CoverpaperDetails = ddlCoverPaperinformation_V.SelectedItem.Text;
            //obTitleMaster.BindingDetails = Binding.SelectedItem.Text;
        }
        else
        {
            ResetFields();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (int.Parse(txtPages.Text) == 0)
            {
                // mainDiv.Style.Add("display", "block");
                //fadeDiv.Style.Add("display", "block");
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Page no can not be zero";

            }
            else if (double.Parse(txtRate.Text) == 0.00)
            {
                mainDiv.Style.Add("display", "block");
                lblmsg.Text = "Rate can not be zero";

            }
            else if (Session["UserID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                obTitleMaster.Medium = int.Parse(ddlMedium.SelectedValue);
                obTitleMaster.ClassTrno = int.Parse(ddlClass.SelectedValue);
                obTitleMaster.TitleHindi = txtTitleHindi.Text;
                obTitleMaster.Size = txtSize.Text;
                obTitleMaster.Pages = int.Parse(txtPages.Text);
                obTitleMaster.ColourCover1n4 = ddlColourCover1n4.SelectedValue;
                obTitleMaster.ColourCover2n3 = ddlColourCover2n3.SelectedValue;
                obTitleMaster.ColorText = ddlColourText.SelectedValue;
                obTitleMaster.TitleEnglish = txtTitleEnglish.Text;
                obTitleMaster.Rate = double.Parse(txtRate.Text);
                obTitleMaster.DepartmentTrno = int.Parse(ddlDepartment.SelectedValue);
                obTitleMaster.CoverPaperSize_GSM = 0;
                obTitleMaster.PrintngPaperSize_GSM = 0;
                obTitleMaster.RateListSNo = int.Parse(txtRateListSNo.Text);
                obTitleMaster.AcademicYrID = int.Parse(ddlAcYear.SelectedValue);
                obTitleMaster.UserId = int.Parse(Session["UserID"].ToString());

                obTitleMaster.PrintingPaperDetails = ddlPrintingPaperInformation_V.SelectedItem.Text + "-" + ddlPrintingPaperInformation_V.SelectedValue;
                obTitleMaster.CoverpaperDetails = ddlCoverPaperinformation_V.SelectedItem.Text + "-" + ddlCoverPaperinformation_V.SelectedValue;
                obTitleMaster.BindingDetails = Binding.SelectedItem.Text;
                int id = 0;
                if (Request.QueryString["ID"] != null)
                {
                    int.TryParse(new APIProcedure().Decrypt(Request.QueryString["ID"]), out id);
                }
                else if (RadioButtonList1.SelectedValue == "2")
                {
                    try
                    {
                        id = Convert.ToInt32(ddlTitle.SelectedValue);
                    }
                    catch { id = 0; }
                }



                obTitleMaster.TranID = id;
                try
                {
                    obTitleMaster.InsertUpdate();
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Data Saved";
                    try
                    {
                        ddlTitle.DataTextField = "TitleHindi_V";
                        ddlTitle.DataValueField = "TitleID_I";
                        ddlTitle.DataSource = obCommonFunction.FillDatasetByProc("call `USP_ACD001_TitleMasterSelect`(0," + hdnAcademicYearID.Value + ",0, 0, 0)");
                        ddlTitle.DataBind();
                        ddlTitle.Items.Insert(0, "Select..");
                    }
                    catch { }
                    // 
                }
                catch (Exception ex)
                {
                    mainDiv.Style.Add("display", "block");
                    lblmsg.Text = "Duplicate entry";
                }
            }
        }
        obCommonFunction.EmptyTextBoxes(this);

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "2")
        {
            a.Visible = true;
            a1.Visible = true;
        }
        else
        {
            ddlTitle.SelectedIndex = 0;
            a.Visible = false;
            a1.Visible = false;

        }
    }
    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillData(Convert.ToInt32(ddlTitle.SelectedValue));
    }
    protected void btnSave0_Click(object sender, EventArgs e)
    {
        Response.Redirect("View_ACD_001.aspx");
    }
    protected void ddlclass1_SelectedIndexChanged(object sender, EventArgs e)
    {


        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleID_I";
        ddlTitle.DataSource = obCommonFunction.FillDatasetByProc("call `USP_ACD001_TitleMasterSelect`(-111," + hdnAcademicYearID.Value + "," + ddlclass1.SelectedValue + ",'" + obCommonFunction.GetFinYear1() + "', 0)");
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, "Select..");
    }
}