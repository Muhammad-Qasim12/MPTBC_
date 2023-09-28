<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportViewer.aspx.cs" Inherits="ReportViewer" MasterPageFile="~/MasterPage.master" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

 
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <%-- <script type="text/javascript">
        function Print() {
            var report = document.getElementById("<%=ReportViewer1.ClientID %>");
            var div = report.getElementsByTagName("DIV");
            var reportContents;
            for (var i = 0; i < div.length; i++) {
                if (div[i].id.indexOf("VisibleReportContent") != -1) {
                    reportContents = div[i].innerHTML;
                    break;
                }
            }
            var frame1 = document.createElement('iframe');
            frame1.name = "frame1";
            frame1.style.position = "absolute";
            frame1.style.top = "-1000000px";
            document.body.appendChild(frame1);
            var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
            frameDoc.document.open();
            frameDoc.document.write('<html><head><title></title>');
            frameDoc.document.write('</head><body style = "font-family:arial;font-size:10pt;">');
            frameDoc.document.write(reportContents);
            frameDoc.document.write('</body></html>');
            frameDoc.document.close();
            setTimeout(function () {
                window.frames["frame1"].focus();
                window.frames["frame1"].print();
                document.body.removeChild(frame1);
            }, 500);
        }

    </script>--%>
    <div class="box">
        <div class="card-header">
            <h2>
                <span ><asp:Label ID="lblTitleName" runat="server"></asp:Label> </span></h2>
        </div>
        <div style="padding-right: 10px; padding-left: 10px; padding-bottom: 0px; padding-top: 0px">
            <div class="table-responsive">
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Label ID="LblAcYear" runat="server">&#2358;&#2367;&#2325;&#2381;&#2359;&#2366; &#2360;&#2340;&#2381;&#2352; <br /> Academic Year :</asp:Label>
                            <asp:DropDownList ID="DdlACYear" runat="server" CssClass="txtbox">
                            </asp:DropDownList>


                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDepot" runat="server">&#2337;&#2367;&#2346;&#2379; <br /> Depot :</asp:Label>
                            <asp:DropDownList ID="DDlDepot" runat="server" CssClass="txtbox"
                                OnSelectedIndexChanged="DDlDepot_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </td>


                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblDistrict" runat="server">&#2332;&#2367;&#2354;&#2366; <br /> District :</asp:Label>
                            <asp:DropDownList ID="DdlDistrict" runat="server" CssClass="txtbox" Enabled="false">
                            </asp:DropDownList>
                        </td>


                    </tr>
                    <tr>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366; <br /> Class:</asp:Label>
                            <asp:DropDownList ID="DDLClass" runat="server" CssClass="txtbox"
                                OnSelectedIndexChanged="DDLClass_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="1-8" Value="1-8"></asp:ListItem>
                                <asp:ListItem Text="9-12" Value="9-12"></asp:ListItem>
                            </asp:DropDownList>
                        </td>

                        <td style="width: 30%; font-size: medium;" valign="top">
                            <asp:Label ID="LblScheme" runat="server">&#2351;&#2379;&#2332;&#2344;&#2366; <br /> Scheme :</asp:Label>
                            <asp:DropDownList ID="DdlScheme" runat="server" CssClass="txtbox">
                            </asp:DropDownList>
                        </td>
                        <td>मांग का प्रकार<br /> Demand Type :
                              <asp:DropDownList ID="DDlDemandType" runat="server" CssClass="txtbox">
                                  <asp:ListItem value="1">प्रथम मांग</asp:ListItem>
                                  <asp:ListItem value="2">द्वितीय&nbsp;मांग</asp:ListItem>
                                  <asp:ListItem value="2,4">तृतीय मांग</asp:ListItem>
                                  <asp:ListItem value="2,4,5">अतिरिक्त मांग</asp:ListItem>
                            </asp:DropDownList>
                           
                        </td>
                        <td>
                             <asp:Button ID="Button1" runat="server" Text="&#2352;&#2367;&#2346;&#2379;&#2352;&#2381;&#2335; &#2342;&#2375;&#2326;&#2375; / See Report" CssClass="btn" OnClick="Button1_Click" />

                        </td>

                    </tr>
                </table>
                <%--<input type="button" id="btnPrint" value="Print" onclick="Print()" />--%>
                <div style="overflow: auto" class="rdlc">
                    <rsweb:ReportViewer ID="ReportViewer1" Width="100%" runat="server"
                        DocumentMapWidth="100%" Height="" SizeToReportContent="True" ShowPrintButton="true">
                    </rsweb:ReportViewer>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
