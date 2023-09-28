using MPTBCBussinessLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Distribution_InterDepoDemand : System.Web.UI.Page
{
    CultureInfo cult = new CultureInfo("gu-IN", true);
    MediumMaster obMediumMaster = null;
    ClassMaster obClass = null;
    DepoBookDemand obDepoBookDemand = null;
    string id;
    int count;
    CommonFuction obCommonFuction = new CommonFuction();
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
           // fillgrd();
            txtDate.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            ddlDepo.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_DD_SelectMainBookDepot()");
            ddlDepo.DataValueField = "DepoTrno_I";
            ddlDepo.DataTextField = "DepoName_V";
            ddlDepo.DataBind();
            ddlDepo.Items.Insert(0, "Select");
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
        }
    }
    protected void grdbookdata_SelectedIndexChanged(object sender, EventArgs e)
    {

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.Date = Convert.ToDateTime(txtDate.Text, cult).ToString("yyyy-MM-dd");
        obDepoBookDemand.UserID_I = Convert.ToInt32(ddlDepo.SelectedValue);
        //DataSet dDate = obDepoBookDemand.CheckDate();
        //if (dDate.Tables[0].Rows.Count > 0)
        //{
        //    HiddenField1.Value = Convert.ToString(dDate.Tables[0].Rows[0]["DemandID_I"]);
        //    HiddenField4.Value = Convert.ToString(dDate.Tables[0].Rows[0]["ClassID_I"]);
        //}
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
                obDepoBookDemand.DepoID = Convert.ToInt32(ddlDepo.SelectedValue);
                obDepoBookDemand.TransactionDate_D = Convert.ToDateTime(System.DateTime.Now, cult);
                obDepoBookDemand.UserID_I = Convert.ToInt32(ddlDepo.SelectedValue );
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
            if (Convert.ToInt32(((TextBox)grdbookdata.Rows[j].FindControl("txtDemand")).Text) != 0)
            { 
            
           

            obDepoBookDemand.Demand_I = Convert.ToInt32(((TextBox)grdbookdata.Rows[j].FindControl("txtDemand")).Text);
            obDepoBookDemand.SubjectID_I = Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("TitalID")).Value);
            try
            {
                obDepoBookDemand.DDemandID_I = Convert.ToInt32(HiddenField1.Value);
            }
            catch { }
            obDepoBookDemand.RequesrdQt_I = Convert.ToInt32(((TextBox)grdbookdata.Rows[j].FindControl("txtDemand")).Text);
            obDepoBookDemand.DepoID = Convert.ToInt32(ddlDepo.SelectedValue);
            obDepoBookDemand.StockP = Convert.ToInt32(0);
            obDepoBookDemand.isSubmited = 0;
            obDepoBookDemand.ClassID_I = Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("hdnclassID")).Value);// Convert.ToInt32(((HiddenField)grdbookdata.Rows[j].FindControl("HiddenField3")).Value);
            obDepoBookDemand.DDemandDetailsID_I = 0;
            if (HiddenField2.Value != "")
            {
                obDepoBookDemand.DDemandDetailsID_I = Convert.ToInt32(HiddenField2.Value);
            }
            obDepoBookDemand.InsertUpdateDemandDetails();
            }
        }
        grdbookdata.DataSource = null;
        grdbookdata.DataBind();
        fillgrd(); HiddenField1.Value = "";
       
        Button12.Visible = true;
    }
    protected void grdbookdata0_SelectedIndexChanged(object sender, EventArgs e)
    {
        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.DDemandID_I = Convert.ToInt32(grdbookdata0.SelectedDataKey.Value.ToString());
        obDepoBookDemand.DepoID = Convert.ToInt32(ddlDepo.SelectedValue);
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
    public void fillgrd()
    {
        try { 
        obDepoBookDemand = new DepoBookDemand();
        obDepoBookDemand.DDemandID_I = 0;
        obDepoBookDemand.DepoID = Convert.ToInt32(ddlDepo.SelectedValue );
        obDepoBookDemand.UserID_I = Convert.ToInt32(ddlDepo.SelectedValue);
        DataSet ds1 = obDepoBookDemand.Select();
        grdbookdata0.DataSource = ds1.Tables[0];
        grdbookdata0.DataBind();
        }
        catch { }
    }
    protected void grdbookdata0_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        CommonFuction obCommon = new CommonFuction();
        obCommon.FillDatasetByProc("call USP_DPT014DeleteDemad(" + Convert.ToInt32(grdbookdata0.DataKeys[e.RowIndex].Value) + ")");
        fillgrd();
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
        DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT014FatchBookStockDetailsNew('" + Convert.ToString(id) + "'," + Convert.ToInt32(ddlMedium.SelectedValue) + "," + Convert.ToInt16(rdBookType.SelectedValue) + ", " + Convert.ToInt32(ddlDepo.SelectedValue) + ",'"+DdlACYear.SelectedItem.Text+"')");
            //obDepoBookDemand.fillBookData(, );
        grdbookdata.DataSource = ds.Tables[0];
        grdbookdata.DataBind();
        }
      
    protected void Button12_Click(object sender, EventArgs e)
    {
        obDepoBookDemand = new DepoBookDemand();
        for (int j = 0; j < grdbookdata0.Rows.Count; j++)
        {
            obDepoBookDemand.DDemandDetailsID_I = Convert.ToInt32(((HiddenField)grdbookdata0.Rows[j].FindControl("HID")).Value);
            obDepoBookDemand.UpdateDemandDetails();
        }
        grdbookdata0.DataSource = null;
        grdbookdata0.DataBind();
        Button12.Visible = false ;
        ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('Data Saved .');</script>");
    }
    protected void ddlDepo_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillgrd();
    }
    protected void DDLClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Classes = "";
        if (DDLClass.SelectedValue.ToString() == "1-8") Classes = "1,2,3,4,5,6,7,8";
        else if (DDLClass.SelectedValue.ToString() == "9-12") Classes = "9,10,11,12";
          obDepoBookDemand = new DepoBookDemand();
       // DataSet ds = obDepoBookDemand.fillBookData(Convert.ToString(Classes), Convert.ToInt32(ddlMedium.SelectedValue), Convert.ToInt16(rdBookType.SelectedValue), Convert.ToInt32(ddlDepo.SelectedValue ));
          DataSet ds = obCommonFuction.FillDatasetByProc("call USP_DPT014FatchBookStockDetailsNew('" + Convert.ToString(Classes) + "'," + Convert.ToInt32(ddlMedium.SelectedValue) + "," + Convert.ToInt16(rdBookType.SelectedValue) + ", " + Convert.ToInt32(ddlDepo.SelectedValue) + ",'" + DdlACYear.SelectedItem.Text + "')");
        grdbookdata.DataSource = ds.Tables[0];
        grdbookdata.DataBind();
    
    }
}