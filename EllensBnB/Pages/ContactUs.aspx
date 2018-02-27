<%@ Page Title="" Language="C#" MasterPageFile="~/EllensSiteMaster.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="EllensBnB.Pages.ContactUs1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<title>Ellen's B&amp;B - Contact Us</title>
	<meta charset="utf-8">
	<meta name="description" content="Ellen's B&amp;B is the gateway to the West with easy access to the picturesque landscape of Connemara,
	Clifden and The Cliffs of Moher. 5 minutes drive by car/taxi or 25 minutes on foot will bring you to the bustling heart of Galway City
	where you can enjoy exploring the medieval streets of Galway - The city of Tribes.
	Contact us form, trip advisor certificates for 2015 and 2016">
	<meta name="keywords" content="best b and b;galway b&amp;b, great b&amp;bs in galway,cheap b&amp;bs in galway, galway guesthouses,
	b&amp;bs near salthill galway,award winning,tripadvisor 2015,tripadvisor 2016">
	<meta name="viewport" content="width=device-width, initial-scale=1.0">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<button onclick="topFunction()" id="topBtn" title="Go to top">Top</button>
    <div role ="main" id="leftcol">
		<div class="bookingOption">
			<asp:Button ID="MakeNewReservation" runat="server" Text="Make New Reservation" CssClass="bookingOption" OnClick="MakeNewReservation_Click" />
			<asp:Button ID="UpdateExistingReservation" runat="server" Text="Update Existing Reservation" CssClass ="bookingOption" OnClick="UpdateExistingReservation_Click"/>
			
		</div>

		<div id="panels">
			<!--Default on all to be set to invisible-->
			<!--Appear when user clicks Make New Reservation button-->
			

			<asp:ScriptManager ID="ScriptManager1" runat="server">
			</asp:ScriptManager>


			<asp:UpdatePanel ID="UpdatePanelCalendar" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<p class = "bookingOption">Please select dates to check room availibility</p>					
					<asp:Calendar ID="EllensWebCalendar" runat="server" OnDayRender="EllensCalendar_DayRender" OnSelectionChanged="EllensCalendar_SelectionChanged"></asp:Calendar>
					<asp:ListBox runat="server" ID="lstUserSelectedDates"></asp:ListBox>
					<asp:Button runat="server" Text="Select Dates" ID="btnSelectDates" OnClick="btnSelectDates_Click" />
					<asp:Button runat="server" Text="Clear Dates" ID="btnClearDates" OnClick="btnClearDates_Click" />
					<asp:Button ID="CheckAvailabilitySelectedDates" runat="server" Text="Check Availability" />
					
				</ContentTemplate>

			</asp:UpdatePanel>

			<asp:UpdatePanel ID="UpdatePanelReturnAvailability" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<p>The data grid is here.  Column headings and data binding to be set</p>
					<!-- Columns to be defined.  8 Options for field types - some below -->
					
					<asp:GridView ID="gvAvailability" runat="server" AutoGenerateColumns ="false">
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
					<asp:Label ID="lblCustomerEmail" runat="server" Text="Enter email address:  "></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerEmail" runat="server"></asp:TextBox>
					<br />
					<asp:Button ID="ReserveSelectedRooms" runat="server" Text="ReserveSelectedRooms" />
				</ContentTemplate>
			</asp:UpdatePanel>
			
			<asp:UpdatePanel ID="RegisterNewCustomer" runat="server">
				<ContentTemplate>
					<asp:Label ID="lblEnteredCustomerEmail" runat="server" Text="">
						The inner HTML on this label needs to be set to the customer email provided
					</asp:Label>
					<br />
					<asp:Label ID="lblCustomerName" runat="server" Text="Name:  "></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
					<br />
					<asp:Label ID="lblCustomerPhone" runat="server" Text="Telephone:  "></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerPhone" runat="server"></asp:TextBox>
					<br />
					<asp:Label ID="lblCustomerCountry" runat="server" Text="Country"></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerCountry" runat="server"></asp:TextBox>
					<br />
					
					<asp:Button ID="CreateNewAccount" runat="server" Text="Create New Account" />
				</ContentTemplate>

			</asp:UpdatePanel>
			<asp:UpdatePanel ID="BookingData" runat="server">
				<ContentTemplate>
					<p>Confirm number of guests for selected room(s):</p>
					<asp:Label ID="lblTaraSuite" runat="server" Text="Tara Suite"></asp:Label> &nbsp &nbsp
					<asp:DropDownList ID="drpTaraSuite" runat="server" Width="50px">
						<asp:ListItem Value="0"></asp:ListItem>
						<asp:ListItem Value ="1"></asp:ListItem>
					</asp:DropDownList>&nbsp &nbsp
					<asp:Label ID="lblLirSuite" runat="server" Text="Lir Suite"></asp:Label>&nbsp &nbsp
					<asp:DropDownList ID="drpLirSuite" runat="server" Width="50px">
						<asp:ListItem Value="0"></asp:ListItem>
						<asp:ListItem Value ="1"></asp:ListItem>
						<asp:ListItem Value ="2"></asp:ListItem>
					</asp:DropDownList>&nbsp &nbsp
					<asp:Label ID="lblBoyneSuite" runat="server" Text="Boyne Suite"></asp:Label>&nbsp &nbsp
					<asp:DropDownList ID="drpBoyneSuite" runat="server" Width="50px">
						<asp:ListItem Value="0"></asp:ListItem>
						<asp:ListItem Value ="1"></asp:ListItem>
						<asp:ListItem Value ="2"></asp:ListItem>
						<asp:ListItem Value ="3"></asp:ListItem>
					</asp:DropDownList>&nbsp &nbsp
					<asp:Label ID="lblKellsSuite" runat="server" Text="Kells Suite"></asp:Label>&nbsp &nbsp
					<asp:DropDownList ID="drpKellsSuite" runat="server" Width="50px">
						<asp:ListItem Value="0"></asp:ListItem>
						<asp:ListItem Value ="1"></asp:ListItem>
						<asp:ListItem Value ="2"></asp:ListItem>
						<asp:ListItem Value ="3"></asp:ListItem>
						<asp:ListItem Value ="4"></asp:ListItem>
					</asp:DropDownList>&nbsp &nbsp
					<br />
					<p>Add any additional notes or comments here (e.g. Early or late arrival, allergies, etc.):</p>
					<asp:TextBox ID="txtCustomerBookingNotes" runat="server"></asp:TextBox>
					<br />
					<asp:Button ID="ConfirmBooking" runat="server" Text="Confirm Booking" />

				</ContentTemplate>				

			</asp:UpdatePanel>
			<asp:UpdatePanel ID="UpdatePanelBookingConfirmation" runat="server">
				<ContentTemplate>
					<h2>Thank you for your reservation.</h2>
					<p>Your booking reference number is: <span id="BookingIDreference">0</span></p>
				</ContentTemplate>

			</asp:UpdatePanel>


		</div>
		

	</div>
	
	<div role="complementary" id="rightcol"> 
		<!--
		<form method="get">
			<input class="search" type="search" name="keyword" id="keyword" placeholder="Search here..." >
			<input class="search" type="submit" value="Go">

		</form> -->
		<h3>Ellen Smith Bed &amp; Breakfast</h3>
		<p>12 St Bridgets Terrace,</p>
		<p>Galway.</p>
		<p>Tel:+353(0)87 234 5678</p>
		<p><img runat="server" src="~/Content/caImages/tn/tripadvisor2016.jpg" width="200" height="150" alt="Trip Advisor Cert 2016"></p>
		<p><img runat="server" src="~/Content/caImages/tn/tripadvisor2015.jpg" width="200" height="150" alt="Trip Advisor Cert 2015"></p>

	</div> <!--end of right column-->
</asp:Content>
