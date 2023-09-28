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
public partial class Printing_PRI004_TenderEvaluation : System.Web.UI.Page
{
    APIProcedure objapi = new APIProcedure();

    PRI_TenderEvaluation obPriEval = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {

                if (Request.QueryString["TenderId"] != null)
                {

                    ImportTogridbytbl();
                }
                else
                {
                    Response.Redirect("TenderEvaluationDetails.aspx");
                }
     
            }
       
        catch {}

        finally{}
        }
    }


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
         //excel code
            //if (FileUploadExcel.HasFile)
            //{
            //    string filename = Path.GetFileName(FileUploadExcel.PostedFile.FileName);
            //    string Extension = Path.GetExtension(FileUploadExcel.PostedFile.FileName);

            //    string folderPath = ConfigurationManager.AppSettings["FolderPath"];

            //    string filePath = Server.MapPath(folderPath + filename);
            //    FileUploadExcel.SaveAs(filePath);

            //    DataTable dtEx = ImportTogrid(filePath, Extension, "Yes");

            //    //  GrdEval.DataSource = dtEx;
            //    //  GrdEval.DataBind();


            //}

            ImportTogridbytbl();
        }
        catch { }
        finally { }
    }


    public string  GetPrinterIDByName(string PrinterName) 
    {
        DataSet ds = new DataSet();
        string PriID = "0";
        obPriEval = new PRI_TenderEvaluation();
        try
        {
            obPriEval.NameofPress_V = PrinterName;
            ds = obPriEval.GetPriIDAndStatus();

            if (ds.Tables[0].Rows.Count > 0) 
            {
                PriID = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);

            }

        }

        catch (Exception ex) { }
        finally { obPriEval = null; }


        return PriID;
    }



    public DataSet GetGroupIDByName(string GroupName)
    {
        DataSet ds = new DataSet();
        string GrpID = "0";
        obPriEval = new PRI_TenderEvaluation();
        try
        {
            obPriEval.NameofPress_V = GroupName;
            //obPriEval.TenAllotid_I = tENDERid;
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
    public DataSet GetGroupIDByName1(string GroupName, int ID)
    {
        DataSet ds = new DataSet();
        string GrpID = "0";
        obPriEval = new PRI_TenderEvaluation();
        try
        {
            obPriEval.NameofPress_V = GroupName;
            obPriEval.TenAllotid_I = ID;
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


    private DataTable ImportTogrid(string FilePath, string Extension, string IsHDR)
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
                    obTenderEvalNew.TenderEvalID = Convert.ToString(Request.QueryString["TenderId"]);
                    obTenderEvalNew.Rank = Convert.ToString(dr[0]);
                    obTenderEvalNew.Rates = Convert.ToString(dr[2]);
                    obTenderEvalNew.GroupId = obTenderEval.GroupId;

                    obTenderEvalNew.PrinterId = GetPrinterIDByName(Convert.ToString(dr[1]));

                    DataSet ds = new DataSet();

                    ds = GetGroupIDByName(obTenderEvalNew.GroupId);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        obTenderEvalNew.GrpId = ds.Tables[0].Rows[0]["GrpID_I"].ToString();
                    }
                    else
                    {
                        obTenderEvalNew.GrpId = "0";
                    }

                    ListTenderEval.Add(obTenderEvalNew);
                }

            }

            if (Convert.ToString(dr[0]) != "" && Convert.ToString(dr[1]) == "" && Convert.ToString(dr[2]) == "")
            {
                obTenderEval = new TenderEval();
                obTenderEval.GroupId = Convert.ToString(dr[0]).Replace(" --", "").Trim();

            }

        }
        GrdEval.DataSource = ListTenderEval;
        GrdEval.DataBind();

        SetColor();
        //Session["d"] = ListTenderEval;
        /// BIND DATA TO GRIDVIEW
        /// 
        GrdEval.Caption = Path.GetFileName(FilePath);


        return dt;


    }


    private int ImportTogridbytbl()
    {
        
         IList<TenderEval> ListTenderEval = new List<TenderEval>();
        TenderEval obTenderEval = null;
         
        DataSet dr = new DataSet();
        obPriEval = new PRI_TenderEvaluation();

        //obPriEval.Tenderid_i = Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString());
        CommonFuction comm = new CommonFuction();
        //obDbaccess.execute("USP_LUNList", DBAccess.SQLType.IS_PROC);
        //obDbaccess.addParam("mtenderid", Tenderid_i);
        dr = comm.FillDatasetByProc("call USP_LUNList("+Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString())+")");

        for (int i = 0; i < dr.Tables[0].Rows.Count;i++ )
        {
             
                
                    TenderEval obTenderEvalNew = new TenderEval();

                    obTenderEvalNew.CompanyName = Convert.ToString(dr.Tables[0].Rows[i]["Company"]  );
                    obTenderEvalNew.TenderEvalID = Convert.ToString(Request.QueryString["TenderId"]);
                    obTenderEvalNew.Rank = Convert.ToString(dr.Tables[0].Rows[i]["Rank"]);
                    obTenderEvalNew.Rates = Convert.ToString(dr.Tables[0].Rows[i]["Rates"]);
                    obTenderEvalNew.GroupId = Convert.ToString(dr.Tables[0].Rows[i]["GroupNo"]); 
            //obTenderEval.GroupId;

                    obTenderEvalNew.PrinterId = GetPrinterIDByName(Convert.ToString(obTenderEvalNew.CompanyName));

                    DataSet ds = new DataSet();

                    ds = GetGroupIDByName(obTenderEvalNew.GroupId);

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        obTenderEvalNew.GrpId = ds.Tables[0].Rows[0]["GrpID_I"].ToString();
                    }
                    else
                    {
                        obTenderEvalNew.GrpId = "0";
                    }
                    ListTenderEval.Add(obTenderEvalNew);

             



        }
        GrdEval.DataSource = ListTenderEval;
        GrdEval.DataBind();
       
        
        SetColor();
        //Session["d"] = ListTenderEval;
        /// BIND DATA TO GRIDVIEW
        /// 
       // GrdEval.Caption = Path.GetFileName(FilePath);


     //   return dt;
        return 0;

    }
    public void SetColor()
    {
        foreach (GridViewRow grdrow in GrdEval.Rows)
        {

            if (((HiddenField)grdrow.Cells[0].FindControl("HdnPriId")).Value == "0")
            {
                grdrow.Cells[2].BackColor = System.Drawing.Color.FromName("#DD5A5A");

                grdrow.Cells[2].ForeColor = System.Drawing.Color.White;
                

                ((CheckBox)grdrow.Cells[0].FindControl("chk")).Enabled = false;

                ((HyperLink)grdrow.Cells[0].FindControl("hypPRIReg")).Visible = true;

                ((HyperLink)grdrow.Cells[0].FindControl("hypPRIReg")).NavigateUrl = "PRI001_PrinterRegistration.aspx";


            }
            else
                if (((HiddenField)grdrow.Cells[0].FindControl("HdnPriId")).Value != "0")
                {
                    grdrow.Cells[2].BackColor = System.Drawing.Color.FromName("#6CC34E");

                    grdrow.Cells[2].ForeColor = System.Drawing.Color.White;
                   
                    ((CheckBox)grdrow.Cells[0].FindControl("chk")).Enabled = true;
                    ((HyperLink)grdrow.Cells[0].FindControl("hypPRIReg")).Visible = false;


                }

        }
    }


    public int SaveTenEvalMaster(int TenEvId, int TenId, int GrpId, string LOINo)
    {
        int i = 0;
        obPriEval = new PRI_TenderEvaluation();

        try
        {
            obPriEval.Tenevalid_i = TenEvId;
            obPriEval.Tenderid_i = TenId;
            obPriEval.GrPID_i = GrpId;
            obPriEval.LOINo_V = LOINo;
            i = obPriEval.TenderEvalMasterSave();

        }

        catch (Exception ex) { }

        finally { obPriEval = null; }

        return i;


    }


    public int SaveTenEvalDetails(int TenEvId, int TenId, int GrpId, int TenEvDet, double Rate, int PriId)
    {
        int i = 0;
        obPriEval = new PRI_TenderEvaluation();

        try
        {
            obPriEval.Tenevalid_i = TenEvId;
            
            obPriEval.GrPID_i = GrpId;
            obPriEval.Ratequoated_n = Rate;
            obPriEval.TenEvalDetID_I = TenEvDet;
            obPriEval.Printerid_i = PriId;

            i = obPriEval.TenderEvalDetailSave();

        }

        catch (Exception ex) { }

        finally { obPriEval = null; }

        return i;


    }


    public int SaveTenAllotment(int tenAllotId, int TenEvId, int TenId, int GrpId, int isallot, double Rate, int PriId)
    {
        int i = 0;
        obPriEval = new PRI_TenderEvaluation();

        try
        {
            obPriEval.TenAllotid_I = tenAllotId;
            obPriEval.Tenevalid_i = TenEvId;
            obPriEval.Tenderid_i = TenId;
            obPriEval.GrPID_i = GrpId;
            obPriEval.Printerid_i = PriId;
            obPriEval.Ratequoated_n = Rate;
            obPriEval.isALLOTED = isallot;
            obPriEval.isPrinter = PriId;


            i = obPriEval.TenderAllotmentSave();

        }

        catch (Exception ex) { }

        finally { obPriEval = null; }

        return i;


    }




    protected void btnSave_Click(object sender, EventArgs e) 
    {
        try
        {

            foreach (GridViewRow grdrow in GridView1.Rows)
            {

                if (((CheckBox)grdrow.Cells[0].FindControl("chk")).Checked == true)
                {
                    int TEval = 0;
                    int TEvalDet = 0;
                    int TENId = 0;
                    int GRPId = 0;
                    int PriId = 0;
                    int TenAlloID = 0;
                    int isAll = 1;
                    double Rate = 0;

                    string LOINo = ""; string GroupName = "";
                    APIProcedure objapi = new APIProcedure();

                    TENId = Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString());

                    //GRPId = Convert.ToInt32(((HiddenField)grdrow.Cells[0].FindControl("HDNGRPID")).Value);
                    PriId =Convert.ToInt32(HiddenField1.Value);
                    Rate =Convert.ToDouble(grdrow.Cells[3].Text) ;
                   // GroupName = Convert.ToString(((HiddenField)grdrow.Cells[1].FindControl("HdnGroupName")).Value);
                    GroupName = grdrow.Cells[1].Text;
                    isAll = 1;
                    try { 
                    CommonFuction comm = new CommonFuction();
                 DataSet dd=comm.FillDatasetByProc("call USP_PRI010_GroupIDGetByGrpName('" + GroupName + "'," + TENId + ")");
                    //Convert.ToString(((HiddenField)grdrow.Cells[0].FindControl("HDNRank")).Value) == "L1" ? 1 : 0;
                 GRPId = Convert.ToInt32(dd.Tables[0].Rows[0]["GrpID_I"]);
                    }
                    catch { }
                    TEval = SaveTenEvalMaster(TEval, TENId, GRPId, LOINo);

                    if (TEval != 0)
                    {

                        DataSet ds = new DataSet();

                        ds = GetGroupIDByName1(GroupName, TENId);
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                SaveTenEvalDetails(TEval, TENId, Convert.ToInt32(ds.Tables[0].Rows[i]["GrpID_I"]), TEvalDet, Rate, PriId);

                                SaveTenAllotment(TenAlloID, TEval, TENId, Convert.ToInt32(ds.Tables[0].Rows[i]["GrpID_I"]), isAll, Rate, PriId);
                            }
                        }
                    }
                }


            }
            ImportTogridbytbl();
        }
        catch { message("जानकारी चेक करे  |", "ERROR+"); }
        finally {
            message("जानकारी सेव हो गई  |", "");
            //Response.Redirect("VIEW_TenderDetails.aspx");
        }
        

        
           
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
        public string GroupId {get;set;}
        public string CompanyName { get; set; }
        public string Rates { get; set; }
        public string Rank { get; set; }
        public string TenderEvalID { get; set; }
        public string IsRegistered { get; set; }
        public string PrinterId { get; set; }
        public string GrpId { get; set; }

    
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        CommonFuction obCommonFuction = new CommonFuction();
        Button bt = (Button)sender;
        GridViewRow grdrow = (GridViewRow)bt.NamingContainer;
        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");
        CommonFuction comm = new CommonFuction();
        //HdnPriId

       HiddenField1.Value = ((HiddenField)grdrow.FindControl("HdnPriId")).Value;
        DataSet dd = comm.FillDatasetByProc("call GetLunListbyCompany(" + Convert.ToInt32(objapi.Decrypt(Request.QueryString["TenderId"]).ToString()) + ",'" + bt.CommandArgument + "','" + obCommonFuction.GetFinYear() + "')");
        GridView1.DataSource =dd.Tables[0];
        GridView1.DataBind ();
        Label1.Text = "";
        //call USP_PrinterGroupValidationforLUN ('2016-2017',76,'Four');
    }
    protected void chkChoose_CheckedChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        CommonFuction obCommonFuction = new CommonFuction();
        double TotalPrinterCa = 0; double Printer=0;
        double TotalEmd = 0; 
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            try { 
            DataSet dd = obCommonFuction.FillDatasetByProc("call USP_PrinterGroupValidationforLUN ('" + obCommonFuction.GetFinYear() + "'," + HiddenField1.Value + ",'" + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField3")).Value + "')");

            Printer = Convert.ToDouble(dd.Tables[0].Rows[0]["fourcolor"].ToString()) * 0.1 + (Convert.ToDouble(dd.Tables[0].Rows[0]["fourcolor"].ToString()));
            }
            catch { }
            if (((CheckBox)GridView1.Rows[i].FindControl("chk")).Checked == true)
            {
                TotalPrinterCa = TotalPrinterCa + Convert.ToDouble(((HiddenField)GridView1.Rows[i].FindControl("HiddenField2")).Value);
                TotalEmd = TotalEmd + Convert.ToDouble(Convert.ToDouble(GridView1.Rows[i].Cells[6].Text));
                try
                {
                    TextBox1.Text = TotalPrinterCa.ToString();
                    TextBox3.Text = TotalEmd.ToString();
                  
                    if (Convert.ToDouble(TextBox1.Text)>Convert.ToDouble(Printer) )
                     {
                         Label1.Text = "प्रिंटर  की शेष कैपेसिटी ग्रुप के कैपेसिटी से कम है  ";
                         ((CheckBox)GridView1.Rows[i].FindControl("chk")).Checked = false;
                         TotalPrinterCa = TotalPrinterCa - Convert.ToDouble(((HiddenField)GridView1.Rows[i].FindControl("HiddenField2")).Value);
                         TextBox1.Text = TotalPrinterCa.ToString();
                         TotalEmd = TotalEmd - Convert.ToDouble(Convert.ToDouble(GridView1.Rows[i].Cells[6].Text));
                         TextBox3.Text = TotalEmd.ToString();
                       // Printer = Printer - Convert.ToDouble(Printer);
                     }else {
                       
                     }
                   
                }
                catch { }
            }
            

        }

        
        TextBox2.Text = Printer.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
         
     }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("VIEW_TenderDetails.aspx");
         
     }
   
}