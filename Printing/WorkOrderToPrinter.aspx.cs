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
                /////////

                ////////////
                ViewState["WorkorderFilePath_V"] = "";
                obWorkOrderDetails = new WorkOrderDetails();
                ddlTenderID_I.DataSource = obCommonFuction.FillDatasetByProc("call Prin_loadTenderdd('" + DdlACYear.SelectedItem.Text + "')");
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Session["WorkorderID_I"] = 0;
        try
        {

            DateTime dt1, dt2;

            dt1 = dateConversion(txtLOIDate_D.Text);
            dt2 = dateConversion(txtWODate_D.Text);
            if (dt1 > dt2)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('LOI की दिनाक कार्य आदेश  दिनाक से बाद की है');</script>");
            }
            else
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
                        obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString());
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
                    Response.Redirect("VIEW_WorkOrderToPrinter.aspx");
                }
                else
                {
                    lblMsg.Text = ImgStatus.ToString();
                    lblMsg.ForeColor = System.Drawing.Color.Red;
                }
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
        var data = obWorkOrderDetails.PrinterAlldetails(3, Convert.ToInt32(intTenderID_I), Convert.ToInt32(intPrinterID), obWorkOrderDetails.Finyear);
        GrdGroupDetails.DataSource = data;
        GrdGroupDetails.DataBind();
    }
    public void showdata(string ID)
    {
        obWorkOrderDetails = new WorkOrderDetails();
        obWorkOrderDetails.WorkorderID_I = Convert.ToInt32(objApi.Decrypt(Request.QueryString["ID"]).ToString());
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

        txtPaperSecAmt.Text = Convert.ToDouble(obDataSet.Tables[0].Rows[0]["DmndPaperSecAmt"].ToString()).ToString();
        txtPrintingSecAmt.Text = Convert.ToDouble(obDataSet.Tables[0].Rows[0]["DmndPrintingSecAmt"].ToString()).ToString();
        txtDepositEndDt.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["DepositEndDt"]).ToString("dd/MM/yyyy");

        GRDGroupAlldetails1(Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue));
        HiddenField1.Value = objApi.Decrypt((Request.QueryString["ID"]).ToString());
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
            ddlPrinter_regid_i.DataSource = obWorkOrderDetails.PrinterAlldetails(1, Convert.ToInt32(ddlTenderID_I.SelectedValue), 0, DdlACYear.SelectedValue);
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
            DataSet ds = new DataSet();
            obWorkOrderDetails = new WorkOrderDetails();
            GrdGroupDetails.DataSource = obWorkOrderDetails.PrinterAlldetails(2, Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue), Convert.ToString(DdlACYear.SelectedValue));
            GrdGroupDetails.DataBind();

            if (GrdGroupDetails.Rows.Count > 0)
            {
                // for printer security
                ds = obWorkOrderDetails.PrinterAlldetails(6, Convert.ToInt32(ddlTenderID_I.SelectedValue), Convert.ToInt32(ddlPrinter_regid_i.SelectedValue), Convert.ToString(DdlACYear.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtPaperSecAmt.Text = Convert.ToString(ds.Tables[0].Rows[0]["Papersecurity"]);
                    txtPrintingSecAmt.Text = Convert.ToString(ds.Tables[0].Rows[0]["printingsecurity"]);
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('कार्यादेश के लिये  ग्रुप उपलब्ध नहीं है  ');</script>");
                ddlPrinter_regid_i.SelectedIndex = 0;
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
        CommonFuction obCommonFuction = new CommonFuction();
        obWorkOrderDetails = new WorkOrderDetails();
        ddlTenderID_I.DataSource = obCommonFuction.FillDatasetByProc("call Prin_loadTenderdd('" + DdlACYear.SelectedItem.Text + "')");
        ddlTenderID_I.DataTextField = "TenderNo_V";
        ddlTenderID_I.DataValueField = "TenderId_I";
        ddlTenderID_I.DataBind();
        ddlTenderID_I.Items.Insert(0, "Select");
        if (Request.QueryString["ID"] != null)
        {
            showdata(objApi.Decrypt(Request.QueryString["ID"]).ToString());
        }
    }
}