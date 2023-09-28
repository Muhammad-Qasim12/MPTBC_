<%@ Page Title="&#2357;&#2367;&#2340;&#2352;&#2339; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2357;&#2375;&#2358; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrinterBookDistribution.aspx.cs" Inherits="Printing_PrinterBookDistribution" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
    &#2357;&#2367;&#2340;&#2352;&#2339; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2357;&#2375;&#2358; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <asp:Panel ID="messDiv" runat="server">
                <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td>
                       &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; :
                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox reqirerd" OnInit="DdlACYear_Init">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="BtnSearch" runat="server" OnClick="BtnSearch_Click" Text="&#2326;&#2379;&#2332;&#2375;"
                            OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="GrdEval" runat="server" CssClass="tab" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <%#Eval("DepoName_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <%#Eval("NoOfBooks")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; ">
                                    <ItemTemplate>
                                        <%#Eval("BookType")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" 	&#2325;&#2325;&#2381;&#2359;&#2366;">
                                    <ItemTemplate>
                                        <%#Eval("Classdet_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2327;&#2337;&#2381;&#2337;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <%#Eval("BooksPerGaddi")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>
                                        <%#Eval("BooksPerBundle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पुस्तक नम्बर से">
                                    <ItemTemplate>
                                        <%#Eval("BookNumberFrom")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पुस्तक नम्बर तक">
                                    <ItemTemplate>
                                        <%#Eval("BookNumberTo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <%#Eval("TotalBundels")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352; &#2360;&#2375;">
                                    <ItemTemplate>
                                        <%#Eval("BundleNoFrom")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352; &#2340;&#2325;">
                                    <ItemTemplate>
                                        <%#Eval("BundleNoTo")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; ">
                                    <ItemTemplate>
                                        <%#Eval("Remark")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--  <asp:Button runat="server" ID="btnSave" CssClass="btn" Text="Save" OnClick="btnSave_Click" />--%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
