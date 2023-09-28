using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

using System.Globalization;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO;
public partial class Depo_ReceiptDetails : System.Web.UI.Page
{
    // CommonFuction comm = new CommonFuction();
    public DataSet ds, ds1, ds2;
    int paikbandal = 0, loojbandla = 0;
    public CommonFuction comm = new CommonFuction();
    DPT_DepotMaster obDPT_DepotMaster = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
            DataSet obDataSet = obDPT_DepotMaster.Select();
            lblAddress.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();

            lblDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblfyYaer.Text = comm.FillDatasetByProc("select   [dbo].[GetAcYear]()").Tables[0].Rows[0][0].ToString();
            Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

            DataSet dd = comm.FillDatasetByProc("call USP_DPT_FillReceipt(" + Session["UseriD"].ToString() + ")");
            ddlChallan.DataTextField = "ChallanID";
            ddlChallan.DataValueField = "ChallanID";
            ddlChallan.DataSource = dd;
            ddlChallan.DataBind();
            ddlChallan.Items.Insert(0, "Select..");
            //if (Request.QueryString["ChallanID"] != null)
            //{
            //    ddlChallan.Visible = false;
            //    Button1.Visible = false;
            //    a.Visible = true;
            //    ds = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + Request.QueryString["ChallanID"] + " ,0) ");
            //    GridView1.DataSource = ds.Tables[0];
            //    GridView1.DataBind();
            //    for (int i = 0; i < GridView1.Rows.Count;i++ )
            //    {
            //        paikbandal = paikbandal + Convert.ToInt32( GridView1.Rows[i].Cells[4].Text);
            //        loojbandla = loojbandla + Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
            //    }
            //    Label1.Text = paikbandal.ToString ();
            //    Label2.Text = loojbandla.ToString ();
            //    Label3.Text = Convert.ToString(paikbandal + loojbandla);
            //        ds1 = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + Request.QueryString["ChallanID"] + " ,12) ");
            //        aaaa.Visible = false;
            //}
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        //System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
        //System.Web.UI.HtmlControls.HtmlGenericControl DIV = new System.Web.UI.HtmlControls.HtmlGenericControl();
        //// System.Web.UI.HtmlControls.HtmlGenericControl DIv1 = new System.Web.UI.HtmlControls.HtmlGenericControl();
        ////System.Web.UI.HtmlTextWriterTag html = new System.Web.UI.HtmlTextWriterTag(); 
        //string barCode = Convert.ToString(ddlChallan.SelectedItem.Text);

