using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_DepoMainStockDetails : System.Web.UI.Page
{
    public CommonFuction obCommonFuction = new CommonFuction();
    public DataSet ds1;
    public DataTable myDT;
    public int j;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = "01-11-2017";
            TextBox2.Text = System.DateTime.Now.ToString("dd-MM-yyyy");
            CommonFuction comm = new CommonFuction();
            DataSet asdf = comm.FillDatasetByProc("call USP_DPTOPeningStock(0,1,0,0,0,0)");
            ddlTital.DataSource = asdf.Tables[0];
            ddlTital.DataTextField = "TitleHindi_V";
            ddlTital.DataValueField = "TitleID_I";
            ddlTital.DataBind();
            ddlTital.Items.Insert(0, new ListItem("All", "0"));

            ddlMedium.DataSource = comm.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("All", "0"));

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (DateTime.Parse(TextBox2.Text, cult) < DateTime.Parse(TextBox1.Text, cult))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('दिनांक तक  दिनांक से से बड़ी चुने  .');</script>");
        }
        else
        {

       GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_MPTBC_GET_STOCK_POSITION(" + Session["UserID"] + "," + ddlTital.SelectedValue + "," + ddlMedium.SelectedValue + ",'" + Convert.ToDateTime(TextBox1.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(TextBox2.Text, cult).ToString("yyyy-MM-dd") + "')");
       GridView1.DataBind();
        }
    }
    protected void ddlMedium_SelectedIndexChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
        DataSet asdf = comm.FillDatasetByProc("call GetMediumbyTitile(" + ddlMedium.SelectedValue + ",'1,2,3,4,5,6,7,8,9,10,11,12')");
        ddlTital.DataSource = asdf.Tables[0];
        ddlTital.DataTextField = "TitleHindi_V";
        ddlTital.DataValueField = "TitleID_I";
        ddlTital.DataBind();
        ddlTital.Items.Insert(0, new ListItem("All", "0"));
    }
}