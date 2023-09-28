<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="InterDepoBarcodeDisti.aspx.cs" Inherits="Depo_InterDepoBarcodeDisti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box table-responsive">
        <div class="card-header">
            <h2><span __designer:mapid="11e1">&#2309;&#2306;&#2340;&#2352; &#2337;&#2367;&#2346;&#2379; 

                </span>&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </h2>
        </div>
        <table width="100%">
            <tr>
                <td colspan="2">

                    <asp:Label ID="Label6" runat="server" Font-Bold="True"></asp:Label>

                </td>
            </tr>
            <tr>
                <td style="width:30%">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Chalan No. </td>
                <td style="width:70%" >
                    <asp:DropDownList ID="ddlChallano" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChallano_SelectedIndexChanged" CssClass="txtbox reqirerd"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width:30%">&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td>
                <td style="width:70%">
                    <asp:DropDownList ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged" CssClass="txtbox reqirerd"></asp:DropDownList>
                </td>



            </tr>

            <tr>
                <td style="width:30%">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; / Bundle No. </td>
                <td style="width:70%">
                    <asp:TextBox ID="txtBundlenNo" runat="server" AutoPostBack="true" OnTextChanged="Checkbarcode" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                </td>



            </tr>
            <tr>
                <td style="width:30%">&#2309;&#2306;&#2340;&#2367;&#2350; &#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; </td>
                <td style="width:70%">

                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

                </td>



            </tr>
            <tr>
                <td>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366;&#2344;&#2375;&#2357;&#2366;&#2354;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; :
         <asp:Label ID="Label3" runat="server" Font-Bold="True"></asp:Label>
                </td>
                <td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; :
             <asp:Label ID="Label4" runat="server" Font-Bold="True"></asp:Label>

                &nbsp;,&nbsp; &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; :
             <asp:Label ID="Label7" runat="server" Font-Bold="True"></asp:Label>

                &nbsp;&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; :
             <asp:Label ID="Label8" runat="server" Font-Bold="True"></asp:Label>

                </td>



            </tr>
            <tr>
                <td>&#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2325;&#2368; &#2332;&#2366; &#2330;&#2369;&#2325;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366;&nbsp; </td>
                <td>
             <asp:Label ID="Label5" runat="server" Font-Bold="True"></asp:Label>

                &nbsp; &#2325;&#2369;&#2354; &#2346;&#2376;&#2325; &#2348;&#2306;&#2337;&#2354; :&nbsp;
             <asp:Label ID="Label9" runat="server" Font-Bold="True"></asp:Label>

                </td>



            </tr>
            <tr>
                <td colspan="2">
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField3" runat="server" />
                    <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="StockDetailsChildID_I" OnRowDeleting="grdPrinterBundleDetails_RowDeleting">
                                                 <Columns>
                                                  


                                                     <asp:TemplateField HeaderText="&#2354;&#2370;&#2332; &#2348;&#2339;&#2381;&#2337;&#2354; /loose">
                                                         <ItemTemplate>
                                                             <asp:CheckBox ID="chkIsLoose" runat="server" AutoPostBack="true" OnCheckedChanged="chkIsLooseChange" />
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                  


                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name ">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="TitleHindi_V" runat="server"  ></asp:Label>
                                              
                                                       </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("booktype") %>' ID="booktype" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle No.">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="BundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2360;&#2375; / Book No. From">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("FromNo_I") %>' ID="FromNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; &#2340;&#2325; / Book No. To">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("ToNo_I") %>' ID="ToNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2360;&#2306;&#2326;&#2381;&#2351;&#2366; / Book No.">
                                                 <ItemTemplate>
                                                  
                                                  <asp:Label Text='<%#Convert.ToInt32(Eval("ToNo_I"))-( Convert.ToInt32(Eval("FromNo_I")))+1 %>' ID="lblPer" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                     <asp:TemplateField>
                                                         <ItemTemplate>
                                                            
                                                               <asp:TextBox ID="txtb" runat="server" Visible="false" OnTextChanged="txtonChange" AutoPostBack="true" Width="30"  ></asp:TextBox>
                                                             <br />
                                                             <asp:HiddenField ID="hdaa" runat="server" Value='<%#Eval("RemainingStock") %>' />
                                                             <asp:Label ID="Label1" runat="server" Text='<%#Eval("RemainingStock") %>'></asp:Label>
                                                             <asp:HiddenField ID="HiddenField2" runat="server" Value='<%# Eval("StockDetailsChildID_I") %>'  />
                                                             <asp:CheckBoxList ID="ChkLooseBundleList" runat="server" RepeatColumns="7" Enabled="false" >
                                                             </asp:CheckBoxList>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:CommandField ShowDeleteButton="True" />
                                                 </Columns>
                                                  <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                 </asp:GridView></td>



            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="&#2360;&#2369;&#2352;&#2325;&#2381;&#2359;&#2367;&#2340; &#2325;&#2352;&#2375;&#2306; "  OnClientClick="return ValidateAllTextForm();" />
                </td>



            </tr>
        </table>
    </div>
</asp:Content>

