using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItHelper
{
    public partial class userOrContractorSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //user
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userSignUp.aspx");
        }


        //wykonawca
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("contractorSignUp.aspx");
        }
    }
}