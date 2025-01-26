
namespace Llc.GoodConsulting.Interfaces.NpiRegistry
{
    /// <summary>
    /// Type of a record in the NPI registry.
    /// </summary>
    internal static class NpiType
    {
        /// <summary>
        /// Record represents an individual.
        /// </summary>
        public const string Individual = "NPI-1";

        /// <summary>
        /// Record represents an organization.
        /// </summary>
        public const string Organization = "NPI-2";

        static readonly string[] values = [Individual, Organization];

        /// <summary>
        /// Determines whether or not the specified value is a valid NPI type.
        /// </summary>
        /// <param name="value">Value to check.</param>
        /// <returns>True if the value is a valid NPI type, else false.</returns>
        public static bool IsValid(string? value)
        {
            if (string.IsNullOrEmpty(value))
                return false;

            return values.Contains(value.ToUpper());
        }
    }
}
