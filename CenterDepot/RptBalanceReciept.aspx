<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RptBalanceReciept.aspx.cs" Inherits="RptBalanceReciept"
    Title="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2360;&#2375;&#2306;&#2335;&#2381;&#2352;&#2354; &#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2337;&#2367;&#2360;&#2381;&#2346;&#2376;&#2330;
        &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Dispatch Information Of Paper Mill To Central Depot " %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
    &#2326;&#2366;&#2340;&#2366; &#2346;&#2352;&#2381;&#2330;&#2368;
    </div>
    <div class="portlet-content">
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td style="text-align: left">
                            <table>
                                <tr>
                                    <td width="27%">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352;/Acadmic Year : <asp:DropDownList ID="ddlAcYear" runat="server" Width="100px" OnInit="ddlAcYear_Init"></asp:DropDownList>
                                         
                                    </td>
                                     <td>
                    &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />
                    Printer Name
                </td>
                <td>
                     <asp:DropDownList runat="server" ID="ddlPrinter" Width="200px"  CssClass="txtbox reqirerd"  >
                       </asp:DropDownList> &nbsp;<span style="color: #FF0000; vertical-align:top;">*</span>
                            </td>
                                    <td style="text-align: right">Date</td>
                        <td style="text-align: left" width="18%">
                             <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>&nbsp;<span style="color: #FF0000; vertical-align:top;">*</span>
                            
                                        <cc1:calendarextender ID="txtFromDate_CalendarExtender" Format="dd/MM/yyyy"  runat="server" TargetControlID="txtDate">
                        </cc1:calendarextender>
                        </td>                                    
                                    <td>GSM</td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlGSM" Width="200px"  CssClass="txtbox"  >
                       </asp:DropDownList>
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
                    Balance Receipt No
                </td>
                <td>
                     <asp:TextBox ID="txtBalanceRecptNo" Enabled="false" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                    &nbsp;<span style="color: #FF0000; vertical-align:top;">*</span>
                    <asp:HiddenField ID="hdnBalanceRecptNo" Value="" runat="server" />
                            </td>
                                   
                         <td> Balance &#2332;&#2366;&#2352;&#2368;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td>
                     <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="txtbox"></asp:DropDownList>
                    
                </td>

                   
                   <td> <asp:RadioButtonList ID="rdOption" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="ddlPrinter_SelectedIndexChanged" >
                        <asp:ListItem Value="1" Selected="True">&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;</asp:ListItem>
                        <asp:ListItem  Value="2">&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351;&#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368;</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                                    
                                    </tr>

                                   <tr>
                                       <td>Title/&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;:</td>
                                        <td><asp:CheckBoxList ID="cblTitles" runat="server" RepeatDirection="Horizontal">
                                        </asp:CheckBoxList>
                                           
                                        </td>

                                     <td>
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                                            OnClick="btnSearch_Click" OnClientClick="return chkDdl();" />

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
                                AllowPaging="True" OnPageIndexChanging="GrdLOI_PageIndexChanging" OnRowDataBound="GrdWorkPlan_RowDataBound"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chk" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="GSM">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>   

                                     <asp:TemplateField HeaderText="Progressive Allotment<br>(M.T/Sheet)">
                                        <ItemTemplate>
                                            
                                             <asp:Label ID="lblProgAllotQty" runat="server" Text='<%#Eval("ProgAllotQty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                                                      

                                    <asp:TemplateField HeaderText="Progressive Supply<br>(M.T/Sheet)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProgSupplyQty" runat="server" Text='<%#Eval("ProgSupplyQty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Balance<br>(M.T/Sheet)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalance" runat="server" Text='<%#Eval("Balance")%>'></asp:Label>
                                            <asp:HiddenField ID="hdnPaperMstrTrID_I" Value='<%#Eval("PaperMstrTrID_I")%>' runat="server" />
                                            <asp:HiddenField ID="hdnPaperType_V" Value='<%#Eval("PaperType_V")%>' runat="server" />
                                             <asp:HiddenField ID="hdnGSM" Value='<%#Eval("GSM")%>' runat="server" />
                                            <asp:HiddenField ID="hdnPrinterId" Value='<%#Eval("PrinterId")%>' runat="server" />
                                            <asp:HiddenField ID="hdnPaperMilID" Value='<%#Eval("PaperMilID")%>' runat="server" />
                                            <asp:HiddenField ID="hdnTitleId_I" Value='<%#Eval("TitleId_I")%>' runat="server" />
                                           <asp:HiddenField ID="hdnPId" Value='' runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Paper Mill" >
                                     <ItemTemplate>
                                         <asp:DropDownList ID="ddlMil" runat="server">
                                         </asp:DropDownList>
                                     </ItemTemplate>
                                </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Title" Visible="false">
                                     <ItemTemplate>
                                         <asp:DropDownList ID="ddlTitle" runat="server">
                                         </asp:DropDownList>
                                     </ItemTemplate>
                                </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remark" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox"></asp:TextBox>  
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                                                                                    
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                
                            </asp:GridView>
                                 </div>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: center">
                             <div id="Div1" runat="server"><br /><br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="tab" Width="100%" EmptyDataText="Record Not Found."
                                 AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                                OnRowDataBound="GridView1_RowDataBound" OnRowCreated="GridView1_RowCreated">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                           <%-- <%# Container.DataItemIndex+1 %>.--%>
                                              <asp:Literal ID="ltrSNo" runat="server"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="BR No.">
                                        <ItemTemplate>
                                             
                                            <asp:Literal ID="ltr" runat="server" Text='<%#Eval("BalanceRecieptNo")%>' 
                                                 OnDataBinding="ltrChallanNo_DataBinding"></asp:Literal>
                                           <asp:HiddenField ID="hdn" runat="server" Value='<%#Eval("BRId")%>'></asp:HiddenField>
                                        </ItemTemplate>
                                    </asp:TemplateField>   

                                     <asp:TemplateField HeaderText="BR Date">
                                        <ItemTemplate>                                           
                                            <asp:Literal ID="ltrLeader" runat="server" Text='<%#Eval("BalanceRecieptDate")%>' 
                                                 OnDataBinding="ltrDemandFrom_DataBinding"></asp:Literal>
                                        </ItemTemplate>
                                    </asp:TemplateField>  

                                    <asp:TemplateField HeaderText="Paper Information">
                                        <ItemTemplate>
                                             <%#Eval("PaperInformation")%>
                                            <asp:HiddenField ID="hdnPrinterId11" runat="server" Value='<%#Eval("PrinterId")%>' />
                                            <asp:HiddenField ID="hdnAcyr" runat="server" Value='<%#Eval("Acyear")%>' />
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
                                       <asp:LinkButton ID="lnk" OnClientClick='<%#String.Format("javascript:return getData(\"{0}\")", Eval("BRId").ToString())%>' runat="server" Text="Cancel"></asp:LinkButton>
                                        <asp:Panel ID="pnl" runat="server">
                                            &nbsp;|&nbsp;
                                        <a href='PrintBalanceRecieptNew.aspx?PrinterId=<%# new APIProcedure().Encrypt( Eval("PrinterId").ToString())%>&acyr=<%# new APIProcedure().Encrypt( Eval("Acyear").ToString())%>&Ono=<%# new APIProcedure().Encrypt( Eval("BalanceRecieptNo").ToString())%>' target="_blank">Print</a>
                                            </asp:Panel>
                                        <%--<asp:LinkButton ID="lnkPrint" runat="server" Text="प्रिंट करें" OnClick="lnkPrint_Click"></asp:LinkButton>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                           
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                
                            </asp:GridView>
                                 </div>
                        </td>
                    </tr>

                     <tr>
                    <td style="height: 26px" colspan="4">
                        <asp:Button ID="btnSave" runat="server" ValidationGroup="grp" CssClass="btn" OnClick="btnSave_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " OnClientClick="return valAll();" />
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="hdnFormId" runat="server" />
                    </td>
                </tr>

                </table>
                
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
                <th colspan="2" style="text-align:left;">&#2326;&#2366;&#2340;&#2366; &#2346;&#2352;&#2381;&#2330;&#2368; &#2352;&#2342;&#2381;&#2342; &#2325;&#2352;&#2375;&#2306;
                </th>
            </tr>
                    <tr>
                        <td>Reason</td>
                        <td><asp:TextBox ID="txtReason" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Date</td>
                        <td><asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"></asp:TextBox>&nbsp;<span style="color: #FF0000; vertical-align:top;">*</span>
                        <cc1:calendarextender ID="Calendarextender2" Format="dd/MM/yyyy"  runat="server" TargetControlID="TextBox1">
                        </cc1:calendarextender></td>
                    </tr>
                       <tr>
                        <td colspan="3">
                                                      
                              <asp:Button ID="Button3" CssClass="btn" runat="server" Text="Save" OnClick="btnReason_Click" CausesValidation="false" OnClientClick="return validateFlds();"   />
                            
                             <asp:Button ID="Button2" CssClass="btn" OnClientClick="return closeMessagesDiv();" runat="server" Text="Close"   />
                      
                            </td>
                            
                    </tr>
                </table>
                </div>
              
              
            </div>

    </div>


