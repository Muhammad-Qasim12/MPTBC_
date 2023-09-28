using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
public partial class Printing_VIEW002_PrinChallanDetails : System.Web.UI.Page
{

    PRIN_ChallanDetails obPrinChallan = null;
    CommonFuction comm = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { LoadGrid(); }
    }


    public void LoadGrid()
    {
        //USP_PRIN0011_ChallanDetailsLoadUE_New

      obPrinChallan = new PRIN_ChallanDetails();
      PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
      PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
      DataSet ds = new DataSet();
        ds = PriReg.GetPrinterDetails();
        
        GrdChallan.DataSource = comm.FillDatasetByProc("call USP_PRIN0011_ChallanDetailsLoadUE_New (0," + Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]) + ")");
      GrdChallan.DataBind();
      
        //try
        //{
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
        //        obPrinChallan.PriTransID = 0;
        //        obPrinChallan.Depo_I = Convert.ToInt32(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
        //        // printer id using depo variable
        //    }
        //    else
        //    {
        //        obPrinChallan.Depo_I = Convert.ToInt32(Session["USerID"]); ;
        //        obPrinChallan.PriTransID = 0;
        //    }
            
        //    GrdChallan.DataSource = obPrinChallan.PrinLoadChallanDetails();
        //    GrdChallan.DataBind();
        //}

        //catch (Exception ex) { }
        //finally { obPrinChallan = null; }


    }

    protected void btnAdd_Click(object sender, EventArgs e) 
    {
        Response.Redirect("PRIN0011_ChallanDetailsU_E.aspx");
    }

    protected void GrdChallan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnClick(object sender, EventArgs e)
    {
        LinkButton btns = (LinkButton)sender;

        GridViewRow grd = (GridViewRow)(btns.NamingContainer);

        HiddenField hd = (HiddenField)grd.FindControl("HiddenField1");
        comm.FillDatasetByProc("call USP_DeleteUEGroup(" + hd.Value + ")");
        LoadGrid();
        //Response.Redirect("PRIN0011_ChallanDetails.aspx?Cid=" + new APIProcedure().Encrypt(hd.Value) + "");
        
    }
}