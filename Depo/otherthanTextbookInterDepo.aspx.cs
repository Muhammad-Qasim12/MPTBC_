using System;
using System.Collections.Generic;
using System.Data;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer.Paper;

public partial class Depo_otherthanTextbookInterDepo : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction(); WareHouseMaster obWareHouseMaster = null;
    CommonFuction obCommonFuction = new CommonFuction();
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = obj.FillDatasetByProc("call usp_OtherthanInterDepoBookRec(" + Session["UserID"].ToString() + ")");
        GridView1.DataBind();
        string user = Session["UserName"].ToString().ToLower();
        string userName = user.Replace("depo", "");
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPTEmployeeeDetails('" + userName + "')");
        ddlEmployee.DataSource = ds.Tables[0];
        ddlEmployee.DataTextField = "Name";
        ddlEmployee.DataValueField = "EmployeeID_I";

        ddlEmployee.DataBind();

        obWareHouseMaster = new WareHouseMaster();
        obWareHouseMaster.WareHouseID = 0;
        obWareHouseMaster.UserID_I = Convert.ToInt32(Session["UserID"]);
        DataSet dsWareHouse = obWareHouseMaster.Select();
        ddlWarehouse.DataTextField = "WareHouseName_V";
        ddlWarehouse.DataValueField = "WareHouseID_I";
        ddlWarehouse.DataSource = dsWareHouse.Tables[0];
        ddlWarehouse.DataBind();
        txtReceivdate.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        aa.Visible = true;
        aaa.Visible = false;
        HiddenField2.Value = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField1")).Value;
        HiddenField4.Value = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField3")).Value;
        HiddenField6.Value = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField5")).Value;
    //    lblBook0.Text = ((HiddenField)GridView1.SelectedRow.FindControl("HiddenField7")).Value;
        lblPrinterName.Text = GridView1.SelectedRow.Cells[1].Text;
        lblChallan.Text = GridView1.SelectedRow.Cells[2].Text;
        lblChallanDate.Text = GridView1.SelectedRow.Cells[3].Text;
        lblBookName.Text = GridView1.SelectedRow.Cells[4].Text;

        lblBook.Text = GridView1.SelectedRow.Cells[5].Text;
        txtTotalBook.Text = GridView1.SelectedRow.Cells[5].Text;
        lblbundel.Text = GridView1.SelectedRow.Cells[6].Text;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_dpt_BookReceivedOtherthanTextbook_INTERDEPO(0,'" + lblChallan.Text + "'," + HiddenField2.Value + ",'" + txtBiltiNo.Text + "','" + Convert.ToDateTime(txtBilltiDate.Text, cult).ToString("yyyy-MM-dd") + "'," + ddlWarehouse.SelectedValue + ",'" + Convert.ToDateTime(txtReceivdate.Text, cult).ToString("yyyy-MM-dd") + "','" + txtTruck.Text + "','" + txtUnloading.Text + "','" + ddlEmployee.SelectedItem.Text + "'," + Session["UserID"] + ",0,'" + HiddenField4.Value + "'," + HiddenField6.Value + "," + txtTotalBook.Text + ")");
        GridView1.DataSource = obj.FillDatasetByProc("call usp_OtherthanInterDepoBookRec(" + Session["UserID"].ToString() + ")");
        GridView1.DataBind();
        aa.Visible = false;
        aaa.Visible = true;
    }
}