<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BRCChallan.aspx.cs" Inherits="Depo_BRCChallan" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div class="box">
        <div class="card-header">
            <h2>
                &#2346;&#2366;&#2357;&#2340;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; </h2>
        </div>
        <div style="padding: 0 10px;">
           
            
            <table width="100%">
                <tr>
                    <td>
                        &#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlDistrict" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlDistrict_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBlock" runat="server">
                        </asp:DropDownList>
                    </td>
                    </tr> 
                <tr>
                    <td>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2357;&#2352;&#2381;&#2359;
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlMedium" runat="server">
                        </asp:DropDownList>
                    </td>
                    </tr> 
                <tr>
                    <td>
                        &#2325;&#2325;&#2381;&#2359;&#2366;
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="1,2,3,4,5,6,7,8">1-8</asp:ListItem>
                            <asp:ListItem Value="9,10,11,12">1-9</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    </tr> 
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show  Data" />
                    </td>
                    </tr>  
                <tr>
                    <td colspan="4">
                       
            <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%" height="" sizetoreportcontent="True">
                            </rsweb:reportviewer>
                       
                    </td>
                    </tr> </table> </div> 
          </div> 
</asp:Content>

