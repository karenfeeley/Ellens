using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EllensBnB.EllensCode
{
	public class BookingElement
	{
		public int BookingID { get; set; }
		public int RoomID { get; set; }
		public DateTime ReservationDate { get; set; }
		public int NumberOfGuests { get; set; }
		public decimal RoomRate { get; set; }

		//added for retrieve BookingExistingBooking as returns all details
		public DateTime DateBookingCreated { get; set; }
		public string Paid { get; set; }
		public string BookingNotes { get; set; }
		public string RoomName { get; set; }
		public string CustomerName { get; set; }
		public string CustomerCountry { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerPhone { get; set; }

		public BookingElement(int bookingID, int roomID, DateTime reservedDate, int noOfGuests, decimal roomRate)
		{
			BookingID = bookingID;
			RoomID = roomID;
			ReservationDate = reservedDate;
			NumberOfGuests = noOfGuests;
			RoomRate = roomRate;
		}

		public BookingElement(int bookingID, int roomID, DateTime reservedDate, int noOfGuests)
		{
			BookingID = bookingID;
			RoomID = roomID;
			ReservationDate = reservedDate;
			NumberOfGuests = noOfGuests;
		}

		public BookingElement()
		{
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(ReservationDate);
			sb.Append(", ");
			sb.Append(BookingID);
			sb.Append(", ");
			sb.Append(DateBookingCreated);
			sb.Append(", ");
			sb.Append(Paid);
			sb.Append(", ");
			sb.Append(RoomID);
			sb.Append(", ");
			sb.Append(NumberOfGuests);
			sb.Append(", ");
			sb.Append(RoomRate);
			sb.Append(", ");
			sb.Append(BookingNotes);
			sb.Append(", ");
			sb.Append(RoomName);
			sb.Append(", ");
			sb.Append(CustomerName);
			sb.Append(", ");
			sb.Append(CustomerCountry);
			sb.Append(", ");
			sb.Append(CustomerEmail);
			sb.Append(", ");
			sb.Append(CustomerPhone);

			return sb.ToString();
		}
	}
}