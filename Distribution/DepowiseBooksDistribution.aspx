<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DepowiseBooksDistribution.aspx.cs" Inherits="Distribution_DistributionOrderReport" Title="Distribution Order Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <script>
                function CalculateBookNos(obj) {

                    // var lblCurntYearOpenBook = obj;
                    var lblNoOfBooks = document.getElementById(obj.id.replace("TxtBookNoFrom", "lblNoOfBooks"));
                    var lblBookNoTo = document.getElementById(obj.id.replace("TxtBookNoFrom", "lblBookNoTo"));

                    if (obj.value != "" && lblNoOfBooks.innerHTML != "" && parseInt(lblNoOfBooks.innerHTML) != 0) {
                        lblBookNoTo.value = parseInt(obj.value) + parseInt(lblNoOfBooks.innerHTML - 1);
                    }
                }

                function Redirect(obj) {
                    var TxtBundleNoFrom = document.getElementById(obj.id.replace("Viewbarcode", "TxtBundleNoFrom"));
                    var lblBundleNoTo = document.getElementById(obj.id.replace("Viewbarcode", "lblBundleNoTo"));
                    var TextBooksPerBundle = document.getElementById('<%=TextBooksPerBundle.ClientID %>');
                    var TxtBookNoFrom = document.getElementById(obj.id.replace("Viewbarcode", "TxtBookNoFrom"));
                    var lblDepoName_V1 = document.getElementById(obj.id.replace("Viewbarcode", "lblDepoName_V1"));

                    var DdlACYear = document.getElementById('<%= DdlACYear.ClientID %>');
                    var DdlTitle = document.getElementById('<%= DdlTitle.ClientID %>');
                    var DdlPrinter = document.getElementById('<%= DdlPrinter.ClientID %>');
                    var DdlBookType = document.getElementById('<%= DdlBookType.ClientID %>');

                    var ACYear = DdlACYear.options[document.getElementById('<%= DdlACYear.ClientID %>').selectedIndex].text;
                    var Title = DdlTitle.options[document.getElementById('<%= DdlTitle.ClientID %>').selectedIndex].text;
                    var Printer = DdlPrinter.options[document.getElementById('<%= DdlPrinter.ClientID %>').selectedIndex].text;
                    var BookType = DdlBookType.options[document.getElementById('<%= DdlBookType.ClientID %>').selectedIndex].text;

                    window.open('barCode.aspx?ACYear=' + ACYear + '&Bookstart=' + TxtBookNoFrom.value + '&DepoName=' + lblDepoName_V1.value + '&BookType=' + BookType + '&TxtBundleNoFrom=' + TxtBundleNoFrom.value + "&lblBundleNoTo=" + lblBundleNoTo.value + "&Title=" + Title + "&Printer=" + Printer + "&Cnt=" + TextBooksPerBundle.value);

                    return false;

                }
                function CalculateBundleNos(obj) {

                    // var lblCurntYearOpenBook = obj;
                    var lblTotalBundles = document.getElementById(obj.id.replace("TxtBundleNoFrom", "lblTotalBundles"));
                    var lblBundleNoTo = document.getElementById(obj.id.replace("TxtBundleNoFrom", "lblBundleNoTo"));

                    if (obj.value != "" && lblTotalBundles.innerHTML != "" && parseInt(lblTotalBundles.innerHTML) != 0) {

                        lblBundleNoTo.value = parseInt(obj.value) + parseInt(lblTotalBundles.innerHTML - 1);
                    }

                }
                function CalBund() {

                    document.getElementById('<%=TextBooksPerBundle.ClientID%>').value = parseFloat(document.getElementById('<%=TxtBooksPerGaddi.ClientID%>').value) * 4;
                }

            </script>
            <div class="card">
                <div class="card-body">
                    <div class="card-header">
                        <h2>शिक्षा सत्र <b>
                            <asp:Label ID="LblFyYear" runat="server"></asp:Label></b> के लिए मुद्रको को आवंटित पाठ्यपुस्तकों का डिपोवार आवंटन</h2>
                    </div>
                    <div class="row g-3">
                        <div class="col-md-12">
                            <asp:Panel class="alert alert-info" runat="server" ID="mainDiv" Style="display: none;">
                                <asp:Label ID="lblmsg" class="notification" runat="server">
                                </asp:Label>
                            </asp:Panel>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select"
                                    OnSelectedIndexChanged="DdlACYear_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <label id="Label7" runat="server">शिक्षा सत्र </label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox runat="server" ID="TxtOrderNO" CssClass="form-control reqirerd"></asp:TextBox>
                                <label id="Label8" runat="server">आदेश क्र.</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:TextBox runat="server" ID="TxtOrderDate" CssClass="form-control reqirerd"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalTxtOrderDate" runat="server" Format="dd/MM/yyyy" TargetControlID="TxtOrderDate">
                                </cc1:CalendarExtender>
                                <label id="Label9" runat="server">आदेश दिनांक</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlGroup" runat="server"  CssClass="form-select" AutoPostBack="true"
                                    OnSelectedIndexChanged="DdlGroup_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label id="Label10" runat="server">ग्रुप चुने</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DdlBookType" CssClass="form-select">
                                    <asp:ListItem Text="योजना" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="सामान्य" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                                <label id="Label11" runat="server">पुस्तक का प्रकार</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList ID="DdlClass" runat="server"  CssClass="form-select"
                                    AutoPostBack="True" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                                <label id="Label12" runat="server">कक्षा</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DdlTitle"  CssClass="form-select"
                                    OnSelectedIndexChanged="DdlTitle_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <label id="Label13" runat="server">पुस्तक का नाम</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                <asp:DropDownList runat="server" ID="DdlPrinter" CssClass="form-select">
                                </asp:DropDownList>
                                <label id="Label1" runat="server">मुद्रक का नाम</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                 <asp:TextBox MaxLength="5" ID="TxtBooksPerGaddi" onblur="CalBund();" CssClass="reqirerd form-control" runat="server" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                <label id="Label2" runat="server">प्रति गड्डी पुस्तक संख्या</label>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-floating">
                                 <asp:TextBox MaxLength="5" ID="TextBooksPerBundle" CssClass="reqirerd form-control" runat="server" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                <label id="Label3" runat="server">प्रति बंडल पुस्तक संख्या</label>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="BtnGenerate" runat="server" CssClass="btn btn-primary" OnClick="Button2_Click" OnClientClick="javascript:return ValidateAllTextForm();" Text="वितरण निर्देश जारी करे" />
                        </div>
                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="GrdVitranNirdesh" CssClass="table table-bordereds hastable " AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <tr>
                                                    <th rowspan="3" align="center">&#2325;&#2381;&#2352;&#2406; / Sr. No.
                                                    </th>
                                                    <th rowspan="3" align="center">डिपो का नाम/ Depot Name
                                                    </th>
                                                    <th rowspan="3" style="width: 80Px;" align="center">&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Depotwise Alloted No. Of Book
                                                    </th>
                                                    <th colspan="2" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; / No. Details of Book
                                                    </th>
                                                    <th colspan="3">&#2337;&#2367;&#2346;&#2379;&#2348;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; /  Depotwise Bundles Details
                                                    </th>
                                                    <th rowspan="3">&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; 
                                                    </th>
                                                    <th rowspan="3">&#2352;&#2367;&#2350;&#2366;&#2352;&#2381;&#2325; / Remark
                                                    </th>
                                                    <th rowspan="3">&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; / Barcode
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2360;&#2375; / From
                                                    </th>

                                                    <th rowspan="2">&#2325;&#2361;&#2366;&#2305; &#2340;&#2325; / To
                                                    </th>
                                                    <th rowspan="2">&#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / No. Of Bundle 
                                                    </th>
                                                    <th colspan="2">&#2348;&#2306;&#2337;&#2354; &#2344;&#2350;&#2381;&#2348;&#2352; / Bundle No.
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <th>&#2325;&#2361;&#2366;&#2305; &#2360;&#2375; / From
                                                    </th>
                                                    <th>&#2325;&#2361;&#2366;&#2305; &#2340;&#2325; / To
                                                    </th>
                                                </tr>
                                            </HeaderTemplate>

                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.DataItemIndex+1 %>.
                                                        <asp:CheckBox runat="server" ID="chk1"></asp:CheckBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="lblDepoName_V1" runat="server" Text='<%#Eval("DepoName_V")%>' Enabled="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoOfBooks" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                    </td>
                                                    <%--<td> <asp:Label  ID="lblBookNoFrom" runat="server" Text='<%#Eval("BookNoFrom")%>' ></asp:Label> </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="TxtBookNoFrom" MaxLength="10" Width="95px" onblur="CalculateBookNos(this);" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="Server" Text='<%# Eval("BookNoFrom") %>'> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="lblBookNoTo" Enabled="false" runat="server" Text='<%# (Convert.ToInt32(Eval("BookNoFrom"))+ Convert.ToInt32(Eval("NoOfBooks"))-1) %>' Width="95px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTotalBundles" runat="server" Text='<%#Eval("TotalBundles")%>'></asp:Label>
                                                    </td>
                                                    <%-- <td> <asp:Label  ID="lblBundleNoFrom" runat="server" Text='<%#Eval("BundleNoFrom")%>' ></asp:Label> </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="TxtBundleNoFrom" MaxLength="10" Width="95px" onblur="CalculateBundleNos(this);" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="Server" Text='<%# Convert.ToInt32(Eval("bookType"))==1 ? Eval("BundleFromSamany"):Eval("BundleFromYojna") %>'> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="lblBundleNoTo" Enabled="false" runat="server" Width="95px" Text='<%# Convert.ToInt32(Eval("bookType"))==1 ? Eval("SamanyBundleto"):Eval("YojnaBundleto") %>'></asp:TextBox>
                                                    </td>
                                                    <td>


                                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="60px">
                                                            <asp:ListItem Value="1">&#2346;&#2381;&#2352;&#2341;&#2350; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                                                            <asp:ListItem Value="2">&#2342;&#2381;&#2357;&#2367;&#2340;&#2368;&#2351; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                                                            <asp:ListItem Value="3">&#2340;&#2371;&#2340;&#2368;&#2351; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                                                            <asp:ListItem Value="4">&#2309;&#2340;&#2367;&#2352;&#2367;&#2325;&#2381;&#2340; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358;  </asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TxtRemark" runat="server" MaxLength="150"></asp:TextBox>

                                                        <asp:HiddenField ID="HDNdepotId" runat="server" Value='<%# Eval("DepoTrno_I") %>' />

                                                    </td>
                                                    <td>

                                                        <%--<a href='barCode.aspx?Bookstart='+TxtBookNoFrom.Text+'>dfd</a>--%>
                                                        <asp:LinkButton Text="&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2346;&#2381;&#2352;&#2367;&#2306;&#2335; &#2325;&#2352;&#2375; / Print Barcode" ID="Viewbarcode" runat="server" OnClientClick="return Redirect(this);"></asp:LinkButton>
                                                    </td>
                                                </tr>

                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="Gvpaging" />
                                    <EmptyDataRowStyle CssClass="GvEmptyText" />
                                </asp:GridView>
                        </div>
                        <div class="col-md-12">
                            <asp:Button ID="Button1" Visible="false" runat="server" Text="&#2360;&#2350;&#2381;&#2348;&#2306;&#2343;&#2367;&#2340; &#2337;&#2367;&#2346;&#2379; &#2349;&#2375;&#2332;&#2375; &#2319;&#2357;&#2306; &#2350;&#2369;&#2342;&#2381;&#2352;&#2325; &#2325;&#2379; &#2346;&#2381;&#2352;&#2375;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375; / Sent Depot And Print " CssClass="btn btn-primary" OnClick="Button1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

