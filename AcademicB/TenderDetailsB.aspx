<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TenderDetailsB.aspx.cs" Inherits="AcademicB_TenderDetailsB" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>
                <span>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;
                    &#2342;&#2352;&#2381;&#2332; &#2325;&#2352;&#2375;&#2306;</span>
                / Tender Information</h2>
        </div>
        <div id="messageDiv" runat="server" class="form-message" style="display: none;">
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year <span class="required">
                            *</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAcdmicYr_V" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="2014-2015">2014-2015</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                        /Tender Type
                        <span class="required">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTenderType_V" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="L1 Rate" Text="L1 Rate"></asp:ListItem>
                            <asp:ListItem Value="Rate Contract" Text="Rate Contract"></asp:ListItem>
                            <asp:ListItem Value="QCBS" Text="QCBS"></asp:ListItem>
                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                        /Tender No
                        <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenderNo_V" runat="server" CssClass="txtbox reqirerd" MaxLength="30"></asp:TextBox>
                       
                    </td>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; /Tender Date <span
                            class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenderDate_D" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtTenderDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.) &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                        /LUN No
                        <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLUNSendNo_V" runat="server" CssClass="txtbox reqirerd" MaxLength="30"></asp:TextBox>
                    </td>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; LUN(&#2319;&#2354;.&#2351;&#2370;.&#2319;&#2344;.)
                        &#2325;&#2375; &#2354;&#2367;&#2319; &#2349;&#2375;&#2332;&#2344;&#2375; &#2325;&#2368;
                        &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;/ Last Date of LUN Submission <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLUNDate_D" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtLUNDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                      
                    </td>
                </tr>
                <tr>
                    <td>
                        NIT &#2344;&#2367;&#2357;&#2367;&#2342;&#2366; &#2346;&#2348;&#2381;&#2354;&#2367;&#2358;&#2367;&#2306;&#2327;
                        &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;/Tender Publicatin Date <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNITDate_D" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtNITDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                       
                    </td>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2337;&#2377;&#2325;&#2381;&#2351;&#2370;&#2350;&#2375;&#2306;&#2335;
                        &#2347;&#2368;&#2360;/ Tender Document Fees (Rs.) <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenderDocFee_N" runat="server" CssClass="txtbox reqirerd" MaxLength="6"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtTenderDocFee_N"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2335;&#2375;&#2306;&#2337;&#2352; &#2360;&#2348;&#2350;&#2367;&#2358;&#2344; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325;
                        /Last Date of Tender Submission
                        <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTenderSubmissionDate_D" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender" runat="server" TargetControlID="txtTenderSubmissionDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                       
                    </td>
                    <td>
                        &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375;
                        &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; /Technical bid opening Date <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTechBidopeningDate_D" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtTechBidopeningDate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                       
                    </td>
                </tr>
                <tr>
                    <td>
                        &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375;
                        &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2305;&#2325; / Commercial Bid Opening Date <span class="required">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCommecialBidOpeningdate_D" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtCommecialBidOpeningdate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                      
                    </td>
                </tr>
            </table>
            <fieldset>
                <legend>&#2335;&#2375;&#2306;&#2337;&#2352; &#2350;&#2375;&#2306; &#2310;&#2344;&#2375;
                    &#2357;&#2366;&#2354;&#2375; &#2327;&#2381;&#2352;&#2369;&#2346; &#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335;
                    &#2325;&#2352;&#2375;&#2306;/Select Group in Tender</legend>
                <table width="100%">
                    <tr>
                        <td style="text-align: center">
                            <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="tab"
                                DataKeyNames="GrpID_I" OnRowDataBound="GrdGroupDetails_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="क्रमांक / S.No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                            <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("GrpID_I") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ग्रुप/Group">
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("GroupNO_V") %>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField HeaderText="&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;" DataField="GroupNO_V" />--%>
                                    <asp:BoundField DataField="Title" HeaderText="शीर्षक /Title">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="TotalSupply" HeaderText="कुल आवंटन /Total Allocation">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PaperQty" DataFormatString="{0:F3}" HeaderText="लगने वाला प्रिंटिंग पेपर (टन मे ) /Total Printing Paper Quantity (Ton)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CoverQty" DataFormatString="{0:F3}" HeaderText="लगने वाला कवर पेपर (शीट मे )/total CoverPaper Quantity(Ton)">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Right" />
                                    </asp:BoundField>
                                    <%-- 
                                <asp:BoundField HeaderText="&#2337;&#2367;&#2346;&#2379;" DataField="DepoID_I" />
                                         <asp:BoundField DataField="" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366;">     <asp:BoundField HeaderText="&#2325;&#2376;&#2335;&#2375;&#2327;&#2352;&#2368;" DataField="PrintingCategory_V"/>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Right" />
                                        </asp:BoundField>
                                    --%>
                                    <asp:TemplateField HeaderText="सेलेक्ट करें/Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkGroup" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table width="100%">
                <tr>
                    <td style="text-align: center">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField3" runat="server" />
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="सुरक्षित करें / Save"
                            OnClientClick='javascript:return ValidateAllTextForm();' OnClick="btnSave_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
