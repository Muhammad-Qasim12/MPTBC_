<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC " Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View_DPT014.aspx.cs" Inherits="Depo_View_DPT014" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=Panel1.ClientID %>");
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
    <%--''OnClientClick="return PrintPanel();"--%>
  
    <asp:Button Visible="false"  Text="&#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344;&#2366;&#2351;&#2375; " runat="server" CssClass="btn" OnClick="Unnamed1_Click " ID="BtnSave" />
    <asp:Button Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;" runat="server" CssClass="btn" OnClientClick="return PrintPanel();" ID="BtnPrint" Visible="False" />

  <%--  &nbsp;&nbsp;<asp:Button Text="&#2360;&#2368;&#2343;&#2375; &#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2379; &#2330;&#2366;&#2354;&#2366;&#2344; &#2349;&#2375;&#2332;&#2375; " runat="server" CssClass="btn" OnClick="BtnSave0_Click" ID="BtnSave0" />--%>
    &nbsp;
     <br />
    <br />
    <h2>
        <asp:Panel ID="Panel2" runat="server" Width="100%" Visible="false">
            <span>&#2360;&#2381;&#2335;&#2377;&#2325; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2348;&#2381;&#2343; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2366; &#2310;&#2357;&#2306;&#2335;&#2344; &#2310;&#2342;&#2375;&#2358; </span>
    </h2>

    <asp:GridView ID="grBook" runat="server" AutoGenerateColumns="False"
        CssClass="tab">
        <Columns>

            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No.">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2330;&#2369;&#2344;&#2375; / Choose">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" DataField="Title_V" />


            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Books Per Bundle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPerbundlebook" Text='<%# Eval("perbundlebook") %>' OnTextChanged="calculate" AutoPostBack="True" runat="server" Width="50px" Enabled="False"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344; / Alloted">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitleId") %>' />
                    <asp:TextBox ID="txtNofBooks" Text='<%#Eval("NoofBooks") %>' runat="server" Width="106px" Enabled="False"></asp:TextBox>
                    <asp:HiddenField ID="hdnDetailsid" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnOrderNoI" Value='<%#Eval("OrderNO") %>' runat="server"></asp:HiddenField>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" DataField="PradayBook" />
            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Distribution">
                <ItemTemplate>

                    <asp:TextBox ID="lblnoofbooks" Text='<%#Convert.ToInt32(Eval("NoofBooks")) - Convert.ToInt32(Eval("PradayBook"))%>' runat="server" Width="106px" AutoPostBack="True" OnTextChanged="calculate"></asp:TextBox>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; / Pack Bundle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPackbundle" runat="server" Width="106px"></asp:TextBox>
                </ItemTemplate>


            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2354;&#2370;&#2360; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books">
                <ItemTemplate>
                    <asp:TextBox ID="txtloose" runat="server" Width="106px"></asp:TextBox>
                </ItemTemplate>

            </asp:TemplateField>


        </Columns>
        <PagerStyle CssClass="Gvpaging" />
        <EmptyDataRowStyle CssClass="GvEmptyText" />
    </asp:GridView>
    <br />
    <br />
    <h2>
        <span>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2360;&#2375; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2366; &#2310;&#2357;&#2306;&#2335;&#2344; &#2310;&#2342;&#2375;&#2358; </span></h2>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
        CssClass="tab">
        <Columns>

            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No.">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1%>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="&#2357;&#2367;&#2359;&#2351; / Subject" DataField="Title_V" />


            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Books Per Bundle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPerbundlebook" Text='<%#Eval("perbundlebook") %>' OnTextChanged="calculate" AutoPostBack="true" runat="server" Width="50px" Enabled="false"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2310;&#2348;&#2306;&#2335;&#2344; / Alloted">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("TitleId") %>' />
                    <asp:TextBox ID="txtNofBooks" Text='<%#Eval("NoofBooks") %>' runat="server" Width="106px" Enabled="False"></asp:TextBox>
                    <asp:HiddenField ID="hdnDetailsid" runat="server"></asp:HiddenField>
                    <asp:HiddenField ID="hdnOrderNoI" Value='<%#Eval("OrderNO") %>' runat="server"></asp:HiddenField>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" DataField="PradayBook" />
            <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Distribution">
                <ItemTemplate>

                    <asp:TextBox ID="lblnoofbooks" Text='<%#Convert.ToInt32(Eval("NoofBooks")) - Convert.ToInt32(Eval("PradayBook"))%>' runat="server" Width="106px" AutoPostBack="True" OnTextChanged="calculate" Enabled="false"></asp:TextBox>

                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; / Pack Bundle">
                <ItemTemplate>
                    <asp:TextBox ID="txtPackbundle" runat="server" Width="106px" Enabled="false"></asp:TextBox>
                </ItemTemplate>


            </asp:TemplateField>
            <asp:TemplateField HeaderText="&#2354;&#2370;&#2360; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Loose Books">
                <ItemTemplate>
                    <asp:TextBox ID="txtloose" runat="server" Width="106px" Enabled="false"></asp:TextBox>
                </ItemTemplate>

            </asp:TemplateField>


        </Columns>
        <PagerStyle CssClass="Gvpaging" />
        <EmptyDataRowStyle CssClass="GvEmptyText" />
    </asp:GridView>
    </asp:Panel> 
     <asp:Panel ID="Panel1" runat="server" Width="100%" Visible="false">
    <table width="100%" border="1" id="a" runat="server" >
        <tr>
            <td colspan="9" align="center">
                <img src="../images/tbc-logo.png" /><br />
                
                
                <b>&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;<br />
                                    <br />
                                    &nbsp;<asp:Label ID="lblAddress" runat="server"></asp:Label>
                                    <br /></td>
        </tr>

        <tr>
            <td align="center" colspan="9">&#2342;&#2370;&#2352;&#2349;&#2366;&#2359; &#2344;&#2306;&#2348;&#2352; : <b>
                                    <asp:Label ID="lblphone" runat="server"></asp:Label>
                                    , &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; :<asp:Label ID="lblmobileNo" runat="server"></asp:Label>
                                    &nbsp;
