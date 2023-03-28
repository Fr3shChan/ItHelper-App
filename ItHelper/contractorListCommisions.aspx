<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contractorListCommisions.aspx.cs" Inherits="ItHelper.contractorListCommisions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Zarządzaj zleceniami</h4>
                                    <br />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="90px" src="images/list.png" />
                                </center>
                            </div>
                        </div>
                        <br />

                        <div class="row">
                                <div class="col-md-6"> 
                                    <label>ID: </label>
                                  <div class="form-group">
                                      <div class="input-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" placeholder="ID"></asp:TextBox>
                                      <asp:Button class="btn btn-primary" ID="Button10" runat="server" Text="Idź do" OnClick="Button10_Click"/>
                                          </div>
                                  </div> 
                                </div>
                            </div>

                            <div class="row">
                                

                                <div class="col-6">
                                    <asp:Button ID="Button30" class="btn btn-lg btn-block btn-primary" runat="server" Text="Wybierz" OnClick="Button30_Click"/>
                                </div>

                                <div class="col-6">
                                    <asp:Button ID="Button40" class="btn btn-lg btn-block btn-success" runat="server" Text="Zakończ" OnClick="Button40_Click"/>
                                </div>
                            </div>
                            <br>
                            <br>
                            <br>
                            <br>



                        
                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>
                        

                        <div class="col">
                            <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Powrót do Profilu" OnClick="Button3_Click"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-8">
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
                                    
                                    <div class="col">
                                    <div style="width: 100%; height: 400px; overflow: scroll">
                                     <asp:GridView ID="GridView1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">

                                         <Columns>
                                                <asp:BoundField HeaderText="ID" DataField="ID_zlecenia" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md" />
                                                <asp:BoundField HeaderText="Login" DataField="login_kli" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Kategoria" DataField="kategoria" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Tytuł" DataField="tytuł" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Opis" DataField="opis" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Budżet"  DataField="budżet" SortExpression="ID_zlecenia" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                         </Columns>
                                     </asp:GridView>    
                                        </div>
                                </div>
                                </center>                              
                            </div>
                            </div>

                            



                            
            </div>
        </div>
    </div>



</asp:Content>
