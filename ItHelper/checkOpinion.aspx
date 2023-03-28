<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="checkOpinion.aspx.cs" Inherits="ItHelper.checkOpinion" %>
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
                                <hr />
                            </div>
                        </div>
                        

                        
                    </div>
                </div>
            </div>
            <div class="col-md-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                     <h4>Opinie o wykonawcach</h4>
                                    
                                    <div class="col">
                                    <div style="width: 100%; height: 400px; overflow: scroll">
                                     <asp:GridView ID="GridView10" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView10_SelectedIndexChanged">

                                         <Columns>
                                                <asp:BoundField HeaderText="nazwa wykonawcy" DataField="imię_nazwa" SortExpression="imię_nazwa" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                
                                                <asp:BoundField HeaderText="Kategoria" DataField="kategoria" SortExpression="imię_nazwa" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                <asp:BoundField HeaderText="Tytuł" DataField="tytuł" SortExpression="imię_nazwa" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
                                                
                                                <asp:BoundField HeaderText="Opinia" DataField="ocena" SortExpression="imię_nazwa" HeaderStyle-CssClass="visible-md" ItemStyle-CssClass="visible-md"/>
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
