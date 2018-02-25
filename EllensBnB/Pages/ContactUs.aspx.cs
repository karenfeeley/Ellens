﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Data;              //  this is needed  !!!

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


            string connectionString = "Server = tcp:gordserver1.database.windows.net,1433;Initial Catalog = TestForWebCA_2; Integrated Security=False;Persist Security Info=False;User ID = gordserver1admin; Password=HelpMeOut!;";




            string dbName = "SATURDAY Test Name";
            string dbEmail = "SATURDAY Test Email"; 


            // Insert basic customer info into database           
            // Create db connection
            using (SqlConnection conn = new SqlConnection(connectionString))
            {

                using (SqlCommand sqlCommand = new SqlCommand("uspInsertCustomer_No_1", conn))
                {
                    // Define command type
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    // Add input parameter @Name for stored proceedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 255));
                    sqlCommand.Parameters["@Name"].Value = dbName;

                    // Add input parameter @Email for stored procedure & specify its value
                    sqlCommand.Parameters.Add(new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50));
                    sqlCommand.Parameters["@CustomerEmail"].Value = dbEmail;


                    // Execute stored procedure with customer data
                    //try  //try/Catch
                    //{//try/Catch
                    conn.Open();
                    // run command
                    sqlCommand.ExecuteNonQuery();
                    //lblDisplayStatus.Text = string.Format("New account created:\nName: {0}\nEmail: {1}",
                        //dbName, dbEmail);
                    //}//try/Catch
                    //catch//try/Catch
                    //{
                    //   lblDisplayStatus.Text = "Error - no data saved - please try again";

                    //}//try/Catch
                    //finally//try/Catch
                    //{//try/Catch
                    conn.Close();
                    //}//try/Catch
                } // end inner Using Statement                
            } // end outer Using Statement



        }// gordon test





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