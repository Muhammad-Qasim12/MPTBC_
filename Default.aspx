<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h5 class="card-title mb-3">Dashboard</h5>
    <div class="row">
        <div class="col-md-4 stretch-card grid-margin">
            <div class="card bg-gradient-danger card-img-holder text-white">
                <div class="p-3">
                    <img src="assets/img/circle.svg" class="card-img-absolute" alt="circle-image">
                    <h4 class="font-weight-normal mb-3">मुद्रण हेतु प्रस्तावित कूल शीर्षक <i class="bi bi-bar-chart float-right"></i>
                    </h4>
                    <h2 class="mb-3"><b class="counter" data-target="290"></b></h2>
                    <h6 class="card-text">कूल शीर्षक 435</h6>
                </div>
            </div>
        </div>
        <div class="col-md-4 stretch-card grid-margin">
            <div class="card bg-gradient-info card-img-holder text-white">
                <div class="p-3">
                    <img src="assets/img/circle.svg" class="card-img-absolute" alt="circle-image">
                    <h4 class="font-weight-normal mb-3">कुल प्रिंट ऑर्डर <i class="bi bi-bar-chart-steps mdi-24px float-right"></i>
                    </h4>
                    <h2 class="mb-3"><b class="counter" data-target="334"></b></h2>
                    <h6 class="card-text">कुल प्रिंट ऑर्डर 10%</h6>
                </div>
            </div>
        </div>
        <div class="col-md-4 stretch-card grid-margin">
            <div class="card bg-gradient-success card-img-holder text-white">
                <div class="p-3">
                    <img src="assets/img/circle.svg" class="card-img-absolute" alt="circle-image">
                    <h4 class="font-weight-normal mb-3">राज्य शिक्षा केंद्र से प्राप्त सी.डी <i class="bi bi-bar-chart-line mdi-24px float-right"></i>
                    </h4>
                    <h2 class="mb-3"><b class="counter" data-target="262"></b></h2>
                    <h6 class="card-text">राज्य शिक्षा केंद्र से अप्राप्त सी.डी. <span class="text-right">02</span></h6>
                </div>
            </div>
        </div>
    </div>
    <div class="card">
    <div class="card-header">
        <h2>मुद्रणालयवार देयक की सूची</h2>
    </div>
    
        <div class="card-body">
            <table id="datatable" class="table table-bordered dataTable">
                <thead>
                    <tr role="row">
                        <th>मुद्रणालय का नाम</th>
                        <th>बिल नंबर</th>
                        <th>बिल दिनांक</th>
                        <th>राशि (रुपये में.)</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>New Press 1</td>
                        <td>NEW/5/2018-2019</td>
                        <td>08-01-2018</td>
                        <td>2333971.00</td>
                    </tr>
                   <tr>
                        <td>New Press 2</td>
                        <td>NEW/5/2018-2019</td>
                        <td>08-01-2018</td>
                        <td>2333971.00</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <div class="box">
        <div id="aa" runat="server" visible="false">
            <table width="100%">
                <tr>
                    <td>&#2358;&#2375;&#2325;&#2381;&#2359;&#2339;&#2367;&#2325; &#2360;&#2340;&#2381;&#2352;</td>
                    <td>
                        <asp:DropDownList ID="ddlAcYearId" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2352; &#2325;&#2366; &#2344;&#2366;&#2350;
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrinter" runat="server">
                        </asp:DropDownList>
                        <a href="RPT003_GroupAllotment.aspx"></a>
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn" Text="&#2326;&#2379;&#2332;&#2375;"
                            OnClick="btnSearch_Click" OnClientClick="return ValidateAllTextForm();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <strong>&#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdGroupDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" OnRowDataBound="GrdGroupDetails_RowDataBound" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleHindi_V" runat="server" Text='<%#Eval("TitleHindi_V") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2371;&#2359;&#2381;&#2335; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoofpages" runat="server" Text='<%#Eval("Noofpages") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="NoofBookYojna" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366; )" />
                                <asp:BoundField DataField="NoofBookSamana" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; )" />

                                <asp:TemplateField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotNoOfBooks" runat="server" Text='<%#Eval("TotNoOfBooks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2342;&#2352; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty_PriPaper11" runat="server" Text='<%#Eval("Rates") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2366;&#2327;&#2332; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl1" runat="server" Text='<%#Eval("Qty_PriPaper") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2325;&#2357;&#2352; &#2325;&#2366;&#2327;&#2332; &#2325;&#2367; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl2" runat="server" Text='<%#Eval("Qty_Covpaper") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>












                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <strong>&#2350;&#2369;&#2342;&#2381;&#2352;&#2325;&#2379; &#2325;&#2379; &#2346;&#2375;&#2346;&#2352; &#2310;&#2357;&#2306;&#2335;&#2344;</strong>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="GrdGroupDetails0" runat="server" AutoGenerateColumns="False" CssClass="tab"
                            OnRowDataBound="GrdGroupDetails_RowDataBound1" ShowFooter="True">
                            <Columns>
                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTitleHindi_V0" runat="server" Text='<%#Eval("TitleHindi_V") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="&#2346;&#2371;&#2359;&#2381;&#2335; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNoofpages0" runat="server" Text='<%#Eval("Noofpages") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="NoofBookYojna" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2351;&#2379;&#2332;&#2344;&#2366; )" />
                                <asp:BoundField DataField="NoofBookSamana" HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; )" />

                                <asp:TemplateField HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotNoOfBooks0" runat="server" Text='<%#Eval("TotNoOfBooks") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2342;&#2352; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQty_PriPaper12" runat="server" Text='<%#Eval("Rates") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <asp:TemplateField HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2350;&#2369;&#2342;&#2381;&#2352;&#2339; &#2325;&#2366;&#2327;&#2332; &#2325;&#2368; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl3" runat="server" Text='<%#Eval("Qty_PriPaper") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2375; &#2325;&#2357;&#2352; &#2325;&#2366;&#2327;&#2332; &#2325;&#2367; &#2350;&#2366;&#2340;&#2381;&#2352;&#2366; ">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl4" runat="server" Text='<%#Eval("Qty_Covpaper") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>












                                <asp:BoundField DataField="Praday" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2327; &#2346;&#2375;&#2346;&#2352;" />
                                <asp:BoundField DataField="CoverPaperPraday" HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; " />












                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
