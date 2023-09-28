using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
using System.IO;
using System.Configuration;
using System.Data.OleDb;

public partial class Printing_VIEW_TenderfeeDetailsfinance : System.Web.UI.Page
{
    int mType;
    // CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = null;
    TenderDetails obTenderDetails = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                obCommonFuction = new CommonFuction();
                DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
                DdlACYear.DataValueField = "AcYear";
                DdlACYear.DataTextField = "AcYear";
                DdlACYear.DataBind();
                DdlACYear.SelectedValue = obCommonFuction.GetFinYearNew();
                FillData();
            }
        }

        catch { }
        finally { }
    }
    public void FillData()
    {
        CommonFuction comm = new CommonFuction();
       
        try
        {
            
            if (Session["Roleid"].ToString() == "4")
            {
                mType = 0;
            }
            else if (Session["Roleid"].ToString() == "39")
            {
                mType = 1;
            }




                if (Request.QueryString["ACYear"] != null)
                {
                    GrdTenderDetails.DataSource = comm.FillDatasetByProc("call Prin_loadTenderDetailsFinance('" + mType +"','" + Request.QueryString["ACYear"] + "')"); ;
                    GrdTenderDetails.DataBind();
                }
                else
                {
                    GrdTenderDetails.DataSource = comm.FillDatasetByProc("call Prin_loadTenderDetailsFinance('" + mType + "','" + DdlACYear.SelectedItem.Text + "')"); ;
                    GrdTenderDetails.DataBind();
                }
        
        
        }
        catch
        {
        }
        finally
        {
           // obTenderDetails = null;
        }
    }

    public void FillDatanew()
    {
        CommonFuction comm = new CommonFuction();

        try
        {

            if (Session["Roleid"].ToString() == "4")
            {
                mType = 0;
            }
            else if (Session["Roleid"].ToString() == "39")
            {
                mType = 1;
            }

                      
                GrdTenderDetails.DataSource = comm.FillDatasetByProc("call Prin_loadTenderDetailsFinance('" + mType + "','" + DdlACYear.SelectedItem.Text + "')"); ;
                GrdTenderDetails.DataBind();
            

        }
        catch
        {
        }
        finally
        {
            // obTenderDetails = null;
        }
    }

    
    protected void GrdTenderDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdTenderDetails.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenderDetails.aspx");
    }
    

    protected void btnFinancialClick(object sender, EventArgs e)
    {
        Response.Redirect("TenderCommercialDetails.aspx");
    }

    protected void lnBtnViewAcceptance_Click(object sender, EventArgs e)
    {
        LinkButton lnkSender = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnkSender.NamingContainer;
        HiddenField TID =  (HiddenField)gv.FindControl("HDNTenID");
        ViewState["TenderID"] = TID.Value ;
        CommonFuction comm = new CommonFuction();
        try
        {
            DataSet ds = new DataSet();
            int TenderID = int.Parse(ViewState["TenderID"].ToString());

            ds = comm.FillDatasetByProc("call USP_TenderSendFinance('" + TenderID + "')");  
            
            
        }
        catch { }
    }


    

   
    protected void btnSave0_Click(object sender, EventArgs e)
    {

    }
    protected void DdlACYear_SelectedIndexChanged(object sender, EventArgs e)
    {
         
        FillDatanew();
    }

    protected void GrdTenderDetails_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}