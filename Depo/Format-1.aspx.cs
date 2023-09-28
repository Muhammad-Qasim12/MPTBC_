using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Depo_Format_1 : System.Web.UI.Page
{
    CommonFuction obCommonFuction = new CommonFuction();
    Dis_TentativeDemandHistory objTentativeDemandHistory;
    string classA;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();
            DdlACYear.SelectedValue = obCommonFuction.GetFinYear();
            objTentativeDemandHistory = new Dis_TentativeDemandHistory();
            DdlScheme.DataSource = objTentativeDemandHistory.MedumFill();
            DdlScheme.DataValueField = "MediumTrno_I";
            DdlScheme.DataTextField = "MediunNameHindi_V";
            DdlScheme.DataBind();

            DataSet dt = obCommonFuction.FillDatasetByProc("call USP_GetEmployeeDetails("+Session["UserID"]+")");
            ddlPEmp.DataSource = dt.Tables[1];
            ddlPEmp.DataValueField = "EmployeeId";
            ddlPEmp.DataTextField = "NAME";
            ddlPEmp.DataBind();

            ddlPEmp.Items.Insert(0, "Select");
            ddlstoreKee.DataSource = dt.Tables[0];
            ddlstoreKee.DataValueField = "EmployeeId";
            ddlstoreKee.DataTextField = "NAME";
            ddlstoreKee.DataBind();
            ddlstoreKee.Items.Insert(0, "Select");

            ddlDepoManager.DataSource = dt.Tables[2];
            ddlDepoManager.DataValueField = "EmployeeId";
            ddlDepoManager.DataTextField = "NAME";
            ddlDepoManager.DataBind();
            ddlDepoManager.Items.Insert(0, "Select");

            DdlACYear.DataSource = obCommonFuction.FillDatasetByProc("CALL USP_ADM015_AcadmicYearLoad(0)");
            DdlACYear.DataValueField = "AcYear";
            DdlACYear.DataTextField = "AcYear";
            DdlACYear.DataBind();

            if (Convert.ToString(Request.QueryString["Year"]) != null)
            {
                DataSet dtr = obCommonFuction.FillDatasetByProc("call USP_DataFormat1('" + Request.QueryString["Year"] + "'," + Request.QueryString["MediumIDa"] + ",'" + Request.QueryString["Classtra"] + "'," + Session["UserID"] + ")");
                ddlDepoManager.SelectedValue = dtr.Tables[0].Rows[0]["DepoManagerID"].ToString();
                ddlstoreKee.SelectedValue = dtr.Tables[0].Rows[0]["StoreKeeper"].ToString();
                ddlPEmp.SelectedValue = dtr.Tables[0].Rows[0]["PhyOfficerID"].ToString();
                DdlScheme.SelectedValue = Request.QueryString["MediumIDa"].ToString();
                DDLClass.SelectedValue = Request.QueryString["Classtra"].ToString();
                GridView1.DataSource = dtr.Tables[0];
                    GridView1.DataBind();
                    Button2.Visible = true;
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DDLClass.SelectedValue.ToString() == "1-8")
        {
            classA = "1,2,3,4,5,6,7,8";
        }
        else if (DDLClass.SelectedValue.ToString() == "9-12")
        {
            classA = "9,10,11,12";
        }
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call DPT_Format1('" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + ",'" + classA + "',"+Session["UserID"]+")");
        GridView1.DataBind();
        Button2.Visible = true;
    
    }
    protected void txt1_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt1 = (TextBox)grd.FindControl("txt1");
        TextBox txt3 = (TextBox)grd.FindControl("txt3");
        TextBox txt5 = (TextBox)grd.FindControl("txt5");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        txt7.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text));
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        txt9.Text = Convert.ToString(Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt8.Text));
    }
    protected void txt2_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        txt8.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text));
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        txt9.Text = Convert.ToString(Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt8.Text));
    }
    protected void txt3_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt1 = (TextBox)grd.FindControl("txt1");
        TextBox txt3 = (TextBox)grd.FindControl("txt3");
        TextBox txt5 = (TextBox)grd.FindControl("txt5");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        txt7.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text));
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        txt9.Text = Convert.ToString(Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt8.Text));
    }
    protected void txt4_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        txt8.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text));
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        txt9.Text = Convert.ToString(Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt8.Text));
    }
    protected void txt5_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt1 = (TextBox)grd.FindControl("txt1");
        TextBox txt3 = (TextBox)grd.FindControl("txt3");
        TextBox txt5 = (TextBox)grd.FindControl("txt5");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        txt7.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text));
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        txt9.Text = Convert.ToString(Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt8.Text));
    }
    protected void txt6_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        txt8.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text));
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        txt9.Text = Convert.ToString(Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt8.Text));

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string SubQuery="";
        
        obCommonFuction.FillDatasetByProc("call USP_PhysicalFormat1(-1,'" + DdlACYear.SelectedValue + "',"+DdlScheme.SelectedValue+",0,0,0,0,0,0,0,"+Session["userID"]+",'"+DDLClass.SelectedValue +"')");
      //  (IDa INT, Acyeara VARCHAR(50), MediumIDa INT, TitleIDa INT, OpenYojnaa INT, Opensamanya INT, PrinterYojnaa INT, PrinterSamanya INT, InterDepoYojnaa INT, InterDepoSamanya INT,DepoIDa INT)
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string txt1, txt2, txt3, txt4, txt5, txt6;
            txt1 = ((TextBox)GridView1.Rows[i].FindControl("txt1")).Text;
            if (txt1 == "")
            {
                txt1 = "0";
            }
            txt2 = ((TextBox)GridView1.Rows[i].FindControl("txt2")).Text;
            if (txt2 == "")
            {
                txt2 = "0";
            }
            txt3 = ((TextBox)GridView1.Rows[i].FindControl("txt3")).Text;
            if (txt3 == "")
            {
                txt3 = "0";
            }
            txt4 = ((TextBox)GridView1.Rows[i].FindControl("txt4")).Text;
            if (txt4 == "")
            {
                txt4 = "0";
            }

            txt5 = ((TextBox)GridView1.Rows[i].FindControl("txt5")).Text;
            if (txt5 == "")
            {
                txt5 = "0";
            }
            txt6 = ((TextBox)GridView1.Rows[i].FindControl("txt6")).Text;
            if (txt6 == "")
            {
                txt6 = "0";
            }



            if (SubQuery == "")
            {
                SubQuery = SubQuery + "('" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + "," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + txt1 + "," + txt2 + "," + txt3 + "," +txt4 + "," +txt5  + "," + txt6 + ","+Session["UserID"]+",'"+DDLClass.SelectedValue+"',"+ddlDepoManager.SelectedValue+","+ddlstoreKee.SelectedValue+","+ddlPEmp.SelectedValue+")";
            }
            else
            {
                SubQuery = SubQuery + ",('" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + "," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + txt1 + "," + txt2 + "," + txt3 + "," + txt4 + "," + txt5 + "," + txt6 + "," + Session["UserID"] + ",'" + DDLClass.SelectedValue + "'," + ddlDepoManager.SelectedValue + "," + ddlstoreKee.SelectedValue + "," + ddlPEmp.SelectedValue + ")";
            }
        }
         //obCommonFuction.FillDatasetByProc("call USP_PhysicalFormat1("+SubQuery+")");
        obCommonFuction.FillDatasetByProc("INSERT INTO DPT_PhysicalFormat1 (Acyear, MediumID, TitleID, OpenYojna, Opensamany, PrinterYojna, PrinterSamany, InterDepoYojna, InterDepoSamany,DepoID,ClassID,DepoManagerID,StoreKeeper,PhyOfficerID)VALUES " + SubQuery + "");
        GridView1.DataSource = null;
        GridView1.DataBind();
        Response.Redirect("ViewFormat1.aspx");
    }
}