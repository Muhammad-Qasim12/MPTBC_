using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer.DistributionB;
using System.Globalization;
using System.IO;

public partial class DistributionB_TenderInsuranceInfo : System.Web.UI.Page
{
    APIProcedure objApi = new APIProcedure();
    DataSet ds;
    InsuranceTenderInfo objTenderInfo = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string path, FileName;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            chkAll.Visible = false;
            if (Request.QueryString["ID"] != null)
            {
                GridFillLoad();
            }
        }
    }

    protected void chkAll_checkedChanged(object sender, EventArgs e)
    {
        try
        {
            if (chkAll.Checked == true)
            {
                foreach(ListItem List in ddlDepo.Items)
                {
                    List.Selected = true;
                }
            }
            else if(chkAll.Checked ==false)
            {
                foreach (ListItem List in ddlDepo.Items)
                {
                    List.Selected = false;
                }
            }
        }
        catch { }
        finally { }
    }

    private void fillDepo()
    {
        DataSet dsDepo = obCommonFuction.FillDatasetByProc("Call USP_ADM010_DepomasterLoad(0)");
        ddlDepo.DataSource = dsDepo.Tables[0];
        ddlDepo.DataValueField = "DepoTrno_I";
        ddlDepo.DataTextField = "DepoName_V";
        ddlDepo.DataBind();

        if (dsDepo.Tables[0].Rows.Count > 0)
        {
            chkAll.Visible = true;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DateTime DteCheck;
        string Date = "", FeeDate = "", CommDate = "", TechDate = "", CommTime = "", TechTime = "";
        if (txtTechnicalTime.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse("01/01/2015 " + txtTechnicalTime.Text, cult);
            }
            catch { TechTime = "NoDate"; }
        }
        if (txtCommTime.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse("01/01/2015 " + txtCommTime.Text, cult);
            }
            catch { CommTime = "NoDate"; }
        }
        if (txtDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtDate.Text, cult);
            }
            catch { Date = "NoDate"; }
        }
        if (txtCommDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtDate.Text, cult);
            }
            catch { CommDate = "NoDate"; }
        }
        if (txtTechnicalDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtTechnicalDate.Text, cult);
            }
            catch { TechDate = "NoDate"; }
        }
        if (txtTenderSubDt.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtTenderSubDt.Text, cult);
            }
            catch { FeeDate = "NoFeeDate"; }
        }

        if (Date != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct tender Date.');</script>");
        }
        else if (FeeDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct tender submission Date.');</script>");
        }

        else if (TechDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct technical bid opening Date.');</script>");
        }
        else if (CommDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct commercial bid opening Date.');</script>");
        }
        else if (TechTime != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct technical Time.');</script>");
        }
        else if (CommTime != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct commercial Time.');</script>");
        }
        else if (DateTime.Parse(txtTenderSubDt.Text, cult) < DateTime.Parse(txtDate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender submit date can not be greater then tender date.');</script>");
        }
        else if (DateTime.Parse(txtTechnicalDate.Text, cult) < DateTime.Parse(txtDate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be less then tender date.');</script>");
        }
        else if (txtCommDate.Text!="" && (DateTime.Parse(txtCommDate.Text, cult) < DateTime.Parse(txtTechnicalDate.Text, cult)))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Technical date can not be greater then Commercial date.');</script>");
        }
        else if (txtDetails.Text.ToString().Length > 240)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 240 character in detail text box.');</script>");

        }
        else if (txtRemark.Text.ToString().Length > 149)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter less then 150 character in remark text box.');</script>");

        }
        else if ((txtCommDate.Text=="" && txtCommTime.Text!="" ) ||(txtCommDate.Text!="" && txtCommTime.Text==""))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter both values for commercial bid opening information.');</script>");

        }
        else
        {

            string ImgStatus = "";


            if (fileUp1.FileName == "")
            {
                ImgStatus = "Ok";
                FileName = hdnFile.Value.ToString();
            }
            else
            {
                ImgStatus = objApi.uploadFile(fileUp1, "PaperUploadedFile", 3000);
                if (ImgStatus == "Ok")
                {
                    FileName = objApi.FullFileName;
                }
            }

            if (ImgStatus == "Ok")
            {
                objTenderInfo = new InsuranceTenderInfo();
                objTenderInfo.EMDAmount_N = float.Parse(txtEMD.Text.Trim());
                objTenderInfo.WorkName_V = txtNameOfWork.Text.Trim();
                objTenderInfo.TenderDate_D = Convert.ToDateTime(txtDate.Text.Trim(), cult);
                objTenderInfo.InsuranceDateFrom_D = Convert.ToDateTime(txtInsuranceDateFrom.Text, cult);
                objTenderInfo.InsuranceDateTo_D = Convert.ToDateTime(txtInsuranceDateTo.Text, cult);
                objTenderInfo.TenderDescription_V = txtDetails.Text;
                objTenderInfo.TenderFees_N = float.Parse(txtTenderFee.Text);
                objTenderInfo.TenderFile_V = FileName;
                objTenderInfo.TenderNo_V = txtRFPNo.Text.Trim();
                objTenderInfo.TenderSubmissionDate_D = Convert.ToDateTime(txtTenderSubDt.Text.Trim(), cult);
                objTenderInfo.TenderType_V = ddlTenderType.SelectedItem.Text;
                objTenderInfo.UserId_I = int.Parse(Session["UserID"].ToString());
                objTenderInfo.Remark_V = txtRemark.Text.Trim();

                objTenderInfo.TechDate = DateTime.Parse(txtTechnicalDate.Text.Trim(), cult);
                objTenderInfo.TechTime = txtTechnicalTime.Text.Trim();

                if (txtCommDate.Text != "")
                    objTenderInfo.CommDate = DateTime.Parse(txtCommDate.Text.Trim(), cult).ToString("yyyy-MM-dd");
                else
                    objTenderInfo.CommDate = null;
                if (txtCommTime.Text != "")
                    objTenderInfo.CommTime = txtCommTime.Text.Trim();
                else
                    objTenderInfo.CommTime = null;

                objTenderInfo.TenderSubmissionTime = txtTenderSubTime.Text;
                objTenderInfo.TenderAmount = int.Parse(txtAnualStock.Text);
                objTenderInfo.DepoIDs = string.Empty;
                foreach (ListItem lstDepo in ddlDepo.Items)
                {
                    if (lstDepo.Selected == true)
                    {
                        objTenderInfo.DepoIDs += lstDepo.Value + ",";
                    }
                }
                if (objTenderInfo.DepoIDs != "")
                {
                    objTenderInfo.DepoIDs = objTenderInfo.DepoIDs.Substring(0, objTenderInfo.DepoIDs.Length - 1);
                }
                if (Request.QueryString["ID"] != null)
                {
                    objTenderInfo.TenderTrId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
                }
                else
                {
                    objTenderInfo.TenderTrId_I = 0;
                }
                try
                {
                    int i = objTenderInfo.InsertUpdate();
                    if (i > 0)
                    {
                        if (Request.QueryString["ID"] != null)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                            Response.Redirect("ViewTenderInsuranceInfo.aspx");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                            Response.Redirect("ViewTenderInsuranceInfo.aspx");
                        }
                        obCommonFuction.EmptyTextBoxes(this);
                        lblMsg.Text = "";
                        foreach (ListItem lstDepo in ddlDepo.Items)
                        {
                            lstDepo.Selected = false;
                        }
                        //   Clear();
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Tender No Already Exist.');</script>"); }
            }
            else
            {
                lblMsg.Text = ImgStatus.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objTenderInfo = new InsuranceTenderInfo();
            objTenderInfo.TenderTrId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
            ds = objTenderInfo.Select();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DateTime dat = new DateTime();
                DateTime SubDt = new DateTime();

                //
                dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
                txtDate.Text = dat.ToString("dd/MM/yyyy");
                txtTenderSubDt.Text = SubDt.ToString("dd/MM/yyyy");
                txtTenderSubTime.Text = ds.Tables[0].Rows[0]["TenderSubmissionTime"].ToString();
                txtDetails.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
                txtEMD.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
                txtNameOfWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
                txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
                txtRFPNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
                txtTenderFee.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();

                txtInsuranceDateFrom.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateFrom_D"]).ToString("dd/MM/yyyy");
                txtInsuranceDateTo.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateTo_D"]).ToString("dd/MM/yyyy");

                if (ds.Tables[0].Rows[0]["CommDate"].ToString() != "")
                {
                    SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
                    txtCommDate.Text = SubDt.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtCommDate.Text = "";
                }   
                SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TechDate"].ToString());
                txtTechnicalDate.Text = SubDt.ToString("dd/MM/yyyy");


                txtTechnicalTime.Text = ds.Tables[0].Rows[0]["TechTime"].ToString();
                txtCommTime.Text = ds.Tables[0].Rows[0]["CommTime"].ToString();

                txtAnualStock.Text = ds.Tables[0].Rows[0]["TenderAmount"].ToString();


                hdnFile.Value = ds.Tables[0].Rows[0]["TenderFile_V"].ToString();
                
               

                FillddlTenderType(Convert.ToInt32(ddlTenderType.SelectedValue));

                ddlTenderType.ClearSelection();
                ddlTenderType.Items.FindByText(ds.Tables[0].Rows[0]["TenderType_V"].ToString()).Selected = true;
            }
        }
        catch { }

    }

    public void FillddlTenderType(int TenderType)
    {
        try
        {
            FillDDL();

            string[] selectedDepos = ds.Tables[0].Rows[0]["DepoIDs"].ToString().Split(',');

            foreach (ListItem lstDepo in ddlDepo.Items)
            {
                for (int i = 0; i < selectedDepos.Length; i++)
                {
                    if (lstDepo.Value == selectedDepos[i])
                    {
                        lstDepo.Selected = true;
                        break;
                    }
                }
            }

        }
        catch { }
        finally { }
    }
    protected void ddlTenderType_SelectedIndexChange(object sender, EventArgs e)
    {
        try
        {
            FillDDL();
        }
        catch { }
        finally { }
    }

    protected void FillDDL()
    {
        fillDepo();
        List<ListItem> List = new List<ListItem>();
        for (int i = 0; i < ddlDepo.Items.Count; i++)
        {
            if (ddlTenderType.SelectedValue == "0")
            {
                if (ddlDepo.Items[i].Text == "केंद्रीय पेपर डिपो")
                {
                    ddlDepo.Items.RemoveAt(i);
                }
            }
            else if (ddlTenderType.SelectedValue == "1")
            {
                if (ddlDepo.Items[i].Text != "केंद्रीय पेपर डिपो")
                {
                    //ddlDepo.Items.RemoveAt(i);
                    List.Add(ddlDepo.Items[i]);
                }
            }
        }
        if (ddlTenderType.SelectedValue == "1")
        {
            for (int i = 0; i < List.Count; i++)
            {
                ddlDepo.Items.Remove(List[i]);
            }
        }
    }
}
