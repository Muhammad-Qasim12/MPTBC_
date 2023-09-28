<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="25PerBookSendho.aspx.cs" Inherits="Depo_25PerBookSendho" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box table-responsive"> 
     <div class="card-header">    <h2>&#2344;&#2350;&#2370;&#2344;&#2375; &#2325;&#2368; &#2348;&#2369;&#2325; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </h2></div> 
       <table width="100%">
    <tr><td >
        &#2360;&#2340;&#2381;&#2352;
       </td><td >
            <asp:DropDownList ID="DdlACYear" runat="server">
            </asp:DropDownList>
       </td><td >
            &nbsp;</td><td >
            &nbsp;</td> </tr>
    <tr><td >
        &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
       </td><td >
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
       </td><td >
            &#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2377;.</td><td >
            <asp:DropDownList ID="DropDownList2" runat="server">
            </asp:DropDownList>
       </td> </tr>
    <tr><td >
        &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;.</td><td >
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
       </td><td >
            &#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352;</td><td >
            <asp:Label ID="Label1" runat="server"></asp:Label>
       </td> </tr>
    <tr><td class="auto-style1" >
        &#2346;&#2381;&#2352;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;.</td><td class="auto-style1" >
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
       </td><td class="auto-style1" >
            &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
       </td><td class="auto-style1" >
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBox3" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
       </td> </tr>
    <tr><td colspan="4" >
        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="save" OnClick="Button1_Click" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
       </td> </tr>
    <tr><td colspan="4" >
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
            <Columns>
                <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />
                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2377; " DataField="CHallanID" />
                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2306;&#2348;&#2352; " DataField="BookNo" />
                <asp:BoundField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; " DataField="bundelNo" />
                <asp:BoundField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;." DataField="LetterNo" />
                <asp:BoundField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="LetterDate" />
            </Columns>
        </asp:GridView>
        </td> </tr>
           </table> </div> 
</asp:Content>

