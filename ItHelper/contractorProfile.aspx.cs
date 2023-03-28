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
    public partial class contractorProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["login"] == null)
                {
                    Response.Write("<script>alert('Sesja logowania wygasła, zaloguj się ponownie');</script>");
                    Response.Redirect("contractorLogin.aspx");
                }
                else
                {
                    getUserList();

                    if (!Page.IsPostBack)
                    {
                        getContractorPersonalData();
                        
                    }
                }
            }
            catch (Exception ex)
            {

            }

            Button4.Enabled = false;

        }


        void getUserList()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE login_wyk='" + Session["login"].ToString() + "'", con);
                SqlCommand cmd = new SqlCommand("SELECT ID_zlecenia, login_kli, kategoria, tytuł, opis, budżet, login_wyk, status_zlec, ocena, Nrtel, nazwa_wyk, imię, nazwisko " +
                    " FROM zleceniaTB, klientTB WHERE login = login_kli AND login_wyk='" + Session["login"].ToString() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //przeglądaj zlecenia
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("contractorListCommisions.aspx");
        }



        // Metoda zwracająca dane zalogowanego wykonawcy
        void getContractorPersonalData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM wykonawcaTB WHERE login='" + Session["login"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["imię_nazwa"].ToString();
                TextBox9.Text = dt.Rows[0]["NIP"].ToString();
                TextBox20.Text = dt.Rows[0]["Nr_tel"].ToString();
                TextBox5.Text = dt.Rows[0]["adres"].ToString();
                TextBox6.Text = dt.Rows[0]["kod_pocztowy"].ToString();
                TextBox22.Text = dt.Rows[0]["miasto"].ToString();

                TextBox4.Text = dt.Rows[0]["login"].ToString();
                TextBox8.Text = dt.Rows[0]["hasło"].ToString();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        // Metoda updatująca dane w profilu wykonawcy

        void updatePersonalContractorData()
        {
            string password = "";
            if (TextBox7.Text.Trim() == "")
            {
                password = TextBox8.Text.Trim();
            }
            else
            {
                password = TextBox7.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }


                SqlCommand cmd = new SqlCommand("UPDATE wykonawcaTB SET imię_nazwa = @imię_nazwa, NIP = @NIP, Nr_tel = @Nr_tel, adres = @adres, kod_pocztowy = @kod_pocztowy, miasto = @miasto, login = @login, hasło = @hasło WHERE login='" + Session["login"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@imię_nazwa", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@NIP", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@Nr_tel", TextBox20.Text.Trim());
                cmd.Parameters.AddWithValue("@adres", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@kod_pocztowy", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@miasto", TextBox22.Text.Trim());
                cmd.Parameters.AddWithValue("@login", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@hasło", password);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Twoje dane zostały zaaktualizowane pomyślnie');</script>");

                    getContractorPersonalData();
                }
                else
                {
                    Response.Write("<script>alert('Błąd');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }


        // Przycisk zmień Dane
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["login"].ToString() == "" || Session["login"] == null)
            {
                Response.Write("<script>alert('Sesja logowania wygasła, zaloguj się ponownie');</script>");
                Response.Redirect("contractorLogin.aspx");
            }
            else
            {
                updatePersonalContractorData();
            }
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        // Podaj ID
        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        // Idź do
        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            using (SqlCommand command = new SqlCommand("select status_zlec from zleceniaTB WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "'", con))
            {
                con.Open();
                using (SqlDataReader read = command.ExecuteReader())
                {
                    while (read.Read())
                    {
                        if (read["status_zlec"].Equals("nieaktywny"))
                        {
                            Button4.Enabled = false;


                        }
                        if (read["status_zlec"].Equals("aktywny"))
                        {
                            Button4.Enabled = false;


                        }
                        if (read["status_zlec"].Equals("zakończone"))
                        {
                            Button4.Enabled = false;


                        }
                        if (read["status_zlec"].Equals("wybrane"))
                        {
                            Button4.Enabled = true;


                        }
                        if (read["status_zlec"].Equals("zrealizowane"))
                        {
                            Button4.Enabled = false;


                        }
                    }
                    
                }
            }
        }


        bool checkIfCommissionExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "';", con);

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


        void commissionRealize()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE zleceniaTB SET status_zlec='zrealizowane' WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>('Zlecenie zostało zrealizowane pomyślnie');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        // Zrealizuj
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfCommissionExist())
            {
                commissionRealize();
                Response.Write("<script>alert('Pomyślnie zrealizowano zlecenie');</script>");
                Response.Redirect("contractorProfile.aspx");
            }
            else
            {
                Response.Write("<script>('Nie ma zlecenia o takim ID');</script>");
            }
        }




    }
}