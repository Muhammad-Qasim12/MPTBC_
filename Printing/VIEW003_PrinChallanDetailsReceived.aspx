﻿<%@ Page Title="Challan Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW003_PrinChallanDetailsReceived.aspx.cs" Inherits="Printing_VIEW002_PrinChallanDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </div>
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
                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; "><ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;"><ItemTemplate><%# Eval("ChalanNo")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;"><ItemTemplate><%# Eval("ChalanDate")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; "><ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; )  "><ItemTemplate><%# Eval("TotalNoOfBooks")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366; )  "><ItemTemplate><%# Eval("TotalNoOfBooksYoj")%></ItemTemplate></asp:TemplateField>
        
       


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
