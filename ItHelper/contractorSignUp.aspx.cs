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
    public partial class contractorSignUp : System.Web.UI.Page
    {


        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIsContractorLoginExist())
            {

                Response.Write("<script>alert('Taki Wykonawca już istnieje');</script>");
            }
            else
            {
                signUpContractor();
            }
        }



        bool checkIsContractorLoginExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM wykonawcaTB WHERE login='" + TextBox4.Text.Trim()+"';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }


        void signUpContractor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO wykonawcaTB (imię_nazwa, NIP, Nr_tel, adres, kod_pocztowy, miasto, login, hasło, wykonawca_status) VALUES (@imię_nazwa, @NIP, @Nr_tel, @adres, @kod_pocztowy, @miasto, @login, @hasło, @wykonawca_status)", con);

                cmd.Parameters.AddWithValue("@imię_nazwa", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@NIP", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Nr_tel", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@adres", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@kod_pocztowy", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@miasto", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@login", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@hasło", TextBox8.Text.Trim());

                cmd.Parameters.AddWithValue("@wykonawca_status", "Nieaktywny");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Zarejestrowano pomyślnie');</script>");

                Response.Redirect("homePage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}