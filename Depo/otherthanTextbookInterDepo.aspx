<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="otherthanTextbookInterDepo.aspx.cs" Inherits="Depo_otherthanTextbookInterDepo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box">
        <div class="card-header">
            <h2>अंतरडिपो बुक प्राप्ति  </h2>

        </div>
        <table style="width: 100%" id="aaa" runat="server">
            <tr>
                <td colspan="4">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ID" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("PrinterID") %>' />
                                     <asp:HiddenField ID="HiddenField3" runat="server" Value='<%# Eval("SubTitleID") %>' />
                                    <asp:HiddenField ID="HiddenField5" runat="server" Value='<%# Eval("ChallanNO") %>' />
                                    
                                 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />
                            <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" DataField="ChallanNO" />
                            <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataField="challandate" />
                            <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="Title" />
                            <asp:BoundField HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="PrdadayBooks" />

                            <asp:CommandField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2352;&#2375; " ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr></table>  <table style="width: 100%" id="aa" runat="server" visible="false" >
            <tr>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;</td>
                <td>
                    <asp:Label ID="lblChallan" runat="server"></asp:Label>
                </td>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                <td>
                    <asp:Label ID="lblChallanDate" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:Label ID="lblPrinterName" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </td>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                <td>
                    <asp:Label ID="lblBookName" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2349;&#2375;&#2332;&#2375; &#2327;&#2351;&#2375; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;</td>
                <td>
                    <asp:Label ID="lblBook" runat="server"></asp:Label>
                </td>
                <td>मुद्रक द्वारा भेजे गए &#2348;&#2339;&#2381;&#2337;&#2354;</td>
                <td>
                    <asp:Label ID="lblbundel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>प्रति बंडल पुस्तक संख्या </td>
                <td>
                    <asp:Label ID="lblBook0" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </td>
            </tr>
            <tr>
                <td>&#2327;&#2379;&#2342;&#2366;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                    <asp:DropDownList ID="ddlWarehouse" runat="server">
                    </asp:DropDownList>
                </td>
                <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                    <asp:TextBox ID="txtReceivdate" runat="server" Enabled="False"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtReceivdate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
                </td>
            </tr>
            <tr>
                <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; </td>
                <td>
                    <asp:TextBox ID="txtBiltiNo" runat="server"></asp:TextBox>
                </td>
                <td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                    <asp:TextBox ID="txtBilltiDate" runat="server"></asp:TextBox>
                     <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtBilltiDate" Format="dd/MM/yyyy">
        </cc1:CalendarExtender>
       
                </td>
            </tr>
            <tr>
                <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; </td>
                <td>
                    <asp:TextBox ID="txtTruck" runat="server"></asp:TextBox>
                </td>
                <td>&#2313;&#2340;&#2352;&#2366;&#2312;</td>
                <td>
                    <asp:TextBox ID="txtUnloading" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>प्राप्त पुस्तक संख्या </td>
                <td>
                    <asp:TextBox ID="txtTotalBook" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlEmployee" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:HiddenField ID="HiddenField4" runat="server" />
                    <asp:HiddenField ID="HiddenField6" runat="server" />
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

