<%@ Page Language="C#" AutoEventWireup="true" CodeFile="imageSearch.aspx.cs" Inherits="imageSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text=" Search" 
            OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <br />
        <asp:DataList ID="dlSearch" runat="server" Width="900px">     
          <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("Url") %>'><img src='<%#Eval("Url") %>' width="250" height="200px"/></asp:HyperLink>
                <asp:LinkButton ID="LinkButton2" runat="server" Text='<%#Eval("Title") %>' PostBackUrl='<%#Eval("OriginalContextUrl") %>'> </asp:LinkButton>
                
            </ItemTemplate> 
            <FooterTemplate>
                <asp:Label Visible='<%#bool.Parse((dlSearch.Items.Count==0).ToString())%>' runat="server"
                  ID="lblNoRecord" Text="No Record Found!"></asp:Label>
           </FooterTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
