<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT002_TenderMaster.aspx.cs" Inherits="Depo_Tender_DPT002_TenderMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
<asp:UpdatePanel runat="server" ID="UpdatePnl">
<ContentTemplate>
 
      
<asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePnl">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>
                            <div class="box table-responsive">
                            <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Information  </div>
              
                     <div class="portlet-content">
                     <div class="table-responsive">
                              <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
     </asp:Panel> 

                    

                     <table width="100%">
                     <tr>
                     <td>&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Tender Name / No. /  </td>
                     <td colspan="3">
                         <asp:TextBox ID="txtTenderNo_V" runat="server" MaxLength="80" Width="300px" CssClass="txtbox reqirerd"  ></asp:TextBox>
                         <cc1:FilteredTextBoxExtender runat="server" ID="filterTenderNo_V" TargetControlID="txtTenderNo_V" FilterMode="InvalidChars"  InvalidChars="~`!@#$=%^&*()+*?<>{}+|\/_" ></cc1:FilteredTextBoxExtender>
                     </td>

                     </tr>

                      <tr>
                    
                     <td colspan="4" ></td> </tr> 


                     <tr>
                     <td>Tender Date / &#2335;&#2375;&#2306;&#2337;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                     <td>
                     <asp:TextBox ID="txtTenderDate_D" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox> 
                     
                     <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtTenderDate_D" TargetControlID="txtTenderDate_D" runat="server"></cc1:CalendarExtender>
                   
                                         
                     </td>
                    
                     <td>NI<asp:HiddenField ID="HiddenField1" runat="server" />
                         T Publish Date / निविदा प्रकाशन की दिनांक </td>
                     <td>
                     <asp:TextBox ID="txtNITDate_D" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>  
                       <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtNITDate_D" TargetControlID="txtNITDate_D" runat="server"></cc1:CalendarExtender>
                      
                     </td>
                     </tr>

                     <tr>
                     <td>Tender Document Fee / &#2335;&#2375;&#2306;&#2337;&#2352; &#2337;&#2377;&#2325;&#2381;&#2351;&#2370;&#2350;&#2375;&#2306;&#2335; &#2347;&#2368;&#2360; &#2352;&#2369;.</td>
                     <td>
                     <asp:TextBox ID="txtTenderDocFee_N" runat="server" MaxLength="8" CssClass="txtbox reqirerd" onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>                     
                     </td>
                    
                     <td>Tender Submission Date / &#2335;&#2375;&#2306;&#2337;&#2352; &#2332;&#2350;&#2366; &#2325;&#2352;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                     <td>
                     <asp:TextBox ID="txtTenderSubmissionDate_D" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>     
                     
                  <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtTenderSubmissionDate_D" TargetControlID="txtTenderSubmissionDate_D" runat="server"></cc1:CalendarExtender>
                                
                     </td>
                     </tr>

                      <tr>
                     <td>Tech Bid Opening Date / &#2335;&#2375;&#2325;&#2381;&#2344;&#2367;&#2325;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
                     <td>
                     <asp:TextBox ID="txtTechBidopeningDate_D" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox>  
                     
                      <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtTechBidopeningDate_D" TargetControlID="txtTechBidopeningDate_D" runat="server"></cc1:CalendarExtender>
                                   
                     </td>
                    
                     <td>Commecial Bid Opening Date / &#2325;&#2350;&#2352;&#2381;&#2358;&#2367;&#2351;&#2354; &#2348;&#2367;&#2337; &#2326;&#2369;&#2354;&#2344;&#2375; &#2325;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
                     <td>
                     <asp:TextBox ID="txtCommecialBidOpeningdate_D" runat="server" MaxLength="10" CssClass="txtbox reqirerd"></asp:TextBox> 
                       <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CaltxtCommecialBidOpeningdate_D" TargetControlID="txtCommecialBidOpeningdate_D" runat="server"></cc1:CalendarExtender>
                     
                                         
                     </td>
                     </tr>
                     
                     <tr>
                    
                     <td colspan="4" >
                          <asp:Panel runat="server" ID="pnlConditions" GroupingText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2358;&#2352;&#2381;&#2340;&#2375; / Tender Conditions" >
     <asp:GridView runat="server" ID="GrdCondition" AutoGenerateColumns="false" CssClass="tab hastable "  OnRowDataBound="GrdCondition_RowDataBound">
     <Columns>
     
     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
     <ItemTemplate>
     <%# Container.DataItemIndex+1 %>
     </ItemTemplate>
     </asp:TemplateField>
          <asp:TemplateField HeaderText="चुने / Select">
     <ItemTemplate>
     <asp:CheckBox ID="chkSelect" runat="server" />
     </ItemTemplate>
     </asp:TemplateField>
     <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2358;&#2352;&#2381;&#2340; / Tender Condition">
     <ItemTemplate>
          <asp:Label runat="server" ID="lblId" Visible="false" Text='<%# Eval("TenderCheckListTrno") %>'> </asp:Label>
          <asp:Label runat="server" ID="lblIdSrNo" Visible="false" Text='<%# Eval("TenChkTrno_I") %>'> </asp:Label>
         <asp:Label runat="server" ID="lblDisplayStatus" Visible="false" Text='<%# Eval("DisplayStatus") %>'> </asp:Label>
     <asp:Label runat="server" ID="LblCheckListCondition" Text='<%# Eval("CheckListCondition") %>'> </asp:Label>
     </ItemTemplate>
     </asp:TemplateField>

     


  

     </Columns>
          <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
     </asp:GridView>
     
     </asp:Panel>


                     </td> </tr> 

                     <tr>
                    
                     <td colspan="4" >
                         <asp:Button ID="BtnTenderSave" runat="server" Text="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; &#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"  CssClass="btn" OnClick="BtnTenderSave_Click" OnClientClick="return ValidateAllTextForm();" />
                          <asp:Button ID="BtnBack" runat="server" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back"  CssClass="btn" OnClick="BtnBack_Click" />
                         <asp:HiddenField ID="HiddenField2" runat="server" />
                     </td>
                     </tr>

             
                     </table>



                    
                     </div>
                     </div> 

                     </ContentTemplate> 
                      </asp:UpdatePanel> 
</asp:Content>

