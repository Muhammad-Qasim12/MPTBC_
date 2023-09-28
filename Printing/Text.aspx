<%@ Page Title="ग्रुप क्रिएशन " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Text.aspx.cs" Inherits="Printing_Text" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">ग्रुप क्रिएशन </div>
        <div class="portlet-content">

        <table width="100%">

       <tr>
       <td colspan="4" style="height:10px;"></td>
       </tr>
        <tr>
        <td colspan="4">
        <div>
        <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
        <td>पुस्तक का शीर्षक</td>
        <td>
        <asp:DropDownList runat="server" ID="ddlTitle"></asp:DropDownList>
        </td>

        <td>कक्षा</td>
        <td>
        <asp:DropDownList runat="server" ID="ddlClass"></asp:DropDownList>
        </td>

        </tr>
        

        <tr>
        
        <td colspan="4">
        <div>
         <asp:Panel runat="server" ID="PnlBookDes" GroupingText="Book Details" Width="1150px" ScrollBars="Auto" >
        <asp:GridView runat="server" ID="grdBooksDes" AutoGenerateColumns="false" CssClass="tab hastable" OnRowUpdating ="grdBooksDes_RowUpdating" >
        <Columns>
        
        
        <asp:TemplateField HeaderText="क्रमांक">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>

        
         <asp:TemplateField HeaderText="पुस्तक का शीर्षक">
        <ItemTemplate><asp:Label runat="server" ID="lblTitle" Text='<%# Eval("TitleHindi_V")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="कक्षा">
        <ItemTemplate><asp:Label runat="server" ID="lblClass" Text='<%# Eval("Class")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="डिपो">
        <ItemTemplate><asp:Label runat="server" ID="lblDepo" Text='<%# Eval("DepoName_V")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="पेजों की संख्या">
        <ItemTemplate><asp:Label runat="server" ID="lblNoOfPages" Text='<%# Eval("Noofpages")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="मुद्रित होने वाली पुस्तकों की संख्या (टन मे )">
        <ItemTemplate><asp:Label runat="server" ID="lblNoOfBooks" Text='<%# Eval("TotNoOfBooks")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="मुद्रण पेपर की मात्रा (टन मे )">
        <ItemTemplate><asp:Label runat="server" ID="lblPaperQuantity" Text='<%# Eval("Qty_PriPaper")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="कवर पेपर की मात्रा (शीट में )">
        <ItemTemplate><asp:Label runat="server" ID="lblCoverQuantity" Text='<%# Eval("Qty_Covpaper")%>'></asp:Label></ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField >
        <ItemTemplate>
        <asp:Button runat="server" ID="btnAdd" Text="Add In Group" CssClass="btn" CommandName="Update"  />

        <asp:HiddenField runat="server" ID="Hdnclasstrno_i" Value='<%# Eval("classtrno_i") %>' />
        <asp:HiddenField runat="server" ID="HdnDepoId" Value='<%# Eval("DepoId") %>' />
        <asp:HiddenField runat="server" ID="HdnTitleId" Value='<%# Eval("TitleId") %>' />
        <asp:HiddenField runat="server" ID="HdnPriDemandId" Value='<%# Eval("PriDemandId") %>' />

        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
        
        </asp:GridView>
      </asp:Panel> 
        </div>
        
        
        
        </td>
        
        </tr>


        <tr>
        <td colspan="4">
        <asp:Panel runat="server" ID="pnlGroupDetail" GroupingText="Group Details" Width="1150px" ScrollBars="Auto" >
        <table width="100%" >
        <tr>
        
        <td>केटेगरी</td>
        <td>
        <asp:DropDownList runat="server" ID="ddlCategory" CssClass="txtbox reqirerd"></asp:DropDownList>

        <asp:HiddenField runat="server" ID="HdnDepoID_I" Value="0" />
        <asp:HiddenField runat="server" ID="HdnGrpId_I" Value="0" />

        </td>
        <td colspan="2" rowspan="2">
        
        <div>
        <asp:Label runat="server" ID="lblCatDes"></asp:Label>
        
        </div>
        
        </td>

        </tr>

        <tr>
        <td>ग्रुप क्रमांक</td>
        <td>
        <asp:TextBox runat="server" ID="txtGroupNo" CssClass="txtbox reqirerd" MaxLength="10"   onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
        </td>

        </tr>
        

        <tr>
        <td colspan="2">
        
        <asp:GridView runat="server" ID="grdGroup" AutoGenerateColumns="false" CssClass="tab hastable" OnRowUpdating="grdGroup_RowUpdating" >
        <Columns>
        
        
        <asp:TemplateField HeaderText="क्रमांक">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>

        
         <asp:TemplateField HeaderText="पुस्तक का शीर्षक">
        <ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="कक्षा">
        <ItemTemplate><%# Eval("Class")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="डिपो">
        <ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="पेजों की संख्या">
        <ItemTemplate><%# Eval("Noofpages")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="मुद्रित होने वाली पुस्तकों की संख्या (टन मे )">
        <ItemTemplate><%# Eval("TotNoOfBooks")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="मुद्रण पेपर की मात्रा (टन मे )">
        <ItemTemplate><%# Eval("Qty_PriPaper")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="कवर पेपर की मात्रा (शीट में )">
        <ItemTemplate><%# Eval("Qty_Covpaper")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField >
        <ItemTemplate>
        <asp:Button runat="server" ID="btnAdd" Text="Remove from Group" CssClass="btn" CommandName="Update"  />

        <asp:HiddenField runat="server" ID="Hdnclasstrno_i" Value='<%# Eval("classtrno_i") %>' />
        <asp:HiddenField runat="server" ID="HdnDepoId" Value='<%# Eval("DepoId") %>' />
        <asp:HiddenField runat="server" ID="HdnTitleId" Value='<%# Eval("TitleId") %>' />
        <asp:HiddenField runat="server" ID="HdnPriDemandId" Value='<%# Eval("PriDemandId") %>' />
       
        </ItemTemplate>
        </asp:TemplateField>
        </Columns>
         <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
        
        </asp:GridView>
        
        </td>
        
        </tr>


        <tr>
        <td colspan="4">
        <asp:Button runat="server" ID="btnSaveGroup" Text="ग्रुप सेव करे" CssClass="btn" OnClientClick="return ValidateAllTextForm();" OnClick="btnSaveGroup_Click"  />
        </td>
        
        </tr>




        </table>

        </asp:Panel>
                
        </td>
        
        </tr>




        </table>
        
        
        
        
        
        </div>
        
        </td>
        </tr>

        

        </table>


</div>


</asp:Content>

