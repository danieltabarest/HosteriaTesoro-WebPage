<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reservas.aspx.cs" Inherits="pHosteria_Tesoro.WebForm7" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="AjaxControlToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 100%;
        }
        .style3
        {
            font-size: x-large;
        }
        .style4
        {
            font-size: large;
        }
        .cssTextoLinea
        {}
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <AjaxControlToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </AjaxControlToolkit:ToolkitScriptManager>
    
        <ContentTemplate>
            <table class="style2">
                <tr>
                    <td colspan="4" 
                        style="font-weight: 700; font-size: xx-large; text-align: center">
                        RESERVAS</td>
                </tr>
                <tr>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td class="style3">
                        <b>Fecha:</b></td>
                    <td>
                        <asp:Label ID="lblFecha" runat="server" CssClass="style4"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <b>Cliente:</b></td>
                    <td>
                        <asp:TextBox ID="txtCliente" runat="server" CssClass="cssTextoLinea"></asp:TextBox>
                        
                        <asp:ImageButton ID="btnConsultar" runat="server" Height="28px" 
                            ImageUrl="~/Imagenes/Buscar.jpg" onclick="btnConsultar_Click" Width="40px" />
                        
                    </td>
                    <div id="ocultar" runat=server>
                    <td colspan="2" class="style3">
                        <b>Cliente:   
                        <asp:Label ID="lblCliente" runat="server" CssClass="style4"></asp:Label>
                        </b>
                    </td>
                </tr>
                <tr>
                
                   <td class="style3">
                        <b>Empleado:</b></td>
                    <td colspan="3">
                        <asp:DropDownList ID="cboEmpleado" runat="server" CssClass="style4" 
                            Height="26px" Width="411px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <b>Promoción:</b></td>
                    <td>
                        <asp:DropDownList ID="cboPromocion" runat="server" CssClass="style4" 
                            AutoPostBack="True" 
                            
                            Width="219px">
                        </asp:DropDownList>
                    </td>
                    <td class="style3">
                        <b>Cabaña:</b></td>
                    <td>
                        <asp:DropDownList ID="cboCabaña" runat="server" CssClass="style4" 
                            AutoPostBack="True" onselectedindexchanged="cboCabaña_SelectedIndexChanged" 
                            >
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <b>Fecha Ingreso:</b></td>
                    <td>
                        
                        <asp:TextBox ID="txtFechaIngreso" runat="server"></asp:TextBox>
                        <AjaxControlToolkit:CalendarExtender ID="txtFechaIngreso_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtFechaIngreso" Format="dd/MM/yyyy">
                        </AjaxControlToolkit:CalendarExtender>
                    </td>
                    <td class="style3">
                        <b>Fecha Salida:</b></td>
                    <td>
                        <asp:TextBox ID="txtFechaSalida" runat="server"></asp:TextBox>
                        <AjaxControlToolkit:CalendarExtender ID="txtFechaSalida_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtFechaSalida" Format="dd/MM/yyyy">
                        </AjaxControlToolkit:CalendarExtender>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <b>Descripción:</b></td>
                    <td colspan="3">
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="cssTextoLinea" 
                            Width="475px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style3">
                        <b>Total:</b></td>
                    <td>
                        <asp:Label ID="lblTotal" runat="server" CssClass="style4"></asp:Label>
                    </td>
                    <td class="style3">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnGrabar" runat="server" Text="RESERVAR"
                             CssClass="cssBoton" onclick="btnGrabar_Click" />
                    </td>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnCerrarFactura" runat="server" Text="LIMPIAR" 
                            CssClass="cssBoton" onclick="btnCerrarFactura_Click"  
                             />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnCancelar" runat="server" CssClass="cssBoton" 
                            Text="CANCELAR" onclick="btnCancelar_Click" />
                    </td>
                    <td colspan="2" style="text-align: center">
                        &nbsp;</td>
                </tr>
                 
                </div>
                 
                <tr>
                    <td colspan="4">
                        <asp:Label ID="lblError" runat="server" 
                            
                            style="font-size: large; font-style: italic; color: #FF0000; font-weight: 700"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:GridView ID="grdDetalle" runat="server" CellPadding="4" ForeColor="#333333" 
                            GridLines="None" CssClass="style4">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <EditRowStyle BackColor="#999999" />
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#E9E7E2" />
                            <SortedAscendingHeaderStyle BackColor="#506C8C" />
                            <SortedDescendingCellStyle BackColor="#FFFDF8" />
                            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
