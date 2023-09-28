<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Menu.ascx.vb" Inherits="WebYojna.UserControls_Menu" %>

<script type="text/javascript" src="../css/ChangeIcon.js"></script>

<script src="../css/HelperScript.js" type="text/javascript"></script>

<link href="../css/webyojna.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../css/jquery.js"></script>

<script type="text/javascript" src="../css/menu.js"></script>

<table id="MainTable" width="100%" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="black_color" align="center">
            <table width="100%" align="center" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="250">
                        <table width="400" align="right" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="111" align="center" valign="middle" class="ULB_pan_frm_top_menu">
                                    <asp:RadioButton ID="rbBusinessModule" Visible="false" AutoPostBack="true" Style="color: White;"
                                        CssClass="rb" runat="server" Text="बिजनिस माड्युल में जाए " />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton ID="hlHome" runat="server"> <%=IIf(Me.Session("Choice") = 1, "HomePage", "होमपेज ")%> |</asp:LinkButton>
                                    <asp:LinkButton ID="hlLogoff" runat="server"> <%=IIf(Me.Session("Choice") = 1, "Logout", "लॉगआउट")%></asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="Menu_Color">
            <div id="myslidemenu" class="jqueryslidemenu2">
                <ul>
                    <li>
                        <asp:LinkButton ID="lnk1002" runat="server" Visible="false" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "Master", "मास्टर")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1271" runat="server" Visible="false" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Finance Master", "वित्तीय मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1285" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Bank", "बैंक")%></asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1267" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Bank Master", "बैंक मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1266" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Bank Branch Master", "बैंक शाखा मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1270" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Account Master", "खाता मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1004" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Import Bank Data", "आयात बैंक डाटा")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1005" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Opening Balance", "प्रारंभिक शेष")%></asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1006" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Cash Opening", "प्रारंभिक रोकड शेष")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1312" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Agency Opening", "एजेंसी का प्रारंभिक शेष")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1760" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Ledger Opening", "लेजर का प्रारंभिक शेष")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1314" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Agency Opening Balance Import", "एजेंसी का प्रारंभिक शेष आयात")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1141" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                                        <%=IIf(Me.Session("Choice") = 1, "Fixed Assets", "स्थाई संपत्ति")%></asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1322" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Configuration Setting", "कॉन्फीगरेशन सेटिंग")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1127" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Block Master", "ब्लॉक मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1126" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Depreciation Master", "ह्रास   मास्टर ")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1310" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Branch Master", "शाखा मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1286" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Agency Master", "एजेंसी मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1797" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "District Master", "जिला मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1798" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Block Master", "जनपद मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1799" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Gram Panchayat Master", "ग्राम पंचायत मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1242" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Scheme Master", "स्कीम मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1756" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Scheme Coverage Master", "स्कीम कवरेज मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1315" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Ledger Master", "लेजर मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1118" runat="server" Visible="false" Enabled="true"><%=IIf(Me.Session("Choice") = 1, "Unit Master", "यूनिट मास्टर ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1308" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Category Master", "श्रेणी मास्टर ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1771" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Year Wise Category & Scheme Combination", "वर्ष वार स्कीम तथा केटेगरी कॉम्बिनेशन ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1087" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Group Master", "ग्रुप मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1320" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Agency Type", "एजेंसी का प्रकार")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1309" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Ledger Type", "लेजर टाईप")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1311" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Register Cheque Book", "रजिस्टर चैक बुक")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1809" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                                        <%=IIf(Me.Session("Choice") = 1, "Configuration", "कॉन्फीगरेशन")%></asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1265" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Voucher Configuration ", "वाउचर कॉन्फीगरेशन ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1653" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Disbursement Ledger Configuration", "सहायता लेजर  कॉन्फीगरेशन ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1752" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Input Subsidy Configuration", "Input Subsidy Configuration")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1758" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Report Configuration", "रिपोर्ट  कॉन्फीगरेशन")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1810" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Advance Ledger configuration", "अग्रिम लेजर  कॉन्फीगरेशन")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1814" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "General Bill Configuration", "सामान्य बिल  कॉन्फीगरेशन")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1815" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Fixed Deposit Configuration", "सावधि जमा  कॉन्फीगरेशन")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1316" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Agency Import", "एजेंसी आयात")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1800" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Type & Nature Selection Under Scheme", "योजना अंतर्गत कार्य का प्रकार और प्रकृति का चुनाव")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1284" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Budget Master", "बजट मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1047" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Budget Configuration", "बजट कॉन्फीगरेशन")%>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1291" runat="server" OnClientClick="javascript:return false;"
                                    Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "D M S", "डी एम एस ")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1207" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sam Form Fees Master", "सैम फोर्म शुल्क मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1171" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "DMS Configuration", "डी एम एस कॉन्फीगरेशन")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1226" runat="server" OnClientClick="javascript:return false;"
                                    Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "T D S Master", "टी डी एस मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1227" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "TDS Rate Master", "टी डी एस रेट मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1230" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "TDS Configuration", "टी डी एस कॉन्फीगरेशन")%>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1811" runat="server" OnClientClick="javascript:return false;"
                                    Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Receipt Management", "रसीद प्रबंधन  ")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1812" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Receipt Configuration", "रसीद कॉन्फीगरेशन")%>
                                        </asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1272" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "HR Master", "एच आर मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1496" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Establishment", "स्थापना")%></asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1273" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grade Master", "ग्रेड मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1427" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Post Master", "पद मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1313" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Designation Master", "पदनाम मास्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1009" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Department ", "विभाग  ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1010" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Division ", "शाखा ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1450" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Leave Master ", "अवकाश मास्टर  ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1431" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Annual Calendar", "वार्षिक कैलेंडर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1451" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Leave Credit  ", "अवकाश भुगतान    ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1448" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Recovery And Penalty ", "वसूली & जुर्माना ")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1088" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Employee Master", "कर्मचारी मास्टर ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1287" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Configuration", "कॉन्फीगरेशन")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1497" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Pay Bill", "पे बिल ")%></asp:LinkButton>
                                        <ul>
                                            <%--<li>
                                            <asp:LinkButton ID="lnk1274" runat="server" PostBackUrl="HR_Master/frm_GradeValueMaster.aspx"
                                                Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grade Value", "ग्रेड वैल्यू ")%></asp:LinkButton>
                                        </li>--%>
                                            <li>
                                                <asp:LinkButton ID="lnk1276" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Pay Bill Header", "वेतन शीर्षक")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1275" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Default Payment & Deductions", "सामान्य भुगतान एवं कटौती")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1214" runat="server" Visible="false" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "Project Master", "प्रोजेक्ट मास्टर")%></asp:LinkButton>
                                <ul style="overflow: auto; height: 250px; width: 220px;">
                                    <li>
                                        <asp:LinkButton ID="lnk1211" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Consumption Item Master", "खपत आइटम मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1206" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Consumption Rate Master", "खपत दर मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1119" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Rate Analysis", "दर विश्लेषण ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1213" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "SOR Configuration", "एस ओ आर कॉन्फीगरेशन")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1208" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sor Activity", "एसओआर एक्टीविटी")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1209" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sor Type", "एसओआर का प्रकार")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1212" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sor Item", "एसओआर आइटम")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1298" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sor Rate", "एसओआर दर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1210" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Type", "कार्य का प्रकार")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1120" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Royalty Rate", "रॉयल्टी दर ")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1122" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "ULB Master", "यू एल बी मास्टर")%></asp:LinkButton>
                                <ul style="overflow: auto; height: 200px; width: 220px;">
                                    <li>
                                        <asp:LinkButton ID="lnk1292" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Tax Payer's Master", "कर भुगतानकर्ता मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1294" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "ULB Configuration", "यू एल बी कॉन्फीगरेशन")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1244" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Receipt Configuration ", "प्राप्ति कॉन्फीगरेशन ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1123" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Circle Master", "सर्किल मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1124" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Circle Area Master", "सर्किल एरिया मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1125" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Tax Master", "टैक्स मास्टर ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1239" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Circle", "सर्किल")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1240" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Import Tax Payer's", "कर भुगतानकर्ता आयात करें")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1241" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Import Tax Data", " कर डाटा आयात करें")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <%--<li>
                                <asp:LinkButton ID="lnk1290" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Inventory Master", "इन्वेन्ट्री मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>  commented code by uttam aspx page and vb page (03/08/2013)task no(1666)
                                        <asp:LinkButton ID="lnk1152" runat="server" PostBackUrl="~/Inventory/ItemGroup.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Item Group", "आइटम ग्रुप")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1153" runat="server" PostBackUrl="~/Inventory/ItemType.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Item Type", "आइटम टाईप")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1154" runat="server" PostBackUrl="~/Inventory/ItemMaster.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Item Master", "आइटम मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1155" runat="server" PostBackUrl="~/Inventory/PriceList.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Price List", "प्राइस लिस्ट")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>--%>
                            <li>
                                <asp:LinkButton ID="lnk1400" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Material Master", "मटेरियल  मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1403" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Item Group Master", "आइटम ग्रुप मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1404" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Item Master", "आइटम मास्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1405" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Supplier Master", "Supplier Master")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1406" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Supplier Rate Master", "Supplier Rate Master")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1188" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "ADV Master", "ADV Master")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1189" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Position Master", "Position Master")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1190" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Edition Master", "Edition Master")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1191" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Rate Master", "Rate Master")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1192" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Service Tax Master", "Service Tax Master")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1193" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Agency Master", "Agency Master")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1117" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "ADV Configuration", "ADV Configuration")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1500" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "E-pay", "ई- पे")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1501" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Vendor registration", "विक्रेता पंजीयन")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1502" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Verify and approve vendors", "विक्रेता का सत्यापन एवं मंजूरी")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1540" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Benificiary Registration", "हितग्राही पंजीयन ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1550" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "A/c Verification And Freezing", "खाता सत्यापन एवँ फ्रीज़िंग ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1509" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Bank Configuration", "बैंक कॉन्फीगरेशन ")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1008" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Functionary Rights", "फंक्शनरी राईटस")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk3505" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "WMS Master", "डब्ल्यू एम एस  मास्टर")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk3504" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Godown Master", "गोदाम मास्टर ")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnk1058" Visible="false" runat="server" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "Reports", "रिपोर्ट")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1744" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Master Data Report", "मास्टर डाटा रिपोर्ट ")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <%--Task No:(1365 link name changed)--%>
                                        <asp:LinkButton ID="lnk1745" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Bank Branch Master Report", "बैंक शाखा मास्टर रिपोर्ट ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <%--Task No:(1365 link name changed)--%>
                                        <asp:LinkButton ID="lnk1746" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Bank A/c Master Report", "बैंक खाता मास्टर रिपोर्ट ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1115" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Agency List Print", "एजेंसी सूची प्रिंट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1644" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Ledger List Print", "लेजर सूची प्रिंट   ")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1059" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Financial Report", "वित्तीय रिपोर्ट")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1305" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Annual Report", "बार्षिक रिपोर्ट")%> </asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1081" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Trial Balance", "तलपट (ट्रॉयल बैलेंस)")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1082" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Receipt & Payment Account", "प्राप्ति एंव भुगतान खाता")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1084" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Income & Expenditure Report", "आय  एवं व्यय  रिपोर्ट ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1085" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Balance Sheet", "बैलेंस-शीट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1086" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Utilization Certificate", "यूटिलाइजेशन प्रमाणपत्र")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1306" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Transaction Report", "लेनदेन रिपोर्ट")%> </asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1288" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Day Book Report", "डे-बुक रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1080" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cash Book Report", "कैश-बुक रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1083" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Ledger Reports", "लेजर रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1223" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Ledger Type Report", "लेजर टाईप रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1301" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "MIS Report", "एमआईएस  रिपोर्ट")%> </asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1302" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Annexure(VIII)", "परिशिष्ट (आठवीं)")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1303" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Annexure(XI)", "परिशिष्ट (ग्यारहवीं)")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1304" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Annexure(XII)", "परिशिष्ट (बारहवीं)")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1060" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Report on Financial Position", "वित्तीय स्थिती पर रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1061" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Financial Position", "वित्तीय स्थिती")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1116" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Assistance Disbursement", "रिप्रिंट सहायता राशि वितरण")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1635" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Subsidy Disbursement", "Reprint Subsidy Disbursement")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1639" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Subsidy Payment Report–MI", " सहायता राशि रिपोर्ट –एम आई ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1770" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Subsidy Payment Report–MI(New)", " सहायता राशि रिपोर्ट –एम आई (न्यू) ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1641" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Annual Action Plan", "वार्षिक कार्य योजना  ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1759" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Budget Progress Report", "बजट प्रगति रिपोर्ट  ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1772" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Pay bill Report", "वेतन पत्रक रिपोर्ट  ")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1307" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Subsidiary Report", "सहायक रिपोर्ट")%> </asp:LinkButton>
                                        <ul style="overflow: auto; height: 280px; width: 220px;">
                                            <li>
                                                <asp:LinkButton ID="lnk1023" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                            <%=IIf(Me.Session("Choice") = 1, "Register Immovable Assets", "अचल संपत्ति रजिस्टर ")%>
                                                </asp:LinkButton>
                                                <ul>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1024" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Building", "भवन")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1025" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Land", "भूमि")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1026" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Road, Street, Lane, Footpaths", "रोड स्ट्रीट लेन एवं फुटपाथ")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1027" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Bridges, Culverts, Flyovers, Subways, Causeways", "सेतु, पुलिया, फ्लाईओवर, सबवे")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1028" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Drains", "नालियां")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1029" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Water Works Distribution", "जल वितरण कार्य")%></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1030" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                            <%=IIf(Me.Session("Choice") = 1, "Register Movable Assets", "चल संपत्ति रजिस्टर")%>
                                                </asp:LinkButton>
                                                <ul>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1031" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Public Lighting", "सार्वजनिक प्रकाश व्यवस्था")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1032" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Lakes and Ponds", "झील और तालाब")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1033" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Capital Work-in-Progress", "प्रगतिरत पूंजीगत कार्य")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1034" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Plant and Machinery", "संयंत्र और मशीनें")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1035" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Vehicles", "वाहन")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1036" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Furniture and Fixtures", "फर्नीचर एवं फिक्चर्स")%></asp:LinkButton>
                                                    </li>
                                                    <li>
                                                        <asp:LinkButton ID="lnk1037" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Office Equipments", "कार्यालय उपकरण")%></asp:LinkButton>
                                                    </li>
                                                </ul>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1055" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Daily Collection Details Report ", "दैनिक संग्रह विवरण रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1056" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cheque Received Register Report", "चेक प्राप्ति पंजी रिपोर्ट")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1057" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cheque Dishonored Register ", "अस्वीकृत चेक पंजी")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1007" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cheque Payment Register ", "चैक भुगतान पंजी")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1481" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "AMC Register", "ए एम सी पंजी ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1482" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Fixed Deposit Register", "सावधि जमा रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1483" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Security Deposit(Inward) Register", "सुरक्षा निधि (प्राप्ति) रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1484" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Security Deposit(Outward) Register", "सुरक्षा निधि (भुगतान) रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1485" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "EMD(Inward) Register", "ई एम डी (प्राप्ति) रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1486" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "EMD(Outward) Register", "ई एम डी (भुगतान) रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1487" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Insurance Register", "बीमा रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1488" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Bank Gurantee Register", "बैंक गारंटी रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1489" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "TDS Deduction Register", "टी डी एस (कटौत्रा) रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1490" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "TDS (Advance tax Register)", "टी डी एस (अग्रिम) रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1491" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Service tax Register", "सेवा कर रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1492" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "EPF Register", "ई पी एफ रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1493" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "VAT Register", "वेट रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1902" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Printers FDR", "प्रिंटर एफ डी आर ")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1063" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                            <%=IIf(Me.Session("Choice") = 1, "Advance Report", "अग्रिम रिपोर्ट")%>
                                        </asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1064" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Advance To Staff ", "कर्मचारी को अग्रिम")%></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnk1065" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Advance To Other", "अन्य को अग्रिम")%></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnk1066" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Advance To Creditors", "लेनदार को अग्रिम")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1067" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sponsor Report", "प्रायोजक रिपोर्ट ")%></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnk1068" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Beneficiary Report", "हितग्राही रिपोर्ट")%></asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton ID="lnk1243" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Age Wise Advance Analysis", "आयु अनुसार अग्रिम की गणना")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1474" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Travelling And Advance Register", "यात्रा एवँ अग्रिम पंजी ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1475" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Grain Advance Register", "अनाज अग्रिम पंजी ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1476" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Festival Advance Register", "उत्सव  अग्रिम पंजी ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1477" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Medical Advance Register", "चिकित्सा  अग्रिम पंजी ")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <%--New Menu Links Add Task No:(1662)--%>
                                    <li>
                                        <asp:LinkButton ID="lnk1079" runat="server" Visible="false" OnClientClick="javascript:return false;">
                                            <%=IIf(Me.Session("Choice") = 1, "C & AG Reports", "सी एन्ड ऐ जी रिपोर्ट")%>
                                        </asp:LinkButton>
                                        <ul style="overflow: auto; height: 250px;">
                                            <li>
                                                <asp:LinkButton ID="lnk1038" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - I Receipt & Payment Account", "फाँरमेट - I प्राप्ति एंव भुगतान खाता")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1003" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - II Consolidated Abstract Register", "फाँरमेट - II कनसालिडेटेड एब्सटेक्ट रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1041" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - III Bank Reconciliation Register", "फाँरमेट - III बैंक समाधान रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1324" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - IV Statement of Receivable", "फाँरमेट - IV प्राप्ति विवरण")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1325" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - IV Statement of Payable", "फाँरमेट - IV भुगतान विवरण")%></asp:LinkButton>
                                            </li>
                                            <%--Removed lnk1326 & lnk1327 link as per task no 1563
                                                <li>
                                                    <asp:LinkButton ID="lnk1326" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - V Register Immovable Assets", "फाँरमेट - V अचल संपत्ति रजिस्टर ")%></asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="lnk1327" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - VI Register Movable Assets", "फाँरमेट - VI चल संपत्ति रजिस्टर")%></asp:LinkButton>
                                                </li>--%>
                                            <li>
                                                <%--  Open materialmanagement/rpt_stockregister.aspx according to Task No.398--%>
                                                <asp:LinkButton ID="lnk1328" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - VII Inventory Register", "फाँरमेट - VII इन्वेन्ट्री रजिस्टर")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1329" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Format - VIII Demand Collection & Balance Register", "फाँरमेट - VIII डिमांड संग्रह और बैलेंस रजिस्टर")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1747" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Assets Register", "संपत्ति रजिस्टर ")%> </asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1748" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Format - V Register Immovable Assets", "फाँरमेट - V अचल संपत्ति रजिस्टर")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1749" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Format - VI Register Movable Assets", "फाँरमेट - VI चल संपत्ति रजिस्टर")%> </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1762" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Externally Aided Project Report", "Externally Aided Project Report ")%> </asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1763" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "SOE-Form 1-B", "एस ओ ई फार्म 1- बी ")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1764" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "SOE-Form 1-C ", "एस ओ ई फार्म 1- सी ")%> </asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1765" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Abstract of summary sheet", "Abstract of summary sheet ")%> </asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1071" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Summary Report", "संक्षिप्त रिपोर्ट")%>
                                </asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1072" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Statement On Status of Cheque Receipt", "चेक प्राप्ति का स्थिति विवरण")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1073" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Form Gen-11", "फार्म जनरल-11")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1074" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Summary of daily Collection", "दैनिक संग्रहण की संक्षिप्त रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1075" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Summary Statement of Bill Raised", "जारी किये गये देयकों का संक्षिप्त विवरण")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1069" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Grant Receipt From State Report", "राज्य से प्राप्त अनुदान रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1070" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Grant Receipt from Center", "केन्द्र से प्राप्त अनुदान रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1076" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Work Report", "कार्य रिपोर्ट")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1077" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Plan, Budget and  Expenditure Report", "कार्य बजट व व्यय रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1078" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "WorkPlan Report", "कार्य योजना रिपोर्ट")%></asp:LinkButton></li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1283" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Budget Report", "बजट रिपोर्ट")%></asp:LinkButton>
                                <ul style="overflow: auto; height: 280px; width: 220px;">
                                    <li>
                                        <asp:LinkButton ID="lnk1249" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment List", "बजट आवंटन सूची")%></asp:LinkButton>
                                    </li>
                                    <%--<li>  Commented by uttam Accordion to joney sir(24/07/13)
                                        <asp:LinkButton ID="lnk1042" runat="server" PostBackUrl="~/BudgetAllotment.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment Report", "बजट आवंटन रिपोर्ट")%></asp:LinkButton>
                                    </li>--%>
                                    <li>
                                        <asp:LinkButton ID="lnk1323" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Fund Allotment Report", "फंड आवंटन रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1246" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment Summary", "बजट आवंटन सारांश")%>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1299" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Allotment & Expenditure Summary", "आवंटन एवं व्यय रिपोर्ट")%>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1045" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment and Expenditure Report", "बजट आवंटन एवं व्यय रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1767" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment and Expenditure Report(New)", "बजट आवंटन एवं व्यय रिपोर्ट (नया)")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1046" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Budget Estimate", "बजट अनुमान ")%>
                                        </asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1043" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Periodic Budget Expenditure Report", "बजट व्यय रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1044" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Quarterly Budget Expenditure Report", "त्रैमासिक बजट व्यय रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1640" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment Report", "बजट आबंटन रिपोर्ट ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1740" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "RKVY Report", "आर के व्ही वाय रिपोर्ट  ")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1092" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "HR Reports", "एच आर रिपोर्ट")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1094" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "EPF Challan  and EPF reports", "ईपीएफ चालान और ईपीएफ रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1097" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Retirement & Seniority list", "सेवानिवृत्ति और वरिष्ठता सूची")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1432" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Roster Report", "Roster Report")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1434" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Leave Register", "अवकाश रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1459" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Combined EPF Challan", "सामुहिक ई पी एफ चालान ")%></asp:LinkButton>
                                    </li>
                                    <%--  <li>
                                            <asp:LinkButton ID="lnk1901" Visible="false" runat="server" Enabled="True"  ><%=IIf(Me.Session("Choice") = 1, "GPF Challan", "जी पी एफ चालान ")%></asp:LinkButton>
                                        </li>--%>
                                    <li>
                                        <asp:LinkButton ID="lnk1438" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Attendance Report", "उपस्थिति रिपोर्ट")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1467" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Appointment Order", "नियुक्ति आदेश")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1553" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Anukampa Niyukti ", "अनुकम्पा नियुक्ति ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1950" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Annual Increment List ", "वार्षिक वृद्धि सूची ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1504" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Pay Bill Reports", "पे बिल रिपोर्ट")%></asp:LinkButton>
                                        <ul>
                                            <li>
                                                <asp:LinkButton ID="lnk1903" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "GIS/EBF Recovery Schedule", "जी आई एस/ एफ बी एफ कटौती अनुसूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1904" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "List of Professional Tax", "व्यवसायिक कर सूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1905" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "List of income Tax", "आयकर सूची ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1906" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "GPF Schedule", "जी पी एफ अनुसूची ")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1907" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Consolidated EPF Report", "मिश्रित ई पी एफ सूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1926" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Grain Advance Recovery Schedule", "अनाज अग्रिम कटौती अनुसूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1927" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Festival Advance Recovery Schedule", "त्यौहार अग्रिम कटौती अनुसूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1908" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Misc Advance Recovery Schedule", "विविध अग्रिम कटौती अनुसूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1928" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "House Rent Recovery Schedule", "मकान किराया कटौती अनुसूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1932" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Medical Advance Recovery Schedule", "चिकित्सा अग्रिम कटौती अनुसूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1929" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "List Of Lic Recovery", "बीमा कटौती की सूची")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1930" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "GPF Challan", "जी पी एफ चालान")%></asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lnk1931" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "GIS Challan", "जी आई एस चालान")%></asp:LinkButton>
                                            </li>
                                        </ul>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1552" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Establishment", "स्थापना")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1458" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Seniority list", "वरिष्ठता सूची (नया)")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1464" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Form Of Leave Account", "अवकाश खाता फार्म ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1495" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Post Information", "पदों की जानकारी")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1110" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                <%=IIf(Me.Session("Choice") = 1, "Project Reports", "प्रोजेक्ट रिपोर्ट ")%></asp:LinkButton>
                                <ul style="overflow: auto; height: 220px; width: 220px;">
                                    <li>
                                        <asp:LinkButton ID="lnk1111" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Contractor Wise Report", "कंट्रेक्टर वाइस रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <%--Change By Ravi on 23.08.2012 Task No 1098 for pas query string encoded form--%>
                                        <asp:LinkButton ID="lnk1112" runat="server" Visible="false" Enabled="true"><%=IIf(Me.Session("Choice") = 1, "Daily Chainage Wise Measurement Report", "दैनिक चेनेज वाइस माप रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <%--Change By Ravi on 23.08.2012 Task No 1098 for pas query string encoded form--%>
                                        <asp:LinkButton ID="lnk1293" runat="server" Visible="false" Enabled="true"><%=IIf(Me.Session("Choice") = 1, "Chainage Wise Report", "चेनेज वाइस रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1113" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Consumption Report", "सामग्री खपत रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1114" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Royalty Report", "रॉयल्टी रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1280" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Project Status Report", "प्रोजेक्ट स्थिति रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1278" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Measurement Trail Detail", "माप ट्रेल विवरण")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1103" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Print Work Details", "प्रिंट कार्य विवरण")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1106" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Print Measurement Details", "प्रिंट माप विवरण")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1109" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Running Bill", "रिप्रिंट चालू बिल ")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1297" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Tender", "रिप्रिंट निविदा")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1251" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Plan, Budget and  Expenditure Report", "कार्य बजट व व्यय रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1252" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "WorkPlan Report", "कार्य योजना रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1220" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Project Details Report", "प्रोजेक्ट विवरण रिपोर्ट")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1439" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Print Rate Analysis", "प्रिंट दर विश्लेषण ")%></asp:LinkButton></li>
                                    <li>
                                        <asp:LinkButton ID="lnk1446" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Physical & Financial Progress Report", "भौतिक और वित्तीय प्रगति रिपोर्ट  ")%></asp:LinkButton></li>
                                    <asp:LinkButton ID="lnk1447" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Activitywise Physical & Financial Progress Report", " एक्टिविटीवाँइस भौतिक और वित्तीय रिपोर्ट  ")%></asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnk1138" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "ULB Reports", "यू एल बी रिपोर्ट")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1139" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Demand Collection & Balance", "डिमांड संग्रह और बैलेंस")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1261" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "DCB Summary", "डिमांड संग्रह और बैलेंस सांराश")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1253" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "List Of Agency", "एजेंसी की सूची ")%></asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <%--<li>
                                <asp:LinkButton ID="lnk1147" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Inventory Reports", "इन्वेन्ट्री रिपोर्ट")%></asp:LinkButton>
                                <ul style="overflow: auto; height: 200px; width: 220px;">
                                    <li>
                                        <asp:LinkButton ID="lnk1148" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Item Stock", "आइटम स्टॉक ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1149" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Quantitative Details of Item", "मद की मात्रात्मक जानकारी का विवरण ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1150" runat="server" PostBackUrl="~/Inventory/SalesReport.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sales ", "विक्रय ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1151" runat="server" PostBackUrl="~/Inventory/PurchaseReport.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Purchase ", "क्रय ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1142" runat="server" PostBackUrl="~/Inventory/frmDailyGrainVoucher.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grain Issue Voucher", "खाद्य पदार्थ वितरण वाउचर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1143" runat="server" PostBackUrl="~/Inventory/frmGrainReport.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grain Register", "खाद्य पदार्थ रजिस्टर")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1144" runat="server" PostBackUrl="~/Inventory/SalesRegister.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sales Register", "विक्रय रजिस्टर ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1145" runat="server" PostBackUrl="~/Inventory/IssueRegister.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Issue Register", "निर्गमन रजिस्टर ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1146" runat="server" PostBackUrl="~/Inventory/StockTransferRegister.aspx"
                                            Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Stock Transfer Register", "स्टॉक ट्रॉन्सफर रजिस्टर")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>--%>
                    <li>
                        <asp:LinkButton ID="lnk1401" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Material Reports", "मटेरियल रिपोर्ट")%></asp:LinkButton>
                        <ul style="overflow: auto; height: 200px; width: 220px;">
                            <li>
                                <asp:LinkButton ID="lnk1418" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Print Certificates / Declaration", "Print Certificates / Declaration")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1419" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Availability of Goods Material", "Availability of Goods Material")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1416" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Stock Register", "Stock Register")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1417" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Stock List", "Stock List")%></asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnk1216" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Party / Agency Register", "पार्टी / एजेंसी  रजिस्टर")%></asp:LinkButton>
                        <ul>
                            <li>
                                <%--Task No:(1365 link name changed)--%>
                                <asp:LinkButton ID="lnk1217" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Party / Agency Register Report", "पार्टी / एजेंसी रजिस्टर रिपोर्ट")%></asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton ID="lnk1218" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Party / Agency Summary Report", "पार्टी / एजेंसी संक्षिप्त रिपोर्ट")%></asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnk1200" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "ADV Report", "ADV Report")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1201" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Daily Ro Report", "Daily Ro Report")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1202" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Cancelled Ro Report", "Cancelled Ro Report")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1203" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Invoice Report", "Invoice Report")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1204" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Cancelled Invoice Report", "Cancelled Ro Report")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1222" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Service Tax Report", "Service Tax Report")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1205" runat="server" Visible="false" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Publish Report", "Publish Report")%></asp:LinkButton></li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnk1795" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Receipt Management Report", "रसीद प्रबंधन रिपोर्ट")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1796" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Cash/dd/e-Transaction Register", "नगद  /डीडी /ई ट्रांजेक्सन  पंजी ")%></asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <li>
                        <asp:LinkButton ID="lnk1511" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "E-Pay", "ई-पे ")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1512" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Bank Data", "रिप्रिंट बंक डाटा ")%></asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1011" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Finance", "वित्तीय")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1012" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "A/C Transactions", "लेखांकन लेनदेन")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1557" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "General Bill Payment", "सामान्य बिल भुगतान ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1015" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " CashDeposits and withdrawals", "रोकङ जमा और निकासी")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1813" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Fixed Deposit", "सावधि जमा")%></asp:LinkButton>
                                </li>
                                <li>
                                    <%-- Paas Query string encrepted form by ravi on 12.09.2012 Task No 1106--%>
                                    <%--<asp:LinkButton ID="lnk1013" runat="server" PostBackUrl="~/voucherTest.aspx?Vtpye=Receipt"--%>
                                    <asp:LinkButton ID="lnk1013" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Receipt Voucher", "प्राप्ति वाउचर")%></asp:LinkButton>
                                </li>
                                <li>
                                    <%-- Paas Query string encrepted form by ravi on 12.09.2012 Task No 1106--%>
                                    <%--<asp:LinkButton ID="lnk1014" runat="server" PostBackUrl="~/voucherTest.aspx?Vtpye=Payment"--%>
                                    <asp:LinkButton ID="lnk1014" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Payment Voucher", " भुगतान वाउचर")%></asp:LinkButton>
                                </li>
                                <li>
                                    <%-- Paas Query string encrepted form by ravi on 12.09.2012 Task No 1106--%>
                                    <%-- <asp:LinkButton ID="lnk1016" runat="server" PostBackUrl="~/frm_voucher_other.aspx?Vtpye=Journal"--%>
                                    <asp:LinkButton ID="lnk1016" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Journal Voucher", "जनरल वाउचर")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1494" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Printing Running Bill Payment", "प्रिंटिंग रनिंग बिल का भुगतान ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1541" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Final Printing Bill Payment", "प्रिंटिंग बिल का पूर्ण भुगतान")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1542" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "2 % Printing Bill Payment", "2 % प्रिंटिंग बिल का भुगतान")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1909" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "EMD To SD Conversion", "ई एम डी का सुरक्षा निधि में रूपांतरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1804" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Paper Bill Payment", "पेपर बिल का भुगतान ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1017" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Other Voucher", "अन्य वाउचर")%></asp:LinkButton>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="lnk1042" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Deferred Payment Voucher", "डिफर्ड भुगतान वाउचर")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1173" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Expenses Allocation Voucher", "व्यय वितरण पत्र")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1174" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grant Received Memo", "अनुदान ज्ञापन")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1175" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Sanction Note", "स्वीकृति पत्रक")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1224" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Unpaid Bill", "अनपेड देयक")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1172" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Inter Scheme Transfer", "अंतर स्कीम हस्तांतरण")%></asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1794" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Deposit Cheque/Fund In Transit", "चेक / फंड इन ट्रांजिट जमा  ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1910" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Miscellaneous Advance", "विविध अग्रिम")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1054" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Bank Reconciliation", "बैंक समाधान विवरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1761" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Pay bill voucher", "वेतन पत्रक वाउचर ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1766" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cancel Pay bill voucher", "वेतन पत्रक वाउचर रद्द  ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1245" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Assistance Disbursement", "सहायता राशि वितरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1634" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Subsidy Disbursement ", "Subsidy Disbursement ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1751" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Input Subsidy Disbursement ", "अनुदान / सामग्री  भुगतान ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1754" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Benificiary Upload Page ", "Benificiary Upload Page")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1753" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Cancel Input Subsidy ", "Cancel Input Subsidy ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1232" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Data Export Utility", "डाटा एक्सपोर्ट यूटिलीटी")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1233" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Data Import Utility", "डाटा इम्पोर्ट यूटिलीटी")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1808" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Cheque Printing", "चैक प्रिंटिंग")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1478" runat="server" OnClientClick="javascript:return false;"
                                Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Advance Payment", "अग्रिम भुगतान ")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1453" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Traveling Advance Recommendation", "अग्रिम यात्रा अनुशंसा ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1480" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Festival Advance Recommendation", "त्यौहार अग्रिम अनुशंसा")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1479" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grain Advance Recommendation", "अनाज अग्रिम अनुशंसा")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1952" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Medical Advance Recommendation", "चिकित्सा  अग्रिम अनुशंसा")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1019" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, " Assets Management", "संपत्तियाँ प्रबंधन")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1020" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Immovable Assets", "अचल संपत्ति")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1021" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Movable Assets", "चल संपत्ति")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1022" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Capital Work In Progress Details", "पूँजीगत कार्यो का प्रगति विवरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1018" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Calculate Depreciation", "ह्रास गणना")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1039" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Budget Management", "बजट प्रबंधन")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1248" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment", "बजट आवंटन")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1341" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Budget Allotment(Without Demand)", "बजट आवंटन (डिमांड रहित")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1040" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Create Budget", "बजट बनाएँ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1335" runat="server" Enabled="True" Visible="false"> </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1247" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Budget Fund Demand", "बजट फंड डिमांड")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1731" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Bulk Budget Allotment", "बल्क बजट आबंटन")%></asp:LinkButton></li>
                                <asp:LinkButton ID="lnk1340" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Fund Refund", "फंड रिफन्ड ")%></asp:LinkButton>
                            </ul>
                        </li>
                        <%--</li>--%>
                        <li>
                            <asp:LinkButton ID="lnk1048" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Receipt Management", "प्राप्तियॉ प्रबंधन")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1049" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Receipt", "रसीद")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1050" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Receipt Reprint", "रसीद रिप्रिंट करे")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1051" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cancel Receipt", "रसीद रद्द करे")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1052" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Daily Collection Register", "दैंनिक संग्रहण पंजी ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1053" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Cheque Deposit Slip", "चेक जमा पर्ची ")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1089" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "T D S", "टी डी एस")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1228" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Generate Challan", "जनरेट चालान")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1229" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Challan Reconciliation", "चालान समाधान विवरण")%>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1801" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Depot Transaction", "डिपो ट्रांजेक्सन ")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1802" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Unloading Expenses", " अनलोडिंग  व्यय ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1803" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Transportation Expenses", "परिवहन व्यय ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1806" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Office & Godown Rent Payment", "कार्यालय तथा गोदाम किराया भुगतान ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1805" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Simplified Transaction", " सरल प्रविष्टि ")%>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1701" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Treasury", "ट्रेजरी ")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1713" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Treasury Configuration", "ट्रेजरी कान्फ़िगरेशन   ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1705" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Bill Register ", "बिल रजिस्टर ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1700" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "FVC ", "एफ. बी. सी. ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1702" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Medical Bill ", "मेडिकल बिल ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1703" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "PA Payment", "पी ए पेमेंट  ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1704" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Traveling Bill", "ट्रेवलिंग बिल ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1706" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Bill For Advance 76 - B", "एडवांस बिल  76 - B")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1707" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " M. P. T. C. 76 ", " एम पी टी सी  76 ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1708" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Bill For Withdrawal - 63 ", " Bill For Withdrawal - 63 ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1709" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Grant In Aid ", "Grant In Aid")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1712" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Temporary Advance ", "Temporary Advance")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1714" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " General Advance ", "General Advance")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1715" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Advance Adjustment ", "Advance Adjustment")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1716" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Miscellaneous Payment ", "Miscellaneous Payment")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1717" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, " Miscellaneous Receipt ", "Miscellaneous Receipt")%>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1554" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "E-pay", "ई- पे")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1505" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Prepare Payment", "भुगतान बनाये ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1506" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Recommend payment", "भुगतान की अनुशंसा  ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1507" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Pass & Forward For Payment", " भुगतान पास कर आगे भेजे  ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1508" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Pass & Transfer Payment", "भुगतान पास कर हस्तांतरित करे ")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1555" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Bill Register", "बिल रजिस्टर")%>
                                    </asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1510" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Prepare Material Payment", "सामग्री भुगतान बनाए ")%>
                                    </asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1099" Visible="false" runat="server" OnClientClick="javascript:return false;">
                        <%=IIf(Me.Session("Choice") = 1, "Project Monitoring", "प्रोजेक्ट मॉनिटरिंग")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1443" Visible="false" runat="server"><%=IIf(Me.Session("Choice") = 1, "Project Detail", "प्रोजेक्ट विवरण")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1225" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "R & D Project", "आर एंड डी प्रोजेक्ट")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton Visible="false" ID="lnk1100" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Project", "प्रोजेक्ट")%></asp:LinkButton>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="lnk1102" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Project Detail", "प्रोजेक्ट विवरण ")%></asp:LinkButton></li>
                                        <li>
                                            <asp:LinkButton ID="lnk1101" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Estimate", "कार्य अनुमान")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1445" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Estimate With Template", "टेंप्लेट के साथ कार्य अनुमान ")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1279" Visible="false" runat="server" Enabled="true"><%=IIf(Me.Session("Choice") = 1, "Estimation Template", "अनुमान टेमप्लेट ")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1219" runat="server" Visible="false" Enabled="true"><%=IIf(Me.Session("Choice") = 1, "Work Order", "कार्य आदेश")%></asp:LinkButton></li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1104" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Measurement", "माप")%></asp:LinkButton>
                                    <ul>
                                        <li>
                                            <asp:LinkButton ID="lnk1105" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Measurement", "कार्य माप ")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton ID="lnk1296" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Contractor Comments", "ठेकेदार टिप्पणी")%></asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1107" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Bill", "बिल")%></asp:LinkButton>
                                    <ul>
                                        <li>
                                            <%--Add QueryString By Prince for work Type Task no ;999--%>
                                            <%--<asp:LinkButton ID="lnk1108" runat="server" PostBackUrl="~/SOR/BuildingWorks/frmBillCreation.aspx?workType=0"--%>
                                            <asp:LinkButton ID="lnk1108" runat="server" Visible="false" Enabled="true"><%=IIf(Me.Session("Choice") = 1, "Bill Generate", "बिल जनरेट ")%></asp:LinkButton></li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1281" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Tender Management", "निविदा प्रबंधन")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1231" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Publish Tender", "निविदा प्रकाशन  ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1238" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Tender Rate", "निविदा रेट ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1268" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Upload Tender", "अपलोड निविदा")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1269" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Download Tender", "डाउनलोड निविदा")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1282" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Fee Collection", "जमा संग्रहण")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1289" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Cancel", "रद्द करें")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1262" runat="server" Visible="false" Enabled="True">
                                    <%=IIf(Me.Session("Choice") = 1, "Cancel Job", "जॉब रद्द करें")%></asp:LinkButton>
                                    <%--Query String Add by prince according to task no:1033 For manage one page for all three sstage  bill cancel--%>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1264" runat="server" Visible="false" Enabled="True">
                                    <%=IIf(Me.Session("Choice") = 1, "Cancel Measurement", "माप रद्द करें")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1263" runat="server" Visible="false" Enabled="True">
                                    <%=IIf(Me.Session("Choice") = 1, "Cancel Bill", "बिल रद्द करें")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1250" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Update Project Status", "प्रोजेक्ट की स्थिति बदलें")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1444" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Work Import", "कार्य आयात ")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1234" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "D M S", "डी एम एस")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1235" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Note Sheet", "नोट शीट")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1236" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Note Sheet Dash Board", "नोट शीट डैश बोर्ड")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1237" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Print Note Sheet", "प्रिंट नोट शीट")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton runat="server" Visible="false" ID="lnk1001" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "HR Management", "एच. आर.प्रबंधन")%>
                    </asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1498" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Establishment", "स्थापना")%></asp:LinkButton>
                            <ul>
                                <%-- <li>
                                            <asp:LinkButton ID="lnk1468" Visible="false" runat="server" Enabled="True" PostBackUrl="HR_Report/rpt_letter_police_Verification.aspx"><%=IIf(Me.Session("Choice") = 1, "Letter For Police Verification", "पुलिस सत्यापन पत्र ")%></asp:LinkButton>
                                        </li>
                                         <li>
                                            <asp:LinkButton ID="lnk1469" Visible="false" runat="server" Enabled="True" PostBackUrl="HR_Report/rpt_Letter_Medical_Examination.aspx"><%=IIf(Me.Session("Choice") = 1, "Letter For Medical Examination", "चिकित्सीय परीक्षण पत्र ")%></asp:LinkButton>
                                        </li> --%>
                                <li>
                                    <asp:LinkButton ID="lnk1466" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Joining Certificate", "नियुक्ति सर्टिफिकेट ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1461" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Employee Service Book", "कर्मचारी सेवा पुस्तिका")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1091" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Promotion", "पदोन्नति")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1221" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Transfer", "स्थानांतरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1925" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Departmental Transfer", "विभागीय स्थानांतरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1090" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Annual Increment", "वार्षिक वृद्धि ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1449" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Penalty", "जुर्माना")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1452" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Leave Approval", "अवकाश मंजूरी ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1433" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Attendance Register", "उपस्थिति  रजिस्टर")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1503" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Last Pay Certificate", "अंतिम भुगतान का प्रमाण-पत्र")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1911" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Annual Increment", "वार्षिक वृद्धि ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1912" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Increment Reversal", "वृद्धि वापसी ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1913" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Pay Fixation", "पे फिक्सेशन ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1914" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Arrear Fixation", "एरियर फिक्सेशन ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1915" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Leave Encashment", "अवकाश नगदीकरण   ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1916" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Retirement Calculation", "सेवानिवृत्ति गणना    ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1917" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Gratuity", "ग्रेच्यूटी")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1918" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Letter Receipt Register", "पत्र प्राप्ति रजिस्टर  ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1919" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Dispatch Register", "डिस्पेच  रजिस्टर   ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1920" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "CR Form For Class First & Second", "प्रथम एवं द्वितीय श्रेणी के लिये सी.आर. फॉर्म")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1921" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "CR Form For Class Three", "तृतीय श्रेणी के लिये सी.आर.फॉर्म")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1922" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "CR Form For Class Four", "चतुर्थ श्रेणी के लिये सी.आर.फॉर्म ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1923" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Employee's Training", "कर्मचारियों का प्रशिक्षण ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1924" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grant Amount", "अनुदान राशि  ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1953" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Pay Bill Deduction Challan", "पे बिल कटौती चालान   ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1954" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Cancel Pay Bill Deduction Challan", "पे बिल कटौती चालान रद्द  ")%></asp:LinkButton>
                                </li>
                            </ul>
                            <li>
                                <asp:LinkButton ID="lnk1499" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Employees Corner", "कर्मचारी कॉर्नर ")%></asp:LinkButton>
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="lnk1460" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Particulars of immovable Assets", "अचल संपत्ति विवरण")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1093" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Print Pay Slip", "प्रिंट वेतन पर्ची ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1096" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Leave Request", "अवकाश आवेदन")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1457" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Travelling Bill", "यात्रा बिल   ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1333" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Travelling Allowance/LTC Claim Bill", "Travelling Allowance/LTC Claim Bill")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1456" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Travelling Advance", "यात्रा अग्रिम ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1455" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Grain Advance", "अनाज अग्रिम ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1454" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Festival Advance", "त्यौहार  अग्रिम ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1951" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Medical Advance", "चिकित्सा अग्रिम ")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1331" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Medical Reimbursement Form", "Medical Reimbursement Form")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1428" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Nominee Details", "नामांकित सदस्यों का विवरण")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1429" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Dependent Details", "आश्रितों का विवरण")%></asp:LinkButton>
                                    </li>
                                    <li>
                                        <asp:LinkButton ID="lnk1430" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Achievements", "उपलब्धियाँ")%></asp:LinkButton>
                                    </li>
                                </ul>
                            </li>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1330" runat="server" OnClientClick="javascript:return false;"
                                Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Forms", "फॉर्मस")%></asp:LinkButton>
                            <ul>
                                <%--   <li>
                                        <asp:LinkButton ID="lnk1470" Visible="false" runat="server" Enabled="True" PostBackUrl="HR_Transaction/frm_Police_Verification_Certificate_Format.aspx"><%=IIf(Me.Session("Choice") = 1, "Format of Police Verification Certificate", "पुलिस सत्यापन सर्टिफिकेट फार्मेट")%></asp:LinkButton>
                                    </li>--%>
                                <li>
                                    <asp:LinkButton ID="lnk1471" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Format of Medical Examination Certificate", "चिकित्सीय परीक्षण  सर्टिफिकेट फार्मेट")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1465" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Joining Letter", "नियुक्ति पत्र ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1332" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "No Dues Certificate", "नो ड्यूज़ प्रमाण-पत्र")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1462" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Declaration Form A", "फ़ार्म ए निर्धारण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1463" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Declaration Form B", "फ़ार्म बी निर्धारण ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1472" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Form No 3", "फार्म क्रमांक 3")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1473" Visible="false" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Form No 4", "फार्म क्रमांक 4")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1095" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Time Sheet", "उपस्थिति  पत्रक")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1098" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Employee Service book", "कर्मचारी सेवा पुस्तिका")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1551" runat="server" OnClientClick="javascript:return false;"
                                Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Pay & Allowance", "वेतन एवं भत्ते")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1277" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Generate Pay Bill", "वेतन पत्रक जनरेट")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1295" runat="server" Enabled="true" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Investments And Income Details", "इंवेस्टमेंट एवं आय की जानकारी ")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1121" runat="server" Visible="false" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "ULB", "यू एल बी")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1128" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Tax Management", "टैक्स प्रबंधन")%></asp:LinkButton>
                            <ul style="overflow: auto; height: 350px; width: 220px;">
                                <li>
                                    <asp:LinkButton ID="lnk1129" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Tax Payer's Registration", "टैक्स भुगतानकर्ता का पंजीयन ")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1130" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Demand Opening Balance", "डिमांड प्रारंभिक शेष")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1131" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Property Tax Demand", "संपत्ति कर डिमांड")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1132" runat="server" Visible="false" Enabled="True">
                                   <%=IIf(Me.Session("Choice") = 1, "Other Demand", "अन्य डिमांड")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1133" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Property Tax Demand", "रिप्रिंट संपत्ति कर डिमांड")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1134" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Other Demand", " रिप्रिंट अन्य डिमांड")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1254" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Reprint Notice / Warrant / Seizure", " रिप्रिंट नोटिस / वारंट / कुर्की आदेश")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1135" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Self Assessment", "स्वतः निर्धारण")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1136" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Self Assessment Approval", "स्व मूल्यांकन और स्वीकृति")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1181" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Self Assessment Description", "स्व मूल्यांकन विवरण ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1137" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Remission / Write Off of Demand", "रिमिशन / राईट आँफ डिमांड")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1255" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Notice/Warrant", "नोटिस/वारंट ")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1182" Visible="false" runat="server" OnClientClick="javascript:return false;">
                                    <%=IIf(Me.Session("Choice") = 1, "Citizen Services", " नागरिक सेवा")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1183" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Birth Registration", "जन्म पंजीयन")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1184" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Water Connection", "जल  प्रदाय कनेक्शन")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1185" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "View Application ", "आवेदन देखे ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1186" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Deliver Certificate ", "प्रमाण पत्र वितरण")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1256" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "New Complaint ", "नयी शिकायत")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1257" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "View Complaint  ", " शिकायत देखे")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton ID="lnk1258" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, " Complaint Transfer  ", " शिकायत स्थानांत्रित करें")%></asp:LinkButton>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
                <%-- <li>'Commented by uttam this lnk id (03/08/2013) Task No:(1666)
                        <asp:LinkButton ID="lnk1140" Visible="false" runat="server" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "Inventory", "इन्वेन्ट्री")%></asp:LinkButton>
                        <ul>
                            <li>
                                <asp:LinkButton ID="lnk1156" runat="server" PostBackUrl="~/Inventory/GRN.aspx" Visible="false"
                                    Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Goods Receipt Note", "जि०आर०एन०")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1157" runat="server" PostBackUrl="~/Inventory/frm_Invoice.aspx"
                                    Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Invoice", "इनवॉइस ")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1158" runat="server" PostBackUrl="~/Inventory/issue.aspx"
                                    Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Issue", "निर्गमन")%></asp:LinkButton></li>
                            <li>
                                <asp:LinkButton ID="lnk1159" runat="server" PostBackUrl="~/Inventory/StockTransfer.aspx"
                                    Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Stock Transfer", "स्टॉक ट्रॉन्सफर")%></asp:LinkButton></li>
                        </ul>
                    </li>--%>
                <li>
                    <asp:LinkButton ID="lnk1402" Visible="false" runat="server" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "Material", "मटेरियल")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1407" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Purchase Order", "क्रय आदेश")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1408" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "G R N", "जी आर एन")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1409" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Material Requisition Slip", "Material Requisition Slip")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1410" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Stock Issue", "Stock Issue")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1411" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Material Requisition Dash Board", "Material Requisition Dash Board")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1413" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "Purchase Order Dash Board", "Purchase Order Dash Board")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1412" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "GRN Dash Board", "GRN Dash Board")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1414" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "AMC Register", "AMC Register")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1415" Visible="false" runat="server" Enabled="True"> <%=IIf(Me.Session("Choice") = 1, "LC Opening Form", "LC Opening Form")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk3500" Visible="false" runat="server" OnClientClick="javascript:return false;"> <%=IIf(Me.Session("Choice") = 1, "WMS", "डब्ल्यू एम एस ")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk3501" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Deposit Gate Pass", "डिपॉजिट गेट पास ")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk3502" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Deposit Request Form", "Deposit Request Form  ")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk3503" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Delivery Form", "Delivery Form ")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1215" Visible="false" runat="server" OnClientClick="javascript:return false;">
                            <%=IIf(Me.Session("Choice") = 1, "RO", "RO")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1194" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Release Order(News Paper)", "Release Order(News Paper)")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1195" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Release Order (Hoarding)", "Release Order (Hoarding)")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1196" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Release Order (Air)", "Release Order (Air)")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1197" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Invoice cancel", "invoice cancel")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1198" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Ro Dash Board", "Ro Dash Board")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1199" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Invoice Sharing", "Invoice Sharing")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1317" Visible="false" runat="server" OnClientClick="javascript:return false;"> <%=IIf(Me.Session("Choice") = 1, "Job", "Job")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1318" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Job Creation", "Job Creation")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1319" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Dash Board", "Dash Board")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1321" runat="server" Enabled="True" Visible="false"> <%=IIf(Me.Session("Choice") = 1, "Job Status Report", "Job Status Report")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1160" Visible="false" runat="server" OnClientClick="javascript:return false;">
                        <%=IIf(Me.Session("Choice") = 1, "Other", "अन्य")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1161" runat="server" Visible="false" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "e-Cashbook", "ई- कैश बुक")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1162" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "e-Cashbook", "ई- कैश बुक ")%> </asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1163" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "e-Cashbook Template", "ई- कैश बुक टेम्पलेट ")%></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1164" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Self Help Group", "स्वय: सहायता समूह ")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton ID="lnk1165" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Self Help Group Meeting", "स्व सहायता समूह मिटिंग")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1166" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Self Help Group", "स्व सहायता समूह")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1167" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Training Plan", "प्रशिक्षण योजना")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1168" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Training Status", "प्रशिक्षण योजना स्थिति")%></asp:LinkButton></li>
                                <li>
                                    <asp:LinkButton ID="lnk1169" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Edit Training Plan", "अपडेट प्रशिक्षण योजना")%></asp:LinkButton></li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1062" Visible="false" runat="server" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "Beta Pages", "Beta Pages")%></asp:LinkButton>
                            <ul>
                                <li>
                                    <asp:LinkButton Visible="false" ID="lnkReceiptBeta" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Receipt Voucher", "Receipt Voucher")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="false" ID="lnkPaymentBeta" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Payment Voucher", "भुगतान वाउचर")%></asp:LinkButton>
                                </li>
                                <%--<li>
                                            <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Master_Pages/frm_Import_Panchayat_Data.aspx"
                                                Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Import Trial Balance", "Import Trial Balance")%></asp:LinkButton>
                                        </li>--%>
                                <li>
                                    <asp:LinkButton Visible="false" ID="lnk1435" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Alert Message", "Alert Message")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="false" ID="lnk1642" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "e-CashBook", " e-CashBook")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="true" ID="lnkcpfvoucher" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "GPF/CPF VOUCHER", "जी पी एफ / सी पी एफ वाउचर ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="true" ID="lnkcpfconfiguration" runat="server" Enabled="True"
                                        PostBackUrl="Beta_pages/frm_gpf_cpf_interest_configuration.aspx"><%=IIf(Me.Session("Choice") = 1, "GPF/CPF INTEREST RATE CONFIGURATION", "जी पी एफ / सी पी एफ कॉन्फीगरेशन ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="true" ID="lnkAgencyMaster" runat="server" Enabled="True"
                                        PostBackUrl="beta_pages/frm_gpf_cpf_Agency_Master.aspx"><%=IIf(Me.Session("Choice") = 1, " AGENCY MASTER", "एजेंसी मास्टर  ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="true" ID="lnkGPFLedger" runat="server" Enabled="True" PostBackUrl="Beta_Pages/rpt_gpf_Ledger.aspx"><%=IIf(Me.Session("Choice") = 1, " GPF Ledger ", "जी पी एफ लेजर   ")%></asp:LinkButton>
                                </li>
                                <li>
                                    <asp:LinkButton Visible="true" ID="lnkcpfLedger" runat="server" Enabled="True" PostBackUrl="Beta_Pages/rpt_cpf_Ledger.aspx"><%=IIf(Me.Session("Choice") = 1, " CPF Ledger  ", "सी  पी एफ लेजर   ")%></asp:LinkButton>
                                </li>
                                <%-- <li>
                                            <asp:LinkButton Visible="True" ID="lnkworkReg" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_Work_Registration_Swach_Bharat.aspx"><%=IIf(Me.Session("Choice") = 1, "Work Registration", "Work Registration")%></asp:LinkButton>
                                        </li>--%>
                                <li>
                                    <asp:LinkButton ID="LinkButton11" runat="server" Visible="true" OnClientClick="javascript:return false;"><%=IIf(Me.Session("Choice") = 1, "NBA", "NBA")%></asp:LinkButton>
                                    <ul>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="lnkworkReg" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_Work_Registration_Swach_Bharat.aspx"><%=IIf(Me.Session("Choice") = 1, "Demand For Toilets", "Demand Of Toilets")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton12" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_Approval_Works.aspx"><%=IIf(Me.Session("Choice") = 1, "Approval Of Demanded Works", "Approval Of Demanded Works")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton13" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_Verification_works.aspx"><%=IIf(Me.Session("Choice") = 1, "Verification Of Demanded Works", "Verification Of Demanded Works")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton1" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_AC_freezing.aspx"><%=IIf(Me.Session("Choice") = 1, "A/C verification freezing", "A/C verification freezing")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton2" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_prepare_payment.aspx"><%=IIf(Me.Session("Choice") = 1, "Prepare Payment", "Prepare Payment")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton3" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_recommend_payment.aspx"><%=IIf(Me.Session("Choice") = 1, "Recommend Payment", "Recommend Payment")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton4" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_pass_forward_payment.aspx"><%=IIf(Me.Session("Choice") = 1, "Pass & Forward for payment", "Pass & Forward for payment")%></asp:LinkButton>
                                        </li>
                                        <li>
                                            <asp:LinkButton Visible="True" ID="LinkButton5" runat="server" Enabled="True" PostBackUrl="Beta_pages/frm_pass_transfer_payment.aspx"><%=IIf(Me.Session("Choice") = 1, "Pass & Transfer payment", "Pass & Transfer payment")%></asp:LinkButton>
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1259" runat="server" PostBackUrl="TrainingMenu.aspx" Enabled="True"
                                Visible="false"><%=IIf(Me.Session("Choice") = 1, "Training erp", "प्रशिक्षण ई आर पी")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1651" runat="server" PostBackUrl="~/DashBoard.aspx" Enabled="True"
                                Visible="false"><%=IIf(Me.Session("Choice") = 1, "Panch Parmeshwar", "पंच परमेश्वर ")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1176" Visible="false" runat="server" OnClientClick="javascript:return false;">
                        <%=IIf(Me.Session("Choice") = 1, "Admin", "प्रशासनिक")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton ID="lnk1177" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Data Backup", "डाटा बेकअप")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1178" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Data Restore", "डाटा री-स्टोर")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1768" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Generate Product Key", "Generate Product Key")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1788" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Update Yojna", "Update Yojna")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1710" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Data Upload", "डाटा अपलोड ")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1711" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Data Download", "डाटा डाऊनलोड ")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1442" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "DB Helper", "DB Helper")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1179" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Upload Tender", "अपलोड टेंडर ")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1260" runat="server" Visible="false" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Upload Document", "अपलोड डाकुमेंट")%></asp:LinkButton></li>
                        <li>
                            <asp:LinkButton ID="lnk1180" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "User Management", "यूजर प्रबंधन")%></asp:LinkButton>
                        </li>
                         <li>
                            <asp:LinkButton ID="lnk1955" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Finance Role", "वित्तीय रोल")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1769" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Register Digital Signature", "Register Digital Signature")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1789" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Generate Signature XML", "Generate Signature XML")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1170" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Change/Reset Password", "पासवर्ड बदलें/रीसेट करें")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk1300" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Book Closing", "पुस्तक समापन")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton ID="lnk4050" runat="server" Enabled="True" Visible="false"><%=IIf(Me.Session("Choice") = 1, "Download Error Log File", "Download Error Log File")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                <li>
                    <asp:LinkButton ID="lnk1441" Visible="false" runat="server" OnClientClick="javascript:return false;">
                        <%=IIf(Me.Session("Choice") = 1, "TMS", "कार्य प्रबंधन")%></asp:LinkButton>
                    <ul>
                        <li>
                            <asp:LinkButton Visible="false" ID="lnk1436" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Task Management", "Task Management")%></asp:LinkButton>
                        </li>
                        <li>
                            <asp:LinkButton Visible="false" ID="lnk1437" runat="server" Enabled="True"><%=IIf(Me.Session("Choice") = 1, "Task Management DashBoard", "Task Management DashBoard")%></asp:LinkButton>
                        </li>
                    </ul>
                </li>
                </ul> </ul>
                <br style="clear: left" />
            </div>
        </td>
    </tr>
    <tr>
        <td align="left" valign="top" class="accordionContentNew">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td id="WATERMARK" width="100%" align="center" valign="top">
                        <asp:Label ID="lblError" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td width="100%" align="right" valign="bottom" style="padding-right: 55px;">
                        <%--<a href="~/TBC_Transaction/frm_Dashboard.aspx" Visible="false" id="lnk1807" runat="server"  ><img src="webyojnaimgYellow/Dashboard.gif" width="150px" /></a>--%>
                        <%--  <asp:LinkButton ID="lnk1807" Visible="false" runat="server"  ><img src="webyojnaimgYellow/Dashboard.gif" width="150px" /></asp:LinkButton>--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
