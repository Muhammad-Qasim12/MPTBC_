<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewChallanDetails.aspx.cs" Inherits="Paper_DispatchDetails"
    Title="पेपर मिल द्वारा सेंट्रल डिपो को डिस्पैच
        की जानकारी / Dispatch Information Of Paper Mill To Central Depot " %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        <%#Eval("PaperVendorName_V")%>पेपर मिल द्वारा सेंट्रल डिपो को डिस्पैच
        की जानकारी / Dispatch Information Of Paper Mill To Central Depot 
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td>   शिक्षा सत्र /Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" Width="200px" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
                                     <td width:
                                         
                                         
                                         >
                    &#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366;
                    &#2344;&#2366;&#2350;/
                    Name Of Paper Mill
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlVendor" Width="250px" 
                        CssClass="txtbox reqirerd" >
                       
                    </asp:DropDownList>
                            </td>
                                    
                                    <td class="auto-style1">
                                        <asp:CheckBox ID="ChkPen" runat="server" />
                                        Pending Challan</td>
                                    
                                    <td>
                                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="200px" placeholder="चालान क्रमांक खोजे / Search By Challan No"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="खोजे / Search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found." DataKeyNames="DisTranId"
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound" PageSize="50">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर मिल का नाम<br>Name Of Paper Mill ">
                                        <ItemTemplate>
                                            <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="इनवाईस नंबर<br>Invoice No.">
                                        <ItemTemplate>
                                            <%#Eval("ChallanNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="इनवाईस दिनांक<br>Invoice Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblChallanDate" runat="server" Text='<%#Eval("ChallanDate")%>'></asp:Label>
                                            <asp:Label ID="lblDisTranId" runat="server" Text='<%#Eval("DisTranId")%>' Visible="false"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पेपर का आकार<br>Paper Size">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperVendorTrId_I")%>'></asp:Label>
                                            <asp:Label ID="lblPaperMstrTrId_I" runat="server" Visible="false" Text='<%#Eval("PaperMstrTrId_I")%>'></asp:Label>
                                            <asp:Label ID="lblLOITrId_I" runat="server" Visible="false" Text='<%#Eval("LOITrId_I")%>'></asp:Label>
                                            <%#Eval("CoverInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="मात्रा (मे. टन)<br>Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperQty" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रदाय दिनांक<br>Supply Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplyDate_D" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रदाय मात्रा (में. टन)<br>Supply Quantity(Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("VdrSendQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्रदाय की अवधि <br>Duration Of Supply Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSupplyTillDate_D" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="डिस्पैच की जानकारी<br>Dispatch Information">
                                        <ItemTemplate>
                                           
                                             <asp:Panel ID="pnupdate2211" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to HO"))?true:false%>'>
                                                <asp:LinkButton ID="lnkChangeSts" runat="server" CausesValidation="false" OnClick="lnkChangeSts_Click" Text='<%#Eval("UpdateStatus") %>'></asp:LinkButton>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel91" runat="server" Visible='<%#(Eval("UpdateStatus").ToString().Equals("Send to HO"))?false:true%>'>
                                                <%#Eval("UpdateStatus") %>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="डेपो की वास्तविक मात्रा (में. टन)<br>Actual Quantity Of Depo (Metric Ton)">
                                        <ItemTemplate>
                                            <%#Eval("ReceivedQty")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="प्राप्त दिनांक<br>Received Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReceivedDate" runat="server" Text='<%#Eval("ReceivedDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="स्वीकार करे<br>Accept">
                                        <ItemTemplate>
                                            <asp:Panel ID="pnupdate" runat="server" Visible='<%#Eval("UpdateStatus").ToString().Equals("Sent to central depot")?true:false%>'>
                                                <a href="ChallanDetails.aspx?ID=<%# new APIProcedure().Encrypt(Eval("DisTranId").ToString()) %>">स्वीकार करे / Accept</a>
                                            </asp:Panel>
                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                             <a href="ChallanDetails.aspx?ID=<%# new APIProcedure().Encrypt(Eval("DisTranId").ToString()) %>">डाटा में सुधार करे / Edit</a>
                                            <asp:Panel ID="pn12update" runat="server" Visible='<%#Eval("UpdateStatus").ToString().Equals("Send to HO")?true:false%>'>
                                                <a href="ChallanDetails.aspx?ID=<%# new APIProcedure().Encrypt(Eval("DisTranId").ToString()) %>">डाटा में सुधार करे / Edit</a>
                                            </asp:Panel>
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
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 137px;
        }
    </style>
</asp:Content>

