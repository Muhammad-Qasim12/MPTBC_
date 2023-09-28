<%@ Page Title="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; " Language="C#" 
MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RPT005_Challanreceived.aspx.cs"
 EnableEventValidation="false"  Inherits="Printing_Reports_RPT003_GroupAllotment" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="portlet-content">

        <table width="100%">

        <tr>

        <td width="20%">
       &#2358;&#2375;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / Academic Year
        </td>
        
        <td width="10%">
        <asp:DropDownList ID="DdlACYear" runat="server"  
                OnSelectedIndexChanged ="ddlPrinter_SelectedIndexChanged" >
        
        </asp:DropDownList>
        </td>


        <td width="18%">
       &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name
        </td>
        
        <td width="15%">
        <asp:DropDownList ID="ddlPrinter" runat="server" AutoPostBack="true"  OnSelectedIndexChanged ="ddlPrinter_SelectedIndexChanged" >
        
        </asp:DropDownList>
        </td>
         <td width="25%">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / Search " 
                Width="120px" />
        </td>
        </tr>          
        <tr>
        <td>&nbsp;</td>
       <td>&nbsp;</td>
        
        <td>
            &nbsp;</td>


        <td>
            &nbsp;</td>
        
        <td>
            &nbsp;</td>
        </tr>
            

        <tr>
        <td colspan="5" width="100%">
        <div runat="server" id = "ExportDiv">
    <center>  <table width="100%" >
      <tr><td colspan="11" align = "center" class="style2"  > <strong>   <center> <asp:Label ID="Label1" 
              runat="server" Text="&#2350;&#2343;&#2381;&#2351;&#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. Textbook Corporation"></asp:Label></center>
          </strong> </td></tr>
      <tr><td colspan="11" align = "center" class="style1" > <center>
          <asp:Label ID="Label2" runat="server" 
              Text="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Challan Details"></asp:Label></center>
          </td></tr>
     </table></center>
        <asp:GridView ID="GrdChallanDetail" runat="server"
                            CssClass="tab" AutoGenerateColumns="False"  >
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ <br> SNo.">
                                    <ItemTemplate>
                                     <center >   <%# Container.DataItemIndex+1 %>. </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / <br> Printer Name ">
                                    <ItemTemplate>
                                        <%#Eval("NameofPress_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / <br> Challan No.">
                                    <ItemTemplate>
                                    <center >    <%#Eval("ChallanNo_V")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / <br> Challan Date">
                                    <ItemTemplate>
                                    <center>    <%#Eval("ChallanDate")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2325; / <br> Book Receiving Date">
                                    <ItemTemplate>
                                     <center>   <%#Eval("Receiveddate_D")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / <br> No of Forwarded Bundles">
                                    <ItemTemplate>
                                      <center>  <%#Eval("TotalNoOfReceiveBundle_I")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2379; &#2348;&#2339;&#2381;&#2337;&#2354; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / <br> No of Received Bundles ">
                                    <ItemTemplate>
                                    <center>    <%#Eval("TotalNoOfReceiveBundle_I")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / <br> Book Title">
                                    <ItemTemplate>
                                    <center>    <%#Eval("TitleHindi_V")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; / <br> No of Received Books (General) ">
                                    <ItemTemplate>
                                    <center>    <%#Eval("NoOFgenralBook_I")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2351;&#2379;&#2332;&#2344;&#2366; / <br> No of Received Books (Scheme)  ">
                                    <ItemTemplate>
                                      <center>  <%#Eval("NofSchemeBook_I")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2360;&#2366;&#2311;&#2395; / <br> Book Size ">
                                    <ItemTemplate>
                                      <center>  <%#Eval("BookDimention_V")%> </center>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </div>
        </td>
        </tr>

       <tr>
        <td colspan="4">
          <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn_gry" OnClick="btnExport_Click" />

        </td>
        </tr>
        </table>

        </div> 

         <script type = "text/javascript">
             function PrintPanel() {
                 var panel = document.getElementById("<%=ExportDiv.ClientID %>");

                 var printWindow = window.open('', '', 'height=400,width=800');
                 printWindow.document.write('<html><head><title>Printer Tender Allotement</title>');
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

<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .style1
        {
            width: 1016px;
        }
        .style2
        {
            width: 1016px;
            height: 25px;
        }
    </style>
</asp:Content>


