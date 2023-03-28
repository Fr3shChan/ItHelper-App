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


    
    public partial class adminUserManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {


            //LinkButton100.Text = "Witaj "+ dr["klient_status"].ToString();

            Button3.Enabled = false;
            Button4.Enabled = false;

            GridView3.DataBind();


        }

        protected void Button69_Click(object sender, EventArgs e)
        {
            Response.Redirect("homePage.aspx");
        }
        

        //Blokowanie użytkownika
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkIfUserExist())
            {
                blockUser();
                Response.Write("<script>('Użytkownik został zablokowany');</script>");
            }
            else
            {
                Response.Write("<script>alert('Użytkownik z takim loginem nie istnieje!');</script>");
            }
        }

        //Odblokuj użytkownika
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfUserExist())
            {
                unBlockUser();
                Response.Write("<script>('Użytkownik został odblokowany');</script>");
            }
            else
            {
                Response.Write("<script>alert('Użytkownik z takim loginem nie istnieje!');</script>");
            }
        }

        //Przycisk Szukaj
        protected void Button1_Click(object sender, EventArgs e)
        {


            using (SqlConnection con = new SqlConnection(strcon))
            using (SqlCommand command = new SqlCommand("select klient_status from klientTB WHERE login='" + TextBox1.Text.Trim()+"'", con))
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        Console.WriteLine(reader["klient_status"].ToString());

                        Debug.Write(TextBox1.Text + "  ");
                        Debug.WriteLine(reader["klient_status"]);
                        
                        if(reader["klient_status"].Equals("aktywny"))
                        {
                            Button3.Enabled = true;
                            Button4.Enabled = false;
                        }
                        else
                        {
                            Button3.Enabled = false;
                            Button4.Enabled = true;
                        }


                    }
                    
                }

                


            }
            //TODO zrobić tak by użytkownik zablokowany widział odblokuj a odblokowany zablokuj
        }


        void blockUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE klientTB SET klient_Status='Nieaktywny' WHERE login='" + TextBox1.Text.Trim() + "'", con);
                //cmd.Parameters.AddWithValue("@login", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>('Użytwkonik został usunięty pomyślnie');</script>");

                GridView3.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void unBlockUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand  cmd = new SqlCommand("UPDATE klientTB SET klient_Status='aktywny' WHERE login='" + TextBox1.Text.Trim() + "'", con);
               // cmd.Parameters.AddWithValue("@login", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();


                GridView3.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        //Sprawdzanie czy użytkownik istnieje:

        bool checkIfUserExist()   
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM klientTB WHERE login='" + TextBox1.Text.Trim() + "';", con);

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



        public void checkUserIsBlocked()
        {
            SqlConnection con = new SqlConnection(strcon);
            

            try
            {
                Response.Write("<script>alert(-----------------------------------------------);</script>");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT klient_status FROM klientTB WHERE login='" + TextBox1.Text.Trim() + "';", con);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                      string x =  reader["klient_status"].ToString();
                        
                    }
                }
                finally
                {
                    reader.Close();
                }
                con.Close();

                
            }
            catch (Exception ex)
            {

            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton100_Click(object sender, EventArgs e)
        {

        }
    }
}