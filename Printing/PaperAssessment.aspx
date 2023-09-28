<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master"
    CodeFile="PaperAssessment.aspx.cs" Inherits="Printing_PaperAssessment"
    Title="पेपर का आंकलन" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="card">
        <div class="card-header">
                <h2>पेपर का आंकलन</h2>
            </div>
        <div class="card-body">
            
            <div class="row g-3">
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select"
                            OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged"
                            AutoPostBack="True">
                            <asp:ListItem>..Select..</asp:ListItem>
                            <asp:ListItem>2012-13</asp:ListItem>
                            <asp:ListItem>2013-14</asp:ListItem>
                            <asp:ListItem>2014-15</asp:ListItem>
                        </asp:DropDownList>
                        <label>शिक्षा सत्र</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:Label ID="LblFyYear" runat="server">2013-2014</asp:Label>
                        <label>वित्तिय वर्ष</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="form-select"
                            AutoPostBack="True" OnSelectedIndexChanged="DdlDepot_SelectedIndexChanged"
                            TabIndex="1" Visible="False">
                            <asp:ListItem>select..</asp:ListItem>
                            <asp:ListItem>&#2311;&#2306;&#2342;&#2380;&#2352; </asp:ListItem>
                            <asp:ListItem>&#2349;&#2379;&#2346;&#2366;&#2354;  </asp:ListItem>
                            <asp:ListItem>&#2357;&#2367;&#2342;&#2367;&#2358;&#2366;  </asp:ListItem>
                            <asp:ListItem>&#2352;&#2368;&#2357;&#2366;  </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="ddlMedum" runat="server" CssClass="form-select reqirerd"
                            OnSelectedIndexChanged="ddlMedum_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label>माध्यम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlClass" runat="server" CssClass="form-select"
                            AutoPostBack="True" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged"
                            TabIndex="4">
                            <asp:ListItem>All</asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2407; </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2408;  </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2409; </asp:ListItem>
                            <asp:ListItem>&#2325;&#2325;&#2381;&#2359;&#2366; &#2410;  </asp:ListItem>
                        </asp:DropDownList>
                        <label>कक्षा</label>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="gvProjectMaster" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-bordered table-hover" OnPageIndexChanging="gvProjectMaster_PageIndexChanging"
                        OnRowCommand="gvProjectMaster_RowCommand" OnRowDataBound="gvProjectMaster_RowDataBound"
                        OnSelectedIndexChanged="gvProjectMaster_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="क्रमांक">
                                <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="TitleHindi_V"
                                HeaderText="शीर्षक">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cLASSDET_V" HeaderText="कक्षा">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="DepoName_V" HeaderText="&#2337;&#2367;&#2346;&#2379; / Depot" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Pages_n" HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="BookYojna" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Alloted Scheme">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="BookSamanya" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Alloted General">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="noofbooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Total Alloted ">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                        </Columns>
                        <PagerStyle CssClass="pagination-ys" />
                    </asp:GridView>
                </div>
                <div class="col-md-12">
                    <asp:Button ID="ButPapCal" runat="server"
                        Text="पेपर का आंकलन"
                        OnClick="ButPapCal_Click" CssClass="btn btn-submit" />
                </div>
                <div class="col-md-12">
                    <asp:GridView ID="gvPapCalculation" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="table table-bordered table-hover" OnPageIndexChanging="gvProjectMaster_PageIndexChanging"
                        OnRowCommand="gvProjectMaster_RowCommand" OnRowDataBound="gvProjectMaster_RowDataBound"
                        OnSelectedIndexChanged="gvProjectMaster_SelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                <ItemTemplate><%# Container.DataItemIndex+1 %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TitleHindi_V"
                                HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; / Title">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cLASSDET_V" HeaderText="&#2325;&#2325;&#2381;&#2359;&#2366; / Class">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="deponame_v" HeaderText="&#2337;&#2367;&#2346;&#2379; / Depot Name">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Pages_n" HeaderText="&#2346;&#2375;&#2332;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No of Pages ">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="noofBookYojna" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2351;&#2379;&#2332;&#2344;&#2366; / Alloted Scheme">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="noofBookSamana" HeaderText="&#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351; / Alloted General">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="totnoofbooks" HeaderText="&#2325;&#2369;&#2354; &#2310;&#2357;&#2306;&#2335;&#2344; / Total Allotment">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>

                            <asp:BoundField DataField="qty_pripaper" HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2346;&#2375;&#2346;&#2352; (&#2335;&#2344; &#2350;&#2375; ) / Printing Paper (in Ton)">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="qty_Covpaper" HeaderText="&#2354;&#2327;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2325;&#2357;&#2352; &#2346;&#2375;&#2346;&#2352; (&#2358;&#2368;&#2335; &#2350;&#2375; ) / Cover Paper (in Sheet)" DataFormatString="{0:0}">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>




                        </Columns>
                        <HeaderStyle CssClass="HeaderStyle" />
                        <EditRowStyle CssClass="RowStyle" />
                        <AlternatingRowStyle CssClass="AltRowStyle" />
                    </asp:GridView>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="सुरक्षित करे"
                        CssClass="btn btn-submit" OnClick="Button1_Click" OnClientClick="return SaveData();"
                        Visible="False" />
                </div>
            </div>
        </div>
    </div>

    <script>
        function SaveData() {
            var item = document.getElementById("ContentPlaceHolder1_gridDetails").getElementsByTagName("input");
            var strdata = '';
            var check = 0;
            var arr = {};
            for (var i = 0; i <= item.length - 1; i++) {

                if (item[i].value != "" && item[i].getAttribute('type') == 'text') {
                    strdata = strdata + "#" + item[i].value;
                }
                if (i == item.length - 1) {
                    check = 1;

                }
            }
            if (check == 1) {
                DistributionService.SaveData(document.getElementById("ContentPlaceHolder1_DDlDemandType").value, document.getElementById("ContentPlaceHolder1_DdlACYear").value, document.getElementById("ContentPlaceHolder1_DdlDepot").value, document.getElementById("ContentPlaceHolder1_DdlDistrict").value, document.getElementById("ContentPlaceHolder1_DdlScheme").value, document.getElementById("ContentPlaceHolder1_DdlClass").value, strdata, succ, fail);
            }
            return false;
        }
        function succ(obj) {
            var item = document.getElementById("ContentPlaceHolder1_gridDetails").getElementsByTagName("input");
            alert(obj);
            for (var i = 0; i <= item.length - 1; i++) {

                if (item[i].value != "" && item[i].getAttribute('type') == 'text') { item[i].value = ""; }
            }
            return false;
        }
        function fail(obj) {

            alert(obj);
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>

