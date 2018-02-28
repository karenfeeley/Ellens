using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace EllensBnB.EllensCode
{
	public class DBMethods
	{
		static string connectionString = "Server = tcp:karensserver.database.windows.net,1433; Initial Catalog = EllensBnB; Persist Security Info = False; User ID = ellenadminlogin; Password =PCEc2018; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
		static SqlConnection dbConnection = new SqlConnection(connectionString);

		//calls uspGetDatesReserved - no parameters required.  Returns all booked dates and associated roomID
		public static List<BookedDates> GetDatesReserved()
		{
			SqlCommand getDatesReserved = new SqlCommand("uspGetDatesReserved", dbConnection);
			getDatesReserved.CommandType = CommandType.StoredProcedure;
			List<BookedDates> queryResult = new List<BookedDates>();
			try
			{
				dbConnection.Open();
				SqlDataReader reader = getDatesReserved.ExecuteReader();
				while (reader.Read())
				{
					BookedDates booking = new BookedDates(reader.GetDateTime(0), reader.GetInt32(1));
					queryResult.Add(booking);

				}
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				dbConnection.Close();
			}

			return queryResult;
		}


		//call uspCreateBookingID
		public static int CreateBookingID(string custEmail, string paidStatus = null, string bookingNotes = null)
		{
			int result;
			SqlCommand cmdCreateBookingID = new SqlCommand("uspCreateBookingID", dbConnection);
			cmdCreateBookingID.CommandType = CommandType.StoredProcedure;
			SqlParameter customerEmail = new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50);
			cmdCreateBookingID.Parameters.Add(customerEmail);
			SqlParameter paid = new SqlParameter("@Paid", SqlDbType.VarChar, 20);
			cmdCreateBookingID.Parameters.Add(paid);
			SqlParameter notes = new SqlParameter("@BookingNotes", SqlDbType.VarChar, 255);
			cmdCreateBookingID.Parameters.Add(notes);

			var bookingID = new SqlParameter("@BookingID", SqlDbType.Int);
			bookingID.Direction = ParameterDirection.ReturnValue;
			cmdCreateBookingID.Parameters.Add(bookingID);

			//var bookingID = cmdCreateBookingID.Parameters.Add(new SqlParameter("@BookingID", SqlDbType.Int));
			//bookingID.Direction = ParameterDirection.ReturnValue;
			try
			{
				dbConnection.Open();
				customerEmail.Value = custEmail;
				paid.Value = paidStatus;
				notes.Value = bookingNotes;
				cmdCreateBookingID.ExecuteNonQuery();
				//var returnedBookingID = bookingID.Value;
				result = (int)bookingID.Value;
			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				dbConnection.Close();
			}

			return result;
		}

		//call uspCreateBookingElements - Create one row in the table
		public static void CreateBookingElements(int bookingID, int roomID, DateTime date, int guests, decimal rate)
		{
			SqlCommand cmdCreateBookingElements = new SqlCommand("uspCreateBookingElements", dbConnection);
			cmdCreateBookingElements.CommandType = CommandType.StoredProcedure;
			SqlParameter pBookingID = new SqlParameter("@BookingID", SqlDbType.Int);
			cmdCreateBookingElements.Parameters.Add(pBookingID);
			SqlParameter pRoomID = new SqlParameter("@RoomID", SqlDbType.Int);
			cmdCreateBookingElements.Parameters.Add(pRoomID);
			SqlParameter pDate = new SqlParameter("@DateReserved", SqlDbType.Date);
			cmdCreateBookingElements.Parameters.Add(pDate);
			SqlParameter pGuest = new SqlParameter("NumberOfGuests", SqlDbType.Int);
			cmdCreateBookingElements.Parameters.Add(pGuest);
			SqlParameter pRate = new SqlParameter("@RoomRate", SqlDbType.Decimal);
			cmdCreateBookingElements.Parameters.Add(pRate);
			try
			{
				dbConnection.Open();
				pBookingID.Value = bookingID;
				pRoomID.Value = roomID;
				pDate.Value = date;
				pGuest.Value = guests;
				pRate.Value = rate;
				cmdCreateBookingElements.ExecuteNonQuery();

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				dbConnection.Close();
			}

		}

		//call uspCreateBookingElements - Create one or many rows in the table
		public static void CreateBookingElements(List<BookingElement> bookingElements)
		{
			SqlCommand cmdCreateBookingElements = new SqlCommand("uspCreateBookingElements", dbConnection);
			cmdCreateBookingElements.CommandType = CommandType.StoredProcedure;
			SqlParameter pBookingID = new SqlParameter("@BookingID", SqlDbType.Int);
			cmdCreateBookingElements.Parameters.Add(pBookingID);
			SqlParameter pRoomID = new SqlParameter("@RoomID", SqlDbType.Int);
			cmdCreateBookingElements.Parameters.Add(pRoomID);
			SqlParameter pDate = new SqlParameter("@DateReserved", SqlDbType.Date);
			cmdCreateBookingElements.Parameters.Add(pDate);
			SqlParameter pGuest = new SqlParameter("NumberOfGuests", SqlDbType.Int);
			cmdCreateBookingElements.Parameters.Add(pGuest);
			SqlParameter pRate = new SqlParameter("@RoomRate", SqlDbType.Decimal);
			cmdCreateBookingElements.Parameters.Add(pRate);
			try
			{
				dbConnection.Open();
				foreach (var bookingElement in bookingElements)
				{
					pBookingID.Value = bookingElement.BookingID;
					pRoomID.Value = bookingElement.RoomID;
					pDate.Value = bookingElement.ReservationDate;
					pGuest.Value = bookingElement.NumberOfGuests;
					pRate.Value = bookingElement.RoomRate;
				}

				cmdCreateBookingElements.ExecuteNonQuery();

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				dbConnection.Close();
			}

		}

		//call uspRetrieveRoomRate - single date
		public static decimal RetrieveRoomRate(int roomID, DateTime reservationDate)
		{
			decimal roomrate;
			SqlCommand cmdRetrieveRoomRate = new SqlCommand("uspRetrieveRoomRate", dbConnection);
			cmdRetrieveRoomRate.CommandType = CommandType.StoredProcedure;
			SqlParameter pRoomID = new SqlParameter("@RoomID", SqlDbType.Int);
			cmdRetrieveRoomRate.Parameters.Add(pRoomID);
			SqlParameter pDate = new SqlParameter("@ReservationDate", SqlDbType.Date);
			cmdRetrieveRoomRate.Parameters.Add(pDate);

			var pRoomRate = new SqlParameter("@RoomRate", SqlDbType.Decimal);
			pRoomRate.Direction = ParameterDirection.ReturnValue;
			cmdRetrieveRoomRate.Parameters.Add(pRoomRate);

			try
			{
				dbConnection.Open();
				pRoomID.Value = roomID;
				pDate.Value = reservationDate;
				cmdRetrieveRoomRate.ExecuteNonQuery();
				roomrate = decimal.Parse(pRoomRate.Value.ToString());

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				dbConnection.Close();
			}

			return roomrate;
		}

		//call uspRetrieveRoomRate - single date
		public static void RetrieveRoomRate(ref List<RoomRateByDate> dates)
		{
			//List<RoomRateByDate> roomRatesForDates = new List<RoomRateByDate>();

			SqlCommand cmdRetrieveRoomRate = new SqlCommand("uspRetrieveRoomRate", dbConnection);
			cmdRetrieveRoomRate.CommandType = CommandType.StoredProcedure;
			SqlParameter pRoomID = new SqlParameter("@RoomID", SqlDbType.Int);
			cmdRetrieveRoomRate.Parameters.Add(pRoomID);
			SqlParameter pDate = new SqlParameter("@ReservationDate", SqlDbType.Date);
			cmdRetrieveRoomRate.Parameters.Add(pDate);

			var pRoomRate = new SqlParameter("@RoomRate", SqlDbType.Decimal);
			pRoomRate.Direction = ParameterDirection.ReturnValue;
			cmdRetrieveRoomRate.Parameters.Add(pRoomRate);

			try
			{
				dbConnection.Open();
				foreach (var item in dates)
				{
					pRoomID.Value = item.RoomID;
					pDate.Value = item.ReservationDate;
					cmdRetrieveRoomRate.ExecuteNonQuery();
					item.RoomRate = decimal.Parse(pRoomRate.Value.ToString());

				}

			}
			catch (Exception)
			{

				throw;
			}
			finally
			{
				dbConnection.Close();
			}

			//return roomrate;
		}


		//calls uspCheckExistingCustomer
		//returns a Customer object if exists and false bool if not existing customer
		public static dynamic CheckExistingCustomer(string custemail)
		{
			SqlCommand cmdCheckExistingCustomer = new SqlCommand("uspCheckExistingCustomer", dbConnection);
			cmdCheckExistingCustomer.CommandType = CommandType.StoredProcedure;
			SqlParameter pCustomerEmail = new SqlParameter("@CustomerEmail", SqlDbType.VarChar, 50);
			cmdCheckExistingCustomer.Parameters.Add(pCustomerEmail);
			Customer checkResult = new Customer();
			bool notCustomer;

			try
			{
				dbConnection.Open();
				pCustomerEmail.Value = custemail;
				SqlDataReader reader = cmdCheckExistingCustomer.ExecuteReader();
				if (reader.HasRows)
				{
					while (reader.Read())
					{
						checkResult.CustomerID = reader.GetInt32(0);
						checkResult.CustomerName = reader.GetString(1);
						checkResult.CustomerCountry = reader.GetString(2);
						checkResult.CustomerEmail = reader.GetString(3);
						checkResult.CustomerPhone = reader.GetString(4);
					}
					return checkResult;
				}
				else
				{
					return notCustomer = false;
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				dbConnection.Close();
			}
		}
	}
}