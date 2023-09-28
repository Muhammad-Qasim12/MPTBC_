using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Printing_Reports_RPT004_Challanreport : System.Web.UI.Page
{
    PRIN_ChallanDetails obPrinChallan = null;
    CommonFuction obCommon = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { LoadGrid(); }
    }


    public void LoadGrid()
    {
        obPrinChallan = new PRIN_ChallanDetails();
        PRI_PrinterRegistration PriReg = new PRI_PrinterRegistration();
        PriReg.UserID_I = Convert.ToInt32(Session["USerID"]);
        DataSet ds = new DataSet();
        ds = PriReg.GetPrinterDetails();
        try
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                obCommon = new CommonFuction();
                lblTitle.Text = "शेक्षणिक सत्र :" + obCommon.GetFinYear() + ", दिनांक :" + System.DateTime.Now.ToString("MMM dd,yyyy");
                Session["PrierID_I"] = Convert.ToString(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                obPrinChallan.PriTransID = 0;
                obPrinChallan.Depo_I = Convert.ToInt32(ds.Tables[0].Rows[0]["Printer_RedID_I"]);
                // printer id using depo variable
            }

            else
            {
                obPrinChallan.Depo_I = 0;
                obPrinChallan.PriTransID = 0;
            }
            GrdChallan.DataSource = obPrinChallan.LoadChallanDetails();
            GrdChallan.DataBind();
        }

        catch (Exception ex) { }
        finally { obPrinChallan = null; }


    }
}