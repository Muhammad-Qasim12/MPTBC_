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


public partial class Printing_OtherDetails : System.Web.UI.Page
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
    {
        Response.Redirect("PrinterRegDetails.aspx");
    
    }


    public void Load() 
    {
        if (Request.QueryString["PriId"] != null)
        {
           
            OtherDetailsLoad();


        }
        else { Response.Redirect("PrinterRegDetails.aspx"); }
    
    
    }

    // function to save other details tab 4

    public int OtherDetailsSaveUpdate()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
            //obPRI_PrinterRegistration.RegOthID = Convert.ToInt32(hdnRegOthID.Value);

            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            if (Request.QueryString["OthId"] != null)
            {
                obPRI_PrinterRegistration.RegOthID = Convert.ToInt32(objapi.Decrypt(Request.QueryString["OthId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.RegOthID = 0;
            }


            obPRI_PrinterRegistration.Noofshift_V = Convert.ToString(txtNoofshift_V.Text);
            obPRI_PrinterRegistration.BookPrintExperience_V = Convert.ToString(txtBookPrintExperience_V.Text);
            // obPRI_PrinterRegistration.NOofTitle_TBCPrint_I = Convert.ToInt32(txtNOofTitle_TBCPrint_I.Text);
            obPRI_PrinterRegistration.NOofTitle_OThTBCPrint_I = txtNOofTitle_OThTBCPrint_I.Text != "" ? Convert.ToInt32(txtNOofTitle_OThTBCPrint_I.Text) : 0;
            //obPRI_PrinterRegistration.NOofTitle_OThPrint_I = Convert.ToInt32(txtNOofTitle_OThPrint_I.Text);
            obPRI_PrinterRegistration.WareHouseDet_V = Convert.ToString(txtWareHouseDet_V.Text);
            obPRI_PrinterRegistration.Premises_GoodIns_V = Convert.ToString(txtPremises_GoodIns_V.Text);
            obPRI_PrinterRegistration.Ins_CoverDetail_V = Convert.ToString(txtIns_CoverDetail_V.Text);
            obPRI_PrinterRegistration.Nameaddbanker_v = Convert.ToString(txtNameaddbanker_v.Text);

            obPRI_PrinterRegistration.AnyOthDetails_V = Convert.ToString(txtAnyOthDetails_V.Text);


            obPRI_PrinterRegistration.UserID_I = Session["UserID_I"] != null ? Convert.ToInt32(Session["UserID_I"]) : 0;
            obPRI_PrinterRegistration.NOofTitle_MPTBCPrint_I = NOofTitle_MPTBCPrint_I.Text != "" ? Convert.ToInt32(NOofTitle_MPTBCPrint_I.Text) : 0;
            //obPRI_PrinterRegistration.Last3YearQuantity_I = Convert.ToInt32(Last3YearQuantity_I.Text);

            obPRI_PrinterRegistration.IncometaxPay = Convert.ToInt32(RadioIncometaxPay.SelectedValue);
            obPRI_PrinterRegistration.ApprovContractor_I = Convert.ToInt32(RadioApprovContractor_I.SelectedValue);


            obPRI_PrinterRegistration.NameOfTitle_OThTBCPrint_V = Convert.ToString(txtNameOfTitle_OThTBCPrint_V.Text);

            obPRI_PrinterRegistration.OtherCorpName_V = Convert.ToString(txtOtherCorpName_V.Text);
            obPRI_PrinterRegistration.OtherCorpNo_I = txtOtherCorpNo_I.Text != "" ? Convert.ToInt32(txtOtherCorpNo_I.Text) : 0;



            if (obPRI_PrinterRegistration.Printer_RedID_I == 0) { Response.Redirect("PRI001_PrinterRegistration.aspx"); }
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
            //obPRI_PrinterRegistration.RegOthID = Convert.ToInt32(hdnRegOthID.Value);

            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString ());
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            if (Request.QueryString["OthId"] != null)
            {
                obPRI_PrinterRegistration.RegOthID = Convert.ToInt32(objapi.Decrypt(Request.QueryString["OthId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.RegOthID = 0;
            }


            ds = obPRI_PrinterRegistration.OtherDetailsLoad();

            if (ds.Tables[0].Rows.Count > 0)
            {

                hdnRegOthID.Value = Convert.ToString(ds.Tables[0].Rows[0]["RegOthID"]);

                txtNoofshift_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Noofshift_V"]);
                txtBookPrintExperience_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookPrintExperience_V"]);
                
                //txtNOofTitle_TBCPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_TBCPrint_I"]);

                txtNOofTitle_OThTBCPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_OThTBCPrint_I"]);
                //txtNOofTitle_OThPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_OThPrint_I"]);
                txtWareHouseDet_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["WareHouseDet_V"]);
                txtPremises_GoodIns_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Premises_GoodIns_V"]);
                txtIns_CoverDetail_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Ins_CoverDetail_V"]);
                txtNameaddbanker_v.Text = Convert.ToString(ds.Tables[0].Rows[0]["Nameaddbanker_v"]);
                txtAnyOthDetails_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["AnyOthDetails_V"]);
                
                NOofTitle_MPTBCPrint_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["NOofTitle_MPTBCPrint_I"]);
                //Last3YearQuantity_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Last3YearQuantity_I"]);

                RadioIncometaxPay.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["IncometaxPay"]);
                RadioApprovContractor_I.SelectedValue = Convert.ToString(ds.Tables[0].Rows[0]["ApprovContractor_I"]);

                txtNameOfTitle_OThTBCPrint_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["NameOfTitle_OThTBCPrint_V"]);

                txtOtherCorpName_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherCorpName_V"]);
                txtOtherCorpNo_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["OtherCorpNo_I"]);

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
            
            hdnRegOthID.Value = i.ToString();
           // ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('fadeDiv').style.display='block'; document.getElementById('SuccessDiv').style.display='block';</script>");
            Response.Redirect("PrinterRegDetails.aspx");
        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }


    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRI001_CheckboxDetails.aspx?PriId=" + objapi.Decrypt(Request.QueryString["PriId"]).ToString () + "");

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterRegDetails.aspx");

    }



}