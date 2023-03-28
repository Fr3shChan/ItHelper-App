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
    public partial class userProfile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["login"] == null)
                {
                    Response.Write("<script>alert('Sesja logowania wygasła, zaloguj się ponownie');</script>");
                    Response.Redirect("userLogin.aspx");
                }
                else
                {
                    getUserLogin();

                    if (!Page.IsPostBack)
                    {
                        getUserPersonalData();
                    }

                }
            }
            catch (Exception ex)
            {

            }


            Button30.Enabled = false;
            Button40.Enabled = false;
            Button3.Enabled = false;

            GridView1.DataBind();

        }

        //Dodaj Zlecenie
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("addUsersCommisions.aspx");
        }


        // Zmien dane
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["login"].ToString() == "" || Session["login"] == null)
            {
                Response.Write("<script>alert('Sesja logowania wygasła, zaloguj się ponownie');</script>");
                Response.Redirect("userLogin.aspx");
            }
            else
            {
                updatePersonalData();
            }
        }


        

        //Metoda wypisująca zlecenia użytkownika - GOTOWA
        void getUserLogin()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State ==  ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE login_kli='" + Session["login"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        //Metoda zwracająca dane zalogowanego usera
        void getUserPersonalData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM klientTB WHERE login='" + Session["login"].ToString() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                TextBox1.Text = dt.Rows[0]["imię"].ToString();
                TextBox2.Text = dt.Rows[0]["nazwisko"].ToString();
                TextBox3.Text = dt.Rows[0]["dataur"].ToString();
                TextBox9.Text = dt.Rows[0]["miasto"].ToString();
                TextBox5.Text = dt.Rows[0]["adres"].ToString();
                TextBox6.Text = dt.Rows[0]["kod_pocztowy"].ToString();
                TextBox10.Text = dt.Rows[0]["Nr_tel"].ToString();
                TextBox4.Text = dt.Rows[0]["login"].ToString();

                TextBox8.Text = dt.Rows[0]["hasło"].ToString();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void updatePersonalData()
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

                SqlCommand cmd = new SqlCommand("UPDATE klientTB SET imię=@imię, nazwisko=@nazwisko, dataur=@dataur, Nr_tel=@Nr_tel, adres=@adres, kod_pocztowy=@kod_pocztowy, miasto=@miasto, hasło=@hasło WHERE login='" + Session["login"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@imię", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@nazwisko", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@dataur", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@Nr_tel", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@adres", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@kod_pocztowy", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@miasto", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@hasło", password);

                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script>alert('Twoje dane zostały zaaktualizowane pomyślnie');</script>");

                    getUserPersonalData();
                    getUserLogin();
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


        // Przycisk szukaj
        protected void Button10_Click(object sender, EventArgs e)
        {
            //using (SqlConnection conne = new SqlConnection(strcon))
            //using (SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "' AND login_kli='" + Session["login"].ToString() + "';", conne))
            //using (SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE ID_zlecenia=2 AND login_kli='" + Session["login"].ToString() + "';", conne))



            using (SqlConnection con = new SqlConnection(strcon))
            using (SqlCommand command = new SqlCommand("select status_zlec from zleceniaTB WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "'", con))
            //using (SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE ID_zlecenia=2 AND login_kli='" + Session["login"].ToString() + "';", con))


            {
                



                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        
                        Console.WriteLine(reader["status_zlec"].ToString());

                        Debug.Write(TextBox12.Text + "  ");
                        Debug.WriteLine(reader["status_zlec"]);

                        if (reader["status_zlec"].Equals("nieaktywny"))
                        {
                            Button30.Enabled = false;
                            Button40.Enabled = true;
                            Button3.Enabled = false;
                        }
                        if (reader["status_zlec"].Equals("aktywny"))
                        {
                            Button30.Enabled = false;
                            Button40.Enabled = false;
                            Button3.Enabled = false;
                        }
                        if (reader["status_zlec"].Equals("zakończone"))
                        {
                            Button30.Enabled = false;
                            Button40.Enabled = false;
                            Button3.Enabled = true;
                        }
                        if (reader["status_zlec"].Equals("wybrane"))
                        {
                            Button30.Enabled = false;
                            Button40.Enabled = false;
                            Button3.Enabled = false;
                        }
                        if (reader["status_zlec"].Equals("zrealizowane"))
                        {
                            Button30.Enabled = true;
                            Button40.Enabled = false;
                            Button3.Enabled = false;
                        }




                    }

                }

                



            }
        }


        // Zakończ zlecenie
        protected void Button30_Click(object sender, EventArgs e)
        {
            if(checkIfCommissionExist())
            {
                endUsersCommission();
                Response.Redirect("userProfile.aspx");
            }
            else
            {
                Response.Write("<script>('Nie ma zlecenia o takim ID');</script>");
            }
            
           
        }


        // Aktywuj Zlecenie
        protected void Button40_Click(object sender, EventArgs e)
        {
            if (checkIfCommissionExist())
            {
                activateUsersCommission();
                Response.Write("<script>('Aktywowano zlecenie');</script>");
                Response.Redirect("userProfile.aspx");
            }
            else
            {
                Response.Write("<script>('Nie ma zlecenia o takim ID');</script>");
            }
        }



        void activateUsersCommission()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE zleceniaTB SET status_zlec='aktywny' WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "';", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>('Zlecenie zostało aktywowane pomyślnie');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void endUsersCommission()
        {
            try
            {
                 SqlConnection con = new SqlConnection(strcon);
                 if (con.State == ConnectionState.Closed)
                 {
                     con.Open();
                 }
                 SqlCommand cmd = new SqlCommand("UPDATE zleceniaTB SET status_zlec='zakończone' WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "';", con);
                 
            
                  cmd.ExecuteNonQuery();
                 con.Close();
                 Response.Write("<script>('Zlecenie zostało zakończone pomyślnie');</script>");
                 GridView1.DataBind();
             }
             catch (Exception ex)
            {
                 Response.Write("<script>alert('" + ex.Message + "');</script>");
             }


            
        }

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                //SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE ID_zlecenia=1;", con);

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



        public void checkCommissionIsEnded()
        {
            SqlConnection con = new SqlConnection(strcon);


            try
            {
                Response.Write("<script>alert(-----------------------------------------------);</script>");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT status_zlec FROM zleceniaTB WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "';", con);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string x = reader["status_zlec"].ToString();

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


        void test()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT zleceniaTB SET status_zlec='aktywny' WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "'", con);
                //cmd.Parameters.AddWithValue("@login", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>('Zlecenie zostało aktywowane pomyślnie');</script>");

                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        void opinionAboutContractor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE login_kli='" + Session["login"].ToString() + "';", con);
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


        // DODAJ OPINIĘ
        protected void Button3_Click(object sender, EventArgs e)
        {
            addUserOpinion();
            GridView1.DataBind();
        }


        //OPINIA
        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }



        void addUserOpinion()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //TODO Numer i ocena

                


                SqlCommand cmd = new SqlCommand("UPDATE zleceniaTB SET ocena=@ocena WHERE status_zlec='zakończone' AND ID_zlecenia='" + TextBox12.Text.Trim() + "'", con);
                cmd.Parameters.AddWithValue("@ocena", TextBox11.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Pomyślnie dodano Opinię');</script>");
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }
    }
}