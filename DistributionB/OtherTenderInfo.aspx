<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="OtherTenderInfo.aspx.cs" Inherits="DistributionB_OtherTenderInfo"
    Title="" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>
                    &nbsp;&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </span>
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
                        <%--Name of Work --%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtNameOfWork" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Type--%>
                        &#2335;&#2375;&#2306;&#2337;&#2352;</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlTenderType" Width="262px" CssClass="txtbox">
                           
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--RFP No. --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtRFPNo" Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Date --%><%--&#2310;&#2352;.&#2319;&#2347;.&#2346;&#2368;.(--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                      
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;(&#2325;&#2348; &#2360;&#2375;)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtInsuranceDateFrom" Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender2" runat="server" TargetControlID="txtInsuranceDateFrom"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                       
                    </td>
                    <td>
                        &nbsp;&#2342;&#2367;&#2344;&#2366;&#2306;&#2325;(&#2325;&#2348; &#2340;&#2325;)
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtInsuranceDateTo" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                         <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtInsuranceDateTo"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                         
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
                        <%--Upload RFP (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2309;&#2346;&#2354;&#2379;&#2337; &#2325;&#2352;&#2375;
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
                        &#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtEMD" Width="250px" MaxLength="6" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        <%--Tender Fee (--%>&#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2346;&#2381;&#2352;&#2346;&#2340;&#2381;&#2352; &#2325;&#2368; &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderFee" Width="250px" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'
                            MaxLength="6" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--Submission Date (--%>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2309;&#2306;&#2340;&#2367;&#2350; &#2340;&#2367;&#2341;&#2367;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderSubDt" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtTenderSubDt"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                       
                    </td>
                     <td>
                         &#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2360;&#2350;&#2351; &#2360;&#2368;&#2350;&#2366;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTenderSubTime" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="MaskedEditExtender3" TargetControlID="txtTenderSubTime"
                            Mask="99:99:99" MaskType="Time" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditValidator2" ControlExtender="MaskedEditExtender2"
                            ControlToValidate="txtTenderSubTime" IsValidEmpty="false" EmptyValueMessage="Time is required."></cc1:MaskedEditValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;">
                        &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375; &#2325;&#2368; &#2340;&#2367;&#2341;&#2367;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtTechnicalDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                       <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtTechnicalDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                        
                    </td>
                    <td>
                        &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2379;&#2354;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351;
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
                        &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtCommDate" Width="250px" MaxLength="10" CssClass="txtbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtCommDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                      
                    </td>
                    <td>
                        &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344; &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351;
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
                    <td colspan="1" style="height: 10px;">
                        &#2335;&#2367;&#2346;&#2381;&#2346;&#2339;&#2368;/ Remark</td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtRemark" TextMode="MultiLine" Width="255px" MaxLength="150"
                            onkeypress="MaxLengthCount('ContentPlaceHolder1_txtRemark',150);tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <strong>&#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;">
                        &#2346;&#2366;&#2352;&#2381;&#2335;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtName" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        &#2346;&#2340;&#2366;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAddres" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" style="height: 10px;">
                        &#2325;&#2366;&#2306;&#2335;&#2375;&#2325;&#2381;&#2335; &#2344;&#2306;&#2348;&#2352;
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtConatac" onkeypress="tbx_fnAlphaNumeric(event, this);"
                            Width="250px" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
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
                <tr>
                    <td colspan="4" style="height: 10px;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                <asp:BoundField DataField="TenderName" HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                <asp:BoundField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " DataField="TenderA" />
                                <asp:BoundField DataField="TenderNo" HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;." />
                                <asp:BoundField DataField="TenderDate" HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="TenderDetails" HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339; " />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
