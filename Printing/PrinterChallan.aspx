<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterChallan.aspx.cs" 
    Inherits="Printing_PrinterChallan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
            <h2>
                 
                &#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344;&#2366;&#2351;&#2375;</h2>
        </div>
     <div class="box table-responsive">
        
    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
        <asp:ListItem Value="1" Selected="True">&#2350;&#2375;&#2332;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344;</asp:ListItem>
        <asp:ListItem Value="2">&#2350;&#2366;&#2311;&#2344;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; (U and E Group)</asp:ListItem>
    </asp:RadioButtonList>
          <br />
         <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" />
          </div> 
</asp:Content>

