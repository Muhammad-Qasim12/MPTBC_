using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;

public partial class Printing_InterestOnPaper : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    PRI_PaperBillInterestonPaper obPRI_PaperBillInterestonPaper = null;
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    CommonFuction obCommonFuction = new CommonFuction();
    public double days = 0;
    public double calculation = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDLALL();
        }

    }

    protected void lnBtnViewSave_Click(object sender, EventArgs e)
    {
        //Messages.Style.Add("display", "block");
        //fadeDiv.Style.Add("display", "block");

        //try
        //{
        //    LinkButton lnkSender = (LinkButton)sender;
        //    GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        //    Label lblBillIntID_I = (Label)gv.FindControl("lblBillIntID_I");
        //    HiddenField1.Value = lblBillIntID_I.Text;

        //    Label lblBillInt = (Label)gv.FindControl("lblBillInt");
        //    HiddenBill_Id.Value = lblBillInt.Text;

        //    if (HiddenField1.Value != null)
        //    {
        //        showdata(HiddenField1.Value);
        //    }




        //}
        //catch
        //{
        //}
        //finally
        //{
        //    //obPRI_PrinterRenewal = null;
        //}


    }


    public void GrdPaperBill_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Messages.Style.Add("display", "block");
        fadeDiv.Style.Add("display", "block");


        HdnPaperAltID_I.Value = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnPaperAltID_I")).Value;
        Session["PapaealtID"] = Convert.ToInt32(HdnPaperAltID_I.Value);
        ViewDataInterest(Convert.ToInt32(HdnPaperAltID_I.Value));
        HdnBillInt.Value = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnBillIntID_I")).Value;

        DateTime dt;
        if (((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnReturnDate_D")).Value == "")
        {
            dt = Convert.ToDateTime(DateTime.Now, cult);
        }
        else
        {
            dt = Convert.ToDateTime(((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnReturnDate_D")).Value, cult);
        }

        txtBookReturnDate.Text = Convert.ToString(dt);
        txtNoDays.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnDays_N")).Value;
        txtIntrestAmount.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnAmount_N")).Value;
        txtIntrestRateonDays.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnInttperTon_I")).Value;



    }


    protected void GrdPaperBill_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdPaperBill_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperBill.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void GrdPaperBill_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdPaperBill_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        try
        {


            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperBillInterestonPaper = new PRI_PaperBillInterestonPaper();
            DataSet ds = obPRI_PaperAllotment.Select();

            obPRI_PaperBillInterestonPaper.BillIntID_I = Convert.ToInt32(HdnBillInt.Value);


            obPRI_PaperBillInterestonPaper.PrinterID_I = Convert.ToInt32(ds.Tables[0].Rows[0]["PrinterID_I"]);
            obPRI_PaperBillInterestonPaper.JobCode_V = Convert.ToString(ds.Tables[0].Rows[0]["JobCode_V"]);
            obPRI_PaperBillInterestonPaper.PaperSupplyTon_N = Convert.ToDouble(ds.Tables[0].Rows[0]["PaperQty_N"]);
            obPRI_PaperBillInterestonPaper.SupplyDate_D = Convert.ToDateTime(ds.Tables[0].Rows[0]["Supplydate_D"]);
            obPRI_PaperBillInterestonPaper.ReturnDate_D = Convert.ToDateTime(txtBookReturnDate.Text, cult);
            obPRI_PaperBillInterestonPaper.PaperAltID_I = Convert.ToInt32(HdnPaperAltID_I.Value);
            obPRI_PaperBillInterestonPaper.Days_N = Convert.ToDouble(txtNoDays.Text);
            obPRI_PaperBillInterestonPaper.Amount_N = Convert.ToDouble(txtIntrestAmount.Text);
            obPRI_PaperBillInterestonPaper.InttperTon_I = Convert.ToInt32(txtIntrestRateonDays.Text);
            obPRI_PaperBillInterestonPaper.USerID_I = Convert.ToInt32(Session["USerID_I"]);
            obPRI_PaperBillInterestonPaper.Transdate_D = System.DateTime.Now;

            //obPRI_PaperBillInterestonPaper.PaperAltID_I= Convert.ToInt32(ds.Tables[0].Rows[0]["PaperAltID_I"]);

            //TimeSpan objTimeSpan = obPRI_PaperBillInterestonPaper.SupplyDate_D - obPRI_PaperBillInterestonPaper.ReturnDate_D;
            //days = Convert.ToDouble(objTimeSpan.TotalDays);

            int b = obPRI_PaperBillInterestonPaper.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);




            Messages.Style.Add("display", "none");
            fadeDiv.Style.Add("display", "none");
        }
        catch { }
        finally
        {
            obPRI_PaperAllotment = null;
            FillData();
        }
    }

    public void BindDDLALL()
    {
        DataSet ds = obCommonFuction.FillDatasetByProc("call GetRegPrinterwithWorkOrder(0,'2020-2021')");
        ddlPrinterName.DataSource = ds.Tables[0];
        ddlPrinterName.DataTextField = "NameofPress_V";
        ddlPrinterName.DataValueField = "Printer_RedID_I";
        //ddlPrinterName.DataValueField = "NameofPress_V";
        ddlPrinterName.DataBind();
        ddlPrinterName.Items.Insert(0, "सलेक्ट करे");


        // Dropdown list of Acadmic Year 
        ddlAcadmicYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
        ddlAcadmicYear.DataValueField = "AcYear";
        ddlAcadmicYear.DataTextField = "AcYear";
        ddlAcadmicYear.DataBind();
        //ddlAcadmicYear.SelectedValue = obCommonFuction.GetFinYearNew();
        ddlAcadmicYear.Items.Insert(0, "सलेक्ट करे");
    }
    public void FillData()
    {
        try
        {
            //obPRI_PaperAllotment = new PRI_PaperAllotment();
            //obPRI_PaperAllotment.PaperAltID_I = 0;

            obPRI_PaperBillInterestonPaper = new PRI_PaperBillInterestonPaper();
            obPRI_PaperBillInterestonPaper.BillIntID_I = 0;
            DataSet ds = obCommonFuction.FillDatasetByProc("call USP_PRI007_BillInterestOnPaperLoadWithAllotmentNew();");
            GrdPaperBill.DataSource = obPRI_PaperBillInterestonPaper.SelectPaperBillIntrestLoad();
            //GrdPaperBill.DataSource = obPRI_PaperAllotment.SelectPaperBillIntrestLoad();
            GrdPaperBill.DataBind();

        }
        catch
        {
        }
        finally { }
    }
    public void ViewDataInterest(int PapIntId)
    {
        try
        {
            //obPRI_PaperAllotment = new PRI_PaperAllotment();
            //obPRI_PaperAllotment.PaperAltID_I = 0;
            DataSet DS = new DataSet();
            obPRI_PaperBillInterestonPaper = new PRI_PaperBillInterestonPaper();
            obPRI_PaperBillInterestonPaper.BillIntID_I = PapIntId;

            DS = obPRI_PaperBillInterestonPaper.Select(PapIntId);

            if (DS.Tables[0].Rows.Count > 0)
            {
                txtBookReturnDate.Text = Convert.ToString(DS.Tables[0].Rows[0]["SupplyDate_D"]);
                txtNoDays.Text = Convert.ToString(DS.Tables[0].Rows[0]["Days_N"]);
                txtIntrestAmount.Text = Convert.ToString(DS.Tables[0].Rows[0]["Amount_N"]);
                txtIntrestRateonDays.Text = Convert.ToString(DS.Tables[0].Rows[0]["InttperTon_I"]);
            }


        }
        catch
        {
        }
        finally { }
    }

    protected void txtBookReturnDate_TextChanged(object sender, EventArgs e)
    {
        CalDays();
    }

    public void CalDays()
    {
        try
        {


            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperBillInterestonPaper = new PRI_PaperBillInterestonPaper();


            if (Request.QueryString["ID"] != null)
            {
                obPRI_PaperBillInterestonPaper.BillIntID_I = Convert.ToInt32(Request.QueryString["ID"]);
            }

            obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(Session["PapaealtID"]);
            DataSet ds = obPRI_PaperAllotment.Select();
            DateTime ReturnDate = Convert.ToDateTime(txtBookReturnDate.Text, cult);
            DateTime SupplyDate = Convert.ToDateTime(ds.Tables[2].Rows[0]["Supplydate_D"], cult);
            txtIntrestRateonDays.Text = Convert.ToString(ds.Tables[2].Rows[0]["InttperTon_I"]);

            TimeSpan objTimeSpan = ReturnDate - SupplyDate;
            days = Convert.ToDouble(objTimeSpan.TotalDays);
            txtNoDays.Text = "" + days;
            calculation = days * Convert.ToInt32(txtIntrestRateonDays.Text);
            txtIntrestAmount.Text = "" + calculation;


        }
        catch { }

        finally { obPRI_PaperAllotment = null; }
    }

    protected void LinkClose_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");

    }

    protected void txtIntrestRateonDays_TextChanged(object sender, EventArgs e)
    {
        if (txtNoDays.Text != "" && txtIntrestRateonDays.Text != "")
        {
            txtIntrestAmount.Text = (Convert.ToDouble(txtNoDays.Text) * Convert.ToDouble(txtIntrestRateonDays.Text)).ToString();

        }

        else
        {
            if (txtNoDays.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Enter No of Days ');</script>");
            }
            else
            {
                if (txtIntrestRateonDays.Text == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Enter Interest Days.. ');</script>");
                }
            }

        }
        CalDays();

    }

    protected void txtNoDays_TextChanged(object sender, EventArgs e)
    {
        CalDays();
    }
    protected void BtnGetReport_Click(object sender, EventArgs e)
    {
       
        GrdBillIntrast.DataSource = null;
        GrdBillIntrast.DataBind();
        GrdBillIntrast.Visible = false;
        GrdPaperBill.Visible = true;
        if (ddlAcadmicYear.SelectedIndex > 0 && ddlPrinterName.SelectedIndex > 0)
        {

            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(0,0.0," + ddlPrinterName.SelectedValue + ",'N');");
           // DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,1);");
            //if (ds1.Tables != null)
            //{
            //    if (ds1.Tables[0].Rows.Count == 0)
            //    {
                    obCommonFuction.FillDatasetByProc("call USP_CUR_AlotpapertoPrinter(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "');");
            //    }
            //}
                    //temp - 91/2018
                    DataSet ds = obCommonFuction.FillDatasetByProc("call USP_PRI007_BillInterestOnPaperLoadWithAllotmentNew(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,1,'" + txtChalanrecDate.Text + "');");
                   // DataSet ds = obCommonFuction.FillDatasetByProc("call USP_PRI007_BillInterestOnPaperLoadWithAllotmentNew(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,1,'" + Convert.ToDateTime(txtChalanrecDate.Text).ToString("yyyy-MM-dd") + "');");
            GrdPaperBill.DataSource = ds;
            GrdPaperBill.DataBind();
        }
    }
    double TotalRecievedWaight = 0, wInTon = 0, TotalwInTon = 0, RecievedWaight = 0;
    double TotalRecievedWaightoth = 0, wInTonoth = 0, TotalwInTonoth = 0, RecievedWaightoth = 0;
    string RecDate = "", printerID, AcYear, chalanno, Supplydate_D;
    protected void GrdPaperBill_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField HdnPrinterID = (HiddenField)e.Row.FindControl("HdnPrinterID");
            HiddenField HdnTitleID_I = (HiddenField)e.Row.FindControl("HdnTitleID_I");
            HiddenField HiddenTrtype = (HiddenField)e.Row.FindControl("HiddenTrtype");

            
            // HiddenField HdnPrinterID = (HiddenField)e.Row.FindControl("HdnPrinterID");
            Label lblAcYear = (Label)e.Row.FindControl("lblAcYear");
            Label lblTransactionDate_N = (Label)e.Row.FindControl("lblTransactionDate_N");
            Label lblPaperQty_N = (Label)e.Row.FindControl("lblPaperQty_N");
            Label lblChalanNo = (Label)e.Row.FindControl("lblChalanNo");
            Label lblIntrestOnPaper = (Label)e.Row.FindControl("lblIntrestOnPaper");
            Label lblPaperSupplydate = (Label)e.Row.FindControl("lblPaperSupplydate");
            CheckBox ChkIsOk = (CheckBox)e.Row.FindControl("ChkIsOk");

            if (HiddenTrtype.Value.ToString() == "1")
            {
                try
                {
                    RecievedWaight = double.Parse(lblPaperQty_N.Text);
                    TotalRecievedWaight = TotalRecievedWaight + double.Parse(lblPaperQty_N.Text);
                    printerID = HdnPrinterID.Value;
                    AcYear = lblAcYear.Text;
                    chalanno = lblChalanNo.Text;

                    DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,3,1);");
                    if (ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        DataTable dts = new DataTable();
                        dts = ds1.Tables[0];
                        double Balance = double.Parse(dts.Rows[0]["Balance"].ToString());
                        if (Balance >= RecievedWaight)
                        {
                            int sts = 0;
                            string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                            int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                            lblIntrestOnPaper.Text = Math.Abs(Math.Round((RecievedWaight * today * 6.0), 0)).ToString();
                            //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                            double lastBalance = Balance - RecievedWaight;
                            string msg = "Intrest From " + dd1 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + "";
                            string details = "Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                            lblPaperSupplydate.Text = dd1;
                            if (lastBalance == 0)
                                sts = 1;
                            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + lastBalance + "," + sts + ",'" + details + "');");
                            msg = "";
                        }
                        else
                        {
                            double GrandAmt = 0;
                            double RemainingBalance = RecievedWaight - Balance;

                            string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                            int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                            GrandAmt = Math.Abs(Balance * today * 6.0);
                            string msg = "Intrest From Balance " + Balance + " Date " + dd1 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + " Intrest is=" + GrandAmt + " ";
                            string details = "Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details + "');");
                            lblPaperSupplydate.Text = dd1;
                            DataTable dtd = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "'," + dts.Rows[0]["PaperAltID_I"].ToString() + ",4,1);").Tables[0];
                            if (dtd.Rows.Count > 0)
                            {
                                int ii = 0;
                                foreach (DataRow row in dtd.Rows)
                                {

                                    //TextBox1.Text = row["ImagePath"].ToString();
                                    double NewBalance = double.Parse(row["Balance"].ToString());
                                    if (NewBalance > RemainingBalance && RemainingBalance > 0)
                                    {

                                        int sts = 0;
                                        string dd12 = row["Supplydate_D"].ToString();

                                        int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                        lblPaperSupplydate.Text = dd12;
                                        if (ii > 0)
                                        {
                                            double lastbal = double.Parse(lblIntrestOnPaper.Text);
                                            lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + lastbal), 0)).ToString();
                                        }
                                        else
                                        {
                                            lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                        }
                                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                        double lastBalance = NewBalance - RemainingBalance;
                                        string msg1 = "Intrest From " + dd1 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + "";
                                        string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + lastBalance + "," + 0 + ",'" + details1 + "');");
                                        RemainingBalance = 0;
                                        msg1 = "";
                                    }
                                    else if (NewBalance < RemainingBalance && RemainingBalance > 0)
                                    {
                                        int sts = 0;
                                        string dd12 = row["Supplydate_D"].ToString();
                                        int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                        lblIntrestOnPaper.Text = Math.Abs(Math.Round(((NewBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                        double lastBalance = RemainingBalance - NewBalance;
                                        string msg1 = "Intrest From " + dd12 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + "";
                                        string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                        lblPaperSupplydate.Text = dd12;
                                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details1 + "');");
                                        RemainingBalance = RemainingBalance - NewBalance;
                                        msg1 = "";
                                    }
                                    else { }
                                    ii = ii + 1;
                                }

                            }
                        }
                    }
                }
                catch { }
            }

                // other interest calculation
            else  
            {
                try
                {
                    RecievedWaightoth = double.Parse(lblPaperQty_N.Text);
                    TotalRecievedWaightoth = TotalRecievedWaightoth + double.Parse(lblPaperQty_N.Text);
                    printerID = HdnPrinterID.Value;
                    AcYear = lblAcYear.Text;
                    chalanno = lblChalanNo.Text;

                    DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,3,2);");
                    if (ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        DataTable dts = new DataTable();
                        dts = ds1.Tables[0];
                        double Balance = double.Parse(dts.Rows[0]["Balance"].ToString());
                        if (Balance >= RecievedWaightoth)
                        {
                            int sts = 0;
                            string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                            int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                            lblIntrestOnPaper.Text = Math.Abs(Math.Round((RecievedWaightoth * today * 6.0), 0)).ToString();
                            //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                            double lastBalance = Balance - RecievedWaightoth;
                            string msg = "Intrest From " + dd1 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + "";
                            string details = "Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                            lblPaperSupplydate.Text = dd1;
                            if (lastBalance == 0)
                                sts = 1;
                            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + lastBalance + "," + sts + ",'" + details + "');");
                            msg = "";
                        }
                        else
                        {
                            double GrandAmt = 0;
                            double RemainingBalance = RecievedWaight - Balance;

                            string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                            int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                            GrandAmt = Math.Abs(Balance * today * 6.0);
                            string msg = "Intrest From Balance " + Balance + " Date " + dd1 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + " Intrest is=" + GrandAmt + " ";
                            string details = "Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details + "');");
                            lblPaperSupplydate.Text = dd1;
                            DataTable dtd = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "'," + dts.Rows[0]["PaperAltID_I"].ToString() + ",4,2);").Tables[0];
                            if (dtd.Rows.Count > 0)
                            {
                                int ii = 0;
                                foreach (DataRow row in dtd.Rows)
                                {

                                    //TextBox1.Text = row["ImagePath"].ToString();
                                    double NewBalance = double.Parse(row["Balance"].ToString());
                                    if (NewBalance > RemainingBalance && RemainingBalance > 0)
                                    {

                                        int sts = 0;
                                        string dd12 = row["Supplydate_D"].ToString();

                                        int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                        lblPaperSupplydate.Text = dd12;
                                        if (ii > 0)
                                        {
                                            double lastbal = double.Parse(lblIntrestOnPaper.Text);
                                            lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + lastbal), 0)).ToString();
                                        }
                                        else
                                        {
                                            lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                        }
                                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                        double lastBalance = NewBalance - RemainingBalance;
                                        string msg1 = "Intrest From " + dd1 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + "";
                                        string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + lastBalance + "," + 0 + ",'" + details1 + "');");
                                        RemainingBalance = 0;
                                        msg1 = "";
                                    }
                                    else if (NewBalance < RemainingBalance && RemainingBalance > 0)
                                    {
                                        int sts = 0;
                                        string dd12 = row["Supplydate_D"].ToString();
                                        int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                        lblIntrestOnPaper.Text = Math.Abs(Math.Round(((NewBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                        double lastBalance = RemainingBalance - NewBalance;
                                        string msg1 = "Intrest From " + dd12 + " To " + lblTransactionDate_N.Text + " For ChallanNo=" + chalanno + "";
                                        string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                        lblPaperSupplydate.Text = dd12;
                                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details1 + "');");
                                        RemainingBalance = RemainingBalance - NewBalance;
                                        msg1 = "";
                                    }
                                    else { }
                                    ii = ii + 1;
                                }

                            }
                        }
                    }
                }
                catch { }
            }
        }
    }

   

    int DaysBetween(DateTime d1, DateTime d2)
    {
        TimeSpan span = d2.Subtract(d1);
        return (int)span.TotalDays;
    }

    protected void BtnCalculate_Click(object sender, EventArgs e)
    {
       GrdBillIntrast.Visible = true;
        GrdPaperBill.Visible = false;
        SaveDetails();
    }
    public void SaveDetails()
    {
        foreach (GridViewRow gv in GrdPaperBill.Rows)
        {
            CheckBox ChkIsOk = (CheckBox)gv.FindControl("ChkIsOk");
            if (ChkIsOk.Checked == true)
            {
                HiddenField HdnPrinterID = (HiddenField)gv.FindControl("HdnPrinterID");
                HiddenField HdnTitleID_I = (HiddenField)gv.FindControl("HdnTitleID_I");
                Label HdnTrtype = (Label)gv.FindControl("LblTrType");
                Label HdnPriTransID = (Label)gv.FindControl("HdnPriTransID");
               // HdnPriTransID
                // HiddenField HdnPrinterID = (HiddenField)e.Row.FindControl("HdnPrinterID");
                Label lblAcYear = (Label)gv.FindControl("lblAcYear");
                Label lblTransactionDate_N = (Label)gv.FindControl("lblTransactionDate_N");
                Label lblPaperQty_N = (Label)gv.FindControl("lblPaperQty_N");
                Label lblChalanNo = (Label)gv.FindControl("lblChalanNo");
                Label lblIntrestOnPaper = (Label)gv.FindControl("lblIntrestOnPaper");
                Label lblPaperSupplydate = (Label)gv.FindControl("lblPaperSupplydate");
                Label lblTotalNoOfBooks = (Label)gv.FindControl("lblTotalNoOfBooks");
                obCommonFuction.FillDatasetByProc("call USP_pri_BillCalculationDetailInsertUpdate(0," + HdnPriTransID.Text + ",'" + Convert.ToDateTime(lblTransactionDate_N.Text, cult).ToString("yyyy-MM-dd") + "','" + lblAcYear.Text + "','" + lblChalanNo.Text + "','" + lblTotalNoOfBooks.Text + "','" + lblPaperQty_N.Text + "',0,'-'," + ddlPrinterName.SelectedValue + ",1," + HdnTrtype.Text +");");
            }
        }
        GrdPaperBill.DataSource = null;
        GrdPaperBill.DataBind();
        BindGrdBillIntrast();
    }


    public void BindGrdBillIntrast()
    {
        GrdBillIntrast.DataSource = obCommonFuction.FillDatasetByProc("call USP_pri_BillCalculationDetailList(" + ddlPrinterName.SelectedValue + ",1);");
        GrdBillIntrast.DataBind();
    }

    decimal dPaper70Total = 0;
    protected void GrdBillIntrast_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            HiddenField HdnPrinterID = (HiddenField)e.Row.FindControl("HdnPrinterID");
            HiddenField HdnTitleID_I = (HiddenField)e.Row.FindControl("HdnTitleID_I");
            HiddenField HiddenTrtype = (HiddenField)e.Row.FindControl("HiddenTrtype");
            Label lblAcYear = (Label)e.Row.FindControl("lblAcYear");
            Label lblTransactionDate_N = (Label)e.Row.FindControl("lblTransactionDate_N");
            Label lblPaperQty_N = (Label)e.Row.FindControl("lblPaperQty_N");
            Label lblChalanNo = (Label)e.Row.FindControl("lblChalanNo");
            Label lblIntrestOnPaper = (Label)e.Row.FindControl("lblIntrestOnPaper");
            Label lblPaperSupplydate = (Label)e.Row.FindControl("lblPaperSupplydate");
            CheckBox ChkIsOk = (CheckBox)e.Row.FindControl("ChkIsOk");
            Label lblDetailsAll = (Label)e.Row.FindControl("lblDetailsAll");

            //Label lblIntrestOnPaper11 = (Label)e.Row.FindControl("lblIntrestOnPaper");
            //if (lblIntrestOnPaper11.Text != "")
            //{
            //    dPaper70Total += Decimal.Parse(lblIntrestOnPaper.Text);
            //}

            if ( HiddenTrtype.Value.ToString()   == "1")
            {
                try
                {
                    RecievedWaight = double.Parse(lblPaperQty_N.Text);
                    TotalRecievedWaight = TotalRecievedWaight + double.Parse(lblPaperQty_N.Text);
                    printerID = HdnPrinterID.Value;
                    AcYear = lblAcYear.Text;
                    chalanno = lblChalanNo.Text;
                    // paper inward detail
                    DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,3,1);");
                    if (ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                    {
                        string CalculationDetails = "";
                        DataTable dts = new DataTable();
                        dts = ds1.Tables[0];
                        double Balance = double.Parse(dts.Rows[0]["Balance"].ToString());
                        if (Balance >= RecievedWaight)
                        {
                            int sts = 0;
                            string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                            int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                            lblIntrestOnPaper.Text = Math.Abs(Math.Round((RecievedWaight * today * 6.0), 0)).ToString();
                            //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                            double lastBalance = Balance - RecievedWaight;
                            string msg = "Date " + dd1 + " To " + lblTransactionDate_N.Text + " Day(s) " + today + " IntAmt=" + lblIntrestOnPaper.Text + " Ton:-" + RecievedWaight + "  <br/>";
                            string details = "<br/>Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                            lblPaperSupplydate.Text = dd1;
                            if (lastBalance == 0)
                                sts = 1;
                            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + lastBalance + "," + sts + ",'" + details + "');");
                            CalculationDetails = msg;
                            msg = "";
                        }
                        else
                        {
                            double GrandAmt = 0;
                            double RemainingBalance = RecievedWaight - Balance;

                            string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                            int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                            GrandAmt = Math.Abs(Math.Round((Balance * today * 6.0), 0));
                            string msg = "Date " + dd1 + " To " + lblTransactionDate_N.Text + " Day(s) " + today + " IntAmt=" + GrandAmt + " Ton:- " + Balance + "<br/>";
                            CalculationDetails = msg;
                            string details = "Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                            obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details + "');");
                            lblPaperSupplydate.Text = dd1;
                            DataTable dtd = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "'," + dts.Rows[0]["PaperAltID_I"].ToString() + ",4,1);").Tables[0];
                            if (dtd.Rows.Count > 0)
                            {
                                int ii = 0;
                                foreach (DataRow row in dtd.Rows)
                                {

                                    //TextBox1.Text = row["ImagePath"].ToString();
                                    double NewBalance = double.Parse(row["Balance"].ToString());
                                    if (NewBalance > RemainingBalance && RemainingBalance > 0)
                                    {

                                        int sts = 0;
                                        string dd12 = row["Supplydate_D"].ToString();

                                        int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                        lblPaperSupplydate.Text = dd12;
                                        if (ii > 0)
                                        {
                                            double lastbal = double.Parse(lblIntrestOnPaper.Text);
                                            lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + lastbal), 0)).ToString();
                                        }
                                        else
                                        {
                                            lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                        }
                                        string IntAmt = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0)), 0)).ToString();
                                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                        double lastBalance = NewBalance - RemainingBalance;
                                        string msg1 = "Date " + dd12 + " To " + lblTransactionDate_N.Text + " Day(s) " + today1 + " IntAmt=" + IntAmt + " Ton:-" + RemainingBalance + "<br/>";
                                        string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + lastBalance + "," + 0 + ",'" + details1 + "');");
                                        RemainingBalance = 0;
                                        CalculationDetails = CalculationDetails + msg1;
                                        msg1 = "";
                                    }
                                    else if (NewBalance < RemainingBalance && RemainingBalance > 0)
                                    {
                                        int sts = 0;
                                        string dd12 = row["Supplydate_D"].ToString();
                                        int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                        lblIntrestOnPaper.Text = Math.Abs(Math.Round(((NewBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                        string IntAmt = Math.Abs(Math.Round(((NewBalance * today1 * 6.0)), 0)).ToString();
                                        double lastBalance = RemainingBalance - NewBalance;
                                        string msg1 = "Date " + dd12 + " To " + lblTransactionDate_N.Text + " Day(s) " + today1 + " IntAmt=" + IntAmt + "<br/>";
                                        string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                        lblPaperSupplydate.Text = dd12;
                                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details1 + "');");
                                        RemainingBalance = RemainingBalance - NewBalance;
                                        CalculationDetails = CalculationDetails + msg1;
                                        msg1 = "";
                                    }
                                    else { }
                                    ii = ii + 1;
                                }

                            }
                        }
                        lblDetailsAll.Text = CalculationDetails;
                        dPaper70Total += Decimal.Parse(lblIntrestOnPaper.Text);
                    }
                }
                catch { }
            }
        
        // other calc

        else
        {
                /*
            HiddenField HdnPrinterID = (HiddenField)e.Row.FindControl("HdnPrinterID");
            HiddenField HdnTitleID_I = (HiddenField)e.Row.FindControl("HdnTitleID_I");
            Label lblAcYear = (Label)e.Row.FindControl("lblAcYear");
            Label lblTransactionDate_N = (Label)e.Row.FindControl("lblTransactionDate_N");
            Label lblPaperQty_N = (Label)e.Row.FindControl("lblPaperQty_N");
            Label lblChalanNo = (Label)e.Row.FindControl("lblChalanNo");
            Label lblIntrestOnPaper = (Label)e.Row.FindControl("lblIntrestOnPaper");
            Label lblPaperSupplydate = (Label)e.Row.FindControl("lblPaperSupplydate");
            CheckBox ChkIsOk = (CheckBox)e.Row.FindControl("ChkIsOk");
            Label lblDetailsAll = (Label)e.Row.FindControl("lblDetailsAll");
                */
            //Label lblIntrestOnPaper11 = (Label)e.Row.FindControl("lblIntrestOnPaper");
            //if (lblIntrestOnPaper11.Text != "")
            //{
            //    dPaper70Total += Decimal.Parse(lblIntrestOnPaper.Text);
            //}


            try
            {
                RecievedWaightoth = double.Parse(lblPaperQty_N.Text);
                TotalRecievedWaightoth = TotalRecievedWaight + double.Parse(lblPaperQty_N.Text);
                printerID = HdnPrinterID.Value;
                AcYear = lblAcYear.Text;
                chalanno = lblChalanNo.Text;
                // paper inward detail
                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "',0,3,2);");
                if (ds1.Tables != null && ds1.Tables[0].Rows.Count > 0)
                {
                    string CalculationDetails = "";
                    DataTable dts = new DataTable();
                    dts = ds1.Tables[0];
                    double Balance = double.Parse(dts.Rows[0]["Balance"].ToString());
                    if (Balance >= RecievedWaightoth)
                    {
                        int sts = 0;
                        string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                        int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                        lblIntrestOnPaper.Text = Math.Abs(Math.Round((RecievedWaight * today * 6.0), 0)).ToString();
                        //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                        double lastBalance = Balance - RecievedWaight;
                        string msg = "Date " + dd1 + " To " + lblTransactionDate_N.Text + " Day(s) " + today + " IntAmt=" + lblIntrestOnPaper.Text + " Ton:-" + RecievedWaight + "  <br/>";
                        string details = "<br/>Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                        lblPaperSupplydate.Text = dd1;
                        if (lastBalance == 0)
                            sts = 1;
                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + lastBalance + "," + sts + ",'" + details + "');");
                        CalculationDetails = msg;
                        msg = "";
                    }
                    else
                    {
                        double GrandAmt = 0;
                        double RemainingBalance = RecievedWaightoth - Balance;

                        string dd1 = dts.Rows[0]["Supplydate_D"].ToString();
                        int today = DaysBetween(Convert.ToDateTime(dd1), Convert.ToDateTime(lblTransactionDate_N.Text));
                        GrandAmt = Math.Abs(Math.Round((Balance * today * 6.0), 0));
                        string msg = "Date " + dd1 + " To " + lblTransactionDate_N.Text + " Day(s) " + today + " IntAmt=" + GrandAmt + " Ton:- " + Balance + "<br/>";
                        CalculationDetails = msg;
                        string details = "Detail:" + dts.Rows[0]["details"].ToString() + " " + msg + "";
                        obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + dts.Rows[0]["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details + "');");
                        lblPaperSupplydate.Text = dd1;
                        DataTable dtd = obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Insert(" + ddlPrinterName.SelectedValue + ",'" + ddlAcadmicYear.SelectedValue + "'," + dts.Rows[0]["PaperAltID_I"].ToString() + ",4,2);").Tables[0];
                        if (dtd.Rows.Count > 0)
                        {
                            int ii = 0;
                            foreach (DataRow row in dtd.Rows)
                            {

                                //TextBox1.Text = row["ImagePath"].ToString();
                                double NewBalance = double.Parse(row["Balance"].ToString());
                                if (NewBalance > RemainingBalance && RemainingBalance > 0)
                                {

                                    int sts = 0;
                                    string dd12 = row["Supplydate_D"].ToString();

                                    int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                    lblPaperSupplydate.Text = dd12;
                                    if (ii > 0)
                                    {
                                        double lastbal = double.Parse(lblIntrestOnPaper.Text);
                                        lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + lastbal), 0)).ToString();
                                    }
                                    else
                                    {
                                        lblIntrestOnPaper.Text = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                    }
                                    string IntAmt = Math.Abs(Math.Round(((RemainingBalance * today1 * 6.0)), 0)).ToString();
                                    //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                    double lastBalance = NewBalance - RemainingBalance;
                                    string msg1 = "Date " + dd12 + " To " + lblTransactionDate_N.Text + " Day(s) " + today1 + " IntAmt=" + IntAmt + " Ton:-" + RemainingBalance + "<br/>";
                                    string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                    obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + lastBalance + "," + 0 + ",'" + details1 + "');");
                                    RemainingBalance = 0;
                                    CalculationDetails = CalculationDetails + msg1;
                                    msg1 = "";
                                }
                                else if (NewBalance < RemainingBalance && RemainingBalance > 0)
                                {
                                    int sts = 0;
                                    string dd12 = row["Supplydate_D"].ToString();
                                    int today1 = DaysBetween(Convert.ToDateTime(dd12), Convert.ToDateTime(lblTransactionDate_N.Text));
                                    lblIntrestOnPaper.Text = Math.Abs(Math.Round(((NewBalance * today1 * 6.0) + GrandAmt), 0)).ToString();
                                    //USP_ppr_AlotpapertoPrinter_Update`(mPaperAltID_I INT, mBalance DOUBLE,  mRecievedStatus INT)
                                    string IntAmt = Math.Abs(Math.Round(((NewBalance * today1 * 6.0)), 0)).ToString();
                                    double lastBalance = RemainingBalance - NewBalance;
                                    string msg1 = "Date " + dd12 + " To " + lblTransactionDate_N.Text + " Day(s) " + today1 + " IntAmt=" + IntAmt + "<br/>";
                                    string details1 = "Detail:" + row["details"].ToString() + " " + msg + "";
                                    lblPaperSupplydate.Text = dd12;
                                    obCommonFuction.FillDatasetByProc("call USP_ppr_AlotpapertoPrinter_Update(" + row["PaperAltID_I"].ToString() + "," + 0 + "," + 1 + ",'" + details1 + "');");
                                    RemainingBalance = RemainingBalance - NewBalance;
                                    CalculationDetails = CalculationDetails + msg1;
                                    msg1 = "";
                                }
                                else { }
                                ii = ii + 1;
                            }

                        }
                    }
                    lblDetailsAll.Text = CalculationDetails;
                    dPaper70Total += Decimal.Parse(lblIntrestOnPaper.Text);
                }
            }

            catch { }
        }
        }


                if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblTotIntrest = (Label)e.Row.FindControl("lblTotIntrest");
            lblTotIntrest.Text = dPaper70Total.ToString("0");
        }

    }
    protected void lbSaveDetails_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gv in GrdBillIntrast.Rows)
        {
         
                HiddenField HdnPrinterID = (HiddenField)gv.FindControl("HdnPrinterID");
                HiddenField HdnTitleID_I = (HiddenField)gv.FindControl("HdnTitleID_I");
                Label HdnPriTransID = (Label)gv.FindControl("HdnPriTransID");
                // HdnPriTransID
                // HiddenField HdnPrinterID = (HiddenField)e.Row.FindControl("HdnPrinterID");
                Label lblAcYear = (Label)gv.FindControl("lblAcYear");
                Label lblTransactionDate_N = (Label)gv.FindControl("lblTransactionDate_N");
                Label lblPaperQty_N = (Label)gv.FindControl("lblPaperQty_N");
                Label lblChalanNo = (Label)gv.FindControl("lblChalanNo");
                Label lblIntrestOnPaper = (Label)gv.FindControl("lblIntrestOnPaper");
                Label lblPaperSupplydate = (Label)gv.FindControl("lblPaperSupplydate");
                Label lblTotalNoOfBooks = (Label)gv.FindControl("lblTotalNoOfBooks");
                Label lblDetailsAll = (Label)gv.FindControl("lblDetailsAll");
                if (lblIntrestOnPaper.Text == "")
                    lblIntrestOnPaper.Text = "0";

                obCommonFuction.FillDatasetByProc("call USP_pri_BillCalculationDetailInsertUpdate(0," + HdnPriTransID.Text + ",'" + Convert.ToDateTime(lblTransactionDate_N.Text, cult).ToString("yyyy-MM-dd") + "','" + lblAcYear.Text + "','" + lblChalanNo.Text + "','" + lblTotalNoOfBooks.Text + "','" + lblPaperQty_N.Text + "','" + lblIntrestOnPaper.Text + "','" + lblDetailsAll.Text+ "'," + ddlPrinterName.SelectedValue + ",2,0);");
          
        }
        mainDiv.CssClass = "form-message success";
        mainDiv.Style.Add("display", "block");
        lblmsg.Text = "Saved Successfully";
    }


    protected void ddlAcadmicYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}