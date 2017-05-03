using System;
namespace SwissTransportPortableLibrary
{

    public enum StationboardType
    {
        Departure,
        Arrival
    };

    static class StationboardTypeMethods
    {
        public static String GetString(this StationboardType transportation)
        {
            switch (transportation)
            {
                case StationboardType.Departure:
                    return "departure";
                case StationboardType.Arrival:
                    return "arrival";
                default:
                    throw new Exception();
            }
        }
    }
}
