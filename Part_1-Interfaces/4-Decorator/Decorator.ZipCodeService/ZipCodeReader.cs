using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Decorator.ZipCodeService
{
    /// <summary>
    /// Class that will read CSV file of zip code information int a list of ZipCodeInfo objects
    /// </summary>
    /// <remarks>
    /// This class is a helper for the InMemoryZipCodeService object so we can read the zip code
    /// date from a file and populate the in memory date structure
    /// </remarks>
    internal class ZipCodeReader
    {



        public List<ZipCodeInfo> LoadZipCodes(String filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("Decorator.ZipCodeService.ZipCodes.csv");
            using (StreamReader reader = new StreamReader(resourceStream, Encoding.UTF8))
            //using (StreamReader reader = File.OpenText(filename))
            {
                Configuration config = new Configuration();
                config.RegisterClassMap<UsZipCodeMap>();
                var csv = new CsvReader(reader, config);
                var records = csv.GetRecords<ZipCodeInfo>();
                return records.ToList();
            }
        }


    }

    /// <summary>
    /// Helper class for the CsvReader to be able to map the input data into the ZipCodeInfo object
    /// </summary>
    public sealed class UsZipCodeMap : ClassMap<ZipCodeInfo>
    {
        public UsZipCodeMap()
        {
            Map(m => m.ZipCode).Name("Zipcode");
            Map(m => m.City).Name("City");
            Map(m => m.State).Name("State");
            Map(m => m.Latitude).Name("Latitude");
            Map(m => m.Longitude).Name("Longitude");
        }
    }
}
