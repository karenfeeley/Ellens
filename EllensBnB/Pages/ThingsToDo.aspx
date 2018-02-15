<%@ Page Title="" Language="C#" MasterPageFile="~/EllensSiteMaster.Master" AutoEventWireup="true" CodeBehind="ThingsToDo.aspx.cs" Inherits="EllensBnB.Pages.ThingsToDo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Ellen's B&amp;B - Things to Do</title>
	<meta charset = "utf-8"/>
	<meta name="description" content="Local tours, nearby restaurants and pubs and adventure activities in the area"/>
	<meta name = "viewport" content = "width = device-width, initial-scale = 1.0"/>        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div>
		<h1><a href ="/Pages/GalwayCity.aspx" style="display:block">Galway City</a></h1>
	</div>
	<div>
		<h1><a href = "/Pages/GalwayOther.aspx" style="display:block">Other nearby attractions</a></h1>
	</div>

</asp:Content>
