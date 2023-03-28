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


//TODO


//Podpisać metody pod przyciski



namespace ItHelper
{
    public partial class adminContractorManagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Button3.Enabled = false;
            Button4.Enabled = false;

            GridView10.DataBind();
        }


        //Zablokuj
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfUserExist())
            {
                blockUser();
                Response.Write("<script>('Wykonawca został zablokowany');</script>");
            }
            else
            {
                Response.Write("<script>alert('Wykonawca z takim loginem nie istnieje!');</script>");
            }
        }


        //Odblokuj
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfUserExist())
            {
                unBlockUser();
                Response.Write("<script>('Wykonawca został odblokowany');</script>");
            }
            else
            {
                Response.Write("<script>alert('Wykonawca z takim loginem nie istnieje!');</script>");
            }
        }

        //Powrót na stronę główną
        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("homePage.aspx");
        //}


        //Przycisk szukaj
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            using (SqlCommand command = new SqlCommand("select wykonawca_Status from wykonawcaTB WHERE login='" + TextBox1.Text.Trim() + "'", con))
            {
                con.Open();
                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["wykonawca_Status"].ToString());

                        Debug.Write(TextBox1.Text + " ");
                        Debug.WriteLine(reader["wykonawca_Status"]);

                        if (reader["wykonawca_status"].Equals("aktywny"))
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

        }




        bool checkIfUserExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM wykonawcaTB WHERE login='" + TextBox1.Text.Trim() + "';", con);

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


        void blockUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE wykonawcaTB SET wykonawca_Status='Nieaktywny' WHERE login='" + TextBox1.Text.Trim() + "'", con);
                //cmd.Parameters.AddWithValue("@login", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>('Wykonawca został usunięty pomyślnie');</script>");

                GridView10.DataBind();
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

                SqlCommand cmd = new SqlCommand("UPDATE wykonawcaTB SET wykonawca_Status='aktywny' WHERE login='" + TextBox1.Text.Trim() + "'", con);
                // cmd.Parameters.AddWithValue("@login", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();


                GridView10.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }






        public void checkUserIsBlocked()
        {
            SqlConnection con = new SqlConnection(strcon);


            try
            {
                Response.Write("<script>alert(-----------------------------------------------);</script>");
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT wykonawca_Status FROM wykonawcaTB WHERE login='" + TextBox1.Text.Trim() + "';", con);
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        string x = reader["wykonawca_Status"].ToString();

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
    }
}