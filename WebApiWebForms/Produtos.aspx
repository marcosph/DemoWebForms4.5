<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="WebApiWebForms.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Produtos</h1><hr />
    <div id="form" class="container">
        <div class="row">
            <div class="col-lg-6">
                <div>
                    <div class="form-group">
                        <label>Nome</label>
                        <input type="text" class="form-control" id="nome" placeholder="Nome">                              
                    </div>
                    <button type="submit" id="submit" class="btn btn-success">Salvar</button>
                </div>
            </div>
            <div class="col-lg-6">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Nome</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Jose Maria</td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function ajax_request(url_, dados, callback) {
            alert("ddddd");
            $.ajax({
                type: 'POST',
                contentType: 'application/json',
                url: url_,
                data: dados ? JSON2.stringify(dados) : null,
                success: function (r) {
                    if (callback) callback(r.d);
                },
                error: function (xhr) {
                    if (xhr.responseText != "") {
                        var excecao = JSON2.parse(xhr.responseText);
                        alert(excecao.Message);
                    }
                }
            });
        }
        $("#submit").on("click", function () {
            Produto = new Object();
            Produto.Nome = $('#nome').val();
            productAdd(Produto);

            //var uri = document.location.origin + "/api/Usuarios";
            //alert(uri);
            //var order = {
            //    "Nome": "Marcos Paulo"
            //};
            //dados.Nome = $('#nome').val();
            //$.ajax({
            //    type: 'POST',
            //    url: uri,
            //    data: JSON.stringify(product),
            //    contentType: "application/json;charset=utf-8",
            //    dataType: 'json'
            //});          

        });
        function productAdd(product) {           
            var uri = document.location.origin + "/api/Usuarios";
            alert(uri);
            $.ajax({
                url: uri,
                type: 'POST',
                contentType:"application/json;charset=utf-8",
                data: JSON.stringify(product),
                success: function (product) {
                    productAddSuccess(product);
                },
                error: function (request, message, error) {
                    handleException(request, message, error);
                }
            });
        }

        
        function Produto() {
            var uri = document.location.origin + "/api/Usuarios/";
            return {
                add: function () {
                   
                   
                },
                edit: function (val) {
                    i = val;
                },
                delete: function (val) {
                    i = val;
                }, 
                validarformulario: function () {
                    return false;
                }
            };
        };
    </script>
</asp:Content>
