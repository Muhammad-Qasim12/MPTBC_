<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperDetilasNewPrint.aspx.cs" Inherits="CenterDepot_PaperDetilasNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box">
        <div class="card-header">
            <h2>&#2346;&#2375;&#2346;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2306;&#2337;&#2354; /&#2352;&#2368;&#2354;&nbsp; &#2360;&#2370;&#2330;&#2368; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <table width="100%">
                    <tr>
                        <td>&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year </td>
                        <td class="auto-style1">
                    <asp:DropDownList ID="ddlAcYear" Width="120px" runat="server" OnSelectedIndexChanged="ddlAcYear_SelectedIndexChanged" ></asp:DropDownList>


                        </td>

                        <td style="display:none;">&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;<br />Printer Name
                </td>
                <td style="display:none;">                     
                </td>

                        <td>
                            &nbsp;</td>                         

                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>&#2360;&#2375;&#2354;&#2375;&#2325;&#2381;&#2335; &#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2379; </td>
                        <td class="auto-style1">
                            
                        <td class="auto-style1">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox " AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="false" >
                            </asp:DropDownList>


                        </td>

                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Print Order" OnClientClick="return PrintPanel();  " />
                            <br />
                </td>
                <td>                    
                            &nbsp;</td>

                        <td>
                            &nbsp;</td>                         

                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:HiddenField ID="HDN_VendorCode" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="gvRoleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" EmptyDataText="Record Not Found." GridLines="None" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                     <asp:TemplateField HeaderText="&#2360;&#2340;&#2381;&#2352;" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAcyear" runat="server" Text='<%#Eval("Acyear")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;&lt;br&gt;Paper Size">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblActTotalSheets" runat="server" Text='<%#Eval("ActTotalSheets")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>  
                                            <asp:HiddenField ID="hdnRollStockID_I" runat="server" Value='<%#Eval("RollStockID_I")%>'></asp:HiddenField>                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;&lt;br&gt;Role No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2358;&#2375;&#2359;(&#2350;&#2375;. &#2335;&#2344;) &lt;br&gt; Total Sheets">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;Net Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;Gross Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                      <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;New Net Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNetWt" runat="server" Text='<%#Eval("NetWt")%>' onkeyup='javascript:tbx_fnSignedNumericCheck(this);' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;New Gross Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGrossWt" runat="server" Text='<%#Eval("GrossWt")%>' onkeyup='javascript:tbx_fnSignedNumericCheck(this);' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReelType" runat="server" Text='<%#Eval("DefectedReelSts")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Add">
                                        <ItemTemplate>
                                            <asp:Button ID="Button2" runat="server" CssClass="btn"   Text="Add" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="ID" 
                                  ShowFooter="True">
                                <Columns>
                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;<br>SrNo">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     
                                    <asp:BoundField DataField="CoverInformation" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; " />
                                    
                                    <%--<asp:BoundField DataField="RollNo" HeaderText="&#2352;&#2379;&#2354; /&#2352;&#2368;&#2354; &#2344;&#2306;&#2348;&#2352; " />--%>
                                    <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; /&#2352;&#2368;&#2354; &#2344;&#2306;&#2348;&#2352; ">
                                        <ItemTemplate>
                                            <%#Eval("RollNo")%>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        &#2325;&#2369;&#2354; / Total :
                                    </FooterTemplate>
                                    </asp:TemplateField>

                                    <%--<asp:BoundField DataField="NetWt" HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; " />--%>
                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; ">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>    
                                                <asp:HiddenField ID="hdnRollStockID_I" runat="server" Value='<%#Eval("RollStockID_I")%>'></asp:HiddenField>                                          
                                        </ItemTemplate>
                                        <FooterTemplate>
                                         <asp:Label ID="lblTotNetWt" runat="server"></asp:Label>  
                                    </FooterTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="GrossWt" HeaderText="&#2327;&#2381;&#2352;&#2366;&#2360; &#2357;&#2332;&#2344; " />

                                     <asp:BoundField DataField="OldNetWt" HeaderText="Old Net Weight(K.G.)" Visible="false" />
                                     <asp:BoundField DataField="OldGrossWt" HeaderText="Old Gross Weight(K.G.)" Visible="false" />

                                    <asp:BoundField DataField="PaperVendorName_V" HeaderText="&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; &#2325;&#2366; &#2344;&#2366;&#2350; " />
                                    <asp:BoundField DataField="TotalSheets" HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; " Visible="False" />
                                    <asp:BoundField DataField="OrderNo" HeaderText="&#2310;&#2352;&#2381;&#2337;&#2352; &#2344;&#2306;&#2348;&#2352; " />
                                    
                                    <asp:CommandField ShowDeleteButton="True" Visible="False" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr></table>  </div></div>

            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 900px; margin-left: -12%; margin-top: -5%">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Closeth>
                </tr>
                
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab" EmptyDataText="Record Not Found." GridLines="None" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>.
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>                                  
                                  
                                    <asp:TemplateField HeaderText="&#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2310;&#2325;&#2366;&#2352;&lt;br&gt;Paper Size">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPaperType_I" runat="server" Text='<%#Eval("PaperType_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPaperVendorTrId_I" runat="server" Text='<%#Eval("PaperVendorTrId_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblActTotalSheets" runat="server" Text='<%#Eval("ActTotalSheets")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblPaperMstrTrId_I" runat="server" Text='<%#Eval("PaperMstrTrId_I")%>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblCoverInformation" runat="server" Text='<%#Eval("CoverInformation")%>'></asp:Label>  
                                            <asp:HiddenField ID="hdnRollStockID_I" runat="server" Value='<%#Eval("RollStockID_I")%>'></asp:HiddenField>                                           
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2352;&#2379;&#2354; &#2344;&#2306;&#2348;&#2352;&lt;br&gt;Role No.">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRollNo" runat="server" Text='<%#Eval("RollNo")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2325;&#2369;&#2354; &#2358;&#2368;&#2335; &#2358;&#2375;&#2359;(&#2350;&#2375;. &#2335;&#2344;) &lt;br&gt; Total Sheets">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalSheets" runat="server" Text='<%#Eval("TotalSheets")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2344;&#2375;&#2335; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;Net Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblNetWt" runat="server" Text='<%#Eval("NetWt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;Gross Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:Label ID="lblGrossWt" runat="server" Text='<%#Eval("GrossWt")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      
                                    <asp:TemplateField HeaderText="Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReelType" runat="server" Text='<%#Eval("DefectedReelSts")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                     <asp:TemplateField HeaderText="&#2360;&#2340;&#2381;&#2352;" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAcyear" runat="server" Text='<%#Eval("Acyear")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                    </td>

                </tr>

                 <tr>
                <td colspan="6" style="height: 10px;">
                    <asp:Button runat="server" ID="btnAdd1" Text="&#2332;&#2379;&#2396;&#2375;&#2306; / Add" CssClass="btn"   OnClientClick="return fnValCheckbox();" />
                </td>
            </tr>

            </table>
        
        </div>
    </div>
       </div>

