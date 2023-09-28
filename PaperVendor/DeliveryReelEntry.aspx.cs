using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer.Paper;
using System.Globalization;

public partial class PaperVendor_DeliveryReelEntry : System.Web.UI.Page
{
    DataSet ds;
    ppr_DeliveryChallan objDeliveryChallan = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    APIProcedure objdb = new APIProcedure();
    protected string PaperVendorTrId_I = "";
    double TotSheetWt = 0, TotNet = 0, TotGrossWt = 0;
    Random rdm = new Random();
    protected string hTotBundleReel = ""; protected string hTotSheetsPerReemBundle = ""; protected string hRollNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        fnGetHeading();
        PaperVendorTrId_I = Session["UserID"].ToString();
        HiddenField1.Value = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            HDN_VendorCode.Value = obCommonFuction.FillScalarByProc("select isnull(VendorCode,'') from ppr_papervendormaster_m where PaperVendorTrId_I='" + PaperVendorTrId_I + "'");

            ViewState["Delivery_Child_Id"] = "";
            //lblAcYear.Text = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            
            if (Request.QueryString["AcYear"] != null)
            {
                lblAcYear.Text = Request.QueryString["AcYear"].ToString();
            }
            if (Request.QueryString["ID"] != null)
            {
                ViewState["Delivery_Child_Id"] = "";
                LabInvDtlFill();
            }
            else
            {
                ViewState["TempData"] = "";
                VendorFill();
                ddlVendor.ClearSelection();
                try
                {
                    ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
                }
                catch { }
                ddlVendor.Enabled = false;
                
                if (Request.QueryString["ChallanNo"] != null)
                {
                    try
                    {
                        string AcYear = Request.QueryString["AcYear"].ToString();
                        lblAcYear.Text = AcYear;
                        ChallanFill();
                        ddlChallanNo.Items.FindByText(objdb.Decrypt(Request.QueryString["ChallanNo"].ToString())).Selected = true;
                    }
                    catch { }
                    ddlLOINo_SelectedIndexChanged(sender, e);

                    //added - 912018 for default selected
                   try
                    {
                        DataSet dss = (DataSet)ddlPaperType.DataSource;
                        string papertype = dss.Tables[0].Rows[0]["PaperType_I"].ToString();
                        string papersize = dss.Tables[0].Rows[0]["PaperMstrTrId_I"].ToString();
                        HDN_PaperCategory.Value = dss.Tables[0].Rows[0]["PaperCategory"].ToString();

                        ddlPaperType.Items.FindByValue(papertype).Selected = true;
                        ddlPaperType_SelectedIndexChanged(sender, e);

                        ddlPaperSize.Items.FindByValue(papersize).Selected = true;
                        ddlPaperSize_SelectedIndexChanged(sender, e);

                        fnGetHeading();
                    }
                    catch { }
                   
                }
               
            }
        }
    }

    private void fnGetHeading()
    {
        try
        {
            if (ddlPaperType.SelectedValue == "1" && HDN_PaperCategory.Value == "Sheet")
            {
                hTotBundleReel = "कुल बंडल<br />Total Bundle";
                hTotSheetsPerReemBundle = "कुल शीट प्रति बंडल <br />Total Sheets Per Bundle ";
                hRollNo = "बंडल नंबर<br />Bundle No.";
            }
            else
            {
                if (ddlPaperType.SelectedValue == "2")
                {
                    hTotBundleReel = "कुल बंडल<br />Total Bundle";
                    hTotSheetsPerReemBundle = "कुल शीट प्रति बंडल <br />Total Sheets Per Bundle";
                    hRollNo = "शीट बंडल<br />Bundle No.";
                }
                else if (ddlPaperType.SelectedValue == "1")
                {
                    hTotBundleReel = "कुल रील<br />Total Reel";
                    hTotSheetsPerReemBundle = "कुल शीट प्रति रीम <br />Total Sheets Per Reem ";
                    hRollNo = "रोल नंबर<br />Roll No.";

                }                
                else
                {
                    hTotBundleReel = "कुल बंडल/रील <br> Total Bundle / Reel";
                    hTotSheetsPerReemBundle = "कुल शीट प्रति रीम/बंडल <br>Total Sheets Per Reem / Bundle";
                    hRollNo = "रोल नंबर <br> Roll No.";
                }
            }
        }
        catch { }
    }

    private string RandomNumber()
    {
        return (rdm.Next(3, 1000)).ToString();
    }
    public void LabInvDtlFill()
    {
        try
        { 
        objDeliveryChallan = new ppr_DeliveryChallan();
        objDeliveryChallan.Delivery_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        ds = objDeliveryChallan.DetailsFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdWorkPlan.DataSource = ds.Tables[0];
            GrdWorkPlan.DataBind();
            VendorFill();
            ddlVendor.ClearSelection();
            ddlVendor.Items.FindByValue(ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true; 
            ddlVendor.Enabled = false;
            ChallanFill();
            ddlChallanNo.ClearSelection();
            ddlChallanNo.Items.FindByValue(ds.Tables[0].Rows[0]["DisTranId"].ToString()).Selected = true; 
            ddlChallanNo.Enabled = false;
            PageTypeFill();
        }
           
        }
        catch { }
    }
    public void VendorFill()
    {
        objDeliveryChallan = new ppr_DeliveryChallan();
        ddlVendor.DataSource = objDeliveryChallan.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        VendorFill();
    }
    public void ChallanFill()
    {
        if (ddlVendor.SelectedItem.Text != "Select")
        {
            DataSet dsr = new DataSet();
            objDeliveryChallan = new ppr_DeliveryChallan();
            objDeliveryChallan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            //ddlChallanNo.DataSource = objDeliveryChallan.ChallanFill();
            dsr = obCommonFuction.FillDatasetByProc("call USP_GetChallanListByAcYear(" + objDeliveryChallan.PaperVendorTrId_I + ",'" + lblAcYear.Text + "')");
            ddlChallanNo.DataSource = dsr.Tables[0];
            ddlChallanNo.DataTextField = "ChallanNo";
            ddlChallanNo.DataValueField = "DisTranId";
            ddlChallanNo.DataBind();
            ddlChallanNo.Items.Insert(0, "Select");
            ddlPaperSize.DataSource = string.Empty;
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "Select");
            txtNetWet.Text = "0";
            txtGrossWt.Text = "0";
            ddlPaperType.DataSource = string.Empty;
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
        }
        else
        {
            ddlChallanNo.DataSource = string.Empty;
            ddlChallanNo.DataBind();
            ddlChallanNo.Items.Insert(0, "Select");
            ddlPaperSize.DataSource = string.Empty;
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "Select");
            ddlPaperType.DataSource = string.Empty;
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");

            txtNetWet.Text = "0";
            txtGrossWt.Text = "0";
        }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        ChallanFill();
    }

    public void PaperSizeFill()
    {
        objDeliveryChallan = new ppr_DeliveryChallan();
        objDeliveryChallan.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
        objDeliveryChallan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
        objDeliveryChallan.DisTranId = int.Parse(ddlChallanNo.SelectedItem.Value);
        ddlPaperSize.DataSource = objDeliveryChallan.PaperSizeFill();
        ddlPaperSize.DataTextField = "CoverInformation";
        ddlPaperSize.DataValueField = "PaperMstrTrId_I";
        ddlPaperSize.DataBind();
        ddlPaperSize.Items.Insert(0, "Select");
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaperType.SelectedItem.Text != "Select")
        {
            PaperSizeFill();

            if (ddlPaperType.SelectedItem.Value.ToString() == "1")
            {
                txtTotalSheets.ReadOnly = true;
                RqTotalSheets.Visible = false;
                txtTotalSheets.Text = "0";
                chkAutoBundel.Visible = false;
                txtRollNo.ReadOnly = false;
                txtRollNo.Text = "";
             
            }
            else
            {
                txtTotalSheets.Text = "0";
                txtTotalSheets.ReadOnly = false; 
                RqTotalSheets.Visible = true;
                if (Request.QueryString["ID"] == null)
                {
                    chkAutoBundel.Visible = true;
                    txtRollNo.ReadOnly = true;
                    txtRollNo.Text = System.DateTime.Now.ToString("yyddMMmm") + RandomNumber();
                }
                else
                {  
                    txtRollNo.ReadOnly = false;
                    txtRollNo.Text = "";
                    chkAutoBundel.Visible = false;
                }
               
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e) 
    {
        string CheckSts, CheckDataAlerady = "";

        objDeliveryChallan = new ppr_DeliveryChallan();

        objDeliveryChallan.DisTranId = int.Parse(ddlChallanNo.SelectedItem.Value.ToString());
        objDeliveryChallan.PaperVendorTrId_I = int.Parse(PaperVendorTrId_I);
        objDeliveryChallan.ChallanNo = ddlChallanNo.SelectedItem.Text;

        if (Request.QueryString["ID"] != null)
        {
            objDeliveryChallan.Delivery_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        }
        else
        {
            objDeliveryChallan.Delivery_Id = 0;
        }
        if (ddlVendor.SelectedItem.Text == "Select" || ddlChallanNo.SelectedItem.Text == "Select")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
        }
        else
        {
            if (Request.QueryString["ID"] != null)
            {
                Response.Redirect("ViewDeliveryReelEntry.aspx");
            }
            else
            {
                try
                {
                    if (GrdWorkPlan.Rows.Count > 0)
                    {

                       // ds = objDeliveryChallan.InsertUpdate();
                        ds = obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelSaveNew(" + objDeliveryChallan.Delivery_Id + "," + objDeliveryChallan.DisTranId + ",'" + objDeliveryChallan.ChallanNo + "'," + objDeliveryChallan.PaperVendorTrId_I + ",'" + lblAcYear.Text + "')");
                        if (ds.Tables[0].Rows.Count > 0)
                        {

                            CheckSts = "NotOk";
                            foreach (GridViewRow gv in GrdWorkPlan.Rows)
                            {
                                Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                                Label lblRollNo = (Label)gv.FindControl("lblRollNo");
                                Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                                Label lblNetWt = (Label)gv.FindControl("lblNetWt");
                                Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
                                Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");

                                //objDeliveryChallan.Delivery_Child_Id = 0;
                                //objDeliveryChallan.RollNo = lblRollNo.Text;
                                //objDeliveryChallan.Delivery_Id = int.Parse(ds.Tables[0].Rows[0]["LastId"].ToString());
                                //objDeliveryChallan.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
                                //objDeliveryChallan.NetWt = float.Parse(lblNetWt.Text);
                                //objDeliveryChallan.PaperType_I = int.Parse(lblPaperType_I.Text);
                                //objDeliveryChallan.GrossWt = float.Parse(lblGrossWt.Text);
                                // objDeliveryChallan.ChildInsert();

                                obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelChildSave('0','" + ds.Tables[0].Rows[0]["LastId"].ToString() + "','" + lblPaperMstrTrId_I.Text + "','" + lblPaperType_I.Text + "','" + lblRollNo.Text + "','" + lblNetWt.Text + "','" + lblGrossWt.Text + "','" + (lblTotalSheets.Text == "" ? "0" : lblTotalSheets.Text) + "')");

                                CheckSts = "Ok";
                            }
                            if (CheckSts == "Ok")
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                                Response.Redirect("ViewDeliveryReelEntry.aspx");
                                ddlPaperSize.SelectedIndex = 0;
                                ddlPaperType.SelectedIndex = 0;
                                ViewState["TempData"] = "";
                                ViewState["Delivery_Child_Id"] = "";
                            }
                            else
                            {

                            }

                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Add Reel Details.');</script>");
                    }
                }
                catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan No Already Exist.');</script>"); }
            }
        }
    }
    protected void ddlPaperQlty_SelectedIndexChanged(object sender, EventArgs e)
    {


    }
    public void GridFill()
    {
        //try
        //{
        //    if (ddlLOINo.SelectedItem.Text != "Select")
        //    {
        //        objDeliveryChallan = new ppr_DeliveryChallan();
        //        objDeliveryChallan.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
        //        GrdWorkPlan.DataSource = objDeliveryChallan.GrWorkPlanFill();
        //        GrdWorkPlan.DataBind();
        //    }
        //}
        //catch { }
    }
    protected void lnkUpdate_Click(object sender, EventArgs e)
    {

            LinkButton lnk = (LinkButton)sender;
            GridViewRow gv = (GridViewRow)lnk.NamingContainer;
            Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
            Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
            Label lblDelivery_Child_Id = (Label)gv.FindControl("lblDelivery_Child_Id");
            Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
            Label lblRollNo = (Label)gv.FindControl("lblRollNo");
            Label lblNetWt = (Label)gv.FindControl("lblNetWt");
            Label lblGrossWt = (Label)gv.FindControl("lblGrossWt");
            Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");
            txtTotalSheets.Text = lblTotalSheets.Text;

            ViewState["Delivery_Child_Id"] = lblDelivery_Child_Id.Text;
            txtRollNo.Text = lblRollNo.Text;
            txtNetWet.Text = lblNetWt.Text;
            txtGrossWt.Text = lblGrossWt.Text;
           
            try
            {
                PageTypeFill();
                ddlPaperType.ClearSelection();
                ddlPaperType.Items.FindByValue(lblPaperType_I.Text).Selected = true;
               
            }
            catch { }
            try
            {
           PaperSizeFill();
            ddlPaperSize.ClearSelection();
            ddlPaperSize.Items.FindByValue(lblPaperMstrTrId_I.Text).Selected = true;
            ddlPaperSize.Enabled = false;
            ddlPaperType.Enabled = false;
        }
        catch{}
        try
        {
            ddlPaperSize_SelectedIndexChanged(sender, e);
        }
        catch { }

    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
        Label lblRollNo = (Label)gv.FindControl("lblRollNo");
        DataTable Dt = new DataTable();
        Dt = (DataTable)ViewState["TempData"];
        for (int i = 0; i < Dt.Rows.Count; i++)
        {
            string RoleNo = "", PaperId = "";
            RoleNo = Dt.Rows[i]["RollNo"].ToString();
            PaperId = Dt.Rows[i]["PaperMstrTrId_I"].ToString();
            if (lblRollNo.Text.ToLower() == RoleNo.ToLower() && lblPaperMstrTrId_I.Text.ToLower() == PaperId.ToLower())
            {
                Dt.Rows.RemoveAt(i);
                Dt.AcceptChanges();
            }
        }
        if (Dt.Rows.Count > 0)
        {
            ViewState["TempData"] = Dt;
        }
        else
        {
            ViewState["TempData"] = "";
        }

        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record deleted successfully.');</script>");
        GrdWorkPlan.DataSource = Dt;
        GrdWorkPlan.DataBind();
    }

    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        ddlPaperType.DataSource = string.Empty;
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "Select");
    }
    public void PageTypeFill()
    {
        if (ddlChallanNo.SelectedItem.Text != "Select")
        {

            objDeliveryChallan = new ppr_DeliveryChallan();
            objDeliveryChallan.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objDeliveryChallan.DisTranId = int.Parse(ddlChallanNo.SelectedItem.Value);
            ddlPaperType.DataSource = objDeliveryChallan.PaperTypeFill();
            ddlPaperType.DataTextField = "PaperType_Name";
            ddlPaperType.DataValueField = "PaperType_I";
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
        }
        else
        {
            ddlPaperType.DataSource = string.Empty;
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
        }
    }
    protected void ddlLOINo_SelectedIndexChanged(object sender, EventArgs e)
    {
        PageTypeFill();
    }
    protected void ddlPaperSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaperSize.SelectedItem.Text != "Select")
        {
            objDeliveryChallan = new ppr_DeliveryChallan();
            objDeliveryChallan.DisTranId = int.Parse(ddlChallanNo.SelectedItem.Value);
            objDeliveryChallan.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedItem.Value);
            ds = obCommonFuction.FillDatasetByProc("call USP_PPR0019_PaperDeliveryReelShowDataByChalanNoandAcYear(" + objDeliveryChallan.DisTranId + "," + objDeliveryChallan.PaperMstrTrId_I + ",'" + lblAcYear.Text + "')");
            // ds = objDeliveryChallan.ReelQtyFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblTotReel.Text = ds.Tables[0].Rows[0]["SndrReel"].ToString();
               
            }
            else
            {
                lblTotReel.Text = "0";
            }
            if (ddlPaperSize.SelectedIndex > 0)
            {
                DataSet dst = new DataSet();
                string pid = ddlPaperSize.SelectedValue;
                dst = obCommonFuction.FillDatasetByProc("SELECT PaperCategory FROM `ppr_papermaster_m` WHERE PaperTrId_I=" + pid + "");
                string ptype = dst.Tables[0].Rows[0][0].ToString();
                if (ptype == "Sheet")
                {
                    txtTotalSheets.Text = "0";
                    txtTotalSheets.ReadOnly = false;
                    RqTotalSheets.Visible = true;
                    if (Request.QueryString["ID"] == null)
                    {
                        chkAutoBundel.Visible = true;
                        txtRollNo.ReadOnly = true;
                        txtRollNo.Text = System.DateTime.Now.ToString("yyddMMmm") + RandomNumber();
                    }
                    else
                    {
                        txtRollNo.ReadOnly = false;
                        txtRollNo.Text = "";
                        chkAutoBundel.Visible = false;
                    }
               
                }
            }

        }//USP_PPR0019_PaperDeliveryReelShowDataByChalanNoandAcYear
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        
        if (txtNetWet.Text == "")
        {
            txtNetWet.Text = "0";
        }
        if (txtGrossWt.Text == "")
        {
            txtGrossWt.Text = "0";
        }
        if (ddlPaperType.SelectedValue == "1" && HDN_PaperCategory.Value != "Sheet")
        {
            if (HDN_VendorCode.Value != "")
            {
                if (HDN_VendorCode.Value == "SA")
                {
                    txtRollNo.Text = System.Text.RegularExpressions.Regex.Replace(txtRollNo.Text, "SIL", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Trim();
                }
                if (HDN_VendorCode.Value == "CH")
                {
                    txtRollNo.Text = System.Text.RegularExpressions.Regex.Replace(txtRollNo.Text, "CP", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Trim();
                }
                txtRollNo.Text = (HDN_VendorCode.Value + txtRollNo.Text.Replace(HDN_VendorCode.Value, "")).Trim();
            }
        }


        decimal NetWt = 0, GrossWt = 0, TotReel = 0, RoleCheck = 0;
        try
        {
            //change filter of academic yr for checking rollno - 14/12/2017
            //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',0)");
            ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',0,'"+lblAcYear.Text+"')");
            if (ds.Tables[0].Rows.Count > 0)
            {
                RoleCheck = ds.Tables[0].Rows.Count;
            }
            else
            {
                RoleCheck = 0;
            }
        }
        catch { RoleCheck = 0; }
        try
        {
            TotReel = decimal.Parse(lblTotReel.Text);
        }
        catch { TotReel = 0; }
        try
        {
            NetWt = decimal.Parse(txtNetWet.Text);
        }
        catch { NetWt = 0; }
        try
        {
            GrossWt = decimal.Parse(txtGrossWt.Text);
        }
        catch { GrossWt = 0; }

        if ((txtNetWet.Text == "0"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter net wt.');</script>");
        }
        if ((txtGrossWt.Text == "0"))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Gross wt.');</script>");
        }
        else if (NetWt > GrossWt)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Net Weight Exceed from Gross Weight.');</script>");
        }
        else if (RoleCheck != 0 && ViewState["Delivery_Child_Id"] == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Role No Already Exist.');</script>");
        }
        else if (TotReel <= GrdWorkPlan.Rows.Count && ViewState["Delivery_Child_Id"] == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Total Bundle / Reel Exceed from Alloted Bundle / Reel.');</script>");
        }
        else
        {
            if (Request.QueryString["ID"] != null)
            {
                if (txtNetWet.Text == "")
                {
                    txtNetWet.Text = "0";
                }
                if (txtGrossWt.Text == "")
                {
                    txtGrossWt.Text = "0";
                }
                if ((txtNetWet.Text == "0"))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter net wt.');</script>");
                }
                else
                {
                    objDeliveryChallan = new ppr_DeliveryChallan();
                    if (ViewState["Delivery_Child_Id"] == "")
                    {
                        objDeliveryChallan.Delivery_Child_Id = 0;
                        //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',0)");
                        ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',0,'"+lblAcYear.Text+"')");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Role No Already Exist.');</script>");
                        }
                        else
                        {
                            obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelChildSave('" + objDeliveryChallan.Delivery_Child_Id.ToString() + "','" + objdb.Decrypt(Request.QueryString["ID"].ToString()) + "','" + ddlPaperSize.SelectedValue.ToString() + "','" + ddlPaperType.SelectedItem.Value.ToString() + "','" + txtRollNo.Text + "','" + txtNetWet.Text + "','" + txtGrossWt.Text + "','" + (txtTotalSheets.Text == "" ? "0" : txtTotalSheets.Text) + "')");
                            //txtGrossWt.Text = "0";
                            //txtNetWet.Text = "0";
                            try
                            {
                                txtRollNo.Text = (double.Parse(txtRollNo.Text) + 1).ToString();
                                txtNetWet.Focus();
                            }
                            catch
                            {
                                txtRollNo.Text = "";
                                txtNetWet.Focus();
                            }
                        }
                    }
                    else
                    {
                        objDeliveryChallan.Delivery_Child_Id = int.Parse(ViewState["Delivery_Child_Id"].ToString());

                        //objDeliveryChallan.RollNo = txtRollNo.Text;
                        //objDeliveryChallan.Delivery_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                        //objDeliveryChallan.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedValue.ToString());
                        //objDeliveryChallan.NetWt = float.Parse(txtNetWet.Text);
                        //objDeliveryChallan.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
                        //objDeliveryChallan.GrossWt = float.Parse(txtGrossWt.Text);
                        //objDeliveryChallan.ChildInsert();
                        //ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',1)");
                        ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',1,'"+lblAcYear.Text+"')");
                        if (int.Parse(ds.Tables[0].Rows[0][0].ToString()) != 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Role No Already Exist.');</script>");
                            obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelChildSaveWithOtRl('" + objDeliveryChallan.Delivery_Child_Id.ToString() + "','" + objdb.Decrypt(Request.QueryString["ID"].ToString()) + "','" + ddlPaperSize.SelectedValue.ToString() + "','" + ddlPaperType.SelectedItem.Value.ToString() + "','" + txtRollNo.Text + "','" + txtNetWet.Text + "','" + txtGrossWt.Text + "','" + (txtTotalSheets.Text == "" ? "0" : txtTotalSheets.Text) + "')");
                        }
                        else
                        {
                            obCommonFuction.FillDatasetByProc("Call USP_PPR0019_PaperDeliveryReelChildSave('" + objDeliveryChallan.Delivery_Child_Id.ToString() + "','" + objdb.Decrypt(Request.QueryString["ID"].ToString()) + "','" + ddlPaperSize.SelectedValue.ToString() + "','" + ddlPaperType.SelectedItem.Value.ToString() + "','" + txtRollNo.Text + "','" + txtNetWet.Text + "','" + txtGrossWt.Text + "','" + (txtTotalSheets.Text == "" ? "0" : txtTotalSheets.Text) + "')");
                            try
                            {
                                txtRollNo.Text = (double.Parse(txtRollNo.Text) + 1).ToString();
                                txtNetWet.Focus();
                            }
                            catch
                            {
                                txtRollNo.Text = "";
                                txtNetWet.Focus();
                            }
                        }
                    }
                    ddlPaperType.Enabled = true;
                    ddlPaperSize.Enabled = true;
                    ViewState["Delivery_Child_Id"] = "";
                    objDeliveryChallan.Delivery_Id = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                    ds = objDeliveryChallan.DetailsFill();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        GrdWorkPlan.DataSource = ds.Tables[0];
                        GrdWorkPlan.DataBind();
                    }

                }
            }
            else
            {
                if (txtNetWet.Text == "")
                {
                    txtNetWet.Text = "0";
                }
                if (txtGrossWt.Text == "")
                {
                    txtGrossWt.Text = "0";
                }
                if (txtNetWet.Text == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter net wt.');</script>");
                }
                else
                {
                    if (chkAutoBundel.Checked == true)
                    {
                        double iTotReel = double.Parse(lblTotReel.Text);
                        Int64 iRollNoTo = Convert.ToInt64((double.Parse(txtRollNo.Text) + iTotReel)-1);
                        ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo_NewAll(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',-1,'" + lblAcYear.Text + "','"+iRollNoTo.ToString()+"')");

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < (int.Parse(lblTotReel.Text)); i++)
                            {
                                try
                                {
                                    ds = obCommonFuction.FillDatasetByProc("CALL USP_PPR0019_PPrCheckRoleNo(" + ddlVendor.SelectedItem.Value + ",'" + txtRollNo.Text + "',0,'" + lblAcYear.Text + "')");
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        RoleCheck = ds.Tables[0].Rows.Count;
                                        txtRollNo.Text = (System.DateTime.Now.ToString("yyddMMmmss") + RandomNumber()).ToString();
                                    }
                                    else
                                    {
                                        RoleCheck = 0;
                                    }
                                }
                                catch { RoleCheck = 0; }

                                DataBindToGrid(txtRollNo.Text);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < (int.Parse(lblTotReel.Text)); i++)
                            {
                                DataBindToGrid(txtRollNo.Text);
                            }
                        }

                        GrdWorkPlan.DataSource = (DataTable)ViewState["TempData"];
                        GrdWorkPlan.DataBind();
                    }
                    else
                    {

                        DataBindToGrid(txtRollNo.Text);
                    }
                }
            }
        }
    }
    public void DataBindToGrid(string RollNo)
    {
        if (ViewState["TempData"] == null || ViewState["TempData"] == "")
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("PaperType_I", typeof(string));
            dt.Columns.Add("PaperType", typeof(string));
            dt.Columns.Add("PaperMstrTrId_I", typeof(string));
            dt.Columns.Add("CoverInformation", typeof(string));
            dt.Columns.Add("RollNo", typeof(string));
            dt.Columns.Add("NetWt", typeof(string));
            dt.Columns.Add("GrossWt", typeof(string));
            dt.Columns.Add("Delivery_Child_Id", typeof(string));
            dt.Columns.Add("TotalSheets", typeof(string));


            DataRow Dr = dt.NewRow();
            Dr["PaperType_I"] = ddlPaperType.SelectedItem.Value.ToString();
            Dr["PaperType"] = ddlPaperType.SelectedItem.Text.ToString();
            Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value.ToString();
            Dr["CoverInformation"] = ddlPaperSize.SelectedItem.Text.ToString();
            Dr["RollNo"] = RollNo;
            Dr["NetWt"] = txtNetWet.Text;
            Dr["GrossWt"] = txtGrossWt.Text;
            Dr["Delivery_Child_Id"] = "0";
            Dr["TotalSheets"] = txtTotalSheets.Text;


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
                    Dr["PaperType_I"] = ddlPaperType.SelectedItem.Value.ToString();
                    Dr["PaperType"] = ddlPaperType.SelectedItem.Text.ToString();
                    Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value.ToString();
                    Dr["CoverInformation"] = ddlPaperSize.SelectedItem.Text.ToString();
                    Dr["RollNo"] = RollNo;
                    Dr["NetWt"] = txtNetWet.Text;
                    Dr["GrossWt"] = txtGrossWt.Text;
                    Dr["Delivery_Child_Id"] = "0";
                    Dr["TotalSheets"] = txtTotalSheets.Text;
                }
                if (dt.Rows[0].ToString() == "")
                {
                    dt.Rows[0].Delete();
                    dt.AcceptChanges();
                }
                string Check = "";
                foreach (DataRow drd in dt.Rows)
                {
                    if (drd["RollNo"].ToString() == RollNo)
                    {
                        Check = "Yes";
                    }
                }
                if (Check == "Yes")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Role No Already Exist.');</script>");
                }
                else
                {
                    dt.Rows.Add(Dr);
                }

               ViewState["TempData"] = dt;
            }
            if (chkAutoBundel.Checked == false)
            {
                GrdWorkPlan.DataSource = dt;
                GrdWorkPlan.DataBind();
            }
        }
        //ddlPaperType.SelectedIndex = 0;
        //ddlPaperSize.SelectedIndex = 0;
        //txtNetWet.Text = "0";
        //txtGrossWt.Text = "0";
        // lblTotReel.Text = "0";
        //txtRollNo.Text = "";
        try
        {
            txtRollNo.Text = (double.Parse(txtRollNo.Text) + 1).ToString();
            txtNetWet.Focus();
        }
        catch
        {
            txtRollNo.Text = "";
            txtNetWet.Focus();
        }
    }
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTotalSheets = (Label)e.Row.FindControl("lblTotalSheets");
            Label lblNetWt = (Label)e.Row.FindControl("lblNetWt");
            Label lblGrossWt = (Label)e.Row.FindControl("lblGrossWt");

            

            LinkButton lnkUpdate = (LinkButton)e.Row.FindControl("lnkUpdate");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            if (Request.QueryString["ID"] != null)
            {
                lnkUpdate.Visible = true;
                lnkDelete.Visible = false;
            }
            else
            {
                lnkDelete.Visible = true;
                lnkUpdate.Visible = false;
            }

            try
            {
                TotSheetWt = TotSheetWt + double.Parse(lblTotalSheets.Text);
            }
            catch { }
            try
            {
                TotNet = TotNet + double.Parse(lblNetWt.Text);
            }
            catch { }
            try
            {
                TotGrossWt = TotGrossWt + double.Parse(lblGrossWt.Text);
            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblFTotalSheets = (Label)e.Row.FindControl("lblFTotalSheets");
            Label lblFNetWt = (Label)e.Row.FindControl("lblFNetWt");
            Label lblFGrossWt = (Label)e.Row.FindControl("lblFGrossWt");

            lblFTotalSheets.Text = TotSheetWt.ToString("0.000");
            lblFNetWt.Text = TotNet.ToString("0.000");
            lblFGrossWt.Text = TotGrossWt.ToString("0.000");
        }
    }
}
