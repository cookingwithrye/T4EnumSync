using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace T4EnumSync
{
    class Program
    {
        /// <summary>
        /// Open a db connection
        /// </summary>
        static SqlConnection GetConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["T4EnumSyncDB"].ConnectionString);
        }

        /// <summary>
        /// Retrieve all vehicle objects from the database
        /// </summary>
        static IEnumerable<Vehicle> GetAllVehicles()
        {
            using (var db = GetConnection())
            {
                var sqlCommand = new SqlCommand(
                    "SELECT VehicleID, OwnerName, ColorID FROM [Vehicle]", db);

                db.Open();
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    //construct our vehicle object
                    yield return new Vehicle()
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Owner = (string)reader["OwnerName"],

                        //very dangerous assumption made here, that int values will always stay aligned with the enum values
                        VehicleColor = (Color)reader["ColorID"]
                    };
                }
            }
        }

        static void Main(string[] args)
        {
            bool warnFlag = false;

            //our business logic will be a validator to ensure that white vehicles aren't present in the database.
            foreach (var vehicle in GetAllVehicles())
                if (vehicle.VehicleColor == Color.White) //this is the type of logic thsat we want to protect ourselves against constant changes
                {
                    Console.WriteLine("There is a white vehicle owned by {0} with ID: '{1}' - I suggest deleting it.",
                        vehicle.Owner, vehicle.VehicleID);
                    warnFlag = true;
                }

            if (!warnFlag)
                Console.WriteLine("Excellent. No white vehicles were detected in the database...");

            Console.ReadLine();
        }
    }
}
