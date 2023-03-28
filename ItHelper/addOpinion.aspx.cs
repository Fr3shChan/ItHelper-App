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
    public partial class addOpinion : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }


        //ZATWIERDŹ
        protected void Button1_Click(object sender, EventArgs e)
        {
            addUserOpinion();
            Response.Redirect("userProfile.aspx");
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

                string x = Session["login"].ToString();


                SqlCommand cmd = new SqlCommand("INSERT INTO zleceniaTB (ocena) VALUES (@ocena) WHERE ", con);

                
                cmd.Parameters.AddWithValue("@login_wyk", "");


                

                cmd.Parameters.AddWithValue("@ocena", "");

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Pomyślnie dodano nowe zlecenie');</script>");

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userProfile.aspx");
        }
    }
}