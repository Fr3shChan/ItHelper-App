<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminUserManagement.aspx.cs" Inherits="ItHelper.adminUserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <!-- Skrypt umożliwiający wyszukiwanie danego rekordu -->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6" >


                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Zarządzaj użytkownikami</h4>
                                    <div class="form-group">
                                    </div>
                                    
                                </center>                              
                            </div>
                            </div>

                            <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="images/profileedit.png" />
                                </center>
                            </div>
                        </div>


                            <div class="row">
                                <div class="col">
                                    <hr />                              
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-8"> 
                                    <label>Login użytkownika: </label>
                                  <div class="form-group">
                                      <div class="input-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Podaj Login" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                      <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Szukaj" OnClick="Button1_Click" />
                                          </div>
                                  </div> 
                                </div>

                                 <div class="col-md-4">
                                     <label></label>
                                  <div class="form-group">
                                     <%-- <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="user login"></asp:TextBox>--%>

                                  </div>
                                 </div>
                            </div>

                        <br />
                            <div class="row">
                                

                                <div class="col-6">
                                    <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="Zablokuj Użytkownika" OnClick="Button3_Click" />
                                </div>

                                <div class="col-6">
                                    <asp:Button ID="Button4" class="btn btn-lg btn-block btn-warning" runat="server" Text="Odblokuj Użytkownika" OnClick="Button4_Click" />
                                </div>
                            </div>

                      
                    </div>
                    
                    <asp:Button ID="Button69" class="btn btn-lg btn-block btn-warning" runat="server" Text="Powrót na stronę główną" OnClick="Button69_Click" />
                </div>           
            </div>
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width ="100px" src="images/sjob.jpg" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Lista Użytkowników</h4>
                                </center>                              
                            </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr />                              
                                </div>
                            </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ithelperDBConnectionString %>" SelectCommand="SELECT [login], [hasło], [klient_status] FROM [klientTB]"></asp:SqlDataSource>
                                <div class="col">
                                     <asp:GridView class="table table-striped table-bordered" ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource">
                                         <Columns>
                                             <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                                             
                                             <asp:BoundField DataField="klient_status" HeaderText="klient_status" SortExpression="klient_status" />
                                         </Columns>
                                     </asp:GridView>                           
                                </div>
                            </div>         
            </div>
        </div>
    </div>

</asp:Content>
