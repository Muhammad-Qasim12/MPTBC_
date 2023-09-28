<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ListofPrinter.aspx.cs" Inherits="Printing_ListofPrinter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="portlet-header ui-widget-header">
      &nbsp;&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352;&#2381;&#2337; &#2319;&#2357;&#2306; &#2309;&#2344; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352;&#2381;&#2337; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; 
        </div>
        <div class="portlet-content">
  
        <table width="100%">

        <tr>

        <td>
            &#2352;&#2366;&#2332;&#2381;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350;
         </td> 

        <td>
            <asp:DropDownList ID="ddlstate" runat="server">
            </asp:DropDownList>
         </td> 

        <td>
            &#2335;&#2366;&#2311;&#2346;
         </td> 

        <td>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"  >
                <asp:ListItem Value="1">&#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352;&#2381;&#2337;</asp:ListItem>
                <asp:ListItem Value="2">&#2309;&#2344;&#2381;&#2351; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352;&#2381;&#2337;</asp:ListItem>
                <asp:ListItem Value="0" Selected="True">&#2360;&#2349;&#2368; </asp:ListItem>
            </asp:RadioButtonList>
         </td> </tr> 

        <tr>

        <td colspan="4">
            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
         </td> 

            </tr> 

        <tr>

        <td colspan="4">    <asp:Button ID="btnPrint" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;" Width="150" CssClass="btn" OnClientClick="return PrintPanel()" />
              
             <div id="ExportDiv" runat="server" clientidmode="Static">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                <Columns>
                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                    <asp:BoundField DataField="Statename_hin_V" HeaderText="&#2352;&#2366;&#2332;&#2381;&#2351; " />
                    <asp:BoundField DataField="NameofPress_V" HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                    <asp:BoundField DataField="FullAddress_V" HeaderText="&#2346;&#2340;&#2366; " />
                    <asp:BoundField DataField="Mobileno" HeaderText="&#2325;&#2366;&#2306;&#2335;&#2375;&#2325;&#2381;&#2335; &#2346;&#2352;&#2381;&#2360;&#2344; &#2319;&#2357;&#2306; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2379;." />
                    <asp:BoundField DataField="Status1" HeaderText="&#2360;&#2381;&#2335;&#2375;&#2335;&#2360; " />
                </Columns>
            </asp:GridView></div> 
         </td> 

            </tr> </table> </div> 
     <script type="text/javascript">
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

