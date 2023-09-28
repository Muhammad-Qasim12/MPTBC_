<%@ Page Title="Paper Return by Printer" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRI007ReturnOrder.aspx.cs" Inherits="Printing_PRI007ReturnOrder" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box">
    <div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379;&#2306; &#2360;&#2375; &#2325;&#2366;&#2327;&#2332; &#2357;&#2366;&#2346;&#2360;&#2368; / Paper Return by Printer</span></h2>
        </div>
       <div class="box table-responsive">
            <table width="100%">
                   <tr>
                   
                     <td>
                         <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" CssClass="txtbox" OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged">
                         </asp:DropDownList>
                       </td>
                     <td>
                          <asp:DropDownList runat="server" ID="ddlPrinter" Width="250px" 
                        CssClass="txtbox reqirerd" >
                       
                    </asp:DropDownList>
                     </td>
                       <td>
                                        <asp:TextBox ID="txtSearch" runat="server" MaxLength="200" Width="200px" placeholder="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2326;&#2379;&#2332;&#2375; / Search By Challan No"></asp:TextBox>
                            <asp:Label ID="lblCheckFlag" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="lblPaperDemand" runat="server" Visible="false"></asp:Label>

                        <asp:Label ID="lblOrderTotSheet" runat="server" Visible="false"></asp:Label>
                           <asp:Label ID="lblPaperMIllName" runat="server" Visible="false"></asp:Label>
                           <asp:Label ID="lblTotWtQty"  runat="server" Visible="false"></asp:Label>
                                    </td>
               <td> 
                     <asp:Button runat="server" ID="btnAdd" CssClass="btn" OnClick="btnAdd_Click" 
                             Text="&#2326;&#2379;&#2332;&#2375; / Search" Width="144px" />
                         </td>
                         </tr>
                   <tr>
                   <td style="text-align: left">
                        &nbsp;</td>
                     <td>
                         &nbsp;</td>
                     <td>
                         &nbsp;</td>
               <td> 
    <asp:Button ID="btnExport" runat="server" CssClass="btn"
        Text="Export to Excel" OnClick="btnExport_Click" Visible="false" />
                         </td>
                         </tr>
                         </table> 
                
                <tr>
                    <td style="text-align: center">
                         <asp:GridView ID="GrdPaperAllotment" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" AllowPaging="True" 
                            onpageindexchanging="GrdPaperAllotment_PageIndexChanging">
                            <Columns> 
                             <asp:BoundField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / <br>Academic Year" HtmlEncode="false" DataField="AcYear" Visible="false" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / <br>Printer Name" HtmlEncode="false" DataField="NameofPress_V" />
                                <asp:BoundField HeaderText="&#2357;&#2366;&#2346;&#2360; &#2325;&#2367;&#2351;&#2366; / <br>Return To" HtmlEncode="false" DataField="ReturnTo" />
                                <asp:BoundField HeaderText="Order No." DataField="OrderNo" />
                                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" />
                                <asp:BoundField HeaderText="Challan No." DataField="Challanno" />
                                <asp:BoundField HeaderText="Challan Date" DataField="ChallanDate" />
                                 <asp:BoundField HeaderText="Recieved Qty(M.T)" DataField="ReqQty"  />  
                                <asp:BoundField DataField="SendQty" HeaderText="Return Qty(M.T.)" />
                             <asp:BoundField HeaderText="No.of Reels" DataField="NoOfReels" />
                                <asp:BoundField HeaderText="No. of Sheets/Bundle" DataField="NoOfSheets" />
                                
                                 
                                
                                 <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnUpdateStatus" runat="server" Value='<%#Eval("UpdateStatus")%>' />
                                            <asp:Panel ID="pnupdate221" runat="server" Visible='<%#(Eval("Status").ToString().Equals("Accept"))?true:false%>'>
                                                <asp:LinkButton ID="lnkChangeSts" runat="server" OnClick="lnkChangeSts_Click" CausesValidation="false" Text='<%#Eval("Status") %>'></asp:LinkButton>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#(Eval("Status").ToString().Equals("Accept")|| Eval("Status").ToString().Equals("Pending"))?false:true%>'>
                                                <%#Eval("Status") %>
                                            </asp:Panel>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                
                                 <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnChallanno" runat="server" Value='<%#Eval("Challanno")%>' />
                                             <asp:HiddenField ID="hdnAcyear" runat="server" Value='<%#Eval("AcYear")%>' />
                                             <asp:HiddenField ID="hdnPaperCategory" runat="server" Value='<%#Eval("PaperCategory")%>' />
                                             <asp:HiddenField ID="hdnReturnQty" runat="server" Value='<%#Eval("SendQty")%>' />
                                            <asp:HiddenField ID="hdnPrinterDisTranId" runat="server" Value='<%#Eval("PrinterDisTranId")%>' />
                                            
                                             <a id="hrf" runat="server" onserverclick="btnAddChallanDetailse_Click" href="#">प्रिंट / Print</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>                         
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>

                        <asp:GridView ID="GrdPaperAllotmentPart" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" AllowPaging="True" 
                            onpageindexchanging="GrdPaperAllotmentPart_PageIndexChanging">
                            <Columns> 
                             <asp:BoundField HeaderText="&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; / <br>Academic Year" HtmlEncode="false" DataField="AcYear" Visible="false" />
                                <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; / <br>Printer Name" HtmlEncode="false" DataField="NameofPress_V" />
                                <asp:BoundField HeaderText="&#2357;&#2366;&#2346;&#2360; &#2325;&#2367;&#2351;&#2366; / <br>Return To" HtmlEncode="false" DataField="ReturnTo" />
                                <asp:BoundField HeaderText="Order No." DataField="OrderNo" />
                                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" />
                                <asp:BoundField HeaderText="Challan No." DataField="Challanno" />
                                <asp:BoundField HeaderText="Challan Date" DataField="ChallanDate" />
                                 <asp:BoundField HeaderText="Recieved Qty(M.T)" DataField="ReqQty"  />  
                                <asp:BoundField DataField="SendQty" HeaderText="Return Qty(M.T.)" />
                             <asp:BoundField HeaderText="No.of Reels" DataField="NoOfReels" />
                                <asp:BoundField HeaderText="No. of Sheets/Bundle" DataField="NoOfSheets" />
                                
                                 
                                
                                 <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnUpdateStatus" runat="server" Value='<%#Eval("UpdateStatus")%>' />
                                            <asp:Panel ID="pnupdate221" runat="server" Visible='<%#(Eval("Status").ToString().Equals("Accept"))?true:false%>'>
                                                <asp:LinkButton ID="lnkChangeStsPart" runat="server" OnClick="lnkChangeStsPart_Click" CausesValidation="false" Text='<%#Eval("Status") %>'></asp:LinkButton>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel1" runat="server" Visible='<%#(Eval("Status").ToString().Equals("Accept")|| Eval("Status").ToString().Equals("Pending"))?false:true%>'>
                                                <%#Eval("Status") %>
                                            </asp:Panel>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField> 
                                
                                 <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdnChallanno" runat="server" Value='<%#Eval("Challanno")%>' />
                                             <asp:HiddenField ID="hdnAcyear" runat="server" Value='<%#Eval("AcYear")%>' />
                                             <asp:HiddenField ID="hdnPaperCategory" runat="server" Value='<%#Eval("PaperCategory")%>' />
                                             <asp:HiddenField ID="hdnReturnQty" runat="server" Value='<%#Eval("SendQty")%>' />
                                            <asp:HiddenField ID="hdnPrinterDisTranId" runat="server" Value='<%#Eval("PrinterDisTranId")%>' />
                                            
                                             <a id="hrf" runat="server" onserverclick="btnAddChallanDetailse_Click" href="#">प्रिंट / Print</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>                         
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                        <div id="ExportDiv" runat="server"  >
                        
                            </div>


                        
                    </td>
                </tr>
            </table>

        </div>
        
    </div>
  </div>

    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 900px; margin-left: -12%; margin-top: -5%">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
            &nbsp;|&nbsp;<asp:LinkButton ID="LinkButton6" runat="server" OnClientClick="javascript:return PrintPanel_bad();">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;..</asp:LinkButton>
        </div>
        
        <div style="min-height: 100px; max-height: 500px; overflow: auto;" id="Panel8">
            <table width="100%" style="padding-bottom:20px;">
                <tr>
                    <th colspan="6" style="font-weight: bold;" class="portlet-header ui-widget-header">मुद्रक से पेपर की वापसी / Paper return by Printer
                    </th>
                </tr>
            </table>
            <table width="100%"> 
                <tr><td>मुद्रक / Printer:</td><td style="text-align:left;font-weight:bold"><asp:Label runat="server" ID="lblPrintPri"></asp:Label></td>
                    <td>किसे वापस किया / Return To:</td><td style="text-align:left;font-weight:bold"><asp:Label runat="server" ID="lblPrintRetToPri"></asp:Label></td>
                </tr>  
                <tr><td>चालान न./ Challan No:</td><td style="text-align:left;font-weight:bold"><asp:Label runat="server" ID="Label1"></asp:Label></td>
                    <td>चालान दिनांक / Challan Date:</td><td style="text-align:left;font-weight:bold"><asp:Label runat="server" ID="Label2"></asp:Label></td>
                </tr>   
                 <tr><td>रील/शीट/बंडल संख्या / No of Reels:</td><td style="text-align:left;font-weight:bold"><asp:Label runat="server" ID="lblPrintNoOfReels"></asp:Label></td>
                    <td>वापसी के मात्रा / Return Qty(M.T):</td><td style="text-align:left;font-weight:bold"><asp:Label runat="server" ID="lblPrintRetQty"></asp:Label></td>
                </tr>                
                <tr>
                    <td colspan="4" style="text-align:center;">                         
                        <asp:GridView ID="GrdChallanReel" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." ShowFooter="true" Width="100%" AllowPaging="false" style="margin-top:28px;"
                            OnRowDataBound="GrdChallanReel_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.                                       
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335;  <br> Total Sheets" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheets" runat="server"  
                                            Text='<%# string.Format("{0}", Eval("TotalSheets")) %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                     <FooterTemplate>
                                        <asp:Label ID="lblTS" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;. <br>Role /Bundle No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (Kg.)<br>Net Weight(Kg.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (Kg.)<br>Gross Weight(Kg.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                       
                    </td>
                </tr>

            </table>
        </div>
    </div>

    <div id="fadeDiv11" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv11" class="popupnew" style="display: none; width: 900px; margin-left: -12%; margin-top: -5%">
        <div align="right">
            <a href="#" onclick="javascript:Closediv11()">Close</a>
        </div>
        <div style="min-height: 100px; max-height: 500px; overflow: auto;">
            <table width="100%">
                <tr>
                    <th colspan="6" style="font-weight: bold;" class="portlet-header ui-widget-header">Paper return by Printer
                    </th>
                </tr>
               
                  <tr>
                                    <td>चालान न.<br />
                        Challan No.</td>
                       <td style="text-align: left;">
                     <asp:Label ID="lblChallanno" runat="server" Font-Bold="true"></asp:Label>
                    </td>

                     <td>पेपर का आकार<br />
                       Paper Size
                    </td>
                     <td>
                       <asp:Label ID="lblCoverInformation" runat="server" Font-Bold="true"></asp:Label>
                         <asp:Label ID="txtNoOfReels" runat="server"></asp:Label>
                    </td>
                </tr>
                

            </table>
            <table width="100%">                
                <tr>
                    <td colspan="3" style="text-align: center;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." ShowFooter="true" Width="100%" AllowPaging="false"
                            OnRowDataBound="Gridview1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                     </ItemTemplate>                                    
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ALL">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAll" runat="server" onclick="checkAll(this,1);" Text="ALL" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkitem" runat="server" onclick="checkItem_All(this,1)" />
                                    </ItemTemplate>                                  
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                           <asp:HiddenField ID="hdnPrinterDisTranID" runat="server" Value='<%#Eval("PrinterDisTranID")%>'></asp:HiddenField>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335;  <br> Total Sheets" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheets" runat="server"  
                                            Text='<%# string.Format("{0}", Eval("TotalSheets")) %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                     <FooterTemplate>
                                        <asp:Label ID="lblTS" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;. <br>Role /Bundle No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (Kg.)<br>Net Weight(Kg.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>' Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtNetWt" runat="server" Text='<%#Eval("NetWt")%>' onkeypress="return fnonlyNos11(event,this);" MaxLength="12"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (Kg.)<br>Gross Weight(Kg.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>' Visible="false"></asp:Label>
                                         <asp:TextBox ID="txtGrossWt" runat="server" Text='<%#Eval("GrossWt")%>' onkeypress="return fnonlyNos11(event,this);" MaxLength="12"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>

                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." ShowFooter="true" Width="100%" AllowPaging="false"
                            OnRowDataBound="GridView3_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                     </ItemTemplate>                                    
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="ALL">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkAllPart" runat="server" onclick="checkAll(this,1);" Text="ALL" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkitemPart" runat="server" onclick="checkItem_All(this,1)" />
                                    </ItemTemplate>                                  
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorTrId_IPart" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperType_IPart" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_IPart" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCoverInformationPart" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>
                                           <asp:HiddenField ID="hdnPrinterDisTranIDPart" runat="server" Value='<%#Eval("PrinterDisTranID")%>'></asp:HiddenField>
                                        
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335;  <br> Total Sheets" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheetsPart" runat="server"  
                                            Text='<%# string.Format("{0}", Eval("TotalSheets")) %>'>
                                        </asp:Label>
                                    </ItemTemplate>
                                     <FooterTemplate>
                                        <asp:Label ID="lblTSPart" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;. <br>Role /Bundle No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNoPart" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (Kg.)<br>Net Weight(Kg.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWtPart" runat="server" Text='<%#Eval("NetWt")%>' Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtNetWtPart" runat="server" Text='<%#Eval("NetWt")%>' onkeypress="return fnonlyNos11(event,this);" MaxLength="12"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotNetWtPart" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (Kg.)<br>Gross Weight(Kg.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWtPart" runat="server" Text='<%#Eval("GrossWt")%>' Visible="false"></asp:Label>
                                         <asp:TextBox ID="txtGrossWtPart" runat="server" Text='<%#Eval("GrossWt")%>' onkeypress="return fnonlyNos11(event,this);" MaxLength="12"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotGrossWtPart" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>

                    </td>
                </tr>

                <tr>
                     <td id="tdsheet2" runat="server" visible="false">
                        <asp:TextBox ID="txtTotalSheets" runat="server" onkeypress='javascript:tbx_fnSignedNumeric(event, this);' Width="100px" MaxLength="10" Text="0"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RqtxtTotalSheets" ForeColor="Red" runat="server"
                            ErrorMessage="Please enter sheets." InitialValue="0" ControlToValidate="txtTotalSheets"
                            Text="*" ValidationGroup="sheet"></asp:RequiredFieldValidator>


                    </td>

                       <td style="text-align: left;">
                        <asp:Button runat="server" ID="btnRoleAdd" Visible="false" ValidationGroup="sheet" Text="जोड़ें / Add"
                            CssClass="btn" OnClick="btnRoleAdd_Click" />
                    </td>
                </tr>

              

                <tr>
                    <td colspan="3" style="text-align: center;">

                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" GridLines="None"
                            CssClass="tab" EmptyDataText="Record Not Found." ShowFooter="true" Width="100%" AllowPaging="false"
                            OnRowDataBound="GridView2_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;<br>Paper Size">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                        <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label> 
                                         <asp:HiddenField ID="hdnPrinterDisTranID" runat="server" Value='<%#Eval("PrinterDisTranID")%>'></asp:HiddenField>  
                                                                             
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335;  <br> Total Sheets">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalSheets" runat="server"  
                                            Text='<%# string.Format("{0}", Eval("TotalSheets")) %>'>

                                        </asp:Label>
                                    </ItemTemplate>
                                     <FooterTemplate>
                                        <asp:Label ID="lblTS" runat="server"></asp:Label>

                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2352; <br>Role /Bundle No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Net Weight(M.T.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (&#2350;&#2375;. &#2335;&#2344;)<br>Gross Weight(M.T.)">
                                    <ItemTemplate>
                                        <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        <asp:Label ID="lblTotGrossWt" runat="server"></asp:Label>
                                    </FooterTemplate>
                                </asp:TemplateField>
                              
                            </Columns>
                            <PagerStyle CssClass="Gvpaging" />
                            <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                        </td></tr>

                <tr>
                <td colspan="4" style="height: 10px;">
                    <asp:Button runat="server" ID="btnSave" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Save"
                        CausesValidation="false" CssClass="btn" OnClick="btnSave_Click" />
                </td>
            </tr>

            </table>
        </div>
    </div>

     
     <script type="text/javascript">
         function OpenBill() {
             document.getElementById('fadeDiv').style.display = "block";
             document.getElementById('BillDiv').style.display = "block";

         }

         function OpenBill11() {
             document.getElementById('<%=fadeDiv11.ClientID%>').style.display = "block";
             document.getElementById('BillDiv11').style.display = "block";

         }

         function Closediv11() {
             document.getElementById('<%=fadeDiv11.ClientID%>').style.display = 'none';
             document.getElementById('BillDiv11').style.display = 'none';
         }

         function fnonlyNos11(e, t) {
             try {

                 if (window.event) {

                     var charCode = window.event.keyCode;

                 }

                 else if (e) {

                     var charCode = e.which;

                 }

                 else { return true; }

                 if (charCode > 31 && (charCode < 48 || charCode > 57)) {

                     return false;

                 }

                 return true;

             }

             catch (err) {

                 // alert(err.Description);

             }

         }

         function GrossWt(txtNetWet, txtGrossWt) {
             var NetWet = document.getElementById(txtNetWet).value;
               if (NetWet != "") {
                   document.getElementById(txtGrossWt).value = parseFloat(NetWet) + 5;
            }
         }

         function checkAll(gvExample, colIndex) {
             //alert(gvExample);
             var GridView = gvExample.parentNode.parentNode.parentNode;
             //alert(GridView);
             for (var i = 1; i < GridView.rows.length; i++) {
                 var chb = GridView.rows[i].cells[colIndex].getElementsByTagName("input")[0];
                 //alert(chb);
                 chb.checked = gvExample.checked;
             }
         }

         function checkItem_All(objRef, colIndex) {
             var GridView = objRef.parentNode.parentNode.parentNode;
             var selectAll = GridView.rows[0].cells[colIndex].getElementsByTagName("input")[0];
             if (!objRef.checked) {
                 selectAll.checked = false;
             }
             else {
                 var checked = true;
                 for (var i = 1; i < GridView.rows.length; i++) {
                     var chb = GridView.rows[i].cells[colIndex].getElementsByTagName("input")[0];
                     if (!chb.checked) {
                         checked = false;
                         break;
                     }
                 }
                 selectAll.checked = checked;
             }
         }


         function PrintPanel_bad() {
             var panel = document.getElementById("Panel8");
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
        }
    </script>
</asp:Content>

