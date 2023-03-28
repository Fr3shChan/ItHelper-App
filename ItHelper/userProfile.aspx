<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="userProfile.aspx.cs" Inherits="ItHelper.userProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="container-fluid">
        <div class="row">
            <div class="col-md-5" >


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
                                     <h4>Twój profil</h4>
                                    
                                    <asp:Label class="badge badge-pill badge-info" ID="Label1" runat="server" Text=""></asp:Label>
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
                                    <label>Imię</label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox1" runat="server" placeholder=""></asp:TextBox>
                                  </div> 
                                </div>

                                 <div class="col-md-6">
                                     <label>Nazwisko</label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox2" runat="server" placeholder=""></asp:TextBox>

                                  </div>
                                 </div>
                            </div>




                            <div class="row">

                                <div class="col-md-11"> 
                                    <label>Adres</label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox5" runat="server" placeholder=""></asp:TextBox>
                                  </div> 
                                </div>


                                <div class="col-md-1"> 
                                    
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox3" runat="server" placeholder=""  TextMode="Date" Visible="false"></asp:TextBox>
                                  </div> 
                                </div>
                            </div>




                            <div class="row">
                                
                                <div class="col-md-6"> 
                                    <label>Miasto</label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox9" runat="server" placeholder=""></asp:TextBox>
                                  </div> 
                                </div>

                                 <div class="col-md-6">
                                     <label>Kod pocztowy</label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox6" runat="server" placeholder=""></asp:TextBox>

                                  </div>
                                 </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Nr Telefonu</label>
                                    <div class="form-group">
                                        <asp:TextBox class="form-control" ID="TextBox10" runat="server" placeholder=""></asp:TextBox>
                                    </div>
                                    
                                </div>
                            </div>


                        <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text=""></asp:Label>
                            <div class="row">

                                <div class="col-md-4">
                                     <label>Login</label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox4" runat="server" placeholder="" ReadOnly="True"></asp:TextBox>

                                  </div>
                                 </div>

                                
                                <div class="col-md-4"> 
                                    <label></label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox8" runat="server" placeholder=""  ReadOnly="True" Visible="false"></asp:TextBox>
                                  </div> 
                                </div>


                                <div class="col-md-4"> 
                                    <label>Nowe Hasło </label>
                                  <div class="form-group">
                                      <asp:TextBox class="form-control" ID="TextBox7" runat="server" placeholder="" TextMode="Password"></asp:TextBox>
                                  </div> 
                                </div>

                                 
                            </div>

                            
                               
                                                              
                                
                            


                            <div class="row">
                                <div class="col-8 mx-auto"> 
                                    <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button1" runat="server" Text="Zmień Dane" OnClick="Button1_Click" />
                                    </div> 
                                        </center>
                            </div>


                        </div>


                    </div>
                    <a href="homePage.aspx"> Powrót na stronę główną </a></br></br>
                </div>


                

                
            </div>


            <div class="col-md-7">

                


                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/sjob.jpg" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Twoje zlecenia</h4>
                                    
                                    
                                </center>                              
                            </div>
                            </div>

                            <div class="row">
                                <label>Podaj ID zlecenia: </label>
                                <div class="col-md-3"> 
                                    
                                  <div class="form-group">
                                      <div class="input-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="ID" OnTextChanged="TextBox12_TextChanged"></asp:TextBox>
                                      <asp:Button class="btn btn-primary" ID="Button10" runat="server" Text="Idź do" OnClick="Button10_Click" />
                                          </div>
                                  </div> 
                                </div>
                            </div>

                            <div class="row">
                                

                                <div class="col-6">
                                    <asp:Button ID="Button30" class="btn btn-lg btn-block btn-danger" runat="server" Text="Zakończ Zlecenie" OnClick="Button30_Click"/>
                                </div>

                                <div class="col-6">
                                    <asp:Button ID="Button40" class="btn btn-lg btn-block btn-success" runat="server" Text="Aktywuj Zlecenie" OnClick="Button40_Click"/>
                                </div>
                            </div>




                            <div class="row">
                                <div class="col">
                                    <hr />                              
                                </div>
                            </div>

                        



                        <%-- TODO --%>
                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ithelperDBConnectionString %>" SelectCommand="SELECT [kategoria], [tytuł] FROM [zleceniaTB] WHERE login_kli='gdfgdfg'"></asp:SqlDataSource>
                            <div class="col">

                                

                                

                            <div class="col">
                                    <div style="width: 100%; height: 400px; overflow: scroll">
                                     <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">

                                         <Columns>
                                                <asp:BoundField HeaderText="ID" DataField="ID_zlecenia" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                                                <%-- <asp:BoundField HeaderText="Login" DataField="login_kli" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>--%>
                                                <asp:BoundField HeaderText="Kategoria" DataField="kategoria" SortExpression="kategoria" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Tytuł" DataField="tytuł" SortExpression="tytuł" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Opis" DataField="opis" SortExpression="opis" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Budżet"  DataField="budżet" SortExpression="budżet" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Status"  DataField="status_zlec" SortExpression="status_zlec" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                             <asp:BoundField HeaderText="Opinia"  DataField="ocena" SortExpression="ocena" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                         </Columns>
                                     </asp:GridView>    
                                        </div>
                                </div>



                            


                                

                                

                                
                            </div>

                            

                        </div>
    
            </div>

                


        </div>


                <div class="col-8 mx-auto"> 
                                    <center>
                                    <div class="form-group">
                                        <asp:Button class="btn btn-primary btn-block btn-lg" ID="Button2" runat="server" Text="Dodaj Zlecenie" OnClick="Button2_Click" />
                                    </div> 
                                        </center>
                            </div>


                <br />

                <div class="row">
                            <div class="col-md-10">
                                

                                    <label>Opinia: </label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Opis" TextMode="MultiLine" OnTextChanged="TextBox11_TextChanged"></asp:TextBox>
                                    </div>

                                    
                               

                            </div>

                            <div class="col-6">
                                    
                                        <center>
                                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-info" runat="server" Text="Zatwierdź" OnClick="Button3_Click"/>
                                        </center>
                                <br />
                            </div>
                        </div>


                
    </div>


</asp:Content>
