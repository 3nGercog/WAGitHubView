<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/GitHubViewSite.Master" CodeBehind="Default.aspx.cs" Inherits="WebAppGitHubView.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="Scripts/jquery-1.8.2.js"></script>
   </asp:Content>
<asp:Content ID="Content2"
    ContentPlaceHolderID="default" runat="Server">
    <div class="staticData">
        <fieldset style="width: 50%; text-align: center">
            <legend>
                <h1 style="text-align: center; color:peru">Login GitHub</h1>
            </legend>
            <ol class="login">
                <li>
                    <asp:Label CssClass="user" Text="Login" runat="server" /><br />
                    <input type="text" runat="server" id="text" name="" style="width: 30%;" />
                    <asp:RequiredFieldValidator CssClass="validation_error" ID="regText" ErrorMessage="Поле login обязательное для заполнения" ControlToValidate="text" runat="server" />
                </li>
                <li>
                    <asp:Label CssClass="user" Text="Password" runat="server" />
                    <br /><input type="password" runat="server" id="password" name="" style="width: 30%" />
                    <asp:RequiredFieldValidator CssClass="validation_error" ID="regPassword" ErrorMessage="Поле password обязательное для заполнения" ControlToValidate="password" runat="server" />
                </li>
                <li>
                    <asp:Label ID="message" CssClass="validation_error" Text="" runat="server" />
                </li>
            </ol>
            <asp:Button ID="buttonSubmit" runat="server" Text="Submit"
                OnClick="text_Click"></asp:Button>
        </fieldset>
        <div class="image">
            <asp:Image ID="htmlImg" runat="server" Visible="false" />
        </div>
    </div>

    <div class="dynamicData">

        <asp:Table ID="tableRepos" runat="server" Visible="false">
        </asp:Table>
    </div>

</asp:Content>
