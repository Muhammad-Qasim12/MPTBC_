using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.AcademicB;
using System.Data;
using System.Globalization;

public partial class AcademicB_OrderAgreementInfo : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    WorkOrderDetails obWorkOrderDetails = null;
    CommonFuction obCommonFuction = null;
    DataSet dt = new DataSet();
    APIProcedure objApi = new APIProcedure();
    int? isAgreement = null;
    string ArgNo = null, PrintSecurityDetail = null, PaperSecurityDetail = null, JobCode = null, LOINo = null, PBGNo = null;
    Decimal? PrintSecurityAmount = null, PaperSecurityAmount = null;
    DateTime? ArgDate = null, TransDate = null, LOIDate = null, PBGdate = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                CommonFuction obCommonFuction = new CommonFuction();
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

                ViewState["WorkorderFilePath_V"] = "";
                obWorkOrderDetails = new WorkOrderDetails();
                ddlTenderID_I.DataSource = obWorkOrderDetails.PrinterAlldetails(0, 0, 0);
                ddlTenderID_I.DataTextField = "TenderNo_V";
                ddlTenderID_I.DataValueField = "TenderId_I";
                ddlTenderID_I.DataBind();
                ddlTenderID_I.Items.Insert(0, "Select");
                if (Request.QueryString["ID"] != null)
                {
                    showdata(new APIProcedure().Decrypt(Request.QueryString[ID]));
                }

            }
            catch { }
            finally { obWorkOrderDetails = null; }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["WorkorderID_I"] = 0;
        try
        {
            string ImgStatus = ""; string filename = "";
            obWorkOrderDetails = new WorkOrderDetails();
            if (FileUpload1.FileName == "")
            {
                ImgStatus = "Ok";
                obWorkOrderDetails.WorkorderFilePath_V = ViewState["WorkorderFilePath_V"].ToString();
            }
            else
            {
                ImgStatus = objApi.uploadFile(FileUpload1, "PrintingFile", 1000);
                if (ImgStatus == "Ok")
                {
                    filename = objApi.FullFileName;
                    obWorkOrderDetails.WorkorderFilePath_V = "PrintingFile/" + filename;
                }
            }

            if (ImgStatus == "Ok")
            {
                lblMsg.Text = "";
                obWorkOrderDetails.TenderID_I = Convert.ToInt32(ddlTenderID_I.SelectedValue);
                obWorkOrderDetails.Printer_regid_i = Convert.ToInt32(ddlPrinter_regid_i.SelectedValue);
                obWorkOrderDetails.WorkorderNo_V = Convert.ToString(txtWorkorderNo_V.Text);
               // obWorkOrderDetails.WorkOrderDate_D = DateTime.ParseExact(txtWODate_D.Text, "dd/MM/yyyy", null);
                //obWorkOrderDetails.WorkOrderDate_D = DateTime.ParseExact("2017-10-01","yyyy-MM-dd", null); 
                obWorkOrderDetails.WorkOrderDate_D = Convert.ToDateTime(txtWODate_D.Text, cult);  
                //Convert.ToDateTime(System.DateTime.Now, cult);
                obWorkOrderDetails.PBGNo_V = "";// Convert.ToString(txtPBGNo_V.Text);
                obWorkOrderDetails.PBGdate_D = System.DateTime.Now;
                obWorkOrderDetails.LOINo_V = Convert.ToString(txtLOINo_V.Text);
                obWorkOrderDetails.LOIDate_D = DateTime.ParseExact(txtLOIDate_D.Text, "dd/MM/yyyy", null);
                 //obWorkOrderDetails.LOIDate_D = DateTime.ParseExact("2017-09-01", "yyyy-MM-dd", null); 
               // obWorkOrderDetails.LOIDate_D = Convert.ToDateTime(txtLOIDate_D.Text, cult);
                obWorkOrderDetails.Userid_I = Convert.ToInt32(Session["UserID_I"]);
                obWorkOrderDetails.Finyear = Convert.ToString(DdlACYear.SelectedValue);
                obWorkOrderDetails.Transdate_D = System.DateTime.Now;
                obWorkOrderDetails.ArgDate_D = System.DateTime.Now;
                if (HiddenField1.Value == "")
                {

                }

                if (Request.QueryString["ID"] != null)
                {
                    obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
                }
                else
                {
                    obWorkOrderDetails.WorkorderID_I = 0;
                    obWorkOrderDetails.isAgreement_I = 0;
                }
                try {
              int dss = obWorkOrderDetails.InsertUpdate();
                }
                catch { }
                CommonFuction comm = new CommonFuction();
                DataSet dt = comm.FillDatasetByProc("select max(WorkorderID_I)WorkorderID_I from acb_workorder_agreement_t where TenderID_I=" + ddlTenderID_I.SelectedValue + "");
                int LID = Convert.ToInt32(dt.Tables[0].Rows[0]["WorkorderID_I"].ToString());
              //  DataSet dt = comm.FillDatasetByProc("call USP_ACB007_WorkOrderDetailsSave(0,'"+txtWorkorderNo_V.Text+"','"+Convert.ToDateTime()+"')");
                //(`mWorkorderID_I` INT(10), `mTenderID_I` INT(10), `mWorkorderNo_V` VARCHAR(20), `mWorkOrderDate_D` VARCHAR(50), `mPBGNo_V` VARCHAR(20), `mPBGdate_D` VARCHAR(50), `mWorkorderFilePath_V` VARCHAR(50), `misAgreement_I` INT(10), `mArgDate_D` VARCHAR(50), `mArgNo_V` VARCHAR(20), `mPrintSecurityAmount_N` DECIMAL(18,2), `mPrintSecurityDetail_V` VARCHAR(20), `mPaperSecurityAmount_N` DECIMAL(18,2), `mPaperSecurityDetail_V` VARCHAR(20), `mJobCode_V` VARCHAR(20), `mPrinter_regid_i` INT(10), `mUserid_I` INT(10), `mTransDate_D` DATETIME, `mLOINo_V` VARCHAR(25), `mLOIDate_D` VARCHAR(50), OUT `LID` INT(10))

                if (Request.QueryString["ID"] == null)
                {


                    int i = 0;
                    foreach (GridViewRow gv in GrdGroupDetails.Rows)
                    {
                        //CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
                        Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
                        int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
                        obWorkOrderDetails.WorkOrderDetID_I = i;
                        i++;
                        obWorkOrderDetails.WorkorderID_I = LID;
                        obWorkOrderDetails.GRPID_I = hd2;
                        obWorkOrderDetails.InsertGroup();
                    }
                }
                //else if (Request.QueryString["ID"] != null)
                //{
                //    int i = 0;
                //    foreach (GridViewRow gv in GrdGroupDetails.Rows)
                //    {
                //        Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
                //        int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
                //        obWorkOrderDetails.WorkOrderDetID_I = i;
                //        i++;
                //        obWorkOrderDetails.WorkorderID_I = LID;
                //        obWorkOrderDetails.GRPID_I = hd2;
                //        obWorkOrderDetails.InsertGroup();
                //    }
                //}
                obCommonFuction = new CommonFuction();
                obCommonFuction.EmptyTextBoxes(this);
                HiddenField1.Value = "";
                //Response.Redirect("View_ACB_007.aspx");

                Response.Redirect("ViewOrderAgreementInfo.aspx",false);
            }
            else
            {
                lblMsg.Text = ImgStatus.ToString();
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
        catch { }
        finally
        {
            obWorkOrderDetails = null;
        }
    }
    public void ddlPrinterAlldetails(int intTenderID_I)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        ddlPrinter_regid_i.DataSource = obWorkOrderDetails.PrinterAlldetails(1, Convert.ToInt32(ddlTenderID_I.SelectedValue), 0);
        ddlPrinter_regid_i.DataTextField = "NameofPress_V";
        ddlPrinter_regid_i.DataValueField = "Printer_RedID_I";
        ddlPrinter_regid_i.DataBind();
        ddlPrinter_regid_i.Items.Insert(0, "Select");
    }

    public void GRDGroupAlldetails(int intTenderID_I, int intPrinterID)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        var data = obWorkOrderDetails.PrinterAlldetails(2, Convert.ToInt32(intTenderID_I), Convert.ToInt32(intPrinterID));
        GrdGroupDetails.DataSource = data;
        GrdGroupDetails.DataBind();
    }

    public void showdata(string ID)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(new APIProcedure().Decrypt(Request.QueryString["ID"]));
        DataSet obDataSet = obWorkOrderDetails.Select();

        ddlTenderID_I.ClearSelection();
        ddlTenderID_I.Items.FindByValue(obDataSet.Tables[0].Rows[0]["TenderID_I"].ToString()).Selected = true;


        ddlPrinterAlldetails(Convert.ToInt32(ddlTenderID_I.SelectedValue));
        ddlPrinter_regid_i.ClearSelection();
        ddlPrinter_regid_i.Items.FindByValue(obDataSet.Tables[0].Rows[0]["Printer_regid_i"].ToString()).Selected = true;
        txtWorkorderNo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["WorkorderNo_V"]);
        txtLOINo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["LOINo_V"]);
        txtLOIDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["LOIDate_D"]).ToString("dd/MM/yyyy");
        txtWODate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["WORKOrderDate_D"]).ToString("dd/MM/yyyy");
        ViewState["WorkorderFilePath_V"] = obDataSet.Tables[0].Rows[0]["WorkorderFilePath_V"].ToString();
        ddlTenderID_I.Enabled = false;
        ddlPrinter_regid_i.Enabled = false;

        DdlACYear.Items.FindByValue(obDataSet.Tables[0].Rows[0]["acyear"].ToString()).Selected = true;

        GRDGroupAlldetails(Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue));
        HiddenField1.Value = (new APIProcedure().Decrypt(Request.QueryString["ID"]));
        // HiddenField3.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["WorkOrderDetID_I"]);

    }

    protected void GrdGroupDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (Request.QueryString["ID"] != "")
            {
                //obWorkOrderDetails = new WorkOrderDetails();
                // obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(Request.QueryString["ID"]);
                // DataSet obDataSet = obWorkOrderDetails.ViewGroup();

                //if (Convert.ToInt32(Request.QueryString["ID"]) != 0)
                //{
                // //   CheckBox chkGroup = (CheckBox)e.Row.FindControl("chkGroup");
                //    Label lblGroupNO_V = (Label)e.Row.FindControl("lblGroupNO_V");
                //    int hd = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField2")).Value);
                //    for (int i = 0; i < obDataSet.Tables[0].Rows.Count; i++)
                //    {
                //        if (hd == Convert.ToInt32(obDataSet.Tables[0].Rows[i]["GRPID_I"]))
                //        {
                //            chkGroup.Checked = true;
                //        }
                //    }
                //}
            }
        }
    }

    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTenderID_I.SelectedItem.Text != "Select")
        {
            obWorkOrderDetails = new WorkOrderDetails();
            ddlPrinter_regid_i.DataSource = obWorkOrderDetails.PrinterAlldetails(1, Convert.ToInt32(ddlTenderID_I.SelectedValue), 0);
            ddlPrinter_regid_i.DataTextField = "NameofPress_V";
            ddlPrinter_regid_i.DataValueField = "Printer_RedID_I";
            ddlPrinter_regid_i.DataBind();
            ddlPrinter_regid_i.Items.Insert(0, "Select");
        }
    }

    protected void ddlPrinter_regid_i_SelectedIndexChanged(object sender, EventArgs e)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        GrdGroupDetails.DataSource = obWorkOrderDetails.PrinterAlldetails(2, Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue));
        GrdGroupDetails.DataBind();
    }
    protected void ddlPrinter_regid_i_Init(object sender, EventArgs e)
    {
        ddlPrinter_regid_i.DataSource = string.Empty;
        ddlPrinter_regid_i.DataBind();
        ddlPrinter_regid_i.Items.Insert(0, "Select");
    }


     

 
    public class WorkOrderDetails  
    {
        private Int32 _WorkorderID_I;
        private Int32 _TenderID_I;
        private string _WorkorderNo_V;
        private DateTime _WorkOrderDate_D;
        private string _PBGNo_V;
        private DateTime _PBGdate_D;
        private string _WorkorderFilePath_V;
        private int _isAgreement_I;
        private DateTime _ArgDate_D;
        private string _ArgNo_V;
        private Decimal _PrintSecurityAmount_N;
        private string _PrintSecurityDetail_V;
        private Decimal _PaperSecurityAmount_N;
        private string _PaperSecurityDetail_V;
        private string _JobCode_V;
        private Int32 _Printer_regid_i;
        private Int32 _Userid_I;
        private DateTime _Transdate_D;
        private Int32 _GRPID_I;
        private Int32 _WorkOrderDetID_I;
        private string _LOINo_V;
        private DateTime _LOIDate_D;
        private Int32 _LID;

        public Int32 WorkorderID_I { get { return _WorkorderID_I; } set { _WorkorderID_I = value; } }
        public Int32 TenderID_I { get { return _TenderID_I; } set { _TenderID_I = value; } }
        public string WorkorderNo_V { get { return _WorkorderNo_V; } set { _WorkorderNo_V = value; } }
        public DateTime WorkOrderDate_D { get { return _WorkOrderDate_D; } set { _WorkOrderDate_D = value; } }
        public string PBGNo_V { get { return _PBGNo_V; } set { _PBGNo_V = value; } }
        public DateTime PBGdate_D { get { return _PBGdate_D; } set { _PBGdate_D = value; } }
        public string WorkorderFilePath_V { get { return _WorkorderFilePath_V; } set { _WorkorderFilePath_V = value; } }
        public Int32 isAgreement_I { get { return _isAgreement_I; } set { _isAgreement_I = value; } }
        public DateTime ArgDate_D { get { return _ArgDate_D; } set { _ArgDate_D = value; } }
        public string ArgNo_V { get { return _ArgNo_V; } set { _ArgNo_V = value; } }
        public Decimal PrintSecurityAmount_N { get { return _PrintSecurityAmount_N; } set { _PrintSecurityAmount_N = value; } }
        public string PrintSecurityDetail_V { get { return _PrintSecurityDetail_V; } set { _PrintSecurityDetail_V = value; } }
        public Decimal PaperSecurityAmount_N { get { return _PaperSecurityAmount_N; } set { _PaperSecurityAmount_N = value; } }
        public string PaperSecurityDetail_V { get { return _PaperSecurityDetail_V; } set { _PaperSecurityDetail_V = value; } }
        public string JobCode_V { get { return _JobCode_V; } set { _JobCode_V = value; } }
        public Int32 Printer_regid_i { get { return _Printer_regid_i; } set { _Printer_regid_i = value; } }
        public Int32 Userid_I { get { return _Userid_I; } set { _Userid_I = value; } }
        public DateTime Transdate_D { get { return _Transdate_D; } set { _Transdate_D = value; } }
        public Int32 GRPID_I { get { return _GRPID_I; } set { _GRPID_I = value; } }
        public Int32 WorkOrderDetID_I { get { return _WorkOrderDetID_I; } set { _WorkOrderDetID_I = value; } }
        public string LOINo_V { get { return _LOINo_V; } set { _LOINo_V = value; } }
        public DateTime LOIDate_D { get { return _LOIDate_D; } set { _LOIDate_D = value; } }
        public Int32 LID { get { return _LID; } set { _LID = value; } }

        public string Finyear { get; set; }

        public int InsertUpdate()
        {
            DBAccess obDBAccess = new DBAccess();
            LID = 0;
            if (WorkorderID_I != 0)
            {
                LID = WorkorderID_I;
            }
            // (`mWorkorderID_I` INT(10), `mTenderID_I` INT(10), `mWorkorderNo_V` VARCHAR(20), `mPBGNo_V` VARCHAR(20), `mWorkorderFilePath_V` VARCHAR(50), 
            //`misAgreement_I` INT(10),  `mArgNo_V` VARCHAR(20), `mPrintSecurityAmount_N` DECIMAL(18,2), `mPrintSecurityDetail_V` VARCHAR(20), 
            //`mPaperSecurityAmount_N` DECIMAL(18,2), `mPaperSecurityDetail_V` VARCHAR(20), `mJobCode_V` VARCHAR(20), `mPrinter_regid_i` INT(10),
            //`mUserid_I` INT(10),   `mLOINo_V` VARCHAR(25),  LID INT(10))
            obDBAccess.execute("USP_ACB007_WorkOrderDetailsSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("@mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("@mTenderID_I", TenderID_I);
            obDBAccess.addParam("@mWorkorderNo_V", WorkorderNo_V);
            obDBAccess.addParam("@mWorkOrderDate_D", WorkOrderDate_D);
            obDBAccess.addParam("@mPBGNo_V", PBGNo_V);
             obDBAccess.addParam(@"mPBGdate_D", PBGdate_D );
            obDBAccess.addParam("@mWorkorderFilePath_V", WorkorderFilePath_V);
            obDBAccess.addParam("@misAgreement_I", isAgreement_I);
            obDBAccess.addParam("@mArgDate_D", ArgDate_D);
            
             obDBAccess.addParam("@mArgNo_V", ArgNo_V);
             obDBAccess.addParam("@mPrintSecurityAmount_N", PrintSecurityAmount_N);
             obDBAccess.addParam("@mPrintSecurityDetail_V", PrintSecurityDetail_V);
             obDBAccess.addParam("@mPaperSecurityAmount_N", PaperSecurityAmount_N);
            obDBAccess.addParam("@mPaperSecurityDetail_V", PaperSecurityDetail_V);
            obDBAccess.addParam("@mJobCode_V", "115");
            obDBAccess.addParam("@mPrinter_regid_i", Printer_regid_i);
            obDBAccess.addParam("@mUserid_I", Userid_I);
             obDBAccess.addParam("@mTransdate_D", "2017-09-01");
             obDBAccess.addParam("@mLOINo_V", LOINo_V);
             obDBAccess.addParam("@mLOIDate_D", "2017-09-01");
            //          obDBAccess.addParam("macyear", Finyear);
            obDBAccess.addParam("@LID", SqlDbType.BigInt, DBAccess.SqlDirection.OUT);
             

            int result = obDBAccess.executeMyQuery();
            LID = Convert.ToInt32(obDBAccess.getParameter(5).ToString());
            return LID;
        }
        public int UpdateAgreement()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderAgreementSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mArgDate_D", ArgDate_D);
            obDBAccess.addParam("mArgNo_V", ArgNo_V);
            obDBAccess.addParam("mPrintSecurityAmount_N", PrintSecurityAmount_N);
            obDBAccess.addParam("mPrintSecurityDetail_V", PrintSecurityDetail_V);
            obDBAccess.addParam("mPaperSecurityAmount_N", PaperSecurityAmount_N);
            obDBAccess.addParam("mPaperSecurityDetail_V", PaperSecurityDetail_V);
            obDBAccess.addParam("mJobCode_V", JobCode_V);
            int i = obDBAccess.executeMyQuery();
            return i;
        }

        public DataSet JobCardNo()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderAgreementSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", 0);
            obDBAccess.addParam("mArgDate_D", 0);
            obDBAccess.addParam("mArgNo_V", 0);
            obDBAccess.addParam("mPrintSecurityAmount_N", 0);
            obDBAccess.addParam("mPrintSecurityDetail_V", 0);
            obDBAccess.addParam("mPaperSecurityAmount_N", 0);
            obDBAccess.addParam("mPaperSecurityDetail_V", 0);
            obDBAccess.addParam("mJobCode_V", 0);
            return obDBAccess.records();
        }
        public DataSet Select()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDetailLoad", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            return obDBAccess.records();
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDetailsDelete", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", id);
            int result = obDBAccess.executeMyQuery();
            return result;

        }

        public DataSet PrinterAlldetails(int ID, int TenderID_I, int PrinterID_I)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDDLdetails", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mID", ID);
            obDBAccess.addParam("mTenderID_I", TenderID_I);
            obDBAccess.addParam("mPrinterID_I", PrinterID_I);
            return obDBAccess.records();
        }

        public int InsertGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderDetailDataSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkOrderDetID_I", WorkOrderDetID_I);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mGRPID_I", GRPID_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public DataSet ViewGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_ACB007_WorkOrderGroupDetail", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            return obDBAccess.records();
        }
    }






    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}