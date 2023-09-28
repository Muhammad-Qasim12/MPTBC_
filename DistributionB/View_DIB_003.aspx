<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View_DIB_003.aspx.cs" Inherits="Distribution_FreeTextBooksDemandFromRSK"
    Title="&#2357;&#2366;&#2352;&#2381;&#2359;&#2367;&#2325; &#2360;&#2381;&#2335;&#2377;&#2325; &#2348;&#2368;&#2350;&#2366; &#2325;&#2375; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2366;&#2352;&#2379;&#2306; &#2325;&#2368; &#2340;&#2325;&#2344;&#2368;&#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2366;&#2352;&#2381;&#2359;&#2367;&#2325; &#2360;&#2381;&#2335;&#2377;&#2325;
                    &#2348;&#2368;&#2350;&#2366; &#2325;&#2375; &#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2366;&#2352;&#2379;&#2306;
                    &#2325;&#2368; &#2340;&#2325;&#2344;&#2368;&#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNewCompany" CssClass="btn" OnClick="btnNewCompany_Click" runat="server"
                            Text="&#2344;&#2312; &#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2349;&#2352;&#2375;&#2306;" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdInfo" runat="server" AutoGenerateColumns="false" CssClass="tab"
                            DataKeyNames="InsuranceCompanyTrno_I" OnRowEditing="GrdInfo_OnRowEditing" OnRowDeleting="GrdInfo_OnRowDeleting"
                            OnDataBinding="GrdInfo_DataBinding" OnRowDataBound="GrdInfo_RowDataBound">
                            <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %></ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField DataField="FyYear" HeaderText=" &#2357;&#2367;&#2340;&#2381;&#2340;&#2367;&#2351; &#2357;&#2352;&#2381;&#2359; " />
                                <asp:BoundField DataField="CompanyName_V" HeaderText="&#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2325;&#2366;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCmpId" runat="server" Text='<%#Eval("InsuranceCompanyTrno_I") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Technical Specifications">
                                    <ItemTemplate>
                                        <asp:GridView ID="GrdSpecDetails" AutoGenerateColumns="false" ShowHeader="false"
                                            runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkTechCondition" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsSelected")) %>'
                                                            runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TndrCondition" />
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="DIB_003_InsuranceTenderInfo.aspx?ID=<%#Eval("InsuranceCompanyTrno_I") %>">&#2360;&#2369;&#2343;&#2366;&#2352;
                                            &#2325;&#2352;&#2375;&#2306; </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306;"
                                            OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div style="height: 5px;">
            </div>
        </div>
    </div>
</asp:Content>
