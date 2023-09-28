using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PrintingDashboard : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    public DataSet ddd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataSet ds = comm.FillDatasetByProc("call USP_GMDashBoard('" + comm.GetActiveAcYear() + "') ");
             
                Label1.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                lblYr.Text = comm.GetActiveAcYear();
                lbl1.Text = ds.Tables[2].Rows[0]["Total_allot"].ToString();
                lbl2.Text = ds.Tables[2].Rows[0]["Total_rec"].ToString();
                lbl3.Text = ds.Tables[2].Rows[0]["Balance"].ToString();

                lbl4.Text = ds.Tables[4].Rows[0]["PriPap_Required"].ToString();
                lbl5.Text = ds.Tables[4].Rows[0]["CovPap_Required"].ToString();
                lbl6.Text = ds.Tables[4].Rows[0]["PriPap_Issue"].ToString();
                lbl7.Text = ds.Tables[4].Rows[0]["CovPap_Issue"].ToString();
                lbl8.Text = ds.Tables[4].Rows[0]["PriPap_Balance"].ToString();
                lbl9.Text = ds.Tables[4].Rows[0]["CovPap_Balance"].ToString();

                //  lbl3.Text = ds.Tables[2].Rows[0]["Balance"].ToString();

                //   comm.FillDatasetByProc("call InsertData_MisReport() ");
            }
            catch { }
            try
            {
                //DataSet bookseller = comm.FillDatasetByProc("call USP_GMBashBoardBookSellerDemand('" + comm.GetFinYear() + "') ");
               // lbl10.Text = Convert.ToString(bookseller.Tables[0].Rows[0]["TotalDemand"]);
                //lbl11.Text = Convert.ToString(bookseller.Tables[0].Rows[0]["TotalAmount"]);

               // lbl12.Text = Convert.ToString(bookseller.Tables[1].Rows[0]["NoOfBooks"]);
              //  lbl13.Text = Convert.ToString(bookseller.Tables[2].Rows[0]["PradayBook"]);
                //lbl14.Text = Convert.ToString(Convert.ToInt32(lbl12.Text) - Convert.ToInt32(lbl13.Text));

            }
            catch

            { }
            try
            {
                lbl15.Text = Convert.ToString(Math.Round((Convert.ToDouble(lbl2.Text) / Convert.ToDouble(lbl1.Text)) * 100, 2));
               // lbl16.Text = Convert.ToString(Math.Round((Convert.ToDouble(lbl13.Text) / Convert.ToDouble(lbl12.Text)) * 100, 2));
            }
            catch { }
            //  try { 
            //DataSet dd=  comm.FillDatasetByProc("call GetDepoDashboard(" + Session["UserID"] + ",'"+comm.GetFinYear ()+"')");
            //lblTotalBook.Text = Convert.ToString(Convert.ToInt32(dd.Tables[0].Rows[0]["Samany"]) + Convert.ToInt32(dd.Tables[0].Rows[0]["Yojna"]));
            //lblSamany.Text = dd.Tables[0].Rows[0]["Samany"].ToString();
            //lblYojnaBook.Text = dd.Tables[0].Rows[0]["Yojna"].ToString();

            //lblotalBooSupP.Text = Convert.ToString(Convert.ToInt32(dd.Tables[2].Rows[0]["Samany"]) + Convert.ToInt32(dd.Tables[2].Rows[0]["Yojna"]));
            //lblTotaSup.Text = dd.Tables[1].Rows[0]["Supbook"].ToString();
            //lblRemain.Text = Convert.ToString(Convert.ToInt32(lblTotaSup.Text) - Convert.ToInt32(lblotalBooSupP.Text));
            //  }
            //  catch { }
            ddd = comm.FillDatasetByProc("call usp_PrinDashboard()");
            Label2.Text = ddd.Tables[0].Rows[0]["TotalTitle"].ToString();
            Label3.Text = ddd.Tables[1].Rows[0]["PrintedTitle"].ToString();
            GridView1.DataSource = ddd.Tables[2];
            GridView1.DataBind();
            GridView2.DataSource = ddd.Tables[3];
            GridView2.DataBind();
            GridView3.DataSource = ddd.Tables[4];
            GridView3.DataBind();
            GridView4.DataSource = comm.FillDatasetByProc(@"SELECT pb.BillID_I, pb.Billno_V, pb.BillDate_D,ptr.NameofPress_V,SUM(Amount_N) Amount_N
FROM pri_bill pb
INNER JOIN pri_billdetails pd ON pb.BillID_I= pd.BillID_I
INNER JOIN pri_printerregistration_t ptr ON ptr.Printer_RedID_I=pb.PrinterID_I
GROUP BY pb.BillID_I,pb.Billno_V, pb.BillDate_D,ptr.NameofPress_V;");
            GridView4.DataBind();

        }

    }
    int Yojan, Samany, Total;
    int asthai, ethai, Total1;
    protected void GriddepoWareHouse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
      

    }
    protected void GridDepoStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
    }
    //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    //{
    //    comm.FillDatasetByProc("CALL `InsertData_MisReport201718`('" + comm.GetActiveAcYear() + "',0)");
    //}
}

