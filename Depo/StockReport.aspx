<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="StockReport.aspx.cs" Inherits="Depo_StockReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box table-responsive">

        <div class="card-header">
            <h2>&#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </h2>
        </div>
        <div style="padding: 0 10px;">

            <table width="100%">
                <tr>
                    <td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :</td>
                    <td>

                    &nbsp;<asp:DropDownList ID="ddlSessionYear" runat="server">
                        </asp:DropDownList>

                    </td><td>&nbsp;</td><td>
                    &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style1">&nbsp; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>

                    </td><td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;&nbsp;</td><td>
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                
                        </td>
                </tr>
                <tr>
                    <td class="auto-style1">&#2325;&#2325;&#2381;&#2359;&#2366; / Class</td>
                    <td>
                    <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox">
                        <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                        <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                    </asp:DropDownList>
                    </td><td colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                    </td>
                </tr></table> 
        </div> 
    <div class="box table-responsive" runat="server" visible="false" ID="a">
        <div id="ExportDiv" runat="server">
            <table width="100%">
                <tr>
                    <td>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &lt;/br&gt; 1">
                                    <ItemTemplate>
                                       <%# Container.DataItemIndex +1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; &lt;/br&gt; 2">

                                    <ItemTemplate>
                                        <%# Eval("Title") %>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &lt;/br&gt; 3">
                                     <ItemTemplate>
                                         <%#Eval("booksperbundleY") %>
                                     </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &lt;/br&gt; 4">
                                    <ItemTemplate>
                                        <%#Eval("noofbooky") %>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2325;&#2368; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &lt;/br&gt; 5">
                                     <ItemTemplate>
                                        <%#Eval("NO Of Books") %>
                                    </ItemTemplate> 
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343;  &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &lt;/br&gt; 6">
                                    <ItemTemplate><%# Convert.ToInt32(Eval("NO Of Books") ) + Convert.ToInt32(Eval("noofbooky"))%></ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <asp:Button ID="btnExport" runat="server" CssClass="btn_gry"
        Text="Export to Excel" OnClick="btnExport_Click" />
</asp:Content>

