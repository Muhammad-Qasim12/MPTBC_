using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillDetails : System.Web.UI.Page
{
    CommonFuction obcomm = new CommonFuction();
    string leaderName = string.Empty;
    string ChallanNo = string.Empty;    
    int ltSno = 1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tblBldg.Visible = false;
            tblPri.Visible = false;

            try
            {
                string uid = Session["UserID"].ToString();
                GetDesignationId();

                if (HDNRedirect.Text != "")
                {
                    Response.Redirect("~/" + HDNRedirect.Text);
                }
            }
            catch { }
        }
    }

    
    public void GetDesignationId()
    {
        try
        {
            string UserID = Session["UserID"].ToString();
            DataTable dt = obcomm.FillDatasetByProc("call USP_LIST_HR_Employee_Basic_Fiters(18,0,0," + UserID + ",'')").Tables[0];
            if (dt.Rows.Count > 0)
            {
                hfDesignationId.Value = dt.Rows[0]["CEDesignationId"].ToString();
                hfDepartmentId.Value = dt.Rows[0]["DepartmentId"].ToString();
                hfLoggedInDepartment.Value = dt.Rows[0]["DepartmentName"].ToString();

                if (dt.Rows[0]["DepartmentName"] != null)
                {
                    if (hfLoggedInDepartment.Value == "Printing")
                    {                        
                        //HDNRedirect.Text = "Printing/Viewbilldetails.aspx";
                        tblPri.Visible = true;
                        tblBldg.Visible = false;
                        HDNRedirect.Text = "";
                    }
                    else if (hfLoggedInDepartment.Value == "Paper")
                    {
                        HDNRedirect.Text = "paper/ViewPPR_013_VD.aspx";
                    }
                    else if (hfLoggedInDepartment.Value == "Account")
                    {
                        if (hfDesignationId.Value == "11")
                        {
                            //HDNRedirect.Text = "Store/Store/ViewStoreBillDetails.aspx";
                            HDNRedirect.Text = "hr/ViewPayrollBill.aspx";
                        }
                        else if (hfDesignationId.Value == "8")
                        {
                            HDNRedirect.Text = "Store/ViewStoreBillDetails.aspx";
                        }
                        else
                        {
                            tblBldg.Visible = false;
                            tblPri.Visible = false;

                        }
                    }
                    else if (hfLoggedInDepartment.Value == "Building & Vehicle")
                    {
                        tblPri.Visible = false;
                        tblBldg.Visible = true;
                        HDNRedirect.Text = "";
                    }
                }
            }
            else
            {
                hfDesignationId.Value = "0";
                hfDepartmentId.Value = "0";
            }

        }
        catch { }
    }



    protected void rdPriBill_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdPriBill.SelectedValue != null && rdPriBill.SelectedValue.ToString() !="")
            {
                if (rdPriBill.SelectedValue == "r")   //running printing bill
                {
                    HDNRedirect.Text = "Printing/Viewbilldetails.aspx";
                }
                else if (rdPriBill.SelectedValue == "f")   //final printing bill
                {
                    HDNRedirect.Text = "Printing/ViewPRI008FinalBillDetails.aspx";
                }

                if (HDNRedirect.Text != "")
                {
                    Response.Redirect("~/" + HDNRedirect.Text);
                }
            }
        }
        catch { }
    }

    protected void rdBldgbill_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (rdBldgbill.SelectedValue != null && rdBldgbill.SelectedValue.ToString() != "")
            {
                if (rdBldgbill.SelectedValue == "b")   //building bill
                {
                    HDNRedirect.Text = "Building/VIEW006_BillPayment.aspx";
                }
                else if (rdBldgbill.SelectedValue == "v")   //vehicle bill
                {
                    HDNRedirect.Text = "Vehicle/VIEW005_BillProcess.aspx";
                }

                if (HDNRedirect.Text != "")
                {
                    Response.Redirect("~/" + HDNRedirect.Text);
                }
            }
        }
        catch { }
    }
}