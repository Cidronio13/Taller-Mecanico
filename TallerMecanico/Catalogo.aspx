<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TallerMecanico.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Catálogo de Servicios</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }
        .container {
            width: 80%;
            margin: auto;
            overflow: hidden;
        }
        header {
            background: #333;
            color: #fff;
            padding: 20px 0;
            text-align: center;
        }
        .catalogo {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            gap: 20px;
            padding: 20px 0;
        }
        .servicio {
            background: #fff;
            padding: 20px;
            width: 250px;
            text-align: center;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .servicio img {
            width: 100%;
            border-radius: 10px;
        }
    </style>
</head>
<body>
    <header>
        <h1>Taller Mecánico - Catálogo de Servicios</h1>
    </header>
    
    <div class="container">
        <section class="catalogo">
            <div class="servicio">
                <img src="Imagenes/Img15.jpg" alt="Servicio al motor">
                <h3>Servicio al motor</h3>
            </div>
            <div class="servicio">
                <img src="https://th.bing.com/th/id/OIP.76A182xWwQgV-GE9nxW9rwHaE1?rs=1&pid=ImgDetMain" alt="Servicio 2">
                <h3>Cambio de Aceite</h3>
            </div>
            <div class="servicio">
                <img src="https://th.bing.com/th/id/R.b5f31119b390ece11f2b15902034b4f0?rik=Wyp7KyVwZNSUWg&pid=ImgRaw&r=0" alt="Servicio 3">
                <h3>Revisión de frenos</h3>
            </div>
        </section>
    </div>
</body>
</html>
</asp:Content>
