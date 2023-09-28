<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true"  CodeFile="PaySlip.aspx.cs" Inherits="Depo_PaySlip"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            width: 7%;
        }
        .auto-style2 {
            font-weight: bold;
        }
        .auto-style3 {
            text-align: center;
            font-weight: bold;
            width: 7%;
        }
        .auto-style4 {
            font-weight: bold;
            width: 7%;
        }
        .auto-style5 {
            width: 7%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card-header">
        <h2>Pay Slip</h2>
    </div>
    <div class="portlet-content">
        <div class="table-responsive">
            <table width="100%" border="1">
                <tr>
                    <td>&nbsp;&#2357;&#2352;&#2381;&#2359; </td>
                    <td>
                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="ddl ">
                        </asp:DropDownList>
                    </td>
                    <td>&#2350;&#2366;&#2361; </td>
                    <td>
                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="ddl ">
                        </asp:DropDownList>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&#2346;&#2375; &#2348;&#2367;&#2354; &#2330;&#2369;&#2344;&#2375;</td>
                    <td>
                        <asp:DropDownList ID="ddlPaybiil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPaybiil_SelectedIndexChanged">
                        </asp:DropDownList>

                      
                    </td>
                    <td>&#2325;&#2352;&#2381;&#2350;&#2330;&#2366;&#2352;&#2368; &#2325;&#2366; &#2344;&#2366;&#2350;</td>
                    <td>
                        <asp:DropDownList ID="ddlEmployeeName" runat="server" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Show Report" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" style="padding-bottom: 30px;"></td>
                </tr>
            </table>
            <div id="aj" runat="server">
                <div id="ExportDiv" runat="server" clientidmode="Static">
                    <table width="100%" style="border:dotted "  >
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <b>PAY SLIP</b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="text-align: center">
                                <b>M.P. TEXT BOOK CORPORATION</b></td>
                        </tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <b>Month&nbsp;&nbsp;:&nbsp;&nbsp;<asp:Label ID="lblmonth" runat="server"></asp:Label></b></td>
                        </tr>

                        <tr>
                            <td style="text-align: left; width: 15%;"><b>Emp.Code</b></td>
                            <td style="text-align: left;">
                                <b>:&nbsp;&nbsp;<asp:Label ID="lblEmpcode" runat="server"></asp:Label></b>
                            </td>


                            <td style="text-align: left; width: 20%;"><b>E.P.F. Account No.</b></td>
                            <td style="text-align: left; width: 15%;">
                                <b>:&nbsp;&nbsp;<asp:Label ID="lblEPF" runat="server"></asp:Label></b>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left;"><b>Name</b></td>
                            <td style="text-align: left;">
                                <b>:&nbsp;&nbsp;<asp:Label ID="lblName" runat="server"></asp:Label></b>
                            </td>


                            <td style="text-align: left;"><b>Pay Bill Register No</b></td>
                            <td style="text-align: left;">
                                <b>:&nbsp;&nbsp;<asp:Label ID="lblPayBillRegisterNo" runat="server"></asp:Label></b>
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left;"><b>Designation</b></td>
                            <td style="text-align: left;">
                                <b>:&nbsp;&nbsp;<asp:Label ID="lblDesgination" runat="server"></asp:Label></b>
                            </td>

                            <td style="text-align: left;"><b>Bill/Voucher No </b></td>
                            <td style="text-align: left;">
                                <b>:&nbsp;&nbsp;<asp:Label ID="lblBillNo" runat="server"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                <table width="100%" border="1">
                                    <tr>
                                        <td colspan="9" style="border-bottom: double"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: center"><b>Details of drawal</b></td>
                                        <td colspan="5" style="text-align: center"><b>Details of deductions</b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="9" style="border-bottom: double"></td>
                                    </tr>
                                    <tr style="border:thin ">
                                        <td style="text-align: left; padding-top: 7px; width: 15%;" class="auto-style2">Bend</td>
                                        <td style="text-align: left; padding-top: 7px; width: 10%"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl1" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px; width: 15%" class="auto-style2">Intrim Relief</td>
                                        <td style="text-align: left; padding-top: 7px; width: 10%"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla1" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px; width: 15%" class="auto-style2">Income Tax</td>
                                        <td style="text-align: left; padding-top: 7px; width: 10%"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld1" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px; width: 15%" class="auto-style2">EPF Adv. Rec.</td>
                                        <td style="text-align: center; " class="auto-style4">(NIL)</td>
                                        <td style="text-align: left; padding-top: 7px; width: 10%"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd1" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Grade Pay</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl2" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Leave Salary</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla2" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">GIS</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld2" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">H.B. Adv. Rec.</td>
                                        <td style="text-align: center;  class="auto-style5">(<asp:Label ID="Label3" runat="server" CssClass="auto-style2"></asp:Label><b>)
                                        </b>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd2" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Stag. Increment</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl3" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Washing Allowance</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla3" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">FPF</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld3" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Mot. Car Rec.</td>
                                        <td style="text-align: center; padding-top: 7px;" class="auto-style4">(NIL)</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd3" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Special Pay</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl4" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Tribal Allowance</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla4" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">EPF/GPF</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld4" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Mot. Cyc. Rec.</td>
                                        <td style="padding-top: 7px;" class="auto-style3">(NIL)</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd4" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Personal Pay</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl5" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Tution Fee</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla5" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">HouseRent+Water<br />
                                            Charge</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld5" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Fest. Adv. Rec. <br />
                                            </td>
                                        <td style="padding-top: 7px;" class="auto-style1">(<asp:Label ID="Label1" runat="server" Text="" CssClass="auto-style2"></asp:Label><b>)</b></td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd5" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Deput. Allowance</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl6" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Conveyance Allowance</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla6" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Leave Recovery</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld6" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Any Adv. Rec.</td>
                                        <td style="padding-top: 7px;" class="auto-style3">(NIL)</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd6" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">DA.</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl7" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Medical Allowance</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla7" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Motor Veh.Charges</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld7" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Grain Adv. Rec. <br />
                                        </td>
                                        <td style="padding-top: 7px;" class="auto-style1"><b>( </b> <asp:Label ID="Label2" runat="server" Text="" CssClass="auto-style2"></asp:Label><b>)
                                        </b>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd7" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Addl.DA.</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl8" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Other Allowance</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbla8" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">TA Recovery</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld8" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Pay Adv. Rec.</td>
                                        <td style="padding-top: 7px;" class="auto-style3">(<asp:Label ID="Label5" runat="server" CssClass="auto-style2"></asp:Label><b>)
                                        </b>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd8" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">House Rent Allow</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl9" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td colspan="2" style="text-align: left; padding-top: 7px;"></td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Professional Tax</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld9" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Cyc. Adv. Rec.</td>
                                        <td style="padding-top: 7px;" class="auto-style3">(NIL)</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd9" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">CCA</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbl10" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td colspan="2" style="text-align: left; padding-top: 7px;"></td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Walfare Fund</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld10" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Med. Adv. Rec.<br />
                                        </td>
                                        <td style="padding-top: 7px;" class="auto-style1">(<asp:Label ID="Label4" runat="server" CssClass="auto-style2"></asp:Label><b>)
                                        </b>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd10" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: left; padding-top: 7px;"></td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">LIC</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbld11" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">Misc. Adv. Rec.</td>
                                        <td style="padding-top: 7px;" class="auto-style3">(NIL)</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;</b><asp:Label ID="lbldd11" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" style="text-align: left; padding-top: 7px;">&nbsp;</td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">NPS</td>
                                        <td style="text-align: left; padding-top: 7px;"><asp:Label ID="lbld12" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style2">EISS</td>
                                        <td style="padding-top: 7px;" class="auto-style3">&nbsp;</td>
                                        <td style="text-align: left; padding-top: 7px;"><asp:Label ID="lbld13" runat="server" CssClass="auto-style2"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" colspan="2"></td>
                                        <td style="text-align: left; padding-top: 7px;"><b>Gross Salary</b></td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;<asp:Label ID="lblGross" runat="server"></asp:Label></b></td>
                                        <td style="text-align: left; padding-top: 7px;" colspan="2"></td>
                                        <td style="text-align: left; padding-top: 7px;"><b>Total Deduction</b></td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style5">&nbsp;</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;<asp:Label ID="lbltotalDedection" runat="server"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td style="text-align: left; padding-top: 7px;" colspan="6"></td>
                                        <td style="text-align: left; padding-top: 7px;"><b>Net Salary</b></td>
                                        <td style="text-align: left; padding-top: 7px;" class="auto-style5">&nbsp;</td>
                                        <td style="text-align: left; padding-top: 7px;"><b>:&nbsp;&nbsp;<asp:Label ID="lblnetsalary" runat="server"></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td colspan="9" style="border-bottom: double"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left; padding-top: 7px;">Date <%= System.DateTime.Now.ToString ("dd/MM/yyy") %> </td>
                            <td colspan="2" style="text-align: left; padding-top: 7px;">Seal of the officer</td>
                        </tr>
                    </table>
                </div>
                <table width="100%">
                    <tr>
                        <td style="text-align: center;">
                            <asp:Button ID="btnPrint" runat="server" Text="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375;&#2306;" Width="150" CssClass="btn" OnClientClick="return PrintPanel()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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
</asp:Content>

