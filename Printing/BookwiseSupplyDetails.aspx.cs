using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class Printing_BookwiseSupplyDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    MediumMaster obMediumMaster = null;
    PRI_PrinterRegistration obPRI_PrinterRegistration = new PRI_PrinterRegistration();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            ddlClassName.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM014_ClassMaster_Load(0)");
            ddlClassName.DataValueField = "ClassTrno_I";
            ddlClassName.DataTextField = "ClassDesc_V";
            ddlClassName.DataBind();
            ddlClassName.Items.Insert(0, new ListItem("All", "0"));

            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();

            DDlDepot.Items.Insert(0, new ListItem("All", "0"));
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "सलेक्ट करे ..");

            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlprinterName.DataSource = ds.Tables[0];
            ddlprinterName.DataValueField = "Printer_RedID_I";
            ddlprinterName.DataTextField = "NameofPressHindi_V";
            ddlprinterName.DataBind();
            ddlprinterName.Items.Insert(0, new ListItem("All", "0"));

            DataSet asdf = obCommonFuction.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));
            TextBox4.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            // fillgrd();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet fillgrd12 = obCommonFuction.FillDatasetByProc("call Prin_BookwiseSupplyDetails(" + DDlDepot.SelectedValue + "," + ddlClassName.SelectedValue + "," + ddlTital.SelectedValue + "," + ddlprinterName.SelectedValue + ",'" + DdlACYear.SelectedValue + "')");
        GrdGroupDetails.DataSource = fillgrd12.Tables[0];
        GrdGroupDetails.DataBind();
        if (GrdGroupDetails.Rows.Count > 0)
        {
            Button2.Visible = true;
        }
        else
        {
            Button2.Visible = false;
        }
        fillgrd();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < GrdGroupDetails.Rows.Count; i++)
        {
            string txtbhopalY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtbhopal")).Text.ToString();
            string txtbhopalS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtbhopal1")).Text.ToString();
            if (txtbhopalY == "")
            {
                txtbhopalY = "0";
            }
            else
            {
                txtbhopalY = txtbhopalY.ToString();
            }
            if (txtbhopalS == "")
            {
                txtbhopalS = "0";
            }
            else
            {
                txtbhopalS = txtbhopalS.ToString();
            }

            string txtindoreY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtindore")).Text.ToString();
            string txtindoreS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtindore1")).Text.ToString();
            if (txtindoreY == "")
            {
                txtindoreY = "0";
            }
            else
            {
                txtindoreY = txtindoreY.ToString();
            }
            if (txtindoreS == "")
            {
                txtindoreS = "0";
            }
            else
            {
                txtindoreS = txtindoreS.ToString();
            }

            string txtjabapurY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtjabapur")).Text.ToString();
            string txtjabapurS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtjabapur1")).Text.ToString();
            if (txtjabapurY == "")
            {
                txtjabapurY = "0";
            }
            else
            {
                txtjabapurY = txtjabapurY.ToString();
            }
            if (txtjabapurS == "")
            {
                txtjabapurS = "0";
            }
            else
            {
                txtjabapurS = txtjabapurS.ToString();
            }

            string txtKhandwaY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtKhandwa")).Text.ToString();
            string txtKhandwaS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtKhandwa1")).Text.ToString();
            if (txtKhandwaY == "")
            {
                txtKhandwaY = "0";
            }
            else
            {
                txtKhandwaY = txtKhandwaY.ToString();
            }
            if (txtKhandwaS == "")
            {
                txtKhandwaS = "0";
            }
            else
            {
                txtKhandwaS = txtKhandwaS.ToString();
            }
            string txtrewaY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtrewa")).Text.ToString();
            string txtrewaS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtrewa1")).Text.ToString();
            if (txtrewaY == "")
            {
                txtrewaY = "0";
            }
            else
            {
                txtrewaY = txtrewaY.ToString();
            }

            if (txtrewaS == "")
            {
                txtrewaS = "0";
            }
            else
            {
                txtrewaS = txtrewaS.ToString();
            }
            string txtGwalioreY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtGwaliore")).Text.ToString();
            string txtGwalioreS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtGwaliore1")).Text.ToString();
            if (txtGwalioreY == "")
            {
                txtGwalioreY = "0";
            }
            else
            {
                txtGwalioreY = txtGwalioreY.ToString();
            }
            if (txtGwalioreS == "")
            {
                txtGwalioreS = "0";
            }
            else
            {
                txtGwalioreS = txtGwalioreS.ToString();
            }
            string txtujjainY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtujjain")).Text.ToString();
            string txtujjainS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtujjain1")).Text.ToString();
            if (txtujjainY == "")
            {
                txtujjainY = "0";
            }
            else
            {
                txtujjainY = txtujjainY.ToString();
            }
            if (txtujjainS == "")
            {
                txtujjainS = "0";
            }
            else
            {
                txtujjainS = txtujjainS.ToString();
            }
            string txtSagarY = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtSagar")).Text.ToString();
            string txtSagarS = ((TextBox)GrdGroupDetails.Rows[i].FindControl("txtSagar1")).Text.ToString();

            if (txtSagarY == "")
            {
                txtSagarY = "0";
            }
            else
            {
                txtSagarY = txtSagarY.ToString();
            }
            if (txtSagarS == "")
            {
                txtSagarS = "0";
            }
            else
            {
                txtSagarS = txtSagarS.ToString();
            }
            //string tb3 = ((TextBox)GrdGroupDetails.Rows[i].FindControl("TextBox3")).Text.ToString();
            string printerID = ((HiddenField)GrdGroupDetails.Rows[i].FindControl("hdPrinter_RedID_I")).Value.ToString();
            string TitleID = ((HiddenField)GrdGroupDetails.Rows[i].FindControl("hdTitleID")).Value.ToString();
            string ClassID_I = ((HiddenField)GrdGroupDetails.Rows[i].FindControl("hdclasstrno_i")).Value.ToString();
            string DepoID ="0";

            obCommonFuction.FillDatasetByProc("call USP_PRI_BookSupplyDetails(0," + TitleID + "," + ClassID_I + "," + printerID + "," + DepoID + ",'" + Convert.ToDateTime(TextBox4.Text, cult).ToString("yyyy-MM-dd") + "'," + txtbhopalY + "," + txtbhopalS + ",'" + DdlACYear.SelectedValue + "',7," + txtindoreY + "," + txtindoreS + ",9," + txtujjainY + "," + txtujjainS + ",10," + txtGwalioreY + "," + txtGwalioreS + "," + txtKhandwaY + "," + txtKhandwaS + ",19," + txtrewaY + "," + txtrewaS + ",11,19,16,13," + txtjabapurY + "," + txtjabapurS + ",17," + txtSagarY + "," + txtSagarS + ")");
            //ID int,TitleIDA int, ClassIDA int, PrinterIDA int, DepoIDA int, DateRecA varchar(50),BhoAllotmentYA int, BhoAllotmentSA int , FyIDA varchar(100), BhopalIDA int, IndAllotmentYA int, IndAllotmentSA int, INdoreIDA int, UJJainAllotmentYA int , UjjainAllotmentSA int, UjjainIDA int, GwaAllotmentYA int, GwaAllotmentsA int, KhandAllotmentYA int, KhandAllotmentSA int, KhnadwaDepoIDA int, RewaAllotmentYA int, RewaAllotmentSA int, GwalioreIDA int, KhandwaIDA int, RewaIDA int, JabalPurIDA int, JablpurAllotmentYA int, JabalpurAllotmentSA int, SagarIDA int, SagarAllotmentYA int, SagarAllotmentSA int

        }
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
        GrdGroupDetails.DataSource = null;
        GrdGroupDetails.DataBind();
        Button2.Visible = false;
        ddlMedium.SelectedIndex = 0;
        fillgrd();

    }
    public void fillgrd()
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_PRI_BookSupplyDelete(0," + ddlprinterName.SelectedValue + "," + ddlClassName.SelectedValue + "," + ddlTital.SelectedValue + ",'" + Convert.ToDateTime(TextBox4.Text, cult).ToString("yyyy-MM-dd") + "')");
        GridView1.DataSource = dd.Tables[0];
        GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("call USP_PRI_BookSupplyDelete(" + GridView1.DataKeys[e.RowIndex].Value + ",0,0,0,0)");
        fillgrd();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        fillgrd();
    }
    protected void ddlClassName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("SELECT TitleHindi_V,TitleID_I FROM acd_titledetail  where classtrno_I=" + ddlClassName.SelectedValue + "");
        ddlTital.DataSource = dd.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));
        ddlMedium.SelectedIndex = 0;
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dd = obCommonFuction.FillDatasetByProc("SELECT TitleHindi_V,TitleID_I FROM acd_titledetail  where classtrno_I=" + ddlClassName.SelectedValue + " and Medium_I="+ddlMedium.SelectedValue+"");
        ddlTital.DataSource = dd.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));
    }
}