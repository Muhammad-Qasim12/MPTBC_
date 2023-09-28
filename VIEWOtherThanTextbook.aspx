<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="VIEWOtherThanTextbook.aspx.cs" Inherits="VIEWOtherThanTextbook" %>

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
                        <asp:Button ID="Button1" runat="server" Text="&#2344;&#2351;&#2366;  &#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344;&#2366;&#2351;&#2375;" CssClass="btn" OnClick="Button1_Click" />
                             <br />
                             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                CssClass="tab" >
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                    
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                 
                                    <asp:BoundField HeaderText="&#2332;&#2367;&#2354;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350; " DataField="District_Name_Hindi_V" />
                                 
                                    <asp:BoundField DataField="BlockNameHindi_V" HeaderText="&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                 
                                    <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
                                        <ItemTemplate>

                                             <%#Eval("ChallanNo_V")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ChallanDate_D" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                    
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

