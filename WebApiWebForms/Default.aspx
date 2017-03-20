<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApiWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <h2>Test Api</h2>
      <button id="get" class="btn btn-danger">Get Hello</button>
      <button id="getsingle" class="btn btn-danger">Get a Hello</button>
      <button id="post" class="btn btn-danger">Post Hello</button>
      <button id="put" class="btn btn-danger">Put Hello</button>
      <button id="delete" class="btn btn-danger">Delete Hello</button>
    </div>
    <hr />
    <table class="table table-bordered">
        <thead>
            <tr>
                <td>Nome</td>
            </tr>
        </thead>
        <tbody id="produtos">
        </tbody>
    </table>
<script type="text/javascript">
    $(document).ready(function () {
        var uri = document.location.origin + "/api/Usuarios";
        //Get
        $('#get').click(function (e) {
            e.preventDefault();
            var uri = document.location.origin + "/api/Usuarios/" + "1";
            $.getJSON(uri);
        });

        //Get Single
        $('#getsingle').click(function (e) {
            e.preventDefault();
            $.getJSON("api/Servicing/" + 1);
        });
        function CarregarProdutos() {
            $.getJSON(uri,
                function (data) {
                    $('#produtos').empty(); // Clear the table body.
                    var dataHTML = "";

                    // Loop through the list of products.
                    $.each(data, function (key, val) {
                        // Add a table row for the product.
                        dataHTML += '<tr><td>' + val.Nome + '</td></tr>';
                    });
                    $('#produtos').html(dataHTML);
                });
        }

        //Post
        $('#post').click(function (e) {
            e.preventDefault();
           
           
            var data = JSON.stringify({ Nome: "World" });
            
            $.ajax({
                url: uri,
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                data: data,
                success: function () {
                    CarregarProdutos();
                },
                error: function (request, message, error) {
                    handleException(request, message, error);
                }
            });
        });

        //Put
        $('#put').click(function (e) {
            e.preventDefault();
            var data = JSON.stringify({
                stuff: {
                    id: 1,
                    hello: "World"
                }
            });
            $.ajax({
                url: "api/Servicing/" + 1,
                type: "PUT",
                contentType: "application/json;charset=UTF-8",
                data: data
            });
        });

        //Delete
        $('#delete').click(function (e) {
            e.preventDefault();
            $.ajax({
                url: "api/Servicing/" + 1,
                type: "DELETE",
                contentType: "application/json;charset=UTF-8",
            });
        });
    });
    
</script>
</asp:Content>
