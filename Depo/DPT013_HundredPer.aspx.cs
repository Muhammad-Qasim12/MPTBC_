using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;
using System.Globalization;


public partial class Depo_DPT013_HundredPer : System.Web.UI.Page
{
    CountingDetails obCountingDetails = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    public string Pdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obCountingDetails = new CountingDetails();
            obCountingDetails.userID = Convert.ToInt32(Session["UserID"]);
            DataSet ds = obCountingDetails.FillPriterDetails();
            GrdMain.DataSource = ds.Tables[0];
            GrdMain.DataBind();
            Pdate = System.DateTime.Now.ToString ("dd/MM/yyyy");
            if (Convert.ToString(Request.QueryString["ID"]) != null)
            {
                DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT017_LoadHunderedPerDataDetailsNEw(" + Session["UserID"] + "," + Request.QueryString["ID"] + ")");
                try
                {
                    lblPriner.Text = Convert.ToString(ds1.Tables[1].Rows[0]["NameofPress_V"]);
                    txtFrom.Text = Convert.ToString(ds1.Tables[1].Rows[0]["FromDate_D"]);
                    txtto.Text = Convert.ToString(ds1.Tables[1].Rows[0]["Totaldate_D"]);
                }
                catch { }


                grdDetails.DataSource = ds1.Tables[1];
                grdDetails.DataBind();
                a.Visible = true;
                GrdMain.Visible = false;
            }
        
        }

    }
    protected void GrdMain_SelectedIndexChanged(object sender, EventArgs e)
    {
//0001-01-01 00:00:00
      
        //obCountingDetails = new CountingDetails();
        //obCountingDetails.PinterID_I =Convert.ToInt32( GrdMain.SelectedDataKey.Value);
        //obCountingDetails.LetterNo_V ="";
        //DataSet ds1 = obCountingDetails.FillHundredPerDetails();
        DataSet ds1 = obCommonFuction.FillDatasetByProc("call USP_DPT017_LoadHunderedPerDataDetailsNEw(" + Session["UserID"] + "," + GrdMain.SelectedDataKey.Value + ")");
        try {
        lblPriner.Text = Convert.ToString(ds1.Tables[0].Rows[0]["NameofPress_V"]);
        }
        catch { }


        grdDetails.DataSource = ds1.Tables[0];
        grdDetails.DataBind();
        a.Visible = true;
        GrdMain.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obCountingDetails = new CountingDetails();
        CommonFuction comm = new CommonFuction();
        for (int j = 0; j < grdDetails.Rows.Count; j++)
        {
            try
            {
                //obCountingDetails.FromDate_D = Convert.ToDateTime(txtFrom.Text, cult);
                //obCountingDetails.Totaldate_D = Convert.ToDateTime(txtto.Text, cult);
                //obCountingDetails.Remarks_V = Convert.ToString(txtremark.Text);
                //obCountingDetails.ReceivedBookNo_I = Convert.ToInt32(((TextBox)grdDetails.Rows[j].FindControl("txtNoofBook")).Text);
                //obCountingDetails.Hund_ReDate = Convert.ToDateTime(((TextBox)grdDetails.Rows[j].FindControl("txtLdate")).Text, cult);
                //obCountingDetails.TotalNotuseful_N = Convert.ToInt32(((TextBox)grdDetails.Rows[j].FindControl("txtnotsell")).Text);
                //obCountingDetails.DStockReceivedTPerID_I = Convert.ToInt32(((HiddenField)grdDetails.Rows[j].FindControl("HiddenField1")).Value);
                //obCountingDetails.InsertUpdateHund();
                comm.FillDatasetByProc("call USP_DPT017_UpdateHundredPer(" + ((HiddenField)grdDetails.Rows[j].FindControl("HiddenField1")).Value + ",'" + Convert.ToDateTime(txtFrom.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToDateTime(txtto.Text, cult).ToString("yyyy-MM-dd") + "','" + Convert.ToString(txtremark.Text) + "','" + Convert.ToDateTime(((TextBox)grdDetails.Rows[j].FindControl("txtLdate")).Text, cult).ToString("yyyy-MM-dd") + "'," + Convert.ToInt32(((TextBox)grdDetails.Rows[j].FindControl("txtNoofBook")).Text) + "," + Convert.ToInt32(((TextBox)grdDetails.Rows[j].FindControl("txtnotsell")).Text) + "," + Convert.ToInt32(((TextBox)grdDetails.Rows[j].FindControl("Textbox1")).Text) + ",'" + Convert.ToString(((TextBox)grdDetails.Rows[j].FindControl("txtRemarkF")).Text) + "','" + Convert.ToString(((TextBox)grdDetails.Rows[j].FindControl("TextBox2")).Text) + "')");

                //obDBAccess.execute("USP_DPT017_UpdateHundredPer", DBAccess.SQLType.IS_PROC);
                //obDBAccess.addParam("id", DStockReceivedTPerID_I);
                //obDBAccess.addParam("FromDate_D", FromDate_D);
                //obDBAccess.addParam("Totaldate_D", Totaldate_D);
                //obDBAccess.addParam("Remarks_V", Remarks_V);
                //obDBAccess.addParam("Hund_ReDate", Hund_ReDate);
                //obDBAccess.addParam("mReceivedBookNo_I", ReceivedBookNo_I);
                //obDBAccess.addParam("TotalNotuseful_N", TotalNotuseful_N);

            }
            catch { }
        }
        Response.Redirect("VIEW_DPT013.aspx");
        obCommonFuction.EmptyTextBoxes(this);
    }
}