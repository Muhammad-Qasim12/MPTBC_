using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;

public partial class Depo_ShowChallanDetails : System.Web.UI.Page
{

    DepoReport obDepoReport = new DepoReport();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        
        { 
            LoadGrid(); 
        }
    }


    public void LoadGrid()
    {
        

        try
        {
            obDepoReport.UserID = 9;//Convert.ToInt32 (Session["UserID"]);
            GrdChallan.DataSource = obDepoReport.LoadChallanDetails ();

            GrdChallan.DataBind();
        }

        catch (Exception ex) { }
        finally { }


    }
}