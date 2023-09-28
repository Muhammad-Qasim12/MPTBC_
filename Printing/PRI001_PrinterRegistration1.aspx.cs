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
using System.IO;

public partial class Printing_PRI001_PrinterRegistration : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

     APIProcedure objApi = new APIProcedure();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["Cid"] != null)
            {
                load();
            }

           
        }

    }


    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("View001_PrinterRegDetails.aspx", true);
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
                //DateTime dte = new DateTime();
                //dte = DateTime.Parse(ds.Tables[0].Rows[0]["RegDate_D"].ToString());
                //txtRegDate_D.Text = dte.ToString("dd/MM/yyyy");

                txtRegforYear_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegforYear_I"]);
                txtRegamount_N.Text = Convert.ToString(ds.Tables[0].Rows[0]["Regamount_N"]);
                txtRegDetails_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegDetails_V"]);
                txtOwnerDeail_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OwnerDeail_V"]);
                

                ddlPayMode.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["PayMode_V"]);
                txtBankName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["BankName_V"]);
                txtDate.Text = Convert.ToString(ds.Tables[0].Rows[0]["RegistrationDate"]);

               
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('DivIsOffReg').style.display='block';</script>");

                    chkIsOffsetReg_I.Checked = Convert.ToString(ds.Tables[0].Rows[0]["IsOffsetReg_I"]) == "1" ? true : false;
                

                if (ddlPayMode.SelectedValue == "Cash")
                {
                    Panel1.Visible = false; 
                    //txtBankName_V.Enabled = false;
                    //txtRegDetails_V.Enabled = false;
                    //txtDate.Enabled = false;

                }
                else
                {
                    Panel1.Visible = true; 
                    //txtBankName_V.Enabled = true;
                    //txtRegDetails_V.Enabled = true;
                    //txtDate.Enabled = true;
                }


            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }



   
      

       

  
    

    // save printer details 1st tab
    public int SavePrinterDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;

        //try
        //{
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
            obPRI_PrinterRegistration.NoofProc_OP_I = txtNoofProc_OP_I.Text != "" ? Convert.ToInt32(txtNoofProc_OP_I.Text) : 0;
            obPRI_PrinterRegistration.NoofComp_OP_I = txtNoofComp_OP_I.Text != "" ? Convert.ToInt32(txtNoofComp_OP_I.Text) : 0;
            obPRI_PrinterRegistration.NoofPrint_OP_I = txtNoofPrint_OP_I.Text != "" ? Convert.ToInt32(txtNoofPrint_OP_I.Text) : 0;
            obPRI_PrinterRegistration.NoofBind_OP_I = txtNoofBind_OP_I.Text != "" ? Convert.ToInt32(txtNoofBind_OP_I.Text) : 0;
            obPRI_PrinterRegistration.NoofMisc_OP_I = txtNoofMisc_OP_I.Text != "" ? Convert.ToInt32(txtNoofMisc_OP_I.Text) : 0;
            obPRI_PrinterRegistration.NoofTotal_OP_I = txtNoofTotal_OP_I.Text != "" ? Convert.ToInt32(txtNoofTotal_OP_I.Text) : 0;
            obPRI_PrinterRegistration.NoofProc_Su_I = txtNoofProc_Su_I.Text != "" ? Convert.ToInt32(txtNoofProc_Su_I.Text) : 0;
            obPRI_PrinterRegistration.NoofComp_Su_I = txtNoofComp_Su_I.Text != "" ? Convert.ToInt32(txtNoofComp_Su_I.Text) : 0;
            obPRI_PrinterRegistration.NoofPrint_Su_I = txtNoofPrint_Su_I.Text != "" ? Convert.ToInt32(txtNoofPrint_Su_I.Text) : 0;
            obPRI_PrinterRegistration.NoofBind_Su_I = txtNoofBind_Su_I.Text != "" ? Convert.ToInt32(txtNoofBind_Su_I.Text) : 0;
            obPRI_PrinterRegistration.NoofMisc_Su_I = txtNoofMisc_Su_I.Text != "" ? Convert.ToInt32(txtNoofMisc_Su_I.Text) : 0;
            obPRI_PrinterRegistration.NoofTotal_Su_I = txtNoofTotal_Su_I.Text != "" ? Convert.ToInt32(txtNoofTotal_Su_I.Text) : 0;
            obPRI_PrinterRegistration.NoofProofreader_I = txtNoofProofreader_I.Text != "" ? Convert.ToInt32(txtNoofProofreader_I.Text) : 0;





            obPRI_PrinterRegistration.Isactive_I = 1;

            obPRI_PrinterRegistration.IsOffsetReg_I = chkIsOffsetReg_I.Checked == true ? 1 : 0;

            obPRI_PrinterRegistration.RegDate_D = Convert.ToDateTime(txtRegDate_D.Text, cult);
            obPRI_PrinterRegistration.RegforYear_I = Convert.ToInt32(txtRegforYear_I.Text);
            obPRI_PrinterRegistration.Regamount_N = Convert.ToDouble(txtRegamount_N.Text);
            obPRI_PrinterRegistration.RegDetails_V = Convert.ToString(txtRegDetails_V.Text);
            obPRI_PrinterRegistration.OwnerDeail_V = Convert.ToString(txtOwnerDeail_V.Text);
            obPRI_PrinterRegistration.PayMode_V = Convert.ToString(ddlPayMode.SelectedValue );
            obPRI_PrinterRegistration.BankName_V = Convert.ToString(txtBankName_V.Text );
            obPRI_PrinterRegistration.RegistrationDate = txtDate.Text=="" ? System.DateTime.Now    : Convert.ToDateTime(txtDate.Text, cult);


            if (fileProfreadpath_v.HasFile)
            {
                string path = "PrintingFile/" + txtNameofPress_V.Text.Replace(" ", "").ToString() + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(fileProfreadpath_v.FileName);
                fileProfreadpath_v.SaveAs(Server.MapPath(path));

                lblProfreadpath_v.Text = path;

                obPRI_PrinterRegistration.Profreadpath_v = path;
            }

            obPRI_PrinterRegistration.Profreadpath_v = lblProfreadpath_v.Text;


            i = obPRI_PrinterRegistration.InsertUpdate();

            CommonFuction obCommonFuction = new CommonFuction();
            DataSet ds = obCommonFuction.FillDatasetByProc("call GetPrinterRegStatus(" + i + ")");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string xml = "<DocumentElement><AgencyColumn><AGENCYTYPECOLUMNID>00836</AGENCYTYPECOLUMNID><COLUMNVALUE>00001</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>00837</AGENCYTYPECOLUMNID><COLUMNVALUE>85C61553-38C1-4A63-AB78-C647DBC22937</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01721</AGENCYTYPECOLUMNID><COLUMNVALUE>1</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01722</AGENCYTYPECOLUMNID><COLUMNVALUE>AENMP1234F</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01723</AGENCYTYPECOLUMNID><COLUMNVALUE>TAN</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01724</AGENCYTYPECOLUMNID><COLUMNVALUE>470339</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01725</AGENCYTYPECOLUMNID><COLUMNVALUE>7566845855</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01726</AGENCYTYPECOLUMNID><COLUMNVALUE>Service tax no</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01727</AGENCYTYPECOLUMNID><COLUMNVALUE>IFSC</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01730</AGENCYTYPECOLUMNID><COLUMNVALUE>Office Building</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01731</AGENCYTYPECOLUMNID><COLUMNVALUE>BOI</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01732</AGENCYTYPECOLUMNID><COLUMNVALUE>Bhopal</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01733</AGENCYTYPECOLUMNID><COLUMNVALUE>989898989898989898</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01734</AGENCYTYPECOLUMNID><COLUMNVALUE>Office Address</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01775</AGENCYTYPECOLUMNID><COLUMNVALUE>Prince</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01801</AGENCYTYPECOLUMNID><COLUMNVALUE>प्रिंस </COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01939</AGENCYTYPECOLUMNID><COLUMNVALUE>jain</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01940</AGENCYTYPECOLUMNID><COLUMNVALUE>kumar</COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01941</AGENCYTYPECOLUMNID><COLUMNVALUE>जन </COLUMNVALUE></AgencyColumn><AgencyColumn><AGENCYTYPECOLUMNID>01942</AGENCYTYPECOLUMNID><COLUMNVALUE>कुमार </COLUMNVALUE></AgencyColumn></DocumentElement>";
                string newGuid = Guid.NewGuid().ToString();


                obCommonFuction.FillDatasetByProc("call HR_PrinterRegistration('" + newGuid + "'," + i + ")");
                //YojnaTBC.YF_WebServiceSoapClient oYF_WebService = new YojnaTBC.YF_WebServiceSoapClient();
                //YojnaService.YF_WebService oYF_WebService = new YojnaService.YF_WebService();
                //oYF_WebService.SaveNewAgency("00014", newGuid, txtNameofPress_V.Text, null, xml);
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);

            }




        //}

        //catch (Exception ex) { }
        //finally { obPRI_PrinterRegistration = null; }

        return i;
    }


    protected void BtnPrinterRegistration_Click(object sender, EventArgs e)
    {
        //try
        //{
            int i = SavePrinterDetails();

            if (i > 0)
            {
                hdnPrinter_RedID_I.Value = i.ToString();

               // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('fadeDiv').style.display='block'; document.getElementById('SuccessDiv').style.display='block';</script>");

                Response.Redirect("View001_PrinterRegDetails.aspx", true);
            }
            else
            { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }

        //}
        //catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert(" + ex.Message + ");</script>"); }
    }



    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRI001_MachineDetails.aspx?PriId=" + hdnPrinter_RedID_I.Value + "");
    
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("View001_PrinterRegDetails.aspx");

    }


    protected void ddlPayMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPayMode.SelectedValue != "0")
        {
            if (ddlPayMode.SelectedValue == "Cash")
            {

                Panel1.Visible = false; 
                //txtBankName_V.Enabled = false;
                //txtRegDetails_V.Enabled = false;
                //txtDate.Enabled = false;

            }
            else
            {
                Panel1.Visible = true; 
                txtBankName_V.Enabled = true;
                txtRegDetails_V.Enabled = true;
                txtDate.Enabled = true;
            }
        }

        else
        {
            //txtBankName_V.Enabled = false;
            //txtRegDetails_V.Enabled = false;
            //txtDate.Enabled = false;
            Panel1.Visible = true; 
            txtBankName_V.Text = "0";
            txtRegDetails_V.Text = "0";
            txtDate.Text = "";


        }
    
    }


    protected void radioReginComact_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radioReginComact_I.SelectedValue == "1")
        {
            txtRegDet_V.Enabled = true;
        }
        else { txtRegDet_V.Enabled = false; }
    }


}