using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItHelper
{
    public partial class adminLogin : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM adminTB WHERE login='" + TextBox1.Text.Trim() + "' AND hasło='" + TextBox2.Text.Trim() + "'", con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Zalogowano pomyślnie');</script>");

                        Session["login"] = dr.GetValue(1).ToString();
                        Session["role"] = "admin";
                    }

                    Response.Redirect("homePage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Podałeś złe dane logowania');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }

            //Response.Write("<script>alert('zalogowano pomyślnie');</script>");
        }
    }
}