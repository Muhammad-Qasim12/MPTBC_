<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT012.aspx.cs" Inherits="Depo_VIEW_DPT012" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box">
        <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; 25 % &#2327;&#2339;&#2344;&#2366; &#2352;&#2360;&#2368;&#2342;</span></h2>
        </div>

        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2370;&#2330;&#2368; &#2342;&#2375;&#2326;&#2375; "
                            OnClick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="Grdmain" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" DataKeyNames="StockReceivedTPerID_I" PageSize="20"
                            OnRowDeleting="Grdmain_RowDeleting"
                            OnPageIndexChanging="Grdmain_PageIndexChanging" AllowPaging="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printers Name">
                                    <ItemTemplate>
                                        <a href="ShowTwentyPerRept.aspx?id=<%# api.Encrypt(Eval("StockReceivedTPerID_I").ToString ()) %>"><%#Eval("NameofPress_V")%></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" DataField="ChallanNo_V" />
                                <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " DataField="ChallanDate" />
                                <%-- <asp:BoundField HeaderText="&#2344;&#2350;&#2370;&#2344;&#2375; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; " DataField="bookNo_V" />
                                 <asp:BoundField HeaderText="&#2332;&#2366;&#2306;&#2330; &#2325;&#2367;&#2351;&#2375; &#2327;&#2351;&#2375; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" DataField="BundleNo_V" />
                                 <asp:BoundField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; &#2325;&#2375; &#2360;&#2352;&#2354;  &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; " DataField="RegisterNo" />--%>
                                <asp:TemplateField HeaderText="&#2346;&#2340;&#2381;&#2352; &#2344;&#2306;&#2348;&#2352;">
                                    <ItemTemplate>
                                        <a href="ShowTwentyPerRept.aspx?id=<%# api.Encrypt(Eval("StockReceivedTPerID_I").ToString ()) %>"><%#Eval("LetterNo_V")%></a>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2342;&#2367;&#2344;&#2366;&#2325;" DataField="Date_D" />
                                <asp:TemplateField HeaderText="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2349;&#2375;&#2332;&#2375; ">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("ChallanNo_V") %>' />
                                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Visible='<%# Eval("DepoSendstatus").ToString()=="1" ? false  : true %>' Text="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2349;&#2375;&#2332;&#2375; " />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>



    </div>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none;" class="popupnew" runat="server">
        <h2></h2>
        <div class="msg MT10">
            <table class="tab" width="100%">
                <tr>
                    <td>चालान नंबर </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    <td>OTP नो.
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpt" runat="server"></asp:TextBox></td>

                </tr>
                <tr>
                    <td colspan="4">

                        <asp:Button ID="Button3" CssClass="btn" runat="server" Text="सुरक्षित करें " OnClick="Button3_Click" />

                        <asp:Button ID="Button2" CssClass="btn" runat="server" Text="बंद करें  " OnClick="Button4_Click" />

                    </td>

                </tr>
            </table>
        </div>
    </div>
</asp:Content>

