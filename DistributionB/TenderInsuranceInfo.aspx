<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TenderInsuranceInfo.aspx.cs" Inherits="DistributionB_TenderInsuranceInfo"
    Title="&#2348;&#2368;&#2350;&#2366; &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    <%--Tender Related Information--%>&#2348;&#2368;&#2350;&#2366; &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Information of Insurance Tender</span>
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
                        <%--Name of Work --%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; /Name of Tender
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNameOfWork" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Type--%>
                        बीमित सामग्री का विवरण/ Type of Insurance
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderType" OnSelectedIndexChanged="ddlTenderType_SelectedIndexChange" AutoPostBack="true" Width="262px" CssClass="txtbox">
                            <asp:ListItem Value="-1" Text="Select.."></asp:ListItem>
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
                        &#2325;&#2381;&#2352;./ Tender No.
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRFPNo" Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352;
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Tender Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Insurance Date(From). --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>
                        &#2348;&#2368;&#2350;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;(&#2325;&#2348; &#2360;&#2375;)
                        / Insurance From Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtInsuranceDateFrom" Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender2" runat="server" TargetControlID="txtInsuranceDateFrom"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                         
                    </td>
                    <td>
                        <%--Insurance Date(To) --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>
                        &#2348;&#2368;&#2350;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;(&#2325;&#2348; &#2340;&#2325;)
                        / Insurance To Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtInsuranceDateTo" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInsuranceDateTo"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                         
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Details (--%>&#2357;&#2367;&#2357;&#2352;&#2339; / Tender Details
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDetails" TextMode="MultiLine" Width="255px" MaxLength="250"
                            CssClass="txtbox reqirerd" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtDetails',250);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                     <td>
                        <%--Upload RFP (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2309;&#2346;&#2354;&#2379;&#2337;
                        &#2325;&#2352;&#2375; / Upload RFP
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
                        &#2350;&#2375; ) / EMD(Rs.)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEMD" Width="250px" MaxLength="6" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Fee (--%>निविदा प्रपत्र की राशि (&#2352;&#2369;&#2346;&#2351;&#2375;
                        &#2350;&#2375; ) / Tender Fee(Rs.)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderFee" Width="250px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            MaxLength="6" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                       <td>
                        <%-- Anual stock--%>
                        &#2360;&#2381;&#2335;&#2377;&#2325; &#2325;&#2366; &#2309;&#2344;&#2369;&#2350;&#2366;&#2344;&#2367;&#2340; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2351;&#2375; &#2325;&#2352;&#2379;&#2396; &#2350;&#2375;&#2306;)
                           / Approx Anual stock (Rs. in Crore)
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtAnualStock" onkeypress="tbx_fnSignedNumeric(event, this);"
                            Width="250px" MaxLength="6" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Submission Date (--%>टेंडर जमा करने की अंतिम तिथि / Last Date of Tender Submission
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderSubDt" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtTenderSubDt"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                         
                    </td>
                     <td>
                     टेंडर जमा करने की समय सीमा / Time limit for Tender Submission
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderSubTime" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="MaskedEditExtender3" TargetControlID="txtTenderSubTime"
                            Mask="99:99:99" MaskType="Time" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                         
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;">
                        टेक्निकल बिड खोलने की तिथि / Opening Date of Techical Bid
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTechnicalDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                       <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtTechnicalDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                         
                    </td>
                    <td>
                        टेक्निकल बिड खोलने का समय / Opening Time of Technical Bid
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTechnicalTime" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="MaskedEditExtender2" TargetControlID="txtTechnicalTime"
                            Mask="99:99:99" MaskType="Time" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditValidator1" ControlExtender="MaskedEditExtender2"
                            ControlToValidate="txtTechnicalTime" IsValidEmpty="false" EmptyValueMessage="Time is required."></cc1:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;">
                      कमर्शियल बिड ओपन करने की दिनांक / Opening Date of Commercial Bid
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCommDate" Width="250px" MaxLength="10" CssClass="txtbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtCommDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                          
                    </td>
                    <td>
                        &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344;
                        &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351; / Opening Time of Commercial Bid
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCommTime" Width="250px" MaxLength="10" CssClass="txtbox"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="Time15" TargetControlID="txtCommTime"
                            Mask="99:99:99" MaskType="Time" ClearTextOnInvalid="true" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditExtender1" ControlExtender="Time15" 
                            ControlToValidate="txtCommTime" IsValidEmpty="true" EmptyValueMessage="Time is required."></cc1:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                  <td>
                        &#2337;&#2367;&#2346;&#2379;/Depo
                    </td>
                    <td>
                        <asp:CheckBox ID="chkAll" runat="server" OnCheckedChanged="chkAll_checkedChanged" Text="&#2360;&#2349;&#2368; &#2325;&#2379; &#2330;&#2369;&#2344;&#2375;&#2306;" AutoPostBack="true"/><br />
                        <asp:CheckBoxList ID="ddlDepo" runat="server"  RepeatColumns="3" CssClass="three-column-small">
                        </asp:CheckBoxList>
                    </td>
                    <td>
                        <%--Remark (--%>&#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;/ Remark
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="255px" MaxLength="150"
                            onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
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
