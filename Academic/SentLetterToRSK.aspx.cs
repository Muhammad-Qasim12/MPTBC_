using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Academic_SentLetterToRSK : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    MessageC m = new MessageC();
    string file, ImgStatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmsg.Text = string.Empty;
        if (!IsPostBack)
        {
            try
            {
                DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACD002_DepartmentMasterSelect(0)");
                DropDownList1.DataValueField = "DepTrno_I";
                DropDownList1.DataTextField = "DepName_V";
                DropDownList1.DataBind();
                DropDownList1.Items.Insert(0, "Select..");
                //DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
                fillgrd2();
                ddlNigamLetter.DataSource = obCommonFuction.FillDatasetByProc("call USP_SubjectChnageDetails(-1,0,0,0,0,0)");
                ddlNigamLetter.DataValueField = "ID";
                ddlNigamLetter.DataTextField = "nigamKaPrata";
                ddlNigamLetter.DataBind();
                ddlNigamLetter.Items.Insert(0, "Select..");
                fillgrd();
            }
            catch (Exception)
            {
            }
        }
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_Savetbl_subjectChnage(-2," + GridView2.SelectedDataKey.Value + ",0,0,0,0)");
            HiddenField3.Value = GridView2.SelectedDataKey.Value.ToString();
            txtLelleterdate.Text = dd1.Tables[0].Rows[0]["LetterDate"].ToString();
            txtLetterNo.Text = dd1.Tables[0].Rows[0]["LetterNO"].ToString();
            txtRemark.Text = dd1.Tables[0].Rows[0]["Remark"].ToString();
            ddlNigamLetter.SelectedValue = dd1.Tables[0].Rows[0]["MasterID"].ToString();
            HiddenField4.Value = dd1.Tables[0].Rows[0]["UploadFile"].ToString();
        }
        catch (Exception)
        {
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            APIProcedure api = new APIProcedure();
            if (HiddenField3.Value == "")
            {
                if (FileUpload2.FileName == "")
                {
                    ImgStatus = "Ok";
                }
                else
                {
                    ImgStatus = api.SingleuploadFile(FileUpload2, "SubjectFile", 100240);
                    file = api.FullFileName;
                }
                obCommonFuction.FillDatasetByProc("call USP_Savetbl_subjectChnage(0," + ddlNigamLetter.SelectedValue + ",'" + txtLetterNo.Text + "','" + Convert.ToDateTime(txtLelleterdate.Text, cult).ToString("yyyy-MM-dd") + "','" + file + "','" + txtRemark.Text + "')");
                m.ShowMessage("s");
            }
            else
            {
                if (FileUpload2.FileName == "")
                {
                    ImgStatus = "Ok";
                    file = HiddenField4.Value;
                }
                else
                {
                    ImgStatus = api.SingleuploadFile(FileUpload2, "SubjectFile", 100240);
                    file = api.FullFileName;
                }
                obCommonFuction.FillDatasetByProc("call USP_Savetbl_subjectChnage(" + HiddenField3.Value + "," + ddlNigamLetter.SelectedValue + ",'" + txtLetterNo.Text + "','" + Convert.ToDateTime(txtLelleterdate.Text, cult).ToString("yyyy-MM-dd") + "','" + file + "','" + txtRemark.Text + "')");
                m.ShowMessage("u");
            }
            fillgrd();
            HiddenField3.Value = "";
            HiddenField4.Value = "";
            obCommonFuction.EmptyTextBoxes(this);
        }
        catch (Exception)
        {
        }
    }
    public void fillgrd()
    {
        try
        {
            DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_Savetbl_subjectChnage(-1,0,0,0,0,0)");
            GridView2.DataSource = dd1.Tables[0];
            GridView2.DataBind();
        }
        catch (Exception)
        {
        }
    }
    public void fillgrd2()
    {
        try
        {
            DataSet dd = obCommonFuction.FillDatasetByProc("call USP_SubjectChnageDetails(-1,0,0,0,0,0)");
            GridView1.DataSource = dd.Tables[0];
            GridView1.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            APIProcedure api = new APIProcedure();
            if (HiddenField3.Value == "")
            {
                if (FileUpload1.FileName == "")
                {
                    ImgStatus = "Ok";
                }
                else
                {
                    ImgStatus = api.SingleuploadFile(FileUpload1, "SubjectFile", 100240);
                    file = api.FullFileName;
                }
                obCommonFuction.FillDatasetByProc("call USP_SubjectChnageDetails(0," + DropDownList1.SelectedValue + ",'" + txtLetterNo1.Text + "','" + Convert.ToDateTime(txtLelleterdate1.Text, cult).ToString("yyyy-MM-dd") + "','" + file + "','" + txtRemarka.Text + "')");
                m.ShowMessage("s");
            }
            else
            {
                if (FileUpload1.FileName == "")
                {
                    ImgStatus = "Ok";
                    file = HiddenField4.Value;
                }
                else
                {
                    ImgStatus = api.SingleuploadFile(FileUpload1, "SubjectFile", 100240);
                    file = api.FullFileName;
                }
                obCommonFuction.FillDatasetByProc("call USP_SubjectChnageDetails(" + HiddenField3.Value + "," + DropDownList1.SelectedValue + ",'" + txtLetterNo1.Text + "','" + Convert.ToDateTime(txtLelleterdate1.Text, cult).ToString("yyyy-MM-dd") + "','" + file + "','" + txtRemarka.Text + "')");
                m.ShowMessage("u");

            }
            fillgrd2();
            HiddenField3.Value = "";
            obCommonFuction.EmptyTextBoxes(this);
            ddlNigamLetter.DataSource = obCommonFuction.FillDatasetByProc("call USP_SubjectChnageDetails(-1,0,0,0,0,0)");
            ddlNigamLetter.DataValueField = "ID";
            ddlNigamLetter.DataTextField = "nigamKaPrata";
            ddlNigamLetter.DataBind();
            ddlNigamLetter.Items.Insert(0, "Select..");
        }
        catch (Exception)
        {
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            HiddenField3.Value = GridView1.SelectedDataKey.Value.ToString();
            DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_SubjectChnageDetails(-2," + HiddenField3.Value + ",0,0,0,0)");           
            txtLelleterdate1.Text = dd1.Tables[0].Rows[0]["LetterDate"].ToString();
            txtLetterNo1.Text = dd1.Tables[0].Rows[0]["LetterNo"].ToString();
            txtRemarka.Text = dd1.Tables[0].Rows[0]["Remark"].ToString();
            DropDownList1.SelectedValue = dd1.Tables[0].Rows[0]["DepartmentID"].ToString();
            HiddenField4.Value = dd1.Tables[0].Rows[0]["UploadFile"].ToString();
        }
        catch (Exception)
        {
            
        }
    }
}