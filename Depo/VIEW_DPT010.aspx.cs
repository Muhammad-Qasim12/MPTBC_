using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_VIEW_DPT013 : System.Web.UI.Page
{
    BookReturn obBookReturn = new BookReturn();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            fillgrd();
        }

    }
    public void fillgrd()
    {
        obBookReturn.UserID_I = Convert.ToInt32(Session["UserID"]);
        DataSet ds = obBookReturn.Select();
        grnMain.DataSource = ds.Tables[0];
        grnMain.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Response.Redirect("DPT010_BookReturnDetails.aspx");
    }
    protected void grnMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grnMain.PageIndex = e.NewPageIndex;
        fillgrd();
    }
}