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

		//List of dates that gets passed to lstDisplay on Contact
		List<DateTime> userSelectedDate = new List<DateTime>(); //consider moving into method as passed to Session Selected Dates
		protected void EllensCalendar_DayRender(object sender, DayRenderEventArgs e)
		{		
			EllenCalendar eCal = new EllenCalendar();
			eCal.SetSelectableDates(e);

			//List<DateTime> userSelectedDates = new List<DateTime>();
			if (e.Day.IsSelected)
			{
				
				userSelectedDate.Add(e.Day.Date);
				e.Cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#4d88ff"); //bright blue
				e.Cell.BorderColor = System.Drawing.ColorTranslator.FromHtml("#000066"); //navy
				
			}
			Session["SelectedDates"] = userSelectedDate;

		}

		//List<DateTime> selectionChangedDateList;
		protected void EllensCalendar_SelectionChanged(object sender, EventArgs e)
		{

			if (Session["SelectedDates"] != null)
			{
				//selectionChangedDateList = (List<DateTime>)Session["SelectedDates"];
				//foreach (DateTime date in selectionChangedDateList)
				foreach(DateTime date in (List<DateTime>)Session["SelectedDates"])
				{
					EllensWebCalendar.SelectedDates.Add(date);
				}
				userSelectedDate.Clear();
			}
		}

		//List<DateTime> browserSelectedDates;// check if needed...
		List<string> userSelectedDatesForDatabaseQuery = new List<string>(); //TODO Check of dates need to be in string format for SQL query
		protected void btnSelectDates_Click(object sender, EventArgs e)
		{

			if (Session["SelectedDates"] != null)
			{
				//browserSelectedDates = (List<DateTime>)Session["SelectedDates"];
				lstUserSelectedDates.Items.Clear();
				lstUserSelectedDates.Items.Add("You have selected the following dates: ");
				lstUserSelectedDates.Items.Add(string.Empty);

				foreach (DateTime dt in (List<DateTime>)Session["SelectedDates"])
				{
					userSelectedDatesForDatabaseQuery.Add(dt.ToShortDateString());
					lstUserSelectedDates.Items.Add(dt.ToShortDateString());
				}

			}

		}
		
		protected void btnClearDates_Click(object sender, EventArgs e)
		{
			userSelectedDate.Clear();
			EllensWebCalendar.SelectedDates.Clear();
			lstUserSelectedDates.Items.Clear();
			Session["SelectedDates"] = null;
			userSelectedDatesForDatabaseQuery.Clear();
		}

        protected void ReserveSelectedRooms_Click(object sender, EventArgs e)
        {
            //Email TxtBox Validation PT  3

            // disable unobtrusive validation
            UnobtrusiveValidationMode =
                System.Web.UI.UnobtrusiveValidationMode.None;

            // if this is not the first time the page is loading
            // (i.e., the user has already submitted form data)
            if (IsPostBack)
            {
                Validate();  // validate the form

                // if the form is valid
                if (IsValid)
                {
                    // retrieve the values submitted by the user
                    string validEmail = txtCustomerEmail.Text;


                    // show the submitted values
                    GordTestLabelRESERVE.Text = validEmail;
                } // end if
            }
        }
    }
}