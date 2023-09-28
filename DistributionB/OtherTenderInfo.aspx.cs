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

public partial class DistributionB_OtherTenderInfo : System.Web.UI.Page
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
            //hkAll.Visible = false;

         GridFillLoad();
            ddlTenderType.DataSource = obCommonFuction.FillDatasetByProc(" SELECT * FROM tenderTypeM");
            ddlTenderType.DataTextField = "TenderA";
            ddlTenderType.DataValueField = "ID";
            ddlTenderType.DataBind();
           
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
                obCommonFuction.FillDatasetByProc("call USP_TenderDetailsA(0,'" + txtNameOfWork.Text + "','" + ddlTenderType.SelectedValue + "','" + txtRFPNo.Text + "','" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtInsuranceDateFrom.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtInsuranceDateTo.Text, cult).ToString("yyyy-MM-dd") + "','" + txtDetails.Text + "','" + FileName.ToString() + "','" + txtEMD.Text + "','" + txtTenderFee.Text + "','" + Convert.ToDateTime(txtTenderSubDt.Text, cult).ToString("yyyy-MM-dd") + "','" + txtTenderSubTime.Text + "','" + Convert.ToDateTime(txtTechnicalDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtTechnicalTime.Text + "','" + Convert.ToDateTime(txtCommDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtCommTime.Text + "','" + txtRemark.Text + "','" + txtName.Text + "','" + txtAddres.Text + "','" + txtConatac.Text + "',"+Session["UserID"].ToString ()+")");
              //  ID,TenderName,TenderType,TenderNo,TenderDate,FromDate,
//ToDate,TenderDetails,CopyRFP,EMD ,TenderFee,LastDateofTen,Timelimitfor,
//  OpeningDate,  TimeofTechnicalBid , CommercialBid,  TimeofCommercialBid ,
// Remark , NAME ,   ContactNo,  Address,  UserID 
                obCommonFuction.EmptyTextBoxes(this);
                GridFillLoad();
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
            GridView1.DataSource = obCommonFuction.FillDatasetByProc(@"SELECT TenderA,TenderName,TenderType,TenderNo
,date_format(TenderDate,'%d/%m/%Y')TenderDate,FromDate,
ToDate,TenderDetails,CopyRFP,EMD ,TenderFee,LastDateofTen,Timelimitfor,
  OpeningDate,  TimeofTechnicalBid , CommercialBid,  TimeofCommercialBid ,
 Remark , NAME ,   ContactNo,  Address,  UserID   FROM tbl_tenderDetails
 INNER JOIN tenderTypeM ON tenderTypeM.ID=tbl_tenderDetails.TenderType where UserID=" + Session["UserID"].ToString() + "");
            GridView1.DataBind();
            //objTenderInfo = new InsuranceTenderInfo();
            //objTenderInfo.TenderTrId_I = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
            //ds = objTenderInfo.Select();
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    DateTime dat = new DateTime();
            //    DateTime SubDt = new DateTime();

            //    //
            //    dat = DateTime.Parse(ds.Tables[0].Rows[0]["TenderDate_D"].ToString());
            //    SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TenderSubmissionDate_D"].ToString());
            //    txtDate.Text = dat.ToString("dd/MM/yyyy");
            //    txtTenderSubDt.Text = SubDt.ToString("dd/MM/yyyy");
            //    txtTenderSubTime.Text = ds.Tables[0].Rows[0]["TenderSubmissionTime"].ToString();
            //    txtDetails.Text = ds.Tables[0].Rows[0]["TenderDescription_V"].ToString();
            //    txtEMD.Text = ds.Tables[0].Rows[0]["EMDAmount_N"].ToString();
            //    txtNameOfWork.Text = ds.Tables[0].Rows[0]["WorkName_V"].ToString();
            //    txtRemark.Text = ds.Tables[0].Rows[0]["Remark_V"].ToString();
            //    txtRFPNo.Text = ds.Tables[0].Rows[0]["TenderNo_V"].ToString();
            //    txtTenderFee.Text = ds.Tables[0].Rows[0]["TenderFees_N"].ToString();

            //    txtInsuranceDateFrom.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateFrom_D"]).ToString("dd/MM/yyyy");
            //    txtInsuranceDateTo.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["InsuranceDateTo_D"]).ToString("dd/MM/yyyy");

            //    if (ds.Tables[0].Rows[0]["CommDate"].ToString() != "")
            //    {
            //        SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["CommDate"].ToString());
            //        txtCommDate.Text = SubDt.ToString("dd/MM/yyyy");
            //    }
            //    else
            //    {
            //        txtCommDate.Text = "";
            //    }   
            //    SubDt = DateTime.Parse(ds.Tables[0].Rows[0]["TechDate"].ToString());
            //    txtTechnicalDate.Text = SubDt.ToString("dd/MM/yyyy");


            //    txtTechnicalTime.Text = ds.Tables[0].Rows[0]["TechTime"].ToString();
            //    txtCommTime.Text = ds.Tables[0].Rows[0]["CommTime"].ToString();

            //    txtAnualStock.Text = ds.Tables[0].Rows[0]["TenderAmount"].ToString();


            //    hdnFile.Value = ds.Tables[0].Rows[0]["TenderFile_V"].ToString();
                
               

            //    FillddlTenderType(Convert.ToInt32(ddlTenderType.SelectedValue));

            //    ddlTenderType.ClearSelection();
            //    ddlTenderType.Items.FindByText(ds.Tables[0].Rows[0]["TenderType_V"].ToString()).Selected = true;
            //}
        }
        catch { }

    }

   
    protected void ddlTenderType_SelectedIndexChange(object sender, EventArgs e)
    {
       
    }

   
}
