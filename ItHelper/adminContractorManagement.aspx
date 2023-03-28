<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminContractorManagement.aspx.cs" Inherits="ItHelper.adminContractorManagement" %>
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
                                     <h4>Zarządzaj Zleceniorcami</h4>
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
                                    <hr>                              
                                </div>
                            </div>


                            <div class="row">
                                <div class="col-md-8"> 
                                    <label>User ID</label>
                                  <div class="form-group">
                                      <div class="input-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Login" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                                      <asp:Button class="btn btn-primary" ID="Button1" runat="server" Text="Szukaj" OnClick="Button1_Click" />
                                          </div>
                                  </div> 
                                </div>                           
                            </div>

                        <br />
                            <div class="row">
                                <div class="col-6">
                                    <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="Zablokuj wykonawcę" OnClick="Button3_Click" />
                                </div>

                            

                                <div class="col-6">
                                    <asp:Button ID="Button4" class="btn btn-lg btn-block btn-warning" runat="server" Text="Odblokuj wykonawcę" OnClick="Button4_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <a href="homePage.aspx"> Back to Home </a>
                <br>
                          
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
                                     <h4>Twoje zlecenia</h4>                                   
                                </center>                              
                            </div>
                            </div>

                            <div class="row">
                                <div class="col">
                                    <hr>                              
                                </div>
                            </div>



                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ithelperDBConnectionString %>" SelectCommand="SELECT [login], [hasło], [wykonawca_Status] FROM [wykonawcaTB]"></asp:SqlDataSource>
                                <div class="col">
                                     <asp:GridView class="table table-striped table-bordered" ID="GridView10" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource">
                                         <Columns>
                                             <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                                             
                                             <asp:BoundField DataField="wykonawca_Status" HeaderText="wykonawca_Status" SortExpression="wykonawca_Status" />
                                         </Columns>
                                     </asp:GridView>                           
                                </div>
                            </div>   
                        </div>
            </div>
        </div>
    </div>
</div>



</asp:Content>
