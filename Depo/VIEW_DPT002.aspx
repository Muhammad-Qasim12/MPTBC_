<%@ Page Title="म.प्र पाठ्यपुस्तक निगम / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW_DPT002.aspx.cs" Inherits="Depo_VIEW_DPT002" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
            <div class="card-header">
            <h2>
                <span>ट्रान्सपोर्ट मास्टर / Transport Master</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdTransport" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="TransportID_I" 
                            
                             AllowPaging="True" 
                            onpageindexchanging="GrdTransport_PageIndexChanging" 
                            onrowcommand="GrdTransport_RowCommand">
                            <Columns> 
                                 <asp:BoundField HeaderText="शैक्षणिक सत्र" DataField="Fyyear" />
                             <asp:BoundField HeaderText="ट्रान्सपोर्टर  कम्पनी नाम / Name of Transporter Company " DataField="TransportName_V" />
                                <asp:BoundField HeaderText="ट्रान्सपोर्टर का नाम / Name of Transporter " DataField="TransportOwnerName_V" />
                               <asp:BoundField HeaderText=" वैध्यता की अवधि (माह में) / Validity Period " DataField="ServicePeriod_V" />
                                <asp:BoundField HeaderText="ट्रान्सपोर्टर का पता / Address of Transporter" DataField="Address_V" />
                                 <asp:BoundField HeaderText="ई मेल आई.डी. / Email ID" DataField="EmailID_V" />
                                <asp:BoundField HeaderText="मोबाइल नंबर / Mobile No." DataField="MobileNo_N" />
                                <asp:BoundField HeaderText="कोर आई.डी.  / Core ID" DataField="AccHrID" />
                                <asp:TemplateField HeaderText="डाटा में सुधार करे / Edit">
                                    <ItemTemplate>
                                        <a href="DPT002_TransportMaster.aspx?ID=<%# api.Encrypt(Eval("TransportID_I").ToString()) %>">डाटा में सुधार करे / Edit</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="डाटा हटाये / Remove">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImgbtnDelete" runat="server" CommandArgument='<%# Eval("TransportID_I") %>'
                                                    CommandName="eDelete" ImageUrl="" CssClass="btn" AlternateText="डाटा हटाये / Remove" OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
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

