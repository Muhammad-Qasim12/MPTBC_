<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeFile="rpt_PrinterOrder.aspx.cs" Inherits="Printing_Reports_rpt_PrinterOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="box table-responsive">
        <div class="card-header">
            <h2>
                <span>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; / Print Order</span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <table width="100%">
             <tr>
                    
                   <td align="right" colspan="3">
                   <asp:Button ID="btnSave" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306;" runat="server" OnClick="btnSave_Click" Visible="false" CssClass="btn"/>
                   </td>
                </tr>
                 <tr>
                    <td style="text-align: left">
                        <span style="font-weight:bold;">मुद्रक का नाम / Printer:-</span> <asp:Label ID="lblPrinter" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         शिक्षा सत्र/ Year :  <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox"></asp:DropDownList>
                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                         <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search "
                            OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:GridView ID="GrdViewPrinterProof" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="WorkOrderID_I"  AllowPaging="True" 
                            onpageindexchanging="GrdViewPrinterProof_PageIndexChanging">
                            <Columns>
                              <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                  <ItemTemplate>
                                      <%# Container.DataItemIndex+1 %>
                                  </ItemTemplate>
                              </asp:TemplateField>
                             <asp:BoundField HeaderText="&#2332;&#2377;&#2348; &#2325;&#2379;&#2337; /  Job Code" DataField="Jobcode_V" />
                                <asp:BoundField HeaderText="&#2319;&#2327;&#2381;&#2352;&#2368;&#2350;&#2375;&#2306;&#2335; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; / Agreement Date" DataField="ArgDate_D" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; /  Printer " DataField="NameofPress_V" Visible="false" />
                                <asp:TemplateField HeaderText="&#2357;&#2367;&#2357;&#2352;&#2339;/Details">
                                    <ItemTemplate>
                                       <table>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="lblPrinter_RedID_I" runat="server" Text='<%#Eval("Printer_RedID_I") %>' Visible="false"></asp:Label>
                                                  <asp:Label ID="lblWorkOrderID_I" runat="server" Text='<%#Eval("WorkOrderID_I") %>' Visible="false"></asp:Label>
                                                 <asp:LinkButton ID="lnBtnViewPrinterProof" runat="server"  OnClick="lnBtnViewPrinterProof_Click" Text="&#2342;&#2375;&#2326;&#2375;&#2306;/Details"></asp:LinkButton>
                                              </td>
                                          </tr>
                                       </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
    <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>
    
     <div id="Messages" style="display: none; width:80%; left:5%" class="popupnew" runat="server">
        <table>
         <tr>
                     <td> <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnExport" runat="server" CssClass="btn" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; Excel &#2350;&#2375;&#2306; &#2349;&#2375;&#2332;&#2375;&#2306;"
                            OnClick="btnExport_Click" />
                    </td>
                    
                </tr>
    </table>
         <table width="100%">
             
         <div class="box">
               <div class="card-header">
                 <h2>   
                    <span>&#2360;&#2370;&#2330;&#2368;</span></h2>
                 </div>
             
           <div class="PLR10" >
            <table width="100%" cellpadding="5" class="MT10" style="font-weight: bold;" cellspacing="0">
                
                <tr>
                     <td>&#2332;&#2377;&#2348; &#2325;&#2379;&#2337; :
                     </td>
                     <td><asp:Label ID="lblPrinter_RedID" runat="server"></asp:Label></td>
                      <td>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
                     </td>
                     <td><asp:Label ID="lblWorkOrderID" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                       <asp:Panel ID="panel1" runat="server" ScrollBars="Both"  Width="900px" Height="300px" >
                        <asp:GridView ID="GrdViewDetails" runat="server" AutoGenerateColumns="False" 
                            CssClass="tab" DataKeyNames="WorkOrderID_I" OnRowCreated="GrdViewDetails_Rowcreated"
                            OnRowDataBound="GrdViewDetails_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText = "&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" >
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Classdet_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366;"/>
                                <asp:BoundField DataField="TitleHindi_V" HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;"/>
                                <asp:BoundField DataField="groupno_V" HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346;" />
                                <asp:BoundField DataField="CDProofLetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="CDProofLetterDate_D" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="CDProofRetLetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="CDProofRetLetterDate_D" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="DepSendProofLetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="DepSendProofLetterDate_D" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="ProofAcceptLetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="ProofAcceptLetterDate_D" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="PrintOrderLetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="PrintOrderLetterDate_D" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}"/>
                                <asp:BoundField DataField="RetProofLetterNo_V" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;" />
                                <asp:BoundField DataField="RetProofLetterDate_D" HeaderText="&#2346;&#2340;&#2381;&#2352; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;" DataFormatString="{0:dd/MM/yyyy}"/>
                            </Columns>  <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                        </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                
            </table>


         
           
                       </div>
                 
                    </div>
            </table>
          <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="txtbox" Visible="false">
                           <asp:ListItem Value="0" Text="Select.."></asp:ListItem>
                        </asp:DropDownList>
    </div>
</asp:Content>

