<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewSpecialDemand.aspx.cs" Inherits="DistributionB_ViewSpecialDemand"
    Title="अध्यक्ष / प्रबंध संचालक का विशेष अधिकार" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>अध्यक्ष / प्रबंध संचालक का विशेष अधिकार / Special Demand from Chairman/ M.D.</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnNewFreeDistribution" CssClass="btn" OnClick="btnNewFreeDistribution_Click" runat="server" Text="नई मांग की जानकारी भरें / New Demand" />


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
                                <asp:TemplateField HeaderText="क्रमांक / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="AcYear" HeaderText="शैक्षणिक सत्र / Financial Year" />
                                <asp:TemplateField HeaderText="पत्र क्र० / Letter No">
                                    <ItemTemplate>
                                        <a href="SpecialDemand.aspx?ID=<%#new APIProcedure().Encrypt( Eval("SpecialBookDemandTrno_I").ToString()) %>"><%# Eval("LetterNo_V") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="पत्र दिनांक / Letter Date" />

                                <asp:BoundField DataField="DemandFrom_V" HeaderText="आदेशकर्ता अधिकारी / Officer  " />
                                <asp:BoundField DataField="SupplyTo_V" HeaderText="जहाँ पुस्तके प्रदाय करना है / Place of Supply" />
                                <asp:BoundField DataField="NetAmount_I" DataFormatString="{0:N}" HeaderText="शुद्ध मूल्य(रुपए) /Net Amount (Rs.)" />
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
