<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addUsersCommisions.aspx.cs" Inherits="ItHelper.addUsersCommisions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Utwórz nowe zlecenie</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="90px" src="images/addnewitem.png" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-10">
                                <label>Wybierz kategorię: </label>
                                <div class="form-group">
                                    
                                        <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                            
                                            <asp:ListItem Text="Instalacja Systemu" Value="Instalacja Systemu" />
                                            <asp:ListItem Text="Aktualizacja sterowników" Value="Aktualizacja sterowników" />
                                            <asp:ListItem Text="Usuwanie Wirusów" Value="Usuwanie Wirusów" />
                                            <asp:ListItem Text="Wymiana podzespołów" Value="Wymiana podzespołów" />
                                            <asp:ListItem Text="OC Karty Graficznej" Value="OC Karty Graficznej" />
                                            <asp:ListItem Text="OC Procesora" Value="OC Procesora" />
                                            <asp:ListItem Text="Czyszczenie Komputera" Value="Czyszczenie Komputera" />
                                            <asp:ListItem Text="Złożenie Komputera" Value="Złożenie Komputera" />
                                        </asp:DropDownList>
                                    </div>
                                    <label>Wpisz tytuł zlecenia: </label>
                                    <div class="form-group">
                                        <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>

                                    </div>
                                    </div>

                                    <label>Opis:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="" TextMode="MultiLine" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
                                    </div>

                                    <label>Budżet:</label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="" TextMode="Number" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
                                    </div>
                               

                            </div>
                        </div>

                        <div class="row">
                            <div class="col-6">
                                <br>
                                <center>
                                    <asp:Button ID="Button1" class="btn btn-lg btn-block btn-info" runat="server" Text="Zatwierdź" OnClick="Button1_Click"/>
                                </center>
                                
                            </div>

                            <div class="col-6">
                                <br>
                                <center>
                                    <asp:Button ID="Button2" class="btn btn-lg btn-block btn-warning" runat="server" Text="Anuluj" OnClick="Button2_Click"/>
                                </center>
                                
                            </div>
                        </div>
                    </div>


                    </div>

                </div>

            </div>

        </div>

    </div>


</asp:Content>
