<%@ Page Title="&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Allotment Details"
    Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PTG_TechnicalChart.aspx.cs" Inherits="PTG_TechnicalChart" MaintainScrollPositionOnPostback="true" ValidateRequest="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .reqirerd {
            height: 22px;
        }


        .tablebordered {
            border-right: 1px solid #444;
            border-bottom: 1px solid #444;
            width: 100%;
            margin-bottom: 10px;
        }

            .tablebordered td {
                vertical-align: middle;
                border-top: 1px solid #444;
                border-left: 1px solid #444;
                height: 30px;
                text-align: center;
                padding: 0px;
            }

            .tablebordered input[type="text"] {
                width: 90% !important;
                border: transparent;
                height: 16px;
            }

            .tablebordered .tablebordered2 input[type="text"] {
                width: 90% !important;
            }

        .tablebordered1 input[type="text"] {
            width: 45% !important;
            border: 1px solid #b4b4b4;
            height: 16px;
        }

        .tablebordered1 select {
            width: 40% !important;
            padding: 0px !important;
        }

        .tablebordered > tbody > tr > th {
            background: #444;
            color: #fff;
            border: 1px solid #444;
            padding: 6px;
            font-weight: bold;
            text-align: center;
        }

        .tablebordered .thh {
            border-bottom-color: #eee;
            border-right-color: #eee;
        }

        .btn {
            display: inline-block;
            margin-bottom: 0;
            font-weight: 400;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            -ms-touch-action: manipulation;
            touch-action: manipulation;
            cursor: pointer;
            background-image: none;
            border: 1px solid transparent;
            padding: 6px 12px;
            font-size: 14px;
            line-height: 1.42857143;
            border-radius: 4px;
            -webkit-user-select: none;
            -moz-user-select: none;
            -ms-user-select: none;
            user-select: none;
        }

        .btn-danger {
            color: #fff;
            background-color: #d9534f;
            border-color: #d43f3a;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Paper Allotment Detail--%>&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;
                    &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;  / Paper Allotment Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>
                        <%--Academic Year  --%>
                        &#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAcadmicYear" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlAcadmicYear_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Name of the Printer--%>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366;
                        &#2344;&#2366;&#2350; / Name of the Printer
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrinterName" runat="server" CssClass="txtbox reqirerd" AutoPostBack="True" OnSelectedIndexChanged="ddlPrinterName_SelectedIndexChanged1">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table class="tablebordered tablebordered1">
                            <tr>
                                <td style="width: 100px; text-align: left; padding-left: 5px;">क्षमता टन में </td>
                                <td colspan="2" style="text-align: center">शीट ऑफ</td>
                                <td colspan="6" style="text-align: center">वैब ऑफसेट कट ऑफ 578 / 560 / 546</td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; text-align: left;">SIZE 20X27</td>
                                <td>चार रंगीय</td>
                                <td>No. of Machine</td>
                                <td>एक रंगीय</td>
                                <td>No. of Machine</td>
                                <td>दो रंगीय</td>
                                <td>No. of Machine</td>
                                <td>चार रंगीय</td>
                                <td>No. of Machine</td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; text-align: left;">आंकलित क्षमता</td>
                                <td>
                                    <asp:TextBox ID="txtECFour_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewFour_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineFour_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtECOne_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewOne_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineOne_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtECTwo_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewTwo_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineTwo_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtECFour2_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewFour2_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineFour2_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; text-align: left;">डेढ़ गुनी क्षमता</td>
                                <td>
                                    <asp:TextBox ID="txtOHCFour_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewFour_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineFour_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOHCOne_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewOne_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineOne_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtOHCTwo_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewTwo_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineTwo_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtOHCFour2_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewFour2_2027" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineFour2_2027" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                        </table>

                        <table class="tablebordered tablebordered1">
                            <tr>
                                <td style="width: 100px; text-align: left; padding-left: 5px;">क्षमता टन में </td>
                                <td colspan="2" style="text-align: center">शीट ऑफ</td>
                                <td colspan="6" style="text-align: center">वैब ऑफसेट कट ऑफ 508</td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; text-align: left;">SIZE 17X24</td>
                                <td>चार रंगीय</td>
                                <td>No. of Machine</td>
                                <td>एक रंगीय</td>
                                <td>No. of Machine</td>
                                <td>दो रंगीय</td>
                                <td>No. of Machine</td>
                                <td>चार रंगीय</td>
                                <td>No. of Machine</td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; text-align: left;">आंकलित क्षमता</td>
                                <td>
                                    <asp:TextBox ID="txtECFour_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewFour_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineFour_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtECOne_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewOne_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineOne_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtECTwo_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewTwo_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineTwo_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtECFour2_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlECOldNewFour2_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtECNoOfMachineFour2_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-left: 5px; text-align: left;">डेढ़ गुनी क्षमता</td>
                                <td>
                                    <asp:TextBox ID="txtOHCFour_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewFour_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineFour_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOHCOne_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewOne_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineOne_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtOHCTwo_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewTwo_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineTwo_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>

                                <td>
                                    <asp:TextBox ID="txtOHCFour2_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                    <asp:DropDownList ID="ddlOHCOldNewFour2_1724" runat="server">
                                        <asp:ListItem Value="Old">Old</asp:ListItem>
                                        <asp:ListItem Value="New">New</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="tablebordered2">
                                    <asp:TextBox ID="txtOHCNoOfMachineFour2_1724" runat="server" CssClass="txtbox" autocomplete="off" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <h3 style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">A: 4 Colour Sheet</h3>
                        <asp:GridView ID="grdFourColourSheet" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                            OnRowCreated="grdFourColourSheet_RowCreated" CssClass="tablebordered">
                            <Columns>
                                <asp:TemplateField HeaderText="ग्रुप क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ई.एम.डी.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEMD" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का वरीयता क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupPriorityNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का टनेज">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupTanej" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity (177)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="BtnAddFourColourSheet" runat="server" Text="Add New Row" OnClick="BtnAddFourColourSheet_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="55px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBtnFourColourSheet" runat="server" OnClick="LBtnFourColourSheet_Click">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td colspan="2">
                        <h3 style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">A: 4 Colour Reel</h3>
                        <asp:GridView ID="grdFourColourReel" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                            OnRowCreated="grdFourColourReel_RowCreated" CssClass="tablebordered">
                            <Columns>
                                <asp:TemplateField HeaderText="ग्रुप क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ई.एम.डी.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEMD" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का वरीयता क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupPriorityNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का टनेज">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupTanej" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity (177)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="BtnAddFourColourReel" runat="server" Text="Add New Row" OnClick="BtnAddFourColourReel_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="55px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBtnFourColourReel" runat="server" OnClick="LBtnFourColourReel_Click">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h3 style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">A: 2 Colour Reel</h3>
                        <asp:GridView ID="grdTwoColourReel" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                            OnRowCreated="grdTwoColourReel_RowCreated" CssClass="tablebordered">
                            <Columns>
                                <asp:TemplateField HeaderText="ग्रुप क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ई.एम.डी.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEMD" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का वरीयता क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupPriorityNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का टनेज">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupTanej" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity (177)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="BtnAddTwoColourReel" runat="server" Text="Add New Row" OnClick="BtnAddTwoColourReel_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="55px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBtnTwoColourReel" runat="server" OnClick="LBtnTwoColourReel_Click">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td colspan="2">
                        <h3 style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">A: 1 Colour Reel 578</h3>
                        <asp:GridView ID="grdOneColourReel" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                            OnRowCreated="grdOneColourReel_RowCreated" CssClass="tablebordered">
                            <Columns>
                                <asp:TemplateField HeaderText="ग्रुप क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ई.एम.डी.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEMD" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का वरीयता क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupPriorityNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का टनेज">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupTanej" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity (177)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="BtnAddOneColourReel" runat="server" Text="Add New Row" OnClick="BtnAddOneColourReel_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="55px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBtnOneColourReel" runat="server" OnClick="LBtnOneColourReel_Click">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <h3 style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">A: 2 Colour Reel 508</h3>
                        <asp:GridView ID="grdTwoColourReel_508" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                            OnRowCreated="grdTwoColourReel_508_RowCreated" CssClass="tablebordered">
                            <Columns>
                                <asp:TemplateField HeaderText="ग्रुप क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ई.एम.डी.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEMD" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का वरीयता क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupPriorityNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का टनेज">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupTanej" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity (177)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="BtnAddTwoColourReel_508" runat="server" Text="Add New Row" OnClick="BtnAddTwoColourReel_508_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="55px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBtnTwoColourReel_508" runat="server" OnClick="LBtnTwoColourReel_508_Click">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                    <td colspan="2">
                        <h3 style="font-size: 16px; font-weight: bold; margin-bottom: 10px;">A: 1 Colour Reel 508</h3>
                        <asp:GridView ID="grdOneColourReel_508" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                            OnRowCreated="grdOneColourReel_508_RowCreated" CssClass="tablebordered">
                            <Columns>
                                <asp:TemplateField HeaderText="ग्रुप क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ई.एम.डी.">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtEMD" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का वरीयता क्रमांक">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupPriorityNo" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ग्रुप का टनेज">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtGroupTanej" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Capacity (177)">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                        <asp:Button ID="BtnAddOneColourReel_508" runat="server" Text="Add New Row" OnClick="BtnAddOneColourReel_508_Click" />
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" HeaderStyle-Width="55px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LBtnOneColourReel_508" runat="server" OnClick="LBtnOneColourReel_508_Click">Remove</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr runat="server">
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click"  />
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375; / Add "
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <script>
        function validateNum(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
        function validateform() {
            var msg = "";
            //if (document.getElementById('ddlColumns').selectedIndex == 0) {
            //    msg += "Select Columns \n";
            //}
            if (document.getElementById('txtRows').value.trim() == "") {
                msg += "Enter Rows \n";
            }
            if (msg != "") {
                alert(msg);
                return false;
            }
            else {
                createtable();
            }
        }
    </script>
</asp:Content>
