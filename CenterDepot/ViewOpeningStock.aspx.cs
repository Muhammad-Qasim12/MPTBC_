using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer.Paper;
using System.Globalization;
using System.Data;

public partial class Paper_ViewOpeningStock : System.Web.UI.Page
{
    DataSet ds;
    PPR_PaperOpeningBal objPaperOpeningBal = null;
    CultureInfo cult = new CultureInfo("gu-IN", true);
    CommonFuction obCommonFuction = new CommonFuction();
    string AcYear = "", Depot_Id = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Depot_Id = Session["UserID"].ToString();
        AcYear = obCommonFuction.GetFinYear();
        if (!Page.IsPostBack)
        {
            GridFillLoad();
        }
    }
    public void GridFillLoad()
    {
        try
        {
            objPaperOpeningBal = new PPR_PaperOpeningBal();
            objPaperOpeningBal.AcYear = AcYear;
            GrdLOI.DataSource = objPaperOpeningBal.FillOpeningStock();
            GrdLOI.DataBind();
        }
        catch { }

    }

    protected void GrdLOI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdLOI.PageIndex = e.NewPageIndex;
        GridFillLoad();
    }
    protected void GrdLOI_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objPaperOpeningBal = new PPR_PaperOpeningBal();
        string SaveSts = "No";
        foreach (GridViewRow gv in GrdLOI.Rows)
        {
            CheckBox chkSelect = (CheckBox)gv.FindControl("chkSelect");
            Label lblOpnBal_Id = (Label)gv.FindControl("lblOpnBal_Id");
            Label lblPaperType_I = (Label)gv.FindControl("lblPaperType_I");
            Label lblPaperTrId_I = (Label)gv.FindControl("lblPaperTrId_I");
            TextBox txtQty = (TextBox)gv.FindControl("txtQty");
            if (chkSelect.Checked == true)
            {
                objPaperOpeningBal.AcYear = AcYear;
                objPaperOpeningBal.OpnBal_Id = int.Parse(lblOpnBal_Id.Text);
                objPaperOpeningBal.PaperTrId_I = int.Parse(lblPaperTrId_I.Text);
                objPaperOpeningBal.PaperType_I = int.Parse(lblPaperType_I.Text);
                objPaperOpeningBal.UserId_I = int.Parse(Depot_Id.ToString());
                objPaperOpeningBal.Qty = float.Parse(txtQty.Text);
                objPaperOpeningBal.InsertUpdate();
                SaveSts = "Ok";
            }
        }
        if (SaveSts == "Ok")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Record saved successfully.');</script>");
            GridFillLoad();
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Please Select At least One Checkbox.');</script>");
        }
    }
    //protected void btnSearch_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        objPaperOpeningBal = new PPR_PaperOpeningBal();
    //        objPaperOpeningBal.AcYear = AcYear;
    //        GrdLOI.DataSource = objPaperOpeningBal.SearchStock(txtSearch.Text);
    //        GrdLOI.DataBind();
    //    }
    //    catch { }
    //}
}