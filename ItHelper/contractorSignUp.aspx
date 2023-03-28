<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contractorSignUp.aspx.cs" Inherits="ItHelper.contractorSignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto" >


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/user.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Zarejestruj firmę</h4>
                                </center>                              
                            </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr />                              
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-6"> 
                                    <label>Nazwa firmy</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder=""></asp:TextBox>
                                  </div> 
                                </div>

                                 
                            </div>




                            <div class="row">
                                   

                                <div class="col-md-4"> 
                                    <label>NIP</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="" TextMode="Number"></asp:TextBox>
                                  </div> 
                                </div>
                                
                                <div class="col-md-4"> 
                                    <label>Nr telefonu</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="" TextMode="Number"></asp:TextBox>
                                  </div> 
                                </div> 
                            </div>




                            <div class="row">
                                <div class="col-md-4"> 
                                    <label>Adres</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder=""></asp:TextBox>
                                  </div> 
                                </div>

                                 <div class="col-md-4">
                                     <label>Kod pocztowy</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder=""></asp:TextBox>

                                  </div>
                                 </div>

                                <div class="col-md-4">
                                     <label>Miasto</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder=""></asp:TextBox>

                                  </div>
                                 </div>
                            </div>



                            <div class="row">

                                <div class="col-md-6">
                                     <label>Login</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder=""></asp:TextBox>

                                  </div>
                                 </div>

                                
                                <div class="col-md-6"> 
                                    <label>Hasło</label>
                                  <div class="form-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="" TextMode="Password"></asp:TextBox>
                                  </div> 
                                </div>

                                 
                            </div>

                            
                               
                                                              
                                
                            


                            <div class="row">
                                <div class="col">
                                     
                                    


                                  
                                    

                                    <div class="form-group">
                                        <asp:Button class="btn btn-info btn-block btn-lg" ID="Button3" runat="server" Text="Zajerestruj" OnClick="Button3_Click" />
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
