using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EllensBnB.Pages
{
	public partial class ContactUs : System.Web.UI.Page
	{
		//static variables
		public static List<DateTime> userCheckDateAvailability = new List<DateTime>();



		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void SelectMakeBooking_Click(object sender, EventArgs e)
		{
			if (!UpdatePanelCheckDatesAreAvailable.Visible)
			{
				UpdatePanelCheckDatesAreAvailable.Visible = true;
				SelectMakeBooking.Visible = false;
				SelectExistingBooking.Visible = false;
			}
		}

		protected void SelectExistingBooking_Click(object sender, EventArgs e)
		{

		}

		protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
		{
			
			//make only days after today bookable
			if (e.Day.Date.CompareTo(DateTime.Today)<1)
			{
				e.Day.IsSelectable = false;
			}


		}

		protected void Calendar1_SelectionChanged(object sender, EventArgs e)
		{

		}
	}
}