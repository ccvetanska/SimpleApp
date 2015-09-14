<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToDos.aspx.cs" Inherits="SimpleApp.ToDos" EnableEventValidation="false" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>To Dos list.</h2>
    </hgroup>

    <asp:Repeater ID="rptToDos" runat="server" OnItemCommand="rptToDos_ItemCommand">
        <HeaderTemplate>
            <table border="1" width="100%">
                <tr>
                    <th>Text</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td><%# DataBinder.Eval(Container.DataItem, "Text").ToString() %></td>
                <td>
                    <div style="text-align: center">
                        <span>Completed: <span>
                            <asp:CheckBox
                                ID="CheckBoxCompeleted"
                                runat="server"
                                AutoPostBack="True"
                                OnCheckedChanged="CheckBoxCompeleted_CheckedChanged"
                                Checked='<%# Convert.ToBoolean(Eval("Completed")) ? true : false %>' />
                            <asp:HiddenField ID="hiddenchkBox" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id").ToString() %>' />
                            <asp:Button
                                runat="server"                                
                                Text="Delete"
                                ID="btnDelete" 
                                CommandName="del" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Id").ToString() %>' />
                    </div>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label Text="Add new item" runat="server" ID="lblAdd" />
    <asp:TextBox runat="server" ID="tbAddNew" Width="314px"></asp:TextBox>
    <asp:Button runat="server" ID="btnAdd" Text="Add" />

</asp:Content>
