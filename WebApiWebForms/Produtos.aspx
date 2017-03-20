<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="WebApiWebForms.Produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Headers" runat="server">
    <script type="text/javascript">
       
       
        $(document).ready(function () {
            $('#btnPesquisar').on('click', function () {
                var uri = document.location.origin + "/api/Produtos/" + 1 + "/" + "Arroz";

            var jqxhr = $.ajax(uri)
                .done(function (data) {
                    $('#produtos').empty(); // Clear the table body.
                    var dataHTML = "";

                    // Loop through the list of products.
                    $.each(data, function (key, val) {
                        // Add a table row for the product.
                        dataHTML += '<tr><td>' + val.Nome + '</td></tr>';
                    });
                    $('#produtos').html(dataHTML);

                })
                .fail(function () {
                    alert("error");
                })
                .always(function () {
                    //alert("complete");
                });
            });
            //var Nome_ = $('#txtNome').val();
            //var id_ = $('#txtId').val();
            //var uri = document.location.origin + "/api/Produtos/" + 1 + "/" + "Arroz";
           
            //var jqxhr = $.ajax(uri)
            //    .done(function (data) {
            //        $('#produtos').empty(); // Clear the table body.
            //        var dataHTML = "";

            //        // Loop through the list of products.
            //        $.each(data, function (key, val) {
            //            // Add a table row for the product.
            //            dataHTML += '<tr><td>' + val.Nome + '</td></tr>';
            //        });
            //        $('#produtos').html(dataHTML);
                    
            //    })
            //    .fail(function () {
            //        alert("error");
            //    })
            //    .always(function () {
            //        //alert("complete");
            //    });
        });
        //function myLinkClickHandler() {
        //    var Nome_ = $('#txtNome').val();
        //    var id_ = $('#txtId').val();
            

        //    // Perform other work here ...

        //    // Set another completion function for the request above
        //    jqxhr.always(function () {
        //        alert("second complete");
        //    });

        //};
        //$("#txtPesquisar").on("click", myLinkClickHandler);
        //$(function () {

           
        //    //$('#tableprodutos').dataTable({
        //    //    "paging": true,
        //    //    "lengthChange": false,
        //    //    "searching": false,
        //    //    "ordering": true,
        //    //    "info": true,
        //    //    "autoWidth": false,
        //    //    'iDisplayLength': 2,
        //    //    "oLanguage": {

        //    //        "sZeroRecords": "Nenhum registro encontrado",
        //    //        "sInfo": "Mostrando _START_ / _END_ de _TOTAL_ registro(s)",
        //    //        "sInfoEmpty": "Mostrando 0 / 0 de 0 registros",
        //    //        "sInfoFiltered": "(filtrado de _MAX_ registros)",
        //    //        "oPaginate": {
        //    //            "sFirst": "Início",
        //    //            "sPrevious": "Anterior",
        //    //            "sNext": "Próximo",
        //    //            "sLast": "Último"
        //    //        }
        //    //    },
        //    //    "aaSorting": [],
        //    //});
        //});
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <div class="container">
       <h3>Produtos</h3> 
       <div class="row">
           <div class="text-right">
               <button class="btn btn-success">
                   <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                   Adicionar Produto
               </button>
           </div>           
       </div><br />
       <div class="row">
           <div class="form-inline">
               <div class="form-group">
                   <input type="text" class="form-control" placeholder="Buscar por Nome" id="txtNome" name="txtNome">
               </div>
               <div class="form-group">
                   <input type="text" class="form-control" placeholder="Buscar por ID" id="txtId" name="txtId">
               </div>
               <div class="form-group">
                   <button class="btn btn-success" id="btnPesquisar" name="btnPesquisar"> <span class="glyphicon glyphicon-search" aria-hidden="true"></span> Pesquisar</button>
               </div>
           </div>
       </div><br />
       <div class="row">          
           <div class="table-responsive">
               <table id="tableprodutos" class="table table-striped table-bordered" >
                   <thead>
                       <tr>
                           <th>Nome do Produto</th>
                           <%--<th style="width:14%;">Ações</th>--%>
                       </tr>
                   </thead>
                    <tbody id="produtos">
                    </tbody>
               </table>
           </div>
       </div>
   </div>
    


    
</asp:Content>
