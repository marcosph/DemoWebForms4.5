<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApiWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<script type="text/javascript">
    $(document).ready(function () {
        
      var uri = document.location.origin + "/api/Usuarios/" + "1" ;
        $.ajax({
            cache: false,
            type: "GET",
            timeout: 5000,
            url: uri,
            success: function (msg) {
                alert(msg);
            },
            error: function (msg) {
                doSomethingMoreClever();
            }
        });
        
    });
    
</script>
</asp:Content>
