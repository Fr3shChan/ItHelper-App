<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="ItHelper.homePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <img height="600" width="2000"src="images/servers.jpg" />
    </section>
    <section>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <center>
                    <h2>Cechy serwisu:</h2>
                    
                    </center>                  
                </div>
            </div>

            <div class="row">
                <div class="col-md-4">
                    <center>
                        <img width="150px" src="images/easy2.jpg" />  
                    <h4>Prosty</h4>
                    
                    </center>
                    
                </div>
            

            
                <div class="col-md-4">
                       <center>
                        <img width="150px" src="images/reliable.jpg" />  
                    <h4>Bezpieczny</h4>
                    
                    </center>               
                </div>
            

            
                <div class="col-md-4">
                       <center>
                        <img width="150px" src="images/big.png" />  
                    <h4>Tworzący społeczność</h4>
                    
                    </center>               
                </div>
           </div> 
        </div>
    </section>



    <section>
        <img src="images/it.jpg" class="img-fluid" />
    </section>

</asp:Content>
