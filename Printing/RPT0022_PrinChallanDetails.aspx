<%@ Page Title="Challan Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT0022_PrinChallanDetails.aspx.cs" Inherits="RPT0022_PrinChallanDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </div>
        <div class="portlet-content">

        <asp:Panel runat="server" ID="pnlMain">
 

        <table width="100%">

          <tr>
            <td>
                <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Academic Year:</asp:Label>
            </td>
              <td>
                  <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" 
                      OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true"  >
                      <asp:ListItem>..Select Academic Year..</asp:ListItem>
                      <asp:ListItem>2012-13</asp:ListItem>
                      <asp:ListItem>2013-14</asp:ListItem>
                      <asp:ListItem>2014-15</asp:ListItem>
                  </asp:DropDownList>
              </td>
              <td>
                  <asp:Label ID="LblDepot" runat="server" Width="85px">&#2337;&#2367;&#2346;&#2379;  &#2330;&#2369;&#2344;&#2375;  :</asp:Label>
              </td>
              <td>
                  <asp:DropDownList ID="DdlDepot" runat="server" AutoPostBack="True" 
                      CssClass="txtbox" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged">
                      <asp:ListItem>select Depo..</asp:ListItem>
                     
                  </asp:DropDownList>
              </td>

        </tr>
            <tr>
                <td>
                    <asp:Label ID="LblClass1" runat="server" Width="85px">&#2325;&#2325;&#2381;&#2359;&#2366;  / Class</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" 
                        CssClass="txtbox" onselectedindexchanged="DdlClass_SelectedIndexChanged" 
                        TabIndex="1" Width="122px">
                        <asp:ListItem Value="0">All</asp:ListItem>
                        <asp:ListItem Value="1">1 To 8</asp:ListItem>
                        <asp:ListItem Value="2">9 To 12  </asp:ListItem>
                        <asp:ListItem Value="3">1 To 12</asp:ListItem>
                        <asp:ListItem Value="4">NCERT</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;/ Title</td>
                <td>
                    <asp:DropDownList ID="ddlTitle" runat="server" CssClass="txtbox" TabIndex="2" 
                        Width="305px">
                    </asp:DropDownList>
                </td>
                <%--  <td>
                <asp:RadioButton ID="rdoRptSummary" runat="server" GroupName="rptType" Text="Summery" Checked="true" />
                <asp:RadioButton ID="rdoRptDetail" runat="server" GroupName="rptType" Text="Detail" />
            </td>--%>
            </tr>
        <tr>
        <td>
            &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSearch0" runat="server" CssClass="btn" 
                    OnClick="btnSearch_Click" Text="&#2326;&#2379;&#2332;&#2375; / Search " 
                    TabIndex="3" />
            </td>
        </tr>
        
        <tr>
        
        <td colspan="4">
        
        <asp:GridView runat="server" ID="GrdChallan" AutoGenerateColumns="False" 
                CssClass="tab hastable" 
                onselectedindexchanged="GrdChallan_SelectedIndexChanged" PageSize="20" 
                onpageindexchanging="GrdChallan_PageIndexChanging" >
        <Columns>
        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;"><ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; "><ItemTemplate><%# Eval("DepoName_V")%>
            </ItemTemplate></asp:TemplateField>

<asp:TemplateField HeaderText="&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; "><ItemTemplate><%# Eval("vitranno")%>
            </ItemTemplate></asp:TemplateField>


        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;"><ItemTemplate><%# Eval("ChalanNo")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;"><ItemTemplate><%# Eval("ChalanDate")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; "><ItemTemplate><%# Eval("TitleHindi_V")%></ItemTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2348;&#2339;&#2381;&#2337;&#2354; "><ItemTemplate><%# Eval("PacketsSendAsPerChallan")%></ItemTemplate></asp:TemplateField>
         
         <asp:TemplateField HeaderText="&#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; - &#2340;&#2325;  "><ItemTemplate><%# Eval("BooksFromYoj")%> - <%# Eval("BooksToYoj")%> </ItemTemplate></asp:TemplateField>

        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  "><ItemTemplate><%# Eval("TotalNoOfBooks")%></ItemTemplate></asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; - &#2340;&#2325;  "><ItemTemplate><%# Eval("BooksFrom") %> - <%# Eval("BooksTo")%> </ItemTemplate></asp:TemplateField>
        
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; "  ><ItemTemplate><%# Eval("BookType").ToString()=="1" ? "&#2351;&#2379;&#2332;&#2344;&#2366;" : "&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;"    %> </ItemTemplate></asp:TemplateField>
        <asp:TemplateField>
        </asp:TemplateField>        
        </Columns>
         <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
        </asp:GridView>
        
        </td>
        
        
        </tr>



            <tr>
                <td colspan="4">
                    <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                        OnClick="btnExport_Click" Text="Export to Excel" />
                </td>
            </tr>


        </table>

         


        </asp:Panel> 
        </div> 

    
</asp:Content>
