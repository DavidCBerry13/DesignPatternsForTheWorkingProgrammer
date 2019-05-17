using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.ZipCodeService
{
    public class ZipCodeInfo
    {

        /// <summary>
        /// The 5 digit Zip Code
        /// </summary>
        public String ZipCode { get; set; }

        /// <summary>
        /// The primary postal city for this zip code
        /// </summary>
        public String City { get; set; }

        /// <summary>
        /// The two letter abbreviation for the US state or territory for the zip code
        /// </summary>
        public String State { get; set; }

        /// <summary>
        /// The latitude of the approximate center of this zip code
        /// </summary>
        /// <remarks>
        /// The value can sometimes be null when the zip code is an armed forces zip code (APO and AFO)
        /// </remarks>
        public double? Latitude { get; set; }

        /// <summary>
        /// The longitude of the approximate center of this zip code
        /// </summary>
        /// <remarks>
        /// This value can sometimes be null when the zip code is an armed forces zip code (APO and AFO)
        /// </remarks>
        public double? Longitude { get; set; }


    }
}
