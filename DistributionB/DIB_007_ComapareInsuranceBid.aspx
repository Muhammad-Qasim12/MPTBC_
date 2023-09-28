<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DIB_007_ComapareInsuranceBid.aspx.cs" Inherits="Distribution_FreeTextBooksDemandFromRSK"
    Title="वार्षिक स्टॉक बीमा के निविदाकारों की तुलनात्मक जानकारी" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>वार्षिक स्टॉक बीमा के निविदाकारों की तुलनात्मक जानकारी</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table>
                <tr>
                    <td>
                        <table>
                            <tr>
                                <td>
                                    वित्तिय वर्ष
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFyYear" OnSelectedIndexChanged="ddlFyYear_OnSelectedIndexChanged"
                                        AutoPostBack="true" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlCompany" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="btnNewCompany" CssClass="btn" OnClick="btnNewCompany_Click" runat="server"
                                        Text="सफल निविदाकार बनाएं " />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="GrdInfo" runat="server" AutoGenerateColumns="false" CssClass="tab"
                            DataKeyNames="InsuranceCompanyTrno_I" OnRowDeleting="GrdInfo_OnRowDeleting" OnRowDataBound="GrdInfo_DataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %></ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField  HeaderText="सफल निविदाकार की स्थिति">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkIsSuccess" Enabled="false" Checked='<%# Convert.ToBoolean(Eval("IsSelected_B")) %>' runat="server" />
                                    </ItemTemplate>
                                
                                </asp:TemplateField>
                                 <asp:BoundField DataField="FyYear" HeaderText=" वित्तिय वर्ष " />
                                <asp:BoundField DataField="CompanyName_V" HeaderText="निविदाकार का नाम" />
                                <asp:BoundField DataField="TotalPrimium" HeaderText="कुल  प्रीमियम राशी" />
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="हटाएं"
                                            OnClientClick="javascript:return confirm('Are you sure you want to delete ?');" />
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
