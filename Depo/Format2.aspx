<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Format2.aspx.cs" Inherits="Depo_Format2" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2346;&#2381;&#2352;&#2346;&#2340;&#2381;&#2352; -2</h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <table width="100%">
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;</td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>
                        <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </td>
                        <td>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>&#2325;&#2325;&#2381;&#2359;&#2366; </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                                <asp:ListItem Text="Select.." Value="0"></asp:ListItem>
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>


                        </td>
                        <td colspan="2">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                        </td>
                    </tr>
                  </table>
                 <div style="overflow: scroll; width="1200px"">
                                    <rsweb:reportviewer id="ReportViewer1" width="100%" runat="server" documentmapwidth="100%"
                                        height="" sizetoreportcontent="True">
                                     </rsweb:reportviewer>  </div></div> </div> 
            </div> 
</asp:Content>

