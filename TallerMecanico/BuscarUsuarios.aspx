<%@ Page Title="Buscar Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BuscarUsuarios.aspx.cs" Inherits="TallerMecanico.BuscarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-4">
        <h2>Buscar Usuarios</h2>
        
        <div class="row mb-3">
            <div class="col-md-8">
                <label for="TxtFiltro" class="form-label">Filtrar por Nombre</label>
                <asp:TextBox ID="TxtFiltro" runat="server" CssClass="form-control" 
                             OnTextChanged="TxtFiltro_TextChanged" AutoPostBack="true" 
                             placeholder="Escribe para filtrar..." />
            </div>
            <div class="col-md-8">
                <label for="TxtAceptar" class="form-label">Escribe el ID para actualizar</label>
                <asp:TextBox ID="TxtAceptar" runat="server" CssClass="form-control" 
                     AutoPostBack="true" 
                     placeholder="Escribe ID..." />
                
                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" CssClass="btn btn-primary w-100" OnClick="BtnAceptar_Click" />
            </div>
        </div>

        <div class="container mt-3">
            <div class="row">
                <div class="col-12">
                    <asp:GridView ID="GvClientes" runat="server" AutoGenerateColumns="True" 
                                    CssClass="table table-bordered table-striped" 
                                    OnSelectedIndexChanged="GvClientes_SelectedIndexChanged">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

