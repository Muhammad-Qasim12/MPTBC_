<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintVoucher.aspx.cs" Inherits="PrintVoucher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
         .btn {
             border-style: none;
border-color: inherit;
border-width: 0px;
background: #34A0C0;
border: 1px solid #2488A6;
padding: 0px 20px;
-moz-border-radius: 3px;
-webkit-border-radius: 3px;
-khtml-border-radius: 3px;
border-radius: 3px;
color: #fff;
cursor: pointer;
font-size: 15px;
         }

         /*#tbld td {
             line-height:2em;
         }*/
        </style>
</head>
<body>
    <form id="form1" runat="server">

        
                <div id="ExportDiv" style="font-family:Verdana;font-size:16px;">
        
<div style="width:20%;float:left;text-align:left;">
<img src="images/logo.png" />
</div>

 <div style="width:80%;float:right;font-weight:bold;text-align:center;">
      <strong>&#2350;.&#2346;&#2381;&#2352;. &#2346;&#2366;&#2336;&#2381;&#2351;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2344;&#2367;&#2327;&#2350;<br />
                &nbsp;&#2346;&#2369;&#2360;&#2381;&#2340;&#2325; &#2349;&#2357;&#2344;
               
                &#2309;&#2352;&#2375;&#2352;&#2366; &#2361;&#2367;&#2354;&#2381;&#2360;, &#2332;&#2375;&#2354; &#2352;&#2379;&#2337; , &#2349;&#2379;&#2346;&#2366;&#2354; -&nbsp; 462011</strong>
</div>

<div style="text-align:center;font-size:18px;line-height:2em;">
    वाउचर
</div>

<div style="float:left;text-align:left;margin-top:21px;">
    <table style="border-collapse:collapse;">
        <tr style="border-style:solid;border-width:1px;border-color:lightgray;">
            <td style="line-height:2em;padding-left:7px;">शाखा का नाम:&nbsp;&nbsp;&nbsp;</td>
            <td style="padding-right:7px;font-weight:bold"><%=txtDepartmentName_V%></td>
        </tr>
        <tr style="border-style:solid;border-width:1px;border-color:darkgray;">
                <td style="line-height:2em;padding-left:7px;">&#2342;&#2375;&#2351;&#2325; &#2325;&#2381;&#2352;&#2350;&#2366;&#2306;&#2325;:&nbsp;&nbsp;&nbsp;</td>
                     <td style="padding-right:7px;font-weight:bold;"><%=txtDeyakNo_V%></td> 
                  
             </tr>
    </table>
</div>

    <div style="float:right;text-align:center;margin-top:21px;">
    <table style="border-collapse:collapse;">
        <tr style="border-style:solid;border-width:1px;border-color:lightgray;">
            <td style="line-height:2em;padding-left:3px;">लेखा शीर्ष:&nbsp;&nbsp;&nbsp;</td>
            <td style="padding-right:3px;font-weight:bold;"><%=txtLekhaSheersh_V%></td>
        </tr>
        <tr style="border-style:solid;border-width:1px;border-color:darkgray;">
                <td style="line-height:2em;padding-left:3px;">मद:&nbsp;&nbsp;&nbsp;</td>
                     <td style="padding-right:3px;font-weight:bold;"><%=txtMad_V%></td> 
                  
             </tr>
          <tr style="border-style:solid;border-width:1px;border-color:darkgray;">
                <td style="line-height:2em;padding-left:7px;">कुल बजट प्राबधान:&nbsp;&nbsp;&nbsp;</td>
                     <td style="padding-right:7px;font-weight:bold;"><%=txtTotalBudjut_N%></td> 
                  
             </tr>
          <tr style="border-style:solid;border-width:1px;border-color:darkgray;">
                <td style="line-height:2em;padding-left:7px;">पिछले बिल तक व्यय:&nbsp;&nbsp;&nbsp;</td>
                     <td style="padding-right:7px;font-weight:bold;"><%=txtPreviousBillAmount_N%></td> 
                  
             </tr>
    </table>
</div>

