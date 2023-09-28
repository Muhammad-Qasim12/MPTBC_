using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_ShowReceivedDetails : System.Web.UI.Page
{
    string bundleNoID; int Count;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack )
        {
            fillgrd();
          
        }
    }
    public void fillgrd()
    {
        CommonFuction obCommonFuction = new CommonFuction();
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT_041GetStockFromPrinter(" + Request.QueryString["ID"] + "," + Request.QueryString["SubJectID_I"] + ")");
        grdPrinterBundleDetails.DataSource = ds.Tables[0];
        grdPrinterBundleDetails.DataBind();
        GrdMismatch.DataSource = ds.Tables[1];
        GrdMismatch.DataBind();
        lblmsg2.Visible = true;

        lblmsg1.Visible = true;

        grdAprapt.DataSource = ds.Tables[2];
        grdAprapt.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("InterDepoBookReceived.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        

        CommonFuction obCommonFuction = new CommonFuction();
        try {
        
        for (int i = 0; i < grdPrinterBundleDetails.Rows.Count; i++)
        {
            if (((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked == true)
            {
                if (Count==0)
                {
                    bundleNoID=((Label)grdPrinterBundleDetails.Rows[i].FindControl("lblBundleNo_I")).Text;
                Count=Count+1;
                }else 
                {
                    bundleNoID = bundleNoID +","+ ((Label)grdPrinterBundleDetails.Rows[i].FindControl("lblBundleNo_I")).Text;
                }
                
                
            }
        }
        }
        catch { }
        obCommonFuction.FillDatasetByProc("call DPTUpdateBundleDetails('" + bundleNoID + "')");
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT_041GetStockFromPrinter(" + Request.QueryString["ID"] + "," + Request.QueryString["SubJectID_I"] + ")");
        grdPrinterBundleDetails.DataSource = ds.Tables[0];
        grdPrinterBundleDetails.DataBind();
        GrdMismatch.DataSource = ds.Tables[1];
        GrdMismatch.DataBind();
        lblmsg2.Visible = true;

        lblmsg1.Visible = true;
        lblmsg2.Text = "बण्डल प्राप्त कर लिए गए है ";
        grdAprapt.DataSource = ds.Tables[2];
        grdAprapt.DataBind();
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
                ((CheckBox)grdPrinterBundleDetails.Rows[i].FindControl("CheckBox1")).Checked = false ;
            }
        }
    }
}