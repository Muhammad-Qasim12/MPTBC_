using MPTBCBussinessLayer;
using MPTBCBussinessLayer.Admin;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using Yojnaservice;

public partial class Printing_EMDTransferToFinance : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_TenderEvaluation obPriEval = null;
    APIProcedure objdb = new APIProcedure();
    YF_WebService objWebService = new YF_WebService();
    CommonFuction obCommonFuction = new CommonFuction();
    UserMaster objUMaster = new UserMaster();
    DataSet ds;
    int Cnt = 0;
    string finyear = "";
    protected void Page_Load(object sender, EventArgs e)
    {


        if (!Page.IsPostBack)
        {
            obCommonFuction = new CommonFuction();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            GridFill();

        }
    }
    public void GridFill()
    {
        obPriEval = new PRI_TenderEvaluation();
        // objdb.Decrypt(Request.QueryString["TenderId"]).ToString()
        if (Request.QueryString["ID"] != null)
        {
            Panel11.Visible = false;

            obPriEval.Tenderid_i = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"]).ToString());
        }
        else
        {
            Panel11.Visible = true;
            obPriEval.Tenderid_i = Convert.ToInt32(ddlTenderID_I.SelectedValue);
        }


        DataSet ds = new DataSet();
        ds = obPriEval.GetPrinterEMD();
        Session["finyear"] = Convert.ToString(ds.Tables[0].Rows[0]["myear"]);
        GrdEval.DataSource = ds;
        GrdEval.DataBind();

    }
    protected void btnclose_Click(object sender, EventArgs e)
    {
        finyear = Convert.ToString(Session["finyear"]);
        Response.Redirect("TenderDetailsFinance.aspx?ACYear=" + Session["finyear"].ToString() + "");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        // string PrathamUId = "", BranchId = "", CreatedByEmpId = "", newGuid = "";
        // string TenderID = objdb.Decrypt(Request.QueryString["TenderId"]).ToString();
        obPriEval = new PRI_TenderEvaluation();
        try
        {
            foreach (GridViewRow gv in GrdEval.Rows)
            {

                Label lblEMDAmount_N = (Label)gv.FindControl("lblEMDAmount_N");
                TextBox lblPrinterSts = (TextBox)gv.FindControl("lblPrinterSts");//MRDate
                if (Request.QueryString["ID"] != null)
                {

                    obPriEval.Tenderid_i = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"]).ToString());
                }
                else
                {

                    obPriEval.Tenderid_i = Convert.ToInt32(ddlTenderID_I.SelectedValue);
                }
                // obPriEval.Tenderid_i  = Convert.ToInt32(ddlTenderID_I.SelectedValue);
                Label lblPrinterid = (Label)gv.FindControl("lblPrinterid");
                Label lblGroupName = (Label)gv.FindControl("lblGroupName");
                TextBox txtRemark = (TextBox)gv.FindControl("txtRemark");
                TextBox lblTransferSts = (TextBox)gv.FindControl("lblTransferSts");//MRno
                Label lblYear = (Label)gv.FindControl("lblYear");

                obPriEval.Printerid_i = Convert.ToInt32(lblPrinterid.Text);
                obPriEval.EMDdetail = Convert.ToString(txtRemark.Text);
                obPriEval.EMD = Convert.ToInt32(Convert.ToDouble(lblEMDAmount_N.Text));
                obPriEval.MRno = Convert.ToString(lblTransferSts.Text);
                obPriEval.MRdate = Convert.ToString(lblPrinterSts.Text);
                finyear = lblYear.Text;
                obPriEval.EMDSave();


            }
        }
        catch { };


        Response.Redirect("TenderDetailsFinance.aspx?ACYear=" + finyear + "");
        // GridFill();

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
    protected void GrdEval_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            finyear = Convert.ToString(e.Row.FindControl("myear"));
            TextBox lblPrinterSts = (TextBox)e.Row.FindControl("lblPrinterSts");
            TextBox lblTransferSts = (TextBox)e.Row.FindControl("lblTransferSts");
            Label lblPrinterName = (Label)e.Row.FindControl("lblPrinterName");

            if (lblPrinterSts.Text == "Not Registered")
            {
                Cnt = Cnt + 1;
                lblPrinterSts.Text = "<a href='PRI001_PrinterRegistration.aspx?PName=" + objdb.Encrypt(lblPrinterName.Text.Replace(" ", "+")) + "' style='color:white;'>Register Now</a>";

                e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#DD5A5A");
                e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#DD5A5A");
                e.Row.Cells[2].BackColor = System.Drawing.Color.FromName("#DD5A5A");
                e.Row.Cells[3].BackColor = System.Drawing.Color.FromName("#DD5A5A");
                e.Row.Cells[4].BackColor = System.Drawing.Color.FromName("#DD5A5A");
                e.Row.Cells[5].BackColor = System.Drawing.Color.FromName("#DD5A5A");

                e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[1].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
            }
            else
            {
                if (lblTransferSts.Text == "Transferred")
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[1].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[3].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[4].BackColor = System.Drawing.Color.Blue;
                    e.Row.Cells[5].BackColor = System.Drawing.Color.Blue;

                    e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    e.Row.Cells[0].BackColor = System.Drawing.Color.FromName("#6CC34E");
                    e.Row.Cells[1].BackColor = System.Drawing.Color.FromName("#6CC34E");
                    e.Row.Cells[2].BackColor = System.Drawing.Color.FromName("#6CC34E");
                    e.Row.Cells[3].BackColor = System.Drawing.Color.FromName("#6CC34E");
                    e.Row.Cells[4].BackColor = System.Drawing.Color.FromName("#6CC34E");
                    e.Row.Cells[5].BackColor = System.Drawing.Color.FromName("#6CC34E");

                    e.Row.Cells[0].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[1].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[2].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[3].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[4].ForeColor = System.Drawing.Color.White;
                    e.Row.Cells[5].ForeColor = System.Drawing.Color.White;
                }
            }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Button btnSave = (Button)e.Row.FindControl("btnSave");
            if (Cnt != 0)
            {
                btnSave.Visible = true;
                message("Sorry You Can Not Transfer EMD Amount Untill All Printer Registered.", "ERROR");
            }
        }
    }
    protected void GrdEval_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("TenderDetailsFinance.aspx");
    }

    public class PRI_TenderEvaluation
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
                _isPrinter, _EMD;

        double _Ratequoated_n;
        string _EMDdetail, _MRno, _MRdate;


        public string NameofPress_V { get { return _NameofPress_V; } set { _NameofPress_V = value; } }
        public string LOINo_V { get { return _LOINo_V; } set { _LOINo_V = value; } }
        public int TenEvalDetID_I { get { return _TenEvalDetID_I; } set { _TenEvalDetID_I = value; } }
        public int TenAllotid_I { get { return _TenAllotid_I; } set { _TenAllotid_I = value; } }
        public int Tenevalid_i { get { return _Tenevalid_i; } set { _Tenevalid_i = value; } }
        public int Tenderid_i { get { return _Tenderid_i; } set { _Tenderid_i = value; } }
        public int GrPID_i { get { return _GrPID_i; } set { _GrPID_i = value; } }
        public int EMD { get { return _EMD; } set { _EMD = value; } }
        public string EMDdetail { get { return _EMDdetail; } set { _EMDdetail = value; } }

        public string MRno { get { return _MRno; } set { _MRno = value; } }
        public string MRdate { get { return _MRdate; } set { _MRdate = value; } }

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
        public DataSet GetPriIDAndStatus()
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                obDbaccess.execute("USP_PRI010_PrinterIDGetByPriName", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mNameofPress_V", NameofPress_V);
                ds = obDbaccess.records();


            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }


        public DataSet GetGrPID()
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                obDbaccess.execute("USP_PRI010_GroupIDGetByGrpName", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mGroupNO_V", NameofPress_V);
                obDbaccess.addParam("TenderID_Ia", TenAllotid_I);
                ds = obDbaccess.records();


            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }

        public DataSet GetPrinterEMD()
        {
            DBAccess obDbaccess = new DBAccess();
            DataSet ds = new DataSet();
            try
            {
                obDbaccess.execute("USP_Pri_EMDSendtoFinance", DBAccess.SQLType.IS_PROC);
                obDbaccess.addParam("mTenderid", Tenderid_i);
                obDbaccess.addParam("mtype", 1);
                ds = obDbaccess.records();


            }

            catch (Exception ex) { }
            finally { obDbaccess = null; }
            return ds;
        }





        public int EMDSave()
        {
            DBAccess obDbaccess = new DBAccess();
            int i = 0;
            try
            {
                obDbaccess.execute("USP_Pri_EMDSendtoFinanceSave", DBAccess.SQLType.IS_PROC);

                obDbaccess.addParam("mTenderID", Tenderid_i);
                obDbaccess.addParam("mprinterid", Printerid_i);
                obDbaccess.addParam("mEMD", 0);
                obDbaccess.addParam("mEMDDetail", EMDdetail);
                obDbaccess.addParam("mMRNo", MRno);
                obDbaccess.addParam("mMRDate", MRdate);
                obDbaccess.addParam("mstatus", 0);
                obDbaccess.addParam("mFee", EMD);
                obDbaccess.addParam("mType", 1);
                i = Convert.ToInt32(obDbaccess.executeMyScalar());

            }

            catch (Exception ex) { }
            finally
            {
                obDbaccess = null;

            }
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


        #region ICommon Members

        public int InsertUpdate()
        {
            throw new NotImplementedException();
        }

        public DataSet Select()
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    protected void ddlTenderID_I_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridFill();
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {

        DataSet dd = obCommonFuction.FillDatasetByProc("call Prin_loadTenderDetails(0,'" + DdlACYear.SelectedItem.Text + "')"); ;
        ddlTenderID_I.DataSource = dd.Tables[0];
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataBind();

    }
}