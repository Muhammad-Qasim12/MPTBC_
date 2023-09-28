<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderFinal.aspx.cs" Inherits="Depo_Tender_TenderFinal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="portlet-header ui-widget-header">
            &#2346;&#2352;&#2367;&#2357;&#2361;&#2344; &#2325;&#2368; &#2342;&#2352;&#2379; &#2325;&#2366; &#2344;&#2367;&#2352;&#2381;&#2343;&#2366;&#2352;&#2339;
        </div>
        <div class="portlet-content">
            <div class="table-responsive">
                <asp:Panel ID="messDiv" runat="server">
                    <asp:Label ID="lblMess" runat="server" class="notification"></asp:Label>
                </asp:Panel>
                <div>
                    <table width="100%">
                        <tr>
                            <td style="width:30%;">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td style="width:30%;">
                                <asp:DropDownList ID="ddlDepo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDepo_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width:30%;">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                            <td>
                                <asp:DropDownList ID="ddlTender" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTender_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2337;&#2367;&#2346;&#2379; &#2325;&#2375; &#2354;&#2367;&#2319; &#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " />
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                                <br />
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                    <Columns>
                                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     <asp:HiddenField ID="hdPartyID" runat="server" Value='<%#Eval("partyID") %>' />
                                                      <asp:HiddenField ID="hdDepo" Value='<%# Eval("DepoTrno_I") %>' runat="server" />
                                                      <asp:HiddenField ID="hdBlock" Value='<%# Eval("BlockID") %>' runat="server" />
                                                     <asp:HiddenField ID="hdDistrictID" Value='<%# Eval("DistrictID") %>' runat="server" />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                        <asp:BoundField DataField="NameofParty" HeaderText="&#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                        <asp:BoundField DataField="District_Name_Hindi_V" HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                        <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                        <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                        <asp:BoundField DataField="FullTruckRate_N" HeaderText="&#2347;&#2369;&#2354; &#2335;&#2381;&#2352;&#2325; " />
                                        <asp:BoundField DataField="HalfTruckRate_N" HeaderText="&#2361;&#2366;&#2347; &#2335;&#2381;&#2352;&#2325; &#2352;&#2375;&#2335; " />
                                        <asp:BoundField DataField="RatePerBundle_N" HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367;&#2348;&#2306;&#2337;&#2354; &#2352;&#2375;&#2335; " />
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

