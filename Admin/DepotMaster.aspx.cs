using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Admin_DepotMaster : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    DPT_DepotMaster obDPT_DepotMaster = null;
    DistrictMaster obDistrictMaster = null;
    CommonFuction obCommonFuction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillCombo();

            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);
                }

            }
            catch { }
            finally { obDPT_DepotMaster = null; }
        }


    }
    private void FillCombo()
    {
        try
        {
            obDistrictMaster = new DistrictMaster();
            ddlDistrict.DataSource = obDistrictMaster.Select();
            ddlDistrict.DataValueField = "DistrictTrno_I";
            ddlDistrict.DataTextField = "District_Name_Hindi_V";
            ddlDistrict.DataBind();
            ListItem lstSelectDistrict = new ListItem("सेलेक्ट", "");
            ddlDistrict.Items.Insert(0, lstSelectDistrict);


            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = 0;
            ddlMainDepo.DataSource = obDPT_DepotMaster.Select();
            ddlMainDepo.DataTextField = "DepoName_V";
            ddlMainDepo.DataValueField = "DepoTrno_I";
            ddlMainDepo.DataBind();
        }
        catch (Exception)
        {
        }
    }
    protected void chkIsStatelite_OnCheckedChanged(object sender, EventArgs e)    
    {
        ChkStateliteChange();
    }
    private void ChkStateliteChange()
    {
        if (chkIsStatelite.Checked)
        {
            ddlMainDepo.Visible = true;
            lblDepoTitle.Visible = true;
        }
        else
        {
            ddlMainDepo.Visible = false;
            lblDepoTitle.Visible = false;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["DepoTrno_I"] = 0;
        try
        {
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoName_V = Convert.ToString(txtDepotName.Text.Trim());
            obDPT_DepotMaster.TeleNo_V = Convert.ToString(txtTelephone.Text.Trim());
            obDPT_DepotMaster.MobNo_V = Convert.ToString(txtMobileNo.Text.Trim());
            obDPT_DepotMaster.DepoAddress_V = txtDepotAddress.Text;
            obDPT_DepotMaster.DistrictTrno_I = Convert.ToInt32(ddlDistrict.SelectedValue);
           // obDPT_DepotMaster.FaxNo_V = Convert.ToString(txtFaxNo.Text.Trim());
            obDPT_DepotMaster.Emailid_V = Convert.ToString(txtEmailID.Text.Trim());
            obDPT_DepotMaster.DepoManager_Name_V = txtDepoManager.Text;
            obDPT_DepotMaster.IsSatellite = chkIsStatelite.Checked;
            if (chkIsStatelite.Checked == true)
            {
                obDPT_DepotMaster.ParentDepotId = int.Parse(ddlMainDepo.SelectedValue);
            }
            else {
                obDPT_DepotMaster.ParentDepotId = 0;
            
            }
            obDPT_DepotMaster.DepoTrno_I = 0;

            if (HiddenField1.Value != "")
            {
                obDPT_DepotMaster.DepoTrno_I = 1;
                obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(HiddenField1.Value);
            }
            obDPT_DepotMaster.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);
            HiddenField1.Value = "";
        }
        catch { }
        finally
        {
            obDPT_DepotMaster = null;
        }
        Response.Redirect("ViewDepot.aspx");

    }

    public void showdata(string ID)
    {
        try
        {
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Request.QueryString["ID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();

            txtDepotName.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DepoName_V"]);
            txtTelephone.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TeleNo_V"]);
            txtMobileNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["MobNo_V"]);
            txtDepotAddress.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DepoAddress_V"]);
            ddlDistrict.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["DistrictTrno_I"]);
           // txtFaxNo.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["FaxNo_V"]);
            txtEmailID.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Emailid_V"]);
            txtDepoManager.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["DepoManager_Name_V"]);
            if (obDataSet.Tables[0].Rows[0]["IsSatellite_I"].ToString() == "1")
            {
                chkIsStatelite.Checked = true;

            }
            else
            {
                chkIsStatelite.Checked = false;
            }
            ChkStateliteChange();
            ddlMainDepo.SelectedValue = obDataSet.Tables[0].Rows[0]["ParentDepotId_I"].ToString();
            obDPT_DepotMaster.DepoTrno_I = 1;
            HiddenField1.Value = (Request.QueryString["ID"]);

        }
        catch (Exception)
        {
        }
    }
}