using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItHelper
{
    public partial class userOrContractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //Użytkownik
        protected void Button100_Click(object sender, EventArgs e)
        {
            Response.Redirect("userLogin.aspx");
        }


        // Wykonawca
        protected void Button101_Click(object sender, EventArgs e)
        {
            Response.Redirect("contractorLogin.aspx");
        }
    }
}