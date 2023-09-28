<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RptBookSupplyReport.aspx.cs" Inherits="Printing_RptBookSupplyReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
            <h2>
                Daily MIS Report</h2>
        </div>
     <div class="box table-responsive">
            <table width="100%">
                <tr>
                    <td style="text-align: center" class="auto-style1">
                        &nbsp;</td><td colspan="3">
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">&#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                            <asp:ListItem Value="2">&#2309;&#2344;&#2381;&#2351; &#2346;&#2366;&#2336;&#2381;&#2351; &#2360;&#2366;&#2350;&#2327;&#2381;&#2352;&#2368; </asp:ListItem>
                        </asp:RadioButtonList>
                    </td><td>
                        &nbsp;</td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1">
                        &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;
                       
                    </td><td colspan="3">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal">
                            <asp:ListItem Value="2" Selected="True">&#2360;&#2350;&#2352;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; (&#2351;&#2379;&#2332;&#2344;&#2366; &#2319;&#2357;&#2306; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)</asp:ListItem>
                            <asp:ListItem Value="3">&#2360;&#2350;&#2352;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; (&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; )</asp:ListItem>
                            <asp:ListItem Value="1">&#2337;&#2367;&#2335;&#2375;&#2354;&#2381;&#2360; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; </asp:ListItem>
                        </asp:RadioButtonList>
                    </td><td>
                        &nbsp;</td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1">
                        &#2358;&#2367;&#2325;&#2381;&#2359;&#2366;&#2360;&#2340;&#2381;&#2352;
                    </td><td colspan="3">
                                    <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                                    </asp:DropDownList>
                                </td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1">
                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                         <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox1">
                        </cc1:CalendarExtender>
                    </td><td>
                        &nbsp;</td><td>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="txtbox"></asp:TextBox>
                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd/MM/yyyy" TargetControlID="TextBox2">
                        </cc1:CalendarExtender>
                    </td><td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="Show Report" OnClick="Button1_Click" />
                    </td> </tr> 
                <tr>
                    <td style="text-align: center" class="auto-style1" colspan="5">
                        <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry"  Visible="false" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF"  />
                         <br />
                         <div id="ExportDiv" runat="server" >
                        <asp:Label ID="Label1" runat="server"></asp:Label><br /><br />
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2360;.&#2325;&#2381;&#2352;."><ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate></asp:TemplateField>
                                
                                <asp:BoundField DataField="ChalanDate" HeaderText="&#2342;&#2367;&#2344;&#2366;&#2325;  " DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;" />
                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366;">

                                      <ItemTemplate>
                                          <asp:Label ID="lblYojna" runat="server" Text='<%#Eval("Yojna") %>' ></asp:Label>
                                                  
                                                    
                                                 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;">
                                      <ItemTemplate>
                                           <asp:Label ID="lblSamay" runat="server" Text='<%#Eval("Samay") %>' ></asp:Label>
                                                    
                                                     
                                                 </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2351;&#2379;&#2327;">

                                    <ItemTemplate>
                                                     <%# Convert.ToInt32(Eval("Yojna"))+ Convert.ToInt32(Eval("Samay"))%>
                                                     
                                                 </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                          
                        </asp:GridView></div>
                       
                        <br />
                       
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"  Height="800px">
                        </rsweb:ReportViewer>
                       
                    </td> </tr>   </table>   </div>   <script type = "text/javascript">
                                                          function PrintPanel() {
                                                              var panel = document.getElementById("<%=ExportDiv.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }</script>       
</asp:Content>

