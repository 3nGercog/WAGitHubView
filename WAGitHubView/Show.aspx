<%@ Page Language="C#"  Async="true" AutoEventWireup="true" ClientIDMode="Static" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="Show.aspx.cs" Inherits="WebAppGitHubView.Show" %>

<asp:Content ID="ContentShowHead" runat="server" ContentPlaceHolderID="head">
    <link href="Style/StyleShowPage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="ContentShowBody" ContentPlaceHolderID="default" runat="server" >
    <div id="container" runat="server"><br />
    <ul style="list-style-type: none;">
        <li>
            <input id="input_back" type="button" class="list_button_inline" name="" value="BACK" onclick="bt_back_Click()" />
        </li>
        <li>
            <asp:Label ID="message" CssClass="validation_error" Text="" runat="server" />
        </li>
    </ul>

        <%--<asp:Button ID="bt_back" CssClass="list_button_inline"  runat="server" Text="BACK" OnClick="bt_back_Click"/>--%>
         <br />
    </div>
</asp:Content>
