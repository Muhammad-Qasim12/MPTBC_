<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BarcodeBookInterDepo.aspx.cs" Inherits="Depo_BarcodeBookInterDepo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="card-header">
                                <h2><span> &#2309;&#2306;&#2340;&#2352;&#2381;&#2337;&#2367;&#2346;&#2379; &#2360;&#2375; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325;&#2379;&#2306; &#2325;&#2368; &#2346;&#2381;&#2352;&#2366;&#2346;&#2381;&#2340;&#2367; / Depot Recieved Books </span></h2>
                            </div>
                            <div style="padding:0 10px;">
<asp:HiddenField ID="hdnId" runat="server" />

                                <table  width="100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="Label1" runat="server" Font-Bold="True"></asp:Label>
                                        &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Chalan No.</td>
                                        <td>
                                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="txtbox">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; (&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; ) </td>
                                        <td>

    <asp:TextBox ID="TxtCode" runat="server" ontextchanged="TxtCode_TextChanged" AutoPostBack="true" onkeyup='javascript:tbx_fnSignedNumericCheck(this);'></asp:TextBox>
                                            <asp:Label ID="LblCode" runat="server">&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; / Bundle No.: </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">

  
                    <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" >
                                                 <Columns>
                                                  


                                                 <asp:TemplateField HeaderText="&#2358;&#2368;&#2352;&#2381;&#2359;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; / Title Name ">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("TitleHindi_V") %>' ID="TitleHindi_V" runat="server"  ></asp:Label>
                                              
                                                       </ItemTemplate>
                                                 </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2325;&#2366;&#2352; / Book Type">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("bookType") %>' ID="bookType" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                   <asp:TemplateField HeaderText="&#2348;&#2306;&#2337;&#2354; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325; / Bundle No.">
                                                 <ItemTemplate>
                                                 <asp:Label Text='<%#Eval("BundleNo_I") %>' ID="BundleNo_I" runat="server"  ></asp:Label>
                                                 </ItemTemplate>
                                                 </asp:TemplateField>
                                                  
                                                     <asp:BoundField DataField="TotalBook" HeaderText="&#2325;&#2369;&#2354; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2368; /Total Book" />
                                                  
                                                 </Columns>
                                                  <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                 </asp:GridView>

  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                               &nbsp;</td>
                                    </tr>
                                </table>
    <br /><br />
       
    </div>
</asp:Content>

