using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DependencyInjection.ZipCodeService
{
    internal class ZipCodeService : IZipCodeService
    {

        public ZipCodeService(List<ZipCodeInfo> zipCodes)
        {
            this.zipCodeTable = new Dictionary<string, ZipCodeInfo>();

            zipCodes.ForEach(x => this.zipCodeTable.Add(x.ZipCode, x));
        }



        private Dictionary<String, ZipCodeInfo> zipCodeTable;




        /// <summary>
        /// Looks up a zip code and returns information about it
        /// </summary>
        /// <param name="zipCode">A String of the 5 digit us zip code</param>
        /// <returns>A UsZipCode object or null if the zip code is not found</returns>
        public ZipCodeInfo GetZipCode(String zipCode)
        {
            // Make sure we have valid input
            if (!Regex.IsMatch(zipCode, "^\\d{5}$"))
                throw new ArgumentException("The zip code must be exactly 5 digits");

            if (!this.zipCodeTable.ContainsKey(zipCode))
                return null;

            return this.zipCodeTable[zipCode];
        }

    }
}
