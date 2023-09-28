<%@ Page Title=" थब्बे से संबंधित देयक के भुगतान की जानकारी / Information Of Defective Payment" Language="C#" MasterPageFile="~/MasterPage.master" 
    AutoEventWireup="true" CodeFile="ViewDefectivePayment.aspx.cs" Inherits="Paper_ViewDefectivePayment" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%--Dispatch to C'Depot by Paper vendor--%>
      थब्बे से संबंधित देयक के भुगतान की जानकारी / Information Of Defective Payment
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left" width="20%">
                            <a class="btn" href="DefectivePayment.aspx">&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366;
                                &#2337;&#2366;&#2354;&#2375; / New Entry</a>
                        </td>
                          <td style="text-align: right" width="30%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;
                        <br />
                        Acadmic Year :
                    </td>
                    <td style="text-align: left" width="15%">
                        <asp:DropDownList ID="ddlAcYear" runat="server" OnInit="ddlAcYear_Init"  Width="245px"></asp:DropDownList>
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
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="Tha_Vch_Trans_Id"
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
                                            <asp:Label ID="lblVouchar_Tr_Id" runat="server" Visible="false" Text='<%#Eval("Tha_Vch_Trans_Id") %>'></asp:Label>
                                             <asp:HiddenField ID="hdnStatus" runat="server" Value='<%#Eval("Status") %>' />
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

                                    <%--<asp:TemplateField HeaderText="वाउचर की स्तिथि<br>Voucher Status">
                                        <ItemTemplate>
                                            <asp:Panel ID="Pnl1" runat="server" Visible='<%#Eval("Status").ToString().Equals("0")?true:false%>'>
                                                Sent For Approval
                                            </asp:Panel>
                                            <asp:Panel ID="Pnl2" runat="server" Visible='<%#Eval("Status").ToString().Equals("1")?true:false%>'>
                                                Sent For Approval
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="डाटा में सुधार करे <br> Edit">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnupdate" runat="server" Visible=' <%#Eval("Status").ToString().Equals("0")?true:false%>'>
                                                <a href="DefectivePayment.aspx?ID=<%# new APIProcedure().Encrypt( Eval("Tha_Vch_Trans_Id").ToString()) %>">डाटा में सुधार करे / Edit</a>
                                            </asp:Panel>
                                           <asp:Panel ID="Panel1" runat="server" Visible='<%#Eval("Status").ToString().Equals("2")||Eval("Status").ToString().Equals("3")?true:false%>'>
                                                <a href="DefectivePayment.aspx?ID=<%# new APIProcedure().Encrypt( Eval("Tha_Vch_Trans_Id").ToString()) %>&vw=1" target="_blank">&#2342;&#2375;&#2326;&#2375;&#2306; / View</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="&#2357;&#2366;&#2313;&#2330;&#2352; &#2325;&#2368; &#2360;&#2381;&#2340;&#2367;&#2341;&#2367;<br>Voucher Status">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnBtnViewGroup" runat="server" OnClick="lnBtnViewGroup_Click"></asp:LinkButton>
                                               <asp:Label ID="ltrStatus"  runat="server" Visible="false"></asp:Label>
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


