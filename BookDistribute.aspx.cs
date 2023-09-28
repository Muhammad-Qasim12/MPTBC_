using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class BookDistribute : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    int count12;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                ddlChallano.DataSource = obCommonFuction.FillDatasetByProc("select StockDistributionSEntryID_I,BlockID_I, UserID,ChallanNo_V from dpt_stockdistributionschemeentry_m where UserID ='" + Convert.ToString(Session["UserID"]) + "';");
                ddlChallano.DataValueField = "StockDistributionSEntryID_I";
                ddlChallano.DataTextField = "ChallanNo_V";
                ddlChallano.DataBind();
                ddlChallano.Items.Insert(0, "Select..");

            }
            catch { }
        }
    }
    protected void ddlChallano_SelectedIndexChanged(object sender, EventArgs e)
    {
        try {
        DataSet ddchallan;
        ddchallan = obCommonFuction.FillDatasetByProc(@"select TitleHindi_V,TitalID,paikbandal,loojbandal from dpt_distributchallanreceipt
inner join acd_titledetail on acd_titledetail.TitleID_I=TitalID where ChallanID=" + ddlChallano.SelectedItem.Text + "");
        ddlBookName.DataSource = ddchallan;
        ddlBookName.DataTextField = "TitleHindi_V";
        ddlBookName.DataValueField = "TitalID";
        ddlBookName.DataBind();
        Label3.Text = ddchallan.Tables[0].Rows[0]["paikbandal"].ToString();
        Label5.Text = ddchallan.Tables[0].Rows[0]["loojbandal"].ToString();
        }
        catch { }

    }
    
    protected void Checkbarcode(object sender, EventArgs e)
    {
        try
        {

            DataSet ds1 = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ")");
            Label4.Text = ds1.Tables[0].Rows.Count.ToString();
            if (Label3.Text == Label4.Text)
            {
                txtBundlenNo.Style.Add("BackColor", "Red");
                txtBundlenNo.BackColor = System.Drawing.Color.Red;
                if (Label5.Text != "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('लूज बण्डल डालने के लिये अपने डिपो प्रवन्धक से संपर्क करें.');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert आगे का काम के लिये डिपो प्रवन्धक से संपर्क करें.');</script>");
                }
            }
            else
            {
                obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',0," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ")");
                Label2.Text = txtBundlenNo.Text;
                //DataSet ds = obCommonFuction.FillDatasetByProc(@"select dpt_stockdetailschild_t.* ,TitleHindi_V , case IsOpenMarket when 2 then 'सामान्य' else 'योज़ना' end as booktype from  dpt_stockdetails_t INNER JOIN dpt_stockdetailschild_t on dpt_stockdetailschild_t.StockDetailsID_I=dpt_stockdetails_t.StockDetailsID_I inner join acd_titledetail on dpt_stockdetails_t.SubJectID_I=acd_titledetail.TitleID_I  inner join dpt_warehouuse_m on dpt_stockdetailschild_t.WareHouseID=dpt_warehouuse_m.WareHouseID_I where dpt_warehouuse_m.UserID_I=" + Convert.ToString(Session["UserID"]) + " and  IsDistribute=3 and  DistributID =" + ddlChallano.SelectedValue + "  ");

                DataSet ds = obCommonFuction.FillDatasetByProc("Call USP_DPT_SchemeBookDistribut_new('" + txtBundlenNo.Text + "','" + ddlChallano.SelectedValue + "',001," + Convert.ToString(Session["UserID"]) + "," + ddlBookName.SelectedValue + ")");
                Label4.Text = ds.Tables[0].Rows.Count.ToString();
            }


        }
        catch { }

        txtBundlenNo.Text = "";
        txtBundlenNo.Focus();
    }

    protected void ddlBookName_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddchallan;
        ddchallan = obCommonFuction.FillDatasetByProc(@"select TitleHindi_V,TitalID,paikbandal,loojbandal from dpt_distributchallanreceipt
inner join acd_titledetail on acd_titledetail.TitleID_I=TitalID where ChallanID=" + ddlChallano.SelectedItem.Text + " and  TitalID=" + ddlBookName.SelectedValue + "");

        Label3.Text = ddchallan.Tables[0].Rows[0]["paikbandal"].ToString();
        Label5.Text = ddchallan.Tables[0].Rows[0]["loojbandal"].ToString();
    }
}