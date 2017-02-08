using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace _7SigmaTest
{
    public class FeatureDeleteHashSet
    {
        private

        static void Main(string[] args)
        {
            string FeaturesToDeletePath = @"FeaturesToDelete.txt";
            string FeaturesPath = @"Features.txt";
            string Output = @"Output.txt";
            int Deleted = 0;

            HashSet<string> Features = new HashSet<string>();
            try
            {
                if (File.Exists(FeaturesPath))
                {
                    Console.WriteLine("Features file found");

                    using (StreamReader FeaturesStream = new StreamReader(FeaturesPath))
                    {
                        while (FeaturesStream.Peek() >= 0)
                        {
                            var FeaturesLine = FeaturesStream.ReadLine().ToString().Substring(0, 8);
                            Features.Add(FeaturesLine);
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
                if (File.Exists(FeaturesToDeletePath))
                {
                    Console.WriteLine("Features to delete file found");

                    // setup the output file to write into
                    var OutputStream = new StreamWriter(Output);
                    using (StreamReader FeaturesToDeleteStream = new StreamReader(FeaturesToDeletePath))
                    {
                        while (FeaturesToDeleteStream.Peek() >= 0)
                        {
                            var FeaturesToDeleteLine = FeaturesToDeleteStream.ReadLine().ToString();

                            if (Features.Contains(FeaturesToDeleteLine))
                            {
                                Deleted++;
                            }
                            else
                            {
                                OutputStream.WriteLine(FeaturesToDeleteLine);
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
            Console.WriteLine("Success. " + "Deleted " + Deleted.ToString() + " records");
            Console.WriteLine("Feature Delete operation completed in: " + runtime);
            Console.ReadLine();

        }
    }
}