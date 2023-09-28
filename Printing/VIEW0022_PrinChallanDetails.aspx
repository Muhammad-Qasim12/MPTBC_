<%@ Page Title="Challan Details" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEW0022_PrinChallanDetails.aspx.cs" Inherits="Printing_VIEW002_PrinChallanDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 <div class="portlet-header ui-widget-header">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; </div>
        <div class="portlet-content">

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
            
शिक्षा सत्र/ Year :
         <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>&nbsp;&nbsp;  
            &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; :
            <asp:DropDownList ID="ddlDepot" runat="server" CssClass="txtbox">
            </asp:DropDownList>
            &nbsp; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
            <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
            </asp:DropDownList>
            &nbsp;<asp:Button ID="btnAdd0" runat="server" CssClass="btn" OnClick="btnAdd0_Click" Text="&#2337;&#2366;&#2335;&#2366; &#2342;&#2375;&#2326;&#2375; " Width="157px" />
        
        </td>
        
        
        </tr>



            <tr>
                <td>
                    <asp:GridView ID="GrdChallan" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="tab hastable" onpageindexchanging="GrdChallan_PageIndexChanging" OnRowDataBound="GrdChallan_RowDataBound" onselectedindexchanged="GrdChallan_SelectedIndexChanged" PageSize="20" ShowFooter="True" ShowHeader="true">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                <ItemTemplate>
                                    <%# Eval("DepoName_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Eval("ChalanNo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;">
                                <ItemTemplate>
                                    <%# Eval("ChalanDate")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                <ItemTemplate>
                                    <%# Eval("TitleHindi_V")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  ">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("TotalNoOfBooks")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2306;&#2348;&#2352; &#2360;&#2375; - &#2340;&#2325;  ">
                                <ItemTemplate>
                                    <%# Eval("BooksFrom") %>- <%# Eval("BooksTo")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; ">
                                <ItemTemplate>
                                    <%# Eval("BookType").ToString()=="1" ? "&#2351;&#2379;&#2332;&#2344;&#2366;" : "&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;"    %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("PriTransID").ToString() %>' />
                                    <asp:LinkButton ID="LinkButton1" visible='<%# Eval("Isdepotstatus").ToString()=="1" ? false  : true %>' runat="server" OnCommand='<%#Eval("PriTransID").ToString() %>' OnClick="btnClick">&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;</asp:LinkButton>
                                   <%-- <a   href='PRIN0011_ChallanDetails.aspx?Cid=<%#new APIProcedure().Encrypt( Eval("PriTransID").ToString()) %>'  > </a>
                               --%>
                                
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" ">
                                <ItemTemplate>
                                    <a href='PrinterChallanRpt.aspx?ID=&#039;<%#Eval("PriTransID") %>&#039;'>&#2330;&#2366;&#2354;&#2366;&#2344; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="Gvpaging" />
                        <EmptyDataRowStyle CssClass="GvEmptyText" />
                    </asp:GridView>
                </td>
            </tr>



            <tr>
                <td>
                    <asp:Button ID="btnExport" runat="server" CssClass="btn_gry" 
                        OnClick="btnExport_Click" Text="Export to Excel" />
                </td>
            </tr>


        </table>

         


        </asp:Panel> 
        </div> 

    
</asp:Content>
