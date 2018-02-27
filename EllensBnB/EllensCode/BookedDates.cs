using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EllensBnB.EllensCode
{
	public class BookedDates
	{
		public DateTime BookedDate { get; set; }
		public int RoomID { get; set; }

		public BookedDates(DateTime date, int roomID)
		{
			BookedDate = date;
			RoomID = roomID;
		}
	}
}