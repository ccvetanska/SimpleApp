<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleApp._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Welcome to Simple App, <u><%: User.Identity.Name %></u>.</h2>
            </hgroup>
            <p>
                Start creating and managing your tasks right now by clicking on <b>To Dos</b> in the top right corner of this page!
            </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>You are able to do the following:</h3>
    <ol class="round">
        <li class="one">
            <h5>Add To Do</h5>
            Add a new To Do task to your list. It is not completed by default.
        </li>
        <li class="two">
            <h5>Delete To Do</h5>
            Delete an existing To Do task.
        </li>
        <li class="three">
            <h5>Complete To Do</h5>
            Complete an existing To Do task. When it is completed it hides from the list.<br /> 
            You have to check the 'Show completed' option in order to see or delete the completed To Dos.
        </li>
    </ol>
</asp:Content>
