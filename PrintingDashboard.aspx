<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PrintingDashboard.aspx.cs" Inherits="PrintingDashboard" %>

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
            width: 62%;
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

        .auto-style1 {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <%--  <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                            <ProgressTemplate>
                                <div class="fade">
                                </div>
                                <div class="progress">
                                    <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                                </div>
                            </ProgressTemplate>
                            </asp:UpdateProgress>--%>


            <asp:Panel ID="Panel1" runat="server">
                <div id="ChallanSummary">
                    <table class="table">


                        <div id="ExportDiv" runat="server">
                            <div style="padding: 10px; font-weight: bold; text-align: center">
                                <caption>

                                    <h2>
                                        <table width="100%" class="table">
                                            <tr>
                                                <td>&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;/Academic Session :
                            <asp:Label ID="lblYr" runat="server"></asp:Label></td>

                                            </tr>
                                        </table>
                                    </h2>
                                </caption>
                            </div>

                            </tr>

                    <tr>
                        <th colspan="9" class="portlet-header ui-widget-header">As on Date : 
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </th>
                        <th class="portlet-header ui-widget-header">&nbsp;</th>
                    </tr>

                            <tr>
                                <th class="sub" colspan="4">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2310;&#2348;&#2306;&#2335;&#2344; &#2325;&#2375; &#2357;&#2367;&#2352;&#2369;&#2342;&#2381;&#2343; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367;/<br />
                                    <br />
                                    Receipt of books against allotment<br />
                                </th>
                                <th class="sub" colspan="2">&nbsp;</th>
                                <th class="sub" colspan="4">&nbsp;</th>
                            </tr>
                            <tr>
                                <th class="sub">&#2325;&#2369;&#2354; &#2310;&#2348;&#2306;&#2335;&#2344;/<br />
                                    <br />
                                    Total allotment </th>
                                <th class="sub">&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;/<br />
                                    <br />
                                    Total Supply </th>
                                <th class="sub">&#2358;&#2375;&#2359; /<br />
                                    <br />
                                    Balance</th>
                                <th class="sub">%</th>

                                <th class="sub">&#2325;&#2369;&#2354; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; /<br />
                                    <br />
                                    Total number of titles</th>
                                <th class="sub">&#2350;&#2369;&#2342;&#2381;&#2352;&#2367;&#2340; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;/<br />
                                    <br />
                                    Number of Printed Titles </th>
                                <th class="sub">&nbsp;</th>
                                <th class="sub">&nbsp;</th>
                                <th class="sub">&nbsp;</th>
                                <th class="sub">&nbsp;</th>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:LinkButton ID="lbl1" runat="server">
                                        <asp:Label ID="lblNotGenerated1" runat="server" Text="0"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <td class="auto-style1">
                                    <asp:LinkButton ID="lbl2" runat="server">
                                        <asp:Label ID="lblNotGenerated0" runat="server" Text="0"></asp:Label>
                                    </asp:LinkButton>
                                </td>
                                <td class="auto-style1">
                                    <asp:LinkButton ID="lbl3" runat="server">
                                        <asp:Label ID="lblNotGenerated" runat="server" Text="0"></asp:Label>
                                    </asp:LinkButton></td>

                                <td class="auto-style1">
                                    <asp:LinkButton ID="lbl15" runat="server">
                                        <asp:Label ID="lblNotGenerated2" runat="server" Text="0"></asp:Label>
                                    </asp:LinkButton>
                                </td>

                                <td>
                                    <asp:LinkButton ID="LinkButton1" runat="server">
                                        <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                                    </asp:LinkButton></td>
                                <td>
                                    <asp:LinkButton ID="LinkButton2" runat="server">
                                        <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                                    </asp:LinkButton></td>
                                <td>&nbsp;</td>

                                <td>&nbsp;</td>

                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <th class="sub" colspan="10">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2325;&#2379; &#2325;&#2366;&#2327;&#2332; &#2310;&#2348;&#2306;&#2335;&#2344; &#2325;&#2375; &#2357;&#2367;&#2352;&#2369;&#2342;&#2381;&#2343; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;/<br />
                                    <br />
                                    Supply against paper allotment to Printers&nbsp;&nbsp;</th>
                            </tr>
                            <tr>
                                <th class="sub">&#2325;&#2369;&#2354; &#2310;&#2348;&#2306;&#2335;&#2344;<br />
                                    &nbsp;(&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352;)<br />
                                    &#2335;&#2344; &#2350;&#2375;&#2306;/<br />
                                    <br />
                                    Total allotment (Printing Paper) In Tons</th>
                                <th class="sub" colspan="3">&#2325;&#2369;&#2354; &#2310;&#2348;&#2306;&#2335;&#2344;<br />
                                    (&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; )<br />
                                    &#2335;&#2344; &#2350;&#2375;&#2306;/<br />
                                    <br />
                                    Total allotment (Cover Paper) In Tons </th>
                                <th class="sub">&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;<br />
                                    (&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352;)<br />
                                    &#2335;&#2344; &#2350;&#2375;&#2306; /<br />
                                    <br />
                                    Total supply (Printing Paper) In Tons</th>
                                <th class="sub">&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351;
                        <br />
                                    (&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; )<br />
                                    &#2335;&#2344; &#2350;&#2375;&#2306;/<br />
                                    <br />
                                    Total supply (Cover Paper) In Tons</th>
                                <th class="sub">&#2358;&#2375;&#2359;<br />
                                    (&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2346;&#2375;&#2346;&#2352;)
                        <br />
                                    &#2335;&#2344; &#2350;&#2375;&#2306;/<br />
                                    <br />
                                    Balance(Printing paper) In Tons </th>
                                <th class="sub" colspan="3">&#2358;&#2375;&#2359;
                        <br />
                                    (&#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; )<br />
                                    &#2335;&#2344; &#2350;&#2375;&#2306;/<br />
                                    <br />
                                    Total supply (Cover Paper) In Tons</th>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:Label ID="lbl4" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style1" colspan="3">
                                    <asp:Label ID="lbl5" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl6" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl7" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbl8" runat="server"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:Label ID="lbl9" runat="server"></asp:Label>
                                </td>
                            </tr>
                    </table>
                    <div class="clearfix"></div>

                    <div id="PaperMillDistributionSummary">
                        <table class="table">
                            <tr>
                                <th class="portlet-header ui-widget-header">&#2344;&#2367;&#2357;&#2367;&#2342;&#2366;&#2357;&#2366;&#2352; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2368; &#2360;&#2370;&#2330;&#2368;/<br />
                                    Tender wise printers list </th>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Height="600px">
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                            <Columns>
                                                <asp:BoundField DataField="Tenderno_v" HeaderText="&#2335;&#2375;&#2306;&#2337;&#2352; &#2337;&#2367;&#2335;&#2375;&#2354;&#2381;&#2360; /Tender details" />
                                                <asp:BoundField DataField="Company" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; /Name of Printer" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>

                                </td>
                                <%--                <th class="sub">Mill Name</th>
             <th class="sub">Paper Supply (in MT)</th>   --%>
                            </tr>

                        </table>
                    </div>
                    <div id="BookDistributionDepotwise">
                        <table class="table table-bordered">
                            <tr>
                                <th class="portlet-header ui-widget-header">&#2325;&#2366;&#2352;&#2381;&#2351;&#2352;&#2340; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2368; &#2354;&#2367;&#2360;&#2381;&#2335;
                                <br />
                                    <br />
                                    /List of working Printers<br />
                                </th>
                                <th class="portlet-header ui-widget-header">&#2344;&#2351;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2368; &#2354;&#2367;&#2360;&#2381;&#2335; /<br />
                                    <br />
                                    List of new printers</th>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Panel ID="Panel3" runat="server" ScrollBars="Both" Height="600px">
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                            <Columns>
                                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; /Name of Printer" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                                <td>
                                    <asp:Panel ID="Panel4" runat="server" ScrollBars="Both" Height="600px">
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                            <Columns>
                                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350; /Name of Printer" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>
                                </td>
                            </tr>


                        </table>
                    </div>
                    <div class="clearfix"></div>
                    <div id="PaperMillDistributionSummary1">
                        <table class="table">
                            <tr>
                                <th class="portlet-header ui-widget-header">&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351;&#2357;&#2366;&#2352; &#2342;&#2375;&#2351;&#2325; &#2325;&#2368; &#2360;&#2370;&#2330;&#2368;<br />
                                    <br />
                                    /Printers Bill Details</th>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Panel ID="Panel5" runat="server" ScrollBars="Both" Height="600px">
                                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" CssClass="tab">
                                            <Columns>
                                                <asp:BoundField DataField="NameofPress_V" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339;&#2366;&#2354;&#2351; &#2325;&#2366; &#2344;&#2366;&#2350;  /Name of Printer" />
                                                <asp:BoundField DataField="Billno_V" HeaderText="&#2348;&#2367;&#2354; &#2344;&#2306;&#2348;&#2352; /Bill No" />
                                                <asp:BoundField DataField="BillDate_D" HeaderText="&#2348;&#2367;&#2354; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; /Bill Date" />
                                                <asp:BoundField DataField="Amount_N" HeaderText="&#2352;&#2366;&#2358;&#2367; (&#2352;&#2369;&#2346;&#2351;&#2375; &#2350;&#2375;&#2306;.) /Amount(in Rs.)" />
                                            </Columns>
                                        </asp:GridView>
                                    </asp:Panel>

                                </td>
                                <%--                <th class="sub">Mill Name</th>
             <th class="sub">Paper Supply (in MT)</th>   --%>
                            </tr>

                        </table>
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
                                    AllowPaging="True">
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
                                        <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  /   Book Quantity">
                                            <ItemTemplate>
                                                <%#Eval("totalnoofbooks")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />

                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <asp:LinkButton ID="lnBtnBack" runat="server">&#2346;&#2368;&#2331;&#2375; &#2332;&#2366;&#2319;&#2306;..</asp:LinkButton>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

