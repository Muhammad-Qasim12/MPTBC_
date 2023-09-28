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

public partial class Printing_BindingDetails : System.Web.UI.Page
{

    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure objapi = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        { load(); }
    }

    public void load()
    {
        if (Request.QueryString["PriId"] != null)
        {
            
            LoadBindingDetails();
          

        }
    }

    protected void BtnBack_Click(object sender, EventArgs e)
    { Response.Redirect("PrinterRegDetails.aspx"); }



    // function to save Bindind Tab 4

    public int SaveBindingDetails()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        int i = 0;
        try
        {
            //obPRI_PrinterRegistration.PriBindID_I = Convert.ToInt32(hdnPriBindID_I.Value);

            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            if (Request.QueryString["BindId"] != null)
            {
                obPRI_PrinterRegistration.PriBindID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["BindId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.PriBindID_I = 0;
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
            obPRI_PrinterRegistration.Mac_othMake_V = Convert.ToString(txtMac_othMake_V.Text)=="" ? "" : Convert.ToString(txtMac_othMake_V.Text);
            obPRI_PrinterRegistration.Mac_othSize_V = Convert.ToString(txtMac_othSize_V.Text) == "" ? "" : Convert.ToString(txtMac_othSize_V.Text);
            obPRI_PrinterRegistration.Mac_othNos_I =  (txtMac_othNos_I.Text)=="" ? 0 : Convert.ToInt32(txtMac_othNos_I.Text);
            obPRI_PrinterRegistration.Mac_othOwned_V = Convert.ToString(txtMac_othOwned_V.Text) == "0" ? "" : Convert.ToString(txtMac_othOwned_V.Text);
            obPRI_PrinterRegistration.Bookname_V = Convert.ToString(txtBookname_V.Text) == "" ? "" : Convert.ToString(txtBookname_V.Text);
            obPRI_PrinterRegistration.Book1BindCapNo_I = (txtBook1BindCapNo_I.Text) == "" ? 0 : Convert.ToInt32(txtBook1BindCapNo_I.Text);
            obPRI_PrinterRegistration.Bookname1_V = Convert.ToString(txtBookname1_V.Text) == "" ? "" : Convert.ToString(txtBookname1_V.Text);
            obPRI_PrinterRegistration.Book2BindCapNo_I = (txtBook2BindCapNo_I.Text) == "" ? 0 : Convert.ToInt32(txtBook2BindCapNo_I.Text);
            obPRI_PrinterRegistration.Bookname2_V = Convert.ToString(txtBookname2_V.Text) == "" ? "" : Convert.ToString(txtBookname2_V.Text);
            obPRI_PrinterRegistration.BookBindCapNo_I =  (txtBookBindCapNo_I.Text) == "" ? 0 : Convert.ToInt32(txtBookBindCapNo_I.Text);
            obPRI_PrinterRegistration.OffsetCameraSize_V = Convert.ToString(txtOffsetCameraSize_V.Text) == "" ? "" : Convert.ToString(txtOffsetCameraSize_V.Text);
            obPRI_PrinterRegistration.OffsetCameraMake_V = Convert.ToString(txtOffsetCameraMake_V.Text) == "" ? "" : Convert.ToString(txtOffsetCameraMake_V.Text);
            obPRI_PrinterRegistration.OffsetWhirlarSize_V = Convert.ToString(txtOffsetWhirlarSize_V.Text) == "" ? "" : Convert.ToString(txtOffsetWhirlarSize_V.Text);
            obPRI_PrinterRegistration.OffsetWhirlarMake_V = Convert.ToString(txtOffsetWhirlarMake_V.Text) == "" ? "" : Convert.ToString(txtOffsetWhirlarMake_V.Text);
            obPRI_PrinterRegistration.OffsetOthSize_V = Convert.ToString(txtOffsetOthSize_V.Text) == "" ? "" : Convert.ToString(txtOffsetOthSize_V.Text);
            obPRI_PrinterRegistration.OffsetOthMake_V = Convert.ToString(txtOffsetOthMake_V.Text) == "" ? "" : Convert.ToString(txtOffsetOthMake_V.Text);
            obPRI_PrinterRegistration.OffsetConCabSize_V = Convert.ToString(txtOffsetConCabSize_V.Text) == "" ? "" : Convert.ToString(txtOffsetConCabSize_V.Text);
            obPRI_PrinterRegistration.OffsetConCabMake_V = Convert.ToString(txtOffsetConCabMake_V.Text) == "" ? "" : Convert.ToString(txtOffsetConCabMake_V.Text);

            obPRI_PrinterRegistration.OffsetConCabSize_V1 = Convert.ToString(txtOffsetConCabSize_V1.Text) == "" ? "" : Convert.ToString(txtOffsetConCabSize_V1.Text);
            obPRI_PrinterRegistration.OffsetConCabMake_V1 = Convert.ToString(txtOffsetConCabMake_V1.Text) == "" ? "" : Convert.ToString(txtOffsetConCabMake_V1.Text);


            if (obPRI_PrinterRegistration.Printer_RedID_I == 0)
            
            {
                Response.Redirect("PRI001_PrinterRegistration.aspx");
            
            }
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
            if (Request.QueryString["PriId"] != null)
            {
                obPRI_PrinterRegistration.Printer_RedID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["PriId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.Printer_RedID_I = 0;
            }

            if (Request.QueryString["BindId"] != null)
            {
                obPRI_PrinterRegistration.PriBindID_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["BindId"]).ToString() );
            }
            else
            {
                obPRI_PrinterRegistration.PriBindID_I = 0;
            }


           // obPRI_PrinterRegistration.PriBindID_I = Convert.ToInt32(hdnPriBindID_I.Value);

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
                txtBook1BindCapNo_I.Text = txtBook1BindCapNo_I.Text == "0" ? "" : txtBook1BindCapNo_I.Text;
                txtBookname1_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookname1_V"]);

                txtBook2BindCapNo_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["Book2BindCapNo_I"]);
                txtBook2BindCapNo_I.Text = txtBook2BindCapNo_I.Text == "0" ? "" : txtBook2BindCapNo_I.Text;
                txtBookname2_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["Bookname2_V"]);

                txtBookBindCapNo_I.Text = Convert.ToString(ds.Tables[0].Rows[0]["BookBindCapNo_I"]);
                txtBookBindCapNo_I.Text = txtBookBindCapNo_I.Text == "0" ? "" : txtBookBindCapNo_I.Text;

                txtOffsetCameraSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetCameraSize_V"]);
                txtOffsetCameraMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetCameraMake_V"]);
                txtOffsetWhirlarSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetWhirlarSize_V"]);
                txtOffsetWhirlarMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetWhirlarMake_V"]);
                txtOffsetOthSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetOthSize_V"]);
                txtOffsetOthMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetOthMake_V"]);
                txtOffsetConCabSize_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetConCabSize_V"]);
                txtOffsetConCabMake_V.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetConCabMake_V"]);

                txtOffsetConCabSize_V1.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetConCabSize_V1"]);
                txtOffsetConCabMake_V1.Text = Convert.ToString(ds.Tables[0].Rows[0]["OffsetConCabMake_V1"]);

            }
        }

        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }

    }


    // for save Binding Tab

    protected void BtnBindingSave_Click(object sender, EventArgs e)
    {
        int i = 0;
        i = SaveBindingDetails();
        if (i > 0)
        {

            hdnPriBindID_I.Value = i.ToString();
            //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>document.getElementById('fadeDiv').style.display='block'; document.getElementById('SuccessDiv').style.display='block';</script>");
            Response.Redirect("PrinterRegDetails.aspx");

        }
        else { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Error.');</script>"); }

    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRI001_OtherDetails.aspx?PriId=" + objapi.Decrypt(Request.QueryString["PriId"]).ToString()  + "");

    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("PrinterRegDetails.aspx");

    }

}