&nbsp;</b>,&#2312;&#2350;&#2375;&#2354; &#2310;&#2312;&#2337;&#2368; : <b>
    <asp:Label ID="lblemailID" runat="server"></asp:Label>
    &nbsp;,</b>&#2357;&#2375;&#2348;&#2360;&#2366;&#2311;&#2335; : http://mptbc.mp.nic.in</td>
        </tr>

        <tr>
            <td align="center" colspan="9">&nbsp;</td>
        </tr>

        <tr>
            <td>&#2332;&#2367;&#2354;&#2375; &#2325;&#2366;&nbsp; &#2344;&#2366;&#2350; </td>
            <td>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td>&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
            <td>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352;</td>
            <td>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td>
            <td>
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>

        <tr>
            <td>&#2337;&#2381;&#2352;&#2366;&#2312;&#2357;&#2352; &#2325;&#2366; &#2350;&#2379;&#2348;&#2366;&#2311;&#2354; &#2344;&#2306;&#2348;&#2352; </td>
            <td>
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td>&#2335;&#2381;&#2352;&#2325; &#2344;&#2306;&#2348;&#2352; </td>
            <td>
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td >&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2344;&#2306;&#2348;&#2352; </td>
            <td>
                <asp:Label ID="Label7" runat="server"></asp:Label>
            </td><td>&#2348;&#2367;&#2354;&#2381;&#2335;&#2368; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325;</td>
             <td>
                 <asp:Label ID="Label8" runat="server"></asp:Label>
            </td><td></td>
        </tr>

    </table>
    <asp:GridView ID="GridView1" runat="server" CssClass="tab" AutoGenerateColumns="False" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;. / No.">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325;" DataField="TitleHindi_V" />
            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; " DataField="PerBandlbook" />
           
             <asp:BoundField DataField="ReceivedBook" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344; " />
            <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; " DataField="DestributeBook"></asp:BoundField>
            <asp:TemplateField HeaderText="&#2358;&#2375;&#2359; ">
                <ItemTemplate>
                      <asp:Label runat="server" Text='<%# Convert.ToInt32(Eval("ReceivedBook")) -Convert.ToInt32(Eval("DestributeBook"))%>' ID="lblTotal"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            <asp:BoundField HeaderText="&#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; " DataField="PaikBandal" />
            <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; ">
                <ItemTemplate>
                      <asp:Label runat="server" Text='<%# (Eval("LoojBandal").ToString()=="0" ? 0 : 1)%>' ID="lblTotalaa"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField  HeaderText="&#2325;&#2369;&#2354; &#2348;&#2306;&#2337;&#2354; ">
                <ItemTemplate>
                      <asp:Label runat="server" Text='<%# Convert.ToInt32(Eval("PaikBandal")) +Convert.ToInt32 (Eval("LoojBandal").ToString()=="0" ? 0 : 1)%>' ID="lblTotalss"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
            
            <asp:BoundField HeaderText="&#2354;&#2370;&#2332; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;" DataField="LoojBandal" />
        </Columns>

        <PagerStyle CssClass="Gvpaging" />
        <EmptyDataRowStyle CssClass="GvEmptyText" />
    </asp:GridView>
           <table border="0" width="100%">
                              
                              
                              <tr>
                                            <td> &nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                              <tr>
                                  <td>&nbsp;</td>
                                  <td>&#2348;&#2381;&#2354;&#2366;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; :
                                      <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                  </td>
                              </tr>
                              <tr>
                                  <td>&#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2348;&#2306;&#2343;&#2325; /&#2346;&#2381;&#2352;&#2349;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                                  <td>&nbsp;</td>
                              </tr>
                              <tr>
                                            <td> &#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; &#2319;&#2357;&#2306; &#2360;&#2368;&#2354; &#2360;&#2361;&#2367;&#2340; </td>
                                            <td>&#2361;&#2360;&#2381;&#2340;&#2366;&#2325;&#2381;&#2359;&#2352; &#2319;&#2357;&#2306; &#2360;&#2368;&#2354; &#2360;&#2361;&#2367;&#2340; </td>
                                        </tr>
                              <tr>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>
                              <tr>
                                  <td>&nbsp;</td>
                                  <td>&nbsp;</td>
                              </tr>
         </table> 
    </asp:Panel> 
  <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
  </div>
    <script>
        function GetPopupBundle(obj, g) {
            // obj = "'" + obj + "'";
            //alert(obj);
            //  alert(document.getElementById(obj.id.replace("bundalNo" ,"DivR"))

            if (document.getElementById(obj.id.replace("bundalNo", "txtNofBooks")).value == "") {

                alert("Please enter total no of book");
                document.getElementById(obj.id.replace("bundalNo", "txtNofBooks")).focus();
                $(document.getElementById(obj.id.replace("bundalNo", "txtNofBooks"))).css('background-color', '#FFBDC1');
            }
            else {
                //  document.getElementById('"+obj+"').value = obj;
                document.getElementById(obj.id.replace("bundalNo", "DivR")).style.display = "block";
                document.getElementById("ContentPlaceHolder1_fadeDiv").style.display = "block";
            }

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

