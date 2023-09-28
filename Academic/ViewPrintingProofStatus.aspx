<%@ Page Title="प्रिंटिंग प्रूफ का स्टेटस मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewPrintingProofStatus.aspx.cs" Inherits="Academic_ViewPrintingProofStatus" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="table-responsive">
        <div class="headlines">
            <h2>
                <span>प्रिंटिंग प्रूफ का स्टेटस मास्टर / Printing Proof Status Master</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <asp:Panel class="form-message error" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                <asp:Label ID="lblmsg" class="notification" runat="server">
                
                </asp:Label>
            </asp:Panel>
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnNewStatus" runat="server" CssClass="btn" Text="नया डाटा डाले /Add New Information"
                            OnClick="btnNewStatus_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdStatusMaster" runat="server" AutoGenerateColumns="False"
                            CssClass="tab" DataKeyNames="StatusMasterID_I" PageSize="30"
                            OnRowDeleting="GrdStatusMaster_RowDeleting" AllowPaging="True"
                            OnPageIndexChanging="GrdStatusMaster_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक / S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="प्रिंटिंग प्रूफ का स्टेटस/  Printing Proof Status  " DataField="Status_V" />

                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <a href="PrintingProofStatus.aspx?ID=<%#new APIProcedure().Encrypt(Eval("StatusMasterID_I").ToString()) %>" class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="#" ItemStyle-Width="60">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnDelete" runat="server" CausesValidation="False" CommandName="Delete" class="btn btn-sm btn-danger" Text='<i class="bi bi-trash"></i>' OnClientClick="return confirm('The item will be deleted. Are you sure want to continue?');"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>

    </div>

</asp:Content>

