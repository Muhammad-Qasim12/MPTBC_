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
            ddlAcYear.SelectedValue = "2023-2024"; 
            PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
            //DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "')");
            //ddlGSM.DataSource = ds;
            //ddlGSM.DataTextField = "CoverInformation";
            //ddlGSM.DataValueField = "PaperMstrTrID_I";
            //ddlGSM.DataBind();
            PrinterAllFill();
            //ddlGSM.Items.Insert(0, "All");
            GenrateOrderNo();

            fillAllGSMAndVendor();
           
        }
    }

    private void GenrateOrderNo()
    {
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        TextBox1.Text = randnum.ToString();
    }

    public void PrinterAllFill()
    {
        PRI_PaperAllotment obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Printer_RedID_I = 0;
        DataSet ds = obPRI_PaperAllotment.SelectddlPrinterName();
        
        ddlPrinter.DataSource = ds.Tables[0];
        ddlPrinter.DataTextField = "NameofPressHindi_V";
        ddlPrinter.DataValueField = "Printer_RedID_I";
        ddlPrinter.DataBind();
        ddlPrinter.Items.Insert(0, "Select");
      
    }

    protected void btnAdd1_Click(object sender, EventArgs e)
    {
        try
        {
            int iCnt = 0;
            foreach (GridViewRow gv in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)gv.FindControl("CheckBox1");
                if (chk.Checked == true)
                    iCnt++;
            }

            if (iCnt == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select atleast one Roll No.');</script>");
                return;
            }

            if (iCnt > 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select only one roll no.');</script>");
                return;
            }

            DataTable dtMainGrid = fnSetInitialRow();
            foreach (GridViewRow gv in GridView2.Rows)
            {
                CheckBox chk = (CheckBox)gv.FindControl("CheckBox1");
                if (chk.Checked == true)
                {
                    Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                    Label lblPaperVendorTrId_I = (Label)gv.FindControl("lblPaperVendorTrId_I");
                    Label lblActTotalSheets = (Label)gv.FindControl("lblActTotalSheets");
                    Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                    Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
                    Label lblRollNo = (Label)gv.FindControl("lblRollNo");

                    Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                    Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                    Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                    Label lblReelType = (Label)gv.FindControl("lblReelType");
                    Label lblAcyear = (Label)gv.FindControl("lblAcyear");
                    HiddenField hdnRollStockID_I = (HiddenField)gv.FindControl("hdnRollStockID_I");

                    DataRow dr = dtMainGrid.NewRow();
                    dr["PaperType_I"] = lblPaperType_I.Text;
                    dr["PaperVendorTrId_I"] = lblPaperVendorTrId_I.Text;
                    dr["ActTotalSheets"] = lblActTotalSheets.Text;

                    dr["PaperMstrTrId_I"] = lblPaperMstrTrId_I.Text;
                    dr["CoverInformation"] = lblCoverInformation.Text;
                    dr["RollNo"] = lblRollNo.Text;

                    dr["TotalSheets"] = lblTotalSheets.Text;
                    dr["NetWt"] = lblNetWt.Text;
                    dr["GrossWt"] = lblGrossWt.Text;
                    dr["DefectedReelSts"] = lblReelType.Text;
                    dr["Acyear"] = lblAcyear.Text;
                    dr["RollStockID_I"] = hdnRollStockID_I.Value;
                   
                    dtMainGrid.Rows.Add(dr);
                }
            }

            if (dtMainGrid.Rows.Count > 0)
            {
                //ViewState["dtBill"] = dtMainGrid;
                gvRoleDetails.DataSource = dtMainGrid;
                gvRoleDetails.DataBind();
                if (gvRoleDetails.Rows.Count > 0)
                {
                    foreach (GridViewRow gv in gvRoleDetails.Rows)
                    {
                        Button btnGrd = (Button)gv.FindControl("Button2");
                        Button2_Click(btnGrd, null);
                    }
                }
            }

        }
        catch { }
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
            DataTable dtt = obCommonFuction.FillTableByProc("CALL USP_ValdPaperOrder('" + ddlAcYear.SelectedItem.Text + "','" + ddlGSM.SelectedValue + "'," + ddlVenderFill.SelectedValue + ",'" + txtRoleNo.Text + "')");
            if (dtt.Rows.Count > 0)
            {
                string orderno = dtt.Rows[0]["Orderno"].ToString();
                if (RadioButtonList1.SelectedValue == "1")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg33", "alert('Rollno - " + txtRoleNo.Text + " already exists in this order no - " + orderno + "');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "msg33", "alert('Rollno - " + txtRoleNo.Text + " already exists');", true);
                }               
            }
            else
            {
                //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0014_ProcReelStockEntry_New2(" + ddlVenderFill.SelectedValue + ",'" + ddlGSM.SelectedValue + "','" + txtRoleNo.Text + "',9,'" + ddlAcYear.SelectedItem.Text + "')");
                ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0020_GetProcReelStockEntryNew(" + ddlVenderFill.SelectedValue + ",'" + ddlGSM.SelectedValue + "','" + txtRoleNo.Text + "',9,'" + ddlAcYear.SelectedItem.Text + "')");
                if (ds.Tables[0].Rows.Count >= 2)
                {
                    GridView2.DataSource = ds.Tables[0];
                    GridView2.DataBind();
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
                }
                else
                {
                    gvRoleDetails.DataSource = ds.Tables[0];
                    gvRoleDetails.DataBind();

                    //GridView2.DataSource = ds.Tables[0];
                    //GridView2.DataBind();
                    //ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>OpenBill();</script>");
                }
            }
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

            if (ddlGSM.SelectedValue == "28")
            {
                lblNetWt1 = (((double.Parse(txtNetWt.Text) / double.Parse(lblActTotalSheets.Text)) * (double.Parse(txtTotalSheets.Text))) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
                lblGrossWt1 = (double.Parse(lblNetWt1) + 0.005).ToString("0.000");
                

                lblNetWt_old = (((double.Parse(lblNetWt.Text) / double.Parse(lblActTotalSheets.Text)) * (double.Parse(txtTotalSheets.Text))) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
                lblGrossWt_old = (double.Parse(lblNetWt_old) + 0.005).ToString("0.000");
            }
            else
            {
                lblNetWt1 = ((double.Parse(txtNetWt.Text)) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
                lblGrossWt1 = (double.Parse(lblNetWt1) + 0.005).ToString("0.000");

                lblNetWt_old = ((double.Parse(lblNetWt.Text)) / 1000).ToString("0.000"); //((decimal.Parse(lblPaperDemand.Text) / decimal.Parse(lblOrderTotSheet.Text)) * decimal.Parse(txtTotalSheets.Text)).ToString("0.000");
                lblGrossWt_old = (double.Parse(lblNetWt_old) + 0.005).ToString("0.000");
            }
            
//        CommonFuction comm = new CommonFuction();
//            comm.FillDatasetByProc(@"insert into tbl_PaperAllotment( PaperType_I, PaperMstrTrId_I, CoverInformation, RollNo, NetWt, GrossWt, PaperVendorTrId_I, PaperVendorName_V, TotalSheets, OrderNo, Fyear,ActTotalSheets,DefectedReelSts,NetWetMt,GrossWtMT,PrinterID_I
//)values ('" + lblPaperType_I.Text + "','" + lblPaperMstrTrId_I.Text + "','" + lblCoverInformation.Text + "','" + lblRollNo.Text + "','" + lblNetWt.Text + "','" + lblGrossWt.Text + "','" + lblPaperVendorTrId_I.Text + "','" + ddlVenderFill.SelectedItem.Text + "','" + lblTotalSheets.Text + "','" + TextBox1.Text + "','" + ddlAcYear.SelectedValue + "','" + lblActTotalSheets.Text + "','" + lblReelType.Text + "'," + lblNetWt1.ToString() + "," + lblGrossWt1.ToString() + "," + ddlPrinter.SelectedValue + ")");

            int PrinterID_I = 0;
            if (txtRoleNo.Text.ToString().Trim().ToUpper () == lblRollNo.Text.ToString().Trim())
            {

            CommonFuction comm = new CommonFuction();
            comm.FillDatasetByProc(@"insert into tbl_PaperAllotment(PaperType_I, PaperMstrTrId_I, CoverInformation, RollNo, NetWt, GrossWt, PaperVendorTrId_I, PaperVendorName_V, TotalSheets, OrderNo, Fyear,ActTotalSheets,DefectedReelSts,NetWetMt,GrossWtMT,PrinterID_I, OldNetWt, OldGrossWt, OldNetWtMt,OldGrossWtMT,RollStockID_I,UserID_A)values ('" + lblPaperType_I.Text + "','" + lblPaperMstrTrId_I.Text + "','" + lblCoverInformation.Text + "','" + lblRollNo.Text + "'," + txtNetWt.Text + ",'" + txtGrossWt + "','" + lblPaperVendorTrId_I.Text + "','" + ddlVenderFill.SelectedItem.Text + "'," + lblTotalSheets.Text + ",'" + TextBox1.Text + "','" + ddlAcYear.SelectedValue + "'," + lblActTotalSheets.Text + ",'" + lblReelType.Text + "'," + lblNetWt1.ToString() + "," + lblGrossWt1.ToString() + "," + PrinterID_I + "," + lblNetWt.Text + "," + lblGrossWt.Text + "," + lblNetWt_old.ToString() + "," + lblGrossWt_old.ToString() + ",'" + hdnRollStockID_I.Value + "',"+Session["UserID"].ToString ()+")");

            gvRoleDetails.DataSource = null;
            gvRoleDetails.DataBind();
            fillGrd12();
            txtRoleNo.Text = "";

            }
            //Random rand = new Random();
            //int randnum = rand.Next(100000, 10000000);
            //TextBox1.Text = randnum.ToString();
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        fillGrd12();
    }
    public void fillGrd12()
    {
        CommonFuction comm = new CommonFuction();
        GridView1.DataSource = comm.FillDatasetByProc("select * from tbl_PaperAllotment where OrderNo='" + TextBox1.Text + "' and Fyear='" + ddlAcYear.SelectedValue + "' order by ID");
        GridView1.DataBind();
    }
    public void fillGrd()
    { 
        CommonFuction comm = new CommonFuction();
    GridView1.DataSource = comm.FillDatasetByProc("select * from tbl_PaperAllotment where OrderNo='" +DropDownList1.SelectedValue + "' and Fyear='"+ddlAcYear.SelectedValue+"' order by ID");
    GridView1.DataBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        comm.FillDatasetByProc("delete from tbl_PaperAllotment where ID=" + GridView1.DataKeys[e.RowIndex].Value + " ");
        if (RadioButtonList1.SelectedValue == "1")
        { 
            fillGrd12(); 
        }
        else
        { 
            fillGrd();
        }
            
       
        
       
       
       
    }

    protected void Gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");          
            try
            {
                TotNetWt = TotNetWt + double.Parse(lblNetWt.Text);
            }
            catch { TotNetWt = 0; }
            
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotNetWt = (Label)e.Row.FindControl("lblTotNetWt");            
            lblTotNetWt.Text = TotNetWt.ToString("0.000");            
        }
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

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {


            DataTable ds = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "',"+ddlPrinter.SelectedValue+",0)");
            ddlGSM.DataSource = ds;
            ddlGSM.DataTextField = "CoverInformation";
            ddlGSM.DataValueField = "PaperMstrTrID_I";
            ddlGSM.DataBind();

            fnGetVendorFill();

            //GridView1.DataSource = null;
            //GridView1.DataBind();
            //gvRoleDetails.DataSource = null;
            //gvRoleDetails.DataBind();
            //GenrateOrderNo();
        }
        catch { }
    }

    private void fnGetVendorFill()
    {
        try
        {
            ddlVenderFill.ClearSelection();
            DataTable Dtt = obCommonFuction.FillTableByProc("call USP_BindGSMDdl_PprDtls('" + ddlAcYear.SelectedItem.Text + "'," + ddlPrinter.SelectedValue + "," + ddlGSM.SelectedValue + ")");
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
            GridView1.DataSource = null;
            GridView1.DataBind();
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
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillGrd();
        if (RadioButtonList1.SelectedValue == "1")
        {
        }
        else
        {
            TextBox1.Text = DropDownList1.SelectedValue;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}