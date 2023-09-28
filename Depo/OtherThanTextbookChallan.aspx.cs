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
public partial class Depo_OtherThanTextbookChallan : System.Web.UI.Page
{
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
            lblAddress1.Text = obDataSet.Tables[0].Rows[0]["DepoAddress_V"].ToString();
            lblphone1.Text = obDataSet.Tables[0].Rows[0]["TeleNo_V"].ToString();
            lblemailID1.Text = obDataSet.Tables[0].Rows[0]["Emailid_V"].ToString();
            lblmobileNo1.Text = obDataSet.Tables[0].Rows[0]["MobNo_V"].ToString();

            lblDate1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            lblfyYaer1.Text = comm.FillDatasetByProc("select GetAcYearDepo()").Tables[0].Rows[0][0].ToString();
        ddlChallan.DataSource=  comm.FillDatasetByProc("call USP_DPTViewOtherThan(" + Session["UserID"] + ")");
        ddlChallan.DataTextField = "ChallanNo_V";
        ddlChallan.DataValueField = "ChallanNo_V";
        ddlChallan.DataBind();
        if (Request.QueryString["ID"] != "" || Request.QueryString["ID"]!=null)
        {
             
                ddlChallan.SelectedItem.Text = Convert.ToString(Request.QueryString["ID"]);
             
            Button1_Click(sender, e);
        }
          //  Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        }
    }
    public decimal aa, a2, a3, a4, a5, a6;

    protected void ddlChallan_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
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
           
            //e.Row.Cells[3].Text = aa.ToString();
              e.Row.Cells[2].Text = a2.ToString();
              e.Row.Cells[4].Text = a3.ToString();
              e.Row.Cells[5].Text = a5.ToString();
              e.Row.Cells[7].Text = Convert.ToString(Convert.ToInt32(a3) + Convert.ToInt32(a5));
            //e.Row.Cells[6].Text = a3.ToString();
            //e.Row.Cells[7].Text = a5.ToString();
            //e.Row.Cells[8].Text = a4.ToString();
            //e.Row.Cells[9].Text = a6.ToString();
            //e.Row.Cells[6].Text = total_TotalBookpaik.ToString();
            ////e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            ////e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            ////e.Row.Cells[9].Text = total_FromNo_I.ToString();
            ////e.Row.Cells[10].Text = total_ToNo_I.ToString();
            //e.Row.Cells[11].Text = total_LoojBook.ToString();
            //e.Row.Cells[12].Text = total_LoojBook.ToString();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportDiv1.Visible = true;
        ds2 = comm.FillDatasetByProc("Call Dpt_otherthanTextbookChallan('" + ddlChallan.SelectedItem.Text + "') ");
        GridView2.DataSource = ds2.Tables[0];
        GridView2.DataBind();
    }
}