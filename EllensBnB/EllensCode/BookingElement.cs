using System;
using System.Collections.Generic;
using System.Linq;
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
	}
}