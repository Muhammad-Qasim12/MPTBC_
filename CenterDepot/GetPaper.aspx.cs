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
public partial class CenterDepot_GetPaper : System.Web.UI.Page
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

            fillAllGSMAndVendor();
           
        }
    }

    private void GenrateOrderNo()
    {
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        TextBox1.Text = randnum.ToString();
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
            ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0050_GetReelStockByPprAndVendorId(" + ddlVenderFill.SelectedValue + ",'" + ddlGSM.SelectedValue + "')");
                if (ds.Tables[0].Rows.Count >0)
                {

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record saved successfully');", true);
                }
                else
                {
                    
                }
           
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
       
    }
  
    protected void ddlGSM_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGSM.SelectedValue == "28")
        {
            lblTotal.Visible = true;
            txtTotalSheets.Visible = true;
        }
        else
        {
            lblTotal.Visible = false;
            txtTotalSheets.Visible = false;
        }

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
            DataTable Dtt = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "',0," + ddlGSM.SelectedValue + ")");
            if (Dtt.Rows.Count > 0)
            {
                
                if (ddlVenderFill.Items.FindByValue(Dtt.Rows[0]["PaperMilID"].ToString()) != null)
                {
                    ddlVenderFill.Items.FindByValue(Dtt.Rows[0]["PaperMilID"].ToString()).Selected = true;
                }
            }

        }
        catch { }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            TextBox1.Visible = true;
            DropDownList1.Visible = false;
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            TextBox1.Text = randnum.ToString();
           
        }
        else
        {
            TextBox1.Visible = false;
            DropDownList1.Visible = true ;
            DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetPaperOrder('"+ ddlAcYear.SelectedValue +"')");
            DropDownList1.DataTextField = "OrderNo";
            DropDownList1.DataValueField = "OrderNo";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select");

        }

    }
   
   
}