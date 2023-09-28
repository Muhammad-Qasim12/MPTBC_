<%@ Page Title="मुद्रण निविदा के लिए ग्रुप निर्माण" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="GroupCreation.aspx.cs" Inherits="DistributionB_GroupCreation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="table-responsive">

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


<div class="portlet-header ui-widget-header">मुद्रण निविदा के लिए ग्रुप निर्माण / Group Creation for Printing Tenders</div>
                     <div class="portlet-content">
                     <div class="table-responsive ">
           


           <asp:Panel ID="messDiv" runat="server" >
        <asp:Label runat="server" ID="lblMess" class="notification" ></asp:Label>
        </asp:Panel> 

        <div>
        
        <table width="100%">
<tr>
<th colspan="2"><asp:HiddenField ID="HdnGroupId" runat="server" Value="0" /></th>
</tr>

<tr>
<th>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350; / Group Name</th>

<td><asp:TextBox runat="server" ID="txtGroupName" CssClass="txtbox reqirerd" MaxLength="30"></asp:TextBox></td>
    
    

</tr>
<tr>

<th>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depo </th>


<td>
<asp:CheckBoxList ID="chkDepots" runat="server" RepeatColumns="4" CssClass="txtbox reqirerd" >
</asp:CheckBoxList>

</td>




</tr>



<tr>
<td colspan="2">

<asp:Button runat="server" ID="btnSaveGroup" Text="&#2327;&#2381;&#2352;&#2369;&#2346; &#2348;&#2344;&#2366;&#2351;&#2375; " CssClass="btn" OnClick="btnSaveGroup_Click" OnClientClick="return ValidateAllTextForm();"  />
</td>
</tr>

<tr>
<td colspan="2">
<div>
    <asp:GridView runat="server" ID="grdGroup" AutoGenerateColumns="false" OnRowUpdating="grdGroup_RowUpdating"
        CssClass="tab" DataKeyNames ="GroupID_I" OnRowDeleting ="grdGroup_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex+1  %>
                    <asp:HiddenField runat="server" ID="HdnGroupId" Value='<%# Eval("GroupID_I") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350; /Group Name">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblGroupName" Text='<%# Eval("GroupName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;/Depo">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDepotIds" Text='<%# Eval("DepoName_V") %>'></asp:Label>
                    <asp:HiddenField runat="server" ID="HdnDepotIds" Value='<%# Eval("DepoID_I") %>' />
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="LinkEdit" CommandName="Update">Edit</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField >
              <asp:TemplateField Visible="false" HeaderText="">
                <ItemTemplate>
                    <asp:LinkButton runat="server" ID="LinkDelete" CommandName="Delete">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns><PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
    </asp:GridView>
    </div>
</td>
</tr>

</table>
        
        </div>


 </div>
                     </div> 
                     
</ContentTemplate> </asp:UpdatePanel>
     </div>
</asp:Content>
