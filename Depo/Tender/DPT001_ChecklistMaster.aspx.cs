using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;

public partial class Depo_Tender_DPT001_ChecklistMaster : System.Web.UI.Page
{
    Vehicle003_Tender obj = null;
    CommonFuction comm = new CommonFuction();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCheckListCondition();
        }

    }

    public void LoadCheckListCondition()
    {
        DataSet ds = new DataSet();
        //obj = new Vehicle003_Tender();

        //obj.TenderCheckListTrno = Convert.ToInt32(HdnTenderCheckListTrno.Value);
        ds = comm.FillDatasetByProc("call depo_TenderChecklistConditionLoad(" + HdnTenderCheckListTrno.Value + ")");

        if (ds.Tables[0].Rows.Count > 0 && Convert.ToInt32(HdnTenderCheckListTrno.Value) > 0)
        {
            txtCheckListCondition.Text = Convert.ToString(ds.Tables[0].Rows[0]["CheckListCondition"]);
            chkDisplayStatus.Checked = Convert.ToString(ds.Tables[0].Rows[0]["DisplayStatus"]) == "YES" ? true : false;
        }

        GrdCondition.DataSource = ds;
        GrdCondition.DataBind();
    }

    public int SaveCheckListCondition()
    {
        int i = 0;
        //obj = new Vehicle003_Tender();
        try
        {
            //obj.TenderCheckListTrno = Convert.ToInt32(HdnTenderCheckListTrno.Value);
            //obj.CheckListCondition = Convert.ToString(txtCheckListCondition.Text);
            //obj.CheckListConditionHindi = Convert.ToString(txtCheckListCondition.Text);
            //obj.DisplayStatus = chkDisplayStatus.Checked == true ? "YES" : "NO";
            //obj.UserTrno_I = Convert.ToInt32(Session[""]);
            //i = obj.TenderChecklistConditionSaveUpdate();
            string status = chkDisplayStatus.Checked == true ? "YES" : "NO";
            comm.FillDatasetByProc("call Depo_TenderChecklistSaveUpdate(" + HdnTenderCheckListTrno.Value + ",'" + txtCheckListCondition.Text + "','" + txtCheckListCondition.Text + "','" + status + "',"+Session["UserID"]+")");
            i = 1;
        }

        catch (Exception ex) { }
        finally { obj = null; }

        return i;
    }

    public void message(string mess, string messType)
    {
        messDiv.Style.Add("display", "block");
        lblMess.Text = mess;

        if (messType == "ERROR")
        {

            messDiv.CssClass = "response-msg error ui-corner-all";
        }

        else if (messType == "SUCCESS")
        {
            messDiv.CssClass = "response-msg success ui-corner-all";

        }

        else if (messType == "INFO")
        {
            messDiv.CssClass = "response-msg inf ui-corner-all";

        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (SaveCheckListCondition() > 0)
        {
            message("टेंडर चेकलिस्ट की शर्त सुरक्षित हो गई है |", "SUCCESS");
            txtCheckListCondition.Text = "";
            chkDisplayStatus.Checked = false;
            HdnTenderCheckListTrno.Value = "0";
            LoadCheckListCondition();


        }
        else
        {
            message("टेंडर चेकलिस्ट की शर्त सुरक्षित नहीं हुई है |", "ERROR");
            txtCheckListCondition.Text = "";
            chkDisplayStatus.Checked = false;
            HdnTenderCheckListTrno.Value = "0";
            LoadCheckListCondition();
        }
    }

    protected void GrdCondition_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        HdnTenderCheckListTrno.Value = ((HiddenField)GrdCondition.Rows[e.RowIndex].FindControl("HdnTenderCheckListTrno")).Value;
        txtCheckListCondition.Text = ((Label)GrdCondition.Rows[e.RowIndex].FindControl("LblCheckListCondition")).Text;
        chkDisplayStatus.Checked = ((Label)GrdCondition.Rows[e.RowIndex].FindControl("lblDisplayStatus")).Text == "YES" ? true : false;
    }
    protected void GrdCondition_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}