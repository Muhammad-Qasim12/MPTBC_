using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Distribution_FreeTextBooksDemandFromRSK : System.Web.UI.Page
{
    MPTBCBussinessLayer.DistributionB.BillPayment obBillPayment = new MPTBCBussinessLayer.DistributionB.BillPayment();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
           
            FillCombo();

            hdnProcessBillID.Value = "0";
            if (Request.QueryString["ID"] != null)
            {
                try
                {
                    int id = int.Parse(new APIProcedure().Decrypt(Request.QueryString["ID"].ToString()));
                    hdnProcessBillID.Value = id.ToString();
                    FillFreeDistributionData(id.ToString());
                }
                catch {
                    hdnProcessBillID.Value = "0";
                }
                
            }
          
          
        }
    }
    private void FillFreeDistributionData(string ProcessBillID)
    {
        obBillPayment.TransID = -8;
        obBillPayment.QueryParameterValue = int.Parse(ProcessBillID);
        DataSet dsobFreeBooksDistribution = obBillPayment.Select();
        ddlAcademicSession.ClearSelection();
        if (dsobFreeBooksDistribution.Tables[0].Rows.Count > 0)
        {
            ddlAcademicSession.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["AcYearID_I"].ToString();
            FillFinaincialYear();
            
            txtLetterNo.Text = dsobFreeBooksDistribution.Tables[0].Rows[0]["LetterNo_V"].ToString();
            txtLetterDate.Text = Convert.ToDateTime(dsobFreeBooksDistribution.Tables[0].Rows[0]["LetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            txtRefLetterNo.Text = dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterNo_V"].ToString();
            try
            {
                txtRefLetterDate.Text = Convert.ToDateTime(dsobFreeBooksDistribution.Tables[0].Rows[0]["RefLetterDate_D"].ToString()).ToString("dd/MM/yyyy");
            }
            catch
            {
                txtRefLetterDate.Text = "";
            }
          

            ddlBillType.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["BillType_V"].ToString();
            ddlDepartment.SelectedValue = dsobFreeBooksDistribution.Tables[0].Rows[0]["DepartmentID_I"].ToString();

            FillGrid();
            //obBillPayment.TransID = -9;
            //obBillPayment.QueryParameterValue = int.Parse(ProcessBillID);
           
            //grdSelectedTitle.DataSource = obBillPayment.Select().Tables[0];
            //grdSelectedTitle.DataBind();
            //CalculateTotal();
          
        }
    }
    private void FillCombo()
    {
        //ddlAcademicSession
        //ddlClass

        obBillPayment.TransID = -1;
        ddlAcademicSession.DataSource = obBillPayment.Select();
        ddlAcademicSession.DataTextField = "AcYear";
        ddlAcademicSession.DataValueField = "Id";
        ddlAcademicSession.DataBind();
        FillFinaincialYear();

        //obProcessBill.TransID = -3;
        //ddlTitle.DataSource = obProcessBill.Select();
        //ddlTitle.DataTextField = "TitleHindi_V";
        //ddlTitle.DataValueField = "TitleID_I";
        //ddlTitle.DataBind();
        //FillSubTitle();

        obBillPayment.TransID = -6;
        ddlDepartment.DataSource = obBillPayment.Select();
        ddlDepartment.DataTextField = "DepartmentName_V";
        ddlDepartment.DataValueField = "DepartmentID_I";
        ddlDepartment.DataBind();
      
        
    }
    protected void ddlAcademicSession_OnSelectedIndexChanged(object sender, EventArgs e)
    {

        FillFinaincialYear();
    }
    private void FillFinaincialYear()
    {
        obBillPayment.TransID = -2;
        obBillPayment.QueryParameterValue = int.Parse(ddlAcademicSession.SelectedValue);
        DataSet dsAcademicYear = obBillPayment.Select();
        if (dsAcademicYear.Tables[0].Rows.Count > 0)
        {
            lblFinancialYear.Text = dsAcademicYear.Tables[0].Rows[0]["FyYear"].ToString();
        }
        else
        {
            lblFinancialYear.Text = "--";
        }
    }  
    protected void ddlClass_OnSelectedIndexChanged(object sender, EventArgs e) 
    {
     
      

    }

    //protected void ddlTitle_OnSelectedIndexChanged(object sender, EventArgs e) 
    //{
    //    FillSubTitle();
    //}
    //private void FillSubTitle()
    //{
    //    //obProcessBill.TransID = -5;
    //    //obProcessBill.QueryParameterValue = int.Parse(ddlTitle.SelectedValue);       
    //    //DataSet dsTitle=obProcessBill.Select();
    //    //ddlSubTitle.DataSource = dsTitle.Tables[0];
    //    //ddlSubTitle.DataTextField = "SubTitleHindi_V";
    //    //ddlSubTitle.DataValueField = "SubTitleID_I";
    //    //ddlSubTitle.DataBind();
        
       
    //}
   
    private void FillGrid()
    {
        obBillPayment.TransID = -9;
        obBillPayment.QueryParameterValue = int.Parse(hdnProcessBillID.Value);
        grdSelectedTitle.DataSource = obBillPayment.Select();
        grdSelectedTitle.DataBind();
        CalculateTotal();
    }

    private void CalculateTotal()
    {
       // double TotalAmount = 0;
       //// double TotalRemAmount = 0;
       // for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
       // {
       //     TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[7].Text);
       //    // TotalRemAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[6].Text);
       // }

       // lblTotalAmount.Text = Convert.ToString(Math.Round(TotalAmount, 2));
       // obBillPayment.TransID = -11;
       // obBillPayment.QueryParameterValue = int.Parse(hdnProcessBillID.Value);
       // DataSet dsPayment = obBillPayment.Select();
       // if (dsPayment.Tables[0] != null && dsPayment.Tables[0].Rows.Count > 0)
       // {
       //     lblLastPayment.Text = dsPayment.Tables[0].Rows[0]["LastPayment"].ToString();
       //     lblPaidTDS.Text = dsPayment.Tables[0].Rows[0]["TDS"].ToString();
       // }
       // else
       // {
       //     lblPaidTDS.Text = "0";
       //     lblLastPayment.Text = "0";
       // }
        double TotalAmount = 0;
        int TotalBooks = 0;
        double TotalDiscount = 0;
        double TotalNetAmount = 0;

        for (int rowno = 0; rowno < grdSelectedTitle.Rows.Count; rowno++)
        {
            //   TotalAmount += double.Parse(grdSelectedTitle.Rows[rowno].Cells[10].Text);
            Label lblTotalBooks = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblBooks");
            Label lblDiscount = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblDiscount");
            Label lblNetAmount = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblNetAmount");
            Label lblAmount = (Label)grdSelectedTitle.Rows[rowno].FindControl("lblAmount");

            TotalDiscount += double.Parse(lblDiscount.Text);
            TotalAmount += double.Parse(lblAmount.Text);
            TotalBooks += int.Parse(lblTotalBooks.Text);
            TotalNetAmount += double.Parse(lblNetAmount.Text);

        }

        try
        {
            Label lblFtTotalBooks = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalBooks");
            Label lblFtTotalDiscount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalDiscount");
            Label lblFtTotalNetAmount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalNetAmount");
            Label lblFtTotalAmount = (Label)grdSelectedTitle.FooterRow.FindControl("lblTotalAmount");

            lblFtTotalBooks.Text = TotalBooks.ToString();
            lblFtTotalDiscount.Text = TotalDiscount.ToString();
            lblFtTotalNetAmount.Text = TotalNetAmount.ToString();
            lblFtTotalAmount.Text = TotalAmount.ToString();
        }
        catch { }

        obBillPayment.TransID = -11;
        obBillPayment.QueryParameterValue = int.Parse(hdnProcessBillID.Value);
        DataSet dsPayment = obBillPayment.Select();
        if (dsPayment.Tables[0] != null && dsPayment.Tables[0].Rows.Count > 0)
        {
            lblLastPayment.Text = dsPayment.Tables[0].Rows[0]["LastPayment"].ToString();
            lblPaidTDS.Text = dsPayment.Tables[0].Rows[0]["TDS"].ToString();    
        }
        else
        {
            lblPaidTDS.Text = "0";
            lblLastPayment.Text = "0";
        }
        lblTotalAmount.Text = Convert.ToString(Math.Round(TotalNetAmount, 2));
        lblRemAmount.Text = Convert.ToString(TotalNetAmount - double.Parse(lblLastPayment.Text) - double.Parse(lblPaidTDS.Text));
    }
    private bool CheckDateFormate(string DateValue)
    {
        try
        {
            DateTime dtTmp = DateTime.Parse(DateValue, cult);
            return true;
        }
        catch
        {
            return false;
        }
    }

    protected void btnSavePayment_Click(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/login.aspx");
        }
        else
        {
            try
            {
                obBillPayment.ProcessBillDetailsTrno_I = int.Parse(hdnProcessBillDetailsTrno.Value);
                obBillPayment.TotalPaidTitles_I = int.Parse(txtTotalTitle.Text);
                obBillPayment.TdsAmount_I = double.Parse(txtTDS.Text);
                obBillPayment.PaidAmount_I = double.Parse(txtPaidAmount.Text);
                obBillPayment.ChqNo_V = txtChqNo.Text;
                obBillPayment.ChqDate_D = DateTime.Parse(txtChqDate.Text, cult).ToString("yyyy-MM-dd");
                obBillPayment.BankName_V = txtBankName.Text;
                obBillPayment.LetterNo_V = txtPayLetterNo.Text;
                obBillPayment.LetterDate_D = DateTime.Parse(txtPayLetterDate.Text, cult).ToString("yyyy-MM-dd");

                obBillPayment.UserID = int.Parse(Session["UserID"].ToString());
                obBillPayment.PaymentMode = ddlPaymentMode.SelectedValue;
                obBillPayment.TransID = 0;
                obBillPayment.InsertUpdate();

                FillPaymentGrid();
                pnlPopupMessage.CssClass = "form-message success";
                pnlPopupMessage.Visible = true;
                lblPopupMessage.Text = "Record saved successfully";
            }
            catch
            {
                pnlPopupMessage.CssClass = "form-message error";
                pnlPopupMessage.Visible = true;
                lblPopupMessage.Text = "Error in data please check";
            }
        }
    }


    private void FillPaymentGrid()
    {
        obBillPayment.TransID = -10;
        obBillPayment.QueryParameterValue = int.Parse(hdnProcessBillID.Value);
        DataSet dsPayment= obBillPayment.Select();
        if (dsPayment.Tables[0] != null && dsPayment.Tables[0].Rows.Count > 0)
        {
            divPopupPayment.Visible = true;
            GrdPayement.DataSource = dsPayment.Tables[0];
            GrdPayement.DataBind();
        }
        else
        {
            divPopupPayment.Visible = false;
        }
    }

    protected void btnClosePopup_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "none");
        Messages.Style.Add("display", "none");

        FillGrid();
    }
    protected void btnSupply_Click(object sender, EventArgs e)
    {
        /*
        mainDiv.Style.Add("display", "none");
        lblmsg.Text = string.Empty;

        int ProcessBillID = 0;
        dtSelectedTitle = (DataTable)ViewState["dtSelectedTitle"];

        if (!CheckDateFormate(txtLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid letter date";
        }
        else if (!CheckDateFormate(txtRefLetterDate.Text))
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Invalid Reference letter date";
        }
        else if (DateTime.Parse(txtLetterDate.Text) > DateTime.Now.Date ||
             DateTime.Parse(txtRefLetterDate.Text) > DateTime.Now.Date)
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Date can not be future date";
        }
        else if (dtSelectedTitle.Rows.Count > 0)
        {
            int.TryParse(hdnProcessBillID.Value, out ProcessBillID);
            obBillPayment.ProcessBillTrno = ProcessBillID;


            obBillPayment.AcYearID = int.Parse(ddlAcademicSession.SelectedValue);
            obBillPayment.LetterNo = txtLetterNo.Text;
            obBillPayment.LetterDate = DateTime.Parse(txtLetterDate.Text).ToString("yyyy-MM-dd");
            obBillPayment.RefLetterNo = txtRefLetterNo.Text;
            obBillPayment.RefLetterDate = DateTime.Parse(txtRefLetterDate.Text).ToString("yyyy-MM-dd");        
            obBillPayment.DepartmentID = int.Parse(ddlDepartment.SelectedValue);
            obBillPayment.BillType = ddlBillType.SelectedValue;
      
            obBillPayment.TransID = ProcessBillID;
            hdnProcessBillID.Value = obBillPayment.InsertUpdate().ToString();

            for (int i = 0; i < dtSelectedTitle.Rows.Count; i++)
            {
                int.TryParse(hdnProcessBillID.Value, out ProcessBillID);
                obBillPayment.ProcessBillTrno = ProcessBillID;
                obBillPayment.SubTitleID = int.Parse(dtSelectedTitle.Rows[i]["SubTitleID"].ToString());
                obBillPayment.TotalBooks = int.Parse(dtSelectedTitle.Rows[i]["TotalBooks"].ToString());
                obBillPayment.Rate = double.Parse(dtSelectedTitle.Rows[i]["Rate"].ToString());
                obBillPayment.DiscountPercent = double.Parse(dtSelectedTitle.Rows[i]["DiscountPercent"].ToString());
                obBillPayment.TransID = -1;
                obBillPayment.InsertUpdate();
            }
            
            Response.Redirect("View_DIB_008.aspx");
        }
        else
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Please select at least one title";
        }
         * */
    }
    private void ResetFields()
    {
        grdSelectedTitle.DataSource = null;
        grdSelectedTitle.DataBind();
        txtLetterNo.Text = "";
        txtLetterDate.Text = "";
        txtRefLetterDate.Text = "";
        txtRefLetterNo.Text = "";
       
    }
    protected void grdSelectedTitle_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        //dtSelectedTitle =(DataTable) ViewState["dtSelectedTitle"];        
        //dtSelectedTitle.Rows[e.RowIndex].Delete();
        //dtSelectedTitle.AcceptChanges();
        //ViewState["dtSelectedTitle"] = dtSelectedTitle;
        //FillGrid();
    }
    protected void grdSelectedTitle_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
       
    }
    protected void GrdPayement_OnRowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
    {
        try
        {
          
            obBillPayment.Delete(int.Parse(GrdPayement.DataKeys[e.RowIndex].Value.ToString()));
            FillPaymentGrid();
            pnlPopupMessage.CssClass = "form-message success";
            pnlPopupMessage.Visible = true;
            lblPopupMessage.Text= "Record deleted successfully";
        }
        catch
        {
            mainDiv.Style.Add("display", "block");
            lblmsg.Text = "Error in delete";
        }

    }
    protected void GrdLetterInfo_OnRowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        //obClassMaster = new ClassMaster();
        //obClassMaster.Delete(Convert.ToInt32(GrdClassMaster.DataKeys[e.RowIndex].Value.ToString()));
        //FillData();
    }
    protected void btnPayment_Click(object sender, EventArgs e)
    {
        fadeDiv.Style.Add("display", "block");
        Messages.Style.Add("display", "block");

        //TextBox txtProcessDetailTrID = (TextBox)grdSelectedTitle.Rows[e.NewEditIndex].FindControl("txtProcessBillDetailsTrno");
        hdnProcessBillDetailsTrno.Value = hdnProcessBillID.Value;

        lblTitleName.Text = grdSelectedTitle.Rows[0].Cells[1].Text;
        //lblSubTitle.Text = grdSelectedTitle.Rows[e.NewEditIndex].Cells[1].Text;
        txtBankName.Text = "";
        txtChqDate.Text = "";
        txtChqNo.Text = "";
        txtLetterDate.Text = "";
        txtLetterNo.Text = "";
        txtPaidAmount.Text = "";
        txtPayLetterDate.Text = "";
        txtPayLetterNo.Text = "";
        txtTDS.Text = "";
        txtPayLetterDate.Text = "";
        ddlPaymentMode.SelectedValue = "0";
        ddlPaymentMode_SelectedIndexChanged(sender, e);
        FillPaymentGrid();
    }
    protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlPaymentMode.SelectedValue=="0")
        {
            lblPaymentNO.Text = "";
            lblPaymentDate.Text = "";
            pnlPaymentDetails.Visible = false;
        }
        else
        {
            lblPaymentDate.Text = ddlPaymentMode.SelectedValue + " Date :";
            lblPaymentNO.Text = ddlPaymentMode.SelectedValue + " No :";
            pnlPaymentDetails.Visible = true;
        }
    }
}
