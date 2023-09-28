using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Globalization;

public partial class CenterDepot_PaperRequiredFromPrinter : System.Web.UI.Page
{
    PRI_PaperAllotment obPRI_PaperAllotment = null;
    CommonFuction obCommonFuction = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
        }
    }

    public void FillData()
    {
        try
        {
            obPRI_PaperAllotment = new PRI_PaperAllotment();
            obPRI_PaperAllotment.PaperAltID_I = 0;
            GrdPaperAllotment.DataSource = obPRI_PaperAllotment.Select();
            GrdPaperAllotment.DataBind();
        }
        catch
        {}
        finally { }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Response.Redirect("PaperAllotment.aspx");
    }
    protected void GrdPaperAllotment_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdPaperAllotment.PageIndex = e.NewPageIndex;
        FillData();
    }
    protected void GrdPaperAllotment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obPRI_PaperAllotment = new PRI_PaperAllotment();
        obPRI_PaperAllotment.Delete(Convert.ToInt32(GrdPaperAllotment.DataKeys[e.RowIndex].Value.ToString()));
        FillData();
    }


    protected void GrdPaperAllotment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "cmdSend")
        {
            try
            {
                obPRI_PaperAllotment = new PRI_PaperAllotment();
                obPRI_PaperAllotment.PaperAltID_I = Convert.ToInt32(e.CommandArgument);
                obPRI_PaperAllotment.Status = 1;
                obPRI_PaperAllotment.UpdateStatus(obPRI_PaperAllotment.PaperAltID_I, obPRI_PaperAllotment.Status);

                obCommonFuction = new CommonFuction();
                obCommonFuction.EmptyTextBoxes(this);

                obPRI_PaperAllotment.PaperAltID_I = 0;

                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Request sent to Printer and Central Depo.');");
                Response.Write("</script>");
            }
            catch { }
            finally
            {
                obPRI_PaperAllotment = null;
            }
        }
        else
        {
            obPRI_PaperAllotment = null;
        }


    }
    protected void GrdPaperAllotment_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}