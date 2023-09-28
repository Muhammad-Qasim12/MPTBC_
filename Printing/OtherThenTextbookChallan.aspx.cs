using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;

public partial class Printing_OtherThenTextbookChallan : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    Random rdm = new Random();
    PRI_PrinterRegistration PriReg = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "Id";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            txtChalanNo.Text = System.DateTime.Now.ToString("ddMMssmm") + RandomNumber();

            //ddlTitleID.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(0,-1)");
            //ddlTitleID.DataValueField = "TitleID_I";
            //ddlTitleID.DataTextField = "TitleHindi_V";
            //ddlTitleID.DataBind();
            //ddlTitleID.Items.Insert(0, new ListItem("-Select-", "0"));

            DdlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM010_DepomasterLoad(0)");
            DdlDepot.DataValueField = "DepoTrno_I";
            DdlDepot.DataTextField = "DepoName_V";
            DdlDepot.DataBind();
            DdlDepot.Items.Insert(0, "--Select--");

            PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
            PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
            DataSet ds = new DataSet();
            ds = PriReg.GetPrinterDetails();
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
            }

            txtChalanDate.Text = System.DateTime.Now.ToShortDateString();
            txtUnloadingCharges.Text = System.DateTime.Now.ToShortDateString();
            fillVitaranNirdesh();
        }

    }
    private string RandomNumber()
    {
        return (rdm.Next(2, 100)).ToString();
    }
    protected void ddlTitleID_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlSub.DataSource = obCommonFuction.FillDatasetByProc("call USP_ACB002_SubTitleMasterSelect(" + ddlTitleID.SelectedValue + ",-2)");
        ddlSub.DataValueField = "SubTitleID_I";
        ddlSub.DataTextField = "SubTitleHindi_V";
        ddlSub.DataBind();
        ddlSub.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    protected void DdlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddlTDistribution.DataSource = obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh(-2,0,0,'" + DdlACYear.SelectedItem.Text + "',0," + ddlTitleID.SelectedValue + "," + ddlSub.SelectedValue + "," + Session["PrierID_I"] + ",0,0,0)");
        ddlTDistribution.DataValueField = "OrderNo";
        ddlTDistribution.DataTextField = "OrderNo_V";
        ddlTDistribution.DataBind();
        ddlTDistribution.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void ddlTDistribution_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int ddlTitleID = 0; int ddlSub = 0;
            GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh(" + ddlTDistribution.SelectedValue + ",'" + ddlTDistribution.SelectedItem.Text + "',0,'" + DdlACYear.SelectedItem.Text + "',0," + ddlTitleID + "," + ddlSub + "," + Session["PrierID_I"] + ",0," + DdlDepot.SelectedValue + ",0,0)");
            GridView1.DataBind();
        }
        catch { }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string chkStatus = "";

        try
        {
            if (GridView1.Rows.Count > 0)
            {
                chkStatus = "ok";
            }

            // USP_acb_PrinterChallan
            if (chkStatus == "ok")
            {
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    int loojs = 0;
                    if (((CheckBox)GridView1.Rows[i].FindControl("CheckBox1")).Checked == true)
                    {
                        loojs = 1;
                    }
                    else
                    {
                        loojs = 0;
                    }
                    //CheckBox1
                    // int chk = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("CheckBox1")).Value);
                    int DdlDepot = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("hdnDepoId")).Value);
                    string hdnGroupNo = ((HiddenField)GridView1.Rows[i].FindControl("hdnGroupID")).Value;
                    int ddlTitleID = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("hdnTitleID")).Value);
                    int ddlSub = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("hdnSubTitleID")).Value);
                    int ddlPrinter = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("hdnPrinterID")).Value);
                    int iVgrpID = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("hdnVGrpID")).Value);
                    int ddlTDistribution = int.Parse(((HiddenField)GridView1.Rows[i].FindControl("hdnDistributionOrderId")).Value);

                    var _totalbook = ((TextBox)GridView1.Rows[i].FindControl("TextBox1")).Text;
                    var _loojbook = ((TextBox)GridView1.Rows[i].FindControl("txtlooj")).Text;

                    if (string.IsNullOrEmpty(_totalbook))
                        _totalbook = "0";
                    if (string.IsNullOrEmpty(_loojbook))
                        _loojbook = "0";

                    var _totalnoofbook = Convert.ToInt64(_totalbook) + Convert.ToInt64(_loojbook);

                    obCommonFuction.FillDatasetByProc("call USP_acb_PrinterChallan(0,'" + DdlACYear.SelectedItem.Text + "','" + txtChalanNo.Text + "','" + Convert.ToDateTime(txtChalanDate.Text, cult).ToString("yyyy-MM-dd") + "'," + DdlDepot + "," + ddlTitleID + "," + ddlSub + ",'" + txtBiltiNO.Text + "','" + Convert.ToDateTime(txtUnloadingCharges.Text).ToString("yyyy-MM-dd") + "','" + txtTruckNo.Text + "','" + txtmobileNo.Text + "','" + txtDriverName.Text + "'," + _totalnoofbook + "," + ddlTDistribution + "," + Session["UserID"] + "," + Session["PrierID_I"] + "," + ((TextBox)GridView1.Rows[i].FindControl("txtBundle")).Text + "," + loojs + ") ");
                }
                Response.Redirect("ViewOtherThenTextbook.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "msg11", "alert('Record not found');", true);
            }


        }
        catch { }


        //AcYearID, ChallanNO, challandate, DepoID, TitleID, SubTitleID, BiltiNo, BiltiDate, TruckNo, TruckDriverMobi, DriverName, PrdadayBooks, DistriButionaOrder, DepoStatsu, UserID, PrinterID
    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            fillVitaranNirdesh();
        }
        catch { }
    }

    private void fillVitaranNirdesh()
    {
        try
        {
            int ddlTitleID = 0; int ddlSub = 0;

            //ddlTDistribution.DataSource = obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh(-3,0,0,'" + DdlACYear.SelectedItem.Text + "',0," + ddlTitleID.SelectedValue + "," + ddlSub.SelectedValue + "," + Session["PrierID_I"] + ",0,0,0,0)");
            ddlTDistribution.DataSource = obCommonFuction.FillDatasetByProc("call USP_acb_vitrannirdesh(-3,0,0,'" + DdlACYear.SelectedItem.Text + "',0," + ddlTitleID + "," + ddlSub + "," + Session["PrierID_I"] + ",0,0,0,0)");
            ddlTDistribution.DataValueField = "OrderNo";
            ddlTDistribution.DataTextField = "OrderNo";
            ddlTDistribution.DataBind();
            ddlTDistribution.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch { }
    }
    protected void DdlDepot_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void txtBundle_TextChanged(object sender, EventArgs e)
    {
        TextBox TextBox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(TextBox.NamingContainer);
        TextBox txtf = (TextBox)grd.FindControl("txtBundle");
        TextBox TextBox1 = (TextBox)grd.FindControl("TextBox1");
        int Perbudel = Convert.ToInt32(grd.Cells[6].Text);
        TextBox1.Text = Convert.ToString(Convert.ToInt32(txtf.Text) * Convert.ToInt32(Perbudel));
        int TotalaBook = Convert.ToInt32(grd.Cells[2].Text);
        int TotalaBook1 = Convert.ToInt32(grd.Cells[4].Text);
        if ((TotalaBook - TotalaBook1) < Convert.ToInt32(TextBox1.Text))
        {
            TextBox1.Text = "0";
            txtf.Text = "0";

        }
    }

    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow gr = (GridViewRow)chk.Parent.Parent;
            TextBox txtlooj = (TextBox)gr.FindControl("txtlooj");

            txtlooj.Text = "0";
            if (chk.Checked == true)
                txtlooj.Enabled = true;
            else
                txtlooj.Enabled = false;
        }
        catch (Exception ex)
        {

        }
    }
}