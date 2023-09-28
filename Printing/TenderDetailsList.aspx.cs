using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Data.OleDb;

public partial class Printing_TenderDetailsList : System.Web.UI.Page
{
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = null;
    TenderDetails obTenderDetails = null;
    PRI_TenderEvaluation obPriEval = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                obCommonFuction = new CommonFuction();
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
                FillData();
            }
        }

        catch { }
        finally { }
    }
    public void FillData()
    {
        try
        {
            //obTenderDetails = new TenderDetails();
            //obTenderDetails.TenderId_I = 0;
            //obTenderDetails.TenderId_I = Convert.ToInt32(Session["TenderId_I"]);
            //GrdTenderDetails.DataSource = obTenderDetails.Select();
            //GrdTenderDetails.DataBind();
            CommonFuction comm = new CommonFuction();

            GrdTenderDetails.DataSource = comm.FillDatasetByProc("call Prin_loadTenderDetails(0,'" + DdlACYear.SelectedItem.Text + "')"); ;
            GrdTenderDetails.DataBind();
        }
        catch
        {
        }
        finally
        {
           // obTenderDetails = null;
        }
    }

    protected void GrdTenderDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obTenderDetails = new TenderDetails();
        string str = GrdTenderDetails.DataKeys[e.RowIndex].Value.ToString();
        obTenderDetails.Delete(Convert.ToInt32(str));
        FillData();
    }
    protected void GrdTenderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTenderDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenderDetails.aspx");
    }
    protected void btnTechinicalClick(object sender, EventArgs e)
    {
        Button chkbox = (Button)sender;
        GridViewRow grd = (GridViewRow)(chkbox.NamingContainer);
        HiddenField tenderID = (HiddenField)grd.FindControl("HDNTenID");
        CommonFuction comm = new CommonFuction();
        DataSet tendertype = comm.FillDatasetByProc("SELECT   tendertype_v,AcdmicYr_V FROM pri_tenderdetail WHERE tenderid_i=" + Convert.ToInt32(tenderID.Value).ToString() + "");
        DataSet dd1 = comm.FillDatasetByProc("Call getlunlistbycompanytenderassmtfin(" + Convert.ToInt32(tenderID.Value) + ",'" + DdlACYear.SelectedItem.Text + "' , 'S' )");
        comm.FillDatasetByProc("call UpdateLUNList('nil',''," + Convert.ToInt32(tenderID.Value)+ ")");
        FillData();
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Tsechnical bid has been saved", true);
    }

    protected void btnFinancialClick(object sender, EventArgs e)
    {
        Response.Redirect("TenderCommercialDetails.aspx");
    }

    protected void GrdTenderDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            int TenEval = 0;
            TenEval = Convert.ToInt32(((HiddenField)e.Row.FindControl("HdnTenEval")).Value);
            int HiddenField1 = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField1")).Value);
            if (HiddenField1 == 0)
            { 
                ((Button)e.Row.FindControl("btnUploadFile")).Visible = true;
                ((FileUpload)e.Row.FindControl("flExcel")).Visible = true;
           // btnUploadFile
            }
            else
            {
                ((Button)e.Row.FindControl("btnUploadFile")).Visible = false;
                ((FileUpload)e.Row.FindControl("flExcel")).Visible = false;
            }
            if (TenEval > 0)
            {
                //((HyperLink)e.Row.FindControl("HypTenderid")).Enabled = false;
                //((HyperLink)e.Row.FindControl("HypTenderid")).ForeColor = System.Drawing.Color.Red;

                ((LinkButton)e.Row.FindControl("pnlTenderid")).Enabled = false;
                // ((Panel)e.Row.FindControl("pnlTenderid")).Style.Add("z-index", "1200");

            }
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string GroupName = "";
        Button btn = (Button)sender;
        GridViewRow gv = (GridViewRow)btn.NamingContainer;
        FileUpload fileUpload = (FileUpload)gv.FindControl("flExcel");
        int hdTenderID = Convert.ToInt32(((HiddenField)gv.FindControl("HDNTenID")).Value);

        if (fileUpload.HasFile == true)
        {
            //excel code
            string filename = Path.GetFileName(fileUpload.PostedFile.FileName);
            string Extension = Path.GetExtension(fileUpload.PostedFile.FileName);

            string folderPath = "TenderLunListFiles/";
            string filePath = Server.MapPath(folderPath + "\\" + filename);

            fileUpload.SaveAs(filePath);

            DataTable dtEx = ImportTogrid(filePath, Extension, "Yes", hdTenderID);
            //  GrdEval.DataSource = dtEx;
            //  GrdEval.DataBind();
        }
        FillData();

    }

    private DataTable ImportTogrid(string FilePath, string Extension, string IsHDR, int TenderID)
    {
        string conStr = "";
        switch (Extension)
        {
            case ".xls": // Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;

                break;

            case ".xlsx": // Excel 07
                conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                break;

        }

        conStr = string.Format(conStr, FilePath, IsHDR);
        OleDbConnection connExcel = new OleDbConnection(conStr);
        OleDbCommand cmdExcel = new OleDbCommand();
        OleDbDataAdapter oda = new OleDbDataAdapter();

        DataTable dt = new DataTable();
        cmdExcel.Connection = connExcel;
        // get first Sheet

        connExcel.Open();

        DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
        connExcel.Close();

        // read data from first sheet
        connExcel.Open();
        cmdExcel.CommandText = "SELECT * FROM [" + sheetName + "]";

        oda.SelectCommand = cmdExcel;
        oda.Fill(dt);
        connExcel.Close();

        IList<TenderEval> ListTenderEval = new List<TenderEval>();
        TenderEval obTenderEval = null;
        foreach (DataRow dr in dt.Rows)
        {
            if (obTenderEval != null)
            {
                if (Convert.ToString(dr[0]) != "" && Convert.ToString(dr[1]) != "" && Convert.ToString(dr[2]) != "")
                {
                    TenderEval obTenderEvalNew = new TenderEval();

                    obTenderEvalNew.CompanyName = Convert.ToString(dr[1]);
                    obTenderEvalNew.TenderEvalID = TenderID;
                    obTenderEvalNew.Rank = Convert.ToString(dr[0]);
                    obTenderEvalNew.Rates = Convert.ToString(dr[2]);
                    obTenderEvalNew.GroupId = obTenderEval.GroupId;

                    //obTenderEvalNew.PrinterId = GetPrinterIDByName(Convert.ToString(dr[1]));

                    DataSet ds = new DataSet();

                    ds = GetGroupIDByName(obTenderEvalNew.GroupId, TenderID);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        obTenderEvalNew.GrpId = ds.Tables[0].Rows[0]["GrpID_I"].ToString();
                    }
                    else
                    {
                        obTenderEvalNew.GrpId = "0";
                    }

                    //ListTenderEval.Add(obTenderEvalNew);
                    if (obTenderEvalNew.GrpId == "0")
                    { }
                    else { 
                    SaveLunListExcel(obTenderEvalNew.CompanyName, double.Parse(obTenderEvalNew.Rates), obTenderEvalNew.Rank, (obTenderEvalNew.GroupId), obTenderEvalNew.TenderEvalID);
                    }
                    }

            }

            if (Convert.ToString(dr[0]) != "" && Convert.ToString(dr[1]) == "" && Convert.ToString(dr[2]) == "")
            {
                obTenderEval = new TenderEval();
                obTenderEval.GroupId = Convert.ToString(dr[0]).Replace(" --", "").Trim();
            }
        }
        //GrdEval.DataSource = ListTenderEval;
        //GrdEval.DataBind();
        //SetColor();
        ////Session["d"] = ListTenderEval;
        ///// BIND DATA TO GRIDVIEW
        ///// 
        //GrdEval.Caption = Path.GetFileName(FilePath);
        return dt;
    }
    public int SaveLunListExcel(string CompanyNM, double Rate, string Rank, string GrpId, int TendID)
    {
        int i = 0;
        obTenderDetails = new TenderDetails();

        try
        {
            obTenderDetails.CompanyName = CompanyNM;
            obTenderDetails.RateQuoated_N = Rate;
            obTenderDetails.Rank = Rank;
            obTenderDetails.TenderNo_V = GrpId;
            obTenderDetails.TenderId_I = TendID;
            i = obTenderDetails.LunListExcelDataSave();

        }

        catch (Exception ex) { }

        finally { obTenderDetails = null; }

        return i;


    }

    public DataSet GetGroupIDByName(string GroupName,int tENDERid)
    {
        DataSet ds = new DataSet();
        string GrpID = "0";
        obPriEval = new PRI_TenderEvaluation();
        try
        {
            obPriEval.NameofPress_V = GroupName;
            obPriEval.TenAllotid_I = tENDERid;
            ds = obPriEval.GetGrPID();

            if (ds.Tables[0].Rows.Count > 0)
            {
                GrpID = Convert.ToString(ds.Tables[0].Rows[0]["GrpID_I"]);

            }

        }

        catch (Exception ex) { }
        finally { obPriEval = null; }
        return ds;
    }

    class TenderEval
    {
        public string GroupId { get; set; }
        public string CompanyName { get; set; }
        public string Rates { get; set; }
        public string Rank { get; set; }
        public int TenderEvalID { get; set; }
        public string IsRegistered { get; set; }
        public string PrinterId { get; set; }
        public string GrpId { get; set; }


    }

   
    protected void btnSave0_Click(object sender, EventArgs e)
    {

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillData();
    }
   
}