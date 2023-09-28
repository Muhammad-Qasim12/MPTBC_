<%@ Page Title="चालान को बिल में जोड़ने की जानकारी /  Adding Challan in Bill Details" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="ChallanSendByDepo.aspx.cs" Inherits="Printing_ChallanSendByDepo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <div class="card-header">
            <h2>
                <span>चालान को बिल में जोड़ने की जानकारी / Adding Challan in Bill Details</span></h2>
        </div>
      <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <%-- <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;"   
                            onclick="btnSave_Click" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdChallanDetail" runat="server" AutoGenerateColumns="False" CssClass="tab"
                            AllowPaging="True" OnPageIndexChanging="GrdWarehouse_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="मुद्रक का नाम / Printer Name ">
                                    <ItemTemplate>
                                        <%#Eval("NameofPress_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="चालान क्रमांक / Challan No.">
                                    <ItemTemplate>
                                        <%#Eval("ChallanNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="चालान दिनांक / Challan Date">
                                    <ItemTemplate>
                                        <%#Eval("ChallanDate")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पुस्तक का नाम / Textbook Name">
                                    <ItemTemplate>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="सामान्य पुस्तक की संख्या / General Book Quantity">
                                    <ItemTemplate>
                                        <%#Eval("NoOFgenralBook_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="योजना पुस्तक की संख्या / Scheme Book Quantity">
                                    <ItemTemplate>
                                        <%#Eval("NofSchemeBook_I")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="चालान का स्तर / Level of Challan">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPinterID_I" runat="server" Text='<%#Eval("PinterID_I") %>' Visible="false"></asp:Label>
                                        <asp:Panel ID="pnlChallanStatus" runat="server" Visible='<%#Eval("ChallanStatus").ToString().Equals("1")?false:true %>'>
                                            <asp:LinkButton ID="lnkUpdate" runat="server" OnClick="lnkUpdate_Click" CausesValidation="false">चालान को बिल में जोड़े</asp:LinkButton>
                                        </asp:Panel>
                                          <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("ChallanStatus").ToString().Equals("1")?true:false %>'>
                                            चालान को बिल में जोड़ दिया गया
                                        </asp:Panel>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
