<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateChallanDetails.aspx.cs" Inherits="Depo_UpdateChallanDetails" %>

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
                                CssClass="tab" OnRowDataBound="GridView1_RowDataBound">
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

                                              <a id="aa" href="BlockChalanReport.aspx?ChallanID=<%#Eval("ChallanNo_V")%>"><%#Eval("ChallanNo_V")%></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ChallanDate_D" HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; " />
                                     <asp:BoundField DataField="ReceiverName_V" HeaderText="प्राप्तकर्ता का नाम  " />
                                    <asp:BoundField DataField="MediunNameHindi_V" HeaderText="&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                   
                                    <asp:TemplateField HeaderText=" चालान  प्रिंट करे   ">
                                        <ItemTemplate>

                                              <a id="aa" href="View_dpt014.aspx?ChallanNo=<%#Eval("ChallanNo_V")%>">प्रिंट करे </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                      <%--<asp:TemplateField HeaderText="&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306; ">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("sendstatus") %>' />
                                       
                                            <a id="aa" href="UpdateSchemeChallan.aspx?ChallanID=<%#Eval("ChallanNo_V")%>">&#2360;&#2369;&#2343;&#2366;&#2352; &#2325;&#2352;&#2375;&#2306;</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
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

