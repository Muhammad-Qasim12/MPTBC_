using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Class1
/// </summary>

    public class Class1
    {
        public SqlConnection con = new SqlConnection();
        public DataSet ds = new DataSet();
        public SqlDataAdapter ada = new SqlDataAdapter();
        public string sql;
        public string conn;
        public SqlCommand cmd;
        public string strrtn;
        public SqlDataReader dr;
        public ListItem l = new ListItem();
        public Class1()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public void connectdb()
        {
            //con = New SqlConnection();
          //  conn = ConfigurationManager.ConnectionStrings["con"].ToString();
           // conn = "Data Source=66.135.39.88;Initial Catalog=shopingcraft;UID=waves1;PWD=w7270";
         // conn="provider=SQLOLEDB;database=employeeAttendance;uid=sa;password=server;server=mphb01\SQLEXPRESS";
            //conn = "Data Source=mphb01/SQLEXPRESS;Initial Catalog=employeeAttendance;UID=sa;PWD=server";
            conn = "Data Source=MPHB01;Initial Catalog=usmis;UID=sa;PWD=server";
            if (con.State == ConnectionState.Open && con.State == ConnectionState.Connecting)
            {

            }
            else if (con.State == ConnectionState.Closed)
            {
                con.ConnectionString = conn;
                con.Open();
            }
            else if (con.State == ConnectionState.Broken)
            {
                con.Close();
                con.ConnectionString = conn;
                con.Open();
            }
        }
        public void fillyear(DropDownList cbo)
        {
            //Listitem i;
            for (int i = 1995; i <= 2015; i++)
            {
                cbo.Items.Add(i.ToString());
            }
        }
        public void insertdata(string sql, GridView GridView1, SqlDataSource SqlDataSource1, string sqldata)
        {
            if (con.State == ConnectionState.Closed)
            {
                conn = ConfigurationManager.ConnectionStrings["con"].ToString();
                con.ConnectionString = conn;
                con.Open();
            }
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            GridView1.Dispose();
            SqlDataSource1.SelectCommand = sqldata;
            GridView1.DataBind();
        }
        public void readdata(string sql)
        {
            if (con.State == ConnectionState.Closed)
            {
                conn = ConfigurationManager.ConnectionStrings["con"].ToString();
                con.ConnectionString = conn;
                con.Open();
            }
            
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            //dr.Close();
        }
        public void fillcombo(DropDownList cbo, string sql, string dm, string vm)
        {
            if (con.State == ConnectionState.Closed)
            {
                conn = ConfigurationManager.ConnectionStrings["con"].ToString();
                con.ConnectionString = conn;
                con.Open();
            }
            //ada = new SqlDataAdapter(sql, con);
            //cbo.Items.Clear();
            //ada.Fill(ds);
            //cbo.DataSource = ds;

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    cbo.DataTextField = dm;
            //    cbo.DataValueField = vm;
            //}
            cmd = new SqlCommand(sql, con);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                cbo.DataSource = dr;
                cbo.DataTextField = dm;
                cbo.DataValueField = vm;
                cbo.DataBind();
                dr.Close();
            }
            con.Close();
        }
        public void Proce(string sql)
        {
            try
            {
                connectdb();
                cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            catch (Exception e)
            {
                strrtn = e.ToString();
            }
        }
        public void FillMonthNames(DropDownList ddl)
        {
            int i;
            for (i = 0; i <= 11; i++)
            {
                l = new ListItem();
                switch (i)
                {
                    case 0:
                        l.Text = "JANUARY";
                        l.Value = Convert.ToString(1);
                        break;
                    case 1:
                        l.Text = "FEBRUARY";
                        l.Value = Convert.ToString(2);
                        break;
                    case 2:
                        l.Text = "MARCH";
                        l.Value = Convert.ToString(3);
                        break;
                    case 3:
                        l.Text = "APRIL";
                        l.Value = Convert.ToString(4);
                        break;
                    case 4:
                        l.Text = "MAY";
                        l.Value = Convert.ToString(5);
                        break;
                    case 5:
                        l.Text = "JUNE";
                        l.Value = Convert.ToString(6);
                        break;
                    case 6:
                        l.Text = "JULY";
                        l.Value = Convert.ToString(7);
                        break;
                    case 7:
                        l.Text = "AUGUST";
                        l.Value = Convert.ToString(8);
                        break;
                    case 8:
                        l.Text = "SEPTEMBER";
                        l.Value = Convert.ToString(9);
                        break;
                    case 9:
                        l.Text = "OCTOBER";
                        l.Value = Convert.ToString(10);
                        break;
                    case 10:
                        l.Text = "NOVEMBER";
                        l.Value = Convert.ToString(11);
                        break;
                    case 11:
                        l.Text = "DECEMBER";
                        l.Value = Convert.ToString(12);
                        break;
                }
                ddl.Items.Add(l);
            }
        }
public void FillSixMonthNames(DropDownList ddl)
    {
        int i;
        for (i = 0; i <= 6; i++)
        {
            l = new ListItem();
            switch (i)
            {


                case 0:
                    l.Text = "APRIL";
                    l.Value = Convert.ToString(4);
                    break;
                case 1:
                    l.Text = "MAY";
                    l.Value = Convert.ToString(5);
                    break;
                case 2:
                    l.Text = "JUNE";
                    l.Value = Convert.ToString(6);
                    break;
                case 3:
                    l.Text = "JULY";
                    l.Value = Convert.ToString(7);
                    break;
                case 4:
                    l.Text = "AUGUST";
                    l.Value = Convert.ToString(8);
                    break;
                case 5:
                    l.Text = "SEPTEMBER";
                    l.Value = Convert.ToString(9);
                    break;
            }
            ddl.Items.Add(l);
        }
    }
    public void Export(string fileName, GridView gv, string cap)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a form to contain the grid
                Table table = new Table();
                table.Caption = cap;
                table.BorderWidth = 1;
                table.BorderColor = System.Drawing.Color.Black;

                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    Class1.PrepareControlForExport(gv.HeaderRow);
                    table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {
                    row.BorderWidth = 1;
                    row.BorderColor = System.Drawing.Color.Black;
                   
                    Class1.PrepareControlForExport(row);
                   

                    table.Rows.Add(row);
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    Class1.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// Replace any of the contained controls with literals
    /// </summary>
    /// <param name="control"></param>
    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }

            if (current.HasControls())
            {
                Class1.PrepareControlForExport(current);
            }
        }
    }
}
