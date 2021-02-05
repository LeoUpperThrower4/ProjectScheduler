using PSObjects;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HelperFunctions
{
    public static class Helper
    {
        /// <summary>
        /// Opens the .dat file given the ID
        /// </summary>
        /// <param name="id">ID of the .dat file</param>
        /// <returns>MainProject that was serialized by the SaveFile method if ID was correctly passed. Otherwise, return an empty MainProject class</returns>
        public static MainProject OpenFile(string id)
        {
            try
            {
                // log a message to the user
                Console.WriteLine("Looking for file...");

                // creates a data stream variable using the passed ID
                Stream stream = File.Open($"{id}.dat", FileMode.Open);

                // initializes a binary formatter for desirialization
                var bf = new BinaryFormatter();

                // stores the desirialized data into the mp variable
                var mp = (MainProject)bf.Deserialize(stream);

                // closes the stream
                stream.Close();

                // log a message to the user
                Console.WriteLine("File loaded");


                return mp;
            }
            catch (Exception)
            {
                Console.WriteLine("It seem that this ID does not exist.");
                return new MainProject();
            }
        }

        /// <summary>
        /// Responsable for serializing the MainProject instance passed as parameter
        /// </summary>
        /// <param name="mainP">file to be serialized</param>
        public static void SaveFile(MainProject mainP)
        {

            // log a message to the user
            Console.WriteLine("Saving...");

            // starts a stream of data for the saving
            Stream stream = File.Open($"{mainP.ID}.dat", FileMode.Create);

            // instaciates a binary formatter
            var bf = new BinaryFormatter();

            // serialize the MainProject class given as parameter
            bf.Serialize(stream, mainP);

            // closes the stream of data
            stream.Close();

            // reminds the user of it's ID and log a message to the user
            Console.WriteLine($"This is your ID. Keep it safe, that's what's needed to see your projects later. ID: {mainP.ID}.\nSaved");
        }

    }
}
