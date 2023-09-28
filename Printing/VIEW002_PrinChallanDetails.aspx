<%@ Page Title="प्रिंटर चालान की जानकारी / Printer Challan Detail" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW002_PrinChallanDetails.aspx.cs" Inherits="Printing_VIEW002_PrinChallanDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">प्रिंटर चालान की जानकारी / Printer Challan Detail </div>
       <div class="box table-responsive">

        <asp:Panel runat="server" ID="pnlMain">

        <table width="100%">
        <tr>
        <td>
        <asp:Button runat="server" ID="btnAdd" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375; " CssClass="btn" 
                OnClick="btnAdd_Click" Width="157px" />
        </td>
        </tr>
        
        <tr>
        
        <td>
        
        <asp:GridView runat="server" ID="GrdChallan" AutoGenerateColumns="False" 
                CssClass="tab hastable" >
        <Columns>
        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
                <asp:TemplateField HeaderText="डिपो का नाम / Depot Name"><ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="चालान क्रमांक / Challan No"><ItemTemplate><%# Eval("ChalanNo")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="चालान दिनांक / Challan Date"><ItemTemplate><%# Eval("ChalanDate")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="पुस्तक का नाम / Textbook Name"><ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="पुस्तक संख्या (सामान्य ) / Textbook No (General) "><ItemTemplate><%# Eval("TotalNoOfBooks")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="पुस्तक संख्या (योजना ) / Textbook No (Scheme)"><ItemTemplate><%# Eval("TotalNoOfBooksYoj")%></ItemTemplate></asp:TemplateField>
        
       


        <asp:TemplateField>
        <ItemTemplate>
        <a href="PRIN001_ChallanDetails.aspx?Cid=<%# Eval("PriTransID") %>" >&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375; </a>
        </ItemTemplate>
        </asp:TemplateField>
        
        </Columns>
         <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
        </asp:GridView>
        
        </td>
        
        
        </tr>



        </table>



        </asp:Panel> 
        </div> 


</asp:Content>
