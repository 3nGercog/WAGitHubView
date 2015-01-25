<%@ Page Language="C#" EnableSessionState="ReadOnly" MasterPageFile="~/GitHubViewSite.Master" AutoEventWireup="true" Async="true" CodeBehind="Second.aspx.cs" Inherits="WebAppGitHubView.Second" %>
<%@ PreviousPageType VirtualPath="~/Default.aspx" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
<asp:Content ID="Content4" 
  ContentPlaceHolderID="default" Runat="Server">
    <div id="commitInfo" runat="server">
    <ul style="list-style-type:none">
        <li>
            <asp:Label ID="message" CssClass="validation_error" Text="" runat="server" />
        </li>
        <li>
            <h1 id="h1" style="text-align: center; color: peru" runat="server"></h1>
        </li>
    </ul>
    </div>
</asp:Content>
