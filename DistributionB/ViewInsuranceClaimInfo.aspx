<%@ Page Title="बीमा क्लेम की जानकारी " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewInsuranceClaimInfo.aspx.cs" Inherits="DistributionB_ViewInsuranceClaimInfo" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>बीमा क्लेम की जानकारी /Insurance Claim Information</span></h2>
        </div>
        <div class="table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले"   
                            onclick="btnSave_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdClaimDetail" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="ClaimId_I"  PageSize="30"
                            
                            onrowdeleting="GrdItemCategory_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdItemCategory_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक/ S.No.">
                                   <ItemTemplate>
                                       <%# Container.DataItemIndex+1 %>
                                   </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="पत्र क्रमांक/Letter No." DataField="LetterNo_V" />
                                <asp:BoundField HeaderText="दिनांक/Date" DataField="ClaimDate_D" />
                                <asp:BoundField HeaderText="क्लेम का प्रकार/ Type of Claim" DataField="ClaimType_V" />
                                <asp:BoundField HeaderText="बीमा कंपनी/Insurance Company" DataField="Company_V" />
                                <asp:BoundField HeaderText="डिपो/Depo" DataField="DepoName_V" />
                                <asp:BoundField HeaderText="क्लेम राशि(रु. में)/Claim Amount(Rs.)" DataField="ClaimAmount_I" />
                                <asp:BoundField HeaderText="क्लेम का कारण/ Reason of Claim " DataField="ClaimReason_V" />
                                <asp:TemplateField HeaderText="डाटा में सुधार करे/Edit">
                                    <ItemTemplate>
                                        <a href="InsuranceClaimInfo.aspx?ID=<%#new APIProcedure().Encrypt(Eval("ClaimId_I").ToString()) %>">डाटा में सुधार करे</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                  <asp:TemplateField>
                                    <ItemTemplate>
                                         <asp:Button ID="btnDelete" CssClass="btn" runat="server" CommandName="Delete" Text="डाटा हटाये"
                                    OnClientClick="javascript:return confirm('क्या आप डाटा हटाना चाहते हैं?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>     
                              
                            </Columns> <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

