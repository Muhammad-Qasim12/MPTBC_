<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Challaninterdepo.aspx.cs" Inherits="Depo_Challaninterdepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="card-header">
                                <h2><span>&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; / Inter Depo Distribution  </span></h2>
                            </div>
     <asp:Button ID="btnExportPDF" runat="server" CssClass="btn_gry" 
                            OnClientClick="return PrintPanel();" Text="Export to PDF and Print" />
     
    <div id="ExportDiv" runat="server" >

    <table width="100%">

        <tr align="center" ><td colspan="4">&#2350;&#2343;&#2381;&#2351; &#2346;&#2381;&#2352;&#2342;&#2375;&#2358; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; ,&#2360;&#2306;&#2349;&#2366;&#2327;&#2368;&#2351; &#2349;&#2306;&#2337;&#2366;&#2352;
       
            <asp:Label ID="lblDepoName" runat="server" ></asp:Label>
</td></tr>

        <tr><td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; </td><td>
            <asp:Label ID="lblChallan" runat="server" ></asp:Label>
            </td><td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2342;&#2367;&#2344;&#2366;&#2306;&#2325; </td><td>
            <asp:Label ID="Label2" runat="server" ></asp:Label>
            </td></tr>

        <tr id="a1" runat="server" visible="false" ><td>&#2313;&#2340;&#2352;&#2366;&#2312; / Unloading</td><td>
            <asp:Label ID="lblUnloding" runat="server" ></asp:Label>
            </td><td>&#2330;&#2338;&#2366;&#2312; / Uploading</td><td>
            <asp:Label ID="lblUploading" runat="server" ></asp:Label>
            </td></tr>

        <tr runat="server" visible="false" ><td>&#2309;&#2344;&#2381;&#2351; / Others</td><td>
            <asp:Label ID="lblOther" runat="server" ></asp:Label>
            </td><td>&nbsp;</td><td>&nbsp;</td></tr>

        <tr><td colspan="4">
      <asp:GridView ID="grdDepoTransfer" runat="server" AutoGenerateColumns="False" 
                                            CssClass="tab" DataKeyNames="DemandChildTrno" 
                                            >
                                            <Columns>
                                                <asp:TemplateField HeaderText="&#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / No.">
                                                 <ItemTemplate>
                                                     <%#Container.DataItemIndex+1 %>
                                                     
                                                     <asp:HiddenField ID="HiddenField1" runat="server"  Value='<%# Eval("TitleID_i") %>' />
                                                     <asp:HiddenField ID="booktype" runat="server"  Value='<%# Eval("BookType") %>'/>
                                                      <asp:HiddenField ID="SDepoTrno_I" runat="server"  Value='<%# Eval("SDepoTrno_I") %>'/>
                                                           <asp:HiddenField ID="Medium_I" runat="server" 
                                                         Value='<%# Eval("Medium_I") %>' />
                                                     <asp:HiddenField ID="ClassTrno_I" runat="server" 
                                                         Value='<%# Eval("ClassTrno_I") %>' />
                                                 </ItemTemplate>
                                             </asp:TemplateField>
                                               
                                            <%--    <asp:BoundField HeaderText="&#2350;&#2369;&#2342;&#2381;&#2352;&#2325; / &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2344;&#2366;&#2350; " DataField="NameofPress_V" />--%>
                                                <asp:BoundField HeaderText="&#2350;&#2369;&#2326;&#2381;&#2351;&#2366;&#2354;&#2351; &#2310;&#2342;&#2375;&#2358; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;/ Head Office Permission No." DataField="reqno" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Book Name" DataField="TitleHindi_V" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; (&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;/ &#2351;&#2379;&#2332;&#2344;&#2366;) / Book Type (Genral / Scheme )" DataField="BookType"/>
                                                
                                               <asp:BoundField HeaderText="&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depot Name" DataField="SDepoName_V" />
                                                <asp:BoundField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Books No." DataField="Supply" />

                                                
                                            </Columns>
                                                                        <PagerStyle CssClass="Gvpaging" />
                                              <EmptyDataRowStyle CssClass="GvEmptyText" />
                                        </asp:GridView>
            </td></tr>
    </table> <br />
        <asp:Button ID="Button1" runat="server" Text="&#2310;&#2346; &#2325;&#2366; &#2330;&#2366;&#2354;&#2366;&#2344; &#2348;&#2344; &#2330;&#2369;&#2325;&#2366; &#2361;&#2376;  &#2325;&#2371;&#2346;&#2351;&#2366; &#2348;&#2306;&#2337;&#2354; &#2349;&#2375;&#2332;&#2344;&#2366; &#2360;&#2369;&#2344;&#2367;&#2358;&#2381;&#2330;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; " class="btn" OnClick="Button1_Click" Width="477px"/>
        <a href="InterDepoBarcodeDisti.aspx" class="btn"> &#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2352;&#2375; </a></div> 
     <script type = "text/javascript">
          function PrintPanel() {
              var panel = document.getElementById("<%=ExportDiv.ClientID %>");

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

