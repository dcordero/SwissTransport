using System;
namespace SwissTransportPortableLibrary
{
    public enum Transportation 
    { 
        IceTgvRj, 
        EcIc, 
        Ir, 
        ReD, 
        Ship, 
        SSNR, 
        Bus,
        Cableway,
        ArzExt,
        TramwayUnderground
    };

    internal static class TransportationMethods
    {
        public static String GetString(this Transportation transportation)
        {
            switch (transportation)
            {
                case Transportation.IceTgvRj:
                    return "ice_tgv_rj";
                case Transportation.EcIc:
                    return "ec_ic";
                case Transportation.Ir:
                    return "ir";
				case Transportation.ReD:
                    return "re_d";
				case Transportation.Ship:
                    return "ship";
				case Transportation.SSNR:
                    return "s_sn_r";
				case Transportation.Bus:
                    return "bus";
				case Transportation.Cableway:
                    return "cableway";
				case Transportation.ArzExt:
                    return "arz_ext";
				case Transportation.TramwayUnderground:
                    return "tramway_underground";
                default:
                    return "";
			}
        }
    }
}
