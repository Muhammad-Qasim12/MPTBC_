using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_DPT007_AdvanceDetails : System.Web.UI.Page
{
    HeadMaster obHeadMaster = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    AdvanceDetails obAdvanceDetails = null;

    CommonFuction obCommonFuction = null;
    string TrNo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                

                obCommonFuction = new CommonFuction();
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
                ddlQ.DataTextField = "MonthFullName";
                ddlQ.DataValueField = "MonthId";
                ddlQ.DataSource = obCommonFuction.FillDatasetByProc("call hr_get_months()");
                ddlQ.DataBind();
                ddlQ.Items.Insert(0, "सलेक्ट करे ..");
                ddlQ0.DataTextField = "MonthFullName";
                ddlQ0.DataValueField = "MonthId";
                ddlQ0.DataSource = obCommonFuction.FillDatasetByProc("call hr_get_months()");
                ddlQ0.DataBind();
                ddlQ0.Items.Insert(0, "सलेक्ट करे ..");
                if (Request.QueryString["ID"] != null)
                {
                    showdata(Request.QueryString[ID]);

                }

            }
            catch { }
            finally { obCommonFuction = null; }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        string MonthTo;
        if (ddlQ0.SelectedIndex == -1 || ddlQ0.SelectedValue == "सलेक्ट करे ..")
        {
            MonthTo ="0";
        }
        else
        {
            MonthTo = ddlQ0.SelectedValue;
        }
        foreach (GridViewRow grdrow in GrdAdvance.Rows)
        {
            if (((CheckBox)grdrow.FindControl("chk")).Checked)
            {
                try

                {

                    TextBox txtEstimateAmount = (TextBox)grdrow.FindControl("txtEstimateAmount");
                    TextBox txtAvailableAmount = (TextBox)grdrow.FindControl("txtAvailableAmount");
                    TextBox txtrequestAmount = (TextBox)grdrow.FindControl("txtrequestAmount");
                    if (txtEstimateAmount.Text == "" || txtAvailableAmount.Text == "" || txtrequestAmount.Text == "")
                    {
                      
                        return;
                    }
                    else
                    {

                       

                        //obAdvanceDetails = new AdvanceDetails();
                        //obAdvanceDetails.Ddate_D = Convert.ToDateTime(txtDate.Text, cult);
                        //obAdvanceDetails.HeadID = Convert.ToInt32(((HiddenField)grdrow.FindControl("hdnHeadId")).Value);
                        //obAdvanceDetails.QuarterNAme = Convert.ToString(ddlQ.SelectedItem.Value);
                        //obAdvanceDetails.Amount = Convert.ToDouble(txtrequestAmount.Text);
                        //obAdvanceDetails.AvailableCost = Convert.ToDouble(txtAvailableAmount.Text);
                        //obAdvanceDetails.EstimateCost = Convert.ToDouble(txtEstimateAmount.Text);
                        //obAdvanceDetails.Trans_I = 0;
                        TrNo = "0";
                        if (HiddenField1.Value != "")
                        {
                            TrNo = "1";
                            HiddenField1.Value = (HiddenField1.Value);
                        }
                        else
                        {
                            HiddenField1.Value = "0";
                        }
                        //obAdvanceDetails.TransactionDate = Convert.ToDateTime(System.DateTime.Now, cult);
                        //obAdvanceDetails.UserID = Convert.ToInt32(Session["UserID"]);
                        //obAdvanceDetails.DepoID = Convert.ToInt32(Session["UserID"]);
                       // obAdvanceDetails.InsertUpdate();
                        obCommonFuction = new CommonFuction();
                        obCommonFuction.FillDatasetByProc("call UPS_DPT006_AdvanceDetails_Save1(" + HiddenField1.Value + "," + ((HiddenField)grdrow.FindControl("hdnHeadId")).Value + "," + txtrequestAmount.Text + "," + ddlQ.SelectedItem.Value + "," + Session["UserID"] + ",'" + Convert.ToDateTime(System.DateTime.Now, cult).ToString("yyyy-MM-dd") + "'," + Session["UserID"] + "," + TrNo + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + Convert.ToDouble(txtEstimateAmount.Text) + "," + txtAvailableAmount.Text + ",'" + DdlACYear.SelectedValue + "','"+TextBox1.Text+"','"+MonthTo+"')");
                        HiddenField1.Value = "";
                    }
                }
                catch { }
                finally
                {
                   // obAdvanceDetails = null;
                }
            }
        }
        Response.Redirect("VIEW_DPT006.aspx");
    }
    public void showdata(string ID)
    {
        APIProcedure api = new APIProcedure();
        obAdvanceDetails = new AdvanceDetails();
        obAdvanceDetails.AdvanceDetailsID = Convert.ToInt32(api.Decrypt(Request.QueryString["ID"].ToString ()));
        obAdvanceDetails.UserID = Convert.ToInt32(Session["UserID"]);
        DataSet obDataSet = obAdvanceDetails.Select();
        HiddenField1.Value = (api.Decrypt(Request.QueryString["ID"].ToString()));
        txtDate.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Ddate_D1"]);
      //  txtAmount.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Amount"]);
        ddlQ.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["QuarterNAme"]);

        ViewState["dt"] = obDataSet.Tables[0];
        GrdAdvance.DataSource = obDataSet;
        GrdAdvance.DataBind();
        //ddlQ.SelectedIndex = -1;
        //ddlQ.Items.FindByText (Convert.ToString( obDataSet.Tables[0].Rows[0]["QuarterNAme"])).Selected=true ;
        //ddlHeadName.SelectedValue = Convert.ToString(obDataSet.Tables[0].Rows[0]["HeadID"]);
       
    }
    protected void ddlQ_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
        {

            obHeadMaster = new HeadMaster();
            obHeadMaster.transID_I = 0;
            DataSet ds = obHeadMaster.Select();
            GrdAdvance.DataSource = ds;
            GrdAdvance.DataBind();
        }
    }
    protected void txtAmountChanged(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((TextBox)(sender)).NamingContainer;
        TextBox  txtEstimateAmount = (TextBox)grdrow.FindControl("txtEstimateAmount");
        TextBox txtAvailableAmount = (TextBox)grdrow.FindControl("txtAvailableAmount");
        TextBox txtrequestAmount = (TextBox)grdrow.FindControl("txtrequestAmount");
        if (txtEstimateAmount.Text != "")
        {
            if ((Convert.ToDouble(txtEstimateAmount.Text) - Convert.ToDouble(txtAvailableAmount.Text)) > 0)
            {
                txtrequestAmount.Text = (Convert.ToDouble(txtEstimateAmount.Text) - Convert.ToDouble(txtAvailableAmount.Text)).ToString();
            }
            else {
                txtrequestAmount.Text = "0";
            }
        
        }
    }
    protected void GrdAdvance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try{
        if (Request.QueryString["ID"] != null)
        {
            TextBox txtEstimateAmount = (TextBox)e.Row.FindControl("txtEstimateAmount");
            TextBox txtAvailableAmount = (TextBox)e.Row.FindControl("txtAvailableAmount");
            TextBox txtrequestAmount = (TextBox)e.Row.FindControl("txtrequestAmount");
            DataTable dt =  (DataTable) ViewState["dt"];
            txtEstimateAmount.Text =Convert.ToString(dt.Rows[0]["EstimateCost"]);
            txtAvailableAmount.Text = Convert.ToString(dt.Rows[0]["AvailableCost"]);
            txtrequestAmount.Text = Convert.ToString(dt.Rows[0]["Amount"]);
            ((CheckBox)e.Row.FindControl("chk")).Checked = true;
            ((CheckBox)e.Row.FindControl("chk")).Enabled = false;

        }
        }
        catch{}

    }
}