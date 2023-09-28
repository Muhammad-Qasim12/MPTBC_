using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_Adasborad : System.Web.UI.Page
{
    CommonFuction obj = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlAcYear.DataSource = obj.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(0)");
            ddlAcYear.DataTextField = "AcYear";
            ddlAcYear.DataValueField = "AcYear";
            ddlAcYear.DataBind();
            ddlAcYear.Items.FindByText(obj.FillDatasetByProc("call USP_ADM015_AcadmicYearLoad(2)").Tables[0].Rows[0][0].ToString()).Selected = true;
            DataSet dt = obj.FillDatasetByProc("CALL USP_AcademicDashboard('')");
          //  lblTotalBook.Text = Convert.ToString(Convert.ToInt32(dd.Tables[0].Rows[0]["Samany"]) + Convert.ToInt32(dd.Tables[0].Rows[0]["Yojna"]));
            lblTotalPrinOrder.Text =Convert.ToString( dt.Tables[0].Rows[0]["PrintOrder"]);
            lblTotalCd.Text = Convert.ToString(dt.Tables[2].Rows[0]["CDRetSend"]);
            lblRemainCD.Text = Convert.ToString(Convert.ToInt32(dt.Tables[1].Rows[0]["CDSend"]) - Convert.ToInt32(dt.Tables[2].Rows[0]["CDRetSend"]));
            lblTotalAllotmentbook.Text =Convert.ToString( dt.Tables[5].Rows[0]["TotalTitle"]);
            lblNCIRT.Text =Convert.ToString( dt.Tables[3].Rows[0]["Ncrt"]);
            lblNonNCIRT.Text =Convert.ToString( dt.Tables[4].Rows[0]["Scrt"]);
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        DataSet dt = obj.FillDatasetByProc("CALL USP_AcademicDashboard('"+ddlAcYear.SelectedValue+"')");
        //  lblTotalBook.Text = Convert.ToString(Convert.ToInt32(dd.Tables[0].Rows[0]["Samany"]) + Convert.ToInt32(dd.Tables[0].Rows[0]["Yojna"]));
        lblTotalPrinOrder.Text = Convert.ToString(dt.Tables[0].Rows[0]["PrintOrder"]);
        lblTotalCd.Text = Convert.ToString(dt.Tables[2].Rows[0]["CDRetSend"]);
        lblRemainCD.Text = Convert.ToString(Convert.ToInt32(dt.Tables[1].Rows[0]["CDSend"]) - Convert.ToInt32(dt.Tables[2].Rows[0]["CDRetSend"]));
        lblTotalAllotmentbook.Text = Convert.ToString(dt.Tables[5].Rows[0]["TotalTitle"]);
        lblNCIRT.Text = Convert.ToString(dt.Tables[3].Rows[0]["Ncrt"]);
        lblNonNCIRT.Text = Convert.ToString(dt.Tables[4].Rows[0]["Scrt"]);
        

    }
}