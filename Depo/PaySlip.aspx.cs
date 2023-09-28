using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_PaySlip : System.Web.UI.Page
{
    CommonFuction obCommanFun = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          
            aj.Visible = false;
            //
            for (int i = 2015; i <= System.DateTime.Now.Year + 1; i++)
            {
                ddlYear.Items.Add(i.ToString());
            }
            ddlMonth.DataTextField = "MonthFullName";
            ddlMonth.DataValueField = "MonthId";
            ddlMonth.DataSource = obCommanFun.FillDatasetByProc("call hr_get_months()");
            ddlMonth.DataBind();
            ddlMonth.Items.Insert(0, "सलेक्ट करे ..");
            ddlPaybiil.DataSource = obCommanFun.FillDatasetByProc(" SELECT * FROM HR_PaybillMaster WHERE DepoID="+Session["UserID"]+"");
            ddlPaybiil.DataTextField = "PaybillName";
            ddlPaybiil.DataValueField = "ID";
            ddlPaybiil.DataBind();
            //ddlPaybiil.Items.Insert(0, "सलेक्ट करे ..");
            ddlPaybiil_SelectedIndexChanged(sender, e);
         
           
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (ddlEmployeeName.SelectedIndex > 0 && ddlMonth.SelectedIndex > 0)
        {
            DataSet dt = obCommanFun.FillDatasetByProc("call USP_HR_PAySlip(" + ddlEmployeeName.SelectedValue + "," + ddlMonth.SelectedValue + ",'" + ddlYear.SelectedValue + "')");
            if (dt.Tables[0].Rows.Count > 0)
            {
                aj.Visible = true;
                lblBillNo.Text = ddlPaybiil.SelectedItem.Text ;
                lblPayBillRegisterNo.Text = "0";
                lblName.Text = Convert.ToString(dt.Tables[0].Rows[0]["EmployeeName"]);
                lblEmpcode.Text = Convert.ToString(dt.Tables[0].Rows[0]["EmployeeCode"]);
                lblDesgination.Text = Convert.ToString(dt.Tables[0].Rows[0]["DesignationName"]);
                lblmonth.Text = ddlMonth.SelectedItem.Text.ToUpper() + ", " + ddlYear.SelectedValue;
                lblEPF.Text = Convert.ToString(dt.Tables[0].Rows[0]["ODPFNo"]);
                //lblEPF.Text = Convert.ToString(dt.Tables[0].Rows[0]["DesignationName"]);
                lbl1.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["BEND"]).ToString("##0.00");
                lbl2.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["GRADEPAY"]).ToString("##0.00");
                lbl3.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["StagINC"]).ToString("##0.00");
                lbl4.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["SplPay"]).ToString("##0.00");
                lbl5.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["PerDaya"]).ToString("##0.00");
                lbl6.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["Deppay"]).ToString("##0.00");
                lbl7.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["DA"]).ToString("##0.00");
                lbl8.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["AddlDA"]).ToString("##0.00");
                lbl9.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["HRA"]).ToString("##0.00");
                lbl10.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["CCA"]).ToString("##0.00");

                lbla1.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["IR"]).ToString("##0.00");
                lbla2.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["LeaveSalaryE"]).ToString("##0.00");
                lbla3.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["WashAllow"]).ToString("##0.00");
                lbla4.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["TribalAllow"]).ToString("##0.00");
                lbla5.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["TutionFee"]).ToString("##0.00");
                lbla6.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["ConveyanceAllowance"]).ToString("##0.00");
                lbla7.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["MedAllow"]).ToString("##0.00");
                lbla8.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["otherallow"]).ToString("##0.00"); 
                // "0.00";
                lblGross.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["GrossSalary"]).ToString("##0.00");
                //--------------//--------------
                lbld1.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["IncomeTax"]).ToString("##0.00");
                lbld2.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["GIS"]).ToString("##0.00");
                lbld3.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["FBF"]).ToString("##0.00");

                lbld4.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["GPF"]).ToString("##0.00");
                if (lbld4.Text == "0.00")
                {
                    lbld4.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["EPF"]).ToString("##0.00");
                }

                lbld5.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["HouseRent"]).ToString("##0.00");
                lbld6.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["LeaveSalary"]).ToString("##0.00");
                lbld7.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["MotVehCharge"]).ToString("##0.00");

                lbld8.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["TARecovery"]).ToString("##0.00");
                lbld9.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["ProfTax"]).ToString("##0.00");
                lbld10.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["WelFund"]).ToString("##0.00");
                lbld11.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["LICRecovery"]).ToString("##0.00");

                lbldd1.Text = "0.00"; //Convert.ToString(dt.Tables[0].Rows[0]["LICRecovery"]);
                lbldd2.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["HBAdvance"]).ToString("##0.00");
                lbldd3.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["MotCar"]).ToString("##0.00");
                lbldd4.Text = "0.00";//Convert.ToString(dt.Tables[0].Rows[0]["LICRecovery"]);
                lbldd5.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["FestAdva"]).ToString("##0.00");
                lbldd7.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["GrainAdvancea"]).ToString("##0.00");
                lbldd6.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["AnyOtherDed"]).ToString("##0.00");
                lbldd8.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["payAdvancea"]).ToString("##0.00");
                lbldd9.Text = "0.00";// Convert.ToString(dt.Tables[0].Rows[0]["LICRecovery"]);
                lbldd10.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["MedAdva"]).ToString("##0.00");
                lbldd11.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["MISAdva"]).ToString("##0.00");
                lbltotalDedection.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["TotalDeduction"]).ToString("##0.00");
                lblnetsalary.Text = Convert.ToDecimal(Convert.ToDecimal(dt.Tables[0].Rows[0]["GrossSalary"]) - Convert.ToDecimal(dt.Tables[0].Rows[0]["TotalDeduction"])).ToString("##0.00");
                try {
                    Label1.Text = Convert.ToString(dt.Tables[1].Rows[0]["NoOfInsPay"]) + "/" + Convert.ToString(dt.Tables[1].Rows[0]["NoOfInstalment"]);
                if (Label1.Text == "")
                {
                    Label1.Text = "NIL";
                }
                }
                catch { Label1.Text = "NIL"; }
                try
                {
                    Label2.Text = Convert.ToString(dt.Tables[2].Rows[0]["NoOfInsPay"]) + "/" + Convert.ToString(dt.Tables[2].Rows[0]["NoOfInstalment"]);
                    if (Label2.Text == "")
                    {
                        Label2.Text = "NIL";
                    }
                }
                catch { Label2.Text = "NIL"; }
                try
                {
                    Label3.Text = Convert.ToString(dt.Tables[4].Rows[0]["NoOfInsPay"]) + "/" + Convert.ToString(dt.Tables[4].Rows[0]["NoOfInstalment"]);
                    if (Label3.Text == "")
                    {
                        Label3.Text = "NIL";
                    }
                }
                catch { Label3.Text = "NIL"; }
                try
                {
                    Label4.Text = Convert.ToString(dt.Tables[3].Rows[0]["NoOfInsPay"]) + "/" + Convert.ToString(dt.Tables[3].Rows[0]["NoOfInstalment"]);
                    if (Label4.Text == "")
                    {
                        Label4.Text = "NIL";
                    }
                }
                catch { Label4.Text = "NIL"; }
                try
                {
                    Label5.Text = Convert.ToString(dt.Tables[5].Rows[0]["NoOfInsPay"]) + "/" + Convert.ToString(dt.Tables[5].Rows[0]["NoOfInstalment"]);
                    if (Label5.Text == "")
                    {
                        Label5.Text = "NIL";
                    }
                }
                catch { Label5.Text = "NIL"; }

                try
                {
                    lbld12.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["NPSDed"]).ToString("##0.00");
               
                }
                catch { }
                try
                {
                    lbld13.Text = Convert.ToDecimal(dt.Tables[0].Rows[0]["EISS"]).ToString("##0.00");

                }
                catch { }
            }
            else
            {
                aj.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Pay slip not found.');</script>");
            }
        }
        else
        { ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please select searching criteria.');</script>"); }
    }
    protected void ddlPaybiil_SelectedIndexChanged(object sender, EventArgs e)
     {
        try {
        DataSet dta = obCommanFun.FillDatasetByProc("call USP_GetPayrollEmployee(" + ddlPaybiil.SelectedValue + ",0,0)");
        if (dta.Tables[2].Rows.Count > 0)
        {
            ddlEmployeeName.DataTextField = "EmployeeName";
            ddlEmployeeName.DataValueField = "EmployeeId";
            ddlEmployeeName.DataSource = dta.Tables[2];
            ddlEmployeeName.DataBind();
            ddlEmployeeName.Items.Insert(0, "सलेक्ट करे ..");
        }
        else
        {
            ddlEmployeeName.DataSource = string.Empty;
            ddlEmployeeName.DataBind();
            ddlEmployeeName.Items.Insert(0, "सलेक्ट करे ..");
        }
        }
        catch { }
    }
}