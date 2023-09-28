<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewDemandFreeTextBooks.aspx.cs" Inherits="DistributionB_ViewDemandFreeTextBooks"
    Title="रा०शि०के से नि:शुल्क पुस्तकों की मांग की स्थिति" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>रा०शि०के से नि:शुल्क पुस्तकों की मांग  /Demand of Free Sample books from RSK</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNewFreeDistribution" CssClass="btn" OnClick="btnNewFreeDistribution_Click"
                            runat="server" Text="नई मांग की जानकारी भरें / New Demand" />

                    </td>
                    <td>शिक्षा सत्र / Academic Year
                        <asp:DropDownList ID="ddlAcYr" CssClass="txtbox" runat="server"></asp:DropDownList>
                        <asp:Button ID="btnSearch" CssClass="btn" OnClick="btnSearch_Click"
                            runat="server" Text="खोजें" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GrdLetterInfo" runat="server" AutoGenerateColumns="false" CssClass="tab"
                            OnRowEditing="GrdLetterInfo_OnRowEditing" OnRowDeleting="GrdLetterInfo_OnRowDeleting"
                            EmptyDataText="Record Not Found.">

                            <Columns>

                                <asp:TemplateField >
                                    <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                    क्रमांक / S.No.
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (1)
                                                </td>

                                            </tr>

                                        </table>

                                    </HeaderTemplate>

                                    <ItemTemplate><%# Container.DataItemIndex+1 %> </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                     <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                    शैक्षणिक सत्र / Financial Year
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (2)
                                                </td>

                                            </tr>

                                        </table>

                                    </HeaderTemplate>

                                    <ItemTemplate>
                                        <asp:Label ID="lblAcYr" runat="server" Text='<%# Eval("AcYear") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false" HeaderText="">
                                      <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                   स्थिति / Status
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (3)
                                                </td>

                                            </tr>

                                        </table>

                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblFreeDisID" runat="server" Text='<%#Eval("FreeBooksDistributionID_I") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                      <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                  RSK का पत्र क्र० / Letter No. from RSK 
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (4)
                                                </td>

                                            </tr>

                                        </table>

                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a href="DemandFreeTextBooks.aspx?ID=<%# new APIProcedure().Encrypt(Eval("FreeBooksDistributionID_I").ToString()) %>">
                                            <%# Eval("LetterNo_V") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                      <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                  पत्र दिनांक / Letter Date 
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (5)
                                                </td>

                                            </tr>

                                        </table>

                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblLetterDate" runat="server" Text='<%# Convert.ToDateTime(Eval("LetterDate_D").ToString()).ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                  प्रदाय का स्थान / Place of Supply
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (6)
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupply" runat="server" Text='<%#Eval("SupplyFrom_V") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                     <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                                डिपो / Depo
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (7)
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblSupplyDepo" runat="server" Text='<%#Eval("DepoName_V") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                     <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                              शुद्ध मूल्य(रुपए) / Net Price(Rs.) 
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (8)
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetAmount_I" runat="server" Text='<%# Convert.ToDouble(Eval("NetAmount_I").ToString()).ToString("N") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                     <HeaderTemplate>
                                        <table>
                                            <tr>
                                                <td style="height:50px;">
                                             स्थिति / Status
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                 (9)
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%#(Eval("ApprovStatus").ToString().Equals("0")) ? "On Process" : "Sent to RSK" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="स्वीकृति स्तर( हा / नहीं)/ Approval Status">
                                    <ItemTemplate>
                                        <asp:Panel ID="pnlStus" runat="server" Visible='<%#(Eval("ApprovStatus").ToString().Equals("0"))?true:false%>'>
                                            <asp:CheckBox ID="chkAgrStatus" runat="server" />
                                        </asp:Panel>
                                        <asp:Panel ID="pnlafterstatus" runat="server" Visible='<%#(Eval("ApprovStatus").ToString().Equals("0"))?false:true%>'>
                                            <%#(Eval("ApprovStatus").ToString().Equals("1")) ? "स्वीकृत" : "अस्वीकृत"%>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <asp:Panel ID="pnlAgrCnm" runat="server" Visible='<%#(Eval("ApprovStatus").ToString().Equals("0"))?true:false%>'>
                                            <asp:LinkButton ID="lnkAgrSave" CausesValidation="false" OnClick="lnkAgrSave_Click"
                                                OnClientClick="javascript:return confirm('Are you sure to approv / reject ?');"
                                                runat="server">माँग स्वीकृत/अस्वीकृत करें</asp:LinkButton>
                                        </asp:Panel>
                                        <asp:Panel ID="Panel3" runat="server" Visible='<%#(Eval("ApprovStatus").ToString().Equals("0"))?false:true%>'>
                                            <%#(Eval("ApprovStatus").ToString().Equals("1")) ? "मांग स्वीकृत हो चुकी है" : "मांग अस्वीकृत हो चुकी है "%>
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TransportAmount_I" Visible="false" DataFormatString="{0:N}"
                                    HeaderText="ट्रांसपोर्ट शुल्क" />
                                <asp:BoundField DataField="OtherExpence_I" Visible="false" DataFormatString="{0:N}"
                                    HeaderText="अन्य व्यय" />
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div style="height: 5px;">
            </div>
        </div>
    </div>
</asp:Content>
