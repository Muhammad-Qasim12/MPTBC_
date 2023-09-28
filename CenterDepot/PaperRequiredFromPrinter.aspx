<%@ Page Title="पेपर आवंटन मास्टर" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperRequiredFromPrinter.aspx.cs" Inherits="CenterDepot_PaperRequiredFromPrinter" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box">
        <div class="card-header">
            <h2>
                <span>पेपर आवंटन मास्टर</span></h2>
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
                    <td style="text-align: center"><div class="table-responsive">
                        <asp:GridView ID="GrdPaperAllotment" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="PaperAltID_I" 
                            
                            onrowdeleting="GrdPaperAllotment_RowDeleting" AllowPaging="True" 
                            onpageindexchanging="GrdPaperAllotment_PageIndexChanging" 
                            onselectedindexchanged="GrdPaperAllotment_SelectedIndexChanged" 
                            onrowcommand="GrdPaperAllotment_RowCommand">
                            <Columns> 
                             <asp:BoundField HeaderText="शैक्षणिक सत्र" DataField="AcadmicYR_V" />
                             <asp:BoundField HeaderText="प्रिंटर का नाम" DataField="NameofPress_V" />
                             <asp:BoundField HeaderText="जॉब कोड" DataField="JobCode_V" />
                             <asp:BoundField HeaderText="दिनांक" DataField="Supplydate_D" />
                             <asp:BoundField HeaderText="पेपर का आकार" DataField="PaperSize_V" />
                             <asp:BoundField HeaderText="पेपर का प्रकार" DataField="PaperCategory_V" />
                             <asp:BoundField HeaderText="GSM" DataField="PaperGSM_V" />
                             <asp:TemplateField HeaderText="प्रिंटिंग पेपर (टन मे )/कवर पेपर (शीट मे )">
                                    <ItemTemplate>
                                    <%#Eval("PaperOpt_I").ToString().Equals("True") ? "प्रिंटिंग पेपर" : "कवर पेपर"%>
                                        </ItemTemplate>
                                </asp:TemplateField>
                           
                             <asp:BoundField HeaderText="पेपर की मात्रा (टन मे )" DataField="PaperQty_N" />
                                
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <ItemTemplate>
                                        <a href="PaperAllotment.aspx?ID=<%#Eval("PaperAltID_I") %>" >डाटा में सुधार करे</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:CommandField ShowDeleteButton="True" HeaderText="डाटा हटाये"/>

                                 <asp:TemplateField HeaderText="प्रिंटर एवं सेन्ट्रल डिपो को भेजे">
                                    <ItemTemplate>
                                    <asp:Button ID="btnSend"  runat="server" CssClass="btn" Text="प्रिंटर एवं सेन्ट्रल डिपो को भेजे " CommandName="cmdSend" CommandArgument='<%# Eval("PaperAltID_I") %>' OnClientClick="return confirm('Are you sure to sent this record to Printer and Central Depo ?');"
                             /> <asp:HiddenField ID="HiddenField1" runat="server" />
                            
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView></div>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>

