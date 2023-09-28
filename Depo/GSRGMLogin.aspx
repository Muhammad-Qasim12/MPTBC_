<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GSRGMLogin.aspx.cs" Inherits="Depo_GSRGMLogin" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="box table-responsive">

        <div class="card-header">
            <h2>&#2332;&#2344;&#2352;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; / General Stock Register 
            </h2>
        </div>
        <div style="padding: 0 10px;">


            <table width="100%">
                <tr>
                    <td>शिक्षा सत्र 
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlAcYear" runat="server">
                        </asp:DropDownList>

                      
                    </td>
                    <td>डिपो का नाम
                    </td>
                    <td>
                        <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox reqirerd" >
                        </asp:DropDownList>

                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;&nbsp; / From Date 
                    </td>
                    <td>
                        <asp:TextBox ID="txtFromdate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromdate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                      
                    </td>
                    <td>&#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; / To Date
                    </td>
                    <td>
                        <asp:TextBox ID="txtTodate" runat="server" CssClass="txtbox reqirerd" MaxLength="10"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTodate" Format="dd/MM/yyyy">
                        </cc1:CalendarExtender>

                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;&#2350;&#2366;&#2343;&#2381;&#2351;&#2350; 
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlMedium" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>

                    </td>
                    <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;&nbsp;&nbsp;&nbsp;</td>
                    <td>
                        <asp:DropDownList ID="ddlTital" runat="server" CssClass="txtbox">
                        </asp:DropDownList>
                
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350; 
                    </td>
                    <td>

                    <asp:DropDownList ID="ddlPrinter" runat="server" CssClass="txtbox reqirerd">
                    </asp:DropDownList>

                    </td>
                    <td colspan="3">
                        <asp:Button ID="Button3" runat="server" CssClass="btn"
                            Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375;&#2306; / See Report "
                            OnClick="Button3_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">&nbsp;</td>
                </tr>
                <tr style="display: none;">
                    <td colspan="5">
                        <div id="ExportDiv" runat="server" visible="false">
                            <table width="100%">
                                <tr>
                                    <td align="center"><b>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                                        <br />
                                        <br />
                                    </b>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&#2332;&#2344;&#2352;&#2354; &#2360;&#2381;&#2335;&#2377;&#2325; &#2352;&#2332;&#2367;&#2360;&#2381;&#2335;&#2352; / General Stock Register&nbsp; :
          &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2360;&#2375;  :  
                                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                        &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; &#2340;&#2325; :
                                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            <div style="display: none;">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / S.No.">
                                            <FooterTemplate>
                                                </table>
                                            </FooterTemplate>
                                            <HeaderTemplate>
                                                <table style="width: 100%" border="2" class="tab">
                                                    <tr>
                                                        <th rowspan="2">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                                                        <th rowspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
                                                        <th rowspan="2">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; &#2332;&#2367;&#2360;&#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2361;&#2369;&#2312; &#2361;&#2376; </th>
                                                        <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </th>
                                                        <th>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2375; &#2349;&#2375;&#2332;&#2344;&#2375; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; </th>
                                                        <th colspan="2">&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; &#2340;&#2325; &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
                                                        <th rowspan="2">&#2330;&#2366;&#2354;&#2366;&#2344;&#2325;&#2381;&#2352;. &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;
                                                        </th>
                                                        <th rowspan="2">&#2332;&#2368; &#2310;&#2352; / /&#2310;&#2352; &#2310;&#2352; &#2325;&#2381;&#2352;. &#2319;&#2357;&#2306; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </th>
                                                        <th>&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2348;&#2339;&#2381;&#2337;&#2354; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; </th>
                                                        <th rowspan="2">&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; </th>
                                                        <th rowspan="2">25 % &#2327;&#2339;&#2344;&#2366; &#2325;&#2375; &#2310;&#2343;&#2366;&#2352; &#2311;&#2332; &#2324;&#2360;&#2340;&#2344; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th rowspan="2">&#2360;&#2381;&#2335;&#2377;&#2325; &#2354;&#2375;&#2332;&#2352; &#2346;&#2371;&#2359;&#2381;&#2335; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </th>
                                                        <th colspan="5">&#2337;&#2367;&#2346;&#2379; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2325;&#2367;&#2351;&#2375; &#2327;&#2319; &#2357;&#2381;&#2351;&#2351; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; </th>
                                                        <th rowspan="2">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2325;&#2352;&#2381;&#2340;&#2366; &#2325;&#2375; &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; </th>
                                                        <th rowspan="2">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; </th>
                                                    </tr>

                                                    <tr>
                                                        <th>&#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th>&#2351;&#2379;&#2332;&#2344;&#2366; </th>
                                                        <th>&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;</th>
                                                        <th>&#2348;&#2339;&#2381;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </th>
                                                        <th>&#2313;&#2340;&#2352;&#2366;&#2312; </th>
                                                        <th>&#2330;&#2397;&#2366;&#2312; </th>
                                                        <th>&#2346;&#2352;&#2367;&#2357;&#2366;&#2361;&#2344; </th>
                                                        <th>&#2309;&#2344;&#2381;&#2351; </th>
                                                        <th>&#2351;&#2379;&#2327; </th>
                                                    </tr>
                                                    <tr>
                                                        <td>1</td>
                                                        <td>2</td>
                                                        <td>3</td>
                                                        <td>4</td>
                                                        <td>5</td>
                                                        <td>6</td>
                                                        <td>7</td>
                                                        <td>8</td>
                                                        <td>9</td>
                                                        <td>10</td>
                                                        <td>11</td>
                                                        <td>12</td>
                                                        <td>13</td>
                                                        <td>14</td>
                                                        <td>15</td>
                                                        <td>16</td>
                                                        <td>17</td>
                                                        <td>18</td>
                                                        <td>19</td>
                                                        <td>20</td>
                                                        <td>21</td>
                                                    </tr>
                                                </table>
                                            </HeaderTemplate>
                                            <ItemTemplate>


                                                <tr>
                                                    <td><%#Container.DataItemIndex+1 %></td>
                                                    <td><%# Eval("Receiveddate_D")%></td>
                                                    <td><%# Eval("NameofPress_V")%>
                                                        <br />
                                                        <%#Eval("FullAddress_V")%> 
                                                    </td>
                                                    <td><%#Eval("Title")%>  </td>
                                                    <td><%#Eval("TotalNoOfBundle")%> </td>
                                                    <td><%#Eval("NoOfbookYojana")%> </td>
                                                    <td><%#Eval("NoOfBookSamanya")%></td>
                                                    <td><%#Eval("BooksFrom")%> -<%#Eval("BooksTo")%><br /><%#Eval("Receiveddate_D") %></td>
                                                    <td><%#Eval("ChallanDate")%></td>
                                                    <td><%#Eval("GRNo_V")%><br />
                                                        <%#Eval("GRDate_D")%>  </td>
                                                    <td><%#Eval("TotalNoOfBundle")%></td>
                                                    <td><%#Eval("BooksFrom")%> -<%#Eval("BooksTo")%></td>
                                                    <td><%#Eval("NoOfBookCounted_I")%></td>
                                                    <td><%#Eval("RegisterNo")%></td>
                                                    <td><%#Eval("unLordingCharge_N")%></td>
                                                    <td><%#Eval("LordingCharge_N")%> </td>
                                                    <td><%#Eval("TransportationCharge_N")%> </td>
                                                    <td><%#Eval("OtherCharges_N")%> </td>
                                                    <td><%#Eval("Total")%></td>
                                                    <td><%#Eval("Name")%> </td>
                                                    <td><%#Eval("Remarks_V")%>  </td>
                                                </tr>




                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    <div style="overflow:auto" class="rdlc">
                        
                            <rsweb:ReportViewer ID="ReportViewer1" Width="80%" runat="server" DocumentMapWidth="100%" Height="" SizeToReportContent="True">
                            </rsweb:ReportViewer>
                      </div>
                    </td>
                </tr>
            </table>
            
            <tr>
                <td colspan="4">

                    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
                    </div>
                    <div id="Messages" style="display: none;" class="popupnew" runat="server">

                        <div class="msg MT10">
                            <p>
                            </p>
                        </div>
                        <a id="fancybox-close" style="display: inline;" onclick="javascript:closeMessagesDiv();"></a>
                    </div>
                </td>

            </tr>
        </div>
    </div>
</asp:Content>

