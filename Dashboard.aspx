<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        #ChallanSummary .table {
            float: left !Important;
            width: 100%;
            border-collapse: collapse;
        }

        .table {
            float: left !Important;
            width: 100%;
            border-collapse: collapse;
        }

            .table tr th {
                font-weight: bold;
                border-collapse: collapse;
            }

                .table tr th.sub {
                    background-color: #c7e9f1;
                    border-collapse: collapse;
                }

            .table tr th, td {
                border: solid 1px #002a3e;
                border-collapse: collapse;
                padding: 10px;
                text-align: center;
            }

        #ChallanSummary {
            width: 99%;
        }

        #PaperMillDistributionSummary {
            width: 25%;
            float: left;
        }

        #BookDistributionDepotwise {
            width: 72%;
            float: left !important;
        }

        #ChallanSummary, #DailyReportSummary, #SummaryOfBookDispatchPrinter, #SummaryOfBookReceivedPrinter, #PaperMillDistributionSummary, #BookDistributionDepotwise {
            padding: 10px;
            float: left;
            overflow: hidden;
            min-height: 250px;
        }

        @media(max-width:520px) {
            #PaperMillDistributionSummary {
                width: 100%;
                float: left;
            }

            #BookDistributionDepotwise {
                width: 100%;
                float: left;
            }
        }
    </style>
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
        <table>
                        <tr>
                            <td>
                                Status as on  Date
                            </td>
                            <td>
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="txtbox reqirerd" 
                                    MaxLength="10" Width="238px"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtFromDate_CalendarExtender" runat="server" 
                                    Format="dd/MM/yyyy" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                            </td>
                            <td>
                             <asp:Button ID="btnSearch" runat="server" CssClass="btn" 
                                    Style="padding: 7px 5px 5px 7px !Important;" Text="Generate" 
                                    OnClick="btnSearch_Click" />
                            </td>

                        </tr>
                    </table>
    <asp:Panel ID="Panel1" runat="server">
        <div id="ChallanSummary">
            <asp:Button ID="btnExport" runat="server" CssClass="btn" Style="padding: 7px 5px 5px 7px !Important;" Text="Export to Excel" OnClick="btnExport_Click" />
             <table class="table">
                    

            <div id="ExportDiv" runat="server">
                <div style="padding: 10px; font-weight: bold; text-align: center">
                    <caption>
                        <h2>
                            &#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;</h2>
                        <br />
                        <br />
                        <h2>
                            Financial Year:
                            <asp:Label ID="lblYr" runat="server" Text="2016-2017"></asp:Label>
                        </h2>
                    </caption>
                </div>
               
                    </tr>

                    <tr>
                        <th colspan="8" class="portlet-header ui-widget-header">Summary</th>
                    </tr>
                    <tr>
                        <th colspan="8" class="sub">Total Printer</th>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <asp:Label ID="lblTotalPrinter" runat="server" Text="Label"></asp:Label></td>
                    </tr>
                    <tr>
                        <th colspan="2" class="portlet-header ui-widget-header">Challan Summary </th>
                        <th colspan="2" class="portlet-header ui-widget-header">Daily Report Summary </th>
                        <th colspan="2" class="portlet-header ui-widget-header">Summary Of Book Dispatch From Printer </th>
                        <th colspan="2" class="portlet-header ui-widget-header">Summary Of Book Received From Printer </th>
                    </tr>

                    <tr>
                        <th class="sub">Generated</th>
                        <th class="sub">Not Generated</th>
                        <th class="sub">Filled</th>
                        <th class="sub">Not filled</th>
                        <th class="sub">No of Depot</th>
                        <th class="sub">No. of books </th>
                        <th class="sub">No of Depot</th>
                        <th class="sub">No. of books </th>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="LnkBtnGenerated" runat="server" 
                                onclick="LnkBtnGenerated_Click">
                                <asp:Label ID="lblGenerated" runat="server" Text="0"></asp:Label>
                            </asp:LinkButton></td>
                        <td>
                            <asp:LinkButton ID="LnkBtnNotGenerated" runat="server"  onclick="LnkBtnNotGenerated_Click">>
                                <asp:Label ID="lblNotGenerated" runat="server" Text="0"></asp:Label>
                            </asp:LinkButton></td>

                        <td>
                            <asp:Label ID="lblFilled" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNotFilled" runat="server" Text="0"></asp:Label></td>

                        <td>
                            <asp:Label ID="lblNoDepotDispatchPrinter" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNoOfBookDispatchPrinter" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNoDepotReceivedPrinter" runat="server" Text="0"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblNoOfBookReceivedPrinter" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>
                <div class="clearfix"></div>

                <div id="PaperMillDistributionSummary">
                    <table class="table">
                        <tr>
                            <th colspan="2" class="portlet-header ui-widget-header">Paper Mill Distribution Summary (Till Today)</th>
                        </tr>

                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridPaperVendor" runat="server" AutoGenerateColumns="False"
                                    CssClass="table" AllowPaging="True" PageSize="10" PagerStyle-CssClass="pagination" OnPageIndexChanging="GridPaperVendor_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Paper Vendor" HeaderStyle-CssClass="sub">
                                            <ItemTemplate>
                                                <%#Eval("PaperVendorName_V") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Paper Supplied(in MT)" HeaderStyle-CssClass="sub">
                                            <ItemTemplate>
                                                <%#Eval("ReceivedQty") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </td>
                            <%--                <th class="sub">Mill Name</th>
             <th class="sub">Paper Supply (in MT)</th>   --%>
                        </tr>

                        <tr>
                            <th class="sub" width="193">Total Quantity (in MT)</th>
                            <th class="sub" style="text-align: left !Important">
                                <asp:Label ID="lblTotalRcvdQty" runat="server" Text=""></asp:Label></th>
                        </tr>
                    </table>
                </div>
                <div id="BookDistributionDepotwise">
                    <table class="table table-bordered">
                        <tr>
                            <th colspan="4" class="portlet-header ui-widget-header">Book Distribution - Depotwise </th>
                        </tr>
                      
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblMsg1" runat="server" Text=""></asp:Label>
                                <asp:GridView ID="GridBookDistributionDepotwise" runat="server" 
                                    AutoGenerateColumns="False" CssClass="table"
                                    AllowPaging="True" PageSize="10" PagerStyle-CssClass="pagination" 
                                    OnPageIndexChanging="GridBookDistributionDepotwise_PageIndexChanging" 
                                    onselectedindexchanged="GridBookDistributionDepotwise_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-CssClass="sub" HeaderText="Depot Name">
                                            <ItemTemplate>
                                                <%#Eval("DepoName_V") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="sub" HeaderText="Yojna">
                                            <ItemTemplate>
                                                <%#Eval("NoOfbookYojna") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="sub" HeaderText="Samanya">
                                            <ItemTemplate>
                                                <%#Eval("NoOfbookSamanya") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderStyle-CssClass="sub" HeaderText="Total">
                                            <ItemTemplate>
                                                <%#Eval("total") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>

                      
                    </table>
                </div>

            </div>
        </div>

         <div id="fadeDiv" runat="server" class="modalBackground" style="display: none">
    </div>
    <div id="MessagesGroup" style="display: none; width: 80%; left: 5%" class="popupnew"
        runat="server">
         <table width="100%">
                <tr>
                    <td style="text-align: left">
                        <%-- <asp:Button ID="btnSave" runat="server" CssClass="btn" Text="&#2344;&#2351;&#2366; &#2337;&#2366;&#2335;&#2366; &#2337;&#2366;&#2354;&#2375;"   
                            onclick="btnSave_Click" />--%>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:GridView ID="GrdChallanDetail" runat="server" AutoGenerateColumns="False" CssClass="tab"
                            AllowPaging="True" OnPageIndexChanging="GrdChallanDetail_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>.
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Printer Name ">
                                    <ItemTemplate>
                                        <%#Eval("NameofPress_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2330;&#2366;&#2354;&#2366;&#2344; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Challan No.">
                                    <ItemTemplate>
                                        <%#Eval("ChallanNo_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350;  / Depot Name ">
                                    <ItemTemplate>
                                        <%#Eval("deponame_v")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Textbook Name">
                                    <ItemTemplate>
                                        <%#Eval("TitleHindi_V")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352;  / Book Type">
                                    <ItemTemplate>
                                        <%#Eval("Booktype")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="पुस्तक संख्या  /   Book Quantity">
                                    <ItemTemplate>
                                        <%#Eval("totalnoofbooks")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                             <PagerStyle CssClass="Gvpaging" /> <EmptyDataRowStyle CssClass="GvEmptyText" />
                            
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        <asp:LinkButton ID="lnBtnBack" runat="server" OnClick="lnBtnBack_Click">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
    </div>
    </asp:Panel>

</asp:Content>

