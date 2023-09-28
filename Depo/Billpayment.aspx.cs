using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using MPTBCBussinessLayer;
using System.Data;
public partial class Depo_Billpayment : System.Web.UI.Page
{
    string ID = "0";
    CultureInfo cult = new CultureInfo("gu-IN", true);
    TransportMaster obTransportMaster = null;
    DPT_DepotMaster obDPT_DepotMaster = new DPT_DepotMaster();
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obDPT_DepotMaster.DepoTrno_I = 0;
            DataSet depo = obDPT_DepotMaster.Select();

            obTransportMaster = new TransportMaster();
            obTransportMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet1 = obTransportMaster.Select();
            DropDownList1.DataTextField = "TransportName_V";
            DropDownList1.DataValueField = "TransportID_I";
            DropDownList1.DataSource = obDataSet1.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "सेलेक्ट..");
            ddlFyYear.DataSource = comm.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            ddlFyYear.DataValueField = "AcYear";
            ddlFyYear.DataTextField = "AcYear";
            ddlFyYear.DataBind();
            ddlFyYear.SelectedValue = comm.GetFinYear();
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtKramank.Text = randnum.ToString();
            fillgrd();
        }
    }
    public void fillgrd()
    {
        DataSet dddd = comm.FillDatasetByProc("call USP_SaveTransportBillDetails(2,0,0,0,0,0,0,0,0,0,0,0,"+Session["UserID"]+")");
        GridView3.DataSource = dddd.Tables[0];
        GridView3.DataBind();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet grds = comm.FillDatasetByProc("call GetFillgrd(3," +DropDownList1.SelectedValue + ",'"+ddlFyYear.SelectedItem.Text+"')");
        GridView2.DataSource = grds.Tables[0];
        GridView2.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        
        // TransID, Gamount, BAmount, Payamount, PaymentDate, BankName, CheckNo, checkDate, Remark,FyYear,PaymentNo
        comm.FillDatasetByProc("call USP_SaveTransportBillDetails(0," + DropDownList1.SelectedValue + "," + lblGAmount.Text + "," + lblBAmount.Text + "," + txtAmount.Text + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtbank.Text + "','" + txtCheck.Text + "','" + Convert.ToDateTime(txtCheckDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtremark.Text + "','" + ddlFyYear.SelectedItem.Text + "','" + txtKramank.Text + "'," + Session["UserID"] + ")");
       // comm.FillDatasetByProc("call USP_SaveTransportBillDetails(1," + DropDownList1.SelectedValue + "," + lblGAmount.Text + "," + lblBAmount.Text + "," + txtAmount.Text + ",'" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtbank.Text + "','" + txtCheck.Text + "','" + Convert.ToDateTime(txtCheckDate.Text, cult).ToString("yyyy-MM-dd") + "'," + HiddenField2.Value + ",'" + ddlFyYear.SelectedItem.Text + "','" + txtKramank.Text + "'," + Session["UserID"] + ")");
        comm.FillDatasetByProc(" update dpt_transpotbilldetails set Status=2  where BilltrNo in (" + HiddenField2.Value + ")");
        DataSet grds = comm.FillDatasetByProc("call GetFillgrd(3," + DropDownList1.SelectedValue + ",'" + ddlFyYear.SelectedItem.Text + "')");
        GridView2.DataSource = grds.Tables[0];
        GridView2.DataBind();
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        txtKramank.Text = randnum.ToString();
        comm.EmptyTextBoxes(this);
        fillgrd();
       // Button1.Enabled = false;
        //USP_SaveTransportBillDetails
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        double Amount=0, amount2=0;
        Label1.Text = "";
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            if (((CheckBox)GridView2.Rows[i].FindControl("CheckBox1")).Checked == true)
            {
                Amount = Amount + Convert.ToDouble(GridView2.Rows[i].Cells[8].Text);
                amount2 = amount2 + Convert.ToDouble(GridView2.Rows[i].Cells[9].Text);
                ID = ID + "," + ((HiddenField) GridView2.Rows[i].FindControl("HiddenField1")).Value;
            }
            else
            { 
            
            }
        }
        lblBAmount.Text = amount2.ToString();
        lblGAmount.Text = Amount.ToString();
        HiddenField2.Value = ID.ToString();
        Button1.Enabled = true;
    }
    protected void txtAmount_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToDouble(lblGAmount.Text) < Convert.ToDouble(txtAmount.Text))
        {
            txtAmount.Text = "";
            Label1.Text = "अग्रिम राशि गणना के अनुसार की राशि से अधिक नहीं हो सकती है ";
        }
        else
        {
            Label1.Text = "";
        }
    }
}