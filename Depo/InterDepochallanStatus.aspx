<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepochallanStatus.aspx.cs" Inherits="Depo_InterDepochallanStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="card-header">
            <h2>
                <span>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368;/ Challan Details </span></h2>
        </div>
   
     <table width="100%">
                <tr>
                    <td>
                             
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CssClass="tab">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                 
                                    <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379;  &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                 
                                    <asp:BoundField DataField="OrderNo_I" HeaderText="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352; ." />
                                 
                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                        <ItemTemplate>
                                          <%-- <a href="ReceiptDetails.aspx?ChallanID='<%#Eval("ChallanNo_V")%>'"></a>--%>
                                              
                                              <a href="RptInterDepoChallan.aspx?ChallanNo=<%#Eval("ChallanNo_V") %>"><%#Eval("ChallanNo_V")%></a>    
                                               
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ChallanDate_D" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                    <asp:BoundField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2360;&#2381;&#2341;&#2367;&#2340;&#2367; " DataField="SendStatus" />
                                </Columns>
                                 <PagerStyle CssClass="Gvpaging" />
                                           <EmptyDataRowStyle CssClass="GvEmptyText" />
                                 <EmptyDataTemplate>
                                     Data Not Found ............
                                 </EmptyDataTemplate>
                            </asp:GridView>
                           </td>
                </tr></table> 
</asp:Content>

