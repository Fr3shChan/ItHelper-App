﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userOrContractor.aspx.cs" Inherits="ItHelper.userOrContractor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto" >


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="150px" src="images/user.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                     <h3>Na jakie konto chcesz się zalogować ?</h3>
                                </center>                              
                            </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr />                              
                            </div>
                        </div>


                            <div class="row">
                                <div class="col">
                                    <label></label>
                                  <div class="form-group">
                                      <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="Button100" runat="server" Text="Użytkownik" OnClick="Button100_Click" />


                                      

                                  </div>  
                                    


                                    <label></label>
                                  <div class="form-group">
                                      <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="Button101" runat="server" Text="Wykonawca" OnClick="Button101_Click" />


                                      

                                  </div> 
                                    

                                    
                            </div>
                        </div>


                    </div>
                </div>


                <a href="homePage.aspx"> Powrót do strony głównej </a></br></br>
            </div>
        </div>
    </div>


</asp:Content>
