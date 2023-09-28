using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Configuration;

public partial class Depo_BundelUpload : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)

        {
            DdlDistrict.DataSource = obCommonFuction.FillDatasetByProc("call USP_DD_SelectDistrict(" + Session["UserID"] + " ,0,0 )");
            DdlDistrict.DataValueField = "DistrictTrno_I";
            DdlDistrict.DataTextField = "District_Name_Hindi_V";
            DdlDistrict.DataBind();
            DdlDistrict.Items.Insert(0, "--Select--");
            ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlSessionYear.DataValueField = "AcYear";
            ddlSessionYear.DataTextField = "AcYear";
            ddlSessionYear.DataBind();
            ddlSessionYear.SelectedValue = "2018-2019";
            ddlChallano.DataSource = obCommonFuction.FillDatasetByProc(@"select distinct StockDistributionSEntryID_I, ChallanNo_V from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=blockID_I  where dpt_stockdistributionschemeentry_m.UserID  ='" + Convert.ToString(Session["UserID"]) + "' and SendStatus not in(1,2) and `YearID`=(SELECT `AcYear` FROM`adm_acadmicyears` WHERE `Isactive`=1);");
            ddlChallano.DataValueField = "StockDistributionSEntryID_I";
            ddlChallano.DataTextField = "ChallanNo_V";
            ddlChallano.DataBind();
            ddlChallano.Items.Insert(0, "select..");
        
        }
    }
    protected void Button3_Click1(object sender, EventArgs e)
    {
        DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPTGetBookDistribute(" + ddlChallano.SelectedItem.Text + "," + Session["UserID"] + "," + ddlChallano.SelectedValue + ",'" + ddlSessionYear.SelectedValue + "')");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        ExportToExcell();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        try
        {
            ExportToExcell();
            //Class1 cls = new Class1();
            //cls.Export("Export.xls", GrdStockAvailability, "Export");
        }
        catch { }
        finally { }
    }
    public void ExportToExcell()
    {
        Response.ClearContent();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", ddlChallano.SelectedItem.Text));
        Response.Charset = "";
        Response.ContentType = "application / vnd.ms - word";

        StringWriter sw = new StringWriter();
        HtmlTextWriter HW = new HtmlTextWriter(sw);

        Panel1.RenderControl(HW);
        Response.Write(sw.ToString());
        Response.End();
        Response.Clear();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void ddlBlock_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlChallano.DataSource = obCommonFuction.FillDatasetByProc(@"select distinct StockDistributionSEntryID_I, ChallanNo_V from dpt_stockdistributionschemeentry_m
inner join dpt_distributchallanreceipt on dpt_distributchallanreceipt.ChallanID=ChallanNo_V
inner join adm_blockmaster on adm_blockmaster.BlockTrno_I=blockID_I  where dpt_stockdistributionschemeentry_m.UserID  ='" + Convert.ToString(Session["UserID"]) + "' and blockID_I=" + ddlBlock.SelectedValue + " and SendStatus not in(1,2) and `YearID`=(SELECT `AcYear` FROM`adm_acadmicyears` WHERE `Isactive`=1);");
        ddlChallano.DataValueField = "StockDistributionSEntryID_I";
        ddlChallano.DataTextField = "ChallanNo_V";
        ddlChallano.DataBind();
        ddlChallano.Items.Insert(0, "select..");
    }
    protected void DdlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strcallbyd = "CALL USP_GEN_GetBlockByDistrict(" + DdlDistrict.SelectedValue + ")";
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc(strcallbyd);
        ddlBlock.DataSource = ds;
        ddlBlock.DataTextField = "BlockNameHindi_V";
        ddlBlock.DataValueField = "BlockTrno_I";
        ddlBlock.DataBind();
        ddlBlock.Items.Insert(0, "select..");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        if (FileUpload1.HasFile)
        {

            string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);

            string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];



            string FilePath = Server.MapPath(FolderPath + FileName);

            FileUpload1.SaveAs(FilePath);

            Import_To_Grid(FilePath, Extension, ddlChallano.SelectedValue);

        }
        }
    private void Import_To_Grid(string FilePath, string Extension, string isHDR)
    {

        string conStr = "";

        switch (Extension)
        {

            case ".xls": //Excel 97-03

                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                         .ConnectionString;

                break;

            case ".xlsx": //Excel 07

                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                          .ConnectionString;

                break;

        }

        conStr = String.Format(conStr, FilePath, isHDR);

        OleDbConnection connExcel = new OleDbConnection(conStr);

        OleDbCommand cmdExcel = new OleDbCommand();

        OleDbDataAdapter oda = new OleDbDataAdapter();

        DataTable dt = new DataTable();

        cmdExcel.Connection = connExcel;



        //Get the name of First Sheet

        connExcel.Open();

        DataTable dtExcelSchema;

        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

        string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

        connExcel.Close();



        //Read Data from First Sheet

        connExcel.Open();

        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

        oda.SelectCommand = cmdExcel;

        oda.Fill(dt);

        connExcel.Close();



        //Bind Data to GridView

        GridView1.Caption = Path.GetFileName(FilePath);

        GridView1.DataSource = dt;

        GridView1.DataBind();

    }
    }
