<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_008Pri_PrinterDetails.aspx.cs" Inherits="Printing_View_008Pri_PrinterDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script language="javascript" type="text/javascript">
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);

            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../images/d_arrow.jpg";
            } else {
                div.style.display = "none";
                img.src = "../images/d_arrow.jpg";
            }
        }

    </script>
    <asp:Panel ID="messDiv" runat="server">
        <asp:Label runat="server" ID="lblMess" class="notification"></asp:Label>
    </asp:Panel>

    <div class="portlet-header ui-widget-header">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2368; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2368; &#2342;&#2376;&#2344;&#2367;&#2325; &#2346;&#2381;&#2352;&#2327;&#2340;&#2367; &#2325;&#2368; &#2332;&#2366;&#2344;&#2325;&#2366;&#2352;&#2368; / Daily Progress Report of Printer </div>



    <div class="portlet-content">
        <div class="box table-responsive">

            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:Label ID="LblAcYear" runat="server" Width="180px">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br/> Academic year:</asp:Label>

                    </td>
                    <td>
                        <asp:DropDownList ID="DdlACYear" runat="server" Width="250px" CssClass="txtbox" OnInit="DdlACYear_Init">
                        </asp:DropDownList>

                    </td>
                    <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                        <br />
                        Printer Name
                    </td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlPrinterName" Width="250px" CssClass="txtbox reqirerd"
                            OnInit="ddlPrinterName_Init">
                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;<br />
                        From Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFromDate" CssClass="txtbox reqirerd" MaxLength="10"
                            Width="238px"></asp:TextBox>

                         <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
                                            TargetControlID="txtFromDate" Format="dd/MM/yyyy">
                              </cc1:CalendarExtender>
                       <%-- <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" TargetControlID="txtFromDate"
                             Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>--%>
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325;<br />
                        To Date
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtToDate" CssClass="txtbox reqirerd" MaxLength="10"
                            Width="238px"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtToDate"
                             Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375; / Search"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSearch_Click" />
                    </td>
                </tr>

                <tr>
                    <td colspan="4">

                        <asp:GridView runat="server" ID="grdPrintingDetail" EmptyDataText="No Record Found." AutoGenerateColumns="false" CssClass="tab" OnRowDataBound="grdPrintingDetail_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table width="98.5%">
                                            <tr>
                                                <td style="width: 10%;">
                                                    Printer Name
                                                  </td>
                                                
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table width="98.5%">
                                            <tr >
                                                <td  style="width: 10%;">  
                                                    <asp:Panel ID="pnlName" runat="server" Style="background-color:yellow;width:100%;padding:10px;color:white;">
                                                    
                                                    <a href="JavaScript:divexpandcollapse('div<%# Eval("Printer_RedID_I") %>');" style="color:white;">
                                                    
                                                    <%#Eval("NameofPress_V") %>
                                                    <asp:Label ID="lblPrinter_RedID_I" runat="server" Text='<%#Eval("Printer_RedID_I") %>' Visible="false"></asp:Label>
                                                    <img id="imgdiv<%# Eval("Printer_RedID_I") %>" width="15px" border="0" src="../images/down.png" />                                                    
                                                </a>
