<%@ Page Title="&#2350;.&#2346;&#2381;&#2352; &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350; / M.P. TBC" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DistributeYojnaBookWithBarcode.aspx.cs" Inherits="Depo_DistributeYojnaBookWithBarcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="box table-responsive"> 
     <div class="card-header">    <h2>&#2348;&#2366;&#2352;&#2325;&#2379;&#2337; &#2342;&#2381;&#2357;&#2366;&#2352;&#2366; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; </h2></div> 
       <table>
    <tr><td class="auto-style1">&#2330;&#2366;&#2354;&#2366;&#2344; &#2344;&#2306;&#2348;&#2352; / Chalan No. </td> <td class="auto-style1"><asp:DropDownList ID="ddlChallano" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlChallano_SelectedIndexChanged"></asp:DropDownList> </td> </tr>
     <tr><td>&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2325;&#2366; &#2344;&#2366;&#2350; </td><td><asp:DropDownList ID="ddlBookName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlBookName_SelectedIndexChanged"></asp:DropDownList> </td>



     </tr>
   
     <tr><td>&#2348;&#2306;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; / Bundle No. </td><td>
         <asp:TextBox ID="txtBundlenNo" runat="server" AutoPostBack="true" OnTextChanged="Checkbarcode"  onkeyup='javascript:tbx_fnSignedNumericCheck(this);'  ></asp:TextBox> </td>



     </tr>
     <tr><td>&#2309;&#2306;&#2340;&#2367;&#2350; &#2348;&#2339;&#2381;&#2337;&#2354; &#2344;&#2306;&#2348;&#2352; </td><td>
       
         <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
       
         </td>



     </tr>
     <tr><td>प्रदाय की जाने वाली :
       
       पैक बंडलो की संख्या :  <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
         लूज पुस्तकों की संख्या :  <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
         </td><td>
       
             प्रदाय किये जा चुके पैक बंडलो की संख्या:
       
         <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
       
         </td>



     </tr>
     <tr><td colspan="2">
         <asp:Button ID="Button2" runat="server" CssClass="btn" OnClick="Button2_Click1" Text="लूज बण्डल की जानकारी डाले " />
         </td>



     </tr>
        <tr><td colspan="2">
            <asp:GridView ID="grdPrinterBundleDetails" runat="server" AutoGenerateColumns="False" CssClass="tab" DataKeyNames="StockDetailsChildID_I" OnRowDeleting="grdPrinterBundleDetails_RowDeleting">
                                                 <Columns>
                                                  


                                                     <asp:TemplateField HeaderText="&amp;#2354;&amp;#2370;&amp;#2360; &amp;#2348;&amp;#2306;&amp;#2337;&amp;#2354;/loose">
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
                                                             <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("StockDetailsChildID_I") %>'  />
                                                             <asp:CheckBoxList ID="ChkLooseBundleList" runat="server" RepeatColumns="7">
                                                             </asp:CheckBoxList>
                                                         </ItemTemplate>
                                                     </asp:TemplateField>
                                                     <asp:CommandField ShowDeleteButton="True" />
                                                 </Columns>
                                                  <PagerStyle CssClass="Gvpaging" />
                                                                <EmptyDataRowStyle CssClass="GvEmptyText" />
                                                 </asp:GridView></td> </tr>
        <tr><td colspan="2">
            <asp:Button ID="Button1" runat="server" CssClass="btn" OnClick="Button1_Click" Text="Save" Visible="False" />
            </td> </tr>
    </table>
      </div>
     <div id="fadeDiv" class="modalBackground" style="display: none;" runat="server" >
            </div>
            <div id="Messages" style="display: none;" class="popupnew" runat="server" >
                <h2>
                  
                </h2>
                <div class="msg MT10">
                    <p>
                   
                       &#2351;&#2375; &#2348;&#2306;&#2337;&#2354; &#2354;&#2370;&#2332; &#2348;&#2306;&#2337;&#2354; &#2361;&#2376; &#2325;&#2371;&#2346;&#2351;&#2366; &#2354;&#2370;&#2332; &#2330;&#2375;&#2325; &#2348;&#2377;&#2325;&#2381;&#2360; &#2325;&#2379; &#2330;&#2375;&#2325; &#2325;&#2352;&#2375; &#2344;&#2361;&#2368;&#2306; &#2340;&#2379; &#2358;&#2375;&#2359; &#2348;&#2330;&#2368; &#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2346;&#2381;&#2352;&#2342;&#2366;&#2351; &#2361;&#2379; &#2332;&#2366;&#2351;&#2327;&#2368; !
                    click="Button2_Click" />
            </div></div> 
</asp:Content>

