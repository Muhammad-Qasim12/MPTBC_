<%@ Page Title="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2352;&#2367;&#2325;&#2381;&#2357;&#2375;&#2360;&#2381;&#2335; / Book Return Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT010_BookReturnDetails.aspx.cs" Inherits="Depo_DPT010_BookReturnDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2357;&#2366;&#2346;&#2360;&#2368; &#2325;&#2368; &#2352;&#2367;&#2325;&#2381;&#2357;&#2375;&#2360;&#2381;&#2335; / Book Return Details</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <ContentTemplate>
                  <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                     <table width="100%">
                         <tr>
                             <td style="width: 284px; height: 32px">
                                 &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Book No. <span class="required">*</span></td>
                             <td style="height: 32px" colspan="3">
                                 <asp:TextBox ID="txtbookNo" runat="server" AutoPostBack="True" 
                                     CssClass="txtbox " MaxLength="12" 
                                     ontextchanged="txtbookNo_TextChanged"></asp:TextBox> 

                             </td>
                         </tr>
                         <tr>
                             <td style="width: 284px; height: 32px">
                                 &#2325;&#2325;&#2381;&#2359;&#2366; / Class </td>
                             <td style="height: 32px">
                                 <asp:Label ID="lblClass" runat="server" CssClass="txtbox"></asp:Label>
                             </td>
                             <td style="height: 32px">
                                 &#2357;&#2367;&#2359;&#2351; / Subject 
                             </td>
                             <td style="height: 32px">
                                 <asp:Label ID="lblSub" runat="server" CssClass="txtbox"></asp:Label>
                             </td>
                         </tr>
                         <tr
                         
                         >
                             <td style="width: 284px; height: 32px">
                                 &#2325;&#2366;&#2352;&#2339; / Reason <span class="required">*</span></td>
                             <td colspan="3" style="height: 32px">
                                 <asp:DropDownList ID="ddlReason" runat="server" CssClass="txtbox ">
                                     <asp:ListItem Value="0">Select..</asp:ListItem>
                                     <asp:ListItem Value="1">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2350;&#2375;&#2306; &#2331;&#2346;&#2366;&#2312; &#2360;&#2361;&#2368; &#2344;&#2361;&#2368;&#2306; &#2361;&#2376;  </asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="4" style="height: 32px">
                                 <asp:Button ID="Button2" runat="server" CssClass="btn" onclick="Button2_Click" 
                                      Text="&#2332;&#2379;&#2396;&#2375;/Add" />
                                 <asp:HiddenField ID="hdmidum" runat="server" />
                                 <asp:HiddenField ID="hdbookDate" runat="server" />
                                 <asp:HiddenField ID="hdOrdeeNo" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td colspan="4" style="height: 32px">
                                 <asp:GridView ID="grdBook" runat="server" AutoGenerateColumns="False" 
                                     CssClass="tab" DataKeyNames="Sno" OnRowDeleting="grdBook_RowDeleting">
                                     <Columns>
                                         <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; /S.No.">
                                             <ItemTemplate>
                                                 <asp:Label ID="Label1" runat="server" Text='<%# Eval("Sno") %>'></asp:Label>
                                                 <asp:HiddenField ID="HiddenField1" runat="server" 
                                                     Value='<%# Eval("BandalNO") %>' />
                                                 <asp:HiddenField ID="HiddenField4" runat="server" Value='<%# Eval("TitaleID") %>'  />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                         <asp:BoundField HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;/Medium "  DataField="Medium" />
                                         <asp:BoundField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;/Class " DataField="ClassName" />
                                         <asp:BoundField DataField="SubjectName" HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" />
                                         <asp:BoundField HeaderText="&#2325;&#2366;&#2352;&#2339;/ Reason" DataField="Reason"/>
                                         <asp:BoundField DataField="BookNo" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Book No." />
                                         <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2326;&#2352;&#2368;&#2342; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Book Purchase Date " DataField="Date" />
                                         <asp:BoundField HeaderText="&#2325;&#2376;&#2358; &#2350;&#2375;&#2350;&#2379; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Cash Memo No" DataField="OrderNO" />
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <asp:Button ID="imgbtnDelete" runat="server" CommandName=" Delete" 
                                                     CssClass="btn" Text=" &#2361;&#2335;&#2366;&#2351;&#2375;&#2306; / Delete" />
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                     </Columns>
                                     <PagerStyle CssClass="Gvpaging" />
                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                 </asp:GridView>
                             </td>
                         </tr></table>
                         <br />
                       <table width="100%" style="display:none" id="aaaa" runat="server" >
                         <tr>
                             <td style="width: 284px; height: 32px">
                                 &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;/Date <span class="required">*</span></td>
                             <td colspan="3" style="height: 32px">
                                 <asp:TextBox ID="txtDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                                     <cc1:calendarextender ID="CalendarExtender1" runat="server" 
                    TargetControlID="txtDate" Format="dd/MM/yyyy"></cc1:calendarextender>
                   
        
                             </td>
                         </tr>
                             <tr>
                             <td style="width: 284px; height: 32px">&#2357;&#2366;&#2346;&#2360;&#2367; &#2344;&#2367;&#2357;&#2375;&#2342;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/Return Request No
                                </td>
                             <td colspan="3" style="height: 32px">
                                 <asp:TextBox ID="txtOrderNo" runat="server" CssClass="txtbox reqirerd" Enabled="false" ></asp:TextBox>
                              
        
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 284px; height: 32px">
                                 &#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350;/Depot Name <span class="required">*</span></td>
                             <td colspan="3" style="height: 32px">
                                 <asp:DropDownList ID="ddlDepo" runat="server" CssClass="txtbox reqirerd">
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td style="width: 284px; height: 32px">
                                 &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/Total Books </td>
                             <td colspan="3" style="height: 32px">
                                 <asp:Label ID="lblTotalNo" runat="server" CssClass="txtbox"></asp:Label>
                             </td>
                         </tr>
                         
                         <tr>
                             <td style="width: 284px; height: 58px">
                                 &#2352;&#2367;&#2352;&#2381;&#2350;&#2366;&#2325;/Remark</td>
                             <td colspan="3" style="height: 58px">
                                 <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox " Height="54px" 
                                     TextMode="MultiLine" Width="271px" onkeypress="MaxLengthCount('ContentPlaceHolder1_txtIns_CoverDetail_V',250);"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="4">
                                 <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; /Save" 
                                     Visible="False" onclick="Button1_Click" OnClientClick='javascript:return ValidateAllTextForm();'/>
                                 <asp:HiddenField ID="HiddenField2" runat="server" />
                                 <asp:HiddenField ID="HiddenField3" runat="server" />
                             </td>
                         </tr>
                     </table>
                 </ContentTemplate>
                        </asp:UpdatePanel>
        </div>
    </div>
     <script type="text/javascript" >

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
</asp:Content>

