using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Academic_ViewTitleMaster : System.Web.UI.Page
{
    MPTBCBussinessLayer.Academic.TitleMaster obTitleMaster = new MPTBCBussinessLayer.Academic.TitleMaster();
    CommonFuction obCommonFunction = new CommonFuction();
    MessageC m = new MessageC();
    protected void Page_Load(object sender, EventArgs e)
    {
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = "";

        if (!IsPostBack)
        {
            try
            {
                obTitleMaster.TitleID = -5;
                lblAcademicYear.Text = obCommonFunction.GetFinYear();
                obTitleMaster.StringParameter = obCommonFunction.GetFinYear();
                DataSet dsAcYear = obTitleMaster.Select();
                if (dsAcYear.Tables[0] != null && dsAcYear.Tables[0].Rows.Count > 0)
                {
                    hdnAcademicYearID.Value = dsAcYear.Tables[0].Rows[0]["Id"].ToString();
                    lblAcademicYear.Text = dsAcYear.Tables[0].Rows[0]["Acyear"].ToString();
                }
                else
                {
                    hdnAcademicYearID.Value = "0";
                }
                FillCombo();
                FillGrid();

            }
            catch (Exception)
            {
                m.ShowMessage("e");
            }
        }

    }

    private void FillCombo()
    {
        try
        {
            obTitleMaster.TitleID = -1;
            ddlClass.DataSource = obTitleMaster.Select();
            ddlClass.DataTextField = "Classdet_V";
            ddlClass.DataValueField = "ClassTrno_I";
            ddlClass.DataBind();
            ListItem lstAllValue = new ListItem("Select..", "0");
            ddlClass.Items.Insert(0, lstAllValue);


            obTitleMaster.TitleID = -3;
            ddlMedium.DataSource = obTitleMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataBind();
            lstAllValue = new ListItem("Select..", "0");
            ddlMedium.Items.Insert(0, lstAllValue);
        }
        catch (Exception)
        {
            m.ShowMessage("e");
        }
    }
    private void FillGrid()
    {
        try
        {

            obTitleMaster.TitleID = -4;
            obTitleMaster.AcademicYrID = int.Parse(hdnAcademicYearID.Value);
            obTitleMaster.ClassTrno = int.Parse(ddlClass.SelectedValue);
            obTitleMaster.Medium = int.Parse(ddlMedium.SelectedValue);
            DataSet dsGridSource = obTitleMaster.Select();
            GrdTitle.DataSource = dsGridSource;
            GrdTitle.DataBind();
            if (dsGridSource.Tables[0].Rows.Count == 0)
            {
                tr2.Visible = false;
                tr3.Visible = true;
            }
            else
            {
                tr2.Visible = true;
                tr3.Visible = false;
            }

        }
        catch (Exception)
        {
            m.ShowMessage("e");
        }

    }
    protected void GrdTitle_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            obTitleMaster.UserId = int.Parse(Session["UserID"].ToString());
            obTitleMaster.Delete(Convert.ToInt32(GrdTitle.DataKeys[e.RowIndex].Value.ToString()));
            FillGrid();
            m.ShowMessage("d");
        }
        catch
        {
            m.ShowMessage("e");
        }
    }
    protected void GrdTitle_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTitle.PageIndex = e.NewPageIndex;
        FillGrid();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("TitleMaster.aspx");
    }
    protected void ddlMedium_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void btnRepeatTitle_Click(object sender, EventArgs e)
    {
        try
        {

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/login.aspx");
            }
            else
            {
                obTitleMaster.TranID = -1;
                obTitleMaster.AcademicYrID = int.Parse(hdnAcademicYearID.Value);
                obTitleMaster.UserId = int.Parse(Session["UserId"].ToString());
                obTitleMaster.InsertUpdate();
                FillGrid();
            }
        }
        catch (Exception)
        {
            m.ShowMessage("e");
        }
    }
}