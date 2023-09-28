<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ExtraDemand.aspx.cs" Inherits="Depo_ExtraDemand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
        <h2>
            <span>Extra Demand </span></h2>
    </div>
                        <asp:Panel class="response-msg success ui-corner-all" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
    <table width="100%">
         <tr>
                    <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>

                    </td>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;                             
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>
                    </td>
                </tr>
           <tr>
               <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Financial Year</td>
               <td>
                   <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
                   </asp:DropDownList>
               </td>
               <td class="auto-style1">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
               <td>
                    <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox reqirerd"></asp:DropDownList>
                    </td>
           </tr>
           <tr>
               <td class="auto-style1">&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; </td>
               <td>
                   <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox reqirerd" >0</asp:TextBox>
               </td>
               <td class="auto-style1">&nbsp;</td>
               <td>&nbsp;</td>
           </tr>
           <tr>
               <td class="auto-style1">&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337;</td>
               <td>  <asp:TextBox ID="txt01" runat="server" CssClass="txtbox" ></asp:TextBox>
                   &nbsp;</td>
               <td class="auto-style1">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2337;&#2367;&#2350;&#2366;&#2306;&#2337; </td>
               <td>  <asp:TextBox ID="txt02" runat="server" CssClass="txtbox" ></asp:TextBox></td>
           </tr>
           <tr>
               <td class="auto-style1" colspan="4">
                   <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click" OnClientClick="return ValidateAllTextForm();" Text="Save Data" />
               </td>
           </tr>
        </table> 
</asp:Content>

