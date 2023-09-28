﻿using System;
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

public partial class Printing_PaperAllotment : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction ();
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
            obCommonFuction = new CommonFuction();
            txtSupplydate_D.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            DataSet dd = obCommonFuction.FillDatasetByProc("call ppr_GetPaperVendorbyAcYear('" + obCommonFuction.GetFinYear() + "')");
            ddlVenderName.DataSource = dd.Tables[0]; 
          ddlVenderName.DataTextField = "PaperVendorName_V";
          ddlVenderName.DataValueField = "PaperVendorTrId_I";
            ddlVenderName.DataBind();
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
        //if (ddlPaperType.SelectedItem.Value.ToString() == "1")
        //{
        //    txtTotalSheets.ReadOnly = true;
        //    RqTotalSheets.Visible = false;
        //    txtTotalSheets.Text = "0";
        //}
        //else
        //{
        //    txtTotalSheets.Text = "0";
        //    txtTotalSheets.ReadOnly = false;
        //    RqTotalSheets.Visible = true;
        //}
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

            DataSet ds = comm.FillDatasetByProc("call GetRegPrinterwithWorkOrder(0)");
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
            ddlAcadmicYear.SelectedValue = obCommonFuction.GetFinYearNew();
            ddlAcadmicYear.Items.Insert(0, "सलेक्ट करे");

            // Dropdown list of JobCode_V
            DataSet ds3=comm.FillDatasetByProc("call USP_PRI006_PaperAllotmentJobCode("+ddlPrinterName.SelectedValue+")");
        //    DataSet ds3 = obPRI_PaperAllotment.SelectddlJobCode();
            ddlJoBCode.DataSource = ds3;
            ddlJoBCode.DataTextField = "WorkorderID_I";
            ddlJoBCode.DataValueField = "WorkorderID_I";
            ddlJoBCode.DataBind();
            ddlJoBCode.Items.Insert(0, "सलेक्ट करे");
        }
        catch { }
        finally { obCommonFuction = null; }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        // Session["UserID"] = 0;
        Session["OfficeTrNo"] = 1;
        try
        {
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            if (Request.QueryString["ID"] != null)
            {
                obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
            }
            obPRI_PaperAllotment.AcadmicYR_V = Convert.ToString(ddlAcadmicYear.SelectedValue);
            obPRI_PaperAllotment.PrinterID_I = Convert.ToInt32(ddlPrinterName.SelectedValue);
            
            obPRI_PaperAllotment.PaperCategory_V = "0";
            obPRI_PaperAllotment.PaperOpt_I = 0;
            obPRI_PaperAllotment.PaperQty_N =0;

            obPRI_PaperAllotment.JobCode_V = Convert.ToString(ddlTitle.SelectedValue);
            obPRI_PaperAllotment.Supplydate_D = Convert.ToDateTime(txtSupplydate_D.Text, cult);
            obPRI_PaperAllotment.OrderNo = txtOrderNo.Text;            

            ds = obPRI_PaperAllotment.InsertUpdate();
            if (ds.Tables[0].Rows.Count > 0)
            {
                obPRI_PaperAllotment.PaperAltID_I = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                string CheckSts = "NotOk";
                //foreach (GridViewRow gv in GrdWorkPlan.Rows)
                //{
                //    Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
                //    Label lblPaperMstrTrId_I = (Label)gv.FindControl("lblPaperMstrTrId_I");
                //    Label lblPaperQuantity_N = (Label)gv.FindControl("lblPaperQuantity_N");
                //    Label lblTotalSheets = (Label)gv.FindControl("lblTotalSheets");

                //    obPRI_PaperAllotment.PaperCategory_V = lblPaperMstrTrId_I.Text;
                //    obPRI_PaperAllotment.PaperQty_N = Convert.ToDouble(lblPaperQuantity_N.Text);
                //    obPRI_PaperAllotment.PaperOpt_I = int.Parse(lblPaperType_I.Text);
                //    obPRI_PaperAllotment.TotalSheets = decimal.Parse(lblTotalSheets.Text);

                //    int i = obPRI_PaperAllotment.ChildInsert();
                //    if (i > 0)
                //    {
                //        CheckSts = "Ok";
                //    }
                //}
                int count = 0, count1=0; double PrintingPaper; string CoverPaper;
                string PaperType_I, PaperMstrTrId_I,TotalAllot;
                int i = 0;
                for (int j = 0; j < GrdWorkPlan0.Rows.Count; j++)
                {
                    if (count == 0)
                    {
                       // CheckBox1
                        //HiddenField2
                        count = count + 1; CheckSts = "Ok";
                        if (((CheckBox)GrdWorkPlan0.Rows[i].FindControl("CheckBox1")).Checked == true)
                        {

                            PrintingPaper = Convert.ToDouble(((TextBox)GrdWorkPlan0.Rows[j].FindControl("TextBox1")).Text);
                            //if (PrintingPaper == "")
                            //{
                            //    PrintingPaper = "0";
                            //}
                            PaperType_I = ((HiddenField)GrdWorkPlan0.Rows[j].FindControl("hdPaperType")).Value;
                            PaperMstrTrId_I = ((HiddenField)GrdWorkPlan0.Rows[j].FindControl("hdPrintingPaperID")).Value;
                            TotalAllot = ((HiddenField)GrdWorkPlan0.Rows[j].FindControl("HiddenField2")).Value;
                            if (Convert.ToDouble(((HiddenField)GrdWorkPlan0.Rows[j].FindControl("HiddenField3")).Value) < (Convert.ToDouble(PrintingPaper) + Convert.ToDouble(TotalAllot)))
                            {
                                obCommonFuction.FillDatasetByProc("call USP_deleteDataPaparAllotment(" + ds.Tables[0].Rows[0][0].ToString() + ")");
                                obPRI_PaperAllotment = new PRI_PaperAllotment();
                                obPRI_PaperAllotment.Delete(Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()));
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('प्रदाय की मात्रा दी जाने वाली मात्रा से जादा है ');</script>");
                                return;
                               
                            }
                            else
                            { 
                            count1 = count1 + 1;
                      
                       
                        obPRI_PaperAllotment.PaperAltID_I = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                        obPRI_PaperAllotment.PaperCategory_V = PaperMstrTrId_I.ToString();
                        obPRI_PaperAllotment.PaperQty_N = Convert.ToDouble(PrintingPaper);
                        obPRI_PaperAllotment.PaperOpt_I =Convert.ToInt32(PaperType_I);
                         i = obPRI_PaperAllotment.ChildInsert();

                        // obCommonFuction.FillDatasetByProc("call USP_PRintingUpdateData("+ddlVenderName.SelectedValue+","+RadioButtonList1.SelectedValue+","+i+")");
                            }
                        }
                    }
                    else {
                        if (((CheckBox)GrdWorkPlan0.Rows[i].FindControl("CheckBox1")).Checked == true)
                        {
                            CheckSts = "Ok";
                            count1 = count1 + 1;
                            TotalAllot = ((HiddenField)GrdWorkPlan0.Rows[j].FindControl("HiddenField2")).Value;
                            CoverPaper = ((TextBox)GrdWorkPlan0.Rows[j].FindControl("TextBox2")).Text;
                            if (CoverPaper == "")
                            {
                                CoverPaper = "0";
                            }
                            TotalSheets = Convert.ToDecimal(((TextBox)GrdWorkPlan0.Rows[j].FindControl("TextBox2")).Text);
                            PaperType_I = ((HiddenField)GrdWorkPlan0.Rows[j].FindControl("hdPaperType")).Value;
                            PaperMstrTrId_I = ((HiddenField)GrdWorkPlan0.Rows[j].FindControl("hdCoverPaperID")).Value;
                            if (Convert.ToDouble(((HiddenField) GrdWorkPlan0.Rows[j].FindControl("HiddenField3")).Value) < (Convert.ToDouble(CoverPaper) + Convert.ToDouble(TotalAllot)))
                            {
                                obCommonFuction.FillDatasetByProc("call USP_deleteDataPaparAllotment(" + ds.Tables[0].Rows[0][0].ToString() + ")");
                                //obPRI_PaperAllotment = new PRI_PaperAllotment();
                                //obPRI_PaperAllotment.Delete(Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()));
                                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('प्रदाय की मात्रा दी जाने वाली मात्रा से जादा है ');</script>");
                                return;
                                
                            }
                            else
                            {
                                obPRI_PaperAllotment.PaperAltID_I = int.Parse(ds.Tables[0].Rows[0][0].ToString());
                                obPRI_PaperAllotment.PaperCategory_V = PaperMstrTrId_I.ToString();
                                obPRI_PaperAllotment.PaperQty_N = Convert.ToDouble(CoverPaper);
                                obPRI_PaperAllotment.PaperOpt_I = Convert.ToInt32(PaperType_I);
                                obPRI_PaperAllotment.TotalSheets = Convert.ToDecimal(TotalSheets);
                                i = obPRI_PaperAllotment.ChildInsert();
                                                    }
                        }
                    }
                    obCommonFuction.FillDatasetByProc("call USP_PRintingUpdateData(" + ddlVenderName.SelectedValue + "," + RadioButtonList1.SelectedValue + "," + int.Parse(ds.Tables[0].Rows[0][0].ToString()) + ")");
       
                    if (count1 == 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Check Data');</script>");
                        return;
                    } 
                   if (i > 0)
                    {
                        CheckSts = "Ok";
                    }
                }
            
                    if (CheckSts == "Ok")
                    {
                        
                        
                      //  Response.Redirect("View_PRI006.aspx");
                        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
                    }

                obCommonFuction = new CommonFuction();
              //  obCommonFuction.EmptyTextBoxes(this);
                HiddenField1.Value = "";
                //Response.Redirect("View_PRI006.aspx");
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
        try { 
        GrdPaperAllotment.DataSource = obCommonFuction.FillDatasetByProc("call USP_PRI006_PaperAllotmentLoadNew("+ddlPrinterName.SelectedValue+","+txtOrderNo.Text+")");
        GrdPaperAllotment.DataBind();
        }
        catch { }
        btnADD0.Visible = true;
        GrdWorkPlan0.DataSource = null;
        GrdWorkPlan0.DataBind();
        ddlTitle.SelectedIndex = 0;
        //USP_PRI006_PaperAllotmentLoadNew
    }

    public void showdata(string ID)
    {
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        DataSet obDataSet = obPRI_PaperAllotment.Select();

        ddlAcadmicYear.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AcadmicYR_V"]);
        ddlPrinterName.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["PrinterID_I"]);
        ddlJoBCode.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["JobCode_V"]);
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
        
        CommonFuction comm = new CommonFuction();
        DataSet ds4 = comm.FillDatasetByProc("call GetPrintigandPaperSec("+ddlPrinterName.SelectedValue+",'"+ddlAcadmicYear.SelectedItem.Text +"')");
        try { 
        Label1.Text = ds4.Tables[0].Rows[0]["PaperSecurityAmount_N"].ToString();
        }
        catch {
            Label1.Text = "";
        }
        
        DataSet ds3 = comm.FillDatasetByProc("call USP_PRI006_PaperAllotmentJobCodeNew(" + ddlPrinterName.SelectedValue + ",'"+ddlAcadmicYear.SelectedItem.Text+"')");
        //    DataSet ds3 = obPRI_PaperAllotment.SelectddlJobCode();
        ddlJoBCode.DataSource = ds3;
        ddlJoBCode.DataTextField = "WorkorderNo_V";
        ddlJoBCode.DataValueField = "WorkorderID_I";
        ddlJoBCode.DataBind();
        ddlJoBCode.Items.Insert(0, "सलेक्ट करे");
        GrdWorkPlan0.DataSource = null;
        GrdWorkPlan0.DataBind();
        ddlTitle.SelectedIndex = -1;
      //  CommonFuction comm = new CommonFuction();
        try { 
        DataSet ds31 = comm.FillDatasetByProc("call GetPrintertitleAllotmentNew(2,0,"+ddlPrinterName.SelectedValue+",'"+ddlAcadmicYear.SelectedItem.Text+"')");
        //    DataSet ds3 = obPRI_PaperAllotment.SelectddlJobCode();
        ddlTitle.DataSource = ds31;
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleId";
        ddlTitle.DataBind();
        ddlTitle.Items.Insert(0, "सलेक्ट करे");
        }
        catch { }
    }
    protected void ddlJoBCode_SelectedIndexChanged(object sender, EventArgs e)
    {
        //
        CommonFuction comm = new CommonFuction();
        DataSet ds31 = comm.FillDatasetByProc("call GetPrintertitleAllotment(2," + ddlJoBCode.SelectedValue + ")");
        //    DataSet ds3 = obPRI_PaperAllotment.SelectddlJobCode();
        ddlTitle.DataSource = ds31;
        ddlTitle.DataTextField = "TitleHindi_V";
        ddlTitle.DataValueField = "TitleId";
        ddlTitle.DataBind();
       ddlTitle.Items.Insert(0, "सलेक्ट करे");
        //CommonFuction comm = new CommonFuction();
       
    }

    protected void ddlTitle_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        //foreach (ListItem items in ddlTitle.Items)
        //{
        //    if (items.Selected)
        //    {

        //        if (str1 == "")
        //        {

        //            str1 = items.Value;
        //        }
        //        else
        //        {
        //            count12 = count12 + 1;
        //            str1 = str1 + "," + items.Value;
        //        }
        //    }
        //}
        DataSet ds311 = comm.FillDatasetByProc("call GetWorkOrderbyPapertest(0," + ddlTitle.SelectedValue + ",'" + ddlPrinterName.SelectedValue + "','" + ddlAcadmicYear.SelectedItem.Text + "')");
        GrdWorkPlan0.DataSource = ds311.Tables[0];
        GrdWorkPlan0.DataBind();
    }
    protected void ddlAcadmicYear_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnADD0_Click(object sender, EventArgs e)
    {
        
        obCommonFuction.FillDatasetByProc("call UpdateStatusPaperAllotment('"+txtOrderNo.Text+"')");
        Response.Redirect("View_PRI006.aspx");
    }

    double PrintingPaper, Coverpaper;
    protected void GrdPaperAllotment_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    //TextBox lblPerBundle = (TextBox)e.Row.FindControl("txtYojna");
                    PrintingPaper += Convert.ToDouble(e.Row.Cells[5].Text);
                }
                catch { }
                try
                {
                    //TextBox txtSamany = (TextBox)e.Row.FindControl("txtSamany");
                    Coverpaper += Convert.ToDouble(e.Row.Cells[6].Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[5].Text = PrintingPaper.ToString();
            e.Row.Cells[6].Text = Coverpaper.ToString();

        }

    }
}