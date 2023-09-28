using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer.AcademicB;
using MPTBCBussinessLayer.Paper;
using System.Web.Services;
using System.Text;
using System.Collections.Specialized;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

public partial class PTG_TechnicalChart : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obcomm = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    ACB_PaperAllotmentDetails obACB_PaperAllotmentDetails = null;
    PPR_WorkPlan objWorkPlan = null;
    DataSet ds; decimal TotalSheets;
    APIProcedure objdb = new APIProcedure(); string str1; int count12;
    string _ptg_tblfourcoloursheet = "ptg_tblfourcoloursheet";
    string _ptg_tblfourcolourreel = "ptg_tblfourcolourreel";
    string _ptg_tblonecolourreel = "ptg_tblonecolourreel";
    string _ptg_tbltwocolourreel = "ptg_tbltwocolourreel";
    string _ptg_tblonecolourreel_508 = "ptg_tblonecolourreel_508";
    string _ptg_tbltwocolourreel_508 = "ptg_tbltwocolourreel_508";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["RowNumber"] = 1;
            SetInitialRow();
            ddlFill();
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    showdata(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                }

            }
            catch { }
            finally { obPRI_PaperAllotment = null; }
        }


    }
    public void ddlFill()
    {
        try
        {
            CommonFuction obCommonFuction = new CommonFuction();
            // Dropdown list of Printer Name 
            //obPRI_PaperAllotment = new PRI_PaperAllotment();
            //obPRI_PaperAllotment.Printer_RedID_I = 0;
            CommonFuction comm = new CommonFuction();

            DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrder(0,'" + ddlAcadmicYear.SelectedValue + "')");
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            //ddlPrinterName.DataValueField = "NameofPress_V";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "सलेक्ट करे");

            DataSet ds1 = comm.FillDatasetByProc("call USP_ADM015_AcadmicYear_Active(0)");

            // Dropdown list of Acadmic Year 
            ddlAcadmicYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlAcadmicYear.DataValueField = "AcYear";
            ddlAcadmicYear.DataTextField = "AcYear";
            ddlAcadmicYear.DataBind();
            ddlAcadmicYear.SelectedValue = ds1.Tables[0].Rows[0][0].ToString();
            ddlAcadmicYear.Items.Insert(0, "सलेक्ट करे");


        }
        catch (Exception ex) { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Session["UserID"] = 0;
        var UserId = Session["UserID"];
        try
        {
            obcomm.FillDatasetByProc("call PTG_TechnicalChartSaveUpdate(" + UserId + "," + ddlAcadmicYear.SelectedValue + "," + ddlPrinterName.SelectedValue + ",'" + txtECFour_2027.Text + "','" + ddlECOldNewFour_2027.SelectedValue + "','" + txtECNoOfMachineFour_2027.Text + "','"
                + txtECOne_2027.Text + "','" + ddlECOldNewOne_2027.SelectedValue + "','" + txtECNoOfMachineOne_2027.Text + "','" + txtECTwo_2027.Text + "','" + ddlECOldNewTwo_2027.SelectedValue + "','" + txtECNoOfMachineTwo_2027.Text + "','" + txtECFour2_2027.Text + "','" + ddlECOldNewFour2_2027.SelectedValue + "','"
                + txtECNoOfMachineFour2_2027.Text + "','" + txtOHCFour_2027.Text + "','" + ddlOHCOldNewFour_2027.SelectedValue + "','" + txtOHCNoOfMachineFour_2027.Text + "','" + txtOHCOne_2027.Text + "','" + ddlOHCOldNewOne_2027.SelectedValue + "','" + txtOHCNoOfMachineOne_2027.Text + "','" + txtOHCTwo_2027.Text + "','"
                + ddlOHCOldNewTwo_2027.SelectedValue + "','" + txtOHCNoOfMachineTwo_2027.Text + "','" + txtOHCFour2_2027.Text + "','" + ddlOHCOldNewFour2_2027.SelectedValue + "','" + txtOHCNoOfMachineFour2_2027.Text + "')");
            
            var PGT_TechnicalId = "";
            InsertFourColourSheet(PGT_TechnicalId);
            InsertFourColourReel(PGT_TechnicalId);
            InsertOneColourReel(PGT_TechnicalId);
            InsertTwoColourReel(PGT_TechnicalId);
            InsertOneColourReel_508(PGT_TechnicalId);
            InsertTwoColourReel_508(PGT_TechnicalId);

            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
        }
        catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record not saved.');</script>"); }

    }

    public void showdata(string ID)
    {
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        DataSet obDataSet = obPRI_PaperAllotment.Select();

        ddlAcadmicYear.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AcadmicYR_V"]);
        ddlPrinterName.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrinterID_I"]);

    }


    protected void ddlPrinterName_SelectedIndexChanged1(object sender, EventArgs e)
    {

        CommonFuction comm = new CommonFuction();
        DataSet ds4 = comm.FillDatasetByProc("call GetPrintigandPaperSec(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedItem.Text + "')");
        //try
        //{
        //    Label1.Text = ds4.Tables[0].Rows[0]["PaperSecurityAmount_N"].ToString();
        //}
        //catch
        //{
        //    Label1.Text = "";
        //}

        //DataSet ds3 = comm.FillDatasetByProc("call USP_PRI006_PaperAllotmentJobCodeNew(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedItem.Text + "')");
        ////    DataSet ds3 = obPRI_PaperAllotment.SelectddlJobCode();
        //ddlJoBCode.DataSource = ds3;
        //ddlJoBCode.DataTextField = "WorkorderNo_V";
        //ddlJoBCode.DataValueField = "WorkorderID_I";
        //ddlJoBCode.DataBind();
        //ddlJoBCode.Items.Insert(0, "सलेक्ट करे");
        //GrdWorkPlan0.DataSource = null;
        //GrdWorkPlan0.DataBind();
        //ddlTitle.SelectedIndex = -1;
        ////  CommonFuction comm = new CommonFuction();
        //try
        //{
        //    DataSet ds31 = comm.FillDatasetByProc("call GetPrintertitleAllotmentNew(2,0," + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedItem.Text + "')");
        //    //    DataSet ds3 = obPRI_PaperAllotment.SelectddlJobCode();
        //    ddlTitle.DataSource = ds31;
        //    ddlTitle.DataTextField = "TitleHindi_V";
        //    ddlTitle.DataValueField = "TitleId";
        //    ddlTitle.DataBind();
        //    ddlTitle.Items.Insert(0, "सलेक्ट करे");
        //}
        //catch { }
    }

    protected void ddlAcadmicYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();

        DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrder(0,'" + ddlAcadmicYear.SelectedValue + "')");
        ddlPrinterName.DataSource = ds.Tables[0];
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        //ddlPrinterName.DataValueField = "NameofPress_V";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, "सलेक्ट करे");
    }

    double PrintingPaper, Coverpaper;


    protected void btnADD_Click(object sender, EventArgs e)
    {

    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));
        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dr = dt.NewRow();
        dr["RowNumber"] = (int)ViewState["RowNumber"];
        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;
        dr["Column4"] = string.Empty;
        dr["Column5"] = string.Empty;
        dt.Rows.Add(dr);
        //dr = dt.NewRow();

        //Store the DataTable in ViewState
        ViewState["CurrentTable1"] = dt;
        ViewState["CurrentTable2"] = dt;
        ViewState["CurrentTable3"] = dt;
        ViewState["CurrentTable4"] = dt;
        ViewState["CurrentTable5"] = dt;
        ViewState["CurrentTable6"] = dt;

        grdFourColourSheet.DataSource = dt;
        grdFourColourSheet.DataBind();

        grdFourColourReel.DataSource = dt;
        grdFourColourReel.DataBind();

        grdTwoColourReel.DataSource = dt;
        grdTwoColourReel.DataBind();

        grdOneColourReel.DataSource = dt;
        grdOneColourReel.DataBind();

        grdTwoColourReel_508.DataSource = dt;
        grdTwoColourReel_508.DataBind();

        grdOneColourReel_508.DataSource = dt;
        grdOneColourReel_508.DataBind();
    }
    private void AddFourColourSheet()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    drCurrentRow["Column4"] = box4.Text;
                    drCurrentRow["Column5"] = box5.Text;
                    rowIndex++;
                }
                ViewState["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable1"] = dtCurrentTable;

                grdFourColourSheet.DataSource = dtCurrentTable;
                grdFourColourSheet.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetFourColourSheet();
    }
    private void AddFourColourReel()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    drCurrentRow["Column4"] = box4.Text;
                    drCurrentRow["Column5"] = box5.Text;
                    rowIndex++;
                }
                ViewState["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable2"] = dtCurrentTable;

                grdFourColourReel.DataSource = dtCurrentTable;
                grdFourColourReel.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetFourColourReel();
    }
    private void AddTwoColourReel()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable3"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    drCurrentRow["Column4"] = box4.Text;
                    drCurrentRow["Column5"] = box5.Text;
                    rowIndex++;
                }
                ViewState["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable3"] = dtCurrentTable;

                grdTwoColourReel.DataSource = dtCurrentTable;
                grdTwoColourReel.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetTwoColourReel();
    }
    private void AddOneColourReel()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable4"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable4"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    drCurrentRow["Column4"] = box4.Text;
                    drCurrentRow["Column5"] = box5.Text;
                    rowIndex++;
                }
                ViewState["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable4"] = dtCurrentTable;

                grdOneColourReel.DataSource = dtCurrentTable;
                grdOneColourReel.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetOneColourReel();
    }
    private void AddTwoColourReel_508()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable5"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable5"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    drCurrentRow["Column4"] = box4.Text;
                    drCurrentRow["Column5"] = box5.Text;
                    rowIndex++;
                }
                ViewState["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable5"] = dtCurrentTable;

                grdTwoColourReel_508.DataSource = dtCurrentTable;
                grdTwoColourReel_508.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetTwoColourReel_508();
    }
    private void OneColourReel_508()
    {
        int rowIndex = 0;

        if (ViewState["CurrentTable6"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable6"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    drCurrentRow = dtCurrentTable.NewRow();

                    drCurrentRow["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                    drCurrentRow["Column1"] = box1.Text;
                    drCurrentRow["Column2"] = box2.Text;
                    drCurrentRow["Column3"] = box3.Text;
                    drCurrentRow["Column4"] = box4.Text;
                    drCurrentRow["Column5"] = box5.Text;
                    rowIndex++;
                }
                ViewState["RowNumber"] = (int)ViewState["RowNumber"] + 1;
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable6"] = dtCurrentTable;

                grdOneColourReel_508.DataSource = dtCurrentTable;
                grdOneColourReel_508.DataBind();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }

        //Set Previous Data on Postbacks
        SetOneColourReel_508();
    }
    private void SetFourColourSheet()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }
    private void SetFourColourReel()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable2"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }
    private void SetTwoColourReel()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable3"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }
    private void SetOneColourReel()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable4"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable4"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }
    private void SetTwoColourReel_508()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable5"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable5"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }
    private void SetOneColourReel_508()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable6"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable6"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();
                    box4.Text = dt.Rows[i]["Column4"].ToString();
                    box5.Text = dt.Rows[i]["Column5"].ToString();

                    rowIndex++;

                }
            }
            // ViewState["CurrentTable"] = dt;

        }
    }
    protected void BtnAddFourColourSheet_Click(object sender, EventArgs e)
    {
        AddFourColourSheet();
    }
    protected void BtnAddFourColourReel_Click(object sender, EventArgs e)
    {
        AddFourColourReel();
    }
    protected void BtnAddTwoColourReel_Click(object sender, EventArgs e)
    {
        AddTwoColourReel();
    }
    protected void BtnAddOneColourReel_Click(object sender, EventArgs e)
    {
        AddOneColourReel();
    }
    protected void BtnAddTwoColourReel_508_Click(object sender, EventArgs e)
    {
        AddTwoColourReel_508();
    }
    protected void BtnAddOneColourReel_508_Click(object sender, EventArgs e)
    {
        OneColourReel_508();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    private void InsertRecords(StringCollection sc, string tablename, string PGT_TechnicalId)
    {
        string sqlStatement = "";
        StringBuilder sb = new StringBuilder(string.Empty);
        string[] splitItems = null;
        foreach (string item in sc)
        {
            sqlStatement = "INSERT INTO " + tablename + " (PGT_TechnicalId,GroupNo,EMD,GroupPriorityNo,GroupTanej,Capacity) VALUES";
            if (item.Contains(","))
            {
                splitItems = item.Split(",".ToCharArray());
                sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}'); ", sqlStatement, PGT_TechnicalId, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4]);
            }
        }
        try
        {
            obcomm.FillDatasetByProc(sb.ToString());
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);

        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Insert Error:";
            msg += ex.Message;
            throw new Exception(msg);

        }
        finally
        {
            //conn.Close();
        }
    }
    // Hide the Remove Button at the last row of the GridView
    protected void grdFourColourSheet_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LBtnFourColourSheet");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void grdFourColourReel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable2"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LBtnFourColourReel");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void grdTwoColourReel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable3"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LBtnTwoColourReel");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void grdOneColourReel_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable4"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LBtnOneColourReel");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void grdTwoColourReel_508_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable5"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LBtnTwoColourReel_508");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void grdOneColourReel_508_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable6"];
            LinkButton lb = (LinkButton)e.Row.FindControl("LBtnOneColourReel_508");
            if (lb != null)
            {
                if (dt.Rows.Count > 1)
                {
                    if (e.Row.RowIndex == dt.Rows.Count - 1)
                    {
                        lb.Visible = false;
                    }
                }
                else
                {
                    lb.Visible = false;
                }
            }
        }
    }
    protected void LBtnFourColourSheet_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable1"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable1"] = dt;
            //Re bind the GridView for the updated data
            grdFourColourSheet.DataSource = dt;
            grdFourColourSheet.DataBind();
        }

        //Set Previous Data on Postbacks
        SetFourColourSheet();
    }
    protected void LBtnFourColourReel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable2"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable2"] = dt;
            //Re bind the GridView for the updated data
            grdFourColourReel.DataSource = dt;
            grdFourColourReel.DataBind();
        }

        //Set Previous Data on Postbacks
        SetFourColourReel();
    }
    protected void LBtnTwoColourReel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable3"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable3"] = dt;
            //Re bind the GridView for the updated data
            grdTwoColourReel.DataSource = dt;
            grdTwoColourReel.DataBind();
        }

        //Set Previous Data on Postbacks
        SetTwoColourReel();
    }
    protected void LBtnOneColourReel_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable4"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable4"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable4"] = dt;
            //Re bind the GridView for the updated data
            grdOneColourReel.DataSource = dt;
            grdOneColourReel.DataBind();
        }

        //Set Previous Data on Postbacks
        SetOneColourReel();
    }
    protected void LBtnTwoColourReel_508_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable5"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable5"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable5"] = dt;
            //Re bind the GridView for the updated data
            grdTwoColourReel_508.DataSource = dt;
            grdTwoColourReel_508.DataBind();
        }

        //Set Previous Data on Postbacks
        SetTwoColourReel_508();
    }
    protected void LBtnOneColourReel_508_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["CurrentTable6"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable6"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[rowID]);
                }
            }
            //Store the current data in ViewState for future reference
            ViewState["CurrentTable6"] = dt;
            //Re bind the GridView for the updated data
            grdOneColourReel_508.DataSource = dt;
            grdOneColourReel_508.DataBind();
        }

        //Set Previous Data on Postbacks
        SetOneColourReel_508();
    }
    public void InsertFourColourSheet(string PGT_TechnicalId)
    {
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        if (ViewState["CurrentTable1"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdFourColourSheet.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text);
                    rowIndex++;
                }
                InsertRecords(sc, _ptg_tblfourcoloursheet, PGT_TechnicalId);
            }
        }
    }
    public void InsertFourColourReel(string PGT_TechnicalId)
    {
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        if (ViewState["CurrentTable2"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable2"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdFourColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text);
                    rowIndex++;
                }
                InsertRecords(sc, _ptg_tblfourcolourreel, PGT_TechnicalId);
            }
        }
    }
    public void InsertOneColourReel(string PGT_TechnicalId)
    {
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        if (ViewState["CurrentTable3"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable3"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdOneColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text);
                    rowIndex++;
                }
                InsertRecords(sc, _ptg_tblonecolourreel, PGT_TechnicalId);
            }
        }
    }
    public void InsertTwoColourReel(string PGT_TechnicalId)
    {
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        if (ViewState["CurrentTable4"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable4"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdTwoColourReel.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text);
                    rowIndex++;
                }
                InsertRecords(sc, _ptg_tbltwocolourreel, PGT_TechnicalId);
            }
        }
    }
    public void InsertOneColourReel_508(string PGT_TechnicalId)
    {
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        if (ViewState["CurrentTable5"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable5"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdOneColourReel_508.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text);
                    rowIndex++;
                }
                InsertRecords(sc, _ptg_tblonecolourreel_508, PGT_TechnicalId);
            }
        }
    }
    public void InsertTwoColourReel_508(string PGT_TechnicalId)
    {
        int rowIndex = 0;
        StringCollection sc = new StringCollection();
        if (ViewState["CurrentTable6"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable6"];
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[1].FindControl("txtGroupNo");
                    TextBox box2 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[2].FindControl("txtEMD");
                    TextBox box3 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[3].FindControl("txtGroupPriorityNo");
                    TextBox box4 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[4].FindControl("txtGroupTanej");
                    TextBox box5 = (TextBox)grdTwoColourReel_508.Rows[rowIndex].Cells[5].FindControl("txtCapacity");

                    sc.Add(box1.Text + "," + box2.Text + "," + box3.Text + "," + box4.Text + "," + box5.Text);
                    rowIndex++;
                }
                InsertRecords(sc, _ptg_tbltwocolourreel_508, PGT_TechnicalId);
            }
        }
    }
}