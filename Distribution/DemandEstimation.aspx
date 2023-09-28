<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="DemandEstimation.aspx.cs" Inherits="Distrubution_DemandEstimation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">

        function CheckAll(rb) {
            var gv = document.getElementById("<%= ChkClass.ClientID  %>");

            var rbs = gv.getElementsByTagName("input");

            var row = rb.parentNode.parentNode;

            for (var i = 0; i < rbs.length; i++) {
                if (rbs[i].type == "checkbox") {
                    rbs[i].checked = document.getElementById('chkSelect').checked;
                }
            }
            if (document.getElementById('chkSelect').checked == true) {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2361;&#2335;&#2366;&#2351;&#2375; / Remove All";
            }
            else {
                document.getElementById('Name').innerHTML = "&#2360;&#2349;&#2368; &#2330;&#2369;&#2344;&#2375; / Select All";
            }
            // alert(document.getElementById('Name').innerHTML);
        }

    </script>
    <script type="text/javascript">
        function Calculation() {
            var grid = document.getElementById("<%= GrdBooksMaster.ClientID%>");
            for (var i = 0; i < grid.rows.length - 1; i++) {
                var txtAmountReceive = $("input[id*=TxtDemandScheme]")
                if (txtAmountReceive[i].value != '') {
                    alert(txtAmountReceive[i].value);
                }
            }
        }
    </script>

    <div class="card">
        <div class="card-body">
            <div class="card-header">
                <h2>पाठ्य पुस्तकों की आवश्यकता का आंकलन</h2>
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
                        <asp:DropDownList ID="DdlACYear" runat="server" CssClass="form-select">
                        </asp:DropDownList>
                        <label id="Label3" runat="server">शिक्षा सत्र </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="form-select" OnSelectedIndexChanged="DDlDemandType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <label id="Label4" runat="server">मांग का प्रकार </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlDepot" runat="server" CssClass="form-select"></asp:DropDownList>
                        <label id="Label5" runat="server">डिपो</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:DropDownList ID="DdlMedium" runat="server" CssClass="form-select"></asp:DropDownList>
                        <label id="Label6" runat="server">माध्यम</label>
                    </div>
                </div>
                <div class="col-md-4">
                    <label>कक्षा</label>
                    <table class="table">
                        <tr>
                            <td>
                                <label id="Name">सभी चुने</label>
                                <input type="checkbox" id="chkSelect" value="सभी चुने" name="सभी चुने" onclick="CheckAll(this);" />
                                <asp:CheckBoxList ID="ChkClass" RepeatDirection="Horizontal" RepeatColumns="12" TextAlign="Left" runat="server">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="300px">
                            <asp:ListItem Selected="True" Value="3">सभी चुने</asp:ListItem>
                            <asp:ListItem Value="1">परिवर्तित </asp:ListItem>
                            <asp:ListItem Value="2">अपरिवर्तित </asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control">100</asp:TextBox>
                        <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                        </asp:RadioButtonList>
                        <label>योजना की डिमांड काप्रतिशत </label>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="RadioButtonList3" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">स्टॉक के साथ</asp:ListItem>
                            <asp:ListItem Value="0">बिना स्टॉक के </asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="form-floating">
                        <asp:RadioButtonList ID="RadioButtonList4" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1" Selected="True">सामान्य के साथ  </asp:ListItem>
                            <asp:ListItem Value="0">बिना सामान्य के </asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="col-md-12">
                    <asp:Button Text="देखें" ID="BtnView" runat="server" CssClass="btn btn-primary" OnClick="DdlClass_SelectedIndexChanged" />
                </div>
                <div class="col-md-12">
                    <div class="text-right">
                        <asp:Button ID="btnExport" runat="server" Text="Export to Excel" CssClass="btn btn-secondary" OnClick="btnExport_Click" />
                    </div>
                    <asp:Panel ID="Panel1" runat="server">
                        <div id="ExportDiv" runat="server" class="table-responsive">
                            <asp:GridView ID="GrdBooksMaster" runat="server" AutoGenerateColumns="false" GridLines="None"
                                CssClass="table table-bordereds" EmptyDataText="Record Not Found." Width="100%" OnRowDataBound="GrdBooksMaster_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="क्रमांक">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="पुस्तक का नाम">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTitleID_I" runat="server" Text='<%#Eval("TitleID_I") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblDepoID" runat="server" Text='<%#Eval("DepoID") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblAcYearId" runat="server" Text='<%#Eval("AcYearId") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblMedium_I" runat="server" Text='<%#Eval("Medium_I") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblDemandTypeID" runat="server" Text='<%#Eval("DemandTypeID") %>' Visible="false"></asp:Label>

                                            <asp:Label ID="lblTitleName" runat="server" Text='<%#Eval("TitleHindi_V")%>'></asp:Label>
                                            <asp:HiddenField ID="HiddenField3" runat="server" Value='<%#Eval("Dtypea") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            योजना हेतु वास्तविक मांग
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="TxtDemandScheme1" runat="server" Width="60px" Text='<%# Eval("SchemeOrDemand") %>' Enabled="false" onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            सामान्य हेतु वास्तविक मांग
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="TxtDemandScheme2" runat="server" Width="60px" Text='<%# Eval("GernalExtrDemand") %>' Enabled="false" onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10"></asp:Label>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            आवश्यकता की पूर्ति योजना
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtDemandScheme" runat="server" Width="60px" Text='<%# Eval("Demand_Scheme") %>' Enabled="false" onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10"></asp:TextBox>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            आवश्यकता की पूर्ति सामान्य
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtDemandOpnMkt" runat="server" Width="60px" Text='<%# Eval("OpenMtkDemand") %>' onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            कुल मांग <br />(C=A + B)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtTotDemand" runat="server" Width="60px" Text='<%# Eval("TotalDemand") %>' onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            योजना का स्टॉक <br />(D)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtYojnaStock" runat="server" CssClass="txtbox" MaxLength="10" Width="60px" Text='<%# Eval("YojnaStock") %>' onkeypress='javascript:tbx_fnInteger(event, this);' Enabled="false"
                                                onblur="Calculation(this.value)"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            सामान्य का स्टॉक <br />(E)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="TxtOpenStock" runat="server" Width="60px" Text='<%# Eval("OpenMktStock") %>' onkeypress='javascript:tbx_fnInteger(event, this);' MaxLength="10" Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            कुल स्टॉक <br />(F=D+E)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtTotStock" runat="server" CssClass="txtbox" MaxLength="10" Width="60px" Text='<%# Eval("TotalStock") %>' onkeypress='javascript:tbx_fnInteger(event, this);' Enabled="false"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            मुद्रण की जानेवाली संख्या (योजना) <br />(G=A-D)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNetDemandScheme" runat="server" CssClass="txtbox" MaxLength="10" Width="60px" Text='<%#(Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))  : 0 %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            मुद्रण की जानेवाली संख्या (सामान्य) <br />(H=B-E)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNetDemandOpen" runat="server" CssClass="txtbox" MaxLength="10" Width="60px" Text='<%#(Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))  : 0 %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            नेट पुस्तकों की मांग<br />(I=G+H)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNetDemand" runat="server" CssClass="txtbox" MaxLength="10" Width="60px" Text='<%#((Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))  : 0)+((Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))> 0 ? (Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))  : 0) %>' onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            आवश्यकता से अधिक (योजना)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdYojna" runat="server" Value='<%#(Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))< 0 ? (Convert.ToInt32(Eval("YojnaStock"))-Convert.ToInt32(Eval("NetDemandYojna")))  : 0 %>' />
                                            <%--<asp:TextBox ID="txtDamnad1" runat="server" CssClass="txtbox" MaxLength="10" Width="60px" Text='' onkeypress='javascript:tbx_fnInteger(event, this);' ></asp:TextBox>--%>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButtonOpen" Visible='<%#(Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))< 0 ? true : false %>'><%#(Convert.ToInt32(Eval("NetDemandYojna"))-Convert.ToInt32(Eval("YojnaStock")))< 0 ? (Convert.ToInt32(Eval("YojnaStock"))-Convert.ToInt32(Eval("NetDemandYojna")))  : 0 %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderTemplate>
                                            आवश्यकता से अधिक (सामान्य)
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:HiddenField ID="hdSamany" runat="server" Value='<%#(Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))< 0 ? (Convert.ToInt32(Eval("OpenMktStock"))-Convert.ToInt32(Eval("NetDemandOpnMkt")))  : 0 %>' />
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButtonOpen2" Visible='<%#(Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))< 0 ? true  :false %>'><%#(Convert.ToInt32(Eval("NetDemandOpnMkt"))-Convert.ToInt32(Eval("OpenMktStock")))< 0 ? (Convert.ToInt32(Eval("OpenMktStock"))-Convert.ToInt32(Eval("NetDemandOpnMkt")))  : 0 %></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlAction" runat="server" Visible="false">
                                                <asp:ListItem Value="1">Add</asp:ListItem>
                                                <asp:ListItem Value="2">Same</asp:ListItem>
                                            </asp:DropDownList>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                                <PagerStyle CssClass="Gvpaging" />
                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                            </asp:GridView>
                        </div>
                    </asp:Panel>
                    <div class="mt-2">
                        <asp:Button ID="btnSave" Visible="false" runat="server" CssClass="btn btn-primary" Text="सुरक्षित करे"
                            OnClientClick="return ValidateAllTextForm();" OnClick="btnSave_Click" />

                        &nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-secondary" Text="Print" OnClick="Button3_Click" />
                    </div>
                    <div style="margin-left: 80px;">
                        <asp:HiddenField ID="HiddenField1" runat="server" />
                        <asp:HiddenField ID="HiddenField2" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server">
    </div>
    <div id="Messages" style="display: none;" class="popupnew1" runat="server">
        <asp:Button ID="Button1" CssClass="btn" runat="server" OnClick="Button1Close" Text="&#2348;&#2306;&#2342; &#2325;&#2352;&#2375;&#2306; " />
        <asp:Button ID="Button2" CssClass="btn" runat="server" OnClick="Button2Save" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306;   " />
        <asp:Button ID="Button4" runat="server" Text="Print" CssClass="btn" OnClientClick="return PrintPanel1();" />

        <asp:Panel ID="Panel2" runat="server" Width="100%" Height="100%">
            <table width="80%" class="tab">
                <tr>
                    <td>&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:Label ID="lblDepoName" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td>&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                    <td>
                        <asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></td>
                </tr>

                <tr>
                    <td>&#2310;&#2357;&#2358;&#2381;&#2325;&#2340;&#2366; &#2360;&#2375; &#2309;&#2343;&#2367;&#2325;  </td>
                    <td>
                        <asp:Label ID="lblTotaBook" runat="server" Text="Label"></asp:Label>
                    <td>&#2346;&#2381;&#2352;&#2325;&#2366;&#2352; </td>
                    <td>
                        <asp:Label ID="lblType" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                    <td>&#2358;&#2375;&#2359; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;</td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="4">

                        <asp:Panel ID="Panel3" runat="server" Width="850px" Height="600px" ScrollBars="Both">
                            <asp:GridView ID="GridView1" runat="server" CssClass="tab01" AutoGenerateColumns="false" OnRowDeleting="GridView1_RowDeleting" DataKeyNames="id">
                                <Columns>

                                    <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>.
                                                    <asp:HiddenField ID="hdTitleId" runat="server" Value='<%# Eval("TitleId") %>' />
                                            <asp:HiddenField ID="hdDepoID" runat="server" Value='<%# Eval("DepoID") %>' />
                                            <asp:HiddenField ID="hdbookType" runat="server" Value='<%# Eval("bookType") %>' />

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; ">
                                        <ItemTemplate>
                                            <%# Eval("DepoName_V") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" &#2350;&#2366;&#2306;&#2327;">
                                        <ItemTemplate>
                                            <%# Eval("bookType").ToString()=="1" ? Eval("NetDemandYojna")  : Eval("NetDemandOpnMkt") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2360;&#2381;&#2335;&#2377;&#2325;  ">
                                        <ItemTemplate>
                                            <%# Eval("bookType").ToString()=="1" ? Eval("YojanaBook")  : Eval("samanyBook") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2381;&#2352;&#2367;&#2306;&#2335;&#2367;&#2306;&#2327; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;  ">
                                        <ItemTemplate>
                                            <%#Convert.ToInt32( (Eval("bookType").ToString()=="1" ? Eval("NetDemandYojna")  : Eval("NetDemandOpnMkt")))-Convert.ToInt32((Eval("bookType").ToString()=="1" ? Eval("YojanaBook")  : Eval("samanyBook"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; &#2337;&#2366;&#2354;&#2375;  ">
                                        <ItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="txtbox" Text='<%# Eval("DistributeBook") %>' AutoPostBack="true" OnTextChanged="txtbox1"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowDeleteButton="True" HeaderText="&#2337;&#2366;&#2335;&#2366; &#2361;&#2335;&#2366;&#2351;&#2375; " />
                                </Columns>

                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
                </td>
                       
                    
            </table>
        </asp:Panel>

    </div>
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
    <script type="text/javascript">
        function PrintPanel1() {
            var panel = document.getElementById("<%=Panel2.ClientID %>");

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


