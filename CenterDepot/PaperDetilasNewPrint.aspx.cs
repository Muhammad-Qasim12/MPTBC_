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
             
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
            PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
            //DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "')");
            //ddlGSM.DataSource = ds;
            //ddlGSM.DataTextField = "CoverInformation";
            //ddlGSM.DataValueField = "PaperMstrTrID_I";
            //ddlGSM.DataBind();
            DropDownList1.Visible = true;
            DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetPaperOrder('" + ddlAcYear.SelectedValue + "')");
            DropDownList1.DataTextField = "OrderNo";
            DropDownList1.DataValueField = "OrderNo";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select");
            PrinterAllFill();
            //ddlGSM.Items.Insert(0, "All");
            GenrateOrderNo();

            
           
        }
    }

    private void GenrateOrderNo()
    {
       /* Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        TextBox1.Text = randnum.ToString();
        */
    }

    public void PrinterAllFill()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
         
      
    }

 
    
    protected void Button1_Click(object sender, EventArgs e)
    {
      fillGrd(); 
              
    }
     
    //protected void TextBox1_TextChanged(object sender, EventArgs e)
    //{
    //    fillGrd12();
    //}
    //public void fillGrd12()
    //{
    //    CommonFuction comm = new CommonFuction();
    //    GridView1.DataSource = comm.FillDatasetByProc("select * from tbl_PaperAllotment where OrderNo='" + TextBox1.Text + "' and Fyear='" + ddlAcYear.SelectedValue + "' order by ID");
    //    GridView1.DataBind();
    //}
    public void fillGrd()
    { 
        CommonFuction comm = new CommonFuction();
    GridView1.DataSource = comm.FillDatasetByProc("select * from tbl_PaperAllotment where OrderNo='" +DropDownList1.SelectedValue + "' and Fyear='"+ddlAcYear.SelectedValue+"' order by ID");
    GridView1.DataBind();
    }    
      
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrd();
        
    }
    
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
         
        DropDownList1.Visible = true;
        DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("call USP_GetPaperOrder('" + ddlAcYear.SelectedValue + "')");
        DropDownList1.DataTextField = "OrderNo";
        DropDownList1.DataValueField = "OrderNo";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select");
    }
}