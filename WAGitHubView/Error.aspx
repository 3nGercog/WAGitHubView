<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WAGitHubView.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div onclick="error_Click()" style = "position:absolute; width:100%; height:100%; text-align:center; background-image: url('Image/404_26_939px.jpg')">
        <div>
            <h6>
                <asp:Label ID="message" Text="" runat="server" />

            </h6>
        </div>
<%--        <img style="width=100%; height=100%; text-align:center;" src="Image/404_26_939px.jpg" alt="Alternate Text" />--%>
    </div>
    </form>
</body>
</html>
