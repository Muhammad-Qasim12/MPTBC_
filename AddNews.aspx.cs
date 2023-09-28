using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
public partial class AddNews : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    APIProcedure api = new APIProcedure();
    string FileName;
    CultureInfo cult = new CultureInfo("gu-IN", true);
  //  CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string ImgStatus = "";
        if (FileUpload1.FileName == "")
        {
            ImgStatus = "Ok";
        }
        else
        {
            ImgStatus = api.SingleuploadFile(FileUpload1, "News", 5000);
            FileName = api.FullFileName;
        }
        if (HiddenField1.Value == "")
        {
            comm.FillDatasetByProc("call USP_NewsSave(0,'" + TextBox1.Text + "','" + FileName + "'," + RadioButtonList1.SelectedValue + ",'"+TextBox2.Text+"','"+Convert.ToDateTime (TextBox3.Text ,cult).ToString("yyyy-MM-dd")+"')");
        }
        else
        {
            if (FileName == "")
            {
                FileName = HiddenField3.Value;
            }
            comm.FillDatasetByProc("call USP_NewsSave(" + HiddenField1.Value + ",'" + TextBox1.Text + "','" + FileName + "'," + RadioButtonList1.SelectedValue + ",'" + TextBox2.Text + "','" + Convert.ToDateTime(TextBox3.Text, cult).ToString("yyyy-MM-dd") + "')");
        }
        TextBox1.Text = "";
        fillgrd();
        HiddenField1.Value = "";
        HiddenField3.Value = "";
    }
    public void fillgrd()
    {
       DataSet dd= comm.FillDatasetByProc("call USP_NewsSave(-1,'" + TextBox1.Text + "','" + FileName + "'," + RadioButtonList1.SelectedValue + ",0,'')");
       GridView2.DataSource = dd.Tables[0];
       GridView2.DataBind();
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        comm.FillDatasetByProc("call USP_NewsSave(-2,'',''," + GridView2.DataKeys[e.RowIndex].Value + ",0,'')");
        fillgrd();
    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList1.SelectedValue = ((HiddenField)GridView2.SelectedRow.FindControl("HiddenField4")).Value;
        
        TextBox1.Text = GridView2.SelectedRow.Cells[2].Text;
        TextBox2.Text = GridView2.SelectedRow.Cells[4].Text;
       
        HiddenField3.Value = GridView2.SelectedRow.Cells[3].Text;
        HiddenField1.Value = GridView2.SelectedDataKey.Value.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button txtPerbundlebook = (Button)sender;
        //txtPerbundlebook
        GridViewRow grdrow = (GridViewRow)txtPerbundlebook.NamingContainer;
        HiddenField hdv = (HiddenField)grdrow.FindControl("HiddenField5");
        comm.FillDatasetByProc("delete from tbl_NewsUpload where ID="+hdv.Value+"");
        fillgrd();

    }
}