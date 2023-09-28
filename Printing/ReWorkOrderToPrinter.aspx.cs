using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_WorkOrderToPrinter : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    WorkOrderDetails obWorkOrderDetails = null;
    CommonFuction obCommonFuction = new CommonFuction();
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
              //  CommonFuction obCommonFuction = new CommonFuction();
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");

                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
                
                
                
                
                ViewState["WorkorderFilePath_V"] = "";
                obWorkOrderDetails = new WorkOrderDetails();
                ddlTenderID_I.DataSource = obWorkOrderDetails.PrinterAlldetails(0, 0, 0, DdlACYear.SelectedValue );
                ddlTenderID_I.DataTextField = "TenderNo_V";
                ddlTenderID_I.DataValueField = "TenderId_I";
                ddlTenderID_I.DataBind();
                ddlTenderID_I.Items.Insert(0, "Select");
                if (Request.QueryString["ID"] != null)
                {
                    showdata(objApi.Decrypt(Request.QueryString["ID"]).ToString());
                }

            }
            catch { }
            finally { obWorkOrderDetails = null; }
        }
    }

    public string FnDtFormat(string date)
    {
        if (date.Trim().Length > 0)
        {
            if (date.IndexOf('-') > 0)
            {
                date = date.Split('-')[2] + "-" + date.Split('-')[1] + "-" + date.Split('-')[0];
            }
            else
                date = date.Split('/')[2] + "-" + date.Split('/')[1] + "-" + date.Split('/')[0];
        }
        return date;
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
                    ImgStatus = objApi.uploadFile(FileUpload1, "Printing_WorkOrderFile", 1000);
                    if (ImgStatus == "Ok")
                    {
                        filename = objApi.FullFileName;
                        obWorkOrderDetails.WorkorderFilePath_V = "Printing_WorkOrderFile/" + filename;
                    }
                }

                if (ImgStatus == "Ok")
                {
                    lblMsg.Text = "";
                    obWorkOrderDetails.TenderID_I = Convert.ToInt32(ddlTenderID_I.SelectedValue);
                    obWorkOrderDetails.Printer_regid_i = Convert.ToInt32(ddlPrinter_regid_i.SelectedValue);
                    obWorkOrderDetails.WorkorderNo_V = Convert.ToString(txtWorkorderNo_V.Text);
                    obWorkOrderDetails.WorkOrderDate_D = Convert.ToDateTime(txtWODate_D.Text, cult);
                    //Convert.ToDateTime(System.DateTime.Now, cult);
                    obWorkOrderDetails.PBGNo_V = "";// Convert.ToString(txtPBGNo_V.Text);
                    obWorkOrderDetails.PBGdate_D = System.DateTime.Now;
                    obWorkOrderDetails.LOINo_V = Convert.ToString(txtLOINo_V.Text);
                    obWorkOrderDetails.LOIDate_D = Convert.ToDateTime(txtLOIDate_D.Text, cult);
                    obWorkOrderDetails.Userid_I = Convert.ToInt32(Session["UserID_I"]);
                    obWorkOrderDetails.Finyear = Convert.ToString(DdlACYear.SelectedValue);
                    obWorkOrderDetails.DmndPaperSecAmt = Convert.ToDecimal(txtPaperSecAmt.Text);
                    obWorkOrderDetails.DmndPrintingSecAmt = Convert.ToDecimal(txtPrintingSecAmt.Text);
                    obWorkOrderDetails.DepositEndDt = Convert.ToDateTime(txtDepositEndDt.Text, cult);
                    if (HiddenField1.Value == "")
                    {

                    }

                    if (Request.QueryString["ID"] != null)
                    {
                        obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(objApi.Decrypt( Request.QueryString["ID"]).ToString());
                    }
                    else
                    {
                        obWorkOrderDetails.WorkorderID_I = 0;
                        obWorkOrderDetails.isAgreement_I = 0;
                    }
                    int LID = obWorkOrderDetails.InsertUpdate();

                    if (Request.QueryString["ID"] == null)
                    {


                        int i = 0; 
                        foreach (GridViewRow gv in GrdGroupDetails.Rows)
                        {
                            
                            //CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
                            Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
                            int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
                            int hdnDepo = Convert.ToInt32(((HiddenField)gv.FindControl("HidDepoid")).Value);
                            obWorkOrderDetails.WorkOrderDetID_I = i;
                            i++;
                            obWorkOrderDetails.WorkorderID_I = LID;
                            obWorkOrderDetails.GRPID_I = hd2;

                            dt = obCommonFuction.FillDatasetByProc("CALL USP_Pri011_Depoagainstprinter_grp(" + obWorkOrderDetails.Printer_regid_i + "," + hd2 + "," + hdnDepo + ")");

                            if (dt.Tables[0].Rows.Count > 0)
                            { obWorkOrderDetails.Depoid = Convert.ToString(dt.Tables[0].Rows[0]["grpdetail"]); }
                            else
                            { obWorkOrderDetails.Depoid = "0"; }


                            obWorkOrderDetails.ReInsertGroup();
                        }

                        //insert in dis_demandtoprintingwithdrawal table - 14/4/2017
                        if (GrdGroupDetails.Rows.Count > 0) 
                        {
                            WorkOrderDetails_New objReWorkOrder = new WorkOrderDetails_New();
                            DataTable dtt = obCommonFuction.FillDatasetByProc("CALL USP_Pri011_Get_dis_demandtoprintingwithdrawal('" + obWorkOrderDetails.Printer_regid_i + "','" + DdlACYear.SelectedItem.Text + "')").Tables[0];
                            if (dtt.Rows.Count > 0)
                            {
                                for (int k = 0; k <= dtt.Rows.Count - 1; k++)
                                {
                                    objReWorkOrder.TitleId = dtt.Rows[k]["titleid_i"].ToString();
                                    objReWorkOrder.MediumId = dtt.Rows[k]["medium_i"].ToString();
                                    objReWorkOrder.AcYear = dtt.Rows[k]["AcYear"].ToString();

                                    objReWorkOrder.DepotID = dtt.Rows[k]["depoid_i"].ToString();
                                    objReWorkOrder.NetSchemeDemand = dtt.Rows[k]["TotNetSchemeDemand"].ToString();
                                    objReWorkOrder.NetOpenMkt = dtt.Rows[k]["TotOpnMktDemand"].ToString();

                                    objReWorkOrder.TotSchemeDemand = dtt.Rows[k]["TotNetSchemeDemand"].ToString();
                                    objReWorkOrder.TotNetSchemeDemand = dtt.Rows[k]["TotOpnMktDemand"].ToString();

                                    objReWorkOrder.TotOpnMktDemand = dtt.Rows[k]["TotNetSchemeDemand"].ToString();
                                    objReWorkOrder.TotNetOpenMkt = dtt.Rows[k]["TotOpnMktDemand"].ToString();

                                    objReWorkOrder.OrderNo = txtWorkorderNo_V.Text;
                                    objReWorkOrder.OrderDate = Convert.ToDateTime(txtWODate_D.Text, cult);
                                   
                                    objReWorkOrder.BookType = dtt.Rows[k]["BookType"].ToString();
                                    objReWorkOrder.DemandType = "10";

                                    LID = objReWorkOrder.InsertUpdate_ReWorkorderIDToPrinter();
                                }
                            }
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
            Response.Redirect("VIEW_REWorkOrderToPrinter.aspx");
        }
    }
    public void ddlPrinterAlldetails(int intTenderID_I)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.Finyear = DdlACYear.SelectedValue; 
        ddlPrinter_regid_i.DataSource = obWorkOrderDetails.PrinterAlldetails(1, Convert.ToInt32(ddlTenderID_I.SelectedValue), 0, obWorkOrderDetails.Finyear);
        ddlPrinter_regid_i.DataTextField = "NameofPress_V";
        ddlPrinter_regid_i.DataValueField = "Printer_RedID_I";
        ddlPrinter_regid_i.DataBind();
        ddlPrinter_regid_i.Items.Insert(0, "Select");
    }

    public void GRDGroupAlldetails(int intTenderID_I, int intPrinterID)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.Finyear = DdlACYear.SelectedValue; 
        var data = obWorkOrderDetails.PrinterAlldetails(2, Convert.ToInt32(intTenderID_I), Convert.ToInt32(intPrinterID), obWorkOrderDetails.Finyear);
        GrdGroupDetails.DataSource = data;
        GrdGroupDetails.DataBind();
    }

    public void GRDGroupAlldetails1(int intTenderID_I, int intPrinterID)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.Finyear = DdlACYear.SelectedValue; 
        var data = obWorkOrderDetails.PrinterAlldetails(5, Convert.ToInt32(intTenderID_I), Convert.ToInt32(intPrinterID), obWorkOrderDetails.Finyear);
        GrdGroupDetails.DataSource = data;
        GrdGroupDetails.DataBind();
    }
    public void showdata(string ID)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString() );
        DataSet obDataSet = obWorkOrderDetails.SelectReorder();

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

        txtPaperSecAmt.Text = Convert.ToDouble(obDataSet.Tables[0].Rows[0]["DmndPaperSecAmt"].ToString()).ToString();
        txtPrintingSecAmt.Text = Convert.ToDouble(obDataSet.Tables[0].Rows[0]["DmndPrintingSecAmt"].ToString()).ToString();
        txtDepositEndDt.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["DepositEndDt"]).ToString("dd/MM/yyyy");

        GRDGroupAlldetails1(Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue));
        HiddenField1.Value = objApi.Decrypt((Request.QueryString["ID"]).ToString()) ;
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
            ddlPrinter_regid_i.DataSource = obWorkOrderDetails.PrinterAlldetails(4, Convert.ToInt32(ddlTenderID_I.SelectedValue), 0, DdlACYear.SelectedValue  );
            ddlPrinter_regid_i.DataTextField = "NameofPress_V";
            ddlPrinter_regid_i.DataValueField = "Printer_RedID_I";
            ddlPrinter_regid_i.DataBind();
            ddlPrinter_regid_i.Items.Insert(0, "Select");
        }
    }

    protected void ddlPrinter_regid_i_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            obWorkOrderDetails = new WorkOrderDetails();
            GrdGroupDetails.DataSource = obWorkOrderDetails.PrinterAlldetails(5, Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue),Convert.ToString (DdlACYear.SelectedValue));
            GrdGroupDetails.DataBind();

            if (GrdGroupDetails.Rows.Count > 0)
            { }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कार्यादेश के लिये  ग्रुप उपलब्ध नहीं है  ');</script>");
                ddlPrinter_regid_i.SelectedIndex  = 0; 
            }
        }
        catch { }
        finally { }
    }
    protected void ddlPrinter_regid_i_Init(object sender, EventArgs e)
    {
        ddlPrinter_regid_i.DataSource = string.Empty;
        ddlPrinter_regid_i.DataBind();
        ddlPrinter_regid_i.Items.Insert(0, "Select");
    }
    public DateTime dateConversion(string txtValue)
    {
        DateTime dt;
        if (txtValue == "")
        {
            return Convert.ToDateTime("01/01/1900");
        }
        else
        {
            return DateTime.ParseExact(txtValue, "dd/MM/yyyy", null);
        }

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    public class WorkOrderDetails_New
    {
        private Int32 _ReWorkorderIDToPrinterID_I;

        private string _TitleId;
        public string TitleId { get { return _TitleId; } set { _TitleId = value; } }

        private string _MediumId;
        public string MediumId { get { return _MediumId; } set { _MediumId = value; } }

        private string _AcYear;
        public string AcYear { get { return _AcYear; } set { _AcYear = value; } }

        private string _DepotID;
        public string DepotID { get { return _DepotID; } set { _DepotID = value; } }

        private string _NetSchemeDemand;
        public string NetSchemeDemand { get { return _NetSchemeDemand; } set { _NetSchemeDemand = value; } }

        private string _NetOpenMkt;
        public string NetOpenMkt { get { return _NetOpenMkt; } set { _NetOpenMkt = value; } }

        private string _TotSchemeDemand;
        public string TotSchemeDemand { get { return _TotSchemeDemand; } set { _TotSchemeDemand = value; } }

        private string _TotNetSchemeDemand;
        public string TotNetSchemeDemand { get { return _TotNetSchemeDemand; } set { _TotNetSchemeDemand = value; } }

        private string _TotOpnMktDemand;
        public string TotOpnMktDemand { get { return _TotOpnMktDemand; } set { _TotOpnMktDemand = value; } }

        private string _TotNetOpenMkt;
        public string TotNetOpenMkt { get { return _TotNetOpenMkt; } set { _TotNetOpenMkt = value; } }

        private string _OrderNo;
        public string OrderNo { get { return _OrderNo; } set { _OrderNo = value; } }

        private DateTime _OrderDate;
        public DateTime OrderDate { get { return _OrderDate; } set { _OrderDate = value; } }

        private string _BookType;
        public string BookType { get { return _BookType; } set { _BookType = value; } }

        private string _DemandType;
        public string DemandType { get { return _DemandType; } set { _DemandType = value; } }
       
        public Int32 ReWorkorderIDToPrinter_I { get { return _ReWorkorderIDToPrinterID_I; } set { _ReWorkorderIDToPrinterID_I = value; } }

        public int InsertUpdate_ReWorkorderIDToPrinter()
        {
            DBAccess obDBAccess = new DBAccess();

            obDBAccess.execute("USP_PRI022_TenderReAllotmentSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mTitleId", TitleId);
            obDBAccess.addParam("mMediumId", MediumId);
            obDBAccess.addParam("mAcYear", AcYear);
            obDBAccess.addParam("mDepotID", DepotID);
            obDBAccess.addParam("mNetSchemeDemand", NetSchemeDemand);
            obDBAccess.addParam("mNetOpenMkt", NetOpenMkt);
            obDBAccess.addParam("mTotSchemeDemand", TotSchemeDemand);
            obDBAccess.addParam("mTotNetSchemeDemand", TotNetSchemeDemand);
            obDBAccess.addParam("mTotOpnMktDemand", TotOpnMktDemand);
            obDBAccess.addParam("mTotNetOpenMkt", TotNetOpenMkt);
            obDBAccess.addParam("mOrderNo", OrderNo);
            obDBAccess.addParam("mOrderDate", OrderDate);
            obDBAccess.addParam("mBookType", BookType);
            obDBAccess.addParam("mDemandType", DemandType);
            obDBAccess.addParam("mPID", ReWorkorderIDToPrinter_I);      
            
            int result = obDBAccess.executeMyQuery();
            return result;
        }               
            
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
       private string _Finyear;

       private string _Depoid;
       public string Depoid { get { return _Depoid; } set { _Depoid = value; } }

       public string Finyear { get { return _Finyear; } set { _Finyear = value; } }
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

       /*Prop 15-03-2016*/
       public DateTime ArgLastDate_D { get; set; }
       public Decimal AskingPaperSecurityAmount_N { get; set; }
       public Decimal AskingPrinterSecurityAmount_N { get; set; }
       /************************/

       /*Prop 11-04-2016*/
       public DateTime DepositEndDt { get; set; }
       public Decimal DmndPaperSecAmt { get; set; }
       public Decimal DmndPrintingSecAmt { get; set; }
       /************************/

       public int InsertUpdate()
       {
           DBAccess obDBAccess = new DBAccess();
           LID = 0;
           if (WorkorderID_I != 0)
           {
               LID = WorkorderID_I;
           }
           obDBAccess.execute("USP_PRI011_WorkOrderDetailsSave", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
           obDBAccess.addParam("mTenderID_I", TenderID_I);
           obDBAccess.addParam("mWorkorderNo_V", WorkorderNo_V);
           obDBAccess.addParam("mWorkOrderDate_D", WorkOrderDate_D);
           obDBAccess.addParam("mPBGNo_V", PBGNo_V);
           obDBAccess.addParam("mPBGdate_D", PBGdate_D);
           obDBAccess.addParam("mWorkorderFilePath_V", WorkorderFilePath_V);
           obDBAccess.addParam("misAgreement_I", isAgreement_I);
           obDBAccess.addParam("mArgDate_D", ArgDate_D);
           obDBAccess.addParam("mArgNo_V", ArgNo_V);
           obDBAccess.addParam("mPrintSecurityAmount_N", PrintSecurityAmount_N);
           obDBAccess.addParam("mPrintSecurityDetail_V", PrintSecurityDetail_V);
           obDBAccess.addParam("mPaperSecurityAmount_N", PaperSecurityAmount_N);
           obDBAccess.addParam("mPaperSecurityDetail_V", PaperSecurityDetail_V);
           obDBAccess.addParam("mJobCode_V", JobCode_V);
           obDBAccess.addParam("mPrinter_regid_i", Printer_regid_i);
           obDBAccess.addParam("mUserid_I", Userid_I);
           obDBAccess.addParam("mTransdate_D", Transdate_D);
           obDBAccess.addParam("mLOINo_V", LOINo_V);
           obDBAccess.addParam("mLOIDate_D", LOIDate_D);
           obDBAccess.addParam("mAcyear", Finyear);

           obDBAccess.addParam("mDepositEndDt", DepositEndDt);
           obDBAccess.addParam("mDmndPaperSecAmt", DmndPaperSecAmt);
           obDBAccess.addParam("mDmndPrintingSecAmt", DmndPrintingSecAmt);

           obDBAccess.addParam("LID", MySql.Data.MySqlClient.MySqlDbType.Int32, DBAccess.SqlDirection.OUT);

           int result = obDBAccess.executeMyQuery();
           LID = Convert.ToInt32(obDBAccess.getParameter(24).ToString());
           return LID;
       }
       public int UpdateAgreement()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderAgreementSave", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
           obDBAccess.addParam("mArgDate_D", ArgDate_D);
           obDBAccess.addParam("mArgNo_V", ArgNo_V);
           obDBAccess.addParam("mPrintSecurityAmount_N", PrintSecurityAmount_N);
           obDBAccess.addParam("mPrintSecurityDetail_V", PrintSecurityDetail_V);
           obDBAccess.addParam("mPaperSecurityAmount_N", PaperSecurityAmount_N);
           obDBAccess.addParam("mPaperSecurityDetail_V", PaperSecurityDetail_V);
           obDBAccess.addParam("mAgLastDate_D", ArgLastDate_D);
           obDBAccess.addParam("mAskPrinterSecurityAmount_N", AskingPrinterSecurityAmount_N);
           obDBAccess.addParam("mAskPaperSecurityAmount_N", AskingPaperSecurityAmount_N);
           obDBAccess.addParam("mJobCode_V", JobCode_V);
           int i = obDBAccess.executeMyQuery();           
           return i;
       }

       public DataSet JobCardNo()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderAgreementSave", DBAccess.SQLType.IS_PROC);
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
           obDBAccess.execute("USP_PRI011_WorkOrderDetailLoad", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
           return obDBAccess.records();
           throw new NotImplementedException();
       }
       public DataSet SelectReorder()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_ReWorkOrderDetailLoad", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
           return obDBAccess.records();
           throw new NotImplementedException();
       }
       public DataSet SelectSearchReorder()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderDetailLoadSearchreworkorder", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mPrinterName", JobCode_V   );
           return obDBAccess.records();
           throw new NotImplementedException();
       }

       public DataSet SelectSearch()
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderDetailLoadSearch", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mPrinterName", JobCode_V);
           return obDBAccess.records();
           throw new NotImplementedException();
       }
       public DataSet PrinSelect(int PrinterId)
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI0111_WorkOrderDetailLoad", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
           obDBAccess.addParam("mPrinterId", PrinterId);
             
           return obDBAccess.records();
           throw new NotImplementedException();
       }
       
       public int Delete(int id)
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderDetailsDelete", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", id);
           int result = obDBAccess.executeMyQuery();
           return result;
           
       }

       public DataSet PrinterAlldetails(int ID, int TenderID_I, int PrinterID_I, String Finyear)
       {
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderDDLdetails", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mID", ID);
           obDBAccess.addParam("mTenderID_I", TenderID_I);
           obDBAccess.addParam("mPrinterID_I", PrinterID_I);
           obDBAccess.addParam("mAcyear", Finyear);
           
             return obDBAccess.records();
       }

        public int InsertGroup()
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI011_WorkOrderDetailDataSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkOrderDetID_I", WorkOrderDetID_I);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mGRPID_I", GRPID_I);

            int result = obDBAccess.executeMyQuery();
            return result;
        }

        public int ReInsertGroup()
        {//user in case of reworkorder only additional depoid is inserted in table
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI011_REWorkOrderDetailDataSave", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mWorkOrderDetID_I", WorkOrderDetID_I);
            obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
            obDBAccess.addParam("mGRPID_I", GRPID_I);
            obDBAccess.addParam("mdepoid", Depoid  );

            int result = obDBAccess.executeMyQuery();
            return result;
        }
        public DataSet ViewGroup()
        { 
           DBAccess obDBAccess = new DBAccess();
           obDBAccess.execute("USP_PRI011_WorkOrderGroupDetail", DBAccess.SQLType.IS_PROC);
           obDBAccess.addParam("mWorkorderID_I", WorkorderID_I);
           return obDBAccess.records();
        }

        public DataSet PrintOrderFill(string PrintOrderLetterNo_V)
        {
            DBAccess obDBAccess = new DBAccess();
            obDBAccess.execute("USP_PRI0022_PrinterOrderPrint", DBAccess.SQLType.IS_PROC);
            obDBAccess.addParam("mPrinterId", Printer_regid_i);
            obDBAccess.addParam("mPrintOrderLetterNo_V", PrintOrderLetterNo_V);

            return obDBAccess.records();
            throw new NotImplementedException();
        }

   }

}
