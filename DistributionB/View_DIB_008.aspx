<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View_DIB_008.aspx.cs" Inherits="Distribution_FreeTextBooksDemandFromRSK"
    Title="बिल भुगतान" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>बिल भुगतान</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GrdLetterInfo" runat="server" AutoGenerateColumns="false" CssClass="tab"
                            OnRowEditing="GrdLetterInfo_OnRowEditing" OnRowDeleting="GrdLetterInfo_OnRowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AcYear" HeaderText="शिक्षा सत्र" />
                                <asp:BoundField DataField="BillType_V" HeaderText="बिल का प्रकार" />
                                <asp:TemplateField HeaderText="बिल क्र०">
                                    <ItemTemplate>
                                        <a href="DIB_008_BillPayment.aspx?ID=<%#Eval("ProcessBillTrno_I") %>">
                                            <%# Eval("LetterNo_V") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="बिल दिनांक" />
                                <asp:BoundField DataField="DepName_V" HeaderText="संस्था का नाम" />
                                <asp:BoundField DataField="NetAmount_I" DataFormatString="{0:N}" HeaderText="शुद्ध मूल्य(रुपए)" />
                               
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div style="height: 5px;">
            </div>
        </div>
    </div>
</asp:Content>
