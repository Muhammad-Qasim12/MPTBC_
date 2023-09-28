<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShowChallanDetails.aspx.cs" Inherits="Depo_ShowChallanDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </div>
    <div class="portlet-content">

        <asp:Panel runat="server" ID="pnlMain">

            <table width="100%">

                <tr>

                    <td>

                        <asp:GridView runat="server" ID="GrdChallan" AutoGenerateColumns="false" CssClass="tab hastable">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate><%# Eval("ChalanNo")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                    <ItemTemplate><%# Eval("ChalanDate")%></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                    <ItemTemplate><%# Eval("ReceiptDate")%></ItemTemplate>
                                </asp:TemplateField>




                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="PRIN001_ChallanDetails.aspx?Cid=<%# Eval("PriTransID") %>">Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>

                    </td>


                </tr>



                <tr>
                    <td>
                        <asp:GridView ID="GrdTitle" runat="server" AutoGenerateColumns="False"
                            CssClass="tab hastable">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                    <ItemTemplate>
                                        <%# Eval("nameofpress_v")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                    <ItemTemplate>
                                        <%# Eval("groupno_v")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
                                    <ItemTemplate>
                                        <%# Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2346;&#2376;&#2325;&#2375;&#2335;&#2381;&#2360;">
                                    <ItemTemplate>
                                        <%--<asp:TextBox ID="txtPacketsSendAsPerChallan" runat="server" 
                                        CssClass="txtbox reqirerd" MaxLength="4" 
                                        onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                                        onpaste="javascript:tbx_fnSignedInteger(event, this);" 
                                        Text='<%# Eval("PacketsSendAsPerChallan") %>' Width="80px"></asp:TextBox>--%><asp:Label
                                            ID="Label1" runat="server" Text='<%# Eval("PacketsSendAsPerChallan") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2367;&#2344;&#2340;&#2368; &#2350;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2376;&#2325;&#2375;&#2335;&#2381;&#2360; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>

                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("PacketsReceiveByCounting") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2369;&#2354; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; ">
                                    <ItemTemplate>

                                        <asp:Label ID="Label3"
                                            runat="server" Text='<%# Eval("TotalNoOfBooks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                    <ItemTemplate>

                                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("BooksFrom") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                    <ItemTemplate>
                                        <asp:Label ID="Label22" runat="server" Text='<%# Eval("BooksTo") %>'></asp:Label>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField></asp:TemplateField>
                                <asp:TemplateField></asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HDNTitleID_I" runat="server"
                                            Value='<%# Eval("TitleID_I") %>' />
                                        <asp:HiddenField ID="HDNDepoID_I" runat="server"
                                            Value='<%# Eval("DepoID_I") %>' />
                                        <asp:HiddenField ID="HDNGRPID_I" runat="server"
                                            Value='<%# Eval("GRPID_I") %>' />
                                        <asp:HiddenField ID="HDNChallanTrno_I" runat="server"
                                            Value='<%# Eval("ChallanTrno_I") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>



            </table>



        </asp:Panel>
    </div>

</asp:Content>

