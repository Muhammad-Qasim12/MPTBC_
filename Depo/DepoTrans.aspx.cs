using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_DepoTrans : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DropDownList1.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_OrderI("+Session["UserID"]+")");
            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "OrderNo";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Select..");
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtOrderNo.Text = randnum.ToString();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_InterDepo_otherThantext('"+DropDownList1.SelectedItem.Text +"'," + Session["UserID"] + ")");
        GridView1.DataBind();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //OrderH ,OrderNo,  OrderDate,  BilltiNo , BilltiDate , truckNNo , TruckDriveNo,  Toalbook , DepoID , UserID
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            obCommonFuction.FillDatasetByProc("call USP_InterDeposave('" + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField2")).Value + "','" + DropDownList1.SelectedItem.Text + "','" + txtOrderNo.Text + "','" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtBillTiNo.Text + "','" + Convert.ToDateTime(txtbiltiDate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtTruckNo.Text + "','" + txtTruckDriver.Text + "','" + ((TextBox)GridView1.Rows[i].FindControl("TextBox2")).Text + "','" + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "'," + Session["UserID"].ToString() + ")");
        }

        Response.Redirect("ViewData.aspx");
        Random rand = new Random();
        int randnum = rand.Next(100000, 10000000);
        txtOrderNo.Text = randnum.ToString();
        obCommonFuction.EmptyTextBoxes(this);
        GridView1.DataSource = null;
        GridView1.DataBind();
    }
}