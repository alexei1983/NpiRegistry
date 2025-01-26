
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Represents an address purpose in the NPI registry.
    /// </summary>
    internal static class NpiAddressPurpose
    {
        /// <summary>
        /// Address represents the physical location of the entity.
        /// </summary>
        public const string Location = "LOCATION";

        /// <summary>
        /// Address represents a mailing address for the entity.
        /// </summary>
        public const string Mailing = "MAILING";

        /// <summary>
        /// Address represents the primary address for the entity.
        /// </summary>
        public const string Primary = "PRIMARY";

        /// <summary>
        /// Address represents a secondary address for the entity.
        /// </summary>
        public const string Secondary = "SECONDARY";


        static readonly string[] values = [Location, Mailing, Primary, Secondary];

        /// <summary>
        /// Determines whether or not the specified value is a valid NPI address purpose.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>True if the value is a valid NPI address purpose, else false.</returns>
        public static bool IsValid(string value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return values.Contains(value.ToUpper());
        }
    }
}
