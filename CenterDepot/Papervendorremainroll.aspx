<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Papervendorremainroll.aspx.cs" Inherits="CenterDepot_PaperDetilasNew" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 37px;
        }
        .auto-style2 {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="box">
        <div class="card-header">
            <h2>&#2346;&#2375;&#2346;&#2352; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2375; &#2354;&#2367;&#2319; &#2348;&#2306;&#2337;&#2354; /&#2352;&#2368;&#2354; &#2348;&#2344;&#2366;&#2351;&#2375; </h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">

                <table width="100%">
                    <tr>
                        <td colspan="2">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; /Acadmic Year </td>
                        <td class="auto-style1" colspan="3">
                    <asp:DropDownList ID="ddlAcYear" Width="120px" runat="server" ></asp:DropDownList>


                        </td>

                        <td style="display:none;">&nbsp;</td>
                <td style="display:none;">&nbsp;</td>

                        <td>
                            &nbsp;

                        </td>                         

                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                        <td class="auto-style1" colspan="3">
                            &nbsp;</td>

                        <td>
                            <br />
                </td>
                <td>                    &nbsp;</td>

                        <td>
                            &nbsp;</td>                         

                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            &#2346;&#2375;&#2346;&#2352; &#2325;&#2366; &#2335;&#2366;&#2311;&#2346;


                        </td>
                        <td class="auto-style1">
                            <asp:DropDownList ID="ddlGSM" runat="server" AutoPostBack="True" CssClass="txtbox reqirerd" OnSelectedIndexChanged="ddlGSM_SelectedIndexChanged">
                            </asp:DropDownList>


                            <br />


                        </td>
                        <td>&#2346;&#2375;&#2346;&#2352; &#2350;&#2367;&#2354; </td>
                        <td>
                            <asp:DropDownList ID="ddlVenderFill" runat="server">
                            </asp:DropDownList>
                        </td>
                        
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="7" class="auto-style2">
                            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Data" OnClientClick="return ValidateAllTextForm();" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            <asp:GridView ID="gvRoleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" EmptyDataText="Record Not Found." GridLines="None" Width="100%">
                                <Columns>
                                    <asp:TemplateField HeaderText="SrNo">
                                        <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                     <asp:TemplateField HeaderText="&#2360;&#2340;&#2381;&#2352;" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAcyear" runat="server" Text='<%#Eval("Acyear")%>' ></asp:Label>
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
                                            <asp:TextBox ID="txtNetWt" runat="server" ReadOnly="true"  Text='<%#Eval("NetWt")%>' onkeyup='javascript:tbx_fnSignedNumericCheck(this);' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="&#2327;&#2381;&#2352;&#2377;&#2360; &#2357;&#2332;&#2344; (K.G.)&lt;br&gt;New Gross Weight(K.G.)">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtGrossWt" runat="server" Text='<%#Eval("GrossWt")%>' onkeyup='javascript:tbx_fnSignedNumericCheck(this);' onkeypress='javascript:tbx_fnSignedNumeric(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>

                                    
                                    
                                     
                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            &nbsp;</td>
                    </tr></table>  </div></div>

            <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="BillDiv" class="popupnew" style="display: none; width: 900px; margin-left: -12%; margin-top: -5%">
        <div align="right">
            <a href="#" onclick="document.getElementById('fadeDiv').style.display='none'; document.getElementById('BillDiv').style.display='none';">Close</a>
        </div>
        <div style="min-height: 100px; max-height: 500px; overflow: auto;">
            <table width="100%">
                <tr>
                    <th colspan="6" style="font-weight: bold;" class="portlet-header ui-widget-header">Roll Details
                    </th>
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
                                            <asp:Label ID="lblAcyear" runat="server" Text='<%#Eval("Acyear")%>' ></asp:Label>
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
    </script>
</asp:Content>

