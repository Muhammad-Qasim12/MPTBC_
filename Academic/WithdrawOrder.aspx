<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WithdrawOrder.aspx.cs" 
    Inherits="Academic_WithdrawOrder" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                &#2346;&#2369;&#2344;&#2307; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2319;&#2357;&#2306; 100 % &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
             <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
                <span id="tmpSpan"></span>
            </asp:Panel>
            <table width="100%">
                <tr><td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</td><td>
                        <asp:DropDownList ID="DdlACYear" Width="250px"  runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                        </td><td>
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                OnClick="btnSearch_Click" />
                        </td></tr>
                <tr><td colspan="3">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No." HeaderStyle-Width="10px" >
                                        <ItemTemplate >
                                            <%# Container.DataItemIndex+1 %>
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:BoundField DataField="nameofpress_v" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%#Eval("PrintOrderdate") %>'></asp:TextBox>
                                     <cc1:CalendarExtender ID="ccextendTxtLetterDate" TargetControlID="TextBox1"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="100 % &#2325;&#2368;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                     <asp:TextBox ID="TextBox2" runat="server"  Text='<%#Eval("100PerDate") %>'></asp:TextBox>
                                    <cc1:CalendarExtender ID="cd" TargetControlID="TextBox2"
                                                Format="dd/MM/yyyy" runat="server">
                                            </cc1:CalendarExtender>
                                    <asp:HiddenField ID="hdPrinter_RedID_I" runat="server" Value='<%#Eval("Printer_RedID_I") %>' />
                                    <asp:HiddenField ID="hdTitleID_I" runat="server"  Value='<%#Eval("TitleID_I") %>'/>

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Button ID="Button1" runat="server" Text="Save" CssClass="btn" OnClick="Button1_Click" />
                    </td></tr>
                <tr><td colspan="3">
                    &nbsp;</td></tr>
                <tr><td colspan="3">
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab">
                        <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No." HeaderStyle-Width="10px" >
                                        <ItemTemplate >
                                            <%# Container.DataItemIndex+1 %>
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                            <asp:BoundField DataField="nameofpress_v" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                  <%#Eval("PrintOrderdate") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="100 % &#2325;&#2368;  &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                     <%#Eval("100PerDate") %>
                                   

                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    </td></tr>
            </table>
            </div> </div>
</asp:Content>

