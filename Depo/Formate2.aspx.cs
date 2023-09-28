using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MPTBCBussinessLayer;
using System.Data;
using System.Globalization;

public partial class Depo_Formate2 : System.Web.UI.Page
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
            DataSet dt = obCommonFuction.FillDatasetByProc("call USP_GetEmployeeDetails(" + Session["UserID"] + ")");
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
            if (Convert.ToString ( Request.QueryString["Year"])!= null)
            {
         DataSet dtra = obCommonFuction.FillDatasetByProc("CALL USP_Format2Update('" + Request.QueryString["Year"].ToString() + "'," + Session["UserID"] + "," + Request.QueryString["MediumIDa"] + ",'" + Request.QueryString["Classtra"].ToString() + "')");

        GridView1.DataSource = dtra.Tables[0];
        GridView1.DataBind();
        DDLClass.SelectedValue = Convert.ToString(Request.QueryString["Classtra"]);
        DdlACYear.SelectedValue = Convert.ToString(Request.QueryString["Year"]);
        DdlScheme.SelectedValue = Convert.ToString(Request.QueryString["MediumIDa"]);
        ddlDepoManager.SelectedValue = dtra.Tables[0].Rows[0]["DepoManagerID"].ToString();
        ddlstoreKee.SelectedValue = dtra.Tables[0].Rows[0]["StoreKeeper"].ToString();
        ddlPEmp.SelectedValue = dtra.Tables[0].Rows[0]["PhyOfficerID"].ToString();
            }
            //"call USP_Format2Update('"+Request.QueryString["Acyear"].ToString ()+"',"+Session["UserID"]+","+Request.QueryString["MediumIDa"]+",'"+Request.QueryString["Classtra"].ToString ()+"')")
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
        GridView1.DataSource = obCommonFuction.FillDatasetByProc("call USP_DptFormate2('" + DdlACYear.SelectedValue + "'," + Session["UserID"] + ",'" + classA + "'," + DdlScheme.SelectedValue + ")");
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
        TextBox txt8 = (TextBox)grd.FindControl("txt8");
        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt1.Text == "")
        {
            txt1.Text = "0";
        }
        if (txt3.Text == "")
        {
            txt3.Text = "0";
        }
        if (txt5.Text == "")
        {
            txt5.Text = "0";
        }
        if (txt8.Text == "")
        {
            txt8.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt10.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text) + Convert.ToInt32(txt11.Text));
    }
    protected void txt2_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt2.Text == "")
        {
            txt2.Text = "0";
        }
        if (txt4.Text == "")
        {
            txt4.Text = "0";
        }
        if (txt6.Text == "")
        {
            txt6.Text = "0";
        }
        if (txt7.Text == "")
        {
            txt7.Text = "0";
        }
        if (txt9.Text == "")
        {
            txt9.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt11.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt10.Text) + Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
       
    }
    protected void txt3_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt1 = (TextBox)grd.FindControl("txt1");
        TextBox txt3 = (TextBox)grd.FindControl("txt3");
        TextBox txt5 = (TextBox)grd.FindControl("txt5");
        TextBox txt8 = (TextBox)grd.FindControl("txt8");

        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt1.Text == "")
        {
            txt1.Text = "0";
        }
        if (txt3.Text == "")
        {
            txt3.Text = "0";
        }
        if (txt5.Text == "")
        {
            txt5.Text = "0";
        }
        if (txt8.Text == "")
        {
            txt8.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt10.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text) + Convert.ToInt32(txt11.Text));
    
    }
    protected void txt4_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt2.Text == "")
        {
            txt2.Text = "0";
        }
        if (txt4.Text == "")
        {
            txt4.Text = "0";
        }
        if (txt6.Text == "")
        {
            txt6.Text = "0";
        }
        if (txt7.Text == "")
        {
            txt7.Text = "0";
        }
        if (txt9.Text == "")
        {
            txt9.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt11.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt10.Text) + Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
       
    }
    protected void txt5_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt1 = (TextBox)grd.FindControl("txt1");
        TextBox txt3 = (TextBox)grd.FindControl("txt3");
        TextBox txt5 = (TextBox)grd.FindControl("txt5");
        TextBox txt8 = (TextBox)grd.FindControl("txt8");

        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt1.Text == "")
        {
            txt1.Text = "0";
        }
        if (txt3.Text == "")
        {
            txt3.Text = "0";
        }
        if (txt5.Text == "")
        {
            txt5.Text = "0";
        }
        if (txt8.Text == "")
        {
            txt8.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt10.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text) + Convert.ToInt32(txt11.Text));
    
    }
    protected void txt6_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt2.Text == "")
        {
            txt2.Text = "0";
        }
        if (txt4.Text == "")
        {
            txt4.Text = "0";
        }
        if (txt6.Text == "")
        {
            txt6.Text = "0";
        }
        if (txt7.Text == "")
        {
            txt7.Text = "0";
        }
        if (txt9.Text == "")
        {
            txt9.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt11.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt10.Text) + Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
       

    }
    protected void txt7_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt2.Text == "")
        {
            txt2.Text = "0";
        }
        if (txt4.Text == "")
        {
            txt4.Text = "0";
        }
        if (txt6.Text == "")
        {
            txt6.Text = "0";
        }
        if (txt7.Text == "")
        {
            txt7.Text = "0";
        }
        if (txt9.Text == "")
        {
            txt9.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt11.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt10.Text) + Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));


    }
    protected void txt9_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt2 = (TextBox)grd.FindControl("txt2");
        TextBox txt4 = (TextBox)grd.FindControl("txt4");
        TextBox txt6 = (TextBox)grd.FindControl("txt6");
        TextBox txt7 = (TextBox)grd.FindControl("txt7");
        TextBox txt9 = (TextBox)grd.FindControl("txt9");
        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt2.Text == "")
        {
            txt2.Text = "0";
        }
        if (txt4.Text == "")
        {
            txt4.Text = "0";
        }
        if (txt6.Text == "")
        {
            txt6.Text = "0";
        }
        if (txt7.Text == "")
        {
            txt7.Text = "0";
        }
        if (txt9.Text == "")
        {
            txt9.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt11.Text = Convert.ToString(Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt10.Text) + Convert.ToInt32(txt2.Text) + Convert.ToInt32(txt4.Text) + Convert.ToInt32(txt6.Text) + Convert.ToInt32(txt7.Text) + Convert.ToInt32(txt9.Text));


    }
    protected void txt8_TextChanged(object sender, EventArgs e)
    {
        TextBox txtbox = (TextBox)sender;
        GridViewRow grd = (GridViewRow)(txtbox.NamingContainer);
        TextBox txt1 = (TextBox)grd.FindControl("txt1");
        TextBox txt3 = (TextBox)grd.FindControl("txt3");
        TextBox txt5 = (TextBox)grd.FindControl("txt5");
        TextBox txt8 = (TextBox)grd.FindControl("txt8");

        TextBox txt10 = (TextBox)grd.FindControl("txt10");
        TextBox txt11 = (TextBox)grd.FindControl("txt11");
        TextBox txt12 = (TextBox)grd.FindControl("txt12");
        if (txt1.Text == "")
        {
            txt1.Text = "0";
        }
        if (txt3.Text == "")
        {
            txt3.Text = "0";
        }
        if (txt5.Text == "")
        {
            txt5.Text = "0";
        }
        if (txt8.Text == "")
        {
            txt8.Text = "0";
        }
        if (txt10.Text == "")
        {
            txt10.Text = "0";
        }
        if (txt11.Text == "")
        {
            txt11.Text = "0";
        }
        if (txt12.Text == "")
        {
            txt12.Text = "0";
        }
        txt10.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text));
        txt12.Text = Convert.ToString(Convert.ToInt32(txt1.Text) + Convert.ToInt32(txt3.Text) + Convert.ToInt32(txt5.Text) + Convert.ToInt32(txt8.Text) + Convert.ToInt32(txt11.Text));
    
    }

    

    protected void Button2_Click(object sender, EventArgs e)
    {
        string SubQuery="";
        //id, avantan, pradayYojna, pradaySamany, extrAvantan, ExtraYojna, ExtraSamany, EnterDepoYojna, EnterDepoSamany, OpenMarket, OtherYojan, OtherSamany, Fyear, MediumID, Classtr, TitleID, DepoID
        obCommonFuction.FillDatasetByProc("delete from dpt_format2 where DepoID=" + Session["UserID"] + " and Fyear='" + DdlACYear.SelectedValue + "' and MediumID=" + DdlScheme.SelectedValue + " and Classtr='"+DDLClass.SelectedValue+"'");
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9,  txtAvantan, TXTAtrikct;
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
            txt7 = ((TextBox)GridView1.Rows[i].FindControl("txt7")).Text;
            if (txt7 == "")
            {
                txt7 = "0";
            }
            txt8 = ((TextBox)GridView1.Rows[i].FindControl("txt8")).Text;
            if (txt8 == "")
            {
                txt8 = "0";
            }
             txt9 = ((TextBox)GridView1.Rows[i].FindControl("txt9")).Text;
            if (txt9 == "")
            {
                txt9 = "0";
            }

            TXTAtrikct = ((TextBox)GridView1.Rows[i].FindControl("TXTAtrikct")).Text;
            if (TXTAtrikct == "")
            {
                TXTAtrikct = "0";
            }

            txtAvantan = ((TextBox)GridView1.Rows[i].FindControl("txtAvantan")).Text;
            if (txtAvantan == "")
            {
                txtAvantan = "0";
            }
           
            if (SubQuery == "")
            {
                SubQuery = SubQuery + "('" + txtAvantan + "'," + txt1 + "," + txt2 + "," + TXTAtrikct + ",'" + txt3 + "'," + txt4 + "," + txt5 + "," + txt6 + "," + txt7 + "," + txt8 + "," + txt9 + ",'" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + ",'" + DDLClass.SelectedValue + "'," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + Session["USerID"] + "," + ddlDepoManager.SelectedValue + "," + ddlstoreKee.SelectedValue + "," + ddlPEmp.SelectedValue + ")";
            }
            else
            {
                SubQuery = SubQuery + ",('" + txtAvantan + "'," + txt1 + "," + txt2 + "," + TXTAtrikct + ",'" + txt3 + "'," + txt4 + "," + txt5 + "," + txt6 + "," + txt7 + "," + txt8 + "," + txt9 + ",'" + DdlACYear.SelectedValue + "'," + DdlScheme.SelectedValue + ",'" + DDLClass.SelectedValue + "'," + ((HiddenField)GridView1.Rows[i].FindControl("HiddenField1")).Value + "," + Session["USerID"] + "," + ddlDepoManager.SelectedValue + "," + ddlstoreKee.SelectedValue + "," + ddlPEmp.SelectedValue + ")";
            }
        }
        obCommonFuction.FillDatasetByProc("insert into dpt_format2(avantan, pradayYojna, pradaySamany, extrAvantan, ExtraYojna, ExtraSamany, EnterDepoYojna, EnterDepoSamany, OpenMarket, OtherYojan, OtherSamany, Fyear, MediumID, Classtr, TitleID, DepoID,DepoManagerID,StoreKeeper,PhyOfficerID)values " + SubQuery + "");

        GridView1.DataSource = null;
        GridView1.DataBind();
        Response.Redirect("ViewFrommat2.aspx");
    }
}