<script type="text/javascript">
    function chkDdl() {
        if (document.getElementById('<%=ddlPrinter.ClientID%>').selectedIndex == 0) {
            alert("Please select Printer name");
            return false;
        }
        if (document.getElementById('<%=txtDate.ClientID%>').value == "") {
            alert("Please enter date");
            return false;
        }

        //return ValidateCheckBoxList();
    }

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
             
             var dt = document.getElementById('<%=txtDate.ClientID%>');
             var txtReason = document.getElementById('<%=txtReason.ClientID%>');
             //alert(dt); alert(txtReason);
             if (txtReason.value == "")
             {
                 alert("Please enter reason");
                 return false;
             }
             //if (dt.value == "")
             //{
             //    alert("Please enter date");
             //    return false;
             //}
             return true;
         }

    function ValidateCheckBoxList() {
        var checkBoxList = document.getElementById("<%=cblTitles.ClientID %>");
         var checkboxes = checkBoxList.getElementsByTagName("input");
         var isValid = false;
         for (var i = 0; i < checkboxes.length; i++) {
             if (checkboxes[i].checked) {
                 isValid = true;
                 break;
             }
         }
         if (isValid == true) {
             return true;
         }
         else {             
             return false;
         }
    }

    function valAll() {
        if (ValidateAllTextForm() == true) {
            if (ValidateCheckBoxList() == true) {
                return true;
            }
            else {
                alert('Please select Title');
                return false;
            }
        }
        else {
            return false;
        }
    }
             </script>

</asp:Content>
