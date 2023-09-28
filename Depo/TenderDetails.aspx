<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderDetails.aspx.cs" Inherits="Depo_TenderDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Tender Related Information--%>&nbsp;टेंडर की जानकारी</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Name of Work --%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNameOfWork" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="150" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Type--%>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderType" Width="262px" CssClass="txtbox">
                            <asp:ListItem Value="0" Text="TextBook"></asp:ListItem>
                            <asp:ListItem Value="1" Text="Paper"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--RFP No. --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                        &#2325;&#2381;&#2352;.
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRFPNo" Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>

                    </td>
                    <td>
                        <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="ccextendtxtTenderDate" TargetControlID="txtDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDetails" TextMode="MultiLine" Width="255px" MaxLength="250"
                            CssClass="txtbox reqirerd" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtDetails',250);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                     <td>
                        <%--Upload RFP (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2309;&#2346;&#2354;&#2379;&#2337;
                        &#2325;&#2352;&#2375;
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fileUp1" Width="250px"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--EMD. (--%>
                        &#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375;
                        &#2350;&#2375; )
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEMD" Width="250px" MaxLength="12" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360; (&#2352;&#2369;&#2346;&#2351;&#2375;
                        &#2350;&#2375; )
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderFee" Width="250px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            MaxLength="12" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%-- Anual stock--%>
                        स्टॉक का अनुमानित मूल्य(रुपये करोड़ में)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAnualStock" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="5" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderSubDt" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="ccextendtxtTenderSubDt" TargetControlID="txtTenderSubDt"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                               
                    </td>
                </tr>
                <tr>
                    <td>
                        तकनीकी बिड खुलने की दिनांक
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTechnicalBid" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="ccextendtxtTechnicalBid" TargetControlID="txtTechnicalBid"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                              
                    </td>
                    <td>
                        कमर्शियल बिड खुलने की दिनांक
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCommercialBid" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                             <cc1:CalendarExtender ID="ccextendtxtCommercialBid" TargetControlID="txtCommercialBid"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
                    </td>
                    <td colspan="3">
                        <%--Remark (--%>
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="255px" MaxLength="150"
                            onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td colspan="3">
                        <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                            CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:HiddenField ID="hdnFile" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <cc1:CalendarExtender ID="CetxtTenderSubDt" runat="server" TargetControlID="txtTenderSubDt"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
    <cc1:CalendarExtender ID="CetxtDate" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

