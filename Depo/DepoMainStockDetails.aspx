<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepoMainStockDetails.aspx.cs" Inherits="Depo_DepoMainStockDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span style="height: 1px">&#2360;&#2381;&#2335;&#2377;&#2325; &#2346;&#2379;&#2332;&#2368;&#2358;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Stock Position Details</span>
            </h2>
        </div>
        <div style="padding: 0 10px;">
            <table width="100%">
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375; / From Date 
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TextBox1" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                         
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / To Date
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox2" CssClass="txtbox reqirerd" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBox2" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                         
                    </td>
                </tr>
                <tr>
                    <td>&#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox " AutoPostBack="True" OnSelectedIndexChanged="ddlMedium_SelectedIndexChanged">
                    </asp:DropDownList>

                    </td>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;                             
                    </td>
                    <td>
                    <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button3" runat="server" CssClass="btn" OnClick="Button3_Click"
                            OnClientClick="return ValidateAllTextForm();" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / Report" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                            <Columns>
                                  <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;" DataField="Title_Name" />
                                 <asp:TemplateField HeaderText="प्रारंभिक स्टॉक शेष">
                                    <ItemTemplate>

                                       योजना (<%#Eval("Stock_Remain_Yojna") %>)<br />  सामान्य (<%#Eval("Stock_Remain_Samanya") %>)
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="मुद्रकों से कुल प्राप्त संख्या">
                                    <ItemTemplate>
                                     <a href='ShowDetails.aspx?id=<%# Eval("TitleID_I") %>&Type=Printer&Fromdate=<%=TextBox1.Text%>&Todate=<%=TextBox2.Text%>' target="_blank" >  योजना (<%# Eval("Printers_Total_Yojna") %>) <br /> सामान्य (<%# Eval("Printers_Total_Samanya") %>)</a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                 <asp:TemplateField HeaderText="अन्तर्डिपो से कुल प्राप्त संख्या ">
                                    <ItemTemplate>
                                     <a href='ShowDetails.aspx?id=<%# Eval("TitleID_I") %>&Fromdate=<%=TextBox1.Text%>&Todate=<%=TextBox2.Text%>' target="_blank" >  योजना (<%# Eval("InterDepo_Total_Yojna") %>)<br />  सामान्य (<%# Eval("InterDepo_Total_Samanya") %>)</a>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                 <asp:TemplateField HeaderText="कुल योग">
                                    <ItemTemplate>
                                       योजना (<%#Convert.ToInt32(Eval("Stock_Remain_Yojna")) +Convert.ToInt32(Eval("Printers_Total_Yojna"))  + Convert.ToInt32(Eval("InterDepo_Total_Yojna")) %>) <br />
                                         सामान्य (<%#Convert.ToInt32(Eval("Stock_Remain_Samanya")) +Convert.ToInt32(Eval("Printers_Total_Samanya"))  + Convert.ToInt32(Eval("InterDepo_Total_Samanya")) %>)
                                    </ItemTemplate>
                                </asp:TemplateField>
                              <asp:TemplateField HeaderText="योजना का प्रदाय ">
                                    <ItemTemplate>
                                  <a href='ShowPradayDetails.aspx?id=<%# Eval("TitleID_I") %>&Fromdate=<%=TextBox1.Text%>&Todate=<%=TextBox2.Text%>&type=1' target="_blank">    <%# Eval ("Total_Distribution_Scheme") %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="खुले बाजार में विक्रय">
                                    <ItemTemplate>
                                     <a href='ShowPradayDetails.aspx?id=<%# Eval("TitleID_I") %>&Fromdate=<%=TextBox1.Text%>&Todate=<%=TextBox2.Text%>&type=2' target="_blank"> <%# Eval ("Open_Market_Total") %></a> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="अन्तर्डिपो में प्रदाय संख्या">
                                    <ItemTemplate>
                                     योजना (<%#Eval("Distribution_InterDepo_Yojna") %>)<br />  सामान्य (<%#Eval("Distribution_InterDepo_Samanya") %>)
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>


                        </asp:GridView>
                    </td>
                </tr>
            </table></div>
</asp:Content>

