<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewRptBalanceReciept.aspx.cs" Inherits="ViewRptBalanceReceipt" EnableEventValidation="false"
    Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot " %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
    खाता पर्ची विवरण 
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                     <tr>
                    <td style="text-align: left">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="नया डाटा डाले / New Entry"   
                            onclick="btnAddnew_Click" />
                    </td>
                </tr>
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td width="23%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" Width="100px" OnInit="ddlAcYear_Init"></asp:DropDownList></td>
                                     <td>
                   &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Printer Name
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlPrinter" Width="200px"  CssClass="txtbox reqirerd"  >
                       </asp:DropDownList>
                            </td>
                                    <td style="text-align: right" width="5%">From Date</td>
                        <td style="text-align: left" width="5%">
                             <asp:TextBox ID="txtFromDt" runat="server"></asp:TextBox>
                                        <cc1:calendarextender ID="txtFromDate_CalendarExtender" Format="dd/MM/yyyy"  runat="server" TargetControlID="txtFromDt">
                        </cc1:calendarextender>
                        </td>
                                    <td style="text-align: right" width="5%">To Date</td>
                                    <td style="text-align: left" width="5%">
                             <asp:TextBox ID="txtToDt" runat="server"></asp:TextBox>
                                        <cc1:calendarextender ID="Calendarextender1" Format="dd/MM/yyyy"  runat="server" TargetControlID="txtToDt">
                        </cc1:calendarextender>
                        </td>   
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                     <td>
                                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="200px" placeholder="Search by Reciept No, Printer, GSM"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center">
                             <div id="ExportDiv" runat="server">
                            <asp:GridView ID="GrdLOI" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found."
                                OnRowDeleting="GrdLOI_RowDeleting" AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging"
                                OnRowDataBound="GrdLOI_RowDataBound" OnRowCreated="GrdLOI_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%--<%# Container.DataItemIndex+1 %>.--%>
                                             <%--<%#Eval("SrR")%>--%>
                                            <asp:Literal ID="ltrSNo" runat="server"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="BR No.">
                                        <ItemTemplate>                                            
                                            <asp:Literal ID="ltrLeader" runat="server" Text='<%#Eval("BalanceRecieptNo")%>' OnDataBinding="ltrLeader_DataBinding"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>   

                                     <asp:TemplateField HeaderText="BR Date">
                                        <ItemTemplate>                                           
                                            <%--<asp:Literal ID="ltrBRDate" runat="server" Text='<%#Eval("BalanceRecieptDate")%>' OnDataBinding="ltrChallanNo_DataBinding"></asp:Literal>--%>
                                            <asp:Literal ID="ltrBRDate" runat="server" Text=''></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>    
                                    
                                    <asp:TemplateField HeaderText="Paper Information">
                                        <ItemTemplate>
                                             <%#Eval("PaperInformation")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>                                                                                                   

                                    <asp:TemplateField HeaderText="Paper Type">
                                        <ItemTemplate>
                                            <%#Eval("PaperType_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Balance">
                                        <ItemTemplate>
                                             <%#Eval("Balance")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Title">
                                        <ItemTemplate>
                                           <asp:HiddenField ID="hdn" runat="server" Value='<%#Eval("BRId")%>'></asp:HiddenField>
                                          <%--  <%#Eval("Remark")%>--%>
                                             <asp:Literal ID="ltrRemark"  runat="server"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                     <asp:TemplateField HeaderText="Paper Mill">
                                        <ItemTemplate>
                                          <%#Eval("PaperVendorName_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField> 

                                     <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                       <asp:LinkButton ID="lnk" Visible='<%#Eval("cntStatus").ToString().Equals("0")?true:false%>' OnClientClick='<%#String.Format("javascript:return getData(\"{0}\")", Eval("BRId").ToString())%>' runat="server" Text=""></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                             <asp:Panel ID="pnl" runat="server">
                                       <a href='PrintBalanceRecieptNew.aspx?PrinterId=<%# new APIProcedure().Encrypt( Eval("PrinterId").ToString())%>&acyr=<%# new APIProcedure().Encrypt( Eval("Acyear").ToString())%>&Ono=<%# new APIProcedure().Encrypt( Eval("BalanceRecieptNo").ToString())%>' target="_blank">Print</a>
                                            </asp:Panel>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                                                                                  
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                
                            </asp:GridView>
                                 </div>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdnFormId" runat="server" />
                <asp:Button ID="btnExport" runat="server" Height="28px" Text="Export to Excel" Visible="false" CssClass="btn" OnClick="btnExport_Click" />
            </div>
        </div>

         <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server">
                 <div align="right">
            <a href="#" onclick="javascript:closeMessagesDiv();">Close</a>
        </div>
                <h2>
                    
                </h2>
                <div class="msg MT10">
                <table class="tab" width="100%">
                    <tr>
                <th colspan="2" style="text-align:left;">खाता पर्ची रद्द करें
                </th>
            </tr>
                    <tr>
                        <td>Reason</td>
                        <td><asp:TextBox ID="txtReason" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date</td>
                        <td><asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>&nbsp;<span style="color: #FF0000; vertical-align:top;">*</span>
                        <cc1:calendarextender ID="Calendarextender2" Format="dd/MM/yyyy"  runat="server" TargetControlID="txtDate">
                        </cc1:calendarextender></td>
                    </tr>
                       <tr>
                        <td colspan="3">
                                                      
                              <asp:Button ID="Button3" CssClass="btn" runat="server" Text="Save" OnClick="btnReason_Click"   />
                            
                             <asp:Button ID="Button2" CssClass="btn" OnClientClick="return closeMessagesDiv();" runat="server" Text="Close"   />
                      
                            </td>
                            
                    </tr>
                </table>
                </div>
              
              
            </div>

    </div>

     <script type="text/javascript">
         function getData(frmid) {
             document.getElementById('<%=hdnFormId.ClientID%>').value = frmid;
             var objfadediv = document.getElementById('<%=fadeDiv.ClientID%>');
             var objmsgdiv = document.getElementById('<%=Messages.ClientID%>');
             //alert(objfadediv); alert(frmid); alert(objmsgdiv);
             objfadediv.style.display = "block";
             objmsgdiv.style.display = "block";
             return false;
         }

         function closeMessagesDiv() {
             var objfadediv = document.getElementById('<%=fadeDiv.ClientID%>');
             var objmsgdiv = document.getElementById('<%=Messages.ClientID%>');
             objfadediv.style.display = "none";
             objmsgdiv.style.display = "none";
                    return false;
         }

         function validateFlds() {
             
                 var dt = document.getElementById('<%=txtDate.Text%>');
                 var txtReason = document.getElementById('<%=txtReason.Text%>');
                 if(txtReason == "")
                 {
                     alert("Please enter reason");
                     return false;
                 }
                 if(dt == "")
                 {
                     alert("Please enter date");
                     return false;
                 }
             }
             </script>
</asp:Content>
