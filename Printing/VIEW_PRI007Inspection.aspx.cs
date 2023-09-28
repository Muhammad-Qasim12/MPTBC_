using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MPTBCBussinessLayer;

public partial class Printing_VIEW_PRI007Inspection : System.Web.UI.Page
{
    PRI_Inspection obInspection = new PRI_Inspection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            loadInspection();
        }
    }

    public void loadInspection()
    {
        DataSet ds = new DataSet();

        obInspection = new PRI_Inspection();

        try
        {
            obInspection.InspectionTrno_I = 0;

            ds = obInspection.Select();

            grdAvas.DataSource = ds;

            grdAvas.DataBind();
        }

        catch (Exception ex) { }

        finally { obInspection = null; }

    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("PRI007_Inspection.aspx");
    }
}