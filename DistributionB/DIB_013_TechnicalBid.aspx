<%@ Page Title="&#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2325;&#2366; &#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325;" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DIB_013_TechnicalBid.aspx.cs" Inherits="Paper_TechnicalBid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="table-responsive">
    <asp:UpdatePanel runat="server" ID="UpdatePnl">
        <ContentTemplate>

            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePnl">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>


            <div class="portlet-header ui-widget-header">बीमा टेंडर की तकनिकी शर्तो की जानकारी / Technical Bid of Insurance Tender  </div>
            <div class="portlet-content">
                <div class="table-responsive ">



                    <asp:Panel ID="messDiv" runat="server">
                        <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
                    </asp:Panel>


                    <table width="100%">
                        <tr>
                            <td>
                                <b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;.</b>
                            </td>
                            <td colspan="3">
                                <asp:DropDownList runat="server" ID="ddlTenderType" AutoPostBack="true" OnSelectedIndexChanged="ddlTenderType_SelectedIndexChanged" CssClass="txtbox reqirerd"></asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Panel ID="Panel1" runat="server" BorderColor="gray" BorderStyle="solid" BorderWidth="1px">
                                    <table width="100%">
                                        <tr>
                                            <td colspan="4" style="height: 10px;"></td>
                                        </tr>
                                        <tr>
                                            <td><b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Tender No.</b></td>

                                            <td>
                                                <asp:Label ID="lblTenderNo" runat="server"></asp:Label>
                                            </td>

                                            <td><b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Tender Date</b></td>

                                            <td>
                                                <asp:Label ID="lblTenderDt" runat="server"></asp:Label>
                                            </td>

                                        </tr>

                                        <tr>

                                            <td>
                                                <b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;/Tender Name</b>
                                            </td>

                                            <td>
                                                <asp:Label ID="lblTenderWork" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;/ Tender Type
                                                </b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTenderType" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>&#2357;&#2367;&#2357;&#2352;&#2339; / Tender Details</b>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="lblTenderDtl" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>&#2312; .&#2319;&#2350;.&#2337;&#2368;. &#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; ) / E.M.D. Amount(Rs.)</b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEMd" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2347;&#2368;&#2360;(&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375; )/ Tender Fees(Rs.) </b>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblTenderFee" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <b>&#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/ Last Date of Tender Submission</b>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="lblSubDt" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>

                                            <td><b>&#2348;&#2368;&#2350;&#2366; &#2309;&#2357;&#2343;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;/ Insurance Date From </b></td>
                                            <td>
                                                <asp:Label ID="lblInsuranceDateFrom_D" runat="server"></asp:Label>
                                            </td>

                                            <td><b>&#2340;&#2325; / Insurance Date To </b></td>
                                            <td>
                                                <asp:Label ID="lblInsuranceDateTo_D" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="btnReturn" runat="server" CssClass="btn" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2319;&#2306;"
                                                    OnClick="btnReturn_Click" />
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="4" style="height: 10px;"></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4"></td>
                        </tr>
                      <tr>
                            <td >&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; <br /> Opening Date of Commercial Bid</td><td >
                                <asp:TextBox runat="server" ID="txtCommDate" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtCommDate"
                        Format="dd/MM/yyyy"> </cc1:CalendarExtender>
                         </td>
                            <td >&#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2323;&#2346;&#2344; &#2325;&#2352;&#2344;&#2375; &#2325;&#2366; &#2360;&#2350;&#2351; <br /> Opening Time of Commercial Bid</td>
                            <td > <asp:TextBox runat="server" ID="txtCommTime" Width="250px" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:MaskedEditExtender runat="server" ID="Time15" TargetControlID="txtCommTime"
                            Mask="99:99:99" MaskType="Time" ClearTextOnInvalid="true" AcceptAMPM="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditValidator runat="server" ID="MaskedEditExtender1" ControlExtender="Time15" 
                            ControlToValidate="txtCommTime" IsValidEmpty="true" EmptyValueMessage="Time is required."></cc1:MaskedEditValidator></td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Panel runat="server" ID="pnlCompanydes" GroupingText=" ">
                                    <table width="100%">

                                        <tr>
                                            <td style="width: 50%;">निविदाकार कंपनी का नाम / Tenderer Company Name :
                                            </td>
                                            <td style="width: 50%;">
                                                <asp:DropDownList runat="server" ID="ddlVenderFill" AutoPostBack="true" OnSelectedIndexChanged="ddlVenderFill_SelectedIndexChanged" CssClass="txtbox reqirerd"></asp:DropDownList>

                                                <asp:Label ID="lblCompAdd" runat="server" Visible="False"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">
                                                <asp:Panel runat="server" ID="pnlCondition" GroupingText=" तकनिकी शर्तें /Technical Conditions">

                                                    <asp:GridView runat="server" ID="grdCompany" AutoGenerateColumns="false" CssClass="tab hastable" OnRowDataBound="grdCompany_RowDataBound">
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ S.No.">
                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex+1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375; / Select">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkCheckStatus" runat="server" />

                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="तकनिकी शर्तें / Technical Condition">
                                                                <ItemTemplate>
                                                                    <%# Eval("TndrCondition")%>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="HDNTechn_TrId" runat="server" Value='<%# Eval("Techn_TrId") %>' />
                                                                    <asp:HiddenField ID="HDNTenderTrId_I" runat="server" Value='<%# Eval("TenderTrId_I") %>' />
                                                                    <asp:HiddenField ID="HDNTender_Cond_Id" runat="server" Value='<%# Eval("Tender_Cond_Id") %>' />

                                                                    <asp:HiddenField ID="HDNCheckStatus" runat="server" Value='<%# Eval("CheckStatus") %>' />


                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                    </asp:GridView>

                                                </asp:Panel>
                                            </td>

                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                                                    CssClass="btn" OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />

                                            </td>
                                        </tr>

                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4">
                                <asp:Panel runat="server" ID="pnlCompanyAll" GroupingText="&#2340;&#2369;&#2354;&#2344;&#2366;&#2340;&#2381;&#2350;&#2325; &#2346;&#2340;&#2381;&#2352;&#2325;/ Comparative Chart ">

                                    <asp:GridView runat="server" ID="grdCompanyAll" AutoGenerateColumns="false" CssClass="tab hastable" OnRowDataBound="grdCompanyAll_RowDataBound">
                                        <Columns>

                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="&#2325;&#2306;&#2346;&#2344;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;/ Company">
                                                <ItemTemplate>
                                                    <%--<%# Eval("Company_V")%>
                                                    --%>
                                                    <asp:Literal runat="server" ID="litCompany_V" OnDataBinding="litCompany_V_DataBinding"></asp:Literal>


                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="&#2330;&#2351;&#2344; &#2325;&#2368; &#2360;&#2381;&#2340;&#2367;&#2341;&#2367; / Selection Status ">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkCheckStatus" runat="server" Enabled="false" />
                                                    <asp:HiddenField ID="HDNCheckStatus" runat="server" Value='<%# Eval("CheckStatus") %>' />

                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="तकनिकी शर्तें/ Technical Condition">
                                                <ItemTemplate>
                                                    <%# Eval("TndrCondition")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>

                                </asp:Panel>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
        </div>
</asp:Content>
