<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministrarServicio.aspx.cs" Inherits="TallerMecanico.AdministrarServicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
    .form-container {
        background-color: white;
        padding: 20px;
        border-radius: 10px;
        width: 400px;
        margin: auto;
        box-shadow: 0px 0px 10px gray;
        font-family: Arial;
    }
    .form-container h2 {
        text-align: center;
        margin-bottom: 20px;
    }
    .form-group {
        margin-bottom: 15px;
    }
    label {
        display: block;
        margin-bottom: 5px;
        font-weight: bold;
    }
    input[type="text"], input[type="password"], dropDownList {
        width: 100%;
        padding: 8px;
        box-sizing: border-box;
    }
    .btn-container {
        text-align: center;
        margin-top: 20px;
    }
    .btn {
        width: 120px;
        padding: 10px;
        margin: 5px;
        border: none;
        background-color: #007BFF;
        color: white;
        cursor: pointer;
        border-radius: 5px;
    }
    .btn:hover {
        background-color: #0056b3;
    }
</style>

<div class="form-container">
    <h2>Gestión de Servicios</h2>

    <div class="form-group">
    <label for="txtServicioID">Servicio ID:</label>
    <asp:TextBox ID="txtServicioID" runat="server" CssClass="form-control" ReadOnly="True" />
</div>

<div class="form-group">
    <label for="txtNombre">Nombre:</label>
    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
</div>

<div class="form-group">
    <label for="txtPrecio">Precio:</label>
    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
</div>

<div class="form-group">
    <label for="txtDescripcion">Descripcion:</label>
    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" />
</div>

    <div class="btn-container">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="btnBuscar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn" OnClick="btnCancelar_Click" />
    </div>
</div>
</asp:Content>
