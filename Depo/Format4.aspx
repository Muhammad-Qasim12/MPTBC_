<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Format4.aspx.cs" Inherits="Depo_Format4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>&#2349;&#2380;&#2340;&#2367;&#2325; &#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2346;&#2381;&#2352;&#2346;&#2340;&#2381;&#2352; -4</h2>
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
                        <td>&#2360;&#2340;&#2381;&#2351;&#2366;&#2346;&#2344; &#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                        <td>
                            <asp:DropDownList ID="ddlPEmp" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                        </td>
                    </tr>
                    <tr>
                        <td>&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2357;&#2344;&#2381;&#2343;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlDepoManager" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                        </td>
                        <td>&#2360;&#2381;&#2335;&#2379;&#2352; &#2325;&#2368;&#2346;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                        <td>
                            <asp:DropDownList ID="ddlstoreKee" runat="server" CssClass="txtbox reqirerd">
                            </asp:DropDownList>


                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                <Columns>
                                     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>

                                    <asp:BoundField HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                    <asp:BoundField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " />
                                    <asp:BoundField HeaderText="&#2309;&#2306;&#2340;&#2367;&#2350; &#2360;&#2381;&#2335;&#2377;&#2325; " />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            &nbsp;</td>
                    </tr>
                    </table> </div> </div> 
</asp:Content>