<script type="text/javascript">
    function OpenBill() {
        document.getElementById('fadeDiv').style.display = "block";
        document.getElementById('BillDiv').style.display = "block";
    }

    function fnValCheckbox() {
        var i = 0;
        var TargetBaseControl = document.getElementById('<%=GridView2.ClientID %>');
        var TargetChildControl = "CheckBox1";
        var Inputs = TargetBaseControl.getElementsByTagName("input");

        for (var n = 0; n < Inputs.length; ++n) {
            if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(TargetChildControl, 0) >= 0 && Inputs[n].checked) {
                //return true;
                i++;
            }
        }

        if (i > 1) {
            alert('Please Select only one Roll No.!');
            return false;
        }
        else if (i == 1) {
            return true;
        }
        else if (i == 0) {
            alert('Select at least one checkbox!');
            return false;
        }
       
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

    

       function PrintPreview() {
           var toPrint = document.getElementById('pntDiv');
           var popupWin = window.open('', '_blank', 'width=800,height=400,location=no,left=200px');
           popupWin.document.open();
           popupWin.document.write('<html><title>::Print Preview::</title><link rel="stylesheet" type="text/css" href="../css/printrcpt.css" media="screen"/></head><body">')
           popupWin.document.write(toPrint.innerHTML);
           popupWin.document.write('</html>');
           popupWin.document.close();
           return false;
       }

    function PrintPanel() {
        <%--var panel = document.getElementById("<%=Panel1.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=900');
            printWindow.document.write('<html><head><title></title><link href="../css/printrcpt.css" rel="stylesheet" />');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;--%>
        }
 
    </script>

    
</asp:Content>

