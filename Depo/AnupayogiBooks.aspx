<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AnupayogiBooks.aspx.cs" Inherits="Depo_AnupayogiBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
                            <div class="card-header">
                                <h2>&#2309;&#2344;&#2369;&#2313;&#2346;&#2351;&#2379;&#2327;&#2368; /&#2309;&#2346;&#2381;&#2352;&#2330;&#2354;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</h2>
                            </div>
        <table width="100%">
            <tr><td>&#2360;&#2340;&#2381;&#2352;</td><td>
                <asp:DropDownList ID="ddlFyYear" runat="server">
                </asp:DropDownList>
                </td><td>
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Details" />
                </td></tr>

            <tr><td colspan="3">
                <asp:Button ID="btnExport" runat="server" CssClass="btn" OnClick="btnExport_Click" Text="Export to Excel"   />
                </td></tr>

            <tr><td colspan="3">
                <div id="ExportDiv" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                    <Columns>
                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                        <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="TitleHindi_V" />
                        <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="TotalNotuseful_N" />
                    </Columns>
                </asp:GridView></div> 
                </td></tr>

        </table>

        </div> 
</asp:Content>

