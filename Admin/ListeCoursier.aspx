<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Master.Master" AutoEventWireup="true" CodeBehind="ListeCoursier.aspx.cs" Inherits="BikeAble.Admin.ListeCoursier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <thead class="tbl-header">
            <tr>
                <th>ID</th>
                <th>Nom</th>
                <th>Prénom</th>
                <th>Email</th>
                <th>Date inscription</th>
                <th></th>
            </tr>            
        </thead>
        <tbody class="tbl-content">  
        <asp:Repeater ID="userList" runat="server">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="coursierName" runat="server" CommandArgument='<%# Eval("ID_usager") %>' Text='<%# DataBinder.Eval(Container.DataItem, "ID_usager") %>' />
                    </td>
                    <td>
                    <asp:Label ID="Label1" runat="server" CommandArgument='<%# Eval("lastName_usager") %>' Text='<%# DataBinder.Eval(Container.DataItem, "lastName_usager") %>' />
                        </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" CommandArgument='<%# Eval("firstName_usager") %>' Text='<%# DataBinder.Eval(Container.DataItem, "firstName_usager") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label4" runat="server" CommandArgument='<%# Eval("email_usager") %>' Text='<%# DataBinder.Eval(Container.DataItem, "email_usager") %>' />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" CommandArgument='<%# Eval("createdDate_usager") %>' Text='<%# DataBinder.Eval(Container.DataItem, "createdDate_usager") %>' />
                    </td>
                    <td>
                        <asp:LinkButton ID="del" OnClick="delCoursier_OnClick" CssClass="btn btn-warning delButton" runat="server" CommandArgument='<%# Eval("ID_usager") %>'><i class="fa fa-user-times"></i></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
            </tbody>    
    </table>
</asp:Content>
