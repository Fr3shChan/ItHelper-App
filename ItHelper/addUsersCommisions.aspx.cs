using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace ItHelper
{
    public partial class addUsersCommisions : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // Wybór kategorii 
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Tytuł zlecenia
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Opis zlecenia
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Budżet zlecenia
        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // Przycisk zatwierdź
        protected void Button1_Click(object sender, EventArgs e)
        {
            addCommision();
            Response.Write("<script>alert('Pomyślnie dodano zlecenie');</script>");
            Response.Redirect("userProfile.aspx");
        }

        //Przycisk anuluj
        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Write("<script>alert('Anulowano dodanie zlecenia');</script>");
            Response.Redirect("userProfile.aspx");

        }


        // Metoda dodająca zlecenie do bazy zlecen

        void addCommision()
        {
            //getUserPhoneNumber();


            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //TODO Numer i ocena

                string x = Session["login"].ToString();

                SqlCommand cmd = new SqlCommand("INSERT INTO zleceniaTB (login_kli, kategoria, tytuł, opis, budżet, login_wyk, status_zlec, ocena, Nrtel) VALUES (@login_kli, @kategoria, @tytuł, @opis, @budżet, @login_wyk, @status_zlec, @ocena, @Nrtel)", con);

                SqlCommand cmd2 = new SqlCommand("SELECT Nr_tel FROM klientTB WHERE login = '" + Session["login"].ToString() + "'", con);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read())
                {

                    string xy = reader["Nr_tel"].ToString();
                    Debug.WriteLine(reader["Nr_Tel"]);
                    cmd.Parameters.AddWithValue("@Nrtel", xy);
                    
                }
                reader.Close();

                    cmd.Parameters.AddWithValue("@login_kli", x);   //<==>  Tutaj ma przechwytywać login z bazy klientTB
                    cmd.Parameters.AddWithValue("@kategoria", DropDownList1.Text.Trim());
                    cmd.Parameters.AddWithValue("@tytuł", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@opis", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@budżet", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@login_wyk", "");


                    cmd.Parameters.AddWithValue("@status_zlec", "nieaktywny");

                    cmd.Parameters.AddWithValue("@ocena", "");

                    cmd.ExecuteNonQuery();
                con.Close();

                DropDownList1.Text = "";
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }

    }
}

        




  
