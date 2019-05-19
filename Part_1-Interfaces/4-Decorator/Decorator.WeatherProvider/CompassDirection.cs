using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.WeatherProvider
{
    public class CompassDirection
    {

        private CompassDirection(String directionCode, String directionName)
        {
            this.Abbreviation = directionCode;
            this.Name = directionName;
        }


        public String Abbreviation { get; private set; }

        public String Name { get; private set; }


        #region Object Definitions

        public static readonly CompassDirection NORTH = new CompassDirection("N", "North");

        public static readonly CompassDirection NORTH_NORTHEAST = new CompassDirection("NNE", "North Northeast");

        public static readonly CompassDirection NORTHEAST = new CompassDirection("NE", "Northeast");

        public static readonly CompassDirection EAST_NORTHEAST = new CompassDirection("ENE", "East Northeast");

        public static readonly CompassDirection EAST = new CompassDirection("E", "East Northeast");

        public static readonly CompassDirection EAST_SOUTHEAST = new CompassDirection("EEE", "East Southeast");

        public static readonly CompassDirection SOUTHEAST = new CompassDirection("SE", "Southeast");

        public static readonly CompassDirection SOUTH_SOUTHEAST = new CompassDirection("SSE", "South Southeast");

        public static readonly CompassDirection SOUTH = new CompassDirection("S", "South");

        public static readonly CompassDirection SOUTH_SOUTHWEST = new CompassDirection("SSW", "South Southwest");

        public static readonly CompassDirection SOUTHWEST = new CompassDirection("SW", "Southwest");

        public static readonly CompassDirection WEST_SOUTHWEST = new CompassDirection("WSW", "West Southwest");

        public static readonly CompassDirection WEST = new CompassDirection("W", "West");

        public static readonly CompassDirection WEST_NORTHWEST = new CompassDirection("WNW", "West Northwest");

        public static readonly CompassDirection NORTHWEST = new CompassDirection("NW", "Northwest");

        public static readonly CompassDirection NORTH_NORTHWEST = new CompassDirection("NNW", "North Northwest");

        #endregion



        public static CompassDirection Decode(double degrees)
        {
            if (degrees > 348.75 && degrees <= 360 || degrees >= 0 && degrees <= 11.25)
                return NORTH;
            else if (degrees > 11.25 && degrees <= 33.75)
                return NORTH_NORTHEAST;
            else if (degrees > 33.75 && degrees <= 56.25)
                return NORTHEAST;
            else if (degrees > 56.25 && degrees <= 78.75)
                return EAST_NORTHEAST;
            else if (degrees > 78.75 && degrees <= 101.25)
                return EAST;
            else if (degrees > 101.25 && degrees <= 123.75)
                return EAST_SOUTHEAST;
            else if (degrees > 123.75 && degrees <= 146.25)
                return SOUTHEAST;
            else if (degrees > 146.25 && degrees <= 168.75)
                return SOUTH_SOUTHEAST;
            else if (degrees > 168.75 && degrees <= 191.25)
                return SOUTH;
            else if (degrees > 191.75 && degrees <= 213.75)
                return SOUTH_SOUTHWEST;
            else if (degrees > 213.75 && degrees <= 236.25)
                return SOUTHWEST;
            else if (degrees > 236.25 && degrees <= 258.75)
                return WEST_SOUTHWEST;
            else if (degrees > 258.75 && degrees <= 281.25)
                return WEST;
            else if (degrees > 281.25 && degrees <= 303.75)
                return WEST_NORTHWEST;
            else if (degrees > 303.75 && degrees <= 326.25)
                return NORTHWEST;
            else
                return NORTH_NORTHWEST;
        }

    }
}
