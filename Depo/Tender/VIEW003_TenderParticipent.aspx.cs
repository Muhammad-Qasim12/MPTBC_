using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

public partial class Vehicle_VIEW003_TenderParticipent : System.Web.UI.Page
{
    Vehicle003_Tender obTender = null;
    CommonFuction obcomm = new CommonFuction();
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

          

            ds = obcomm.FillDatasetByProc("call Depo_TenderParticipentLoad(0,"+Session["UserID"]+")");

            grdTenderParticipent.DataSource = ds.Tables[0];
            grdTenderParticipent.DataBind();

        }

        catch (Exception ex) { }

        finally { obTender = null; }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("TenderParticipent.aspx");
    }

}