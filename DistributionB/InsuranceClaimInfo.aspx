<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InsuranceClaimInfo.aspx.cs" 
    Inherits="DistributionB_InsuranceClaimInfo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="headlines">
            <h2>&#2348;&#2368;&#2350;&#2366; &#2325;&#2381;&#2354;&#2375;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Insurance Claim Information</h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td>&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; /Letter No. <span class="required">*</span></td>
                    <td>
                        <asp:TextBox ID="txtLetterNo" runat="server" MaxLength="50" CssClass="txtbox reqirerd"></asp:TextBox></td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtClaimDate" runat="server" CssClass="txtbox" OnTextChanged="txtClaimDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender" runat="server" TargetControlID="txtClaimDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                        
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2381;&#2354;&#2375;&#2350; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; /Type of Claim <span class="required">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlClaimType" runat="server" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlClaimType_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                            <asp:ListItem Value="TextBook" Text="TextBook"></asp:ListItem>
                            <asp:ListItem Value="Paper" Text="Paper"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&#2337;&#2367;&#2346;&#2379; / Depo<span class="required">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlDepoName" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2348;&#2368;&#2350;&#2366; &#2325;&#2306;&#2346;&#2344;&#2368; / Insurance Company<span class="required">*</span></td>
                    <td>
                        <asp:DropDownList ID="ddlInsuranceCompany" runat="server" CssClass="txtbox reqirerd">
                            <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>&#2325;&#2381;&#2354;&#2375;&#2350; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;. &#2350;&#2375;&#2306;) / Claim Amount (Rs.)<span class="required">*</span></td>
                    <td>
                        <asp:TextBox ID="txtClaimAmount" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2381;&#2354;&#2375;&#2350; &#2325;&#2366; &#2325;&#2366;&#2352;&#2339; / Reason of Claim <span class="required">*</span></td>
                    <td>
                        <asp:TextBox ID="txtClaimReason" MaxLength="150" runat="server" onkeypress="MaxLengthCount(this,150);" CssClass="txtbox reqirerd"></asp:TextBox></td>
                    <td>&#2309;&#2344;&#2381;&#2351; &#2357;&#2367;&#2357;&#2352;&#2339; / Other Details </td>
                    <td>
                        <asp:Button ID="btnOtherDetails" runat="server" CssClass="btn" Text="&#2309;&#2344;&#2381;&#2351; &#2357;&#2367;&#2357;&#2352;&#2339; &#2349;&#2352;&#2375;&#2306;" OnClick="btnOtherDetails_Click" />
                    </td>
                </tr>
                <tr>
                    <td>&#2325;&#2306;&#2346;&#2344;&#2368; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2381;&#2357;&#2368;&#2325;&#2371;&#2340;&#2367; &#2325;&#2381;&#2354;&#2375;&#2350; &#2352;&#2366;&#2358;&#2367;(&#2352;&#2369;.&#2350;&#2375;&#2306;) / Reimbursed Amount by Company(Rs.)</td>
                    <td>
                        <asp:TextBox ID="txtReimbursedAmount" runat="server" MaxLength="6" CssClass="txtbox"></asp:TextBox>
                        
                    </td>
                    <td>&#2360;&#2381;&#2357;&#2368;&#2325;&#2371;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Reimbursed Date </td>
                    <td>
                        <asp:TextBox ID="txtReimbursedDate" runat="server" CssClass="txtbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtReimbursedDate" Format="dd/MM/yyyy"></cc1:CalendarExtender>
                        
                    </td>
                </tr>
                <tr>
                    <td>&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; /Remark </td>
                    <td>
                        <asp:TextBox ID="txtReimbursedRemark" runat="server" MaxLength="150" onkeypress="MaxLengthCount(this,150);" CssClass="txtbox"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="3">
                        <asp:Button ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;" runat="server" OnClick="btnSave_Click" OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none;" class="popupnew1" runat="server">
        <div class="headlines">
            <h2>
                <span>&#2348;&#2368;&#2350;&#2366; &#2325;&#2381;&#2354;&#2375;&#2350; &#2325;&#2375; &#2309;&#2344;&#2381;&#2351; &#2357;&#2367;&#2357;&#2352;&#2339; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Other Insurance Claim Related Information
                </span>
            </h2>
        </div>
        <asp:Panel class="form-message error" runat="server" ID="pnlPopupMessage" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
            <asp:Label ID="lblPopupMessage" class="notification" runat="server">
                
            </asp:Label>
        </asp:Panel>
        <table class="tab">
            <%-- <tr>
                        <th>&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2366;&#2327;&#2381;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350; / Other then TextBook Item
                        </th>
                        <th>
                            <asp:Label ID="lblTitleName" runat="server" Text=""></asp:Label>
                           
                        </th>
                        <th>
                              &#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                        </th>
                        <th>
                              <asp:Label ID="lblSubTitle" runat="server" Text=""></asp:Label>
                        </th>
                    </tr>--%>


            <tr>
                <td>&#2354;&#2376;&#2335;&#2352; &#2344;&#2306;. / Letter No.
                </td>
                <td>
                    <asp:TextBox ID="txtPayLetterNo" MaxLength="40" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                </td>
                <td>&#2354;&#2376;&#2335;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date
                </td>
                <td>
                    <asp:TextBox ID="txtPayLetterDate" MaxLength="20" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                    <cc1:CalendarExtender ID="ccePayLetterDate" TargetControlID="txtPayLetterDate" Format="dd/MM/yyyy"
                        runat="server">
                    </cc1:CalendarExtender>
                    
                </td>
            </tr>
            <tr>
                <td>&#2325;&#2381;&#2354;&#2375;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Claim Related Information 
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtclaimRemark" MaxLength="200" TextMode="MultiLine" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                </td>
                
                <td>
                    <asp:Button runat="server" OnClick="btnSaveClaimOtherInfo_Click" ID="btnSaveClaimOtherInfo" OnClientClick='javascript:return ValidateAllTextForm1();'
                        Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                        CssClass="btn" />
                </td>
            </tr>
        </table>
        <div id="divPopupPayment" runat="server" style="overflow: scroll; height: 120px">
            <asp:GridView ID="GrdOtherPaymentInfo" AutoGenerateColumns="false" CssClass="tab" OnRowDeleting="GrdOtherPaymentInfo_RowDeleting"
                DataKeyNames="InsClaimOtherInfoId_I" EmptyDataText="No Record Found" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No." />
                    <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date " />
                    <asp:BoundField DataField="Remark" HeaderText="&#2325;&#2381;&#2354;&#2375;&#2350; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Claim Related Information " />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="&#2361;&#2335;&#2366;&#2319;&#2306;"
                                OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="Gvpaging" />
                <EmptyDataRowStyle CssClass="GvEmptyText" />
            </asp:GridView>
        </div>
        <asp:Button runat="server" OnClick="btnClosePopup_Click" ID="btnClosePopup" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375; "
            CssClass="btn" />
    </div>
</asp:Content>

