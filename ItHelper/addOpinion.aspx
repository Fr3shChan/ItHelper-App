<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="addOpinion.aspx.cs" Inherits="ItHelper.addOpinion" %>
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
                                    <h4>Dodaj opinię o wykonawcy</h4>
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
                                

                                    <label>Opinia: </label>
                                    <div class="form-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Opis" TextMode="MultiLine" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
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