<div style="float:left;text-align:left;margin-top:21px;position:relative;">
<div>
    1. कर्मचारी अथवा पार्टी का नाम जिसे भुगतान / समायोजन होना है:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtPartyName_V%></span>
</div>
    <div style="line-height:2em;">
    2. भुगतान हेतु बैंक का नाम, खाता क्र. एवं I.F.S.C Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=lblBankIFSCCode%></span>
</div>
    <div style="line-height:2em;">
    3. स्वीकृति योग्य कुल राशि रू: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtSanctionedAmount_N%></span>
</div>
    <div style="line-height:2em;">
    4. समायोजन राशि रू. / 2% आयकर:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtSamayojanAmount_N%></span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;भुगतान राशि रू:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtPayAmount_N%></span>
</div>
       <div style="line-height:2em;">
    5. पार्टी का बिल क्रमांक/दिनांक: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtPartyBillNo_V%>/<%=txtPartyBillDate_D%></span>
</div>
     <div style="line-height:2em;">
    6. निगम आदेश क्रमांक/दिनांक: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtNigamOrderNo_V%>/<%=txtNigamOrderDate_D%></span>
</div>
      <div style="line-height:3em;">प्रबंध संचालक / महाप्रबंधक महोदय द्वारा नसती के नोटशीट<span style="text-align:right;float:right;">कर्मचारी के हस्ताक्षर</span></div>
     <div style="line-height:2em;">प्रष्ठ:&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtNoteSheetNo%></span>&nbsp;&nbsp;&nbsp;पर दिनांक:&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtNoteSheetDate%>&nbsp;&nbsp;&nbsp;</span>को प्रस्तावित

         <div style="float:right;text-align:center;padding-left:20px;">
             नाम/पद.....................................<span style="font-weight:bold;"></span>
         </div>

     </div>
 
     <div style="line-height:2em;">
    7. शाखा प्रभारी द्वारा स्वीकृत / अनुशंसित राशि रु: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtSanctionedAmountByBranchOfficer_N%></span>/-
</div>
     <div style="line-height:3em;float:right;font-family:'Segoe UI Symbol';">
    शाखा प्रभारी के हस्ताक्षर.........................
</div>

      <div style="line-height:2em;font-weight:bold;"><br />वित्त्त कक्ष का भुगतान आदेश</div>
     <div style="line-height:2em;">
          राशि रू:&nbsp;&nbsp;<span style="font-weight:bold;"><%=lblTotalAccountSectionAmt%></span>&nbsp;&nbsp;(शब्दों में):&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=lblTotalAccountSectionAmt_Words%></span>&nbsp;&nbsp;&nbsp;को देयक नियमानुसार पारित |
         </div>
     <div style="line-height:2em;">
    1. समायोजन राशि रू: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtSamayojanAmount_N_Account%></span>
</div>
     <div style="line-height:2em;">
    2. भुगतान राशि रू: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-weight:bold;"><%=txtPayAmount_N_Account%></span>
</div>

     <div style="line-height:3em;font-family:'Segoe UI Symbol';text-align:right;">
    वरिष्ठ प्रबंधक, वित्त्त के हस्ताक्षर.........................
</div>

    <div style="line-height:2em;">
        आवासीय सम्परीक्ष द्वारा सत्यापन के लिये स्थान
        </div>
    
</div>  
             
</div>
            
        
       
<div style="float:left;text-align:left;margin-top:544px;position:relative;">
      <input type="button" id="btnp" class="btn" value="Print" onclick="return PrintPanel();" /></div>

    </form>

    
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("ExportDiv");
            //document.getElementById("btnp").style.display = 'none';
              var printWindow = window.open('', '', 'height=400,width=800');
              printWindow.document.write('<html><head><title>Voucher</title>');
              printWindow.document.write('</head><body >');
              printWindow.document.write(panel.innerHTML);
              printWindow.document.write('</body></html>');
              printWindow.document.close();
              setTimeout(function () {
                  printWindow.print();
              }, 500);
              return false;
          }</script>
</body>
</html>
