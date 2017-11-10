<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="pHosteria_Tesoro.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            font-size: large;
            font-weight: bold;
        }
        .style4
        {
            font-weight: bold;
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="style2">
                <tr>
                    <td colspan="2" 
                        style="font-weight: 700; text-align: center; font-size: x-large">
                        ADMINISTRACIÓN DE EMPLEADOS</td>
                </tr>
                <tr>
                    <td class="style3">
                        DOCUMENTO:</td>
                    <td>
                        <asp:TextBox ID="txtDocumento" runat="server" style="font-size: large"></asp:TextBox>
                        <asp:ImageButton ID="btnConsultar" runat="server" Height="28px" 
                            ImageUrl="~/Imagenes/Buscar.jpg" onclick="btnConsultar_Click" Width="40px" />
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        NOMBRE:</td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server" style="font-size: large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        PRIMER APELLIDO:</td>
                    <td>
                        <asp:TextBox ID="txtPrimerApellido" runat="server" style="font-size: large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        SEGUNDO APELLIDO:</td>
                    <td>
                        <asp:TextBox ID="txtSegundoApellido" runat="server" style="font-size: large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        DIRECCIÓN:</td>
                    <td>
                        <asp:TextBox ID="txtDireccion" runat="server" style="font-size: large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        TELÉFONO:</td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" style="font-size: large"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="btnGrabar" runat="server" BackColor="Blue" CssClass="style4" 
                            ForeColor="White" Height="50px" onclick="btnGrabar_Click" Text="GRABAR" 
                            Width="240px" />
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnLimpiar" runat="server" BackColor="Blue" CssClass="style4" 
                            ForeColor="White" Height="50px" Text="LIMPIAR" Width="240px" 
                            onclick="btnLimpiar_Click" />
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                        <asp:Button ID="btnActualizar" runat="server" BackColor="Blue" 
                            CssClass="style4" ForeColor="White" Height="50px"  
                            Text="ACTUALIZAR" Width="240px" onclick="btnActualizar_Click" />
                    </td>
                    <td style="text-align: center">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" 
                            style="font-size: large; font-style: italic; font-weight: 700; color: #FF6600"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
