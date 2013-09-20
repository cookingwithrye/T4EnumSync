﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace T4EnumSync
{
    class Program
    {
        /// <summary>
        /// Open a db connection
        /// </summary>
        static SqlConnection GetConnection()
        {
            return new SqlConnection("T4EnumSyncDB");
        }

        /// <summary>
        /// Retrieve all vehicle objects from the database
        /// </summary>
        static IEnumerable<Vehicle> GetAllVehicles()
        {
            using (var db = GetConnection())
            {
                var sqlCommand = new SqlCommand(
                    "SELECT VehicleID, Owner, VehicleTypeID, ColorID FROM [Vehicle]", db);

                var reader = sqlCommand.ExecuteReader();

                while (reader.NextResult())
                {
                    //construct our vehicle object
                    yield return new Vehicle()
                    {
                        VehicleID = (int)reader["VehicleID"],
                        Owner = (string)reader["Owner"],

                        //very dangerous assumption made here, that int values will always stay aligned with the enum values
                        Type = (VehicleType)reader["VehicleTypeID"],
                        VehicleColor = (Color)reader["ColorID"]
                    };
                }

            }
        }

        /// <summary>
        /// Perform a sanity check that the enum names and underlying values have corresponding entries in the database
        /// </summary>
        static void SanityCheck()
        {
            
        }
        
        static void Main(string[] args)
        {
            SanityCheck();
            
            bool warnFlag = false;
            
            //our business logic will be a validator to ensure that white motorcycles aren't present in the database. They're kind of lame so we don't want them.
            foreach (var vehicle in GetAllVehicles())
                if (vehicle.VehicleColor == Color.White && vehicle.Type == VehicleType.MotorCycle) //this is the type of logic thsat we want to protect ourselves against
                {
                    Console.WriteLine("There is a white motorcycle owned by {0} with ID: '{1}' - I suggest deleting it.",
                        vehicle.Owner, vehicle.VehicleID);
                }

            if (!warnFlag)
                Console.WriteLine("Excellent. No lame vehicles were detected in the database...");

            Console.ReadLine();

            //additional scenario - if we drop the 'White' color and then recreate it, it will have a new id which wasn't accounted for in our enum.
            //no compile-time exception would be thrown, and we'd potentially be left with a runtime error
        }
    }
}
