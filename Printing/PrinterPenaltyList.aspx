<%@ Page Title="पेनाल्टी की जानकारी / Printer Penalty" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrinterPenaltyList.aspx.cs" Inherits="Printing_PrinterPenaltyList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <div class="row">
                <div class="col-md-6">
                    <h2>पेनाल्टी की जानकारी</h2>
                </div>
                <div class="col-md-6 text-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn-add" Text="नया डाटा डाले" onclick="btnSave_Click" />
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <asp:GridView ID="GrdPrinterPenaltyDetails" runat="server" AutoGenerateColumns="False"
                            CssClass="table table-bordered table-hover" DataKeyNames="PenaltyID_I"
                            onrowdeleting="GrdPrinterPenaltyDetails_RowDeleting" AllowPaging="True"
                            onpageindexchanging="GrdPrinterPenaltyDetails_PageIndexChanging">
                            <columns>
                                <asp:TemplateField HeaderText="क्रमांक">
                                    <itemtemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </itemtemplate>
                                </asp:TemplateField>

                                <%--<asp:BoundField HeaderText="जॉब कोड / Job Code" DataField="JobCode_V" />--%>
                                <%--<asp:BoundField HeaderText="प्रिंटर का नाम" DataField="PrinterID_I" />
                                <asp:BoundField HeaderText="ग्रुप आईडी" DataField="GRPID_I"/>
                                <asp:BoundField HeaderText="पुस्तक का नाम" DataField="BookID_I" />--%>
                                <asp:BoundField HeaderText="प्रिंटर" DataField="NameofPress_V" />
                                <asp:BoundField HeaderText="शीर्षक" DataField="TitleHindi_V" />
                                <asp:BoundField HeaderText="प्रिंटिंग चार्ज(100%) / Printing Charge (100%)" DataField="PrintingChr100per_N" />


                                <asp:BoundField HeaderText="खराब प्रिंटिंग की पेनाल्टी (रु. में) / Penalty for bad printing (in Rs.)" DataField="BadPrintingAmount_N" />
                                <asp:BoundField HeaderText="प्रिंटिंग गलतियों में पेनाल्टी (% में) / Penalty for Printing Mistakes (in %)" DataField="PrintMistakPer_N" />
                                <asp:BoundField HeaderText="प्रिंटिंग गलतियों में पेनाल्टी (रु. में) / Penalty for Printing Mistakes (in Rs.)" DataField="MistakeAmount_N" />



                                <%-- <asp:BoundField HeaderText="टोटल पेनाल्टी (% में)" DataField="TotPerofpenalty_proof_N" />
                                <asp:BoundField HeaderText="टोटल पेनाल्टी (रु. में)" DataField="AmountofPenalty_proof_N" />
                                --%>

                                <%--<asp:BoundField HeaderText="जमा करने में देरी (दिनों में) / Delay In Submission" DataField="Delay_Supply_N" />--%>
                                <asp:BoundField HeaderText="चालान दिनांक कब तक / Upto Challan Date" DataField="UptoChallandate_D" DataFormatString="{0:dd/MM/yyyy}" />
                                <%--<asp:BoundField HeaderText="टोटल पेनाल्टी (% में)" DataField="TotPerofpenalty_Supply_N" />
                                <asp:BoundField HeaderText="टोटल पेनाल्टी (रु. में)" DataField="AmountofPenalty_Supply_N" />
                                --%>
                                <asp:TemplateField HeaderText="डाटा में सुधार करे">
                                    <itemtemplate>
                                        <a href="PrinterPenalty.aspx?ID=<%#new APIProcedure().Encrypt(Eval("PenaltyID_I").ToString()) %>">डाटा में सुधार करे</a>
                                    </itemtemplate>
                                </asp:TemplateField>

                                <asp:CommandField ShowDeleteButton="True" />
                            </columns>
                            <pagerstyle cssclass="Gvpaging" />
                            <emptydatarowstyle cssclass="GvEmptyText" />
                        </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

