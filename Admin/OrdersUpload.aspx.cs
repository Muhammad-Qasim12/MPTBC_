using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrdersUpload : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure api = new APIProcedure();
    CommonFuction obCommonFuction = new CommonFuction ();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            //DdlACYear.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select..", "0"));
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string ImgStatus = "", FileName = "";
        if (FileUpload1.FileName == "")
        {
            ImgStatus = "Ok";
        }
        else
        {
            ImgStatus = api.SingleuploadFile(FileUpload1, "Hrorders", 10000);
            FileName = api.FullFileName;
        }
        obCommonFuction.FillDatasetByProc("insert into tempOrders(DocumentName)values ('"+FileName+"')");
        GridView3.DataSource = obCommonFuction.FillDatasetByProc("select * from tempOrders");
        GridView3.DataBind();
        //tempOrders

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Hr_Orders
        //hr_orderDetails
        obCommonFuction.FillDatasetByProc("call USP_Hr_orderSave(0,'"+TextBox1.Text+"','"+Convert.ToDateTime (TextBox2.Text,cult).ToString("yyyy-MM-dd")+ "','"+Session["UserID"].ToString ()+"','"+DdlACYear.SelectedValue+"')");
        fillgrd();
        TextBox1.Text = "";
        TextBox2.Text = "";
        GridView3.DataSource = null;
        GridView3.DataBind();

    }
    public void fillgrd()
    {
        GridView2.DataSource = obCommonFuction.FillDatasetByProc("call USP_Hr_orderSave(-1,0,0,'" + Session["UserID"].ToString() + "',0)");
        GridView2.DataBind();
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_Hr_orderSave(" + GridView2.DataKeys[e.RowIndex].Value.ToString() + ",0,0,'" + Session["UserID"].ToString() + "',0)");
        fillgrd();

    }
}