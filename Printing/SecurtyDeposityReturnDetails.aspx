<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SecurtyDeposityReturnDetails.aspx.cs" Inherits="Depo_SecurtyDeposityReturnDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>सिक्योरिटी डिपाजिट वापसी की जानकारी</h2>
            </div>
        <div class="card-body">
            
            <div class="row g-3">
                <%--<div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False">
                            <asp:ListItem Value="0">Select...</asp:ListItem>
                            <asp:ListItem Value="1">Transporter </asp:ListItem>
                            <asp:ListItem Value="2">WareHouse</asp:ListItem>
                            <asp:ListItem Value="3">BookSelller Name</asp:ListItem>
                                 <asp:ListItem Value="5">Printer</asp:ListItem>
                            <asp:ListItem Value="4">Other</asp:ListItem>                         
                        </asp:DropDownList>
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                        <label>पार्टी नाम</label>
                    </div>
                </div>--%>
                <div class="col-md-12">
                    <asp:GridView ID="GrdPrinterId" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-bordered table-hover" DataKeyNames="Printer_regid_i" AllowPaging="True" PageSize="120">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Printer Name" DataField="NameofPressHindi_V" />
                            <asp:BoundField HeaderText="Address"
                                DataField="FullAddress_V" />
                            <asp:BoundField HeaderText="Registration  No." DataField="RegistrationNo_V" />
                            <asp:BoundField HeaderText="Registration Date" DataField="RegistrationDate_D" />

                            <asp:BoundField HeaderText="Security  Amount" DataField="RegistrationAmount_N" />

                            <asp:BoundField HeaderText="Mobile No." DataField="MobileNo_N" />

                            <asp:BoundField HeaderText="Security Return " DataField="returnamount" />



                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <table cellpadding="4" cellspacing="3" width="100%" style="display: none" runat="Server" id="aa">
                        <tr>
                            <td>&#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2344;&#2366;&#2350; /Party Name</td>
                            <td>
                                <asp:Label ID="lblPartyName" runat="server" CssClass="txtbox"></asp:Label>
                            </td>
                            <td>&#2309;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2344;&#2306;&#2348;&#2352; /Agrement No/Reg.No</td>
                            <td>
                                <asp:Label ID="lblagrement" runat="server" CssClass="txtbox"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2352;&#2366;&#2358;&#2368; /Security Amount</td>
                            <td>
                                <asp:Label ID="lblSecurityAmount" runat="server" CssClass="txtbox"></asp:Label>
                            </td>
                            <td>&#2350;&#2366;&#2354;&#2367;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Owner Name</td>
                            <td>
                                <asp:Label ID="lblOwnerName" runat="server" CssClass="txtbox "></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2360;&#2306;&#2346;&#2352;&#2381;&#2325; &#2360;&#2370;&#2340;&#2381;&#2352; /Contact No</td>
                            <td>
                                <asp:Label ID="lblContractNo" runat="server" CssClass="txtbox"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&#2319;&#2344;.&#2323;.&#2360;&#2368;.&#2344;&#2306;&#2348;&#2352; /NOC No</td>
                            <td>
                                <asp:TextBox ID="txtNoc" runat="server" CssClass="txtbox"></asp:TextBox>
                            </td>
                            <td>&#2319;&#2344;.&#2323;.&#2360;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /NOC Date</td>
                            <td>
                                <asp:TextBox ID="txtNocDate" runat="server" CssClass="txtbox"></asp:TextBox>

                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtNocDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>

                            </td>
                        </tr>
                        <tr>
                            <td>&#2319;&#2344;.&#2323;.&#2360;&#2368;.&#2309;&#2346;&#2354;&#2379;&#2337; /NOC Upload </td>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&#2346;&#2340;&#2381;&#2352; &#2344;&#2306;&#2348;&#2352; /Letter No</td>
                            <td>
                                <asp:TextBox ID="txtLetterNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                            <td>&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Letter date</td>
                            <td>
                                <asp:TextBox ID="txtLetterDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLetterDate" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>


                            </td>
                        </tr>
                        <tr>
                            <td>&#2357;&#2366;&#2346;&#2360;&#2368; &#2352;&#2366;&#2358;&#2368; /Return Amount</td>
                            <td>
                                <asp:TextBox ID="txtRamount" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                            <td>&#2348;&#2376;&#2306;&#2325; &#2344;&#2366;&#2350; /Bank Name</td>
                            <td>
                                <asp:TextBox ID="txtBankNaem" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2337;&#2368;.&#2337;&#2368;. &#2344;&#2306;&#2348;&#2352;  /DD No </td>
                            <td>
                                <asp:TextBox ID="txtDDNo" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                            </td>
                            <td>&#2337;&#2368;.&#2337;&#2368;. &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/DD Date</td>
                            <td>
                                <asp:TextBox ID="txtDDdate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDDdate" Format="dd/MM/yyyy">
                                </cc1:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <%--    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Save" OnClick="Button1_Click" OnClientClick="return ValidateAllTextForm();"/>--%>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

