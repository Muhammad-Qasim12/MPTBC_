<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="DIS_002_DemadFromOpenMarket.aspx.cs" Inherits="Distrubution_DIS_002_DemadFromOpenMarket" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function CheckAll(rb) {
            var gv = document.getElementById("<%= ddlClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375;";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375;";
            }
        }
    </script>
    <asp:UpdatePanel ID="up1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="up1">
                <ProgressTemplate>
                    <div class="fade">
                    </div>
                    <div class="progress">
                        <img src="../images/loading.gif" alt="Loading..." width="110" height="110" />
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div class="card">
                <div class="card-body">
                    <div class="card-header">
                        <h2>डिपोवार खुले बाजार में विक्रय हेतु पुस्तकों की मांग का विवरण</h2>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-12">
                            <asp:Panel class="alert alert-info" runat="server" ID="mainDiv" Style="display: block;">
                                <asp:Label ID="lblmsg"
                                    Text="कृपया डिमांड देखने के लिए शिक्षा सत्र, डिपो , माध्यम तथा कक्षा चुने / Please select Academic Year , Depot , Medium and Class to view demand"
                                    class="notification" runat="server">                
                                </asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="ddlSessionYear" runat="server" CssClass="form-select reqirerd">
                                    </asp:DropDownList>
                                <label id="LblAcYear" runat="server">शिक्षा सत्र </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="ddlDepoMaster" runat="server" CssClass="form-select reqirerd" OnInit="ddlDepoMaster_Init" >
                                    </asp:DropDownList>
                                <label id="Label1" runat="server">शिक्षा सत्र </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="ddlMedum" runat="server" CssClass="form-select reqirerd" OnInit="ddlMedum_Init" >
                                    </asp:DropDownList>
                                <label>माध्यम चुने </label>
                            </div>
                        </div> 
                        <div class="col-md-4">
                            <div class="form-floating222">
                                <input type="checkbox" id="chkSelect" value="सभी चुने " name="सभी चुने " onclick="CheckAll(this);" />
                                <asp:CheckBoxList ID="ddlClass" OnInit="ddlClass_Init" RepeatDirection="Horizontal" RepeatColumns="8" TextAlign="Left" runat="server">
                                </asp:CheckBoxList>
                                <label>कक्षा</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button Text="देखें" ID="BtnView" runat="server" CssClass="btn btn-primary" OnClick="ddlClass_SelectedIndexChanged" />
                        </div>
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="False" GridLines="None"
                                        CssClass="table table-bordered" EmptyDataText="Record Not Found." Width="100%">
                                        <Columns>
                                            <asp:TemplateField HeaderText=" ">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;
                                                                <br>
                                                                S.No.
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(1)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>.
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; 
                                                                <br>
                                                                Book Title
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(2)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblClassTrno_I" runat="server" Text='<%#Eval("ClassTrno_I") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblDepoTrno_I" runat="server" Text='<%#Eval("DepoTrno_I") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblMedium_I" runat="server" Text='<%#Eval("Medium_I") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblSession_v" runat="server" Text='<%#Eval("Session_v") %>' Visible="false"></asp:Label>
                                                    <%#Eval("TitleHindi_V")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" ">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2346;&#2367;&#2331;&#2354;&#2375; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2351; &#2325;&#2368; &#2327;&#2312; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;
                                                                <br>
                                                                No Of Books Sold In Last Session
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(3)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLastYearSaleBook" runat="server" Text='<%#Eval("LastYearSale") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" ">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2310;&#2327;&#2366;&#2350;&#2368; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2310;&#2306;&#2325;&#2354;&#2367;&#2340; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; 
                                                                <br>
                                                                Estimated Demand For Upcommimg Session
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(4)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCurntYearOpenBook" runat="server" Text='<%#Eval("CurntYarNeed") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--      <asp:TemplateField HeaderText="&#2351;&#2379;&#2332;&#2344;&#2366; &#2361;&#2375;&#2340;&#2369; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; ">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtPlanStock" runat="server" CssClass="txtbox"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2357;&#2352;&#2381;&#2340;&#2350;&#2366;&#2344; &#2360;&#2340;&#2381;&#2352; &#2350;&#2375;&#2306; &#2357;&#2367;&#2325;&#2381;&#2352;&#2368; &#2346;&#2358;&#2381;&#2330;&#2366;&#2340; &#2348;&#2330;&#2344;&#2375; &#2357;&#2366;&#2354;&#2366; &#2360;&#2306;&#2349;&#2366;&#2357;&#2367;&#2340; &#2360;&#2381;&#2335;&#2377;&#2325; 
                                                                <br>
                                                                Possible Stock In Current Session After Sales
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(5)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="txtOpenTentetiveStock" runat="server" Text='<%#Eval("OpnMrketStk") %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2310;&#2327;&#2366;&#2350;&#2368; &#2360;&#2340;&#2381;&#2352; &#2361;&#2375;&#2340;&#2369; &#2358;&#2369;&#2342;&#2381;&#2343; &#2310;&#2357;&#2358;&#2381;&#2351;&#2325;&#2340;&#2366; 
                                                                <br>
                                                                Net Demand For Upcomming Session
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(6)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtNetDemand" runat="server" CssClass="txtbox" MaxLength="10" Text='<%#Eval("CurntYarNeed") %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderTemplate>
                                                    <table>
                                                        <tr>
                                                            <td style="height: 70px;">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325;
                                                                <br>
                                                                Remark 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>(7)
                                                            </td>
                                                        </tr>

                                                    </table>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="txtbox" Text='<%#Eval("Remark_v") %>' MaxLength="200"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="btnSave" Visible="false" runat="server" CssClass="btn btn-primary" Text="सुरक्षित करे"
                                        OnClientClick="return ValidateAllTextForm();" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
