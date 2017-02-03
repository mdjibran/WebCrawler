<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<title>Spider Search</title>
<style type="text/css">

body
{
    background-color:#A9E2F3;
}
    .style1
    {
        font-family: "Comic Sans MS";
        text-decoration: underline;
        font-size: medium;
        color: #0000CC;
    }
</style>

</head>


<body >

<form id="form1" runat="server">
<div> 

 <div id="Div1" runat="server"><span class="style1">Are you happy with the results?</span>
      <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Yes" />
      <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="No" />
      </div>
      

       <div id="Div2" runat="server"><span class="style1">Rate our results on scale of 10?</span><br />
           <asp:RadioButton ID="RadioButton1" GroupName="rate" Text="1  " runat="server" />
           <asp:RadioButton ID="RadioButton2" GroupName="rate" Text="2  " runat="server" />
           <asp:RadioButton ID="RadioButton3" GroupName="rate" Text="3  " runat="server" />
           <asp:RadioButton ID="RadioButton4" GroupName="rate" Text="4  " runat="server" />
           <asp:RadioButton ID="RadioButton5" GroupName="rate" Text="5  " runat="server" />
           <asp:RadioButton ID="RadioButton6" GroupName="rate" Text="6  " runat="server" />
           <asp:RadioButton ID="RadioButton7" GroupName="rate" Text="7  " runat="server" />
           <asp:RadioButton ID="RadioButton8" GroupName="rate" Text="8  " runat="server" />
           <asp:RadioButton ID="RadioButton9" GroupName="rate" Text="9  " runat="server" />
           <asp:RadioButton ID="RadioButton10" GroupName="rate" Text="10  " runat="server" />
           <br />
           <asp:Button ID="Button4" runat="server" onclick="Button4_Click" Text="Button" />
           <br />

      </div>
    
  <br />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    <br /><br />
  <center><a href="Default.aspx">
      <img src="images/spiderLogo1.jpg" /></a> 
      
      <br /><br />
   <asp:TextBox ID="TextBox1" runat="server" Width="500px" Font-Bold="True"></asp:TextBox>
    &nbsp;
    <asp:Button ID="Button1" runat="server" Text="Search" onclick="Button1_Click" 
        Font-Bold="True" Height="33px" Width="97px" />
        
        <h5>
        <a href = "imageSearch.aspx">Images  |  |</a>
        
        <a href = "http://www.youtube.com/" target="_blank">Videos  |  |</a>

        <a href = "#">News    |  |</a>

        <a href = "https://mail.google.com/" target="_blank">Gmail   |  |</a>

        <a href = "https://login.yahoo.com/" target="_blank">Yahoo Mail</a>
        
        </h5>
        </center>

        
        <table border="1"> 
<asp:DataList ID="dl1" runat="server"> 

<HeaderTemplate> 
<b>Spider Search</b>

</HeaderTemplate> 
<itemtemplate> 
<tr> 
<td> 

<font color="red"><a target="_blank" href="<%#Eval("url")%>"><%#Eval("url")%></font><br />
<font><b style="font-size:20px" ><%#Eval("title")%></b></font> <br /></a>
<%#Eval("text").ToString().Length <= 160 ? Eval("text") : Eval("text").ToString().Substring(0, 160)+"..." %> 
<br />
<br /><br /><br />
</td> 

</tr> 
</itemtemplate> 

</asp:DataList> 
</table> 
<table width="100%" border="0"> 
<tr> 
<td> <asp:label id="lbl1" runat="server" BackColor="Yellow" BorderColor="Yellow" 
Font-Bold="True" ForeColor="#FF3300"></asp:label></td> 
</tr> 
<tr> 
<td> 
    <asp:button id="btnPrevious" runat="server" text="&lt;&lt; Previous" Width="110px" 
onclick="btnPrevious_Click" Font-Bold="True" Visible="False"></asp:button> 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
<asp:button id="btnNext" runat="server" text="Next &gt;&gt;" Width="110px" 
onclick="btnNext_Click" Font-Bold="True" Visible="False"></asp:button></td> 
</tr> 
</table> 
</div>
<center>
<img src="images/new.png" 
        style="height: 239px; width: 342px; text-align: center;" />
        </center>

</form>

</body>

</html>
