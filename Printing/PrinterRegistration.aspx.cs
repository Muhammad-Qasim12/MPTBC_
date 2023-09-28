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

public partial class Printing_PrinterRegistration : System.Web.UI.Page
{

    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure objApi = new APIProcedure();
    public static string FilePath = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Opentab();
            LoadMachineDesDDl();
        }
    }

    // function to open all tab details 
    public void Opentab()
    {

        if (Request.QueryString["Cid"] != null)
        {
            hdnPrinter_RedID_I.Value = Convert.ToString(Request.QueryString["Cid"]);
            load();
            LoadMachineDetails();
            LoadMachineDescription();
            LoadBindingDetails();
            OtherDetailsLoad();
            LoadChkList();
            
        }



    }


    // load first tab data 

    public void load()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }
            DataSet ds = new System.Data.DataSet();
            ds = obPRI_PrinterRegistration.PrinterRegistrationLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnPrinter_RedID_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                txtRegno_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Regno_I"]);
                ddlGrade_V.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Grade_V"]);
                txtNameofPress_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameofPress_V"]);
                txtFullAddress_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["FullAddress_V"]);
                txtHeadoffice_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Headoffice_V"]);
                txtBOTelegraph_Add_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["BOTelegraph_Add_V"]);
                txtEst_Date_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["Est_Date_D"]);
                txtAreaOccupies_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["AreaOccupies_N"]);
                radioAreaType_I.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["AreaType_I"]);
                txtFacRegNo_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["FacRegNo_V"]);
                radioReginComact_I.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ReginComact_I"]);
                txtRegDet_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegDet_V"]);
                txtNoofProc_OP_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofProc_OP_I"]);
                txtNoofComp_OP_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofComp_OP_I"]);
                txtNoofPrint_OP_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofPrint_OP_I"]);
                txtNoofBind_OP_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofBind_OP_I"]);
                txtNoofMisc_OP_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofMisc_OP_I"]);
                txtNoofTotal_OP_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofTotal_OP_I"]);
                txtNoofProc_Su_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofProc_Su_I"]);
                txtNoofComp_Su_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofComp_Su_I"]);
                txtNoofPrint_Su_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofPrint_Su_I"]);
                txtNoofBind_Su_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofBind_Su_I"]);
                txtNoofMisc_Su_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofMisc_Su_I"]);
                txtNoofTotal_Su_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofTotal_Su_I"]);
                txtNoofProofreader_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoofProofreader_I"]);
                lblProfreadpath_v.Text = Convert.ToString(ds.Tables[0].Rows[0]["Profreadpath_v"]);

                txtRegDate_D.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegDate_D"]);

                txtRegforYear_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegforYear_I"]);
                txtRegamount_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["Regamount_N"]);
                txtRegDetails_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegDetails_V"]);
                txtOwnerDeail_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerDeail_V"]);

                if (txtRegforYear_I.Text != "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('DivIsOffReg').style.display='block';</script>");

                    chkIsOffsetReg_I.Checked = true;
                }



            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }

    // fill dropdown of tab 2

    public void LoadMachineDesDDl()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {

            obPRI_PrinterRegistration.MachineID_I = 0;

            ddlMachineDescription.DataTextField = "MachineDescription";
            ddlMachineDescription.DataValueField = "MachineID_I";
            ddlMachineDescription.DataSource = obPRI_PrinterRegistration.MachineDesLoad();
            ddlMachineDescription.DataBind();

            ddlMachineDescription.Items.Insert(0, new ListItem("Select", "0"));
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }


    // save printer details 1st tab
    public int SavePrinterDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
            //obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.Regno_I = Convert.ToString(txtRegno_I.Text);
            obPRI_PrinterRegistration.Grade_V = Convert.ToString(ddlGrade_V.SelectedValue);
            obPRI_PrinterRegistration.NameofPress_V = Convert.ToString(txtNameofPress_V.Text);
            obPRI_PrinterRegistration.FullAddress_V = Convert.ToString(txtFullAddress_V.Text);
            obPRI_PrinterRegistration.Headoffice_V = Convert.ToString(txtHeadoffice_V.Text);
            obPRI_PrinterRegistration.BOTelegraph_Add_V = Convert.ToString(txtBOTelegraph_Add_V.Text);
            obPRI_PrinterRegistration.Est_Date_D = Convert.ToDateTime(txtEst_Date_D.Text, cult);
            obPRI_PrinterRegistration.AreaOccupies_N = Convert.ToDouble(txtAreaOccupies_N.Text);

            obPRI_PrinterRegistration.AreaType_I = Convert.ToInt32(radioAreaType_I.SelectedValue);

            obPRI_PrinterRegistration.FacRegNo_V = Convert.ToString(txtFacRegNo_V.Text);
            obPRI_PrinterRegistration.ReginComact_I = Convert.ToInt32(radioReginComact_I.SelectedValue);
            obPRI_PrinterRegistration.RegDet_V = Convert.ToString(txtRegDet_V.Text);
            obPRI_PrinterRegistration.NoofProc_OP_I = Convert.ToInt32(txtNoofProc_OP_I.Text);
            obPRI_PrinterRegistration.NoofComp_OP_I = Convert.ToInt32(txtNoofComp_OP_I.Text);
            obPRI_PrinterRegistration.NoofPrint_OP_I = Convert.ToInt32(txtNoofPrint_OP_I.Text);
            obPRI_PrinterRegistration.NoofBind_OP_I = Convert.ToInt32(txtNoofBind_OP_I.Text);
            obPRI_PrinterRegistration.NoofMisc_OP_I = Convert.ToInt32(txtNoofMisc_OP_I.Text);
            obPRI_PrinterRegistration.NoofTotal_OP_I = Convert.ToInt32(txtNoofTotal_OP_I.Text);
            obPRI_PrinterRegistration.NoofProc_Su_I = Convert.ToInt32(txtNoofProc_Su_I.Text);
            obPRI_PrinterRegistration.NoofComp_Su_I = Convert.ToInt32(txtNoofComp_Su_I.Text);
            obPRI_PrinterRegistration.NoofPrint_Su_I = Convert.ToInt32(txtNoofPrint_Su_I.Text);
            obPRI_PrinterRegistration.NoofBind_Su_I = Convert.ToInt32(txtNoofBind_Su_I.Text);
            obPRI_PrinterRegistration.NoofMisc_Su_I = Convert.ToInt32(txtNoofMisc_Su_I.Text);
            obPRI_PrinterRegistration.NoofTotal_Su_I = Convert.ToInt32(txtNoofTotal_Su_I.Text);
            obPRI_PrinterRegistration.NoofProofreader_I = Convert.ToInt32(txtNoofProofreader_I.Text);

            if (fileProfreadpath_v.HasFile)
            {
                fileProfreadpath_v.SaveAs(Server.MapPath("PrintingFile/" + txtNameofPress_V.Text + fileProfreadpath_v.FileName));

                lblProfreadpath_v.Text = "PrintingFile/" + txtNameofPress_V.Text.Replace(" ", "").ToString() + fileProfreadpath_v.FileName;

                obPRI_PrinterRegistration.Profreadpath_v = lblProfreadpath_v.Text;
            }




            obPRI_PrinterRegistration.Isactive_I = 1;

            obPRI_PrinterRegistration.IsOffsetReg_I = chkIsOffsetReg_I.Checked == true ? 1 : 0;

            obPRI_PrinterRegistration.RegDate_D = Convert.ToDateTime(txtRegDate_D.Text, cult);
            obPRI_PrinterRegistration.RegforYear_I = Convert.ToInt32(txtRegforYear_I.Text);
            obPRI_PrinterRegistration.Regamount_N = Convert.ToDouble(txtRegamount_N.Text);
            obPRI_PrinterRegistration.RegDetails_V = Convert.ToString(txtRegDetails_V.Text);
            obPRI_PrinterRegistration.OwnerDeail_V = Convert.ToString(txtOwnerDeail_V.Text);

            i = obPRI_PrinterRegistration.InsertUpdate();

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet ds = obCommonFuction.FillDatasetByProc("call GetPrinterRegStatus(" + i + ")");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string xml = "<DocumentElement><AgencyColumn><AGENCYTYPECOLUMNID>00836</AGENCYTYPECOLUMNID><COLUMNVALUE>00001</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>00837</AGENCYTYPECOLUMNID><COLUMNVALUE>85C61553-38C1-4A63-AB78-C647DBC22937</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01721</AGENCYTYPECOLUMNID><COLUMNVALUE>1</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01722</AGENCYTYPECOLUMNID><COLUMNVALUE>AENMP1234F</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01723</AGENCYTYPECOLUMNID><COLUMNVALUE>TAN</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01724</AGENCYTYPECOLUMNID><COLUMNVALUE>470339</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01725</AGENCYTYPECOLUMNID><COLUMNVALUE>7566845855</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01726</AGENCYTYPECOLUMNID><COLUMNVALUE>Service tax no</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01727</AGENCYTYPECOLUMNID><COLUMNVALUE>IFSC</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01730</AGENCYTYPECOLUMNID><COLUMNVALUE>Office Building</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01731</AGENCYTYPECOLUMNID><COLUMNVALUE>BOI</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01732</AGENCYTYPECOLUMNID><COLUMNVALUE>Bhopal</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01733</AGENCYTYPECOLUMNID><COLUMNVALUE>989898989898989898</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01734</AGENCYTYPECOLUMNID><COLUMNVALUE>Office Address</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01775</AGENCYTYPECOLUMNID><COLUMNVALUE>Prince</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01801</AGENCYTYPECOLUMNID><COLUMNVALUE>प्रिंस </COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01939</AGENCYTYPECOLUMNID><COLUMNVALUE>jain</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01940</AGENCYTYPECOLUMNID><COLUMNVALUE>kumar</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01941</AGENCYTYPECOLUMNID><COLUMNVALUE>जन </COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01942</AGENCYTYPECOLUMNID><COLUMNVALUE>कुमार </COLUMNVALUE></AgencyColumn></DocumentElement>";
                string newGuid = Guid.NewGuid().ToString();


                obCommonFuction.FillDatasetByProc("call HR_PrinterRegistration('" + newGuid + "'," + i + ")");
                //YojnaTBC.YF_WebServiceSoapClient oYF_WebService = new YojnaTBC.YF_WebServiceSoapClient();
                Yojnaservice.YF_WebService oYF_WebService = new Yojnaservice.YF_WebService();
                oYF_WebService.SaveNewAgency("00014", newGuid, txtNameofPress_V.Text, null, xml);
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);

            }

        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;
    }



    protected void BtnPrinterRegistration_Click(object sender, EventArgs e)
    {
        try
        {
            int i = SavePrinterDetails();

            if (i > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved Successfully ..');</script>");
                hdnPrinter_RedID_I.Value = i.ToString();



                TabPrinter.ActiveTabIndex = 1;



            }
            else
            { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); TabPrinter.ActiveTabIndex = 0; }

        }
        catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert(" + ex.Message + ");</script>"); }
    }


    // function to save Checklist tab 5
    public int SaveChecklist()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
          

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.RegChkLSTID_I = Convert.ToInt32(HdnRegChkLSTID_I.Value);

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

            obPRI_PrinterRegistration.ProcessCamera_I = chkProcessCamera.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.PlateMat_I = chkPlateMat.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.SingleColOffset_I = chkSingleCallOffset.Checked == true ? 1 : 0;
            obPRI_PrinterRegistration.BindingFacility_I = chkBindingFacility.Checked == true ? 1 : 0;
            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { TabPrinter.ActiveTabIndex = 0; }
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
            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }
            DataSet ds = new System.Data.DataSet();

            obPRI_PrinterRegistration.RegChkLSTID_I = Convert.ToInt32(HdnRegChkLSTID_I.Value);

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
                chkProcessCamera.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["ProcessCamera_I"]) == 1 ? true : false;
                chkPlateMat.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["PlateMat_I"]) == 1 ? true : false;
                chkSingleCallOffset.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["SingleColOffset_I"]) == 1 ? true : false;
                chkBindingFacility.Checked = Convert.ToInt32(ds.Tables[0].Rows[0]["BindingFacility_I"]) == 1 ? true : false;

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

        }

        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }

    }


    // for save 12- 15 
    public int SaveMachineDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
            obPRI_PrinterRegistration.PriMacDesID_I = Convert.ToInt32(HdnPriMacDesID_I.Value);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.Composing_Monotype_V = txtComposing_Monotype_V.Text;
            obPRI_PrinterRegistration.Composing_Linotype_V = txtComposing_Linotype_V.Text;
            obPRI_PrinterRegistration.ComposAnyOthtype_V = txtComposAnyOthtype_V.Text;

            if (FileFoundaryTyAtt_V.HasFile)
            {
                FileFoundaryTyAtt_V.SaveAs(Server.MapPath("PrintingFile/" + "FoundryTypeInStock" + FileFoundaryTyAtt_V.FileName));

                lblFoundaryTyAtt_V.Text = "PrintingFile/" + "FoundryTypeInStock" + FileFoundaryTyAtt_V.FileName;

                obPRI_PrinterRegistration.FoundaryTyAtt_V = lblFoundaryTyAtt_V.Text;
            }

            //obPRI_PrinterRegistration.FoundaryTyAtt_V			=FileFoundaryTyAtt_V

            obPRI_PrinterRegistration.ComposingCapL1_V = txtComposingCapL1_V.Text;
            obPRI_PrinterRegistration.ComposingCapP1_I = Convert.ToInt32(txtComposingCapP1_I.Text);
            obPRI_PrinterRegistration.ComposingCapL2_V = txtComposingCapL2_V.Text;
            obPRI_PrinterRegistration.ComposingCapP2_I = Convert.ToInt32(txtComposingCapP2_I.Text);
            obPRI_PrinterRegistration.ComposingCapL3_V = txtComposingCapL3_V.Text;
            obPRI_PrinterRegistration.ComposingCapP3_I = Convert.ToInt32(txtComposingCapP3_I.Text);

            if (FileLanguagesTxtSetAttach_V.HasFile)
            {
                FileFoundaryTyAtt_V.SaveAs(Server.MapPath("PrintingFile/" + "LanguagesInWhichTextbook" + FileLanguagesTxtSetAttach_V.FileName));

                lblLanguagesTxtSetAttach_V.Text = "PrintingFile/" + "LanguagesInWhichTextbook" + FileLanguagesTxtSetAttach_V.FileName;

                obPRI_PrinterRegistration.LanguagesTxtSetAttach_V = lblLanguagesTxtSetAttach_V.Text;
            }


            //obPRI_PrinterRegistration.LanguagesTxtSetAttach_V=  = FilemLanguagesTxtSetAttach_V

            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { TabPrinter.ActiveTabIndex = 0; }
            else
            {
                i = obPRI_PrinterRegistration.PrinterMachineDetailsSaveUpdate();
            }

        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;


    }


    // for save 16

    public int SaveMachineDescription()
    {

        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;

        try
        {
           
            obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(HdnPriMacID_I.Value);
            obPRI_PrinterRegistration.MachineID_I = Convert.ToInt32(ddlMachineDescription.SelectedValue);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.Make_V = txtMake_V.Text;
            obPRI_PrinterRegistration.Year_I = Convert.ToInt32(txtYear_I.Text);

            if (filemFoundaryTyAtt_V.HasFile)
            {
                filemFoundaryTyAtt_V.SaveAs(Server.MapPath("PrintingFile/" + "PrintingMachines" + filemFoundaryTyAtt_V.FileName));

                lblmFoundaryTyAtt_V.Text = "PrintingFile/" + "PrintingMachines" + filemFoundaryTyAtt_V.FileName;

                obPRI_PrinterRegistration.FoundaryTyAtt_V = lblmFoundaryTyAtt_V.Text;
            }

            obPRI_PrinterRegistration.FoundaryTyAtt_V = lblFoundaryTyAtt_V.Text;

            obPRI_PrinterRegistration.nOOFmACHINE = Convert.ToInt32(txtnOOFmACHINE.Text);
            obPRI_PrinterRegistration.pRINcAPASITY_v = txtpRINcAPASITY_v.Text;
            obPRI_PrinterRegistration.DateOfInstallation_D = Convert.ToDateTime(txtDateOfInstallation_D.Text, cult);



            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { TabPrinter.ActiveTabIndex = 0; }
            else
            {
                
                i = obPRI_PrinterRegistration.PrinterMachineListSaveUpdate();

             
            }

        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;

    }



    //  for load machine details like mono type ,leno ,other

    public void LoadMachineDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        DataSet ds = new System.Data.DataSet();
        try
        {
            obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(HdnPriMacDesID_I.Value);
            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            ds = obPRI_PrinterRegistration.PrinterMachineDescriptionLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {
                HdnPriMacDesID_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["PriMacID_I"]);

                txtComposing_Monotype_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Composing_Monotype_V"]);
                txtComposing_Linotype_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Composing_Linotype_V"]);
                txtComposAnyOthtype_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposAnyOthtype_V"]);
                lblFoundaryTyAtt_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["FoundaryTyAtt_V"]);
                txtComposingCapL1_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapL1_V"]);
                txtComposingCapP1_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapP1_I"]);
                txtComposingCapL2_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapL2_V"]);
                txtComposingCapP2_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapP2_I"]);
                txtComposingCapL3_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapL3_V"]);
                txtComposingCapP3_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ComposingCapP3_I"]);
                lblLanguagesTxtSetAttach_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["LanguagesTxtSetAttach_V"]);

            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }




    // function to load Machin list grid tab 2
    public void LoadMachineDescription()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            obPRI_PrinterRegistration.PriMacID_I = Convert.ToInt32(HdnPriMacID_I.Value);
            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            grdMachineDetails.DataSource = obPRI_PrinterRegistration.PrinterMachineListLoad();
            grdMachineDetails.DataBind();
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }




    // for select data from gridview
    protected void grdMachineDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        HdnPriMacID_I.Value = ((HiddenField)grdMachineDetails.Rows[e.RowIndex].FindControl("HdnPriMacID_I")).Value;
        //HdnPriMacID_I.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblPriMacID_I")).Text;

        ddlMachineDescription.SelectedValue = ((HiddenField)grdMachineDetails.Rows[e.RowIndex].FindControl("HdnmMachineID_I")).Value;


        txtMake_V.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblMake_V")).Text;
        txtYear_I.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblYear_I")).Text;
        txtDateOfInstallation_D.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblDateOfInstallation_D")).Text;
        txtnOOFmACHINE.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblnOOFmACHINE")).Text;
        txtpRINcAPASITY_v.Text = ((Label)grdMachineDetails.Rows[e.RowIndex].FindControl("lblpRINcAPASITY_v")).Text;

        TabPrinter.ActiveTabIndex = 1;
    }

    //  button of 12-15 save
    
    protected void btnMachineDesSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = SaveMachineDetails();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved Successfully ..');</script>");
            HdnPriMacDesID_I.Value = i.ToString();
            LoadMachineDescription();
            btnMachineDesSave.Enabled = true;
            TabPrinter.ActiveTabIndex = 2;
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }

    }


    
    // button of 16 save
    protected void btnMachineDetailsave_Click(object sender, EventArgs e)
    {
       
        int i = 0;
        i = SaveMachineDescription();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved Successfully ..');</script>");
            HdnPriMacDesID_I.Value = i.ToString();
            ddlMachineDescription.SelectedValue = "0";
            HdnPriMacID_I.Value = "0";
            txtMake_V.Text = "";
            txtYear_I.Text = "";
            txtDateOfInstallation_D.Text = "";
            txtnOOFmACHINE.Text = "";
            txtpRINcAPASITY_v.Text = "";

            LoadMachineDescription();
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }
    }



    // for save Binding Tab

    protected void BtnBindingSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = SaveBindingDetails();
        if (i> 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved Successfully ..');</script>");
            hdnPriBindID_I.Value = i.ToString();
            TabPrinter.ActiveTabIndex = 3;

        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }

    }


    // function to save Bindind Tab 4

    public int SaveBindingDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
            obPRI_PrinterRegistration.PriBindID_I = Convert.ToInt32(hdnPriBindID_I.Value);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.Mac_FoldingMake_V = Convert.ToString(txtMac_FoldingMake_V.Text);
            obPRI_PrinterRegistration.Mac_FoldingSize_V = Convert.ToString(txtMac_FoldingSize_V.Text);
            obPRI_PrinterRegistration.Mac_FoldingNos_I = Convert.ToInt32(txtMac_FoldingNos_I.Text);
            obPRI_PrinterRegistration.Mac_FoldingOwned_V = Convert.ToString(txtMac_FoldingOwned_V.Text);
            obPRI_PrinterRegistration.Mac_StichgMake_V = Convert.ToString(txtMac_StichgMake_V.Text);
            obPRI_PrinterRegistration.Mac_StichgSize_V = Convert.ToString(txtMac_StichgSize_V.Text);
            obPRI_PrinterRegistration.Mac_StichgNos_I = Convert.ToInt32(txtMac_StichgNos_I.Text);
            obPRI_PrinterRegistration.Mac_StichgOwned_V = Convert.ToString(txtMac_StichgOwned_V.Text);
            obPRI_PrinterRegistration.Mac_CutMake_V = Convert.ToString(txtMac_CutMake_V.Text);
            obPRI_PrinterRegistration.Mac_CutSize_V = Convert.ToString(txtMac_CutSize_V.Text);
            obPRI_PrinterRegistration.Mac_CutNos_I = Convert.ToInt32(txtMac_CutNos_I.Text);
            obPRI_PrinterRegistration.Mac_CutOwned_V = Convert.ToString(txtMac_CutOwned_V.Text);
            obPRI_PrinterRegistration.Mac_othMake_V = Convert.ToString(txtMac_othMake_V.Text);
            obPRI_PrinterRegistration.Mac_othSize_V = Convert.ToString(txtMac_othSize_V.Text);
            obPRI_PrinterRegistration.Mac_othNos_I = Convert.ToInt32(txtMac_othNos_I.Text);
            obPRI_PrinterRegistration.Mac_othOwned_V = Convert.ToString(txtMac_othOwned_V.Text);
            obPRI_PrinterRegistration.Bookname_V = Convert.ToString(txtBookname_V.Text);
            obPRI_PrinterRegistration.Book1BindCapNo_I = Convert.ToInt32(txtBook1BindCapNo_I.Text);
            obPRI_PrinterRegistration.Bookname1_V = Convert.ToString(txtBookname1_V.Text);
            obPRI_PrinterRegistration.Book2BindCapNo_I = Convert.ToInt32(txtBook2BindCapNo_I.Text);
            obPRI_PrinterRegistration.Bookname2_V = Convert.ToString(txtBookname2_V.Text);
            obPRI_PrinterRegistration.BookBindCapNo_I = Convert.ToInt32(txtBookBindCapNo_I.Text);
            obPRI_PrinterRegistration.OffsetCameraSize_V = Convert.ToString(txtOffsetCameraSize_V.Text);
            obPRI_PrinterRegistration.OffsetCameraMake_V = Convert.ToString(txtOffsetCameraMake_V.Text);
            obPRI_PrinterRegistration.OffsetWhirlarSize_V = Convert.ToString(txtOffsetWhirlarSize_V.Text);
            obPRI_PrinterRegistration.OffsetWhirlarMake_V = Convert.ToString(txtOffsetWhirlarMake_V.Text);
            obPRI_PrinterRegistration.OffsetOthSize_V = Convert.ToString(txtOffsetOthSize_V.Text);
            obPRI_PrinterRegistration.OffsetOthMake_V = Convert.ToString(txtOffsetOthMake_V.Text);
            obPRI_PrinterRegistration.OffsetConCabSize_V = Convert.ToString(txtOffsetConCabSize_V.Text);
            obPRI_PrinterRegistration.OffsetConCabMake_V = Convert.ToString(txtOffsetConCabMake_V.Text);

            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { TabPrinter.ActiveTabIndex = 0; }
            else
            {
                i = obPRI_PrinterRegistration.BindingDetailsSaveUpdate();
            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

        return i;

    }


    // function to load binding details tab 4
    public void LoadBindingDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();

        DataSet ds = new System.Data.DataSet();

        try
        {
            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }
            obPRI_PrinterRegistration.PriBindID_I = Convert.ToInt32(hdnPriBindID_I.Value);

            ds = obPRI_PrinterRegistration.BindingDetailsLoad();
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnPriBindID_I.Value = Convert.ToString(ds.Tables[0].Rows[0]["PriBindID_I"]);

                txtMac_FoldingMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_FoldingMake_V"]);
                txtMac_FoldingSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_FoldingSize_V"]);
                txtMac_FoldingNos_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_FoldingNos_I"]);
                txtMac_FoldingOwned_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_FoldingOwned_V"]);
                txtMac_StichgMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_StichgMake_V"]);
                txtMac_StichgSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_StichgSize_V"]);
                txtMac_StichgNos_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_StichgNos_I"]);
                txtMac_StichgOwned_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_StichgOwned_V"]);
                txtMac_CutMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_CutMake_V"]);
                txtMac_CutSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_CutSize_V"]);
                txtMac_CutNos_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_CutNos_I"]);
                txtMac_CutOwned_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_CutOwned_V"]);
                txtMac_othMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_othMake_V"]);
                txtMac_othSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_othSize_V"]);
                txtMac_othNos_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_othNos_I"]);
                txtMac_othOwned_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Mac_othOwned_V"]);
                txtBookname_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookname_V"]);
                txtBook1BindCapNo_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Book1BindCapNo_I"]);
                txtBookname1_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookname1_V"]);
                txtBook2BindCapNo_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Book2BindCapNo_I"]);
                txtBookname2_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookname2_V"]);
                txtBookBindCapNo_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookBindCapNo_I"]);
                txtOffsetCameraSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetCameraSize_V"]);
                txtOffsetCameraMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetCameraMake_V"]);
                txtOffsetWhirlarSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetWhirlarSize_V"]);
                txtOffsetWhirlarMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetWhirlarMake_V"]);
                txtOffsetOthSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetOthSize_V"]);
                txtOffsetOthMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetOthMake_V"]);
                txtOffsetConCabSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetConCabSize_V"]);
                txtOffsetConCabMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetConCabMake_V"]);


            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }


    // function to save other details tab 4

    public int OtherDetailsSaveUpdate()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
            obPRI_PrinterRegistration.RegOthID = Convert.ToInt32(hdnRegOthID.Value);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.Noofshift_V = Convert.ToString(txtNoofshift_V.Text);
            obPRI_PrinterRegistration.BookPrintExperience_V = Convert.ToString(txtBookPrintExperience_V.Text);
            obPRI_PrinterRegistration.NOofTitle_TBCPrint_I = Convert.ToInt32(txtNOofTitle_TBCPrint_I.Text);
            obPRI_PrinterRegistration.NOofTitle_OThTBCPrint_I = Convert.ToInt32(txtNOofTitle_OThTBCPrint_I.Text);
            obPRI_PrinterRegistration.NOofTitle_OThPrint_I = Convert.ToInt32(txtNOofTitle_OThPrint_I.Text);
            obPRI_PrinterRegistration.WareHouseDet_V = Convert.ToString(txtWareHouseDet_V.Text);
            obPRI_PrinterRegistration.Premises_GoodIns_V = Convert.ToString(txtPremises_GoodIns_V.Text);
            obPRI_PrinterRegistration.Ins_CoverDetail_V = Convert.ToString(txtIns_CoverDetail_V.Text);
            obPRI_PrinterRegistration.Nameaddbanker_v = Convert.ToString(txtNameaddbanker_v.Text);
            obPRI_PrinterRegistration.ApprovContractor_I = Convert.ToInt32(txtApprovContractor_I.Text);
            obPRI_PrinterRegistration.AnyOthDetails_V = Convert.ToString(txtAnyOthDetails_V.Text);
            obPRI_PrinterRegistration.IncometaxPay = Convert.ToInt32(txtIncometaxPay.Text);
            obPRI_PrinterRegistration.UserID_I = Session["UserID_I"] != null ? Convert.ToInt32(Session["UserID_I"]) : 0;
            obPRI_PrinterRegistration.NOofTitle_MPTBCPrint_I = Convert.ToInt32(NOofTitle_MPTBCPrint_I.Text);
            obPRI_PrinterRegistration.Last3YearQuantity_I = Convert.ToInt32(Last3YearQuantity_I.Text);

            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { TabPrinter.ActiveTabIndex = 0; }
            else
            {
                i = obPRI_PrinterRegistration.OtherDetailsSave();
            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
        return i;

    }


    // load other tab 4
    public void OtherDetailsLoad()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        DataSet ds = new System.Data.DataSet();
        try
        {
            obPRI_PrinterRegistration.RegOthID = Convert.ToInt32(hdnRegOthID.Value);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            ds = obPRI_PrinterRegistration.OtherDetailsLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnRegOthID.Value = Convert.ToString(ds.Tables[0].Rows[0]["RegOthID"]);

                txtNoofshift_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Noofshift_V"]);
                txtBookPrintExperience_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookPrintExperience_V"]);
                txtNOofTitle_TBCPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_TBCPrint_I"]);
                txtNOofTitle_OThTBCPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_OThTBCPrint_I"]);
                txtNOofTitle_OThPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_OThPrint_I"]);
                txtWareHouseDet_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["WareHouseDet_V"]);
                txtPremises_GoodIns_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Premises_GoodIns_V"]);
                txtIns_CoverDetail_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ins_CoverDetail_V"]);
                txtNameaddbanker_v.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameaddbanker_v"]);
                txtApprovContractor_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["ApprovContractor_I"]);
                txtAnyOthDetails_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnyOthDetails_V"]);
                txtIncometaxPay.Text = Convert.ToString(ds.Tables[0].Rows[0]["IncometaxPay"]);

                NOofTitle_MPTBCPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_MPTBCPrint_I"]);
                Last3YearQuantity_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Last3YearQuantity_I"]);
            }

        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
      
    }

    // save other details

    protected void btnOtherDetailsSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = OtherDetailsSaveUpdate();
        if (i > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Details Saved Successfully ..');</script>");
            hdnRegOthID.Value = i.ToString();
            TabPrinter.ActiveTabIndex = 4;
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }


    }




}




