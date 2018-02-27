using EllensBnB.EllensCode;
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
			EllenCalendar eCal = new EllenCalendar();
			eCal.SetSelectableDates(e);			
		}
	}
}