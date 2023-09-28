<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TenderRelatedInformation.aspx.cs" Inherits="Paper_TenderRelatedInformation"
    Title="Tender Related Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>
                    <%--Tender Related Information--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368;
                    &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </span>
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
                        <%--Name of Work --%>&#2325;&#2366;&#2352;&#2381;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNameOfWork" Width="250px" MaxLength="150" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaOnly(event, this)"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Type--%>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderType" Width="262px" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                              <asp:ListItem Value="1" Text="QCBS"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Rate Contract"></asp:ListItem>
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
                        <asp:TextBox runat="server" ID="txtRFPNo" Width="250px" MaxLength="30" CssClass="txtbox reqirerd" onkeypress="javascript:tbx_fnAlphaNumericOnly(event, this)"></asp:TextBox>
                    </td>
                    <td>
                        <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        <cc1:MaskedEditExtender ID="txtBookingDate0_MaskedEditExtender" runat="server"  MaskType="Date" CultureName="en-GB" TargetControlID="txtDate" Mask="99/99/9999">
                                   </cc1:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339;
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtDetails" TextMode="MultiLine" MaxLength="250" onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"
                            CssClass="txtbox reqirerd"></asp:TextBox>
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
                        <asp:TextBox runat="server" ID="txtEMD" Width="250px" MaxLength="6" CssClass="txtbox reqirerd" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' ></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Fee (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360; (&#2352;&#2369;&#2346;&#2351;&#2375;
                        &#2350;&#2375; )
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderFee" Width="250px" onkeyup='javascript:tbx_fnSignedNumericCheck(this);' 
                            MaxLength="7" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtTenderSubDt" Width="250px" MaxLength="10" 
                            CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTenderSubDt" Format="dd/MM/yyyy">
                     </cc1:CalendarExtender>
                        
                        <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server"  MaskType="Date" CultureName="en-GB" TargetControlID="txtTenderSubDt" Mask="99/99/9999">
                                   </cc1:MaskedEditExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="255px"  onkeypress="MaxLengthCount(this,100);javascript:tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Upload RFP (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2309;&#2346;&#2354;&#2379;&#2337;
                        &#2325;&#2352;&#2375;
                    </td>
                    <td colspan="3">
                        <asp:FileUpload runat="server" ID="fileUp1" Width="250px"></asp:FileUpload>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
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
    
</asp:Content>
