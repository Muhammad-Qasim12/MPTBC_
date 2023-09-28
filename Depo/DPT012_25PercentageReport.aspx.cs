using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class Depo_DPT012_25PercentageReport : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CountingDetails obCountingDetails = null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            DdlACYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = comm.GetFinYear1();

            DataSet dd = comm.FillDatasetByProc("call USP_DPT25PerLoad(" + Convert.ToInt32(Session["UserID"]) + ",0,1,'"+DdlACYear.SelectedItem.Text+"')");
            DropDownList1.DataTextField = "NameofPress_V";
            DropDownList1.DataValueField = "Printer_RedID_I";
            DropDownList1.DataSource = dd.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, new ListItem("All", "0"));
            //obCountingDetails = new CountingDetails();
            //DataSet dt = obCountingDetails.FatchData(0, 1, Convert.ToInt32(Session["UserID"]), 1);
            DataSet dt = comm.FillDatasetByProc("call USP_DPT25PerLoad(" + Convert.ToInt32(Session["UserID"]) + "," + DropDownList1.SelectedValue + ",0,'" + DdlACYear.SelectedItem.Text + "')");
           GrdMain.DataSource = dt.Tables[0];
           GrdMain.DataBind();

          
        }
    }
    protected void GrdMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        a.Visible = true;
        obCountingDetails = new CountingDetails();
        CommonFuction comm=new CommonFuction ();
        Panel1.Visible = false;
       // DataSet dt1 = obCountingDetails.FatchData(Convert.ToInt32(GrdMain.SelectedDataKey.Value), 1, 0, 0);
        DataSet dt1 = comm.FillDatasetByProc("call USP_DPTTewntyPerCentageLoad(" + Convert.ToInt32(GrdMain.SelectedDataKey.Value) + ", '" + DdlACYear.SelectedItem.Text + "', 0, 0)");
        if (dt1.Tables[0].Rows.Count == 0)
        {
             dt1 = comm.FillDatasetByProc("call USP_DPTTewntyPerCentageLoad1(" + Convert.ToInt32(GrdMain.SelectedDataKey.Value) + ",'"+DdlACYear.SelectedItem.Text+"', 0, 0)");
        }
        if (dt1.Tables[0].Rows.Count == 0)

        {
             dt1 = comm.FillDatasetByProc("call USP_dpttewenty(" + Convert.ToInt32(GrdMain.SelectedDataKey.Value) + ")");
        }

       // USP_DPTTewntyPerCentageLoad1
        
        if (dt1.Tables[0].Rows.Count > 0)
        {
            txtReceieveddate.Text = dt1.Tables[0].Rows[0]["TransactionDate_N"].ToString();
            lblChalan.Text = dt1.Tables[0].Rows[0]["ChallanNo_V"].ToString();
            lblbGrDate.Text = dt1.Tables[0].Rows[0]["GRDate_D"].ToString();
            lblGrNo.Text = dt1.Tables[0].Rows[0]["GRNo_V"].ToString();
            lblorderNo.Text = dt1.Tables[0].Rows[0]["OrderNo_I"].ToString();
            lblOrderDate.Text = dt1.Tables[0].Rows[0]["OrderDate_D"].ToString();//Printer_RedID_I
            lblChalandate.Text = dt1.Tables[0].Rows[0]["ChallanDate_D"].ToString();
            HiddenField1.Value = dt1.Tables[0].Rows[0]["PinterID_I"].ToString();
            HiddenField2.Value = dt1.Tables[0].Rows[0]["StockReceiveEntryID_I"].ToString();
        }
        grdBookDetails.DataSource = dt1.Tables[0];
        grdBookDetails.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave.Visible = false;
        for (int i=0;i<grdBookDetails.Rows.Count;i++)
        {
            try
            {
                obCountingDetails = new CountingDetails();
                obCountingDetails.OrderNo_V = Convert.ToString(lblorderNo.Text);
                obCountingDetails.PinterID_I = Convert.ToInt32(HiddenField1.Value);
                obCountingDetails.ChallanNo_V = Convert.ToString(lblChalan.Text);
                obCountingDetails.ChallanDate = Convert.ToDateTime(lblChalandate.Text, cult);//Label1
                obCountingDetails.TotalNoOfReceiveBundle_I = Convert.ToInt32(((Label)grdBookDetails.Rows[i].FindControl("Label1")).Text);
                try { 
                obCountingDetails.NofSchemeBook_I = Convert.ToInt32(((TextBox)grdBookDetails.Rows[i].FindControl("txtSechemBook")).Text);
                }
                catch {
                    obCountingDetails.NofSchemeBook_I = 0;
                }
                try { 
                obCountingDetails.NoOFgenralBook_I = Convert.ToInt32(((TextBox)grdBookDetails.Rows[i].FindControl("txtGenranlBook")).Text);
                }
                catch { obCountingDetails.NoOFgenralBook_I = 0; }
                obCountingDetails.NoOfBookCounted_I = Convert.ToInt32(((TextBox)grdBookDetails.Rows[i].FindControl("txtReceivedBandla")).Text);
                obCountingDetails.BookDimention_V = Convert.ToString(((TextBox)grdBookDetails.Rows[i].FindControl("txtLambai")).Text + "X" + ((TextBox)grdBookDetails.Rows[i].FindControl("txtch")).Text);
                obCountingDetails.LetterNo_V = Convert.ToString(txtLetterNo.Text);
                if (txtLetterDate.Text == "")
                {
                    txtLetterDate.Text = "01/01/1900";
                }
                obCountingDetails.LetterDate = Convert.ToDateTime(txtLetterDate.Text, cult);
                obCountingDetails.TitalID = Convert.ToInt32(((HiddenField)grdBookDetails.Rows[i].FindControl("HiddenField3")).Value);
                obCountingDetails.userID = Convert.ToInt32(Session["UserID"]);
                if (txtbookNo.Text == "")
                {
                    txtbookNo.Text = "0";
                }
                obCountingDetails.bookNo_V = Convert.ToString(txtNo.Text);
                if (txtbandlNo.Text == "")
                {
                    txtbandlNo.Text = "0";
                }
                obCountingDetails.BundleNo_V = Convert.ToString(txtbandlNo.Text);
                obCountingDetails.SatusOfBook_V = Convert.ToString(ddlType.SelectedValue);
                obCountingDetails.PrinterCompanyperson_V = Convert.ToString(txtContactperson.Text);
                if (txtPdate.Text == "")
                { 
                
                }
                else
                {
                    obCountingDetails.PresentDate_D = Convert.ToDateTime(txtPdate.Text, cult);
                }
                obCountingDetails.CheckBundleNoOfBookFirst_I = Convert.ToInt32(txtbookNo.Text);
                obCountingDetails.CheckBundleNoOfBookSecond = Convert.ToInt32(txtbandlNo.Text);
                obCountingDetails.RegisterNo = Convert.ToString(txtRegNo.Text);
                if (txtDdate.Text == "")
                {
                    txtDdate.Text = "01/01/1900";
                }
                obCountingDetails.Date_D = Convert.ToDateTime(txtDdate.Text, cult);
                obCountingDetails.Remarks_V = Convert.ToString(txtRemark.Text);
                obCountingDetails.Receiveddate_D = Convert.ToDateTime(txtReceieveddate.Text, cult);
                obCountingDetails.InsertUpdate();
                obCountingDetails.PinterID_I = Convert.ToInt32(HiddenField2.Value);
                obCountingDetails.UpdateTwStatus();
               
            }
            catch (Exception ex) { }
           
        }
        Response.Redirect("VIEW_DPT012.aspx");


    }
    protected void GrdMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdBookDetails.PageIndex = e.NewPageIndex;
        DataSet dt = comm.FillDatasetByProc("call USP_DPT25PerLoad(" + Convert.ToInt32(Session["UserID"]) + "," + DropDownList1.SelectedValue + ",0,'"+DdlACYear.SelectedItem.Text+"')");
        GrdMain.DataSource = dt.Tables[0];
        GrdMain.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dt = comm.FillDatasetByProc("call USP_DPT25PerLoad(" + Convert.ToInt32(Session["UserID"]) + "," + DropDownList1.SelectedValue + ",0,'" + DdlACYear.SelectedItem.Text + "')");
        GrdMain.DataSource = dt.Tables[0];
        GrdMain.DataBind();
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedItem.Text == "निरंक")
        {
            ar1.Visible = false;
            ar2.Visible = false;
            ar3.Visible = false;
        }
        else
        {
            ar1.Visible = true;
            ar2.Visible = true;
            ar3.Visible = true;
        }
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dt = comm.FillDatasetByProc("call USP_DPT25PerLoad(" + Convert.ToInt32(Session["UserID"]) + "," + DropDownList1.SelectedValue + ",0,'" + DdlACYear.SelectedItem.Text + "')");
        GrdMain.DataSource = dt.Tables[0];
        GrdMain.DataBind();
    }
}