        if (ddlScheme.SelectedIndex == 0)
        {
            obDPT_DepotMaster = new DPT_DepotMaster();
            obDPT_DepotMaster.DepoTrno_I = Convert.ToInt32(Session["UserID"]);
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
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                paikbandal = paikbandal + Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);
                loojbandla = loojbandla + Convert.ToInt32(GridView1.Rows[i].Cells[5].Text);
            }
            Label1.Text = paikbandal.ToString();
            Label2.Text = loojbandla.ToString();
            Label3.Text = Convert.ToString(paikbandal + loojbandla);
            ds1 = comm.FillDatasetByProc("Call USP_DPT_BlockChallanDetails(" + ddlChallan.SelectedItem.Text + " ,12," + ddlScheme.SelectedValue + ") ");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("BundleDetails.aspx?ID=" + ddlChallan.SelectedValue + "");
    }
    protected void ddlChallan_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ddd = comm.FillDatasetByProc("call GetReceiverName(" + ddlChallan.SelectedValue + ")");
        HiddenField1.Value = ddd.Tables[0].Rows[0]["ReceiverName_V"].ToString();
        DataSet dd = comm.FillDatasetByProc("call USP_DPTChallanDataBindWithScheme(" + ddlChallan.SelectedValue + ",0,0)");
        ddlScheme.DataTextField = "SchemeName_Hindi";
        ddlScheme.DataValueField = "SchemeId";
        ddlScheme.DataSource = dd;
        ddlScheme.DataBind();
        if (ddlScheme.SelectedValue=="")
        { 
        ddlScheme.Items.Insert(0, "--मास्टर चालान--");
        }
        else { 
        //ddlScheme.Items.Insert(50, "--चुने --");
        }
    }
  public  decimal one, two, three, four, five, six, seven, eight, nine;
  public decimal aa, a2, a3, a4, a5, a6;


    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {//Label lblTotalBookpaik = (Label)e.Row.Cells[6].FindControl("lblTotalBookpaik");
                Label TotalAllotmenta = (Label)e.Row.Cells[3].FindControl("lbl1"); ;
                one += Convert.ToDecimal(TotalAllotmenta.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta1 = (Label)e.Row.Cells[4].FindControl("lbl2");// Convert.ToDecimal(e.Row.Cells[4].Text);
                two += Convert.ToDecimal(TotalAllotmenta1.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta112222 = (Label)e.Row.Cells[5].FindControl("lbl3");// Convert.ToDecimal(e.Row.Cells[5].Text);
                three += Convert.ToDecimal(TotalAllotmenta112222.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta112 = (Label)e.Row.Cells[6].FindControl("lbl4");//Convert.ToDecimal(e.Row.Cells[6].Text);
                four +=Convert.ToDecimal(TotalAllotmenta112.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta132 = (Label)e.Row.Cells[7].FindControl("lbl5");//Convert.ToDecimal(e.Row.Cells[7].Text);
                five +=Convert.ToDecimal (TotalAllotmenta132.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta1122 = (Label)e.Row.Cells[8].FindControl("lbl6");// Convert.ToDecimal(e.Row.Cells[8].Text);
                six +=Convert.ToDecimal(TotalAllotmenta1122.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta34 = (Label)e.Row.Cells[9].FindControl("lbl7");//Convert.ToDecimal(e.Row.Cells[9].Text);
                seven +=Convert.ToDecimal(TotalAllotmenta34.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta343 = (Label)e.Row.Cells[10].FindControl("lbl8");// Convert.ToDecimal(e.Row.Cells[10].Text);
                eight +=Convert.ToDecimal(TotalAllotmenta343.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta34333 = (Label)e.Row.Cells[11].FindControl("lbl9"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                nine +=Convert.ToDecimal(TotalAllotmenta34333.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta67 = (Label)e.Row.Cells[14].FindControl("lbl10"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                aa += Convert.ToDecimal(TotalAllotmenta67.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta672 = (Label)e.Row.FindControl("lbl11"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                a2 += Convert.ToDecimal(TotalAllotmenta672.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta672e = (Label)e.Row.FindControl("lbl12"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                a3 += Convert.ToDecimal(TotalAllotmenta672e.Text);
            }
            catch { }
            try
            {
                Label TotalAllotmenta672we = (Label)e.Row.FindControl("lbl13"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                a4 += Convert.ToDecimal(TotalAllotmenta672we.Text);
            }
            catch { }
            try
            {
                Label lbl002 = (Label)e.Row.FindControl("lbl002"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                a5 += Convert.ToDecimal(lbl002.Text);
            }
            catch { }
            try
            {
                Label lbl003 = (Label)e.Row.FindControl("lbl003"); //Convert.ToDecimal(e.Row.Cells[11].Text);
                a6 += Convert.ToDecimal(lbl003.Text);
            }
            catch { }

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "कुल योग  ";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[3].Text = one.ToString();
            e.Row.Cells[4].Text = two.ToString();
            e.Row.Cells[5].Text = three.ToString();
            e.Row.Cells[6].Text = four.ToString();
            e.Row.Cells[7].Text = five.ToString();
            e.Row.Cells[8].Text = six.ToString();
            e.Row.Cells[9].Text = seven.ToString();
            e.Row.Cells[10].Text = eight.ToString();
            e.Row.Cells[11].Text = nine.ToString();
            e.Row.Cells[12].Text = aa.ToString();
            e.Row.Cells[13].Text = a2.ToString();
            e.Row.Cells[14].Text = a3.ToString();
            e.Row.Cells[15].Text = a5.ToString();
            e.Row.Cells[16].Text = a4.ToString();
            e.Row.Cells[17].Text = a6.ToString();
            //e.Row.Cells[6].Text = total_TotalBookpaik.ToString();
            ////e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            ////e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            ////e.Row.Cells[9].Text = total_FromNo_I.ToString();
            ////e.Row.Cells[10].Text = total_ToNo_I.ToString();
            //e.Row.Cells[11].Text = total_LoojBook.ToString();
            //e.Row.Cells[12].Text = total_LoojBook.ToString();
        }
    }
}