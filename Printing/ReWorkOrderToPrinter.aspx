<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ReWorkOrderToPrinter.aspx.cs" Inherits="Printing_WorkOrderToPrinter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
            <h2>प्रिंटर को पुनः कार्यादेश जारी करे</h2>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-12">
                    <div id="messageDiv" runat="server" class="form-message" style="display: none;"></div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="form-select"
                            OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                            <asp:ListItem>Select</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                        <label>शैक्षणिक सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlTenderID_I" runat="server" CssClass="form-select reqirerd" OnSelectedIndexChanged="ddlTenderID_I_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <label>टेंडर</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlPrinter_regid_i" runat="server"
                            CssClass="form-select reqirerd"
                            OnSelectedIndexChanged="ddlPrinter_regid_i_SelectedIndexChanged"
                            AutoPostBack="true" OnInit="ddlPrinter_regid_i_Init">
                        </asp:DropDownList>
                        <label>प्रिंटर का नाम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtLOINo_V" runat="server" MaxLength="12" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>एल.ओ.आई. क्रमांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtLOIDate_D" runat="server" placeholder="" TextMode="Date" MaxLength="10" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>एल.ओ.आई. दिनांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtWorkorderNo_V" runat="server" placeholder="" MaxLength="12" CssClass="form-control reqirerd"></asp:TextBox>
                        <label>कार्यादेश क्रमांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtWODate_D" runat="server" TextMode="Date" MaxLength="10" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtWODate_D_CalendarExtender" runat="server" TargetControlID="txtWODate_D"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>कार्यादेश दिनांक</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <label>कार्यादेश अपलोड करे</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPaperSecAmt" runat="server" MaxLength="15" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtPaperSecAmt"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>पेपर सिक्यूरिटी राशि (मांग) </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtPrintingSecAmt" runat="server" MaxLength="15" placeholder="" CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtPrintingSecAmt"
                            ValidChars="0123456789." FilterMode="ValidChars">
                        </cc1:FilteredTextBoxExtender>
                        <label>प्रिंटिंग सिक्यूरिटी राशि (मांग)</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="txtDepositEndDt" TextMode="Date" runat="server" MaxLength="10"
                            CssClass="form-control reqirerd"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDepositEndDt"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                        <label>जमा करने की अंतिम दिनांक</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False"
                        CssClass="table table-bordered" DataKeyNames="GRPID_I"
                        OnRowDataBound="GrdGroupDetails_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                    <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("GRPID_I") %>' />
                                    <asp:HiddenField ID="HidDepoid" runat="server" Value='<%# Eval("depoid") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ &lt;br&gt; Group No">
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGroupNO_V" runat="server" Text='<%#Eval("groupno_v") %>'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/ No of Pages"
                                DataField="Noofpages" />
                            <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/No of Books"
                                DataField="TotNoOfBooks" />
                            <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375;)/Printing Qty (Ton)"
                                DataField="Qty_PriPaper" />
                            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;/Name of the Printer"
                                DataField="NameofPress_V" />
                            <asp:BoundField HeaderText="&#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;)/Amount (Rs)" DataField="rate" />

                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-submit"
                        Text="कार्यादेश सेव करे एवं प्रिंटर को भेजे" OnClientClick='javascript:return ValidateAllTextForm();'
                        OnClick="btnSave_Click" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        function MaxLengthCount(txt, MaxLen) {
            var txtBox = document.getElementById(txt);
            var len = MaxLen;
            if (txtBox.value.length > len) {

                txtBox.value = txtBox.value.substring(0, len);
                alert("Character length is Exeed from " + len);
            }
            else { }
        }
    </script>
    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtLOIDate_D"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
</asp:Content>

