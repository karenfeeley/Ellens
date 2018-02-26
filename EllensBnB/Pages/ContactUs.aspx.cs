using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EllensBnB.Pages
{
	public partial class ContactUs1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void MakeNewReservation_Click(object sender, EventArgs e)
		{

		}

		protected void UpdateExistingReservation_Click(object sender, EventArgs e)
		{

		}

		protected void EllensCalendar_DayRender(object sender, DayRenderEventArgs e)
		{
			//make only days after today bookable
			if (e.Day.Date.CompareTo(DateTime.Today) < 1 )
			{
				e.Day.IsSelectable = false;
				e.Cell.BackColor = System.Drawing.Color.LightGray;
			}
			//make days more than 365 days ahead unbookable		

			DateTime maxBookingDate = DateTime.Today.AddDays(365);
			if (e.Day.Date > maxBookingDate)
			{
				e.Day.IsSelectable = false;
				e.Cell.BackColor = System.Drawing.Color.LightGray;
			}


		}
	}
}