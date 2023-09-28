<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Summaryofmonthlyexps.aspx.cs" Inherits="Paper_PaperReport_PaperCalu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-decoration: underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="portlet-header ui-widget-header">
        माहवार व्यय पत्रक  / Monthly expenditure detail   
    </div>
    <div class="portlet-content">

        <div class="table-responsive">

            <table width="100%">


                <tr>
                    <td>&nbsp;सत्र /&nbsp; Year:
                        <asp:DropDownList ID="ddlYear" runat="server">
                            <asp:ListItem>2017</asp:ListItem>
                        </asp:DropDownList>

                    </td>

                    <td>
                        <asp:Label ID="LblClass" runat="server" Visible="False">माह / Month</asp:Label>
                    </td>

                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server" Height="16px" Width="106px">
                            <asp:ListItem>1</asp:ListItem>
                        </asp:DropDownList>

                      
                        <br />
                    </td>

                    <td>
                        Depo / डिपो का नाम
                    </td>

                    <td>
                            <asp:DropDownList ID="DdlDepot" runat="server">
                            </asp:DropDownList>
                           
                    </td>
                </tr>


                <tr>
                    <td colspan="3">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                            OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>

                    <td>
                        &nbsp;</td>

                    <td>
                        &nbsp;</td>

                </tr>
            </table>

            <table width="100%">

                <tr>
                    <td>
                        <div runat="server" id="ExportDiv" visible="false">



                            <table align="center" width="100%">
                                <tr>
                                    <td style="text-align: center; font-weight: bold; font-family: Verdana; font-size: 18px;">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;

                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="text-align: center; font-family: Verdana; font-size: 16px;">
                                        डिपो - <%=ddlMonth.SelectedValue.ToString()%>

                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="width: 100%; font-weight: bold;">
                                        <div style="text-align: center;">

                                            <h4 class="auto-style1" style="font-size: large">व्यय पत्रक माह - <%=ddlMonth.Text.ToString()  %> - <%=ddlMonth.SelectedValue.ToString() %>  </h4>
                                        </div>
                                    </td>
                                </tr>

                                <tr>
                                    <td align="center" style="width: 100%; font-weight: bold;">&nbsp;</td>
                                </tr>



                                <tr>
                                   
                                    <td> 
                                        <asp:GridView ID="gvPapCalculation" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="gvPapCalculation_RowDataBound" ShowFooter="True">
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / SNo &lt;br&gt;(1)">
                                                    <ItemTemplate>
                                                                 <%# (Container.DataItemIndex+1).ToString ()=="17" ? ""  : ( Container.DataItemIndex+1).ToString () %>                                            
                                                       

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                 <asp:TemplateField HeaderText="&#2325;&#2379;&#2337;   / Code   &lt;br&gt; (2)">
                                                    <ItemTemplate> <asp:Label ID="lbledgercode" runat="server" Text='<%# Eval("ledgercode")%>'></asp:Label> </ItemTemplate> 
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="&#2350;&#2342;  / Head   &lt;br&gt; (3)">
                                                    <ItemTemplate> <asp:Label ID="lblNoofpages" runat="server" Text='<%# Eval("LEDGERNAME")%>'></asp:Label> </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:TemplateField HeaderText="&#2352;&#2366;&#2358;&#2367; / Amount Rs &lt;br&gt; (4)">

                                                    
                                                    <ItemTemplate>
                                                         <asp:Label ID="lblNoofpages" runat="server" Text='<%# Eval("AmountDr")%>'></asp:Label>  
                                                    </ItemTemplate>

                                                </asp:TemplateField>

                                            </Columns>
                                            <HeaderStyle CssClass="HeaderStyle" />
                                            <EditRowStyle CssClass="RowStyle" />
                                            <AlternatingRowStyle CssClass="AltRowStyle" />
                                        </asp:GridView>
                                        <br />
                                         <b runat="server" id="a" style="display:none">    </b> 
                                        <b runat="server" id="a1" style="display:none">     </b> 
                     <asp:Button ID="btnExport" runat="server" Text="Print" OnClientClick="return PrintPanel();"
                            CssClass="btn_gry" Visible="false" />
                    </td>
                </tr>

            </table>


        </div>

    </div>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title></title><style>.tab {width: 100%;  border-collapse: collapse;  border-left: 1px solid #d8d8d8; }.tab th { color: #000;border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold; }   .tab th, .tab td {  padding: 8px 10px;  text-align: center;  font-size: 1em;    border-bottom: 1px solid #d8d8d8; border-right: 1px solid #d8d8d8;  border-left: 1px solid #d8d8d8; background: transparent; }  .tab th { color: #000;  border-bottom: 1px solid #d8d8d8;  border-top: 1px solid #d8d8d8;  background: #f1f1f1;  font-weight: bold;  } .tab th, .tab td { padding: 8px 10px; text-align: left; font-size: 1em; border-bottom: 1px solid #d8d8d8;   border-right: 1px solid #d8d8d8;   border-left: 1px solid #d8d8d8;   background: transparent; }</style>');
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

