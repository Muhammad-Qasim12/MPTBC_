using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class DistributionB_PrintData : System.Web.UI.Page
{
    public DataSet dtr = new DataSet();
    public DataSet dtr1 = new DataSet();
    public DataSet dtr2 = new DataSet();
    public int r;
    public CommonFuction comm = new CommonFuction();
    public double TotalAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dtr = comm.FillDatasetByProc("call USP_DIB008_BillPaymentSelect(" + Request.QueryString["ID"].ToString() + "," + Request.QueryString["ID"].ToString() + ",-9)");
            dtr1 = comm.FillDatasetByProc("call USP_DIB008_BillPaymentSelect(" + Request.QueryString["ID"].ToString() + "," + Request.QueryString["ID"].ToString() + ",-8)");

            if (dtr.Tables[0].Rows.Count > 0)
            {
                span_Title.InnerText = Convert.ToString(dtr.Tables[0].Rows[0]["Title"]);
            }

        }
    }
}