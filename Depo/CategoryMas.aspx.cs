using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Depo_CategoryMas : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillgrd();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (txtName.Text == "")
        {

        }
        else
        {
            if (HiddenField1.Value == "")
            { 
            comm.FillDatasetByProc("call DPT_CategoryMasterSave(0,'" + txtName.Text + "','" + txtAmount.Text + "')");
            }
            else
            {

                comm.FillDatasetByProc("call DPT_CategoryMasterSave("+HiddenField1.Value+",'" + txtName.Text + "','" + txtAmount.Text + "')");
            }
            fillgrd(); txtAmount.Text = "";
            txtName.Text = "";
            HiddenField1.Value = "";
            ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('आपका का डाटा सुरक्षित हो चूका है .');</script>");
        }
    }
    public void fillgrd()
    {
       DataSet dd= comm.FillDatasetByProc("call DPT_CategoryMasterSave(-1,'" + txtName.Text + "','" + txtAmount.Text + "')");
       GridView1.DataSource = dd.Tables[0];
       GridView1.DataBind();
    }
}