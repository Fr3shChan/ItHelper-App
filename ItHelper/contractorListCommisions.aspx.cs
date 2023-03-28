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
    public partial class contractorListCommisions : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            getUserList();

            Button30.Enabled = false;
            Button40.Enabled = false;

            GridView1.DataBind();
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE status_zlec='aktywny'", con);
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


        //Powrót do profilu
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("contractorProfile.aspx");
        }


        // Przycisk szukaj
        protected void Button10_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(strcon))
            using (SqlCommand command = new SqlCommand("select * from zleceniaTB WHERE status_zlec ='aktywny' AND ID_zlecenia='" + TextBox12.Text.Trim() + "'", con))
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["status_zlec"].ToString());

                        Debug.Write(TextBox12.Text + "  ");
                        Debug.WriteLine(reader["status_zlec"]);

                        if (reader["status_zlec"].Equals("wybrane")) 
                        {
                            Button30.Enabled = false;
                            Button40.Enabled = true;
                        }
                        if (reader["status_zlec"].Equals("zrealizowane"))
                        {
                            Button30.Enabled = false;
                            Button40.Enabled = false;
                        }
                        if (reader["status_zlec"].Equals("aktywny"))
                        {
                            Button30.Enabled = true;
                            Button40.Enabled = false;
                        }


                    }
                }
            }
        }



        void chooseCommission()
        {
            try
            {
                
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE zleceniaTB SET status_zlec='wybrane', login_wyk='" + Session["login"].ToString() + "'  WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "'", con);
                //SqlCommand cmd3 = new SqlCommand("INSERT INTO zleceniaTB (nazwa_wyk) VALUES (@nazwa_wyk)", con);

               // cmd3.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                
                con.Close();
                Response.Write("<script>('Zlecenie zostało rozpoczęte');</script>");

                GridView1.DataBind();


            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }



        void endCommission()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE zleceniaTB set status_zlec='zrealizowane', login_wyk='" + Session["login"].ToString() + "' WHERE ID_zlecenia='" + TextBox12.Text.Trim() + "'", con);

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



        bool checkifCommissionExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == ConnectionState.Closed)
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


        // Przycisk wybierz
        protected void Button30_Click(object sender, EventArgs e)
        {
            if (checkifCommissionExist())
            {
                chooseCommission();
                
                Response.Write("<script>('Wybrano zlecenie');</script>");
                Response.Redirect("contractorProfile.aspx");
            }
            else
            {
                Response.Write("<script>('Nie ma zlecenia o takim ID');</script>");
            }
        }


        //Przycisk zakończ
        protected void Button40_Click(object sender, EventArgs e)
        {
            if(checkifCommissionExist())
            {
                endCommission();
                Response.Write("<script>('Zakończono zlecenie');</script>");
                Response.Redirect("contractorProfile.aspx");
            }
            else
            {
                Response.Write("<script>('Nie ma zlecenia o takim ID');</script>");
            }
        }




        
    }
}