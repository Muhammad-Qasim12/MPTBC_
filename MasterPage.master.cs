using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    DBAccess db = new DBAccess();

    MPTBCBussinessLayer.Admin.Login obLogin = new MPTBCBussinessLayer.Admin.Login();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["DepartName"] == null)
        {
            Session["DepartName"] = "Other";
        }
        if (!IsPostBack)
        {
            CreateMenu();
        }
    }
    public void CreateMenu()
    {
        try
        {
            //Response.Write("USERID = " +Session["UserID"]);
            if (Session["UserID"] != null && Session["UserName"] != null)
            {
                h6username.InnerHtml = Session["UserName"].ToString();
                if (Session["CoreModule"].ToString() == "Yes")
                {
                    rbcore.Visible = true;
                }
                else
                {
                    rbcore.Visible = false;
                }
                obLogin.UserID = int.Parse(Session["UserID"].ToString());
                string FullName = "";
                if (!string.IsNullOrEmpty(Convert.ToString(Session["FullName"])))
                    FullName = " [" + Session["FullName"].ToString() + "]";

                lblUserName.Text = Session["UserName"].ToString() + FullName;
                DataSet dsSubModule = obLogin.GetMenu();

                StringBuilder html = new StringBuilder();
                html.Append("<ul class='nav flex-column'>");
                if (dsSubModule.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSubModule.Tables[0].Rows.Count; i++)
                    {
                        string MainURL = "";
                        try
                        {
                            if (dsSubModule.Tables[0].Rows[i]["Path"].ToString() != "")
                            {
                                MainURL = dsSubModule.Tables[0].Rows[i]["Path"].ToString();
                            }
                        }
                        catch { }
                        string MainMenuName = dsSubModule.Tables[0].Rows[i]["SubModuleName_V"].ToString();
                        string MainID = dsSubModule.Tables[0].Rows[i]["SubModuleTrno_I"].ToString();
                        html.Append("<li class='nav-item'>");

                        if (dsSubModule.Tables[1].Rows.Count > 0)
                        {
                            DataTable dsForms = dsSubModule.Tables[1];
                            DataRow[] results_Menu = dsForms.Select("SubModuleTrno_I ='" + MainID + "'");

                            if (results_Menu.Length > 0)
                            {
                                html.Append("<a href='/" + MainURL + "' class='nav-link'>" + MainMenuName + "<i class='bi bi-arrow-right float-right'></i>" + "</a>");

                                html.Append("<ul class='submenu dropdown-menu'>");
                                for (int j = 0; j < results_Menu.Length; j++)
                                {
                                    string MenuName = results_Menu[j]["FormDesc_V"].ToString();
                                    string MenuID = results_Menu[j]["FormTrno_I"].ToString();
                                    string MenuURL = results_Menu[j]["FormPath_V"].ToString();

                                    html.Append("<li class='nav-item'>");

                                    if (dsSubModule.Tables[2].Rows.Count > 0)
                                    {
                                        DataTable dt_SubMenu = dsSubModule.Tables[2];
                                        DataRow[] results_SubMenu = dt_SubMenu.Select("MainFormTrno_I ='" + MenuID + "'");

                                        if (results_SubMenu.Length > 0)
                                        {
                                            html.Append("<a href='/" + MenuURL + "' class='nav-link'>" + MenuName + "<i class='bi bi-arrow-right float-right'></i>" + "</a>");
                                            html.Append("<ul class='submenu dropdown-menu'>");
                                            for (int k = 0; k < results_SubMenu.Length; k++)
                                            {
                                                //string SubMenuID = results_SubMenu[k]["FormTrno_I"].ToString();
                                                string SubMenuName = results_SubMenu[k]["FormDesc_V"].ToString();
                                                string SubMenuURL = results_SubMenu[k]["FormPath_V"].ToString();

                                                html.Append("<li class='nav-link'><a href='/" + SubMenuURL + "' class='nav-link'>" + SubMenuName + "</a></li>");
                                            }
                                            html.Append("</ul>");
                                        }
                                        else
                                            html.Append("<a href='/" + MenuURL + "' class='nav-link'>" + MenuName + "</a>");
                                    }
                                    else
                                    {
                                        html.Append("<a href='/" + MenuURL + "' class='nav-link'>" + MenuName + "</a>");
                                    }
                                    html.Append("</li>");
                                }
                                html.Append("</ul>");
                            }
                            else
                                html.Append("<a href='/" + MainURL + "' class='nav-link dropdown-toggle'>" + MainMenuName + "</a>");
                        }
                        else
                        {
                            html.Append("<a href='/" + MainURL + "' class='nav-link dropdown-toggle'>" + MainMenuName + "</a>");
                        }
                        html.Append("</li>");
                    }
                }

                html.Append("</ul>");
                menu_navbar.InnerHtml = html.ToString();
            }
            else
            {
                Response.Redirect("~/login.aspx");
            }
        }
        catch { }
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Abandon();

        Response.Redirect("~/login.aspx");
    }
    protected void rbcore_CheckedChanged(object sender, EventArgs e)
    {
        Response.Redirect("~/Pan.aspx");
    }

}
