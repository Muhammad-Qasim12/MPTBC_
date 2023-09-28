<%@ Page Title="Group Creation" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI002_GroupCreation.aspx.cs" Inherits="Printing_PRI002_GroupCreation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="portlet-header ui-widget-header">&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2367;&#2319;&#2358;&#2344; </div>
        <div class="portlet-content">
        <div class="table-responsive">
        <table width="100%">

       <tr>
       <td colspan="4" style="height:10px;"></td>
       </tr>
        <tr>
        <td colspan="4">
        <div>
        <table width="100%" cellpadding="0" cellspacing="0">
        <tr>
        <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;</td>
        <td>
        <asp:DropDownList runat="server" ID="ddlTitle"></asp:DropDownList>
        </td>

        <td>&#2325;&#2325;&#2381;&#2359;&#2366;</td>
        <td>
        <asp:DropDownList runat="server" ID="ddlClass"></asp:DropDownList>
        </td>

        </tr>
        

        <tr>
        
        <td colspan="4">
        <div>
         <asp:Panel runat="server" ID="PnlBookDes" GroupingText="Book Details"   >
        <asp:GridView runat="server" ID="grdBooksDes" AutoGenerateColumns="false" CssClass="tab" OnRowUpdating ="grdBooksDes_RowUpdating" >
        <Columns>
        
        
        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>

        
         <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;">
        <ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;">
        <ItemTemplate><%# Eval("Class")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379;">
        <ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
        <ItemTemplate><%# Eval("Noofpages")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2335;&#2344; &#2350;&#2375; )">
        <ItemTemplate><%# Eval("TotNoOfBooks")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; )">
        <ItemTemplate><%# Eval("Qty_PriPaper")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2358;&#2368;&#2335; &#2350;&#2375;&#2306; )">
        <ItemTemplate><%# Eval("Qty_Covpaper")%></ItemTemplate>
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
        <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
        
        </asp:GridView>
      </asp:Panel> 
        </div>
        
        
        
        </td>
        
        </tr>


        <tr>
        <td colspan="4">
        <asp:Panel runat="server" ID="pnlGroupDetail" GroupingText="Group Details" >
        <table width="100%" >

        <tr>
        <td>&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
        
        <td>
        <asp:DropDownList runat="server" ID="ddlGroupId" CssClass="txtbox reqirerd" AutoPostBack="true"  OnSelectedIndexChanged="ddlGroupId_SelectedIndexChanged" ></asp:DropDownList>
        </td> 

        </tr>
        <tr>
        <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
        
        <td>
        <asp:DropDownList runat="server" ID="ddlDepoTrno_I" CssClass="txtbox reqirerd" ></asp:DropDownList>
        </td> 

        </tr>

        <tr>
        
        <td>&#2325;&#2375;&#2335;&#2375;&#2327;&#2352;&#2368;</td>
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
        <td>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</td>
        <td>
        <asp:TextBox runat="server" ID="txtGroupNo" CssClass="txtbox reqirerd" MaxLength="10"   onkeypress="tbx_fnAlphaNumericOnly(event, this);"></asp:TextBox>
        </td>

        </tr>
        

        <tr>
        <td colspan="2">
        
        <asp:GridView runat="server" ID="grdGroup" AutoGenerateColumns="false" CssClass="tab" OnRowUpdating="grdGroup_RowUpdating" >
        <Columns>
        
        
        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>

        
         <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;">
        <ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;">
        <ItemTemplate><%# Eval("Class")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379;">
        <ItemTemplate><%# Eval("DepoName_V")%></ItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
        <ItemTemplate><%# Eval("Noofpages")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2335;&#2344; &#2350;&#2375; )">
        <ItemTemplate><%# Eval("TotNoOfBooks")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2335;&#2344; &#2350;&#2375; )">
        <ItemTemplate><%# Eval("Qty_PriPaper")%></ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; (&#2358;&#2368;&#2335; &#2350;&#2375;&#2306; )">
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
        
        </asp:GridView>
        
        </td>
        
        </tr>


        <tr>
        <td colspan="4">
        <asp:Button runat="server" ID="btnSaveGroup" Text="&#2327;&#2381;&#2352;&#2369;&#2346; &#2360;&#2375;&#2357; &#2325;&#2352;&#2375;" CssClass="btn" OnClientClick="return ValidateAllTextForm();" OnClick="btnSaveGroup_Click"  />
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

</div>
</asp:Content>

