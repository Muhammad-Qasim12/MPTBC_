<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPT001_ChecklistMaster.aspx.cs" Inherits="Depo_Tender_DPT001_ChecklistMaster" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePnl">
    <ContentTemplate>
 
      
   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePnl">
    <ProgressTemplate>
    <div class="fade"></div>
    <div class="progress"><img src="../images/loading.gif" alt="Loading..." width="110" height="110" /></div>
    </ProgressTemplate>
    </asp:UpdateProgress>--%>
        
<div class="box table-responsive">
    <div class="portlet-header ui-widget-header">&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2375; &#2309;&#2306;&#2340;&#2352;&#2381;&#2327;&#2340; &#2354;&#2366;&#2327;&#2369; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2358;&#2352;&#2381;&#2340;&#2379; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Tender Condition's Details </div>
              
    <div class="portlet-content">
    <div class="table-responsive">
    <asp:Panel ID="messDiv" runat="server" >
    <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
    </asp:Panel> 

   <div>
     <table width="100%">
     <tr>
     <td style="width:30%;">&#2358;&#2352;&#2381;&#2340; / Condition </td>
     <td>
     <asp:TextBox runat="server" ID="txtCheckListCondition" CssClass="txtbox reqirerd"  MaxLength="255" TextMode="MultiLine"  ></asp:TextBox>
     <cc1:FilteredTextBoxExtender runat="server" ID="filterConditions" InvalidChars="~`!@#$*_<>{}[]|\" FilterMode="InvalidChars"  TargetControlID="txtCheckListCondition" ></cc1:FilteredTextBoxExtender>
     <asp:HiddenField runat="server" ID="HdnTenderCheckListTrno" Value="0" />
     </td>
     </tr>

     <tr>
     <td>&#2360;&#2381;&#2341;&#2367;&#2340;&#2367; / Display Status</td>
     <td>
     <asp:CheckBox runat="server" ID="chkDisplayStatus" />
     </td>

     </tr>

     <tr>
     <td></td>
     <td>
     <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save" CssClass="btn" OnClick="btnSave_Click"  OnClientClick="return ValidateAllTextForm();" />
     <asp:Button runat="server" ID="btnBack" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back " CssClass="btn" />

     </td>
    
     </tr>


     <tr>
     <td colspan="2">
     <asp:Panel runat="server" ID="pnlConditions" GroupingText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2358;&#2352;&#2381;&#2340;&#2375; / Tender Conditions" >
     <asp:GridView runat="server" ID="GrdCondition" AutoGenerateColumns="false" CssClass="tab hastable " OnRowUpdating="GrdCondition_RowUpdating" OnSelectedIndexChanged="GrdCondition_SelectedIndexChanged" >
     <Columns>
     
     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
     <ItemTemplate>
     <%# Container.DataItemIndex+1 %>
     <asp:HiddenField runat="server" ID="HdnTenderCheckListTrno" Value='<%# Eval("TenderCheckListTrno") %>' />
     
     </ItemTemplate>
     </asp:TemplateField>

     <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2358;&#2352;&#2381;&#2340; / Tender Condition">
     <ItemTemplate>
     <asp:Label runat="server" ID="LblCheckListCondition" Text='<%# Eval("CheckListCondition") %>'> </asp:Label>
     </ItemTemplate>
     </asp:TemplateField>

      <asp:TemplateField HeaderText="&#2360;&#2381;&#2341;&#2367;&#2340;&#2367; / Display Status">
     <ItemTemplate>
     <asp:Label runat="server" ID="lblDisplayStatus" Text='<%# Eval("DisplayStatus") %>'> </asp:Label>
     </ItemTemplate>
     </asp:TemplateField>


     <asp:TemplateField HeaderText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit">
     <ItemTemplate>
    <asp:LinkButton Text="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; / Edit" CommandName="Update" ID="linkbtn" runat="server"  ></asp:LinkButton>
     </ItemTemplate>
     </asp:TemplateField>

     </Columns>
          <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
     </asp:GridView>
     
     </asp:Panel>
     
     
     </td>
     </tr>
     </table> 

   </div>
   
     </div> 
     </ContentTemplate> 
     </asp:UpdatePanel> 
</asp:Content>

