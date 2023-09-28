using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;
using System.Data;
using MPTBCBussinessLayer.AcademicB;
using MPTBCBussinessLayer.Paper;

public partial class View_PaperAllotmentReturn : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    ACB_PaperAllotmentDetails obACB_PaperAllotmentDetails = null;
    PPR_WorkPlan objWorkPlan = null;
    DataSet ds; decimal TotalSheets;
    APIProcedure objdb = new APIProcedure(); string str1; int count12;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

           
            try
            {
                if (Request.QueryString["y"] != null && Request.QueryString["y"].ToString() != "")
                    lblAcyear.Text = objdb.Decrypt(Request.QueryString["y"].ToString());
                else lblAcyear.Text = "2018-2019";
                BindGrdWorkPlan();

            }
            catch { }
            finally { obPRI_PaperAllotment = null; }
        }


    }
   
    protected void ddlPaperType_Init(object sender, EventArgs e)
    {
        PaperTypeFill();
    }
    public void PaperTypeFill()
    {
        objWorkPlan = new PPR_WorkPlan();
        //ddlPaperType.DataSource = objWorkPlan.PaperTypeFill();
        //ddlPaperType.DataTextField = "PaperType";
        //ddlPaperType.DataValueField = "PaperType_Id";
        //ddlPaperType.DataBind();
        //ddlPaperType.Items.Insert(0, "सलेक्ट करे ");
    }




    protected void lnkChangeSts_Click(object sender, EventArgs e)
    {
        LinkButton lnk = (LinkButton)sender;
        GridViewRow gv = (GridViewRow)lnk.NamingContainer;
        HiddenField hdnPrinterDisTranId = (HiddenField)gv.FindControl("hdnPrinterDisTranId");
        obCommonFuction.FillDatasetByProc("UPDATE ppr_paperprinterreturn_m SET UpdateStatus=1 WHERE PrinterDisTranId='"+hdnPrinterDisTranId.Value+"'");
        BindGrdWorkPlan();
        //Response.Write("alert('Sent to central depo successfully');");
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Sent to central depo successfully');</script>");
    }



    public void BindGrdWorkPlan()
    {
        string UserID = Session["UserID"].ToString();
        CommonFuction comm = new CommonFuction();
        DataSet ds3 = comm.FillDatasetByProc("call USP_PaperReturnOrderFromPrinter('" + lblAcyear.Text + "'," + UserID + ",0,4)");
        string ID = ds3.Tables[0].Rows[0][0].ToString();
        ds3 = comm.FillDatasetByProc("call USP_PaperReturnOrderFromPrinter('"+lblAcyear.Text+"'," + ID + ",0,2)");
        GrdPaperAllotment.DataSource = ds3;
        GrdPaperAllotment.DataBind();
    }

}