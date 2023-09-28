<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VitranNoGenrate.aspx.cs" Inherits="Distribution_VitranNoGenrate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
                <div class="card-header">
                    &#2357;&#2367;&#2340;&#2352;&#2339; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2348;&#2344;&#2366;&#2351;&#2375;
                </div>
                <div class="portlet-content">
                    <asp:Panel class="response-msg success ui-corner-all" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
                    <table width="100%">

                        <tr>
                            <td width="10%" style="font-size: medium;" valign="top">
                                <span style="color: Red;">*</span>
                                <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            </td>
                            <td width="20%">
                                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox"
                                    OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td width="5%" style="font-size: medium;" valign="top">
                                <asp:Label ID="Label2" runat="server">&#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2406;<br /> Order No :</asp:Label>

                            </td>
                            <td width="20%">
                                <asp:DropDownList ID="ddlOrderNO" runat="server" CssClass="txtbox"
                                 >
                                </asp:DropDownList></td>

                        </tr>

                        <tr>
                            <td width="10%" style="font-size: medium;" valign="top">
                                &#2346;&#2361;&#2354;&#2366; &#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; &#2337;&#2366;&#2354;&#2375;</td>
                            <td width="20%">
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                            <td width="5%" style="font-size: medium;" valign="top">
                                &nbsp;</td>
                            <td width="20%">
                                &nbsp;</td>

                        </tr></table> </div> 
</asp:Content>

