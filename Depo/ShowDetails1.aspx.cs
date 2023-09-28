using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class Depo_ShowDetails1 : System.Web.UI.Page
{
    CommonFuction comm = new CommonFuction();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dd = comm.FillDatasetByProc("call USP_DPTUpdateScheamChallanDate(" + Request.QueryString["ID"].ToString() + ")");
            GridView1.DataSource = dd.Tables[0];
            GridView1.DataBind();
        }

    }
}