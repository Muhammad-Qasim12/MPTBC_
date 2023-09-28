<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Billpayment.aspx.cs" Inherits="Depo_Billpayment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>&nbsp;&#2346;&#2352;&#2367;&#2357;&#2361;&#2344;&nbsp; &#2325;&#2375; &#2348;&#2367;&#2354;&nbsp; &#2325;&#2366; &#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label1" runat="server" ForeColor="#CC0000"></asp:Label>
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                    </td>
                </tr>
                <tr>
                    <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; <span>*</span>
                                    </td>
                    <td>
                                        <asp:DropDownList ID="ddlFyYear" runat="server" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)">
                                        </asp:DropDownList>

                    </td>
                    <td>&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name</td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                        </td>
                </tr>
                <tr>
                    <td colspan="4">

            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="BilltrNo" >
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField  DataField="TransportName_V" HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Transporter Name" />
                              <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2360;&#2381;&#2341;&#2366;&#2344; / Place" />
                                  <asp:BoundField DataField="BillNo" HeaderText="&#2348;&#2367;&#2354; &#2344;&#2306;&#2348;&#2352; / Bill No." />
                                <asp:BoundField DataField="Bdate" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date" />
                                <asp:BoundField DataField="BiltiNo" HeaderText="&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; / Bilti No. " />
                                <asp:BoundField DataField="BiltiD" HeaderText="&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Bilti Date" />
                                <asp:BoundField HeaderText="&#2357;&#2332;&#2344; &#2335;&#2344; &#2350;&#2375;&#2306; " DataField="NoofBandal" />
                                <asp:BoundField DataField="Amount" HeaderText="&#2327;&#2339;&#2344;&#2366;  &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; " />
                                
                                <asp:BoundField HeaderText="&#2348;&#2367;&#2354; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367; " DataField="TranAmount" />
                                
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("BilltrNo") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                            <EmptyDataTemplate>
                                Data Not Found............
                            </EmptyDataTemplate>
                        </asp:GridView>
                                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="auto-style1">
                            <tr>
                                <td>&#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367;</td>
                                <td>
                                    <asp:Label ID="lblGAmount" runat="server" CssClass="txtbox"></asp:Label>
                                </td>
                                <td>&#2348;&#2367;&#2354; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2352;&#2366;&#2358;&#2367;&nbsp;</td>
                                <td>
                                    <asp:Label ID="lblBAmount" runat="server" CssClass="txtbox"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                </td>
                                <td>&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                                <td>
                                    <asp:TextBox ID="txtKramank" runat="server" CssClass="txtbox" Enabled="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; &#2342;&#2375;&#2351;&#2325; &#2352;&#2366;&#2358;&#2367;</td>
                                <td>
                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="txtbox" onkeypress='javascript:tbx_fnNumeric(event, this);' AutoPostBack="True" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                </td>
                                <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                                <td>
                                    <asp:TextBox ID="txtbank" runat="server" CssClass="txtbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtCheckDate" runat="server" CssClass="txtbox"></asp:TextBox>
                                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtCheckDate" Format="dd/MM/yyyy">
                                         </cc1:CalendarExtender>
                                </td>
                                <td>&#2330;&#2375;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
                                <td>
                                    <asp:TextBox ID="txtCheck" runat="server" CssClass="txtbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtremark" runat="server" CssClass="txtbox" Height="47px" TextMode="MultiLine" Width="424px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClick="Button1_Click" Enabled="False" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                                <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TransportName_V" HeaderText="&#2335;&#2381;&#2352;&#2366;&#2306;&#2360;&#2346;&#2379;&#2352;&#2381;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                            <asp:BoundField DataField="PaymentNo" HeaderText="&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; " />
                                            <asp:BoundField DataField="PaymentDate" HeaderText="&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                            <asp:BoundField DataField="Payamount" HeaderText="&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367; " />
                                            <asp:BoundField DataField="BankName" HeaderText="&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                            <asp:BoundField DataField="CheckNo" HeaderText="&#2330;&#2375;&#2325; &#2344;&#2306;&#2348;&#2352;" />
                                            <asp:BoundField DataField="checkDate" HeaderText="&#2330;&#2375;&#2325; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr></table> </div> 
</asp:Content>

