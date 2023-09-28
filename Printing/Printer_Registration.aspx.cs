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
//using Yojnaservice;
using MPTBCBussinessLayer.Admin;
public partial class Printing_Printer_Registration : System.Web.UI.Page
{
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure objapi = new APIProcedure();
    UserMaster objUMaster = new UserMaster();
   //--  YF_WebService objWebService = new YF_WebService();
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PName"] != null)
            {
                txtNameofPress_V.Text = objapi.Decrypt(Request.QueryString["PName"].ToString()).Replace("+", " ");
            }
            if (Request.QueryString["Cid"] != null)
            {
                load();
            }
        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterRegDetails.aspx", true);
    }

    // load first tab data 

    public void load()
    {



        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            if (Request.QueryString["Cid"] != null)
            {


                obPRI_PrinterRegistration.Printer_RedID_I = int.Parse(objapi.Decrypt(Request.QueryString["Cid"]).ToString());
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
               // ddlGrade_V.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["Grade_V"]);
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

                //txtNameOfPressHindi.Text = ds.Tables[0].Rows[0]["NameofPressHindi_V"].ToString();
                //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('DivIsOffReg').style.display='block';</script>");

              //  chkIsOffsetReg_I.Checked = Convert.ToString(ds.Tables[0].Rows[0]["IsOffsetReg_I"]) == "1" ? true : false;


                if (ddlPayMode.SelectedValue == "Cash")
                {
                    Panel1.Visible = false;
                    txtBankName_V.Enabled = false;
                    txtRegDetails_V.Enabled = false;
                    txtDate.Enabled = false;

                }
                else
                {
                    Panel1.Visible = true;
                    txtBankName_V.Enabled = true;
                    txtRegDetails_V.Enabled = true;
                    txtDate.Enabled = true;
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

        try
        {
            //obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(Request.QueryString["Cid"]);

            if (Request.QueryString["Cid"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = int.Parse(objapi.Decrypt(Request.QueryString["Cid"]).ToString());
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
            }

            obPRI_PrinterRegistration.Regno_I = Convert.ToString(txtRegno_I.Text);
          //  obPRI_PrinterRegistration.Grade_V = Convert.ToString(ddlGrade_V.SelectedValue);
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

          //  obPRI_PrinterRegistration.IsOffsetReg_I = chkIsOffsetReg_I.Checked == true ? 1 : 0;

            obPRI_PrinterRegistration.RegDate_D = Convert.ToDateTime(txtRegDate_D.Text, cult);
            obPRI_PrinterRegistration.RegforYear_I = Convert.ToInt32(txtRegforYear_I.Text);
            obPRI_PrinterRegistration.Regamount_N = Convert.ToDouble(txtRegamount_N.Text);
            obPRI_PrinterRegistration.RegDetails_V = Convert.ToString(txtRegDetails_V.Text);
            obPRI_PrinterRegistration.OwnerDeail_V = Convert.ToString(txtOwnerDeail_V.Text);
            obPRI_PrinterRegistration.PayMode_V = Convert.ToString(ddlPayMode.SelectedValue);
            obPRI_PrinterRegistration.BankName_V = Convert.ToString(txtBankName_V.Text);
            obPRI_PrinterRegistration.RegistrationDate = txtDate.Text == "" ? System.DateTime.Now : Convert.ToDateTime(txtDate.Text, cult);
            //obPRI_PrinterRegistration.NameofPressHindi_V = txtNameOfPressHindi.Text;
            string path = "";
            string ImgStatus = "Ok";
            if (fileProfreadpath_v.HasFile)
            {
                ImgStatus = objapi.SingleuploadFile(fileProfreadpath_v, "Printing/PrintingFile", 1000);
                if (ImgStatus == "Ok")
                {
                    path = "PrintingFile/" + objapi.FullFileName;
                }


                //string path = "PrintingFile/" + txtNameofPress_V.Text.Replace(" ", "").ToString() + DateTime.Now.Date.ToString("dd/MM/yyyy").Replace("/", "") + Path.GetExtension(fileProfreadpath_v.FileName);
                //fileProfreadpath_v.SaveAs(Server.MapPath(path));
                lblProfreadpath_v.Text = path;
                obPRI_PrinterRegistration.Profreadpath_v = path;
            }
            obPRI_PrinterRegistration.Profreadpath_v = lblProfreadpath_v.Text;

            if (ImgStatus == "Ok")
            {
               

                string PrathamUId = "", BranchId = "", CreatedByEmpId = "", newGuid = "",NewEntry="";
                i = obPRI_PrinterRegistration.InsertUpdate();

                CommonFuction obCommonFuction = new CommonFuction();

                if (Request.QueryString["Cid"] != null)
                {
                    ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, objapi.Decrypt(Request.QueryString["Cid"]).ToString());
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        newGuid = ds.Tables[1].Rows[0][0].ToString();
                        if (newGuid == "")
                        {
                            newGuid = Guid.NewGuid().ToString();
                        }
                    }
                    else
                    {
                        NewEntry = "Yes";
                        newGuid = Guid.NewGuid().ToString();
                    }
                }
                else
                {
                    ds = objUMaster.PrathamIdSelect(Session["UserID"].ToString(), 1, "");
                }
                PrathamUId = ds.Tables[0].Rows[0]["PrathamUserId"].ToString();
                BranchId = ds.Tables[0].Rows[0]["BranchId"].ToString();
                CreatedByEmpId = ds.Tables[0].Rows[0]["EmployeeID_I"].ToString();
                byte PaymentType = 0;

                ds = obCommonFuction.FillDatasetByProc("call GetPrinterRegStatus(" + i + ")");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    string xml = @"<DocumentElement>
<AgencyColumn><AGENCYTYPECOLUMNID>00836</AGENCYTYPECOLUMNID><COLUMNVALUE>00001</COLUMNVALUE></AgencyColumn>
<AgencyColumn><AGENCYTYPECOLUMNID>00837</AGENCYTYPECOLUMNID><COLUMNVALUE>85C61553-38C1-4A63-AB78-C647DBC22937</COLUMNVALUE></AgencyColumn>
<AgencyColumn><AGENCYTYPECOLUMNID>01721</AGENCYTYPECOLUMNID><COLUMNVALUE>9</COLUMNVALUE></AgencyColumn> " +
"<AgencyColumn><AGENCYTYPECOLUMNID>01730</AGENCYTYPECOLUMNID><COLUMNVALUE>" + txtHeadoffice_V.Text + "</COLUMNVALUE></AgencyColumn> " +
"<AgencyColumn><AGENCYTYPECOLUMNID>01734</AGENCYTYPECOLUMNID><COLUMNVALUE>" + txtFullAddress_V.Text + "</COLUMNVALUE></AgencyColumn>"
+ "<AgencyColumn><AGENCYTYPECOLUMNID>01775</AGENCYTYPECOLUMNID><COLUMNVALUE>" + txtNameofPress_V.Text + "</COLUMNVALUE></AgencyColumn></DocumentElement>";

                    if (Request.QueryString["Cid"] != null)
                    {

                    }
                    else
                    {
                        NewEntry = "Yes";
                        newGuid = Guid.NewGuid().ToString();
                    }
                    DateTime DateRec = new DateTime();
                    DateTime CheqDate = new DateTime();
                    DateRec = DateTime.Parse(txtRegDate_D.Text, cult);
                    string Instrumentxml = "", ReceiptDetailxml = "", GentEmpId = "", deduction_detailsxml = "";

                    if (ddlPayMode.Text == "Cash")
                    {
                        PaymentType = 1;
                        Instrumentxml = @"<DocumentElement><INSTRUMENTXML>
        <ROWNO>1</ROWNO> <CHEQUEDATE>" + DateRec.ToString("yyyy/MM/dd") + "</CHEQUEDATE><CHEQUEAMOUNT>" + txtRegamount_N.Text + "</CHEQUEAMOUNT><INSTRUMENTID>" + newGuid + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";
                    }
                    else if (ddlPayMode.Text == "Cheque" || ddlPayMode.Text == "DD")
                    {
                        CheqDate = DateTime.Parse(txtDate.Text, cult);
                        PaymentType = 2;
                        Instrumentxml = @"<DocumentElement><INSTRUMENTXML>
        <ROWNO>1</ROWNO><CHEQUENO>" + txtRegDetails_V + "</CHEQUENO><CHEQUEDATE>" + CheqDate.ToString("yyyy/MM/dd") + "</CHEQUEDATE><CHEQUEAMOUNT>" + txtRegamount_N.Text + "</CHEQUEAMOUNT><BANKNAME>" + txtBankName_V.Text + "</BANKNAME><BRANCHNAME>Empty</BRANCHNAME><INSTRUMENTID>" + newGuid + "</INSTRUMENTID></INSTRUMENTXML></DocumentElement>";
                    }
                    else if (ddlPayMode.Text == "E Payment")
                    {
                        PaymentType = 3;
                        Instrumentxml = "";
                    }

                
                    ReceiptDetailxml = @"<DocumentElement> <RECEIPTDETAILXML> <ROWNO>1</ROWNO> <COLUMNID>00026</COLUMNID> <COLUMNVALUE>" + obCommonFuction.GetFinYear() + "</COLUMNVALUE>" +
                  "<INSTRUMENTID>" + newGuid + "</INSTRUMENTID> <RECEIPTTYPEID>404c5380-4312-435c-bda4-a187723b724f</RECEIPTTYPEID></RECEIPTDETAILXML>" +
      "<RECEIPTDETAILXML> <ROWNO>1</ROWNO><COLUMNID>00035</COLUMNID><COLUMNVALUE>" + txtNameofPress_V.Text + "</COLUMNVALUE>" +
      "<INSTRUMENTID>" + newGuid + "</INSTRUMENTID> <RECEIPTTYPEID>404c5380-4312-435c-bda4-a187723b724f</RECEIPTTYPEID></RECEIPTDETAILXML>" +
      "<RECEIPTDETAILXML><ROWNO>1</ROWNO><COLUMNID>00004</COLUMNID><COLUMNVALUE>" + txtRegamount_N.Text + "</COLUMNVALUE>" +
      "<INSTRUMENTID>" + newGuid + "</INSTRUMENTID><RECEIPTTYPEID>404c5380-4312-435c-bda4-a187723b724f</RECEIPTTYPEID></RECEIPTDETAILXML></DocumentElement>";
             



                    deduction_detailsxml = @"<DocumentElement><DEDUCTION><TRRD_TRT_ID>404c5380-4312-435c-bda4-a187723b724f</TRRD_TRT_ID>
<TRRD_ROW_NO>1</TRRD_ROW_NO><TRRD_TDS_AMT>0</TRRD_TDS_AMT><TRRD_COMM_AMT>0</TRRD_COMM_AMT><TRRD_OTHER_AMT>0</TRRD_OTHER_AMT></DEDUCTION></DocumentElement>";


                    if (NewEntry == "Yes" && PrathamUId != "")
                    {
                        //objWebService.SaveNewAgency("00014", newGuid, txtNameofPress_V.Text, null, xml);
                        //obCommonFuction.FillDatasetByProc("call HR_PrinterRegistration('" + newGuid + "'," + i + ")");

                        //objWebService.Printers_Registration_Or_Renewal_Fees(DateRec.ToString("yyyy/MM/dd"), newGuid.ToString(), PaymentType, PrathamUId.ToString(), BranchId,
                        //    ReceiptDetailxml, Instrumentxml, txtRegamount_N.Text, CreatedByEmpId, objUMaster.SendToEmpId(), "From Printer Registration", deduction_detailsxml);
                        //obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(hdnPrinter_RedID_I.Value);
                    }
                }

            }
            else
            {
                i = 0;
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
                hdnPrinter_RedID_I.Value = i.ToString();

                // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('fadeDiv').style.display='block'; document.getElementById('SuccessDiv').style.display='block';</script>");

                Response.Redirect("Printing_PrinterRegDetails.aspx", true);
            }
            else
            { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Check Your Data.');</script>"); }

        }
        catch (Exception ex) { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert(" + ex.Message + ");</script>"); }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRI001_MachineDetails.aspx?PriId=" + hdnPrinter_RedID_I.Value + "");

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("Printing_PrinterRegDetails.aspx");

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