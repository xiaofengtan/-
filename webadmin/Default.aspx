<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="webadmin._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        浙江嘉报设计印刷有限公司
    </h2>
    <p>
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </p>
    <p>
      
        <asp:GridView ID="GridView1" runat="server" Width="899px">
        </asp:GridView>
      
    </p>
</asp:Content>
