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
public partial class CenterDepot_PaperDetilasNew : System.Web.UI.Page
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
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
            //DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "')");
            //ddlGSM.DataSource = ds;
            //ddlGSM.DataTextField = "CoverInformation";
            //ddlGSM.DataValueField = "PaperMstrTrID_I";
            //ddlGSM.DataBind();
           // PrinterAllFill();
            //ddlGSM.Items.Insert(0, "All");
           

            fillAllGSMAndVendor();
           
        }
    }

    
     

   

    private DataTable fnSetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;

        //Define the Columns
        dt.Columns.Add(new DataColumn("PaperType_I", typeof(string)));
        dt.Columns.Add(new DataColumn("PaperVendorTrId_I", typeof(string)));
        dt.Columns.Add(new DataColumn("ActTotalSheets", typeof(string)));
        dt.Columns.Add(new DataColumn("PaperMstrTrId_I", typeof(string)));
        dt.Columns.Add(new DataColumn("CoverInformation", typeof(string)));

        dt.Columns.Add(new DataColumn("RollNo", typeof(string)));
        dt.Columns.Add(new DataColumn("TotalSheets", typeof(string)));
        dt.Columns.Add(new DataColumn("NetWt", typeof(string)));

        dt.Columns.Add(new DataColumn("GrossWt", typeof(string)));
        dt.Columns.Add(new DataColumn("DefectedReelSts", typeof(string)));
        dt.Columns.Add(new DataColumn("Acyear", typeof(string)));
        dt.Columns.Add(new DataColumn("RollStockID_I", typeof(string)));
       
        return dt;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlVenderFill.SelectedValue == "Select")
        {
           
            ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('कृपया पेपर मिल चुनें');", true);
        }
        
        else
        {
            //change validate Rollno - 12345
            //DataTable dtt = obCommonFuction.FillTableByProc("CALL USP_ValdPaperOrder('" + ddlAcYear.SelectedItem.Text + "','" + ddlGSM.SelectedValue + "'," + ddlVenderFill.SelectedValue + ",'0')");
            //if (dtt.Rows.Count > 0)
            //{

                ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0020_GetProcReelStockEntrySerch(" + ddlVenderFill.SelectedValue + ",'" + ddlGSM.SelectedValue + "','0',9,'" + ddlAcYear.SelectedItem.Text + "')");
                if (ds.Tables[0].Rows.Count >= 2)
                {
                    gvRoleDetails.DataSource = ds.Tables[0];
                    gvRoleDetails.DataBind();
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
                }
              
            //}
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //if (ddlPrinter.SelectedValue == "Select")
        //{

        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('कृपया प्रिंटर का नाम चुनें');", true);
        //    return;
        //}
             Button txtPerbundlebook = (Button)sender;
        //txtPerbundlebook
            GridViewRow gv = (GridViewRow)txtPerbundlebook.NamingContainer;
            Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
            Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
            Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
            Label lblRollNo = (Label)gv.FindControl("lblRollNo");
            Label lblNetWt = (Label)gv.FindControl("lblNetWt");
            Label lblActTotalSheets = (Label)gv.FindControl("lblActTotalSheets");
            CheckBox ChkSelectedRoll = (CheckBox)gv.FindControl("chkitem");
            Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
            Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
            Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");//500
            Label lblReelType = (Label)gv.FindControl("lblReelType");//500

            TextBox txtNetWt = (TextBox)gv.FindControl("txtNetWt");
            HiddenField hdnRollStockID_I = (HiddenField)gv.FindControl("hdnRollStockID_I");

            //TextBox txtGrossWt = (TextBox)gv.FindControl("txtGrossWt");
            string txtGrossWt = (double.Parse(txtNetWt.Text) + 5).ToString("0.000");  

            if (txtNetWt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('कृपया नया नेट वजन डालें');", true);
                return;
            }
           

            //if (ddlGSM.SelectedValue == "28")
            //{
            //    lblNetWt1 = (((double.Parse(lblNetWt.Text) / double.Parse(lblActTotalSheets.Text)) * (double.Parse(txtTotalSheets.Text))) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
            //    lblGrossWt1 = (double.Parse(lblNetWt1) + 0.005).ToString("0.000");
            //}
            //else
            //{
            //    lblNetWt1 = ((double.Parse(lblNetWt.Text)) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
            //    lblGrossWt1 = (double.Parse(lblNetWt1) + 0.005).ToString("0.000");
            //}

            //if (ddlGSM.SelectedValue == "28")
            //{
            //    lblNetWt1 = (((double.Parse(txtNetWt.Text) / double.Parse(lblActTotalSheets.Text)) * (double.Parse(txtTotalSheets.Text))) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
            //    lblGrossWt1 = (double.Parse(lblNetWt1) + 0.005).ToString("0.000");
                

            //    lblNetWt_old = (((double.Parse(lblNetWt.Text) / double.Parse(lblActTotalSheets.Text)) * (double.Parse(txtTotalSheets.Text))) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
            //    lblGrossWt_old = (double.Parse(lblNetWt_old) + 0.005).ToString("0.000");
            //}
            //else
            //{
            //    lblNetWt1 = ((double.Parse(txtNetWt.Text)) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
            //    lblGrossWt1 = (double.Parse(lblNetWt1) + 0.005).ToString("0.000");

            //    lblNetWt_old = ((double.Parse(lblNetWt.Text)) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
            //    lblGrossWt_old = (double.Parse(lblNetWt_old) + 0.005).ToString("0.000");
            //}
            
//        CommonFuction comm = new CommonFuction();
//            comm.FillDatasetByProc(@"insert into tbl_PaperAllotment( PaperType_I, PaperMstrTrId_I, CoverInformation, RollNo, NetWt, GrossWt, PaperVendorTrId_I, PaperVendorName_V, TotalSheets, OrderNo, Fyear,ActTotalSheets,DefectedReelSts,NetWetMt,GrossWtMT,PrinterID_I
//)values ('" + lblPaperType_I.Text + "','" + lblPaperMstrTrId_I.Text + "','" + lblCoverInformation.Text + "','" + lblRollNo.Text + "','" + lblNetWt.Text + "','" + lblGrossWt.Text + "','" + lblPaperVendorTrId_I.Text + "','" + ddlVenderFill.SelectedItem.Text + "','" + lblTotalSheets.Text + "','" + TextBox1.Text + "','" + ddlAcYear.SelectedValue + "','" + lblActTotalSheets.Text + "','" + lblReelType.Text + "'," + lblNetWt1.ToString() + "," + lblGrossWt1.ToString() + "," + ddlPrinter.SelectedValue + ")");

//            int PrinterID_I = 0;
//            if (txtRoleNo.Text.ToString().Trim().ToUpper () == lblRollNo.Text.ToString().Trim())
//            {

//            CommonFuction comm = new CommonFuction();
//            comm.FillDatasetByProc(@"insert into tbl_PaperAllotment(PaperType_I, PaperMstrTrId_I, CoverInformation, RollNo, NetWt, GrossWt, PaperVendorTrId_I, PaperVendorName_V, TotalSheets, OrderNo, Fyear,ActTotalSheets,DefectedReelSts,NetWetMt,GrossWtMT,PrinterID_I, OldNetWt, OldGrossWt, OldNetWtMt,OldGrossWtMT,RollStockID_I
//)values ('" + lblPaperType_I.Text + "','" + lblPaperMstrTrId_I.Text + "','" + lblCoverInformation.Text + "','" + lblRollNo.Text + "','" + txtNetWt.Text + "','" + txtGrossWt + "','" + lblPaperVendorTrId_I.Text + "','" + ddlVenderFill.SelectedItem.Text + "','" + lblTotalSheets.Text + "','" + TextBox1.Text + "','" + ddlAcYear.SelectedValue + "','" + lblActTotalSheets.Text + "','" + lblReelType.Text + "'," + lblNetWt1.ToString() + "," + lblGrossWt1.ToString() + "," + PrinterID_I + "," + lblNetWt.Text + "," + lblGrossWt.Text + "," + lblNetWt_old.ToString() + "," + lblGrossWt_old.ToString() + ",'"+hdnRollStockID_I.Value+"')");

//            gvRoleDetails.DataSource = null;
//            gvRoleDetails.DataBind();
//            fillGrd12();
//            txtRoleNo.Text = "";

            }
            //Random rand = new Random();
            //int randnum = rand.Next(100000, 10000000);
            //TextBox1.Text = randnum.ToString();
    
     
    

    
    protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
    {
        

        try
        {

           // fnGetVendorFill();

        }
        catch { }
    }

    private void fillAllGSMAndVendor()
    {
        try
        {


            DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "',0,-1)");
            ddlGSM.DataSource = ds;
            ddlGSM.DataTextField = "CoverInformation";
            ddlGSM.DataValueField = "PaperMstrTrID_I";
            ddlGSM.DataBind();

            DataSet dd = obCommonFuction.FillDatasetByProc("call ppr_GetPaperVendorbyAcYear('" + ddlAcYear.SelectedItem.Text + "')");
            ddlVenderFill.DataSource = dd.Tables[0];
            ddlVenderFill.DataTextField = "PaperVendorName_V";
            ddlVenderFill.DataValueField = "PaperVendorTrId_I";
            ddlVenderFill.DataBind();
        }
        catch { }
    }

    

    private void fnGetVendorFill()
    {
        try
        {
            ddlVenderFill.ClearSelection();
            
        }
        catch { }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
    
    
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}