</asp:Panel>
                                                </td>
                                              
                                            </tr>
                                            <tr>
                                                <td style="width: 100%;">
                                                        <div id="div<%# Eval("Printer_RedID_I") %>" style="display: none; position: relative; left: 15px; overflow: auto">
 <asp:GridView runat="server" ID="GridView1" Width="980px" AutoGenerateColumns="false" CssClass="tab">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                             
                                                                <HeaderTemplate>
                                                              
                                                                   
                                                                    <tr>
                                                                        <th  ><center>  &#2325;&#2381;&#2352;.
                                                    <br>
                                                                            / SNo </center></th>
                                                                        
                                                                        <th ><center>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                                            / Title</center></th>
                                                                        

                                                                        <th  ><center>&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                                            / Class </center></th>
                                                                        <th  ><center>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                                            / Group  </center></th>
                                                                        <th  ><center>&#2346;&#2371;&#2359;&#2381;&#2336; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  
                                                    <br>
                                                                            / Total No of Pages </center>    </th>
                                                                        <th  ><center>&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; 
                                                    <br>
                                                                            / Alloted Printing Qty in Number </center>   </th>
                                                                        <th  > <center>&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; 
                                                    <br>
                                                                            / Qty of Printing Paper in Tons </center>   </th>
                                                                        <th  ><center> &#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; 
                                                    <br />
                                                                            / No of Cover Paper in Sheets  </center></th>
                                                                       
                                                                        <th > <center> &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352;  /
                                                    <br />
                                                                            Qty(Tons) of Printing Paper Received by Press </center></th>
                                                                        
                                                                        <th  > <center>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2367;&#2351;&#2366; &#2327;&#2351;&#2366; &#2325;&#2357;&#2352;  &#2346;&#2375;&#2346;&#2352; 
                                                    <br />
                                                                           Qty (Sheets) of Cover Paper Received by Press</center></th>


                                                                    </tr>

                                                                    

                                                                </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                       
                                                                    <tr>
                                                                        <td>
                                                                            <%# Container.DataItemIndex +1 %>                                                                      
                                                                           

                                                                        </td>
                                                                        <td>
                                                                          <center>  <%# Eval("TitleHindi_V")%> </center>
                                                                             
                                                                        </td>
                                                                        
                                                                        <td>
                                                                           <center> <%# Eval("Classdet_V")%> </center>
                                                                            
                                                                        </td>
                                                                        <td>
                                                                          <center>  <%# Eval("Groupname")%> </center>
                                                                            
                                                                        </td>
                                                                        <td>
                                                                          <center>  <%# Eval("pages_n")%> </center> </td>
                                                                        <td>
                                                                          <center>  <%# Eval("Totnoofbooks")%> </center> </td>
                                                                        <td>
                                                                           <center>  <%# Eval("qty_pripaper")%> </center> </td>
                                                                         <td>
                                                                           <center>  <%# Eval("qty_covpaper")%> </center> </td>

                                                                            <td>
                                                                           <center>   </center> </td>
                                                                         <td>
                                                                            <center> </center></td>
                                                                    </tr>



                                                                </ItemTemplate>

                                                               

                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <PagerStyle CssClass="Gvpaging" />
                                                        <EmptyDataRowStyle CssClass="GvEmptyText" />

                                                    </asp:GridView>
                                                    <asp:GridView runat="server" ID="grdPrintingDetailChild" Width="980px" AutoGenerateColumns="false" CssClass="tab">
                                                        <Columns>
                                                            <asp:TemplateField>
                                                             
                                                                <HeaderTemplate>
                                                              
                                                                   
                                                                    <tr>
                                                                        <th rowspan="2">&#2325;&#2381;&#2352;.
                                                    <br>
                                                                            / SNo </th>
                                                                        
                                                                        <th rowspan="2">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                                            / Title</th>
                                                                        <th rowspan="2">
                                                                            Entry Date
                                                                        </th>

                                                                        <th rowspan="2">&#2325;&#2325;&#2381;&#2359;&#2366; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                                            / Class </th>
                                                                        <th rowspan="2">&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2344;&#2366;&#2350;
                                                    <br>
                                                                            / Group  </th>
                                                                        <th rowspan="2">&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2375; &#2325;&#2369;&#2354; &#2398;&#2377;&#2352;&#2381;&#2350;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; 
                                                    <br>
                                                                            / Total Form Nos    </th>
                                                                        <th colspan="3">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2361;&#2379; &#2330;&#2369;&#2325;&#2375; &#2347;&#2366;&#2352;&#2381;&#2350;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                    <br>
                                                                            / Printed Forms Description  </th>
                                                                        <th colspan="3">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2350;&#2375;&#2306; &#2330;&#2354; &#2352;&#2361;&#2375; &#2347;&#2366;&#2352;&#2381;&#2350;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339;
                                                    <br>
                                                                            / Running Printing Form Nos   </th>
                                                                        <th rowspan="2">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2325;&#2357;&#2352; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                    <br />
                                                                            / No of Printed Cover Paper </th>
                                                                        <th rowspan="2">&#2327;&#2375;&#2342;&#2352;&#2367;&#2306;&#2327; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2325;&#2381;&#2352;&#2367;&#2351;&#2366;&#2343;&#2368;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Books in Gathering Process</th>
                                                                        <th rowspan="2">&#2360;&#2381;&#2335;&#2367;&#2330;&#2367;&#2306;&#2327; &#2348;&#2366;&#2311;&#2306;&#2337;&#2367;&#2306;&#2327; &#2346;&#2381;&#2352;&#2325;&#2381;&#2352;&#2367;&#2351;&#2366; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /
                                                    <br />
                                                                            No of Books in Binding Process </th>
                                                                        <th rowspan="2">&#2347;&#2367;&#2344;&#2367;&#2358;&#2367;&#2306;&#2327; &#2325;&#2335;&#2367;&#2306;&#2327; &#2350;&#2375;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /<br />
                                                                            No of Books in Finishing Cutting Process </th>
                                                                        <th rowspan="2">&#2344;&#2350;&#2381;&#2348;&#2352;&#2367;&#2306;&#2327; &#2350;&#2375;&#2306; &#2346;&#2381;&#2352;&#2325;&#2381;&#2352;&#2367;&#2351;&#2366;&#2343;&#2368;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                    <br />
                                                                            No of Books in Numbering Process </th>


                                                                    </tr>

                                                                    <tr>
                                                                        <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2360;&#2375;
                                                    <br>
                                                                            / From Formno </th>
                                                                        <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2340;&#2325;
                                                    <br>
                                                                            / To Formno </th>
                                                                        <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /
                                                    <br>
                                                                            Nos </th>

                                                                        <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2360;&#2375;
                                                    <br>
                                                                            From Formno </th>
                                                                        <th>&#2347;&#2377;&#2352;&#2381;&#2350; &#2340;&#2325;
                                                    <br>
                                                                            /To Formno </th>
                                                                        <th>&#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /
                                                    <br>
                                                                            /Nos </th>

                                                                    </tr>

                                                                </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                       
                                                                    <tr>
                                                                        <td>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                          
                                                                           

                                                                        </td>
                                                                        <td>
                                                                            <%# Eval("TitleHindi_V")%>
                                                                            <asp:HiddenField runat="server" ID="HDNTitleID_I" Value='<%# Eval("TitleID_I") %>' />
                                                                        </td>
                                                                        <td style="padding-left:5px;padding-right:5px;">
                                                                            <%#Eval("Transdate_D") %>

                                                                        </td>
                                                                        <td>
                                                                            <%# Eval("Classdet_V")%>
                                                                            <asp:HiddenField runat="server" ID="HDNClassTrno_I" Value='<%# Eval("ClassTrno_I") %>' />
                                                                        </td>
                                                                        <td>
                                                                            <%# Eval("GroupNO_V")%>
                                                                            <asp:HiddenField runat="server" ID="HDNGrpID_I" Value='<%# Eval("GrpID_I") %>' />
                                                                        </td>
                                                                        <td> <center><%# Eval("TitleTotalFormQty_I") %> </center> 
                                                                        
                                                                        </td>
                                                                        <td> <center><%# Eval("CompFormFrom")%> </center> 
                                                                           
                                                                        </td>
                                                                        <td> <center><%# Eval("CompFormTo")%> </center> 
                                                                         
                                                                        </td>
                                                                        <td> <center><%# Eval("CompQuantity")%> </center> 
                                                                          
                                                                        </td>
                                                                        <td> <center><%# Eval("PenFrmFrom")%> </center> 
                                                                            </td>
                                                                        <td>
                                                                        <center><%# Eval("PenFrmTo")%> </center> 
                                                                           </td>
                                                                        <td>
                                                                        <center><%# Eval("PenQuantity")%> </center> 
                                                                          </td>
                                                                        <td>
                                                                        <center><%# Eval("PrintingCover")%> </center> 
                                                                           </td>
                                                                        <td>
                                                                        <center><%# Eval("Gathering")%> </center> 
                                                                          </td>
                                                                        <td>
                                                                         <center><%# Eval("Stiching")%> </center> 
                                                                          
                                                                        <td>
                                                                        <center><%# Eval("Finishing")%> </center> 
                                                                          
                                                                        <td>
                                                                          <center><%# Eval("Numbering")%> </center> 
                                                                           
                                                                    </tr>



                                                                </ItemTemplate>

                                                               

                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <PagerStyle CssClass="Gvpaging" />
                                                        <EmptyDataRowStyle CssClass="GvEmptyText" />

                                                    </asp:GridView>
                                                </div>
                                                </td>

                                            </tr>
                                        </table>

                                    </ItemTemplate>
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
</asp:Content>

