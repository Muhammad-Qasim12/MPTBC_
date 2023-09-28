<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DIB_008_BillPayment.aspx.cs" Inherits="Distribution_FreeTextBooksDemandFromRSK"
    Title="देयक राशि प्राप्ति की जानकारी " %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="box table-responsive">
                <div class="card-header">
                    <h2>
                        <span>देयक राशि प्राप्ति की जानकारी / Received Bill Payment Information </span>
                    </h2>
                </div>
                <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
                    <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
                    <table width="100%">
                        <tr>
                            <td colspan="4">
                                <asp:HiddenField ID="hdnProcessBillID" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>&#2348;&#2367;&#2354; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Type of Bill
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlBillType" runat="server" CssClass="txtbox"
                                    Enabled="False">
                                    <asp:ListItem Value="&#2348;&#2367;&#2354;"> &#2348;&#2367;&#2354; </asp:ListItem>
                                    <asp:ListItem Value="&#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2348;&#2367;&#2354;"> &#2360;&#2306;&#2358;&#2379;&#2343;&#2367;&#2340; &#2348;&#2367;&#2354; </asp:ListItem>
                                    <asp:ListItem Value="&#2346;&#2381;&#2352;&#2379;&#2357;&#2367;&#2332;&#2344;&#2354; &#2348;&#2367;&#2354;">&#2346;&#2381;&#2352;&#2379;&#2357;&#2367;&#2332;&#2344;&#2354; &#2348;&#2367;&#2354;</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&#2360;&#2306;&#2360;&#2381;&#2341;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; /Department Name
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDepartment" CssClass="txtbox reqirerd" runat="server"
                                    Enabled="False">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year
                            </td>
                            <td>
                                <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlAcademicSession_OnSelectedIndexChanged"
                                    runat="server" ID="ddlAcademicSession" Enabled="False">
                                </asp:DropDownList>
                            </td>
                            <td>&#2357;&#2367;&#2340;&#2381;&#2340;&#2368;&#2351; &#2357;&#2352;&#2381;&#2359; / Financial Year
                            </td>
                            <td>
                                <asp:Label ID="lblFinancialYear" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>पत्र क्रमांक / Letter No
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterNo" MaxLength="40" CssClass="txtbox reqirerd"
                                    runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>पत्र दिनांक / Letter Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtLetterDate" MaxLength="20" CssClass="txtbox reqirerd"
                                    runat="server" Enabled="False"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtLetterDate" TargetControlID="txtLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                             
                            </td>
                        </tr>
                        <tr>
                            <td>रेफ़रेंस पत्र क्रमांक / Reference Letter No.
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterNo" MaxLength="40" CssClass="txtbox reqirerd"
                                    runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td>रेफ़रेंस पत्र दिनांक / Reference Letter Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtRefLetterDate" MaxLength="12" CssClass="txtbox reqirerd"
                                    runat="server" Enabled="False"></asp:TextBox>
                                <cc1:CalendarExtender ID="ccextendtxtRefLetterDate" TargetControlID="txtRefLetterDate"
                                    Format="dd/MM/yyyy" runat="server">
                                </cc1:CalendarExtender>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <div>
                                    <asp:GridView ID="grdSelectedTitle" runat="server" AutoGenerateColumns="False" CssClass="tab"
                                        OnRowEditing="grdSelectedTitle_RowEditing" OnRowDeleting="grdSelectedTitle_RowDeleting"
                                        ShowFooter="true" FooterStyle-BackColor="LightGray" FooterStyle-Font-Bold="true">
                                        <Columns>
                                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ S.No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Title" ReadOnly="true" HeaderText=" अन्य पाठ्य सामाग्री का नाम / Other then TextBook Item" />
                                            <asp:BoundField DataField="SubTitle" ReadOnly="true" HeaderText="अन्य पाठ्य सामग्री का शीर्षक / Title of Other then TextBook Item" />
                                            <asp:BoundField DataField="Rate" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;)/Rate (Rs.)" />
                                            <%--  <asp:BoundField DataField="TotalBooks" ReadOnly="true" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />--%>
                                            <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total Items">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBooks" runat="server" Text='<%# Eval("TotalBooks") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalBooks" runat="server" Text="0"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="TotalAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText="&#2352;&#2366;&#2358;&#2368;(&#2352;&#2370;&#2346;&#2319;)" />--%>
                                            <asp:TemplateField HeaderText="&#2352;&#2366;&#2358;&#2368;(&#2352;&#2370;&#2346;&#2319;) /Total Amount (Rs.)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("TotalAmount") %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="DiscountPercent" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText="&#2331;&#2370;&#2335; &#2325;&#2366; &#2346;&#2381;&#2352;&#2340;&#2367;&#2358;&#2340; / Discount Percent" />
                                            <%--<asp:BoundField DataField="Discount" DataFormatString="{0:N}" ReadOnly="true" HeaderText="&#2331;&#2370;&#2335;(&#2352;&#2370;&#2346;&#2319;)" />--%>
                                            <asp:TemplateField HeaderText="&#2331;&#2370;&#2335; (&#2352;&#2369;&#2346;&#2319;) /Discount Amount(Rs.)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDiscount" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("Discount")),2) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalDiscount" runat="server" Text="0"></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:BoundField DataField="TotalPaidTitles" ReadOnly="true" HeaderText="&#2346;&#2370;&#2352;&#2381;&#2357; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />
                                    <asp:BoundField DataField="RemTitles" ReadOnly="true" HeaderText="&#2358;&#2375;&#2359; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />--%>
                                            <%--  <asp:BoundField DataField="NetAmount" DataFormatString="{0:N}" ReadOnly="true" HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2352;&#2366;&#2358;&#2368; (&#2352;&#2370;&#2346;&#2319;) " />--%>
                                            <asp:TemplateField HeaderText=" &#2358;&#2369;&#2342;&#2381;&#2343; &#2350;&#2370;&#2354;&#2381;&#2351;(&#2352;&#2369;&#2346;&#2319;)/Net Total Amount(Rs.)">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNetAmount" runat="server" Text='<%# Math.Round(Convert.ToDouble(Eval("NetAmount")),2) %>'></asp:Label>
                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <asp:Label ID="lblTotalNetAmount" runat="server" Text='0'></asp:Label>
                                                </FooterTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField Visible="false" DataField="TdsAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText="&#2335;&#2368; &#2337;&#2368; &#2319;&#2360; &#2325;&#2368; &#2352;&#2366;&#2358;&#2368; " />
                                            <asp:BoundField Visible="false" DataField="PaidAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText=" &#2346;&#2370;&#2352;&#2381;&#2357; &#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2352;&#2366;&#2358;&#2368; " />
                                            <asp:BoundField Visible="false" DataField="RemAmount" DataFormatString="{0:N}" ReadOnly="true"
                                                HeaderText=" &#2358;&#2375;&#2359; &#2352;&#2366;&#2358;&#2368; " />
                                            <asp:TemplateField Visible="false">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtProcessBillDetailsTrno" Visible="false" Text='<%# Eval("ProcessBillDetailsTrno_I") %>'
                                                        runat="server"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerStyle CssClass="Gvpaging" />
                                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Button ID="btnPayment" CssClass="btn" runat="server" Text="&#2349;&#2369;&#2327;&#2340;&#2366;&#2344; &#2357;&#2367;&#2357;&#2352;&#2339;"
                                    OnClick="btnPayment_Click" />
                            </td>
                        </tr>
                    </table>
                    <table width="100%" class="tab">
                        <tr>
                            <th>देयक की कुल राशि / Total Bill Payable Amount(Rs.)
                            </th>
                            <th>
                                <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label>
                            </th>
                            <th>पूर्व प्राप्त राशि / Total Received Payment (Rs.)
                                (&#2352;&#2370;&#2346;&#2319;)
                            </th>
                            <th>
                                <asp:Label ID="lblLastPayment" runat="server" Text="0"></asp:Label>
                            </th>
                            <th>TDS &#2352;&#2366;&#2358;&#2368;(&#2352;&#2370;&#2346;&#2319;) / TDS Amount(Rs.)
                            </th>
                            <th>
                                <asp:Label ID="lblPaidTDS" runat="server" Text="0"></asp:Label>
                            </th>
                            <th>&#2325;&#2369;&#2354; &#2358;&#2375;&#2359; &#2352;&#2366;&#2358;&#2368;(&#2352;&#2370;&#2346;&#2319;) / Remaining Amount(Rs.)
                            </th>
                            <th>
                                <asp:Label ID="lblRemAmount" runat="server" Text="0"></asp:Label>
                            </th>
                        </tr>
                        <%--  <tr>
                    <td colspan="4">
                        <asp:Button runat="server" ID="btnSupply" OnClick="btnSupply_Click" Text="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375; "
                            OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                    </td>
                </tr>--%>
                    </table>
                </div>
            </div>
            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew1" runat="server">
                <div class="card-header">
                    <h2>
                        <span>देयक राशि प्राप्ति की जानकारी / Received Bill Payment Information
                        </span>
                    </h2>
                </div>
                <asp:Panel class="form-message error" runat="server" ID="pnlPopupMessage" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                    <asp:Label ID="lblPopupMessage" class="notification" runat="server">
                
                    </asp:Label>
                </asp:Panel>
                <table class="tab">
                    <tr>
                        <th>अन्य पाठ्य सामाग्री का नाम / Other then TextBook Item
                        </th>
                        <th>
                            <asp:Label ID="lblTitleName" runat="server" Text=""></asp:Label>
                            <asp:HiddenField ID="hdnProcessBillDetailsTrno" runat="server" />
                        </th>
                        <th>
                            <%--  &#2313;&#2346; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;--%>
                        </th>
                        <th>
                            <%--  <asp:Label ID="lblSubTitle" runat="server" Text=""></asp:Label>--%>
                        </th>
                    </tr>

                    <tr>

                        <td>भुगतान प्राप्ति का प्रकार / Mode of Payment Recieve
                        </td>
                        <td>
                            <asp:TextBox ID="txtTotalTitle" MaxLength="8" onkeypress='javascript:tbx_fnInteger(event, this);'
                                Visible="false" Text="0" CssClass="txtbox " runat="server"></asp:TextBox>
                            <asp:DropDownList ID="ddlPaymentMode" AutoPostBack="true" CssClass="txtbox reqirerd1"
                                OnSelectedIndexChanged="ddlPaymentMode_SelectedIndexChanged" runat="server">
                                <asp:ListItem Selected="True" Text="Select.." Value="0"></asp:ListItem>
                                <asp:ListItem Text="Cheque" Value="Cheque"></asp:ListItem>
                                <asp:ListItem Text="RTGS" Value="RTGS"></asp:ListItem>
                                <asp:ListItem Text="Internet Banking" Value="Internet Banking"></asp:ListItem>

                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <asp:Panel ID="pnlPaymentDetails" Visible="false" runat="server">
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
                            <td>&#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Bank Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtBankName" MaxLength="30" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                            </td>
                           <td>
                                <%-- &#2330;&#2375;&#2325; &#2344;&#2306;. / Cheque No.--%>
                                <asp:Label ID="lblPaymentNO" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChqNo" MaxLength="15" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            
                            <td>
                                <%--  &#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Cheque Date--%>
                                <asp:Label ID="lblPaymentDate" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtChqDate" MaxLength="12" CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="cceChqDate" TargetControlID="txtChqDate" Format="dd/MM/yyyy"
                                    runat="server">
                                </cc1:CalendarExtender>
                                
                            </td>
                             <td>प्राप्त राशि (रुपए) / Received Amount (Rs.)
                            </td>
                            <td>
                                <asp:TextBox ID="txtPaidAmount" MaxLength="8" onkeypress='javascript:tbx_fnInteger(event, this);'
                                    CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                           
                            <td>&#2309;&#2327;&#2381;&#2352;&#2367;&#2350; TDS(रूपए) / TDS Amount(Rs.)
                            </td>
                            <td>
                                <asp:TextBox ID="txtTDS" MaxLength="12" onkeypress='javascript:tbx_fnInteger(event, this);'
                                    CssClass="txtbox reqirerd1" runat="server"></asp:TextBox>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button runat="server" OnClick="btnSavePayment_Click" ID="btnSavePayment" OnClientClick='javascript:return ValidateAllTextForm1();'
                                    Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; "
                                    CssClass="btn" />
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td colspan="4"></td>
                    </tr>
                </table>
                <div id="divPopupPayment" runat="server" style="overflow: scroll; height: 120px">
                    <asp:GridView ID="GrdPayement" AutoGenerateColumns="false" CssClass="tab" OnRowDeleting="GrdPayement_OnRowDeleting"
                        DataKeyNames="BillPaymentTrno_I" runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PaymentMode" HeaderText="भुगतान प्राप्ति का प्रकार / Mode of Payment Recieve" />
                            <asp:BoundField DataField="LetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Letter No." />
                            <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Letter Date " />
                            <asp:BoundField DataField="ChqNo_V" HeaderText=" &#2330;&#2375;&#2325; &#2344;&#2306;./ Cheque No." />
                            <asp:BoundField DataField="ChqDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText=" &#2330;&#2375;&#2325; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Cheque Date" />
                            <asp:BoundField DataField="BankName_V" HeaderText=" &#2348;&#2376;&#2306;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /Bank Name" />
                            <%--                            <asp:BoundField DataField="TotalPaidTitles_I" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" />--%>
                            <asp:BoundField DataField="PaidAmount_I" HeaderText="  प्राप्त राशि (रुपए) / Received Amount (Rs.)" />
                            <asp:BoundField DataField="TdsAmount_I" HeaderText="अग्रिम TDS(रूपए) / TDS Amount(Rs.)" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
