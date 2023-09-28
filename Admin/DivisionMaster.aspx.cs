using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Admin_DivisionMaster : System.Web.UI.Page
{
    DivisionMaster obDivisionMaster = new DivisionMaster();
    CommonFuction obCommonFuction = null;
    APIProcedure objdb = new APIProcedure();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    showdata(objdb.Decrypt(Request.QueryString["ID"].ToString()));
                }

            }
            catch { }
            finally { obDivisionMaster = null; }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            obDivisionMaster = new DivisionMaster();
            obDivisionMaster.Division_Name_Hindi_V = Convert.ToString(txtdistNameHin.Text);
            obDivisionMaster.Division_Name_Eng_V = Convert.ToString(txtdistNameEng.Text);
            obDivisionMaster.Trans_I = 0;

            obDivisionMaster.DivisionTrno_I = 0;
            if (HiddenField1.Value != "")
            {
                obDivisionMaster.Trans_I = 1;
                obDivisionMaster.DivisionTrno_I = Convert.ToInt32(HiddenField1.Value);
            }
            obDivisionMaster.InsertUpdate();
            obCommonFuction = new CommonFuction();
            obCommonFuction.EmptyTextBoxes(this);
            HiddenField1.Value = "";
        }
        catch { }
        finally
        {
            obDivisionMaster = null;
        }
        Response.Redirect("VIEW_ADM006.aspx");
    }

    public void showdata(string ID)
    {
        obDivisionMaster = new DivisionMaster();
        obDivisionMaster.DivisionTrno_I = Convert.ToInt32(objdb.Decrypt(Request.QueryString["ID"].ToString()));
        DataSet obDataSet = obDivisionMaster.Select();

        txtdistNameHin.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Division_Name_Hindi_V"]);
        txtdistNameEng.Text = Convert.ToString(obDataSet.Tables[0].Rows[0]["Division_Name_Eng_V"]);
        obDivisionMaster.Trans_I = 1;
        HiddenField1.Value = (objdb.Decrypt(Request.QueryString["ID"].ToString()));

    }
}