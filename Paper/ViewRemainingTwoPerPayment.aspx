<%@ Page Title="बचे हुये 2% पेमेंट की जानकारी / Information Of Remaining 2% Payment" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewRemainingTwoPerPayment.aspx.cs" Inherits="Paper_ViewRemainingTwoPerPayment" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>
     बचे हुये 2% पेमेंट की जानकारी / Information Of Remaining 2% Payment
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="RemainingTwoPerPayment.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                &#2337;&#2366;&#2354;&#2375; / New Entry</a>
                        </td>
                         <td style="text-align: right" width="25%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                            Academic Year
                        </td>
                        <td style="text-align: right" width="25%">
                            <asp:Label ID="lblAcYear" runat="server" Visible="false"></asp:Label>
                            <asp:DropDownList runat="server" ID="DdlACYear" Width="262px"
                                CssClass="txtbox reqirerd">
                                <asp:ListItem Text="Select"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: right" width="25%">
                            <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="300px" placeholder="वाउचर क्रमांक खोजे / Search By Voucher No."></asp:TextBox>
                        </td>
                        <td style="text-align: left" width="5%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे / Search" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center" colspan="5">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="Vch_Trans_Id"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="वाउचर क्रमांक<br>Voucher No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVouchar_Tr_Id" runat="server" Visible="false" Text='<%#Eval("Vch_Trans_Id") %>'></asp:Label>
                                            <%#Eval("VoucharNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="वाउचर दिनांक<br>Voucher Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblVoucharDate" runat="server" Text='<%#Eval("VoucharDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="राशि(रुपये में)<br>Amount">
                                        <ItemTemplate>
                                            <%#Eval("TotAmount")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर मिल का नाम<br>Name Of Paper Mill">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="एल.ओ.आई. क्रमांक<br>L.O.I. No.">
                                        <ItemTemplate>
                                            <%#Eval("LOINo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="वाउचर की स्तिथि<br>Voucher Status">
                                        <ItemTemplate>
                                            <asp:Panel ID="Pnl1" runat="server" Visible='<%#Eval("Status").ToString().Equals("0")?true:false%>'>
                                                Sent For Approval
                                            </asp:Panel>
                                            <asp:Panel ID="Pnl2" runat="server" Visible='<%#Eval("Status").ToString().Equals("1")?true:false%>'>
                                                Sent For Approval
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="डाटा में सुधार करे <br> Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnupdate" runat="server" Visible=' <%#Eval("Status").ToString().Equals("0")?true:false%>'>
                                                <a href="RemainingTwoPerPayment.aspx?ID=<%# new APIProcedure().Encrypt( Eval("Vch_Trans_Id").ToString()) %>">डाटा में सुधार करे / Edit</a>
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
    </div>
    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <script type="text/javascript">
        function OpenBill() {
            document.getElementById('fadeDiv').style.display = "block";
            document.getElementById('BillDiv').style.display = "block";

        }


    
    </script>
</asp:Content>
