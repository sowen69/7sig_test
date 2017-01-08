using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace _7SigmaTest
{
    public class FeatureDelete
    {
        private

        static void Main(string[] args)
        {
            string FeaturesToDeletePath = @"FeaturesToDelete.txt";
            string FeaturesPath = @"Features.txt";
            string Output = @"Output.txt";

            // TODO: get the number of lines in the "FeaturesToDelete.txt" and use that to initialise the array
            string[] FeaturesToDelete = new string[10000];

            try
            {
                if (File.Exists(FeaturesToDeletePath))
                {
                    Console.WriteLine("Features to delete file found");

                    using (StreamReader sr = new StreamReader(FeaturesToDeletePath))
                    {
                        var i = 0;
                        while (sr.Peek() >= 0)
                        {
                            FeaturesToDelete[i] = sr.ReadLine();
                            i++;
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Something meaningfull here
                throw;
            }

            try
            {
                if (File.Exists(FeaturesPath))
                {
                    Console.WriteLine("Features file found");

                    // setup the output file to write into
                    var OutputStream = new StreamWriter(Output);
                    using (StreamReader FeaturesStream = new StreamReader(FeaturesPath))
                    {
                        while (FeaturesStream.Peek() >= 0)
                        {
                            var FeaturesLine = FeaturesStream.ReadLine().ToString();

                            // Grab the first 8 chars of the line
                            var UDB = FeaturesLine.Substring(0, 8);

                            // Check if the GID is present in the delete list
                            var s = from ftd in FeaturesToDelete where (ftd == UDB) select ftd;

                            // If s is empty the record dosen't need deleting so can be written to the update file
                            if (String.IsNullOrEmpty(s.FirstOrDefault()))
                            {
                                OutputStream.WriteLine(FeaturesLine);
                            }
                            else
                            {
                                Console.WriteLine("Deleted UDB: " + s.FirstOrDefault());
                            }
                        }
                    }

                    //Tidy up
                    OutputStream.Close();
                    OutputStream.Dispose();
                }
            }

            catch (Exception)
            {
                // Something meaningfull here
                throw;
            }
            // Display runtime
            var runtime = DateTime.Now - Process.GetCurrentProcess().StartTime;
            Console.WriteLine("Success.");
            Console.WriteLine("Feature Delete operation completed in: " + runtime);
            Console.ReadLine();

        }
    }
}