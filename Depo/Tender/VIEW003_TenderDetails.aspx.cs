using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Vehicle_VIEW003_TenderDetails : System.Web.UI.Page
{
     Vehicle003_Tender obTender = null;
     CommonFuction obCommonFuction = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) { LoadTender(); }
    }


    public void LoadTender()
    {
        DataSet ds = new DataSet();

        obTender = new Vehicle003_Tender();

        try
        {

          //  obTender.TenderID_I = 0;

            ds = obCommonFuction.FillDatasetByProc("call Depo_TenderDetailsLoad(0,"+Session["UserID"]+")");

            grdTender.DataSource = ds;
            grdTender.DataBind();

        }

        catch (Exception ex) { }

        finally { obTender = null; }
    }

    protected void btnAdd_Click(object sender, EventArgs e) 
    {
        Response.Redirect("DPT002_TenderMaster.aspx");
    }

}