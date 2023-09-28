<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="BillProcessPaymentInfo.aspx.cs" Inherits="DistributionB_BillProcessPaymentInfo"
    Title="देयक निर्माण एवं प्राप्त राशि का विवरण" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>देयक निर्माण एवं प्राप्त राशि का विवरण / Bill Process and Received Payment Information</span>
            </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
                    <tr>
                    <td>
                       <asp:Button ID="btnNewFreeDistribution" CssClass="btn" OnClick="btnNewFreeDistribution_Click"
                            runat="server" Text="नया बिल जोडें / Add New Bill" />
                    </td><td>


                    </td>
                      <td >
          शिक्षा सत्र / Academic Year
                    </td>
                    <td >
                         <asp:DropDownList ID="ddlAcYr" CssClass="txtbox" runat="server"></asp:DropDownList>
                    </td>
                    
                    <td>
                     

                    </td>
                </tr>
                <tr>
                 
                      <td >
               मांगकर्ता विभाग का नाम   <br />
                           Demand Receive from Department 
                    </td>
                    <td >
                       <asp:DropDownList ID="ddlDepartmentName" CssClass="txtbox" runat="server"></asp:DropDownList>
                    </td>
                    <td>
 अन्य पाठ्यसामाग्री का नाम <br />Other then TextBook Item

                    </td>
                    <td>
                       <asp:DropDownList ID="ddlTitle" CssClass="txtbox" runat="server"></asp:DropDownList>

                    </td>
                </tr>
                <tr>
                      <td>
                        दिनांक से<br />From Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="txtbox" MaxLength="10" ></asp:TextBox>
                        <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                    <td>
                         दिनांक तक<br />To Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox" MaxLength="10" ></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                            Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                      <td>
                       
                          </td>
                          <td>
                        <asp:Button ID="btnSearch" CssClass="btn" OnClick="btnSearch_Click"
                            runat="server" Text="खोजें" />
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GrdLetterInfo" runat="server" AutoGenerateColumns="false" CssClass="tab"
                            OnRowEditing="GrdLetterInfo_OnRowEditing" OnRowDeleting="GrdLetterInfo_OnRowDeleting"
                              EmptyDataText="Record Not Found.">
                            <Columns>
                                <asp:TemplateField HeaderText="क्रमांक/ S.No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="BillType_V" HeaderText="बिल का प्रकार/ Type of Bill" />
                                 <asp:BoundField DataField="AcYear" HeaderText="शिक्षा सत्र / Academic Year " />
                                <asp:TemplateField HeaderText="पत्र क्र० / Letter No">
                                    <ItemTemplate>
                                        <a href="DIB_005_ProcessBill.aspx?ID=<%# new APIProcedure().Encrypt(Eval("ProcessBillTrno_I").ToString()) %>">
                                            <%# Eval("LetterNo_V") %>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="LetterDate_D" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="पत्र दिनांक / Letter Date" />
                                 <asp:BoundField DataField="Title" HeaderText="शीर्षक का नाम /Title " />
                                <asp:BoundField DataField="DepartmentName_V" HeaderText="संस्था का नाम / Department Name" />
                                <asp:BoundField DataField="NetAmount_I" DataFormatString="{0:N}" HeaderText="शुद्ध मूल्य(रुपए) / Net Amount (Rs.)" />
                                <asp:TemplateField HeaderText="भुगतान प्राप्ति की जानकारी / Recieved Payment Information">
                                    <ItemTemplate>
                                        <a href="DIB_008_BillPayment.aspx?ID=<%#  new APIProcedure().Encrypt(Eval("ProcessBillTrno_I").ToString())  %>">क्लिक करें
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Print">
                                    <ItemTemplate>
                                        <a href="PrintData.aspx?ID=<%#Eval("ProcessBillTrno_I").ToString() %>">क्लिक करें
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
            <div style="height: 5px;">
            </div>
        </div>
    </div>
</asp:Content>
