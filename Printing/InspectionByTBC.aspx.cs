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
using System.IO;
using System.Globalization;
public partial class Paper_InspectionByTBC : System.Web.UI.Page
{
    DataSet ds;
    string path, FileName;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PPR_InspectionByTBc objInspectionByTBc = null;
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
        objInspectionByTBc = new PPR_InspectionByTBc();
        objInspectionByTBc.InspectionTrId_I = int.Parse(Request.QueryString["ID"].ToString());
        ds = objInspectionByTBc.InspectionDetailsFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnADD.Visible = false;
            DateTime dte = new DateTime();
            dte = DateTime.Parse(ds.Tables[0].Rows[0]["InspectionDate_D"].ToString());
            txtInspectionDate.Text = dte.ToString("dd/MM/yyyy");
            txtRemark.Text = ds.Tables[0].Rows[0]["InspectionReport_V"].ToString();
            rbInspectiontype.SelectedValue = ds.Tables[0].Rows[0]["InspectionType_I"].ToString();
            hdnFile.Value = ds.Tables[0].Rows[0]["InspectionFile_V"].ToString();

            ddlInspectionLevel.ClearSelection();
            try
            {
                ddlInspectionLevel.Items.FindByValue(ds.Tables[0].Rows[0]["InspectionLevel_I"].ToString()).Selected = true;
            }
            catch { }
            if (ddlInspectionLevel.SelectedItem.Value.ToString() == "4")
            {
                trINspectionName.Visible = true;
            }
            txtInspectionName.Text = ds.Tables[0].Rows[0]["InspectionName_V"].ToString();
            LOIFill();
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
            ddlLOINo.Enabled = false;
            PaperTypeFill();
            ddlPaperType.ClearSelection();
            ddlPaperType.Items.FindByValue(ds.Tables[0].Rows[0]["PaperType_I"].ToString()).Selected = true;
            PaperSizeFill();
            ddlPaperSize.ClearSelection();
            ddlPaperSize.Items.FindByValue(ds.Tables[0].Rows[0]["PaperMstrTrId_I"].ToString()).Selected = true;


