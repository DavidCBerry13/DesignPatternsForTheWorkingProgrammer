using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.ZipCodeService
{
    public interface IZipCodeService
    {
        /// <summary>
        /// Gets information about the given zip code.  If the zip code is not found, then null is returned
        /// </summary>
        /// <param name="zipCode">A String of the zip code</param>
        /// <returns>A UsZipCode object that contains information about the zip code or null if the zip code is not found</returns>
        ZipCodeInfo GetZipCode(String zipCode);

    }
}
