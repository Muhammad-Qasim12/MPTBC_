using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using MPTBCBussinessLayer;
using System.Globalization;
public partial class TenderGroupReAallocation : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PrinterRegistration obPRI_PrinterRegistration = null;
    PRI_TenderEvaluation_New obPriEval = null;
    CommonFuction obCommonFuction = new CommonFuction();
    DataSet dsGrid = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            FillPrinter();
            FillToPrinter();
        }
    }

    public void FillPrinter()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            ddlPrinter.DataTextField = "NameofPress_V";
            ddlPrinter.DataValueField = "Printer_RedID_I";
            ddlPrinter.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlPrinter.DataBind();
            ddlPrinter.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }

    public void FillToPrinter()
    {
        obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        try
        {
            ddlToPrinter.DataTextField = "NameofPress_V";
            ddlToPrinter.DataValueField = "Printer_RedID_I";
            ddlToPrinter.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
            ddlToPrinter.DataBind();
            ddlToPrinter.Items.Insert(0, new ListItem("Select", "0"));
        }
        catch (Exception ex) { }
        finally { obPRI_PrinterRegistration = null; }
    }



    public void FillTitle()
    {
        ddlTital.Items.Clear();
        DataSet asdf = obCommonFuction.FillDatasetByProc("call USP_Titleallottoprint('" + DdlACYear.SelectedItem.Text + "','" + ddlPrinter.SelectedValue + "')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("Select", "0"));
        btnSave.Visible = false;
    }

    public void FillGrid()
    {
        GrdEval.DataSource = null;
        //dsGrid = obCommonFuction.FillDatasetByProc("call USP_Titleallottoprint_Update('" + ddlTital.SelectedValue + "','" + DdlACYear.SelectedItem.Text + "')");
        //if (dsGrid.Tables[0].Rows.Count > 0)
        //{
        //    checkForUpdate = 1;
        //    GrdEval.DataSource = dsGrid;
        //    GrdEval.DataBind();
        //    fillGridDataForUpdate();
        //    btnSave.Text = "अपडेट/Update";
        //    btnSave.Visible = true;
        //}
        //else
        //{
        dsGrid = obCommonFuction.FillDatasetByProc("call USP_Titleallottoprint_Load('" + ddlTital.SelectedValue + "','" + ddlPrinter.SelectedValue + "','" + DdlACYear.SelectedItem.Text + "','" + ddlToPrinter.SelectedValue + "')");
        if (dsGrid.Tables[0].Rows.Count > 0)
        {
            GrdEval.DataSource = dsGrid;
            GrdEval.DataBind();
            fillGridDataForUpdate();
            btnSave.Visible = true;
        }
        else
        {
            GrdEval.DataSource = null;
            GrdEval.DataBind();
            btnSave.Visible = false;
        }
        //}
    }

    public void fillGridDataForUpdate()
    {
        try
        {
            for (int i = 0; i <= GrdEval.Rows.Count - 1; i++)
            {
                // DropDownList ddlPrinter = (DropDownList)GrdEval.Rows[i].FindControl("ddlPrinter");
                // ddlPrinter.SelectedValue = dsGrid.Tables[0].Rows[i]["printerid_i"].ToString();

                DropDownList ddlYojna = (DropDownList)GrdEval.Rows[i].FindControl("ddlYojna");
                ddlYojna.SelectedValue = dsGrid.Tables[0].Rows[i]["BookType"].ToString();
            }
        }
        catch { }
    }

    protected void ddlPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        GrdEval.DataSource = null;
        GrdEval.DataBind();
        btnSave.Visible = false;
        FillTitle();
    }

    protected void ddlTital_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DdlACYear.SelectedIndex >= 0 && ddlPrinter.SelectedIndex > 0 && ddlTital.SelectedIndex > 0)
        {
            FillGrid();
        }
        else
        {
            message("ईयर, प्रिंटर, टाइटल सेलेक्ट करें  |", "");
        }
    }

    public int SaveTenAllotment(int optType, int key, int TenId, int GrpId,
        int TitleId, int DepoId, int PriId, double Rate, DateTime AllotDate,
        string AcYear, int PrinterIdFrom, int BookTypeId, int AllottedBooks)
    {
        int i = 0;
        obPriEval = new PRI_TenderEvaluation_New();

        //try
        //{
        obPriEval.optType = optType;
        obPriEval.Key = key;
        obPriEval.Tenderid_i = TenId;
        obPriEval.GrPID_i = GrpId;
        obPriEval.TitleId = TitleId;
        obPriEval.DepoId = DepoId;
        obPriEval.Printerid_i = PriId;
        obPriEval.Ratequoated_n = Rate;
        obPriEval.AllotDate = AllotDate;
        obPriEval.AcYear = AcYear;

        obPriEval.PrinteridFrom = PrinterIdFrom;
        obPriEval.BookTypeId = BookTypeId;
        obPriEval.AllotedBook = AllottedBooks;

        i = obPriEval.TenderReAllotmentSave();
        //}

        //catch (Exception ex) { }

        //finally { obPriEval = null; }

        return i;


    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //try
        //{
        int key = 0, optType = 0;
        int printerIDFrom = Convert.ToInt32(ddlPrinter.SelectedValue);
        foreach (GridViewRow grdrow in GrdEval.Rows)
        {
            int reTenAllotId = 0, tenderID = 0, grpID = 0, titleID = 0, depoID = 0, printerID = 0; double rate = 0;
            DateTime allotDt = new DateTime();
            string dateChk = "";

            printerID = Convert.ToInt32(ddlToPrinter.SelectedValue);
            // Convert.ToInt32(((DropDownList)grdrow.Cells[0].FindControl("ddlPrinter")).SelectedValue);
            rate = Convert.ToDouble(((TextBox)grdrow.Cells[0].FindControl("txtRate")).Text);
            dateChk = ((TextBox)grdrow.Cells[0].FindControl("txtDate")).Text;
            int bookTypeId = 0; int allotedBooks = 0;

            reTenAllotId = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("tenreallotid_i")).Value);

            if (((CheckBox)grdrow.Cells[0].FindControl("chk")).Checked == true)
            {
                if (printerID > 0 && ddlTital.SelectedIndex > 0 && rate > 0 && dateChk != "" && DdlACYear.SelectedItem.Text.Length > 0)
                {
                    var aa = Convert.ToDateTime(((TextBox)grdrow.Cells[0].FindControl("txtDate")).Text, cult).ToString("yyyy/MM/dd");
                    allotDt = Convert.ToDateTime(aa);
                    tenderID = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("HndTenderid")).Value);
                    grpID = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("HndGrpid_i")).Value);
                    titleID = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("HndTitleid")).Value);
                    depoID = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("HdnDepoID")).Value);
                    bookTypeId = Convert.ToInt32(((DropDownList)grdrow.Cells[0].FindControl("ddlYojna")).SelectedValue);
                    allotedBooks = Convert.ToInt32(((TextBox)grdrow.Cells[0].FindControl("txtQty")).Text);

                    if (reTenAllotId == 0)
                    {
                        key = 0; optType = 0;
                        APIProcedure objapi = new APIProcedure();

                        int a = SaveTenAllotment(optType, key, tenderID, grpID, titleID,
                            depoID, printerID, rate,
                            allotDt, DdlACYear.SelectedItem.Text, printerIDFrom,
                            bookTypeId, allotedBooks);

                    }
                    else
                    {
                        key = reTenAllotId; optType = 1;
                        allotDt = Convert.ToDateTime(((TextBox)grdrow.Cells[0].FindControl("txtDate")).Text, cult);
                        int a = SaveTenAllotment(optType, key, tenderID, grpID,
                            titleID, depoID, printerID, rate, allotDt,
                            DdlACYear.SelectedItem.Text, printerIDFrom,
                            bookTypeId, allotedBooks);

                    }
                }
                else
                {
                    message("ईयर, प्रिंटर, टाइटल, रेट, दिनांक सेलेक्ट करें  |", "");
                    return;
                }
            }
            else
            {
                if (reTenAllotId == 0 && printerID != 0)
                {
                    message("ईयर, प्रिंटर, टाइटल, रेट, दिनांक सेलेक्ट करें  |", "");
                    // return;
                }
                else if (reTenAllotId != 0)
                {
                    key = reTenAllotId; optType = 2;
                    allotDt = Convert.ToDateTime(((TextBox)grdrow.Cells[0].FindControl("txtDate")).Text, cult);
                    int a = SaveTenAllotment(optType, key, tenderID, grpID,
                        titleID, depoID, printerID, rate, allotDt,
                        DdlACYear.SelectedItem.Text, printerIDFrom,
                            bookTypeId, allotedBooks);
                }
            }
        }
        Response.Redirect("PRI001_Group_ReAllocation.aspx");
        // }

        //catch { message("जानकारी चेक करे  |", "ERROR+"); }
        //finally
        //{
        //    // message("जानकारी सेव हो गई  |", "");
        //    //Response.Redirect("PRI001_Group_ReAllocation.aspx");
        //}
    }

    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }

    class TenderEval
    {
        public string GroupId { get; set; }
        public string CompanyName { get; set; }
        public string Rates { get; set; }
        public string Rank { get; set; }
        public string TenderEvalID { get; set; }
        public string IsRegistered { get; set; }
        public string PrinterId { get; set; }
        public string GrpId { get; set; }


    }

    protected void GrdEval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //obPRI_PrinterRegistration = new PRI_PrinterRegistration();
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DropDownList ddlPrinters = (DropDownList)e.Row.FindControl("ddlPrinter");
        //    try
        //    {
        //        ddlPrinters.DataSource = obPRI_PrinterRegistration.PrinterRegistrationLoad();
        //        ddlPrinters.DataTextField = "NameofPress_V";
        //        ddlPrinters.DataValueField = "Printer_RedID_I";               
        //        ddlPrinters.DataBind();
        //        ddlPrinters.Items.Insert(0, new ListItem("Select", "0"));


        //    }
        //    catch (Exception ex) { }
        //    finally { obPRI_PrinterRegistration = null; }
        //}
    }
    //protected void chkAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox ChkBoxHeader = (CheckBox)GrdEval.HeaderRow.FindControl("chkAll");
    //    foreach (GridViewRow row in GrdEval.Rows)
    //    {
    //        CheckBox ChkBoxRows = (CheckBox)row.FindControl("chk");
    //        if (ChkBoxHeader.Checked == true)
    //        {
    //            ChkBoxRows.Checked = true;
    //        }
    //        else
    //        {
    //            ChkBoxRows.Checked = false;
    //        }
    //    }
    //}


    public class PRI_TenderEvaluation_New
    {

        string _NameofPress_V,
               _LOINo_V;

        int
                _TenEvalDetID_I,
                _TenAllotid_I,
                _Tenevalid_i,
                _Tenderid_i,
                _GrPID_i,
                _Printerid_i,

                _isALLOTED,
                _isPrinter;

        double _Ratequoated_n;





        public string NameofPress_V { get { return _NameofPress_V; } set { _NameofPress_V = value; } }
        public string LOINo_V { get { return _LOINo_V; } set { _LOINo_V = value; } }

        public int TenEvalDetID_I { get { return _TenEvalDetID_I; } set { _TenEvalDetID_I = value; } }
        public int TenAllotid_I { get { return _TenAllotid_I; } set { _TenAllotid_I = value; } }
        public int Tenevalid_i { get { return _Tenevalid_i; } set { _Tenevalid_i = value; } }
        public int Tenderid_i { get { return _Tenderid_i; } set { _Tenderid_i = value; } }
        public int GrPID_i { get { return _GrPID_i; } set { _GrPID_i = value; } }
        public int Printerid_i { get { return _Printerid_i; } set { _Printerid_i = value; } }
        public int isALLOTED { get { return _isALLOTED; } set { _isALLOTED = value; } }
        public int isPrinter { get { return _isPrinter; } set { _isPrinter = value; } }

        public double Ratequoated_n { get { return _Ratequoated_n; } set { _Ratequoated_n = value; } }


        public int optType { get; set; }
        public int Key { get; set; }
        public DateTime AllotDate { get; set; }
        public int DepoId { get; set; }
        public int TitleId { get; set; }
        public string AcYear { get; set; }
        public int PrinteridFrom { get; set; }
        public int BookTypeId { get; set; }
        public int AllotedBook { get; set; }

        public int TenderReAllotmentSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            //  try
            //   {
            obDbaccess.execute("USP_PRI010_TenderReAlloteSave", DBAccess.SQLType.IS_PROC);
            obDbaccess.addParam("mOpt", optType);
            obDbaccess.addParam("mKey", Key);
            obDbaccess.addParam("mTenderid_i", Tenderid_i);
            obDbaccess.addParam("mGrPID_i", GrPID_i);
            obDbaccess.addParam("mTitleid_i", TitleId);
            obDbaccess.addParam("mDepoid_i", DepoId);
            obDbaccess.addParam("mPrinterid_i", Printerid_i);
            obDbaccess.addParam("mRatequoated_n", Ratequoated_n);
            obDbaccess.addParam("mAllotDate", AllotDate);
            obDbaccess.addParam("mAcyear", AcYear);

            obDbaccess.addParam("mPrinteridFrom", PrinteridFrom);
            obDbaccess.addParam("mBookType", BookTypeId);
            obDbaccess.addParam("mAllotedBook", AllotedBook);

            i = obDbaccess.executeMyQuery();
            //   }
            //  catch (Exception ex) { }
            //   finally { obDbaccess = null; }
            return i;
        }





        public int TenderEvalMasterSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TEnderEvalMasterSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenEvalID_I", Tenevalid_i);
                obDbaccess.addParam("mTenderID_I", Tenderid_i);
                obDbaccess.addParam("mGRPID_I", GrPID_i);
                obDbaccess.addParam("mLOINo_V", LOINo_V);

                i = Convert.ToInt32(obDbaccess.executeMyScalar());

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }



        public int TenderEvalDetailSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TenderEvalDetailsSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenEvalDetID_I", TenEvalDetID_I);
                obDbaccess.addParam("mTenEvalID_I", Tenevalid_i);
                obDbaccess.addParam("mGRPID_I", GrPID_i);
                obDbaccess.addParam("mPrinterID_I", Printerid_i);
                obDbaccess.addParam("mRateQuoated_N", Ratequoated_n);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }

        public int TenderAllotmentSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_PRI010_TenderAlloteSave", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenAllotid_I", TenAllotid_I);
                obDbaccess.addParam("mTenevalid_i", Tenevalid_i);
                obDbaccess.addParam("mTenderid_i", Tenderid_i);
                obDbaccess.addParam("mGrPID_i", GrPID_i);
                obDbaccess.addParam("mPrinterid_i", Printerid_i);
                obDbaccess.addParam("mRatequoated_n", Ratequoated_n);
                obDbaccess.addParam("misALLOTED", isALLOTED);
                obDbaccess.addParam("misPrinter", isPrinter);

                i = obDbaccess.executeMyQuery();

            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return i;
        }


        //#region ICommon Members

        //public int InsertUpdate()
        //{
        //    throw new NotImplementedException();
        //}

        //public DataSet Select()
        //{
        //    throw new NotImplementedException();
        //}

        //public int Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //#endregion
    }

    protected void ddlToPrinter_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
        btnSave.Visible = true;
        // FillTitle();
    }
}

