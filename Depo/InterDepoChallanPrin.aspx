<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoChallanPrin.aspx.cs" Inherits="Depo_InterDepoChallanPrin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive"> 
     <div class="card-header">    <h2> अंतर्डिपो चालान प्रिंट </h2></div> 
       <table width="100%" >
    <tr><td class="auto-style1" colspan="2">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
        </td> </tr>
    <tr><td class="auto-style1">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; / Financial Year</td> <td class="auto-style1">
        <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="txtbox reqirerd">
        </asp:DropDownList>
        </td> </tr>
     
          

           
     
           <tr>
               <td class="auto-style1">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Challan No. </td>
               <td class="auto-style1">
                   <asp:DropDownList ID="ddlChallano" runat="server" >
                   </asp:DropDownList>
               </td>
           </tr>
     
          

           
     
           <tr>
               <td   colspan="2">
                   <asp:Button ID="Button6" runat="server" CssClass="btn" OnClick="Button6_Click1" Text="Show Challan" />
               &nbsp;<asp:Button ID="Button16" runat="server" CssClass="btn" OnClientClick="return PrintPanel();" Text="Print" />
               </td>
           </tr>
           <tr><td colspan="2">
               <asp:Panel ID="Panel6" runat="server" Height="400px" ScrollBars="Both" Width="100%">
                   <table width="100%">
                       <tr align="center">
                           <td colspan="4">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;
                               <asp:Label ID="lblDepoName" runat="server"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; </td>
                           <td>
                               <asp:Label ID="lblChallan" runat="server"></asp:Label>
                           </td>
                           <td></td>
                           <td>
                               <asp:Label ID="lblChallanDate" runat="server"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2337;&#2367;&#2346;&#2379; :</td>
                           <td>
                               <asp:Label ID="lblReceiverDepot" runat="server"></asp:Label>
                           </td>
                           <td>&#2346;&#2381;&#2352;&#2375;&#2359;&#2325; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;:</td>
                           <td>
                               <asp:Label ID="lblSenderDepo" runat="server"></asp:Label>
                           </td>
                       </tr>
                   </table>
                   <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="grdPrinterBundleDetails0_RowDataBound" ShowFooter="True" Width="100%">
                       <Columns>
                           <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name/ " />
                           <asp:BoundField DataField="DestributeBook" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375; &#2357;&#2366;&#2354;&#2368; &#2348;&#2369;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/No of Distribute Books " />
                           <asp:BoundField DataField="PaikBandal" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2376;&#2325; &#2348;&#2339;&#2381;&#2337;&#2354; / Total  Pack Bundle" />
                           <asp:BoundField DataField="LoojBandal" HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/ No. Of Loose Books" />
                           <asp:BoundField DataField="BundleNo_I" HeaderText="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2306;&#2337;&#2354;&#2379;  &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /No of Bundle Received by barcode" />
                           <asp:BoundField DataField="TotalBook" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /Distributed Books  No" />
                           <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                               <ItemTemplate>
                                   &#39;<%# Eval("IsScheme").ToString()=="1" ? "&#2351;&#2379;&#2332;&#2344;&#2366;"  : "&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" %>&#39;
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                   </asp:GridView>
               </asp:Panel>
               </td></tr>
           </table> </div> 

     <script type = "text/javascript">
         function PrintPanel() {
             var panel = document.getElementById("<%=Panel6.ClientID %>");

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
    </ContentTemplate>
</asp:Content>

