<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Servicios.aspx.cs" Inherits="pHosteria_Tesoro.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <style type="text/css">
        .style2
        {
            width: 100%;
        }
    .style3
    {
        height: 31px;
    }
    .style4
    {
        height: 31px;
        font-weight: bold;
        font-size: large;
    }
    .style5
    {
        font-size: large;
        font-weight: bold;
    }
    .style6
    {
        text-align: center;
    }
    .style7
    {
        color: #CCCCCC;
        font-weight: bold;
        font-size: x-large;
    }
    .style8
    {
        font-size: large;
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
                        style="font-weight: 700; font-size: x-large; text-align: center">
                        ADMINISTRACIÓN DE SERVICIOS</td>
                </tr>
                <tr>
                    <td class="style4">
                        NOMBRE:</td>
                    <td class="style3">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="style8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        DESCRIPCIÓN:</td>
                    <td>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="style8"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style5">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Button ID="btnGrabar" runat="server" Text="GRABAR" BackColor="#3399FF" 
                            CssClass="style7" Width="320px" onclick="btnGrabar_Click" />
                    </td>
                    <td class="style6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style6">
                        <asp:Button ID="btnLimpiar" runat="server" Text="LIMPIAR" BackColor="#3399FF" 
                            CssClass="style7" Width="320px" onclick="btnLimpiar_Click" />
                    </td>
                    <td class="style6">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblError" runat="server" 
                            style="font-size: large; font-style: italic; font-weight: 700; color: #FF3300"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:GridView ID="grdProductos" runat="server" style="font-size: x-large" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" 
                            >
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:ButtonField CommandName="Edit" HeaderText="Editar" ShowHeader="True" 
                                    Text="Editar" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
