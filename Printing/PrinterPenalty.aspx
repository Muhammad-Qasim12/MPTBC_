<%@ Page Title="&#2346;&#2375;&#2344;&#2366;&#2354;&#2381;&#2335;&#2368; &#2347;&#2377;&#2352;&#2381;&#2350; / Penalty Form" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PrinterPenalty.aspx.cs" Inherits="Printing_PrinterPenalty" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>प्रिंटर पेनाल्टी</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <div id="messageDiv" runat="server" class="form-message" style="display: none;"></div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:Label ID="lblJobCode_V" runat="server"></asp:Label>
                        <asp:DropDownList ID="ddlJobCode" runat="server" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlJobCode_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                        <asp:HiddenField ID="HDNAlready" runat="server" />
                        <asp:HiddenField ID="HfChallanDate" runat="server" />
                        <asp:Label ID="lblLastMaxChallanDate" runat="server" Visible="false" />
                        <asp:Label ID="lblCount" runat="server" Visible="false" />
                        <asp:Label ID="lblMaxChallanDate" runat="server" Visible="false" />
                    </div>
                </div>
                <div class="col-md-4"></div>
                <div class="col-md-4"></div>
                <div class="col-md-12">
                    <h5><b>प्रिंटर की जानकारी</b></h5>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtChalanrecDate" runat="server" CssClass="form-control" TextMode="Date" MaxLength="10" onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtChalanrecDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" TargetControlID="txtChalanrecDate">
                        </cc1:CalendarExtender>
                        <label>चालान दिनांक </label>
                        <asp:Label ID="lblGroupNo" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinterID_I" runat="server" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlPrinterID_I_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <label>प्रिंटर का नाम</label>
                        <asp:Label ID="lblPrinterName" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlBookID_I" runat="server" CssClass="form-select reqirerd" AutoPostBack="true" OnInit="ddlBookID_I_Init" OnSelectedIndexChanged="ddlBookID_I_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>पुस्तक का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrintingChr100per_N" runat="server" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>प्रिंटिंग चार्ज(100%)</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <h5><b>खराब प्रिंटिंग और प्रिंटिंग में गलतियाँ</b></h5>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtSubstandardbadprintingper_N" runat="server" MaxLength="5" placeholder="" CssClass="form-control" OnTextChanged="txtSubstandardbadprintingper_N_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtSubstandardbadprintingper_N"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>खराब प्रिंटिंग की पेनाल्टी (% में) </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtBadPrintingAmount_N" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                        <label>खराब प्रिंटिंग की पेनाल्टी (रु. में) </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrintMistakPer_N" runat="server" MaxLength="5" placeholder="" CssClass="form-control" OnTextChanged="txtPrintMistakPer_N_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPrintMistakPer_N"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>प्रिंटिंग गलतियों में पेनाल्टी (% में)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtMistakeAmount_N" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                        <label>प्रिंटिंग गलतियों में पेनाल्टी (रु. में) </label>
                    </div>
                </div>
                <div class="col-md-12">
                    <h5><b>प्रूफ जमा करने पर देरी</b></h5>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDateofRecMssDesign_D" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtBookingDate0_CalendarExtender" runat="server" TargetControlID="txtDateofRecMssDesign_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>डिजाइन प्रदान करने की दिनाँक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDateofProofSubmission_D" runat="server" placeholder="" CssClass="form-control" OnTextChanged="txtDateofProofSubmission_D_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDateofProofSubmission_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>प्रूफ जमा करने की दिनाँक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDelay_proof_N" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                        <label>जमा करने में देरी (दिनों में)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPerofpenalty_proof_N" runat="server" MaxLength="5" placeholder="" CssClass="form-control" OnTextChanged="txtPerofpenalty_proof_N_TextChanged" AutoPostBack="true"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPerofpenalty_proof_N"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>प्रतिदिन के अनुसार पेनाल्टी (% में) </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtTotPerofpenalty_proof_N" runat="server" MaxLength="5" placeholder="" CssClass="form-control"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtTotPerofpenalty_proof_N"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>टोटल पेनाल्टी (% में)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtAmountofPenalty_proof_N" runat="server" placeholder="" CssClass="form-control"></asp:TextBox>
                        <label>टोटल पेनाल्टी (रु. में)</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Panel ID="pnl" runat="server" GroupingText="पुस्तकों को जमा करने पर देरी" Visible="false">
                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtSupp_DueDate_D" runat="server" CssClass="form-control"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSupp_DueDate_D"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <label>जमा करने की दिनाँक</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtRecDate_D" runat="server" CssClass="form-control" OnTextChanged="txtRecDate_D_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtRecDate_D"
                                        Format="dd/MM/yyyy">
                                    </cc1:CalendarExtender>
                                    <label>प्राप्त करने की दिनाँक</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtDelay_Supply_N" runat="server" CssClass="form-control"></asp:TextBox>
                                    <label>जमा करने में देरी (दिनों में)</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtTotPerofpenalty_Supply_N" runat="server" MaxLength="5" CssClass="form-control" OnTextChanged="txtTotPerofpenalty_Supply_N_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtTotPerofpenalty_Supply_N"
                                        ValidChars="0123456789." FilterMode="ValidChars">
                                    </cc1:FilteredTextBoxExtender>
                                    <label>टोटल पेनाल्टी (% में)</label>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-floating">
                                    <asp:TextBox ID="txtAmountofPenalty_Supply_N" runat="server" CssClass="txtbox"></asp:TextBox>
                                    <label>टोटल पेनाल्टी (रु. में)</label>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <div class="col-md-12">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HDNPriTransID" runat="server" />
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit" Text="सुरक्षित करे" OnClientClick='javascript:return ValidateAllTextForm();'
                        OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
