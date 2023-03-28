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
    public partial class checkOpinion : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            showOpinion();
        }

        void showOpinion() 
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //SqlCommand cmd = new SqlCommand("SELECT * FROM zleceniaTB WHERE status_zlec='zakończony'", con);
                SqlCommand cmd = new SqlCommand("select imię_nazwa, login_wyk, ocena, kategoria, tytuł, opis from wykonawcaTB, zleceniaTB where login_wyk = login and ocena>'' order by imię_nazwa", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                GridView10.DataSource = dt;
                GridView10.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }

        protected void GridView10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}