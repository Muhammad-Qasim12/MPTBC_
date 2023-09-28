using System;
using System.Data;

public partial class Distrubution_DepotEmplyeeContactList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CommonFuction obCommonFuction = new CommonFuction();

        DataSet obDataset = obCommonFuction.FillDatasetByProc("Call USP_ADM010_DepomasterLoad(0)");
        GrdContactList.DataSource = obDataset;
        GrdContactList.DataBind();
    }
}