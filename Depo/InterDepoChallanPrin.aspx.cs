using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Collections;
using System.Data.OleDb;
using System.Data;
using System.IO;

public partial class Depo_InterDepoChallanPrin : System.Web.UI.Page
{
    int totalBook = 0;
    int TotalLooj = 0;
    int TotalPaik = 0;
    int TotalPaik1 = 0;
    int TotalPaik2 = 0;
    int aj = 0;
    decimal total_TotalBookpaik = 0;
    string SubQuery, SubQuery1;
    int titleIDa;
    CommonFuction obCommonFuction = new CommonFuction();
    int count12;

    ArrayList aa = new ArrayList();
    int TotalBandal, count1; int total = 0, total112, total113;
    int grdCount1, grdCount2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataSet asdf = obCommonFuction.FillDatasetByProc("call USP_DPTInterDepoChallan(" + Session["UserID"] + ",0,0)");
                ddlChallano.DataSource = asdf.Tables[1];
                ddlChallano.DataTextField = "ChallanNo_V";
                ddlChallano.DataValueField = "ChallanNo_V";
                ddlChallano.DataBind();

                ddlChallano.Items.Insert(0, "Select..");
                ddlSessionYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                ddlSessionYear.DataValueField = "AcYear";
                ddlSessionYear.DataTextField = "AcYear";
                ddlSessionYear.DataBind();
                if (Request.QueryString["ChallanID"] != null)
                {
                    ddlChallano.SelectedValue = Request.QueryString["ChallanID"].ToString();

                }

            }
            catch { }
        }
    }
    
    protected void grdPrinterBundleDetails0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                aj += 1;
                try
                {
                    totalBook += e.Row.Cells[1].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[1].Text.Replace("&nbsp;", "0"));//Convert.ToInt32(e.Row.Cells[1].Text);
                    // total_BundleNo_IMin += e.Row.Cells[7].Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(e.Row.Cells[7].Text);

                }
                catch { }
                try
                {
                    TotalLooj += e.Row.Cells[2].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[2].Text.Replace("&nbsp;", "0"));

                }
                catch { }
                try
                {
                    TotalPaik += e.Row.Cells[3].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[3].Text.Replace("&nbsp;", "0"));
                }
                catch { }
                try
                {
                    TotalPaik1 += e.Row.Cells[4].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[4].Text.Replace("&nbsp;", "0"));
                }
                catch { }

                try
                {
                    TotalPaik2 += e.Row.Cells[5].Text.Trim().Length == 0 ? 0 : Convert.ToInt32(e.Row.Cells[5].Text.Replace("&nbsp;", "0"));
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
            e.Row.Cells[0].Text = aj.ToString();
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[1].Text = totalBook.ToString();
            e.Row.Cells[2].Text = TotalLooj.ToString();
            e.Row.Cells[3].Text = TotalPaik.ToString();
            e.Row.Cells[4].Text = TotalPaik1.ToString();
            e.Row.Cells[5].Text = TotalPaik2.ToString();
            //e.Row.Cells[7].Text = total_BundleNo_IMin.ToString();
            //e.Row.Cells[8].Text = total_BundleNo_Imax.ToString();
            //e.Row.Cells[9].Text = total_FromNo_I.ToString();
            //e.Row.Cells[10].Text = total_ToNo_I.ToString();

        }
    }
    protected void Button6_Click1(object sender, System.EventArgs e)
    {
        string lblfyYaer;
        lblfyYaer = obCommonFuction.FillDatasetByProc("select GetAcYear()").Tables[0].Rows[0][0].ToString();

        DataSet ds1 = obCommonFuction.FillDatasetByProc("Call USPDPTGetInterDepoChallan('" + ddlChallano.SelectedValue + "'," + Session["UserID"] + ",'" + lblfyYaer.ToString() + "','" + ddlChallano.SelectedItem.Text + "')");
        GridView5.DataSource = ds1;
        GridView5.DataBind();
        DataSet ds12 = obCommonFuction.FillDatasetByProc("call GetInterdepoDetails('" + ddlChallano.SelectedValue + "')");
        lblSenderDepo.Text = ds12.Tables[0].Rows[0]["SupplierDepo"].ToString();
        lblReceiverDepot.Text = ds12.Tables[0].Rows[0]["DemandingDepot"].ToString();
        //GetInterdepoDetails
        lblChallan.Text = ddlChallano.SelectedItem.Text;
    }
}