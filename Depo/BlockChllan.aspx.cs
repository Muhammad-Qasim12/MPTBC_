using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;
public partial class Depo_BlockChllan : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    public DataSet ds, ds1, ds2; CultureInfo cult = new CultureInfo("gu-IN", true);
    DPT_DepotMaster obDPT_DepotMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //DataSet dd = comm.FillDatasetByProc("call DPT_ShowChallanBlock(" + Session["UseriD"].ToString() + ")");
            //ddlChallan.DataTextField = "ChallanNo_V";
            //ddlChallan.DataValueField = "StockDistributionSEntryID_I";
            //ddlChallan.DataSource = dd;
            //ddlChallan.DataBind();
            //ddlChallan.Items.Insert(0, "Select..");
            TextBox2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            filldropdwn();

        }

    }
    public void filldropdwn()
    {
        if (Convert.ToString(Session["RoleId"]) == "28")
        {

            DataSet dd = comm.FillDatasetByProc("call DPT_ShowChallanBlock(" + Session["UseriD"].ToString() + ")");
            ddlChallan.DataTextField = "ChallanNo_V";
            ddlChallan.DataValueField = "StockDistributionSEntryID_I";
            ddlChallan.DataSource = dd.Tables[0];
            ddlChallan.DataBind();
            ddlChallan.Items.Insert(0, "Select..");
        }
        else
        {
            DataSet dd = comm.FillDatasetByProc("call DPT_ShowChallanBlock(" + Session["UseriD"].ToString() + ")");
            ddlChallan.DataTextField = "ChallanNo_V";
            ddlChallan.DataValueField = "StockDistributionSEntryID_I";
            ddlChallan.DataSource = dd.Tables[1];
            ddlChallan.DataBind();
            ddlChallan.Items.Insert(0, "Select..");
        
        }
        //TextBox2.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet ddd = comm.FillDatasetByProc("call GetReceiverName(" + ddlChallan.SelectedItem.Text + ")");
        HiddenField1.Value = ddd.Tables[0].Rows[0]["ReceiverName_V"].ToString();
        if (HiddenField1.Value == "1" || HiddenField1.Value == "4")
        {
            if (ddlScheme.SelectedValue == "--मास्टर चालान--")
            {
                MasterChallan.Visible = true;
            }
            else { MasterChallan.Visible = false; }
        }
        else
        {
            MasterChallan.Visible = true;
        }
        if (ddlScheme.SelectedIndex == 0)
        {
            DataSet d12 = comm.FillDatasetByProc("call USP_DPTGetBolckWiseDepotName(" + ddlChallan.SelectedItem.Text + ")");

            obDPT_DepotMaster = new DPT_DepotMaster();

            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(d12.Tables[0].Rows[0]["depotID_I"].ToString());
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress1.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone1.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID1.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo1.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();

            lblDate1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblfyYaer1.Text = comm.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();
            //Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            ds2 = new DataSet();
            ds1 = new DataSet();
            a.Visible = false;
            divB.Visible = true;
            ds2 = comm.FillDatasetByProc("Call procedure1('" + ddlChallan.SelectedItem.Text + "','" + lblfyYaer1.Text + "') ");
            GridView2.DataSource = ds2.Tables[0];
            GridView2.DataBind();
        }

        else
        {
            ds = new DataSet();
            ds2 = new DataSet();
            a.Visible = true;
            divB.Visible = false;
            ds = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + ddlChallan.SelectedItem.Text + " ,0," + ddlScheme.SelectedValue + ") ");
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            ds1 = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + ddlChallan.SelectedItem.Text + " ,12," + ddlScheme.SelectedValue + ") ");
        }
        //if (ddlScheme.SelectedIndex == 0)
        //{
        //    a.Visible = true;
        //    ds = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + ddlChallan.SelectedItem.Text + " ,0," + ddlScheme.SelectedValue + ") ");
        //    GridView1.DataSource = ds.Tables[0];
        //    GridView1.DataBind();
        //    ds1 = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + ddlChallan.SelectedItem.Text + " ,12," + ddlScheme.SelectedValue + ") ");
        //}

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        comm.FillDatasetByProc("update dpt_distributchallanreceipt set Remark='" + TextBox1.Text + "', RemarkDate='" + Convert.ToDateTime(TextBox2.Text,cult).ToString("yyyy-MM-dd") + "',SendStatus=2 where ChallanID=" + ddlChallan.SelectedItem.Text + "");
       // ddlChallan.SelectedIndex = 0;
        TextBox1.Text = "";
        a.Visible = false;
        filldropdwn();
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('आपके द्वारा चालान प्राप्त किया गया.');</script>");

    }
    protected void ddlChallan_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddd = comm.FillDatasetByProc("call GetReceiverName(" + ddlChallan.SelectedItem.Text + ")");
        HiddenField1.Value = ddd.Tables[0].Rows[0]["ReceiverName_V"].ToString();
        
        DataSet dd = comm.FillDatasetByProc("call USP_DPTChallanDataBindWithScheme(" + ddlChallan.SelectedItem.Text + ",0,0)");
        ddlScheme.DataTextField = "SchemeName_Hindi";
        ddlScheme.DataValueField = "SchemeId";
        ddlScheme.DataSource = dd;
        ddlScheme.DataBind();
      
            ddlScheme.Items.Insert(0, "--मास्टर चालान--");
           
       
    }
    protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlScheme_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
}