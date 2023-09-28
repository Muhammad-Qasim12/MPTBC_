using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Printing_TenderDetails : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    TenderDetails obTenderDetails = null;
    APIProcedure objapi = new APIProcedure();
    CommonFuction obCommonFunction = new CommonFuction();
    DataSet dt = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    obTenderDetails = new TenderDetails();
                    DataSet ds = new DataSet();
                  //  obTenderDetails.AcdmicYr_V =       Convert.ToString(Request.QueryString["Yr"]); 
                    obTenderDetails.AcdmicYr_V = Convert.ToString(objapi.Decrypt(Request.QueryString["Yr"]).ToString());    
                    obTenderDetails.ID = 1;
                    obTenderDetails.TenderId_I = Convert.ToInt32(objapi.Decrypt(Request.QueryString["ID"]).ToString());
                    ds = obTenderDetails.FillGridGroupDetail();
                    GrdGroupDetails.DataSource = ds;
                    GrdGroupDetails.DataBind();
                    //showdata(Request.QueryString[ID]);

                }

            }
            catch { }
            finally { obTenderDetails = null; }
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Session["TenderId_I"] = 0;
        //try
        //{
        //    obTenderDetails = new TenderDetails();
        //    obTenderDetails.AcdmicYr_V = Convert.ToString(ddlAcdmicYr_V.SelectedValue);
        //    obTenderDetails.TenderType_V = Convert.ToString(ddlTenderType_V.SelectedValue);
        //    obTenderDetails.TenderNo_V = Convert.ToString(txtTenderNo_V.Text.Trim());
        //    obTenderDetails.TenderDate_D = Convert.ToDateTime(txtTenderDate_D.Text, cult);
        //    obTenderDetails.LUNSendNo_V = Convert.ToString(txtLUNSendNo_V.Text.Trim());
        //    obTenderDetails.LUNDate_D = Convert.ToDateTime(txtLUNDate_D.Text, cult);
        //    obTenderDetails.NITDate_D = Convert.ToDateTime(txtNITDate_D.Text, cult);
        //    obTenderDetails.TenderDocFee_N = Convert.ToDecimal(txtTenderDocFee_N.Text);
        //    obTenderDetails.TenderSubmissionDate_D = Convert.ToDateTime(txtTenderSubmissionDate_D.Text, cult);
        //    obTenderDetails.TechBidopeningDate_D = Convert.ToDateTime(txtTechBidopeningDate_D.Text, cult);
        //    obTenderDetails.CommecialBidOpeningdate_D = Convert.ToDateTime(txtCommecialBidOpeningdate_D.Text, cult);
        //    obTenderDetails.Transdate_D = Convert.ToDateTime(System.DateTime.Now, cult);
        //    obTenderDetails.UserID_I = Convert.ToInt32(Session["UserID_I"]);

        //    obTenderDetails.TenderId_I = 0;
        //    if (HiddenField1.Value != "")
        //    {
        //        obTenderDetails.TenderId_I = 1;
        //        obTenderDetails.TenderId_I = Convert.ToInt32(HiddenField1.Value);
        //    }
        //    int LID = obTenderDetails.InsertUpdate();

        //    //if (HiddenField3.Value == "")
        //    //{
        //    int ch = 0;
        //        foreach (GridViewRow gv in GrdGroupDetails.Rows)
        //        {
        //            CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
        //            Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
        //            int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
        //            if (chk.Checked == true)
        //            {

        //                obTenderDetails.TenDetid_I = ch;
        //                obTenderDetails.TenderId_I = LID;
        //                obTenderDetails.GrpID_I = hd2;
        //                obTenderDetails.InsertGroup();
        //                ch++;
        //            }
        //        }
        //    //}
        //    //else if (HiddenField3.Value != "")
        //    //{
        //    //    obTenderDetails = new TenderDetails();
        //    //    obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
        //    //    DataSet obDataSet = obTenderDetails.Select();

        //    //    for (int i = 0; i < obDataSet.Tables[0].Rows.Count; i++)
        //    //    {
        //    //        foreach (GridViewRow gv in GrdGroupDetails.Rows)
        //    //        {
        //    //            CheckBox chk = (CheckBox)gv.FindControl("chkGroup");
        //    //            Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
        //    //            int hd2 = Convert.ToInt32(((HiddenField)gv.FindControl("HiddenField2")).Value);
        //    //            if (chk.Checked == true)
        //    //            {
        //    //                HiddenField3.Value = Convert.ToString(obDataSet.Tables[0].Rows[i]["TenDetid_I"]);
        //    //                obTenderDetails.TenDetid_I = Convert.ToInt32(HiddenField3.Value);
        //    //                obTenderDetails.TenderId_I = LID;
        //    //                obTenderDetails.GrpID_I = hd2;
        //    //                obTenderDetails.InsertGroup();
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    obCommonFuction = new CommonFuction();
        //    obCommonFuction.EmptyTextBoxes(this);
        //    HiddenField1.Value = "";
        //}
        //catch { }
        //finally
        //{
        //    obTenderDetails = null;
        //}
        Response.Redirect("VIEW_TenderDetails.aspx");

    }

    public void showdata(string ID)
    {
       // obTenderDetails = new TenderDetails();
       // obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
       // DataSet obDataSet = obTenderDetails.Select();

       // ddlAcdmicYr_V.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["AcdmicYr_V"]);
       // ddlTenderType_V.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenderType_V"]);
       // txtTenderNo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenderNo_V"]);
       // txtTenderDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["TenderDate_D"]).ToString("dd/MM/yyyy");
       // txtLUNSendNo_V.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["LUNSendNo_V"]);
       // txtLUNDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["LUNDate_D"]).ToString("dd/MM/yyyy");
       // txtNITDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["NITDate_D"]).ToString("dd/MM/yyyy");
       // txtTenderDocFee_N.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenderDocFee_N"]);
       // txtTenderSubmissionDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["TenderSubmissionDate_D"]).ToString("dd/MM/yyyy");
       // txtTechBidopeningDate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["TechBidopeningDate_D"]).ToString("dd/MM/yyyy");
       // txtCommecialBidOpeningdate_D.Text = Convert.ToDateTime(obDataSet.Tables[0].Rows[0]["CommecialBidOpeningdate_D"]).ToString("dd/MM/yyyy");
       // obTenderDetails.TenderId_I = 1;
       // HiddenField1.Value = (Request.QueryString["ID"]);
       //HiddenField3.Value = Convert.ToString(obDataSet.Tables[0].Rows[0]["TenDetid_I"]);
    }


    protected void GrdGroupDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //obTenderDetails = new TenderDetails();
        //obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
        //DataSet obDataSet = obTenderDetails.Select();

        //if (Convert.ToInt32(Request.QueryString["ID"]) != 0)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        CheckBox chkGroup = (CheckBox)e.Row.FindControl("chkGroup");
        //        Label lblGroupNO_V = (Label)e.Row.FindControl("lblGroupNO_V");
        //        int hd = Convert.ToInt32(((HiddenField)e.Row.FindControl("HiddenField2")).Value);
        //        for (int i = 0; i < obDataSet.Tables[0].Rows.Count; i++)
        //        {

        //            if (hd == Convert.ToInt32(obDataSet.Tables[0].Rows[0]["GrpID_I"]))
        //            {
        //                chkGroup.Checked = true;
        //            }
        //        }
        //    }
        //}
    }
    protected void GrdGroupDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
   
    protected void GrdGroupDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        

        try
        {
            Messages.Style.Add("display", "block");
            fadeDiv.Style.Add("display", "block");
            obTenderDetails = new TenderDetails();
            Session["TenderId_I"]=   Convert.ToInt32(((HiddenField)GrdGroupDetails.Rows[e.RowIndex].FindControl("HDNTenID")).Value);
            Session["GrpID_I"] = Convert.ToInt32(((HiddenField)GrdGroupDetails.Rows[e.RowIndex].FindControl("HdnGRP")).Value);
            obTenderDetails.TenderId_I = Convert.ToInt32(((HiddenField)GrdGroupDetails.Rows[e.RowIndex].FindControl("HDNTenID")).Value);
            obTenderDetails.GrpID_I = Convert.ToInt32(((HiddenField)GrdGroupDetails.Rows[e.RowIndex].FindControl("HdnGRP")).Value);
            GrdPrinter.DataSource = obTenderDetails.PrinterGroupwise();
            GrdPrinter.DataBind();
        }
        catch
        {


        }
        finally { obTenderDetails = null; }

        //HdnPaperAltID_I.Value = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnPaperAltID_I")).Value;
        //HdnBillInt.Value = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnBillIntID_I")).Value;

        //txtBookReturnDate.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnReturnDate_D")).Value;
        //txtNoDays.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnDays_N")).Value;
        //txtIntrestAmount.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnAmount_N")).Value;
        //txtIntrestRateonDays.Text = ((HiddenField)GrdPaperBill.Rows[e.RowIndex].FindControl("HdnInttperTon_I")).Value;
    }


    protected void btnSavePrinter_Click(object sender, EventArgs e)
    {
        int ch=0;
 obTenderDetails = new TenderDetails();
 try
 {

     foreach (GridViewRow gv in GrdPrinter.Rows)
     {
         TextBox txtrate = (TextBox)gv.FindControl("txtRate");
         // Label lblGroupNO_V = (Label)gv.FindControl("lblGroupNO_V");
       //  int hdTenEval = Convert.ToInt32(((HiddenField)gv.FindControl("HdnTenEval")).Value);
       //  int hdGrp = Convert.ToInt32(((HiddenField)gv.FindControl("HdnGRP")).Value);
         int hdPrn = Convert.ToInt32(((HiddenField)gv.FindControl("HdnPrinterID")).Value);

         if (txtrate.Text == "")
         {
             obTenderDetails.RateQuoated_N = 0.0; 
         }
         else
         {
             obTenderDetails.RateQuoated_N = Convert.ToDouble(txtrate.Text);
         }

        
            obTenderDetails.ID =ch;
          
            
            obTenderDetails.TenderId_I = Convert.ToInt32 ( Session["TenderId_I"]);
            obTenderDetails.GrpID_I = Convert.ToInt32 ( Session["GrpID_I"]);
            obTenderDetails.PrinterID_I = Convert.ToInt32(hdPrn);
           //  obTenderDetails.TenderId_I = hdTenEval;
           //  obTenderDetails.GrpID_I = hdGrp;
             obTenderDetails.InsertPrinterinGroup();
             ch++;
        
     }
 }
 catch { }
        finally { obTenderDetails = null;
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
        }
       

    }
    protected void ButClose_Click(object sender, EventArgs e)
    {Messages.Style.Add("display", "none");
   
         
        fadeDiv.Style.Add("display", "none");

    }


    protected void BtnLOI_Click(object sender, EventArgs e) 
    {
        LOIGeneratePrinterArrange();
        LOIGeneratePrinterAllot();
       
    }


    protected void btnViewLOI_Click(object sender, EventArgs e) 
    {
         try
        {
            dIVLOI.Style.Add("display", "block");
            fadeDiv.Style.Add("display", "block");
            obTenderDetails = new TenderDetails();
            obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
            GRVLOI.DataSource = obTenderDetails.LoadAllotedTenderList();
            GRVLOI.DataBind();
        }
        catch
        {
        }
         finally
         {
             obTenderDetails = null; 
         }
    
    
    }


    public void LOIGeneratePrinterArrange()
    {
        obTenderDetails = new TenderDetails();
        obTenderDetails.AcdmicYr_V = obCommonFunction.GetFinYear(); 
        if (Request.QueryString["ID"] != null)
        {
            obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
        }
            obTenderDetails.LOIGenrateprinterArrange();


        

    }

    public void LOIGeneratePrinterAllot()
    {
        obTenderDetails = new TenderDetails();

        obTenderDetails.AcdmicYr_V = obCommonFunction.GetFinYear(); 
            if (Request.QueryString["ID"] != null)
            {
                obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
            }
            obTenderDetails.LOIGenrateAllot_ofprinter();


        

    }


    public void  LoadAllotedTender() 
    {
        obTenderDetails = new TenderDetails();

        if (Request.QueryString["ID"] != null)
        {
            obTenderDetails.TenderId_I = Convert.ToInt32(Request.QueryString["ID"]);
        }
        GRVLOI.DataSource = obTenderDetails.LoadAllotedTenderList();
        GRVLOI.DataBind();

    }
    protected void lnBtnBack_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void butclose1_Click(object sender, EventArgs e)
    {
        dIVLOI.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void ButClose2_Click(object sender, EventArgs e)
    {
        dIVaLLOTEDtENDER.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");
    }
    protected void ButcloseMsg_Click(object sender, EventArgs e)
    {
        Messages.Style.Add("display", "none");
        fadeDiv.Style.Add("display", "none");

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string id= (objapi.Decrypt(Request.QueryString["ID"]).ToString());
        Response.Redirect("PRI004_TenderEvaluation.aspx?TenderId=" +objapi.Encrypt(id) + "");
    }
}