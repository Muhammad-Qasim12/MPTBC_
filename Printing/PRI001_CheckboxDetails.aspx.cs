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
using System.Data;
using System.Globalization;

public partial class Printing_PRI001_CheckboxDetails : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { Load(); }
    }


    protected void BtnBack_Click(object sender, EventArgs e)
    { Response.Redirect("PrinterRegDetails.aspx"); }


    public void Load()
    {

        if (Request.QueryString["PriId"] != null)
        {

            LoadChkList();

        }

        else { Response.Redirect("PrinterRegDetails.aspx"); }

    }


    // function to save Checklist tab 5
    public int SaveChecklist()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {


            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString());
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            if (Request.QueryString["ChkId"] != null)
            {
                obPRI_PrinterRegistration.RegChkLSTID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["ChkId"]).ToString());
            }
            else
            {
                obPRI_PrinterRegistration.RegChkLSTID_I = 0;
            }

           // obPRI_PrinterRegistration.RegChkLSTID_I = Convert.ToInt32(HdnRegChkLSTID_I.Value);

            obPRI_PrinterRegistration.RegAmount_I = chkRegAmount.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.PressActCert_I = chkPressActCert.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.IncometaxClearance_I = chkIncomeTaxClearance.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.LastThreeYrsPrinting_I = chkLastThreeYrsPrinting.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.MacPurchaseBillcopy_I = chkMacPurcBillCopy.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.Insurance_I = chkInsurance.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.Other_I = chkOther.Checked == true ? 1 : 0;

            if (chkOther.Checked == true)
            {
                obPRI_PrinterRegistration.OtherDet_V = txtOtherDet.Text;
            }
            else { obPRI_PrinterRegistration.OtherDet_V = ""; }
            obPRI_PrinterRegistration.ProcessCamera_I = chkProcessCamera.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.PlateMat_I = chkPlateMat.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.SingleColOffset_I = chkSingleCallOffset.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.BindingFacility_I = chkBindingFacility.Checked == true ? 1 : 0;
            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { Response.Redirect("PRI001_PrinterRegistration.aspx"); }
            else
            {
                i = obPRI_PrinterRegistration.PrinterRegistrationChkSaveUpdate();
            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;



    }

    // function to load checklist tab 5
    public void LoadChkList()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            if (Request.QueryString["ChkId"] != null)
            {
                obPRI_PrinterRegistration.RegChkLSTID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["ChkId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.RegChkLSTID_I = 0;
            }

            DataSet ds = new System.Data.DataSet();

            //obPRI_PrinterRegistration.RegChkLSTID_I = Convert.ToInt32(HdnRegChkLSTID_I.Value);

            ds = obPRI_PrinterRegistration.PrinterRegistrationChkLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {

                HdnRegChkLSTID_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["RegChkLSTID_I"]);

                chkRegAmount.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["RegAmount_I"]) == 1 ? true : false;
                chkPressActCert.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["PressActCert_I"]) == 1 ? true : false;
                chkIncomeTaxClearance.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["IncometaxClearance_I"]) == 1 ? true : false;
                chkLastThreeYrsPrinting.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["LastThreeYrsPrinting_I"]) == 1 ? true : false;
                chkMacPurcBillCopy.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["MacPurchaseBillcopy_I"]) == 1 ? true : false;
                chkInsurance.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["Insurance_I"]) == 1 ? true : false;
                chkOther.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["Other_I"]) == 1 ? true : false;
                txtOtherDet.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherDet_V"]);

                if (Convert.ToInt32(ds.Tables[0].Rows[0]["IsOffsetReg_I"]) == 1)
                {

                    chkProcessCamera.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["ProcessCamera_I"]) == 1 ? true : false;
                    chkPlateMat.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["PlateMat_I"]) == 1 ? true : false;
                    chkSingleCallOffset.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["SingleColOffset_I"]) == 1 ? true : false;
                    chkBindingFacility.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["BindingFacility_I"]) == 1 ? true : false;

                }
                else
                {
                    pnlChkWithOffset.Visible = false;


                }
                


                if (Convert.ToInt32(ds.Tables[0].Rows[0]["Other_I"]) == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('Divtxt').style.display='block'; </script>");

                }

            }

        }
        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    // save checklist tab
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = SaveChecklist();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved Successfully ..');</script>");

            HdnRegChkLSTID_I.Value = i.ToString();

            Response.Redirect("PrinterRegDetails.aspx");

        }

        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }

    }





}