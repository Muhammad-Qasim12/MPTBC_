<%@ Page Title="&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="DIB_010_DistributionOrder.aspx.cs" Inherits="DistributionB_Default" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
             <table width="100%">
                <tr>
                <td>
                &nbsp;&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                    <td>
                        <asp:DropDownList ID="ddlAcYr" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td>
                             &#2327;&#2381;&#2352;&#2369;&#2346;</td>
                <td>
                    <asp:DropDownList ID="ddlGroup" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>
                </td>
                </tr>
                <tr>
                <td>
                    &#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
                    <td>
                        <asp:TextBox ID="txtLetterNo" runat="server" 
                            onkeypress='javascript:tbx_fnSignedNumeric(event, this);' 
                            CssClass="txtbox" MaxLength="15"></asp:TextBox>
                    </td>
                    <td>
                        &#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                <td>
                           <asp:TextBox ID="txtLetterDate" MaxLength="12" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>

                        <cc1:calendarextender ID="ccextendtxtLetterDate" TargetControlID="txtLetterDate"
                          Format="dd/MM/yyyy"   runat="server">
                        </cc1:calendarextender>
                    </td>
                </tr>
                <tr>
                <td>
                    &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</td>
                    <td>
                        <asp:DropDownList ID="ddlTitle" runat="server" CssClass="txtbox reqirerd" 
                            onselectedindexchanged="ddlTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                    &#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</td>
                <td>
                        <asp:DropDownList ID="ddlSubTitle" runat="server" CssClass="txtbox reqirerd" 
                            onselectedindexchanged="ddlSubTitle_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                <td>
                    &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;</td>
                    <td>
                        <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                        <asp:DropDownList ID="ddlDepo" runat="server" CssClass="txtbox reqirerd">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                <td>
                    &#2346;&#2381;&#2352;&#2340;&#2367; &#2327;&#2337;&#2381;&#2337;&#2368; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                    <td>
                        <asp:TextBox ID="txtPerGaddiTitle" runat="server" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' CssClass="txtbox"></asp:TextBox>
                    </td>
                    <td>
                        &#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2339;&#2381;&#2337;&#2354; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                <td>
                    <asp:TextBox ID="txtPerBundleTitles"  onkeypress='javascript:tbx_fnSignedNumeric(event, this);' CssClass="txtbox" runat="server"></asp:TextBox>
                </td>
                </tr>
                <tr>
                <td>
                    &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" 
                            Text="&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375;&#2306;" />
                    </td>
                <td>
                    &nbsp;</td>
                </tr>
                <tr>
                <td colspan="4">
                    <asp:GridView ID="GrdDisOrder" runat="server" AutoGenerateColumns="False" 
                        CssClass="tab">
                        <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %></ItemTemplate>
                                            </asp:TemplateField>
                            <asp:BoundField DataField="" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                            <asp:BoundField DataField="" HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                            <asp:TemplateField HeaderText="&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemark" MaxLength="30" runat="server"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
                </tr>
                <tr>
                <td>
                    &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
                </tr>
                <tr>
                <td>
                    &nbsp;</td>
                    <td>
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" />
                    </td>
                    <td>
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
                </tr>
                <tr>
                <td>
                    &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                <td>
                    &nbsp;</td>
                </tr>
                </table>
        </div>
    </div>
</asp:Content>
