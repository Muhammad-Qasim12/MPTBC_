using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Depo_TotalVitranNirdesh : System.Web.UI.Page
{
    DIS_DemandEstimation ObjDemandEstimation = new DIS_DemandEstimation();
    CommonFuction obCommonFuction = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();

            ddlMedium.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM013_MediumMaster_Load(0)").Tables[0];
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, new ListItem("Select...", "0"));
            DDlDepot.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            DDlDepot.DataValueField = "DepoTrno_I";
            DDlDepot.DataTextField = "DepoName_V";
            DDlDepot.DataBind();
            DDlDepot.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string DepoID;
        if (DDlDepot.SelectedIndex == 0)
        {
            DepoID = "0";
        }
        else
        {
            DepoID = DDlDepot.SelectedValue;
        
        }
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_TotalVitranNirdesh('" + DdlACYear.SelectedValue + "','" + DropDownList2.SelectedValue + "','" + ddlMedium.SelectedValue + "'," + DepoID + ")");
        GridView1.DataBind();
    }
    int Samany, Yojan, Total;
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                try
                {

                   // TextBox txtSamany = (TextBox)e.Row.FindControl("txtSamany");
                    Yojan += Convert.ToInt32(e.Row.Cells[2].Text);
                    Samany += Convert.ToInt32(e.Row.Cells[3].Text);
                    Total += Convert.ToInt32(e.Row.Cells[4].Text);
                }
                catch { }
              


            }
            catch { }
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[2].Text = Yojan.ToString();
            e.Row.Cells[3].Text = Samany.ToString();
            e.Row.Cells[4].Text = Total.ToString();

        }
    }
}