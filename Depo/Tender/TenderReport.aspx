<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderReport.aspx.cs" Inherits="Depo_Tender_TenderReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="portlet-header ui-widget-header">
            &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2325;&#2368; &#2342;&#2352;&#2379; &#2325;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;
        </div>
        <div class="portlet-content">
            <div class="table-responsive">
                <asp:Panel ID="messDiv" runat="server">
                    <asp:Label ID="lblMess" runat="server" class="notification"></asp:Label>
                </asp:Panel>
                <div>
                    <table width="100%">
                        <tr>
                            <td style="width: 30%;">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td style="width: 30%;">
                                <asp:DropDownList ID="ddlDepo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 30%;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td>
                                <asp:DropDownList ID="ddlTender" runat="server" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; " />
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352; &lt;br&gt; 1">
                                            <ItemTemplate>
                                               <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350;  &lt;br&gt; 2">  <ItemTemplate>
                                                <asp:Literal ID="ltrLeader" runat="server" OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                            </ItemTemplate></asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350;  &lt;br&gt; 3">
                                              <ItemTemplate>
                                                <%# Eval("BlockNameHindi_V") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325;&#2379; (9 &#2335;&#2344; )&#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;br&gt; 4">
                                              <ItemTemplate>
                                              <%# Eval("FullTruckRate_N") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="&#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325;&#2379; (4.5 &#2335;&#2344; )&#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;br&gt; 5">
                                              <ItemTemplate>
                                                <%# Eval("HalfTruckRate_N") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354;&#2379; (&#2354;&#2327;&#2349;&#2327; 40 &#2325;&#2367;&#2354;&#2379;) &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &lt;br&gt;6">
                                               <ItemTemplate>
                                               <%# Eval("RatePerBundle_N") %>
                                            </ItemTemplate>
                                         </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

