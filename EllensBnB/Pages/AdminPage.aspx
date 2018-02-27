<%@ Page Title="" Language="C#" MasterPageFile="~/EllensSiteMaster.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EllensBnB.Pages.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<button onclick="topFunction()" id="topBtn" title="Go to top">Top</button>
    <div role ="main" id="ReportsPage">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        
            <asp:UpdatePanel ID="Reports" runat="server">
                <ContentTemplate>
                    <p>Select reports to run</p>
                    <!--<asp:Label ID="ReportsList" runat="server" Text="Reports"></asp:Label>--> &nbsp &nbsp
                    <asp:DropDownList ID="drpReportsList" runat="server" Width="400px">
                        <asp:ListItem Value="All bookings in date order"></asp:ListItem>
                        <asp:ListItem Value ="Future bookings"></asp:ListItem>
                        <asp:ListItem Value ="Unpaid bookings"></asp:ListItem>
                        <asp:ListItem Value ="Customer distribution list"></asp:ListItem>
                        <asp:ListItem Value ="All bookings by customer"></asp:ListItem>
                    </asp:DropDownList>&nbsp &nbsp
                        <p>The data grid reports is here.  Column headings will come from individual reports, data binding to be set</p>
                    <!-- Columns to be defined.  8 Options for field types - some below -->
                    
                    <asp:GridView ID="gvReports" runat="server" AutoGenerateColumns ="false">
                        <Columns>                            
                            <asp:Boundfield HeaderText ="Date Selected"/>
                            <asp:BoundField HeaderText ="Room 1" />
                            <asp:BoundField HeaderText ="Room 2" />
                            <asp:Templatefield></asp:Templatefield>
                            <asp:HyperLinkField />
                            <asp:CommandField />
                            <asp:CheckBoxField />
                        </Columns>
                        
                    </asp:GridView> 
    
                </ContentTemplate>                

            </asp:UpdatePanel>


    </div><!--end of reports-->

</asp:Content>
