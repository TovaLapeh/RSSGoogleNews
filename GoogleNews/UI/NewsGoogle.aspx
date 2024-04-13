<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsGoogle.aspx.cs" Inherits="tovi.UI.newsGoogle" %>

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.3/jquery.min.js"></script>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>News</title>
     <link rel="stylesheet" type="text/css" href="StyleNews.css"><link />
    <script src="scriptNews.js"></script>
    <h1>Google News</h1>
</head>
<body>
    <form id="formNews" runat="server">
        <main class="main-div-news">
            <asp:Repeater ID="RepeaterNews" runat="server">
                <ItemTemplate>
                    
                    <section class="news-item">
                        <a href="javascript:void(0);" onclick="toggleContent(this)">
                            <h3><%# Eval("Title") %>!!!!</h3>
                        </a>
                        <div class="google-body" style="display: none;">
                            <p><%# Eval("body") %></p>
                            <a href='<%# Eval("Link") %>'>לכתבה המלאה-</a>
                        </div>
                    </section>
                </ItemTemplate>
            </asp:Repeater>
        </main>
    </form>
</body>
</html>