using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MPTBCBussinessLayer;
using System.Globalization;
using MPTBCBussinessLayer.Paper;
using System.Data;

public partial class Paper_DispatchDetails : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperDispatchDetails objPaperDispatchDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    MailHelper objSendSms = new MailHelper();
    string PaperVendorTrId_I = "";
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        PaperVendorTrId_I = Session["UserID"].ToString();
        if (!Page.IsPostBack)
        {
            //lblAcYear.Text =   obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString(); 
            DataSet ds = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");

            lblAcYear.Text = ds.Tables[0].Rows[0][1].ToString();
            ViewState["TempData"] = "";
            ViewState["TotSendQty"] = "0";
            //Random rand = new Random();
            //int randnum = rand.Next(100000, 10000000);
            //txtChallanNo.Text = randnum.ToString();
            txtChallanNo.Enabled = true;
            if (Request.QueryString["ID"] != null)
            {
                LabInvDtlFill();

            }
            else
            {
                VendorFill();
                ddlVendor.ClearSelection();
                try
                {
                    ddlVendor.Items.FindByValue(PaperVendorTrId_I).Selected = true;
                }
                catch { }
                ddlVendor.Enabled = false;
                LOIFill();
            }
        }
    }
    protected void ddlAcYear_Init(object sender, EventArgs e)
    {
        try
        {
            ddlAcYear.DataSource = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataBind();
           // ddlAcYear.SelectedValue = "2020-2021";

            // ddlAcYear.SelectedValue = obCommonFuction.GetFinYearNew();
            //ddlAcYear.Enabled = false;
            //ddlAcYear.Items.FindByText(obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString()).Selected = true;

            // ddlAcYear.Items.Insert(0, "Select");
        }
        catch { }
    }
    public void LabInvDtlFill()
    {

        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        objPaperDispatchDetails.DisTranId = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        ds = objPaperDispatchDetails.DetailsFill();
        if (ds.Tables[0].Rows.Count > 0)
        {
            VendorFill();
            ddlVendor.ClearSelection();
            ddlVendor.Items.FindByValue(ds.Tables[0].Rows[0]["PaperVendorTrId_I"].ToString()).Selected = true; ;
            ddlVendor.Enabled = false;
            try
            {
                DataSet dsyear = obCommonFuction.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
                ddlAcYear.DataSource = dsyear.Tables[0];
                ddlAcYear.DataTextField = "AcYear";
                ddlAcYear.DataBind();
                ddlAcYear.ClearSelection();
                ddlAcYear.Items.FindByText(dsyear.Tables[0].Rows[0]["AcYear"].ToString()).Selected = true;
                // ddlAcYear.Items.Insert(0, "Select");
            }
            catch { }
            LOIFill();
            ddlLOINo.ClearSelection();
            ddlLOINo.Items.FindByValue(ds.Tables[0].Rows[0]["LOITrId_I"].ToString()).Selected = true;
            ddlLOINo.Enabled = false;
            DateTime dte = new DateTime();
            dte = DateTime.Parse(ds.Tables[0].Rows[0]["ChallanDate"].ToString());
            txtChallanDate.Text = dte.ToString("dd/MM/yyyy");

            txtGrNo.Text = ds.Tables[0].Rows[0]["GRNo"].ToString();
            txtGrDate.Text = ds.Tables[0].Rows[0]["GRDate"].ToString();
            txtChallanNo.Text = ds.Tables[0].Rows[0]["ChallanNo"].ToString();
            txtOrderNo.Text = ds.Tables[0].Rows[0]["OrderNo"].ToString();
            txtMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
            txtDriverName.Text = ds.Tables[0].Rows[0]["DriverName"].ToString();
            txtTruckNo.Text = ds.Tables[0].Rows[0]["TruckNo"].ToString();

            txtChallanNo.Enabled = false;
            btnADD.Visible = false;
            GrdWorkPlan.DataSource = ds.Tables[0];
            GrdWorkPlan.DataBind();

        }

    }
    public void VendorFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        ddlVendor.DataSource = objPaperDispatchDetails.VenderFill();
        ddlVendor.DataTextField = "PaperVendorName_V";
        ddlVendor.DataValueField = "PaperVendorTrId_I";
        ddlVendor.DataBind();
        ddlVendor.Items.Insert(0, "Select");
    }
    protected void ddlVendor_Init(object sender, EventArgs e)
    {
        VendorFill();
    }
    public void LOIFill()
    {
        if (ddlVendor.SelectedItem.Text != "Select")
        {
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            //ddlLOINo.DataSource = objPaperDispatchDetails.LOINoFill();
            DataTable dtt = obCommonFuction.FillTableByProc("call USP_PPR0014_PaperDispatchShowData_newrpt(" + ddlVendor.SelectedValue + ",0,0,0,0,0,1,'" + ddlAcYear.SelectedItem.Text + "')");
            ddlLOINo.DataSource = dtt;
            ddlLOINo.DataTextField = "LOINo_V";
            ddlLOINo.DataValueField = "LOITrId_I";
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "Select");
            ddlPaperSize.DataSource = string.Empty;
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "Select");

            txtPaperQty.Text = "0";
            txtVdrSendQty.Text = "0";
            ddlPaperType.DataSource = string.Empty;
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
        }
        else
        {
            ddlLOINo.DataSource = string.Empty;
            ddlLOINo.DataBind();
            ddlLOINo.Items.Insert(0, "Select");
            ddlPaperSize.DataSource = string.Empty;
            ddlPaperSize.DataBind();
            ddlPaperSize.Items.Insert(0, "Select");
            ddlPaperType.DataSource = string.Empty;
            ddlPaperType.DataBind();
            ddlPaperType.Items.Insert(0, "Select");
            txtPaperQty.Text = "0";
            txtVdrSendQty.Text = "0";
        }
    }
    protected void ddlVendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        LOIFill();
    }
    public void PaperSizeFill()
    {
        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        objPaperDispatchDetails.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
        objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
        objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);
        ddlPaperSize.DataSource = objPaperDispatchDetails.PaperSizeFill();
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
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        DateTime DteCheck;
        string RptDate = "", GrDate = "";
        if (txtChallanDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtChallanDate.Text, cult);
            }
            catch { RptDate = "NoDate"; }
        }
        if (txtGrDate.Text != "")
        {
            try
            {
                DteCheck = DateTime.Parse(txtGrDate.Text, cult);
            }
            catch { GrDate = "NoDate"; }
        }

        if (RptDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct Challan Date.');</script>");
        }
        else if (GrDate != "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter correct GR Date.');</script>");
        }

        else if (DateTime.Parse(txtGrDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('GR date cannot greater than current date.');</script>");
        }
        else if (DateTime.Parse(txtChallanDate.Text, cult) > System.DateTime.Now)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan date cannot greater than current date.');</script>");
        }
        else if (GrdWorkPlan.Rows.Count <= 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Add Delivery Details.');</script>");
        }
        else if (DateTime.Parse(txtGrDate.Text, cult) < DateTime.Parse(txtChallanDate.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('GR Date can not be less then challan date.');</script>");
        }
        else
        {
            string CheckSts, PaperGSM = "";
            double TotReel = 0;
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.Trim());
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedValue.ToString());
            objPaperDispatchDetails.UserId_I = int.Parse(PaperVendorTrId_I);
             //objPaperDispatchDetails.ReceivedDate = DateTime.Parse(txtReceivedDate.Text, cult);
            objPaperDispatchDetails.ChallanDate = DateTime.Parse(txtChallanDate.Text, cult);
            objPaperDispatchDetails.ChallanNo = txtChallanNo.Text;
            objPaperDispatchDetails.AcYear = ddlAcYear.SelectedItem.Text;
            objPaperDispatchDetails.DriverName = txtDriverName.Text;
            objPaperDispatchDetails.MobileNo = txtMobileNo.Text;
            objPaperDispatchDetails.TruckNo = txtTruckNo.Text;
            objPaperDispatchDetails.OrderNo = txtOrderNo.Text;
            objPaperDispatchDetails.GRNo = txtGrNo.Text;
            objPaperDispatchDetails.GRDate = DateTime.Parse(txtGrDate.Text, cult);

            if (Request.QueryString["ID"] != null || (ddlVendor.Enabled == false && ddlLOINo.Enabled == false))
            {
                objPaperDispatchDetails.DisTranId = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
            }
            else
            {
                objPaperDispatchDetails.DisTranId = 0;
            }


            if (ddlVendor.SelectedItem.Text == "Select" || ddlLOINo.SelectedItem.Text == "Select")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select all feilds.');</script>");
            }
            //else if (DateTime.Parse(txtChallanDate.Text, cult) > DateTime.Parse(txtReceivedDate.Text, cult))
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Can not be greter challan date from receive date.');</script>");
            //}
            else if (txtChallanNo.Text == "" || txtChallanDate.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter challan information.');</script>");
            }
            else
            {
                if (Request.QueryString["ID"] != null)
                {
                    try
                    {
                        int i = objPaperDispatchDetails.InsertUpdateData();
                        if (i > 0)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record updated successfully.');</script>");
                            //Response.Redirect("ViewPprVndrDispatchDetails.aspx");
                            Response.Redirect("ViewPprVndrDispatchDetails.aspx?e=" + objdb.Encrypt(txtChallanNo.Text));
                            ddlLOINo.Enabled = true;
                            ddlVendor.Enabled = true;
                        }
                    }
                    catch { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan No Already Exist.');</script>"); }
                }
                else
                {

                    ds = objPaperDispatchDetails.InsertUpdate();
                    if (ds.Tables[0].Rows[0]["ChallanCheck"].ToString() == "0")
                    {

                        CheckSts = "NotOk";

                        foreach (GridViewRow gv in GrdWorkPlan.Rows)
                        {
                            Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                            Label lblVdrSendQty = (Label)gv.FindControl("lblVdrSendQty");
                            Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                            Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
                            Label lblSndrReel = (Label)gv.FindControl("lblSndrReel");
                            Label lblCoverInformation = (Label)gv.FindControl("lblCoverInformation");
                            try
                            {
                                TotReel = TotReel + double.Parse(lblSndrReel.Text);
                            }
                            catch { }
                            try
                            {
                                if (PaperGSM == "")
                                {
                                    PaperGSM = lblCoverInformation.Text;
                                }
                                else
                                {
                                    PaperGSM = PaperGSM + ", " + lblCoverInformation.Text;
                                }
                            }
                            catch { }
                            objPaperDispatchDetails.DisDtl_Id = 0;
                            objPaperDispatchDetails.ReqQty = float.Parse(lblPaperQuantity_N.Text);
                            objPaperDispatchDetails.DisTranId = int.Parse(ds.Tables[0].Rows[0]["LastId"].ToString());
                            objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(lblPaperMstrTrId_I.Text);
                            objPaperDispatchDetails.VdrSendQty = float.Parse(lblVdrSendQty.Text);
                            objPaperDispatchDetails.PaperType_I = int.Parse(lblPaperType_I.Text);
                            objPaperDispatchDetails.SndrReel = float.Parse(lblSndrReel.Text);
                            /////////////////////////////////////////////////////////////////////////////////////////////New Code for AcYear///////////
                            int i = ChildInsertwithAcYear(objPaperDispatchDetails);
                            // objPaperDispatchDetails.ChildInsert();
                            CheckSts = "Ok";
                        }
                        if (CheckSts == "Ok")
                        {
                            try
                            {
                                MailHelper objSendSms = new MailHelper();
                                PPR_RDLCData objGetMobile = new PPR_RDLCData();
                                string Msg = "", DepotMoblNo = "";
                                //Usp_Get_SMS_MobileNo
                                ds = new DataSet();
                                ds = obCommonFuction.FillDatasetByProc("CALL Usp_Get_SMS_MobileNo()");
                                Msg = "GSM Type :" + PaperGSM + ", No.of Reels :" + TotReel.ToString() + ", Date of Dispatch :" + txtChallanDate.Text + ", Vehicle No :" + txtTruckNo.Text + ", Driver Contact No. :" + txtDriverName.Text + " Please see Challan No : " + txtChallanNo.Text.Trim() + ", Challan Date: " + txtChallanDate.Text + " And Date.";
                                foreach (DataRow Dr in ds.Tables[0].Rows)
                                {
                                    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Paper")
                                    {
                                        objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                                    }
                                    if (Dr["Flag"].ToString() == "DGM" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Printing")
                                    {
                                        objSendSms.sendMessage(Dr["MobileNo"].ToString(), Msg);
                                    }

                                    if (Dr["Flag"].ToString() == "User" && Dr["SmsStatus"].ToString() == "Active" && Dr["Department"].ToString() == "Central Depot")
                                    {
                                        try
                                        {
                                            //Central Paper Depot
                                            ds = new DataSet();
                                            DepotMoblNo = objGetMobile.GetMobileNoForSms("5", ddlVendor.SelectedItem.Value.ToString()).Tables[0].Rows[0]["MobileNo"].ToString();
                                        }
                                        catch { }
                                        objSendSms.sendMessage(DepotMoblNo, Msg);
                                    }
                                }
                            }
                            catch { }


                            //Response.Redirect("ViewPprVndrDispatchDetails.aspx");
                            Response.Redirect("DeliveryReelEntry.aspx?ChallanNo=" + objdb.Encrypt(txtChallanNo.Text) + "&AcYear=" + ddlAcYear.SelectedItem.Text);
                            ddlPaperSize.SelectedIndex = 0;
                            ddlPaperType.SelectedIndex = 0;
                            txtVdrSendQty.Text = "";
                            txtPaperQty.Text = "";
                            txtChallanDate.Text = "";
                            // txtReceivedDate.Text = "";
                            txtChallanNo.Text = "";
                            ddlLOINo.SelectedIndex = 0;
                            ddlVendor.SelectedIndex = 0;
                            ViewState["TempData"] = "";
                            ViewState["DisDtl_Id"] = "";
                            txtTruckNo.Text = "";
                            txtDriverName.Text = "";
                            ViewState["TotSendQty"] = "0";
                            txtMobileNo.Text = "";
                            GrdWorkPlan.DataSource = string.Empty;
                            GrdWorkPlan.DataBind();
                            // Random rand = new Random();
                            //int randnum = rand.Next(100000, 10000000);
                            //txtChallanNo.Text = randnum.ToString();
                            txtChallanNo.Enabled = true;
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Challan No Already Exist.');</script>");
                    }
                }
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
        //        objPaperDispatchDetails = new PPR_PaperDispatchDetails();
        //        objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value.ToString());
        //        GrdWorkPlan.DataSource = objPaperDispatchDetails.GrWorkPlanFill();
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
        Label lblVdrSendQty = (Label)gv.FindControl("lblVdrSendQty");
        Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
        Label lblDisDtl_Id = (Label)gv.FindControl("lblDisDtl_Id");
        Label lblSndrReel = (Label)gv.FindControl("lblSndrReel");
        ViewState["DisDtl_Id"] = lblDisDtl_Id.Text;
        txtPaperQty.Text = lblPaperQuantity_N.Text;
        txtVdrSendQty.Text = lblVdrSendQty.Text;
        txtPaperQty.Text = lblPaperQuantity_N.Text;
        txtNoOfSndReel.Text = lblSndrReel.Text;
        PageTypeFill();
        ddlPaperType.ClearSelection();
        ddlPaperType.Items.FindByValue(lblPaperType_I.Text).Selected = true;
        PaperSizeFill();
        btnADD.Visible = true;
        ddlPaperSize.ClearSelection();
        ddlPaperSize.Items.FindByValue(lblPaperMstrTrId_I.Text).Selected = true;
        ddlPaperSize.Enabled = true;
        ddlPaperType.Enabled = false;
        try
        {
            ddlPaperSize_SelectedIndexChanged(sender, e);
        }
        catch { }

    }
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        ddlPaperType.DataSource = string.Empty;
        ddlPaperType.DataBind();
        ddlPaperType.Items.Insert(0, "Select");
    }
    public void PageTypeFill()
    {
        if (ddlLOINo.SelectedItem.Text != "Select")
        {

            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);
            ddlPaperType.DataSource = objPaperDispatchDetails.PaperTypeFill();
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
            objPaperDispatchDetails = new PPR_PaperDispatchDetails();
            objPaperDispatchDetails.PaperType_I = int.Parse(ddlPaperType.SelectedItem.Value);
            objPaperDispatchDetails.PaperVendorTrId_I = int.Parse(ddlVendor.SelectedItem.Value);
            objPaperDispatchDetails.LOITrId_I = int.Parse(ddlLOINo.SelectedItem.Value);
            objPaperDispatchDetails.PaperMstrTrId_I = int.Parse(ddlPaperSize.SelectedItem.Value);
            ds = objPaperDispatchDetails.QtyFill();
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPaperQty.Text = ds.Tables[0].Rows[0]["PaperQuantity_N"].ToString();
                lblRemainingQty.Text = ds.Tables[0].Rows[0]["RemainingQty"].ToString();
                ViewState["TotSendQty"] = ds.Tables[0].Rows[0]["TotSendQty"].ToString();
            }
        }
    }
    protected void btnADD_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            if (txtVdrSendQty.Text == "")
            {
                txtVdrSendQty.Text = "0";
            }
            if (txtPaperQty.Text == "")
            {
                txtPaperQty.Text = "0";
            }
            if (lblRemainingQty.Text == "")
            {
                lblRemainingQty.Text = "0";
            }
            float PaperQty = 0, Qty = 0, TotQty = 0, TotSendQty = 0;

            try
            {
                TotSendQty = float.Parse(ViewState["TotSendQty"].ToString());
            }
            catch { TotSendQty = 0; }


            try
            {
                PaperQty = float.Parse(txtPaperQty.Text);
            }
            catch { }
            try
            {
                Qty = (PaperQty * 40) / 100;
            }
            catch { }
            TotQty = PaperQty + Qty;

            if (((float.Parse(txtVdrSendQty.Text) + TotSendQty) > TotQty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Send quantity exceed from alloted quantity.');</script>");
            }
            else if ((txtVdrSendQty.Text == "0" || txtPaperQty.Text == "0"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Qty.');</script>");
            }
            else
            {
                objPaperDispatchDetails.DisDtl_Id = int.Parse(ViewState["DisDtl_Id"].ToString());
                objPaperDispatchDetails.ReqQty = 0;
                objPaperDispatchDetails.DisTranId = 0;
                objPaperDispatchDetails.PaperMstrTrId_I = 0;
                objPaperDispatchDetails.VdrSendQty = float.Parse(txtVdrSendQty.Text);
                objPaperDispatchDetails.PaperType_I = 0;
                objPaperDispatchDetails.SndrReel = float.Parse(txtNoOfSndReel.Text);
                //int i = objPaperDispatchDetails.ChildInsert();
                int i = ChildInsertwithAcYear(objPaperDispatchDetails);
                if (i > 0)
                {
                    objPaperDispatchDetails = new PPR_PaperDispatchDetails();
                    objPaperDispatchDetails.DisTranId = int.Parse(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                    // ds = objPaperDispatchDetails.DetailsFill();
                    ds = obCommonFuction.FillDatasetByProc("call USP_PPR0014_PaperDispatchShowDataByAcYear(0,0,0,0,0," + objPaperDispatchDetails.DisTranId + "," + ddlAcYear.SelectedItem.Text + "," + 7 + ")");
                    GrdWorkPlan.DataSource = ds.Tables[0];
                    GrdWorkPlan.DataBind();

                    ddlPaperSize.SelectedIndex = 0;
                    ddlPaperType.SelectedIndex = 0;
                    ddlPaperSize.Enabled = true;
                    ddlPaperType.Enabled = true;
                    btnADD.Visible = false;
                    txtVdrSendQty.Text = "0";
                    lblRemainingQty.Text = "0";
                    txtPaperQty.Text = "0";
                    txtNoOfSndReel.Text = "0";
                    ViewState["TotSendQty"] = "0";
                }
            }
        }
        else
        {
            float PaperQty = 0, Qty = 0, TotQty = 0, TotSendQty = 0;
            try
            {
                PaperQty = float.Parse(txtPaperQty.Text);
            }
            catch { }
            try
            {
                Qty = (PaperQty * 40) / 100;
            }
            catch { }

            try
            {
                TotSendQty = float.Parse(ViewState["TotSendQty"].ToString());
            }
            catch { TotSendQty = 0; }

            TotQty = PaperQty + Qty;

            if (((float.Parse(txtVdrSendQty.Text) + TotSendQty) > TotQty))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Send quantity exceed from alloted quantity.');</script>");
                ViewState["TotSendQty"] = "0";
            }
            else if ((txtVdrSendQty.Text == "0" || txtPaperQty.Text == "0"))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please enter Qty.');</script>");
                ViewState["TotSendQty"] = "0";
            }
            else
            {
                DataBindToGrid();
                ViewState["TotSendQty"] = "0";
            }
        }
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
            dt.Columns.Add("PaperQuantity_N", typeof(string));
            dt.Columns.Add("VdrSendQty", typeof(string));
            dt.Columns.Add("DisDtl_Id", typeof(string));
            dt.Columns.Add("SndrReel", typeof(string));


            DataRow Dr = dt.NewRow();
            Dr["PaperType_I"] = ddlPaperType.SelectedItem.Value.ToString();
            Dr["PaperType"] = ddlPaperType.SelectedItem.Text.ToString();
            Dr["PaperMstrTrId_I"] = ddlPaperSize.SelectedItem.Value.ToString();
            Dr["CoverInformation"] = ddlPaperSize.SelectedItem.Text.ToString();
            Dr["PaperQuantity_N"] = txtPaperQty.Text;
            Dr["VdrSendQty"] = txtVdrSendQty.Text;
            Dr["DisDtl_Id"] = "0";
            Dr["SndrReel"] = txtNoOfSndReel.Text;
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
                    Dr["PaperQuantity_N"] = txtPaperQty.Text;
                    Dr["VdrSendQty"] = txtVdrSendQty.Text;
                    Dr["DisDtl_Id"] = "0";
                    Dr["SndrReel"] = txtNoOfSndReel.Text;
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
        ddlPaperType.SelectedIndex = 0;
        ddlPaperSize.SelectedIndex = 0;
        txtPaperQty.Text = "0";
        txtVdrSendQty.Text = "0";
        txtNoOfSndReel.Text = "0";
        lblRemainingQty.Text = "0";
    }
    protected void GrdWorkPlan_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkUpdate = (LinkButton)e.Row.FindControl("lnkUpdate");
            LinkButton lnkDelete = (LinkButton)e.Row.FindControl("lnkDelete");
            if (Request.QueryString["ID"] != null)
            {
                lnkDelete.Visible = false;
                lnkUpdate.Visible = true;
            }
            else
            {
                lnkDelete.Visible = true;
                lnkUpdate.Visible = false;
            }
        }
    }
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");

        DataTable Dt = new DataTable();
        Dt = (DataTable)ViewState["TempData"];
        for (int i = 0; i < Dt.Rows.Count; i++)
        {
            string PaperMstrTrId_I = "";
            PaperMstrTrId_I = Dt.Rows[i]["PaperMstrTrId_I"].ToString();
            if (lblPaperMstrTrId_I.Text.ToLower() == PaperMstrTrId_I.ToLower())
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
    public int ChildInsertwithAcYear(PPR_PaperDispatchDetails obj)
    {
        DBAccess obDBAccess = new DBAccess();
        obDBAccess.execute("USP_PPR0014_PaperDispatchChildSaveDataNew", DBAccess.SQLType.IS_PROC);
        obDBAccess.addParam("mDisDtl_Id", obj.DisDtl_Id);
        obDBAccess.addParam("mDisTranId", obj.DisTranId);
        obDBAccess.addParam("mPaperMstrTrId_I", obj.PaperMstrTrId_I);
        obDBAccess.addParam("mVdrSendQty", obj.VdrSendQty);
        obDBAccess.addParam("mPaperType_I", obj.PaperType_I);
        obDBAccess.addParam("mReqQty", obj.ReqQty);
        obDBAccess.addParam("mSndrReel", obj.SndrReel);
        obDBAccess.addParam("mAcYear", ddlAcYear.SelectedItem.Text);
        int result = obDBAccess.executeMyQuery();
        return result;
    }
    protected void ddlAcYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            LOIFill();
        }
        catch { }
    }
}
