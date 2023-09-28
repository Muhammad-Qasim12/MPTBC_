using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Depo_localShifting : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    APIProcedure api = new APIProcedure();
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
            Filgrd();
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        string ImgStatus = "", ImgStatus1 = "";

        try
        {

            if (FileUpload1.FileName == "")
            {
                ImgStatus = "Ok";
            }
            else
            {
                ImgStatus = api.SingleuploadFile(FileUpload1, "localbill1", 10204);
                ImgStatus1 = api.FullFileName;
            }
        }
        catch { }
        if (txtLooj.Text == "")
        {
            txtLooj.Text = "0";
        }
        obCommonFuction.FillDatasetByProc("call USP_dpt_localShifting(0,'" + DdlACYear.SelectedValue + "','" + Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd") + "'," + txtPaik.Text + "," + txtLooj.Text + "," + TextBox3.Text + ",'" + ImgStatus1 + "',"+Session["UserID"]+")");
        obCommonFuction.EmptyTextBoxes(this); Filgrd();
    }
    public void Filgrd()
    {

     GridView1.DataSource =   obCommonFuction.FillDatasetByProc("call USP_dpt_localShifting(-1,'0','0','0','0','0','0'," + Session["UserID"] + ")");
     GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        obCommonFuction.FillDatasetByProc("call USP_dpt_localShifting("+GridView1.DataKeys[e.RowIndex].Value.ToString ()+",'0','0','0','0','0','0'," + Session["UserID"] + ")");
   
        Filgrd();
    }
    protected void txtPaik_TextChanged(object sender, EventArgs e)
    {
        CommonFuction comm = new CommonFuction();
    DataSet dt=   comm.FillDatasetByProc("call USP_Getrate('"+DdlACYear.SelectedValue+"',"+Session["UserID"]+","+txtPaik.Text+",0)");
    try {
        TextBox3.Text = (dt.Tables[0].Rows[0]["total"].ToString());
    }
    catch { }
    }
    //protected void txtLooj_TextChanged(object sender, EventArgs e)
    //{
    //    //CommonFuction comm = new CommonFuction();
    //    //DataSet dt = comm.FillDatasetByProc("call USP_Getrate('" + DdlACYear.SelectedValue + "'," + Session["UserID"] + ")");
    //    //try
    //    //{
    //    //    TextBox3.Text = Convert.ToString(Convert.ToDouble(txtLooj.Text) * Convert.ToDouble(dt.Tables[0].Rows[0]["RatePerBundle_N"].ToString()));
    //    //}
    //    //catch { }
    //}
}