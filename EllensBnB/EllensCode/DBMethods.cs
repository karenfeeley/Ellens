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

		//calls uspGetDatesReserved - no parameters required.  Returns all booked dates and associated roomID
		public static List<BookedDates> GetDatesReserved()
		{
			SqlConnection dbConnection = new SqlConnection(connectionString);
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

			return queryResult;

		}
	}
}