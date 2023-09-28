using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;
using MPTBCBussinessLayer;
public partial class CenterDepot_PaperDetilas : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string Depot_Id = ""; double TotalSheets;
    PPR_TenderEvaluation objTenderEvaluation = null;
    APIProcedure objdb = new APIProcedure();
    string  lblNetWt1;
    string lblGrossWt1; double TotNetWt = 0;
    string lblNetWt_old;
    string lblGrossWt_old;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           // DropDownList ddlVenderFill = (DropDownList)e.Row.FindControl("ddlVenderFill");
            objTenderEvaluation = new PPR_TenderEvaluation();
            ddlVenderFill.DataSource = objTenderEvaluation.VenderFill();
            ddlVenderFill.DataTextField = "PaperVendorName_V";
            ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            ddlVenderFill.DataBind();
            ddlVenderFill.Items.Insert(0, "Select");
         //  ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
           // ddlAcYear.DataTextField = "AcYear";
           // ddlAcYear.DataBind();
          
            PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
            //DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "')");
            //ddlGSM.DataSource = ds;
            //ddlGSM.DataTextField = "CoverInformation";
            //ddlGSM.DataValueField = "PaperMstrTrID_I";
            //ddlGSM.DataBind();
         //   PrinterAllFill();
            //ddlGSM.Items.Insert(0, "All");
          //  GenrateOrderNo();

            fillAllGSMAndVendor();
           
        }
    }

  
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlVenderFill.SelectedValue == "Select")
        {
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('कृपया पेपर मिल चुनें');", true);
        }
        //else if (ddlPrinter.SelectedValue == "Select")
        //{

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('कृपया प्रिंटर का नाम चुनें');", true);
        //}
       
            else
            {
                //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry(" + ddlVenderFill.SelectedValue + ",'" + ddlGSM.SelectedValue + "','" + txtRoleNo.Text + "',3)");
            int opt;
            if (RDall.Checked == true)
            {
                opt = 1;
            }
            else if (RDex.Checked == true)
            {
                opt = 2;
            }
            else
            {
                opt = 3;
            }
            ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry_New2_Search(" + ddlVenderFill.SelectedValue + ",'" + ddlGSM.SelectedValue + "','" + txtRoleNo.Text + "',"+ opt+",'2018')");
                gvRoleDetails.DataSource = ds.Tables[0];
                gvRoleDetails.DataBind();
            }
         
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       // fillGrd12();
    }
    public void fillGrd12()
    { 
    }
     

     

    

    private void fillAllGSMAndVendor()
    {
        try
        {
            DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('2018-2019',0,-1)");
            ddlGSM.DataSource = ds;
            ddlGSM.DataTextField = "CoverInformation";
            ddlGSM.DataValueField = "PaperMstrTrID_I";
            ddlGSM.DataBind();

            DataSet dd = obCommonFuction.FillDatasetByProc("call ppr_GetPaperVendorbyAcYear('2018-2019')");
            ddlVenderFill.DataSource = dd.Tables[0];
            ddlVenderFill.DataTextField = "PaperVendorName_V";
            ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            ddlVenderFill.DataBind();
        }
        catch { }
    }

    
  

    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
  
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}