using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Academic_addSubject : System.Web.UI.Page
{
    APIProcedure api = new APIProcedure();
    string file, ImgStatus;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction comm = new CommonFuction();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd = comm.FillDatasetByProc("call GetClassandTitle(0,0)");
            ddlclass.DataTextField = "Classdet_V";
            ddlclass.DataValueField = "ClassTrno_I";
            ddlclass.DataSource = dd.Tables[0];
            ddlclass.DataBind();
            ddlclass.Items.Insert(0, "Select...");

            DropDownList2.DataSource = obCommonFuction.FillDatasetByProc("call USPSaveAddSubject(-1,0,0,0,0,0,0,0)");
            DropDownList2.DataValueField = "ID";
            DropDownList2.DataTextField = "Dateandname";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "Select..");
            //DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            fillgrd2();
            fillgrd();
        
        }
    }
    public void fillgrd2()
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_SaveSubjectDetails(-1,0,0,0,0)");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (HiddenField3.Value == "")
        {
            obCommonFuction.FillDatasetByProc("call USP_SaveSubjectDetails(0," + DropDownList2.SelectedValue + ",'" + txtLetterNo1.Text + "','" + Convert.ToDateTime(txtLelleterdate1.Text, cult).ToString("yyyy-MM-dd") + "','" + txtRemarka.Text + "')");
           mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Saved successfully";
        }
        else
        {
            obCommonFuction.FillDatasetByProc("call USP_SaveSubjectDetails(" + HiddenField3.Value + "," + DropDownList2.SelectedValue + ",'" + txtLetterNo1.Text + "','" + Convert.ToDateTime(txtLelleterdate1.Text, cult).ToString("yyyy-MM-dd") + "','" + txtRemarka.Text + "')");
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Updated successfully";

        }
        fillgrd2();
        HiddenField3.Value = "";
        obCommonFuction.EmptyTextBoxes(this);
        tcTitle.ActiveTabIndex = 1;
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd1 = obCommonFuction.FillDatasetByProc("call USP_SaveSubjectDetails(-2," + GridView1.SelectedDataKey.Value + ",0,0,0)");
        HiddenField3.Value = GridView1.SelectedDataKey.Value.ToString();
        txtLelleterdate1.Text = dd1.Tables[0].Rows[0]["dateL"].ToString();
        txtLetterNo1.Text = dd1.Tables[0].Rows[0]["LetterNo"].ToString();
        txtRemarka.Text = dd1.Tables[0].Rows[0]["Remark"].ToString();
        DropDownList2.SelectedValue = dd1.Tables[0].Rows[0]["SubID"].ToString();
        tcTitle.ActiveTabIndex = 1;
    }
    protected void ddlclass_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = comm.FillDatasetByProc("call GetClassandTitle(-1,"+ddlclass.SelectedValue+")");
        ddltitle.DataTextField = "TitleHindi_V";
        ddltitle.DataValueField = "TitleID_I";
        ddltitle.DataSource = dd.Tables[0];
        ddltitle.DataBind();
        ddltitle.Items.Insert(0, "Select...");
    }
    protected void btnOrder1_Click(object sender, EventArgs e)
    {
        
       
        if (HiddenField1.Value == "")
        {
            file = "";
            if (FileUpload1.FileName == "")
            {
                ImgStatus = "Ok";
            }
            else
            {
                ImgStatus = api.SingleuploadFile(FileUpload1, "SubjectFile", 100000);
                file = api.FullFileName;
            }
        comm.FillDatasetByProc("call USPSaveAddSubject(0,'" + txtlekhak.Text + "','" + txtLetterNoa.Text + "','" + Convert.ToDateTime(txtLetterDatea.Text, cult).ToString("yyyy-MM-dd") + "','" + ddlclass.SelectedValue + "','" + ddltitle.SelectedValue + "','" + DropDownList1.SelectedItem.Text + "','" + file.ToString () + "')");
        mainDiv.CssClass = "form-message success";
        mainDiv.Style.Add("display", "block");
        lblmsg.Text = "Record Saved successfully";
        }
        else
        {
            if (FileUpload1.FileName == "")
            {
                ImgStatus = "Ok";
                file = HiddenField2.Value;
            }
            else
            {
                ImgStatus = api.SingleuploadFile(FileUpload1, "SubjectFile", 100000);
                file = api.FullFileName;
            }
            comm.FillDatasetByProc("call USPSaveAddSubject("+HiddenField1.Value+",'" + txtlekhak.Text + "','" + txtLetterNoa.Text + "','" + Convert.ToDateTime(txtLetterDatea.Text, cult).ToString("yyyy-MM-dd") + "','" + ddlclass.SelectedValue + "','" + ddltitle.SelectedValue + "','" + DropDownList1.SelectedItem.Text + "','" + file.ToString() + "')");
            mainDiv.CssClass = "form-message success";
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Record Updated successfully";
            
        }
        fillgrd();
        comm.EmptyTextBoxes(this);
        DropDownList2.DataSource = obCommonFuction.FillDatasetByProc("call USPSaveAddSubject(-1,0,0,0,0,0,0,0)");
        DropDownList2.DataValueField = "ID";
        DropDownList2.DataTextField = "Dateandname";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select..");
    }
    public void fillgrd()
    {
     DataSet dd=  comm.FillDatasetByProc("call USPSaveAddSubject(-1,0,0,0,0,0,0,0)");
     grdSelectedTitle1.DataSource = dd.Tables[0];
     grdSelectedTitle1.DataBind();
    }
    protected void grdSelectedTitle1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dda = comm.FillDatasetByProc("call USPSaveAddSubject(-2,"+grdSelectedTitle1.SelectedDataKey.Value+",0,0,0,0,0,0)");
        txtlekhak.Text = dda.Tables[0].Rows[0]["Name"].ToString();
        txtLetterDatea.Text = dda.Tables[0].Rows[0]["LetterDate"].ToString();
        txtLetterNoa.Text = dda.Tables[0].Rows[0]["LetterNo"].ToString();
        ddlclass.SelectedValue = dda.Tables[0].Rows[0]["ClassID"].ToString();
        ddlclass_SelectedIndexChanged( sender,  e);
        ddltitle.SelectedValue = dda.Tables[0].Rows[0]["TitleID"].ToString();
        DropDownList1.ClearSelection();
        DropDownList1.Items.FindByText(dda.Tables[0].Rows[0]["Subject"].ToString()).Selected = true;//Subject
        HiddenField1.Value = grdSelectedTitle1.SelectedDataKey.Value.ToString();
        HiddenField2.Value = dda.Tables[0].Rows[0]["FileUpload"].ToString();
    }
}