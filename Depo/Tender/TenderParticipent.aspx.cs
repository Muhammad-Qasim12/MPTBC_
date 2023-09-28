using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using System.IO;
public partial class Depo_Tender_TenderParticipent : System.Web.UI.Page
{
    Vehicle003_Tender obTender = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadTender();
            if (Request.QueryString["Cid"] != null)
            {
                LoadTenderParticipent();
            }
        }
    }


    public void LoadTender()
    {
       // obTender = new Vehicle003_Tender();
        obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc("call Depo_TenderDetailsLoad(0,"+Session["UserID"].ToString()+")");
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataValueField = "TenderId_I";
        try
        {
         //   obTender.TenderID_I = 0;

            ddlTenderID_I.DataSource = ds.Tables[0];
            ddlTenderID_I.DataBind();
        }
        catch (Exception ex) { }
        finally { obTender = null; }

        ddlTenderID_I.Items.Insert(0, new ListItem("Select", "0"));
    }


    public int SaveTenderParticipent()
    {
        int i = 0;
       // obTender = new Vehicle003_Tender();

        try
        {
            if (Request.QueryString["Cid"] != null)
            {
               HiddenField2.Value= (new APIProcedure().Decrypt(Request.QueryString["Cid"]));


            }
            else { HiddenField2.Value = "0"; }

           

            APIProcedure objApi = new APIProcedure();
            bool IsValidFile = true;
            if (FileRegistration.HasFile)
            {

                string uploadStatus = objApi.SingleuploadFile(FileRegistration, "Depo/Tender/VehicleFile", 3000);
                if (uploadStatus != "Ok")
                {
                    //messDiv.Style.Add("display", "block");
                    //lblMess.Text = uploadStatus;
                    message(uploadStatus, "ERROR");
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + uploadStatus + "');</script>");
                    IsValidFile = false;
                }
                else
                    LblFileRegistration.Text = "Depo/Tender/VehicleFile/" + objApi.FullFileName;
            }
            if (FilePANNo.HasFile)
            {

                string uploadStatus = objApi.SingleuploadFile(FilePANNo, "Depo/Tender/VehicleFile", 3000);
                if (uploadStatus != "Ok")
                {
                    message(uploadStatus, "ERROR");
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + uploadStatus + "');</script>");
                    IsValidFile = false;
                }
                else
                    lblFilePANNo.Text = "Depo/Tender/VehicleFile/" + objApi.FullFileName;
            }
            if (IsValidFile)
            {
                //obTender.FilePANNo = Convert.ToString(lblFilePANNo.Text);
                //obTender.FileRegistration = Convert.ToString(LblFileRegistration.Text);
                //i = obTender.SaveTenderParticipent();
                obCommonFuction = new CommonFuction();
                obCommonFuction.FillDatasetByProc("call Depo_TenderParticipentSaveUpdate(" + HiddenField2.Value + "," + Convert.ToInt32(ddlTenderID_I.SelectedValue) + ",'" + Convert.ToString(txtNameofParty.Text) + "','" + Convert.ToString(txtAddress_Party.Text) + "','" + Convert.ToString(txtAddress_Garage.Text) + "','" + Convert.ToString(txtNature_Concern.SelectedValue) + "','" + Convert.ToString(txtRegistrationNo.Text) + "','" + Convert.ToString(txtTel_MobNo.Text) + "','" + Convert.ToString(txtTel_MobNo_Office.Text) + "','" + Convert.ToString(txtPANNo.Text) + "','" + Convert.ToDouble(txtEMD_Amt.Text) + "','" + Convert.ToString(txtDD_Details.Text) + "','" + Convert.ToString(txtBankDetails.Text) + "','" + Convert.ToDateTime(txtDDDate.Text, cult).ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(radioNITSign_I.SelectedValue) + ",'" + Convert.ToString(txtRemarks.Text) + "'," + Convert.ToInt32(Session["UserId"]) + ",'" + LblFileRegistration.Text + "','" + lblFilePANNo.Text + "')");
                i = 1;
            }
            //if (FileRegistration.HasFile)
            //{
            //    string path = "VehicleFile/" + txtNameofParty.Text.Replace(" ", "").ToString() + "Registration" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(FileRegistration.FileName);
            //    FileRegistration.SaveAs(Server.MapPath(path));
            //    LblFileRegistration.Text = path;
            //}
            //if (FilePANNo.HasFile)
            //{
            //    string path = "VehicleFile/" + txtNameofParty.Text.Replace(" ", "").ToString() + "PAN" + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(FilePANNo.FileName);
            //    FilePANNo.SaveAs(Server.MapPath(path));
            //    lblFilePANNo.Text = path;
            //}


        }
        catch (Exception ex) { }
        finally { obTender = null; }
        return i;
    }


    public void LoadTenderParticipent()
    {
        DataSet ds = new DataSet();
        obTender = new Vehicle003_Tender();

        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                HiddenField1.Value = (new APIProcedure().Decrypt(Request.QueryString["Cid"]));
            }else 
            {
            HiddenField1.Value="0";
            }
            ds = obCommonFuction.FillDatasetByProc("call Depo_TenderParticipentLoad(" + HiddenField1.Value + ","+Session["UserID"].ToString ()+")");

            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlTenderID_I.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["TenderID_I"]);
                txtNameofParty.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameofParty"]);
                txtAddress_Party.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address_Party"]);
                txtAddress_Garage.Text = Convert.ToString(ds.Tables[0].Rows[0]["Address_Garage"]);
                txtNature_Concern.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Nature_Concern"]);
                txtRegistrationNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegistrationNo"]);
                txtTel_MobNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["Tel_MobNo"]);
                txtTel_MobNo_Office.Text = Convert.ToString(ds.Tables[0].Rows[0]["Tel_MobNo_Office"]);
                txtPANNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["PANNo"]);
                txtEMD_Amt.Text = Convert.ToString(ds.Tables[0].Rows[0]["EMD_Amt"]);
                txtDD_Details.Text = Convert.ToString(ds.Tables[0].Rows[0]["DD_Details"]);
                txtBankDetails.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankDetails"]);
                txtDDDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["DDDate"]);
                radioNITSign_I.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["NITSign_I"]);
                txtRemarks.Text = Convert.ToString(ds.Tables[0].Rows[0]["Remarks"]);
                lblFilePANNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["FilePANNo"]);
                LblFileRegistration.Text = Convert.ToString(ds.Tables[0].Rows[0]["FileRegistration"]);
                ddlTenderID_I.Enabled = false;
            }

        }
        catch (Exception ex) { }
        finally { obTender = null; }

    }



    protected void btnTendererSave_Click(object sender, EventArgs e)
    {
        if (SaveTenderParticipent() > 0)
        {
            Response.Redirect("VIEW003_TenderParticipent.aspx");
        }

        else
        {
            message("Error.", "ERROR");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>");
        }
    }



    protected void BtnBack_Click(object sender, EventArgs e)
    {
       // Response.Redirect("VIEW003_TenderParticipent.aspx");
    }
    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }
    protected void radioNITSign_I_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}