using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;
public partial class Depo_DPT011_DemandFormat : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    MediumMaster obMediumMaster = null;
    ClassMaster obClass = null;
    DepoBookDemand obDepoBookDemand = null;
    string id;
    int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obMediumMaster = new MediumMaster();
            obMediumMaster.MediumTrno_I = 0;
            DataSet dtmedium = obMediumMaster.Select();
            ddlMedium.DataTextField = "MediunNameHindi_V";
            ddlMedium.DataValueField = "MediumTrno_I";
            ddlMedium.DataSource = dtmedium.Tables[0];
            ddlMedium.DataBind();
            ddlMedium.Items.Insert(0, "सलेक्ट करे ..");
            //----------------Class Bind

            obClass = new ClassMaster();
            DataSet dtclass = obClass.Select();
            obClass.ClassTrno_I = 0;
         
            CheckBoxList1.DataTextField = "Classdet_V";
            CheckBoxList1.DataValueField = "ClassTrno_I";
            CheckBoxList1.DataSource = dtclass;
            CheckBoxList1.DataBind();
            Random rand = new Random();
            int randnum = rand.Next(100000, 10000000);
            txtOrderNo.Text = randnum.ToString();
        //    ddlClass.Items.Insert(0, "सलेक्ट करे ..");
            fillgrd();
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");

        }
    }
    protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
    {

        //obDepoBookDemand = new DepoBookDemand();
        //DataSet ds = obDepoBookDemand.fillBookData(Convert.ToInt32(ddlClass.SelectedValue), Convert.ToInt32(ddlMedium.SelectedValue), 2, Convert.ToInt32(Session["UserID"]));
        //grdbookdata.DataSource = ds.Tables[0];
        //grdbookdata.DataBind();

    }
    protected void txtDemand_TextChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < grdbookdata.Rows.Count; i++)
        {
            if (((TextBox)grdbookdata.Rows[i].FindControl("txtDemand")).Text != "")
            {
                if (Convert.ToInt32(grdbookdata.Rows[i].Cells[3].Text) < Convert.ToInt32(((TextBox)grdbookdata.Rows[i].FindControl("txtDemand")).Text))
                {
                    ((Label)grdbookdata.Rows[i].FindControl("Label1")).Text = Convert.ToString(Convert.ToInt32(((TextBox)grdbookdata.Rows[i].FindControl("txtDemand")).Text) - Convert.ToInt32(grdbookdata.Rows[i].Cells[3].Text));
                }
                else
                {
                    ((Label)grdbookdata.Rows[i].FindControl("Label1")).Text = "0";
                }
            }
        }
    }
    protected void grdbookdata0_SelectedIndexChanged(object sender, EventArgs e)
    {
        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.DDemandID_I = Convert.ToInt32(grdbookdata0.SelectedDataKey.Value.ToString());
        obDepoBookDemand.DepoID = Convert.ToInt32(Session["UserID"]);
        DataSet ds2 = obDepoBookDemand.Select();

        ddlMedium.SelectedValue = Convert.ToString(ds2.Tables[0].Rows[0]["MedaimID_I"]);
        
       // ddlClass.SelectedValue = Convert.ToString(ds2.Tables[0].Rows[0]["ClassID_I"]);
        txtDate.Text = Convert.ToDateTime(ds2.Tables[0].Rows[0]["DemandDate_D"]).ToString("dd/MM/yyyy");
        txtOrderNo.Text = Convert.ToString(ds2.Tables[0].Rows[0]["OrderNo"]);
        rdDemandType.SelectedValue = Convert.ToString(ds2.Tables[0].Rows[0]["DemandType_I"]);
        rdBookType.SelectedValue = Convert.ToString(ds2.Tables[0].Rows[0]["BookType_I"]); 
        grdbookdata.DataSource = ds2.Tables[0];
        grdbookdata.DataBind();
        HiddenField2.Value = Convert.ToString(ds2.Tables[0].Rows[0]["DemandDetailsID_I"]);// Convert.ToInt32(ds2.Tables[0].Rows[0]["DemandDetailsID_I"]);
    }
     
    public void CheckForUpdate()
    {
        DepoBookDemand  obDepoBookDemandnew = new DepoBookDemand();
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button12.Visible = true;

        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.Date = Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd");
        obDepoBookDemand.UserID_I = Convert.ToInt32(Session["UserID"]);
        DataSet dDate = obDepoBookDemand.CheckDate();
        if (dDate.Tables[0].Rows.Count > 0)
        {
            HiddenField1.Value = Convert.ToString(dDate.Tables[0].Rows[0]["DemandID_I"]);
            HiddenField4.Value = Convert.ToString(dDate.Tables[0].Rows[0]["ClassID_I"]);
        }
        if (HiddenField1.Value == "")
        {
           try
           {
            obDepoBookDemand.BookType_I = Convert.ToInt32(rdBookType.SelectedValue);
            obDepoBookDemand.DemandType_I = Convert.ToInt32(rdDemandType.SelectedValue);
        //    HiddenField4.Value = ddlClass.SelectedValue;
            obDepoBookDemand.DemandDate_D = Convert.ToDateTime(txtDate.Text, cult);
            obDepoBookDemand.MedaimID_I = Convert.ToInt32(ddlMedium.SelectedValue);
         //   obDepoBookDemand.ClassID_I = Convert.ToInt32(ddlClass.SelectedValue);
            obDepoBookDemand.DepoID = Convert.ToInt32(Session["UserID"]);
            obDepoBookDemand.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
            obDepoBookDemand.UserID_I = Convert.ToInt32(Session["UserID"]);
            obDepoBookDemand.OrderNo = Convert.ToString(txtOrderNo.Text);
            int id = Convert.ToInt32(obDepoBookDemand.InsertUpdate());
            HiddenField1.Value = id.ToString();
           }
           catch { }
            // //HiddenField1.Value=Convert.ToInt32( obDepoBookDemand.InsertUpdate());
        }
        else
        {

        }
        for (int j = 0; j < grdbookdata.Rows.Count; j++)
        {
            obDepoBookDemand.Demand_I = Convert.ToInt32(((Label)grdbookdata.Rows[j].FindControl("Label1")).Text);
            obDepoBookDemand.SubjectID_I = Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("TitalID")).Value);
            try
            {
                obDepoBookDemand.DDemandID_I = Convert.ToInt32(HiddenField1.Value);
            }
            catch { }
            obDepoBookDemand.RequesrdQt_I = Convert.ToInt32(((TextBox)grdbookdata.Rows[j].FindControl("txtDemand")).Text);
            obDepoBookDemand.DepoID = Convert.ToInt32(Session["UserID"]);
            obDepoBookDemand.StockP = Convert.ToInt32(grdbookdata.Rows[j].Cells[3].Text);
            obDepoBookDemand.isSubmited = 0;
            obDepoBookDemand.ClassID_I = Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("hdnclassID")).Value);// Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("HiddenField3")).Value);
            obDepoBookDemand.DDemandDetailsID_I = 0;
            try
            {
                CommonFuction comm = new CommonFuction();
                comm.FillDatasetByProc("call DeleteMedsessionDemand (" + Convert.ToInt32(Session["UserID"]) + "," + Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("TitalID")).Value) + "," + HiddenField1.Value + ")");
            }
            catch { }
            if (HiddenField2.Value != "")
            {
                obDepoBookDemand.DDemandDetailsID_I = Convert.ToInt32(HiddenField2.Value);
            }
            obDepoBookDemand.InsertUpdateDemandDetails();

        }
        grdbookdata.DataSource = null;
        grdbookdata.DataBind();
        HiddenField2.Value = "";
        ddlMedium.SelectedIndex =0;
     //   ddlClass.SelectedIndex = 0;
        
        rdDemandType.SelectedIndex =0;
        rdBookType.SelectedIndex = 0; 
        fillgrd();
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        obDepoBookDemand = new DepoBookDemand();
        for (int j = 0; j < grdbookdata0.Rows.Count; j++)
        {
            obDepoBookDemand.DDemandDetailsID_I = Convert.ToInt32(((HiddenField)grdbookdata0.Rows[j].FindControl("HID")).Value);
            obDepoBookDemand.UpdateDemandDetails();
        }
        Response.Redirect("VIEW_DPT011.aspx");
    }
    public void fillgrd()
    {
        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.DDemandID_I = 0;
        obDepoBookDemand.DepoID = Convert.ToInt32(Session["UserID"]);
        obDepoBookDemand.UserID_I = Convert.ToInt32(Session["UserID"]);
        DataSet ds1 = obDepoBookDemand.Select();
        grdbookdata0.DataSource = ds1.Tables[0];
        grdbookdata0.DataBind();
        if (grdbookdata0.Rows.Count > 0)
        {
            Button12.Visible = true;
        }
    }
    protected void grdbookdata_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        foreach (ListItem chk in CheckBoxList1.Items)
        {
            if (chk.Selected == true)
            {
                if (count == 0)
                {
                    count = count + 1;
                    id = chk.Value;
                }
                else
                {
                    id = id + "," + chk.Value;
                }
            }
        }
        obDepoBookDemand = new DepoBookDemand();
        DataSet ds = obDepoBookDemand.fillBookData(Convert.ToString(id), Convert.ToInt32(ddlMedium.SelectedValue),Convert.ToInt16(rdBookType.SelectedValue), Convert.ToInt32(Session["UserID"]));
        grdbookdata.DataSource = ds.Tables[0];
        grdbookdata.DataBind();

    }
    protected void grdbookdata0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CommonFuction obCommon = new CommonFuction();
        obCommon.FillDatasetByProc("call USP_DPT014DeleteDemad("+Convert.ToInt32(grdbookdata0.DataKeys[e.RowIndex].Value)+")");
        fillgrd();
    }
    decimal Demand = 0;
    decimal Required = 0;
    protected void grdbookdata0_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblRequired = (Label)e.Row.Cells[3].FindControl("Label3");
            Required += lblRequired.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblRequired.Text);

            Label lblDemand = (Label)e.Row.Cells[3].FindControl("Label2");
            Demand += lblDemand.Text.Trim().Length == 0 ? 0 : Convert.ToDecimal(lblDemand.Text);

            //Label2

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Style.Add("background", "#f1f1f1");
            e.Row.Cells[0].Text = "Total";
            //e.Row.Cells[3].Text = total_PerBundle.ToString();
            e.Row.Cells[3].Text = Required.ToString();
            e.Row.Cells[4].Text = Demand.ToString();
        }
    }
}