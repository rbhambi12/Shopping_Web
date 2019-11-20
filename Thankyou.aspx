<%@ Page Title="" Language="C#" MasterPageFile="~/Guest.master" AutoEventWireup="true" CodeFile="Thankyou.aspx.cs" Inherits="Thankyou" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 100%;text-align: center;">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>

        <asp:Button ID="Button1" runat="server" Text="OK" OnClick="Button1_Click"  class='btn btn-fefault cart' Width="184px" />
    </div>
    
    <img src="thanks.jpg" width="100%" />
</asp:Content>

