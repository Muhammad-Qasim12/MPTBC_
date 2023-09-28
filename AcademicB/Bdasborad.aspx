<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Bdasborad.aspx.cs" 
    Inherits="Academic_Bdasborad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            font-size: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/dashboard.css" rel="stylesheet" media="all" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" title="style" media="all" />
    <link href="../css/bootstrap-override.css" rel="stylesheet" title="style" media="all" />
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="../css/components.css" rel="stylesheet" media="all" />
    <script src="../js/amcharts.js" type="text/javascript"></script>
    <script src="../js/serial.js" type="text/javascript"></script>
    <div class="portlet-header ui-widget-header">
        <%--View Demand Grouping From Printing--%> &#2350;&#2369;&#2326;&#2381;&#2351; &#2346;&#2371;&#2359;&#2381;&#2336; / Home<div style="float: right;"></div>
        &nbsp;&nbsp;
    </div>

    &nbsp;&nbsp;&nbsp;&nbsp;	&#2358;&#2376;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352; -
    <asp:DropDownList ID="ddlAcYear" CssClass="txtbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <div class="MT20">
        <div class="col-sm-6 col-md-3">
            <div class="panel panel-success panel-stat">
                <div class="panel-heading">

                    <div class="hdngbox tsqbrd">
                        &#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2321;&#2352;&#2381;&#2337;&#2352; /<br />
                        <br />
                        Total Print orders
                    </div>
                    <div class="stat">
                        <div class="row">
                            <div class="col-xs-3">
                                <img alt="" src="../images/is-document.png">
                            </div>
                            <div class="col-xs-9">
                                <small class="stat-label"><strong>&#2325;&#2369;&#2354; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2321;&#2352;&#2381;&#2337;&#2352;/<br />
                                    <br />
                                    Total Print orders<br />
                                </strong></small>&nbsp;<h1>
                                    <asp:Label ID="lblTotalPrinOrder" runat="server" Text=""></asp:Label></h1>
                                <br />
                                <br />
                                <br />
                            </div>
                        </div>
                        <!-- row -->

                        <div class="mb15"></div>

                        <div class="row tsqbox">
                            <div class="col-xs-6">
                                <small class="stat-label"></small>
                                <h4>
                                    <asp:Label ID="lblYojnaBook" runat="server" Text=""></asp:Label></h4>
                            </div>

                            <div class="col-xs-6">
                                <small class="stat-label"></small>
                                <h4>
                                    <asp:Label ID="lblSamany" runat="server" Text=""></asp:Label></h4>
                            </div>
                        </div>
                        <!-- row -->

                    </div>
                    <!-- stat -->

                </div>
                <!-- panel-heading -->
            </div>
            <!-- panel -->
        </div>



        <div class="col-sm-6 col-md-3">
            <div class="panel panel-danger panel-stat">
                <div class="panel-heading">
                    <div class="hdngbox pcabrd">
                        &#2352;&#2366;&#2332;&#2381;&#2351; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2325;&#2375;&#2306;&#2342;&#2381;&#2352; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;  &#2360;&#2368;.&#2337;&#2368; /<br />
                        <br />
                        CD received from RSK
                    </div>
                    <div class="stat">
                        <div class="row">
                            <div class="col-xs-3">
                                <img alt="" src="../images/printer.png">
                            </div>

                        </div>
                        <!-- row -->

                        <div class="mb15"></div>

                        <div class="row pcabox">
                            <div class="col-xs-6">
                                <small class="stat-label">&#2352;&#2366;&#2332;&#2381;&#2351; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2325;&#2375;&#2306;&#2342;&#2381;&#2352; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2360;&#2368;.&#2337;&#2368;.  /<br />
                                    <br />
                                    CD received from RSK</small><h4>
                                        <asp:Label ID="lblTotalCd" runat="server" Text=""></asp:Label></h4>
                            </div>

                            <div class="col-xs-6">
                                <small class="stat-label">&#2352;&#2366;&#2332;&#2381;&#2351; &#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2325;&#2375;&#2306;&#2342;&#2381;&#2352; &#2360;&#2375; &#2309;&#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2360;&#2368;.&#2337;&#2368;./<br />
                                    <br />
                                    Outstanding CD from RSK </small>
                                <h4>
                                    <asp:Label ID="lblRemainCD" runat="server" Text=""></asp:Label></h4>
                            </div>
                        </div>
                        <!-- row -->

                    </div>
                    <!-- stat -->

                </div>
                <!-- panel-heading -->
            </div>
            <!-- panel -->
        </div>
        <!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
            <div class="panel panel-primary panel-stat">
                <div class="panel-heading">
                    <div class="hdngbox dibrd">
                        &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2361;&#2375;&#2340;&#2369; &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2366;&#2357;&#2367;&#2340; &#2325;&#2370;&#2354; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;  /<br />
                        <br />
                        Total proposed title for Printing
                    </div>
                    <div class="stat">
                        <div class="row">
                            <div class="col-xs-3">
                                <img alt="" src="../images/dispatch.png">
                            </div>
                            <div class="col-xs-9">
                                <small class="stat-label"><strong>&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2361;&#2375;&#2340;&#2369; &#2346;&#2381;&#2352;&#2360;&#2381;&#2340;&#2366;&#2357;&#2367;&#2340; &#2325;&#2370;&#2354; &#2358;&#2368;&#2352;&#2381;&#2359;&#2325; /<br />
                                    <br />
                                    Total proposed title for Printing<br />
                                </strong></small>
                                <h1>
                                    <asp:Label ID="lblTotalAllotmentbook" runat="server" Text=""></asp:Label>
                                </h1>
                                <br />
                                <br />
                            </div>
                        </div>
                        <!-- row -->

                        <div class="mb15">
                        </div>
                        <div class="row dibox">
                            <div class="col-xs-6">
                                <small class="stat-label"></small>
                                <h4>
                                    <asp:Label ID="lblSupplied" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="col-xs-6">
                                <small class="stat-label">; </small>
                                <h4>
                                    <asp:Label ID="lblRemaining" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                        </div>
                    </div>
                    <!-- stat -->

                </div>
                <!-- panel-heading -->
            </div>
            <!-- panel -->
        </div>
        <!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
            <div class="panel panel-dark panel-stat">
                <div class="panel-heading">
                    <div class="hdngbox millbrd">
                        NCIRT & SCERT &#2358;&#2368;&#2352;&#2381;&#2359;&#2325;   /<br />
                        <br />
                        Title(NCERT &amp; SCERT)
                    </div>
                    <div class="stat">
                        <div class="row">
                            <div class="col-xs-3">
                                <img alt="" src="../images/mill.png">
                            </div>
                        </div>
                        <!-- row -->

                        <div class="mb15">
                        </div>
                        <div class="row millbox">
                            <div class="col-xs-6">
                                <small class="stat-label">NCIRT </small>
                                <h4>
                                    <asp:Label ID="lblNCIRT" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="col-xs-6">
                                <small class="stat-label">Non NCIRT </small>
                                <h4>
                                    <asp:Label ID="lblNonNCIRT" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                        </div>
                        <!-- row -->

                    </div>
                    <!-- stat -->

                </div>
                <!-- panel-heading -->
            </div>
            <!-- panel -->
        </div>
        <!-- col-sm-6 -->
    </div>
    <div class="col-sm-12 col-md-12">
        <a href="ACD_Reports/DailyReport.aspx" style="color: red">&#2337;&#2375;&#2354;&#2368; &#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335;</a>
    </div>
</asp:Content>

