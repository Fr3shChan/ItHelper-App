using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ItHelper
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"] == null)
                {
                    LinkButton1.Visible = true; //User login visible
                    LinkButton2.Visible = true; //User sign up visible

                    LinkButton3.Visible = false; //User log out visible
                    LinkButton7.Visible = false; //User Hello user visible

                    LinkButton6.Visible = true; //Admin login visible

                    //Admin options
                    LinkButton11.Visible = false; //User sign up visible
                    LinkButton12.Visible = false; //User sign up visible
                    LinkButton8.Visible = false; //User sign up visible
                    LinkButton9.Visible = false; //User sign up visible
                    LinkButton10.Visible = false; //User sign up visible

                } 
                else if(Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //User login visible
                    LinkButton2.Visible = false; //User sign up visible

                    LinkButton3.Visible = true; //User log out visible
                    LinkButton7.Visible = true; //User Hello user visible
                    LinkButton7.Text =  "Witaj " + Session["login"].ToString();


                    LinkButton6.Visible = false; //Admin login visible
                    LinkButton11.Visible = false; //User sign up visible
                    LinkButton12.Visible = false; //User sign up visible
                    LinkButton8.Visible = false; //User sign up visible
                    LinkButton9.Visible = false; //User sign up visible
                    LinkButton10.Visible = false; //User sign up visible


                    
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //User login visible
                    LinkButton2.Visible = false; //User sign up visible

                    LinkButton3.Visible = true; //User log out visible
                    LinkButton7.Visible = true; //User Hello user visible
                    LinkButton7.Text = "Witaj Adminie ";


                    LinkButton6.Visible = false; //Admin login visible
                    LinkButton11.Visible = true; //User sign up visible
                    LinkButton12.Visible = true; //User sign up visible
                    LinkButton8.Visible = true; //User sign up visible
                    LinkButton9.Visible = true; //User sign up visible
                    LinkButton10.Visible = true; //User sign up visible


                    
                }
                else if (Session["role"].Equals("contractor"))
                {
                    LinkButton1.Visible = false; //User login visible
                    LinkButton2.Visible = false; //User sign up visible

                    LinkButton3.Visible = true; //User log out visible
                    LinkButton7.Visible = true; //User Hello user visible
                    LinkButton7.Text = "Witaj " + Session["login"].ToString();


                    LinkButton6.Visible = false; //Admin login visible
                    LinkButton11.Visible = false; //User sign up visible
                    LinkButton12.Visible = false; //User sign up visible
                    LinkButton8.Visible = false; //User sign up visible
                    LinkButton9.Visible = false; //User sign up visible
                    LinkButton10.Visible = false; //User sign up visible


                    
                }
            }
            catch(Exception ex)
            {

            }
            
        }

        //Admin Login
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminLogin.aspx");
        }

        //Zarządzanie użytkownikiem
        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminContractorManagement.aspx");
        }

        //Zarządzanie wystawcami
        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("adminUserManagement.aspx");
        }


        //hello user

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("contractor"))
            {
                Response.Redirect("contractorProfile.aspx");
            }
            else
            {
                Response.Redirect("userProfile.aspx");
            }


            Response.Redirect("userProfile.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            

            Response.Redirect("userOrContractor.aspx");
        }

        // Home LinkButton
        

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            
                Session["login"] = "";
                Session["imię"] = "";
                Session["nazwisko"] = "";
                Session["role"] = "";


                LinkButton1.Visible = true; //User login visible
                LinkButton2.Visible = true; //User sign up visible

                LinkButton3.Visible = false; //User log out visible
                LinkButton7.Visible = false; //User Hello user visible

                LinkButton6.Visible = true; //Admin login visible

                //Admin options
                LinkButton11.Visible = false; //User sign up visible
                LinkButton12.Visible = false; //User sign up visible
                LinkButton8.Visible = false; //User sign up visible
                LinkButton9.Visible = false; //User sign up visible
                LinkButton10.Visible = false; //User sign up visible

                Response.Redirect("homePage.aspx");
            


            
            
        }

        protected void LinkButton100_Click(object sender, EventArgs e)
        {
            Response.Redirect("homePage.aspx");
        }


        //signup
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userOrContractorSignUp.aspx");
        }


        // zarządzanie wykonawcami
        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminContractorManagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("checkOpinion.aspx");
        }
    }
}