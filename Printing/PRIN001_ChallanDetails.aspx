<%@ Page Title="प्रिंटर चालान की जानकारी / Printer Challan Details " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PRIN001_ChallanDetails.aspx.cs" Inherits="Printing_PRIN001_ChallanDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="portlet-header ui-widget-header">प्रिंटर चालान की जानकारी / Printer Challan Details </div>
        <div class="box table-responsive">
         <div id="messageDiv" runat="server" class="form-message" style="display: none;">
            </div>
        <asp:Panel runat="server" ID="pnlMain">
        <table width="100%">      
        <tr>
        <td colspan="4"></td>
        </tr>
        <tr>        
        <td>
            <asp:Label ID="LblAcYear" runat="server" Width="85px">शिक्षा सत्र / Academic Year :</asp:Label>
            </td>
        <td>
            <asp:DropDownList ID="DdlACYear" runat="server" AutoPostBack="True" 
                CssClass="txtbox"  
                onselectedindexchanged="DdlACYear_SelectedIndexChanged"  >
                <asp:ListItem>..Select..</asp:ListItem>
                <asp:ListItem>2012-13</asp:ListItem>
                <asp:ListItem>2013-14</asp:ListItem>
                <asp:ListItem>2014-15</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="LblFy" runat="server" >वित्तिय वर्ष/Financial Year :</asp:Label>
            <asp:Label ID="LblFyYear" runat="server" Width="85px">2013-2014</asp:Label>
            </td>
        <td>
            <asp:Label ID="LblDepot" runat="server" Width="85px">डिपो चुने / Depot :</asp:Label>
            </td>
        <td>        
            <asp:DropDownList ID="DdlDepot" runat="server" AutoPostBack="True" 
                CssClass="txtbox" onselectedindexchanged="DdlDepot_SelectedIndexChanged">
                <asp:ListItem>select..</asp:ListItem>
                <asp:ListItem>&#2311;&#2306;&#2342;&#2380;&#2352; </asp:ListItem>
                <asp:ListItem>&#2349;&#2379;&#2346;&#2366;&#2354;  </asp:ListItem>
                <asp:ListItem>&#2357;&#2367;&#2342;&#2367;&#2358;&#2366;  </asp:ListItem>
                <asp:ListItem>&#2352;&#2368;&#2357;&#2366;  </asp:ListItem>
            </asp:DropDownList>             
         </td>
         </tr>
          <tr>
            <td>
              <asp:Label ID="LblScheme" runat="server" Width="103px">योजना चुने / Scheme :</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlScheme" runat="server" AutoPostBack="True" 
                        CssClass="txtbox" onselectedindexchanged="DdlScheme_SelectedIndexChanged">
                        <asp:ListItem>Select..</asp:ListItem>
                        <asp:ListItem>&#2361;&#2367;&#2306;&#2342;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:ListItem>
                        <asp:ListItem>&#2309;&#2306;&#2327;&#2381;&#2352;&#2375;&#2332;&#2368;  &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:ListItem>
                        <asp:ListItem>&#2360;&#2306;&#2360;&#2381;&#2325;&#2371;&#2340; &#2358;&#2366;&#2354;&#2366; </asp:ListItem>
                        <asp:ListItem>&#2313;&#2352;&#2381;&#2342;&#2370; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350;  </asp:ListItem>
                        <asp:ListItem>&#2313;&#2352;&#2381;&#2342;&#2370; &#2349;&#2366;&#2359;&#2366; </asp:ListItem>
                        <asp:ListItem>&#2350;&#2342;&#2352;&#2360;&#2366;</asp:ListItem>
                        <asp:ListItem>&#2350;&#2352;&#2366;&#2336;&#2368; &#2350;&#2366;&#2343;&#2381;&#2351;&#2350; </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="LblClass" runat="server" Width="85px">कक्षा / Class :</asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlClass" runat="server" AutoPostBack="True" 
                        CssClass="txtbox" onselectedindexchanged="DdlClass_SelectedIndexChanged">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2407; </asp:ListItem>
                        <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2408;  </asp:ListItem>
                        <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2409; </asp:ListItem>
                        <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2410;  </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                   चालान क्रमांक / G.R. क्रमांक / Challan No./ GR No.
                </td>
                <td>
                    <asp:TextBox ID="txtChalanNo" runat="server" CssClass="txtbox reqirerd" 
                        MaxLength="15" onkeypress="javascript:tbx_fnSignedInteger(event, this);" 
                        onpaste="javascript:tbx_fnSignedInteger(event, this);"></asp:TextBox>
                </td>
                <td>
                    G.R. दिनांक / GR Date</td>
                <td>
                    <asp:TextBox ID="txtChalanDate" runat="server" CssClass="txtbox reqirerd"></asp:TextBox>
                    <cc1:CalendarExtender ID="CaltxtChalanDate" runat="server" Format="dd/MM/yyyy" 
                        TargetControlID="txtChalanDate">
                    </cc1:CalendarExtender>
                  
                </td>
            </tr>
        
         <tr>
        
        <td>प्राप्ति दिनांक / Receiving Date </td>
        <td colspan="3"><asp:TextBox runat="server" ID="txtReceiptDate" CssClass="txtbox reqirerd" ></asp:TextBox></td>
        <cc1:CalendarExtender Format="dd/MM/yyyy" ID="CalendartxtReceiptDate" TargetControlID="txtReceiptDate"    runat="server"></cc1:CalendarExtender>
       
        </tr>
        
       

          
      <%--  <tr>
        <td>&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2366; &#2330;&#2351;&#2344; &#2325;&#2352;&#2375; </td>
        <td colspan="3">
        
        <asp:RadioButtonList runat="server" ID="radioGroup" RepeatDirection="Horizontal" RepeatColumns="10" AutoPostBack="true" OnSelectedIndexChanged="radioGroup_SelectedIndexChanged" >
        </asp:RadioButtonList>
        
        </td>
        </tr>--%>
        <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>
        <tr>
        <td colspan="4">

        <asp:Panel runat="server" ID="pnlTitles" GroupingText="Printer Details / प्रिंटर की जानकारी " Width="1200px" ScrollBars="Auto" >

        <asp:GridView runat="server" ID="GrdTitle" AutoGenerateColumns="False" 
                CssClass="tab hastable" onrowdatabound="GrdTitle_RowDataBound">
        <Columns>
        
        <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
        <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
        </asp:TemplateField>

         
        <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;">
        <ItemTemplate>
        <%# Eval("nameofpress_v")%>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2369;&#2346; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; ">
        <ItemTemplate>
        <%# Eval("groupno_v")%>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350;">
        <ItemTemplate>
        <%# Eval("TitleHindi_V")%>
        </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;) ">
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtPacketsSendAsPerChallan" Text='<%# Eval("PacketsSendAsPerChallan") %>'  Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2369;&#2354; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;(&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;) " >
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtTotalNoOfBooks"  Text='<%# Eval("TotalNoOfBooks") %>' Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;(&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)">
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtBooksFrom" Text='<%# Eval("BooksFrom") %>' Width="45px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox> 
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;(&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;)">
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtBooksTo" Text='<%# Eval("BooksTo") %>' Width="45px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>

  <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2348;&#2306;&#2337;&#2354; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;(&#2351;&#2379;&#2332;&#2344;&#2366;)">
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtPacketsSendAsPerChallanYoj" Text='<%# Eval("PacketsSendAsPerChallanyoj") %>'  Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        
         <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2369;&#2354; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;(&#2351;&#2379;&#2332;&#2344;&#2366;) " >
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtTotalNoOfBooksYoj"  Text='<%# Eval("TotalNoOfBooksyoj") %>' Width="80px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;(&#2351;&#2379;&#2332;&#2344;&#2366;)">
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtBooksFromYoj" Text='<%# Eval("BooksFromYoj") %>' Width="45px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox> 
        </ItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;(&#2351;&#2379;&#2332;&#2344;&#2366;)">
        <ItemTemplate>
        <asp:TextBox runat="server" ID="txtBooksToYoj" Text='<%# Eval("BooksToyoj") %>' Width="45px" MaxLength="9" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);'></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>



       <asp:TemplateField>
       <ItemTemplate>

       <asp:HiddenField runat="server" ID="HDNTitleID_I" Value='<%# Eval("TitleID_I") %>' />

        
        <asp:HiddenField runat="server" ID="HDNDepoID_I" Value='<%# Eval("DepoID_I") %>' />

       <asp:HiddenField runat="server" ID="HDNGRPID_I" Value='<%# Eval("GRPID_I") %>' />   
       
      <asp:HiddenField runat="server" ID="HDNChallanTrno_I" Value='<%# Eval("ChallanTrno_I") %>' />
          
                                        <asp:CheckBox ID="chkGroup" runat="server" />

                                
       </ItemTemplate>
       
       </asp:TemplateField>
       <asp:TemplateField>
       <ItemTemplate>
         <a href="#" id="bundalNo" runat="server" onclick="GetPopupBundle(this)">&#2348;&#2306;&#2337;&#2354; &#2319;&#2357;&#2306; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;</a>
                                                           <asp:Panel style="display:none;" id="DivR" class="popupnew1" runat="server">
                                                           <a href="#" id="fancyboxclose" class="fancyboxclose" runat="server" style="display: block;" onclick="javascript:closeMessagesDiv(this);" ></a>                 
                                                           <asp:Panel   class="form-message error" runat="server" id="mainDiv" style="display: none;padding-top:10px;padding-bottom:10px;">
                <asp:Label  id="lblmsg" class="notification" runat="server">
                
            </asp:Label>
            </asp:Panel>
                                        
                                        <table class="tab" cellspacing="5" width="100%">
                                            <tr>
                                                <th>&#2348;&#2306;&#2337;&#2354; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;</th>
                                                <th>&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;</th>
                                                <th>&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;</th>
                                                <th>&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;</th>
                                                <th>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;</th>
                                              
                                            </tr>
                                            <tr>
                                                <td>
                                                  <asp:DropDownList ID="ddltype"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" >
                                                  <asp:ListItem Text="&#2351;&#2379;&#2332;&#2344;&#2366;" Value="&#2351;&#2379;&#2332;&#2344;&#2366;"></asp:ListItem>
                                                  <asp:ListItem Text="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" Value="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" ></asp:ListItem>
                                                  </asp:DropDownList>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtBundleNo"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtToBundle"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                  <asp:TextBox ID="txtPerBundleBook"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                      <asp:TextBox ID="txtFromBookNo" onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"   AutoPostBack="true" OnTextChanged="ClacluteBook" runat="server" ></asp:TextBox>
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="txtToBookNo"  onkeypress='javascript:tbx_fnInteger(event, this);' Width="70"  runat="server" ></asp:TextBox>
                                                </td>
                                               
                                            </tr>
                                            <tr>
                                            <td colspan="2"> <asp:Button runat="server"   Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;" ID="btnSaveAll" class="btn" OnClick="SaveData"   />  </td> <td colspan="2"></td>
                                            </tr>

                                           <tr><td colspan="4">
                                           <div style="overflow:scroll;">
                                           <asp:GridView ID="grdData" runat="server" CssClass="tab" AutoGenerateColumns="false">
                                           <Columns>
                                           <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                           <ItemTemplate>
                                           <asp:TextBox runat="server" ID="BundleNo" Text='<%# Eval("BundleNo") %>'  Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
                                          <asp:HiddenField ID="hdnTitleid" runat="server" Value='<%# Eval("TitleID") %>' />
                                          
                                           </ItemTemplate>
                                           </asp:TemplateField>
                                            <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;">
                                           <ItemTemplate>
                                           <asp:Label runat="server" ID="BundleType" Text='<%# Eval("BundleType") %>'  Width="80px"  onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:Label>
                                           </ItemTemplate>
                                           </asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375;">
                                           <ItemTemplate>
        <asp:TextBox runat="server" ID="FromBook" Text='<%# Eval("FromBook") %>'  Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325;">
                                           <ItemTemplate>
        <asp:TextBox runat="server" ID="ToBook" Text='<%# Eval("ToBook") %>'  Width="80px" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </ItemTemplate>
        </asp:TemplateField>
                                           
                                           </Columns>
                                           </asp:GridView></div> </td> </tr>
                                        </table>
                                       
                            </asp:Panel>
        
       
       </ItemTemplate>
       
       </asp:TemplateField>
        </Columns>
        </asp:GridView>
        <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />

        </asp:Panel>
        </td>
        
        </tr>



       <%-- <tr>
        
        <td>&#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
        <td>
        <asp:DropDownList runat="server" ID="ddlTitalID" CssClass="txtbox reqirerd">
        
        </asp:DropDownList>
        </td>

        <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
        <td>
        <asp:Label runat="server" ID="lblDepotName" > </asp:Label>
        <asp:HiddenField runat="server" ID="HdnDepo_I" Value="0" />
        </td>

        </tr>--%>

       <%-- <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>

        <tr>
        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2349;&#2375;&#2332;&#2375; &#2327;&#2319; &#2346;&#2376;&#2325;&#2375;&#2335;&#2381;&#2360; </td>
        <td>
        <asp:TextBox runat="server" ID="txtPacketsSendAsPerChallan" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </td>

        <td>&#2327;&#2367;&#2344;&#2340;&#2368; &#2350;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2376;&#2325;&#2375;&#2335;&#2381;&#2360; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; </td>
        <td>
        <asp:TextBox runat="server" ID="txtPacketsReceiveByCounting" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </td>

        </tr>

         <tr>
        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2375; &#2309;&#2344;&#2369;&#2360;&#2366;&#2352; &#2325;&#2369;&#2354; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  </td>
        <td colspan="3">
        <asp:TextBox runat="server" ID="txtTotalNoBook" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        </td>
        </tr> 
        
        <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>


        <tr>
        
        <td>&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;  </td>
        <td>
        <asp:TextBox runat="server" ID="txtBookFrom" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        &#2360;&#2375;</td>

        <td>&#2360;&#2368;&#2352;&#2368;&#2332; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; </td>
        <td>
        <asp:TextBox runat="server" ID="txtBookto" MaxLength="4" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
        &#2340;&#2325;</td>

        </tr>--%>



         <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>

        <tr>
       
        <td>ट्रक चार्ज राशि (रू. मे) / Truck Charges (in Rs.)</td>
        <td> <asp:TextBox runat="server" ID="txtTruckCharges" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
       </td>

       <td>अनलोडिंग चार्ज राशि (रू. मे) / Unloading Charges (in Rs.)</td>
        <td> <asp:TextBox runat="server" ID="txtUnloadingCharges" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
       </td>

        </tr>
        
         <tr>
       
        <td>लोडिंग चार्ज राशि (रू. मे) / Loading Chares (in Rs.) </td>
        <td> <asp:TextBox runat="server" ID="txtLoadingCharges" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
       </td>

       <td>अन्य चार्ज राशि (रू. मे) / Other Charges  (in Rs.)</td>
        <td> <asp:TextBox runat="server" ID="txtOtherCharges" MaxLength="8" CssClass="txtbox reqirerd" onpaste="javascript:tbx_fnSignedInteger(event, this);" onkeypress='javascript:tbx_fnSignedInteger(event, this);' ></asp:TextBox>
       </td>

        </tr>
         <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>
              
        <tr>
        <td>रिमार्क / remark</td>

        <td colspan="3">
        <asp:TextBox runat="server" TextMode="MultiLine" Width="500px" ID="txtRemark"  onpaste="MaxLengthCount(this,150);" onkeypress="MaxLengthCount(this,150);tbx_fnAlphaNumericOnly(event, this);" ></asp:TextBox>
      
        </td>

        </tr>

         <tr>
        <td colspan="4"  style="height:10px;"></td>
        </tr>
        <tr>
        <td></td>
        <td colspan="3">
        <asp:Button runat="server" ID="btnsaveChallan" Text="&#2360;&#2375;&#2357; &#2325;&#2352;&#2375; " CssClass="btn" 
                OnClientClick="return ValidateAllTextForm();" OnClick="btnsaveChallan_Click" />
            <asp:Button ID="btnsaveChallan0" runat="server" CssClass="btn" 
                OnClick=" btnsaveChallan0_Click" Text="&#2357;&#2366;&#2346;&#2360; &#2332;&#2366;&#2351;&#2375; " />
        </td>
        </tr>

        </table>

        

        </asp:Panel> 
        </div> 
        <script>
            function GetPopupBundle(obj, g) {
                //alert(1);
                // obj = "'" + obj + "'";
                //alert(obj);
                //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))

               
                    //  document.getElementById('"+obj+"').value = obj;
                    document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                    document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
                

            }
            function ValidateAllTextFormNew() {
                if (document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).value == "") {
                    document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).focus();
                    return false;

                }
                //   document.getElementById(obj.id.replace("txtBundleNo", "btnSaveAll")).style.display = "block";
                //document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
            }
            function closeMessagesDiv(obj) {
                document.getElementById(obj.id.replace("fancyboxclose", "DivR")).style.display = "none";
                document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "none";
                return false;
            }
                            
                            </script>
</asp:Content>
