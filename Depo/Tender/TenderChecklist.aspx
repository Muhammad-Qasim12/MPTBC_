<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="TenderChecklist.aspx.cs" Inherits="Depo_Tender_TenderChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                          <div class="box table-responsive">                
       <div class="portlet-header ui-widget-header"> &#2340;&#2325;&#2344;&#2368;&#2325;&#2368; &#2358;&#2352;&#2381;&#2340;&#2375; &#2325;&#2366; &#2352;&#2381;&#2330;&#2375;&#2325;&#2354;&#2367;&#2360;&#2381;&#2335; / Checklist Of Technical Condition </div>
                     <div class="portlet-content">
                     <div class="table-responsive ">
                             
                             <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 


     
                   
                    <table style="width: 100%">                   
                        <tr>
                            <td colspan="5">
                                  <asp:GridView runat="server" ID="GrdCondition" AutoGenerateColumns="false" CssClass="tab hastable"  OnRowDataBound="GrdCondition_RowDataBound" >
     <Columns>
     
     <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
     <ItemTemplate>
     <%# Container.DataItemIndex+1 %>
     </ItemTemplate>
     </asp:TemplateField>
          <asp:TemplateField HeaderText="स्थिति / Status">
     <ItemTemplate>
     <asp:CheckBox ID="chkSelect" runat="server" />
     </ItemTemplate>
     </asp:TemplateField>
     <asp:TemplateField HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2325;&#2368; &#2358;&#2352;&#2381;&#2340; / Tender Condition">
     <ItemTemplate>
          <asp:Label runat="server" ID="lblId" Visible="false" Text='<%# Eval("TenderCheckListTrno") %>'> </asp:Label>
          <asp:Label runat="server" ID="lblIdSrNo" Visible="false" Text='<%# Eval("TransID") %>'> </asp:Label>
         <asp:Label runat="server" ID="lblDisplayStatus" Visible="false" Text='<%# Eval("CheckStatus") %>'> </asp:Label>
     <asp:Label runat="server" ID="LblCheckListCondition" Text='<%# Eval("CheckListCondition") %>'> </asp:Label>
     </ItemTemplate>
     </asp:TemplateField>
         <asp:TemplateField HeaderText="अपलोड डॉक्यूमेंट / Upload Document">
     <ItemTemplate>
    <asp:FileUpload ID="Fileregistration_V" runat="server"  />
     </ItemTemplate>
     </asp:TemplateField>
          <asp:TemplateField HeaderText="">
     <ItemTemplate>
         
           <asp:Label ID="lblFilePath"  runat="server" Visible="false" Text='<%#Eval("FilePath") %>'></asp:Label>
         <asp:Label ID="lblDocPath"  runat="server"></asp:Label>
    
     </ItemTemplate>
     </asp:TemplateField>
        
     </Columns>
          <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
     </asp:GridView>

                            </td>

                        </tr>
                         <tr>
                    <td  colspan="5">
                    <asp:HiddenField ID="HdnChklstid" Value="0" runat="server" />
                    <asp:Button ID="btnSaveCheckList" runat="server" Text="सुरक्षित करे / Save" CssClass="btn" OnClick="btnSaveCheckList_Click" />

                    <asp:Button runat="server" ID="BtnBack" Text=" &#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; / Back" CssClass="btn" OnClick="BtnBack_Click" />
                        
                    </td>
                    </tr>
                        </table>

</div> 
</div> 
</div>
</asp:Content>

