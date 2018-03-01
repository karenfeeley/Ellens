﻿<%@  Page Culture ="en-IE" Title="" Language="C#" MasterPageFile="~/EllensSiteMaster.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="EllensBnB.Pages.ContactUs1" %>
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
        <asp:SiteMapPath ID="SiteMapPath1" Runat="server"></asp:SiteMapPath>
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
					<asp:Button ID="CheckAvailabilitySelectedDates" runat="server" Text="Check Availability" OnClick="CheckAvailabilitySelectedDates_Click" />
					
				</ContentTemplate>
			</asp:UpdatePanel>



       	
		
		<asp:UpdatePanel ID="UpdatePanelReturnAvailability" runat="server" UpdateMode="Conditional">
				<ContentTemplate>
					<p>The data grid is here.  Column headings and data binding to be set</p>
					<!-- Columns to be defined.  8 Options for field types - some below -->

					<asp:GridView ID="gvAvailability" runat="server" AutoGenerateColumns ="False">
						<Columns>
							<asp:BoundField DataField="UserDate" HeaderText="Your selected dates"
								DataFormatString ="{0:d}" />
							<asp:BoundField DataField="RoomID" HeaderText="Room" />
							<asp:BoundField DataField="MaxCapacity" HeaderText="Max Capacity" />
							<asp:BoundField DataField="RoomRate" HeaderText="Rate" 
								DataFormatString ="{0:c}"/>
							<asp:TemplateField HeaderText ="No of Guests">
								<ItemTemplate>
									<asp:DropDownList ID="ddlUserGuests" runat="server" 
										
										DataField ="NumberOfGuests">
										
									</asp:DropDownList>
								</ItemTemplate>
							</asp:TemplateField>
							<asp:TemplateField HeaderText="Select">
								<ItemTemplate>									
									<asp:CheckBox ID="cbxUserSelection" runat="server" 
										checked ='<%# Convert.ToBoolean(Eval("UserSelected")) %>' />									
								</ItemTemplate>
							</asp:TemplateField>							
	
						</Columns>

					</asp:GridView>
					 
					<asp:Label ID="lblCustomerEmail" runat="server" Text="Enter email address:  " validationgroup="UpdatePanelReturnAvailabilityValidation"></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerEmail" runat="server" validationgroup="UpdatePanelReturnAvailabilityValidation"></asp:TextBox>
					<br />


					<asp:Button ID="ReserveSelectedRooms" runat="server" Text="ReserveSelectedRooms" OnClick="ReserveSelectedRooms_Click" validationgroup="UpdatePanelReturnAvailabilityValidation"/>
					<br />



                     <!--  Email TxtBox Validation PT  1 -->                         <!--not in use............enableclientscript="false" -->
                     <asp:RequiredFieldValidator    
                                    ID="nameRequiredFieldValidator"         runat="server" 
                                    validationgroup="UpdatePanelReturnAvailabilityValidation"
                                    ControlToValidate="txtCustomerEmail"    Display="Dynamic"
                                    ErrorMessage="Email can't be blank"     ForeColor="Red"   
                                   
                            ></asp:RequiredFieldValidator>

                    <!--  Email TxtBox Validation PT  2 -->
                    <asp:RegularExpressionValidator     
                                    ID="emailRegularExpressionValidator"    runat="server" 
                                    validationgroup="UpdatePanelReturnAvailabilityValidation"
                                    ControlToValidate="txtCustomerEmail"    Display="Dynamic" 
                                    ErrorMessage="Please enter an email in a valid format"  ForeColor="Red"                                     
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ></asp:RegularExpressionValidator>      
                    
					<asp:Label ID="GordTestLabelRESERVE" runat="server" Text="Label"></asp:Label>
				</ContentTemplate>
			</asp:UpdatePanel>



			
			<asp:UpdatePanel ID="RegisterNewCustomer" runat="server">
				<ContentTemplate>
					<asp:Label ID="lblEnteredCustomerEmail" runat="server" Text="">
						The inner HTML on this label needs to be set to the customer email provided
					</asp:Label>
					<br />
					<asp:Label ID="lblCustomerName" runat="server" Text="Name:  "></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerName" runat="server" validationgroup="RegisterNewCustomerValidation"></asp:TextBox>
					<br />
                                        			
			
                    <!--  txtCustomerName Validation PT  1 -->
                     <asp:RequiredFieldValidator    
                                    ID="RequiredFieldValidator1"          runat="server" 
                                    validationgroup="RegisterNewCustomerValidation"
                                    ControlToValidate="txtCustomerName"    Display="Dynamic"
                                    ErrorMessage="Name can't be blank"     ForeColor="Red"                                   
                            ></asp:RequiredFieldValidator>
					<br />


					<asp:Label ID="lblCustomerPhone" runat="server" Text="Telephone:  "></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerPhone" runat="server" validationgroup="RegisterNewCustomerValidation"></asp:TextBox>
					<br />


                      <!--  txtPhoneNo Validation PT  1 -->
                     <asp:RequiredFieldValidator    
                                    ID="RequiredFieldValidator2"          runat="server" 
                                    validationgroup="RegisterNewCustomerValidation"
                                    ControlToValidate="txtCustomerPhone"  Display="Dynamic"
                                    ErrorMessage="Telephone Phone Number can't be blank"    ForeColor="Red"                                     
                            ></asp:RequiredFieldValidator>
					<br />
					<asp:Label ID="GordTestLabelNewCustomer" runat="server" Text="Label"></asp:Label>




					<asp:Label ID="lblCustomerCountry" runat="server" Text="Country"></asp:Label> &nbsp &nbsp
					<asp:TextBox ID="txtCustomerCountry" runat="server"></asp:TextBox>
					<asp:DropDownList ID="ddlCountry" runat="server">
                        
                    </asp:DropDownList>
					<br />
					
					<asp:Button ID="CreateNewAccount" runat="server" Text="Create New Account" OnClick="CreateNewAccount_Click" validationgroup="RegisterNewCustomerValidation" />
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
