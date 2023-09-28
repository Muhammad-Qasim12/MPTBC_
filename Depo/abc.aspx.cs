using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_abc : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CommonFuction comm = new CommonFuction();
            DataSet books = new DataSet();
            if (Convert.ToString(Request.QueryString["Year"]) == "2017-2018")
            {
                books = comm.FillDatasetByProc("call USP_DPTOPeningStock(" + Request.QueryString["BookTitle"] + ",0," + Session["userID"].ToString() + "," + Request.QueryString["BookType"] + "," + Request.QueryString["Medium"] + "," + Request.QueryString["ClassTrno"] + ")");
            }
            else
            {
                books = comm.FillDatasetByProc("call USP_DPTOPeningStockOLD(" + Request.QueryString["BookTitle"] + ",0," + Session["userID"].ToString() + "," + Request.QueryString["BookType"] + "," + Request.QueryString["Medium"] + "," + Request.QueryString["ClassTrno"] + ")");
            }
           
           // Year
            grdPrinterBundleDetails.DataSource = books.Tables[0];
            grdPrinterBundleDetails.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("OpeningStockReport.aspx?BookTitle="+Request.QueryString["BookTitle"]+"&BookType="+Request.QueryString["BookType"]+"&Medium="+Request.QueryString["Medium"]+"&ClassTrno="+Request.QueryString["ClassTrno"]+"");
    }
    protected void grdPrinterBundleDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
      

    }
    protected void Button2_Click(object sender, EventArgs e)
    {        CommonFuction comm = new CommonFuction();
        for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
        {

            if (((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked == true)
            {

            comm.FillDatasetByProc("delete from dpt_stockdetailschild_t where BundleNo_I=" + ((Label)grdPrinterBundleDetails.Rows[i].FindControl("BundleNo_I")).Text + " ");
            }

        }
      DataSet books = comm.FillDatasetByProc("call USP_DPTOPeningStock(" + Request.QueryString["BookTitle"] + ",0," + Session["userID"].ToString() + "," + Request.QueryString["BookType"] + "," + Request.QueryString["Medium"] + "," + Request.QueryString["ClassTrno"] + ")");
      grdPrinterBundleDetails.DataSource = books.Tables[0];
       grdPrinterBundleDetails.DataBind();


    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
        {
            if (((CheckBox)grdPrinterBundleDetails.HeaderRow.FindControl("CheckBox2")).Checked == true)
            {
                ((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked = true;
            }
            else
            {
                ((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked = false;
            }
        }
    }
}