<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contractorLogin.aspx.cs" Inherits="ItHelper.contactorLogin" %>
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
                                     <h3>Logowanie jako Wykonawca</h3>
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
                                    <label>Login    </label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder=""></asp:TextBox>
                                  </div>  
                                   
                                    <label>Hasło</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="" TextMode="Password"></asp:TextBox>




                                      </div> 
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Zaloguj się" OnClick="Button1_Click" />
                                    </div>

                                    <div class="form-group">
                                        <asp:Button class="btn btn-info btn-block btn-lg" ID="Button2" runat="server" Text="Zarejerstruj się" OnClick="Button2_Click" />
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
