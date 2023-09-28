using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class GMDashBoard : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    public DataSet ddd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try {
                DataSet ds = comm.FillDatasetByProc("call USP_GMDashBoard('" + comm.GetActiveAcYear() + "') ");
            GridDepoStock.DataSource = ds.Tables[0];
            GridDepoStock.DataBind();
            GriddepoWareHouse.DataSource = ds.Tables[1];
            GriddepoWareHouse.DataBind();
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
            try {
                DataSet bookseller = comm.FillDatasetByProc("call USP_GMBashBoardBookSellerDemand('"+comm.GetFinYear ()+"') ");
                lbl10.Text = Convert.ToString(bookseller.Tables[0].Rows[0]["TotalDemand"]);
                lbl11.Text = Convert.ToString(bookseller.Tables[0].Rows[0]["TotalAmount"]);

                lbl12.Text = Convert.ToString(bookseller.Tables[1].Rows[0]["NoOfBooks"]);
                lbl13.Text = Convert.ToString(bookseller.Tables[2].Rows[0]["PradayBook"]);
                lbl14.Text = Convert.ToString(Convert.ToInt32(lbl12.Text) - Convert.ToInt32(lbl13.Text));

            }
            catch

            { }
            try {
            lbl15.Text = Convert.ToString(Math.Round ((Convert.ToDouble(lbl2.Text) / Convert.ToDouble(lbl1.Text)) * 100,2));
            lbl16.Text = Convert.ToString(Math.Round ((Convert.ToDouble(lbl13.Text) / Convert.ToDouble(lbl12.Text)) * 100,2));
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
            //  ddd = comm.FillDatasetByProc("call GetDepoNotification(" + Session["UserID"] + ")");

        }

    }
    int Yojan, Samany, Total;
    int asthai, ethai, Total1;
    protected void GriddepoWareHouse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    Label lblPerBundle1 = (Label)e.Row.FindControl("Ethai");
                    asthai += lblPerBundle1.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblPerBundle1.Text);
                }
                catch { }
                try
                {
                    Label lblSamay2 = (Label)e.Row.FindControl("Aesthai");
                    ethai += lblSamay2.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblSamay2.Text);
                }
                catch { }
                try
                {
                    Label lblTotal2 = (Label)e.Row.Cells[3].FindControl("lblT");
                    Total1 += lblTotal2.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblTotal2.Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[1].Text = asthai.ToString();
            e.Row.Cells[2].Text = ethai.ToString();
            e.Row.Cells[3].Text = Total1.ToString();

        }

    }
    protected void GridDepoStock_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {
                    Label lblPerBundle = (Label)e.Row.FindControl("Yojna");
                    Yojan += lblPerBundle.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblPerBundle.Text);
                }
                catch { }
                try
                {
                    Label lblSamay = (Label)e.Row.FindControl("Samany");
                    Samany += lblSamay.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblSamay.Text);
                }
                catch { }
                try
                {
                    Label lblTotal = (Label)e.Row.FindControl("Total");
                    Total += lblTotal.Text.Trim().Length == 0 ? 0 : Convert.ToInt32(lblTotal.Text);
                }
                catch { }


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FToNo_I0 = (Label)e.Row.FindControl("FToNo_I0");
            Label lblFLoojBook = (Label)e.Row.FindControl("lblFLoojBook");
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[1].Text = Yojan.ToString();
            e.Row.Cells[2].Text = Samany.ToString();
            e.Row.Cells[3].Text = Total.ToString();
            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        comm.FillDatasetByProc("CALL `InsertData_MisReport201718`('" + comm.GetActiveAcYear() + "',0)");
    }
}
    

public class CDStockDtl
{
    public string country { get; set; }
    public decimal visits { get; set; }
    public string color { get; set; }
    public string PaperType { get; set; }
    public string fullName { get; set; }
    // public string TotQty { get; set; }
    //    public string TotDispatch { get; set; }

}
