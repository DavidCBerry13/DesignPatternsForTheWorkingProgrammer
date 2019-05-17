using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection.ZipCodeService
{
    public class ZipCodeServiceFactory
    {

        private static Lazy<IZipCodeService> zipCodeProvider = new Lazy<IZipCodeService>(CreateZipCodeProvider);



        public static IZipCodeService ZipCodeService
        {
            get { return zipCodeProvider.Value; }
        }



        private static IZipCodeService CreateZipCodeProvider()
        {
            ZipCodeReader reader = new ZipCodeReader();
            List<ZipCodeInfo> zipCodes = reader.LoadZipCodes("ZipCodes.csv");

            ZipCodeService service = new ZipCodeService(zipCodes);
            return service;
        }

    }
}