            objInspectionByTBc.InspectionTrId_I = int.Parse(Request.QueryString["ID"].ToString());
           
            
            GrdOfficerDetail.DataSource = objInspectionByTBc.InspectionChildFill();
            GrdOfficerDetail.DataBind();

        }

    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblOfficeid = (Label)gv.FindControl("lblOfficeid");
        Label lblPost = (Label)gv.FindControl("lblPost");
        Label lblInspectionOfficerTrId_I = (Label)gv.FindControl("lblInspectionOfficerTrId_I");

        OfficeFill();
        ddlOfficeName.ClearSelection();
        ddlOfficeName.Items.FindByValue(lblOfficeid.Text).Selected = true;
        txtDesignation.Text = lblPost.Text;
        hdChildId.Value = lblInspectionOfficerTrId_I.Text;
        btnADD.Visible = true;
    }
    public void DataBindToGrid()
    {
        if (ViewState["TempData"] == null || ViewState["TempData"] == "")
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("OfficeName", typeof(string));
            dt.Columns.Add("Post", typeof(string));
            dt.Columns.Add("Officeid", typeof(string));
            dt.Columns.Add("OfficerDesignation_I", typeof(string));
            dt.Columns.Add("InspectionOfficerTrId_I", typeof(string));



            DataRow Dr = dt.NewRow();
            Dr["OfficeName"] = ddlOfficeName.SelectedItem.Text;
            Dr["Officeid"] = ddlOfficeName.SelectedItem.Value.ToString();
            Dr["Post"] = txtDesignation.Text;
            Dr["OfficerDesignation_I"] = ddlOfficeName.SelectedItem.Value.ToString();
            Dr["InspectionOfficerTrId_I"] = "0";

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
                    Dr["Officeid"] = ddlOfficeName.SelectedItem.Value.ToString();
                    Dr["Post"] = txtDesignation.Text;
                    Dr["OfficerDesignation_I"] = ddlOfficeName.SelectedItem.Value.ToString();
                    Dr["InspectionOfficerTrId_I"] = "0";
                }
                if (dt.Rows[0].ToString() == "")
                {
                    dt.Rows[0].Delete();
                    dt.AcceptChanges();
                }
                string Ckh = "";
                foreach (DataRow drt in dt.Rows)
                {
                    if (ddlOfficeName.SelectedItem.Value == drt["Officeid"].ToString())
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
    protected void btnADD_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            objInspectionByTBc.InspectionOfficerTrId_I = int.Parse(hdChildId.Value.ToString());
            objInspectionByTBc.InspectionOfficerName_I = int.Parse(ddlOfficeName.SelectedItem.Value);
            objInspectionByTBc.OfficerDesignation_I = int.Parse(ddlOfficeName.SelectedItem.Value);
            objInspectionByTBc.InspectionType_I = int.Parse(rbInspectiontype.SelectedValue.ToString());
            objInspectionByTBc.InspectionTrId_I = 0;
            objInspectionByTBc.OfficerInsertUpdate();

            objInspectionByTBc.InspectionTrId_I = int.Parse(Request.QueryString["ID"].ToString());
            GrdOfficerDetail.DataSource = objInspectionByTBc.InspectionChildFill();
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
        objInspectionByTBc = new PPR_InspectionByTBc();
        ddlLOINo.DataSource = objInspectionByTBc.LOIFill();
        ddlLOINo.DataTextField = "LOINo_V";
        ddlLOINo.DataValueField = "LOIId_I";
        ddlLOINo.DataBind();
        ddlLOINo.Items.Insert(0, "Select");
    }
    protected void ddlLOINo_Init(object sender, EventArgs e)
    {
        LOIFill();
    }
    public void PaperTypeFill()
    {
        if (ddlLOINo.SelectedItem.Text != "Select")
        {
            objInspectionByTBc = new PPR_InspectionByTBc();
            objInspectionByTBc.LOITrId_I = int.Parse(ddlLOINo.SelectedValue.ToString());
            ds = objInspectionByTBc.PaperFill();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlPaperType.DataSource = ds.Tables[0];
                ddlPaperType.DataTextField = "PaperType";
                ddlPaperType.DataValueField = "PaperType_I";
                ddlPaperType.DataBind();
                ddlPaperType.Items.Insert(0, "Select");

            }
        }
    }
    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        PaperTypeFill();
    }
    public void PaperSizeFill()
    {

        if (ddlLOINo.SelectedItem.Text != "Select")
        {
            objInspectionByTBc = new PPR_InspectionByTBc();
            objInspectionByTBc.LOITrId_I = int.Parse(ddlLOINo.SelectedValue.ToString());
            objInspectionByTBc.PaperMstrTrId_I = int.Parse(ddlPaperType.SelectedValue.ToString());
            ds = objInspectionByTBc.SizeFill();
            if (ds.Tables[0].Rows.Count > 0)
            {

                ddlPaperSize.DataSource = ds.Tables[0];
                ddlPaperSize.DataTextField = "CoverInformation";
                ddlPaperSize.DataValueField = "PaperMstrTrId_I";
                ddlPaperSize.DataBind();
                ddlPaperSize.Items.Insert(0, "Select");

            }
        }
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        PaperSizeFill();
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
        else if (txtRemark.Text.ToString().Length > 199)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 200 charecter in Inspection Report text box.');</script>");

        }
        else
        {
            if (GrdOfficerDetail.Rows.Count > 0)
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
                    objInspectionByTBc = new PPR_InspectionByTBc();

                    objInspectionByTBc.InspectionType_I = int.Parse(rbInspectiontype.SelectedItem.Value.ToString());
                    objInspectionByTBc.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedItem.Value.ToString());
                    objInspectionByTBc.PaperType_I = int.Parse(ddlPaperType.SelectedValue.ToString());
                    objInspectionByTBc.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
                    objInspectionByTBc.InspectionReport_V = txtRemark.Text;
                    objInspectionByTBc.InspectionFile_V = FileName;
                    objInspectionByTBc.InspectionDate_D = DateTime.Parse(txtInspectionDate.Text, cult);
                    objInspectionByTBc.UserId_I = int.Parse(Session["UserID"].ToString());
                    objInspectionByTBc.InspectionLevel_I = int.Parse(ddlInspectionLevel.SelectedItem.Value);
                    objInspectionByTBc.InspectionName_V = txtInspectionName.Text;

                    if (Request.QueryString["ID"] != null)
                    {
                        objInspectionByTBc.InspectionTrId_I = int.Parse(Request.QueryString["ID"].ToString());
                    }
                    else
                    {
                        objInspectionByTBc.InspectionTrId_I = 0;
                    }

                    if (Request.QueryString["ID"] != null)
                    {
                        int i = objInspectionByTBc.Update();
                        if (i > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                            Response.Redirect("ViewPPR_010_TBC.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record Not Changed.');</script>");
                        }
                    }
                    else
                    {
                        int i = objInspectionByTBc.InsertUpdate();
                        if (i > 0)
                        {
                            string CheckSts = "No";
                            foreach (GridViewRow gv in GrdOfficerDetail.Rows)
                            {
                                Label lblInspectionDate = (Label)gv.FindControl("lblInspectionDate");
                                Label lblOfficeid = (Label)gv.FindControl("lblOfficeid");
                                Label lblOfficerDesignation_I = (Label)gv.FindControl("lblOfficerDesignation_I");
                                objInspectionByTBc.InspectionOfficerTrId_I = 0;
                                objInspectionByTBc.InspectionOfficerName_I = int.Parse(lblOfficeid.Text);
                                objInspectionByTBc.OfficerDesignation_I = int.Parse(lblOfficerDesignation_I.Text);
                                objInspectionByTBc.InspectionType_I = int.Parse(rbInspectiontype.SelectedValue.ToString());
                                objInspectionByTBc.InspectionTrId_I = i;
                                objInspectionByTBc.OfficerInsertUpdate();
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
    }
    public void OfficeFill()
    {
        objInspectionByTBc = new PPR_InspectionByTBc();
        ddlOfficeName.DataSource = objInspectionByTBc.OfficerDesignationmFill();
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
        objInspectionByTBc = new PPR_InspectionByTBc();
        if (ddlOfficeName.SelectedItem.Text != "Select")
        {
            ds = objInspectionByTBc.OfficerPostFill(int.Parse(ddlOfficeName.SelectedValue.ToString()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtDesignation.Text = ds.Tables[0].Rows[0]["Post"].ToString();
            }
        }
        else
        {
            txtDesignation.Text = "";
        }
    }
    protected void ddlInspectionLevel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInspectionLevel.SelectedItem.Value == "4")
        {
            trINspectionName.Visible = true;
        }
        else
        {
            trINspectionName.Visible = false;
           
        }
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
            PBGNo_V = Dt.Rows[i]["Officeid"].ToString();
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
}
