<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="InspectionByTBC.aspx.cs" Inherits="Paper_InspectionByTBC" Title="Inspection By TBC" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Inspection By TBC--%>TBC &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339;
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td>
                        <%--Date of Inspection (--%>&#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339;
                    &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtInspectionDate" onkeypress="tbx_fnAlphaNumeric(event, this);" CssClass="txtbox reqirerd" MaxLength="10"
                            Width="240px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Inspection type (--%>&#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339;
                    &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                    </td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rbInspectiontype" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="&#2332;&#2344;&#2352;&#2354; &#2311;&#2306;&#2360;&#2381;&#2346;&#2375;&#2325;&#2381;&#2358;&#2344;(&#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339;)" Selected="True" Value="1"></asp:ListItem>
                            <asp:ListItem Text="&#2325;&#2381;&#2357;&#2366;&#2354;&#2367;&#2335;&#2368; &#2311;&#2306;&#2360;&#2381;&#2346;&#2375;&#2325;&#2381;&#2358;&#2344;(&#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339;)" Value="2"></asp:ListItem>

                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Officer name (--%>&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366;
                    &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlOfficeName" runat="server" AutoPostBack="True" OnInit="ddlOfficeName_Init"
                            OnSelectedIndexChanged="ddlOfficeName_SelectedIndexChanged" Width="250px">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Designation (--%>&#2346;&#2342;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDesignation" Width="250px" onkeypress="tbx_fnAlphaNumeric(event, this);" Enabled="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnADD" Width="200px" CssClass="btn" Text="&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;  "
                            OnClick="btnADD_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdOfficerDetail" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." Width="100%"
                            AllowPaging="false" OnRowDataBound="GrdOfficerDetail_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--      <asp:TemplateField HeaderText="&#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; ">
                                <ItemTemplate>
                                    <asp:Label ID="lblInspectionDate" runat="server" Text='<%#Eval("InspectionDate") %>'></asp:Label>    
                                    
                                    
                                </ItemTemplate>

                            </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="&#2309;&#2343;&#2367;&#2325;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOfficeid" Visible="false" runat="server" Text='<%#Eval("Officeid") %>'></asp:Label>
                                        <asp:Label ID="lblOfficeName" runat="server" Text='<%#Eval("OfficeName") %>'></asp:Label>
                                        <asp:Label ID="lblInspectionOfficerTrId_I" Visible="false" runat="server" Text='<%#Eval("InspectionOfficerTrId_I") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2342;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPost" runat="server" Text='<%#Eval("Post") %>'></asp:Label>
                                        <asp:Label ID="lblOfficerDesignation_I" Visible="false" runat="server" Text='<%#Eval("OfficerDesignation_I") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>

                                        <asp:LinkButton ID="lnkUpdate" OnClick="lnkUpdate_Click" runat="server">&#2337;&#2366;&#2335;&#2366; &#2350;&#2375;&#2306; &#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</asp:LinkButton>


                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" OnClick="lnkDelete_Click" OnClientClick="javascript:return confirm('Are you sure to delete ?')" runat="server" Visible="false">&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375;</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
                <tr>
                    <td>&#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339; &#2325;&#2366; &#2360;&#2381;&#2340;&#2352;</td>
                    <td>

                        <asp:DropDownList ID="ddlInspectionLevel" runat="server" Width="250px"
                            AutoPostBack="True"
                            OnSelectedIndexChanged="ddlInspectionLevel_SelectedIndexChanged">
                            <asp:ListItem Value="1">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2360;&#2381;&#2340;&#2352; &#2346;&#2352;</asp:ListItem>
                            <asp:ListItem Value="2">&#2350;&#2367;&#2354; &#2360;&#2381;&#2340;&#2352; &#2346;&#2352;</asp:ListItem>
                            <asp:ListItem Value="3">&#2325;&#2375;&#2306;&#2342;&#2381;&#2352;&#2368;&#2351; &#2337;&#2367;&#2346;&#2379; &#2360;&#2381;&#2340;&#2352; &#2346;&#2352;</asp:ListItem>
                            <asp:ListItem Value="4">&#2309;&#2344;&#2381;&#2351; &#2360;&#2381;&#2340;&#2352; &#2346;&#2352;</asp:ListItem>
                        </asp:DropDownList></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr id="trINspectionName" runat="server" visible="false">
                    <td>&#2344;&#2367;&#2352;&#2368;&#2325;&#2381;&#2359;&#2339; &#2360;&#2381;&#2340;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                        <asp:TextBox ID="txtInspectionName" runat="server" MaxLength="100" onkeypress="tbx_fnAlphaNumeric(event, this);" Width="240px" CssClass="txtbox reqirerd"></asp:TextBox></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <%--LOI No. (--%>&#2319;&#2354;.&#2323;.&#2310;&#2312;. &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlLOINo" Width="250px" CssClass="txtbox reqirerd"
                            OnInit="ddlLOINo_Init" AutoPostBack="True" OnSelectedIndexChanged="ddlLOINo_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;
                    </td>
                    <td>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Paper type (--%>&#2325;&#2366;&#2327;&#2332; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPaperType" Width="250px" CssClass="txtbox reqirerd"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlPaperType_SelectedIndexChanged">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <%--Paper Size (--%> &#2325;&#2366;&#2327;&#2332; &#2310;&#2325;&#2366;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPaperSize" CssClass="txtbox reqirerd" Width="250px">
                            <asp:ListItem Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Inspection Report (--%>&#2344;&#2367;&#2352;&#2367;&#2325;&#2381;&#2359;&#2339;
                    &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" MaxLength="200" Width="250px" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',200);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                    <td>
                        <%--Upload &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;  (--%>
                    &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2309;&#2346;&#2354;&#2379;&#2337;
                    &#2325;&#2352;&#2375;
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fileUp1"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                            CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />

                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:HiddenField ID="hdnFile" runat="server" />
                        <asp:HiddenField ID="hdChildId" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td colspan="4" style="height: 10px;"></td>
                </tr>
            </table>
        </div>
    </div>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInspectionDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>
