<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BarCodeStockDistribution.aspx.cs" 
    Inherits="Distribution_BarCodeStockDistribution" Title="प्रारंभिक स्टॉक की जानकारी" %>

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
            <script type="text/javascript">
                function checkAll(objRef) {
                    var GridView = objRef.parentNode.parentNode.parentNode;
                    var inputList = GridView.getElementsByTagName("input");
                    for (var i = 0; i < inputList.length; i++) {
                        //Get the Cell To find out ColumnIndex
                        var row = inputList[i].parentNode.parentNode;
                        if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                            if (objRef.checked) {
                                //If the header checkbox is checked
                                //check all checkboxes
                                //and highlight all rows
                                //row.style.backgroundColor = "aqua";
                                inputList[i].checked = true;
                            }
                            else {
                                //If the header checkbox is checked
                                //uncheck all checkboxes
                                //and change rowcolor back to original
                                //if (row.rowIndex % 2 == 0) {
                                //    //Alternating Row Color
                                //    row.style.backgroundColor = "#C2D69B";
                                //}
                                //else {
                                //    row.style.backgroundColor = "white";
                                //}
                                inputList[i].checked = false;
                            }
                        }
                    }
                }
            </script>
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

                    
                    var lblNoOfBooks = document.getElementById(obj.id.replace("Viewbarcode", "lblNoOfBooks"));
                  
                    var lblDepoName_V = document.getElementById(obj.id.replace("Viewbarcode", "lblDepoName_V"));
                    var TxtBundleNoFrom = document.getElementById(obj.id.replace("Viewbarcode", "TxtBundleNoFrom"));
                    var lblBundleNoTo = document.getElementById(obj.id.replace("Viewbarcode", "lblBundleNoTo"));
                    var TextBooksPerBundle = document.getElementById('<%=TextBooksPerBundle.ClientID %>');
                    var TxtBookNoFrom = document.getElementById(obj.id.replace("Viewbarcode", "TxtBookNoFrom"));


                    var DdlTitle = document.getElementById('<%= DdlTitle.ClientID %>');
                    var DdlBookType = document.getElementById('<%= DdlBookType.ClientID %>');


                    var Title = DdlTitle.options[document.getElementById('<%= DdlTitle.ClientID %>').selectedIndex].text;
                    var BookType = DdlBookType.options[document.getElementById('<%= DdlBookType.ClientID %>').selectedIndex].text;
                      

                    window.open('StockBarCode.aspx?NoOfBooks=' + lblNoOfBooks.innerHTML + '&Bookstart=' + TxtBookNoFrom.value + '&BookType=' + BookType + '&TxtBundleNoFrom=' + TxtBundleNoFrom.value + "&lblBundleNoTo=" + lblBundleNoTo.value + "&Title=" + Title + "&DepoName=" + lblDepoName_V.innerHTML + "&Cnt=" + TextBooksPerBundle.value);

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

            </script>
            <div class="box table-responsive">
                <div class="card-header">
                    <h2 style="text-align: center;"><span><b>प्रारंभिक स्टॉक की जानकारी </b></span></h2>
                </div>
                <div class="portlet-content">
                    <asp:Panel class="response-msg success ui-corner-all" runat="server" ID="mainDiv" Style="display: none; padding-top: 10px; padding-bottom: 10px;">
                        <asp:Label ID="lblmsg" class="notification" runat="server">
                
                        </asp:Label>
                    </asp:Panel>
                    <table width="100%">


                        <tr>
                            <td style="font-size: medium;"><span style="color: Red;">*</span><asp:Label ID="LblBookType" runat="server">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; <br /> Book Type:</asp:Label>

                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlBookType">
                                    <asp:ListItem Text="&#2351;&#2379;&#2332;&#2344;&#2366;" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="&#2360;&#2366;&#2350;&#2366;&#2344;&#2381;&#2351;" Value="2"></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="font-size: medium;">
                                <span style="color: Red;">*</span><asp:Label ID="LblClass" runat="server">&#2325;&#2325;&#2381;&#2359;&#2366;<br /> Class :</asp:Label>

                            </td>
                            <td>
                                <asp:DropDownList ID="DdlClass" runat="server" CssClass="txtbox reqirerd"
                                    AutoPostBack="True" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                                </asp:DropDownList></td>
                            <td style="font-size: medium;"></td>

                        </tr>
                        <tr>
                            <td>
                                <span style="color: Red;">*</span><asp:Label ID="Label3" runat="server">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; <br /> Book Tittle:</asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList runat="server" ID="DdlTitle" CssClass="txtbox reqirerd">
                                </asp:DropDownList>
                            </td>
                            <td style="font-size: medium;">
                                <span style="color: Red;">*</span><asp:Label ID="Label4" runat="server">&#2346;&#2381;&#2352;&#2340;&#2367; &#2348;&#2306;&#2337;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;<br /> Books Per Bundle:</asp:Label>

                            </td>
                            <td>
                                <asp:TextBox MaxLength="5" ID="TextBooksPerBundle" CssClass="reqirerd" runat="server" onkeypress='javascript:tbx_fnInteger(event, this);'></asp:TextBox>
                            </td>

                            <td style="font-size: medium;">
                                <asp:Button ID="BtnGenerate" runat="server" OnClick="Button2_Click" Text="&#2357;&#2367;&#2340;&#2352;&#2339; &#2344;&#2367;&#2352;&#2381;&#2342;&#2375;&#2358; &#2332;&#2366;&#2352;&#2368; &#2325;&#2352;&#2375; / Save "
                                    OnClientClick='javascript:return ValidateAllTextForm();' CssClass="btn" />
                            </td>

                        </tr>

                        <%-- <tr>
    <td style="font-size: medium;"><span style="color:Red; vertical-align:top;">*</span><asp:Label ID="lblBookNo" runat="server" Width="142px"> &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2325;&#2361;&#2366;&#2305; &#2360;&#2375; </asp:Label>
         <asp:TextBox MaxLength="10" ID="TxtBookNo" CssClass="reqirerd" runat="server"  onkeypress='javascript:tbx_fnInteger(event, this);' ></asp:TextBox>
    </td>
    <td style="font-size: medium;"><span style="color:Red; vertical-align:top;">*</span><asp:Label ID="LblBundleNO" runat="server" Width="142px"> &#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2325;&#2361;&#2366;&#2305; &#2360;&#2375; </asp:Label>
         <asp:TextBox MaxLength="10" ID="TxtBundleNo" CssClass="reqirerd" runat="server"  onkeypress='javascript:tbx_fnInteger(event, this);' ></asp:TextBox>
    </td>
    </tr>--%>
                        <tr>
                            <td colspan="5">


                                <asp:GridView runat="server" ID="GrdVitranNirdesh" CssClass="tab hastable " AutoGenerateColumns="False" OnRowDataBound="GrdVitranNirdesh_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <tr>
                                                    <th rowspan="3" align="center">&#2325;&#2381;&#2352;&#2406; / Sr. No.
                                                    </th>
                                                    <th rowspan="3" align="center">चुने / Choose<br />
                                                        <asp:CheckBox ID="ChkHeaderSelect" runat="server" onclick="checkAll(this);" />
                                                    </th>
                                                    <th rowspan="3" align="center">&#2337;&#2367;&#2346;&#2379; &#2325;&#2366; &#2344;&#2366;&#2350; / Depot Name
                                                    </th>
                                                    <th rowspan="3" style="width: 80Px;" align="center">&#2337;&#2367;&#2346;&#2379; &#2361;&#2375;&#2340;&#2369; &#2310;&#2357;&#2306;&#2335;&#2367;&#2340; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Depotwise Alloted No. Of Book
                                                    </th>
                                                    <th colspan="2" align="center">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2344;&#2306;&#2348;&#2352;&#2367;&#2306;&#2327; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; / No. Details of Book
                                                    </th>
                                                    <th colspan="3">&#2337;&#2367;&#2346;&#2379;&#2348;&#2366;&#2352; &#2348;&#2306;&#2337;&#2354;&#2379; &#2325;&#2366; &#2357;&#2367;&#2357;&#2352;&#2339; /  Depotwise Bundles Details
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
                                                    <td><%# Container.DataItemIndex+1 %>.</td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkSelect" runat="server" />

                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblDepoName_V" runat="server" Text='<%#Eval("DepoName_V")%>'></asp:Label>
                                                         <asp:Label ID="lblDepoTrno_I" runat="server" Text='<%#Eval("DepoTrno_I")%>' Visible="false"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNoOfBooks" runat="server" Text='<%#Eval("NoOfBooks")%>'></asp:Label>
                                                    </td>
                                                    <%--<td> <asp:Label  ID="lblBookNoFrom" runat="server" Text='<%#Eval("BookNoFrom")%>' ></asp:Label> </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="TxtBookNoFrom" MaxLength="10" Width="95px" onblur="CalculateBookNos(this);" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="Server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="lblBookNoTo" Enabled="false" runat="server" Text="0" Width="95px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTotalBundles" runat="server" Text='<%#Eval("TotalBundles")%>'></asp:Label>
                                                    </td>
                                                    <%-- <td> <asp:Label  ID="lblBundleNoFrom" runat="server" Text='<%#Eval("BundleNoFrom")%>' ></asp:Label> </td>--%>
                                                    <td>
                                                        <asp:TextBox ID="TxtBundleNoFrom" MaxLength="10" Width="95px" onblur="CalculateBundleNos(this);" onkeypress='javascript:tbx_fnNumeric(event, this);' runat="Server"> </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="lblBundleNoTo" Enabled="false" runat="server" Width="95px" Text="0"></asp:TextBox>
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

                            </td>

                        </tr>
                        <tr>
                            <td colspan="5"> 
                                <asp:Button ID="btnSave" runat="server" CssClass="btn" Visible="false"
                                    Text="सुरक्षित करे / Save"
                                    OnClick="btnSave_Click" OnClientClick="return ValidateAllTextForm();" />
                            </td>

                        </tr>
                    </table>


                    <br />
                    <br />
                </div>


                <div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

