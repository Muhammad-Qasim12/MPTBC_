<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DPTDasborad.aspx.cs" Inherits="Depo_DPTDasborad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <link href="../css/dashboard.css" rel="stylesheet" media="all" />
	<link href="../css/bootstrap.min.css" rel="stylesheet" title="style" media="all" />
	<link href="../css/bootstrap-override.css" rel="stylesheet" title="style" media="all" />
	<link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	<link href="../css/uniform.default.css" rel="stylesheet" type="text/css"/>
    <link href="../css/components.css" rel="stylesheet" media="all" />
   <script src="../js/amcharts.js" type="text/javascript"></script>
	<script src="../js/serial.js" type="text/javascript"></script>
    <%--<script type="text/javascript">
        var chart;
        var graph;
        var categoryAxis;

        PwdChange();
        function PwdChange() {

            $.ajax({
                type: "POST",
                url: "DPTDasborad.aspx/DepoStock",
               
                data: JSON.stringify({ ID: '<%=Session["UserID"]%>' }),
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        };
        function OnSuccess(response) {
            var chartData = JSON.parse(response.d);

            chart = new AmCharts.AmSerialChart();
            chart.dataProvider = chartData;
            chart.categoryField = "country";
            chart.position = "left";
            chart.angle = 30;
            chart.depth3D = 15;
            chart.startDuration = 1;

            categoryAxis = chart.categoryAxis;
            categoryAxis.labelRotation = 45;
            categoryAxis.dashLength = 5; //
            categoryAxis.gridPosition = "start";
            categoryAxis.autoGridCount = false;
            categoryAxis.gridCount = chartData.length;


            graph = new AmCharts.AmGraph();
            graph.valueField = "visits";
            graph.type = "column";
            graph.colorField = "color";
            graph.lineAlpha = 200;
            graph.fillAlphas = 0.8;
            graph.balloonText = "[[fullName]]";

            chart.addGraph(graph);

            chart.write('chartdiv');
        };

</script>--%>
   <%-- 
	<div id="page-wrapper">
		<div id="main-wrapper">
			<div id="main-content">	--%>		
			  <div class="portlet-header ui-widget-header">
        <%--View Demand Grouping From Printing--%> &#2350;&#2369;&#2326;&#2381;&#2351; &#2346;&#2371;&#2359;&#2381;&#2336; / Home<div style="float:right;"></div>
    </div>
			    
				
				<div class="MT20">

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-success panel-stat">
            <div class="panel-heading">

              <div class="hdngbox tsqbrd">&#2337;&#2367;&#2346;&#2379; &#2350;&#2375;&#2306; &#2313;&#2346;&#2354;&#2357;&#2381;&#2343; &#2360;&#2381;&#2335;&#2377;&#2325;  </div>
			  <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/is-document.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label"><strong>&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; (&#2351;&#2379;. + &#2360;&#2366;. )</strong></small>
                    <h1>
                        <asp:Label ID="lblTotalBook" runat="server" Text=""></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row tsqbox">
                  <div class="col-xs-6">
                    <small class="stat-label">&#2351;&#2379;&#2332;&#2344;&#2366; </small>
                    <h4><asp:Label ID="lblYojnaBook" runat="server" Text=""></asp:Label></h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; </small>
                    <h4><asp:Label ID="lblSamany" runat="server" Text=""></asp:Label></h4>
                  </div>
                </div><!-- row -->
				
              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-danger panel-stat">
            <div class="panel-heading">
				<div class="hdngbox pcabrd">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; </div>
              <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/printer.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label"><strong>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2360;&#2375; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; </strong></small>
                    <h1><asp:Label ID="lblotalBooSupP" runat="server" Text=""></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row pcabox">
                  <div class="col-xs-6">
                    <small class="stat-label">&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2325;&#2379; &#2310;&#2357;&#2306;&#2335;&#2344; </small>
                    <h4><asp:Label ID="lblTotaSup" runat="server" Text=""></asp:Label></h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">&#2358;&#2375;&#2359; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; </small>
                    <h4><asp:Label ID="lblRemain" runat="server" Text=""></asp:Label></h4>
                  </div>
                </div><!-- row -->

              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-primary panel-stat">
            <div class="panel-heading">
				<div class="hdngbox dibrd">&#2351;&#2379;&#2332;&#2344;&#2366; &#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </div>
              <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/dispatch.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label"><strong>&#2310;&#2357;&#2306;&#2335;&#2344; </strong></small>
                    <h1><asp:Label ID="lblTotalAllotmentbook" runat="server" Text=""></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row dibox">
                  <div class="col-xs-6">
                    <small class="stat-label">&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </small>
                    <h4><asp:Label ID="lblSupplied" runat="server" Text=""></asp:Label></h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">&#2358;&#2375;&#2359; </small>
                    <h4><asp:Label ID="lblRemaining" runat="server" Text=""></asp:Label></h4>
                  </div>
                </div><!-- row -->

              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-dark panel-stat">
            <div class="panel-heading">
			  <div class="hdngbox millbrd">&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2348;&#2367;&#2325;&#2381;&#2352;&#2368; </div>
              <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/mill.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2350;&#2366;&#2306;&#2327; </small>
                    <h1><asp:Label ID="lblBooksellerDemand" runat="server" Text=""></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row millbox">
                  <div class="col-xs-6">
                    <small class="stat-label">&#2325;&#2369;&#2354; &#2350;&#2366;&#2306;&#2327; </small>
                    <h4>00 </h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">&#2358;&#2375;&#2359; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2375; </small>
                    <h4>00</h4>
                  </div>
                </div><!-- row -->

              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->
      </div>
				
				<div class="row">
					
					<div class="col-md-6 col-sm-6">
					
						<div class="portlet light">
					 <div class="portlet-title">
								<div class="caption">
									<span class="caption-subject font-blue-steel bold uppercase"> &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; </span>
								</div>							
							</div>
							<%--<div class="portlet-title">
								<div class="caption">
									<span class="caption-subject font-blue-steel bold uppercase">Graph Report of Class Wise Books</span>
								</div>							
							</div>--%>
                         <asp:Panel ID="Panel2" runat="server" ScrollBars="Both" Height="400px" >
							<div class="portlet-body">
							
								<ul class="feeds">
                                     <%
                                        
                                         for (int i = 0; i < ddd1.Tables[0].Rows.Count; i++)
                                                          { 
                                                          
                                                          
                                                           %>
									<li>
										<div class="col1">
											<div class="cont">
												<div class="cont-col1">
													<div class="label label-sm label-info">
														<i class="fa fa-check"></i>
													</div>
												</div>
												<div class="cont-col2">
													<div class="desc">
                                                       
														<%=ddd1.Tables[0].Rows[i]["PrinterName"].ToString () %>- <%=ddd1.Tables[0].Rows[i]["NoOfBooks"].ToString () %>  <span class="label label-sm label-warning ">
												
                                                             <a href="VitranOrder.aspx">&#2342;&#2375;&#2326;&#2375; <i class="fa fa-share"></i></a>
                                                         
														</span>
													</div>
												</div>
											</div>
										</div>
										<div class="col2">
											<div class="date">
												<%=ddd1.Tables[0].Rows[i]["VitranDate"].ToString () %>
											</div>
										</div>
									</li><%} %>
								
									
																	
									
									
								</ul>
								
							</div>
							<div class="btn-arrow-link">
								<a  <a href="VitranOrder.aspx">&#2360;&#2349;&#2368; &#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2342;&#2375;&#2326;&#2375; </a>
							</div>
							</asp:Panel>

						
							<%--<div class="portlet-body">
								<div id="chartdiv"></div>
							</div>--%>
						</div>
					</div>
					
					<div class="col-md-6 col-sm-6">
					
					<div class="portlet light">
					
							<div class="portlet-title">
								<div class="caption">
									<span class="caption-subject font-blue-steel bold uppercase"> &#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; /&#2309;&#2306;&#2340;&#2337;&#2367;&#2346;&#2379; &#2325;&#2375; &#2330;&#2366;&#2354;&#2366;&#2344; </span>
								</div>							
							</div>
                        <asp:Panel ID="Panel1" runat="server" ScrollBars="Both" Height="400px">
							<div class="portlet-body">
							
								<ul class="feeds">
                                     <%for (int i = 0; i < ddd.Tables[0].Rows.Count; i++)
                                                          { 
                                                          
                                                          
                                                           %>
									<li>
										<div class="col1">
											<div class="cont">
												<div class="cont-col1">
													<div class="label label-sm label-info">
														<i class="fa fa-check"></i>
													</div>
												</div>
												<div class="cont-col2">
													<div class="desc">
                                                       
														<%=ddd.Tables[0].Rows[i]["ChallanDetails"].ToString () %> <span class="label label-sm label-warning ">
													<% if (ddd.Tables[0].Rows[i]["typea"].ToString () == "1")
                {   %>
                                                            <a href="InterDepoBookReceived.aspx">	&#2342;&#2375;&#2326;&#2375; <i class="fa fa-share"></i></a>
                                                            <%} %>
                                                            <% if (ddd.Tables[0].Rows[i]["typea"].ToString () == "2")
                                                               { 
                                                                   %>
                                                             <a href="ReceievedInterDepoBandal.aspx">	&#2342;&#2375;&#2326;&#2375;  <i class="fa fa-share"></i></a>
                                                            <%} %>
                                                             <% if (ddd.Tables[0].Rows[i]["typea"].ToString () == "3")
                                                               { 
                                                                   %>
                                                             <a href="OtherThanTextbookReceived.aspx">	&#2342;&#2375;&#2326;&#2375;  <i class="fa fa-share"></i></a>
                                                            <%} %>
                                                             <% if (ddd.Tables[0].Rows[i]["typea"].ToString () == "4")
                                                               { 
                                                                   %>
                                                             <a href="otherthanTextbookInterDepo.aspx">	&#2342;&#2375;&#2326;&#2375;  <i class="fa fa-share"></i></a>
                                                            <%} %>
														</span>
													</div>
												</div>
											</div>
										</div>
										<div class="col2">
											<div class="date">
												<%=ddd.Tables[0].Rows[i]["d"].ToString () %>
											</div>
										</div>
									</li><%} %>
								
									
																	
									
									
								</ul>
								
							</div>
							<div class="btn-arrow-link">
								<a href="javascript:;">&#2360;&#2349;&#2368; &#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2375;&#2326;&#2375; </a>
							</div>
							</asp:Panel>
                        <br />
                       
						</div>
						
					</div>
					
				</div>
				
				<%--</div>
			
			</div>
			--%>
			
			<div class="clearfix"></div>
	<%--	</div>
		
	</div></div>
	<div class="clearfix"></div></div>--%>
</asp:Content>

