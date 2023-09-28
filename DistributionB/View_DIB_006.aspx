<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="View_DIB_006.aspx.cs" Inherits="Distribution_FreeTextBooksDemandFromRSK"
    Title="वार्षिक स्टॉक बीमा के निविदाकारों की कॉमेर्सियल जानकारी" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>वार्षिक स्टॉक बीमा के निविदाकारों की कॉमेर्सियल जानकारी</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="GrdInfo" runat="server" AutoGenerateColumns="false" CssClass="tab"
                            DataKeyNames="InsuranceCompanyTrno_I" OnRowEditing="GrdInfo_OnRowEditing" 
                            OnRowDeleting="GrdInfo_OnRowDeleting" OnRowDataBound="GrdInfo_RowDataBound">
                            <Columns>
                             <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %></ItemTemplate>
                                    </asp:TemplateField>
                                <asp:BoundField DataField="FyYear" HeaderText=" वित्तिय वर्ष " />
                                <asp:BoundField DataField="CompanyName_V" HeaderText="निविदाकार का नाम" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCmpId" runat="server" Text='<%#Eval("InsuranceCompanyTrno_I") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Technical Specifications">
                                <ItemTemplate>
                                        <%--<table class="tab">
                                <tr>
                                    <td>
                                        क्या निविदाकार IRDA से अनुबंधित है ?
                                    </td>
                                    <td>
                                          <asp:CheckBox ID="IsIRDA_B" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsIRDA_B")) %>' runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        निविदाकार द्वारा फॉर्म निगम से क्रय / डाउनलोड है तो उक्त फॉर्म की क्रिय करने की
                                         राशि संगलन है ?"
                                    </td>
                                    <td>
                                         <asp:CheckBox ID="IsFormPurchase_B"  Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsFormPurchase_B")) %>' runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td> क्या फ्लोटर डिक्लेरेशन पालिसी के लिए ऑफर दिया है ?</td>
                                    <td> <asp:CheckBox ID="IsDeclarePolicy_B"  Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsDeclarePolicy_B")) %>' runat="server" /></td>
                                </tr>
                                   <tr>
                                    <td>क्या ऑफर अग्नि एवं अन्य रिस्क हेतु है ?</td>
                                    <td>  <asp:CheckBox ID="IsFireOther_B"  Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsFireOther_B")) %>' runat="server" /></td>
                                </tr>
                                   <tr>
                                    <td>क्या ऑफर STFI , RSMD & Earthquake हेतु दिया है ?</td>
                                    <td><asp:CheckBox ID="IsSiftRSMD_B"  Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsSiftRSMD_B")) %>' runat="server" /></td>
                                </tr>
                                   <tr>
                                    <td>क्या ऑफर IRDA के मार्गदर्शन सिद्धान्तों एवं टेरिफ अनुसार है ?</td>
                                    <td>  <asp:CheckBox ID="IsIRDARules_B"  Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsIRDARules_B")) %>' runat="server" /></td>
                                </tr>
                                   <%--<tr>
                                    <td>रिमार्क</td>
                                    <td>
                                        <asp:Label ID="txtgrdRemark" Text='<%# Eval("Remark_V") %>' runat="server"/>
                                    </td>

                                </tr>
                            </table>--%>
                                        <asp:GridView ID="GrdSpecDetails" AutoGenerateColumns="false" ShowHeader="false"
                                            runat="server">
                                            <Columns>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkTechCondition" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsSelected")) %>'
                                                            runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="TndrCondition" />
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" For Gross primium including service tax of floater declaration policy for anual insurance">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    Net primium
                                                </td>
                                                <td>
                                                    <asp:Label ID="txtgrdRemark" Text='<%# Eval("NetPrimium_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Service tax
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" Text='<%# Eval("ServiceTax_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Other Tax
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label5" Text='<%# Eval("OtherTax_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Gross Primium
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" Text='<%# Eval("GrossPrimium_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" For Insurance cover of burglary">
                                    <ItemTemplate>
                                        <table>
                                            <tr>
                                                <td>
                                                    Net primium
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label1" Text='<%# Eval("BurglaryNetPrimium_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Service tax
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" Text='<%# Eval("BurglaryServiceTax_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Other Tax
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" Text='<%# Eval("BurglaryOtherTax_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    Gross Primium
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label7" Text='<%# Eval("BurglaryGrossPrimium_N") %>' runat="server" />
                                                </td>
                                            </tr>
                                            <%-- <tr>
                                    <td> Remark</td>
                                    <td><asp:Label ID="Label8" Text='<%# Eval("BurglaryRemark_V") %>' runat="server"/></td>
                                </tr>--%>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="TotalPrimium" HeaderText="कुल ग्रॉस प्रीमियम" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <a href="DIB_006_CommercialInsuranceInfo.aspx?ID=<%#Eval("InsuranceCompanyTrno_I") %>">
                                            कॉमेर्सियल डाटा भरें </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" CssClass="btn" runat="server" Visible="false" CommandName="Delete"
                                            Text="हटाएं" OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
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
