
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// 
    /// </summary>
    public static class NpiAddressPurpose
    {
        /// <summary>
        /// 
        /// </summary>
        public const string Location = "LOCATION";

        /// <summary>
        /// 
        /// </summary>
        public const string Mailing = "MAILING";

        /// <summary>
        /// 
        /// </summary>
        public const string Primary = "PRIMARY";

        /// <summary>
        /// 
        /// </summary>
        public const string Secondary = "SECONDARY";


        static readonly string[] values = [Location, Mailing, Primary, Secondary];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return values.Contains(value.ToUpper());
        }
    }
}
