<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsEmpty.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.1.1.min.js"></script>    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <button id="btnSend" class="btn btn-success">Send</button></p>
            <h1><span id="results"></span></h1>
            <hr />
            <h3>
                <button id="button-container" name="button-container" class="btn btn-danger">Onclick</button>
                <span id="banner-message" style="display: none;">Hello</span></h3>
            <hr />
            
            
        </div>
    </form>
    <script type="text/javascript">
       
        // IIFE - Immediately Invoked Function Expression
        (function ($, window, document) {
            
            // The $ is now locally scoped 
            // Listen for the jQuery ready event on the document
            $("#btnSend").on("click", function (event) {
                event.preventDefault();
                var empObj = { nome: "casdfadsfadf", id: "1" };
                $.ajax({
                    url: "http://localhost:62540/home/produtos",
                    data: JSON.stringify(empObj),
                    type: "POST",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    success: function (result) {
                        $('#results').html(result);
                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                    }
                });
            });          
            $(function () {
                // The DOM is ready!
                var hiddenBox = $("#banner-message");
                $("#button-container").on("click", function (e) {
                    e.preventDefault();
                    hiddenBox.show();
                });

            });

            // The rest of the code goes here!

        }(window.jQuery, window, document));
  // The global jQuery object is passed as a parameter
      
        //$(document).ready(function () {            
           
            
        //});

        
    </script>
</body>
</html>
