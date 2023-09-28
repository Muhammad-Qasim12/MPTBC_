<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PaperHomePage.aspx.cs" Inherits="Paper_PaperHomePage"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="../css/dashboard.css" rel="stylesheet" media="all" />
	<link href="../css/bootstrap.min.css" rel="stylesheet" title="style" media="all" />
	<link href="../css/bootstrap-override.css" rel="stylesheet" title="style" media="all" />
	<link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	<link href="../css/uniform.default.css" rel="stylesheet" type="text/css"/>
    <link href="../css/components.css" rel="stylesheet" media="all" />
   <script src="../js/amcharts.js" type="text/javascript"></script>
	<script src="../js/serial.js" type="text/javascript"></script>
    
    <script type="text/javascript">
       var chart;
       var graph;
       var categoryAxis;
      
       PwdChange();
       //function PwdChange() {
       //    $.ajax({
       //        type: "POST",
       //        url: "PaperHomePage.aspx/PaperStock",
       //        data: '{}',
       //        contentType: "application/json;charset=utf-8",
       //        dataType: "json",
       //        success: OnSuccess,
       //        failure: function (response) {
       //            alert(response.d);
       //        }
       //    });
       //};
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
           graph.lineAlpha = 0;
           graph.fillAlphas = 0.8;
           graph.balloonText = "[[fullName]]: <b>[[value]]</b>";

           chart.addGraph(graph);

           chart.write('chartdiv');
       };
     
</script>
    
     <div class="table-responsive">
        <div class="portlet-header ui-widget-header">
        <%--View Demand Grouping From Printing--%> मुख्य पृष्ठ / Home<div style="float:right;">[ All Unit In Metric Ton ]</div>
    </div>


        <div class="MT20">

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-success panel-stat">
            <div class="panel-heading">

              <div class="hdngbox tsqbrd">Paper Stock Quantity in Central Depot </div>
			  <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/is-document.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label"><strong>Total Quantity Of Paper</strong></small>
                    <h1><asp:Label ID="lblPaperTotQty" runat="server"></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row tsqbox">
                  <div class="col-xs-6">
                    <small class="stat-label">Total Supplied<br /> Quantity</small>
                    <h4><asp:Label ID="lblPprTotSupplied" runat="server"></asp:Label></h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">Remaining Quatity Of Paper</small>
                    <h4><asp:Label ID="lblPPRTotRemaining" runat="server"></asp:Label></h4>
                  </div>
                </div><!-- row -->
				
              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-danger panel-stat">
            <div class="panel-heading">
				<div class="hdngbox pcabrd">Mill Wise Printing & Cover Paper Allotment</div>
              <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/printer.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label"><strong>Allotment Of Paper</strong></small>
                    <h1><asp:Label ID="lblMillTotAllot" runat="server"></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row pcabox">
                  <div class="col-xs-6">
                    <small class="stat-label">Total Supplied<br /> Quantity</small>
                    <h4><asp:Label ID="lblMillTotSupplied" runat="server"></asp:Label></h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">Remaining Quatity Of Paper</small>
                    <h4><asp:Label ID="lblMillTotRemaining" runat="server"></asp:Label></h4>
                  </div>
                </div><!-- row -->

              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-primary panel-stat">
            <div class="panel-heading">
				<div class="hdngbox dibrd">Dispatch Info Of Central Depot To Printer</div>
              <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/dispatch.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label"><strong>Paper Allotted Quantity</strong></small>
                    <h1><asp:Label ID="lblPrinterTotAllotted" runat="server"></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row dibox">
                  <div class="col-xs-6">
                    <small class="stat-label">Total Supplied <br />Quantity</small>
                    <h4><asp:Label ID="lblPrinterTotSupplied" runat="server"></asp:Label></h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">Remaining Quatity Of Paper</small>
                    <h4><asp:Label ID="lblPrinterTotRemaining" runat="server"></asp:Label></h4>
                  </div>
                </div><!-- row -->

              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->

        <div class="col-sm-6 col-md-3">
          <div class="panel panel-dark panel-stat">
            <div class="panel-heading">
			  <div class="hdngbox millbrd">Work Plan Of Paper Mill</div>
              <div class="stat">
                <div class="row">
                  <div class="col-xs-3">
                    <img alt="" src="../images/mill.png">
                  </div>
                  <div class="col-xs-9">
                    <small class="stat-label">Allotment Of Paper </small>
                    <h1><asp:Label ID="lblWorkTotAllot" runat="server"></asp:Label></h1>
                  </div>
                </div><!-- row -->

                <div class="mb15"></div>

                <div class="row millbox">
                  <div class="col-xs-6">
                    <small class="stat-label">Total Supplied <br />Quantity</small>
                    <h4><asp:Label ID="lblWorkTotSupplied" runat="server"></asp:Label> </h4>
                  </div>

                  <div class="col-xs-6">
                    <small class="stat-label">Remaining Quatity Of Paper</small>
                    <h4><asp:Label ID="lblWorkRemain" runat="server"></asp:Label> </h4>
                  </div>
                </div><!-- row -->

              </div><!-- stat -->

            </div><!-- panel-heading -->
          </div><!-- panel -->
        </div><!-- col-sm-6 -->
      </div>
       
         
         <div class="" >
					
					<div class="col-md-6 col-sm-6">
					
						<div class="portlet light">
					
							<div class="portlet-title">
								<div class="caption">
									<span class="caption-subject font-blue-steel bold uppercase"> Graph Report Of Paper Stock</span>
								</div>							
							</div>
						
							<div class="portlet-body">
								<div id="chartdiv"></div>
							</div>
						</div>
					</div>
					
					<div class="col-md-6 col-sm-6">
					
					<div class="portlet light">
					
							<div class="portlet-title">
								<div class="caption">
									<span class="caption-subject font-blue-steel bold uppercase">Recent Activities</span>
								</div>							
							</div>
						
							<div class="portlet-body" style="min-height:400px;">
							
								<ul class="feeds">
                                    <asp:GridView ID="GVCurrentActivity" runat="server" GridLines="None" AutoGenerateColumns="false" Width="100%" ShowFooter="false" ShowHeader="false">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
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
														<%#Eval("Title") %>
														</span>
													</div>
												</div>
											</div>
										</div>
										<div class="col2">
											<div class="date">
												
											</div>
										</div>
									</li>

                                                </ItemTemplate>

                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>

									
									
								</ul>
								
							</div>
							<div class="btn-arrow-link">
								<%--<a href="javascript:;">See All Activities</a>--%>
							</div>
							
						</div>
						
					</div>
					
				</div>
				
				</div>
			
		







        
         
</asp:Content>

