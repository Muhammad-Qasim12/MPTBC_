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

public partial class Printing_OtherThenPaperAllotmentReturn : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    ACB_PaperAllotmentDetails obACB_PaperAllotmentDetails = null;
    PPR_WorkPlan objWorkPlan = null;
    DataSet ds; decimal TotalSheets;
    APIProcedure objdb = new APIProcedure(); string str1; int count12;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ddlFill();
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtOrderNo.Text = randnum.ToString();
            txtSupplydate_D.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
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
    protected void btnADD_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            if (txtPaperQuantity.Text == "")
            {
                txtPaperQuantity.Text = "0";
            }

            else if ((txtPaperQuantity.Text == "0" || txtPaperQuantity.Text == "0"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Quantity.');</script>");
            }
            else
            {
                obPRI_PaperAllotment = new PRI_PaperAllotment();
                obPRI_PaperAllotment.pprAlltChild_id = int.Parse(ViewState["pprAlltChild_id"].ToString());
                obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                obPRI_PaperAllotment.PaperCategory_V = ddlPaperSize.SelectedValue.ToString();
                obPRI_PaperAllotment.PaperQty_N = Convert.ToDouble(txtPaperQuantity.Text);
                //obPRI_PaperAllotment.PaperOpt_I = int.Parse(ddlPaperType.SelectedItem.Value);
                obPRI_PaperAllotment.TotalSheets = decimal.Parse(txtTotalSheets.Text);
                string CheckSts = "";
                int i = obPRI_PaperAllotment.ChildUpdate();
                if (i > 0)
                {
                    CheckSts = "Ok";
                }

                if (CheckSts == "Ok")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");

                    obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                    DataSet obDataSet = obPRI_PaperAllotment.Select();
                    if (obDataSet.Tables[1].Rows.Count > 0)
                    {
                        GrdWorkPlan.DataSource = obDataSet.Tables[1];
                        GrdWorkPlan.DataBind();
                    }

                    ddlPaperSize.SelectedIndex = 0;
                    // ddlPaperType.SelectedIndex = 0;

                    btnADD.Visible = false;

                    ViewState["pprAlltChild_id"] = "0";
                }
            }
        }
        else
        {

            if ((txtPaperQuantity.Text == "0" || txtPaperQuantity.Text == ""))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Quantity.');</script>");
                ViewState["TotSendQty"] = "0";
            }
            else
            {
                DataBindToGrid();
                ViewState["TotSendQty"] = "0";
            }
        }
    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperTypeFill();
    }
    public void PaperTypeFill()
    {
        objWorkPlan = new PPR_WorkPlan();
        //ddlPaperType.DataSource = objWorkPlan.PaperTypeFill();
        //ddlPaperType.DataTextField = "PaperType";
        //ddlPaperType.DataValueField = "PaperType_Id";
        //ddlPaperType.DataBind();
        //ddlPaperType.Items.Insert(0, "सलेक्ट करे ");
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {

        PaperSizeFill();

    }
    public void PaperSizeFill()
    {
        //if (ddlPaperType.SelectedItem.Text != "Select")
        //{
        objWorkPlan = new PPR_WorkPlan();
        //objWorkPlan.PaperType_I = int.Parse(0);
        ddlPaperSize.DataSource = objWorkPlan.PaperSizeFill();
        ddlPaperSize.DataTextField = "CoverInformation";
        ddlPaperSize.DataValueField = "PaperTrId_I";
        ddlPaperSize.DataBind();
        ddlPaperSize.Items.Insert(0, "सलेक्ट करे ");
        //}
    }

    public void DataBindToGrid()
    {
        if (ViewState["TempData"] == null || ViewState["TempData"] == "")
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("PaperType_I", typeof(string));
            dt.Columns.Add("PaperType", typeof(string));
            dt.Columns.Add("PaperMstrTrId_I", typeof(string));
            dt.Columns.Add("CoverInformation", typeof(string));
            dt.Columns.Add("PaperQty_N", typeof(string));
            dt.Columns.Add("pprAlltChild_id", typeof(int));
            dt.Columns.Add("TotSheets", typeof(decimal));


            DataRow Dr = dt.NewRow();
            Dr["PaperType_I"] = "PaperType";
            Dr["PaperType"] = "PaperType";
            Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value.ToString();
            Dr["CoverInformation"] = ddlPaperSize.SelectedItem.Text.ToString();
            Dr["PaperQty_N"] = txtPaperQuantity.Text;
            Dr["pprAlltChild_id"] = 0;
            Dr["TotSheets"] = txtTotalSheets.Text;
            dt.Rows.Add(Dr);
            ViewState["TempData"] = dt;
            GrdWorkPlan.DataSource = dt;
            GrdWorkPlan.DataBind();
        }
        else
        {
            DataTable dt = (DataTable)ViewState["TempData"];
            DataRow Dr = null;
            if (dt.Rows.Count > 0)
            {
                for (int i = 1; i <= dt.Rows.Count; i++)
                {
                    Dr = dt.NewRow();
                    Dr["PaperType_I"] = "ddlPaperType";
                    Dr["PaperType"] = "ddlPaperType";
                    Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value.ToString();
                    Dr["CoverInformation"] = ddlPaperSize.SelectedItem.Text.ToString();
                    Dr["PaperQty_N"] = txtPaperQuantity.Text;
                    Dr["pprAlltChild_id"] = 0;
                    Dr["TotSheets"] = txtTotalSheets.Text;
                }
                if (dt.Rows[0].ToString() == "")
                {
                    dt.Rows[0].Delete();
                    dt.AcceptChanges();
                }
                string Check = "";
                foreach (DataRow drd in dt.Rows)
                {
                    if (drd["PaperMstrTrId_I"].ToString() == ddlPaperSize.SelectedItem.Value.ToString())
                    {
                        Check = "Yes";
                    }
                }
                if (Check == "Yes")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Paper Size Already Exist.');</script>");
                }
                else
                {
                    dt.Rows.Add(Dr);
                }
                ViewState["TempData"] = dt;
            }

            GrdWorkPlan.DataSource = dt;
            GrdWorkPlan.DataBind();
        }
        //ddlPaperType.SelectedIndex = 0;
        ddlPaperSize.SelectedIndex = 0;
        txtTotalSheets.Text = "0";
        txtPaperQuantity.Text = "0";

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

            DataSet ds10 = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            acd_titledetail.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            acd_titledetail.DataValueField = "AcYear";
            acd_titledetail.DataTextField = "AcYear";
            acd_titledetail.DataBind();
            acd_titledetail.SelectedValue = ds10.Tables[0].Rows[0][0].ToString();



            DataSet ds = comm.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload_wo_wise(0,'" + acd_titledetail.SelectedValue + "')");
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "सलेक्ट करे");
            ddlPrinter2.DataSource = ds.Tables[0];
            ddlPrinter2.DataTextField = "NameofPress_V";
            ddlPrinter2.DataValueField = "Printer_RedID_I";
            ddlPrinter2.DataBind();
            ddlPrinter2.Items.Insert(0, "सलेक्ट करे");
        }
        catch { }
        finally { obCommonFuction = null; }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string UserID = Session["UserID"].ToString();
        // Session["OfficeTrNo"] = 1;
        try
        {
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            if (Request.QueryString["ID"] != null)
            {
                obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
            }
            obPRI_PaperAllotment.PrinterID_I = Convert.ToInt32(ddlPrinterName.SelectedValue);
            obPRI_PaperAllotment.PaperCategory_V = "0";

            // obPRI_PaperAllotment.JobCode_V = Convert.ToString(ddlTitle.SelectedValue);
            obPRI_PaperAllotment.Supplydate_D = Convert.ToDateTime(txtSupplydate_D.Text, cult);
            obPRI_PaperAllotment.OrderNo = txtOrderNo.Text;


            string CheckSts = "NotOk", ReturnTo = "", IssueId;
            string FODate = txtSupplydate_D.Text;
            FODate = FODate.Replace("-", "/");
            FODate = FODate.Split('/')[2] + "/" + FODate.Split('/')[1] + "/" + FODate.Split('/')[0];

            if (rdoCPD.Checked == true)
            {
                IssueId = "0";
                ReturnTo = "Central Depot";
            }
            else
            {
                ReturnTo = "Printer";
                IssueId = ddlPrinter2.SelectedValue;
            }
            foreach (GridViewRow gv in GrdWorkPlan0.Rows)
            {
                HiddenField lblPaperType_I = (HiddenField)gv.FindControl("hdPaperType");
                HiddenField hdPaperMstrTrId_I = (HiddenField)gv.FindControl("hdPaperMstrTrId_I");
                //Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
                // Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
                CheckBox CheckBox1 = (CheckBox)gv.FindControl("CheckBox1");
                TextBox TextBox1 = (TextBox)gv.FindControl("TextBox1");
                TextBox TextBox2 = (TextBox)gv.FindControl("TextBox2");
                // obPRI_PaperAllotment.PaperCategory_V = lblPaperMstrTrId_I.Value;
                if (CheckBox1.Checked == true)
                {
                    //obPRI_PaperAllotment.PaperQty_N = Convert.ToDouble(lblPaperQuantity_N.Text);
                    obPRI_PaperAllotment.PaperOpt_I = int.Parse(lblPaperType_I.Value);
                    //obPRI_PaperAllotment.TotalSheets = decimal.Parse(lblTotalSheets.Text);
                    obCommonFuction.FillDatasetByProc("call USP_paperReturnOrderSaveUpdate(0,'" + acd_titledetail.SelectedItem + "','" + txtOrderNo.Text + "'," + ddlPrinterName.SelectedValue + ",'" + ReturnTo + "'," + IssueId + "," + hdPaperMstrTrId_I.Value + "," + lblPaperType_I.Value + "," + TextBox1.Text + "," + TextBox2.Text + ",0,'" + FODate + "'," + UserID + ")");
                    CheckSts = "Ok";
                }
            }

            if (CheckSts == "Ok")
            {
                //  Response.Redirect("View_PRI006.aspx");
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record not saved.');</script>");
            }
        }
        catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record not saved.');</script>"); }
        finally
        {
            obPRI_PaperAllotment = null;
        }
        try
        {
            // GrdPaperAllotment.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadNew(" + ddlPrinterName.SelectedValue + "," + txtOrderNo.Text + ")");
            // GrdPaperAllotment.DataBind();
        }
        catch { }
        // btnADD0.Visible = true;
        GrdWorkPlan0.DataSource = null;
        GrdWorkPlan0.DataBind();
        BindGrdWorkPlan();
    }

    public void showdata(string ID)
    {
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        DataSet obDataSet = obPRI_PaperAllotment.Select();

        acd_titledetail.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AcadmicYR_V"]);
        ddlPrinterName.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrinterID_I"]);
        // ddlJoBCode.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["JobCode_V"]);
        txtSupplydate_D.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Supplydate_D"], cult);

        txtOrderNo.Text = obDataSet.Tables[0].Rows[0]["OrderNo"].ToString();
        if (obDataSet.Tables[1].Rows.Count > 0)
        {
            GrdWorkPlan.DataSource = obDataSet.Tables[1];
            GrdWorkPlan.DataBind();
        }
        HiddenField1.Value = (objdb.Decrypt(Request.QueryString["ID"].ToString()));
    }

    protected void txtOrderNo_TextChanged(object sender, EventArgs e)
    {
        try
        {
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.OrderNo = txtOrderNo.Text;
            DataSet ds = obPRI_PaperAllotment.OrderNoExistPrinter();
            if (ds.Tables[0].Rows[0][0].ToString() != "0")
            {
                txtOrderNo.Text = "";
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('इस आर्डर नंबर की जानकारी दर्ज हो चुकी है..');</script>");
            }
        }
        catch
        {
        }
        finally
        {

        }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
        Label lblpprAlltChild_id = (Label)gv.FindControl("lblpprAlltChild_id");
        Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
        Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");

        ViewState["pprAlltChild_id"] = lblpprAlltChild_id.Text;
        txtPaperQuantity.Text = lblPaperQuantity_N.Text;
        txtTotalSheets.Text = lblTotalSheets.Text;

        PaperTypeFill();
        //ddlPaperType.ClearSelection();
        //ddlPaperType.Items.FindByValue(lblPaperType_I.Text).Selected = true;
        PaperSizeFill();

        ddlPaperSize.ClearSelection();
        ddlPaperSize.Items.FindByValue(lblPaperMstrTrId_I.Text).Selected = true;
        btnADD.Visible = true;

        //if (ddlPaperType.SelectedItem.Value.ToString() == "1")
        //{
        //    txtTotalSheets.ReadOnly = true;
        //    RqTotalSheets.Visible = false;
        //   // txtTotalSheets.Text = "0";
        //}
        //else
        //{
        //   // txtTotalSheets.Text = "0";
        //    txtTotalSheets.ReadOnly = false;
        //    RqTotalSheets.Visible = true;
        //}
        //try
        //{
        //    ddlPaperSize_SelectedIndexChanged(sender, e);
        //}
        //catch { }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        HiddenField hdOrderno = (HiddenField)gv.FindControl("hdOrderno");
        CommonFuction comm = new CommonFuction();
        if (hdOrderno.Value != "")
        {
            DataSet ds3 = comm.FillDatasetByProc("call USP_PaperReturnOrderFromPrinter('" + hdOrderno.Value + "'," + ddlPrinterName.SelectedValue + ",0,3)");
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
            ddlPrinterName_SelectedIndexChanged1(sender, e);
        }
    }
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void ddlPaperSize_Init(object sender, EventArgs e)
    {

        ddlPaperSize.DataSource = string.Empty;
        ddlPaperSize.DataBind();
        ddlPaperSize.Items.Insert(0, "सलेक्ट करे ");
    }

    protected void ddlPrinterName_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlPrinterName.SelectedIndex > 0)
        {
            CommonFuction comm = new CommonFuction();
            DataSet ds4 = comm.FillDatasetByProc("call GetPrintigandPaperSec_acb(" + ddlPrinterName.SelectedValue + ",'" + acd_titledetail.SelectedItem.Text + "')");
            try
            {
                Label1.Text = ds4.Tables[0].Rows[0]["PaperSecurityAmount_N"].ToString();
            }
            catch
            {
                Label1.Text = "";
            }

            DataSet ds3 = comm.FillDatasetByProc("call USP_PaperReturnOrderFromPrinter('" + acd_titledetail.SelectedItem.Text + "'," + ddlPrinterName.SelectedValue + ",0,1)");

            GrdWorkPlan0.DataSource = ds3;
            GrdWorkPlan0.DataBind();

            try
            {
                BindGrdWorkPlan();
            }
            catch { }
        }
    }
    protected void ddlJoBCode_SelectedIndexChanged(object sender, EventArgs e)
    {


    }

    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlAcadmicYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            CommonFuction comm = new CommonFuction();
            DataSet ds = comm.FillDatasetByProc("call USP_PRI004_PrinterRegistrationload_wo_wise(0,'" + acd_titledetail.SelectedValue + "')");
            ddlPrinterName.DataSource = ds.Tables[0];
            ddlPrinterName.DataTextField = "NameofPress_V";
            ddlPrinterName.DataValueField = "Printer_RedID_I";
            ddlPrinterName.DataBind();
            ddlPrinterName.Items.Insert(0, "सलेक्ट करे");
            ddlPrinter2.DataSource = ds.Tables[0];
            ddlPrinter2.DataTextField = "NameofPress_V";
            ddlPrinter2.DataValueField = "Printer_RedID_I";
            ddlPrinter2.DataBind();
            ddlPrinter2.Items.Insert(0, "सलेक्ट करे");

        }
        catch { }
    }
    protected void btnADD0_Click(object sender, EventArgs e)
    {

        obCommonFuction.FillDatasetByProc("call UpdateStatusPaperAllotment('" + txtOrderNo.Text + "')");
        Response.Redirect("View_PRI006.aspx");
    }

    double PrintingPaper, Coverpaper;

    protected void rdoCPD_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCPD.Checked == true)
        {
            ddlPrinter2.Visible = false;
            lblCPD.Visible = true;
            lblCPD.Text = "Central Depot";
        }
        else
        {
            ddlPrinter2.Visible = true;
            lblCPD.Visible = false;
        }
    }
    public void BindGrdWorkPlan()
    {
        CommonFuction comm = new CommonFuction();
        DataSet ds3 = comm.FillDatasetByProc("call USP_PaperReturnOrderFromPrinter('" + acd_titledetail.SelectedItem.Text + "'," + ddlPrinterName.SelectedValue + ",0,2)");
        GrdPaperAllotment.DataSource = ds3;
        GrdPaperAllotment.DataBind();
    }

}